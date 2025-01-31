﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyKTX
{
    public partial class TrangChu : Form
    {

        
        public TrangChu()
        {
            InitializeComponent();
        }

        DataHelper helper = new DataHelper();


        private void quảnLýLớpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TrangChu_BLL trangchu = new TrangChu_BLL();
            trangchu.qlLop();
        }


        private void quảnLýKhuNhàToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TrangChu_BLL trangchu = new TrangChu_BLL();
            trangchu.qlKhuNha();
        }

        private void quảnLýThiếtBịToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TrangChu_BLL trangchu = new TrangChu_BLL();
            trangchu.qlThietBi();
        }

        private void quảnLýPhòngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TrangChu_BLL trangchu = new TrangChu_BLL();
            trangchu.qlPhong();
        }

        private void quảnLýPhòngThiếtBịToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TrangChu_BLL trangchu = new TrangChu_BLL();
            trangchu.qlTbiPhong();
        }

        private void quảnLýKhoaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TrangChu_BLL trangchu = new TrangChu_BLL();
            trangchu.qlKhoa();
        }

        private void quảnLýQuêToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TrangChu_BLL trangchu = new TrangChu_BLL();
            trangchu.qlQue();
        }   

        private void quảnLýSinhViênToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TrangChu_BLL trangchu = new TrangChu_BLL();
            trangchu.qlSinhVien();
        }

    
        private void ShowToolStripMenuItem(bool x, ToolStripMenuItem y)
        {
            if (x)
            {
                y.Enabled = true;
                y.Visible = true;
            }
            else
            {
                y.Enabled = false;
                y.Visible = false;
            }
        }



        private void TrangChu_Load(object sender, EventArgs e)
        {//đây, ở đây các biến bool static ở form đăng nhập đc gọi lại, nếu true sẽ enable control menustrip, false thì ko enable
            User.FormLogin formLogin = new User.FormLogin(this);
            formLogin.ShowDialog();

            ShowToolStripMenuItem(User.FormLogin.QLDanhMuc, quảnLýDanhMụcToolStripMenuItem);
            ShowToolStripMenuItem(User.FormLogin.HoaDon, hóaĐơnToolStripMenuItem);
            ShowToolStripMenuItem(User.FormLogin.QLKhoa, quảnLýKhoaToolStripMenuItem);
            ShowToolStripMenuItem(User.FormLogin.QLLop, quảnLýLớpToolStripMenuItem);
            ShowToolStripMenuItem(User.FormLogin.QLKhuNha, quảnLýKhuNhàToolStripMenuItem);
            ShowToolStripMenuItem(User.FormLogin.QLPhong, quảnLýPhòngToolStripMenuItem);
            ShowToolStripMenuItem(User.FormLogin.QLSinhVien, quảnLýSinhViênToolStripMenuItem);
            ShowToolStripMenuItem(User.FormLogin.QLThietBi, quảnLýThiếtBịToolStripMenuItem);
            ShowToolStripMenuItem(User.FormLogin.PhanQuyen, phânQuyềntoolStripMenuItem);
            ShowToolStripMenuItem(User.FormLogin.QLNhanVien, QLnhânViêntoolStripMenuItem);
            ShowToolStripMenuItem(User.FormLogin.QLDanhMuc, quảnLýDanhMụcToolStripMenuItem);
            ShowToolStripMenuItem(User.FormLogin.QLPhongThietBi, quảnLýPhòngThiếtBịToolStripMenuItem);
            if (User.FormLogin.FullName != "")
            {
                toolStripLabel1.Text = User.FormLogin.FullName + " đang sử dụng phần mềm";
            }
            CheckTTTP();
        }
        
        public DataTable CheckTTTP()
        {
            string sql = "exec sp_TrangChu_CheckTTTP";
            return helper.getTable(sql);
        }

       

       

        private void tổngQuanVềKTXToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            TrangChu_BLL trangchu = new TrangChu_BLL();
            trangchu.TongQuan();
        }

        private void thoátToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn chắc chắn muốn thoát ứng dụng chứ?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void hóaĐơnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TrangChu_BLL trangchu = new TrangChu_BLL();
            trangchu.qlHoaDon();
        }

        private void trảphòngtoolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            TrangChu_BLL trangchu = new TrangChu_BLL();
            trangchu.qlSVTraPhong();
        }

        private void thuêphòngtoolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            TrangChu_BLL trangchu = new TrangChu_BLL();
            trangchu.qlSVThuePhong();
        }

        private void tìmkiemSVtoolStripMenuItem_Click(object sender, EventArgs e)
        {
            TrangChu_BLL trangchu = new TrangChu_BLL();
            trangchu.TimKiem();
        }

        private void tìmkiếmhóađơntoolStripMenuItem_Click_1(object sender, EventArgs e)
        {

            TrangChu_BLL trangchu = new TrangChu_BLL();
            trangchu.timkiemHoaDon();
        }

        private void phânQuyềntoolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            TrangChu_BLL trangchu = new TrangChu_BLL();
            trangchu.PhanQuyen();
        }

        private void nhânViêntoolStripMenuItem_Click_1(object sender, EventArgs e)
        {

            TrangChu_BLL trangchu = new TrangChu_BLL();
            trangchu.NhanVien();
        }
    }
}
