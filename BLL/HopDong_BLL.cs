using DAL;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class HopDong_BLL
    {
        private HopDong_DAL dal = new HopDong_DAL();

        //Kiểm tra dữ liệu hợp đồng
        public void Validate(HopDong_DTO hd)
        {
            if (hd == null)
                throw new Exception("Dữ liệu hợp đồng không được để trống.");

            if (string.IsNullOrWhiteSpace(hd.MaHopDong))
                throw new Exception("Số hợp đồng không được để trống.");

            if (string.IsNullOrWhiteSpace(hd.TenHopDong))
                throw new Exception("Tên hợp đồng không được để trống.");

            if (hd.KhachHangID <= 0)
                throw new Exception("Vui lòng chọn khách hàng.");

            if (hd.GiaTriHopDong < 0)
                throw new Exception("Giá trị hợp đồng không được âm.");

            if (hd.NgayKy != null && hd.NgayKy > DateTime.Now)
                throw new Exception("Ngày ký không được lớn hơn ngày hiện tại.");

            using (var db = new QuanLyXayDungEntities2())
            {
                bool existed = db.HopDongs.Any(x =>
                    x.MaHopDong == hd.MaHopDong &&
                    x.HopDongID != hd.HopDongID // tránh lỗi khi cập nhật
                );

                if (existed)
                    throw new Exception("Số hợp đồng đã tồn tại.");
            }
        }

        // Lấy danh sách hợp đồng
        public List<HopDong_DTO> GetAllHopDong()
        {
            try
            {
                return dal.GetAll();
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi lấy danh sách hợp đồng: " + ex.Message);
            }
        }

        // Thêm hợp đồng
        public void Add(HopDong_DTO hd)
        {
            try
            {
                Validate(hd);
                dal.Add(hd);
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi thêm hợp đồng: " + ex.Message);
            }
        }

        // Cập nhật hợp đồng
        public void Update(HopDong_DTO hd)
        {
            try
            {
                if (hd.HopDongID <= 0)
                    throw new Exception("ID hợp đồng không hợp lệ.");

                Validate(hd);
                dal.Update(hd);
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi cập nhật hợp đồng: " + ex.Message);
            }
        }

        // Xóa hợp đồng
        public void Delete(int hopDongID)
        {
            try
            {
                if (hopDongID <= 0)
                    throw new Exception("ID hợp đồng không hợp lệ.");

                dal.Delete(hopDongID);
            }
            catch (System.Data.Entity.Infrastructure.DbUpdateException)
            {
                throw new InvalidOperationException("Không thể xóa hợp đồng này vì đang được tham chiếu trong bảng khác.");
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi xóa hợp đồng: " + ex.Message);
            }
        }

        // Tìm kiếm hợp đồng
        public List<HopDong_DTO> TimKiem(string keyword)
        {
            try
            {
                return dal.Search(keyword);
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi tìm kiếm hợp đồng: " + ex.Message);
            }
        }

        // Lấy hợp đồng theo ID (nếu cần mở form chi tiết)
        public HopDong_DTO GetHopDongByID(int id)
        {
            try
            {
                var list = dal.GetAll();
                return list.FirstOrDefault(x => x.HopDongID == id);
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi lấy hợp đồng theo ID: " + ex.Message);
            }
        }
    }
}
