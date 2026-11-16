using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Bai6_7.DTO;

namespace Bai6_7.DAL
{
    public class PhongKhamDAL
    {
        // 1. Tra cứu bệnh nhân theo SĐT bằng SqlParameter
        public BenhNhanDTO TimBenhNhanTheoSDT(string sdt)
        {
            string sql = "SELECT MaBN, HoTen, SoDienThoai, NamSinh FROM BenhNhan WHERE SoDienThoai = @SDT";
            using (SqlConnection conn = DBConnect.GetConnection())
            using (SqlCommand cmd = new SqlCommand(sql, conn))
            {
                cmd.Parameters.AddWithValue("@SDT", sdt);
                conn.Open();
                using (SqlDataReader r = cmd.ExecuteReader())
                {
                    if (r.Read())
                    {
                        return new BenhNhanDTO
                        {
                            MaBN = r.GetInt32(0),
                            HoTen = r.GetString(1),
                            SoDienThoai = r.GetString(2),
                            NamSinh = r.GetInt32(3)
                        };
                    }
                }
            }
            return null;
        }

        // Thêm bệnh nhân mới và tạo hồ sơ khám
        public int TiepNhanKham(BenhNhanDTO bn, HoSoKhamDTO hsk)
        {
            using (SqlConnection conn = DBConnect.GetConnection())
            {
                conn.Open();
                SqlTransaction trans = conn.BeginTransaction();
                try
                {
                    int maBN = bn.MaBN;
                    // Nếu bệnh nhân mới -> Thêm mới
                    if (maBN == 0)
                    {
                        string sqlBN = "INSERT INTO BenhNhan (HoTen, SoDienThoai, NamSinh) VALUES (@Ten, @SDT, @NamSinh); SELECT CAST(SCOPE_IDENTITY() AS INT);";
                        SqlCommand cmdBN = new SqlCommand(sqlBN, conn, trans);
                        cmdBN.Parameters.AddWithValue("@Ten", bn.HoTen);
                        cmdBN.Parameters.AddWithValue("@SDT", bn.SoDienThoai);
                        cmdBN.Parameters.AddWithValue("@NamSinh", bn.NamSinh);
                        maBN = (int)cmdBN.ExecuteScalar();
                    }

                    // Tạo HoSoKham
                    string sqlHS = "INSERT INTO HoSoKham (MaBN, NgayKham, TrieuChung, ChanDoan) VALUES (@MaBN, GETDATE(), @TrieuChung, N''); SELECT CAST(SCOPE_IDENTITY() AS INT);";
                    SqlCommand cmdHS = new SqlCommand(sqlHS, conn, trans);
                    cmdHS.Parameters.AddWithValue("@MaBN", maBN);
                    cmdHS.Parameters.AddWithValue("@TrieuChung", hsk.TrieuChung);
                    int maHoSo = (int)cmdHS.ExecuteScalar();

                    trans.Commit();
                    return maHoSo;
                }
                catch
                {
                    trans.Rollback();
                    throw;
                }
            }
        }

