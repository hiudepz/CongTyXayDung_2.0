using DAL;
using DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace BLL
{
    public class KhachHang_BLL
    {
        private static KhachHang_DAL kh_dal = new KhachHang_DAL();
        public List<KhachHang_DTO> GetAllCustomer()
        {
            return kh_dal.GetAllCustomers();
        }
        public void AddCustomer(KhachHang_DTO kh_dto)
        {
            KhachHang kh = new KhachHang
            {
                HoTenKH = kh_dto.HoTenKH,
                Email = kh_dto.Email,
                Phone = kh_dto.Phone,
                DiaChi = kh_dto.DiaChi,
                AnhDaiDien = kh_dto.AnhDaiDien
            };
            kh_dal.AddCustomer(kh);
        }
        public void UpdateCustomer(KhachHang kh)
        {
            kh_dal.UpdateCustomer(kh);
        }
        public void DeleteCustomer(int CustomerId)
        {
            kh_dal.DeleteCustomer(CustomerId);
        }
        public DataTable GetAllCustomertoRP()
        {
            return kh_dal.GetAllCustomertoRP();  
        }
        public DataTable GetCustomerInRP(string text)
        {
            return kh_dal.GetCustomerInRP(text);
        }
        public List<KhachHang_DTO> SearchCustomers(string text)
        {
            return kh_dal.SearchCustomers(text);
        }
        public string CheckAdd(KhachHang_DTO kh)
        {
          

            StringBuilder loi = new StringBuilder();
            if (string.IsNullOrWhiteSpace(kh.HoTenKH))
                loi.AppendLine("- Vui lòng thêm khách hàng");
            if (string.IsNullOrWhiteSpace(kh.Email))
                loi.AppendLine("- Email không được để trống.");
            if (!Regex.IsMatch(kh.Email, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
                loi.AppendLine("- Email không hợp lệ ví dụ: cty@gmail.com");
            if (string.IsNullOrWhiteSpace(kh.Phone))
                loi.AppendLine("- Số điện thoại không được để trống.");
            if (!Regex.IsMatch(kh.Phone, @"^(0|\+84)[0-9]{9,10}$"))
                loi.AppendLine("- Số điện thoại không hợp lệ");
            if (string.IsNullOrWhiteSpace(kh.DiaChi))
                loi.AppendLine("- Địa chỉ không được để trống");

            var ID = kh.KhachHangID;
            //var nd = kh.GetByCustomer(ID);
            //if (kh != null && kh.KhachHangID == ID)
            //{
            //    loi.AppendLine("- Nhân viên đã có tài khoản");
            //}
            return loi.ToString();
        }
    }
}
