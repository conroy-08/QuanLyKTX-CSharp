using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyKTX.TimKiem
{
    class TimKiem_BLL
    {

        TimKiem_DAL timKiem_DAL = new TimKiem_DAL();
        
        public DataTable BLL_Search(string str)
        {
            return timKiem_DAL.DAL_Search(str);
        }

        public DataTable BLL_ShowSV()
        {
            return timKiem_DAL.DAL_ShowSV();
        }
    }
}
