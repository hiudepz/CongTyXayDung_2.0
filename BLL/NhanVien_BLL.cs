using DAL;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Policy;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;


namespace BLL
{
    public class NhanVien_BLL
    {
        private static NhanVien_DAL dal = new NhanVien_DAL();
        public List<NhanVien_DTO> Laydanhsachnhanvien()
        {
            
            return dal.GetAll().Select(nv => new NhanVien_DTO
            {
                NhanVienID = nv.NhanVienID,
                HoTen = nv.HoTen,
                Email = nv.Email,
                Phone = nv.Phone,
                VaiTro = nv.VaiTro,
                AnhDaiDien = nv.AnhDaiDien
            }).ToList();
        }
        // Kiểm tra dữ liệu nhập
        private void Validate(NhanVien_DTO nv)
        {
            if (string.IsNullOrWhiteSpace(nv.HoTen))
                throw new ArgumentException("Họ tên không được để trống.");

            if (string.IsNullOrWhiteSpace(nv.Email))
                throw new ArgumentException("Email không được để trống.");

            if (!Regex.IsMatch(nv.Email, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
                throw new ArgumentException("Định dạng email không hợp lệ.");

            if (string.IsNullOrWhiteSpace(nv.Phone))
                throw new ArgumentException("Số điện thoại không được để trống.");

            if (!Regex.IsMatch(nv.Phone, @"^(0|\+84)[0-9]{9,10}$"))
                throw new ArgumentException("Số điện thoại không hợp lệ.");

            if (string.IsNullOrWhiteSpace(nv.VaiTro))
                throw new ArgumentException("Vai trò không được để trống.");
        }

        // Thêm nhân viên
        public void Add(NhanVien_DTO dto)
        {
            Validate(dto);

            if (dal.ExistsEmail(dto.Email, dto.NhanVienID))
                throw new ArgumentException("Email đã tồn tại, vui lòng chọn email khác.");
            if (dal.IsPhoneExists(dto.Phone,dto.NhanVienID))
                throw new ArgumentException("Số điện thoại đã tồn tại.");

            var nv = new NhanVien
            {
                HoTen = dto.HoTen,
                Email = dto.Email,
                Phone = dto.Phone,
                VaiTro = dto.VaiTro,
                AnhDaiDien = dto.AnhDaiDien,
            };

            try
            {
                dal.Add_NV(nv);
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi thêm nhân viên: " + ex.Message, ex);
            }
        }

        //Sửa nhân viên
        public void Edit(NhanVien_DTO dto)
        {
            Validate(dto);

            if (dal.ExistsEmail(dto.Email, dto.NhanVienID))
                throw new ArgumentException("Email đã tồn tại, vui lòng chọn email khác.");
            if (dal.IsPhoneExists(dto.Phone, dto.NhanVienID))
                throw new ArgumentException("Số điện thoại đã tồn tại.");
            var nv = new NhanVien
            {
                NhanVienID = dto.NhanVienID,
                HoTen = dto.HoTen,
                Email = dto.Email,
                Phone = dto.Phone,
                VaiTro = dto.VaiTro,
                AnhDaiDien = dto.AnhDaiDien
            };

            try
            {
                dal.Edit_NV(nv);
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi sửa nhân viên: " + ex.Message, ex);
            }
        }

        //Xóa nhân viên
        public void Delete(int id)
        {
            if (id <= 0)
                throw new ArgumentException("ID nhân viên không hợp lệ.");
            try

            {
                dal.Delete_NV(id);
            }
            catch (System.Data.Entity.Infrastructure.DbUpdateException)
            {
                throw new InvalidOperationException("Không thể xóa nhân viên này vì đang được tham chiếu trong bảng khác (VD: tài khoản, dự án...).");
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi xóa nhân viên: " + ex.Message);
            }
        }

        public List<NhanVien_DTO> TimKiem(string keyword)
        {
            return dal.TimKiem(keyword);
        }

    }
}

