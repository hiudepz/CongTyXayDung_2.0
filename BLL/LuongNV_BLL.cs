using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;

namespace BLL
{
    public class LuongNV_BLL
    {
        LuongNV_DAL dal = new LuongNV_DAL();
        public void Validate(LuongNV_DTO luong)
        {
            if (luong == null)
            {
                throw new Exception("Dữ liệu lương nhân viên không được để trống.");
            }
            if (luong.NhanVienID <= 0)
            {
                throw new Exception("Mã nhân viên không hợp lệ.");
            }
            if (luong.Thang < 1 || luong.Thang > 12)
            {
                throw new Exception("Tháng không hợp lệ. Vui lòng nhập giá trị từ 1 đến 12.");
            }
            if (luong.Nam == DateTime.Now.Year)
            {
                throw new Exception("Năm không hợp lệ. Vui lòng nhập năm hiện tại.");
            }
            if (luong.LuongCoBan < 0)
            {
                throw new Exception("Lương cơ bản không được âm.");
            }
            if (luong.Thuong < 0)
            {
                throw new Exception("Thưởng không được âm.");
            }
            if (luong.PhuCap < 0)
            {
                throw new Exception("Phụ cấp không được âm.");
            }
            if (luong.KhauTru < 0)
            {
                throw new Exception("Khấu trừ không được âm.");
            }
            if (luong.NgayCong < 0 || luong.NgayCong > 31)
            {
                throw new Exception("Ngày công không hợp lệ. Vui lòng nhập giá trị từ 0 đến 31.");
            }
            if (luong.GioTangCa < 0)
            {
                throw new Exception("Giờ tăng ca không được âm.");
            }
            if(luong.LuongCoBan < luong.KhauTru)
            {
                throw new Exception("Khấu trừ không được lớn hơn lương cơ bản.");
            }
            //Kiểm tra nhân viên chỉ được nhận lương 1 lần mỗi tháng
            using (var db = new QuanLyXayDungEntities2())
            {
                bool existed = db.BangLuongs.Any(x =>
                    x.NhanVienID == luong.NhanVienID &&
                    x.Thang == luong.Thang &&
                    x.Nam == luong.Nam &&
                    x.BangLuongID != luong.BangLuongID  // tránh lỗi khi đang sửa
                );

                if (existed)
                {
                    throw new Exception("Nhân viên này đã có bảng lương trong tháng và năm này.");
                }
            }
        }
        public List<LuongNV_DTO> GetAllLuong()
        {
            try
            {
                return dal.GetAll();
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi lấy dữ liệu lương nhân viên: " + ex.Message);
            }
        }

        public void Add(LuongNV_DTO luong)
        {
            try
            {
                Validate(luong);
                dal.AddLuong(luong);
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi thêm lương nhân viên: " + ex.Message);
            }

        }

        public void Delete(int luong)
        {
            try
            {
                if (luong <= 0)
                    throw new ArgumentException("ID bảng lương không hợp lệ.");

                dal.DeleteLuong(luong);
            }
            catch (System.Data.Entity.Infrastructure.DbUpdateException)
            {
                throw new InvalidOperationException("Không thể xóa bảng lương này vì đang được tham chiếu trong bảng khác.");
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi xóa lương nhân viên: " + ex.Message);
            }
        }
        public void Update(LuongNV_DTO luong)
        {
            try
            {
                if (luong.BangLuongID <= 0)
                {
                    throw new ArgumentException("ID bảng lương không hợp lệ");
                }
                Validate(luong);
                dal.EditLuong(luong);
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi sửa lương nhân viên: " + ex.Message);
            }
        }
        public List<LuongNV_DTO> TimKiem(string keyword)
        {
            try
            {
                return dal.SearchLuong(keyword);

            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi tìm kiếm bảng ghi lương nhân viên: " + ex.Message);
            }
        }
        public LuongNV_DTO GetLuongByID(int id)
        {
            return dal.GetLuongByID(id);
        }

    }
}
