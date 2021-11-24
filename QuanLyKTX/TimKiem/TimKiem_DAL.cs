using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace QuanLyKTX.TimKiem
{
    class TimKiem_DAL
    {
        DataHelper helper = new DataHelper();
        public DataTable selectAllTable()
        {
            string sql = "exec sp_TimKiem_All";
            return helper.getTable(sql);
        }

        public DataTable SearchSV(string str)
        {
            string sql = "exec sp_TimKiem_All_MSV N'" + str + "'";
            return helper.getTable(sql);
        }
        public DataTable SearchPhong(string str)
        {
            string sql = "exec sp_TimKiem_All_MP N'" + str + "'";
            return helper.getTable(sql);
        }
        public DataTable Search_SV_P(string sv,string p)
        {
            string sql = "exec sp_TimKiem_All_MSV_MP N'" + sv + "',N'" + p + "'";
            return helper.getTable(sql);
        }

        public DataTable Search_SV_P_TT(string sv, string p, int tt)
        {
            string sql = "exec sp_TimKiem_All_MSV_MP_TT N'" + sv + "',N'" + p + "'," + tt;
            return helper.getTable(sql);
        }
        public DataTable Search_SV_TT(string sv, int tt)
        {
            string sql = "exec sp_TimKiem_All_MSV_TT N'" + sv + "'," + tt;
            return helper.getTable(sql);
        }
        public DataTable Search_P_TT(string p, int tt)
        {
            string sql = "exec sp_TimKiem_All_MP_TT N'" + p + "'," + tt;
            return helper.getTable(sql);
        }
        public DataTable Search_TT(int tt)
        {
            string sql = "exec sp_TimKiem_All_TT " + tt;
            return helper.getTable(sql);
        }
    }
}
