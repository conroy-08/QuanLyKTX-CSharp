using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyKTX.Lop
{
    public partial class Lop_GUI : Form
    {
        Lop_BLL lop = new Lop_BLL();

        void ShowTable()
        {
            dgv_Lop.DataSource = lop.ShowTable();
        }
        public Lop_GUI()
        {
            InitializeComponent();
        }

        private void btn_Thoat_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn chắc chắn chứ?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (MessageBox.Show("Bạn có muốn thêm Sinh viên cho lớp ngay?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    SinhVien.SinhVien_GUI sinhvien = new SinhVien.SinhVien_GUI();
                    this.Visible = false;
                    sinhvien.Show();
                }
                else
                {
                    this.Close();
                }
            }

        }

        void EditTable()
        {
            cbo_Khoa.DataSource = lop.selectTableKhoa();
            cbo_Khoa.DisplayMember = "TenKhoa";
            cbo_Khoa.ValueMember = "MaKhoa";
            cbo_Khoa.Text = "";



            dgv_Lop.Columns[0].HeaderText = "Mã Lớp";
            dgv_Lop.Columns[1].HeaderText = "Tên Lớp";
            dgv_Lop.Columns[2].HeaderText = "Tên Khoa";


            dgv_Lop.BackgroundColor = Color.Gray;

            dgv_Lop.Columns[0].Width = 250;
            dgv_Lop.Columns[1].Width = 250;
            dgv_Lop.Columns[2].Width = 330;
            dgv_Lop.AllowUserToAddRows = false;
        }

        private void Lop_GUI_Load(object sender, EventArgs e)
        {
            while (!User.FormLogin.Checked)
            {
                User.FormLogin formLogin = new User.FormLogin();
                formLogin.ShowDialog();
                this.Close();
            }
            try
            {
                txt_MaLop.Enabled = false;
                btn_Xoa.Enabled = false;
                btn_Sua.Enabled = false;
                btn_Luu.Hide();
                ShowTable();
                EditTable();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
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

            txt_MaLop.Text = "";
            txt_TenLop.Text = "";
            cbo_Khoa.Text = "";
        }

        private void btn_Them_Click(object sender, EventArgs e)
        {
            btn_Luu.Show();
            btn_Sua.Hide();
            btn_Xoa.Hide();
            btn_Them.Enabled = false;
            txt_MaLop.Text = lop.checkId();
            txt_TenLop.Focus();
        }

        private void dgv_Lop_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            btn_Luu.Hide();
            btn_Sua.Show();
            btn_Sua.Enabled = true;
            btn_Xoa.Show();
            btn_Xoa.Enabled = true;
            btn_Them.Enabled = false;


            txt_MaLop.Text = dgv_Lop.CurrentRow.Cells[0].Value.ToString();
            txt_TenLop.Text = dgv_Lop.CurrentRow.Cells[1].Value.ToString();

            cbo_Khoa.Text = "";
            cbo_Khoa.SelectedText = dgv_Lop.CurrentRow.Cells[2].Value.ToString();

        }

        private void btn_Sua_Click(object sender, EventArgs e)
        {
            try
            {
                lop.Update(txt_MaLop.Text, txt_TenLop.Text, lop.getMaKhoa(cbo_Khoa.Text));
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
                txt_TenLop.Focus();
            }
        }

        private void btn_Xoa_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("Bạn có chắc chắn muốn xóa?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    lop.Delete(txt_MaLop.Text);
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
                txt_TenLop.Focus();
            }
        }

        private void btn_TimKiem_Click(object sender, EventArgs e)
        {
            try
            {
                dgv_Lop.DataSource = lop.Search(txt_TimKiem.Text);
                btn_Reset_Click(null, null);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                txt_TenLop.Focus();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            Khoa.Khoa_GUI khoa = new Khoa.Khoa_GUI();
            khoa.ShowDialog();
        }



        private void btn_Refresh_Click(object sender, EventArgs e)
        {
            Lop_GUI_Load(null, null);
            btn_AddKhoa.Show();
        }

        private void btn_Luu_Click(object sender, EventArgs e)
        {
            try
            {
                lop.Insert(txt_MaLop.Text, txt_TenLop.Text, cbo_Khoa.SelectedValue.ToString());
                ShowTable();
                MessageBox.Show("Thêm mới thành công!", "Thông báo");
                btn_Reset_Click(null, null);
                cbo_Khoa.Text = "";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông báo");
            }
            finally
            {
                txt_TenLop.Focus();
            }

        }

    }
}
