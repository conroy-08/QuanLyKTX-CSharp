using QuanLyKTX.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyKTX.User
{
    public partial class PhanQuyen_GUI : Form
    {
        public PhanQuyen_GUI()
        {
            InitializeComponent();
        }

        PhanQuyen_BLL phanQuyen_BLL = new PhanQuyen_BLL();
        DataUtils utils = new DataUtils();
        private int UserId;


        private void PhanQuyen_GUI_Load(object sender, EventArgs e)
        {
            while (!User.FormLogin.Checked)
            {
                User.FormLogin formLogin = new User.FormLogin();
                formLogin.ShowDialog();
                this.Close();
            }
            try
            {
                txtTenTK.Enabled = false;
                txtMaTK.Enabled = false;
                txtMK.Enabled = false;
                dtPhanQuyen.ReadOnly = true;
                dtPhanQuyen.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                OpenDataGridView();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
           
        }
        private bool CheckedBox(CheckBox checkBox)//Đây, rất quan trọng, vì sẽ gọi hàm này để tick hoặc ko tick vào ô vuông của checkbox
        {
            if (checkBox.Checked) return true;
            return false;
        }

        private void OpenDataGridView()
        {
            dtPhanQuyen.DataSource = phanQuyen_BLL.BLL_PhanQuyen_Select();
            if (User.FormLogin.ROLES.Equals("MANAGER"))
            {
                for (int i = 0; i < dtPhanQuyen.Rows.Count - 1; i++)
                {
                    dtPhanQuyen.Rows[i].Cells[3].Value = utils.DecodePassWord("123", phanQuyen_BLL.BLL_PhanQuyen_Select().Rows[i][3].ToString());
                }
            }
            dtPhanQuyen.Columns[0].HeaderText = "ID"; dtPhanQuyen.Columns[0].Width = 30;
            dtPhanQuyen.Columns[1].HeaderText = "Tên Tài Khoản "; dtPhanQuyen.Columns[1].Width = 150;
            dtPhanQuyen.Columns[2].HeaderText = "Họ Và Tên "; dtPhanQuyen.Columns[2].Width = 150;
            dtPhanQuyen.Columns[3].HeaderText = "Mật Khẩu ";
            dtPhanQuyen.Columns[4].Visible = false;
            dtPhanQuyen.Columns[5].Visible = false;
            dtPhanQuyen.Columns[6].Visible = false;
            dtPhanQuyen.Columns[7].Visible = false;
            dtPhanQuyen.Columns[8].HeaderText = "Khoa "; dtPhanQuyen.Columns[8].Width = 60;
            dtPhanQuyen.Columns[9].HeaderText = "Lớp "; dtPhanQuyen.Columns[9].Width = 60;
            dtPhanQuyen.Columns[10].HeaderText = "Quê "; dtPhanQuyen.Columns[10].Width = 60;
            dtPhanQuyen.Columns[11].HeaderText = "Khu Nhà "; dtPhanQuyen.Columns[11].Width = 60;
            dtPhanQuyen.Columns[12].HeaderText = "Phòng "; dtPhanQuyen.Columns[12].Width = 60;
            dtPhanQuyen.Columns[13].HeaderText = "Sinh Viên "; dtPhanQuyen.Columns[13].Width = 60;
            dtPhanQuyen.Columns[14].HeaderText = "Thiết Bị "; dtPhanQuyen.Columns[14].Width = 60;
            dtPhanQuyen.Columns[15].HeaderText = "Thống Kê "; dtPhanQuyen.Columns[15].Width = 60;
            dtPhanQuyen.Columns[16].HeaderText = "Phân Quyền "; dtPhanQuyen.Columns[16].Width = 80;
            dtPhanQuyen.Columns[17].Visible = false;
            dtPhanQuyen.Columns[18].Visible = false;
            dtPhanQuyen.Columns[19].Visible = false;
            dtPhanQuyen.Columns[20].Visible = false;
            dtPhanQuyen.AllowUserToAddRows = false;
        }


        private void CheckOrUncheck(CheckBox ck, DataGridView dtv, int index, int cell)
        {
            if (dtv.Rows[index].Cells[cell].Value.ToString() == "True")
                ck.Checked = true;
            else ck.Checked = false;
        }

        private void CheckAll(Control parent)
        {
            foreach (Control ct in parent.Controls)
            {
                if (ct is CheckBox)
                    ((CheckBox)ct).Checked = true;
                if (ct.HasChildren)
                    CheckAll(ct);
            }
        }

        private void UnCheckAll(Control parent)
        {
            foreach (Control ct in parent.Controls)
            {
                if (ct is CheckBox)
                    ((CheckBox)ct).Checked = false;
                if (ct.HasChildren)
                    UnCheckAll(ct);
            }
        }

        private void ClearTextBoxes(Control ct)
        {
            foreach (Control c in ct.Controls)
            {
                if (c is TextBox)
                {
                    ((TextBox)c).Clear();
                }

                if (c.HasChildren)
                {
                    ClearTextBoxes(c);
                }
            }
        }

        private void dtPhanQuyen_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            UserId = int.Parse(dtPhanQuyen.Rows[e.RowIndex].Cells[0].Value.ToString());
            txtMaTK.Text = dtPhanQuyen.Rows[e.RowIndex].Cells[1].Value.ToString();
            txtTenTK.Text = dtPhanQuyen.Rows[e.RowIndex].Cells[2].Value.ToString();
            try
            {
                txtMK.Text = dtPhanQuyen.Rows[e.RowIndex].Cells[3].Value.ToString();
            }
            catch
            {
                txtMK.Text = utils.DecodePassWord("123", dtPhanQuyen.Rows[e.RowIndex].Cells[3].Value.ToString());
            }
            CheckOrUncheck(checkKhoa, dtPhanQuyen, e.RowIndex, 8);
            CheckOrUncheck(checkLop, dtPhanQuyen, e.RowIndex, 9);
            CheckOrUncheck(checkQue, dtPhanQuyen, e.RowIndex, 10);
            CheckOrUncheck(checkKhuNha, dtPhanQuyen, e.RowIndex, 11);
            CheckOrUncheck(checkPhong, dtPhanQuyen, e.RowIndex, 12);
            CheckOrUncheck(checkSinhVien, dtPhanQuyen, e.RowIndex, 13);
            CheckOrUncheck(checkThietBi, dtPhanQuyen, e.RowIndex, 14);
            CheckOrUncheck(checkTke, dtPhanQuyen, e.RowIndex, 15);
            CheckOrUncheck(checkPQuyen, dtPhanQuyen, e.RowIndex, 16);
        }


        private void btnChonTatCa_Click(object sender, EventArgs e)
        {
            CheckAll(this);
        }

        private void btnBoChonTatCa_Click(object sender, EventArgs e)
        {
            UnCheckAll(this);
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (txtMaTK.Text.Length != 0)
            {
                if (txtMK.Text.Length != 0)
                {
                    DialogResult dialogResult = MessageBox.Show("Ban có THẬT SỰ MUỐN CẬP NHẬT?", " CẢNH BÁO",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    if (dialogResult == DialogResult.Yes)
                    {
                        try
                        {
                            phanQuyen_BLL.BLL_PhanQuyenUser_Update(UserId, CheckedBox(checkKhoa), CheckedBox(checkLop)
                                , CheckedBox(checkQue), CheckedBox(checkKhuNha), CheckedBox(checkPhong), CheckedBox(checkSinhVien), CheckedBox(checkThietBi) , CheckedBox(checkPhongThietBi)
                                , CheckedBox(checkTke), CheckedBox(checkPQuyen));

                            MessageBox.Show("Cập nhật THÀNH CÔNG!!! ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            ClearTextBoxes(this);
                            UnCheckAll(this);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Cập nhật THẤT BẠI do: " + ex, " CẢNH BÁO ",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                else MessageBox.Show("Bạn chưa nhập mật khẩu");
            }
            else MessageBox.Show("Bạn chọn đối tượng để chỉnh sửa");
            PhanQuyen_GUI_Load(sender, e);
        }
    }
}
