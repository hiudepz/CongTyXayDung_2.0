using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DTO
{
    public class NhanVien_DTO
    {
        public int NhanVienID { get; set; }
        public string HoTen { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string VaiTro { get; set; }
        public byte[] AnhDaiDien { get; set; } // save image in binary form(lưu ảnh dưới dạng nhị phân)
    }
}
