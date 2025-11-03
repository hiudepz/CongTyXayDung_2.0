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
        public Nullable<int> SoLuongTon { get; set; }
        public Nullable<int> NhaCungCapID { get; set; }
        public byte[] HinhAnhVatTu { get; set; } 
    }
}
