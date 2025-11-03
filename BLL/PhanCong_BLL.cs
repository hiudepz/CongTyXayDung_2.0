using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
namespace BLL
{
    public class PhanCong_BLL
    {
        private readonly PhanCong_DAL dal = new PhanCong_DAL();


        public List<PhanCong_DTO> GetAll()
        {
            return dal.GetAll();
        }

        private void Validate(PhanCong_DTO pc)
        {
            if (pc == null)
            {
                throw new Exception("Dữ liệu phân công không được để trống.");
            }

            if (pc.DuAnID <= 0)
            {
                throw new Exception("Phân công phải thuộc về một dự án hợp lệ.");
            }

            if (pc.NhanVienID <= 0)
            {
                throw new Exception("Phải chọn một nhân viên để phân công.");
            }

            if (string.IsNullOrWhiteSpace(pc.NhiemVu))
            {
                throw new Exception("Nhiệm vụ không được để trống.");
            }

            if (pc.NhiemVu.Length > 255)
            {
                throw new Exception("Nhiệm vụ không được vượt quá 255 ký tự.");
            }

            if (pc.NgayBatDau == default)
            {
                throw new Exception("Ngày bắt đầu không được để trống.");
            }

            if (pc.NgayKetThuc == default)
            {
                throw new Exception("Ngày kết thúc không được để trống.");
            }

            if (pc.NgayKetThuc < pc.NgayBatDau)
            {
                throw new Exception("Ngày kết thúc không thể trước ngày bắt đầu.");
            }

            if (pc.NgayBatDau > DateTime.Now.AddYears(5))
            {
                throw new Exception("Ngày bắt đầu không hợp lệ (không được vượt quá 5 năm kể từ hiện tại).");
            }

            // --- Kiểm tra trùng nhân viên trong cùng dự án ---
            using (var db = new QuanLyXayDungEntities2())
            {
                bool existed = db.PhanCongs.Any(x =>
                    x.DuAnID == pc.DuAnID &&
                    x.NhanVienID == pc.NhanVienID &&
                    x.PhanCongID != pc.PhanCongID);

                if (existed)
                {
                    throw new Exception("Nhân viên này đã được phân công trong dự án này.");
                }
            }
        }

        public void Add(PhanCong_DTO pc)
        {
            try
            {
            Validate(pc);
            dal.Add(pc);
            }
            catch(Exception ex)
            {
                throw new Exception("Lỗi khi thêm phân công: " + ex.Message);
            }
          
        }

        public void Update(PhanCong_DTO pc)
        {
            try
            {

                if (pc.PhanCongID <= 0)
                {
                    throw new ArgumentException("ID không hợp lệ");
                }
                Validate(pc);
                dal.Update(pc);
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi sửa: " + ex.Message);
            }
        }

        public void Delete(int id)
        {
            try
            {
                if (id <= 0)
                    throw new ArgumentException("ID không hợp lệ.");

                dal.Delete(id);
            }
            catch (System.Data.Entity.Infrastructure.DbUpdateException)
            {
                throw new InvalidOperationException("Không thể xóa  vì đang được tham chiếu trong bảng khác.");
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi xóa : " + ex.Message);
            }
        }
        public void DeleteAllByDuAn(int id)
        {
            try
            {
                if (id <= 0)
                    throw new ArgumentException("ID không hợp lệ.");

                dal.DeleteAllByDuAn(id);
            }
            catch (System.Data.Entity.Infrastructure.DbUpdateException)
            {
                throw new InvalidOperationException("Không thể xóa  vì đang được tham chiếu trong bảng khác.");
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi xóa : " + ex.Message);
            }
        }

        public List<PhanCong_DTO> Timkiem(string keyword)
        {
            return dal.Search(keyword);
        }
    }
}
