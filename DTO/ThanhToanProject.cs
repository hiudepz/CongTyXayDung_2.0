using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class ThanhToanProject
    {
        public int DuAnID { get; set; }
        public string TenDuAn { get; set; }
        public string HoTenKH { get; set; }
        public decimal GiaTriHopDong { get; set; }
        public decimal? TienNo { get; set; }
    }
}
