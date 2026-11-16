using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Bai6_6.DTO;

namespace Bai6_6.DAL
{
    public class PhieuMuonDAL
    {
        // 1. Lọc danh sách phiếu mượn theo Độc giả và Trạng thái
        public DataTable LocPhieuMuon(int maDocGia, string trangThai)
        {
            string query = @"
                SELECT pm.MaPhieu, dg.HoTen AS TenDocGia, pm.NgayMuon, pm.HanTra, pm.TrangThai
                FROM PhieuMuon pm
                INNER JOIN DocGia dg ON pm.MaDocGia = dg.MaDocGia
                WHERE (@MaDocGia = 0 OR pm.MaDocGia = @MaDocGia)
                  AND (@TrangThai = N'Tất cả' OR pm.TrangThai = @TrangThai)";

            using (SqlConnection conn = DBConnect.GetConnection())
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@MaDocGia", maDocGia);
                cmd.Parameters.AddWithValue("@TrangThai", trangThai);

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }

        // Lập phiếu mượn mới (kèm trừ tồn kho sách)
        public bool LapPhieuMuon(int maDocGia, DateTime hanTra, int maSach, int soLuong)
        {
            using (SqlConnection conn = DBConnect.GetConnection())
            {
                conn.Open();
                SqlTransaction trans = conn.BeginTransaction();
                try
                {
                    // Thêm phiếu mượn và lấy MaPhieu vừa tạo bằng SCOPE_IDENTITY()
                    string sqlPM = @"INSERT INTO PhieuMuon (MaDocGia, NgayMuon, HanTra, TrangThai) 
                                     VALUES (@MaDocGia, GETDATE(), @HanTra, N'Đang mượn');
                                     SELECT CAST(SCOPE_IDENTITY() AS INT);";
                    SqlCommand cmdPM = new SqlCommand(sqlPM, conn, trans);
                    cmdPM.Parameters.AddWithValue("@MaDocGia", maDocGia);
                    cmdPM.Parameters.AddWithValue("@HanTra", hanTra);
                    int maPhieuMoi = (int)cmdPM.ExecuteScalar();

                    // Thêm chi tiết mượn
                    string sqlCT = "INSERT INTO ChiTietMuon (MaPhieu, MaSach, SoLuong) VALUES (@MaPhieu, @MaSach, @SoLuong)";
                    SqlCommand cmdCT = new SqlCommand(sqlCT, conn, trans);
                    cmdCT.Parameters.AddWithValue("@MaPhieu", maPhieuMoi);
                    cmdCT.Parameters.AddWithValue("@MaSach", maSach);
                    cmdCT.Parameters.AddWithValue("@SoLuong", soLuong);
                    cmdCT.ExecuteNonQuery();

                    // Trừ số lượng sách còn
                    string sqlSach = "UPDATE DauSach SET SoLuongCon = SoLuongCon - @SoLuong WHERE MaSach = @MaSach AND SoLuongCon >= @SoLuong";
                    SqlCommand cmdSach = new SqlCommand(sqlSach, conn, trans);
                    cmdSach.Parameters.AddWithValue("@SoLuong", soLuong);
                    cmdSach.Parameters.AddWithValue("@MaSach", maSach);
                    if (cmdSach.ExecuteNonQuery() == 0)
                        throw new Exception("Số lượng sách trong kho không đủ!");

                    trans.Commit();
                    return true;
                }
                catch
                {
                    trans.Rollback();
                    throw;
                }
            }
        }

