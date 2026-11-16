using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using Bai6_6.BUS;
using Bai6_6.DTO;

namespace Bai6_6
{
    public partial class Form1 : Form
    {
        private readonly DauSachBUS sachBUS = new DauSachBUS();
        private readonly DocGiaBUS dgBUS = new DocGiaBUS();
        private readonly PhieuMuonBUS pmBUS = new PhieuMuonBUS();

        // Biến hỗ trợ lấy đúng ComboBox trạng thái dù bạn đặt tên là cboLocTrangThai hay comboBox2
        private ComboBox CboTrangThai => this.Controls.Find("cboLocTrangThai", true).Length > 0
            ? (ComboBox)this.Controls.Find("cboLocTrangThai", true)[0]
            : (ComboBox)this.Controls.Find("comboBox2", true)[0];

        public Form1()
        {
            InitializeComponent();

            // Đăng ký tự động các sự kiện quan trọng để không cần chỉnh tay trong Properties
            this.Load += Form1_Load;
            this.dgvSach.CellClick += dgvSach_CellClick;
            this.dgvDocGia.CellClick += dgvDocGia_CellClick;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Khởi tạo ComboBox Thể loại
            cboTheLoai.Items.Clear();
            cboTheLoai.Items.AddRange(new string[] { "Công nghệ thông tin", "Kinh tế", "Văn học" });
            cboTheLoai.SelectedIndex = 0;

            // Khởi tạo ComboBox Trạng thái
            CboTrangThai.Items.Clear();
            CboTrangThai.Items.AddRange(new string[] { "Tất cả", "Đang mượn", "Đã trả", "Quá hạn" });
            CboTrangThai.SelectedIndex = 0;

            // Nạp toàn bộ dữ liệu từ SQL Server lên giao diện
            LoadAllData();
        }

