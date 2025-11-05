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
        private readonly Kho_DAL dal = new Kho_DAL();
        public void AddToWareHouse(int donDatHangID, int nhanVienID)
        {
            dal.AddToWareHouse(donDatHangID, nhanVienID);
        }
        public List<Kho_DTO> GetAllWareHouseRecords()
        {
            return dal.GetAllWareHouseRecords();
        }
        public List<Kho_DTO> FilterWarehouseRecords(bool nhap, bool xuat)
        {
            return dal.FilterWarehouseRecords(nhap, xuat);
        }
        public bool XuatKho(int vatTuID, int soLuong, int nhanVienID, int duAnID)
        {
            return dal.XuatKho(vatTuID, soLuong, nhanVienID, duAnID);
        }

        // Wrapper for DAL.Search
        public List<Kho_DTO> Search(string keyword = null, DateTime? fromDate = null, DateTime? toDate = null, string loaiGiaoDich = null)
        {
            return dal.Search(keyword, fromDate, toDate, loaiGiaoDich);
        }
    }
}
