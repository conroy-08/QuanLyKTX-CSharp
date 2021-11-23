using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace QuanLyKTX.KhuNha
{
    class KhuNha_BLL
    {
        KhuNha_DAL khunha = new KhuNha_DAL();
        string MaKhuNha;

        public DataTable ShowTable()
        {
            return khunha.selectAllTable();
        }

        public void Insert(string MaKhuNha,string TenKhuNha,int TrangThai)
        {
            if(TenKhuNha != "")
            {
                khunha.Insert(MaKhuNha, TenKhuNha,TrangThai);
            }
            else
            {
                throw new Exception("Vui lòng điền đầy đủ thông tin");
            }
        }

        public void Update(string MaKhuNha, string TenKhuNha,int TrangThai)
        {
            if (TenKhuNha != "")
            {
                khunha.Update(MaKhuNha, TenKhuNha,TrangThai);
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
                khunha.Delete(MaKhuNha);
            }
            catch(Exception ex)
            {
                throw new Exception("Bản ghi này liên quan đến nhiều dữ liệu khác.. Hãy chắc chắn là đã xóa hết dữ liệu liên quan từ các bảng khác!!");
            }
        }

        public DataTable Search(string str)
        {
            return khunha.Search(str);
        }

        // Hàm kiểm tra xem Khu nhà tồn tại hay chưa
        private bool CheckTable(string MaKhuNha)
        {
            if(khunha.CheckTable(MaKhuNha).Rows.Count > 0)
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
                    MaKhuNha = "KN0" + i.ToString();
                }
                else
                {
                    MaKhuNha = "KN" + i.ToString();
                }

                if(CheckTable(MaKhuNha))
                {                  
                     i++;                  
                }
                else
                {
                    check = false;
                }
            }

            return MaKhuNha;
        }
    }
}
