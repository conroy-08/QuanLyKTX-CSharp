using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyKTX.TimKiem
{
    class TimKiem_DAL
    {
        DataHelper dataHelper = new DataHelper();
        string[] name;
        object[] value;

        public DataTable DAL_Search(string str)
        {
            name = new string[1];
            value = new object[1];
            name[0] = "@str"; value[0] = str;
            return dataHelper.GetDataByCondition("sp_tSinhVienSearch", name, value, 1);
        }

        public DataTable DAL_ShowSV()
        {
            return dataHelper.GetData("sp_tSinhVien_Show");
        }
    }
}
