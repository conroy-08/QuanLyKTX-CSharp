using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace QuanLyKTX.User
{
    class User_DAL
    {
        DataHelper dataHelper = new DataHelper();
        string[] name;
        object[] value;

        public DataTable DAL_USER_Select()
        {
            return dataHelper.GetData("User_Select");
        }

        public DataTable DAL_USER_Search(string HoVaTen)
        {
            name = new string[1];
            value = new object[1];
            name[0] = "@HoVaTen"; value[0] = HoVaTen;
            return dataHelper.GetDataByCondition("sp_tUser_Search", name,value,1);
        }

        public DataTable DAL_USER_GetStaff(string TenTaiKhoan , string Roles)
        {
            name = new string[2];
            value = new object[2];
            name[0] = "@TenTaiKhoan"; value[0] = TenTaiKhoan;
            name[1] = "@Roles"; value[1] = Roles;
            return dataHelper.GetDataByCondition("sp_tUser_SelectStaff", name, value, 2);
        }
    }
}
