
using DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

        namespace DAL
{
    public class ThanhToan_DAL
    {
        private QuanLyXayDungEntities2 db = new QuanLyXayDungEntities2();
        public List<ThanhToan_DTO> GetAllPay()
        {
            var list = (from tt in db.ThanhToans
                        select new ThanhToan_DTO
                        {
                            ThanhToanID = tt.ThanhToanID,
                            NgayThanhToan = tt.NgayThanhToan,
                            SoTien = tt.SoTien,
                            HinhThuc = tt.HinhThuc,
                            GhiChu = tt.GhiChu,
                            DuAnID = tt.DuAnID,
                            TenDuAn = tt.DuAn != null ? tt.DuAn.TenDuAn : null,
                            DonDatHangID = tt.DonDatHangID,
                            TenNCC = tt.DonDatHang != null && tt.DonDatHang.NhaCungCap != null ? tt.DonDatHang.NhaCungCap.TenNCC : null,
                            NhanVienID = tt.NhanVienID,
                            HoTen = tt.NhanVien != null ? tt.NhanVien.HoTen : null,
                        }).ToList();
            return list;
        }
        public ThanhToan GetByID(int id)
        {
            var tt = db.ThanhToans.FirstOrDefault(t => t.ThanhToanID == id);
            return tt;
        }
        public void Add(ThanhToan tt)
        {
            db.ThanhToans.Add(tt);
            db.SaveChanges();
        }
        public void Delete(int id)
        {
            var existingPay = db.ThanhToans.FirstOrDefault(t => t.ThanhToanID == id);
            if (existingPay != null)
            {
                db.ThanhToans.Remove(existingPay);
                db.SaveChanges();
            }
        }
        public void UpdatePay(ThanhToan tt)
        {
            var existingPay = db.ThanhToans.FirstOrDefault(t => t.ThanhToanID == tt.ThanhToanID);
            if (existingPay != null)
            {
                existingPay.NgayThanhToan = tt.NgayThanhToan;
                existingPay.SoTien = tt.SoTien;
                existingPay.HinhThuc = tt.HinhThuc;
                existingPay.GhiChu = tt.GhiChu;
                existingPay.DuAnID = tt.DuAnID;
                existingPay.DonDatHangID = tt.DonDatHangID;
                existingPay.NhanVienID = tt.NhanVienID;
                db.SaveChanges();
            }
        }
        public List<ThanhToan_DTO> SearchPays(string term)
        {
            // 1. Kiểm tra đầu vào trống
            if (string.IsNullOrWhiteSpace(term))
                return GetAllPay();

            // 2. Chuẩn hóa từ khóa tìm kiếm
            var t = term.Trim().ToLower();

            // 3. Lấy dữ liệu nguồn
            var allPays = GetAllPay();

            // 4. Lọc dữ liệu (Mapping theo DB QuanLyXayDung)
            var filteredPays = allPays.Where(p =>
                // a. Tìm theo tên Nhân viên thu/chi
                (p.HoTen != null && p.HoTen.ToLower().Contains(t)) ||

                // b. Tìm theo Ghi chú (Nội dung thanh toán)
                (p.GhiChu != null && p.GhiChu.ToLower().Contains(t)) ||

                // c. Tìm theo Hình thức (Tiền mặt, Chuyển khoản)
                (p.HinhThuc != null && p.HinhThuc.ToLower().Contains(t)) ||

                // d. Tìm theo Ngày thanh toán (Format ngày tháng để so sánh chuỗi)
                p.NgayThanhToan.ToString("dd/MM/yyyy").Contains(t) ||

                // e. Logic quan trọng: Tìm Dự án HOẶC Nhà Cung Cấp
                // Nếu thanh toán cho Dự án -> Tìm tên dự án
                (p.TenDuAn != null && p.TenDuAn.ToLower().Contains(t)) ||

                // Nếu thanh toán cho Đơn hàng -> Tìm tên Nhà cung cấp
                (p.TenNCC != null && p.TenNCC.ToLower().Contains(t)) ||

                // f. Tìm theo Số tiền (Chuyển số sang chuỗi để tìm gần đúng)
                p.SoTien.ToString().Contains(t)

            ).ToList();

            return filteredPays;
        }
        public List<ThanhToanOrder> LayDanhSachDonDatHang()
        {
            
                var list = (from ddh in db.DonDatHangs
                            select new ThanhToanOrder
                            {
                                DonDatHangID = ddh.DonDatHangID,
                                TenNCC = ddh.NhaCungCap.TenNCC,
                                HoTen = ddh.NhanVien.HoTen,
                                NgayDat = ddh.NgayDat,
                                TongTien = db.ChiTietDonDatHangs
                                             .Where(c => c.DonDatHangID == ddh.DonDatHangID)
                                             .Sum(c => (decimal?)c.SoLuong * c.DonGia) ?? 0,
                                TienNo = ddh.ChiTietDonDatHangs.Sum(c => (decimal)c.SoLuong * c.DonGia)
                                   - (db.ThanhToans.Where(t => t.DonDatHangID == ddh.DonDatHangID)
                           .Sum(t => (decimal?)t.SoTien) ?? 0)
                            }).ToList();

                return list;
        }
        public List<ThanhToanProject> LayDanhSachDuAn()
        {
            
            var list = (from da in db.DuAns
                            select new ThanhToanProject
                            {
                                DuAnID = da.DuAnID,
                                TenDuAn = da.TenDuAn,
                                HoTenKH = da.KhachHang.HoTenKH,
                                GiaTriHopDong = da.HopDong != null ? da.HopDong.GiaTriHopDong : 0,
                                TienNo = da.HopDong.GiaTriHopDong -
                                    (db.ThanhToans.Where(t => t.DuAnID == da.DuAnID)
                              .Sum(t => (decimal?)t.SoTien) ?? 0)
                            }).ToList();

                return list;
            
        }

