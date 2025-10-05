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
    public partial class quanlynhacungcap : Form
    {
        public quanlynhacungcap()
        {
            InitializeComponent();
        }

        private void quanlynhacungcap_Load(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("ID", typeof(int));
            dt.Columns.Add("Tên Nhà cung cấp", typeof(string));
            dt.Columns.Add("Email", typeof(string));
            dt.Columns.Add("Địa chỉ", typeof(string));
            dt.Columns.Add("Phone", typeof(string));

            dt.Rows.Add(1, "Công ty Xi măng Holcim", "holcim@gmail.com", "KCN Hiệp Phước, Nhà Bè", "0901234567");
            dt.Rows.Add(2, "Công ty Gạch Đồng Tâm", "dongtam@gmail.com", "Long An", "0912345678");
            dt.Rows.Add(3, "Công ty Thép Việt Nhật", "vietnhat@gmail.com", "Hải Phòng", "0923456789");
            dt.Rows.Add(4, "Công ty VLXD Miền Bắc", "vlxdmb@gmail.com", "Hà Nội", "0934567890");
            dt.Rows.Add(5, "Công ty VLXD Miền Nam", "vlxdmn@gmail.com", "TP. Hồ Chí Minh", "0945678901");

            dgvNcc.DataSource = dt;
        }

        private void dgvNcc_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
