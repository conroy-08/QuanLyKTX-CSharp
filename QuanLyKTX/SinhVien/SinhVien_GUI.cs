using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyKTX.SinhVien
{
    public partial class SinhVien_GUI : Form
    {
        SinhVien_BLL sinhvien = new SinhVien_BLL();
        void ShowTable()
        {
            dgv_SinhVien.DataSource = sinhvien.ShowTable();
        }

        public SinhVien_GUI()
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

            cbo_Khoa.DataSource = sinhvien.selectTableKhoa();
            cbo_Khoa.DisplayMember = "TenKhoa";
            cbo_Khoa.ValueMember = "MaKhoa";
            cbo_Khoa.Text = "";

            cbo_Que.DataSource = sinhvien.selectTableQue();
            cbo_Que.DisplayMember = "TenQue";
            cbo_Que.ValueMember = "MaQue";
            cbo_Que.Text = "";



            dgv_SinhVien.Columns[0].HeaderText = "Mã Sinh Viên";
            dgv_SinhVien.Columns[1].HeaderText = "Tên Sinh Viên";
            dgv_SinhVien.Columns[2].HeaderText = "Ngày Sinh";
            dgv_SinhVien.Columns[3].HeaderText = "Giới tính (Nam)";
            dgv_SinhVien.Columns[4].HeaderText = "Tên Lớp";
            dgv_SinhVien.Columns[5].HeaderText = "Tên Khoa";
            dgv_SinhVien.Columns[6].HeaderText = "Tên Quê";

            dgv_SinhVien.BackgroundColor = Color.Gray;

            dgv_SinhVien.Columns[6].Width = 300;
        }

        private void Phong_GUI_Load(object sender, EventArgs e)
        {
            while (!User.FormLogin.Checked)
            {
                this.Close();
            }

            try
            {
                txt_MaSinhVien.Enabled = false;
                btn_Xoa.Enabled = false;
                btn_Sua.Enabled = false;
                btn_Luu.Hide();
                ShowTable();
                EditTable();
                rdb_Nam.Checked=true;
                cbo_Lop.Enabled = false;
                
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
            cbo_Lop.Enabled = false;

            txt_MaSinhVien.Text = "";
            txt_TenSinhVien.Text = "";          
            cbo_Lop.Text = "";
            cbo_Que.Text = "";
            cbo_Khoa.Text = "";
            dtp_NgaySinh.Value = new DateTime(2001, 10, 14);
            rdb_Nam.Checked = true;

            txt_TenSinhVien.Focus();
        }

        private void btn_Them_Click(object sender, EventArgs e)
        {
            btn_Luu.Show();
            btn_Sua.Hide();
            btn_Xoa.Hide();
            btn_Them.Enabled = false;
            txt_MaSinhVien.Text = sinhvien.checkId();
            txt_TenSinhVien.Focus();
        }

        private void dgv_Phong_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                btn_Luu.Hide();
                btn_Sua.Show();
                btn_Sua.Enabled = true;
                btn_Xoa.Show();
                btn_Xoa.Enabled = true;
                btn_Them.Enabled = false;

                txt_MaSinhVien.Text = dgv_SinhVien.CurrentRow.Cells[0].Value.ToString();
                txt_TenSinhVien.Text = dgv_SinhVien.CurrentRow.Cells[1].Value.ToString();

                if (dgv_SinhVien.CurrentRow.Cells[2].Value.ToString() != "")
                {
                    dtp_NgaySinh.Value = DateTime.Parse(dgv_SinhVien.CurrentRow.Cells[2].Value.ToString());
                }

                if (dgv_SinhVien.CurrentRow.Cells[3].Value.ToString() == "True")
                {
                    rdb_Nam.Checked = true;
                }
                else rdb_Nu.Checked = true;


                // xử lý khi sửa với khoa và lớp
                if(dgv_SinhVien.CurrentRow.Cells[5].Value.ToString() != "")
                {
                    cbo_Khoa.Text = "";
                    cbo_Khoa.SelectedText = dgv_SinhVien.CurrentRow.Cells[5].Value.ToString();

                    string MaKhoa;

                    MaKhoa = sinhvien.getMaKhoa(cbo_Khoa.Text);

                    cbo_Lop.Text = "";
                    cbo_Lop.Enabled = true;
                    cbo_Lop.DataSource = sinhvien.LayDSLop(MaKhoa);
                    cbo_Lop.DisplayMember = "TenLop";
                    cbo_Lop.ValueMember = "MaLop";
                    cbo_Lop.Text = "";
                    cbo_Lop.SelectedText = dgv_SinhVien.CurrentRow.Cells[4].Value.ToString();
                }
               
                cbo_Que.Text = "";
                cbo_Que.SelectedText = dgv_SinhVien.CurrentRow.Cells[6].Value.ToString();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btn_Sua_Click(object sender, EventArgs e)
        {
            try
            {
                if (rdb_Nam.Checked)
                {
                    sinhvien.Update(txt_MaSinhVien.Text, txt_TenSinhVien.Text, dtp_NgaySinh.Text, 1, sinhvien.getMaLop(cbo_Lop.Text), sinhvien.getMaKhoa(cbo_Khoa.Text), sinhvien.getMaQue(cbo_Que.Text));
                    ShowTable();
                    MessageBox.Show("Sửa thành công!", "Thông báo");
                    btn_Reset_Click(null, null);
                }
                else
                {
                    sinhvien.Update(txt_MaSinhVien.Text, txt_TenSinhVien.Text, dtp_NgaySinh.Text, 0, sinhvien.getMaLop(cbo_Lop.Text), sinhvien.getMaKhoa(cbo_Khoa.Text), sinhvien.getMaQue(cbo_Que.Text));
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
                txt_TenSinhVien.Focus();
            }
        }

        private void btn_Xoa_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("Bạn có chắc chắn muốn xóa?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    sinhvien.Delete(txt_MaSinhVien.Text);
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
                txt_MaSinhVien.Focus();
            }
        }

        private void btn_TimKiem_Click(object sender, EventArgs e)
        {
            try
            {
                dgv_SinhVien.DataSource = sinhvien.Search(txt_TimKiem.Text);
                btn_Reset_Click(null, null);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                txt_TenSinhVien.Focus();
            }
        }

        private void btn_AddLop_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            Lop.Lop_GUI lop = new Lop.Lop_GUI();
            lop.ShowDialog();
        }

        private void btn_AddKhoa_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            Khoa.Khoa_GUI khoa = new Khoa.Khoa_GUI();
            khoa.ShowDialog();
        }

        private void btn_AddQue_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            Que.Que_GUI que = new Que.Que_GUI();
            que.ShowDialog();
        }

        private void btn_Refresh_Click(object sender, EventArgs e)
        {
            Phong_GUI_Load(null, null);
            btn_AddLop.Show();
        }

        private void btn_Luu_Click(object sender, EventArgs e)
        {
            try
            {
                if (rdb_Nam.Checked)
                {
                    sinhvien.Insert(txt_MaSinhVien.Text, txt_TenSinhVien.Text, dtp_NgaySinh.Text, 1, cbo_Lop.SelectedValue.ToString(), cbo_Khoa.SelectedValue.ToString(), cbo_Que.SelectedValue.ToString());
                    ShowTable();
                    MessageBox.Show("Thêm mới thành công!", "Thông báo");
                    btn_Reset_Click(null, null);
                }
                else
                {
                    sinhvien.Insert(txt_MaSinhVien.Text, txt_TenSinhVien.Text, dtp_NgaySinh.Text, 0, cbo_Lop.SelectedValue.ToString(), cbo_Khoa.SelectedValue.ToString(), cbo_Que.SelectedValue.ToString());
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
                txt_TenSinhVien.Focus();
            }

        }

        private void cbo_Khoa_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            cbo_Lop.Enabled = true;
            cbo_Lop.DataSource = sinhvien.LayDSLop(cbo_Khoa.SelectedValue.ToString());
            cbo_Lop.DisplayMember = "TenLop";
            cbo_Lop.ValueMember = "MaLop";
        }
    }
}
