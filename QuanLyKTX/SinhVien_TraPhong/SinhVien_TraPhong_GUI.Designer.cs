
namespace QuanLyKTX.SinhVien_TraPhong
{
    partial class SinhVien_TraPhong_GUI
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
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btn_Luu = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.cbo_TimKiem = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btn_Thoat = new System.Windows.Forms.Button();
            this.btn_TimKiem = new System.Windows.Forms.Button();
            this.btn_Reset = new System.Windows.Forms.Button();
            this.btn_Xoa = new System.Windows.Forms.Button();
            this.btn_Sua = new System.Windows.Forms.Button();
            this.btn_Them = new System.Windows.Forms.Button();
            this.dgv_TraPhong = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.txt_TienViPham = new System.Windows.Forms.TextBox();
            this.lbl_TienViPham = new System.Windows.Forms.Label();
            this.dtp_NgayTra = new System.Windows.Forms.DateTimePicker();
            this.label20 = new System.Windows.Forms.Label();
            this.cbo_MaSoThue = new System.Windows.Forms.ComboBox();
            this.lbl_MaSoThue = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_TraPhong)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btn_Luu);
            this.groupBox2.Controls.Add(this.groupBox3);
            this.groupBox2.Controls.Add(this.btn_Thoat);
            this.groupBox2.Controls.Add(this.btn_TimKiem);
            this.groupBox2.Controls.Add(this.btn_Reset);
            this.groupBox2.Controls.Add(this.btn_Xoa);
            this.groupBox2.Controls.Add(this.btn_Sua);
            this.groupBox2.Controls.Add(this.btn_Them);
            this.groupBox2.Location = new System.Drawing.Point(612, 11);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(476, 267);
            this.groupBox2.TabIndex = 10;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Thao tác";
            // 
            // btn_Luu
            // 
            this.btn_Luu.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Luu.Image = global::QuanLyKTX.Properties.Resources.Sua32_11;
            this.btn_Luu.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_Luu.Location = new System.Drawing.Point(184, 41);
            this.btn_Luu.Name = "btn_Luu";
            this.btn_Luu.Size = new System.Drawing.Size(100, 45);
            this.btn_Luu.TabIndex = 9;
            this.btn_Luu.Text = "Lưu";
            this.btn_Luu.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_Luu.UseVisualStyleBackColor = true;
            this.btn_Luu.Click += new System.EventHandler(this.btn_Luu_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.cbo_TimKiem);
            this.groupBox3.Controls.Add(this.label2);
            this.groupBox3.Location = new System.Drawing.Point(18, 108);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(283, 129);
            this.groupBox3.TabIndex = 8;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Tìm kiếm";
            // 
            // cbo_TimKiem
            // 
            this.cbo_TimKiem.FormattingEnabled = true;
            this.cbo_TimKiem.Location = new System.Drawing.Point(119, 52);
            this.cbo_TimKiem.Name = "cbo_TimKiem";
            this.cbo_TimKiem.Size = new System.Drawing.Size(147, 24);
            this.cbo_TimKiem.TabIndex = 30;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(24, 55);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(89, 17);
            this.label2.TabIndex = 4;
            this.label2.Text = "Mã Số Thuê:";
            // 
            // btn_Thoat
            // 
            this.btn_Thoat.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Thoat.Image = global::QuanLyKTX.Properties.Resources.Thoat321;
            this.btn_Thoat.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_Thoat.Location = new System.Drawing.Point(337, 183);
            this.btn_Thoat.Name = "btn_Thoat";
            this.btn_Thoat.Size = new System.Drawing.Size(122, 54);
            this.btn_Thoat.TabIndex = 7;
            this.btn_Thoat.Text = "Thoát";
            this.btn_Thoat.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_Thoat.UseVisualStyleBackColor = true;
            this.btn_Thoat.Click += new System.EventHandler(this.btn_Thoat_Click);
            // 
            // btn_TimKiem
            // 
            this.btn_TimKiem.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_TimKiem.Image = global::QuanLyKTX.Properties.Resources.TraCuu32;
            this.btn_TimKiem.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_TimKiem.Location = new System.Drawing.Point(337, 116);
            this.btn_TimKiem.Name = "btn_TimKiem";
            this.btn_TimKiem.Size = new System.Drawing.Size(122, 45);
            this.btn_TimKiem.TabIndex = 6;
            this.btn_TimKiem.Text = "Tìm kiếm";
            this.btn_TimKiem.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_TimKiem.UseVisualStyleBackColor = true;
            this.btn_TimKiem.Click += new System.EventHandler(this.btn_TimKiem_Click);
            // 
            // btn_Reset
            // 
            this.btn_Reset.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Reset.Image = global::QuanLyKTX.Properties.Resources.ChuyenPhong161;
            this.btn_Reset.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_Reset.Location = new System.Drawing.Point(359, 41);
            this.btn_Reset.Name = "btn_Reset";
            this.btn_Reset.Size = new System.Drawing.Size(91, 45);
            this.btn_Reset.TabIndex = 3;
            this.btn_Reset.Text = "Reset";
            this.btn_Reset.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_Reset.UseVisualStyleBackColor = true;
            this.btn_Reset.Click += new System.EventHandler(this.btn_Reset_Click);
            // 
            // btn_Xoa
            // 
            this.btn_Xoa.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Xoa.Image = global::QuanLyKTX.Properties.Resources.x;
            this.btn_Xoa.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_Xoa.Location = new System.Drawing.Point(257, 41);
            this.btn_Xoa.Name = "btn_Xoa";
            this.btn_Xoa.Size = new System.Drawing.Size(96, 45);
            this.btn_Xoa.TabIndex = 2;
            this.btn_Xoa.Text = "Xóa";
            this.btn_Xoa.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_Xoa.UseVisualStyleBackColor = true;
            this.btn_Xoa.Click += new System.EventHandler(this.btn_Xoa_Click);
            // 
            // btn_Sua
            // 
            this.btn_Sua.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Sua.Image = global::QuanLyKTX.Properties.Resources.Sua32_11;
            this.btn_Sua.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_Sua.Location = new System.Drawing.Point(137, 41);
            this.btn_Sua.Name = "btn_Sua";
            this.btn_Sua.Size = new System.Drawing.Size(100, 45);
            this.btn_Sua.TabIndex = 1;
            this.btn_Sua.Text = "Sửa";
            this.btn_Sua.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_Sua.UseVisualStyleBackColor = true;
            this.btn_Sua.Click += new System.EventHandler(this.btn_Sua_Click);
            // 
            // btn_Them
            // 
            this.btn_Them.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Them.Image = global::QuanLyKTX.Properties.Resources.Them32_1;
            this.btn_Them.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_Them.Location = new System.Drawing.Point(18, 41);
            this.btn_Them.Name = "btn_Them";
            this.btn_Them.Size = new System.Drawing.Size(101, 45);
            this.btn_Them.TabIndex = 0;
            this.btn_Them.Text = "Thêm";
            this.btn_Them.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_Them.UseVisualStyleBackColor = true;
            this.btn_Them.Click += new System.EventHandler(this.btn_Them_Click);
            // 
            // dgv_TraPhong
            // 
            this.dgv_TraPhong.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_TraPhong.Location = new System.Drawing.Point(15, 290);
            this.dgv_TraPhong.Name = "dgv_TraPhong";
            this.dgv_TraPhong.ReadOnly = true;
            this.dgv_TraPhong.RowHeadersWidth = 51;
            this.dgv_TraPhong.RowTemplate.Height = 24;
            this.dgv_TraPhong.Size = new System.Drawing.Size(1073, 363);
            this.dgv_TraPhong.TabIndex = 11;
            this.dgv_TraPhong.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_KhuNha_CellClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(211, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(179, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Thông tin Trả Phòng";
            // 
            // txt_TienViPham
            // 
            this.txt_TienViPham.Location = new System.Drawing.Point(244, 188);
            this.txt_TienViPham.Name = "txt_TienViPham";
            this.txt_TienViPham.Size = new System.Drawing.Size(195, 24);
            this.txt_TienViPham.TabIndex = 4;
            // 
            // lbl_TienViPham
            // 
            this.lbl_TienViPham.AutoSize = true;
            this.lbl_TienViPham.Location = new System.Drawing.Point(119, 191);
            this.lbl_TienViPham.Name = "lbl_TienViPham";
            this.lbl_TienViPham.Size = new System.Drawing.Size(99, 18);
            this.lbl_TienViPham.TabIndex = 2;
            this.lbl_TienViPham.Text = "Tiền Vi Phạm:";
            // 
            // dtp_NgayTra
            // 
            this.dtp_NgayTra.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtp_NgayTra.Location = new System.Drawing.Point(244, 131);
            this.dtp_NgayTra.MaxDate = new System.DateTime(2100, 12, 12, 0, 0, 0, 0);
            this.dtp_NgayTra.MinDate = new System.DateTime(2020, 1, 1, 0, 0, 0, 0);
            this.dtp_NgayTra.Name = "dtp_NgayTra";
            this.dtp_NgayTra.Size = new System.Drawing.Size(196, 24);
            this.dtp_NgayTra.TabIndex = 28;
            this.dtp_NgayTra.Value = new System.DateTime(2021, 12, 31, 0, 0, 0, 0);
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(119, 136);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(119, 18);
            this.label20.TabIndex = 27;
            this.label20.Text = "Ngày Trả Phòng:";
            // 
            // cbo_MaSoThue
            // 
            this.cbo_MaSoThue.FormattingEnabled = true;
            this.cbo_MaSoThue.Location = new System.Drawing.Point(244, 72);
            this.cbo_MaSoThue.Name = "cbo_MaSoThue";
            this.cbo_MaSoThue.Size = new System.Drawing.Size(196, 26);
            this.cbo_MaSoThue.TabIndex = 29;
            // 
            // lbl_MaSoThue
            // 
            this.lbl_MaSoThue.AutoSize = true;
            this.lbl_MaSoThue.Location = new System.Drawing.Point(119, 80);
            this.lbl_MaSoThue.Name = "lbl_MaSoThue";
            this.lbl_MaSoThue.Size = new System.Drawing.Size(93, 18);
            this.lbl_MaSoThue.TabIndex = 1;
            this.lbl_MaSoThue.Text = "Mã Số Thuê:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cbo_MaSoThue);
            this.groupBox1.Controls.Add(this.dtp_NgayTra);
            this.groupBox1.Controls.Add(this.label20);
            this.groupBox1.Controls.Add(this.txt_TienViPham);
            this.groupBox1.Controls.Add(this.lbl_TienViPham);
            this.groupBox1.Controls.Add(this.lbl_MaSoThue);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(12, 11);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(581, 268);
            this.groupBox1.TabIndex = 9;
            this.groupBox1.TabStop = false;
            // 
            // SinhVien_TraPhong_GUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightBlue;
            this.ClientSize = new System.Drawing.Size(1100, 664);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.dgv_TraPhong);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "SinhVien_TraPhong_GUI";
            this.Text = "TRẢ PHÒNG";
            this.Load += new System.EventHandler(this.TraPhong_GUI_Load);
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_TraPhong)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btn_Luu;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.ComboBox cbo_TimKiem;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btn_Thoat;
        private System.Windows.Forms.Button btn_TimKiem;
        private System.Windows.Forms.Button btn_Reset;
        private System.Windows.Forms.Button btn_Xoa;
        private System.Windows.Forms.Button btn_Sua;
        private System.Windows.Forms.Button btn_Them;
        private System.Windows.Forms.DataGridView dgv_TraPhong;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txt_TienViPham;
        private System.Windows.Forms.Label lbl_TienViPham;
        private System.Windows.Forms.DateTimePicker dtp_NgayTra;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.ComboBox cbo_MaSoThue;
        private System.Windows.Forms.Label lbl_MaSoThue;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}