using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Bai6_7.DAL;
using Bai6_7.DTO;

namespace Bai6_7.BUS
{
    public class ThuocBUS
    {
        private readonly ThuocDAL dal = new ThuocDAL();
        public DataTable LayDanhSachThuoc() => dal.GetAllThuoc();

        public bool ThemThuoc(ThuocDTO t)
        {
            if (string.IsNullOrWhiteSpace(t.TenThuoc)) throw new Exception("Tên thuốc không được để trống!");
            if (t.DonGia < 0 || t.SoLuongTon < 0) throw new Exception("Đơn giá và tồn kho phải >= 0!");
            return dal.InsertThuoc(t);
        }

        public bool SuaThuoc(ThuocDTO t)
        {
            if (t.MaThuoc <= 0) throw new Exception("Vui lòng chọn thuốc cần sửa!");
            return dal.UpdateThuoc(t);
        }

        public bool NhapKho(int maThuoc, int sl)
        {
            if (maThuoc <= 0 || sl <= 0) throw new Exception("Số lượng nhập kho phải > 0!");
            return dal.NhapThemKho(maThuoc, sl);
        }
    }

    public class PhongKhamBUS
    {
        private readonly PhongKhamDAL dal = new PhongKhamDAL();

        public BenhNhanDTO TraCuuSDT(string sdt)
        {
            if (string.IsNullOrWhiteSpace(sdt)) throw new Exception("Vui lòng nhập số điện thoại!");
            return dal.TimBenhNhanTheoSDT(sdt.Trim());
        }

        public int TiepNhanBenhNhan(BenhNhanDTO bn, string trieuChung)
        {
            if (string.IsNullOrWhiteSpace(bn.HoTen)) throw new Exception("Họ tên bệnh nhân không được trống!");
            if (string.IsNullOrWhiteSpace(trieuChung)) throw new Exception("Vui lòng nhập triệu chứng lâm sàng!");
            return dal.TiepNhanKham(bn, new HoSoKhamDTO { TrieuChung = trieuChung });
        }

        public DataTable LayDanhSachHoSo() => dal.GetDanhSachHoSoKham();

        public int KeDonVaXuatKho(int maHoSo, string chanDoan, decimal tienKham, List<ChiTietDonThuocDTO> dsThuoc)
        {
            if (maHoSo <= 0) throw new Exception("Vui lòng chọn hồ sơ khám!");
            if (string.IsNullOrWhiteSpace(chanDoan)) throw new Exception("Vui lòng nhập chẩn đoán bệnh!");
            if (dsThuoc == null || dsThuoc.Count == 0) throw new Exception("Đơn thuốc phải có ít nhất 1 loại thuốc!");

            decimal tongTienThuoc = dsThuoc.Sum(x => x.ThanhTien);
            decimal tongChiPhi = tienKham + tongTienThuoc;

            return dal.LuuVaXuatDonThuoc(maHoSo, chanDoan, tienKham, tongChiPhi, dsThuoc);
        }

        public DataTable LayDanhSachDonThuoc() => dal.GetDanhSachDonThuoc();

        public bool ThanhToan(int maDon)
        {
            if (maDon <= 0) throw new Exception("Vui lòng chọn đơn thuốc cần thanh toán!");
            return dal.ThanhToanDonThuoc(maDon);
        }
    }
}