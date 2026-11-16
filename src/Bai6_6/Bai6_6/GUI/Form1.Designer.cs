namespace Bai6_6
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tabMain = new System.Windows.Forms.TabControl();
            this.tabSach = new System.Windows.Forms.TabPage();
            this.dgvSach = new System.Windows.Forms.DataGridView();
            this.btnXoaSach = new System.Windows.Forms.Button();
            this.btnSuaSach = new System.Windows.Forms.Button();
            this.btnThemSach = new System.Windows.Forms.Button();
            this.numSoLuong = new System.Windows.Forms.NumericUpDown();
            this.cboTheLoai = new System.Windows.Forms.ComboBox();
            this.txtTenSach = new System.Windows.Forms.TextBox();
            this.txtMaSach = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tabDocGia = new System.Windows.Forms.TabPage();
            this.dgvDocGia = new System.Windows.Forms.DataGridView();
            this.btnXoaDG = new System.Windows.Forms.Button();
            this.btnSuaDG = new System.Windows.Forms.Button();
            this.btnThemDG = new System.Windows.Forms.Button();
            this.dtpHanThe = new System.Windows.Forms.DateTimePicker();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.txtHoTen = new System.Windows.Forms.TextBox();
            this.txtMaDG = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.tabMuonTra = new System.Windows.Forms.TabPage();
            this.dgvPhieuMuon = new System.Windows.Forms.DataGridView();
            this.grpTheoDoi = new System.Windows.Forms.GroupBox();
            this.btnLoc = new System.Windows.Forms.Button();
            this.btnTraSach = new System.Windows.Forms.Button();
            this.cboLocTrangThai = new System.Windows.Forms.ComboBox();
            this.cboLocDocGia = new System.Windows.Forms.ComboBox();
            this.label14 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.grpLapPhieu = new System.Windows.Forms.GroupBox();
            this.btnLapPhieu = new System.Windows.Forms.Button();
            this.dtpHanTra = new System.Windows.Forms.DateTimePicker();
            this.numMuonSL = new System.Windows.Forms.NumericUpDown();
            this.cboMuonSach = new System.Windows.Forms.ComboBox();
            this.cboMuonDocGia = new System.Windows.Forms.ComboBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.tabCanhBaoThongKe = new System.Windows.Forms.TabPage();
            this.dgvThongKe = new System.Windows.Forms.DataGridView();
            this.btnThongKe = new System.Windows.Forms.Button();
            this.label16 = new System.Windows.Forms.Label();
            this.dgvQuaHan = new System.Windows.Forms.DataGridView();
            this.btnKiemTraQuaHan = new System.Windows.Forms.Button();
            this.label15 = new System.Windows.Forms.Label();
            this.lblTongKetTheLoai = new System.Windows.Forms.Label();
            this.tabMain.SuspendLayout();
            this.tabSach.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSach)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numSoLuong)).BeginInit();
            this.tabDocGia.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDocGia)).BeginInit();
            this.tabMuonTra.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPhieuMuon)).BeginInit();
            this.grpTheoDoi.SuspendLayout();
            this.grpLapPhieu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numMuonSL)).BeginInit();
            this.tabCanhBaoThongKe.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvThongKe)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvQuaHan)).BeginInit();
            this.SuspendLayout();
            // 
            // tabMain
            // 
            this.tabMain.Controls.Add(this.tabSach);
            this.tabMain.Controls.Add(this.tabDocGia);
            this.tabMain.Controls.Add(this.tabMuonTra);
            this.tabMain.Controls.Add(this.tabCanhBaoThongKe);
            this.tabMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabMain.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabMain.Location = new System.Drawing.Point(0, 0);
            this.tabMain.Name = "tabMain";
            this.tabMain.SelectedIndex = 0;
            this.tabMain.Size = new System.Drawing.Size(973, 558);
            this.tabMain.TabIndex = 0;
            // 
            // tabSach
            // 
            this.tabSach.Controls.Add(this.dgvSach);
            this.tabSach.Controls.Add(this.btnXoaSach);
            this.tabSach.Controls.Add(this.btnSuaSach);
            this.tabSach.Controls.Add(this.btnThemSach);
            this.tabSach.Controls.Add(this.numSoLuong);
            this.tabSach.Controls.Add(this.cboTheLoai);
            this.tabSach.Controls.Add(this.txtTenSach);
            this.tabSach.Controls.Add(this.txtMaSach);
            this.tabSach.Controls.Add(this.label4);
            this.tabSach.Controls.Add(this.label3);
            this.tabSach.Controls.Add(this.label2);
            this.tabSach.Controls.Add(this.label1);
            this.tabSach.Location = new System.Drawing.Point(4, 25);
            this.tabSach.Name = "tabSach";
            this.tabSach.Padding = new System.Windows.Forms.Padding(3);
            this.tabSach.Size = new System.Drawing.Size(965, 529);
            this.tabSach.TabIndex = 0;
            this.tabSach.Text = "Quản lý Đầu sách";
            this.tabSach.UseVisualStyleBackColor = true;
            // 
            // dgvSach
            // 
            this.dgvSach.AllowUserToAddRows = false;
            this.dgvSach.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvSach.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSach.Location = new System.Drawing.Point(283, 6);
            this.dgvSach.Name = "dgvSach";
            this.dgvSach.ReadOnly = true;
            this.dgvSach.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvSach.Size = new System.Drawing.Size(643, 499);
            this.dgvSach.TabIndex = 11;
            this.dgvSach.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvSach_CellContentClick);
            // 
            // btnXoaSach
            // 
            this.btnXoaSach.Location = new System.Drawing.Point(98, 281);
            this.btnXoaSach.Name = "btnXoaSach";
            this.btnXoaSach.Size = new System.Drawing.Size(75, 23);
            this.btnXoaSach.TabIndex = 10;
            this.btnXoaSach.Text = "Xóa";
            this.btnXoaSach.UseVisualStyleBackColor = true;
            this.btnXoaSach.Click += new System.EventHandler(this.btnXoaSach_Click);
            // 
            // btnSuaSach
            // 
            this.btnSuaSach.Location = new System.Drawing.Point(173, 237);
            this.btnSuaSach.Name = "btnSuaSach";
            this.btnSuaSach.Size = new System.Drawing.Size(75, 23);
            this.btnSuaSach.TabIndex = 9;
            this.btnSuaSach.Text = "Sửa";
            this.btnSuaSach.UseVisualStyleBackColor = true;
            this.btnSuaSach.Click += new System.EventHandler(this.btnSuaSach_Click);
            // 
            // btnThemSach
            // 
            this.btnThemSach.Location = new System.Drawing.Point(31, 237);
            this.btnThemSach.Name = "btnThemSach";
            this.btnThemSach.Size = new System.Drawing.Size(75, 23);
            this.btnThemSach.TabIndex = 8;
            this.btnThemSach.Text = "Thêm";
            this.btnThemSach.UseVisualStyleBackColor = true;
            this.btnThemSach.Click += new System.EventHandler(this.btnThemSach_Click);
            // 
            // numSoLuong
            // 
            this.numSoLuong.Location = new System.Drawing.Point(130, 195);
            this.numSoLuong.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numSoLuong.Name = "numSoLuong";
            this.numSoLuong.Size = new System.Drawing.Size(137, 22);
            this.numSoLuong.TabIndex = 7;
            this.numSoLuong.ValueChanged += new System.EventHandler(this.numSoLuong_ValueChanged);
            // 
            // cboTheLoai
            // 
            this.cboTheLoai.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTheLoai.FormattingEnabled = true;
            this.cboTheLoai.Location = new System.Drawing.Point(130, 141);
            this.cboTheLoai.Name = "cboTheLoai";
            this.cboTheLoai.Size = new System.Drawing.Size(137, 24);
            this.cboTheLoai.TabIndex = 6;
            this.cboTheLoai.SelectedIndexChanged += new System.EventHandler(this.cboTheLoai_SelectedIndexChanged);
            // 
            // txtTenSach
            // 
            this.txtTenSach.Location = new System.Drawing.Point(130, 95);
            this.txtTenSach.Name = "txtTenSach";
            this.txtTenSach.Size = new System.Drawing.Size(137, 22);
            this.txtTenSach.TabIndex = 5;
            this.txtTenSach.TextChanged += new System.EventHandler(this.txtTenSach_TextChanged);
            // 
            // txtMaSach
            // 
            this.txtMaSach.Location = new System.Drawing.Point(130, 47);
            this.txtMaSach.Name = "txtMaSach";
            this.txtMaSach.ReadOnly = true;
            this.txtMaSach.Size = new System.Drawing.Size(137, 22);
            this.txtMaSach.TabIndex = 4;
            this.txtMaSach.TextChanged += new System.EventHandler(this.txtMaSach_TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(18, 197);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(88, 16);
            this.label4.TabIndex = 3;
            this.label4.Text = "Số lượng còn:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(18, 149);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(59, 16);
            this.label3.TabIndex = 2;
            this.label3.Text = "Thể loại:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(18, 101);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(66, 16);
            this.label2.TabIndex = 1;
            this.label2.Text = "Tên sách:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(18, 53);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(61, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Mã sách:";
            // 
            // tabDocGia
            // 
            this.tabDocGia.Controls.Add(this.dgvDocGia);
            this.tabDocGia.Controls.Add(this.btnXoaDG);
            this.tabDocGia.Controls.Add(this.btnSuaDG);
            this.tabDocGia.Controls.Add(this.btnThemDG);
            this.tabDocGia.Controls.Add(this.dtpHanThe);
            this.tabDocGia.Controls.Add(this.txtEmail);
            this.tabDocGia.Controls.Add(this.txtHoTen);
            this.tabDocGia.Controls.Add(this.txtMaDG);
            this.tabDocGia.Controls.Add(this.label8);
            this.tabDocGia.Controls.Add(this.label7);
            this.tabDocGia.Controls.Add(this.label6);
            this.tabDocGia.Controls.Add(this.label5);
            this.tabDocGia.Location = new System.Drawing.Point(4, 25);
            this.tabDocGia.Name = "tabDocGia";
            this.tabDocGia.Padding = new System.Windows.Forms.Padding(3);
            this.tabDocGia.Size = new System.Drawing.Size(965, 529);
            this.tabDocGia.TabIndex = 1;
            this.tabDocGia.Text = "Quản lý Độc giả";
            this.tabDocGia.UseVisualStyleBackColor = true;
            this.tabDocGia.Click += new System.EventHandler(this.tabDocGia_Click);
            // 
            // dgvDocGia
            // 
            this.dgvDocGia.AllowUserToAddRows = false;
            this.dgvDocGia.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvDocGia.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDocGia.Location = new System.Drawing.Point(358, 3);
            this.dgvDocGia.Name = "dgvDocGia";
            this.dgvDocGia.ReadOnly = true;
            this.dgvDocGia.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDocGia.Size = new System.Drawing.Size(570, 518);
            this.dgvDocGia.TabIndex = 11;
            this.dgvDocGia.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDocGia_CellContentClick);
            // 
            // btnXoaDG
            // 
            this.btnXoaDG.Location = new System.Drawing.Point(140, 264);
            this.btnXoaDG.Name = "btnXoaDG";
            this.btnXoaDG.Size = new System.Drawing.Size(75, 23);
            this.btnXoaDG.TabIndex = 10;
            this.btnXoaDG.Text = "Xóa";
            this.btnXoaDG.UseVisualStyleBackColor = true;
            this.btnXoaDG.Click += new System.EventHandler(this.btnXoaDG_Click);
            // 
            // btnSuaDG
            // 
            this.btnSuaDG.Location = new System.Drawing.Point(219, 213);
            this.btnSuaDG.Name = "btnSuaDG";
            this.btnSuaDG.Size = new System.Drawing.Size(75, 23);
            this.btnSuaDG.TabIndex = 9;
            this.btnSuaDG.Text = "Sửa";
            this.btnSuaDG.UseVisualStyleBackColor = true;
            this.btnSuaDG.Click += new System.EventHandler(this.btnSuaDG_Click);
            // 
            // btnThemDG
            // 
            this.btnThemDG.Location = new System.Drawing.Point(62, 213);
            this.btnThemDG.Name = "btnThemDG";
            this.btnThemDG.Size = new System.Drawing.Size(75, 23);
            this.btnThemDG.TabIndex = 8;
            this.btnThemDG.Text = "Thêm";
            this.btnThemDG.UseVisualStyleBackColor = true;
            this.btnThemDG.Click += new System.EventHandler(this.btnThemDG_Click);
            // 
            // dtpHanThe
            // 
            this.dtpHanThe.CustomFormat = "dd/MM/yyyy";
            this.dtpHanThe.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpHanThe.Location = new System.Drawing.Point(152, 170);
            this.dtpHanThe.Name = "dtpHanThe";
            this.dtpHanThe.Size = new System.Drawing.Size(200, 22);
            this.dtpHanThe.TabIndex = 7;
            this.dtpHanThe.ValueChanged += new System.EventHandler(this.dtpHanThe_ValueChanged);
            // 
            // txtEmail
            // 
            this.txtEmail.Location = new System.Drawing.Point(152, 128);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(200, 22);
            this.txtEmail.TabIndex = 6;
            this.txtEmail.TextChanged += new System.EventHandler(this.txtEmail_TextChanged);
            // 
            // txtHoTen
            // 
            this.txtHoTen.Location = new System.Drawing.Point(152, 86);
            this.txtHoTen.Name = "txtHoTen";
            this.txtHoTen.Size = new System.Drawing.Size(200, 22);
            this.txtHoTen.TabIndex = 5;
            this.txtHoTen.TextChanged += new System.EventHandler(this.txtHoTen_TextChanged);
            // 
            // txtMaDG
            // 
            this.txtMaDG.Location = new System.Drawing.Point(152, 44);
            this.txtMaDG.Name = "txtMaDG";
            this.txtMaDG.ReadOnly = true;
            this.txtMaDG.Size = new System.Drawing.Size(200, 22);
            this.txtMaDG.TabIndex = 4;
            this.txtMaDG.TextChanged += new System.EventHandler(this.txtMaDG_TextChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(27, 176);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(110, 16);
            this.label8.TabIndex = 3;
            this.label8.Text = "Ngày hết hạn thẻ:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(27, 134);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(44, 16);
            this.label7.TabIndex = 2;
            this.label7.Text = "Email:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(27, 92);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(67, 16);
            this.label6.TabIndex = 1;
            this.label6.Text = "Họ và tên:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(27, 50);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(77, 16);
            this.label5.TabIndex = 0;
            this.label5.Text = "Mã độc giả:";
            // 
            // tabMuonTra
            // 
            this.tabMuonTra.Controls.Add(this.dgvPhieuMuon);
            this.tabMuonTra.Controls.Add(this.grpTheoDoi);
            this.tabMuonTra.Controls.Add(this.grpLapPhieu);
            this.tabMuonTra.Location = new System.Drawing.Point(4, 25);
            this.tabMuonTra.Name = "tabMuonTra";
            this.tabMuonTra.Padding = new System.Windows.Forms.Padding(3);
            this.tabMuonTra.Size = new System.Drawing.Size(965, 529);
            this.tabMuonTra.TabIndex = 2;
            this.tabMuonTra.Text = "Mượn / Trả sách";
            this.tabMuonTra.UseVisualStyleBackColor = true;
            // 
            // dgvPhieuMuon
            // 
            this.dgvPhieuMuon.AllowUserToAddRows = false;
            this.dgvPhieuMuon.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvPhieuMuon.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPhieuMuon.Location = new System.Drawing.Point(322, 6);
            this.dgvPhieuMuon.Name = "dgvPhieuMuon";
            this.dgvPhieuMuon.ReadOnly = true;
            this.dgvPhieuMuon.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvPhieuMuon.Size = new System.Drawing.Size(604, 451);
            this.dgvPhieuMuon.TabIndex = 2;
            this.dgvPhieuMuon.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvPhieuMuon_CellContentClick);
            // 
            // grpTheoDoi
            // 
            this.grpTheoDoi.Controls.Add(this.btnLoc);
            this.grpTheoDoi.Controls.Add(this.btnTraSach);
            this.grpTheoDoi.Controls.Add(this.cboLocTrangThai);
            this.grpTheoDoi.Controls.Add(this.cboLocDocGia);
            this.grpTheoDoi.Controls.Add(this.label14);
            this.grpTheoDoi.Controls.Add(this.label13);
            this.grpTheoDoi.Location = new System.Drawing.Point(8, 241);
            this.grpTheoDoi.Name = "grpTheoDoi";
            this.grpTheoDoi.Size = new System.Drawing.Size(308, 216);
            this.grpTheoDoi.TabIndex = 1;
            this.grpTheoDoi.TabStop = false;
            this.grpTheoDoi.Text = "Theo dõi, Lọc & Trả sách";
            this.grpTheoDoi.Enter += new System.EventHandler(this.grpTheoDoi_Enter);
            // 
            // btnLoc
            // 
            this.btnLoc.Location = new System.Drawing.Point(24, 157);
            this.btnLoc.Name = "btnLoc";
            this.btnLoc.Size = new System.Drawing.Size(108, 31);
            this.btnLoc.TabIndex = 5;
            this.btnLoc.Text = "Lọc dữ liệu";
            this.btnLoc.UseVisualStyleBackColor = true;
            this.btnLoc.Click += new System.EventHandler(this.btnLoc_Click);
            // 
            // btnTraSach
            // 
            this.btnTraSach.Location = new System.Drawing.Point(175, 157);
            this.btnTraSach.Name = "btnTraSach";
            this.btnTraSach.Size = new System.Drawing.Size(108, 31);
            this.btnTraSach.TabIndex = 4;
            this.btnTraSach.Text = "Trả sách";
            this.btnTraSach.UseVisualStyleBackColor = true;
            this.btnTraSach.Click += new System.EventHandler(this.btnTraSach_Click);
            // 
            // cboLocTrangThai
            // 
            this.cboLocTrangThai.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboLocTrangThai.FormattingEnabled = true;
            this.cboLocTrangThai.Location = new System.Drawing.Point(122, 86);
            this.cboLocTrangThai.Name = "cboLocTrangThai";
            this.cboLocTrangThai.Size = new System.Drawing.Size(151, 24);
            this.cboLocTrangThai.TabIndex = 3;
            this.cboLocTrangThai.SelectedIndexChanged += new System.EventHandler(this.comboBox2_SelectedIndexChanged);
            // 
            // cboLocDocGia
            // 
            this.cboLocDocGia.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboLocDocGia.FormattingEnabled = true;
            this.cboLocDocGia.Location = new System.Drawing.Point(123, 45);
            this.cboLocDocGia.Name = "cboLocDocGia";
            this.cboLocDocGia.Size = new System.Drawing.Size(150, 24);
            this.cboLocDocGia.TabIndex = 2;
            this.cboLocDocGia.SelectedIndexChanged += new System.EventHandler(this.cboLocDocGia_SelectedIndexChanged);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(5, 94);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(106, 16);
            this.label14.TabIndex = 1;
            this.label14.Text = "Trạng thái phiếu:";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(7, 53);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(109, 16);
            this.label13.TabIndex = 0;
            this.label13.Text = "Lọc theo độc giả:";
            // 
            // grpLapPhieu
            // 
            this.grpLapPhieu.Controls.Add(this.btnLapPhieu);
            this.grpLapPhieu.Controls.Add(this.dtpHanTra);
            this.grpLapPhieu.Controls.Add(this.numMuonSL);
            this.grpLapPhieu.Controls.Add(this.cboMuonSach);
            this.grpLapPhieu.Controls.Add(this.cboMuonDocGia);
            this.grpLapPhieu.Controls.Add(this.label12);
            this.grpLapPhieu.Controls.Add(this.label11);
            this.grpLapPhieu.Controls.Add(this.label10);
            this.grpLapPhieu.Controls.Add(this.label9);
            this.grpLapPhieu.Location = new System.Drawing.Point(8, 6);
            this.grpLapPhieu.Name = "grpLapPhieu";
            this.grpLapPhieu.Size = new System.Drawing.Size(308, 219);
            this.grpLapPhieu.TabIndex = 0;
            this.grpLapPhieu.TabStop = false;
            this.grpLapPhieu.Text = "Lập phiếu mượn mới";
            // 
            // btnLapPhieu
            // 
            this.btnLapPhieu.Location = new System.Drawing.Point(97, 174);
            this.btnLapPhieu.Name = "btnLapPhieu";
            this.btnLapPhieu.Size = new System.Drawing.Size(120, 39);
            this.btnLapPhieu.TabIndex = 8;
            this.btnLapPhieu.Text = "Lập phiếu mượn";
            this.btnLapPhieu.UseVisualStyleBackColor = true;
            this.btnLapPhieu.Click += new System.EventHandler(this.btnLapPhieu_Click);
            // 
            // dtpHanTra
            // 
            this.dtpHanTra.CustomFormat = "dd/MM/yyyy";
            this.dtpHanTra.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpHanTra.Location = new System.Drawing.Point(123, 135);
            this.dtpHanTra.Name = "dtpHanTra";
            this.dtpHanTra.Size = new System.Drawing.Size(176, 22);
            this.dtpHanTra.TabIndex = 7;
            this.dtpHanTra.ValueChanged += new System.EventHandler(this.dtpHanTra_ValueChanged);
            // 
            // numMuonSL
            // 
            this.numMuonSL.Location = new System.Drawing.Point(124, 97);
            this.numMuonSL.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numMuonSL.Name = "numMuonSL";
            this.numMuonSL.Size = new System.Drawing.Size(176, 22);
            this.numMuonSL.TabIndex = 6;
            this.numMuonSL.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numMuonSL.ValueChanged += new System.EventHandler(this.numMuonSL_ValueChanged);
            // 
            // cboMuonSach
            // 
            this.cboMuonSach.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboMuonSach.FormattingEnabled = true;
            this.cboMuonSach.Location = new System.Drawing.Point(123, 59);
            this.cboMuonSach.Name = "cboMuonSach";
            this.cboMuonSach.Size = new System.Drawing.Size(176, 24);
            this.cboMuonSach.TabIndex = 5;
            this.cboMuonSach.SelectedIndexChanged += new System.EventHandler(this.cboMuonSach_SelectedIndexChanged);
            // 
            // cboMuonDocGia
            // 
            this.cboMuonDocGia.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboMuonDocGia.FormattingEnabled = true;
            this.cboMuonDocGia.Location = new System.Drawing.Point(123, 21);
            this.cboMuonDocGia.Name = "cboMuonDocGia";
            this.cboMuonDocGia.Size = new System.Drawing.Size(176, 24);
            this.cboMuonDocGia.TabIndex = 4;
            this.cboMuonDocGia.SelectedIndexChanged += new System.EventHandler(this.cboMuonDocGia_SelectedIndexChanged);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(8, 140);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(86, 16);
            this.label12.TabIndex = 3;
            this.label12.Text = "Ngày hẹn trả:";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(8, 103);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(99, 16);
            this.label11.TabIndex = 2;
            this.label11.Text = "Số lượng mượn:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(8, 67);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(109, 16);
            this.label10.TabIndex = 1;
            this.label10.Text = "Chọn sách mượn:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(8, 34);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(89, 16);
            this.label9.TabIndex = 0;
            this.label9.Text = "Chọn độc giả:";
            // 
            // tabCanhBaoThongKe
            // 
            this.tabCanhBaoThongKe.Controls.Add(this.lblTongKetTheLoai);
            this.tabCanhBaoThongKe.Controls.Add(this.dgvThongKe);
            this.tabCanhBaoThongKe.Controls.Add(this.btnThongKe);
            this.tabCanhBaoThongKe.Controls.Add(this.label16);
            this.tabCanhBaoThongKe.Controls.Add(this.dgvQuaHan);
            this.tabCanhBaoThongKe.Controls.Add(this.btnKiemTraQuaHan);
            this.tabCanhBaoThongKe.Controls.Add(this.label15);
            this.tabCanhBaoThongKe.Location = new System.Drawing.Point(4, 25);
            this.tabCanhBaoThongKe.Name = "tabCanhBaoThongKe";
            this.tabCanhBaoThongKe.Padding = new System.Windows.Forms.Padding(3);
            this.tabCanhBaoThongKe.Size = new System.Drawing.Size(965, 529);
            this.tabCanhBaoThongKe.TabIndex = 3;
            this.tabCanhBaoThongKe.Text = "Cảnh báo & Thống kê";
            this.tabCanhBaoThongKe.UseVisualStyleBackColor = true;
            // 
            // dgvThongKe
            // 
            this.dgvThongKe.AllowUserToAddRows = false;
            this.dgvThongKe.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvThongKe.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvThongKe.Location = new System.Drawing.Point(488, 49);
            this.dgvThongKe.Name = "dgvThongKe";
            this.dgvThongKe.ReadOnly = true;
            this.dgvThongKe.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvThongKe.Size = new System.Drawing.Size(455, 446);
            this.dgvThongKe.TabIndex = 5;
            this.dgvThongKe.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvThongKe_CellContentClick);
            // 
            // btnThongKe
            // 
            this.btnThongKe.Location = new System.Drawing.Point(710, 7);
            this.btnThongKe.Name = "btnThongKe";
            this.btnThongKe.Size = new System.Drawing.Size(129, 30);
            this.btnThongKe.TabIndex = 4;
            this.btnThongKe.Text = "Thống kê thể loại";
            this.btnThongKe.UseVisualStyleBackColor = true;
            this.btnThongKe.Click += new System.EventHandler(this.btnThongKe_Click);
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(463, 21);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(224, 16);
            this.label16.TabIndex = 3;
            this.label16.Text = "THỐNG KÊ MƯỢN THEO THỂ LOẠI";
            this.label16.Click += new System.EventHandler(this.label16_Click);
            // 
            // dgvQuaHan
            // 
            this.dgvQuaHan.AllowUserToAddRows = false;
            this.dgvQuaHan.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvQuaHan.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvQuaHan.Location = new System.Drawing.Point(9, 49);
            this.dgvQuaHan.Name = "dgvQuaHan";
            this.dgvQuaHan.ReadOnly = true;
            this.dgvQuaHan.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvQuaHan.Size = new System.Drawing.Size(428, 446);
            this.dgvQuaHan.TabIndex = 2;
            this.dgvQuaHan.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvQuaHan_CellContentClick);
            // 
            // btnKiemTraQuaHan
            // 
            this.btnKiemTraQuaHan.Location = new System.Drawing.Point(208, 7);
            this.btnKiemTraQuaHan.Name = "btnKiemTraQuaHan";
            this.btnKiemTraQuaHan.Size = new System.Drawing.Size(129, 30);
            this.btnKiemTraQuaHan.TabIndex = 1;
            this.btnKiemTraQuaHan.Text = "Kiểm tra quá hạn";
            this.btnKiemTraQuaHan.UseVisualStyleBackColor = true;
            this.btnKiemTraQuaHan.Click += new System.EventHandler(this.btnKiemTraQuaHan_Click);
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(6, 20);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(194, 16);
            this.label15.TabIndex = 0;
            this.label15.Text = "DANH SÁCH PHIẾU QUÁ HẠN";
            this.label15.Click += new System.EventHandler(this.label15_Click);
            // 
            // lblTongKetTheLoai
            // 
            this.lblTongKetTheLoai.AutoSize = true;
            this.lblTongKetTheLoai.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTongKetTheLoai.Location = new System.Drawing.Point(485, 508);
            this.lblTongKetTheLoai.Name = "lblTongKetTheLoai";
            this.lblTongKetTheLoai.Size = new System.Drawing.Size(280, 16);
            this.lblTongKetTheLoai.TabIndex = 6;
            this.lblTongKetTheLoai.Text = "Tổng số cuốn thể loại CNTT đã mượn: 0";
            this.lblTongKetTheLoai.Click += new System.EventHandler(this.lblTongKetTheLoai_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(973, 558);
            this.Controls.Add(this.tabMain);
            this.Name = "Form1";
            this.Text = "HỆ THỐNG QUẢN LÝ MƯỢN TRẢ SÁCH THƯ VIỆN";
            this.tabMain.ResumeLayout(false);
            this.tabSach.ResumeLayout(false);
            this.tabSach.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSach)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numSoLuong)).EndInit();
            this.tabDocGia.ResumeLayout(false);
            this.tabDocGia.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDocGia)).EndInit();
            this.tabMuonTra.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPhieuMuon)).EndInit();
            this.grpTheoDoi.ResumeLayout(false);
            this.grpTheoDoi.PerformLayout();
            this.grpLapPhieu.ResumeLayout(false);
            this.grpLapPhieu.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numMuonSL)).EndInit();
            this.tabCanhBaoThongKe.ResumeLayout(false);
            this.tabCanhBaoThongKe.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvThongKe)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvQuaHan)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabMain;
        private System.Windows.Forms.TabPage tabSach;
        private System.Windows.Forms.TabPage tabDocGia;
        private System.Windows.Forms.ComboBox cboTheLoai;
        private System.Windows.Forms.TextBox txtTenSach;
        private System.Windows.Forms.TextBox txtMaSach;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnXoaSach;
        private System.Windows.Forms.Button btnSuaSach;
        private System.Windows.Forms.Button btnThemSach;
        private System.Windows.Forms.NumericUpDown numSoLuong;
        private System.Windows.Forms.DataGridView dgvSach;
        private System.Windows.Forms.DateTimePicker dtpHanThe;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.TextBox txtHoTen;
        private System.Windows.Forms.TextBox txtMaDG;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DataGridView dgvDocGia;
        private System.Windows.Forms.Button btnXoaDG;
        private System.Windows.Forms.Button btnSuaDG;
        private System.Windows.Forms.Button btnThemDG;
        private System.Windows.Forms.TabPage tabMuonTra;
        private System.Windows.Forms.GroupBox grpTheoDoi;
        private System.Windows.Forms.GroupBox grpLapPhieu;
        private System.Windows.Forms.Button btnLapPhieu;
        private System.Windows.Forms.DateTimePicker dtpHanTra;
        private System.Windows.Forms.NumericUpDown numMuonSL;
        private System.Windows.Forms.ComboBox cboMuonSach;
        private System.Windows.Forms.ComboBox cboMuonDocGia;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox cboLocTrangThai;
        private System.Windows.Forms.ComboBox cboLocDocGia;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.DataGridView dgvPhieuMuon;
        private System.Windows.Forms.Button btnLoc;
        private System.Windows.Forms.Button btnTraSach;
        private System.Windows.Forms.TabPage tabCanhBaoThongKe;
        private System.Windows.Forms.Button btnKiemTraQuaHan;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Button btnThongKe;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.DataGridView dgvQuaHan;
        private System.Windows.Forms.DataGridView dgvThongKe;
        private System.Windows.Forms.Label lblTongKetTheLoai;
    }
}

