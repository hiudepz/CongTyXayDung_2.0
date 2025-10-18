using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class NguoiDung_DTO
    {
        public int NguoiDungID { get; set; }
        public string TenDangNhap { get; set; }
        public string MatKhau { get; set; }
        public string VaiTro { get; set; }
        public Nullable<int> NhanVienID { get; set; }
        public string HoTenNhanVien { get; set; }
    }
}
