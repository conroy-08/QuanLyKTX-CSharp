using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace QuanLyKTX.Lop
{
    class Lop_BLL
    {
        Lop_DAL lop = new Lop_DAL();
        string MaLop;
        public DataTable ShowTable()
        {
            return lop.selectAllTable();
        }

        public DataTable selectTableKhoa()
        {
            return lop.selectTableKhoa();
        }

        public void Insert(string MaLop, string TenLop, string MaKhoa)
        {
            lop.Insert(MaLop, TenLop, MaKhoa);
        }

        public void Update(string MaLop, string TenLop, string MaKhoa)
        {
            if (MaLop != "" && TenLop != "" && MaKhoa != "")
            {
                try
                {
                    lop.Update(MaLop, TenLop, MaKhoa);
                }
                catch
                {
                    throw new Exception("Vui lòng nhập đúng định dạng");
                }
            }
        }

        public bool CheckTable(string MaLop)
        {
            if (lop.CheckTable(MaLop).Rows.Count > 0)
            {
                return true;
            }
            return false;
        }

        public void Delete(string MaLop)
        {
            try
            {
                lop.Delete(MaLop);
            }
            catch (Exception)
            {
                throw new Exception("Bản ghi này liên quan đến nhiều dữ liệu khác.. Hãy chắc chắn là đã xóa hết dữ liệu liên quan từ các bảng khác!!");
            }
        }

        public DataTable Search(string str)
        {
            return lop.Search(str);
        }

        // Hàm xử lý lấy mã khoa khi sửa
        public string getMaKhoa(string TenKhoa)
        {
            string res;
            res = lop.LayMaKhoa(TenKhoa).Rows[0]["MaKhoa"].ToString();
            return res;
        }

        // Lấy id(mã) tự động
        public string checkId()
        {
            bool check = true;
            int i = 0;
            while (check)
            {
                if (i < 10)
                {
                    MaLop = "L0" + i.ToString();
                }
                else
                {
                    MaLop = "L" + i.ToString();
                }

                if (CheckTable(MaLop))
                {
                    i++;
                }
                else
                {
                    check = false;
                }
            }

            return MaLop;
        }
    }
}
