using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace QuanLyKTX.SinhVien_TraPhong
{
    class SinhVien_TraPhong_DAL
    {
        DataHelper helper = new DataHelper();
        public DataTable selectAllTable()
        {
            string sql = "exec sp_tTraPhong_All";
            return helper.getTable(sql);
        }

        public void Insert(string MaSoThue, DateTime NgayTra , double TienViPham)
        {
            string sql = "exec sp_tTraPhong_Insert '" + MaSoThue + "',N'" + NgayTra + "','" + TienViPham + "'";
            helper.ExecuteQuery(sql);
        }

        public void Update(string MaSoThue, DateTime NgayTra, double TienViPham)
        {
            string sql = "exec sp_tTraPhong_Update '" + MaSoThue + "',N'" + NgayTra + "','" + TienViPham + "'";
            helper.ExecuteQuery(sql);
        }

        public void Delete(string MaSoThue)
        {
            string sql = "exec sp_tTraPhong_Delete '" + MaSoThue + "'";
            helper.ExecuteQuery(sql);
        }

        public DataTable Search(string str)
        {
            string sql = "exec sp_tTraPhong_Search N'" + str + "'";
            return helper.getTable(sql);
        }

        public DataTable CheckMaSoThue(string MaKhuNha)
        {
            string sql = "exec sp_tTraPhong_Insertcheck N'" + MaKhuNha + "'";
            return helper.getTable(sql);
        }

        public DataTable getMaSoThue()
        {
            string sql = "exec sp_SVTraPhong_MaSoThue";
            return helper.getTable(sql);
        }

        public DataTable getMaSoThue1()
        {
            string sql = "exec sp_SVTraPhong_MaSoThue1";
            return helper.getTable(sql);
        }

        public DataTable getMaSoThue2(string MST)
        {
            string sql = "exec sp_SVTraPhong_MaSoThueCheck N'" + MST + "'";
            return helper.getTable(sql);
        }

        public DataTable getThoiGianThue(string MST)
        {
            string sql = "exec sp_SVTraPhong_getThoiGianThue N'" + MST + "'";
            return helper.getTable(sql);
        }
        
    }
}
