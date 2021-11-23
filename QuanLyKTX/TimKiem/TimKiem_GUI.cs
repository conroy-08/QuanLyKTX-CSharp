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
    public partial class TimKiem_GUI : Form
    {
        public TimKiem_GUI()
        {
            InitializeComponent();
        }

        TimKiem_BLL timKiem_BLL = new TimKiem_BLL();

        private void btn_TimKiemMSV_Click(object sender, EventArgs e)
        {
            DataTable dataSearch = new DataTable();
            if (txtTimKiemSV.Text.Trim() == "")
            {
                MessageBox.Show("Bạn chưa nhập thông tin !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
            else
            {
                dataSearch = timKiem_BLL.BLL_Search(txtTimKiemSV.Text);
                if (dataSearch.Rows.Count > 0)
                {
                    dtGrid_SinhVien.DataSource = dataSearch;
                }
                else
                {
                    MessageBox.Show("Bạn tìm :  " + txtTimKiemSV.Text + " không có trong dữ liệu !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    txtTimKiemSV.Text = "";
                }
            }
        }

        private void OpenDataGridView()
        {
            dtGrid_SinhVien.DataSource = timKiem_BLL.BLL_ShowSV();
            dtGrid_SinhVien.Columns[0].HeaderText = "MSV"; dtGrid_SinhVien.Columns[0].Width = 60;
            dtGrid_SinhVien.Columns[1].HeaderText = "Tên Sinh Viên "; dtGrid_SinhVien.Columns[1].Width = 150;
            dtGrid_SinhVien.Columns[2].HeaderText = "Ngày Sinh "; dtGrid_SinhVien.Columns[2].Width = 100;
            dtGrid_SinhVien.Columns[3].HeaderText = "Giới Tính"; dtGrid_SinhVien.Columns[3].Width = 70;
            dtGrid_SinhVien.Columns[4].HeaderText = "Tên Lớp "; dtGrid_SinhVien.Columns[4].Width = 150;
            dtGrid_SinhVien.Columns[5].HeaderText = "Tên Khoa "; dtGrid_SinhVien.Columns[5].Width = 150;
            dtGrid_SinhVien.Columns[6].HeaderText = "Tên Quê "; dtGrid_SinhVien.Columns[6].Width = 90;
            dtGrid_SinhVien.Columns[7].HeaderText = "Tên Phòng "; dtGrid_SinhVien.Columns[7].Width = 100;
            dtGrid_SinhVien.Columns[8].HeaderText = "Tên Khu Nhà"; dtGrid_SinhVien.Columns[8].Width = 110;
            
        }

        private void TimKiem_GUI_Load(object sender, EventArgs e)
        {
            OpenDataGridView();

        }

        private void dtGrid_SinhVien_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtMSV.Text = dtGrid_SinhVien.CurrentRow.Cells[0].Value.ToString();
            txtHVT.Text = dtGrid_SinhVien.CurrentRow.Cells[1].Value.ToString();
            if (dtGrid_SinhVien.CurrentRow.Cells[2].Value.ToString() != "")
            {
                dtp_NgaySinh.Value = DateTime.Parse(dtGrid_SinhVien.CurrentRow.Cells[2].Value.ToString());
            }
            if (dtGrid_SinhVien.CurrentRow.Cells[3].Value.ToString() == "True")
            {
                rdb_Nam.Checked = true;
            }
            else
            {
                rdb_Nu.Checked = true;
            }
            txtLop.Text = dtGrid_SinhVien.CurrentRow.Cells[4].Value.ToString();
            txtKhoa.Text = dtGrid_SinhVien.CurrentRow.Cells[5].Value.ToString();
            txtQue.Text = dtGrid_SinhVien.CurrentRow.Cells[6].Value.ToString();
            txtTenPhong.Text =  dtGrid_SinhVien.CurrentRow.Cells[7].Value.ToString();
            txtTenKhuNha.Text = dtGrid_SinhVien.CurrentRow.Cells[8].Value.ToString();
        }

        private void btn_Thoat_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn chắc chắn muốn thoát chứ?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void btnHienThi_Click(object sender, EventArgs e)
        {
            OpenDataGridView();
            txtMSV.Text = txtHVT.Text = txtLop.Text = txtKhoa.Text = txtQue.Text = txtTenPhong.Text = txtTenKhuNha.Text = "";
            rdb_Nam.Checked = rdb_Nu.Checked = false;
          
        }
    }
}
