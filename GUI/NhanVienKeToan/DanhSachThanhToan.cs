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
        public DanhSachThanhToan()
        {
            InitializeComponent();
        }

        private void guna2DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void BangThanhToan_Load(object sender, EventArgs e)
        {
            // Tạo bảng dữ liệu giả lập
            DataTable dt = new DataTable();
            dt.Columns.Add("ThanhToanID", typeof(int));
            dt.Columns.Add("NgayThanhToan", typeof(DateTime));
            dt.Columns.Add("SoTien", typeof(decimal));
            dt.Columns.Add("HinhThuc", typeof(string));
            dt.Columns.Add("GhiChu", typeof(string));
            dt.Columns.Add("DuAnID", typeof(int));
            dt.Columns.Add("DonDatHangID", typeof(int));
            dt.Columns.Add("NhanVienID", typeof(int));

            // Thêm dữ liệu minh hoạ
            dt.Rows.Add(1, DateTime.Today.AddDays(-5), 25000000, "Chuyển khoản", "Thanh toán giai đoạn 1 công trình A", 101, 501, 3);
            dt.Rows.Add(2, DateTime.Today.AddDays(-3), 15000000, "Tiền mặt", "Ứng trước vật liệu", 102, 502, 3);
            dt.Rows.Add(3, DateTime.Today.AddDays(-2), 5000000, "Chuyển khoản", "Chi phí nhân công", 101, 566, 4);
            dt.Rows.Add(4, DateTime.Today.AddDays(-1), 18000000, "Chuyển khoản", "Thanh toán hoàn tất dự án B", 103, 503, 3);
            dt.Rows.Add(5, DateTime.Today, 22000000, "Tiền mặt", "Thanh toán đơn hàng vật liệu", 455, 504, 5);

            // Gán dữ liệu vào DataGridView
            dgvDSThanhToan.DataSource = dt;

           
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            SuaThanhToan stt = new SuaThanhToan();
            stt.ShowDialog();
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
             BangDonDatHang_BangDuAn tt = new BangDonDatHang_BangDuAn();
            tt.ShowDialog();
        }
    }
}
