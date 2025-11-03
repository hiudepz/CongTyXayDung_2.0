using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using DAL;

namespace BLL
{
    public class Kho_BLL
    {
        private readonly Kho_DAL _dal = new Kho_DAL();
        public void AddToWareHouse(int donDatHangID, int nhanVienID)
        {
            _dal.AddToWareHouse(donDatHangID, nhanVienID);
        }
        public List<Kho_DTO> GetAllWareHouseRecords()
        {
            return _dal.GetAllWareHouseRecords();
        }
    }
}
