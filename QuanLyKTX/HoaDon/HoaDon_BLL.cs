using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
namespace QuanLyKTX.HoaDon
{
    class HoaDon_BLL
    {
        HoaDon_DAL HoaDon_DAL = new HoaDon_DAL();
        public bool CheckTable(string MaHD)
        {
            if (HoaDon_DAL.CheckTable(MaHD).Rows.Count > 0)
            {
                return true;
            }
            return false;
        }
        public void BLL_insert_HoaDon(string MaPhong, string MaHD, DateTime NgayLapHoaDon, double TienNha,double TienDien, double TienNc, double TienVs,
            double TienPhat, double TongTien, int TrangThai)
        {
            HoaDon_DAL.DAL_insert_HoaDon(MaPhong, MaHD, NgayLapHoaDon,TienNha, TienDien, TienNc, TienVs, TienPhat, TongTien, TrangThai);
        }

        public void BLL_Update_HoaDon(string MaHD ,DateTime NgayDong, double TienDien, double TienNc, double TienVs,
            double TienPhat, double TongTien, int TrangThai)
        {
            HoaDon_DAL.DAL_Update_HoaDon(MaHD, NgayDong, TienDien, TienNc, TienVs, TienPhat, TongTien, TrangThai);
        }
        public DataTable findByMaHD(string MaHD)
        {
            return HoaDon_DAL.findByMaHD(MaHD);
        }

        public DataTable getAll()
        {
            return HoaDon_DAL.getAll();
        }

        public string convertNumberToText(double inputNumber, bool suffix = true)
        {
            return HoaDon_DAL.convertNumberToText(inputNumber, suffix);
        }

    }
}
