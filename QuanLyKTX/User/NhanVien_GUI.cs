using QuanLyKTX.Utils;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.IO;
using System.Drawing.Imaging;
using Excel = Microsoft.Office.Interop.Excel;

namespace QuanLyKTX.User
{
    public partial class NhanVien_GUI : Form
    {
        public NhanVien_GUI()
        {
            InitializeComponent();
        }

        PhanQuyen_BLL phanQuyen_BLL = new PhanQuyen_BLL();
        DataUtils utils = new DataUtils();
        private static string oldTenTaiKhoan = "";
        private static string oldEmail = "";

        User_BLL nhanVien_BLL = new User_BLL();

        private int UserId;
        private static int ktErrorTenTaiKhoan = 0;
        private static int ktErrorTen = 0;
        private static int ktErrorDC = 0;
        private static int ktErrorSDT = 0;
        private static int ktErrorMK = 0;
        private static int ktErrorEmail = 0;
        private static int ktErrorXNMK = 0;
        private static int ktTxtChange = 0;
        private static int ktErrorChucVu = 0;
        private string imageName = "";
        Dictionary<string, string> hash = new Dictionary<string, string>();
        

        private void NhanVien_GUI_Load(object sender, EventArgs e)
        {
            while (!User.FormLogin.Checked)
            {
                User.FormLogin formLogin = new User.FormLogin();
                formLogin.ShowDialog();
                this.Close();
            }
            try
            {
                btnSua.Enabled = false;
                btnXoa.Enabled = false;
                OpenDataGridView();
                addItemComboBox();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
           
        }
        private void OpenDataGridView()
        {
            string ROLES = User.FormLogin.ROLES;
            if (ROLES.Equals("STAFF"))
            {
                dtGridNV.DataSource = nhanVien_BLL.BLL_USER_GetStaff(User.FormLogin.TenTaiKhoan, ROLES);
                btnThem.Visible = false; btnThem.Enabled = false;
                btnXoa.Visible = false; btnXoa.Enabled = false;
            }else if (ROLES.Equals("MANAGER"))
            {
                dtGridNV.DataSource = nhanVien_BLL.BLL_USER_Select();
            }
            dtGridNV.Columns[0].HeaderText = "ID"; dtGridNV.Columns[0].Width = 30;
            dtGridNV.Columns[1].HeaderText = "Tên Tài Khoản "; dtGridNV.Columns[1].Width = 150;
            dtGridNV.Columns[2].HeaderText = "Họ Và Tên "; dtGridNV.Columns[2].Width = 150;
            dtGridNV.Columns[3].Visible = false;
            dtGridNV.Columns[4].HeaderText = "Ngày Sinh "; dtGridNV.Columns[4].Width = 100;
            dtGridNV.Columns[5].HeaderText = "Địa Chỉ "; dtGridNV.Columns[5].Width = 150;
            dtGridNV.Columns[6].HeaderText = "Số Điện Thoại "; dtGridNV.Columns[6].Width = 100;
            dtGridNV.Columns[7].HeaderText = "Email "; dtGridNV.Columns[7].Width = 150;
            dtGridNV.Columns[8].Visible = false;
            dtGridNV.Columns[9].Visible = false;
            dtGridNV.Columns[10].Visible = false;
            dtGridNV.Columns[11].Visible = false;
            dtGridNV.Columns[12].Visible = false;
            dtGridNV.Columns[13].Visible = false;
            dtGridNV.Columns[14].Visible = false;
            dtGridNV.Columns[15].Visible = false;
            dtGridNV.Columns[16].Visible = false;
            dtGridNV.Columns[17].Visible = false;
            dtGridNV.Columns[18].HeaderText = "Chức Vụ "; dtGridNV.Columns[17].Width = 80;
            dtGridNV.Columns[19].Visible = false;
            dtGridNV.Columns[20].Visible = false;
            dtGridNV.AllowUserToAddRows = false;
            picAnh.Image = Image.FromFile(Application.StartupPath.ToString() + "\\hình\\Thumbnail\\noimage.jpg");
            picAnh.SizeMode = PictureBoxSizeMode.StretchImage;
            
        }

        private void addItemComboBox()
        {
            try
            {
                if (User.FormLogin.ROLES.Equals("MANAGER"))
                {
                    cbChucVu.Items.Add("MANAGER");
                    cbChucVu.Items.Add("STAFF");
                    for (int i = 2; i <= cbChucVu.Items.Count; i++)
                    {
                        cbChucVu.Items.RemoveAt(i);
                    }
                }
                else if (User.FormLogin.ROLES.Equals("STAFF"))
                {
                    cbChucVu.Items.Add("STAFF");
                    for (int i = 1; i <= cbChucVu.Items.Count; i++)
                    {
                        cbChucVu.Items.RemoveAt(i);
                    }

                }
            }
            catch
            {

            }
              
            
        }

        /* su kien changed */
        private void txtTenTaiKhoan_TextChanged(object sender, EventArgs e)
        {
            if (ktTxtChange == 0)
            {
                if (txtTenTaiKhoan.Text.Length == 0)
                {
                    errorPro.SetError(txtTenTaiKhoan, "Bạn chưa nhập tên đăng nhập");
                    txtTenTaiKhoan.BackColor = Color.Pink;
                }
                else
                {
                    errorPro.Clear();
                    txtTenTaiKhoan.BackColor = Color.White;
                    ktErrorTenTaiKhoan = 1;
                }
            }
        }
        private void txtTenNhanVien_TextChanged(object sender, EventArgs e)
        {
            if (ktTxtChange == 0)
            {
                if (txtTenNhanVien.Text.Length == 0)
                {
                    errorPro.SetError(txtTenNhanVien, "Bạn chưa nhập tên nhân viên");
                    txtTenNhanVien.BackColor = Color.Pink;
                }
                else
                    if (Regex.IsMatch(txtTenNhanVien.Text, "[0-9-]+"))
                {
                    
                    errorPro.SetError(txtTenNhanVien, "Tên nhân vien không chứa số và ký tự đặc biệt");
                    txtTenNhanVien.BackColor = Color.Pink;
                }
                else
                {
                    errorPro.Clear();
                    txtTenNhanVien.BackColor = Color.White;
                    ktErrorTen = 1;
                }
            }
        }
        private void txtMatKhau_TextChanged(object sender, EventArgs e)
        {
            if (ktTxtChange == 0)
            {
                if (txtMatKhau.Text.Length == 0 || txtMatKhau.Text.Length < 6)
                {
                    errorPro.SetError(txtMatKhau, "Bạn chưa nhập mật khẩu - Mật khẩu phải tối thiểu 6 ký tự");
                    txtMatKhau.BackColor = Color.Pink;
                }
                else
                {
                    errorPro.Clear();
                    txtMatKhau.BackColor = Color.White;
                    ktErrorMK = 1;
                }
            }
        }
        private void txtXacNhanMatKhau_TextChanged(object sender, EventArgs e)
        {
            if (ktTxtChange == 0)
            {
                if (txtXacNhanMatKhau.Text.Length == 0)
                {
                    errorPro.SetError(txtXacNhanMatKhau, "Bạn chưa nhập xác nhận mật khẩu");
                    txtXacNhanMatKhau.BackColor = Color.Pink;
                }
                else
                    if (txtXacNhanMatKhau.Text != txtMatKhau.Text)
                {
                    txtMatKhau_TextChanged(sender, e);
                    errorPro.SetError(txtXacNhanMatKhau, "Xác nhận mật khẩu không khớp mật khẩu");
                    txtXacNhanMatKhau.BackColor = Color.Pink;
                }
                else
                {
                    errorPro.Clear();
                    txtXacNhanMatKhau.BackColor = Color.White;
                    ktErrorXNMK = 1;
                }
            }
        }

        private void txtSDT_TextChanged(object sender, EventArgs e)
        {
            if (ktTxtChange == 0)
            {
                if (txtSDT.Text.Length == 0)
                {
                    errorPro.SetError(txtSDT, "Bạn chưa nhập số điện thoại");
                    txtSDT.BackColor = Color.Pink;
                }
                else
                {
                    if (Regex.IsMatch(txtSDT.Text, "[0-9-]+"))
                    {
                        errorPro.Clear();
                        txtSDT.BackColor = Color.White;
                        ktErrorSDT = 1;
                    }
                    else
                    {
                        errorPro.SetError(txtSDT, "Số điện thoại không chứa chữ và ký tự đặc biệt");
                        txtSDT.BackColor = Color.Pink;
                    }
                }
            }
        }

        private void txtEmail_TextChanged(object sender, EventArgs e)
       {
            string pattern = "^([0-9a-zA-Z]([-\\.\\w]*[0-9a-zA-Z])*@([0-9a-zA-Z][-\\w]*[0-9a-zA-Z]\\.)+[a-zA-Z]{2,9})$";
            if (Regex.IsMatch(txtEmail.Text, pattern))
            {
                errorPro.Clear();
                txtEmail.BackColor = Color.White;
                ktErrorEmail = 1;
            }
            else
            {
                errorPro.SetError(this.txtEmail, "Email không đúng định dạng ");
                txtEmail.BackColor = Color.Pink;

            }
        }

        private void txtDiaChi_TextChanged(object sender, EventArgs e)
        {
            if (ktTxtChange == 0)
            {
                if (txtDiaChi.Text.Length == 0)
                {
                    errorPro.SetError(txtDiaChi, "Bạn chưa nhập địa chỉ");
                    txtDiaChi.BackColor = Color.Pink;
                }
                else
                {
                    errorPro.Clear();
                    txtDiaChi.BackColor = Color.White;
                    ktErrorDC = 1;
                }
            }
        }

        private void cbChucVu_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ktTxtChange == 0)
            {
                if (cbChucVu.SelectedIndex <= -1)
                {
                    errorPro.SetError(cbChucVu, "Bạn chưa chọn chức vụ");
                    cbChucVu.BackColor = Color.Pink;
                }
                else
                {
                    errorPro.Clear();
                    cbChucVu.BackColor = Color.White;
                    ktErrorChucVu = 1;
                }
            }
        }
        private void CallTextChanged(object sender, EventArgs e)
        {
            txtTenTaiKhoan_TextChanged(sender, e);
            txtTenNhanVien_TextChanged(sender, e);
            txtMatKhau_TextChanged(sender, e);
            txtXacNhanMatKhau_TextChanged(sender, e);
            txtSDT_TextChanged(sender, e);
            txtEmail_TextChanged(sender, e);
            txtDiaChi_TextChanged(sender, e);
            cbChucVu_SelectedIndexChanged(sender, e);

        }

