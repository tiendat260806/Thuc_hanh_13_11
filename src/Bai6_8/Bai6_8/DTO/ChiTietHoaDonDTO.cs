
namespace Bai6_8.DTO
{
    public class ChiTietHoaDonDTO
    {
        public int MaHD { get; set; }
        public int MaDV { get; set; }
        public string TenDV { get; set; }
        public int SoLuong { get; set; }
        public decimal DonGia { get; set; }
        public decimal ThanhTien => SoLuong * DonGia;

        public ChiTietHoaDonDTO() { }

        public ChiTietHoaDonDTO(int maHD, int maDV, string tenDV, int soLuong, decimal donGia)
        {
            MaHD = maHD;
            MaDV = maDV;
            TenDV = tenDV;
            SoLuong = soLuong;
            DonGia = donGia;
        }
    }
}