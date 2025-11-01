using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
namespace DAL
{
    public class LuongNV_DAL
    {
        private static QuanLyXayDungEntities2 db = new QuanLyXayDungEntities2();
        public List<LuongNV_DTO> GetAll()
        {
            using (var db = new QuanLyXayDungEntities2())
            {


                var query = from bl in db.BangLuongs
                            join nv in db.NhanViens on bl.NhanVienID equals nv.NhanVienID
                            select new LuongNV_DTO
                            {
                                BangLuongID = bl.BangLuongID,
                                NhanVienID = bl.NhanVienID,
                                HoTen = nv.HoTen,
                                Thang = bl.Thang,
                                Nam = bl.Nam,
                                LuongCoBan = bl.LuongCoBan,
                                Thuong = bl.Thuong ?? 0,
                                KhauTru = bl.KhauTru ?? 0,
                                PhuCap = bl.PhuCap ?? 0,
                                NgayCong = bl.NgayCong ?? 0,
                                GioTangCa = bl.GioTangCa ?? 0
                            };
                return query.ToList();
            }
        }
        public void AddLuong (LuongNV_DTO luong)
        {
            BangLuong bl = new BangLuong
            {
                NhanVienID = luong.NhanVienID,
                Thang = luong.Thang,
                Nam = luong.Nam,
                LuongCoBan = luong.LuongCoBan,
                Thuong = luong.Thuong,
                KhauTru = luong.KhauTru,
                PhuCap = luong.PhuCap,
                NgayCong = luong.NgayCong,
                GioTangCa = luong.GioTangCa
            };
            db.BangLuongs.Add(bl);
            db.SaveChanges();
        }
        public void DeleteLuong(int id)
        {
            using (var db = new QuanLyXayDungEntities2())
            {
                var bl = db.BangLuongs.FirstOrDefault(s => s.BangLuongID == id);
                if (bl != null)
                {
                    db.BangLuongs.Remove(bl);
                    db.SaveChanges();
                    //try
                    //{
                    //    db.BangLuongs.Remove(bl);
                    //    db.SaveChanges();
                    //}
                    //catch (System.Data.Entity.Infrastructure.DbUpdateException)
                    //{
                    //    // Ném lỗi ra để GUI xử lý hiển thị thông báo người dùng
                    //    throw;
                    //}
                }
            }
        }

        public void EditLuong(LuongNV_DTO luong)
        {
            var existing = db.BangLuongs.FirstOrDefault(x => x.BangLuongID == luong.BangLuongID);
            if (existing != null)
            {
                existing.NhanVienID = luong.NhanVienID;
                existing.Thang = luong.Thang;
                existing.Nam = luong.Nam;
                existing.LuongCoBan = luong.LuongCoBan;
                existing.Thuong = luong.Thuong;
                existing.KhauTru = luong.KhauTru;
                existing.PhuCap = luong.PhuCap;
                existing.NgayCong = luong.NgayCong;
                existing.GioTangCa = luong.GioTangCa;
                
                db.SaveChanges();
            }
        }
        //Tìm lương theo năm hoặc tháng hoặc tên nhân viên
        public List<LuongNV_DTO> SearchLuong(string keyword)
        {
            using (var db = new QuanLyXayDungEntities2())
            {
                keyword = RemoveDiacritics(keyword?.Trim().ToLower() ?? "");

                var result = db.BangLuongs
                    .AsEnumerable() //cần có để tránh lỗi ToString()
                    .Where(x =>
                        RemoveDiacritics(x.NhanVien.HoTen.ToLower()).Contains(keyword) ||
                        x.Thang.ToString().Contains(keyword) ||
                        x.Nam.ToString().Contains(keyword) ||
                        x.LuongCoBan.ToString().Contains(keyword)
                    )
                    .Select(x => new LuongNV_DTO
                    {
                        BangLuongID = x.BangLuongID,
                        NhanVienID = x.NhanVienID,
                        HoTen = x.NhanVien.HoTen,
                        Thang = x.Thang,
                        Nam = x.Nam,
                        LuongCoBan = x.LuongCoBan,
                        Thuong = x.Thuong??0,
                        PhuCap = x.PhuCap ?? 0,
                        KhauTru = x.KhauTru ?? 0,
                        NgayCong = x.NgayCong ?? 0,
                        GioTangCa = x.GioTangCa ?? 0,
                    })
                    .ToList();

                return result;
            }
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
        public LuongNV_DTO GetLuongByID(int id)
        {
            var result = (from bl in db.BangLuongs
                          join nv in db.NhanViens on bl.NhanVienID equals nv.NhanVienID
                          where bl.BangLuongID == id
                          select new LuongNV_DTO
                          {
                              BangLuongID = bl.BangLuongID,
                              NhanVienID = bl.NhanVienID,
                              HoTen = nv.HoTen,
                              Thang = bl.Thang,
                              Nam = bl.Nam,
                              LuongCoBan = bl.LuongCoBan,
                              Thuong = bl.Thuong??0,
                              KhauTru = bl.KhauTru??0,
                              PhuCap = bl.PhuCap??0,
                              NgayCong = bl.NgayCong??0,
                              GioTangCa = bl.GioTangCa??0
                          }).FirstOrDefault();

            return result;
        }


        //public bool ExistsLuong(int nhanVienId, int thang, int nam, int? excludeBangLuongId = null)
        //{
        //    return db.BangLuongs.Any(bl =>
        //                   bl.NhanVienID == nhanVienId &&
        //                                  bl.Thang == thang &&
        //                                                 bl.Nam == nam &&
        //                                                                (excludeBangLuongId == null || bl.BangLuongID != excludeBangLuongId));
        //}
    }
}
