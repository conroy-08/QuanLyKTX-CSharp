using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
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
        int trangthai;

        private void HoaDon_GUI_Load(object sender, EventArgs e)
        {
            lbNgayDong.Visible = false; lbNgayDong.Enabled = false;
            lbTrangThai.Visible = false; lbTrangThai.Enabled = false;
            dtp_NgayDong.Enabled = false; dtp_NgayDong.Visible = false;
            rdb_ChuaDong.Visible = false; rdb_ChuaDong.Enabled = false;
            rdb_DaDong.Visible = false; rdb_DaDong.Enabled = false;
            btn_sua.Enabled = false;
            dtp_NgayLap.Enabled = false;

            // Đổ dữ liệu ra combobox
            DataTable dtPhong = phong_BLL.ShowTable();
            DataTable dtHoaDon = hoaDon_BLL.getAll();
            dataUtils.FillCombobox(cbMaPhong, dtPhong, "MaPhong", "MaPhong");
            dataUtils.FillCombobox(cb_MaHD, dtHoaDon, "MaHD", "MaHD");
            cbMaPhong.Text = "";
            cb_MaHD.Text = "";
            dtp_NgayHetHan.Value = dtp_NgayLap.Value.AddDays(+7);

        }

        void ResetValue()
        {
            txtMHD.Text = "";
             txtTenKhu.Text = "";
             txtTenPhong.Text = "";
             txtThanhTien.Text = "";
             txtTienDien.Text = txtTienNc.Text = txtTienPhat.Text = txtTienVeSinh.Text = txtTienNha.Text = "";
             cbMaPhong.Text = "";
           

        }

        private void cbMaPhong_SelectedIndexChanged(object sender, EventArgs e)
        {

            

            try
            {
             
                    DataTable dtPhong = phong_BLL.findOneByMaPhong(cbMaPhong.SelectedValue.ToString());
                    txtTenPhong.Text = dtPhong.Rows[0]["TenPhong"].ToString();
                    txtTenKhu.Text = dtPhong.Rows[0]["TenKhu"].ToString();
                    txtTienNha.Text = dtPhong.Rows[0]["GiaPhong"].ToString();
                    txtTienDien.Enabled = txtTienNc.Enabled = txtTienPhat.Enabled = txtTienVeSinh.Enabled = true;
                    dtp_NgayLap.Enabled = true;
                
            }
            catch
            {

            }
        }



        private void btn_Them_Click(object sender, EventArgs e)
        {
            string maPhong;
            if (cbMaPhong.Text.Trim() == "")
            {
                MessageBox.Show(" Không thể lập mã hóa đơn !!!. Bởi vì bạn chưa chọn mã phòng !!!!");
                return;
            }
            else
            {
                maPhong = cbMaPhong.SelectedValue.ToString();
                maHD = "HD" + maPhong +   dtp_NgayLap.Value.Month.ToString() + dtp_NgayLap.Value.Year.ToString();
                if (hoaDon_BLL.CheckTable(maHD))
                {
                    txtMHD.Text = maHD;
                    MessageBox.Show(maHD + " đã tồn tại !!!.");
                    txtMHD.Text = "";
                }
                else
                {
                    txtMHD.Text = maHD;
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
            double thanhtien, tiennha, tiendien, tiennuoc, tienvesinh, tienphat;
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

            if (txtItem.Text.Trim() == "" || double.Parse(txtItem.Text) <=0)
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
            txtThanhTien.Text = TinhTienHoaDon().ToString();
        }

        private void txtTienNc_TextChanged(object sender, EventArgs e)
        {
            txtThanhTien.Text = TinhTienHoaDon().ToString();
        }

        private void txtTienVeSinh_TextChanged(object sender, EventArgs e)
        {
            txtThanhTien.Text = TinhTienHoaDon().ToString();
        }

        private void txtTienPhat_TextChanged(object sender, EventArgs e)
        {
            txtThanhTien.Text = TinhTienHoaDon().ToString();
        }

        private void btn_Luu_Click(object sender, EventArgs e)
        {
            if (cbMaPhong.SelectedIndex == -1)
            {
                MessageBox.Show("Thiếu thông tin phòng !");
                return;
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
                        double tongtien, tiennha, tiendien, tiennuoc, tienvesinh, tienphat;
                        tiennha = double.Parse(txtTienNha.Text);
                        tiendien = checkItem(txtTienDien);
                        tiennuoc = checkItem(txtTienNc);
                        tienvesinh = checkItem(txtTienVeSinh);
                        tienphat = checkItem(txtTienPhat);
                        tongtien = double.Parse(txtThanhTien.Text);
                        hoaDon_BLL.BLL_insert_HoaDon(cbMaPhong.SelectedValue.ToString(), txtMHD.Text, dtp_NgayLap.Value , tiennha
                            ,tiendien,tiennuoc,tienvesinh,tienphat,tongtien,0);                       
                        MessageBox.Show("Thêm Hóa Đơn THÀNH CÔNG!!!", "THÔNG BÁO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        OpenDataGridView(txtMHD.Text);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Thêm THẤT BẠI do: " + ex, " CẢNH BÁO ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }


            }


        }

        private void dtp_NgayLap_ValueChanged(object sender, EventArgs e)
        {
            dtp_NgayHetHan.Value = dtp_NgayLap.Value.AddDays(+7);
        }

        private void OpenDataGridView(string MaHD)
        {
            dtGrid_HoaDon.DataSource = hoaDon_BLL.findByMaHD(MaHD);
            dtGrid_HoaDon.Columns[0].HeaderText = "Mã Phòng"; 
            dtGrid_HoaDon.Columns[1].HeaderText = "Mã Hóa Đơn ";
            dtGrid_HoaDon.Columns[2].HeaderText = "Ngày Lập HĐ  "; 
            dtGrid_HoaDon.Columns[3].HeaderText = "Tiền Điện  ";
            dtGrid_HoaDon.Columns[4].HeaderText = "Tiền Nước "; 
            dtGrid_HoaDon.Columns[5].HeaderText = "Tiền Vệ Sinh ";
            dtGrid_HoaDon.Columns[6].HeaderText = "Tiền Phạt "; 
            dtGrid_HoaDon.Columns[7].HeaderText = "Ngày Đóng "; 
            dtGrid_HoaDon.Columns[8].HeaderText = "Tổng Tiền ";
            dtGrid_HoaDon.Columns[9].Visible = false;
            dtGrid_HoaDon.Columns[10].HeaderText = "Tiền Nhà ";
            dtGrid_HoaDon.AllowUserToAddRows = false;
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
                dtp_NgayLap.Enabled = false;
                cbMaPhong.Enabled = false;
                btn_Reset.Enabled = false;
                txtMHD.Text = dtGrid_HoaDon.CurrentRow.Cells[1].Value.ToString();
                dtp_NgayLap.Value = DateTime.Parse(dtGrid_HoaDon.CurrentRow.Cells[2].Value.ToString());
                dtp_NgayHetHan.Value = dtp_NgayLap.Value.AddDays(+7);
                txtTienDien.Text = dtGrid_HoaDon.CurrentRow.Cells[3].Value.ToString(); ;
                txtTienNc.Text = dtGrid_HoaDon.CurrentRow.Cells[4].Value.ToString();
                txtTienVeSinh.Text = dtGrid_HoaDon.CurrentRow.Cells[5].Value.ToString();
                txtTienPhat.Text = dtGrid_HoaDon.CurrentRow.Cells[6].Value.ToString();
                txtThanhTien.Text = dtGrid_HoaDon.CurrentRow.Cells[8].Value.ToString();
                txtTongTien.Text = dtGrid_HoaDon.CurrentRow.Cells[8].Value.ToString();
                lblBangchu.Text = "Bằng chữ : "+ hoaDon_BLL.convertNumberToText(double.Parse(txtTongTien.Text));
                lblBangchu. ForeColor = Color.Red;

                lbNgayDong.Visible = true; lbNgayDong.Enabled = true;
                lbTrangThai.Visible = true; lbTrangThai.Enabled = true;
                dtp_NgayDong.Enabled = true; dtp_NgayDong.Visible = true;
                rdb_ChuaDong.Visible = true; rdb_ChuaDong.Enabled = true;
                rdb_DaDong.Visible = true; rdb_DaDong.Enabled = true;
                if (dtGrid_HoaDon.CurrentRow.Cells[9].Value.ToString() == "True")
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
                        double tongtien,  tiendien, tiennuoc, tienvesinh, tienphat;
                        tiendien = checkItem(txtTienDien);
                        tiennuoc = checkItem(txtTienNc);
                        tienvesinh = checkItem(txtTienVeSinh);
                        tienphat = checkItem(txtTienPhat);
                        tongtien = double.Parse(txtThanhTien.Text);
                         hoaDon_BLL.BLL_Update_HoaDon(txtMHD.Text, dtp_NgayDong.Value, tiendien, tiennuoc, tienvesinh, tienphat, tongtien, trangthai);
                        MessageBox.Show("Cập nhật THÀNH CÔNG!!! ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    OpenDataGridView(txtMHD.Text);
                }   
                    catch (Exception ex)
                    {
                        MessageBox.Show("Cập nhật THẤT BẠI do: " + ex, " CẢNH BÁO ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
            }
           
            
        }

        private void btn_Reset_Click(object sender, EventArgs e)
        {
            txtTienDien.Enabled = txtTienNc.Enabled = txtTienPhat.Enabled = txtTienVeSinh.Enabled = false;
            btn_Luu.Enabled = true; btn_Luu.Visible = true;
            lbNgayDong.Visible = false; lbNgayDong.Enabled = false;
            lbTrangThai.Visible = false; lbTrangThai.Enabled = false;
            dtp_NgayDong.Enabled = false; dtp_NgayDong.Visible = false;
            rdb_ChuaDong.Visible = false; rdb_ChuaDong.Enabled = false;
            rdb_DaDong.Visible = false; rdb_DaDong.Enabled = false;
            dtp_NgayLap.Enabled = true;
            cbMaPhong.Enabled = true;
            lbNgayDong.Visible = false; lbNgayDong.Enabled = false;
            lbTrangThai.Visible = false; lbTrangThai.Enabled = false;
            btn_Them.Enabled = true;
            dtp_NgayLap.Enabled = false;
            btn_sua.Enabled = false;
            cbMaPhong.Text = "";
            txtTenKhu.Text = txtTenPhong.Text = txtTienNha.Text = txtThanhTien.Text = "";
            txtTienDien.Text = txtTienNc.Text = txtTienPhat.Text = txtTienVeSinh.Text = "";
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
                exSheet.get_Range("D17").Value = "Vũ Hải Đăng : ";
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
                    exSheet.get_Range("D" + (19).ToString()).Value = "Phòng " + dtGrid_HoaDon.Rows[0].Cells["MaPhong"].Value.ToString() +"chuyển tiền  ";
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
                }
                else
                {
                    MessageBox.Show("Bạn tìm :  " + cb_MaHD.Text + " không có trong dữ liệu !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    cb_MaHD.Text = "";
                }
            }
        }
    }
}
