using BLL;
using CrystalDecisions.CrystalReports.Engine;
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
    public partial class frmBaoCaoVatTuTonKho : Form
    {
        public frmBaoCaoVatTuTonKho()
        {
            InitializeComponent();
        }

        private static VatTu_BLL vt_bll = new VatTu_BLL();
        private ReportDocument currentReport;

        public void TimKiemInRPVT()
        {
            try
            {
                DataTable dt;
                // If search box is empty show all materials, otherwise filtered results
                if (string.IsNullOrWhiteSpace(txtTimKiem.Text))
                {
                    dt = vt_bll.GetAllMaterialstoRP();
                }
                else
                {
                    dt = vt_bll.GetMaterialsInRP(txtTimKiem.Text);
                }

                LoadReportFromDataTable(dt);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải báo cáo: " + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadReportFromDataTable(DataTable dt)
        {
            // Dispose previous report to avoid memory leaks
            try
            {
                if (currentReport != null)
                {
                    currentReport.Close();
                    currentReport.Dispose();
                    currentReport = null;
                }

                string rptPath = Path.Combine(Application.StartupPath, "Report", "Baocaotonkho.rpt");
                currentReport = new ReportDocument();
                currentReport.Load(rptPath);

                currentReport.SetDataSource(dt ?? new DataTable());

                crystalReportViewer1.ReportSource = currentReport;
                crystalReportViewer1.Refresh();
            }
            catch (Exception ex)
            {
                // Bubble up for caller to show message
                throw new InvalidOperationException("Không thể nạp file báo cáo: " + ex.Message, ex);
            }
        }

        private void frmBaoCaoVatTuTonKho_Load(object sender, EventArgs e)
        {
            // Load full report on form open
            TimKiemInRPVT();
        }

        private void crystalReportViewer1_Load(object sender, EventArgs e)
        {
            // No-op: report is loaded from form Load to avoid duplicate loads.
        }

        private void txtTimKiem_TextChanged(object sender, EventArgs e)
        {
            
        }

        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            base.OnFormClosed(e);
            if (currentReport != null)
            {
                try
                {
                    currentReport.Close();
                    currentReport.Dispose();
                }
                catch
                {
                    // ignore cleanup errors
                }
                currentReport = null;
            }
        }

        private void txtTimKiem_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                //goi ham tim kiem
                TimKiemInRPVT();
            }
        }
    }
}
