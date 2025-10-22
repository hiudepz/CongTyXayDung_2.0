using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class NguoiDung_DAL
    {
        private static QuanLyXayDungEntities2 db = new QuanLyXayDungEntities2();
        public NguoiDung GetByUser(int id)
        {
            var nd = db.NguoiDungs.FirstOrDefault(u => u.NhanVienID == id);
            return nd;
        }
        public List<NguoiDung_DTO> GetAllUser()
        {
            var list = (from nd in db.NguoiDungs join nv in db.NhanViens on nd.NhanVienID equals nv.NhanVienID
                        select new NguoiDung_DTO
                        {
                            NguoiDungID = nd.NguoiDungID,
                            TenDangNhap = nd.TenDangNhap,
                            MatKhau = nd.MatKhau,
                            VaiTro = nd.VaiTro,
                            NhanVienID = nd.NhanVienID,
                            HoTenNhanVien = nv.HoTen
                        }).ToList();

            return list;
        }

        // New: search users by term (matches username, role or employee name)
        public List<NguoiDung_DTO> SearchUsers(string term)
        {
            if (string.IsNullOrWhiteSpace(term))
                return GetAllUser();

            var t = term.Trim().ToLower();

            var list = (from nd in db.NguoiDungs
                        join nv in db.NhanViens on nd.NhanVienID equals nv.NhanVienID
                        where (nd.TenDangNhap != null && nd.TenDangNhap.ToLower().Contains(t))
                           || (nd.VaiTro != null && nd.VaiTro.ToLower().Contains(t))
                           || (nv.HoTen != null && nv.HoTen.ToLower().Contains(t))
                        select new NguoiDung_DTO
                        {
                            NguoiDungID = nd.NguoiDungID,
                            TenDangNhap = nd.TenDangNhap,
                            MatKhau = nd.MatKhau,
                            VaiTro = nd.VaiTro,
                            NhanVienID = nd.NhanVienID,
                            HoTenNhanVien = nv.HoTen
                        }).ToList();

            return list;
        }

        public void AddUser(NguoiDung nd)
        {
            db.NguoiDungs.Add(nd);
            db.SaveChanges();
        }
        public void UpdateUser(NguoiDung nd)
        {
            var existingUser = db.NguoiDungs.Find(nd.NguoiDungID);
            if (existingUser != null)
            {
                existingUser.TenDangNhap = nd.TenDangNhap;
                existingUser.MatKhau = nd.MatKhau;
                existingUser.VaiTro = nd.VaiTro;
                existingUser.NhanVienID = nd.NhanVienID;
                db.SaveChanges();
            }
        }
        public void DeleteUser(int userId)
        {
            var user = db.NguoiDungs.Find(userId);
            if (user != null)
            {
                db.NguoiDungs.Remove(user);
                db.SaveChanges();
            }
        }

        public object GetByUser()
        {
            throw new NotImplementedException();
        }
    }
}
