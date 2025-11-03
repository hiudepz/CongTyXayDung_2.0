using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;

namespace DAL
{
    public class VatTu_DAL
    {
        private static QuanLyXayDungEntities2 db = new QuanLyXayDungEntities2();
        public List<VatTu_DTO> GetAllMaterials()
        {
            var list = (from vt in db.VatTus
                        select new VatTu_DTO
                        {
                            VatTuID = vt.VatTuID,
                            TenVatTu = vt.TenVatTu,
                            DonViTinh = vt.DonViTinh,
                            SoLuongTon = vt.SoLuongTon,
                            NhaCungCapID = vt.NhaCungCapID,
                            HinhAnhVatTu = vt.HinhAnhVatTu
                        }).ToList();
            return list;
        }

    }
}
