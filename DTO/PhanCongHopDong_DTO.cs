using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class PhanCongHopDong_DTO
    {
        public int PhanCongID { get; set; }
        public int HopDongID { get; set; }
        public int NhanVienID { get; set; }
        public string VaiTro { get; set; }

        // Dhiển thị trong DataGridView
        public string TenHopDong { get; set; }
        public string HoTenNV { get; set; }

    }
}
