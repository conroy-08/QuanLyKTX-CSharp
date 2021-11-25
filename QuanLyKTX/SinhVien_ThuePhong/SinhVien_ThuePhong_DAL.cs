using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace QuanLyKTX.SinhVien_DatPhong
{
    class SinhVien_ThuePhong_DAL
    {
        DataHelper helper = new DataHelper();

        public DataTable selectAllTable()
        {
            string sql = "exec sp_SVThuePhong_All";
            return helper.getTable(sql);
        }

        //Lấy tất cả mã phòng truyền vào combo box
        public DataTable getMaPhong()
        {
            string sql = "exec sp_SVThuePhong_MaPhong";
            return helper.getTable(sql);
        }


        public DataTable getMaSoThue()
        {
            string sql = "exec sp_SVThuePhong_MaSoThue";
            return helper.getTable(sql);
        }

        public DataTable getInformationPhong(string MaPhong)
        {
            string sql = "exec sp_TbiPhong_InformationPhong '" + MaPhong + "'";
            return helper.getTable(sql);
        }

        //Lấy mã Sinhviên từ proc tSinhvien
        public DataTable getMaSV()
        {
            string sql = "exec sp_SVThuePhong_MaSV";
            return helper.getTable(sql);
        }

        //Lấy thông tin sinh viên
        public DataTable getInformationSV(string MaSV)
        {
            string sql = "exec sp_SVThuePhong_InformationSV '" + MaSV + "'";
            return helper.getTable(sql);
        }
        public void Insert(string MaSoThue, string MaSV, string MaPhong, DateTime NgayBD, DateTime NgayKT, string GhiChu, int TinhTrang) 
        {
            string sql = "exec sp_SVThuePhong_Insert '" + MaSoThue + "',N'" + MaSV + "','" + MaPhong + "','" + NgayBD + "','" + NgayKT + "',N'" + GhiChu + "','" + TinhTrang + "'";
            helper.ExecuteQuery(sql);
        }

        public void Update(string MaSoThue, DateTime NgayBD, DateTime NgayKT, string GhiChu, int TinhTrang,string MaPhong)
        {
            string sql = "exec sp_SVThuePhong_Update '" + MaSoThue + "',N'" + NgayBD + "','" + NgayKT + "',N'" + GhiChu + "','" + TinhTrang + "','"+MaPhong+"'";
            helper.ExecuteQuery(sql);
        }

        public void Delete(string MaSoThue)
        {
            string sql = "exec sp_SVThuePhong_Delete '" + MaSoThue + "'";
            helper.ExecuteQuery(sql);
        }

        //Kiểm tra sv phòng  đã có chưa
        public DataTable checkTable(string MaSoThue)
        {
            string sql = "exec sp_SVThuePhong_checkTable '" + MaSoThue + "'";
            return helper.getTable(sql);
        }


        public DataTable checkMaSV(string MaSV)
        {
            string sql = "exec sp_SVThuePhong_checkmasv '" + MaSV + "'";
            return helper.getTable(sql);
        }

        // Hàm kiểm tra phòng có tồn tại
        public DataTable checkMaPhong(string MaPhong)
        {
            string sql = "exec sp_TbiPhong_checkPhong '" + MaPhong + "'";
            return helper.getTable(sql);
        }

        public DataTable CheckTable1(string MaSoThue)
        {
            string sql = "exec sp_SVThuePhong_checkMaST '" + MaSoThue + "'";
            return helper.getTable(sql);
        }
    }
}
