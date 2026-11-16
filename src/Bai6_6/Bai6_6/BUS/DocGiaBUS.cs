using System;
using System.Data;
using Bai6_6.DAL;
using Bai6_6.DTO;

namespace Bai6_6.BUS
{
    public class DocGiaBUS
    {
        private readonly DocGiaDAL dal = new DocGiaDAL();

        public DataTable LayDanhSachDocGia() => dal.GetAllDocGia();

        public bool ThemDocGia(DocGiaDTO dg)
        {
            if (string.IsNullOrWhiteSpace(dg.HoTen))
                throw new Exception("Họ tên độc giả không được để trống!");
            return dal.InsertDocGia(dg);
        }

        public bool SuaDocGia(DocGiaDTO dg)
        {
            if (dg.MaDocGia <= 0)
                throw new Exception("Vui lòng chọn độc giả cần sửa!");
            if (string.IsNullOrWhiteSpace(dg.HoTen))
                throw new Exception("Họ tên độc giả không được để trống!");
            return dal.UpdateDocGia(dg);
        }

        public bool XoaDocGia(int maDocGia)
        {
            if (maDocGia <= 0)
                throw new Exception("Vui lòng chọn độc giả cần xóa!");
            return dal.DeleteDocGia(maDocGia);
        }
    }
}