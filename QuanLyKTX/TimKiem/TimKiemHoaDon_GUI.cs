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

namespace QuanLyKTX.TimKiem
{
    public partial class TimKiemHoaDon_GUI : Form
    {
        Phong.Phong_BLL phong_BLL = new Phong.Phong_BLL();
        Utils.DataUtils dataUtils = new Utils.DataUtils();
        HoaDon.HoaDon_BLL hoaDon_BLL = new HoaDon.HoaDon_BLL();
        string MaPhong;

        public TimKiemHoaDon_GUI()
        {
            InitializeComponent();
        }

        private void TimKiemHoaDon_GUI_Load(object sender, EventArgs e)
        {
            txtKhuNha.Enabled = false;
            txtTenPhong.Enabled = false;
            cmbMaHD.Enabled = false;
            btnTimKiem.Enabled = false;
            dtp_NgayDong.Enabled = false; dtp_NgayDong.Visible = false;
            txtTongTien.Enabled = false; txtTongTien.Visible = false;
            lblTongTien.Enabled = false; lblTongTien.Visible = false;
            lblNgayDong.Enabled = false; lblNgayDong.Visible = false;
        }

        private void cmbMaPhong_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {

                DataTable dtPhong = phong_BLL.findOneByMaPhong(cmbMaPhong.SelectedValue.ToString());
                txtTenPhong.Text = dtPhong.Rows[0]["TenPhong"].ToString();
                txtKhuNha.Text = dtPhong.Rows[0]["TenKhu"].ToString();
                if(cmbMaPhong.Text != "")
                {
                    cmbMaHD.Enabled = true;
                    MaPhong = cmbMaPhong.Text;
                    btnTimKiem.Enabled = true;
                }
               
                
            }
            catch
            {

            }
        }

        private void cmbMaPhong_Click(object sender, EventArgs e)
        {
            DataTable dtPhong = phong_BLL.ShowTable();
            dataUtils.FillCombobox(cmbMaPhong, dtPhong, "MaPhong", "MaPhong");

        }

