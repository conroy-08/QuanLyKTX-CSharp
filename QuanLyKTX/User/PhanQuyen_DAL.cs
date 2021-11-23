using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace QuanLyKTX.User
{
    class PhanQuyen_DAL
    {
        DataHelper dataHelper = new DataHelper();
        string[] name;
        object[] value;

        public DataTable DAL_PhanQuyen_Select()
        {
            return dataHelper.GetData("PhanQuyen_Select");
        }

        public DataTable DAL_PhanQuyenDangNhap_Select(string TenTaiKhoan, string password)
        {
            name = new string[2];
            value = new object[2];
            name[0] = "@TenTaiKhoan"; value[0] = TenTaiKhoan;
            name[1] = "@MatKhau"; value[1] = password;
            return dataHelper.GetDataByCondition("PhanQuyenDangNhap_Select", name, value, 2);
        }


        public void DAL_PhanQuyen_Insert(string TenTaiKhoan, string HoVaTen, string password, DateTime NgaySinh,
                   string DiaChi, string SDT, string Email, string Roles, int TrangThai, string thumbnail)
        {
            name = new string[10];
            value = new object[10];
            name[0] = "@TenTaiKhoan"; value[0] = TenTaiKhoan;
            name[1] = "@HoVaTen"; value[1] = HoVaTen;
            name[2] = "@MatKhau"; value[2] = password;
            name[3] = "@NgaySinh"; value[3] = NgaySinh;
            name[4] = "@DiaChi"; value[4] = DiaChi;
            name[5] = "@SDT"; value[5] = SDT;
            name[6] = "@Email"; value[6] = Email;
            name[7] = "@Roles"; value[7] = Roles;
            name[8] = "@TrangThai"; value[8] = TrangThai;
            name[9] = "@Thumbnail"; value[9] = thumbnail;
            dataHelper.ExecuteQuery("PhanQuyen_Insert", name, value, 10);

        }

        public void DAL_PhanQuyen_Update(int UserId, string TenTaiKhoan, string HoVaTen, string password, DateTime NgaySinh,
                    string DiaChi, string SDT, string Email, string Roles, string thumbnail)
        {
            name = new string[10];
            value = new object[10];
            name[0] = "@UserID"; value[0] = UserId;
            name[1] = "@TenTaiKhoan"; value[1] = TenTaiKhoan;
            name[2] = "@HoVaTen"; value[2] = HoVaTen;
            name[3] = "@MatKhau"; value[3] = password;
            name[4] = "@NgaySinh"; value[4] = NgaySinh;
            name[5] = "@DiaChi"; value[5] = DiaChi;
            name[6] = "@SDT"; value[6] = SDT;
            name[7] = "@Email"; value[7] = Email;
            name[8] = "@Roles"; value[8] = Roles;
            name[9] = "@Thumbnail"; value[9] = thumbnail;
            dataHelper.ExecuteQuery("PhanQuyen_Update", name, value, 10);
        }


        public void DAL_PhanQuyenUser_Update(int UserId, bool QLKhoa, bool QLLop, bool QLQue, bool QLKhuNha,
                  bool QLPhong, bool QLSinhVien, bool QLThietBi, bool QLPhongThietBi ,bool ThongKe, bool PhanQuyen)
        {
            name = new string[11];
            value = new object[11];
            name[0] = "@UserID"; value[0] = UserId;
            name[1] = "@QLKhoa"; value[1] = QLKhoa;
            name[2] = "@QLLop"; value[2] = QLLop;
            name[3] = "@QLQue"; value[3] = QLQue;
            name[4] = "@QLKhuNha"; value[4] = QLKhuNha;
            name[5] = "@QLPhong"; value[5] = QLPhong;
            name[6] = "@QLSinhVien"; value[6] = QLSinhVien;
            name[7] = "@QLThietBi"; value[7] = QLThietBi;
            name[8] = "@QLPhongThietBi"; value[8] = QLPhongThietBi;
            name[9] = "@ThongKe"; value[9] = ThongKe;
            name[10] = "@PhanQuyen"; value[10] = PhanQuyen;

            dataHelper.ExecuteQuery("PhanQuyenUser_Update", name, value, 11);
        }

        public void DAL_PhanQuyen_Delete(int UserId, int TrangThai)
        {
            name = new string[2];
            value = new object[2];
            name[0] = "@UserID"; value[0] = UserId;
            name[1] = "@TrangThai"; value[1] = TrangThai;
            dataHelper.ExecuteQuery("PhanQuyen_Delete", name, value, 2);
        }

        
    }
}
