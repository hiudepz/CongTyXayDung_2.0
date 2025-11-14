using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class PhanCongHopDong_DAL
    {
        private static QuanLyXayDungEntities2 db = new QuanLyXayDungEntities2();

        // Lấy danh sách phân công
        public List<PhanCongHopDong_DTO> GetAll()
        {
            var query = from pc in db.PhanCongHopDongs
                        join hd in db.HopDongs on pc.HopDongID equals hd.HopDongID into hdGroup
                        from hd in hdGroup.DefaultIfEmpty()
                        join nv in db.NhanViens on pc.NhanVienID equals nv.NhanVienID into nvGroup
                        from nv in nvGroup.DefaultIfEmpty()
                        select new PhanCongHopDong_DTO
                        {
                            PhanCongID = pc.PhanCongID,
                            HopDongID = pc.HopDongID,
                            NhanVienID = pc.NhanVienID,
                            VaiTro = pc.VaiTro,
                            TenHopDong = hd != null ? hd.TenHopDong : "(Không có)",
                            HoTenNV = nv != null ? nv.HoTen : "(Không có)"
                        };

            return query.ToList();
        }

        public void Add(PhanCongHopDong pc)
        {
            db.PhanCongHopDongs.Add(pc);
            db.SaveChanges();
        }

        public void Update(PhanCongHopDong pc)
        {
            var entity = db.PhanCongHopDongs.FirstOrDefault(x => x.PhanCongID == pc.PhanCongID);
            if (entity != null)
            {
                entity.HopDongID = pc.HopDongID;
                entity.NhanVienID = pc.NhanVienID;
                entity.VaiTro = pc.VaiTro;
                db.SaveChanges();
            }
        }

        public void Delete(int id)
        {
            var entity = db.PhanCongHopDongs.FirstOrDefault(x => x.PhanCongID == id);
            if (entity != null)
            {
                db.PhanCongHopDongs.Remove(entity);
                db.SaveChanges();
            }
        }

       
            public List<PhanCongHopDong_DTO> Search(string keyword)
            {
                keyword = RemoveDiacritics(keyword.ToLower());

                var data = GetAll();

                var result = data.Where(item =>
                    RemoveDiacritics(item.TenHopDong.ToLower()).Contains(keyword) ||
                    RemoveDiacritics(item.HoTenNV.ToLower()).Contains(keyword) ||
                    RemoveDiacritics(item.VaiTro.ToLower()).Contains(keyword)
                ).ToList();

                return result;
            }
        
        //Hàm bỏ dấu
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
    }
}
