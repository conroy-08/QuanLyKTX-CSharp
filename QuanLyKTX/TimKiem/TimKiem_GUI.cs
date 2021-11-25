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
    public partial class TimKiem_GUI : Form
    {
        TimKiem_BLL timkiem = new TimKiem_BLL();

        public TimKiem_GUI()
        {
            InitializeComponent();
        }
        void EditTable()
        {
            dgv_TimKiem.Columns[0].HeaderText = "Mã Số Thuê";
            dgv_TimKiem.Columns[1].HeaderText = "Mã Sinh Viên";
            dgv_TimKiem.Columns[2].HeaderText = "Mã Phòng";
            dgv_TimKiem.Columns[3].HeaderText = "Tên Sinh Viên";
            dgv_TimKiem.Columns[4].HeaderText = "Ngày Sinh";
            dgv_TimKiem.Columns[5].HeaderText = "Giới Tính";
            dgv_TimKiem.Columns[6].HeaderText = "Tên Phòng";
            dgv_TimKiem.Columns[7].HeaderText = "Loại Phòng";
            dgv_TimKiem.Columns[8].HeaderText = "Số Người Tối Đa";
            dgv_TimKiem.Columns[9].HeaderText = "Số Người Đang ở";
            dgv_TimKiem.Columns[10].HeaderText = "Giá Phòng";
            dgv_TimKiem.Columns[11].HeaderText = "Ngày Bắt Đầu";
            dgv_TimKiem.Columns[12].HeaderText = "Ngày Kết Thúc";
            dgv_TimKiem.Columns[13].HeaderText = "Trạng Thái Thuê Phòng";

            dgv_TimKiem.BackgroundColor = Color.Gray;
            dgv_TimKiem.Columns[0].Width = 85;
            dgv_TimKiem.Columns[1].Width = 85;
            dgv_TimKiem.Columns[2].Width = 85;
            dgv_TimKiem.Columns[3].Width = 130;
            dgv_TimKiem.Columns[4].Width = 70;
            dgv_TimKiem.Columns[5].Width = 70;
            dgv_TimKiem.Columns[6].Width = 70;
            dgv_TimKiem.Columns[7].Width = 70;
            dgv_TimKiem.Columns[8].Width = 70;
            dgv_TimKiem.Columns[9].Width = 70;
            dgv_TimKiem.Columns[10].Width = 90;
            dgv_TimKiem.Columns[11].Width = 90;
            dgv_TimKiem.Columns[12].Width = 90;
            dgv_TimKiem.Columns[13].Width = 90;
            dgv_TimKiem.AllowUserToAddRows = false;
        }

        void ShowTable()
        {
            dgv_TimKiem.DataSource = timkiem.ShowTable();
        }

        private void KhuNha_GUI_Load(object sender, EventArgs e)
        {
            while (!User.FormLogin.Checked)
            {
                User.FormLogin formLogin = new User.FormLogin();
                formLogin.ShowDialog();

                this.Close();
            }

            try
            {
                txt_SinhVien.Focus();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông báo");
            }
        }

        private void dgv_TimKiem_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txt_SinhVien.Enabled = true;
            txt_Phong.Enabled = true;
            txt_SinhVien.Text = "";
            txt_Phong.Text = "";

            txt_MST.Text = dgv_TimKiem.CurrentRow.Cells[0].Value.ToString();
            txt_MaSV.Text = dgv_TimKiem.CurrentRow.Cells[1].Value.ToString();
            txt_MaP.Text = dgv_TimKiem.CurrentRow.Cells[2].Value.ToString();
            txt_TenSV.Text = dgv_TimKiem.CurrentRow.Cells[3].Value.ToString();
            txt_NgaySinh.Text = dgv_TimKiem.CurrentRow.Cells[4].Value.ToString();
            txt_GioiTinh.Text = dgv_TimKiem.CurrentRow.Cells[5].Value.ToString();
            txt_TenPhong.Text = dgv_TimKiem.CurrentRow.Cells[6].Value.ToString();
            txt_LoaiPhong.Text = dgv_TimKiem.CurrentRow.Cells[7].Value.ToString();
            txt_SoLuongMax.Text = dgv_TimKiem.CurrentRow.Cells[8].Value.ToString();
            txt_SoLuongNow.Text = dgv_TimKiem.CurrentRow.Cells[9].Value.ToString();
            txt_GiaPhong.Text = dgv_TimKiem.CurrentRow.Cells[10].Value.ToString();
            txt_NgayBD.Text = dgv_TimKiem.CurrentRow.Cells[11].Value.ToString();
            txt_NgayKT.Text = dgv_TimKiem.CurrentRow.Cells[12].Value.ToString();
            txt_TT.Text = dgv_TimKiem.CurrentRow.Cells[13].Value.ToString();
            
        }
        

        private void btn_TimKiem_Click(object sender, EventArgs e)
        {
            try
            {  
                if (txt_SinhVien.Text == "" && txt_Phong.Text == "" && cbb_TTTP.SelectedIndex < 1)
                {
                    MessageBox.Show("Hãy nhập gì đó để tìm kiếm");
                }
                else
                { 
                    dgv_TimKiem.Enabled = true;
                    resettext();
                }

                if (txt_SinhVien.Text != "" && txt_Phong.Text != "" && cbb_TTTP.SelectedIndex >= 1)
                {
                    dgv_TimKiem.DataSource = timkiem.Search_SV_P_TT(txt_SinhVien.Text, txt_Phong.Text, cbb_TTTP.SelectedIndex - 1);
                    EditTable();
                    return;
                }

                if (txt_SinhVien.Text != "" && txt_Phong.Text != "" && cbb_TTTP.SelectedIndex < 1)
                {
                    dgv_TimKiem.DataSource = timkiem.Search_SV_P(txt_SinhVien.Text, txt_Phong.Text);
                    EditTable();
                    return;
                }
                if (txt_SinhVien.Text != "" && txt_Phong.Text == "" && cbb_TTTP.SelectedIndex < 1)
                {
                    dgv_TimKiem.DataSource = timkiem.SearchSV(txt_SinhVien.Text);
                    EditTable();
                    return;
                }
                if (txt_SinhVien.Text == "" && txt_Phong.Text != "" && cbb_TTTP.SelectedIndex < 1)
                {
                    dgv_TimKiem.DataSource = timkiem.SearchPhong(txt_Phong.Text);
                    EditTable();
                    return;
                }

                if (txt_SinhVien.Text != "" && txt_Phong.Text == "" && cbb_TTTP.SelectedIndex >= 1)
                {
                    dgv_TimKiem.DataSource = timkiem.Search_SV_TT(txt_SinhVien.Text,cbb_TTTP.SelectedIndex - 1);
                    EditTable();
                    return;
                }

                if (txt_SinhVien.Text == "" && txt_Phong.Text != "" && cbb_TTTP.SelectedIndex >= 1)
                {
                    dgv_TimKiem.DataSource = timkiem.Search_P_TT(txt_Phong.Text, cbb_TTTP.SelectedIndex - 1);
                    EditTable();
                    return;
                }
                if (txt_SinhVien.Text == "" && txt_Phong.Text == "" && cbb_TTTP.SelectedIndex >= 1)
                {
                    dgv_TimKiem.DataSource = timkiem.Search_TT(cbb_TTTP.SelectedIndex - 1);
                    EditTable();
                    return;
                }


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông báo");
            }
            finally
            {
                txt_SinhVien.Focus();
            }
        }

        private void btn_Thoat_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn chắc chắn chứ?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void btn_Show_Click(object sender, EventArgs e)
        {
            ShowTable();
        }

        private void btn_Reset_Click(object sender, EventArgs e)
        {
            dgv_TimKiem.Enabled = true;
            dgv_TimKiem.DataSource = null;
            txt_Phong.Text = "";
            txt_SinhVien.Text = "";
            resettext();
        }
        void resettext()
        {
            txt_MST.Text = "";
            txt_MaSV.Text = "";
            txt_MaP.Text = "";
            txt_TenSV.Text = "";
            txt_NgaySinh.Text = "";
            txt_GioiTinh.Text = "";
            txt_TenPhong.Text = "";
            txt_LoaiPhong.Text = "";
            txt_SoLuongMax.Text = "";
            txt_SoLuongNow.Text = "";
            txt_GiaPhong.Text = "";
            txt_NgayBD.Text = "";
            txt_NgayKT.Text = ""; 
            txt_TT.Text = "";
        }

        private void btc_InExcel_Click(object sender, EventArgs e)
        {
            if (dgv_TimKiem.Rows.Count > 0)
            {
                //Khai báo và khởi tạo các đối tượng
                Excel.Application exApp = new Excel.Application();
                Excel.Workbook exBook = exApp.Workbooks.Add(Excel.XlWBATemplate.xlWBATWorksheet);
                Excel.Worksheet exSheet = (Excel.Worksheet)exBook.Worksheets[1];

                //Định dạng chung
                Excel.Range tenKTX = (Excel.Range)exSheet.Cells[1, 1];
                exSheet.get_Range("A1:E1").Merge(true);
                tenKTX.Font.Size = 12;
                tenKTX.Font.Bold = true;
                tenKTX.Font.Color = Color.Blue;
                tenKTX.Value = "KÍ TÚC XÁ SINH VIÊN ĐẠI HỌC GTVT ";
                Excel.Range dcKTX = (Excel.Range)exSheet.Cells[2, 1];
                exSheet.get_Range("A2:E2").Merge(true);
                dcKTX.Font.Size = 12;
                dcKTX.Font.Bold = true;
                dcKTX.Font.Color = Color.Blue;
                dcKTX.Value = "Địa chỉ: Số 99 - Nguyễn Chí Thanh - P.Láng Hạ - Q.Đống Đa - TP. Hà Nội.";
                Excel.Range dtKTX = (Excel.Range)exSheet.Cells[3, 1];
                exSheet.get_Range("A3:E3").Merge(true);
                dtKTX.Font.Size = 12;
                dtKTX.Font.Bold = true;
                dtKTX.Font.Color = Color.Blue;
                dtKTX.Value = "Điện thoại: 0336125345";


                Excel.Range header = (Excel.Range)exSheet.Cells[5, 6];
                exSheet.get_Range("F5:J5").Merge(true);
                header.Font.Size = 16;
                header.Font.Bold = true;
                header.Font.Color = Color.Red;
                header.Value = "Danh Sách Tìm Kiếm ";

                exSheet.get_Range("A7").Value = "STT";
                exSheet.get_Range("B7").Value = "Mã Số Thuê";
                exSheet.get_Range("C7").Value = "Mã Sinh Viên";
                exSheet.get_Range("D7").Value = "Mã Phòng";
                exSheet.get_Range("E7").Value = "Tên Sinh Viên";
                exSheet.get_Range("F7").Value = "Ngày Sinh";
                exSheet.get_Range("G7").Value = "Giới Tính";
                exSheet.get_Range("H7").Value = "Tên Phòng";
                exSheet.get_Range("I7").Value = "Loại Phòng";
                exSheet.get_Range("J7").Value = "Số Người Tối Đa";
                exSheet.get_Range("K7").Value = "Số Người Đang Ở";
                exSheet.get_Range("L7").Value = "Giá Phòng";
                exSheet.get_Range("M7").Value = "Ngày Bắt Đầu";
                exSheet.get_Range("N7").Value = "Ngày Kết Thúc";
                exSheet.get_Range("O7").Value = "Trạng Thái Thuê Phòng";
                exSheet.get_Range("B7:O7").ColumnWidth = 13;
                exSheet.get_Range("J7:K7").ColumnWidth = 15;
                exSheet.get_Range("E7").ColumnWidth = 20;
                exSheet.get_Range("O7").ColumnWidth = 23;

                // In dữ liệu
                int i;
                for (i = 0; i < dgv_TimKiem.Rows.Count - 1; i++)
                {
                    for (int j = 0; j < dgv_TimKiem.Columns.Count; j++)
                    {
                        if(dgv_TimKiem.Columns[j].Name == "NgaySinh" || dgv_TimKiem.Columns[j].Name == "NgayBatDau" || dgv_TimKiem.Columns[j].Name == "NgayKetThuc")
                            exSheet.Cells[i + 8, j + 2] = string.Format("{0:dd/MM/yyyy}", Convert.ToDateTime(dgv_TimKiem.Rows[i].Cells[j].Value.ToString()));
                        else
                            exSheet.Cells[i + 8, j + 2] = dgv_TimKiem.Rows[i].Cells[j].Value.ToString();
                    }
                    exSheet.get_Range("A" + (8 + i).ToString()).Value = i + 1;
                }
                exSheet.get_Range("A5:O" + i + 10).HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;

                exSheet.Name = "Danh Sách Tìm Kiếm";
                exBook.Activate(); //Kích hoạt file Excel
                                   //Thiết lập các thuộc tính của SaveFileDialog
                dlgSaveFile.Filter = "Excel Document(*.xls)|*.xls |Word Document(*.doc) | *.doc | All files(*.*) | *.* ";
                dlgSaveFile.FilterIndex = 1;
                dlgSaveFile.AddExtension = true;
                dlgSaveFile.DefaultExt = ".xls";
                if (dlgSaveFile.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    exBook.SaveAs(dlgSaveFile.FileName.ToString());//Lưu file Excel
                    MessageBox.Show("In Danh Sách Thành Công .");
                }
                exApp.Quit();//Thoát khỏi ứng dụng
            }
        }
    }
}
