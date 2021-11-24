using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyKTX
{
    class TrangChu_BLL
    {
        KhuNha.KhuNha_GUI khunha = new KhuNha.KhuNha_GUI();
        ThietBi.ThietBi_GUI thietbi = new ThietBi.ThietBi_GUI();
        Phong.Phong_GUI phong = new Phong.Phong_GUI();
        ThietBi_Phong.ThietBi_Phong_GUI tbi_phong = new ThietBi_Phong.ThietBi_Phong_GUI();
        Khoa.Khoa_GUI khoa = new Khoa.Khoa_GUI();
        Lop.Lop_GUI lop = new Lop.Lop_GUI();
        Que.Que_GUI que = new Que.Que_GUI();
        SinhVien.SinhVien_GUI sinhvien = new SinhVien.SinhVien_GUI();
        User.NhanVien_GUI nhanVien = new User.NhanVien_GUI();
        User.PhanQuyen_GUI phanQuyen = new User.PhanQuyen_GUI();
        TongQuan_GioiThieu.TongQuan_GUI tongquan = new TongQuan_GioiThieu.TongQuan_GUI();
        TrangChu trangChu = new TrangChu();
        HoaDon.HoaDon_GUI HoaDon_GUI = new HoaDon.HoaDon_GUI();
        TimKiem.TimKiem_GUI TimKiem_GUI = new TimKiem.TimKiem_GUI();
        

        public void qlPhong()
        {
            phong.Show();
        }

        public void TimKiem()
        {
            TimKiem_GUI.Show();
        }
       
        public void qlThietBi()
        {
            thietbi.Show();
        }

        public void qlKhuNha()
        {
            khunha.Show();
        }

        public void qlTbiPhong()
        {
            tbi_phong.Show();
        }

        public void qlLop()
        {
            lop.Show();
        }
        public void qlKhoa()
        {
            khoa.Show();
        }
        public void qlQue()
        {
            que.Show();
        }

        public void qlSinhVien()
        {
            sinhvien.Show();
        }

        public void PhanQuyen()
        {
            phanQuyen.Show();
        }
        public void NhanVien()
        {
            nhanVien.Show();
        }

        public void TongQuan()
        {
            tongquan.Show();
        }
        public void qlHoaDon()
        {
            HoaDon_GUI.Show();
        }
    }
}