        public (decimal TongTien, decimal TienNo) GetTienDuAn(int duAnID)
        {
            using (var db = new QuanLyXayDungEntities2())
            {
                var hopDong = db.HopDongs.FirstOrDefault(h => h.DuAnID == duAnID);
                decimal tongTien = hopDong?.GiaTriHopDong ?? 0;

                decimal daThanhToan = db.ThanhToans
                    .Where(t => t.DuAnID == duAnID)
                    .Sum(t => (decimal?)t.SoTien) ?? 0;

                decimal tienNo = tongTien - daThanhToan;

                return (tongTien, tienNo);
            }
        }
        public (decimal TongTien, decimal TienNo) GetTienDonDatHang(int ddhID)
        {
            using (var db = new QuanLyXayDungEntities2())
            {
                decimal tongTien = db.ChiTietDonDatHangs
                    .Where(c => c.DonDatHangID == ddhID)
                    .Sum(c => (decimal?)(c.SoLuong * c.DonGia)) ?? 0;

                decimal daThanhToan = db.ThanhToans
                    .Where(t => t.DonDatHangID == ddhID)
                    .Sum(t => (decimal?)t.SoTien) ?? 0;

                decimal tienNo = tongTien - daThanhToan;

                return (tongTien, tienNo);
            }
        }
        public ThanhToan GetThanhToanByID(int id)
        {
            return db.ThanhToans
                     .Include("DuAn")
                     .Include("KhachHang")
                     .FirstOrDefault(x => x.ThanhToanID == id);
        }
        public HoaDonThanhToan_DTO GetThongTinHoaDon(int? duAnID, decimal soTienThanhToan)
        {
            using (var db = new QuanLyXayDungEntities2())
            {
                var da = db.DuAns.Find(duAnID);
                var hd = da.HopDong;
                var kh = da.KhachHang;

                decimal tongTien = hd?.GiaTriHopDong ?? 0;

                decimal daThanhToan = db.ThanhToans
                    .Where(t => t.DuAnID == duAnID)
                    .Sum(t => (decimal?)t.SoTien ?? 0);

                decimal tienNoTruoc = tongTien - daThanhToan;
                decimal tienNoSau = tienNoTruoc - soTienThanhToan;
                
               
                return new HoaDonThanhToan_DTO
                {
                    DuAnID = da.DuAnID,
                    TenDuAn = da.TenDuAn,
                    TenKhachHang = kh.HoTenKH,
                    MaHopDong = hd?.MaHopDong,
                    GiaTriHopDong = tongTien,
                    NgayKy = hd?.NgayKy,
                    ThoiHanThiCong = hd?.ThoiHanThiCong,
                    TongTien = tongTien,
                    TienNoTruoc = tienNoTruoc,
                    TienThanhToan = soTienThanhToan,
                    TienNoSau = tienNoSau,

                };
            }
        }
        public DataTable GetLichSuThanhToan(int duAnID)
        {
            using (var db = new QuanLyXayDungEntities2())
            {
                var list= db.ThanhToans
                    .Where(t => t.DuAnID == duAnID)
                    .Select(t => new LichSuThanhToan_DTO
                    {
                        NgayThanhToan = t.NgayThanhToan,
                        SoTien = t.SoTien,
                        NhanVien = t.NhanVien.HoTen
                    }).ToList();
                return KhachHang_DAL.ConvertToDataTable(list);
            }
        }


    }
}
