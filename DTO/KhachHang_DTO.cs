using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class KhachHang_DTO
    {
        public int KhachHangID { get; set; }
        public string HoTenKH { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string DiaChi { get; set; }
        public byte[] AnhDaiDien { get; set; }
    }
}
