using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace QuanLyKTX.KhuNha
{
    class KhuNha_DAL
    {
        // Thực thi câu lệnh SQL
        DataHelper helper = new DataHelper();
        public DataTable selectAllTable()
        {
            string sql = "exec sp_tKhuNha_All";
            return helper.getTable(sql);
        }

        public void Insert(string MaKhuNha,string TenKhuNha,int Trangthai)
        {
            string sql = "exec sp_tKhuNha_Insert '" + MaKhuNha + "',N'" + TenKhuNha + "','" + Trangthai + "'";
            helper.ExecuteQuery(sql);
        }

        public void Update(string MaKhuNha, string TenKhuNha,int Trangthai)
        {
            string sql = "exec sp_tKhuNha_Update '" + MaKhuNha + "',N'" + TenKhuNha + "','" + Trangthai + "'";
            helper.ExecuteQuery(sql);
        }

        public void Delete(string MaKhuNha)
        {
            string sql = "exec sp_tKhuNha_Delete '" + MaKhuNha + "'";
            helper.ExecuteQuery(sql);
        }

        public DataTable Search(string str)
        {
            string sql = "exec sp_tKhuNha_Search N'" + str + "'";
            return helper.getTable(sql);
        }

        public DataTable CheckTable(string MaKhuNha)
        {
            string sql = "select MaKhuNha from tKhuNha where MaKhuNha = '" + MaKhuNha + "'";
            return helper.getTable(sql);
        }
    }
}
