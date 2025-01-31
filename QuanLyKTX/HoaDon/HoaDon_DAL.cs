﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace QuanLyKTX.HoaDon
{
    class HoaDon_DAL
    {

        DataHelper dataHelper = new DataHelper();
        string[] name;
        object[] value;
        public DataTable CheckTable(string MaHD)
        {
            string sql = "select MaHD from tPhong_ChiPhi where MaHD = '" + MaHD + "'";
            return dataHelper.getTable(sql);
        }

        public DataTable getAll()
        {
            return dataHelper.GetData("Phong_Chiphi_SelectAll");
        }


        public DataTable findByMaHD(string MaHD)
        {
            name = new string[1];
            value = new object[1];
            name[0] = "@MaHD"; value[0] = MaHD;
            return dataHelper.GetDataByCondition("Phong_Chiphi_Select", name, value, 1);
        }

        public DataTable findByMaPhongAndMaHD(string MaPhong , string MaHD)
        {
            name = new string[2];
            value = new object[2];
            name[0] = "@MaPhong"; value[0] = MaPhong;
            name[1] = "@MaHD"; value[1] = MaHD;
            return dataHelper.GetDataByCondition("Phong_Chiphi_findByMaPhongAndMaHD", name, value, 2);

        }

        public void DAL_insert_HoaDon(string MaPhong , string MaHD , int Thang , int Nam , double TienNha ,double TienDien , double TienNc , double TienVs ,
            double TienPhat, DateTime NgayHetHan,double TongTien , int TrangThai)
        {
            name = new string[12];
            value = new object[12];
            name[0] = "@MaPhong"; value[0] = MaPhong;
            name[1] = "@MaHD"; value[1] = MaHD;
            name[2] = "@Thang"; value[2] = Thang;
            name[3] = "@Nam"; value[3] = Nam;
            name[4] = "@TienNha"; value[4] = TienNha;
            name[5] = "@TienDien"; value[5] = TienDien;
            name[6] = "@TienNuoc"; value[6] = TienNc;
            name[7] = "@TienVeSinh"; value[7] = TienVs;
            name[8] = "@TienPhat"; value[8] = TienPhat;
            name[9] = "@NgayHetHan"; value[9] = NgayHetHan;
            name[10] = "@TongTien"; value[10] = TongTien;
            name[11] = "@TrangThai"; value[11] = TrangThai;
            dataHelper.ExecuteQuery("Phong_Chiphi_Insert", name, value, 12);
        }

        public void DAL_Update_HoaDon(string MaHD ,DateTime NgayDong, double TienDien, double TienNc, double TienVs,
            double TienPhat, double TongTien ,int TrangThai)
        {
            name = new string[8];
            value = new object[8];
            name[0] = "@MaHD"; value[0] = MaHD;
            name[1] = "@NgayDong"; value[1] = NgayDong;
            name[2] = "@TienDien"; value[2] = TienDien;
            name[3] = "@TienNuoc"; value[3] = TienNc;
            name[4] = "@TienVeSinh"; value[4] = TienVs;
            name[5] = "@TienPhat"; value[5] = TienPhat;
            name[6] = "@TongTien"; value[6] = TongTien;
            name[7] = "@TrangThai"; value[7] = TrangThai;
            dataHelper.ExecuteQuery("Phong_Chiphi_Update", name, value, 8);

        }

        public string convertNumberToText(double inputNumber, bool suffix = true)
        {
            string[] unitNumbers = new string[] { "không", "một", "hai", "ba", "bốn", "năm", "sáu", "bảy", "tám", "chín" };
            string[] placeValues = new string[] { "", "nghìn", "triệu", "tỷ" };
            bool isNegative = false;

            string sNumber = inputNumber.ToString("#");
            double number = Convert.ToDouble(sNumber);
            if (number < 0)
            {
                number = -number;
                sNumber = number.ToString();
                isNegative = true;
            }


            int ones, tens, hundreds;

            int positionDigit = sNumber.Length;

            string result = " ";


            if (positionDigit == 0)
                result = unitNumbers[0] + result;
            else
            {

                int placeValue = 0;

                while (positionDigit > 0)
                {

                    tens = hundreds = -1;
                    ones = Convert.ToInt32(sNumber.Substring(positionDigit - 1, 1));
                    positionDigit--;
                    if (positionDigit > 0)
                    {
                        tens = Convert.ToInt32(sNumber.Substring(positionDigit - 1, 1));
                        positionDigit--;
                        if (positionDigit > 0)
                        {
                            hundreds = Convert.ToInt32(sNumber.Substring(positionDigit - 1, 1));
                            positionDigit--;
                        }
                    }

                    if ((ones > 0) || (tens > 0) || (hundreds > 0) || (placeValue == 3))
                        result = placeValues[placeValue] + result;

                    placeValue++;
                    if (placeValue > 3) placeValue = 1;

                    if ((ones == 1) && (tens > 1))
                        result = "một " + result;
                    else
                    {
                        if ((ones == 5) && (tens > 0))
                            result = "lăm " + result;
                        else if (ones > 0)
                            result = unitNumbers[ones] + " " + result;
                    }
                    if (tens < 0)
                        break;
                    else
                    {
                        if ((tens == 0) && (ones > 0)) result = "lẻ " + result;
                        if (tens == 1) result = "mười " + result;
                        if (tens > 1) result = unitNumbers[tens] + " mươi " + result;
                    }
                    if (hundreds < 0) break;
                    else
                    {
                        if ((hundreds > 0) || (tens > 0) || (ones > 0))
                            result = unitNumbers[hundreds] + " trăm " + result;
                    }
                    result = " " + result;
                }
            }
            result = result.Trim();
            if (isNegative) result = "Âm " + result;
            return result + (suffix ? " đồng chẵn" : "");
        }

    }
}
