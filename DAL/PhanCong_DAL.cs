using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace DAL
{
    public class PhanCong_DAL
    {
        public List<PhanCong_DTO> GetAll()
        {
            using (var db = new QuanLyXayDungEntities2())
            {
                var list = (from pc in db.PhanCongs
                            join nv in db.NhanViens on pc.NhanVienID equals nv.NhanVienID
                            join da in db.DuAns on pc.DuAnID equals da.DuAnID
                            select new PhanCong_DTO
                            {
                                PhanCongID = pc.PhanCongID,
                                DuAnID = pc.DuAnID,
                                NhanVienID = pc.NhanVienID,
                                NhiemVu = pc.NhiemVu,
                                NgayBatDau = pc.NgayBatDau,
                                NgayKetThuc = pc.NgayKetThuc,
                                TenDuAn = da.TenDuAn,
                                HoTenNV = nv.HoTen
                            }).ToList();
                return list;
            }
        }


        public void Add(PhanCong_DTO pc)
        {
            using (var db = new QuanLyXayDungEntities2())
            {
                var newPC = new PhanCong
                {
                    DuAnID = pc.DuAnID,
                    NhanVienID = pc.NhanVienID,
                    NhiemVu = pc.NhiemVu,
                    NgayBatDau = pc.NgayBatDau,
                    NgayKetThuc = pc.NgayKetThuc
                };
                db.PhanCongs.Add(newPC);
                db.SaveChanges();
            }
        }

        public void Update(PhanCong_DTO pc)
        {
            using (var db = new QuanLyXayDungEntities2())
            {
                var exist = db.PhanCongs.FirstOrDefault(x => x.PhanCongID == pc.PhanCongID);
                if (exist != null)
                {
                    exist.NhanVienID = pc.NhanVienID;
                    exist.NhiemVu = pc.NhiemVu;
                    exist.NgayBatDau = pc.NgayBatDau;
                    exist.NgayKetThuc = pc.NgayKetThuc;
                    db.SaveChanges();
                }
            }
        }

        public void Delete(int id)
        {
            using (var db = new QuanLyXayDungEntities2())
            {
                var pc = db.PhanCongs.FirstOrDefault(x => x.PhanCongID == id);
                if (pc != null)
                {
                    db.PhanCongs.Remove(pc);
                    db.SaveChanges();
                }
            }
        }
        public void DeleteAllByDuAn(int duAnID)
        {
            using (var db = new QuanLyXayDungEntities2())
            {
                var list = db.PhanCongs.Where(x => x.DuAnID == duAnID).ToList();
                foreach (var item in list)
                {
                    db.PhanCongs.Remove(item);
                }
                db.SaveChanges();
            }
        }

        public List<PhanCong_DTO> Search(string keyword)
        {
            keyword = RemoveDiacritics(keyword?.Trim().ToLower() ?? "");

            using (var db = new QuanLyXayDungEntities2())
            {
                var list = (from pc in db.PhanCongs
                            join da in db.DuAns on pc.DuAnID equals da.DuAnID into daGroup
                            from da in daGroup.DefaultIfEmpty()
                            join nv in db.NhanViens on pc.NhanVienID equals nv.NhanVienID into nvGroup
                            from nv in nvGroup.DefaultIfEmpty()
                            select new
                            {
                                pc,
                                TenDuAn = da.TenDuAn,
                                HoTenNV = nv.HoTen
                            })
                            .AsEnumerable()
                            .Where(x =>
                                RemoveDiacritics(x.pc.NhiemVu?.ToLower()).Contains(keyword) ||
                                RemoveDiacritics(x.TenDuAn?.ToLower()).Contains(keyword) ||
                                RemoveDiacritics(x.HoTenNV?.ToLower()).Contains(keyword)
                            )
                            .Select(x => new PhanCong_DTO
                            {
                                PhanCongID = x.pc.PhanCongID,
                                DuAnID = x.pc.DuAnID,
                                NhanVienID = x.pc.NhanVienID,
                                NhiemVu = x.pc.NhiemVu,
                                NgayBatDau = x.pc.NgayBatDau,
                                NgayKetThuc = x.pc.NgayKetThuc,
                                TenDuAn = x.TenDuAn,
                                HoTenNV = x.HoTenNV
                            }).ToList();

                return list;
            }
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
