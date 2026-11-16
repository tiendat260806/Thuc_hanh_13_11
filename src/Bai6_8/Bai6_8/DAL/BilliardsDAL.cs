
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace Bai6_8.DAL
{
    public class BilliardsDAL
    {
        public DataTable GetAllBanBida()
        {
            return DatabaseHelper.ExecuteQuery("SELECT MaBan, TenBan, LoaiBan, GiaTheoGio, TrangThai FROM BanBida");
        }

        public DataTable GetAllMenuDichVu()
        {
            return DatabaseHelper.ExecuteQuery("SELECT MaDV, TenDV, DonGia, TonKho FROM MenuDichVu");
        }

        // Mở bàn & tạo hóa đơn mới (Transaction)
        public bool OpenTable(int maBan, out int newMaHD)
        {
            newMaHD = 0;
            using (SqlConnection conn = new SqlConnection(DatabaseHelper.ConnectionString))
            {
                conn.Open();
                SqlTransaction trans = conn.BeginTransaction();
                try
                {
                    string sqlBan = "UPDATE BanBida SET TrangThai = N'Đang chơi' WHERE MaBan = @MaBan";
                    using (SqlCommand cmdBan = new SqlCommand(sqlBan, conn, trans))
                    {
                        cmdBan.Parameters.AddWithValue("@MaBan", maBan);
                        cmdBan.ExecuteNonQuery();
                    }

                    string sqlHD = @"INSERT INTO HoaDon (MaBan, GioBatDau, TrangThai) 
                                     VALUES (@MaBan, GETDATE(), 0);
                                     SELECT SCOPE_IDENTITY();";
                    using (SqlCommand cmdHD = new SqlCommand(sqlHD, conn, trans))
                    {
                        cmdHD.Parameters.AddWithValue("@MaBan", maBan);
                        newMaHD = Convert.ToInt32(cmdHD.ExecuteScalar());
                    }

                    trans.Commit();
                    return true;
                }
                catch
                {
                    trans.Rollback();
                    return false;
                }
            }
        }

        // Lấy hóa đơn chưa thanh toán của bàn
        public DataTable GetActiveBillByTable(int maBan)
        {
            string sql = "SELECT TOP 1 MaHD, MaBan, GioBatDau FROM HoaDon WHERE MaBan = @MaBan AND TrangThai = 0 ORDER BY MaHD DESC";
            SqlParameter[] param = { new SqlParameter("@MaBan", maBan) };
            return DatabaseHelper.ExecuteQuery(sql, param);
        }

        // Nạp chi tiết dịch vụ theo Disconnected Model (SqlDataAdapter + DataTable)
        public DataTable GetChiTietHoaDon(int maHD)
        {
            string sql = @"
                SELECT ct.MaDV, dv.TenDV, ct.SoLuong, ct.DonGia, (ct.SoLuong * ct.DonGia) AS ThanhTien
                FROM ChiTietHoaDon ct
                JOIN MenuDichVu dv ON ct.MaDV = dv.MaDV
                WHERE ct.MaHD = @MaHD";
            SqlParameter[] param = { new SqlParameter("@MaHD", maHD) };
            return DatabaseHelper.ExecuteQuery(sql, param);
        }

        // Thêm món mới hoặc tăng số lượng món đã gọi
        public bool AddOrIncreaseService(int maHD, int maDV, int soLuong, decimal donGia)
        {
            string checkSql = "SELECT COUNT(*) FROM ChiTietHoaDon WHERE MaHD = @MaHD AND MaDV = @MaDV";
            SqlParameter[] pCheck = { new SqlParameter("@MaHD", maHD), new SqlParameter("@MaDV", maDV) };
            int exists = Convert.ToInt32(DatabaseHelper.ExecuteScalar(checkSql, pCheck));

            if (exists > 0)
            {
                string updateSql = "UPDATE ChiTietHoaDon SET SoLuong = SoLuong + @SoLuong WHERE MaHD = @MaHD AND MaDV = @MaDV";
                SqlParameter[] pUp = {
                    new SqlParameter("@SoLuong", soLuong),
                    new SqlParameter("@MaHD", maHD),
                    new SqlParameter("@MaDV", maDV)
                };
                return DatabaseHelper.ExecuteNonQuery(updateSql, pUp) > 0;
            }
            else
            {
                string insertSql = "INSERT INTO ChiTietHoaDon (MaHD, MaDV, SoLuong, DonGia) VALUES (@MaHD, @MaDV, @SoLuong, @DonGia)";
                SqlParameter[] pIn = {
                    new SqlParameter("@MaHD", maHD),
                    new SqlParameter("@MaDV", maDV),
                    new SqlParameter("@SoLuong", soLuong),
                    new SqlParameter("@DonGia", donGia)
                };
                return DatabaseHelper.ExecuteNonQuery(insertSql, pIn) > 0;
            }
        }

        // THANH TOÁN HÓA ĐƠN BẰNG SQLTRANSACTION
        public bool Checkout(int maHD, int maBan, decimal tienGioChoi, decimal tienDichVu, out string error)
        {
            error = "";
            using (SqlConnection conn = new SqlConnection(DatabaseHelper.ConnectionString))
            {
                conn.Open();
                SqlTransaction trans = conn.BeginTransaction();
                try
                {
                    // 1. Lấy danh sách các dịch vụ đã gọi trong hóa đơn
                    string getDVSql = "SELECT MaDV, SoLuong FROM ChiTietHoaDon WHERE MaHD = @MaHD";
                    List<KeyValuePair<int, int>> dvList = new List<KeyValuePair<int, int>>();
                    using (SqlCommand cmdGet = new SqlCommand(getDVSql, conn, trans))
                    {
                        cmdGet.Parameters.AddWithValue("@MaHD", maHD);
                        using (SqlDataReader rd = cmdGet.ExecuteReader())
                        {
                            while (rd.Read())
                            {
                                dvList.Add(new KeyValuePair<int, int>(Convert.ToInt32(rd["MaDV"]), Convert.ToInt32(rd["SoLuong"])));
                            }
                        }
                    }

                    // 2. Kiểm tra & Trừ tồn kho (Bỏ qua dịch vụ thuê gậy)
                    foreach (var item in dvList)
                    {
                        string sqlStock = "SELECT TenDV, TonKho FROM MenuDichVu WHERE MaDV = @MaDV";
                        string tenDV = "";
                        int tonKho = 0;
                        using (SqlCommand cmdCheck = new SqlCommand(sqlStock, conn, trans))
                        {
                            cmdCheck.Parameters.AddWithValue("@MaDV", item.Key);
                            using (SqlDataReader rd = cmdCheck.ExecuteReader())
                            {
                                if (rd.Read())
                                {
                                    tenDV = rd["TenDV"].ToString();
                                    tonKho = Convert.ToInt32(rd["TonKho"]);
                                }
                            }
                        }

                        // Bỏ qua trừ kho nếu là dịch vụ thuê gậy
                        bool isRental = tenDV.IndexOf("thuê gậy", StringComparison.OrdinalIgnoreCase) >= 0;
                        if (!isRental)
                        {
                            if (tonKho < item.Value)
                            {
                                trans.Rollback();
                                error = $"Mặt hàng '{tenDV}' chỉ còn tồn {tonKho}, không đủ để xuất {item.Value}!";
                                return false;
                            }

                            string sqlDeduct = "UPDATE MenuDichVu SET TonKho = TonKho - @SoLuong WHERE MaDV = @MaDV";
                            using (SqlCommand cmdDeduct = new SqlCommand(sqlDeduct, conn, trans))
                            {
                                cmdDeduct.Parameters.AddWithValue("@SoLuong", item.Value);
                                cmdDeduct.Parameters.AddWithValue("@MaDV", item.Key);
                                cmdDeduct.ExecuteNonQuery();
                            }
                        }
                    }

                    // 3. Cập nhật hóa đơn đã thanh toán
                    string sqlUpdateHD = @"
                        UPDATE HoaDon 
                        SET GioKetThuc = GETDATE(), TienGioChoi = @TienGio, TienDichVu = @TienDV, TrangThai = 1
                        WHERE MaHD = @MaHD";
                    using (SqlCommand cmdHD = new SqlCommand(sqlUpdateHD, conn, trans))
                    {
                        cmdHD.Parameters.AddWithValue("@TienGio", tienGioChoi);
                        cmdHD.Parameters.AddWithValue("@TienDV", tienDichVu);
                        cmdHD.Parameters.AddWithValue("@MaHD", maHD);
                        cmdHD.ExecuteNonQuery();
                    }

                    // 4. Đổi trạng thái bàn về Trống
                    string sqlFreeBan = "UPDATE BanBida SET TrangThai = N'Trống' WHERE MaBan = @MaBan";
                    using (SqlCommand cmdBan = new SqlCommand(sqlFreeBan, conn, trans))
                    {
                        cmdBan.Parameters.AddWithValue("@MaBan", maBan);
                        cmdBan.ExecuteNonQuery();
                    }

                    trans.Commit();
                    return true;
                }
                catch (Exception ex)
                {
                    trans.Rollback();
                    error = ex.Message;
                    return false;
                }
            }
        }
    }
}