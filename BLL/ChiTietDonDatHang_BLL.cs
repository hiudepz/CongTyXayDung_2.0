using DTO;
using DAL;
using System.Collections.Generic;

namespace BLL
{
    public class ChiTietDonDatHang_BLL
    {
        private readonly ChiTietDonDatHang_DAL _dal = new ChiTietDonDatHang_DAL();

        public List<ChiTietDonDatHang_DTO> GetAllOrderDetails()
        {
            return _dal.GetAllOrderDetails();
        }

        public List<ChiTietDonDatHang_DTO> GetDetailsByOrderId(int orderId)
        {
            return _dal.GetDetailsByOrderId(orderId);
        }

        public void AddOrderDetail(ChiTietDonDatHang_DTO dto)
        {
            _dal.AddOrderDetail(dto);
        }

        public void UpdateOrderDetail(ChiTietDonDatHang_DTO dto)
        {
            _dal.UpdateOrderDetail(dto);
        }

        public void DeleteOrderDetail(int chiTietId)
        {
            _dal.DeleteOrderDetail(chiTietId);
        }
        public List<ChiTietDonDatHang_DTO> SearchOrderDetails(string term)
        {
            return _dal.SearchOrderDetails(term);
        }
        
    }
}
