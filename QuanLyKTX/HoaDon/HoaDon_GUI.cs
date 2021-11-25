using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;

namespace QuanLyKTX.HoaDon
{
    public partial class HoaDon_GUI : Form
    {
        public HoaDon_GUI()
        {
            InitializeComponent();
        }
        Phong.Phong_BLL phong_BLL = new Phong.Phong_BLL();
        Utils.DataUtils dataUtils = new Utils.DataUtils();
        HoaDon_BLL hoaDon_BLL = new HoaDon_BLL();
        string maHD;
        int trangthai = 0;
        string maPhong;
        static string pattern = "^[0-9]*.?[0-9]*$";
        
        Double tiendien = 0;
        Double tiennha = 0;
        Double tiennuoc = 0;
        Double tienvesinh = 0;
        Double tienphat = 0;
        private static int ktErrorTienDien = 0;
        private static int ktErrorTienNc = 0;
        private static int ktErrorTienVs = 0;
        private static int ktErrorTienPhat = 0;
        private void HoaDon_GUI_Load(object sender, EventArgs e)
        {
            while (!User.FormLogin.Checked)
            {
                User.FormLogin formLogin = new User.FormLogin();
                formLogin.ShowDialog();
                this.Close();
            }

            try
            {
                lbNgayDong.Visible = false; lbNgayDong.Enabled = false;
                lbTrangThai.Visible = false; lbTrangThai.Enabled = false;
                dtp_NgayDong.Enabled = false; dtp_NgayDong.Visible = false;
                rdb_ChuaDong.Visible = false; rdb_ChuaDong.Enabled = false;
                rdb_DaDong.Visible = false; rdb_DaDong.Enabled = false;
                btn_sua.Enabled = false;
                btn_Luu.Enabled = false;
                cbMaPhong.Text = "";
                cb_MaHD.Text = "";
                addItemComboBoxThang();
                addItemComboxBoxNam();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void addItemComboBoxThang()
        {
            for(int i = 1; i <= 12; i++)
            {
                cbThang.Items.Add(i);
            }

        }
        private void addItemComboxBoxNam()
        {
            cmbNam.Items.Add(DateTime.Today.Year);
            cmbNam.Items.Add(DateTime.Today.Year + 1);
        }

        private void cbMaPhong_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
             
                    DataTable dtPhong = phong_BLL.findOneByMaPhong(cbMaPhong.SelectedValue.ToString());
                    txtTenPhong.Text = dtPhong.Rows[0]["TenPhong"].ToString();
                    txtTenKhu.Text = dtPhong.Rows[0]["TenKhu"].ToString();
                    txtTienNha.Text = dtPhong.Rows[0]["GiaPhong"].ToString();
                    txtThanhTien.Text = txtTienNha.Text;
                    txtTienDien.Enabled = txtTienNc.Enabled = txtTienPhat.Enabled = txtTienVeSinh.Enabled = true;
                    txtMHD.Text = txtTienDien.Text = txtTienNc.Text = txtTienVeSinh.Text = txtTienPhat.Text = "";
                    btn_Them.Enabled = true;
                    btn_Luu.Enabled = false;
                
            }
            catch
            {

            }
        }

        private void btn_Them_Click(object sender, EventArgs e)
        {
           
            if (cbMaPhong.Text.Trim() == "")
            {
                MessageBox.Show(" Không thể lập mã hóa đơn !. Bởi vì bạn chưa chọn mã phòng !!!!", " CẢNH BÁO ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                maPhong = cbMaPhong.SelectedValue.ToString();
                maHD = "HD" + maPhong + cbThang.Text + cmbNam.Text;
                if (hoaDon_BLL.CheckTable(maHD))
                {
                    btn_Them.Enabled = true;
                    MessageBox.Show( "Hóa đơn tháng " + cbThang.Text + "/" + cmbNam.Text + " đã tồn tại !!! Vui lòng nhập lập mã hóa đơn khác ."," CẢNH BÁO ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtMHD.Text = ""; 
                    btn_Luu.Enabled = false;
                    
                }
                else
                {
                    txtMHD.Text = maHD;
                    btn_Luu.Enabled = true;
                    btn_Them.Enabled = false;
                    
                }
            }


        }

        private void btn_Thoat_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn chắc chắn muốn thoát chứ?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                this.Close();
            }
        }



