using BLL;
using GUI.Report.dataset;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI.Report.form
{
    public partial class frmBaocaochiphithuenhansu : Form
    {
        public frmBaocaochiphithuenhansu()
        {
            InitializeComponent();
        }
        public frmBaocaochiphithuenhansu(string nguoiLap)
        {
            InitializeComponent();
            this.nguoiLap=nguoiLap;
        }
        private LuongNV_BLL bll = new LuongNV_BLL();
        private string nguoiLap;
        private void crystalReportViewer1_Load(object sender, EventArgs e)
        {
            try
            {
                var ds = new DataSetLuong(); // Dataset .xsd
                var table = ds.LuongNhanVien;

                var danhSachLuong = bll.GetAllLuong(); // danh sách lương theo tháng

                var tongHop = danhSachLuong
                    .GroupBy(p => new { p.HoTen, p.Nam })
                    .Select(g => new
                    {
                        HoTenNV = g.Key.HoTen,
                        Nam = g.Key.Nam,
                        TongLuongCoBan = g.Sum(x => x.LuongCoBan),
                        TongThuong = g.Sum(x => x.Thuong),
                        TongKhauTru = g.Sum(x => x.KhauTru),
                        TongLuongNam = g.Sum(x => x.LuongCoBan + x.Thuong - x.KhauTru)
                    });

                foreach (var item in tongHop)
                {
                    table.Rows.Add(
                        item.HoTenNV,
                        item.Nam,
                        item.TongLuongCoBan,
                        item.TongThuong,
                        item.TongKhauTru,
                        item.TongLuongNam
                    );
                }

                var rpt = new BangLuong(); 
                rpt.SetDataSource(ds);
                //rpt.SetParameterValue("NguoiLap", nguoiLap);
                rpt.SetParameterValue("NguoiLap", GUI.Login.login.TenDangNhapHienTai);
                crystalReportViewer1.ReportSource = rpt;
                crystalReportViewer1.Refresh();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải báo cáo: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            LoadData(txtTimKiem.Text.Trim());
        }
       
            
        
        private void LoadData(string keyword)
        {
            var ds = new DataSetLuong();
            var table = ds.LuongNhanVien;

            var list = bll.GetAllLuong(); // lấy toàn bộ dữ liệu

            if (!string.IsNullOrWhiteSpace(keyword))
            {
                keyword = RemoveDiacritics(keyword?.Trim().ToLower() ?? "");

                list = list.Where(p =>
                    RemoveDiacritics(p.HoTen.ToLower()).Contains(keyword)).ToList();
            }

            var tongHop = list
                .GroupBy(p => new { p.HoTen, p.Nam })
                .Select(g => new
                {
                    HoTenNV = g.Key.HoTen,
                    Nam = g.Key.Nam,
                    TongLuongCoBan = g.Sum(x => x.LuongCoBan),
                    TongThuong = g.Sum(x => x.Thuong),
                    TongKhauTru = g.Sum(x => x.KhauTru),
                    TongLuongNam = g.Sum(x => x.LuongCoBan + x.Thuong - x.KhauTru)
                });

            foreach (var item in tongHop)
            {
                table.Rows.Add(
                    item.HoTenNV,
                    item.Nam,
                    item.TongLuongCoBan,
                    item.TongThuong,
                    item.TongKhauTru,
                    item.TongLuongNam
                );
            }

            var rpt = new BangLuong();
            rpt.SetDataSource(ds);
            rpt.SetParameterValue("NguoiLap", GUI.Login.login.TenDangNhapHienTai);
            crystalReportViewer1.ReportSource = rpt;
            crystalReportViewer1.Refresh();
            

        }
        //Hàm bỏ dấu
        private string RemoveDiacritics(string text)
        {
            if (string.IsNullOrEmpty(text))
                return text;

            var normalized = text.Normalize(System.Text.NormalizationForm.FormD);
            var chars = normalized.Where(c =>
                System.Globalization.CharUnicodeInfo.GetUnicodeCategory(c) !=
                System.Globalization.UnicodeCategory.NonSpacingMark
            );

            return new string(chars.ToArray()).Normalize(System.Text.NormalizationForm.FormC);
        }
    }
}
