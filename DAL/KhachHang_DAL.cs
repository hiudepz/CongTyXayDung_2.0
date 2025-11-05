using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;

namespace DAL
{
    public class KhachHang_DAL
    { 
        private static QuanLyXayDungEntities2 db = new QuanLyXayDungEntities2();
        public List<KhachHang_DTO> GetByCustomer(int id )
        {
            var list = (from kh in db.KhachHangs
                        where kh.KhachHangID ==id
                        select new KhachHang_DTO
                        {
                            KhachHangID= kh.KhachHangID,
                            HoTenKH = kh.HoTenKH,
                            Email= kh.Email,
                            Phone= kh.Phone,
                            DiaChi= kh.DiaChi,
                            AnhDaiDien= kh.AnhDaiDien
                        }
                        ).ToList();
            return list;
        }
        public List<KhachHang_DTO> GetAllCustomers()
        {
            //tao list DTO de truyen du lieu qua GUI
            var list = (from kh in db.KhachHangs
                        select new KhachHang_DTO
                        {
                            KhachHangID = kh.KhachHangID,
                            HoTenKH = kh.HoTenKH,
                            Email = kh.Email,
                            Phone = kh.Phone,
                            DiaChi = kh.DiaChi,
                            AnhDaiDien = kh.AnhDaiDien                            
                        }).ToList();

            return list;
        }

        //Add Customer
        public void AddCustomer(KhachHang kh)
        {
            if (kh == null)
                return;

            db.KhachHangs.Add(kh);
            db.SaveChanges();
        }

        //Update Customer
        public void UpdateCustomer(KhachHang kh)
        {
            var existingCustomer = db.KhachHangs.FirstOrDefault(k => k.KhachHangID == kh.KhachHangID);
            if (existingCustomer != null)
            {
                existingCustomer.HoTenKH = kh.HoTenKH;
                existingCustomer.Email = kh.Email;
                existingCustomer.Phone = kh.Phone;
                existingCustomer.DiaChi = kh.DiaChi;
                existingCustomer.AnhDaiDien = kh.AnhDaiDien;
                db.SaveChanges();
            }
        }

        //Delete Customer 
        public void DeleteCustomer(int CustomerId)
        {
            var Customer = db.KhachHangs.Find(CustomerId);
            if (Customer != null)
            {
                db.KhachHangs.Remove(Customer);
                db.SaveChanges();
            }
        }

        //Tim Kiem Customer
        public List<KhachHang_DTO> SearchCustomers(string text)
        {
            if (string.IsNullOrWhiteSpace(text))
            {
                return GetAllCustomers();
            }
            var t = text.Trim().ToLower();
            var list = (from kh in db.KhachHangs
                       where (kh.HoTenKH !=null && kh.HoTenKH.ToLower().Contains(t))
                          || (kh.Email != null && kh.Email.ToLower().Contains(t))
                          || (kh.DiaChi != null && kh.DiaChi.ToLower().Contains(t))
                          || (kh.Phone != null && kh.Phone.ToLower().Contains(t))
                          select new KhachHang_DTO
                          {
                              KhachHangID   = kh.KhachHangID,
                              HoTenKH = kh.HoTenKH,
                              Email = kh.Email,
                              Phone= kh.Phone,
                              DiaChi = kh.DiaChi,
                              AnhDaiDien = kh.AnhDaiDien
                          }).ToList();
            return list;
        }
        //----------------------tim kiem cho report-------------------
        public DataTable GetCustomerInRP(string text)
        {
            var list = (from kh in db.KhachHangs
                        where (kh.HoTenKH != null && kh.HoTenKH.Contains(text))
                          || (kh.Email != null && kh.Email.Contains(text))
                          || (kh.DiaChi != null && kh.DiaChi.Contains(text))
                          || (kh.Phone != null && kh.Phone.Contains(text))
                        select new KhachHang_DTO
                        {
                            KhachHangID = kh.KhachHangID,
                            HoTenKH = kh.HoTenKH,
                            Email = kh.Email,
                            Phone = kh.Phone,
                            DiaChi = kh.DiaChi,
                            AnhDaiDien = kh.AnhDaiDien
                        }).ToList();
            return ConvertToDataTable(list);
        }
        public static DataTable ConvertToDataTable<T>(IList<T> data)
        {
            var props = typeof(T).GetProperties();
            DataTable tb = new DataTable();

            // Tạo cột tương ứng với thuộc tính
            foreach (var prop in props)
                tb.Columns.Add(prop.Name, Nullable.GetUnderlyingType(prop.PropertyType) ?? prop.PropertyType);

            // Tạo dòng dữ liệu
            foreach (var item in data)
            {
                var row = tb.NewRow();
                foreach (var prop in props)
                {
                    row[prop.Name] = prop.GetValue(item) ?? DBNull.Value;
                }
                tb.Rows.Add(row);
            }

            return tb;
        }

        //----------------------lay du lieu de in report khach hang-------------------
        public DataTable GetAllCustomertoRP()
        {
            var list = (from kh in db.KhachHangs
                        select new KhachHang_DTO
                        {
                            KhachHangID = kh.KhachHangID,
                            HoTenKH = kh.HoTenKH,
                            Email = kh.Email,
                            Phone = kh.Phone,
                            DiaChi = kh.DiaChi,
                            AnhDaiDien = kh.AnhDaiDien
                        }).ToList();

            return ConvertToDataTable(list);
        }

        //----------------------ham chuyen doi tu list-------------------
        

    }
}
