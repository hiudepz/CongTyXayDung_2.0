using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class LuongNV_DTO
    {
        public int BangLuongID { get; set; }
        public int NhanVienID { get; set; }
        public string HoTen { get; set; }
        public int Thang { get; set; }
        public int Nam { get; set; }
        public decimal LuongCoBan { get; set; }
        public decimal Thuong { get; set; }
        public decimal KhauTru { get; set; }
        public decimal PhuCap { get; set; }
        public int NgayCong { get; set; }
        public int GioTangCa { get; set; }

        public decimal TongLuong => LuongCoBan + Thuong - KhauTru + PhuCap;
    }
}
