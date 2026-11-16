using System.Data.SqlClient;

namespace Bai6_6.DAL
{
    public class DBConnect
    {
        // Đổi tên Server (Data Source) phù hợp với máy của bạn (VD: . hoặc .\SQLEXPRESS)
        private static readonly string connectionString =
    @"Data Source=DESKTOP-VMU8SL9\SQLEXPRESS;Initial Catalog=LibraryDB;Integrated Security=True";

        public static SqlConnection GetConnection()
        {
            return new SqlConnection(connectionString);
        }
    }
}