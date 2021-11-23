using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace QuanLyKTX.ThietBi
{
    class ThietBi_BLL
    {
        ThietBi_DAL thietbi = new ThietBi_DAL();
        string MaThietBi;

        public DataTable ShowTable()
        {
            return thietbi.selectAllTable();
        }

        public void Insert(string MaThietBi, string TenThietBi, int TrangThai)
        {
            if (TenThietBi != "")
            {
                thietbi.Insert(MaThietBi, TenThietBi, TrangThai);
            }
            else
            {
                throw new Exception("Vui lòng điền đầy đủ thông tin");
            }
        }

        public void Update(string MaThietBi, string TenThietBi, int TrangThai)
        {
            if(TenThietBi != "")
            {
                thietbi.Update(MaThietBi, TenThietBi,TrangThai);
            }
            else
            {
                throw new Exception("Vui lòng điền đầy đủ thông tin");
            }
        }

        public void Delete(string MaThietBi)
        {
            try
            {
                thietbi.Delete(MaThietBi);
            }       
            catch (Exception ex)
            {
                throw new Exception("Bản ghi này có liên quan đên các dữ liệu khác.. Vui lòng xóa các dữ liệu khác trước khi xóa bản ghi này!");
            }
        }

        public DataTable Search(string str)
        {
            return thietbi.Search(str);
        }

        // Kiểm tra tồn tại 1 bản ghi
        private bool CheckTable(string MaThietBi)
        {
            if (thietbi.CheckTable(MaThietBi).Rows.Count > 0)
            {
                return true;
            }
            return false;
        }

        // Hàm xử lý id tự tăng
        public string checkId()
        {
            bool check = true;
            int i = 0;
            while (check)
            {
                if (i < 10)
                {
                    MaThietBi = "TB0" + i.ToString();
                }
                else
                {
                    MaThietBi = "TB" + i.ToString();
                }

                if (CheckTable(MaThietBi))
                {
                    i++;
                }
                else
                {
                    check = false;
                }
            }

            return MaThietBi;
        }
    }
}
