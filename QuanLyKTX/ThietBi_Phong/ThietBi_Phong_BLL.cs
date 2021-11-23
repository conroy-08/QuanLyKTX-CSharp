using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace QuanLyKTX.ThietBi_Phong
{
    class ThietBi_Phong_BLL
    {
        ThietBi_Phong_DAL tbi_phong = new ThietBi_Phong_DAL();

        public DataTable ShowTable()
        {          
                 return tbi_phong.selectAllTable();           
        }

        public void Insert(string MaPhong,string MaThietBi,string SoLuong,int TrangThai)
        {
            if (tbi_phong.checkMaTB(MaThietBi).Rows.Count > 0)
            {
                if (CheckTable(MaPhong, MaThietBi))
                {
                    throw new Exception($"Đã thêm Mã thiết bị {MaThietBi} cho phòng {MaPhong}");
                }
                else
                {
                    try
                    {
                        tbi_phong.Insert(MaPhong, MaThietBi, int.Parse(SoLuong), TrangThai);
                    }
                    catch (FormatException ex)
                    {
                        throw new Exception("Vui lòng nhập đúng định dạng");
                    }
                }
            }
            else
            {
                throw new Exception("Thao tác không thành công!! Có thể do bạn đã chọn mã thiết bị không hoạt động hoặc bạn chưa chọn mã thiết bị..");
            }
        }

        public void Update(string MaPhong, string MaThietBi, string SoLuong, int TrangThai)
        {
            try
            {
                tbi_phong.Update(MaPhong, MaThietBi, int.Parse(SoLuong), TrangThai);
            }
            catch(FormatException ex)
            {
                throw new Exception("Vui lòng nhập đúng định dạng");
            }
        }

        public void Delete (string MaPhong, string MaThietBi)
        {
            tbi_phong.Delete(MaPhong, MaThietBi);
        }

        public DataTable LayMaPhong()
        {
            return tbi_phong.getMaPhong();
        }

        public DataTable LayThongTinPhong(string MaPhong)
        {        
                return tbi_phong.getInformationPhong(MaPhong);         
        }

        public DataTable LayMaThietBi()
        {
            return tbi_phong.getMaThietBi();
        }

        public DataTable LayThongTinThietBi(string MaThietBi)
        {
            return tbi_phong.getInformationTbi(MaThietBi);
        }

        private bool CheckTable(string MaPhong,string MaThietBi)
        {
            if (tbi_phong.checkTable(MaPhong, MaThietBi).Rows.Count>0)
            {
                return true;
            }
            return false;
        }

        // Search phòng
        public DataTable Search(string MaPhong,string MaThietBi)
        {
            return tbi_phong.checkTable(MaPhong, MaThietBi);
        }
    }
}
