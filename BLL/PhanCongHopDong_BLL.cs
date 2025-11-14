using DAL;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class PhanCongHopDong_BLL
    {
        private readonly PhanCongHopDong_DAL dal = new PhanCongHopDong_DAL();

        // Lấy danh sách
        public List<PhanCongHopDong_DTO> GetAll()
        {
            return dal.GetAll();
        }

   
        // xác thực
        private void Validate(PhanCongHopDong_DTO pc)
        {
            if (pc.HopDongID <= 0)
                throw new ArgumentException("Hợp đồng không hợp lệ.");

            if (pc.NhanVienID <= 0)
                throw new ArgumentException("Nhân viên không hợp lệ.");

            if (string.IsNullOrWhiteSpace(pc.VaiTro))
                throw new ArgumentException("Vai trò không được để trống.");

            if (pc.VaiTro.Length > 200)
                throw new ArgumentException("Vai trò không được vượt quá 200 ký tự.");
            var all = dal.GetAll();
            bool isDuplicate = all.Any(x => x.HopDongID == pc.HopDongID
                              && x.NhanVienID == pc.NhanVienID
                              && x.PhanCongID != pc.PhanCongID);
            if (isDuplicate)
                throw new ArgumentException("Nhân viên này đã được phân công cho hợp đồng này");

        }

        public void Add(PhanCongHopDong_DTO pc)
        {
            Validate(pc);

            try
            {
                var entity = new PhanCongHopDong
                {
                    PhanCongID = pc.PhanCongID,
                    HopDongID = pc.HopDongID,
                    NhanVienID = pc.NhanVienID,
                    VaiTro = pc.VaiTro
                };
                dal.Add(entity);
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi thêm phân công: " + ex.Message, ex);
            }
        }

        public void Update(PhanCongHopDong_DTO pc)
        {
            Validate(pc);

            try
            {
                var entity = new PhanCongHopDong
                {
                    PhanCongID = pc.PhanCongID,
                    HopDongID = pc.HopDongID,
                    NhanVienID = pc.NhanVienID,
                    VaiTro = pc.VaiTro
                };
                dal.Update(entity);
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi cập nhật phân công: " + ex.Message, ex);
            }
        }

        public void Delete(int id)
        {
            if (id <= 0)
                throw new ArgumentException("ID phân công không hợp lệ.");

            try
            {

                dal.Delete(id);
            }
            catch (System.Data.Entity.Infrastructure.DbUpdateException)
            {
                throw new InvalidOperationException("Không thể xóa phân công này vì đang được tham chiếu trong bảng khác.");
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi xóa phân công: " + ex.Message);
            }
        }
        public List<PhanCongHopDong_DTO> Search(string keyword)
        {
            return dal.Search(keyword);
        }
    }
}
