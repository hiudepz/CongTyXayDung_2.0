using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;

namespace DAL
{
    public class NhaCungCap_DAL
    {
        private static QuanLyXayDungEntities2 db = new QuanLyXayDungEntities2();
        public List<NhaCungCap_DTO> GetAllSupplier()
        {
            var list = ( from ncc in db.NhaCungCaps
                         select new NhaCungCap_DTO
                         {
                             NhaCungCapID = ncc.NhaCungCapID,
                             TenNCC = ncc.TenNCC,
                             Email = ncc.Email,
                             DiaChi = ncc.DiaChi,
                             Phone = ncc.Phone,
                             Logo = ncc.Logo
                         }
                 ).ToList();
            return list;
        }

        public void Add(NhaCungCap dto)
        {
            var entity = new NhaCungCap
            {
                TenNCC = dto.TenNCC,
                Email = dto.Email,
                DiaChi = dto.DiaChi,
                Phone = dto.Phone,
        
            };
            db.NhaCungCaps.Add(entity);
            db.SaveChanges();
        }

        public void Update(NhaCungCap dto)
        {
            var entity = db.NhaCungCaps.FirstOrDefault(x => x.NhaCungCapID == dto.NhaCungCapID);
            if (entity == null) throw new Exception("Không tìm thấy nhà cung cấp!");

            entity.TenNCC = dto.TenNCC;
            entity.Email = dto.Email;
            entity.DiaChi = dto.DiaChi;
            entity.Phone = dto.Phone;
       

            db.SaveChanges();
        }

        public void Delete(int id)
        {
            using (var db = new QuanLyXayDungEntities2())
            {
                var entity = db.NhaCungCaps.FirstOrDefault(x => x.NhaCungCapID == id);
                if (entity == null) throw new Exception("Không tìm thấy nhà cung cấp!");
                db.NhaCungCaps.Remove(entity);
                db.SaveChanges();
            }
        }

        public List<NhaCungCap_DTO> Search(string keyword)
        {
            keyword = RemoveDiacritics(keyword.Trim().ToLower());

            return db.NhaCungCaps
            .AsEnumerable() // chuyển sang IEnumerable để dùng RemoveDiacritics
            .Where(x =>
            RemoveDiacritics(x.TenNCC ?? "").ToLower().Contains(keyword) ||
            RemoveDiacritics(x.Email ?? "").ToLower().Contains(keyword) ||
            RemoveDiacritics(x.Phone ?? "").ToLower().Contains(keyword)
        )
        .Select(x => new NhaCungCap_DTO
        {
            NhaCungCapID = x.NhaCungCapID,
            TenNCC = x.TenNCC,
            Email = x.Email,
            DiaChi = x.DiaChi,
            Phone = x.Phone,
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
    }
}
