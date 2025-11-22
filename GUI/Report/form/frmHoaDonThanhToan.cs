using BLL;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Windows.Forms;
using GUI.Report.dataset;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI.Report.form
{
    
    public partial class frmHoaDonThanhToan : Form
    {
        public int? duAnID;
        public decimal SoTien;
        public string nguoiLap;
        public frmHoaDonThanhToan(int? IDduAn,decimal soTien,string nguoiLap)
        {
            InitializeComponent();
            this.duAnID = IDduAn;
            this.SoTien = soTien;
            this.nguoiLap = nguoiLap;
        }
        public frmHoaDonThanhToan()
        { 
            InitializeComponent();
            
        }
        public ThanhToan_BLL tt_bll = new ThanhToan_BLL();
        private void crystalReportViewer1_Load(object sender, EventArgs e)
        {
            try
            {
                // Lấy thông tin hóa đơn từ BLL
                var tt = tt_bll.GetThongTinHoaDon(duAnID, SoTien); // trả về hopdong_dto

                // Tạo DataTable cho báo cáo
                var dt = new ThanhToanHoaDon.HoaDonThanhToanDataTable();
                var row = dt.NewHoaDonThanhToanRow();

                // Gán dữ liệu từ DTO vào DataTable
                row.DuAnID = tt.DuAnID;
                row.TenDuAn = tt.TenDuAn;
                row.TenKhachHang = tt.TenKhachHang;
                row.MaHopDong = tt.MaHopDong;
                row.GiaTriHopDong = tt.GiaTriHopDong;
                row.NgayKy = tt.NgayKy ?? DateTime.MinValue;
                row.ThoiHanThiCong = tt.ThoiHanThiCong;
                row.TongTien = tt.TongTien;
                row.TienNoTruoc = tt.TienNoTruoc;
                row.TienThanhToan = tt.TienThanhToan;
                row.TienNoSau = tt.TienNoSau;

                dt.AddHoaDonThanhToanRow(row);

                // Load báo cáo Crystal Report
                string reportPath = Path.Combine(Application.StartupPath, "Report", "Hoadonthanhtoan.rpt");
                ReportDocument rpt = new ReportDocument();
                rpt.Load(reportPath);

                // Gán nguồn dữ liệu cho báo cáo
                rpt.SetDataSource((DataTable)dt);

                // Gán tham số báo cáo
                rpt.SetParameterValue("NguoiLap", GUI.Login.login.TenDangNhapHienTai);

                // Hiển thị báo cáo trên CrystalReportViewer
                crystalReportViewer1.ReportSource = rpt;
                crystalReportViewer1.Refresh();

            }
            catch (Exception ex)
            {
                {
                    MessageBox.Show("Lỗi khi tải báo cáo: " + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void frmHoaDonThanhToan_Load(object sender, EventArgs e)
        {

        }
    }
}
