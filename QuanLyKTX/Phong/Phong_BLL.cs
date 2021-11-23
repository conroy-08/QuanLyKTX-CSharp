using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace QuanLyKTX.Phong
{
    class Phong_BLL
    {
        Phong_DAL phong = new Phong_DAL();
        string MaPhong;

        public DataTable ShowTable()
        {
            return phong.selectAllTable();
        }

        public DataTable selectTableKhuNha()
        {
            return phong.selectTableKhuNha();
        }

        public DataTable findOneByMaPhong(string MaPhong)
        {
            return phong.findOneByMaPhong(MaPhong);
        }

        public void Insert(string MaPhong, string TenPhong, string MaKhuNha, int LoaiPhong, string songuoi, string GhiChu, string GiaPhong,int TrangThai)
        {
            if (TenPhong != "" && MaKhuNha != "")
            {
                try
                {
                    phong.Insert(MaPhong, TenPhong, MaKhuNha, LoaiPhong, int.Parse(songuoi), GhiChu, double.Parse(GiaPhong),TrangThai);
                }
                catch
                {
                    throw new Exception("Vui lòng nhập đúng định dạng");
                }
            }
            else
            {
                throw new Exception("Vui lòng điền đầy đủ thông tin");
            }
        }

        public void Update(string MaPhong, string TenPhong, string MaKhuNha, int LoaiPhong, string songuoi, string GhiChu, string GiaPhong,int TrangThai)
        {
            if (TenPhong != "" && MaKhuNha != "")
            {
                try
                {
                    phong.Update(MaPhong, TenPhong, MaKhuNha, LoaiPhong, int.Parse(songuoi), GhiChu, double.Parse(GiaPhong), TrangThai);
                }
                catch
                {
                    throw new Exception("Vui lòng nhập đúng định dạng");
                }
            }
            else
            {
                throw new Exception("Vui lòng điền đầy đủ thông tin");
            }
        }

        // Kiểm tra tồn tại 1 bản ghi
        private bool CheckTable(string MaPhong)
        {
            if (phong.CheckTable(MaPhong).Rows.Count > 0) 
            {
                return true;
            }
            return false;
        }

        public void Delete(string MaPhong)
        {
            try
            {
                phong.Delete(MaPhong);
            }
            catch(Exception ex)
            {
                throw new Exception("Bản ghi này có liên quan đên các dữ liệu khác.. Vui lòng xóa các dữ liệu khác trước khi xóa bản ghi này!");
            }
        }

        public DataTable Search(string str, int songuoi)
        {
            return phong.Search(str, songuoi);
        }

        // Hàm xử lý lấy mã khu khi sửa
        public string getMaKhu(string TenKhu)
        {
            string res;
            res = phong.LayMaKhu(TenKhu).Rows[0]["MaKhuNha"].ToString();
            return res;
        }

        // Lấy id tự động
        public string checkId()
        {
            bool check = true;
            int i = 0;
            while (check)
            {
                if (i < 10)
                {
                    MaPhong = "P0" + i.ToString();
                }
                else
                {
                    MaPhong = "P" + i.ToString();
                }

                if (CheckTable(MaPhong))
                {
                    i++;
                }
                else
                {
                    check = false;
                }
            }

            return MaPhong;
        }
    }
}
