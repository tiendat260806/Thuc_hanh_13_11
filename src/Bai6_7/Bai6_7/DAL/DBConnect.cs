using System.Data.SqlClient;

namespace Bai6_7.DAL
{
    public class DBConnect
    {
        // Đổi Data Source theo tên máy của bạn (VD: DESKTOP-FJ4FDED\SQLEXPRESS)
        private static readonly string connectionString =
    @"Data Source=DESKTOP-VMU8SL9\SQLEXPRESS;Initial Catalog=ClinicDB;Integrated Security=True";

        public static SqlConnection GetConnection() => new SqlConnection(connectionString);
    }
}