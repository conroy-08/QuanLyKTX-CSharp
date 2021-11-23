using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace QuanLyKTX.ThietBi
{
    class ThietBi_DAL
    {
        // Thực thi câu lệnh SQL
        DataHelper helper = new DataHelper();
        public DataTable selectAllTable()
        {
            string sql = "exec sp_tThietBi_All";
            return helper.getTable(sql);
        }

        public void Insert(string MaThietBi, string TenThietBi,int TrangThai)
        {
            string sql = "exec sp_tThietBi_Insert '" + MaThietBi + "',N'" + TenThietBi + "','" + TrangThai + "'";
            helper.ExecuteQuery(sql);
        }

        public void Update(string MaThietBi, string TenThietBi,int TrangThai)
        {
            string sql = "exec sp_tThietBi_Update '" + MaThietBi + "',N'" + TenThietBi + "','" + TrangThai + "'";
            helper.ExecuteQuery(sql);
        }

        public void Delete(string MaThietBi)
        {
            string sql = "exec sp_tThietBi_Delete '" + MaThietBi + "'";
            helper.ExecuteQuery(sql);
        }

        public DataTable Search(string str)
        {
            string sql = "exec sp_tThietBi_Search N'" + str + "'";
            return helper.getTable(sql);
        }

        public DataTable CheckTable(string MaThietBi)
        {
            string sql = "select MaThietBi from tThietBi where MaThietBi = '" + MaThietBi + "'";
            return helper.getTable(sql);
        }
    }
}
