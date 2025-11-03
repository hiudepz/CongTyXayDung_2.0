using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace BLL
{
    public class DuAn_BLL
    {
        private readonly DuAn_DAL dal = new DuAn_DAL();

        public List<DuAn_DTO> GetAll() => dal.GetAll();
        private void Validate(DuAn_DTO duan)
        {
            if (duan == null)
            {
                throw new Exception("Dữ liệu dự án không được để trống.");
            }

            if (string.IsNullOrWhiteSpace(duan.TenDuAn))
            {
                throw new Exception("Tên dự án không được để trống.");
            }

            if (duan.TenDuAn.Length > 255)
            {
                throw new Exception("Tên dự án không được vượt quá 255 ký tự.");
            }

            if (!duan.NgayBatDau.HasValue)
            {
                throw new Exception("Ngày bắt đầu không được để trống.");
            }

            if (!duan.NgayKetThuc.HasValue)
            {
                throw new Exception("Ngày kết thúc không được để trống.");
            }

            if (duan.NgayKetThuc < duan.NgayBatDau)
            {
                throw new Exception("Ngày kết thúc không thể trước ngày bắt đầu.");
            }

            if (duan.NgayBatDau > DateTime.Now.AddYears(5))
            {
                throw new Exception("Ngày bắt đầu không hợp lệ (không được vượt quá 5 năm so với hiện tại).");
            }

            if (duan.TienDo != null && duan.TienDo.Length > 100)
            {
                throw new Exception("Tiến độ dự án không được vượt quá 100 ký tự.");
            }

       

            // Kiểm tra trùng tên dự án trong DB (tránh khi sửa chính mình)
            using (var db = new QuanLyXayDungEntities2())
            {
                bool existed = db.DuAns.Any(x =>
                    x.TenDuAn == duan.TenDuAn &&
                    x.DuAnID != duan.DuAnID);

                if (existed)
                {
                    throw new Exception("Tên dự án đã tồn tại trong hệ thống. Vui lòng chọn tên khác.");
                }
            }
        }
        public void Add(DuAn_DTO duan)
        {
            Validate(duan);
            dal.Add(duan);
        }

        public void Update(DuAn_DTO duan)
        {
            Validate(duan);
            dal.Update(duan);
        }

        public void Delete(int id)
        {
            if (id <= 0)
                throw new ArgumentException("ID dự án không hợp lệ.");
            try

            {
                dal.Delete(id);
            }
            catch (System.Data.Entity.Infrastructure.DbUpdateException)
            {
                throw new InvalidOperationException("Không thể xóa dự án này vì đang được tham chiếu trong bảng khác.");
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi xóa dự án: " + ex.Message);
            }
        }

        public List<DuAn_DTO> Search(string keyword) => dal.Search(keyword);

        
        
    }
}

