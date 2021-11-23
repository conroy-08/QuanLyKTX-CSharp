using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
namespace QuanLyKTX.User
{
    class User_BLL
    {
        User_DAL user_DAL = new User_DAL();

        public DataTable BLL_USER_Select()
        {
            return user_DAL.DAL_USER_Select();
        }

        public DataTable BLL_User_Search(string HoVaTen)
        {
            return user_DAL.DAL_USER_Search(HoVaTen);
        }

        public DataTable BLL_USER_GetStaff(string TenTaiKhoan , string Roles)
        {
            return user_DAL.DAL_USER_GetStaff(TenTaiKhoan, Roles);
        }
    }
}
