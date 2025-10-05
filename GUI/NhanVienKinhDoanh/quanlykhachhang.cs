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
    public partial class quanlykhachhang : Form
    {
        public quanlykhachhang()
        {
            InitializeComponent();
        }

        private void dgvKhachhang_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void quanlykhachhang_Load(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("ID", typeof(int));
            dt.Columns.Add("Họ tên", typeof(string));
            dt.Columns.Add("Email", typeof(string));
            dt.Columns.Add("Phone", typeof(string));
            dt.Columns.Add("Địa chỉ", typeof(string));

            dt.Rows.Add(1, "Công ty Xây dựng Hòa Bình", "contact@hoabinh.com", "0901234567", "Quận 1, TP.HCM");
            dt.Rows.Add(2, "Công ty Cổ phần Coteccons", "info@coteccons.vn", "0907654321", "Quận Bình Thạnh, TP.HCM");
            dt.Rows.Add(3, "Công ty VinGroup", "support@vingroup.vn", "0912345678", "Quận Hai Bà Trưng, Hà Nội");
            dt.Rows.Add(4, "Công ty SunGroup", "contact@sungroup.com.vn", "0987654321", "Quận Ngũ Hành Sơn, Đà Nẵng");

            dgvKhachhang.DataSource = dt;
        }
    }
}
