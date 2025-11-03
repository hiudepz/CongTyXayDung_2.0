using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using DTO;

namespace BLL
{
    public class DonDatHang_BLL
    {
        private DonDatHang_DAL ddh_dal = new DonDatHang_DAL();
        public List<DonDatHang_DTO> GetAllOrders()
        {
            return ddh_dal.GetAllOrders();
        }
        public void AddOrder(DonDatHang_DTO ddh_dto)
        {
            DonDatHang ddh = new DonDatHang
            {
                NhaCungCapID = ddh_dto.NhaCungCapID,
                NhanVienID = ddh_dto.NhanVienID,
                NgayDat = ddh_dto.NgayDat,
                TrangThai = ddh_dto.TrangThai
            };
            ddh_dal.AddOrder(ddh);
        }
        public void UpdateOrder(DonDatHang_DTO ddh_dto)
        {
            DonDatHang ddh = new DonDatHang
            {
                DonDatHangID = ddh_dto.DonDatHangID,
                NhaCungCapID = ddh_dto.NhaCungCapID,
                NhanVienID = ddh_dto.NhanVienID,
                NgayDat = ddh_dto.NgayDat,
                TrangThai = ddh_dto.TrangThai
            };
            ddh_dal.UpdateOrder(ddh);
        }
        public void DeleteOrder(int id)
        {
            ddh_dal.DeleteOrder(id);
        }
        public DonDatHang GetByOrder(int id)
        {
            return ddh_dal.GetByOrder(id);
        }
       
        public void DeleteOrderDetail(int id)
        {
            ddh_dal.DeleteOrderDetail(id);
        }
        public List<DonDatHang_DTO> SearchOrders(string term)
        {
            return ddh_dal.SearchOrders(term);
        }
    }
}
