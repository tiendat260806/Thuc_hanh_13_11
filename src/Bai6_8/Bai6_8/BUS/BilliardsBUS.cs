using System.Data;
using Bai6_8.DAL;

namespace Bai6_8.BUS
{
    public class BilliardsBUS
    {
        private readonly BilliardsDAL dal = new BilliardsDAL();

        public DataTable GetAllTables() => dal.GetAllBanBida();
        public DataTable GetAllServices() => dal.GetAllMenuDichVu();
        public bool OpenTable(int maBan, out int maHD) => dal.OpenTable(maBan, out maHD);
        public DataTable GetActiveBill(int maBan) => dal.GetActiveBillByTable(maBan);
        public DataTable GetBillDetails(int maHD) => dal.GetChiTietHoaDon(maHD);
        public bool OrderService(int maHD, int maDV, int soLuong, decimal donGia) => dal.AddOrIncreaseService(maHD, maDV, soLuong, donGia);
        public bool CheckoutTable(int maHD, int maBan, decimal tienGio, decimal tienDV, out string error) => dal.Checkout(maHD, maBan, tienGio, tienDV, out error);
    }
}