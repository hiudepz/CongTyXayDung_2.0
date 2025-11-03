using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace BLL
{
    public class NhaCungCap_BLL
    {
        private NhaCungCap_DAL ncc_dal = new NhaCungCap_DAL();
        public List<DTO.NhaCungCap_DTO> GetAllSuplier()
        {
            return ncc_dal.GetAllSuplier();
        }
    }
}
