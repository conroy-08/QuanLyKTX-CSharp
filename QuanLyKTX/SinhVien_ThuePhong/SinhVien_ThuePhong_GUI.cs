using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyKTX.SinhVien_DatPhong
{
    public partial class SinhVien_ThuePhong_GUI : Form
    {
        SinhVien_ThuePhong_BLL SV_Phong = new SinhVien_ThuePhong_BLL();
        public SinhVien_ThuePhong_GUI()
        {
            InitializeComponent();
        }
        void ShowTable()
        {
            dgv_SVThuePhong.DataSource = SV_Phong.ShowTable();
        }

        void getMaSV()
        {
            // set value mã SV cho combobox
            cbo_MaSV.DataSource = SV_Phong.LayMaSV();
            cbo_MaSV.DisplayMember = "MaSinhVien";
            cbo_MaSV.ValueMember = "MaSinhVien";
            cbo_MaSV.Text = "";
        }

        void getMaPhong_Search()
        {
            //set value mã phòng cho cbo tìm kiếm
            cbo_MaSoThue_search.DataSource = SV_Phong.LayMaSoThue();
            cbo_MaSoThue_search.DisplayMember = "MaSoThue";
            cbo_MaSoThue_search.ValueMember = "MaSoThue";
            cbo_MaSoThue_search.Text = "";
        }

        void getMaPhong()
        {
            // set value mã phòng cho combobox
            cbo_MaPhong.DataSource = SV_Phong.LayMaPhong();
            cbo_MaPhong.ValueMember = "MaPhong";
            cbo_MaPhong.Text = "";
        }

        void EditTable()
        {
           

            getMaSV();
            getMaPhong();
            getMaPhong_Search();

            dgv_SVThuePhong.Columns[0].HeaderText = "Mã Số Thuê";
            dgv_SVThuePhong.Columns[1].HeaderText = "Mã Sinh Viên";
            dgv_SVThuePhong.Columns[2].HeaderText = "Mã Phòng";
            dgv_SVThuePhong.Columns[3].HeaderText = "Ngày Bắt Đầu";
            dgv_SVThuePhong.Columns[4].HeaderText = "Ngày Kết Thúc";
            dgv_SVThuePhong.Columns[5].HeaderText = "Ghi Chú";
            dgv_SVThuePhong.Columns[6].HeaderText = "Tình Trạng Thuê Phòng";

            dgv_SVThuePhong.BackgroundColor = Color.Gray;

            dgv_SVThuePhong.Columns[0].Width = 150;
            dgv_SVThuePhong.Columns[1].Width = 150;
            dgv_SVThuePhong.Columns[2].Width = 130;
            dgv_SVThuePhong.Columns[3].Width = 130;
            dgv_SVThuePhong.Columns[4].Width = 150;
            dgv_SVThuePhong.Columns[5].Width = 150;
            dgv_SVThuePhong.Columns[6].Width = 200;
            dgv_SVThuePhong.AllowUserToAddRows = false;
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
            txt_GiaPhong.Text = "";
            txt_TenSV.Text = "";
            txt_NgaySinh.Text = "";
            txt_GioiTinh.Text = "";
            txt_Khoa.Text = "";
            txt_Lop.Text = "";
            txt_Que.Text = "";
            txt_MaSV.Text = "";
            txt_MaPhong.Text = "";
            txt_MaSoThue.Text = "";
            cbo_TTThuePhong.SelectedIndex = 0;
            cbo_TTThuePhong.Enabled = false;
            DateTime startDay = DateTime.Today;
            dtp_NgayBD.Value = startDay;
            dtp_NgayKT.Value = startDay.AddDays(31);
            dtp_NgayBD.Enabled = true;
            dtp_NgayKT.Enabled = true;
            txt_GhiChu.Enabled = true;
            cbo_TTThuePhong.Enabled = false;
        }

        private void SV_Phong_GUI_Load(object sender, EventArgs e)
        {
            while (!User.FormLogin.Checked)
            {
                User.FormLogin formLogin = new User.FormLogin();
                formLogin.ShowDialog();
                this.Close();
            }
            try
            {
                cbo_TTThuePhong.Text = "";
                //cbo_masv_search.SelectedIndex = 0;
                btn_Xoa.Enabled = false;
                btn_Sua.Enabled = false;
                btn_Show.Enabled = false;
                btn_Luu.Hide();
                ShowTable();
                EditTable();
                Reset();
                cbo_TTThuePhong.SelectedIndex = 0;
                DateTime startDay = DateTime.Today;
                dtp_NgayBD.Value = startDay;
          
                dtp_NgayKT.Value = startDay.AddDays(31);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông báo");
            }
        }

        // Mỗi khi combobox thay đổi
        void MaPhongChange()
        {
            DataTable infoPhong = SV_Phong.LayThongTinPhong(cbo_MaPhong.Text);
            if (infoPhong.Rows.Count > 0)
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
                txt_MaPhong.Text = cbo_MaPhong.Text;
            }

        }

        private void cbo_MaPhong_SelectedIndexChanged(object sender, EventArgs e)
        {
            MaPhongChange();
        }

        // Khi MaTb thay đổi
        void MaSVChange()
        {
            DataTable infoSV = SV_Phong.LayThongTinSV(cbo_MaSV.Text);
            if (infoSV.Rows.Count > 0)
            {
                txt_TenSV.Text = infoSV.Rows[0]["TenSinhVien"].ToString();
                txt_NgaySinh.Text = infoSV.Rows[0]["NgaySinh"].ToString();
                txt_GioiTinh.Text = infoSV.Rows[0]["GioiTinh"].ToString();
                txt_Khoa.Text = infoSV.Rows[0]["TenLop"].ToString();
                txt_Lop.Text = infoSV.Rows[0]["TenKhoa"].ToString();
                txt_Que.Text = infoSV.Rows[0]["TenQue"].ToString();
            }
            txt_MaSV.Text = cbo_MaSV.Text;
        }
        private void cbo_MaSV_SelectedIndexChanged(object sender, EventArgs e)
        {
            MaSVChange();
        }
        private void btn_Them_Click(object sender, EventArgs e)
        {
            btn_Luu.Show();
            btn_Sua.Hide();
            btn_Xoa.Hide();
            btn_Them.Enabled = false;
            txt_MaSoThue.Text = SV_Phong.checkId();
            txt_GhiChu.Focus();
        }

        private void btn_Reset_Click(object sender, EventArgs e)
        {
            cbo_MaSV.Enabled = true;
            cbo_MaPhong.Enabled = true;
            btn_Them.Enabled = true;
            btn_Sua.Show();
            btn_Sua.Enabled = false;
            btn_Xoa.Show();
            btn_Xoa.Enabled = false;
            btn_Luu.Hide();
            Reset();
            txt_GhiChu.Text = "";
            cbo_MaPhong.Text = "";
            cbo_MaSV.Text = "";
            cbo_TTThuePhong.SelectedIndex = 0;
            txt_GhiChu.Focus();
          
        }

        private void btn_Luu_Click(object sender, EventArgs e)
        {
            try
            {
                if(txt_GioiTinh.Text == txt_LoaiPhong.Text)
                {
                    SV_Phong.Insert(txt_MaSoThue.Text, txt_MaSV.Text, txt_MaPhong.Text, dtp_NgayBD.Text, dtp_NgayKT.Text, txt_GhiChu.Text, cbo_TTThuePhong.SelectedIndex);
                    ShowTable();
                    MessageBox.Show("Thêm mới thành công!", "Thông báo");
                    btn_Reset_Click(null, null);
                    getMaPhong();
                    getMaPhong_Search();
                    getMaSV();
                    Reset();
                }
                else
                {
                    throw new Exception("Giới tính sinh viên không phù hợp với phòng này");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông báo");
            }
            finally
            {
                txt_GhiChu.Focus();
            }
        }

        private void dgv_TbiPhong_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (dgv_SVThuePhong.CurrentRow.Cells[6].Value.ToString() != "")
                {
                    for (int i = 0; i < cbo_TTThuePhong.Items.Count; i++)
                    {
                        if (cbo_TTThuePhong.Items[i].ToString() == dgv_SVThuePhong.CurrentRow.Cells[6].Value.ToString())
                        {
                            cbo_TTThuePhong.SelectedIndex = i;
                        }
                    }
                }

              
                    cbo_MaPhong.Enabled = true;
                    dtp_NgayBD.Enabled = true;
                    dtp_NgayKT.Enabled = true;
                    txt_GhiChu.Enabled = true;
                    cbo_TTThuePhong.Enabled = true;
                    txt_MaSV.Enabled = false;
                    cbo_MaSV.Enabled = false;
                    //cbo_MaPhong.Enabled = false;
                    btn_Luu.Hide();
                    btn_Sua.Show();
                    btn_Sua.Enabled = true;
                    btn_Xoa.Show();
                    btn_Xoa.Enabled = true;
                    btn_Them.Enabled = false;
                    txt_MaSoThue.Text = dgv_SVThuePhong.CurrentRow.Cells[0].Value.ToString();

                    if (dgv_SVThuePhong.CurrentRow.Cells[3].Value.ToString() != "")
                    {
                        dtp_NgayBD.Value = DateTime.Parse(dgv_SVThuePhong.CurrentRow.Cells[3].Value.ToString());
                    }

                    if (dgv_SVThuePhong.CurrentRow.Cells[4].Value.ToString() != "")
                    {
                        dtp_NgayKT.Value = DateTime.Parse(dgv_SVThuePhong.CurrentRow.Cells[4].Value.ToString());
                    }

                    txt_GhiChu.Text = dgv_SVThuePhong.CurrentRow.Cells[5].Value.ToString();
                    //cbo_TTThuePhong.Text = dgv_SVThuePhong.CurrentRow.Cells[6].Value.ToString();

                    // Xử lý khi người dùng cellclick vào datagridview rỗng

                    if (dgv_SVThuePhong.CurrentRow.Cells[1].Value.ToString() != "" && dgv_SVThuePhong.CurrentRow.Cells[0].Value.ToString() != "")
                    {

                        cbo_MaPhong.Text = "";
                        cbo_MaPhong.SelectedText = dgv_SVThuePhong.CurrentRow.Cells[2].Value.ToString();
                        MaPhongChange();
                        cbo_MaSV.Text = "";
                        cbo_MaSV.SelectedText = dgv_SVThuePhong.CurrentRow.Cells[1].Value.ToString();
                        MaSVChange();
                    }

                    //MessageBox.Show(dgv_SVThuePhong.CurrentRow.Cells[6].Value.ToString());

                

            }
            catch (Exception ex)
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
                    SV_Phong.Delete(txt_MaSoThue.Text);
                    ShowTable();
                    MessageBox.Show("Xóa thành công!", "Thông báo");
                    btn_Reset_Click(null, null);
                    getMaSV();
                    getMaPhong();
                    getMaPhong_Search();
                    Reset();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông báo");
            }
            finally
            {
                txt_GhiChu.Focus();
            }
        }

        private void btn_Sua_Click(object sender, EventArgs e)
        {
            //MessageBox.Show(cbo_TTThuePhong.SelectedIndex.ToString());
            try
            {
                if (txt_GioiTinh.Text == txt_LoaiPhong.Text)
                {
                    if (MessageBox.Show("Bạn có chắc chắn muốn sửa?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        SV_Phong.Update(txt_MaSoThue.Text, dtp_NgayBD.Text, dtp_NgayKT.Text, txt_GhiChu.Text, cbo_TTThuePhong.SelectedIndex,cbo_MaPhong.Text);
                        ShowTable();
                        MessageBox.Show("Sửa thành công!", "Thông báo");
                        btn_Reset_Click(null, null);
                        getMaSV();
                        getMaPhong();
                        getMaPhong_Search();
                        Reset();
                    }           
                }
                else
                {
                    throw new Exception("Giới tính sinh viên không phù hợp với loại phòng này!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông báo");
            }
            finally
            {
                txt_GhiChu.Focus();
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
            dgv_SVThuePhong.DataSource = SV_Phong.Search(cbo_MaSoThue_search.Text);
            Reset();
        }

        private void btn_Show_Click(object sender, EventArgs e)
        {
            ShowTable();
            cbo_MaSoThue_search.Text = "";
            btn_Show.Enabled = false;
        }

        private void btn_AddPhong_Click(object sender, EventArgs e)
        {
            Phong.Phong_GUI phong = new Phong.Phong_GUI();
            this.Visible = false;
            phong.Show();
        }
        private void btn_AddSV_Click_1(object sender, EventArgs e)
        {
            SinhVien.SinhVien_GUI sinhvien = new SinhVien.SinhVien_GUI();
            this.Visible = false;
            sinhvien.Show();
        }
    }
}
