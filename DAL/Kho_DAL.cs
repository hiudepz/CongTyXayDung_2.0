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
                            DonDatHangID = k.DonDatHangID,
                            VatTuID = k.VatTuID,
                            LoaiGiaoDich = k.LoaiGiaoDich,
                            SoLuong = k.SoLuong,
                            NgayGiaoDich = k.NgayGiaoDich,
                            NhanVienID = k.NhanVienID,
                        }
                 ).ToList();
            return list;
        }
    }
}