        private void cmbMaHD_Click(object sender, EventArgs e)
        {
            DataTable dtHoaDon = hoaDon_BLL.findByMaPhongAndMaHD(MaPhong ,"");
            dataUtils.FillCombobox(cmbMaHD, dtHoaDon, "MaHD", "MaHD");
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            DataTable dateSearch = new DataTable();
            if (cmbMaPhong.Text.Trim() == "")
            {
                MessageBox.Show("Bạn chưa chọn thông tin !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
            else
            {
                if(cmbMaHD.Text.Trim() == "")
                {
                    dateSearch = hoaDon_BLL.findByMaPhongAndMaHD(cmbMaPhong.Text ,"");
                    if (dateSearch.Rows.Count > 0)
                    {
                        OpenDataGridView(cmbMaPhong.Text, "");

                    }
                    else
                    {
                        MessageBox.Show("Không có trong dữ liệu cần tìm !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Stop);

                    }
                }
                else
                {
                    dateSearch = hoaDon_BLL.findByMaPhongAndMaHD(cmbMaPhong.Text, cmbMaHD.Text);
                    if (dateSearch.Rows.Count > 0)
                    {
                        OpenDataGridView(cmbMaPhong.Text, cmbMaHD.Text);
                    }
                    else
                    {
                        MessageBox.Show("Không có trong dữ liệu cần tìm !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    }

                }
               
               
            }
        }

        void OpenDataGridView(string MaPhong , string MaHD)
        {
            dtGridTimKiem.DataSource = hoaDon_BLL.findByMaPhongAndMaHD(MaPhong, MaHD);
            dtGridTimKiem.Columns[0].HeaderText = "Mã Phòng";
            dtGridTimKiem.Columns[1].HeaderText = "Mã Hóa Đơn ";
            dtGridTimKiem.Columns[2].HeaderText = "Tháng   ";
            dtGridTimKiem.Columns[3].HeaderText = "Năm   ";
            dtGridTimKiem.Columns[4].HeaderText = "Tiền Nhà ";
            dtGridTimKiem.Columns[5].HeaderText = "Tiền Điện  ";
            dtGridTimKiem.Columns[6].HeaderText = "Tiền Nước ";
            dtGridTimKiem.Columns[7].HeaderText = "Tiền Vệ Sinh ";
            dtGridTimKiem.Columns[8].HeaderText = "Tiền Phạt ";
            dtGridTimKiem.Columns[9].HeaderText = "Ngày hết hạn ";
            dtGridTimKiem.Columns[10].HeaderText = "Ngày Đóng ";
            dtGridTimKiem.Columns[11].HeaderText = "Tổng Tiền ";
            dtGridTimKiem.Columns[12].Visible = false;
            dtGridTimKiem.AllowUserToAddRows = false;
        }

        private void dtGridTimKiem_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                cmbMaPhong.Text = dtGridTimKiem.CurrentRow.Cells[0].Value.ToString();
                cmbMaHD.Text = dtGridTimKiem.CurrentRow.Cells[1].Value.ToString();
                DataTable dtPhong = phong_BLL.findOneByMaPhong(cmbMaPhong.SelectedValue.ToString());
                txtTenPhong.Text = dtPhong.Rows[0]["TenPhong"].ToString();
                txtKhuNha.Text = dtPhong.Rows[0]["TenKhu"].ToString();
                if(dtGridTimKiem.Rows[e.RowIndex].Cells[10].Value.ToString() == "")
                {
                    dtp_NgayDong.Enabled = false; dtp_NgayDong.Visible = false;
                    lblNgayDong.Text = "Ngày đóng :    Chưa có ngày đóng ";
                    
                }
                else
                {
                    dtp_NgayDong.Value = DateTime.Parse(dtGridTimKiem.Rows[e.RowIndex].Cells[10].Value.ToString());
                    dtp_NgayDong.Visible = true; dtp_NgayDong.Enabled = false;
                }
                txtTongTien.Text = dtGridTimKiem.CurrentRow.Cells[11].Value.ToString();            
                txtTongTien.Enabled = false; txtTongTien.Visible = true;
                lblTongTien.Enabled = false; lblTongTien.Visible = true;
                lblNgayDong.Enabled = false; lblNgayDong.Visible = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn chắc chắn muốn thoát chứ?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void btn_InExcel_Click(object sender, EventArgs e)
        {
            if(dtGridTimKiem.Rows.Count > 0)
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

                if(dtGridTimKiem.Rows.Count == 1)
                {
                    addOne(exSheet);
                }
                else
                {
                    addAll(exSheet);
                }

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

        void addOne(Excel.Worksheet exSheet)
        {

            //Định dạng tiêu đề bảng
            exSheet.get_Range("D7").Value = "Thành tiền";
            exSheet.get_Range("D7").ColumnWidth = 30;
            exSheet.get_Range("D7").Font.Bold = true;
            exSheet.get_Range("D17").Value = "Vũ Hải Đăng  ";
            exSheet.get_Range("D18").Value = "MB Bank : 072010457xxxx ";
            exSheet.get_Range("D20").Value = dtGridTimKiem.Rows[0].Cells["NgayHetHan"].Value.ToString();
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

            exSheet.get_Range("A" + (8).ToString()).Value = "Phòng :" + dtGridTimKiem.Rows[0].Cells["MaPhong"].Value.ToString();
            exSheet.get_Range("D" + (19).ToString()).Value = "Phòng " + dtGridTimKiem.Rows[0].Cells["MaPhong"].Value.ToString() + " chuyển tiền  ";
            exSheet.get_Range("D" + (8).ToString()).Value = dtGridTimKiem.Rows[0].Cells["TienNha"].Value.ToString();
            exSheet.get_Range("D" + (9).ToString()).Value = dtGridTimKiem.Rows[0].Cells["TienDien"].Value.ToString();
            exSheet.get_Range("D" + (10).ToString()).Value = dtGridTimKiem.Rows[0].Cells["TienNuoc"].Value.ToString();
            exSheet.get_Range("D" + (11).ToString()).Value = dtGridTimKiem.Rows[0].Cells["TienVeSinh"].Value.ToString();
            exSheet.get_Range("D" + (12).ToString()).Value = dtGridTimKiem.Rows[0].Cells["TienPhat"].Value.ToString();
            exSheet.get_Range("D" + (13).ToString()).Value = dtGridTimKiem.Rows[0].Cells["TongTien"].Value.ToString();



        }

        void addAll(Excel.Worksheet exSheet)
        {
            exSheet.get_Range("A7:M7").Font.Bold = true;
            exSheet.get_Range("A7:M7").HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
            exSheet.get_Range("A7").Value = "STT";
            exSheet.get_Range("B7").Value = "Mã Phòng";
            exSheet.get_Range("B7").ColumnWidth = 15;
            exSheet.get_Range("C7").Value = "Mã Hóa Đơn";
            exSheet.get_Range("C7").ColumnWidth = 20;
            exSheet.get_Range("D7").Value = "Tháng ";
            exSheet.get_Range("D7").ColumnWidth = 12;
            exSheet.get_Range("E7").Value = "Năm";
            exSheet.get_Range("E7").ColumnWidth = 12;
            exSheet.get_Range("F7").Value = "Tiền nhà";
            exSheet.get_Range("F7").ColumnWidth = 30;
            exSheet.get_Range("G7").Value = "Tiền điện";
            exSheet.get_Range("G7").ColumnWidth = 20;
            exSheet.get_Range("H7").Value = "Tiền nước";
            exSheet.get_Range("H7").ColumnWidth = 20;
            exSheet.get_Range("I7").Value = "Tiền vệ sinh";
            exSheet.get_Range("I7").ColumnWidth = 20;
            exSheet.get_Range("J7").Value = "Tiền phạt";
            exSheet.get_Range("J7").ColumnWidth = 20;
            exSheet.get_Range("K7").Value = "Ngày hết hạn";
            exSheet.get_Range("K7").ColumnWidth = 20;
            exSheet.get_Range("L7").Value = "Ngày đóng";
            exSheet.get_Range("L7").ColumnWidth = 20;
            exSheet.get_Range("M7").Value = "Tổng tiền";
            exSheet.get_Range("M7").ColumnWidth = 20;

            for (int i = 0; i < dtGridTimKiem.Rows.Count; i++)
            {
                exSheet.get_Range("A" + (i + 8).ToString() + ":H" + (i + 8).ToString()).Font.Bold = false;
                exSheet.get_Range("A" + (i + 8).ToString()).Value = (i + 1).ToString();
                exSheet.get_Range("B" + (i + 8).ToString()).Value = dtGridTimKiem.Rows[i].Cells["MaPhong"].Value.ToString();
                exSheet.get_Range("C" + (i + 8).ToString()).Value = dtGridTimKiem.Rows[i].Cells["MaHD"].Value.ToString();
                exSheet.get_Range("D" + (i + 8).ToString()).Value = dtGridTimKiem.Rows[i].Cells["Thang"].Value.ToString();
                exSheet.get_Range("E" + (i + 8).ToString()).Value = dtGridTimKiem.Rows[i].Cells["Nam"].Value.ToString();
                exSheet.get_Range("F" + (i + 8).ToString()).Value = dtGridTimKiem.Rows[i].Cells["TienNha"].Value.ToString();
                exSheet.get_Range("G" + (i + 8).ToString()).Value = dtGridTimKiem.Rows[i].Cells["TienDien"].Value.ToString();
                exSheet.get_Range("H" + (i + 8).ToString()).Value = dtGridTimKiem.Rows[i].Cells["TienNuoc"].Value.ToString();
                exSheet.get_Range("I" + (i + 8).ToString()).Value = dtGridTimKiem.Rows[i].Cells["TienVeSinh"].Value.ToString();
                exSheet.get_Range("J" + (i + 8).ToString()).Value = dtGridTimKiem.Rows[i].Cells["TienPhat"].Value.ToString();
                exSheet.get_Range("K" + (i + 8).ToString()).Value = dtGridTimKiem.Rows[i].Cells["NgayHetHan"].Value.ToString();
                exSheet.get_Range("L" + (i + 8).ToString()).Value = dtGridTimKiem.Rows[i].Cells["NgayDong"].Value.ToString();
                exSheet.get_Range("M" + (i + 8).ToString()).Value = dtGridTimKiem.Rows[i].Cells["TongTien"].Value.ToString();
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {  
            dtGridTimKiem.DataSource = null;
            txtKhuNha.Enabled = false;
            txtTenPhong.Enabled = false;
            cmbMaHD.Enabled = false;
            cmbMaHD.Text = "";
            cmbMaPhong.Text = "";
            txtKhuNha.Text = txtTenPhong.Text = txtTongTien.Text = "";
            dtp_NgayDong.Enabled = false; dtp_NgayDong.Visible = false;
            txtTongTien.Enabled = false; txtTongTien.Visible = false;
            lblTongTien.Enabled = false; lblTongTien.Visible = false;
            lblNgayDong.Enabled = false; lblNgayDong.Visible = false;
            btnTimKiem.Enabled = false;
        }
    }
}
