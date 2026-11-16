using System.Data;
using System.Data.SqlClient;
using Bai6_7.DTO;

namespace Bai6_7.DAL
{
    public class ThuocDAL
    {
        public DataTable GetAllThuoc()
        {
            using (SqlConnection conn = DBConnect.GetConnection())
            {
                SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM Thuoc", conn);
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }

        public bool InsertThuoc(ThuocDTO t)
        {
            string sql = "INSERT INTO Thuoc (TenThuoc, DonViTinh, DonGia, SoLuongTon) VALUES (@Ten, @DVT, @Gia, @Ton)";
            using (SqlConnection conn = DBConnect.GetConnection())
            using (SqlCommand cmd = new SqlCommand(sql, conn))
            {
                cmd.Parameters.AddWithValue("@Ten", t.TenThuoc);
                cmd.Parameters.AddWithValue("@DVT", t.DonViTinh);
                cmd.Parameters.AddWithValue("@Gia", t.DonGia);
                cmd.Parameters.AddWithValue("@Ton", t.SoLuongTon);
                conn.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }

        public bool UpdateThuoc(ThuocDTO t)
        {
            string sql = "UPDATE Thuoc SET TenThuoc = @Ten, DonViTinh = @DVT, DonGia = @Gia, SoLuongTon = @Ton WHERE MaThuoc = @Ma";
            using (SqlConnection conn = DBConnect.GetConnection())
            using (SqlCommand cmd = new SqlCommand(sql, conn))
            {
                cmd.Parameters.AddWithValue("@Ma", t.MaThuoc);
                cmd.Parameters.AddWithValue("@Ten", t.TenThuoc);
                cmd.Parameters.AddWithValue("@DVT", t.DonViTinh);
                cmd.Parameters.AddWithValue("@Gia", t.DonGia);
                cmd.Parameters.AddWithValue("@Ton", t.SoLuongTon);
                conn.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }

        public bool NhapThemKho(int maThuoc, int soLuongNhap)
        {
            string sql = "UPDATE Thuoc SET SoLuongTon = SoLuongTon + @SL WHERE MaThuoc = @Ma";
            using (SqlConnection conn = DBConnect.GetConnection())
            using (SqlCommand cmd = new SqlCommand(sql, conn))
            {
                cmd.Parameters.AddWithValue("@SL", soLuongNhap);
                cmd.Parameters.AddWithValue("@Ma", maThuoc);
                conn.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }
    }
}