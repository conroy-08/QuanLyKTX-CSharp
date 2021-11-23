using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace QuanLyKTX.ThietBi_Phong
{
    class ThietBi_Phong_DAL
    {
        DataHelper helper = new DataHelper();

        public DataTable selectAllTable()
        {
            string sql = "exec sp_TbiPhong_All";
            return helper.getTable(sql);
        }

       //Lấy tất cả mã phòng truyền vào combo box

        public DataTable getMaPhong()
        {
            string sql = "exec sp_TbiPhong_MaPhong";
            return helper.getTable(sql);
        }

        //Lấy thông tin phòng mỗi khi người dùng thay đổi lựa chọn trong combobox

        public DataTable getInformationPhong(string MaPhong)
        {
            string sql = "exec sp_TbiPhong_InformationPhong '" + MaPhong + "'";
            return helper.getTable(sql);
        }

        //Lấy mã thiết bị từ proc tThietBi

        public DataTable getMaThietBi()
        {
            string sql = "exec sp_TbiPhong_MaTBi";
            return helper.getTable(sql);
        }

        // Lấy tên tbi

        public DataTable getInformationTbi(string MaThietBi)
        {
            string sql = "exec sp_TbiPhong_InformationTbi '" + MaThietBi + "'";
            return helper.getTable(sql);
        }

        public void Insert(string MaPhong, string MaThietBi, int SoLuong, int TinhTrang)
        {
            string sql = "exec sp_TbiPhong_Insert '" + MaPhong + "',N'" + MaThietBi + "','" + SoLuong + "','" + TinhTrang + "'";
            helper.ExecuteQuery(sql);
        }

        public void Update(string MaPhong, string MaThietBi, int SoLuong, int TinhTrang)
        {
            string sql = "exec sp_TbiPhong_Update '" + MaPhong + "',N'" + MaThietBi + "','" + SoLuong + "','" + TinhTrang + "'";
            helper.ExecuteQuery(sql);
        }

        public void Delete(string MaPhong,string MaThietBi)
        {
            string sql = "exec sp_TbiPhong_Delete '" + MaPhong + "','"+ MaThietBi +"'";
            helper.ExecuteQuery(sql);
        }

        //Kiểm tra phòng tbi đã có chưa
        public DataTable checkTable(string MaPhong,string MaThietBi)
        {
            string sql = "exec sp_TbiPhong_checkTable '" + MaPhong + "','" + MaThietBi + "'";
            return helper.getTable(sql);
        }

        // Kiểm tra thiết bị khi sửa hoặc thêm có hoạt động hay không?
        public DataTable checkMaTB(string MaTB)
        {
            string sql = "exec sp_TbiPhong_checkTBI '" + MaTB + "'";
            return helper.getTable(sql);
        }
    }
}
