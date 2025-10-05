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
    public partial class quanlyyeucaukhachhang : Form
    {
        public quanlyyeucaukhachhang()
        {
            InitializeComponent();
        }

        private void quanlyyeucaukhachhang_Load(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("Yêu cầu ID", typeof(int));
            dt.Columns.Add("Khách hàng", typeof(string));
            dt.Columns.Add("Dự án", typeof(string));
            dt.Columns.Add("Nội dung yêu cầu", typeof(string));
            dt.Columns.Add("Ngày tạo", typeof(DateTime));

            dt.Rows.Add(1, "Nguyễn Văn A", "Nhà phố Thủ Đức", "Yêu cầu thay đổi vật liệu xây tường.", new DateTime(2025, 9, 10));
            dt.Rows.Add(2, "Trần Thị B", "Căn hộ Bình Dương", "Đề nghị cập nhật tiến độ thi công.", new DateTime(2025, 9, 15));
            dt.Rows.Add(3, "Lê Văn C", "Văn phòng Quận 1", "Thêm cửa sổ ở tầng 2.", new DateTime(2025, 9, 20));

            dgvYeucaukh.DataSource = dt;

            // ====== 2. Thiết lập combo box mẫu ======
            cbbKH.Items.AddRange(new string[] { "Nguyễn Văn A", "Trần Thị B", "Lê Văn C" });
            cbbDuan.Items.AddRange(new string[] { "Nhà phố Thủ Đức", "Căn hộ Bình Dương", "Văn phòng Quận 1" });

            cbbKH.SelectedIndex = 0;
            cbbDuan.SelectedIndex = 0;
            dtpNgaytao.Value = DateTime.Now;
        }
    }
}
