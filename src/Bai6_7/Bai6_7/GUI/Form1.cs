using System;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using Bai6_7.BUS;
using Bai6_7.DTO;

namespace Bai6_7
{
    public partial class Form1 : Form
    {
        private readonly ThuocBUS thuocBUS = new ThuocBUS();
        private readonly PhongKhamBUS pkBUS = new PhongKhamBUS();
        private BindingList<ChiTietDonThuocDTO> gioThuoc = new BindingList<ChiTietDonThuocDTO>();
        private DataTable dtThuocCache;

        // Tự động tìm đúng Label hiển thị tổng tiền dự kiến (dù đặt tên là lblTongTamTinh hay để mặc định label12)
        private Label LblTongTienDuKien => this.Controls.Find("lblTongTamTinh", true).Length > 0
            ? (Label)this.Controls.Find("lblTongTamTinh", true)[0]
            : (Label)this.Controls.Find("label12", true)[0];

        public Form1()
        {
            InitializeComponent();
            this.dgvThuoc.CellClick += dgvThuoc_CellClick;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            cboDVT.Items.Clear();
            cboDVT.Items.AddRange(new string[] { "Viên", "Vỉ", "Chai", "Tuýp" });
            cboDVT.SelectedIndex = 0;

            dgvChiTietDon.DataSource = gioThuoc;
            LoadAllData();
            CapNhatTongTamTinh();
        }

