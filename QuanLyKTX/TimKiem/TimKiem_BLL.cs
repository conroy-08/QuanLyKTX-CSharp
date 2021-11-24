using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace QuanLyKTX.TimKiem
{
    class TimKiem_BLL
    {
        TimKiem_DAL timkiem = new TimKiem_DAL();
        public DataTable ShowTable()
        {
            return timkiem.selectAllTable();
        }
        public DataTable SearchSV(string str)
        {
            return timkiem.SearchSV(str);
        }
        public DataTable SearchPhong(string str)
        {
            return timkiem.SearchPhong(str);
        }
        public DataTable Search_SV_P(string sv, string p)
        {
            return timkiem.Search_SV_P(sv,p);
        }
        public DataTable Search_SV_P_TT(string sv, string p, int tt)
        {
            return timkiem.Search_SV_P_TT(sv, p, tt);
        }
        public DataTable Search_SV_TT(string sv, int tt)
        {
            return timkiem.Search_SV_TT(sv, tt);
        }
        public DataTable Search_P_TT(string p, int tt)
        {
            return timkiem.Search_P_TT(p, tt);
        }
        public DataTable Search_TT(int tt)
        {
            return timkiem.Search_TT(tt);
        }
    }
}
