using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace QuanLyKTX.User
{
    class PhanQuyen_BLL
    {
        PhanQuyen_DAL phanQuyen_DAL = new PhanQuyen_DAL();

        public DataTable BLL_PhanQuyen_Select()
        {
            return phanQuyen_DAL.DAL_PhanQuyen_Select();
        }

        public DataTable BLL_PhanQuyen_DangNhap_Select(string TenTaiKhoan, string MatKhau)
        {
            return phanQuyen_DAL.DAL_PhanQuyenDangNhap_Select(TenTaiKhoan, MatKhau);
        }

        public void BLL_PhanQuyen_Insert(string TenTaiKhoan, string HoVaTen, string password, DateTime NgaySinh,
                   string DiaChi, string SDT, string Email, string Roles, int TrangThai, string thumbnail)
        {
            phanQuyen_DAL.DAL_PhanQuyen_Insert(TenTaiKhoan, HoVaTen, password, NgaySinh, DiaChi, SDT, Email, Roles, TrangThai, thumbnail);
        }

        public void BLL_PhanQuyen_Update(int UserId, string TenTaiKhoan, string HoVaTen, string password, DateTime NgaySinh,
                   string DiaChi, string SDT, string Email, string Roles, string thumbnail)
        {
            phanQuyen_DAL.DAL_PhanQuyen_Update(UserId, TenTaiKhoan, HoVaTen, password, NgaySinh, DiaChi, SDT, Email, Roles, thumbnail);
        }

        public void BLL_PhanQuyenUser_Update(int UserId, bool QLKhoa, bool QLLop, bool QLQue, bool QLKhuNha,
                  bool QLPhong, bool QLSinhVien, bool QLThietBi, bool QLPhongThietBi , bool ThongKe, bool PhanQuyen)
        {
            phanQuyen_DAL.DAL_PhanQuyenUser_Update(UserId, QLKhoa, QLLop, QLQue, QLKhuNha, QLPhong, QLSinhVien, QLThietBi, QLPhongThietBi ,ThongKe, PhanQuyen);
        }

        public void BLL_PhanQuyen_Delete(int UserId, int TrangThai)
        {
            phanQuyen_DAL.DAL_PhanQuyen_Delete(UserId, TrangThai);
        }
    }
}
