using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;


namespace QuanLyKTX.Lop
{
    class Lop_DAL
    {
        DataHelper helper = new DataHelper();

        public DataTable selectAllTable()
        {
            string sql = "exec sp_tLop_All";
            return helper.getTable(sql);
        }

        public DataTable selectTableKhoa()
        {
            string sql = "exec sp_tKhoa_All";
            return helper.getTable(sql);
        }

        public DataTable CheckTable(string MaLop)
        {
            string sql = "select MaLop from tLop where MaLop = '" + MaLop + "'";
            return helper.getTable(sql);
        }

        public void Insert(string MaLop, string TenLop, string MaKhoa)
        {
            string sql = "exec sp_tLop_Insert '" + MaLop + "',N'" + TenLop + "',N'" + MaKhoa + "'";
            helper.ExecuteQuery(sql);
        }

        public void Update(string MaLop, string TenLop, string MaKhoa)
        {
            string sql = "exec sp_tLop_Update '" + MaLop + "',N'" + TenLop + "',N'" + MaKhoa + "'";
            helper.ExecuteQuery(sql);
        }

        public void Delete(string MaLop)
        {
            string sql = "exec sp_tLop_Delete '" + MaLop + "'";
            helper.ExecuteQuery(sql);
        }

        public DataTable Search(string str)
        {
            string sql = "exec sp_tLop_Search N'" + str + "'";
            return helper.getTable(sql);
        }

        // gọi đến proc lấy mã khoa đang check
        public DataTable LayMaKhoa(string TenKhoa)
        {
            string sql = "exec sp_tLop_LayMaKhoa N'" + TenKhoa + "'";
            return helper.getTable(sql);
        }
    }
}
