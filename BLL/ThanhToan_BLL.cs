using DAL;
using DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class ThanhToan_BLL
    {
        private static ThanhToan_DAL tt_dal = new ThanhToan_DAL();
        private readonly ChiTietDonDatHang_BLL ctddh_bll = new ChiTietDonDatHang_BLL();
        private readonly DonDatHang_BLL ddh_bll = new DonDatHang_BLL();
        private readonly DuAn_BLL duan_bll = new DuAn_BLL();
        private readonly HopDong_BLL hopdong_bll = new HopDong_BLL();

        public List<ThanhToan_DTO> SearchPays(string term)
        {
            return tt_dal.SearchPays(term);
        }
        public List<ThanhToan_DTO> GetAllPay()
        {
            return tt_dal.GetAllPay();
        }
        public ThanhToan_DTO GetByID(int id)
        {
            var tt = tt_dal.GetByID(id);
            return tt == null ? null : new ThanhToan_DTO
            {
                ThanhToanID = tt.ThanhToanID,
                NgayThanhToan = tt.NgayThanhToan,
                SoTien = tt.SoTien,
                HinhThuc = tt.HinhThuc,
                GhiChu = tt.GhiChu,
                DuAnID = tt.DuAnID,
                DonDatHangID = tt.DonDatHangID,
                NhanVienID = tt.NhanVienID
            };
        }
        public void Add(ThanhToan_DTO tt_dto)
        {
            string loi = CheckAdd(tt_dto);
            if (!string.IsNullOrEmpty(loi))
                throw new Exception(loi);//nem loi cho GUI
            ThanhToan tt = new ThanhToan
            {
                NgayThanhToan = tt_dto.NgayThanhToan,
                SoTien = tt_dto.SoTien,
                HinhThuc = tt_dto.HinhThuc,
                GhiChu = tt_dto.GhiChu,
                DuAnID = tt_dto.DuAnID,
                DonDatHangID = tt_dto.DonDatHangID,
                NhanVienID = tt_dto.NhanVienID,
            };
            tt_dal.Add(tt);
        }
        public void Delete(int id)
        {
            var idThanhToan = tt_dal.GetByID(id);
            if (idThanhToan == null)
            {
                throw new Exception("Vui lòng chọn thông tin cần xoá");
            }
            tt_dal.Delete(id);
        }
        public void Update(ThanhToan_DTO tt_dto)
        {
            if (tt_dto == null || tt_dto.ThanhToanID <= 0)
                throw new Exception("Vui lòng chọn bản ghi hợp lệ để cập nhật.");

            string loi = CheckAdd(tt_dto);
            if (!string.IsNullOrEmpty(loi))
                throw new Exception(loi);

            var existing = tt_dal.GetByID(tt_dto.ThanhToanID);
            if (existing == null)
                throw new Exception("Không tìm thấy phiếu thanh toán để cập nhật.");

            ThanhToan tt = new ThanhToan
            {
                ThanhToanID = tt_dto.ThanhToanID,
                NgayThanhToan = tt_dto.NgayThanhToan,
                SoTien = tt_dto.SoTien,
                HinhThuc = tt_dto.HinhThuc,
                GhiChu = tt_dto.GhiChu,
                DuAnID = tt_dto.DuAnID,
                DonDatHangID = tt_dto.DonDatHangID,
                NhanVienID = tt_dto.NhanVienID,
            };
            tt_dal.UpdatePay(tt);
        }
        public string CheckAdd(ThanhToan_DTO tt_dto)
        {
            StringBuilder loi = new StringBuilder();

            // 1. Kiểm tra số tiền
            if (tt_dto.SoTien <= 0)
            {
                loi.AppendLine("- Số tiền thanh toán phải lớn hơn 0.");
            }

            // 2. Kiểm tra hình thức thanh toán
            if (string.IsNullOrWhiteSpace(tt_dto.HinhThuc))
            {
                loi.AppendLine("- Vui lòng chọn hình thức thanh toán.");
            }

            // 3. Kiểm tra Nhân viên thực hiện
            if (tt_dto.NhanVienID <= 0)
            {
                loi.AppendLine("- Vui lòng xác định nhân viên thực hiện giao dịch.");
            }

            // 4. Dự án vs Đơn hàng
            bool coDuAn = tt_dto.DuAnID.HasValue && tt_dto.DuAnID.Value > 0;
            bool coDonHang = tt_dto.DonDatHangID.HasValue && tt_dto.DonDatHangID.Value > 0;

            if (!coDuAn && !coDonHang)
            {
                loi.AppendLine("- Thanh toán phải gắn với một Dự án hoặc một Đơn đặt hàng cụ thể.");
            }

            if (coDuAn && coDonHang)
            {
                loi.AppendLine("- Không thể thanh toán cho cả Dự án và Đơn hàng trong cùng một phiếu. Vui lòng tách làm 2 phiếu.");
            }

            // Determine whether this is an update (so we exclude the current record from existing sums)
            bool isUpdate = tt_dto.ThanhToanID > 0;
            decimal existingPaymentAmount = 0m;
            if (isUpdate)
            {
                var existingEntity = tt_dal.GetByID(tt_dto.ThanhToanID);
                if (existingEntity != null)
                    existingPaymentAmount = existingEntity.SoTien;
            }

            // Check against order total
            if (coDonHang)
            {
                int orderId = tt_dto.DonDatHangID.Value;
                var details = ctddh_bll.GetDetailsByOrderId(orderId);
                decimal orderTotal = details.Sum(d => d.DonGia * d.SoLuong);

                if (orderTotal <= 0)
                {
                    loi.AppendLine("- Đơn đặt hàng chưa có chi tiết hoặc tổng giá trị bằng 0; không thể thanh toán.");
                }
                else
                {
                    decimal paidSoFar = tt_dal.GetAllPay()
                        .Where(p => p.DonDatHangID.HasValue && p.DonDatHangID.Value == orderId)
                        .Sum(p => p.SoTien);

                    decimal paidExcludingCurrent = paidSoFar - (isUpdate ? existingPaymentAmount : 0m);
                    decimal remaining = orderTotal - paidExcludingCurrent;

                    if (remaining <= 0)
                    {
                        loi.AppendLine("- Đơn hàng đã được thanh toán đầy đủ.");
                    }
                    else if (tt_dto.SoTien > remaining)
                    {
                        loi.AppendLine($"- Số tiền vượt quá tổng giá trị đơn hàng (còn lại {remaining:N0}).");
                    }
                }
            }

            // Check against contract value for project
            if (coDuAn)
            {
                int projectId = tt_dto.DuAnID.Value;
                var duan = duan_bll.GetAll().FirstOrDefault(d => d.DuAnID == projectId);
                if (duan == null)
                {
                    loi.AppendLine("- Dự án không tồn tại.");
                }
                else if (!duan.HopDongID.HasValue || duan.HopDongID.Value <= 0)
                {
                    loi.AppendLine("- Dự án chưa gán hợp đồng, không thể thanh toán theo hợp đồng.");
                }
                else
                {
                    var hopdong = hopdong_bll.GetByID(duan.HopDongID.Value);
                    if (hopdong == null)
                    {
                        loi.AppendLine("- Không tìm thấy hợp đồng của dự án.");
                    }
                    else
                    {
                        decimal contractValue = hopdong.GiaTriHopDong;
                        decimal paidSoFar = tt_dal.GetAllPay()
                            .Where(p => p.DuAnID.HasValue && p.DuAnID.Value == projectId)
                            .Sum(p => p.SoTien);

                        decimal paidExcludingCurrent = paidSoFar - (isUpdate ? existingPaymentAmount : 0m);
                        decimal remaining = contractValue - paidExcludingCurrent;

                        if (remaining <= 0)
                        {
                            loi.AppendLine("- Giá trị hợp đồng đã được thanh toán đầy đủ.");
                        }
                        else if (tt_dto.SoTien > remaining)
                        {
                            loi.AppendLine($"- Số tiền vượt quá giá trị hợp đồng (còn lại {remaining:N0}).");
                        }
                    }
                }

            }

            return loi.ToString();
        }

        public List<ThanhToanOrder> GetAllOrder() => tt_dal.LayDanhSachDonDatHang();
        public List<ThanhToanProject> GetAllPro() => tt_dal.LayDanhSachDuAn();
        public (decimal TongTien, decimal TienNo) GetTienDuAn(int duAnID)
        {
            return tt_dal.GetTienDuAn(duAnID);
        }

        public (decimal TongTien, decimal TienNo) GetTienDonDatHang(int ddhID)
        {
            return tt_dal.GetTienDonDatHang(ddhID);
        }
        public ThanhToan GetMaster(int id)
        {
            return tt_dal.GetThanhToanByID(id);
        }
       
        public HoaDonThanhToan_DTO GetThongTinHoaDon(int? duAnID, decimal soTienThanhToan)
        {
            return tt_dal.GetThongTinHoaDon(duAnID, soTienThanhToan);
        }
    }
}
