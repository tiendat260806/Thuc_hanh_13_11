using System;

namespace Bai6_6.DTO
{
    public class PhieuMuonDTO
    {
        public int MaPhieu { get; set; }
        public int MaDocGia { get; set; }
        public string TenDocGia { get; set; } // Dùng để hiển thị trên Grid
        public DateTime NgayMuon { get; set; }
        public DateTime HanTra { get; set; }
        public string TrangThai { get; set; }
    }
}