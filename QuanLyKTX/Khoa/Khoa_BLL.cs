using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace QuanLyKTX.Khoa
{
    class Khoa_BLL
    {
        Khoa_DAL khoa = new Khoa_DAL();
        string MaKhoa;

        public DataTable ShowTable()
        {
            return khoa.selectAllTable();
        }

        public void Insert(string MaKhoa, string TenKhoa)
        {
            khoa.Insert(MaKhoa, TenKhoa);
        }

        public void Update(string MaKhoa, string TenKhoa)
        {
            khoa.Update(MaKhoa, TenKhoa);
        }

        public void Delete(string MaKhoa)
        {
            try
            {
                khoa.Delete(MaKhoa);
            }
            catch (Exception)
            {
                throw new Exception("Bản ghi này liên quan đến nhiều dữ liệu khác.. Hãy chắc chắn là đã xóa hết dữ liệu liên quan từ các bảng khác!!");
            }
        }

        public DataTable Search(string str)
        {
            return khoa.Search(str);
        }

        public bool CheckTable(string MaKhoa)
        {
            if (khoa.CheckTable(MaKhoa).Rows.Count > 0)
            {
                return true;
            }
            return false;
        }

        public string checkId()
        {
            bool check = true;
            int i = 0;
            while (check)
            {
                if (i < 10)
                {
                    MaKhoa = "K00" + i.ToString();
                }
                else
                {
                    MaKhoa = "K" + i.ToString();
                }

                if (khoa.CheckTable(MaKhoa).Rows.Count > 0)
                {
                    i++;
                }
                else
                {
                    check = false;
                }
            }

            return MaKhoa;
        }
    }
}
