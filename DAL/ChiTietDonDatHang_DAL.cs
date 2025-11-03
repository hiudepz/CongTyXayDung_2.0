using DTO;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DAL
{
    public class ChiTietDonDatHang_DAL
    {
        private static QuanLyXayDungEntities2 db = new QuanLyXayDungEntities2();

        
        public List<ChiTietDonDatHang_DTO> GetAllOrderDetails()
        {
            var list = (from ctdh in db.ChiTietDonDatHangs
                        join vt in db.VatTus on ctdh.VatTuID equals vt.VatTuID
                        select new ChiTietDonDatHang_DTO
                        {
                            ChiTietID = ctdh.ChiTietID,
                            DonDatHangID = ctdh.DonDatHangID,
                            VatTuID = ctdh.VatTuID,
                            TenVatTu = vt.TenVatTu,
                            SoLuong = ctdh.SoLuong,
                            DonGia = ctdh.DonGia
                        }).ToList();
            return list;
        }
        public List<ChiTietDonDatHang_DTO> SearchOrderDetails(string term)
        {
            if (string.IsNullOrWhiteSpace(term))
                return GetAllOrderDetails();
            var t = term.Trim().ToLower();
            var allDetails = GetAllOrderDetails();
            var filteredDetails = allDetails.Where(ctdh =>
                (ctdh.TenVatTu != null && ctdh.TenVatTu.ToLower().Contains(t)) ||
                ctdh.SoLuong.ToString().ToLower().Contains(t) ||
                ctdh.DonGia.ToString().ToLower().Contains(t)
            ).ToList();
            return filteredDetails;
        }

        public List<ChiTietDonDatHang_DTO> GetDetailsByOrderId(int orderId)
        {
            var list = (from ctdh in db.ChiTietDonDatHangs
                        join vt in db.VatTus on ctdh.VatTuID equals vt.VatTuID
                        where ctdh.DonDatHangID == orderId
                        select new ChiTietDonDatHang_DTO
                        {
                            ChiTietID = ctdh.ChiTietID,
                            DonDatHangID = ctdh.DonDatHangID,
                            VatTuID = ctdh.VatTuID,
                            TenVatTu = vt.TenVatTu,
                            SoLuong = ctdh.SoLuong,
                            DonGia = ctdh.DonGia
                        }).ToList();
            return list;
        }

        public void AddOrderDetail(ChiTietDonDatHang_DTO dto)
        {
            if (dto == null) return;

            int vatTuId = dto.VatTuID;

            // If VatTuID not provided but TenVatTu is, try find or create VatTu
            if (vatTuId <= 0 && !string.IsNullOrWhiteSpace(dto.TenVatTu))
            {
                var vt = db.VatTus.FirstOrDefault(v => v.TenVatTu == dto.TenVatTu);
                if (vt == null)
                {
                    vt = new VatTu { TenVatTu = dto.TenVatTu };
                    db.VatTus.Add(vt);
                    db.SaveChanges();
                }
                vatTuId = vt.VatTuID;
            }

            var entity = new ChiTietDonDatHang
            {
                DonDatHangID = dto.DonDatHangID,
                VatTuID = vatTuId,
                SoLuong = dto.SoLuong,
                DonGia = dto.DonGia
            };

            db.ChiTietDonDatHangs.Add(entity);
            db.SaveChanges();
        }

        public void UpdateOrderDetail(ChiTietDonDatHang_DTO dto)
        {
            if (dto == null) return;

            var existing = db.ChiTietDonDatHangs.FirstOrDefault(ct => ct.ChiTietID == dto.ChiTietID);
            if (existing == null) return;

            int vatTuId = dto.VatTuID;
            if (vatTuId <= 0 && !string.IsNullOrWhiteSpace(dto.TenVatTu))
            {
                var vt = db.VatTus.FirstOrDefault(v => v.TenVatTu == dto.TenVatTu);
                if (vt == null)
                {
                    vt = new VatTu { TenVatTu = dto.TenVatTu };
                    db.VatTus.Add(vt);
                    db.SaveChanges();
                }
                vatTuId = vt.VatTuID;
            }

            existing.VatTuID = vatTuId;
            existing.SoLuong = dto.SoLuong;
            existing.DonGia = dto.DonGia;
            // Don't normally update DonDatHangID here

            db.SaveChanges();
        }

        public void DeleteOrderDetail(int chiTietId)
        {
            var existing = db.ChiTietDonDatHangs.FirstOrDefault(ct => ct.ChiTietID == chiTietId);
            if (existing != null)
            {
                db.ChiTietDonDatHangs.Remove(existing);
                db.SaveChanges();
            }
        }
    }
}
