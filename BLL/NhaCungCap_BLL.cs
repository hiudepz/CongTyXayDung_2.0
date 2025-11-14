using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using DAL;
using DTO;

namespace BLL
{
    public class NhaCungCap_BLL
    {
        private NhaCungCap_DAL dal = new NhaCungCap_DAL();
        public List<NhaCungCap_DTO> GetAllSupplier()
        {
            return dal.GetAllSupplier();
        }
        private void Validate(NhaCungCap_DTO ncc)
        {
            if (ncc == null)
                throw new ArgumentException("Dữ liệu nhà cung cấp không được để trống.");

            if (string.IsNullOrWhiteSpace(ncc.TenNCC))
                throw new ArgumentException("Tên nhà cung cấp không được để trống.");
            if (ncc.TenNCC.Length > 255)
                throw new ArgumentException("Tên nhà cung cấp không được vượt quá 255 ký tự.");

            if (string.IsNullOrWhiteSpace(ncc.Email))
                throw new ArgumentException("Email không được để trống.");
            if (!Regex.IsMatch(ncc.Email, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
                throw new ArgumentException("Định dạng email không hợp lệ.");

            if (string.IsNullOrWhiteSpace(ncc.Phone))
                throw new ArgumentException("Số điện thoại không được để trống.");
            if (!Regex.IsMatch(ncc.Phone, @"^(0|\+84)[0-9]{9,10}$"))
                throw new ArgumentException("Số điện thoại không hợp lệ.");

            if (!string.IsNullOrWhiteSpace(ncc.DiaChi) && ncc.DiaChi.Length > 255)
                throw new ArgumentException("Địa chỉ không được vượt quá 255 ký tự.");

            // Kiểm tra trùng tên / email / sđt
            using (var db = new QuanLyXayDungEntities2())
            {
                if (db.NhaCungCaps.Any(x => x.TenNCC == ncc.TenNCC && x.NhaCungCapID != ncc.NhaCungCapID))
                    throw new ArgumentException("Tên nhà cung cấp đã tồn tại.");

                if (db.NhaCungCaps.Any(x => x.Email == ncc.Email && x.NhaCungCapID != ncc.NhaCungCapID))
                    throw new ArgumentException("Email đã tồn tại.");

                if (db.NhaCungCaps.Any(x => x.Phone == ncc.Phone && x.NhaCungCapID != ncc.NhaCungCapID))
                    throw new ArgumentException("Số điện thoại đã tồn tại.");
            }
        }

        public void Add(NhaCungCap_DTO dto)
        {
            Validate(dto);

            var entity = new NhaCungCap
            {
                TenNCC = dto.TenNCC,
                Email = dto.Email,
                Phone = dto.Phone,
                DiaChi = dto.DiaChi,
                
            };

            try
            {
                dal.Add(entity);
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi thêm nhà cung cấp: " + ex.Message, ex);
            }
        }

        public void Update(NhaCungCap_DTO dto)
        {
            Validate(dto);

            var entity = new NhaCungCap
            {
                NhaCungCapID = dto.NhaCungCapID,
                TenNCC = dto.TenNCC,
                Email = dto.Email,
                Phone = dto.Phone,
                DiaChi = dto.DiaChi,
            };

            try
            {
                dal.Update(entity);
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi cập nhật nhà cung cấp: " + ex.Message, ex);
            }
        }

        public void Delete(int id)
        {
            if (id <= 0)
                throw new ArgumentException("ID nhà cung cấp không hợp lệ.");

            try
            {
                dal.Delete(id);
            }
            catch (System.Data.Entity.Infrastructure.DbUpdateException)
            {
                throw new InvalidOperationException("Không thể xóa nhà cung cấp này vì đang được tham chiếu trong bảng khác (VD: vật tư, hợp đồng...).");
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi xóa nhà cung cấp: " + ex.Message);
            }
        }

        public List<NhaCungCap_DTO> Search(string keyword)
        {
            return dal.Search(keyword);
        }
    }
}
