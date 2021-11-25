using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace QuanLyKTX.SinhVien_TraPhong
{
    class SinhVien_TraPhong_BLL
    {
        SinhVien_TraPhong_DAL TraPhong = new SinhVien_TraPhong_DAL();

        public DataTable ShowTable()
        {
            return TraPhong.selectAllTable();
        }

        public void Insert(string MaSoThue, string NgayTra, string TienViPham)
        {
            if (NgayTra != "")
            {
                if (checkThoiGian(NgayTra, MaSoThue))
                {
                    try
                    {
                        if (TienViPham == "")
                        {
                            TraPhong.Insert(MaSoThue, DateTime.Parse(NgayTra), 0);
                        }
                        else TraPhong.Insert(MaSoThue, DateTime.Parse(NgayTra), double.Parse(TienViPham));
                    }
                    catch
                    {
                        throw new Exception("Vui lòng nhập đúng định dạng");
                    }
                }
                else
                {
                    throw new Exception("Ngày trả không hợp lệ!! Chú ý ngày trả phải sau ngày bắt đầu thuê và trước ngày hết hạn");
                }      
            }
            else
            {
                throw new Exception("Vui lòng điền đầy đủ thông tin");
            }
        }

        public void Update(string MaSoThue, string NgayTra, string TienViPham)
        {
            if (NgayTra != "")
            {
                if (checkThoiGian(NgayTra, MaSoThue))
                {
                    try
                    {
                        if (TienViPham == "")
                        {
                            TraPhong.Update(MaSoThue, DateTime.Parse(NgayTra), 0);
                        }
                        else
                        {
                            TraPhong.Update(MaSoThue, DateTime.Parse(NgayTra), double.Parse(TienViPham));
                        }
                   
                    }
                    catch
                    {
                        throw new Exception("Vui lòng nhập đúng định dạng");
                    }
                }
                else
                {
                    throw new Exception("Ngày trả không hợp lệ!! Chú ý ngày trả phải sau ngày bắt đầu thuê và trước ngày hết hạn");
                }
            }
            else
            {
                throw new Exception("Vui lòng điền đầy đủ thông tin");
            }
        }

        private bool checkThoiGian(string NgayTra,string MST)
        {

            DateTime pDay = Convert.ToDateTime(NgayTra);
            DateTime startDay = Convert.ToDateTime(TraPhong.getThoiGianThue(MST).Rows[0]["NgayBatDau"].ToString());
            DateTime endDay = Convert.ToDateTime(TraPhong.getThoiGianThue(MST).Rows[0]["NgayKetThuc"].ToString());

            TimeSpan time1 = pDay.Subtract(startDay);
            TimeSpan time2 = pDay.Subtract(endDay);

            if (time1.Days < 0)
            {
                //throw new Exception("Thời gian trả phòng phải sau thời gian bắt đầu thuê");
                return false;
            }
            else
            {
                if (time2.Days > 0)
                {
                    //throw new Exception("Ngày trả phải trước ngày hết hạn hợp đồng");
                    return false;
                }
                return true;
            }
            
        }

        public void Delete(string MaKhuNha)
        {
            TraPhong.Delete(MaKhuNha);
        }

        public DataTable Search(string str)
        {
            return TraPhong.Search(str);
        }

        // Hàm kiểm tra xem Khu nhà tồn tại hay chưa
        private bool checkMaSoThue(string MaKhuNha)
        {
            if (TraPhong.CheckMaSoThue(MaKhuNha).Rows.Count > 0)
            {
                return true;
            }
            return false;
        }

        public DataTable LayMaSoThue()
        {
            return TraPhong.getMaSoThue();
        }
        public DataTable LayMaSoThue1()
        {
            return TraPhong.getMaSoThue1();
        }
        public DataTable LayMaSoThue2(string MST)
        {
            return TraPhong.getMaSoThue2(MST);
        }
    }
}
