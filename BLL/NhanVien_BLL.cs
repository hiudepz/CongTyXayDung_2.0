using DAL;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Policy;
using System.Text;
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
        public void Add (NhanVien_DTO nv_dto)
        {
            var nv = new NhanVien
            {
                HoTen= nv_dto.HoTen,
                Email= nv_dto.Email,
                Phone= nv_dto.Phone,
                VaiTro= nv_dto.VaiTro,
                AnhDaiDien=nv_dto.AnhDaiDien,
            };
            dal.Add_NV(nv);
        }
        public void Edit(NhanVien nv)
        {
            dal.Edit_NV(nv);
        }
        public void Delete(int id)
        {
            dal.Delete_NV(id);
        }
    }
}

