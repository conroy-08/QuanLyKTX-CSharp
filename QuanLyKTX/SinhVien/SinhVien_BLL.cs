using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace QuanLyKTX.SinhVien
{
    class SinhVien_BLL
    {
        SinhVien_DAL sinhvien = new SinhVien_DAL();
        string MaSinhVien;

        public DataTable ShowTable()
        {
            return sinhvien.selectAllTable();
        }

        public DataTable selectTableLop()
        {
            return sinhvien.selectTableLop();
        }

        public DataTable selectTableKhoa()
        {
            return sinhvien.selectTableKhoa();
        }
        public DataTable selectTableQue()
        {
            return sinhvien.selectTableQue();
        }

        public void Insert(string MaSinhVien, string TenSinhVien, string NgaySinh, int GioiTinh, string MaLop, string MaKhoa, string MaQue)
        {
            if (TenSinhVien != "" && NgaySinh != "" && MaLop != "" && MaKhoa != "" && MaQue != "")
            {
                try
                {
                    sinhvien.Insert(MaSinhVien, TenSinhVien, DateTime.Parse(NgaySinh), GioiTinh, MaLop, MaKhoa, MaQue);
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

        public void Update(string MaSinhVien, string TenSinhVien, string NgaySinh, int GioiTinh, string MaLop, string MaKhoa, string MaQue)
        {
            if (TenSinhVien != "" && NgaySinh != "" && MaLop != "" && MaKhoa != "" && MaQue != "")
            {
                try
                {
                    sinhvien.Update(MaSinhVien, TenSinhVien, DateTime.Parse(NgaySinh), GioiTinh, MaLop, MaKhoa, MaQue);
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
        private bool CheckTable(string MaSinhVien)
        {
            if (sinhvien.CheckTable(MaSinhVien).Rows.Count > 0)
            {
                return true;
            }
            return false;
        }

        public void Delete(string MaSinhVien)
        {
            try
            {
                sinhvien.Delete(MaSinhVien);
            }
            catch (Exception ex)
            {
                throw new Exception("Bản ghi này có liên quan đên các dữ liệu khác.. Vui lòng xóa các dữ liệu khác trước khi xóa bản ghi này!");
            }
        }

        public DataTable Search(string str)
        {
            return sinhvien.Search(str);
        }

        // Hàm xử lý lấy mã lớp khi sửa
        public string getMaLop(string TenLop)
        {
            string res;
            res = sinhvien.LayMaLop(TenLop).Rows[0]["MaLop"].ToString();
            return res;
        }

        // Hàm xử lý lấy mã khu khi sửa
        public string getMaKhoa(string TenKhoa)
        {
            string res;
            res = sinhvien.LayMaKhoa(TenKhoa).Rows[0]["MaKhoa"].ToString();
            return res;
        }

        // Hàm xử lý lấy mã khu khi sửa
        public string getMaQue(string TenQue)
        {
            string res;
            res = sinhvien.LayMaQue(TenQue).Rows[0]["MaQue"].ToString();
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
                    MaSinhVien = "SV0" + i.ToString();
                }
                else
                {
                    MaSinhVien = "SV" + i.ToString();
                }

                if (CheckTable(MaSinhVien))
                {
                    i++;
                }
                else
                {
                    check = false;
                }
            }

            return MaSinhVien;
        }

        // Hàm lấy danh sách lớp với khoa đã biết
        public DataTable LayDSLop(string MaKhoa)
        {
            return sinhvien.LayLopTuKhoa(MaKhoa);
        }

        
    }
}
