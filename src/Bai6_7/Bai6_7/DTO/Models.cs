using System;

namespace Bai6_7.DTO
{
    public class BenhNhanDTO
    {
        public int MaBN { get; set; }
        public string HoTen { get; set; }
        public string SoDienThoai { get; set; }
        public int NamSinh { get; set; }
    }

    public class HoSoKhamDTO
    {
        public int MaHoSo { get; set; }
        public int MaBN { get; set; }
        public DateTime NgayKham { get; set; }
        public string TrieuChung { get; set; }
        public string ChanDoan { get; set; }
    }

    public class ThuocDTO
    {
        public int MaThuoc { get; set; }
        public string TenThuoc { get; set; }
        public string DonViTinh { get; set; }
        public decimal DonGia { get; set; }
        public int SoLuongTon { get; set; }
    }

    public class ChiTietDonThuocDTO
    {
        public int MaThuoc { get; set; }
        public string TenThuoc { get; set; }
        public string DonViTinh { get; set; }
        public decimal DonGia { get; set; }
        public int SoLuong { get; set; }
        public string LieuDung { get; set; }
        public decimal ThanhTien => DonGia * SoLuong;
    }
}