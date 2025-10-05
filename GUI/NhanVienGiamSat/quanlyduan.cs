using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI
{
    public partial class quanlyduan : Form
    {
        public quanlyduan()
        {
            InitializeComponent();
        }

        private void quanlyduan_Load(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();

            dt.Columns.Add("ID", typeof(int));
            dt.Columns.Add("Tên dự án", typeof(string));
            dt.Columns.Add("Khách hàng", typeof(string));
            dt.Columns.Add("Ngày bắt đầu", typeof(DateTime));
            dt.Columns.Add("Ngày kết thúc", typeof(DateTime));
            dt.Columns.Add("Tiến độ", typeof(string));

            // Dữ liệu mẫu
            dt.Rows.Add(1, "Xây nhà máy Bình Dương", "Nguyen A", new DateTime(2025, 1, 10), new DateTime(2025, 6, 20), "40%");
            dt.Rows.Add(2, "Chung cư Quận 9", "Nguyen B", new DateTime(2025, 2, 5), new DateTime(2025, 12, 30), "20%");
            dt.Rows.Add(3, "Cầu vượt Đồng Nai", "Nguyen C", new DateTime(2025, 3, 15), new DateTime(2026, 3, 15), "10%");

            dgvQuanlyduan.DataSource = dt;
            dgvQuanlyduan.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            // Load combobox khách hàng (demo)
            cbbKhachhang.Items.Add("Nguyen A");
            cbbKhachhang.Items.Add("Nguyen B");
            cbbKhachhang.Items.Add("Nguyen C");
        }

        private void btnPhancongnhansuchoduan_Click(object sender, EventArgs e)
        {
            // Lấy ID hợp đồng đang chọn trong DataGridView
            if (dgvQuanlyduan.CurrentRow != null)
            {
                string iD = dgvQuanlyduan.CurrentRow.Cells["ID"].Value.ToString();

                // Tạo form phân công và truyền HopDongID vào
                phancongnhansuchoduan frm = new phancongnhansuchoduan(/*hopDongID*/);
                frm.ShowDialog();
            }
            else
            {
                MessageBox.Show("Vui lòng chọn hợp đồng trước khi phân công!");
            }
        }
    }
}
