using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using DAL;

namespace BLL
{
    public class VatTu_BLL
    {
        private readonly VatTu_DAL dal = new VatTu_DAL();
        public List<VatTu_DTO> GetAllMaterials()
        {
            
            return dal.GetAllMaterials();
        }
    }
}
