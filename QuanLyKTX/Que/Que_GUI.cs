using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyKTX.Que
{
    public partial class Que_GUI : Form
    {
        Que_BLL que = new Que_BLL();
        public Que_GUI()
        {
            InitializeComponent();
        }


        void EditTable()
        {
            dgv_Que.Columns[0].HeaderText = "Mã Quê";
            dgv_Que.Columns[1].HeaderText = "Tên Quê";

            dgv_Que.BackgroundColor = Color.Gray;
            dgv_Que.Columns[0].Width = 250;
            dgv_Que.Columns[1].Width = 500;
            dgv_Que.AllowUserToAddRows = false;
        }
        void ShowTable()
        {
            dgv_Que.DataSource = que.ShowTable();
        }

        private void Que_GUI_Load(object sender, EventArgs e)
        {
            while (!User.FormLogin.Checked)
            {
                User.FormLogin formLogin = new User.FormLogin();
                formLogin.ShowDialog();
                this.Close();
            }
            try
            {
                txt_MaQue.Enabled = false;
                btn_Xoa.Enabled = false;
                btn_Sua.Enabled = false;
                btn_Luu.Hide();
                txt_TenQue.Focus();
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
            txt_MaQue.Text = que.checkId();
            txt_TenQue.Focus();
        }

        private void dgv_KhuNha_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            btn_Luu.Hide();
            btn_Sua.Show();
            btn_Sua.Enabled = true;
            btn_Xoa.Show();
            btn_Xoa.Enabled = true;
            btn_Them.Enabled = false;
            txt_MaQue.Text = dgv_Que.CurrentRow.Cells[0].Value.ToString();
            txt_TenQue.Text = dgv_Que.CurrentRow.Cells[1].Value.ToString();
        }

        private void btn_Sua_Click(object sender, EventArgs e)
        {
            try
            {
                que.Update(txt_MaQue.Text, txt_TenQue.Text);
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
                txt_TenQue.Focus();
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
            txt_MaQue.Text = "";
            txt_TenQue.Text = "";
            txt_TenQue.Focus();
        }

        private void btn_Xoa_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("Bạn có chắc chắn muốn xóa?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    que.Delete(txt_MaQue.Text);
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
                txt_TenQue.Focus();
            }
        }

        private void btn_TimKiem_Click(object sender, EventArgs e)
        {
            try
            {
                dgv_Que.DataSource = que.Search(txt_TimKiem.Text);
                btn_Reset_Click(null, null);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông báo");
            }
            finally
            {
                txt_TenQue.Focus();
            }
        }

        private void btn_Thoat_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn chắc chắn chứ?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                //if (MessageBox.Show("Bạn có muốn thêm phòng ngay?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                //{
                //    Phong.Phong_GUI phong = new Phong.Phong_GUI();
                //    this.Close();
                //    phong.ShowDialog();
                //}
                //else
                //{
                    this.Close();
                //}
            }

        }

        private void btn_Luu_Click(object sender, EventArgs e)
        {
            try
            {
                que.Insert(txt_MaQue.Text, txt_TenQue.Text);
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
                txt_TenQue.Focus();
            }
        }

    }
}
