using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class ThanhToanOrder
    {
        public int DonDatHangID { get; set; }
        public string TenNCC { get; set; }
        public string HoTen {  get; set; }
        public DateTime NgayDat { get; set; }
        public decimal TongTien { get; set; }
        public decimal? TienNo { get; set; }
    }
}
