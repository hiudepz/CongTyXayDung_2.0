using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class HoaDonThanhToan_DTO
    {
        public int DuAnID { get; set; }
        public string TenDuAn { get; set; }
        public string TenKhachHang { get; set; }
        public string MaHopDong { get; set; }
        public decimal GiaTriHopDong { get; set; }
        public DateTime? NgayKy { get; set; }
        public string ThoiHanThiCong { get; set; }
        public decimal TongTien { get; set; }
        public decimal TienNoTruoc { get; set; }
        public decimal TienThanhToan { get; set; }
        public decimal TienNoSau { get; set; }
        
    }
}