        double TinhTienHoaDon()
        {
            double thanhtien;
            tiennha = double.Parse(txtTienNha.Text);
            tiendien = checkItem(txtTienDien);
            tiennuoc = checkItem(txtTienNc);
            tienvesinh = checkItem(txtTienVeSinh);
            tienphat = checkItem(txtTienPhat);
            thanhtien = tiennha + tiennuoc + tiendien + tienvesinh + tienphat;
            return thanhtien;
        }

        double checkItem(TextBox txtItem)
        {
            double value;

            if (txtItem.Text.Trim() == "" || double.Parse(txtItem.Text) <0 )
            {
                value = 0;
                
            }
            else
            {
                value = double.Parse(txtItem.Text);
            }
            return value;
        }

        private void txtTienDien_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (Regex.IsMatch(txtTienDien.Text, pattern)  )
                {
                    errorPro.Clear();
                    txtTienDien.BackColor = Color.White;
                    txtThanhTien.Text = TinhTienHoaDon().ToString();
                    ktErrorTienDien = 1;
                }
                else
                {
                    errorPro.SetError(this.txtTienDien, "Tiền điện không đúng định dạng ");
                    txtTienDien.BackColor = Color.Pink;

                }
            }
            catch 
            {
                errorPro.SetError(this.txtTienDien, "Tiền điện không đúng định dạng ");
                txtTienDien.BackColor = Color.Pink;
                ktErrorTienDien = 0;
            }
        }

        private void txtTienNc_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (Regex.IsMatch(txtTienNc.Text, pattern)  )
                {
                    errorPro.Clear();
                    txtTienNc.BackColor = Color.White;
                    txtThanhTien.Text = TinhTienHoaDon().ToString();
                    ktErrorTienNc = 1;
                }
                else
                {
                    errorPro.SetError(this.txtTienNc, "Tiền nước không đúng định dạng ");
                    txtTienNc.BackColor = Color.Pink;

                }
            }
            catch
            {
                errorPro.SetError(this.txtTienNc, "Tiền nước không đúng định dạng ");
                txtTienNc.BackColor = Color.Pink;
                ktErrorTienNc = 0;
            }
        }

        private void txtTienVeSinh_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (Regex.IsMatch(txtTienVeSinh.Text, pattern) || txtTienVeSinh.Text =="" )
                {
                    errorPro.Clear();
                    txtTienVeSinh.BackColor = Color.White;
                    txtThanhTien.Text = TinhTienHoaDon().ToString();
                    ktErrorTienVs = 1;
                    
                }
                else
                {
                    errorPro.SetError(this.txtTienVeSinh, "Tiền vệ sinh không đúng định dạng ");
                    txtTienVeSinh.BackColor = Color.Pink;

                }
            }
            catch
            {
                errorPro.SetError(this.txtTienVeSinh, "Tiền vệ sinh không đúng định dạng ");
                txtTienVeSinh.BackColor = Color.Pink;
                ktErrorTienVs = 0;
            }
            
        }

        private void txtTienPhat_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (Regex.IsMatch(txtTienPhat.Text, pattern)  )
                {
                    errorPro.Clear();
                    txtTienPhat.BackColor = Color.White;
                    txtThanhTien.Text = TinhTienHoaDon().ToString();
                    ktErrorTienPhat = 1;
                    
                }
                else
                {
                    errorPro.SetError(this.txtTienPhat, "Tiền phạt không đúng định dạng ");
                    txtTienPhat.BackColor = Color.Pink;

                }
            }
            catch {
                errorPro.SetError(this.txtTienPhat, "Tiền phạt không đúng định dạng ");
                txtTienPhat.BackColor = Color.Pink;
                ktErrorTienPhat = 0;

            }
        }
        private void CallTextChanged(object sender, EventArgs e)
        {
            txtTienNc_TextChanged(sender, e);
            txtTienDien_TextChanged(sender, e);
            txtTienPhat_TextChanged(sender, e);
            txtTienVeSinh_TextChanged(sender, e);

        }
        private void btn_Luu_Click(object sender, EventArgs e)
        {
            CallTextChanged(sender, e);
            if (hoaDon_BLL.CheckTable(maHD))
            {
                
                MessageBox.Show(maHD + " đã tồn tại !!!.");
                txtMHD.Text = "";
                return;
            }
            else
            {
                txtMHD.Text = maHD;
            }
            if (cbMaPhong.SelectedIndex == -1)
            {
                MessageBox.Show("Thiếu thông tin phòng !");
                return;
            }
            if(ktErrorTienDien == 0  || ktErrorTienNc == 0 || ktErrorTienPhat == 0 || ktErrorTienVs == 0)
            {
                MessageBox.Show
                   ("Các ô thông tin nhập vào còn trống, hoặc nhập vào không đúng đinh dạng, "
                    + "click vào dấu hiệu cảnh báo (dấu chấm than) bên cạnh để biết thêm chi tiết ",
                    "CẢNH BÁO ",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                if (txtMHD.Text.Trim() == "")
                {
                    MessageBox.Show("Thiếu thông tin mã hóa đơn !");
                    return;
                }
                else
                {
                    try
                    {
                        hoaDon_BLL.BLL_insert_HoaDon(cbMaPhong.SelectedValue.ToString(), txtMHD.Text, int.Parse(cbThang.Text), int.Parse(cmbNam.Text),  tiennha
                            ,tiendien,tiennuoc,tienvesinh,tienphat, dtp_NgayHetHan.Value,double.Parse(txtThanhTien.Text), 0);                       
                        MessageBox.Show("Thêm Hóa Đơn THÀNH CÔNG!!!", "THÔNG BÁO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        OpenDataGridView(txtMHD.Text);
                        reset();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Thêm THẤT BẠI do: " + ex, " CẢNH BÁO ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }

            }

             
        }

      

        private void OpenDataGridView(string MaHD)
        {
            dtGrid_HoaDon.DataSource = hoaDon_BLL.findByMaHD(MaHD);
            dtGrid_HoaDon.Columns[0].HeaderText = "Mã Phòng"; 
            dtGrid_HoaDon.Columns[1].HeaderText = "Mã Hóa Đơn ";
            dtGrid_HoaDon.Columns[2].HeaderText = "Tháng   ";
            dtGrid_HoaDon.Columns[3].HeaderText = "Năm   ";
            dtGrid_HoaDon.Columns[4].HeaderText = "Tiền Nhà ";
            dtGrid_HoaDon.Columns[5].HeaderText = "Tiền Điện  ";
            dtGrid_HoaDon.Columns[6].HeaderText = "Tiền Nước "; 
            dtGrid_HoaDon.Columns[7].HeaderText = "Tiền Vệ Sinh ";
            dtGrid_HoaDon.Columns[8].HeaderText = "Tiền Phạt ";
            dtGrid_HoaDon.Columns[9].HeaderText = "Ngày hết hạn ";
            dtGrid_HoaDon.Columns[10].HeaderText = "Ngày Đóng "; 
            dtGrid_HoaDon.Columns[11].HeaderText = "Tổng Tiền ";
            dtGrid_HoaDon.Columns[12].Visible = false;
            dtGrid_HoaDon.AllowUserToAddRows = false;
        }

        private void cb_MaHD_Click(object sender, EventArgs e)
        {
            DataTable dtHoaDon = hoaDon_BLL.getAll();
            dataUtils.FillCombobox(cb_MaHD, dtHoaDon, "MaHD", "MaHD");
        }

        private void cbMaPhong_Click(object sender, EventArgs e)
        {
            DataTable dtPhong = phong_BLL.ShowTable();

            dataUtils.FillCombobox(cbMaPhong, dtPhong, "MaPhong", "MaPhong");

        }

        private void dtGrid_HoaDon_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                cbMaPhong.Text = dtGrid_HoaDon.CurrentRow.Cells[0].Value.ToString();
                DataTable dtPhong = phong_BLL.findOneByMaPhong(cbMaPhong.Text);
                txtTenPhong.Text = dtPhong.Rows[0]["TenPhong"].ToString();
                txtTenKhu.Text = dtPhong.Rows[0]["TenKhu"].ToString();
                txtTienNha.Text = dtPhong.Rows[0]["GiaPhong"].ToString();
                txtTienDien.Enabled = txtTienNc.Enabled = txtTienPhat.Enabled = txtTienVeSinh.Enabled = true;
                btn_sua.Enabled = true;
                btn_Luu.Enabled = false;
                btn_Them.Enabled = false;
                cbMaPhong.Enabled = false;
               
                txtMHD.Text = dtGrid_HoaDon.CurrentRow.Cells[1].Value.ToString();            
               
                txtTienDien.Text = dtGrid_HoaDon.CurrentRow.Cells[5].Value.ToString(); ;
                txtTienNc.Text = dtGrid_HoaDon.CurrentRow.Cells[6].Value.ToString();
                txtTienVeSinh.Text = dtGrid_HoaDon.CurrentRow.Cells[7].Value.ToString();
                txtTienPhat.Text = dtGrid_HoaDon.CurrentRow.Cells[8].Value.ToString();
                dtp_NgayHetHan.Value = DateTime.Parse(dtGrid_HoaDon.Rows[e.RowIndex].Cells[9].Value.ToString());
                txtThanhTien.Text = dtGrid_HoaDon.CurrentRow.Cells[11].Value.ToString();

                txtTongTien.Text = dtGrid_HoaDon.CurrentRow.Cells[11].Value.ToString();
                lblBangchu.Text = "Bằng chữ : "+ hoaDon_BLL.convertNumberToText(double.Parse(txtTongTien.Text));
                lblBangchu. ForeColor = Color.Red;

                lbNgayDong.Visible = true; lbNgayDong.Enabled = true;
                lbTrangThai.Visible = true; lbTrangThai.Enabled = true;
                dtp_NgayDong.Enabled = true; dtp_NgayDong.Visible = true;
                rdb_ChuaDong.Visible = true; rdb_ChuaDong.Enabled = true;
                rdb_DaDong.Visible = true; rdb_DaDong.Enabled = true;
                if (dtGrid_HoaDon.CurrentRow.Cells[12].Value.ToString() == "True")
                {
                    rdb_DaDong.Checked = true;
                }
                else rdb_ChuaDong.Checked = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        
        private void btn_sua_Click(object sender, EventArgs e)
        {
            CallTextChanged(sender, e);
            DialogResult dialogResult = MessageBox.Show("BẠN CÓ THẬT SỰ MUỐN CẬP NHẬT?", " CẢNH BÁO", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (dialogResult == DialogResult.Yes)
            {
                    try
                    {
                        if (rdb_DaDong.Checked)
                        {
                            trangthai = 1;
                        }
                        if (rdb_ChuaDong.Checked)
                        {
                            trangthai = 0;
                        }
                        
                         hoaDon_BLL.BLL_Update_HoaDon(txtMHD.Text, dtp_NgayDong.Value, tiendien, tiennuoc, tienvesinh, 
                             tienphat, double.Parse(txtThanhTien.Text), trangthai);
                        MessageBox.Show("Cập nhật THÀNH CÔNG!!! ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                         OpenDataGridView(txtMHD.Text);
                    return;
                    }   
                    catch (Exception ex){
                        MessageBox.Show("Cập nhật THẤT BẠI do: " + ex, " CẢNH BÁO ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                     }
            }
            else return;


        }

        private void btn_Reset_Click(object sender, EventArgs e)
        {
                dtGrid_HoaDon.DataSource = null;

                txtMHD.Text = "";
                txtTongTien.Text = "";
                txtTenKhu.Text = txtTenPhong.Text = txtTienNha.Text = txtThanhTien.Text = "";
                txtTienPhat.Text = txtTienDien.Text = txtTienVeSinh.Text = txtTienNc.Text = "";
                txtTienDien.Enabled = txtTienNc.Enabled = txtTienPhat.Enabled = txtTienVeSinh.Enabled = false;

                lbNgayDong.Visible = false; lbNgayDong.Enabled = false;
                lbTrangThai.Visible = false; lbTrangThai.Enabled = false;
                lblBangchu.Text = "";

                dtp_NgayDong.Enabled = false; dtp_NgayDong.Visible = false;
                

                rdb_ChuaDong.Visible = false; rdb_ChuaDong.Enabled = false;
                rdb_DaDong.Visible = false; rdb_DaDong.Enabled = false;

                btn_sua.Enabled = false;
                btn_Luu.Enabled = false;
                btn_Them.Enabled = true;
                
                cbMaPhong.Enabled = true;
                cbMaPhong.Text = "";
                cb_MaHD.Text = "";

                txtMHD.Text = "";
                txtTongTien.Text = "";
                               
                errorPro.Clear();
                txtTienNc.BackColor = Color.White;
                txtTienDien.BackColor = Color.White;
                txtTienPhat.BackColor = Color.White;
                txtTienVeSinh.BackColor = Color.White;
               
            

        }

        private void reset()
        {
            txtMHD.Text = "";
            txtTongTien.Text = "";
            txtTenKhu.Text = txtTenPhong.Text = txtTienNha.Text = txtThanhTien.Text = "";
            txtTienPhat.Text = txtTienDien.Text = txtTienVeSinh.Text = txtTienNc.Text = "";
            txtTienDien.Enabled = txtTienNc.Enabled = txtTienPhat.Enabled = txtTienVeSinh.Enabled = false;

            lbNgayDong.Visible = false; lbNgayDong.Enabled = false;
            lbTrangThai.Visible = false; lbTrangThai.Enabled = false;
            lblBangchu.Text = "";

            cbMaPhong.Enabled = true;
            cbMaPhong.Text = "";
            cb_MaHD.Text = "";

            dtp_NgayDong.Enabled = false; dtp_NgayDong.Visible = false;
            

            rdb_ChuaDong.Visible = false; rdb_ChuaDong.Enabled = false;
            rdb_DaDong.Visible = false; rdb_DaDong.Enabled = false;
            errorPro.Clear();
            txtTienNc.BackColor = Color.White;
            txtTienDien.BackColor = Color.White;
            txtTienPhat.BackColor = Color.White;
            txtTienVeSinh.BackColor = Color.White;
        }


        private void btn_inHd_Click(object sender, EventArgs e)
        {
            if(dtGrid_HoaDon.Rows.Count > 0)
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
                header.Value = "HOÁ ĐƠN PHÒNG  ";


                //Định dạng tiêu đề bảng
                exSheet.get_Range("D7").Value = "Thành tiền";
                exSheet.get_Range("D7").ColumnWidth = 30;
                exSheet.get_Range("D7").Font.Bold = true;
                exSheet.get_Range("D17").Value = "Vũ Hải Đăng  ";
                exSheet.get_Range("D18").Value = "MB Bank : 072010457xxxx ";
                exSheet.get_Range("D20").Value = dtp_NgayHetHan.Value.ToString();
                exSheet.get_Range("D7:D20").HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                exSheet.get_Range("A7:A13").Font.Bold = true;
                exSheet.get_Range("A7:A13").HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                exSheet.get_Range("A7").Value = "STT";
                exSheet.get_Range("A7").ColumnWidth = 20;
                exSheet.get_Range("A8").ColumnWidth = 20;
                exSheet.get_Range("A9").Value = "Tiền điện :";
                exSheet.get_Range("A10").Value = "Tiền nước :";
                exSheet.get_Range("A11").Value = "Tiền vệ sinh :";
                exSheet.get_Range("A12").Value = "Tiền phạt :";
                exSheet.get_Range("A13").Value = "Tổng tiền : ";
                exSheet.get_Range("A17").Value = "Tài khoản : ";
                exSheet.get_Range("A18").Value = "Ngân hàng  : ";
                exSheet.get_Range("A19").Value = "Nội dung : ";
                exSheet.get_Range("A20").Value = "Ngày hết hạn : ";



                // In dữ liệu
               
                    exSheet.get_Range("A" + (8).ToString()).Value = "Phòng :" + dtGrid_HoaDon.Rows[0].Cells["MaPhong"].Value.ToString();
                    exSheet.get_Range("D" + (19).ToString()).Value = "Phòng " + dtGrid_HoaDon.Rows[0].Cells["MaPhong"].Value.ToString() +" chuyển tiền  ";
                    exSheet.get_Range("D" + (8).ToString()).Value = dtGrid_HoaDon.Rows[0].Cells["TienNha"].Value.ToString();
                    exSheet.get_Range("D" + (9).ToString()).Value = dtGrid_HoaDon.Rows[0].Cells["TienDien"].Value.ToString();
                    exSheet.get_Range("D" + (10).ToString()).Value = dtGrid_HoaDon.Rows[0].Cells["TienNuoc"].Value.ToString();
                    exSheet.get_Range("D" + (11).ToString()).Value = dtGrid_HoaDon.Rows[0].Cells["TienVeSinh"].Value.ToString();
                    exSheet.get_Range("D" + (12).ToString()).Value = dtGrid_HoaDon.Rows[0].Cells["TienPhat"].Value.ToString();
                    exSheet.get_Range("D" + (13).ToString()).Value = dtGrid_HoaDon.Rows[0].Cells["TongTien"].Value.ToString();

                



                exSheet.Name = "Hóa Đơn";
                exBook.Activate(); //Kích hoạt file Excel
                                   //Thiết lập các thuộc tính của SaveFileDialog
                dlgSaveFile.Filter = "Excel Document(*.xls)|*.xls |Word Document(*.doc) | *.doc | All files(*.*) | *.* ";
                dlgSaveFile.FilterIndex = 1;
                dlgSaveFile.AddExtension = true;
                dlgSaveFile.DefaultExt = ".xls";
                if (dlgSaveFile.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    exBook.SaveAs(dlgSaveFile.FileName.ToString());//Lưu file Excel
                    MessageBox.Show("In hóa đơn thành công .");
                }
                exApp.Quit();//Thoát khỏi ứng dụng
            }
            else
            {
                MessageBox.Show("Không có dữ liệu để in. " , " CẢNH BÁO ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_TimKiem_Click(object sender, EventArgs e)
        {
           
            DataTable dateSearch = new DataTable();
            if(cb_MaHD.Text.Trim() == "")
            {
                MessageBox.Show("Bạn chưa chọn thông tin !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
            else
            {
               
                dateSearch = hoaDon_BLL.findByMaHD(cb_MaHD.Text);
                if (dateSearch.Rows.Count > 0)
                {
                   
                    OpenDataGridView(cb_MaHD.Text);
                    reset();
                }
                else
                {
                    MessageBox.Show("Bạn tìm :  " + cb_MaHD.Text + " không có trong dữ liệu !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    cb_MaHD.Text = "";
                }
            }
        }

        private void cbThang_SelectedIndexChanged(object sender, EventArgs e)
        {
            int mm = int.Parse(cbThang.Text);
            dtp_NgayHetHan.Value = new DateTime(DateTime.Now.Year, mm, 10);
        }

        private void cmbNam_SelectedIndexChanged(object sender, EventArgs e)
        {
            int mm = int.Parse(cbThang.Text);
            int yyyy = int.Parse(cmbNam.Text);
            dtp_NgayHetHan.Value = new DateTime(yyyy, mm, 10);
        }
    }
}
