using BLL;
using CrystalDecisions.CrystalReports.Engine;
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
    public partial class frmBaocaonhansutrongduan : Form
    {

        public frmBaocaonhansutrongduan()
        {
            InitializeComponent();
        }
        public frmBaocaonhansutrongduan(string nguoiLap)
        {
            InitializeComponent();
            this.nguoiLap = nguoiLap;
        }
        private PhanCong_BLL bll = new PhanCong_BLL();
        private string nguoiLap;
        private void frmBaoCaoNhanSu_Load(object sender, EventArgs e)
        {
            try
            {
                LoadData("");
                // Tạo instance từ Dataset đã khai báo
                var ds = new DataSetPhanCong(); // Dataset .xsd của bạn
                var table = ds.PhanCong; // bảng đã có sẵn cột

                var list = bll.GetAll(); // lấy dữ liệu đã join từ BLL

                foreach (var ppl in list)
                {
                    table.Rows.Add(
                        ppl.TenDuAn,
                        ppl.HoTenNV,
                        ppl.NhiemVu,
                        ppl.NgayBatDau ?? DateTime.MinValue,
                        ppl.NgayKetThuc ?? DateTime.MinValue
                    );
                }

                ReportDocument rpt = new ReportDocument();
                string reportPath = System.IO.Path.Combine(Application.StartupPath, "Report", "Baocaophancong.rpt");
                rpt.Load(reportPath);
                
                rpt.SetDataSource(ds); // gán toàn bộ Dataset
                rpt.SetParameterValue("NguoiLap", GUI.Login.login.TenDangNhapHienTai);
                frmBaoCaoNhanSu.ReportSource = rpt;
                frmBaoCaoNhanSu.Refresh();
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
            var ds = new DataSetPhanCong();
            var table = ds.PhanCong;

            var list = bll.GetAll(); // lấy toàn bộ dữ liệu

            if (!string.IsNullOrWhiteSpace(keyword))
            {
                keyword = RemoveDiacritics(keyword?.Trim().ToLower() ?? "");

                list = list.Where(p =>
                    RemoveDiacritics(p.TenDuAn.ToLower()).Contains(keyword) ||
                    RemoveDiacritics(p.HoTenNV.ToLower()).Contains(keyword) ||
                    RemoveDiacritics(p.NhiemVu.ToLower()).Contains(keyword)).ToList();
            }

            foreach (var ppl in list)
            {
                table.Rows.Add(ppl.TenDuAn, ppl.HoTenNV, ppl.NhiemVu,
                               ppl.NgayBatDau ?? DateTime.MinValue,
                               ppl.NgayKetThuc ?? DateTime.MinValue);
            }

            var rpt = new Baocaophancong();
            rpt.SetDataSource(ds);
            rpt.SetParameterValue("NguoiLap", GUI.Login.login.TenDangNhapHienTai);
            frmBaoCaoNhanSu.ReportSource = rpt;
            frmBaoCaoNhanSu.Refresh();
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

        private void frmBaocaonhansutrongduan_Load(object sender, EventArgs e)
        {

        }
    }
}
