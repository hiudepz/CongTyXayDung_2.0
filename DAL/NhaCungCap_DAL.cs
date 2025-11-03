using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;

namespace DAL
{
    public class NhaCungCap_DAL
    {
        private static QuanLyXayDungEntities2 db = new QuanLyXayDungEntities2();
        public List<NhaCungCap_DTO> GetAllSuplier()
        {
            var list = ( from ncc in db.NhaCungCaps
                         select new NhaCungCap_DTO
                         {
                             NhaCungCapID = ncc.NhaCungCapID,
                             TenNCC = ncc.TenNCC,
                             Email = ncc.Email,
                             DiaChi = ncc.DiaChi,
                             Phone = ncc.Phone,
                             Logo = ncc.Logo
                         }
                 ).ToList();
            return list;
        }
    }
}
