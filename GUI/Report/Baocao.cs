using BLL;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using GUI.Report;
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

namespace GUI.User
{
    public partial class Baocao: Form
    {
        public Baocao()
        {
            InitializeComponent();
        }
        private BLL_Congtrinh_Admin bll =  new BLL_Congtrinh_Admin();
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        //private void btnSearch_Click(object sender, EventArgs e)
        //{
        //    rptDanhSachVatTuVaTongChiPhi t = new rptDanhSachVatTuVaTongChiPhi();
        //    ParameterValues pars = new ParameterValues();
        //    ParameterDiscreteValue pa = new ParameterDiscreteValue();
        //    pa.Value = txtTenCongTrinh.Text;
        //    pars.Add(pa);
        //    t.DataDefinition.ParameterFields["@tenCongTrinh"].ApplyCurrentValues(pars);
        //    crystalReportViewer1.ReportSource = t;
        //    //Kiểm tra nếu ko thấy 
        //    if (t.Rows.Count == 0)
        //    {
        //        MessageBox.Show($"Không tìm thấy {txtTenCongTrinh.Text}", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        //    }
        //}
        private void BaoCao_User_Load(object sender, EventArgs e)
        {
            cbbLoaiBaoCao.Items.Add("Danh sách nhân công theo công trình");
            cbbLoaiBaoCao.Items.Add("Báo cáo tiến độ theo công trình");
            cbbLoaiBaoCao.Items.Add("Báo cáo chi phí tổng");
            cbbLoaiBaoCao.Items.Add("Báo cáo danh sách vật tư và tổng chi phí theo công trình");
            cbbLoaiBaoCao.Items.Add("Báo cáo nhà thầu theo công trình");
            cbbCongTrinh.DataSource = bll.GetConstructionList();
            cbbCongTrinh.ValueMember  = "id";
            cbbCongTrinh.DisplayMember = "ten";
        }

        private void btnXuat_Click(object sender, EventArgs e)
        {
            string loaiBaoCao = cbbLoaiBaoCao.SelectedItem.ToString();
            ReportDocument report = new ReportDocument();

            string reportDirectory = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Report");

            int congTrinhId = Convert.ToInt32(cbbCongTrinh.SelectedValue);

            switch (loaiBaoCao)
            {
                case "Danh sách nhân công theo công trình":
                    report.Load(Path.Combine(reportDirectory, "rptDanhSachNhanCongTheoCongTrinh.rpt"));
                    report.SetParameterValue("@CongTrinhID", congTrinhId);
                    break;

                case "Báo cáo tiến độ theo công trình":
                    report.Load(Path.Combine(reportDirectory, "rptTienDoCongTrinhTheoIdCongTrinh.rpt"));
                    report.SetParameterValue("@CongTrinhID", congTrinhId);
                    break;
                        
                case "Báo cáo chi phí tổng":
                    report.Load(Path.Combine(reportDirectory, "ChiPhiTongTheoIdCongTrinh.rpt"));
                    report.SetParameterValue("@CongTrinhID", congTrinhId);
                    break;

                case "Báo cáo danh sách vật tư và tổng chi phí theo công trình":
                    report.Load(Path.Combine(reportDirectory, "rptDanhSachVatTuVaTongChiPhi.rpt"));
                    report.SetParameterValue("@CongTrinhID", congTrinhId);
                    break;

                case "Báo cáo nhà thầu theo công trình":
                    report.Load(Path.Combine(reportDirectory, "rptNhaThauCongTrinh.rpt"));
                    report.SetParameterValue("@IdCongTrinh", congTrinhId);
                    break;
            }

            crystalReportViewerAll.ReportSource = report;
            crystalReportViewerAll.Refresh();
        }
    }
   
}
