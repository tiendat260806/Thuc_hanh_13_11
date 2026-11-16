using System;
using System.Collections.Generic;
using System.Data;
using Bai6_6.DAL;
using Bai6_6.DTO;

namespace Bai6_6.BUS
{
    public class PhieuMuonBUS
    {
        private readonly PhieuMuonDAL pmDal = new PhieuMuonDAL();
        private readonly DocGiaDAL dgDal = new DocGiaDAL();

        public DataTable LocPhieuMuon(int maDocGia, string trangThai)
        {
            return pmDal.LocPhieuMuon(maDocGia, trangThai);
        }

        public bool LapPhieuMuonMoi(int maDocGia, DateTime hanTra, int maSach, int soLuong)
        {
            // Kiểm tra nghiệp vụ 1: Hạn thẻ độc giả
            if (!dgDal.KiemTraHanThe(maDocGia))
                throw new Exception("Thẻ độc giả đã hết hạn! Không thể lập phiếu mượn mới.");

            // Kiểm tra nghiệp vụ 2: Ngày hẹn trả & số lượng
            if (hanTra.Date < DateTime.Now.Date)
                throw new Exception("Hạn trả phải lớn hơn hoặc bằng ngày hiện tại!");
            if (soLuong <= 0)
                throw new Exception("Số lượng mượn phải lớn hơn 0!");

            return pmDal.LapPhieuMuon(maDocGia, hanTra, maSach, soLuong);
        }

        public bool TraSach(int maPhieu)
        {
            if (maPhieu <= 0)
                throw new Exception("Vui lòng chọn phiếu mượn cần trả!");
            return pmDal.TraSach(maPhieu);
        }

        public List<PhieuMuonDTO> LayDanhSachQuaHan() => pmDal.GetDanhSachQuaHanReader();

        public DataTable ThongKeTheoTheLoai() => pmDal.ThongKeLuotMuonTheoTheLoai();

        public int DemLuotMuonTheLoai(string theLoai) => pmDal.GetTongLuotMuonByTheLoai(theLoai);
    }
}