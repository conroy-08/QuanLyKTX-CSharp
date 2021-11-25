using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyKTX.Phong
{
    public partial class Phong_GUI : Form
    {
        Phong_BLL phong = new Phong_BLL();

        void ShowTable()
        {
            dgv_Phong.DataSource = phong.ShowTable();
        }
        public Phong_GUI()
        {
            InitializeComponent();
        }

        private void btn_Thoat_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn chắc chắn chứ?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {               
                this.Close();             
            }
           
        }

        void EditTable()
        {
            cbo_KhuNha.DataSource = phong.selectTableKhuNha();
            cbo_KhuNha.DisplayMember = "TenKhu";
            cbo_KhuNha.ValueMember = "MaKhuNha";
            cbo_KhuNha.Text = "";
           


            dgv_Phong.Columns[0].HeaderText = "Mã Phòng";
            dgv_Phong.Columns[1].HeaderText = "Tên Phòng";
            dgv_Phong.Columns[2].HeaderText = "Tên Khu Nhà";
            dgv_Phong.Columns[3].HeaderText = "Loại Phòng (Nam)";
            dgv_Phong.Columns[4].HeaderText = "Số Người Tối Đa";
            dgv_Phong.Columns[5].HeaderText = "Số Người Đang Ở";
            dgv_Phong.Columns[6].HeaderText = "Ghi Chú";
            dgv_Phong.Columns[7].HeaderText = "Giá Phòng";
            dgv_Phong.Columns[8].HeaderText = "Trạng thái";
            

            dgv_Phong.BackgroundColor = Color.Gray;

            dgv_Phong.Columns[6].Width = 250;
        }

        private void Phong_GUI_Load(object sender, EventArgs e)
        {
            while (!User.FormLogin.Checked)
            {
                this.Close();
            }

            try
            {         
                cbo_timnguoi.SelectedIndex = 0;
                txt_MaPhong.Enabled = false;
                btn_Xoa.Enabled = false;
                btn_Sua.Enabled = false;
                btn_Luu.Hide();
                ShowTable();
                EditTable();
                rdb_Nam.Checked = true;
                cbo_TrangThai.SelectedIndex = 1;
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
          
            txt_MaPhong.Text = "";
            txt_TenPhong.Text = "";
            txt_GiaPhong.Text = "";
            rdb_Nam.Checked = true;
         
            txt_SoNguoi.Text = "";
            cbo_KhuNha.Text = "";
            txt_GhiChu.Text = "";

            cbo_TrangThai.SelectedIndex = 1;

            txt_TenPhong.Focus();
        }

        private void btn_Them_Click(object sender, EventArgs e)
        {
            btn_Luu.Show();
            btn_Sua.Hide();
            btn_Xoa.Hide();
            btn_Them.Enabled = false;
            txt_MaPhong.Text = phong.checkId();
            txt_TenPhong.Focus();
        }

        private void dgv_Phong_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            btn_Luu.Hide();
            btn_Sua.Show();
            btn_Sua.Enabled = true;
            btn_Xoa.Show();
            btn_Xoa.Enabled = true;
            btn_Them.Enabled = false;

            
            txt_MaPhong.Text = dgv_Phong.CurrentRow.Cells[0].Value.ToString();
            txt_TenPhong.Text = dgv_Phong.CurrentRow.Cells[1].Value.ToString();

            cbo_KhuNha.Text = "";
            cbo_KhuNha.SelectedText = dgv_Phong.CurrentRow.Cells[2].Value.ToString();

            if (dgv_Phong.CurrentRow.Cells[3].Value.ToString() == "True")
            {
                rdb_Nam.Checked = true;
            }
            else rdb_Nu.Checked = true;
           
            txt_SoNguoi.Text = dgv_Phong.CurrentRow.Cells[4].Value.ToString();
            txt_GhiChu.Text = dgv_Phong.CurrentRow.Cells[6].Value.ToString();
            txt_GiaPhong.Text = dgv_Phong.CurrentRow.Cells[7].Value.ToString();

            if(dgv_Phong.CurrentRow.Cells[8].Value.ToString() != "")
            {
                for(int i = 0; i < cbo_TrangThai.Items.Count; i++)
                {
                    if (i == int.Parse(dgv_Phong.CurrentRow.Cells[8].Value.ToString()))
                    {
                        cbo_TrangThai.SelectedIndex = i;
                    }
                }
            }
        }

        private void btn_Sua_Click(object sender, EventArgs e)
        {
            try
            {
                if (rdb_Nam.Checked)
                {
                    phong.Update(txt_MaPhong.Text, txt_TenPhong.Text, phong.getMaKhu(cbo_KhuNha.Text), 1, txt_SoNguoi.Text, txt_GhiChu.Text, txt_GiaPhong.Text,cbo_TrangThai.SelectedIndex);
                    ShowTable();
                    MessageBox.Show("Sửa thành công!", "Thông báo");
                    btn_Reset_Click(null, null);
                }
                else
                {
                    phong.Update(txt_MaPhong.Text, txt_TenPhong.Text, phong.getMaKhu(cbo_KhuNha.Text), 0, txt_SoNguoi.Text, txt_GhiChu.Text, txt_GiaPhong.Text,cbo_TrangThai.SelectedIndex);
                    ShowTable();
                    MessageBox.Show("Sửa thành công!", "Thông báo");
                    btn_Reset_Click(null, null);
                }
                               
            }
            catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Thông báo");
                }
            finally
            {
                txt_TenPhong.Focus();
            }
        }

        private void btn_Xoa_Click(object sender, EventArgs e)
        {
            try
            {            
                        if (MessageBox.Show("Bạn có chắc chắn muốn xóa?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            phong.Delete(txt_MaPhong.Text);
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
                txt_TenPhong.Focus();
            }
        }

        private void btn_TimKiem_Click(object sender, EventArgs e)
        {         
            try
            {           
                dgv_Phong.DataSource = phong.Search(txt_TimKiem.Text,int.Parse(cbo_timnguoi.SelectedIndex.ToString()));
                btn_Reset_Click(null, null);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                txt_TenPhong.Focus();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            KhuNha.KhuNha_GUI khunha = new KhuNha.KhuNha_GUI();
            khunha.ShowDialog();           
        }


        private void btn_Refresh_Click(object sender, EventArgs e)
        {
            Phong_GUI_Load(null, null);
            btn_AddKhu.Show();
        }

        private void btn_Luu_Click(object sender, EventArgs e)
        {
            try
            {
                if (rdb_Nam.Checked)
                {
                    phong.Insert(txt_MaPhong.Text, txt_TenPhong.Text, cbo_KhuNha.SelectedValue.ToString(), 1, txt_SoNguoi.Text, txt_GhiChu.Text, txt_GiaPhong.Text,cbo_TrangThai.SelectedIndex);
                    ShowTable();
                    MessageBox.Show("Thêm mới thành công!", "Thông báo");
                    btn_Reset_Click(null, null);
                }
                else
                {
                    phong.Insert(txt_MaPhong.Text, txt_TenPhong.Text, cbo_KhuNha.SelectedValue.ToString(), 0, txt_SoNguoi.Text, txt_GhiChu.Text, txt_GiaPhong.Text,cbo_TrangThai.SelectedIndex);
                    ShowTable();
                    MessageBox.Show("Thêm mới thành công!", "Thông báo");
                    btn_Reset_Click(null, null);
                }             
            }                               
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông báo");
            }
            finally
            {
                txt_TenPhong.Focus();
            }

        }
    }
}
