
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
            this.dgv_TimKiem = new System.Windows.Forms.DataGridView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btn_InExcel = new System.Windows.Forms.Button();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.cbb_TTTP = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.button4 = new System.Windows.Forms.Button();
            this.label22 = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.txt_SinhVien = new System.Windows.Forms.TextBox();
            this.txt_Phong = new System.Windows.Forms.TextBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.txt_MST = new System.Windows.Forms.TextBox();
            this.txt_TT = new System.Windows.Forms.TextBox();
            this.label17 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.txt_NgayKT = new System.Windows.Forms.TextBox();
            this.txt_NgayBD = new System.Windows.Forms.TextBox();
            this.label19 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.txt_MaSV = new System.Windows.Forms.TextBox();
            this.txt_GioiTinh = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.txt_NgaySinh = new System.Windows.Forms.TextBox();
            this.txt_TenSV = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.txt_MaP = new System.Windows.Forms.TextBox();
            this.txt_GiaPhong = new System.Windows.Forms.TextBox();
            this.txt_SoLuongNow = new System.Windows.Forms.TextBox();
            this.txt_SoLuongMax = new System.Windows.Forms.TextBox();
            this.txt_LoaiPhong = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.txt_TenPhong = new System.Windows.Forms.TextBox();
            this.lbl_TenKhuNha = new System.Windows.Forms.Label();
            this.lbl_MaKhuNha = new System.Windows.Forms.Label();
            this.dlgSaveFile = new System.Windows.Forms.SaveFileDialog();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_TimKiem)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgv_TimKiem
            // 
            this.dgv_TimKiem.BackgroundColor = System.Drawing.Color.Silver;
            this.dgv_TimKiem.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_TimKiem.Location = new System.Drawing.Point(10, 416);
            this.dgv_TimKiem.Name = "dgv_TimKiem";
            this.dgv_TimKiem.ReadOnly = true;
            this.dgv_TimKiem.RowHeadersWidth = 51;
            this.dgv_TimKiem.RowTemplate.Height = 24;
            this.dgv_TimKiem.Size = new System.Drawing.Size(1474, 354);
            this.dgv_TimKiem.TabIndex = 15;
            this.dgv_TimKiem.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_TimKiem_CellClick);
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Transparent;
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Controls.Add(this.groupBox6);
            this.groupBox1.Controls.Add(this.groupBox3);
            this.groupBox1.Controls.Add(this.groupBox5);
            this.groupBox1.Controls.Add(this.groupBox4);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(10, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1474, 398);
            this.groupBox1.TabIndex = 14;
            this.groupBox1.TabStop = false;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btn_InExcel);
            this.groupBox2.Location = new System.Drawing.Point(730, 241);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(347, 143);
            this.groupBox2.TabIndex = 29;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Xuất dữ liệu Ra Excel";
            // 
            // btn_InExcel
            // 
            this.btn_InExcel.BackgroundImage = global::QuanLyKTX.Properties.Resources.SaoLuu32;
            this.btn_InExcel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btn_InExcel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_InExcel.Location = new System.Drawing.Point(129, 54);
            this.btn_InExcel.Name = "btn_InExcel";
            this.btn_InExcel.Size = new System.Drawing.Size(160, 46);
            this.btn_InExcel.TabIndex = 28;
            this.btn_InExcel.Text = "In danh sách ";
            this.btn_InExcel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_InExcel.UseVisualStyleBackColor = true;
            this.btn_InExcel.Click += new System.EventHandler(this.btc_InExcel_Click);
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.button1);
            this.groupBox6.Controls.Add(this.button2);
            this.groupBox6.Controls.Add(this.button3);
            this.groupBox6.Controls.Add(this.cbb_TTTP);
            this.groupBox6.Controls.Add(this.label2);
            this.groupBox6.Controls.Add(this.button4);
            this.groupBox6.Controls.Add(this.label22);
            this.groupBox6.Controls.Add(this.label21);
            this.groupBox6.Controls.Add(this.txt_SinhVien);
            this.groupBox6.Controls.Add(this.txt_Phong);
            this.groupBox6.Location = new System.Drawing.Point(1097, 23);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(362, 362);
            this.groupBox6.TabIndex = 23;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Tìm Kiếm";
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Image = global::QuanLyKTX.Properties.Resources.ChuyenPhong161;
            this.button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button1.Location = new System.Drawing.Point(211, 199);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(106, 54);
            this.button1.TabIndex = 20;
            this.button1.Text = "Reset";
            this.button1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.btn_Reset_Click);
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.Image = global::QuanLyKTX.Properties.Resources.Thoat321;
            this.button2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button2.Location = new System.Drawing.Point(211, 294);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(106, 54);
            this.button2.TabIndex = 7;
            this.button2.Text = "Thoát";
            this.button2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.btn_Thoat_Click);
            // 
            // button3
            // 
            this.button3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button3.Image = global::QuanLyKTX.Properties.Resources.ChuyenPhong161;
            this.button3.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button3.Location = new System.Drawing.Point(29, 294);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(146, 54);
            this.button3.TabIndex = 9;
            this.button3.Text = "Hiển thị tất cả";
            this.button3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.btn_Show_Click);
            // 
            // cbb_TTTP
            // 
            this.cbb_TTTP.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbb_TTTP.FormattingEnabled = true;
            this.cbb_TTTP.Items.AddRange(new object[] {
            "No Search ...",
            "Chưa Đến Ở",
            "Đang Ở",
            "Đã Dọn Đi"});
            this.cbb_TTTP.Location = new System.Drawing.Point(195, 148);
            this.cbb_TTTP.Name = "cbb_TTTP";
            this.cbb_TTTP.Size = new System.Drawing.Size(151, 26);
            this.cbb_TTTP.TabIndex = 30;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 151);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(166, 18);
            this.label2.TabIndex = 28;
            this.label2.Text = "Trạng Thái Thuê Phòng:";
            // 
            // button4
            // 
            this.button4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button4.Image = global::QuanLyKTX.Properties.Resources.TraCuu32;
            this.button4.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button4.Location = new System.Drawing.Point(29, 201);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(146, 54);
            this.button4.TabIndex = 6;
            this.button4.Text = "Tìm kiếm";
            this.button4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.btn_TimKiem_Click);
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Location = new System.Drawing.Point(24, 108);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(112, 18);
            this.label22.TabIndex = 26;
            this.label22.Text = "Nhập Sinh Viên:";
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(26, 53);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(94, 18);
            this.label21.TabIndex = 16;
            this.label21.Text = "Nhập Phòng:";
            // 
            // txt_SinhVien
            // 
            this.txt_SinhVien.Location = new System.Drawing.Point(168, 105);
            this.txt_SinhVien.Name = "txt_SinhVien";
            this.txt_SinhVien.Size = new System.Drawing.Size(178, 24);
            this.txt_SinhVien.TabIndex = 25;
            // 
            // txt_Phong
            // 
            this.txt_Phong.Location = new System.Drawing.Point(168, 50);
            this.txt_Phong.Name = "txt_Phong";
            this.txt_Phong.Size = new System.Drawing.Size(178, 24);
            this.txt_Phong.TabIndex = 15;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.txt_MST);
            this.groupBox3.Controls.Add(this.txt_TT);
            this.groupBox3.Controls.Add(this.label17);
            this.groupBox3.Controls.Add(this.label18);
            this.groupBox3.Controls.Add(this.txt_NgayKT);
            this.groupBox3.Controls.Add(this.txt_NgayBD);
            this.groupBox3.Controls.Add(this.label19);
            this.groupBox3.Controls.Add(this.label20);
            this.groupBox3.Location = new System.Drawing.Point(730, 23);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(347, 212);
            this.groupBox3.TabIndex = 22;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Thông tin Hợp Đồng";
            // 
            // txt_MST
            // 
            this.txt_MST.Enabled = false;
            this.txt_MST.Location = new System.Drawing.Point(166, 45);
            this.txt_MST.Name = "txt_MST";
            this.txt_MST.Size = new System.Drawing.Size(162, 24);
            this.txt_MST.TabIndex = 25;
            // 
            // txt_TT
            // 
            this.txt_TT.Enabled = false;
            this.txt_TT.Location = new System.Drawing.Point(196, 170);
            this.txt_TT.Name = "txt_TT";
            this.txt_TT.Size = new System.Drawing.Size(131, 24);
            this.txt_TT.TabIndex = 18;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(6, 173);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(166, 18);
            this.label17.TabIndex = 17;
            this.label17.Text = "Trạng Thái Thuê Phòng:";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(28, 129);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(109, 18);
            this.label18.TabIndex = 16;
            this.label18.Text = "Ngày Kết Thúc:";
            // 
            // txt_NgayKT
            // 
            this.txt_NgayKT.Enabled = false;
            this.txt_NgayKT.Location = new System.Drawing.Point(165, 126);
            this.txt_NgayKT.Name = "txt_NgayKT";
            this.txt_NgayKT.Size = new System.Drawing.Size(163, 24);
            this.txt_NgayKT.TabIndex = 15;
            // 
            // txt_NgayBD
            // 
            this.txt_NgayBD.Enabled = false;
            this.txt_NgayBD.Location = new System.Drawing.Point(165, 85);
            this.txt_NgayBD.Name = "txt_NgayBD";
            this.txt_NgayBD.Size = new System.Drawing.Size(162, 24);
            this.txt_NgayBD.TabIndex = 4;
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(28, 48);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(93, 18);
            this.label19.TabIndex = 5;
            this.label19.Text = "Mã Số Thuê:";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(28, 88);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(103, 18);
            this.label20.TabIndex = 6;
            this.label20.Text = "Ngày Bắt Đầu:";
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.txt_MaSV);
            this.groupBox5.Controls.Add(this.txt_GioiTinh);
            this.groupBox5.Controls.Add(this.label5);
            this.groupBox5.Controls.Add(this.label13);
            this.groupBox5.Controls.Add(this.txt_NgaySinh);
            this.groupBox5.Controls.Add(this.txt_TenSV);
            this.groupBox5.Controls.Add(this.label3);
            this.groupBox5.Controls.Add(this.label4);
            this.groupBox5.Location = new System.Drawing.Point(361, 23);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(349, 361);
            this.groupBox5.TabIndex = 21;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Thông Tin Sinh Viên";
            // 
            // txt_MaSV
            // 
            this.txt_MaSV.Enabled = false;
            this.txt_MaSV.Location = new System.Drawing.Point(164, 50);
            this.txt_MaSV.Name = "txt_MaSV";
            this.txt_MaSV.Size = new System.Drawing.Size(165, 24);
            this.txt_MaSV.TabIndex = 27;
            // 
            // txt_GioiTinh
            // 
            this.txt_GioiTinh.Enabled = false;
            this.txt_GioiTinh.Location = new System.Drawing.Point(163, 175);
            this.txt_GioiTinh.Name = "txt_GioiTinh";
            this.txt_GioiTinh.Size = new System.Drawing.Size(165, 24);
            this.txt_GioiTinh.TabIndex = 18;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(23, 181);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(75, 18);
            this.label5.TabIndex = 17;
            this.label5.Text = "Giới Tính :";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(23, 137);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(79, 18);
            this.label13.TabIndex = 16;
            this.label13.Text = "Ngày Sinh:";
            // 
            // txt_NgaySinh
            // 
            this.txt_NgaySinh.Enabled = false;
            this.txt_NgaySinh.Location = new System.Drawing.Point(163, 134);
            this.txt_NgaySinh.Name = "txt_NgaySinh";
            this.txt_NgaySinh.Size = new System.Drawing.Size(166, 24);
            this.txt_NgaySinh.TabIndex = 15;
            // 
            // txt_TenSV
            // 
            this.txt_TenSV.Enabled = false;
            this.txt_TenSV.Location = new System.Drawing.Point(163, 93);
            this.txt_TenSV.Name = "txt_TenSV";
            this.txt_TenSV.Size = new System.Drawing.Size(165, 24);
            this.txt_TenSV.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(23, 56);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(98, 18);
            this.label3.TabIndex = 5;
            this.label3.Text = "Mã Sinh Viên:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(23, 96);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(102, 18);
            this.label4.TabIndex = 6;
            this.label4.Text = "Tên Sinh Viên:";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.txt_MaP);
            this.groupBox4.Controls.Add(this.txt_GiaPhong);
            this.groupBox4.Controls.Add(this.txt_SoLuongNow);
            this.groupBox4.Controls.Add(this.txt_SoLuongMax);
            this.groupBox4.Controls.Add(this.txt_LoaiPhong);
            this.groupBox4.Controls.Add(this.label12);
            this.groupBox4.Controls.Add(this.label11);
            this.groupBox4.Controls.Add(this.label10);
            this.groupBox4.Controls.Add(this.label9);
            this.groupBox4.Controls.Add(this.txt_TenPhong);
            this.groupBox4.Controls.Add(this.lbl_TenKhuNha);
            this.groupBox4.Controls.Add(this.lbl_MaKhuNha);
            this.groupBox4.Location = new System.Drawing.Point(16, 23);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(326, 361);
            this.groupBox4.TabIndex = 20;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Thông Tin Phòng";
            // 
            // txt_MaP
            // 
            this.txt_MaP.Enabled = false;
            this.txt_MaP.Location = new System.Drawing.Point(140, 50);
            this.txt_MaP.Name = "txt_MaP";
            this.txt_MaP.Size = new System.Drawing.Size(151, 24);
            this.txt_MaP.TabIndex = 17;
            // 
            // txt_GiaPhong
            // 
            this.txt_GiaPhong.Enabled = false;
            this.txt_GiaPhong.Location = new System.Drawing.Point(139, 259);
            this.txt_GiaPhong.Name = "txt_GiaPhong";
            this.txt_GiaPhong.Size = new System.Drawing.Size(151, 24);
            this.txt_GiaPhong.TabIndex = 12;
            // 
            // txt_SoLuongNow
            // 
            this.txt_SoLuongNow.Enabled = false;
            this.txt_SoLuongNow.Location = new System.Drawing.Point(174, 211);
            this.txt_SoLuongNow.Name = "txt_SoLuongNow";
            this.txt_SoLuongNow.Size = new System.Drawing.Size(116, 24);
            this.txt_SoLuongNow.TabIndex = 11;
            // 
            // txt_SoLuongMax
            // 
            this.txt_SoLuongMax.Enabled = false;
            this.txt_SoLuongMax.Location = new System.Drawing.Point(175, 175);
            this.txt_SoLuongMax.Name = "txt_SoLuongMax";
            this.txt_SoLuongMax.Size = new System.Drawing.Size(116, 24);
            this.txt_SoLuongMax.TabIndex = 10;
            // 
            // txt_LoaiPhong
            // 
            this.txt_LoaiPhong.Enabled = false;
            this.txt_LoaiPhong.Location = new System.Drawing.Point(140, 134);
            this.txt_LoaiPhong.Name = "txt_LoaiPhong";
            this.txt_LoaiPhong.Size = new System.Drawing.Size(151, 24);
            this.txt_LoaiPhong.TabIndex = 9;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(28, 262);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(82, 18);
            this.label12.TabIndex = 8;
            this.label12.Text = "Giá Phòng:";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(28, 217);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(120, 18);
            this.label11.TabIndex = 7;
            this.label11.Text = "Số người đang ở:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(26, 175);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(111, 18);
            this.label10.TabIndex = 6;
            this.label10.Text = "Số người tối đa:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(28, 137);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(87, 18);
            this.label9.TabIndex = 5;
            this.label9.Text = "Loại Phòng:";
            // 
            // txt_TenPhong
            // 
            this.txt_TenPhong.Enabled = false;
            this.txt_TenPhong.Location = new System.Drawing.Point(139, 88);
            this.txt_TenPhong.Name = "txt_TenPhong";
            this.txt_TenPhong.Size = new System.Drawing.Size(151, 24);
            this.txt_TenPhong.TabIndex = 2;
            // 
            // lbl_TenKhuNha
            // 
            this.lbl_TenKhuNha.AutoSize = true;
            this.lbl_TenKhuNha.Location = new System.Drawing.Point(26, 90);
            this.lbl_TenKhuNha.Name = "lbl_TenKhuNha";
            this.lbl_TenKhuNha.Size = new System.Drawing.Size(84, 18);
            this.lbl_TenKhuNha.TabIndex = 2;
            this.lbl_TenKhuNha.Text = "Tên Phòng:";
            // 
            // lbl_MaKhuNha
            // 
            this.lbl_MaKhuNha.AutoSize = true;
            this.lbl_MaKhuNha.Location = new System.Drawing.Point(26, 50);
            this.lbl_MaKhuNha.Name = "lbl_MaKhuNha";
            this.lbl_MaKhuNha.Size = new System.Drawing.Size(80, 18);
            this.lbl_MaKhuNha.TabIndex = 1;
            this.lbl_MaKhuNha.Text = "Mã Phòng:";
            // 
            // TimKiem_GUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightBlue;
            this.ClientSize = new System.Drawing.Size(1492, 781);
            this.Controls.Add(this.dgv_TimKiem);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "TimKiem_GUI";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Tìm kiếm sinh viên";
            this.Load += new System.EventHandler(this.KhuNha_GUI_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_TimKiem)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.DataGridView dgv_TimKiem;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.TextBox txt_SinhVien;
        private System.Windows.Forms.TextBox txt_GioiTinh;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox txt_NgaySinh;
        private System.Windows.Forms.TextBox txt_TenSV;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.TextBox txt_Phong;
        private System.Windows.Forms.TextBox txt_GiaPhong;
        private System.Windows.Forms.TextBox txt_SoLuongNow;
        private System.Windows.Forms.TextBox txt_SoLuongMax;
        private System.Windows.Forms.TextBox txt_LoaiPhong;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txt_TenPhong;
        private System.Windows.Forms.Label lbl_TenKhuNha;
        private System.Windows.Forms.Label lbl_MaKhuNha;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox txt_MST;
        private System.Windows.Forms.TextBox txt_TT;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.TextBox txt_NgayKT;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.TextBox txt_MaP;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.TextBox txt_MaSV;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.TextBox txt_NgayBD;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbb_TTTP;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btn_InExcel;
        private System.Windows.Forms.SaveFileDialog dlgSaveFile;
    }
}