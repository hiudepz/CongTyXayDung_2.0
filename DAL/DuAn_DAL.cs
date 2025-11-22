using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace DAL
{
    public class DuAn_DAL
    {
        public List<DuAn_DTO> GetAll()
        {
            using (var db = new QuanLyXayDungEntities2())
            {
                var list = (from da in db.DuAns
                            join kh in db.KhachHangs on da.KhachHangID equals kh.KhachHangID into khGroup
                            from kh in khGroup.DefaultIfEmpty()
                            join hd in db.HopDongs on da.HopDongID equals hd.HopDongID into hdGroup
                            from hd in hdGroup.DefaultIfEmpty()
                            select new DuAn_DTO
                            {
                                DuAnID = da.DuAnID,
                                TenDuAn = da.TenDuAn,
                                KhachHangID = da.KhachHangID,
                                HopDongID = da.HopDongID,
                                NgayBatDau = da.NgayBatDau,
                                NgayKetThuc = da.NgayKetThuc,
                                TienDo = da.TienDo,
                                HinhAnhDuAn = da.HinhAnhDuAn,
                                TenKhachHang = kh.HoTenKH?? "",
                                TenHopDong = hd.TenHopDong?? ""
                            }).ToList();
                return list;
            }
        }

        public void Add(DuAn_DTO duan)
        {
            using (var db = new QuanLyXayDungEntities2())
            {
                var entity = new DuAn
                {
                    TenDuAn = duan.TenDuAn,
                    KhachHangID = duan.KhachHangID,
                    HopDongID = duan.HopDongID,
                    NgayBatDau = duan.NgayBatDau,
                    NgayKetThuc = duan.NgayKetThuc,
                    TienDo = duan.TienDo,
                    HinhAnhDuAn = duan.HinhAnhDuAn
                };
                db.DuAns.Add(entity);
                db.SaveChanges();
            }
        }

        public void Update(DuAn_DTO duan)
        {
            using (var db = new QuanLyXayDungEntities2())
            {
                var entity = db.DuAns.FirstOrDefault(x => x.DuAnID == duan.DuAnID);
                if (entity == null)
                    throw new Exception("Không tìm thấy dự án cần sửa.");

                entity.TenDuAn = duan.TenDuAn;
                entity.KhachHangID = duan.KhachHangID;
                entity.HopDongID = duan.HopDongID;
                entity.NgayBatDau = duan.NgayBatDau;
                entity.NgayKetThuc = duan.NgayKetThuc;
                entity.TienDo = duan.TienDo;
                entity.HinhAnhDuAn = duan.HinhAnhDuAn;

                db.SaveChanges();
            }
        }

        public void Delete(int id)
        {
            using (var db = new QuanLyXayDungEntities2())
            {
                var entity = db.DuAns.FirstOrDefault(x => x.DuAnID == id);
                if (entity == null)
                    throw new Exception("Không tìm thấy dự án cần xóa.");

                db.DuAns.Remove(entity);
                db.SaveChanges();
            }
        }
        public List<DuAn_DTO> Search(string keyword)
        {
            keyword = RemoveDiacritics(keyword?.Trim().ToLower() ?? "");

            using (var db = new QuanLyXayDungEntities2())
            {
                var list = (from da in db.DuAns
                            join kh in db.KhachHangs on da.KhachHangID equals kh.KhachHangID into khGroup
                            from kh in khGroup.DefaultIfEmpty()
                            join hd in db.HopDongs on da.HopDongID equals hd.HopDongID into hdGroup
                            from hd in hdGroup.DefaultIfEmpty()
                            select new
                            {
                                da,
                                TenKhachHang = da.KhachHang != null ? da.KhachHang.HoTenKH : "(Không có khách hàng)",
                                TenHopDong = da.HopDong != null ? da.HopDong.TenHopDong : "(Không có hợp đồng)"
                            })
                            .AsEnumerable()
                            .Where(x =>
                                RemoveDiacritics(x.da.TenDuAn?.ToLower()).Contains(keyword) ||
                                RemoveDiacritics(x.da.TienDo?.ToLower()).Contains(keyword) ||
                                RemoveDiacritics(x.TenKhachHang?.ToLower()).Contains(keyword) ||
                                RemoveDiacritics(x.TenHopDong?.ToLower()).Contains(keyword)
                            )
                            .Select(x => new DuAn_DTO
                            {
                                DuAnID = x.da.DuAnID,
                                TenDuAn = x.da.TenDuAn,
                                KhachHangID = x.da.KhachHangID,
                                HopDongID = x.da.HopDongID,
                                NgayBatDau = x.da.NgayBatDau,
                                NgayKetThuc = x.da.NgayKetThuc,
                                TienDo = x.da.TienDo,
                                HinhAnhDuAn = x.da.HinhAnhDuAn,
                                TenKhachHang = x.da.KhachHang != null ? x.da.KhachHang.HoTenKH : "",
                                TenHopDong = x.da.HopDong != null ? x.da.HopDong.TenHopDong : ""
                            }).ToList();

                return list;
            }
        }

        //public List<DuAn_DTO> Search(string keyword)
        //{
        //    keyword =  RemoveDiacritics(keyword.Trim().ToLower()?? "");

        //    using (var db = new QuanLyXayDungEntities2())
        //    {
        //        //lấy toàn bộ dữ liệu từ DB
        //        var rawList = (from duan in db.DuAns
        //                       join kh in db.KhachHangs on duan.KhachHangID equals kh.KhachHangID into khGroup
        //                       from khach in khGroup.DefaultIfEmpty()
        //                       join hd in db.HopDongs on duan.HopDongID equals hd.HopDongID into hdGroup
        //                       from hopdong in hdGroup.DefaultIfEmpty()
        //                       select new DuAn_DTO
        //                       {
        //                           DuAnID = duan.DuAnID,
        //                           TenDuAn = duan.TenDuAn,
        //                           KhachHangID = duan.KhachHangID,
        //                           HopDongID = duan.HopDongID,
        //                           TenKhachHang = khach != null ? khach.HoTenKH : "",
        //                           TenHopDong = hopdong != null ? hopdong.TenHopDong : "",
        //                           NgayBatDau = duan.NgayBatDau,
        //                           NgayKetThuc = duan.NgayKetThuc,
        //                           TienDo = duan.TienDo
        //                       }).ToList(); // chuyển sang LINQ to Objects

        //        //lọc bằng hàm C# RemoveDiacritics
        //        var filtered = rawList.Where(x =>
        //            RemoveDiacritics(x.TenDuAn?.ToLower()).Contains(keyword) ||
        //            RemoveDiacritics(x.TienDo?.ToLower()).Contains(keyword)
        //        ).ToList();

        //        return filtered;
        //    }
        //}

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

        public decimal GetTongThanhToan(int duAnID)
        {
            throw new NotImplementedException();
        }
    }
}