        private void LoadAllData()
        {
            try
            {
                // 1. Load Sách
                DataTable dtSach = sachBUS.LayDanhSachDauSach();
                dgvSach.DataSource = dtSach;
                cboMuonSach.DataSource = dtSach.Copy();
                cboMuonSach.DisplayMember = "TenSach";
                cboMuonSach.ValueMember = "MaSach";

                // 2. Load Độc giả
                DataTable dtDG = dgBUS.LayDanhSachDocGia();
                dgvDocGia.DataSource = dtDG;

                cboMuonDocGia.DataSource = dtDG.Copy();
                cboMuonDocGia.DisplayMember = "HoTen";
                cboMuonDocGia.ValueMember = "MaDocGia";

                // ComboBox lọc độc giả có thêm dòng "Tất cả" (MaDocGia = 0)
                DataTable dtLocDG = dtDG.Copy();
                DataRow allRow = dtLocDG.NewRow();
                allRow["MaDocGia"] = 0;
                allRow["HoTen"] = "-- Tất cả độc giả --";
                dtLocDG.Rows.InsertAt(allRow, 0);

                cboLocDocGia.DataSource = dtLocDG;
                cboLocDocGia.DisplayMember = "HoTen";
                cboLocDocGia.ValueMember = "MaDocGia";

                // 3. Load Phiếu mượn
                LocPhieuMuon();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi kết nối CSDL: " + ex.Message, "Lỗi hệ thống", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #region TAB 1: QUẢN LÝ ĐẦU SÁCH
        private void btnThemSach_Click(object sender, EventArgs e)
        {
            try
            {
                DauSachDTO ds = new DauSachDTO
                {
                    TenSach = txtTenSach.Text.Trim(),
                    TheLoai = cboTheLoai.Text,
                    SoLuongCon = (int)numSoLuong.Value
                };
                if (sachBUS.ThemDauSach(ds))
                {
                    MessageBox.Show("Thêm đầu sách thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadAllData();
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void btnSuaSach_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtMaSach.Text))
                {
                    MessageBox.Show("Vui lòng chọn đầu sách cần sửa trong bảng!");
                    return;
                }
                DauSachDTO ds = new DauSachDTO
                {
                    MaSach = int.Parse(txtMaSach.Text),
                    TenSach = txtTenSach.Text.Trim(),
                    TheLoai = cboTheLoai.Text,
                    SoLuongCon = (int)numSoLuong.Value
                };
                if (sachBUS.SuaDauSach(ds))
                {
                    MessageBox.Show("Cập nhật đầu sách thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadAllData();
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void btnXoaSach_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtMaSach.Text))
                {
                    MessageBox.Show("Vui lòng chọn đầu sách cần xóa trong bảng!");
                    return;
                }
                if (MessageBox.Show("Xác nhận xóa đầu sách này?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    if (sachBUS.XoaDauSach(int.Parse(txtMaSach.Text)))
                    {
                        MessageBox.Show("Xóa đầu sách thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadAllData();
                    }
                }
            }
            catch (Exception ex) { MessageBox.Show("Không thể xóa sách đang tồn tại trong phiếu mượn!\n" + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void dgvSach_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex < dgvSach.Rows.Count)
            {
                DataGridViewRow row = dgvSach.Rows[e.RowIndex];
                txtMaSach.Text = row.Cells["MaSach"].Value?.ToString();
                txtTenSach.Text = row.Cells["TenSach"].Value?.ToString();
                cboTheLoai.Text = row.Cells["TheLoai"].Value?.ToString();
                if (row.Cells["SoLuongCon"].Value != null)
                    numSoLuong.Value = Convert.ToDecimal(row.Cells["SoLuongCon"].Value);
            }
        }

        private void dgvSach_CellContentClick(object sender, DataGridViewCellEventArgs e) => dgvSach_CellClick(sender, e);
        #endregion

        #region TAB 2: QUẢN LÝ ĐỘC GIẢ
        private void btnThemDG_Click(object sender, EventArgs e)
        {
            try
            {
                DocGiaDTO dg = new DocGiaDTO
                {
                    HoTen = txtHoTen.Text.Trim(),
                    Email = txtEmail.Text.Trim(),
                    NgayHetHanThe = dtpHanThe.Value
                };
                if (dgBUS.ThemDocGia(dg))
                {
                    MessageBox.Show("Thêm độc giả thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadAllData();
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void btnSuaDG_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtMaDG.Text))
                {
                    MessageBox.Show("Vui lòng chọn độc giả cần sửa trong bảng!");
                    return;
                }
                DocGiaDTO dg = new DocGiaDTO
                {
                    MaDocGia = int.Parse(txtMaDG.Text),
                    HoTen = txtHoTen.Text.Trim(),
                    Email = txtEmail.Text.Trim(),
                    NgayHetHanThe = dtpHanThe.Value
                };
                if (dgBUS.SuaDocGia(dg))
                {
                    MessageBox.Show("Cập nhật độc giả thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadAllData();
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void btnXoaDG_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtMaDG.Text))
                {
                    MessageBox.Show("Vui lòng chọn độc giả cần xóa trong bảng!");
                    return;
                }
                if (MessageBox.Show("Xác nhận xóa độc giả này?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    if (dgBUS.XoaDocGia(int.Parse(txtMaDG.Text)))
                    {
                        MessageBox.Show("Xóa độc giả thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadAllData();
                    }
                }
            }
            catch (Exception ex) { MessageBox.Show("Không thể xóa độc giả đang có lịch sử mượn sách!\n" + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void dgvDocGia_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex < dgvDocGia.Rows.Count)
            {
                DataGridViewRow row = dgvDocGia.Rows[e.RowIndex];
                txtMaDG.Text = row.Cells["MaDocGia"].Value?.ToString();
                txtHoTen.Text = row.Cells["HoTen"].Value?.ToString();
                txtEmail.Text = row.Cells["Email"].Value?.ToString();
                if (row.Cells["NgayHetHanThe"].Value != null)
                    dtpHanThe.Value = Convert.ToDateTime(row.Cells["NgayHetHanThe"].Value);
            }
        }

        private void dgvDocGia_CellContentClick(object sender, DataGridViewCellEventArgs e) => dgvDocGia_CellClick(sender, e);
        #endregion

        #region TAB 3: MƯỢN / TRẢ SÁCH & LỌC TRẠNG THÁI
        private void btnLapPhieu_Click(object sender, EventArgs e)
        {
            try
            {
                int maDG = Convert.ToInt32(cboMuonDocGia.SelectedValue);
                int maSach = Convert.ToInt32(cboMuonSach.SelectedValue);
                int soLuong = (int)numMuonSL.Value;
                DateTime hanTra = dtpHanTra.Value;

                if (pmBUS.LapPhieuMuonMoi(maDG, hanTra, maSach, soLuong))
                {
                    MessageBox.Show("Lập phiếu mượn thành công và đã cập nhật tồn kho!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadAllData();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Cảnh báo nghiệp vụ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnLoc_Click(object sender, EventArgs e)
        {
            LocPhieuMuon();
        }

        private void LocPhieuMuon()
        {
            if (cboLocDocGia.SelectedValue == null) return;
            int maDG = Convert.ToInt32(cboLocDocGia.SelectedValue);
            string trangThai = CboTrangThai.Text;
            dgvPhieuMuon.DataSource = pmBUS.LocPhieuMuon(maDG, trangThai);
        }

        private void btnTraSach_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvPhieuMuon.CurrentRow == null)
                {
                    MessageBox.Show("Vui lòng chọn phiếu mượn cần trả trong bảng!");
                    return;
                }

                int maPhieu = Convert.ToInt32(dgvPhieuMuon.CurrentRow.Cells["MaPhieu"].Value);
                string trangThai = dgvPhieuMuon.CurrentRow.Cells["TrangThai"].Value.ToString();

                if (trangThai == "Đã trả")
                {
                    MessageBox.Show("Phiếu mượn này đã được trả trước đó!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                if (pmBUS.TraSach(maPhieu))
                {
                    MessageBox.Show("Trả sách thành công! Đã chuyển trạng thái sang 'Đã trả' và cộng lại số lượng sách.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadAllData();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion

        #region TAB 4: CẢNH BÁO QUÁ HẠN (SqlDataReader) & THỐNG KÊ
        private void btnKiemTraQuaHan_Click(object sender, EventArgs e)
        {
            var dsQuaHan = pmBUS.LayDanhSachQuaHan();
            dgvQuaHan.DataSource = dsQuaHan;

            // Tô đỏ nổi bật các dòng quá hạn
            foreach (DataGridViewRow row in dgvQuaHan.Rows)
            {
                row.DefaultCellStyle.BackColor = Color.MistyRose;
                row.DefaultCellStyle.ForeColor = Color.DarkRed;
            }

            if (dsQuaHan.Count > 0)
                MessageBox.Show($"Cảnh báo: Phát hiện {dsQuaHan.Count} phiếu mượn đã vượt quá hạn trả!", "Cảnh báo quá hạn", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            else
                MessageBox.Show("Tuyệt vời! Hiện không có phiếu mượn nào quá hạn.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnThongKe_Click(object sender, EventArgs e)
        {
            // Hiển thị bảng thống kê theo GROUP BY
            dgvThongKe.DataSource = pmBUS.ThongKeTheoTheLoai();

            // Sử dụng ExecuteScalar lấy tổng lượt mượn riêng của thể loại CNTT
            int luotMuonCNTT = pmBUS.DemLuotMuonTheLoai("Công nghệ thông tin");
            lblTongKetTheLoai.Text = $"Tổng số cuốn thể loại 'Công nghệ thông tin' đã mượn: {luotMuonCNTT} cuốn";
        }
        #endregion

        #region CÁC SỰ KIỆN RỖNG GIỮ LẠI ĐỂ KHÔNG LỖI DESIGNER
        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e) { }
        private void label15_Click(object sender, EventArgs e) { }
        private void label16_Click(object sender, EventArgs e) { }
        private void txtMaSach_TextChanged(object sender, EventArgs e) { }
        private void txtTenSach_TextChanged(object sender, EventArgs e) { }
        private void cboTheLoai_SelectedIndexChanged(object sender, EventArgs e) { }
        private void numSoLuong_ValueChanged(object sender, EventArgs e) { }
        private void txtMaDG_TextChanged(object sender, EventArgs e) { }
        private void txtHoTen_TextChanged(object sender, EventArgs e) { }
        private void txtEmail_TextChanged(object sender, EventArgs e) { }
        private void dtpHanThe_ValueChanged(object sender, EventArgs e) { }
        private void tabDocGia_Click(object sender, EventArgs e) { }
        private void cboMuonDocGia_SelectedIndexChanged(object sender, EventArgs e) { }
        private void cboMuonSach_SelectedIndexChanged(object sender, EventArgs e) { }
        private void numMuonSL_ValueChanged(object sender, EventArgs e) { }
        private void dtpHanTra_ValueChanged(object sender, EventArgs e) { }
        private void cboLocDocGia_SelectedIndexChanged(object sender, EventArgs e) { }
        private void grpTheoDoi_Enter(object sender, EventArgs e) { }
        private void dgvPhieuMuon_CellContentClick(object sender, DataGridViewCellEventArgs e) { }
        private void dgvQuaHan_CellContentClick(object sender, DataGridViewCellEventArgs e) { }
        private void dgvThongKe_CellContentClick(object sender, DataGridViewCellEventArgs e) { }
        private void lblTongKetTheLoai_Click(object sender, EventArgs e) { }
        #endregion
    }
}