using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyKTX.ThietBi_Phong
{
    public partial class ThietBi_Phong_GUI : Form
    {
        ThietBi_Phong_BLL tbi_phong = new ThietBi_Phong_BLL();
        public ThietBi_Phong_GUI()
        {
            InitializeComponent();
        }

        void ShowTable()
        {
            dgv_TbiPhong.DataSource = tbi_phong.ShowTable();
        }

        void EditTable()
        {
            // set value mã phòng cho combobox
            cbo_MaPhong.DataSource = tbi_phong.LayMaPhong();
            cbo_MaPhong.DisplayMember = "MaPhong";
            cbo_MaPhong.ValueMember = "MaPhong";
            cbo_MaPhong.Text = "";

            // set value mã thiết bị cho combobox
            cbo_MaTB.DataSource = tbi_phong.LayMaThietBi();
            cbo_MaTB.DisplayMember = "MaThietBi";
            cbo_MaTB.ValueMember = "MaThietBi";
            cbo_MaTB.Text = "";

            //set value mã phòng cho cbo tìm kiếm
            cbo_maphong_search.DataSource = tbi_phong.LayMaPhong();
            cbo_maphong_search.DisplayMember = "MaPhong";
            cbo_maphong_search.ValueMember = "MaPhong";
            cbo_maphong_search.Text = "";

            //set value mã thiết bị cho cbo tìm kiếm
            cbo_matb_search.DataSource = tbi_phong.LayMaThietBi();
            cbo_matb_search.DisplayMember = "MaThietBi";
            cbo_matb_search.ValueMember = "MaThietBi";
            cbo_matb_search.Text = "";


            dgv_TbiPhong.Columns[0].HeaderText = "Mã Thiết Bị";
            dgv_TbiPhong.Columns[1].HeaderText = "Mã Phòng";
            dgv_TbiPhong.Columns[2].HeaderText = "Số lượng";
            dgv_TbiPhong.Columns[3].HeaderText = "Tình Trạng";
           

            dgv_TbiPhong.BackgroundColor = Color.Gray;

            dgv_TbiPhong.Columns[0].Width = 150;
            dgv_TbiPhong.Columns[1].Width = 150;
            dgv_TbiPhong.Columns[2].Width = 130;
            dgv_TbiPhong.Columns[3].Width = 130;
        }

        // Trả textbox về rỗng
        void Reset()
        {
            txt_TenPhong.Text = "";
            txt_KhuNha.Text = "";
            txt_LoaiPhong.Text = "";
            txt_GiaPhong.Text = "";
            txt_SoLuongMax.Text = "";
            txt_SoLuongNow.Text = "";
            txt_TrangThai.Text = "";
            txt_TenTb.Text = "";
        }

        private void ThietBi_Phong_GUI_Load(object sender, EventArgs e)
        {
            try
            {
                cbo_TinhTrang.SelectedIndex = 2;
                cbo_matb_search.SelectedIndex = 0;
                btn_Xoa.Enabled = false;
                btn_Sua.Enabled = false;
                btn_Show.Enabled = false;
                btn_Luu.Hide();
                ShowTable();
                EditTable();
                Reset();
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message,"Thông báo");
            }
        }

        // Mỗi khi combobox thay đổi
        void MaPhongChange()
        {
            DataTable infoPhong = tbi_phong.LayThongTinPhong(cbo_MaPhong.Text);
            if(infoPhong.Rows.Count>0)
            {
                txt_TenPhong.Text = infoPhong.Rows[0]["TenPhong"].ToString();
                txt_KhuNha.Text = infoPhong.Rows[0]["TenKhu"].ToString();
                if (infoPhong.Rows[0]["LoaiPhong"].ToString() == "True")
                {
                    txt_LoaiPhong.Text = "Nam";
                }
                else
                {
                    txt_LoaiPhong.Text = "Nữ";
                }
                txt_SoLuongMax.Text = infoPhong.Rows[0]["SoNguoiToiDa"].ToString();
                txt_SoLuongNow.Text = infoPhong.Rows[0]["SoNguoiDangO"].ToString();
                txt_GiaPhong.Text = infoPhong.Rows[0]["GiaPhong"].ToString();
            }
           
        }

        private void cbo_MaPhong_SelectedIndexChanged(object sender, EventArgs e)
        {
            MaPhongChange();
        }

        // Khi MaTb thay đổi
        void MaTBChange()
        {
         
            DataTable infoTB = tbi_phong.LayThongTinThietBi(cbo_MaTB.Text);
            if (infoTB.Rows.Count > 0)
            {
                txt_TenTb.Text = infoTB.Rows[0]["TenThietBi"].ToString();
                if (int.Parse(infoTB.Rows[0]["TrangThai"].ToString()) == 1)
                {
                    txt_TrangThai.Text = "Hoạt động";
                }
                else
                {
                    txt_TrangThai.Text = "Không hoạt động";
                }
            }
        }
        private void cbo_MaTB_SelectedIndexChanged(object sender, EventArgs e)
        {
            MaTBChange();
        }

        private void btn_Them_Click(object sender, EventArgs e)
        {
            btn_Luu.Show();
            btn_Sua.Hide();
            btn_Xoa.Hide();
            btn_Them.Enabled = false;
            txt_SoLuong.Focus();
        }

        private void btn_Reset_Click(object sender, EventArgs e)
        {
            cbo_MaTB.Enabled = true;
            cbo_MaPhong.Enabled = true;
            btn_Them.Enabled = true;
            btn_Sua.Show();
            btn_Sua.Enabled = false;
            btn_Xoa.Show();
            btn_Xoa.Enabled = false;
            btn_Luu.Hide();
            Reset();
            txt_SoLuong.Text = "";
            cbo_MaPhong.Text = "";
            cbo_MaTB.Text = "";
            cbo_TinhTrang.SelectedIndex = 2;
            txt_SoLuong.Focus();
        }

        private void btn_Luu_Click(object sender, EventArgs e)
        {
            try
            {                      
                    tbi_phong.Insert(cbo_MaPhong.Text,cbo_MaTB.Text,txt_SoLuong.Text,cbo_TinhTrang.SelectedIndex);
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
                txt_SoLuong.Focus();
            }
        }

        private void dgv_TbiPhong_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                cbo_MaTB.Enabled = false;
                cbo_MaPhong.Enabled = false;
                btn_Luu.Hide();
                btn_Sua.Show();
                btn_Sua.Enabled = true;
                btn_Xoa.Show();
                btn_Xoa.Enabled = true;
                btn_Them.Enabled = false;
                txt_SoLuong.Text = dgv_TbiPhong.CurrentRow.Cells[2].Value.ToString();

                // Xử lý khi người dùng cellclick vào datagridview rỗng

                if(dgv_TbiPhong.CurrentRow.Cells[1].Value.ToString() != "" && dgv_TbiPhong.CurrentRow.Cells[0].Value.ToString() != "")
                {
                    cbo_MaPhong.Text = "";
                    cbo_MaPhong.SelectedText = dgv_TbiPhong.CurrentRow.Cells[1].Value.ToString();
                    MaPhongChange();
                    cbo_MaTB.Text = "";
                    cbo_MaTB.SelectedText = dgv_TbiPhong.CurrentRow.Cells[0].Value.ToString();
                    MaTBChange();
                }
                
              
                if(dgv_TbiPhong.CurrentRow.Cells[3].Value.ToString() != "")
                {
                    for (int i = 0; i < cbo_TinhTrang.Items.Count; i++)
                    {
                        if (int.Parse(dgv_TbiPhong.CurrentRow.Cells[3].Value.ToString()) == i)
                        {
                            cbo_TinhTrang.SelectedIndex = i;
                        }
                    }
                }            
            }
             catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btn_Xoa_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("Bạn có chắc chắn muốn xóa?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    tbi_phong.Delete(cbo_MaPhong.Text, cbo_MaTB.Text);
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
                txt_SoLuong.Focus();
            }
        }

        private void btn_Sua_Click(object sender, EventArgs e)
        {
            try
            {             
                    tbi_phong.Update(cbo_MaPhong.Text, cbo_MaTB.Text, txt_SoLuong.Text, cbo_TinhTrang.SelectedIndex);
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
                txt_SoLuong.Focus();
            }
        }

        private void btn_Thoat_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn chắc chắn chứ?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void btn_TimKiem_Click(object sender, EventArgs e)
        {
            btn_Show.Enabled = true;
            dgv_TbiPhong.DataSource = tbi_phong.Search(cbo_maphong_search.Text, cbo_matb_search.Text);
        }

        private void btn_Show_Click(object sender, EventArgs e)
        {
            ShowTable();
            cbo_matb_search.Text = "";
            cbo_maphong_search.Text = "";
            btn_Show.Enabled = false;
        }

        private void btn_AddPhong_Click(object sender, EventArgs e)
        {
            Phong.Phong_GUI phong = new Phong.Phong_GUI();
            this.Visible = false;
            phong.Show();
        }

        private void btn_AddTB_Click(object sender, EventArgs e)
        {
            ThietBi.ThietBi_GUI thietbi = new ThietBi.ThietBi_GUI();
            this.Visible = false;
            thietbi.Show();
        }
    }
}
