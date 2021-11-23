using QuanLyKTX.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace QuanLyKTX.User
{
    public partial class FormLogin : Form
    {

        TrangChu trangChu = new TrangChu();
        public FormLogin(TrangChu trangChu)
        {
            InitializeComponent();
            this.trangChu = trangChu;
        }


        public static string FullName = "";
        PhanQuyen_BLL phanQuyen_BLL = new PhanQuyen_BLL();
        DataUtils utils = new DataUtils();
        public static bool QLKhoa;
        public static bool QLLop;
        public static bool QLQue;
        public static bool QLKhuNha;
        public static bool QLPhong;
        public static bool QLSinhVien;
        public static bool QLThietBi;
        public static bool ThongKe;
        public static bool PhanQuyen;
        public static bool QLDanhMuc;
        public static bool QLPhongThietBi;
        public static bool HoaDon;
        public static bool QLNhanVien;
        public static string ROLES = "";
        public static string TenTaiKhoan = "";


        private bool Phan_Quyen(int col)
        {
            bool check = false;

            for (int i = 0; i < phanQuyen_BLL.BLL_PhanQuyen_DangNhap_Select(txtUser.Text, utils.EncodePassWord("123", txtPass.Text)).Rows.Count; i++)
            {
                if (phanQuyen_BLL.BLL_PhanQuyen_DangNhap_Select(txtUser.Text, utils.EncodePassWord("123", txtPass.Text)).Rows[i][col].ToString() == "True")
                    return check = true;
            }

            return check;
        }


        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            if (txtUser.Text.Length == 0 || txtPass.Text.Length == 0)//nếu trống thì cho lable hiển thị là chưa nhập
            {    
                
                lblStatus.BackColor = Color.Pink;
                lblStatus.Text = "Bạn chưa nhập tài khoản hoặc mật khẩu.";
            }
            else
            {
                lblStatus.Text = "";
                int count = phanQuyen_BLL.BLL_PhanQuyen_DangNhap_Select(txtUser.Text, utils.EncodePassWord("123", txtPass.Text)).Rows.Count;
                phanQuyen_BLL.BLL_PhanQuyen_DangNhap_Select(txtUser.Text, utils.EncodePassWord("123", txtPass.Text));

                if (count == 0)
                {
                    lblStatus.BackColor = Color.Pink;
                    lblStatus.Text = "Tài khoản hoặc mật khẩu không đúng";
                }
                else
                {
                    //thì sẽ set tentaikhoan đc lấy từ cơ sở dữ liệu
                    TenTaiKhoan = phanQuyen_BLL.BLL_PhanQuyen_DangNhap_Select(txtUser.Text, utils.EncodePassWord("123", txtPass.Text)).Rows[0][1].ToString();
                    FullName = phanQuyen_BLL.BLL_PhanQuyen_DangNhap_Select(txtUser.Text, utils.EncodePassWord("123", txtPass.Text)).Rows[0][2].ToString();
                    ROLES = phanQuyen_BLL.BLL_PhanQuyen_DangNhap_Select(txtUser.Text, utils.EncodePassWord("123", txtPass.Text)).Rows[0][18].ToString();
                 /*   if (ROLES.Equals("STAFF") || ROLES.Equals("MANAGER"))
                    {
                      
                        QLNhanVien = true; 
                        QLDanhMuc = true;
                        HoaDon = true;
                    }
                    else
                    {
                        QLNhanVien = false;
                        HoaDon = false;
                        QLDanhMuc = false;
                    }*/
                    //rồi việc còn lại là gọi hàm phân quyền thôi, như đã nói ở trên, nhớ số cột cẩn thận ko sai nhé :v
                    QLKhoa = Phan_Quyen(8);
                    QLLop = Phan_Quyen(9);
                    QLQue = Phan_Quyen(10);
                    QLKhuNha = Phan_Quyen(11);
                    QLPhong = Phan_Quyen(12);
                    QLSinhVien = Phan_Quyen(13);
                    QLThietBi = Phan_Quyen(14);
                    QLPhongThietBi = Phan_Quyen(15);
                    ThongKe = Phan_Quyen(16);
                    PhanQuyen = Phan_Quyen(17);
                    
                    this.Close();
                }
            }
        }

        private void FormLogin_Load(object sender, EventArgs e)
        {
            lblTitle.BackColor = Color.Transparent;
            lblPassword.BackColor = Color.Transparent;
            lblUserName.BackColor= Color.Transparent;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
     
        }
    }
}
