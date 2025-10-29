using BLL;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI.Report
{
    public partial class frmBaoCaoKhachHang : Form
    {
        private static KhachHang_BLL kh_bll = new KhachHang_BLL();
        public frmBaoCaoKhachHang()
        {
            InitializeComponent();
        }


        private void crystalReportViewer1_Load_1(object sender, EventArgs e)
        {
            try
            {
                //1. lay du lieu tu khach hang tu bll
                //var dsNhanVien = kh_bll.GetAllCustomer();

                //DataTable dt = new DataTable();
                //dt.Columns.Add("KhachHangID", typeof(int));
                //dt.Columns.Add("HoTenKH", typeof(string));
                //dt.Columns.Add("Email", typeof(string));
                //dt.Columns.Add("Phone", typeof(string));
                //dt.Columns.Add("DiaChi", typeof(string));
                //dt.Columns.Add("AnhDaiDien", typeof(byte[]));

                //foreach (var nv in dsNhanVien)
                //{
                //    dt.Rows.Add(nv.KhachHangID, nv.HoTenKH, nv.Email, nv.Phone, nv.DiaChi, nv.AnhDaiDien);
                //}
                DataTable dt = kh_bll.GetAllCustomertoRP();

                //2. tao doi tuong 
                string rptPath = Path.Combine(Application.StartupPath, "Report", "Baocaodanhsachkhachhang.rpt");
                ReportDocument rp = new ReportDocument();
                rp.Load(rptPath);
                //3. Gan datasource 
                rp.SetDataSource(dt);

                //4. Gan rp vao view
                crystalReportViewer1.ReportSource = rp;
                crystalReportViewer1.Refresh();
            }
            catch (Exception ex)
            {
                {
                    MessageBox.Show("Lỗi khi tải báo cáo: " + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
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
        private void button1_Click(object sender, EventArgs e)
        {

            try
            {
                //1. lay du lieu tu khach hang tu bll

                DataTable dt = kh_bll.GetCustomerInRP(txtSearch.Text);

                //2. tao doi tuong 
                string rptPath = Path.Combine(Application.StartupPath, "Report", "Baocaodanhsachkhachhang.rpt");
                ReportDocument rp = new ReportDocument();
                rp.Load(rptPath);
                //3. Gan datasource 
                rp.SetDataSource(dt);

                //4. Gan rp vao view
                crystalReportViewer1.ReportSource = rp;
                //crystalReportViewer1.Refresh();
            }
            catch (Exception ex)
            {
                {
                    MessageBox.Show("Lỗi khi tải báo cáo: " + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnTimKiem_KeyDown(object sender, KeyEventArgs e)
        {

        }
        public void TimKiemInRPKH()
        {
            try
            {
                //1. lay du lieu tu khach hang tu bll

                DataTable dt = kh_bll.GetCustomerInRP(txtSearch.Text);

                //2. tao doi tuong 
                string rptPath = Path.Combine(Application.StartupPath, "Report", "Baocaodanhsachkhachhang.rpt");
                ReportDocument rp = new ReportDocument();
                rp.Load(rptPath);
                //3. Gan datasource 
                rp.SetDataSource(dt);

                //4. Gan rp vao view
                crystalReportViewer1.ReportSource = rp;
                //crystalReportViewer1.Refresh();
            }
            catch (Exception ex)
            {
                {
                    MessageBox.Show("Lỗi khi tải báo cáo: " + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void txtSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                //goi ham tim kiem
                TimKiemInRPKH();
            }
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            TimKiemInRPKH();
        }
    }
 }