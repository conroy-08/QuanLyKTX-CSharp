using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace QuanLyKTX.Que
{
    class Que_DAL
    {
        // Thực thi câu lệnh SQL
        DataHelper helper = new DataHelper();

        public DataTable selectAllTable()
        {
            string sql = "exec sp_tQue_All";
            return helper.getTable(sql);
        }

        public void Insert(string MaQue, string TenQue)
        {
            string sql = "exec sp_tQue_Insert '" + MaQue + "',N'" + TenQue + "'";
            helper.ExecuteQuery(sql);
        }

        public void Update(string MaQue, string TenQue)
        {
            string sql = "exec sp_tQue_Update '" + MaQue + "',N'" + TenQue + "'";
            helper.ExecuteQuery(sql);
        }

        public void Delete(string MaQue)
        {
            string sql = "exec sp_tQue_Delete '" + MaQue + "'";
            helper.ExecuteQuery(sql);
        }

        public DataTable Search(string str)
        {
            string sql = "exec sp_tQue_Search N'" + str + "'";
            return helper.getTable(sql);
        }

        public DataTable CheckTable(string MaQue)
        {
            string sql = "select MaQue from tQue where MaQue = '" + MaQue + "'";
            return helper.getTable(sql);
        }
    }
}
