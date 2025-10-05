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
    public partial class quanlyvattu : Form
    {
        public quanlyvattu()
        {
            InitializeComponent();
        }

        private void dgvVattu_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void quanlyvattu_Load(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("ID", typeof(int));
            dt.Columns.Add("Tên vật tư", typeof(string));
            dt.Columns.Add("Đơn vị", typeof(string));
            dt.Columns.Add("Số lượng tồn", typeof(int));
            dt.Columns.Add("Nhà cung cấp", typeof(string));

            dt.Rows.Add(1, "Xi măng Holcim", "Bao", 1500, "Công ty Xi măng Holcim");
            dt.Rows.Add(2, "Gạch nung đỏ", "Viên", 12000, "Công ty Gạch Đồng Tâm");
            dt.Rows.Add(3, "Thép Việt Nhật", "Cây", 500, "Công ty Thép Việt Nhật");
            dt.Rows.Add(4, "Cát vàng sông Hồng", "Khối", 300, "Công ty VLXD Miền Bắc");
            dt.Rows.Add(5, "Đá 1x2", "Khối", 700, "Công ty VLXD Miền Nam");

            cbbNCC.Items.AddRange(new string[] { "Công ty Xi măng Holcim", "Công ty Gạch Đồng Tâm", "Công ty Thép Việt Nhật", "Công ty VLXD Miền Bắc", "Công ty VLXD Miền Nam" });
        
            cbbNCC.SelectedIndex = 0;
            dgvVattu.DataSource = dt;
          
        }
    }
}
