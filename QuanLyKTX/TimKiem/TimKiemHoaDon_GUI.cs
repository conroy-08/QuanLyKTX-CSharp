using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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
                }
                else
                {
                    cmbMaHD.Enabled = false;

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
    }
}
