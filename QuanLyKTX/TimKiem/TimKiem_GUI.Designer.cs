
namespace QuanLyKTX.TimKiem
{
    partial class TimKiem_GUI
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
            this.grbShow = new System.Windows.Forms.GroupBox();
            this.dtGrid_SinhVien = new System.Windows.Forms.DataGridView();
            this.grbSearch = new System.Windows.Forms.GroupBox();
            this.grbNhanVien = new System.Windows.Forms.GroupBox();
            this.btn_Thoat = new System.Windows.Forms.Button();
            this.btn_TimKiemMSV = new System.Windows.Forms.Button();
            this.txtTimKiemSV = new System.Windows.Forms.TextBox();
            this.lblMsv = new System.Windows.Forms.Label();
            this.grbThongTin = new System.Windows.Forms.GroupBox();
            this.lblTenPhong = new System.Windows.Forms.Label();
            this.lblTenKhuNha = new System.Windows.Forms.Label();
            this.lblHVT = new System.Windows.Forms.Label();
            this.lblLop = new System.Windows.Forms.Label();
            this.lblKhoa = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblMaSV = new System.Windows.Forms.Label();
            this.txtMSV = new System.Windows.Forms.TextBox();
            this.txtHVT = new System.Windows.Forms.TextBox();
            this.txtLop = new System.Windows.Forms.TextBox();
            this.txtKhoa = new System.Windows.Forms.TextBox();
            this.txtTenPhong = new System.Windows.Forms.TextBox();
            this.txtTenKhuNha = new System.Windows.Forms.TextBox();
            this.dtp_NgaySinh = new System.Windows.Forms.DateTimePicker();
            this.rdb_Nu = new System.Windows.Forms.RadioButton();
            this.rdb_Nam = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.txtQue = new System.Windows.Forms.TextBox();
            this.btnHienThi = new System.Windows.Forms.Button();
            this.grbShow.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtGrid_SinhVien)).BeginInit();
            this.grbSearch.SuspendLayout();
            this.grbNhanVien.SuspendLayout();
            this.grbThongTin.SuspendLayout();
            this.SuspendLayout();
            // 
            // grbShow
            // 
            this.grbShow.Controls.Add(this.dtGrid_SinhVien);
            this.grbShow.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grbShow.Location = new System.Drawing.Point(12, 369);
            this.grbShow.Name = "grbShow";
            this.grbShow.Size = new System.Drawing.Size(1391, 296);
            this.grbShow.TabIndex = 3;
            this.grbShow.TabStop = false;
            this.grbShow.Text = "Hiển thị";
            // 
            // dtGrid_SinhVien
            // 
            this.dtGrid_SinhVien.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dtGrid_SinhVien.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtGrid_SinhVien.Location = new System.Drawing.Point(29, 41);
            this.dtGrid_SinhVien.Name = "dtGrid_SinhVien";
            this.dtGrid_SinhVien.RowHeadersWidth = 51;
            this.dtGrid_SinhVien.RowTemplate.Height = 24;
            this.dtGrid_SinhVien.Size = new System.Drawing.Size(1347, 249);
            this.dtGrid_SinhVien.TabIndex = 0;
            this.dtGrid_SinhVien.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtGrid_SinhVien_CellClick);
            // 
            // grbSearch
            // 
            this.grbSearch.Controls.Add(this.grbNhanVien);
            this.grbSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grbSearch.Location = new System.Drawing.Point(688, 32);
            this.grbSearch.Name = "grbSearch";
            this.grbSearch.Size = new System.Drawing.Size(715, 331);
            this.grbSearch.TabIndex = 2;
            this.grbSearch.TabStop = false;
            this.grbSearch.Text = "Tìm kiếm";
            // 
            // grbNhanVien
            // 
            this.grbNhanVien.Controls.Add(this.btnHienThi);
            this.grbNhanVien.Controls.Add(this.btn_Thoat);
            this.grbNhanVien.Controls.Add(this.btn_TimKiemMSV);
            this.grbNhanVien.Controls.Add(this.txtTimKiemSV);
            this.grbNhanVien.Controls.Add(this.lblMsv);
            this.grbNhanVien.Location = new System.Drawing.Point(67, 46);
            this.grbNhanVien.Name = "grbNhanVien";
            this.grbNhanVien.Size = new System.Drawing.Size(577, 232);
            this.grbNhanVien.TabIndex = 0;
            this.grbNhanVien.TabStop = false;
            this.grbNhanVien.Text = "Tìm kiếm  sinh viên";
            // 
            // btn_Thoat
            // 
            this.btn_Thoat.Image = global::QuanLyKTX.Properties.Resources.Thoat321;
            this.btn_Thoat.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_Thoat.Location = new System.Drawing.Point(380, 128);
            this.btn_Thoat.Name = "btn_Thoat";
            this.btn_Thoat.Size = new System.Drawing.Size(122, 45);
            this.btn_Thoat.TabIndex = 9;
            this.btn_Thoat.Text = "Thoát";
            this.btn_Thoat.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_Thoat.UseVisualStyleBackColor = true;
            this.btn_Thoat.Click += new System.EventHandler(this.btn_Thoat_Click);
            // 
            // btn_TimKiemMSV
            // 
            this.btn_TimKiemMSV.Image = global::QuanLyKTX.Properties.Resources.TraCuu32;
            this.btn_TimKiemMSV.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_TimKiemMSV.Location = new System.Drawing.Point(224, 128);
            this.btn_TimKiemMSV.Name = "btn_TimKiemMSV";
            this.btn_TimKiemMSV.Size = new System.Drawing.Size(122, 45);
            this.btn_TimKiemMSV.TabIndex = 8;
            this.btn_TimKiemMSV.Text = "Tìm kiếm";
            this.btn_TimKiemMSV.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_TimKiemMSV.UseVisualStyleBackColor = true;
            this.btn_TimKiemMSV.Click += new System.EventHandler(this.btn_TimKiemMSV_Click);
            // 
            // txtTimKiemSV
            // 
            this.txtTimKiemSV.Location = new System.Drawing.Point(189, 61);
            this.txtTimKiemSV.Name = "txtTimKiemSV";
            this.txtTimKiemSV.Size = new System.Drawing.Size(313, 22);
            this.txtTimKiemSV.TabIndex = 1;
            // 
            // lblMsv
            // 
            this.lblMsv.AutoSize = true;
            this.lblMsv.Location = new System.Drawing.Point(68, 66);
            this.lblMsv.Name = "lblMsv";
            this.lblMsv.Size = new System.Drawing.Size(85, 17);
            this.lblMsv.TabIndex = 0;
            this.lblMsv.Text = "Sinh viên :";
            // 
            // grbThongTin
            // 
            this.grbThongTin.BackColor = System.Drawing.SystemColors.Control;
            this.grbThongTin.Controls.Add(this.txtQue);
            this.grbThongTin.Controls.Add(this.label1);
            this.grbThongTin.Controls.Add(this.rdb_Nu);
            this.grbThongTin.Controls.Add(this.rdb_Nam);
            this.grbThongTin.Controls.Add(this.dtp_NgaySinh);
            this.grbThongTin.Controls.Add(this.txtTenKhuNha);
            this.grbThongTin.Controls.Add(this.txtTenPhong);
            this.grbThongTin.Controls.Add(this.txtKhoa);
            this.grbThongTin.Controls.Add(this.txtLop);
            this.grbThongTin.Controls.Add(this.txtHVT);
            this.grbThongTin.Controls.Add(this.txtMSV);
            this.grbThongTin.Controls.Add(this.lblTenPhong);
            this.grbThongTin.Controls.Add(this.lblTenKhuNha);
            this.grbThongTin.Controls.Add(this.lblHVT);
            this.grbThongTin.Controls.Add(this.lblLop);
            this.grbThongTin.Controls.Add(this.lblKhoa);
            this.grbThongTin.Controls.Add(this.label3);
            this.grbThongTin.Controls.Add(this.label2);
            this.grbThongTin.Controls.Add(this.lblMaSV);
            this.grbThongTin.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grbThongTin.Location = new System.Drawing.Point(12, 32);
            this.grbThongTin.Name = "grbThongTin";
            this.grbThongTin.Size = new System.Drawing.Size(569, 331);
            this.grbThongTin.TabIndex = 4;
            this.grbThongTin.TabStop = false;
            this.grbThongTin.Text = "Thông tin";
            // 
            // lblTenPhong
            // 
            this.lblTenPhong.AutoSize = true;
            this.lblTenPhong.Location = new System.Drawing.Point(21, 256);
            this.lblTenPhong.Name = "lblTenPhong";
            this.lblTenPhong.Size = new System.Drawing.Size(96, 17);
            this.lblTenPhong.TabIndex = 9;
            this.lblTenPhong.Text = "Tên phòng :";
            // 
            // lblTenKhuNha
            // 
            this.lblTenKhuNha.AutoSize = true;
            this.lblTenKhuNha.Location = new System.Drawing.Point(21, 295);
            this.lblTenKhuNha.Name = "lblTenKhuNha";
            this.lblTenKhuNha.Size = new System.Drawing.Size(109, 17);
            this.lblTenKhuNha.TabIndex = 8;
            this.lblTenKhuNha.Text = "Tên khu nhà :";
            // 
            // lblHVT
            // 
            this.lblHVT.AutoSize = true;
            this.lblHVT.Location = new System.Drawing.Point(21, 63);
            this.lblHVT.Name = "lblHVT";
            this.lblHVT.Size = new System.Drawing.Size(88, 17);
            this.lblHVT.TabIndex = 5;
            this.lblHVT.Text = "Họ và tên :";
            // 
            // lblLop
            // 
            this.lblLop.AutoSize = true;
            this.lblLop.Location = new System.Drawing.Point(21, 188);
            this.lblLop.Name = "lblLop";
            this.lblLop.Size = new System.Drawing.Size(50, 17);
            this.lblLop.TabIndex = 4;
            this.lblLop.Text = "Lớp  :";
            // 
            // lblKhoa
            // 
            this.lblKhoa.AutoSize = true;
            this.lblKhoa.Location = new System.Drawing.Point(21, 222);
            this.lblKhoa.Name = "lblKhoa";
            this.lblKhoa.Size = new System.Drawing.Size(55, 17);
            this.lblKhoa.TabIndex = 3;
            this.lblKhoa.Text = "Khoa :";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(21, 126);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(84, 17);
            this.label3.TabIndex = 2;
            this.label3.Text = "Giới tính : ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(21, 96);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(90, 17);
            this.label2.TabIndex = 1;
            this.label2.Text = "Ngày sinh :";
            // 
            // lblMaSV
            // 
            this.lblMaSV.AutoSize = true;
            this.lblMaSV.Location = new System.Drawing.Point(21, 31);
            this.lblMaSV.Name = "lblMaSV";
            this.lblMaSV.Size = new System.Drawing.Size(109, 17);
            this.lblMaSV.TabIndex = 0;
            this.lblMaSV.Text = "Mã sinh viên :";
            // 
            // txtMSV
            // 
            this.txtMSV.Enabled = false;
            this.txtMSV.Location = new System.Drawing.Point(153, 26);
            this.txtMSV.Name = "txtMSV";
            this.txtMSV.Size = new System.Drawing.Size(309, 22);
            this.txtMSV.TabIndex = 10;
            // 
            // txtHVT
            // 
            this.txtHVT.Enabled = false;
            this.txtHVT.Location = new System.Drawing.Point(153, 58);
            this.txtHVT.Name = "txtHVT";
            this.txtHVT.Size = new System.Drawing.Size(309, 22);
            this.txtHVT.TabIndex = 11;
            // 
            // txtLop
            // 
            this.txtLop.Enabled = false;
            this.txtLop.Location = new System.Drawing.Point(153, 183);
            this.txtLop.Name = "txtLop";
            this.txtLop.Size = new System.Drawing.Size(309, 22);
            this.txtLop.TabIndex = 13;
            // 
            // txtKhoa
            // 
            this.txtKhoa.Enabled = false;
            this.txtKhoa.Location = new System.Drawing.Point(153, 219);
            this.txtKhoa.Name = "txtKhoa";
            this.txtKhoa.Size = new System.Drawing.Size(309, 22);
            this.txtKhoa.TabIndex = 14;
            // 
            // txtTenPhong
            // 
            this.txtTenPhong.Enabled = false;
            this.txtTenPhong.Location = new System.Drawing.Point(153, 256);
            this.txtTenPhong.Name = "txtTenPhong";
            this.txtTenPhong.Size = new System.Drawing.Size(309, 22);
            this.txtTenPhong.TabIndex = 15;
            // 
            // txtTenKhuNha
            // 
            this.txtTenKhuNha.Enabled = false;
            this.txtTenKhuNha.Location = new System.Drawing.Point(153, 290);
            this.txtTenKhuNha.Name = "txtTenKhuNha";
            this.txtTenKhuNha.Size = new System.Drawing.Size(309, 22);
            this.txtTenKhuNha.TabIndex = 16;
            // 
            // dtp_NgaySinh
            // 
            this.dtp_NgaySinh.Enabled = false;
            this.dtp_NgaySinh.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtp_NgaySinh.Location = new System.Drawing.Point(153, 91);
            this.dtp_NgaySinh.MaxDate = new System.DateTime(2015, 10, 14, 0, 0, 0, 0);
            this.dtp_NgaySinh.MinDate = new System.DateTime(1950, 7, 13, 0, 0, 0, 0);
            this.dtp_NgaySinh.Name = "dtp_NgaySinh";
            this.dtp_NgaySinh.Size = new System.Drawing.Size(175, 22);
            this.dtp_NgaySinh.TabIndex = 20;
            this.dtp_NgaySinh.Value = new System.DateTime(1950, 7, 13, 0, 0, 0, 0);
            // 
            // rdb_Nu
            // 
            this.rdb_Nu.AutoSize = true;
            this.rdb_Nu.Enabled = false;
            this.rdb_Nu.Location = new System.Drawing.Point(279, 124);
            this.rdb_Nu.Name = "rdb_Nu";
            this.rdb_Nu.Size = new System.Drawing.Size(49, 21);
            this.rdb_Nu.TabIndex = 23;
            this.rdb_Nu.TabStop = true;
            this.rdb_Nu.Text = "Nữ";
            this.rdb_Nu.UseVisualStyleBackColor = true;
            // 
            // rdb_Nam
            // 
            this.rdb_Nam.AutoSize = true;
            this.rdb_Nam.Enabled = false;
            this.rdb_Nam.Location = new System.Drawing.Point(153, 126);
            this.rdb_Nam.Name = "rdb_Nam";
            this.rdb_Nam.Size = new System.Drawing.Size(61, 21);
            this.rdb_Nam.TabIndex = 22;
            this.rdb_Nam.TabStop = true;
            this.rdb_Nam.Text = "Nam";
            this.rdb_Nam.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(21, 157);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 17);
            this.label1.TabIndex = 24;
            this.label1.Text = "Quê : ";
            // 
            // txtQue
            // 
            this.txtQue.Enabled = false;
            this.txtQue.Location = new System.Drawing.Point(153, 153);
            this.txtQue.Name = "txtQue";
            this.txtQue.Size = new System.Drawing.Size(309, 22);
            this.txtQue.TabIndex = 25;
            // 
            // btnHienThi
            // 
            this.btnHienThi.Image = global::QuanLyKTX.Properties.Resources.HienThi32;
            this.btnHienThi.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnHienThi.Location = new System.Drawing.Point(71, 128);
            this.btnHienThi.Name = "btnHienThi";
            this.btnHienThi.Size = new System.Drawing.Size(122, 45);
            this.btnHienThi.TabIndex = 10;
            this.btnHienThi.Text = "Hiển thị";
            this.btnHienThi.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnHienThi.UseVisualStyleBackColor = true;
            this.btnHienThi.Click += new System.EventHandler(this.btnHienThi_Click);
            // 
            // TimKiem_GUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1415, 677);
            this.Controls.Add(this.grbThongTin);
            this.Controls.Add(this.grbShow);
            this.Controls.Add(this.grbSearch);
            this.Name = "TimKiem_GUI";
            this.Text = "Tìm Kiếm";
            this.Load += new System.EventHandler(this.TimKiem_GUI_Load);
            this.grbShow.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtGrid_SinhVien)).EndInit();
            this.grbSearch.ResumeLayout(false);
            this.grbNhanVien.ResumeLayout(false);
            this.grbNhanVien.PerformLayout();
            this.grbThongTin.ResumeLayout(false);
            this.grbThongTin.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grbShow;
        private System.Windows.Forms.DataGridView dtGrid_SinhVien;
        private System.Windows.Forms.GroupBox grbSearch;
        private System.Windows.Forms.GroupBox grbNhanVien;
        private System.Windows.Forms.Button btn_TimKiemMSV;
        private System.Windows.Forms.TextBox txtTimKiemSV;
        private System.Windows.Forms.Label lblMsv;
        private System.Windows.Forms.GroupBox grbThongTin;
        private System.Windows.Forms.Label lblTenPhong;
        private System.Windows.Forms.Label lblTenKhuNha;
        private System.Windows.Forms.Label lblHVT;
        private System.Windows.Forms.Label lblLop;
        private System.Windows.Forms.Label lblKhoa;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblMaSV;
        private System.Windows.Forms.Button btn_Thoat;
        private System.Windows.Forms.TextBox txtTenKhuNha;
        private System.Windows.Forms.TextBox txtTenPhong;
        private System.Windows.Forms.TextBox txtKhoa;
        private System.Windows.Forms.TextBox txtLop;
        private System.Windows.Forms.TextBox txtHVT;
        private System.Windows.Forms.TextBox txtMSV;
        private System.Windows.Forms.DateTimePicker dtp_NgaySinh;
        private System.Windows.Forms.RadioButton rdb_Nu;
        private System.Windows.Forms.RadioButton rdb_Nam;
        private System.Windows.Forms.TextBox txtQue;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnHienThi;
    }
}