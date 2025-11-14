using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using System.Data.Entity; 

namespace DAL
{
    public class DonDatHang_DAL
    {
        private static QuanLyXayDungEntities2 db = new QuanLyXayDungEntities2();
        public DonDatHang GetByOrder(int id)
        {
            var ddh = db.DonDatHangs.FirstOrDefault(o => o.DonDatHangID == id);
            return ddh;
        }
        public List<DonDatHang_DTO> GetAllOrders()
        {
            var list = ( from ddh in db.DonDatHangs
                         select new DonDatHang_DTO
                         {
                             DonDatHangID = ddh.DonDatHangID,
                             NhaCungCapID = ddh.NhaCungCapID,
                             TenNCC = ddh.NhaCungCap.TenNCC,
                             NhanVienID = ddh.NhanVienID,
                             HoTen = ddh.NhanVien.HoTen,
                             NgayDat = ddh.NgayDat,
                             TrangThai = ddh.TrangThai
                         }
                 ).ToList();
            return list;
        }
        public void AddOrder(DonDatHang ddh)
        {
            if (ddh == null)
                return;
            db.DonDatHangs.Add(ddh);
            db.SaveChanges();
        }
        public void DeleteOrder(int id)
        {
            var existingOrder = db.DonDatHangs.FirstOrDefault(o => o.DonDatHangID == id);
            if (existingOrder != null)
            {
                db.DonDatHangs.Remove(existingOrder);
                db.SaveChanges();
            }
        }
        public void UpdateOrder(DonDatHang ddh)
        {
            var existingOrder = db.DonDatHangs.FirstOrDefault(o => o.DonDatHangID == ddh.DonDatHangID);
            if (existingOrder != null)
            {
                existingOrder.NhaCungCapID = ddh.NhaCungCapID;
                existingOrder.NhanVienID = ddh.NhanVienID;
                existingOrder.NgayDat = ddh.NgayDat;
                existingOrder.TrangThai = ddh.TrangThai;
                db.SaveChanges();
            }
        }
        public void DeleteOrderDetail(int id)
        {
            var existingOrder = db.ChiTietDonDatHangs.Where(o => o.DonDatHangID == id).ToList();
            if (existingOrder != null && existingOrder.Count > 0)
            {
                foreach (var item in existingOrder)
                {
                    db.ChiTietDonDatHangs.Remove(item);
                }
                db.SaveChanges();
            }
        }
        public List<DonDatHang_DTO> SearchOrders(string term)
        {
            if (string.IsNullOrWhiteSpace(term))
                return GetAllOrders();
            var t = term.Trim().ToLower();
            var allOrders = GetAllOrders();
            var filteredOrders = allOrders.Where(ddh =>
                (ddh.TenNCC != null && ddh.TenNCC.ToLower().Contains(t)) ||
                (ddh.HoTen != null && ddh.HoTen.ToLower().Contains(t)) ||
                ddh.TrangThai.ToLower().Contains(t) ||
                ddh.NgayDat.ToString("d").ToLower().Contains(t)
            ).ToList();
            return filteredOrders;
        }
    }
}