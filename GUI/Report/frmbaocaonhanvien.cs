using CrystalDecisions.CrystalReports.Engine;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BLL;

namespace GUI.Report
{
    public partial class frmbaocaonhanvien : Form
    {
        public frmbaocaonhanvien()
        {
            InitializeComponent();
        }
        private NhanVien_BLL bll = new NhanVien_BLL();
        private void crystalReportViewer1_Load(object sender, EventArgs e)
        {
            try
            {
                var dsNhanVien = bll.Laydanhsachnhanvien();

                DataTable dt = new DataTable();
                dt.Columns.Add("NhanVienID", typeof(int));
                dt.Columns.Add("HoTen", typeof(string));
                dt.Columns.Add("Email", typeof(string));
                dt.Columns.Add("Phone", typeof(string));
                dt.Columns.Add("VaiTro", typeof(string));
                dt.Columns.Add("AnhDaiDien", typeof(byte[]));

                foreach (var nv in dsNhanVien)
                {
                    dt.Rows.Add(nv.NhanVienID, nv.HoTen, nv.Email, nv.Phone, nv.VaiTro, nv.AnhDaiDien);
                }

                ReportDocument rpt = new ReportDocument();
                rpt.Load(Application.StartupPath + @"\Report\Danhsachnhanvien.rpt");
                rpt.SetDataSource(dt);

                crystalReportViewer1.ReportSource = rpt;
                crystalReportViewer1.Refresh();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải báo cáo: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
