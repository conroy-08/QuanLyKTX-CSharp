using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyKTX.KhuNha
{
    public partial class KhuNha_GUI : Form
    {
        KhuNha_BLL khunha = new KhuNha_BLL();
        public KhuNha_GUI()
        {
            InitializeComponent();
        }
        void EditTable()
        {
            dgv_KhuNha.Columns[0].HeaderText = "Mã Khu Nhà";
            dgv_KhuNha.Columns[1].HeaderText = "Tên Khu Nhà";
            dgv_KhuNha.Columns[2].HeaderText = "Trạng Thái";

            dgv_KhuNha.BackgroundColor = Color.Gray;
            dgv_KhuNha.Columns[0].Width = 250;
            dgv_KhuNha.Columns[1].Width = 400;      
        }
        void ShowTable()
        {
            dgv_KhuNha.DataSource = khunha.ShowTable();
        }      

        private void KhuNha_GUI_Load(object sender, EventArgs e)
        {
            try
            {
                txt_MaKhuNha.Enabled = false;
                btn_Xoa.Enabled = false;
                btn_Sua.Enabled = false;               
                btn_Luu.Hide();
                txt_TenKhuNha.Focus();
                cbo_TrangThai.SelectedIndex = 1;
                ShowTable();
                EditTable();
            }
            catch(Exception ex)
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
            txt_MaKhuNha.Text = khunha.checkId();
            txt_TenKhuNha.Focus();
        }

        private void dgv_KhuNha_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            btn_Luu.Hide();
            btn_Sua.Show();
            btn_Sua.Enabled = true;
            btn_Xoa.Show();
            btn_Xoa.Enabled = true;
            btn_Them.Enabled = false;
            txt_MaKhuNha.Text = dgv_KhuNha.CurrentRow.Cells[0].Value.ToString();
            txt_TenKhuNha.Text = dgv_KhuNha.CurrentRow.Cells[1].Value.ToString();
            if(dgv_KhuNha.CurrentRow.Cells[2].Value.ToString() != "")
            {
                for (int i = 0; i < cbo_TrangThai.Items.Count; i++)
                {
                    if (int.Parse(dgv_KhuNha.CurrentRow.Cells[2].Value.ToString()) == i)
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
                  khunha.Update(txt_MaKhuNha.Text, txt_TenKhuNha.Text, cbo_TrangThai.SelectedIndex);
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
                txt_TenKhuNha.Focus();
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
            txt_MaKhuNha.Text = "";
            txt_TenKhuNha.Text = "";
            txt_TenKhuNha.Focus();
            cbo_TrangThai.SelectedIndex = 1;
        }

        private void btn_Xoa_Click(object sender, EventArgs e)
        {
            try
            {                 
               if (MessageBox.Show("Bạn có chắc chắn muốn xóa?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            khunha.Delete(txt_MaKhuNha.Text);
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
                txt_TenKhuNha.Focus();
            }
        }

        private void btn_TimKiem_Click(object sender, EventArgs e)
        {
            try
            {
                dgv_KhuNha.DataSource = khunha.Search(txt_TimKiem.Text);
                btn_Reset_Click(null, null);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông báo");
            }
            finally
            {
                txt_TenKhuNha.Focus();
            }
        }

        private void btn_Thoat_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn chắc chắn chứ?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (MessageBox.Show("Bạn có muốn thêm phòng ngay?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    Phong.Phong_GUI phong = new Phong.Phong_GUI();
                    this.Close();
                    phong.Show();
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
                khunha.Insert(txt_MaKhuNha.Text, txt_TenKhuNha.Text,cbo_TrangThai.SelectedIndex);
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
                txt_TenKhuNha.Focus();
            }
        }
    }
}
