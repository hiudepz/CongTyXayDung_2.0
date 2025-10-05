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
    public partial class quanlyhopdong : Form
    {
        public quanlyhopdong()
        {
            InitializeComponent();
        }

        private void quanlyhopdong_Load(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();

            
            dt.Columns.Add("HopDongID", typeof(int));
            dt.Columns.Add("Khách hàng", typeof(string));
            dt.Columns.Add("Ngày ký", typeof(DateTime));
            dt.Columns.Add("Giá trị", typeof(decimal));
            dt.Columns.Add("Mô tả", typeof(string));

            dt.Rows.Add(1, "Nguyen A", new DateTime(2025, 1, 10), 500000000, "Xây dựng nhà máy");
            dt.Rows.Add(2, "Nguyen B", new DateTime(2025, 2, 15), 200000000, "Sửa chữa văn phòng");
            dt.Rows.Add(3, "Nguyen C", new DateTime(2025, 3, 1), 150000000, "Xây dựng kho bãi");
            dt.Rows.Add(4, "Nguyen D", new DateTime(2025, 4, 5), 300000000, "Thi công chung cư");

          
            dgvQlhopdong.DataSource = dt;

            // Format số
            dgvQlhopdong.Columns["Giá trị"].DefaultCellStyle.Format = "N0";
            dgvQlhopdong.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void btnPhancongnhanvienhopdong_Click(object sender, EventArgs e)
        {
            // Lấy ID hợp đồng đang chọn trong DataGridView
            if (dgvQlhopdong.CurrentRow != null)
            {
                string hopDongID = dgvQlhopdong.CurrentRow.Cells["HopDongID"].Value.ToString();

                // Tạo form phân công và truyền HopDongID vào
                phancongnhanvienchohopdong frm = new phancongnhanvienchohopdong(/*hopDongID*/);
                frm.ShowDialog();
            }
            else
            {
                MessageBox.Show("Vui lòng chọn hợp đồng trước khi phân công!");
            }
        }
    }
}
