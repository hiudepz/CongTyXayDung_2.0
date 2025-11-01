using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class PhanCong_DTO
    {
        public int PhanCongID { get; set; }
        public int? DuAnID { get; set; }
        public int? NhanVienID { get; set; }
        public string NhiemVu { get; set; }
        public DateTime? NgayBatDau { get; set; }
        public DateTime? NgayKetThuc { get; set; }

        // Thông tin mở rộng để hiển thị
        public string TenDuAn { get; set; }
        public string HoTenNV { get; set; }
    }
}

