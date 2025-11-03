using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class Kho_DTO
    {
        public int KhoID { get; set; }
        public Nullable<int> VatTuID { get; set; }
        public string LoaiGiaoDich { get; set; }
        public Nullable<int> SoLuong { get; set; }
        public Nullable<System.DateTime> NgayGiaoDich { get; set; }
        public Nullable<int> DuAnID { get; set; }
        public Nullable<int> DonDatHangID { get; set; }
        public int NhanVienID { get; set; } 
    }
}