        private bool checkTenDangNhap(string TenDangNhap)
        {
            dtGridNV.DataSource = nhanVien_BLL.BLL_USER_Select();
            bool check = false;
            List<string> listTenDangNhap = new List<string>();
            for (int i = 0; i < dtGridNV.Rows.Count; i++)
            {
                string str = dtGridNV.Rows[i].Cells[1].Value.ToString();
                listTenDangNhap.Add(str);
            }
            foreach(string item in listTenDangNhap){
                if (item.Equals(TenDangNhap))
                {
                    check = true;
                    break;
                }
            }

            return check;
            
        }

        private bool checkEmail(string email)
        {
            dtGridNV.DataSource = nhanVien_BLL.BLL_USER_Select();
            bool check = false;
            List<string> listEmail = new List<string>();
            for (int i = 0; i < dtGridNV.Rows.Count; i++)
            {
                string str = dtGridNV.Rows[i].Cells[7].Value.ToString();
                listEmail.Add(str);
            }
            foreach (string item in listEmail)
            {
                if (item.Equals(email))
                {
                    check = true;
                    break;
                }
            }


            return check;
        }

        /* Sự kiện click */
        private void btnThem_Click(object sender, EventArgs e)
        {
            CallTextChanged(sender, e);

            if (ktErrorDC == 0 || ktErrorMK == 0 || ktErrorTen == 0 || ktErrorXNMK == 0 || ktErrorTenTaiKhoan == 0 || ktErrorSDT == 0 || ktErrorEmail == 0
                || ktErrorChucVu == 0)
            {
                MessageBox.Show
                    ("Các ô thông tin nhập vào còn trống, hoặc nhập vào không đúng đinh dạng, "
                     + "click vào dấu hiệu cảnh báo (dấu chấm than) bên cạnh để biết thêm chi tiết ",
                     "CẢNH BÁO ",
                     MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else if (checkTenDangNhap(txtTenTaiKhoan.Text))
            {
                errorPro.SetError(txtTenTaiKhoan, "Tên đăng nhập đã tồn tại ");
                txtTenTaiKhoan.BackColor = Color.Pink;
                return;
            }
            else if (checkEmail(txtEmail.Text))
            {
                errorPro.SetError(txtEmail, "Email đã tồn tại");
                txtEmail.BackColor = Color.Pink;
                return;
            }
            else
            {
                if (DateTime.Now.Year - dtNgaySinh.Value.Year < 18)
                {
                    MessageBox.Show("Chưa đủ 18 tuổi - Mời bạn nhập lại ngày sinh !!!", "THÔNG BÁO", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (txtMatKhau.Text == txtXacNhanMatKhau.Text )
                {
                    try
                    {

                        phanQuyen_BLL.BLL_PhanQuyen_Insert(txtTenTaiKhoan.Text, txtTenNhanVien.Text, utils.EncodePassWord("123", txtMatKhau.Text),
                            dtNgaySinh.Value, txtDiaChi.Text, txtSDT.Text, txtEmail.Text, cbChucVu.Text, 1, imageName);
                        MessageBox.Show("Thêm Nhân Viên THÀNH CÔNG!!!", "THÔNG BÁO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Thêm THẤT BẠI do: " + ex, " CẢNH BÁO ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    ktTxtChange = 1;
                    txtTenTaiKhoan.Clear();
                    txtTenNhanVien.Clear();
                    txtMatKhau.Clear();
                    txtDiaChi.Clear();
                    txtXacNhanMatKhau.Clear();
                    txtSDT.Clear();
                    txtEmail.Clear();
                    errorPro.Clear();
                    txtEmail.BackColor = Color.White;
                    cbChucVu.SelectedIndex = -1;
                    ktTxtChange = 0;
                }
                else MessageBox.Show("Mật khẩu KHÔNG khớp !!! Mời nhập lại mật khẩu.");
                ktErrorTen = ktErrorDC = ktErrorMK = ktErrorXNMK = ktErrorChucVu = ktErrorEmail = ktErrorTenTaiKhoan = ktErrorSDT = 0;
            }
            NhanVien_GUI_Load(sender, e);

        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            CallTextChanged(sender, e);
            string newTenTaiKhoan = txtTenTaiKhoan.Text;
            string newEmail = txtEmail.Text;
            if (ktErrorDC == 0 || ktErrorMK == 0 || ktErrorTen == 0 || ktErrorXNMK == 0 || ktErrorTenTaiKhoan == 0 || ktErrorSDT == 0 || ktErrorEmail == 0
                || ktErrorChucVu == 0)
            {
                MessageBox.Show
                    ("Các ô thông tin nhập vào còn trống, hoặc nhập vào không đúng đinh dạng, "
                     + "click vào dấu hiệu cảnh báo (dấu chấm than) bên cạnh để biết thêm chi tiết ",
                     "CẢNH BÁO ",
                     MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!newTenTaiKhoan.Equals(oldTenTaiKhoan))
            {
                if (checkTenDangNhap(newTenTaiKhoan))
                {
                    errorPro.SetError(txtTenTaiKhoan, "Tên đăng nhập đã tồn tại ");
                    txtTenTaiKhoan.BackColor = Color.Pink;
                    return;
                }
            }
            else if (!newEmail.Equals(oldEmail))
            {
                if (checkEmail(newEmail))
                {
                    errorPro.SetError(txtEmail, "Tên đăng nhập đã tồn tại ");
                    txtEmail.BackColor = Color.Pink;
                    return;
                }
            }
            else
            {
              
                DialogResult dialogResult = MessageBox.Show("BẠN CÓ THẬT SỰ MUỐN CẬP NHẬT?", " CẢNH BÁO", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (dialogResult == DialogResult.Yes)
                {
                    if (txtMatKhau.Text == txtXacNhanMatKhau.Text)
                     {
                        try
                        {
                            phanQuyen_BLL.BLL_PhanQuyen_Update(UserId, txtTenTaiKhoan.Text, txtTenNhanVien.Text, utils.EncodePassWord("123", txtMatKhau.Text),
                                dtNgaySinh.Value, txtDiaChi.Text, txtSDT.Text, txtEmail.Text, cbChucVu.Text, imageName);
                            MessageBox.Show("Cập nhật THÀNH CÔNG!!! ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Cập nhật THẤT BẠI do: " + ex, " CẢNH BÁO ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        ktTxtChange = 1;
                        txtTenTaiKhoan.Clear();
                        txtTenNhanVien.Clear();
                        txtDiaChi.Clear();
                        txtMatKhau.Clear();
                        txtXacNhanMatKhau.Clear();
                        txtSDT.Clear();
                        txtEmail.Clear();
                        cbChucVu.SelectedIndex = -1;
                        ktTxtChange = 0;
                    }
                    else
                    {
                        MessageBox.Show("Mật khẩu KHÔNG khớp !!! Mời nhập lại mật khẩu.");
                        ktErrorTen = ktErrorDC = ktErrorMK = ktErrorXNMK = ktErrorChucVu = ktErrorEmail = ktErrorTenTaiKhoan = ktErrorSDT = 0;
                    }
                }
                else return;
                ktErrorTen = ktErrorDC = ktErrorMK = ktErrorXNMK = ktErrorChucVu = ktErrorEmail = ktErrorTenTaiKhoan = ktErrorSDT = 0;
            }
            NhanVien_GUI_Load(sender, e);
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (UserId != 0)
            {
                try
                {

                    DialogResult dialogResult = MessageBox.Show("Ban có THẬT SỰ MUỐN XÓA?", " CẢNH BÁO", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    if (dialogResult == DialogResult.Yes)
                    {

                        phanQuyen_BLL.BLL_PhanQuyen_Delete(UserId, 0);
                        MessageBox.Show("Xóa THÀNH CÔNG!!! ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        ktTxtChange = 1;
                        txtTenTaiKhoan.Clear();
                        txtTenNhanVien.Clear();
                        txtMatKhau.Clear();
                        txtDiaChi.Clear();
                        txtXacNhanMatKhau.Clear();
                        txtSDT.Clear();
                        txtEmail.Clear();
                        ktTxtChange = 0;
                    }
                    else return;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Xóa THẤT BẠI do: " + ex, " CẢNH BÁO ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else MessageBox.Show("Bạn chưa chọn nhân viên");
            NhanVien_GUI_Load(sender, e);
        }

        private void dtGridNV1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            btnSua.Enabled = true;
            btnXoa.Enabled = true;
            btnThem.Enabled = false;
            UserId = int.Parse(dtGridNV.Rows[e.RowIndex].Cells[0].Value.ToString());
            oldTenTaiKhoan =  txtTenTaiKhoan.Text = dtGridNV.Rows[e.RowIndex].Cells[1].Value.ToString();
            txtTenNhanVien.Text = dtGridNV.Rows[e.RowIndex].Cells[2].Value.ToString();
            dtNgaySinh.Value = DateTime.Parse(dtGridNV.Rows[e.RowIndex].Cells[4].Value.ToString());
            txtDiaChi.Text = dtGridNV.Rows[e.RowIndex].Cells[5].Value.ToString();
            txtSDT.Text = dtGridNV.Rows[e.RowIndex].Cells[6].Value.ToString();
            oldEmail = txtEmail.Text = dtGridNV.Rows[e.RowIndex].Cells[7].Value.ToString();
            if(txtMatKhau.Text=="" || txtXacNhanMatKhau.Text == "" || txtDiaChi.Text==""|| txtEmail.Text=="" || txtSDT.Text =="")
            {
                errorPro.Clear();
                txtXacNhanMatKhau.BackColor = Color.White;
                txtMatKhau.BackColor = Color.White;
                txtDiaChi.BackColor = Color.White;
                txtEmail.BackColor = Color.White;
                txtSDT.BackColor = Color.White;
            }


            cbChucVu.Text = dtGridNV.Rows[e.RowIndex].Cells[18].Value.ToString();

            if (dtGridNV.Rows[e.RowIndex].Cells[20].Value.ToString() != "")
            {
                picAnh.Image = Image.FromFile(Application.StartupPath.ToString() + "\\hình\\Thumbnail\\" + dtGridNV.Rows[e.RowIndex].Cells[20].Value.ToString());
            }
            else
            {
                picAnh.Image = Image.FromFile(Application.StartupPath.ToString() + "\\hình\\Thumbnail\\noimage.jpg");           
            }
            picAnh.SizeMode = PictureBoxSizeMode.StretchImage;
        }

        private void btnAnh_Click(object sender, EventArgs e)
        {
            
            string appPath = Path.GetDirectoryName(Application.ExecutablePath) + @"\hình\Thumbnail\";
            string[] pathImage;
            OpenFileDialog dlgOpen = new OpenFileDialog();
            dlgOpen.InitialDirectory = "Downloads";
            dlgOpen.Filter = "jpg files (*.jpg)|*.jpg|All files (*.*)|*.*";
            dlgOpen.Title = "Chọn ảnh để hiển thị";
            if (Directory.Exists(appPath) == false)
            {
                Directory.CreateDirectory(appPath);
            }
            if (dlgOpen.ShowDialog() == DialogResult.OK)
            {

                try
                {
                    picAnh.Image = Image.FromFile(dlgOpen.FileName);
                    picAnh.SizeMode = PictureBoxSizeMode.StretchImage;
                    pathImage = dlgOpen.FileName.Split('\\');
                    imageName = pathImage[pathImage.Length - 1];
                    picAnh.Image.Save(appPath + imageName, ImageFormat.Jpeg);

                }
                catch (Exception exp)
                {
                    MessageBox.Show("Unable to open file because the file already exists in the directory !");
                }

            }
            else
            {
                dlgOpen.Dispose();
            }

        }

        private void btn_Thoat_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn chắc chắn chứ?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void btn_TimKiem_Click(object sender, EventArgs e)
        {
            DataTable dataSearch = new DataTable();
            if(txtTimKiem.Text.Trim() == "")
            {
                MessageBox.Show("Bạn chưa nhập thông tin !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
            else
            {
                dataSearch = nhanVien_BLL.BLL_User_Search(txtTimKiem.Text);
                if(dataSearch.Rows.Count > 0)
                {
                    dtGridNV.DataSource = dataSearch;
                }
                else
                {
                    MessageBox.Show("Bạn tìm :  "+txtTimKiem.Text +" không có trong dữ liệu !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    txtTimKiem.Text = "";
                }

            }
        }

        private void btnInDS_Click(object sender, EventArgs e)
        {
            if(dtGridNV.Rows.Count > 0)
            {
                //Khai báo và khởi tạo các đối tượng
                Excel.Application exApp = new Excel.Application();
                Excel.Workbook exBook = exApp.Workbooks.Add(Excel.XlWBATemplate.xlWBATWorksheet);
                Excel.Worksheet exSheet = (Excel.Worksheet)exBook.Worksheets[1];

                //Định dạng chung
                Excel.Range tenKTX = (Excel.Range)exSheet.Cells[1, 1];
                tenKTX.Font.Size = 12;
                tenKTX.Font.Bold = true;
                tenKTX.Font.Color = Color.Blue;
                tenKTX.Value = "KÍ TÚC XÁ SINH VIÊN ĐẠI HỌC GTVT ";
                Excel.Range dcKTX = (Excel.Range)exSheet.Cells[2, 1];
                dcKTX.Font.Size = 12;
                dcKTX.Font.Bold = true;
                dcKTX.Font.Color = Color.Blue;
                dcKTX.Value = "Địa chỉ: Số 99 - Nguyễn Chí Thanh - P.Láng Hạ - Q.Đống Đa - TP. Hà Nội.";
                Excel.Range dtKTX = (Excel.Range)exSheet.Cells[3, 1];
                dtKTX.Font.Size = 12;
                dtKTX.Font.Bold = true;
                dtKTX.Font.Color = Color.Blue;
                dtKTX.Value = "Điện thoại: 0336125345";

                Excel.Range header = (Excel.Range)exSheet.Cells[5, 2];
                exSheet.get_Range("B5:G5").Merge(true);
                header.Font.Size = 13;
                header.Font.Bold = true;
                header.Font.Color = Color.Red;
                header.Value = "DANH SÁCH NHÂN VIÊN ";

                //Định dạng tiêu đề bảng
                exSheet.get_Range("A7:G7").Font.Bold = true;
                exSheet.get_Range("A7:G7").HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                exSheet.get_Range("A7").Value = "STT";
                exSheet.get_Range("B7").Value = "Họ Và Tên";
                exSheet.get_Range("B7").ColumnWidth = 20;
                exSheet.get_Range("C7").Value = "Ngày Sinh";
                exSheet.get_Range("C7").ColumnWidth = 15;
                exSheet.get_Range("D7").Value = "Địa Chỉ ";
                exSheet.get_Range("D7").ColumnWidth = 30;
                exSheet.get_Range("E7").Value = "Số Điện Thoại";
                exSheet.get_Range("E7").ColumnWidth = 15;
                exSheet.get_Range("F7").Value = "Email";
                exSheet.get_Range("F7").ColumnWidth = 30;
                exSheet.get_Range("G7").Value = "Chức Vụ";
                
              
                // In dữ liệu
                for(int i = 0; i < dtGridNV.Rows.Count; i++)
                {
                    exSheet.get_Range("A" + (i + 8).ToString() + ":H" + (i + 8).ToString()).Font.Bold = false;
                    exSheet.get_Range("A" + (i + 8).ToString()).Value = (i + 1).ToString();
                    exSheet.get_Range("B" + (i + 8).ToString()).Value = dtGridNV.Rows[i].Cells["HoVaTen"].Value.ToString();
                    exSheet.get_Range("C" + (i + 8).ToString()).Value = dtGridNV.Rows[i].Cells["NgaySinh"].Value.ToString();
                    exSheet.get_Range("D" + (i + 8).ToString()).Value = dtGridNV.Rows[i].Cells["DiaChi"].Value.ToString();
                    exSheet.get_Range("E" + (i + 8).ToString()).Value = dtGridNV.Rows[i].Cells["SDT"].Value.ToString();
                    exSheet.get_Range("F" + (i + 8).ToString()).Value = dtGridNV.Rows[i].Cells["Email"].Value.ToString();
                    exSheet.get_Range("G" + (i + 8).ToString()).Value = dtGridNV.Rows[i].Cells["ROLES"].Value.ToString();
                }
                exSheet.Name = "DSNhanVien";
                exBook.Activate(); //Kích hoạt file Excel
                                   //Thiết lập các thuộc tính của SaveFileDialog
                dlgSaveFile.Filter = "Excel Document(*.xls)|*.xls |Word Document(*.doc) | *.doc | All files(*.*) | *.* ";
                dlgSaveFile.FilterIndex = 1;
                dlgSaveFile.AddExtension = true;
                dlgSaveFile.DefaultExt = ".xls";
                if (dlgSaveFile.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    exBook.SaveAs(dlgSaveFile.FileName.ToString());//Lưu file Excel
                    MessageBox.Show("In danh sách thành công .");
                }  
                exApp.Quit();//Thoát khỏi ứng dụng

            }
            else
            {
                MessageBox.Show("Không có danh sách hàng để in");
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            btnThem.Enabled = true;
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            txtTenTaiKhoan.Clear();
            txtTenNhanVien.Clear();
            txtMatKhau.Clear();
            txtDiaChi.Clear();
            txtXacNhanMatKhau.Clear();
            txtSDT.Clear();
            txtEmail.Clear();
            cbChucVu.SelectedIndex = -1;
            errorPro.Clear();
            txtXacNhanMatKhau.BackColor = Color.White;
            txtMatKhau.BackColor = Color.White;
            txtDiaChi.BackColor = Color.White;
            txtEmail.BackColor = Color.White;
            txtSDT.BackColor = Color.White;
            txtTenNhanVien.BackColor = Color.White;
            txtTenTaiKhoan.BackColor = Color.White;
            cbChucVu.BackColor = Color.White;
            picAnh.Image = Image.FromFile(Application.StartupPath.ToString() + "\\hình\\Thumbnail\\noimage.jpg");
            picAnh.SizeMode = PictureBoxSizeMode.StretchImage;
            
        }
    }
}
