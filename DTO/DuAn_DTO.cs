using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class DuAn_DTO
    {
        public int DuAnID { get; set; }              
        public string TenDuAn { get; set; }          
        public int? KhachHangID { get; set; }        
        public int? HopDongID { get; set; }         
        public DateTime? NgayBatDau { get; set; }    
        public DateTime? NgayKetThuc { get; set; }   
        public string TienDo { get; set; }           // (vd: "40%")
        public byte[] HinhAnhDuAn { get; set; }      // Ảnh (lưu ở dạng byte)

        //Thuộc tính mở rộng — lấy từ JOIN khi hiển thị
        public string TenKhachHang { get; set; }     
        public string TenHopDong { get; set; }      
    }
}
