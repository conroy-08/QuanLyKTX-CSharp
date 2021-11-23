using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyKTX.ThietBi
{
    public partial class ThietBi_GUI : Form
    {
        ThietBi_BLL thietbi = new ThietBi_BLL();
        public ThietBi_GUI()
        {
            InitializeComponent();
        }

        void EditTable()
        {
            dgv_ThietBi.Columns[0].HeaderText = "Mã Thiết Bị";
            dgv_ThietBi.Columns[1].HeaderText = "Tên Thiết Bị";
            dgv_ThietBi.Columns[2].HeaderText = "Trạng Thái";

            dgv_ThietBi.BackgroundColor = Color.Gray;
            dgv_ThietBi.Columns[0].Width = 250;
            dgv_ThietBi.Columns[1].Width = 400;
        }

        void ShowTable()
        {
            dgv_ThietBi.DataSource = thietbi.ShowTable();
        }

        private void btn_Thoat_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn chắc chắn chứ?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                
                this.Close();
              
            }
        
        }

        private void btn_Them_Click(object sender, EventArgs e)
        {
            btn_Luu.Show();
            btn_Sua.Hide();
            btn_Xoa.Hide();
            btn_Them.Enabled = false;
            txt_MaThietBi.Text = thietbi.checkId();
            txt_TenThietBi.Focus();
        }

        
        private void ThietBi_GUI_Load(object sender, EventArgs e)
        {
            try
            {
                txt_MaThietBi.Enabled = false;
                btn_Xoa.Enabled = false;
                btn_Sua.Enabled = false;
                btn_Luu.Hide();
                txt_TenThietBi.Focus();
                cbo_TrangThai.SelectedIndex = 1;
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
            txt_MaThietBi.Text = "";
            txt_TenThietBi.Text = "";
            cbo_TrangThai.SelectedIndex = 1;
            txt_TenThietBi.Focus();
        }

        private void btn_Sua_Click(object sender, EventArgs e)
        {
            try
            {        
                thietbi.Update(txt_MaThietBi.Text, txt_TenThietBi.Text,cbo_TrangThai.SelectedIndex);
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
                txt_TenThietBi.Focus();
            }
        }

        private void btn_Xoa_Click(object sender, EventArgs e)
        {
            try
            {              
               if (MessageBox.Show("Bạn có chắc chắn muốn xóa?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                   {
                        thietbi.Delete(txt_MaThietBi.Text);
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
                txt_TenThietBi.Focus();
            }
        }

        private void btn_TimKiem_Click(object sender, EventArgs e)
        {
            try
            {
                dgv_ThietBi.DataSource = thietbi.Search(txt_TimKiem.Text);
                btn_Reset_Click(null, null);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                txt_MaThietBi.Focus();
            }
        }

        private void dgv_ThietBi_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            btn_Luu.Hide();
            btn_Sua.Show();
            btn_Sua.Enabled = true;
            btn_Xoa.Show();
            btn_Xoa.Enabled = true;
            btn_Them.Enabled = false;
            txt_MaThietBi.Text = dgv_ThietBi.CurrentRow.Cells[0].Value.ToString();
            txt_TenThietBi.Text = dgv_ThietBi.CurrentRow.Cells[1].Value.ToString();
            if(dgv_ThietBi.CurrentRow.Cells[2].Value.ToString() != "")
            {
                for(int i = 0; i < cbo_TrangThai.Items.Count; i++)
                {
                    if(int.Parse(dgv_ThietBi.CurrentRow.Cells[2].Value.ToString()) == i){
                        cbo_TrangThai.SelectedIndex = i;
                    }
                }
            }
        }

        private void btn_Luu_Click(object sender, EventArgs e)
        {
            try
            {    
                    thietbi.Insert(txt_MaThietBi.Text, txt_TenThietBi.Text,cbo_TrangThai.SelectedIndex);
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
                txt_MaThietBi.Focus();
            }

        }
    }
}
