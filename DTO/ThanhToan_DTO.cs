using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class ThanhToan_DTO
    {
        public int ThanhToanID { get; set; }
        public System.DateTime NgayThanhToan { get; set; }
        public decimal SoTien { get; set; }
        public string HinhThuc { get; set; }
        public string GhiChu { get; set; }
        public Nullable<int> DuAnID { get; set; }
        public string TenDuAn { get; set; }
        public Nullable<int> DonDatHangID { get; set; }
        public string TenNCC { get; set; }
        public int NhanVienID { get; set; }
        public string HoTen { get; set; }
        
    }
}
