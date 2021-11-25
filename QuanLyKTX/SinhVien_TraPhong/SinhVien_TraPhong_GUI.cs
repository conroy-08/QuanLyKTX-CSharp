using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyKTX.SinhVien_TraPhong
{
    public partial class SinhVien_TraPhong_GUI : Form
    {
        SinhVien_TraPhong_BLL TraPhong = new SinhVien_TraPhong_BLL();
        public SinhVien_TraPhong_GUI()
        {
            InitializeComponent();
        }
        
        void ResetHopDongThue()
        {
            txt_MaSoThue.Text = "";
            txt_MaSV.Text = "";
            txt_TenSV.Text = "";
            txt_Khoa.Text = "";
            txt_Lop.Text = "";
            txt_MaPhong.Text = "";
            txt_TenPhong.Text = "";
            txt_KhuNha.Text = "";
            txt_GiaPhong.Text = "";
            txt_NgayBatDau.Text = "";
            txt_NgayKetThuc.Text = "";
            txt_GhiChu.Text = "";
            txt_TrangThai.Text = "";
        }
        void EditTable()
        {
            getMaSoThue();
            dgv_TraPhong.Columns[0].HeaderText = "Mã Số Thuê";
            dgv_TraPhong.Columns[1].HeaderText = "Ngày Trả";
            dgv_TraPhong.Columns[2].HeaderText = "Tiền Vi Phạm";

            dgv_TraPhong.BackgroundColor = Color.Gray;
            dgv_TraPhong.Columns[0].Width = 250;
            dgv_TraPhong.Columns[1].Width = 250;
            dgv_TraPhong.Columns[2].Width = 250;
            dgv_TraPhong.AllowUserToAddRows = false;
            getMaSoThue1();

        }
        void ShowTable()
        {
            dgv_TraPhong.DataSource = TraPhong.ShowTable();
        }

        void getMaSoThue1()
        {
            // set value mã SV cho combobox
            cbo_TimKiem.DataSource = TraPhong.LayMaSoThue1();
            cbo_TimKiem.DisplayMember = "MaSoThue";
            cbo_TimKiem.ValueMember = "MaSoThue";
            cbo_TimKiem.Text = "";
        }

        void getMaSoThue()
        {
            // set value mã SV cho combobox
            cbo_MaSoThue.DataSource = TraPhong.LayMaSoThue();
            cbo_MaSoThue.DisplayMember = "MaSoThue";
            cbo_MaSoThue.ValueMember = "MaSoThue";
            cbo_MaSoThue.Text = "";
        }


        private void btn_Them_Click(object sender, EventArgs e)
        {
            DataTable checkMa = TraPhong.LayMaSoThue2(cbo_MaSoThue.Text);
            if (cbo_MaSoThue.Text != "" && checkMa.Rows.Count > 0)
            {
                btn_Luu.Show();
                btn_Sua.Hide();
                btn_Xoa.Hide();
                btn_Them.Enabled = false;
                cbo_MaSoThue.Focus();
            }
            else
            {
                MessageBox.Show("Hãy chọn mã số thuê hợp lệ !!!");
            }
        }

        private void dgv_KhuNha_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgv_TraPhong.CurrentRow.Cells[0].Value.ToString() != "")
                try
                {
                    cbo_MaSoThue.Enabled = false;
                    btn_Luu.Hide();
                    btn_Sua.Show();
                    btn_Sua.Enabled = true;
                    btn_Xoa.Show();
                    btn_Xoa.Enabled = true;
                    btn_Them.Enabled = false;
                    cbo_MaSoThue.Text = "";
                    cbo_MaSoThue.SelectedText = dgv_TraPhong.CurrentRow.Cells[0].Value.ToString();
                    HopDongChange(dgv_TraPhong.CurrentRow.Cells[0].Value.ToString());
                    txt_TienViPham.Text = double.Parse(dgv_TraPhong.CurrentRow.Cells[2].Value.ToString()).ToString();
                    if (dgv_TraPhong.CurrentRow.Cells[1].Value.ToString() != "")
                    {
                        dtp_NgayTra.Value = DateTime.Parse(dgv_TraPhong.CurrentRow.Cells[1].Value.ToString());
                    }
                }


                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
        
        }

        private void btn_Sua_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("Bạn chắc chắn với hành động này chứ?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    TraPhong.Update(cbo_MaSoThue.Text, dtp_NgayTra.Text, txt_TienViPham.Text);
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
                cbo_MaSoThue.Focus();
            }
        }

        private void btn_Reset_Click(object sender, EventArgs e)
        {
            getMaSoThue();
            getMaSoThue1();
            btn_Them.Enabled = true;
            btn_Sua.Show();
            btn_Sua.Enabled = false;
            btn_Xoa.Show();
            btn_Xoa.Enabled = false;
            btn_Luu.Hide();
            cbo_MaSoThue.Text = "";
            txt_TienViPham.Text = "";
            dtp_NgayTra.Value = new DateTime(2021, 12, 31, 0, 0, 0);
            cbo_MaSoThue.Focus();
            cbo_MaSoThue.Enabled = true;
            ResetHopDongThue();
        }

        private void btn_Xoa_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("Bạn có chắc chắn muốn xóa?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    TraPhong.Delete(cbo_MaSoThue.Text);
                    ShowTable();
                    MessageBox.Show("Xóa thành công!", "Thông báo");
                    btn_Reset_Click(null, null);
                    getMaSoThue();
                    getMaSoThue1();
             
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông báo");
            }
            finally
            {
                cbo_MaSoThue.Focus();
            }
        }

        private void btn_TimKiem_Click(object sender, EventArgs e)
        {
            try
            {
                dgv_TraPhong.DataSource = TraPhong.Search(cbo_TimKiem.Text);
                //btn_Reset_Click(null, null);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông báo");
            }
            finally
            {
                cbo_MaSoThue.Focus();
            }
        }

        private void btn_Thoat_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn chắc chắn chứ?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                this.Close();
            }

        }

        private void btn_Luu_Click(object sender, EventArgs e)
        {
            try
            {
                TraPhong.Insert(cbo_MaSoThue.Text, dtp_NgayTra.Text, txt_TienViPham.Text);
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
                cbo_MaSoThue.Focus();
            }
        }

        private void TraPhong_GUI_Load(object sender, EventArgs e)
        {
            while (!User.FormLogin.Checked)
            {
                this.Close();
            }

            try
            {
                btn_Xoa.Enabled = false;
                btn_Sua.Enabled = false;
                btn_Luu.Hide();
                cbo_MaSoThue.Focus();
                ShowTable();
                EditTable();
                ResetHopDongThue();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông báo");
            }
        }

    

        private void cbo_MaSoThue_SelectedValueChanged(object sender, EventArgs e)
        {
            HopDongChange(cbo_MaSoThue.Text);
        }

        void HopDongChange(string MST)
        {
            DataTable info = TraPhong.InfoHopDong(MST);

            if (info.Rows.Count > 0)
            {
                txt_MaSoThue.Text = info.Rows[0]["MaSoThue"].ToString();
                txt_MaSV.Text = info.Rows[0]["MaSinhVien"].ToString();
                txt_TenSV.Text = info.Rows[0]["TenSinhVien"].ToString();
                txt_Lop.Text = info.Rows[0]["TenLop"].ToString();
                txt_Khoa.Text = info.Rows[0]["TenKhoa"].ToString();
                txt_MaPhong.Text = info.Rows[0]["MaPhong"].ToString();
                txt_TenPhong.Text = info.Rows[0]["TenPhong"].ToString();
                txt_KhuNha.Text = info.Rows[0]["TenKhu"].ToString();
                txt_GiaPhong.Text = info.Rows[0]["GiaPhong"].ToString();
                txt_NgayBatDau.Text = info.Rows[0]["NgayBatDau"].ToString();
                txt_NgayKetThuc.Text = info.Rows[0]["NgayKetThuc"].ToString();
                txt_GhiChu.Text = info.Rows[0]["GhiChu"].ToString();
                txt_TrangThai.Text = info.Rows[0]["TrangThaiThuePhong"].ToString();
            }
           
        }
    }
}
