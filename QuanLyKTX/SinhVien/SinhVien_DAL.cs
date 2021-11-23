using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace QuanLyKTX.SinhVien
{
    class SinhVien_DAL
    {
        DataHelper helper = new DataHelper();

        // Lấy toàn bộ thông tin từ bảng SinhVien 
        public DataTable selectAllTable()
        {
            string sql = "exec sp_tSinhVien_All";
            return helper.getTable(sql);
        }

        // Lấy toàn bộ thông tin về Khu nhà truyền vào combobox
        public DataTable selectTableLop()
        {
            string sql = "exec sp_tLop_All";
            return helper.getTable(sql);
        }

        public DataTable selectTableKhoa()
        {
            string sql = "exec sp_tKhoa_All";
            return helper.getTable(sql);
        }
        public DataTable selectTableQue()
        {
            string sql = "exec sp_tQue_All";
            return helper.getTable(sql);
        }


        public DataTable CheckTable(string MaSinhVien)
        {
            string sql = "select MaSinhVien from tSinhVien where MaSinhVien = '" + MaSinhVien + "'";
            return helper.getTable(sql);
        }

        public void Insert(string MaSinhVien, string TenSinhVien, DateTime NgaySinh, int GioiTinh, string MaLop, string MaKhoa, string MaQue)
        {
            string sql = "exec sp_tSinhVien_Insert '" + MaSinhVien + "',N'" + TenSinhVien + "',N'" + NgaySinh + "',N'" + GioiTinh + "','" + MaLop + "',N'" + MaKhoa + "','" + MaQue + "'";
            helper.ExecuteQuery(sql);
        }

        public void Update(string MaSinhVien, string TenSinhVien, DateTime NgaySinh, int GioiTinh, string MaLop, string MaKhoa, string MaQue)
        {
            string sql = "exec sp_tSinhVien_Update '" + MaSinhVien + "',N'" + TenSinhVien + "',N'" + NgaySinh + "',N'" + GioiTinh + "','" + MaLop + "',N'" + MaKhoa + "','" + MaQue + "'";
            helper.ExecuteQuery(sql);
        }

        public void Delete(string MaSinhVien)
        {
            string sql = "exec sp_tSinhVien_Delete '" + MaSinhVien + "'";
            helper.ExecuteQuery(sql);
        }

        public DataTable Search(string str)
        {
            string sql = "exec sp_tSinhVien_Search N'" + str + "'";
            return helper.getTable(sql);
        }

        // gọi đến proc lấy mã khu đang check
        public DataTable LayMaLop(string TenLop)
        {
            string sql = "exec sp_tSinhVien_LayMaLop N'" + TenLop + "'";
            return helper.getTable(sql);
        }

        public DataTable LayMaKhoa(string TenKhoa)
        {
            string sql = "exec sp_tSinhVien_LayMaKhoa N'" + TenKhoa + "'";
            return helper.getTable(sql);
        }

        public DataTable LayMaQue(string TenQue)
        {
            string sql = "exec sp_tSinhVien_LayMaQue N'" + TenQue + "'";
            return helper.getTable(sql);
        }

        public DataTable LayLopTuKhoa(string MaKhoa)
        {
            string sql = "exec sp_tSinhVien_LayLopTuKhoa N'" + MaKhoa + "'";
            return helper.getTable(sql);
        }

      
    }
}
