using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
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
        public NhanVien GetByID(int id)
        {
            return db.NhanViens.FirstOrDefault(nv => nv.NhanVienID == id);
        }
        public void Add_NV(NhanVien nv)
        {
            db.NhanViens.Add(nv);
            db.SaveChanges();
        }

        public void Delete_NV(int id)
        {
            using (var db = new QuanLyXayDungEntities2())
            {
                var nv = db.NhanViens.FirstOrDefault(s => s.NhanVienID == id);
                if (nv != null)
                {
                    try
                    {
                        db.NhanViens.Remove(nv);
                        db.SaveChanges();
                    }
                    catch (System.Data.Entity.Infrastructure.DbUpdateException)
                    {
                        // Ném lỗi ra để GUI xử lý hiển thị thông báo người dùng
                        throw;
                    }
                }
            }
        }

        public void Edit_NV(NhanVien nv)
        {
            var existing = db.NhanViens.FirstOrDefault(x => x.NhanVienID == nv.NhanVienID);
            if (existing != null)
            {
                existing.HoTen = nv.HoTen;
                existing.Email = nv.Email;
                existing.Phone = nv.Phone;
                existing.VaiTro = nv.VaiTro;
                existing.AnhDaiDien = nv.AnhDaiDien;
                db.SaveChanges();
            }
        }
        public List<NhanVien_DTO> TimKiem(string keyword)
        {
            keyword = RemoveDiacritics(keyword.Trim().ToLower());

            return db.NhanViens
                .AsEnumerable() //cần để tránh lỗi ToString()
                .Where(n =>
                    RemoveDiacritics(n.HoTen.ToLower()).Contains(keyword) ||
                    RemoveDiacritics(n.Email.ToLower()).Contains(keyword) ||
                    RemoveDiacritics(n.Phone.ToLower()).Contains(keyword) ||
                    RemoveDiacritics(n.VaiTro.ToLower()).Contains(keyword)
                )
                .Select(n => new NhanVien_DTO
                {
                    NhanVienID = n.NhanVienID,
                    HoTen = n.HoTen,
                    Email = n.Email,
                    Phone = n.Phone,
                    VaiTro = n.VaiTro,
                    AnhDaiDien = n.AnhDaiDien
                })
                .ToList();
        }

        //Hàm loại bỏ dấu tiếng Việt
        private string RemoveDiacritics(string text)
        {
            if (string.IsNullOrEmpty(text))
                return text;

            var normalized = text.Normalize(System.Text.NormalizationForm.FormD);
            var chars = normalized.Where(c =>
                System.Globalization.CharUnicodeInfo.GetUnicodeCategory(c) !=
                System.Globalization.UnicodeCategory.NonSpacingMark
            );

            return new string(chars.ToArray()).Normalize(System.Text.NormalizationForm.FormC);
        }
        public bool IsPhoneExists(string phone, int? excludeID = null)
        {
            using (var db = new QuanLyXayDungEntities2())
            {
                return db.NhanViens.Any(nv => nv.Phone == phone && (excludeID == null || nv.NhanVienID != excludeID));
            }
        }

        public bool ExistsEmail(string email, int? excludeId = null)
        {
            email = email.Trim().ToLower();
            return db.NhanViens.Any(n =>
                n.Email.ToLower() == email &&
                (!excludeId.HasValue || n.NhanVienID != excludeId.Value)
            );
        }
        public bool ExistsImage(byte[] imageBytes, int? excludeId = null)
        {
            if (imageBytes == null || imageBytes.Length == 0)
                return false;

            return db.NhanViens.Any(n =>
                n.AnhDaiDien != null &&
                n.AnhDaiDien.SequenceEqual(imageBytes) &&
                (!excludeId.HasValue || n.NhanVienID != excludeId.Value)
            );
        }


    }
}