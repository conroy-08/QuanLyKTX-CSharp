using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace QuanLyKTX.SinhVien_DatPhong
{
    class SinhVien_ThuePhong_BLL
    {
        SinhVien_ThuePhong_DAL SV_Phong = new SinhVien_ThuePhong_DAL();
        string MaSoThue;

        public DataTable ShowTable()
        {
            return SV_Phong.selectAllTable();
        }

        private bool CheckTable(string MaSoThue)
        {
            if (SV_Phong.checkTable(MaSoThue).Rows.Count > 0)
            {
                return true;
            }
            return false;
        }

        public void Insert(string MaSoThue, string MaSV, string MaPhong, string NgayBD, string NgayKT, string GhiChu, int TinhTrang)
        {
            // Kiểm tra mã thiết bị và phòng có tồn tại hay không
            if (SV_Phong.checkMaSV(MaSV).Rows.Count > 0 && SV_Phong.checkMaPhong(MaPhong).Rows.Count > 0)
            {
                DateTime startDay = Convert.ToDateTime(NgayBD);
                DateTime endDay = Convert.ToDateTime(NgayKT);

                TimeSpan time = endDay.Subtract(startDay);

                if (time.Days > 30)
                {
                    try
                    {
                        SV_Phong.Insert(MaSoThue, MaSV, MaPhong, DateTime.Parse(NgayBD), DateTime.Parse(NgayKT), GhiChu, TinhTrang);
                    }
                    catch (FormatException)
                    {
                        throw new Exception("Vui lòng nhập đúng định dạng");
                    }
                    catch
                    {
                        throw new Exception("Phòng không còn trống");
                    }
                }
                else
                {
                    throw new Exception("Bạn phải thuê phòng ít nhất 1 tháng");
                }
            }
            else
            {
                throw new Exception("Thao tác không thành công!! Hãy xem xét lại");
            }
        }
        public void Update(string MaSoThue, string NgayBD, string NgayKT, string GhiChu, int TinhTrang,string MaPhong)
        {
            DateTime startDay = Convert.ToDateTime(NgayBD);
            DateTime endDay = Convert.ToDateTime(NgayKT);

            TimeSpan time = endDay.Subtract(startDay);

            if (time.Days > 30)
            {
                try
                {
                    SV_Phong.Update(MaSoThue, DateTime.Parse(NgayBD), DateTime.Parse(NgayKT), GhiChu, TinhTrang,MaPhong);
                }
                catch(FormatException)
                {
                    throw new Exception("Vui lòng nhập đúng định dạng");
                }
                catch
                {
                    throw new Exception("Phòng không còn trống");
                }
            }
            else
            {
                throw new Exception("Bạn phải thuê phòng ít nhất 1 tháng");
            }
        }
        public void Delete(string MaSoThue)
        {
            try
            {
                SV_Phong.Delete(MaSoThue);
            }
            catch
            {
                throw new Exception("Việc xóa dữ liệu liên quan đến các bản ghi khác!! Vui lòng xóa các bản ghi đó trước");
            }
           
        }

        public DataTable LayMaPhong()
        {
            return SV_Phong.getMaPhong();
        }
        public DataTable LayMaSoThue()
        {
            return SV_Phong.getMaSoThue();
        }

        public DataTable LayThongTinPhong(string MaPhong)
        {
            return SV_Phong.getInformationPhong(MaPhong);
        }

        public DataTable LayMaSV()
        {
            return SV_Phong.getMaSV();
        }

        public DataTable LayThongTinSV(string MaSV)
        {
            return SV_Phong.getInformationSV(MaSV);
        }

        // Search phòng
        public DataTable Search(string MaSoThue)
        {
            return SV_Phong.checkTable(MaSoThue);
        }


        public string checkId()
        {
            bool check = true;
            int i = 0;
            while (check)
            {
                if (i < 10)
                {
                    MaSoThue = "MST0" + i.ToString();
                }
                else
                {
                    MaSoThue = "MST " + i.ToString();
                }

                if (CheckTable(MaSoThue))
                {
                    i++;
                }
                else
                {
                    check = false;
                }
            }

            return MaSoThue;
        }

    }
}
