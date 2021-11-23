using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace QuanLyKTX.Que
{
    class Que_BLL
    {
        Que_DAL que = new Que_DAL();
        string MaQue;

        public DataTable ShowTable()
        {
            return que.selectAllTable();
        }

        public void Insert(string MaQue, string TenQue)
        {
            if (TenQue != "")
            {
                que.Insert(MaQue, TenQue);
            }
            else
            {
                throw new Exception("Vui lòng điền đầy đủ thông tin");
            }
        }

        public void Update(string MaQue, string TenQue)
        {
            if (TenQue != "")
            {
                que.Update(MaQue, TenQue);
            }
            else
            {
                throw new Exception("Vui lòng điền đầy đủ thông tin");
            }
        }

        public void Delete(string MaKhuNha)
        {
            try
            {
                que.Delete(MaKhuNha);
            }
            catch (Exception ex)
            {
                throw new Exception("Bản ghi này liên quan đến nhiều dữ liệu khác.. Hãy chắc chắn là đã xóa hết dữ liệu liên quan từ các bảng khác!!");
            }
        }

        public DataTable Search(string str)
        {
            return que.Search(str);
        }

        // Hàm kiểm tra xem quê tồn tại hay chưa
        private bool CheckTable(string MaKhuNha)
        {
            if (que.CheckTable(MaKhuNha).Rows.Count > 0)
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
                    MaQue = "Q0" + i.ToString();
                }
                else
                {
                    MaQue = "Q" + i.ToString();
                }

                if (CheckTable(MaQue))
                {
                    i++;
                }
                else
                {
                    check = false;
                }
            }

            return MaQue;
        }

    }
}
