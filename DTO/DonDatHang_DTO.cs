using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class DonDatHang_DTO
    {
        public int DonDatHangID { get; set; }
        public int NhaCungCapID { get; set; }
        public string TenNCC { get; set; }
        public int NhanVienID { get; set; }
        public string HoTen { get; set; }
        public System.DateTime NgayDat { get; set; }
        public string TrangThai { get; set; }
    }
}