        // 2. Thực hiện trả sách (Parameterized SQL UPDATE + Cộng lại SoLuongCon)
        public bool TraSach(int maPhieu)
        {
            using (SqlConnection conn = DBConnect.GetConnection())
            {
                conn.Open();
                SqlTransaction trans = conn.BeginTransaction();
                try
                {
                    // Bước A: Cộng lại SoLuongCon cho các đầu sách thuộc phiếu này
                    string sqlCongKho = @"
                        UPDATE ds
                        SET ds.SoLuongCon = ds.SoLuongCon + ct.SoLuong
                        FROM DauSach ds
                        INNER JOIN ChiTietMuon ct ON ds.MaSach = ct.MaSach
                        INNER JOIN PhieuMuon pm ON ct.MaPhieu = pm.MaPhieu
                        WHERE pm.MaPhieu = @MaPhieu AND pm.TrangThai <> N'Đã trả'";

                    SqlCommand cmdKho = new SqlCommand(sqlCongKho, conn, trans);
                    cmdKho.Parameters.AddWithValue("@MaPhieu", maPhieu);
                    cmdKho.ExecuteNonQuery();

                    // Bước B: Cập nhật trạng thái phiếu mượn sang "Đã trả"
                    string sqlUpdatePM = "UPDATE PhieuMuon SET TrangThai = N'Đã trả' WHERE MaPhieu = @MaPhieu AND TrangThai <> N'Đã trả'";
                    SqlCommand cmdPM = new SqlCommand(sqlUpdatePM, conn, trans);
                    cmdPM.Parameters.AddWithValue("@MaPhieu", maPhieu);
                    int rowsAffected = cmdPM.ExecuteNonQuery();

                    trans.Commit();
                    return rowsAffected > 0;
                }
                catch
                {
                    trans.Rollback();
                    throw;
                }
            }
        }

        // 3a. Dùng SqlDataReader lấy danh sách phiếu quá hạn (HanTra < GETDATE() và TrangThai != 'Đã trả')
        public List<PhieuMuonDTO> GetDanhSachQuaHanReader()
        {
            List<PhieuMuonDTO> list = new List<PhieuMuonDTO>();
            string query = @"
                SELECT pm.MaPhieu, pm.MaDocGia, dg.HoTen, pm.NgayMuon, pm.HanTra, pm.TrangThai
                FROM PhieuMuon pm
                INNER JOIN DocGia dg ON pm.MaDocGia = dg.MaDocGia
                WHERE pm.HanTra < GETDATE() AND pm.TrangThai <> N'Đã trả'";

            using (SqlConnection conn = DBConnect.GetConnection())
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                conn.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        list.Add(new PhieuMuonDTO
                        {
                            MaPhieu = reader.GetInt32(0),
                            MaDocGia = reader.GetInt32(1),
                            TenDocGia = reader.GetString(2),
                            NgayMuon = reader.GetDateTime(3),
                            HanTra = reader.GetDateTime(4),
                            TrangThai = reader.GetString(5)
                        });
                    }
                }
            }
            return list;
        }

        // 3b. Thống kê tổng số lượt mượn theo từng Thể loại (GROUP BY)
        public DataTable ThongKeLuotMuonTheoTheLoai()
        {
            string query = @"
                SELECT ds.TheLoai AS [Thể Loại], 
                       COUNT(DISTINCT ct.MaPhieu) AS [Số Phiếu Mượn], 
                       ISNULL(SUM(ct.SoLuong), 0) AS [Tổng Số Cuốn Mượn]
                FROM DauSach ds
                LEFT JOIN ChiTietMuon ct ON ds.MaSach = ct.MaSach
                GROUP BY ds.TheLoai";

            using (SqlConnection conn = DBConnect.GetConnection())
            {
                SqlDataAdapter da = new SqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }

        // 3c. Lấy tổng lượt mượn của 1 thể loại cụ thể bằng ExecuteScalar
        public int GetTongLuotMuonByTheLoai(string theLoai)
        {
            string query = @"
                SELECT ISNULL(SUM(ct.SoLuong), 0)
                FROM ChiTietMuon ct
                INNER JOIN DauSach ds ON ct.MaSach = ds.MaSach
                WHERE ds.TheLoai = @TheLoai";

            using (SqlConnection conn = DBConnect.GetConnection())
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@TheLoai", theLoai);
                conn.Open();
                return (int)cmd.ExecuteScalar();
            }
        }
    }
}