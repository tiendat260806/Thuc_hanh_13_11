using System;
using System.Data;
using System.Data.SqlClient;
using Bai6_6.DTO;

namespace Bai6_6.DAL
{
    public class DocGiaDAL
    {
        public DataTable GetAllDocGia()
        {
            using (SqlConnection conn = DBConnect.GetConnection())
            {
                SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM DocGia", conn);
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }

        public bool InsertDocGia(DocGiaDTO dg)
        {
            string query = "INSERT INTO DocGia (HoTen, Email, NgayHetHanThe) VALUES (@HoTen, @Email, @NgayHetHanThe)";
            using (SqlConnection conn = DBConnect.GetConnection())
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@HoTen", dg.HoTen);
                cmd.Parameters.AddWithValue("@Email", dg.Email);
                cmd.Parameters.AddWithValue("@NgayHetHanThe", dg.NgayHetHanThe);
                conn.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }

        public bool UpdateDocGia(DocGiaDTO dg)
        {
            string query = "UPDATE DocGia SET HoTen = @HoTen, Email = @Email, NgayHetHanThe = @NgayHetHanThe WHERE MaDocGia = @MaDocGia";
            using (SqlConnection conn = DBConnect.GetConnection())
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@MaDocGia", dg.MaDocGia);
                cmd.Parameters.AddWithValue("@HoTen", dg.HoTen);
                cmd.Parameters.AddWithValue("@Email", dg.Email);
                cmd.Parameters.AddWithValue("@NgayHetHanThe", dg.NgayHetHanThe);
                conn.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }

        public bool DeleteDocGia(int maDocGia)
        {
            string query = "DELETE FROM DocGia WHERE MaDocGia = @MaDocGia";
            using (SqlConnection conn = DBConnect.GetConnection())
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@MaDocGia", maDocGia);
                conn.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }

        // Kiểm tra hạn thẻ độc giả trực tiếp dưới DB (NgayHetHanThe >= GETDATE())
        public bool KiemTraHanThe(int maDocGia)
        {
            string query = "SELECT COUNT(*) FROM DocGia WHERE MaDocGia = @MaDocGia AND NgayHetHanThe >= GETDATE()";
            using (SqlConnection conn = DBConnect.GetConnection())
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@MaDocGia", maDocGia);
                conn.Open();
                int count = (int)cmd.ExecuteScalar();
                return count > 0;
            }
        }
    }
}