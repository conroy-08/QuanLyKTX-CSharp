using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyKTX.TongQuan_GioiThieu
{
    public partial class TongQuan_GUI : Form
    {
        public TongQuan_GUI()
        {
            InitializeComponent();
        }

        private void TongQuan_GUI_Load(object sender, EventArgs e)
        {
            while (!User.FormLogin.Checked)
            {
                this.Close();
            }

            introduceKTX();
        }
        public void introduceKTX()
        {
            string space = "                 ";
            lblIntroduce.Text = space +" Ban quản lý Ký túc xá được thành lập theo quyết định số 390/QĐ-TC," +
                " ngày 24 tháng 10 năm 1981 của Hiệu Trưởng trường đại học Giao thông Đường sắt và Đường bộ ( hiện nay là trường đại học Giao thông Vận tải ) ." +
                " Ban quản lý Ký túc xá có chức năng giúp Hiệu Trưởng quản lý toàn diện khu Ký túc xá của trường ; tổ chức phục vụ về học tập, sinh hoạt của " +
                " sinh viên được bố trí ở nội trú và đảm bảo trật tự an toàn, vệ sinh, cảnh quan ; tổ chức quản lý, xây dựng, khai thác cơ sở vật chất ;" +
                " tuyên truyền sinh viên nội trú thực hiện tốt nội quy, quy chế ; phối, kết hợp với các phòng ban chức năng của trường, với cơ quan địa phương tổ " +
                " chức những hoạt động văn hoá, thể dục, thể thao, phát thanh tuyên truyền, tham gia các hoạt động xã hội ...xây dựng Ký túc xá trở thành nơi có môi trường giáo dục lành mạnh cho sinh viên ."+
                space + space + space + space + " Hiện nay, Ký túc xá của trường có 03 khối nhà vĩnh cửu từ 4 – 5 tầng với tổng số 214 phòng hoàn toàn có công trình phụ khép kín với súc chứa 1700 sinh viên ." +
                " Trong khu nội trú còn có khu giảng đường phục vụ cho việc học tập và tự học của sinh viên ; câu lạc bộ văn hoá thể thao, sân tập thể thao, phòng máy tính được nối mạng in ternet," +
                " đài truyền thanh nội bộ, trạm Y tế, các quầy dịch vụ phục vụ ăn, uống ; điện, nước ... đáp ứng nhu cầu sinh hoạt của sinh viên nội trú ."+
                space + space + space + space + "     Đội ngũ cán bộ công nhân viên của đơn vị hiện nay gồm 26 người, trong đó trình độ thạc sỹ, đại học, cao đẳng có 12 người . Chi bộ Đảng gồm 08 Đảng viên thực hiện chức năng, " +
                " nhiêm vụ nhà trường giao, triển khai công việc 24/24 giờ trong ngày ."+
                space + "    Trong nhiều năm qua, dưới sự chỉ đạo của Đảng uỷ, ban Giám hiệu và sự phối hợp của các phòng ban chức năng, với sự đoàn kết của tập thể cán bộ công nhân viên trong đơn vị," +
                " Ký túc xá đã được cấp trên trao tặng những phần thưởng cho sự phấn đấu hoàn thành tốt nhiệm vụ nhà Trường giao cho . Phát huy thành tích đã đạt được, tập thể cán bộ công nhân viên của đơn vị" +
                " phấn đấu xây dựng Ký túc xá là nơi có môi trường lành mạnh, cảnh quan, văn hoá ; tạo điều kiện cho sinh viên nội trú yên tâm học tập và rèn luyện.";

            lblDiaChi.Text = " - Địa chỉ: Số 99 - Nguyễn Chí Thanh - P.Láng Hạ - Q.Đống Đa - TP. Hà Nội ";
            lblSdt.Text = "- Điện thoại: 024 3.834246";
        }
    }
}
