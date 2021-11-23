using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace QuanLyKTX.Khoa
{
    class Khoa_DAL
    {
        DataHelper helper = new DataHelper();

        public DataTable selectAllTable()
        {
            string sql = "exec sp_tKhoa_All";
            return helper.getTable(sql);
        }

        public void Insert(string MaKhoa, string TenKhoa)
        {
            string sql = "exec sp_tKhoa_Insert '" + MaKhoa + "',N'" + TenKhoa + "'";
            helper.ExecuteQuery(sql);
        }

        public void Update(string MaKhoa, string TenKhoa)
        {
            string sql = "exec sp_tKhoa_Update '" + MaKhoa + "',N'" + TenKhoa + "'";
            helper.ExecuteQuery(sql);
        }

        public void Delete(string MaKhoa)
        {
            string sql = "exec sp_tKhoa_Delete '" + MaKhoa + "'";
            helper.ExecuteQuery(sql);
        }

        public DataTable Search(string str)
        {
            string sql = "exec sp_tKhoa_Search N'" + str + "'";
            return helper.getTable(sql);
        }

        public DataTable CheckTable(string MaKhoa)
        {
            string sql = "select MaKhoa from tKhoa where MaKhoa = '" + MaKhoa + "'";
            return helper.getTable(sql);
        }
    }
}
