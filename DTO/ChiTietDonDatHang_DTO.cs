using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class ChiTietDonDatHang_DTO
    {
        public int ChiTietID { get; set; }
        public int DonDatHangID { get; set; }
        public int VatTuID { get; set; }
        public string TenVatTu { get; set; }
        public int SoLuong { get; set; }
        public decimal DonGia { get; set; }
    }
}
