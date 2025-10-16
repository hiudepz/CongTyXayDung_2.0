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
    }
    }