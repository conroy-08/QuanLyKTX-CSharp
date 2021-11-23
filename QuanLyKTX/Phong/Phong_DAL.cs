using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace QuanLyKTX.Phong
{
    class Phong_DAL
    {
        DataHelper helper = new DataHelper();

        // Lấy toàn bộ thông tin từ bảng Phòng db
        public DataTable selectAllTable()
        {
            string sql = "exec sp_tPhong_All";
            return helper.getTable(sql);
        }

        // Lấy toàn bộ thông tin về Khu nhà truyền vào combobox
        public DataTable selectTableKhuNha()
        {
            string sql = "exec sp_tKhuNha_All";
            return helper.getTable(sql);
        }


        public DataTable CheckTable(string MaPhong)
        {
            string sql = "select MaPhong from tPhong where MaPhong = '" + MaPhong + "'";
            return helper.getTable(sql);
        }


        public DataTable findOneByMaPhong(string MaPhong)
        {
            string sql = "sp_tPhong_FindOneByMaPhong '" + MaPhong + "'";
            return helper.getTable(sql);
        }

        public void Insert(string MaPhong,string TenPhong,string MaKhuNha,int LoaiPhong, int songuoi, string GhiChu, double GiaPhong,int TrangThai)
        {
            string sql = "exec sp_tPhong_Insert '" + MaPhong + "',N'" + TenPhong + "',N'" + MaKhuNha + "','" + LoaiPhong + "','" + songuoi + "',N'" + GhiChu + "','" + GiaPhong + "','" + TrangThai + "'";
            helper.ExecuteQuery(sql);
        }

        public void Update(string MaPhong, string TenPhong, string MaKhuNha, int LoaiPhong, int songuoi, string GhiChu, double GiaPhong,int TrangThai)
        {
            string sql = "exec sp_tPhong_Update '" + MaPhong + "',N'" + TenPhong + "',N'" + MaKhuNha + "','" + LoaiPhong + "','" + songuoi + "',N'" + GhiChu + "','" + GiaPhong + "','" + TrangThai + "'";
            helper.ExecuteQuery(sql);
        }

        public void Delete(string MaPhong)
        {
            string sql = "exec sp_tPhong_Delete '" + MaPhong + "'";
            helper.ExecuteQuery(sql);
        }

        public DataTable Search(string str, int songuoi)
        {
            string sql = "exec sp_tPhong_Search N'" + str + "','"+ songuoi +"'";
            return helper.getTable(sql);
        }

        


        // gọi đến proc lấy mã khu đang check
        public DataTable LayMaKhu(string TenKhu)
        {
            string sql = "exec sp_tPhong_LayMaKhu N'" + TenKhu + "'";
            return helper.getTable(sql);
        }


    }
}
