using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyKTX.Khoa
{
    public partial class Khoa_GUI : Form
    {
        Khoa_BLL khoa = new Khoa_BLL();
        public Khoa_GUI()
        {
            InitializeComponent();
        }
        void EditTable()
        {
            dgv_Khoa.Columns[0].HeaderText = "Mã Khoa";
            dgv_Khoa.Columns[1].HeaderText = "Tên Khoa";

            dgv_Khoa.BackgroundColor = Color.Gray;
            dgv_Khoa.Columns[0].Width = 250;
            dgv_Khoa.Columns[1].Width = 500;
        }
        void ShowTable()
        {
            dgv_Khoa.DataSource = khoa.ShowTable();
        }

        private void Khoa_GUI_Load(object sender, EventArgs e)
        {
            while (!User.FormLogin.Checked)
            {
                this.Close();
            }
            try
            {
                txt_MaKhoa.Enabled = false;
                btn_Xoa.Enabled = false;
                btn_Sua.Enabled = false;
                btn_Luu.Hide();
                txt_TenKhoa.Focus();
                ShowTable();
                EditTable();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông báo");
            }
        }

        private void btn_Them_Click(object sender, EventArgs e)
        {
            btn_Luu.Show();
            btn_Sua.Hide();
            btn_Xoa.Hide();
            btn_Them.Enabled = false;
            txt_MaKhoa.Text = khoa.checkId();
            txt_TenKhoa.Focus();
        }

        private void dgv_Khoa_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            btn_Luu.Hide();
            btn_Sua.Show();
            btn_Sua.Enabled = true;
            btn_Xoa.Show();
            btn_Xoa.Enabled = true;
            btn_Them.Enabled = false;
            txt_MaKhoa.Text = dgv_Khoa.CurrentRow.Cells[0].Value.ToString();
            txt_TenKhoa.Text = dgv_Khoa.CurrentRow.Cells[1].Value.ToString();
        }

        private void btn_Sua_Click(object sender, EventArgs e)
        {
            try
            {
                khoa.Update(txt_MaKhoa.Text, txt_TenKhoa.Text);
                ShowTable();
                MessageBox.Show("Sửa thành công!", "Thông báo");
                btn_Reset_Click(null, null);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông báo");
            }
            finally
            {
                txt_TenKhoa.Focus();
            }
        }

        private void btn_Reset_Click(object sender, EventArgs e)
        {
            btn_Them.Enabled = true;
            btn_Sua.Show();
            btn_Sua.Enabled = false;
            btn_Xoa.Show();
            btn_Xoa.Enabled = false;
            btn_Luu.Hide();
            txt_MaKhoa.Text = "";
            txt_TenKhoa.Text = "";
            txt_TenKhoa.Focus();
        }

        private void btn_Xoa_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("Bạn có chắc chắn muốn xóa?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    khoa.Delete(txt_MaKhoa.Text);
                    ShowTable();
                    MessageBox.Show("Xóa thành công!", "Thông báo");
                    btn_Reset_Click(null, null);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông báo");
            }
            finally
            {
                txt_TenKhoa.Focus();
            }
        }

        private void btn_TimKiem_Click(object sender, EventArgs e)
        {
            try
            {
                dgv_Khoa.DataSource = khoa.Search(txt_TimKiem.Text);
                btn_Reset_Click(null, null);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông báo");
            }
            finally
            {
                txt_TenKhoa.Focus();
            }
        }

        private void btn_Thoat_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn chắc chắn chứ?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (MessageBox.Show("Bạn có muốn thêm Lớp ngay?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    Lop.Lop_GUI lop = new Lop.Lop_GUI();
                    this.Close();
                    lop.Show();
                }
                else
                {
                    this.Close();
                }
            }

        }

        private void btn_Luu_Click(object sender, EventArgs e)
        {
            try
            {
                khoa.Insert(txt_MaKhoa.Text, txt_TenKhoa.Text);
                ShowTable();
                MessageBox.Show("Thêm mới thành công!", "Thông báo");
                btn_Reset_Click(null, null);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông báo");
            }
            finally
            {
                txt_TenKhoa.Focus();
            }
        }

    }
}