        private void LoadAllData()
        {
            try
            {
                // 1. Load Danh mục thuốc
                dtThuocCache = thuocBUS.LayDanhSachThuoc();
                dgvThuoc.DataSource = dtThuocCache;

                cboThuoc.DataSource = dtThuocCache.Copy();
                cboThuoc.DisplayMember = "TenThuoc";
                cboThuoc.ValueMember = "MaThuoc";

                // 2. Load Hồ sơ khám
                DataTable dtHS = pkBUS.LayDanhSachHoSo();
                dgvHoSo.DataSource = dtHS;

                // Hiển thị kèm Mã Hồ Sơ + Tên Bệnh Nhân trong ComboBox kê đơn cho dễ phân biệt
                DataTable dtCboHS = dtHS.Copy();
                dtCboHS.Columns.Add("HienThi", typeof(string), "'HS#' + MaHoSo + ' - ' + HoTen");
                cboHoSo.DataSource = dtCboHS;
                cboHoSo.DisplayMember = "HienThi";
                cboHoSo.ValueMember = "MaHoSo";

                // 3. Load Đơn thuốc
                dgvDonThuoc.DataSource = pkBUS.LayDanhSachDonThuoc();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi kết nối CSDL: " + ex.Message, "Lỗi hệ thống", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #region TAB 1: TIẾP NHẬN BỆNH NHÂN
        private void btnTimSDT_Click(object sender, EventArgs e)
        {
            try
            {
                var bn = pkBUS.TraCuuSDT(txtSDT.Text);
                if (bn != null)
                {
                    txtMaBN.Text = bn.MaBN.ToString();
                    txtHoTen.Text = bn.HoTen;
                    txtNamSinh.Text = bn.NamSinh.ToString();
                    MessageBox.Show("Đã tìm thấy hồ sơ bệnh nhân cũ!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    txtMaBN.Text = "0";
                    txtHoTen.Clear();
                    txtNamSinh.Clear();
                    txtHoTen.Focus();
                    MessageBox.Show("Bệnh nhân mới! Vui lòng nhập Họ tên, Năm sinh và Triệu chứng để tạo hồ sơ.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning); }
        }

        private void btnTaoHoSo_Click(object sender, EventArgs e)
        {
            try
            {
                if (!int.TryParse(txtNamSinh.Text.Trim(), out int namSinh))
                {
                    MessageBox.Show("Năm sinh phải là số nguyên hợp lệ!", "Lỗi nhập liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtNamSinh.Focus();
                    return;
                }

                BenhNhanDTO bn = new BenhNhanDTO
                {
                    MaBN = string.IsNullOrEmpty(txtMaBN.Text) ? 0 : int.Parse(txtMaBN.Text),
                    HoTen = txtHoTen.Text.Trim(),
                    SoDienThoai = txtSDT.Text.Trim(),
                    NamSinh = namSinh
                };

                int maHS = pkBUS.TiepNhanBenhNhan(bn, txtTrieuChung.Text.Trim());
                MessageBox.Show($"Tiếp nhận thành công! Mã hồ sơ khám mới: #{maHS}", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtTrieuChung.Clear();
                LoadAllData();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, "Lỗi nhập liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning); }
        }
        #endregion

        #region TAB 2: KÊ ĐƠN & XUẤT KHO (SqlTransaction)
        private void btnThemVaoDon_Click(object sender, EventArgs e)
        {
            if (cboThuoc.SelectedValue == null) return;
            int maThuoc = Convert.ToInt32(cboThuoc.SelectedValue);
            int sl = (int)numSLKe.Value;

            DataRow[] rows = dtThuocCache.Select($"MaThuoc = {maThuoc}");
            if (rows.Length == 0) return;

            string tenThuoc = rows[0]["TenThuoc"].ToString();
            string dvt = rows[0]["DonViTinh"].ToString();
            decimal donGia = Convert.ToDecimal(rows[0]["DonGia"]);

            var existing = gioThuoc.FirstOrDefault(x => x.MaThuoc == maThuoc);
            if (existing != null)
            {
                existing.SoLuong += sl;
                existing.LieuDung = txtLieuDung.Text.Trim();
                dgvChiTietDon.Refresh();
            }
            else
            {
                gioThuoc.Add(new ChiTietDonThuocDTO
                {
                    MaThuoc = maThuoc,
                    TenThuoc = tenThuoc,
                    DonViTinh = dvt,
                    DonGia = donGia,
                    SoLuong = sl,
                    LieuDung = txtLieuDung.Text.Trim()
                });
            }
            CapNhatTongTamTinh();
        }

        private void txtTienKham_TextChanged(object sender, EventArgs e)
        {
            CapNhatTongTamTinh();
        }

        private void CapNhatTongTamTinh()
        {
            decimal.TryParse(txtTienKham.Text.Trim(), out decimal tienKham);
            decimal tong = tienKham + gioThuoc.Sum(x => x.ThanhTien);
            LblTongTienDuKien.Text = $"Tổng tiền dự kiến: {tong:N0} VNĐ";
        }

        private void btnLuuXuatDon_Click(object sender, EventArgs e)
        {
            try
            {
                if (cboHoSo.SelectedValue == null)
                {
                    MessageBox.Show("Chưa có hồ sơ khám nào được chọn!");
                    return;
                }

                int maHoSo = Convert.ToInt32(cboHoSo.SelectedValue);
                if (!decimal.TryParse(txtTienKham.Text.Trim(), out decimal tienKham) || tienKham < 0)
                {
                    MessageBox.Show("Tiền khám không hợp lệ!");
                    return;
                }

                int maDon = pkBUS.KeDonVaXuatKho(maHoSo, txtChanDoan.Text.Trim(), tienKham, gioThuoc.ToList());
                MessageBox.Show($"Lưu đơn thuốc #{maDon} và trừ tồn kho thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);

                gioThuoc.Clear();
                txtChanDoan.Clear();
                CapNhatTongTamTinh();
                LoadAllData();
            }
            catch (Exception ex)
            {
                // Hiển thị cảnh báo khi thiếu tồn kho và Transaction đã tự động Rollback
                MessageBox.Show(ex.Message, "Cảnh báo Giao dịch (Rollback)", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion

        #region TAB 3: THANH TOÁN & IN HÓA ĐƠN
        private void btnThanhToan_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvDonThuoc.CurrentRow == null)
                {
                    MessageBox.Show("Vui lòng chọn một đơn thuốc trong bảng để thanh toán!");
                    return;
                }

                int maDon = Convert.ToInt32(dgvDonThuoc.CurrentRow.Cells["MaDon"].Value);
                string trangThai = dgvDonThuoc.CurrentRow.Cells["TrangThai"].Value.ToString();

                if (trangThai == "Đã thanh toán")
                {
                    MessageBox.Show("Đơn thuốc này đã được thanh toán trước đó!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                if (pkBUS.ThanhToan(maDon))
                {
                    string tenBN = dgvDonThuoc.CurrentRow.Cells["TenBenhNhan"].Value.ToString();
                    string chanDoan = dgvDonThuoc.CurrentRow.Cells["ChanDoan"].Value.ToString();
                    decimal tienKham = Convert.ToDecimal(dgvDonThuoc.CurrentRow.Cells["TienKham"].Value);
                    decimal tongTien = Convert.ToDecimal(dgvDonThuoc.CurrentRow.Cells["TongTien"].Value);

                    MessageBox.Show(
                        $"========= HÓA ĐƠN VIỆN PHÍ =========\n" +
                        $"Mã đơn thuốc : #{maDon}\n" +
                        $"Bệnh nhân    : {tenBN}\n" +
                        $"Chẩn đoán    : {chanDoan}\n" +
                        $"Tiền khám    : {tienKham:N0} VNĐ\n" +
                        $"Tiền thuốc   : {(tongTien - tienKham):N0} VNĐ\n" +
                        $"------------------------------------\n" +
                        $"TỔNG CỘNG    : {tongTien:N0} VNĐ\n" +
                        $"Trạng thái   : Đã thanh toán",
                        "In Hóa Đơn Thành Công", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    LoadAllData();
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }
        #endregion

        #region TAB 4: QUẢN LÝ DANH MỤC THUỐC
        private void btnThemThuoc_Click(object sender, EventArgs e)
        {
            try
            {
                if (!decimal.TryParse(txtDonGia.Text.Trim(), out decimal donGia))
                {
                    MessageBox.Show("Đơn giá phải là số hợp lệ!");
                    return;
                }

                ThuocDTO t = new ThuocDTO
                {
                    TenThuoc = txtTenThuoc.Text.Trim(),
                    DonViTinh = cboDVT.Text,
                    DonGia = donGia,
                    SoLuongTon = (int)numTonKho.Value
                };

                if (thuocBUS.ThemThuoc(t))
                {
                    MessageBox.Show("Thêm thuốc mới thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadAllData();
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning); }
        }

        private void btnSuaThuoc_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtMaThuoc.Text))
                {
                    MessageBox.Show("Vui lòng chọn một loại thuốc trong bảng trước!");
                    return;
                }
                if (!decimal.TryParse(txtDonGia.Text.Trim(), out decimal donGia))
                {
                    MessageBox.Show("Đơn giá phải là số hợp lệ!");
                    return;
                }

                ThuocDTO t = new ThuocDTO
                {
                    MaThuoc = int.Parse(txtMaThuoc.Text),
                    TenThuoc = txtTenThuoc.Text.Trim(),
                    DonViTinh = cboDVT.Text,
                    DonGia = donGia,
                    SoLuongTon = (int)numTonKho.Value
                };

                if (thuocBUS.SuaThuoc(t))
                {
                    MessageBox.Show("Cập nhật thông tin thuốc thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadAllData();
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning); }
        }

        private void btnNhapKho_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtMaThuoc.Text))
                {
                    MessageBox.Show("Vui lòng chọn thuốc cần nhập kho trong bảng!");
                    return;
                }
                if (thuocBUS.NhapKho(int.Parse(txtMaThuoc.Text), 10))
                {
                    MessageBox.Show("Đã nhập thêm +10 vào số lượng tồn kho!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadAllData();
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning); }
        }

        private void dgvThuoc_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex < dgvThuoc.Rows.Count)
            {
                DataGridViewRow r = dgvThuoc.Rows[e.RowIndex];
                txtMaThuoc.Text = r.Cells["MaThuoc"].Value?.ToString();
                txtTenThuoc.Text = r.Cells["TenThuoc"].Value?.ToString();
                cboDVT.Text = r.Cells["DonViTinh"].Value?.ToString();
                txtDonGia.Text = r.Cells["DonGia"].Value?.ToString();
                if (r.Cells["SoLuongTon"].Value != null)
                    numTonKho.Value = Convert.ToDecimal(r.Cells["SoLuongTon"].Value);
            }
        }

        private void dgvThuoc_CellContentClick(object sender, DataGridViewCellEventArgs e) => dgvThuoc_CellClick(sender, e);
        #endregion

        #region CÁC SỰ KIỆN RỖNG GIỮ LẠI ĐỂ KHÔNG LỖI DESIGNER
        private void txtSDT_TextChanged(object sender, EventArgs e) { }
        private void txtMaBN_TextChanged(object sender, EventArgs e) { }
        private void txtHoTen_TextChanged(object sender, EventArgs e) { }
        private void txtNamSinh_TextChanged(object sender, EventArgs e) { }
        private void txtTrieuChung_TextChanged(object sender, EventArgs e) { }
        private void dgvHoSo_CellContentClick(object sender, DataGridViewCellEventArgs e) { }
        private void cboHoSo_SelectedIndexChanged(object sender, EventArgs e) { }
        private void txtChanDoan_TextChanged(object sender, EventArgs e) { }
        private void cboThuoc_SelectedIndexChanged(object sender, EventArgs e) { }
        private void numSLKe_ValueChanged(object sender, EventArgs e) { }
        private void txtLieuDung_TextChanged(object sender, EventArgs e) { }
        private void dgvChiTietDon_CellContentClick(object sender, DataGridViewCellEventArgs e) { }
        private void label12_Click(object sender, EventArgs e) { }
        private void dgvDonThuoc_CellContentClick(object sender, DataGridViewCellEventArgs e) { }
        private void txtMaThuoc_TextChanged(object sender, EventArgs e) { }
        private void txtTenThuoc_TextChanged(object sender, EventArgs e) { }
        private void cboDVT_SelectedIndexChanged(object sender, EventArgs e) { }
        private void txtDonGia_TextChanged(object sender, EventArgs e) { }
        private void numTonKho_ValueChanged(object sender, EventArgs e) { }
        #endregion
    }
}