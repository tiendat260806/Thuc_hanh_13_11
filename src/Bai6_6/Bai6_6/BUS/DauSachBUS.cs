using System;
using System.Data;
using Bai6_6.DAL;
using Bai6_6.DTO;

namespace Bai6_6.BUS
{
    public class DauSachBUS
    {
        private readonly DauSachDAL dal = new DauSachDAL();

        public DataTable LayDanhSachDauSach() => dal.GetAllDauSach();

        public bool ThemDauSach(DauSachDTO ds)
        {
            if (string.IsNullOrWhiteSpace(ds.TenSach))
                throw new Exception("Tên sách không được để trống!");
            if (ds.SoLuongCon < 0)
                throw new Exception("Số lượng còn phải >= 0!");
            return dal.InsertDauSach(ds);
        }

        public bool SuaDauSach(DauSachDTO ds)
        {
            if (ds.MaSach <= 0)
                throw new Exception("Vui lòng chọn đầu sách cần sửa!");
            if (ds.SoLuongCon < 0)
                throw new Exception("Số lượng còn phải >= 0!");
            return dal.UpdateDauSach(ds);
        }

        public bool XoaDauSach(int maSach)
        {
            if (maSach <= 0)
                throw new Exception("Vui lòng chọn đầu sách cần xóa!");
            return dal.DeleteDauSach(maSach);
        }
    }
}