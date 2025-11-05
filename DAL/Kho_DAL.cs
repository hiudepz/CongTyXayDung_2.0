using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class Kho_DAL
    {
        private static QuanLyXayDungEntities2 db = new QuanLyXayDungEntities2();
        public void AddToWareHouse(int donDatHangID, int nhanVienID)
        {
            
            var chiTietList = db.ChiTietDonDatHangs.Where(ct => ct.DonDatHangID == donDatHangID).ToList();
            foreach (var chiTiet in chiTietList)
            {
                //Ghi lai lich su nhap kho
                var kho = new Kho
                {
                    VatTuID = chiTiet.VatTuID,
                    LoaiGiaoDich = "Nhập",
                    SoLuong = chiTiet.SoLuong,
                    NgayGiaoDich = DateTime.Now,
                    DonDatHangID = donDatHangID,
                    NhanVienID = nhanVienID,
                };
                db.Khoes.Add(kho);

                //Cập nhật tồn kho
                var vt = db.VatTus.FirstOrDefault(v => v.VatTuID == chiTiet.VatTuID);
                if (vt != null)
                {
                    vt.SoLuongTon += chiTiet.SoLuong;
                }
            }


            //cập nhật trạng thái đơn đặt hàng
            var ddh = db.DonDatHangs.FirstOrDefault(d => d.DonDatHangID == donDatHangID);
            if (ddh != null)
            {
                ddh.TrangThai = "Đã Nhập Kho";
            }
            db.SaveChanges();
        }
        public List<Kho_DTO> GetAllWareHouseRecords()
        {
            var list = (from k in db.Khoes
                        select new Kho_DTO
                        {
                            KhoID = k.KhoID,
                            DonDatHangID = k.DonDatHangID,
                            VatTuID = k.VatTuID,
                            TenVatTu = k.VatTu.TenVatTu,
                            LoaiGiaoDich = k.LoaiGiaoDich,
                            SoLuong = k.SoLuong,
                            NgayGiaoDich = k.NgayGiaoDich,
                            DuAnID = k.DuAn.DuAnID,
                            TenDuAn = k.DuAn.TenDuAn,
                            NhanVienID = k.NhanVienID,
                            TenNhanVien = k.NhanVien.HoTen,
                        }
                 ).ToList();
            return list;
        }

        //loc don hang nhap / xuat
        public List<Kho_DTO> FilterWarehouseRecords(bool nhap, bool xuat)
        {
            var query = db.Khoes.AsQueryable();
            if (nhap && !xuat)
                query = query.Where(k => k.LoaiGiaoDich == "Nhập");
            else if (!nhap && xuat)
                query = query.Where(k => k.LoaiGiaoDich == "Xuất");
            // Nếu cả hai đều true hoặc false => không lọc, lấy tất cả

            return query.Select(k => new Kho_DTO
            {
                KhoID = k.KhoID,
                DonDatHangID = k.DonDatHangID,
                VatTuID = k.VatTuID,
                TenVatTu = k.VatTu.TenVatTu,
                SoLuong = k.SoLuong,
                LoaiGiaoDich = k.LoaiGiaoDich,
                NgayGiaoDich = k.NgayGiaoDich,
                NhanVienID = k.NhanVienID,
                TenNhanVien = k.NhanVien.HoTen
            }).ToList();
        }
        public bool XuatKho(int vatTuID, int soLuongXuat, int nhanVienID, int duAnID)
        {
            var vatTu = db.VatTus.FirstOrDefault(v => v.VatTuID == vatTuID);
            if (vatTu == null || vatTu.SoLuongTon < soLuongXuat)
            {
                throw new Exception("Không đủ hàng để xuất kho ");
            }
            // Ghi lại lịch sử xuất kho
            var kho = new Kho
            {
                VatTuID = vatTuID,
                LoaiGiaoDich = "Xuất",
                SoLuong = soLuongXuat,
                NgayGiaoDich = DateTime.Now,
                DuAnID = duAnID,
                NhanVienID = nhanVienID,
            };
            db.Khoes.Add(kho);
            // Cập nhật tồn kho
            vatTu.SoLuongTon -= soLuongXuat;
            db.SaveChanges();
            return true;
        }

        // Tìm kiếm kho với các bộ lọc linh hoạt:
        // keyword tìm theo tên vật tư, tên nhân viên, hoặc loại giao dịch (case-insensitive)
        // fromDate / toDate để lọc theo khoảng ngày giao dịch (inclusive)
        // loaiGiaoDich nếu != null thì chỉ lấy loại tương ứng ("Nhập" hoặc "Xuất")
        public List<Kho_DTO> Search(string keyword = null, DateTime? fromDate = null, DateTime? toDate = null, string loaiGiaoDich = null)
        {
            var query = db.Khoes.AsQueryable();

            if (!string.IsNullOrWhiteSpace(keyword))
            {
                var lower = keyword.Trim().ToLower();
                query = query.Where(k =>
                    (k.VatTu != null && k.VatTu.TenVatTu != null && k.VatTu.TenVatTu.ToLower().Contains(lower)) ||
                    (k.NhanVien != null && k.NhanVien.HoTen != null && k.NhanVien.HoTen.ToLower().Contains(lower)) ||
                    (k.LoaiGiaoDich != null && k.LoaiGiaoDich.ToLower().Contains(lower))
                );
            }

            if (!string.IsNullOrWhiteSpace(loaiGiaoDich))
            {
                query = query.Where(k => k.LoaiGiaoDich == loaiGiaoDich);
            }

            if (fromDate.HasValue)
            {
                var start = fromDate.Value.Date;
                query = query.Where(k => k.NgayGiaoDich >= start);
            }

            if (toDate.HasValue)
            {
                // include the whole toDate day
                var end = toDate.Value.Date.AddDays(1).AddTicks(-1);
                query = query.Where(k => k.NgayGiaoDich <= end);
            }

            return query.OrderBy(k => k.KhoID)
                        .Select(k => new Kho_DTO
                        {
                            KhoID = k.KhoID,
                            DonDatHangID = k.DonDatHangID,
                            VatTuID = k.VatTuID,
                            TenVatTu = k.VatTu != null ? k.VatTu.TenVatTu : null,
                            LoaiGiaoDich = k.LoaiGiaoDich,
                            SoLuong = k.SoLuong,
                            NgayGiaoDich = k.NgayGiaoDich,
                            DuAnID = k.DuAnID,
                            TenDuAn = k.DuAn.TenDuAn,
                            NhanVienID = k.NhanVienID,
                            TenNhanVien = k.NhanVien != null ? k.NhanVien.HoTen : null,
                        }).ToList()
            ;
        }
    }
}
