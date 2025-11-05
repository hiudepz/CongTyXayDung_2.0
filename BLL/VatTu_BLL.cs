using DAL;
using DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class VatTu_BLL
    {
        private readonly VatTu_DAL dal = new VatTu_DAL();
        public List<VatTu_DTO> GetAllMaterials()
        {
            return dal.GetAllMaterials();
        }
        public void AddMaterial(VatTu_DTO vatTuDto)
        {
            var vt = new VatTu
            {
                TenVatTu = vatTuDto.TenVatTu,
                DonViTinh = vatTuDto.DonViTinh,
                SoLuongTon = vatTuDto.SoLuongTon,
                NhaCungCapID = vatTuDto.NhaCungCapID,
                HinhAnhVatTu = vatTuDto.HinhAnhVatTu
            };
            dal.AddMaterial(vt);
        }
        public void UpdateMaterial(VatTu_DTO vatTuDto)
        {
            dal.UpdateMaterial(vatTuDto);
        }
        public void Delete(int id)
        {
            dal.Delete(id);
        }
        public List<VatTu_DTO> SearchMaterials(string keyword)
        {
            return dal.SearchMaterials(keyword);
        }
        public DataTable GetMaterialsInRP(string text)
        {
            return dal.GetMaterialsInRP(text);
        }
        public DataTable GetAllMaterialstoRP()
        {
            return dal.GetAllMaterialstoRP();
        }
    }
}
