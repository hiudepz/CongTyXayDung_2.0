using BLL;
using GUI.NhanVienKho;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI.NhanVienKeToan
{
    public partial class DanhSachThanhToan : Form
    {
        private ThanhToan_BLL tt_bll = new ThanhToan_BLL();
        public DanhSachThanhToan()
        {
            InitializeComponent();
            SetupGrid(dgvDuAn);
            SetupGrid(dgvDonDatHang);
        }
        private void SetupGrid(Guna.UI2.WinForms.Guna2DataGridView grid)
        {
            // Nền chung
            grid.BackgroundColor = Color.White;
            grid.BorderStyle = BorderStyle.FixedSingle;

            // Không tự sinh dòng trống
            grid.AllowUserToAddRows = false;

            // Chọn nguyên dòng
            grid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            grid.MultiSelect = false;
            grid.ReadOnly = true;

            // Tự giãn theo nội dung
            grid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            // Bố cục Header
            grid.ColumnHeadersHeight = 32;
            grid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing;

            // Kiểu dữ liệu Theme
            grid.EnableHeadersVisualStyles = false;

            // Style cho Header
            grid.ThemeStyle.HeaderStyle.BackColor = Color.FromArgb(230, 230, 230);
            grid.ThemeStyle.HeaderStyle.ForeColor = Color.Black;
            grid.ThemeStyle.HeaderStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            grid.ThemeStyle.HeaderStyle.BorderStyle = DataGridViewHeaderBorderStyle.Single;
            grid.ThemeStyle.HeaderStyle.Height = 32;

            // Style cho dòng dữ liệu
            grid.ThemeStyle.RowsStyle.BackColor = Color.White;
            grid.ThemeStyle.RowsStyle.ForeColor = Color.Black;
            grid.ThemeStyle.RowsStyle.Font = new Font("Segoe UI", 10, FontStyle.Regular);
            grid.ThemeStyle.RowsStyle.SelectionBackColor = Color.FromArgb(210, 210, 210);
            grid.ThemeStyle.RowsStyle.SelectionForeColor = Color.Black;
            grid.ThemeStyle.RowsStyle.BorderStyle = DataGridViewCellBorderStyle.Single;

            // Alternating row (dòng xen kẽ)
            grid.ThemeStyle.AlternatingRowsStyle.BackColor = Color.FromArgb(245, 245, 245);

            // Đường viền bảng
            grid.GridColor = Color.FromArgb(220, 220, 220);
        }

        

        

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            ThanhToan tt = new ThanhToan();
            tt.Show();
        }
       
        
        
        

        private void DanhSachThanhToan_Load(object sender, EventArgs e)
        {
            dgvDonDatHang.DataSource = tt_bll.GetAllOrder();
            dgvDuAn.DataSource = tt_bll.GetAllPro();
        }

        private void guna2DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                int id = Convert.ToInt32(dgvDonDatHang.Rows[e.RowIndex].Cells["DonDatHangID"].Value);
                decimal tongTien = Convert.ToDecimal(dgvDonDatHang.Rows[e.RowIndex].Cells["TongTien"].Value);
                decimal tienNo = Convert.ToDecimal(dgvDonDatHang.Rows[e.RowIndex].Cells["TienNo"].Value);

                var form = new ThanhToan(id, null, tongTien,tienNo); // null dự án
                form.FormClosed += (s, args) =>
                {
                    dgvDonDatHang.DataSource = tt_bll.GetAllOrder();
                    
                };
                form.Show();
            }
        }

        private void dgvDuAn_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                int id = Convert.ToInt32(dgvDuAn.Rows[e.RowIndex].Cells["DuAnID"].Value);
                decimal giaTri = Convert.ToDecimal(dgvDuAn.Rows[e.RowIndex].Cells["GiaTriHopDong"].Value);
                decimal tienNo = Convert.ToDecimal(dgvDuAn.Rows[e.RowIndex].Cells["TienNo"].Value);

                var form = new ThanhToan(null, id, giaTri, tienNo);
                form.FormClosed += (s, args) =>
                {
                   
                    dgvDuAn.DataSource = tt_bll.GetAllPro();
                };
                form.Show();
            }
        }
    }
}
