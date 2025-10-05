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
    public partial class phancongnhansuchoduan : Form
    {
        public phancongnhansuchoduan()
        {
            InitializeComponent();
        }

        private void phancongnhansuchoduan_Load(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("Tên nhân viên", typeof(string));
            dt.Columns.Add("Nhiệm vụ", typeof(string));
            dt.Columns.Add("Ngày bắt đầu", typeof(DateTime));
            dt.Columns.Add("Ngày kết thúc", typeof(DateTime));

            dt.Rows.Add("Nguyễn Văn A", "Giám sát", new DateTime(2025, 10, 1), new DateTime(2025, 10, 15));
            dt.Rows.Add("Trần Thị B", "Thi công chính", new DateTime(2025, 10, 1), new DateTime(2025, 11, 30));
            dt.Rows.Add("Lê Văn C", "Kế toán dự án", new DateTime(2025, 10, 1), new DateTime(2025, 12, 15));

            dgvPhancongduan.DataSource = dt;

            
            cbbDuan.Items.Add("Dự án A");
            cbbDuan.Items.Add("Dự án B");

            cbbNhanvien.Items.Add("Nguyễn Văn A");
            cbbNhanvien.Items.Add("Trần Thị B");
            cbbNhanvien.Items.Add("Lê Văn C");
        }
    }
}
