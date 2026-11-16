using System.Data;
using System.Data.SqlClient;
using Bai6_6.DTO;

namespace Bai6_6.DAL
{
    public class DauSachDAL
    {
        public DataTable GetAllDauSach()
        {
            using (SqlConnection conn = DBConnect.GetConnection())
            {
                SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM DauSach", conn);
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }

        public bool InsertDauSach(DauSachDTO ds)
        {
            string query = "INSERT INTO DauSach (TenSach, TheLoai, SoLuongCon) VALUES (@TenSach, @TheLoai, @SoLuongCon)";
            using (SqlConnection conn = DBConnect.GetConnection())
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@TenSach", ds.TenSach);
                cmd.Parameters.AddWithValue("@TheLoai", ds.TheLoai);
                cmd.Parameters.AddWithValue("@SoLuongCon", ds.SoLuongCon);
                conn.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }

        public bool UpdateDauSach(DauSachDTO ds)
        {
            string query = "UPDATE DauSach SET TenSach = @TenSach, TheLoai = @TheLoai, SoLuongCon = @SoLuongCon WHERE MaSach = @MaSach";
            using (SqlConnection conn = DBConnect.GetConnection())
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@MaSach", ds.MaSach);
                cmd.Parameters.AddWithValue("@TenSach", ds.TenSach);
                cmd.Parameters.AddWithValue("@TheLoai", ds.TheLoai);
                cmd.Parameters.AddWithValue("@SoLuongCon", ds.SoLuongCon);
                conn.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }

        public bool DeleteDauSach(int maSach)
        {
            string query = "DELETE FROM DauSach WHERE MaSach = @MaSach";
            using (SqlConnection conn = DBConnect.GetConnection())
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@MaSach", maSach);
                conn.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }
    }
}