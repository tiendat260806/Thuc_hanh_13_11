using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Bai6_8.BUS;

namespace Bai6_8
{
    public partial class Form1 : Form
    {
        private readonly BilliardsBUS bus = new BilliardsBUS();

        private int currentMaBan = 0;
        private string currentTenBan = "";
        private decimal currentGiaGio = 0;
        private string currentTrangThai = "";
        private int currentMaHD = 0;
        private DateTime currentGioBatDau;

        public Form1()
        {
            InitializeComponent();
            this.Load += Form1_Load;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "HỆ THỐNG QUẢN LÝ BÀN BIDA & DỊCH VỤ GIẢI TRÍ";

            dgvDichVuDat.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            LoadTableVisualGrid();
            LoadServiceCombo();
        }

        // TẠO SƠ ĐỒ BÀN TRỰC QUAN (VISUAL TABLE GRID)
        private void LoadTableVisualGrid()
        {
            flpBanBida.Controls.Clear();
            DataTable dtTables = bus.GetAllTables();

            foreach (DataRow row in dtTables.Rows)
            {
                string tenBan = row["TenBan"].ToString();
                string loaiBan = row["LoaiBan"].ToString();
                decimal giaGio = Convert.ToDecimal(row["GiaTheoGio"]);
                string trangThai = row["TrangThai"].ToString();

                Button btn = new Button
                {
                    Width = 135,
                    Height = 110,
                    Text = $"{tenBan}\n({loaiBan})\n{giaGio:N0}đ/h\n[{trangThai}]",
                    Font = new Font("Segoe UI", 9.5F, FontStyle.Bold),
                    Margin = new Padding(6),
                    Tag = row
                };

                // Bàn Trống = Xanh lá, Đang chơi = Cam/Đỏ
                if (trangThai == "Đang chơi")
                {
                    btn.BackColor = Color.OrangeRed;
                    btn.ForeColor = Color.White;
                }
                else
                {
                    btn.BackColor = Color.MediumSeaGreen;
                    btn.ForeColor = Color.White;
                }

                btn.Click += BtnTable_Click;
                flpBanBida.Controls.Add(btn);
            }
        }

        private void BtnTable_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            DataRow row = (DataRow)btn.Tag;

            currentMaBan = Convert.ToInt32(row["MaBan"]);
            currentTenBan = row["TenBan"].ToString();
            currentGiaGio = Convert.ToDecimal(row["GiaTheoGio"]);
            currentTrangThai = row["TrangThai"].ToString();

            lblTenBanChon.Text = $"Bàn đang chọn: {currentTenBan} ({row["LoaiBan"]})";
            lblGiaBan.Text = $"Giá bàn/giờ: {currentGiaGio:N0} VNĐ";

            if (currentTrangThai == "Đang chơi")
            {
                btnMoBan.Enabled = false;
                btnThemDV.Enabled = true;
                btnThanhToan.Enabled = true;

                DataTable dtHD = bus.GetActiveBill(currentMaBan);
                if (dtHD.Rows.Count > 0)
                {
                    currentMaHD = Convert.ToInt32(dtHD.Rows[0]["MaHD"]);
                    currentGioBatDau = Convert.ToDateTime(dtHD.Rows[0]["GioBatDau"]);
                    lblGioBatDau.Text = $"Giờ bắt đầu: {currentGioBatDau:HH:mm:ss dd/MM/yyyy}";
                    RefreshServiceGridAndCalculate();
                }
            }
            else
            {
                btnMoBan.Enabled = true;
                btnThemDV.Enabled = false;
                btnThanhToan.Enabled = false;

                currentMaHD = 0;
                lblGioBatDau.Text = "Giờ bắt đầu: --:--:--";
                dgvDichVuDat.DataSource = null;
                lblTienGio.Text = "0 VNĐ";
                lblTienDV.Text = "0 VNĐ";
                lblTongTien.Text = "0 VNĐ";
            }
        }

