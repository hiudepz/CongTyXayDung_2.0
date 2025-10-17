using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace DAL
{
    public class NhanVien_DAL
    {
        private static QuanLyXayDungEntities2 db = new QuanLyXayDungEntities2();
        public List<NhanVien_DTO> GetAll()
        {
            return db.NhanViens.Select(n => new NhanVien_DTO
            {
                NhanVienID = n.NhanVienID,
                HoTen = n.HoTen,
                Email = n.Email,
                Phone = n.Phone,
                VaiTro = n.VaiTro,
                AnhDaiDien = n.AnhDaiDien
            }).ToList();
        }
        public void Add_NV(NhanVien nv)
        {
            db.NhanViens.Add(nv);
        }
        public void Delete_NV(int id)
        {
            var nv = db.NhanViens.FirstOrDefault(s => s.NhanVienID == id);
            if (nv!=null) // not 
            {
                db.NhanViens.Remove(nv);
                db.SaveChanges();
            }
        }
        public void Edit_NV(NhanVien nv)
        {
            var existing = db.NhanViens.FirstOrDefault(x=>x.NhanVienID == nv.NhanVienID);
            if (existing != null) { 
                existing.HoTen = nv.HoTen;
                existing.Email = nv.Email;
                existing.Phone = nv.Phone;
                existing.VaiTro = nv.VaiTro;
                existing.AnhDaiDien= nv.AnhDaiDien;
                db.SaveChanges() ;
            }
        }
    }
   }