using DAL;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class NguoiDung_BLL
    {
        private NguoiDung_DAL nd_dal = new NguoiDung_DAL();
        public NguoiDung_DTO GetByUser(string name, string pass, string role)
        {
            var nd = nd_dal.GetByUser(name, pass, role);
           return nd== null ? null : new NguoiDung_DTO
            {
                NguoiDungID = nd.NguoiDungID,
                TenDangNhap = nd.TenDangNhap,
                MatKhau = nd.MatKhau,
                VaiTro = nd.VaiTro,
                NhanVienID = nd.NhanVienID
            };
        }
        public List<NguoiDung_DTO> GetAllUser()
        {
            
            var nd = nd_dal.GetAllUser();
            return nd;
        }
        public void AddUser(NguoiDung_DTO nd_dto)
        {
            NguoiDung nd = new NguoiDung
            {
                TenDangNhap = nd_dto.TenDangNhap,
                MatKhau = nd_dto.MatKhau,
                VaiTro = nd_dto.VaiTro,
                NhanVienID = nd_dto.NhanVienID
            };
            nd_dal.AddUser(nd);
        }
        public void UpdateUser(NguoiDung_DTO nd_dto)
        {
            NguoiDung nd = new NguoiDung
            {
                NguoiDungID = nd_dto.NguoiDungID,
                TenDangNhap = nd_dto.TenDangNhap,
                MatKhau = nd_dto.MatKhau,
                VaiTro = nd_dto.VaiTro,
                NhanVienID = nd_dto.NhanVienID
            };
            nd_dal.UpdateUser(nd);
        }
        public void DeleteUser(int userId)
        {
            nd_dal.DeleteUser(userId);
        }
    }
}
