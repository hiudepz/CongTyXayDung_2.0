using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class HopDong_DAL
    {
        private static QuanLyXayDungEntities2 db = new QuanLyXayDungEntities2();

        // Lấy tất cả hợp đồng
        public List<HopDong_DTO> GetAll()
        {
            using (var db = new QuanLyXayDungEntities2())
            {
                var query = from hd in db.HopDongs
                            join kh in db.KhachHangs on hd.KhachHangID equals kh.KhachHangID
                            join da in db.DuAns on hd.DuAnID equals da.DuAnID into duAnTemp
                            from da in duAnTemp.DefaultIfEmpty() // Cho phép null
                            select new HopDong_DTO
                            {
                                HopDongID = hd.HopDongID,
                                MaHopDong = hd.MaHopDong,
                                TenHopDong = hd.TenHopDong,
                                KhachHangID = hd.KhachHangID,
                                DuAnID = hd.DuAnID,
                                NgayKy = hd.NgayKy,
                                GiaTriHopDong = hd.GiaTriHopDong,
                                NoiDungYeuCau = hd.NoiDungYeuCau,
                                ThoiHanThiCong = hd.ThoiHanThiCong,
                                DieuKhoanThanhToan = hd.DieuKhoanThanhToan,
                                TrangThai = hd.TrangThai,
                                FileHopDong = hd.FileHopDong,
                                TenKhachHang = kh.HoTenKH,
                                TenDuAn = da != null ? da.TenDuAn : "Chưa gán"
                            };
                return query.ToList();
            }
        }

        // Thêm hợp đồng
        public void Add(HopDong_DTO hd)
        {
            using (var db = new QuanLyXayDungEntities2())
            {
                var entity = new HopDong
                {
                    MaHopDong = hd.MaHopDong,
                    TenHopDong = hd.TenHopDong,
                    KhachHangID = hd.KhachHangID,
                    DuAnID = hd.DuAnID,
                    NgayKy = hd.NgayKy ?? DateTime.Now,
                    GiaTriHopDong = hd.GiaTriHopDong,
                    NoiDungYeuCau = hd.NoiDungYeuCau,
                    ThoiHanThiCong = hd.ThoiHanThiCong,
                    DieuKhoanThanhToan = hd.DieuKhoanThanhToan,
                    TrangThai = hd.TrangThai,
                    FileHopDong = hd.FileHopDong
                };
                db.HopDongs.Add(entity);
                db.SaveChanges();
            }
        }

        // Cập nhật hợp đồng
        public void Update(HopDong_DTO hd)
        {
            using (var db = new QuanLyXayDungEntities2())
            {
                var existing = db.HopDongs.FirstOrDefault(x => x.HopDongID == hd.HopDongID);
                if (existing != null)
                {
                    existing.MaHopDong = hd.MaHopDong;
                    existing.TenHopDong = hd.TenHopDong;
                    existing.KhachHangID = hd.KhachHangID;
                    existing.DuAnID = hd.DuAnID;
                    existing.NgayKy = hd.NgayKy ?? existing.NgayKy;
                    existing.GiaTriHopDong = hd.GiaTriHopDong;
                    existing.NoiDungYeuCau = hd.NoiDungYeuCau;
                    existing.ThoiHanThiCong = hd.ThoiHanThiCong;
                    existing.DieuKhoanThanhToan = hd.DieuKhoanThanhToan;
                    existing.TrangThai = hd.TrangThai;
                    existing.FileHopDong = hd.FileHopDong;
                    db.SaveChanges();
                }
            }
        }

        // Xóa hợp đồng
        public void Delete(int id)
        {
            using (var db = new QuanLyXayDungEntities2())
            {
                var hopDong = db.HopDongs.FirstOrDefault(x => x.HopDongID == id);
                if (hopDong != null)
                {
                    db.HopDongs.Remove(hopDong);
                    db.SaveChanges();
                }
            }
        }

        // Tìm kiếm hợp đồng
        public List<HopDong_DTO> Search(string keyword)
        {
            keyword = RemoveDiacritics(keyword?.Trim().ToLower() ?? "");

            using (var db = new QuanLyXayDungEntities2())
            {
                var query = from hd in db.HopDongs
                            join kh in db.KhachHangs on hd.KhachHangID equals kh.KhachHangID
                            join da in db.DuAns on hd.DuAnID equals da.DuAnID into duAnTemp
                            from da in duAnTemp.DefaultIfEmpty()
                            where RemoveDiacritics(hd.MaHopDong.ToLower()).Contains(keyword)
                               || RemoveDiacritics(hd.TenHopDong.ToLower()).Contains(keyword)
                               || RemoveDiacritics(hd.TrangThai.ToLower()).Contains(keyword)
                               || RemoveDiacritics(kh.HoTenKH.ToLower()).Contains(keyword)
                               || (da != null && RemoveDiacritics(da.TenDuAn.ToLower()).Contains(keyword))
                            select new HopDong_DTO
                            {
                                HopDongID = hd.HopDongID,
                                MaHopDong = hd.MaHopDong,
                                TenHopDong = hd.TenHopDong,
                                KhachHangID = hd.KhachHangID,
                                DuAnID = hd.DuAnID,
                                NgayKy = hd.NgayKy,
                                GiaTriHopDong = hd.GiaTriHopDong,
                                TrangThai = hd.TrangThai,
                                TenKhachHang = kh.HoTenKH,
                                TenDuAn = da != null ? da.TenDuAn : "Chưa gán"
                            };

                return query.ToList();
            }
        }

        // Hàm loại bỏ dấu tiếng Việt
        private string RemoveDiacritics(string text)
        {
            if (string.IsNullOrEmpty(text))
                return text;

            var normalized = text.Normalize(System.Text.NormalizationForm.FormD);
            var chars = normalized.Where(c =>
                System.Globalization.CharUnicodeInfo.GetUnicodeCategory(c) !=
                System.Globalization.UnicodeCategory.NonSpacingMark);
            return new string(chars.ToArray()).Normalize(System.Text.NormalizationForm.FormC);
        }
    }

}

