using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class HopDong_DTO
    {
        public int HopDongID { get; set; }
        public string MaHopDong { get; set; }
        public string TenHopDong { get; set; }
        public int KhachHangID { get; set; }
        public int? DuAnID { get; set; }
        public DateTime? NgayKy { get; set; }
        public decimal GiaTriHopDong { get; set; }
        public string NoiDungYeuCau { get; set; }
        public string ThoiHanThiCong { get; set; }
        public string DieuKhoanThanhToan { get; set; }
        public string TrangThai { get; set; }

        // Dữ liệu file hợp đồng (để lưu hoặc tải)
        public byte[] FileHopDong { get; set; }

        // Các trường mở rộng để hiển thị trong DataGridView
        public string TenKhachHang { get; set; }   // join từ bảng KhachHang
        public string TenDuAn { get; set; }
    }
}
