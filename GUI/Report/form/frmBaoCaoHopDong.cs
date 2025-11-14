using BLL;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using DTO;
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
    public partial class frmBaoCaoHopDong : Form
    {
        private readonly HopDong_BLL bll = new HopDong_BLL();
        public frmBaoCaoHopDong()
        {
            InitializeComponent();
        }

        private void crvHopDong_Load(object sender, EventArgs e)
        {
            var list = bll.GetAllHopDong();
            cbbHopDong.DataSource = list;
            cbbHopDong.DisplayMember = "TenHopDong";
            cbbHopDong.ValueMember = "HopDongID";
            cbbHopDong.SelectedIndex = 0;

            cbbHopDong.DropDownStyle = ComboBoxStyle.DropDownList;
        }
        private void LoadReport(int hopDongID)
        {
            var hd = bll.GetByID(hopDongID); //return hopdong_dto

            var dt = new DataSetHopDong.HopDongDataTable();
            var row = dt.NewHopDongRow();

            row.HopDongID = hd.HopDongID;
            row.SoHopDong = hd.MaHopDong;
            row.TenHopDong = hd.TenHopDong;
            row.NgayKy = hd.NgayKy ?? DateTime.MinValue;
            row.GiaTriHopDong = hd.GiaTriHopDong;
            row.NoiDungYeuCau = hd.NoiDungYeuCau;
            row.ThoiHanThiCong = hd.ThoiHanThiCong;
            row.DieuKhoanThanhToan = hd.DieuKhoanThanhToan;
            row.TrangThai = hd.TrangThai;
            row.TenKhachHang = hd.TenKhachHang;
            row.TenDuAn = hd.TenDuAn;

            dt.AddHopDongRow(row);

            var report = new Baocaohopdong();
            report.SetDataSource((DataTable)dt);

            crvHopDong.ReportSource = report;
            crvHopDong.Refresh();
            //string path = @"C:\Reports\HopDong_" + hd.HopDongID + ".pdf";
            //report.ExportToDisk(ExportFormatType.PortableDocFormat, path);

            //MessageBox.Show("Đã xuất báo cáo hợp đồng ra PDF: " + path, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //System.Diagnostics.Process.Start(path);

        }

        private void cbbHopDong_SelectedIndexChanged(object sender, EventArgs e)
        {

            var selectedHopDong = cbbHopDong.SelectedItem as HopDong_DTO;
            if (selectedHopDong != null)
            {
                int hopDongID = selectedHopDong.HopDongID;
                LoadReport(hopDongID);
            }

        }

        private void btnExportPdf_Click(object sender, EventArgs e)
        {
            if (crvHopDong.ReportSource != null)
            {
                //Lấy report hiện tại từ CrystalReportViewer
                ReportDocument report = crvHopDong.ReportSource as ReportDocument;

                if (report != null)
                {
                    //Chọn đường dẫn lưu file PDF
                    SaveFileDialog saveFileDialog = new SaveFileDialog();
                    saveFileDialog.Filter = "PDF Files|*.pdf";
                    saveFileDialog.Title = "Chọn nơi lưu báo cáo hợp đồng";
                    saveFileDialog.FileName = "BaoCaoHopDong.pdf";

                    if (saveFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        string path = saveFileDialog.FileName;

                        //Xuất ra PDF
                        report.ExportToDisk(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, path);

                        MessageBox.Show("Đã xuất báo cáo ra PDF:\n" + path,
                                        "Thông báo",
                                        MessageBoxButtons.OK,
                                        MessageBoxIcon.Information);

                        //Mở file PDF ngay sau khi xuất
                        System.Diagnostics.Process.Start(path);
                    }
                }
            }
            else
            {
                MessageBox.Show("Chưa có báo cáo nào để xuất!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
