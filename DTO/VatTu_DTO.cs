using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class VatTu_DTO
    {
        public int VatTuID { get; set; }
        public string TenVatTu { get; set; }
        public string DonViTinh { get; set; }
        public int? SoLuongTon { get; set; }
        public int? NhaCungCapID { get; set; }
            // optional: supplier name for report
        public byte[] HinhAnhVatTu { get; set; }
        public string TenNhaCungCap { get; set; }
    }
}