        public DataTable GetDanhSachHoSoKham()
        {
            string sql = @"SELECT hs.MaHoSo, bn.HoTen, bn.SoDienThoai, hs.NgayKham, hs.TrieuChung, hs.ChanDoan
                           FROM HoSoKham hs INNER JOIN BenhNhan bn ON hs.MaBN = bn.MaBN
                           ORDER BY hs.MaHoSo DESC";
            using (SqlConnection conn = DBConnect.GetConnection())
            {
                SqlDataAdapter da = new SqlDataAdapter(sql, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }

        // 2. Kê đơn thuốc & Xuất kho bằng SqlTransaction
        public int LuuVaXuatDonThuoc(int maHoSo, string chanDoan, decimal tienKham, decimal tongTien, List<ChiTietDonThuocDTO> dsChiTiet)
        {
            using (SqlConnection conn = DBConnect.GetConnection())
            {
                conn.Open();
                SqlTransaction trans = conn.BeginTransaction();
                try
                {
                    // Cập nhật chẩn đoán vào HoSoKham
                    string sqlUpdateHS = "UPDATE HoSoKham SET ChanDoan = @ChanDoan WHERE MaHoSo = @MaHoSo";
                    SqlCommand cmdHS = new SqlCommand(sqlUpdateHS, conn, trans);
                    cmdHS.Parameters.AddWithValue("@ChanDoan", chanDoan);
                    cmdHS.Parameters.AddWithValue("@MaHoSo", maHoSo);
                    cmdHS.ExecuteNonQuery();

                    // Bước 1: Tạo bản ghi DonThuoc
                    string sqlDon = @"INSERT INTO DonThuoc (MaHoSo, TienKham, TongTien, TrangThai) 
                                      VALUES (@MaHoSo, @TienKham, @TongTien, N'Chờ lấy thuốc');
                                      SELECT CAST(SCOPE_IDENTITY() AS INT);";
                    SqlCommand cmdDon = new SqlCommand(sqlDon, conn, trans);
                    cmdDon.Parameters.AddWithValue("@MaHoSo", maHoSo);
                    cmdDon.Parameters.AddWithValue("@TienKham", tienKham);
                    cmdDon.Parameters.AddWithValue("@TongTien", tongTien);
                    int maDon = (int)cmdDon.ExecuteScalar();

                    // Bước 2 & 3: Lưu từng ChiTietDonThuoc và Trừ kho
                    foreach (var ct in dsChiTiet)
                    {
                        // Kiểm tra tồn kho trước khi trừ
                        string sqlCheckTon = "SELECT SoLuongTon FROM Thuoc WHERE MaThuoc = @MaThuoc";
                        SqlCommand cmdCheck = new SqlCommand(sqlCheckTon, conn, trans);
                        cmdCheck.Parameters.AddWithValue("@MaThuoc", ct.MaThuoc);
                        int tonHienTai = (int)cmdCheck.ExecuteScalar();

                        if (tonHienTai < ct.SoLuong)
                        {
                            throw new Exception($"Thuốc '{ct.TenThuoc}' chỉ còn {tonHienTai} {ct.DonViTinh}, không đủ số lượng kê ({ct.SoLuong})! Giao dịch đã được hoàn tác (Rollback).");
                        }

                        // Tạo bản ghi ChiTietDonThuoc
                        string sqlCT = "INSERT INTO ChiTietDonThuoc (MaDon, MaThuoc, SoLuong, LieuDung) VALUES (@MaDon, @MaThuoc, @SL, @LieuDung)";
                        SqlCommand cmdCT = new SqlCommand(sqlCT, conn, trans);
                        cmdCT.Parameters.AddWithValue("@MaDon", maDon);
                        cmdCT.Parameters.AddWithValue("@MaThuoc", ct.MaThuoc);
                        cmdCT.Parameters.AddWithValue("@SL", ct.SoLuong);
                        cmdCT.Parameters.AddWithValue("@LieuDung", ct.LieuDung);
                        cmdCT.ExecuteNonQuery();

                        // Trừ SoLuongTon
                        string sqlTruKho = "UPDATE Thuoc SET SoLuongTon = SoLuongTon - @SL WHERE MaThuoc = @MaThuoc";
                        SqlCommand cmdKho = new SqlCommand(sqlTruKho, conn, trans);
                        cmdKho.Parameters.AddWithValue("@SL", ct.SoLuong);
                        cmdKho.Parameters.AddWithValue("@MaThuoc", ct.MaThuoc);
                        cmdKho.ExecuteNonQuery();
                    }

                    trans.Commit();
                    return maDon;
                }
                catch
                {
                    // Bước 4: Rollback toàn bộ nếu có bất kỳ lỗi nào
                    trans.Rollback();
                    throw;
                }
            }
        }

        // 3. Thanh toán đơn thuốc
        public DataTable GetDanhSachDonThuoc()
        {
            string sql = @"SELECT dt.MaDon, bn.HoTen AS TenBenhNhan, hs.ChanDoan, dt.TienKham, dt.TongTien, dt.TrangThai
                           FROM DonThuoc dt
                           INNER JOIN HoSoKham hs ON dt.MaHoSo = hs.MaHoSo
                           INNER JOIN BenhNhan bn ON hs.MaBN = bn.MaBN
                           ORDER BY dt.MaDon DESC";
            using (SqlConnection conn = DBConnect.GetConnection())
            {
                SqlDataAdapter da = new SqlDataAdapter(sql, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }

        public bool ThanhToanDonThuoc(int maDon)
        {
            string sql = "UPDATE DonThuoc SET TrangThai = N'Đã thanh toán' WHERE MaDon = @MaDon";
            using (SqlConnection conn = DBConnect.GetConnection())
            using (SqlCommand cmd = new SqlCommand(sql, conn))
            {
                cmd.Parameters.AddWithValue("@MaDon", maDon);
                conn.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }
    }
}