        private void btnMoBan_Click(object sender, EventArgs e)
        {
            if (currentMaBan == 0)
            {
                MessageBox.Show("Vui lòng chọn 1 bàn trên sơ đồ!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (bus.OpenTable(currentMaBan, out int newMaHD))
            {
                MessageBox.Show($"Mở [{currentTenBan}] thành công! Hóa đơn #{newMaHD} đã được khởi tạo.", "Mở bàn", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadTableVisualGrid();

                currentTrangThai = "Đang chơi";
                currentMaHD = newMaHD;
                currentGioBatDau = DateTime.Now;
                lblGioBatDau.Text = $"Giờ bắt đầu: {currentGioBatDau:HH:mm:ss dd/MM/yyyy}";
                btnMoBan.Enabled = false;
                btnThemDV.Enabled = true;
                btnThanhToan.Enabled = true;
                RefreshServiceGridAndCalculate();
            }
        }

        private void LoadServiceCombo()
        {
            cboDichVu.DataSource = bus.GetAllServices();
            cboDichVu.DisplayMember = "TenDV";
            cboDichVu.ValueMember = "MaDV";
        }

        private void btnThemDV_Click(object sender, EventArgs e)
        {
            if (currentMaHD == 0)
            {
                MessageBox.Show("Bàn chưa được mở!", "Cảnh báo");
                return;
            }

            DataRowView row = (DataRowView)cboDichVu.SelectedItem;
            int maDV = Convert.ToInt32(row["MaDV"]);
            decimal donGia = Convert.ToDecimal(row["DonGia"]);
            int soLuong = (int)nmSoLuong.Value;

            if (bus.OrderService(currentMaHD, maDV, soLuong, donGia))
            {
                RefreshServiceGridAndCalculate();
            }
        }

        // HÀM TÍNH TIỀN GIỜ LÀM TRÒN THEO BLOCK 15 PHÚT
        private decimal CalculateTimeCharge(DateTime start, DateTime end, decimal hourlyRate, out int blocks15Min, out TimeSpan duration)
        {
            duration = end - start;
            double totalMinutes = duration.TotalMinutes;
            if (totalMinutes < 1) totalMinutes = 1; // Tối thiểu 1 block 15 phút khi vừa mở bàn

            blocks15Min = (int)Math.Ceiling(totalMinutes / 15.0);
            double billedHours = blocks15Min * 0.25; // Mỗi block = 0.25 giờ
            return (decimal)billedHours * hourlyRate;
        }

        private void RefreshServiceGridAndCalculate()
        {
            DataTable dtServices = bus.GetBillDetails(currentMaHD);
            dgvDichVuDat.DataSource = dtServices;

            if (dgvDichVuDat.Columns["DonGia"] != null)
                dgvDichVuDat.Columns["DonGia"].DefaultCellStyle.Format = "N0";
            if (dgvDichVuDat.Columns["ThanhTien"] != null)
                dgvDichVuDat.Columns["ThanhTien"].DefaultCellStyle.Format = "N0";

            // 1. Tiền dịch vụ
            decimal tienDV = 0;
            foreach (DataRow r in dtServices.Rows)
            {
                tienDV += Convert.ToDecimal(r["ThanhTien"]);
            }
            lblTienDV.Text = $"{tienDV:N0} VNĐ";

            // 2. Tiền giờ chơi (làm tròn block 15 phút)
            decimal tienGio = CalculateTimeCharge(currentGioBatDau, DateTime.Now, currentGiaGio, out int blocks, out TimeSpan duration);
            lblTienGio.Text = $"{tienGio:N0} VNĐ ({blocks} block 15p)";

            // 3. Tổng cộng
            lblTongTien.Text = $"{(tienGio + tienDV):N0} VNĐ";
        }

        private void btnThanhToan_Click(object sender, EventArgs e)
        {
            if (currentMaHD == 0) return;

            decimal tienGio = CalculateTimeCharge(currentGioBatDau, DateTime.Now, currentGiaGio, out int blocks, out TimeSpan duration);

            decimal tienDV = 0;
            DataTable dtServices = bus.GetBillDetails(currentMaHD);
            foreach (DataRow r in dtServices.Rows) tienDV += Convert.ToDecimal(r["ThanhTien"]);

            decimal tongCong = tienGio + tienDV;

            DialogResult confirm = MessageBox.Show(
                $"XÁC NHẬN THANH TOÁN [{currentTenBan}]?\n" +
                $"- Thời gian thực tế: {duration.Hours} giờ {duration.Minutes} phút (Làm tròn {blocks} block 15p)\n" +
                $"- Tiền giờ chơi: {tienGio:N0} VNĐ\n" +
                $"- Tiền dịch vụ: {tienDV:N0} VNĐ\n" +
                $"----------------------------------\n" +
                $"=> TỔNG THANH TOÁN: {tongCong:N0} VNĐ",
                "Thanh toán Hóa đơn (Transaction)",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (confirm == DialogResult.Yes)
            {
                if (bus.CheckoutTable(currentMaHD, currentMaBan, tienGio, tienDV, out string error))
                {
                    MessageBox.Show("Thanh toán thành công qua SqlTransaction!\nĐã trừ kho đồ ăn/uống (giữ nguyên kho gậy thuê) và trả bàn về Trống.",
                        "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    currentMaHD = 0;
                    currentMaBan = 0;
                    lblTenBanChon.Text = "Bàn đang chọn: Chưa chọn";
                    lblGioBatDau.Text = "Giờ bắt đầu: --:--:--";
                    dgvDichVuDat.DataSource = null;
                    lblTienGio.Text = "0 VNĐ";
                    lblTienDV.Text = "0 VNĐ";
                    lblTongTien.Text = "0 VNĐ";

                    LoadTableVisualGrid();
                    LoadServiceCombo();
                }
                else
                {
                    MessageBox.Show($"THANH TOÁN THẤT BẠI (ROLLBACK)!\nChi tiết: {error}",
                        "Lỗi Transaction", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        // Các hàm sự kiện phụ do Designer sinh ra (giữ lại để không báo lỗi biên dịch)
        private void flpBanBida_Paint(object sender, PaintEventArgs e) { }
        private void lblNoteGreen_Click(object sender, EventArgs e) { }
        private void lblNoteOrange_Click(object sender, EventArgs e) { }
        private void lblTenBanChon_Click(object sender, EventArgs e) { }
        private void lblGioBatDau_Click(object sender, EventArgs e) { }
        private void lblGiaBan_Click(object sender, EventArgs e) { }
        private void cboDichVu_SelectedIndexChanged(object sender, EventArgs e) { }
        private void nmSoLuong_ValueChanged(object sender, EventArgs e) { }
        private void dgvDichVuDat_CellContentClick(object sender, DataGridViewCellEventArgs e) { }
        private void lblTienGio_Click(object sender, EventArgs e) { }
        private void lblTienDV_Click(object sender, EventArgs e) { }
        private void lblTongTien_Click(object sender, EventArgs e) { }
    }
}