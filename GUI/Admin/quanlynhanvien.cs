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
    public partial class quanlynhanvien : Form
    {
        public quanlynhanvien()
        {
            InitializeComponent();
        }

        private void dgvQuanlynhanvien_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void quanlynhanvien_Load(object sender, EventArgs e)
        {
            //this.Dock = DockStyle.Fill;
            
            DataTable dt = new DataTable();
            dt.Columns.Add("ID", typeof(int));
            dt.Columns.Add("Họ tên", typeof(string));
            dt.Columns.Add("Email", typeof(string));
            dt.Columns.Add("Phone", typeof(string));
            dt.Columns.Add("Vai trò", typeof(string));

            dt.Rows.Add(1, "Nguyễn Văn An", "an.nguyen@company.com", "0901111222", "Kỹ sư xây dựng");
            dt.Rows.Add(2, "Trần Thị Bình", "binh.tran@company.com", "0902222333", "Kế toán");
            dt.Rows.Add(3, "Lê Văn Cường", "cuong.le@company.com", "0903333444", "Quản lý kho");
            dt.Rows.Add(4, "Phạm Thị Dung", "dung.pham@company.com", "0904444555", "Giám sát công trình");

            dgvQuanlynhanvien.DataSource = dt;

        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }
    }
}
