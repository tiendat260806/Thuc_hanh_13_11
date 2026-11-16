namespace Bai6_8
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
            this.gbSoDoBan = new System.Windows.Forms.GroupBox();
            this.flpBanBida = new System.Windows.Forms.FlowLayoutPanel();
            this.lblNoteOrange = new System.Windows.Forms.Label();
            this.lblNoteGreen = new System.Windows.Forms.Label();
            this.btnMoBan = new System.Windows.Forms.Button();
            this.gbChiTiet = new System.Windows.Forms.GroupBox();
            this.lblGiaBan = new System.Windows.Forms.Label();
            this.lblGioBatDau = new System.Windows.Forms.Label();
            this.lblTenBanChon = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.cboDichVu = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.nmSoLuong = new System.Windows.Forms.NumericUpDown();
            this.btnThemDV = new System.Windows.Forms.Button();
            this.dgvDichVuDat = new System.Windows.Forms.DataGridView();
            this.label2 = new System.Windows.Forms.Label();
            this.lblTienGio = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lblTienDV = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.lblTongTien = new System.Windows.Forms.Label();
            this.btnThanhToan = new System.Windows.Forms.Button();
            this.gbSoDoBan.SuspendLayout();
            this.gbChiTiet.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nmSoLuong)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDichVuDat)).BeginInit();
            this.SuspendLayout();
            // 
            // gbSoDoBan
            // 
            this.gbSoDoBan.Controls.Add(this.btnMoBan);
            this.gbSoDoBan.Controls.Add(this.lblNoteGreen);
            this.gbSoDoBan.Controls.Add(this.lblNoteOrange);
            this.gbSoDoBan.Controls.Add(this.flpBanBida);
            this.gbSoDoBan.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbSoDoBan.Location = new System.Drawing.Point(24, 29);
            this.gbSoDoBan.Name = "gbSoDoBan";
            this.gbSoDoBan.Size = new System.Drawing.Size(493, 570);
            this.gbSoDoBan.TabIndex = 0;
            this.gbSoDoBan.TabStop = false;
            this.gbSoDoBan.Text = "Sơ đồ bàn Bida trực quan";
            // 
            // flpBanBida
            // 
            this.flpBanBida.AutoScroll = true;
            this.flpBanBida.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.flpBanBida.Location = new System.Drawing.Point(15, 29);
            this.flpBanBida.Name = "flpBanBida";
            this.flpBanBida.Size = new System.Drawing.Size(460, 459);
            this.flpBanBida.TabIndex = 0;
            this.flpBanBida.Paint += new System.Windows.Forms.PaintEventHandler(this.flpBanBida_Paint);
            // 
            // lblNoteOrange
            // 
            this.lblNoteOrange.AutoSize = true;
            this.lblNoteOrange.ForeColor = System.Drawing.Color.OrangeRed;
            this.lblNoteOrange.Location = new System.Drawing.Point(279, 500);
            this.lblNoteOrange.Name = "lblNoteOrange";
            this.lblNoteOrange.Size = new System.Drawing.Size(140, 16);
            this.lblNoteOrange.TabIndex = 1;
            this.lblNoteOrange.Text = "■ Đang Chơi (Cam/Đỏ)";
            this.lblNoteOrange.Click += new System.EventHandler(this.lblNoteOrange_Click);
            // 
            // lblNoteGreen
            // 
            this.lblNoteGreen.AutoSize = true;
            this.lblNoteGreen.ForeColor = System.Drawing.Color.DarkGreen;
            this.lblNoteGreen.Location = new System.Drawing.Point(53, 500);
            this.lblNoteGreen.Name = "lblNoteGreen";
            this.lblNoteGreen.Size = new System.Drawing.Size(136, 16);
            this.lblNoteGreen.TabIndex = 2;
            this.lblNoteGreen.Text = "■ Bàn Trống (Xanh lá)";
            this.lblNoteGreen.Click += new System.EventHandler(this.lblNoteGreen_Click);
            // 
            // btnMoBan
            // 
            this.btnMoBan.Location = new System.Drawing.Point(15, 531);
            this.btnMoBan.Name = "btnMoBan";
            this.btnMoBan.Size = new System.Drawing.Size(111, 23);
            this.btnMoBan.TabIndex = 3;
            this.btnMoBan.Text = "MỞ BÀN CHƠI";
            this.btnMoBan.UseVisualStyleBackColor = true;
            this.btnMoBan.Click += new System.EventHandler(this.btnMoBan_Click);
            // 
            // gbChiTiet
            // 
            this.gbChiTiet.Controls.Add(this.btnThanhToan);
            this.gbChiTiet.Controls.Add(this.lblTongTien);
            this.gbChiTiet.Controls.Add(this.label7);
            this.gbChiTiet.Controls.Add(this.lblTienDV);
            this.gbChiTiet.Controls.Add(this.label5);
            this.gbChiTiet.Controls.Add(this.lblTienGio);
            this.gbChiTiet.Controls.Add(this.label2);
            this.gbChiTiet.Controls.Add(this.dgvDichVuDat);
            this.gbChiTiet.Controls.Add(this.btnThemDV);
            this.gbChiTiet.Controls.Add(this.nmSoLuong);
            this.gbChiTiet.Controls.Add(this.label1);
            this.gbChiTiet.Controls.Add(this.cboDichVu);
            this.gbChiTiet.Controls.Add(this.label4);
            this.gbChiTiet.Controls.Add(this.lblTenBanChon);
            this.gbChiTiet.Controls.Add(this.lblGioBatDau);
            this.gbChiTiet.Controls.Add(this.lblGiaBan);
            this.gbChiTiet.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbChiTiet.Location = new System.Drawing.Point(579, 29);
            this.gbChiTiet.Name = "gbChiTiet";
            this.gbChiTiet.Size = new System.Drawing.Size(772, 570);
            this.gbChiTiet.TabIndex = 1;
            this.gbChiTiet.TabStop = false;
            this.gbChiTiet.Text = "Chi tiết giờ chơi, Dịch vụ & Thanh toán";
            // 
            // lblGiaBan
            // 
            this.lblGiaBan.AutoSize = true;
            this.lblGiaBan.Location = new System.Drawing.Point(397, 29);
            this.lblGiaBan.Name = "lblGiaBan";
            this.lblGiaBan.Size = new System.Drawing.Size(121, 16);
            this.lblGiaBan.TabIndex = 0;
            this.lblGiaBan.Text = "Giá bàn/giờ: 0 VNĐ";
            this.lblGiaBan.Click += new System.EventHandler(this.lblGiaBan_Click);
            // 
            // lblGioBatDau
            // 
            this.lblGioBatDau.AutoSize = true;
            this.lblGioBatDau.Location = new System.Drawing.Point(246, 29);
            this.lblGioBatDau.Name = "lblGioBatDau";
            this.lblGioBatDau.Size = new System.Drawing.Size(112, 16);
            this.lblGioBatDau.TabIndex = 1;
            this.lblGioBatDau.Text = "Giờ bắt đầu: --:--:--";
            this.lblGioBatDau.Click += new System.EventHandler(this.lblGioBatDau_Click);
            // 
            // lblTenBanChon
            // 
            this.lblTenBanChon.AutoSize = true;
            this.lblTenBanChon.Location = new System.Drawing.Point(30, 29);
            this.lblTenBanChon.Name = "lblTenBanChon";
            this.lblTenBanChon.Size = new System.Drawing.Size(166, 16);
            this.lblTenBanChon.TabIndex = 2;
            this.lblTenBanChon.Text = "Bàn đang chọn: Chưa chọn";
            this.lblTenBanChon.Click += new System.EventHandler(this.lblTenBanChon_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(30, 69);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(161, 16);
            this.label4.TabIndex = 3;
            this.label4.Text = "Chọn Đồ uống / Thuê gậy:";
            // 
            // cboDichVu
            // 
            this.cboDichVu.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboDichVu.FormattingEnabled = true;
            this.cboDichVu.Location = new System.Drawing.Point(211, 63);
            this.cboDichVu.Name = "cboDichVu";
            this.cboDichVu.Size = new System.Drawing.Size(121, 24);
            this.cboDichVu.TabIndex = 4;
            this.cboDichVu.SelectedIndexChanged += new System.EventHandler(this.cboDichVu_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(372, 69);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 16);
            this.label1.TabIndex = 5;
            this.label1.Text = "Số lượng:";
            // 
            // nmSoLuong
            // 
            this.nmSoLuong.Location = new System.Drawing.Point(441, 63);
            this.nmSoLuong.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nmSoLuong.Name = "nmSoLuong";
            this.nmSoLuong.Size = new System.Drawing.Size(120, 22);
            this.nmSoLuong.TabIndex = 6;
            this.nmSoLuong.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nmSoLuong.ValueChanged += new System.EventHandler(this.nmSoLuong_ValueChanged);
            // 
            // btnThemDV
            // 
            this.btnThemDV.Location = new System.Drawing.Point(33, 105);
            this.btnThemDV.Name = "btnThemDV";
            this.btnThemDV.Size = new System.Drawing.Size(164, 23);
            this.btnThemDV.TabIndex = 7;
            this.btnThemDV.Text = "Thêm / Tăng SL món";
            this.btnThemDV.UseVisualStyleBackColor = true;
            this.btnThemDV.Click += new System.EventHandler(this.btnThemDV_Click);
            // 
            // dgvDichVuDat
            // 
            this.dgvDichVuDat.AllowUserToAddRows = false;
            this.dgvDichVuDat.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvDichVuDat.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDichVuDat.Location = new System.Drawing.Point(7, 142);
            this.dgvDichVuDat.Name = "dgvDichVuDat";
            this.dgvDichVuDat.ReadOnly = true;
            this.dgvDichVuDat.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDichVuDat.Size = new System.Drawing.Size(759, 346);
            this.dgvDichVuDat.TabIndex = 8;
            this.dgvDichVuDat.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDichVuDat_CellContentClick);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(14, 500);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(183, 16);
            this.label2.TabIndex = 9;
            this.label2.Text = "Tiền giờ chơi (Block 15p):";
            // 
            // lblTienGio
            // 
            this.lblTienGio.AutoSize = true;
            this.lblTienGio.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTienGio.Location = new System.Drawing.Point(208, 500);
            this.lblTienGio.Name = "lblTienGio";
            this.lblTienGio.Size = new System.Drawing.Size(50, 16);
            this.lblTienGio.TabIndex = 10;
            this.lblTienGio.Text = "0 VNĐ";
            this.lblTienGio.Click += new System.EventHandler(this.lblTienGio_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(339, 500);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(96, 16);
            this.label5.TabIndex = 11;
            this.label5.Text = "Tiền dịch vụ:";
            // 
            // lblTienDV
            // 
            this.lblTienDV.AutoSize = true;
            this.lblTienDV.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTienDV.Location = new System.Drawing.Point(441, 500);
            this.lblTienDV.Name = "lblTienDV";
            this.lblTienDV.Size = new System.Drawing.Size(50, 16);
            this.lblTienDV.TabIndex = 12;
            this.lblTienDV.Text = "0 VNĐ";
            this.lblTienDV.Click += new System.EventHandler(this.lblTienDV_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(14, 538);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(158, 16);
            this.label7.TabIndex = 13;
            this.label7.Text = "TỔNG THANH TOÁN:";
            // 
            // lblTongTien
            // 
            this.lblTongTien.AutoSize = true;
            this.lblTongTien.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTongTien.Location = new System.Drawing.Point(178, 538);
            this.lblTongTien.Name = "lblTongTien";
            this.lblTongTien.Size = new System.Drawing.Size(50, 16);
            this.lblTongTien.TabIndex = 14;
            this.lblTongTien.Text = "0 VNĐ";
            this.lblTongTien.Click += new System.EventHandler(this.lblTongTien_Click);
            // 
            // btnThanhToan
            // 
            this.btnThanhToan.Location = new System.Drawing.Point(342, 531);
            this.btnThanhToan.Name = "btnThanhToan";
            this.btnThanhToan.Size = new System.Drawing.Size(170, 23);
            this.btnThanhToan.TabIndex = 15;
            this.btnThanhToan.Text = "THANH TOÁN HÓA ĐƠN";
            this.btnThanhToan.UseVisualStyleBackColor = true;
            this.btnThanhToan.Click += new System.EventHandler(this.btnThanhToan_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1363, 633);
            this.Controls.Add(this.gbChiTiet);
            this.Controls.Add(this.gbSoDoBan);
            this.Name = "Form1";
            this.Text = "HỆ THỐNG QUẢN LÝ BÀN BIDA & DỊCH VỤ GIẢI TRÍ (BILLIARDS CLUB)";
            this.gbSoDoBan.ResumeLayout(false);
            this.gbSoDoBan.PerformLayout();
            this.gbChiTiet.ResumeLayout(false);
            this.gbChiTiet.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nmSoLuong)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDichVuDat)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbSoDoBan;
        private System.Windows.Forms.Label lblNoteGreen;
        private System.Windows.Forms.Label lblNoteOrange;
        private System.Windows.Forms.FlowLayoutPanel flpBanBida;
        private System.Windows.Forms.Button btnMoBan;
        private System.Windows.Forms.GroupBox gbChiTiet;
        private System.Windows.Forms.Button btnThemDV;
        private System.Windows.Forms.NumericUpDown nmSoLuong;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cboDichVu;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblTenBanChon;
        private System.Windows.Forms.Label lblGioBatDau;
        private System.Windows.Forms.Label lblGiaBan;
        private System.Windows.Forms.Label lblTongTien;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label lblTienDV;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblTienGio;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView dgvDichVuDat;
        private System.Windows.Forms.Button btnThanhToan;
    }
}

