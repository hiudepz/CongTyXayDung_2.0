using DAL;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace BLL
{
    public class NhanVien_BLL
    {
        private static NhanVien_DAL dal = new NhanVien_DAL();
        public List<NhanVien_DTO> Laydanhsachnhanvien()
        {
           return dal.GetAll();
        }

    }
}

