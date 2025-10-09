using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI.Admin
{
    public partial class QuanLyNguoiDung : Form
    {
        public QuanLyNguoiDung()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ThemNguoiDung addUser = new ThemNguoiDung();
            addUser.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            SuaNguoiDung addUser = new SuaNguoiDung();
            addUser.ShowDialog();
        }

        private void QuanLyNguoiDung_Load(object sender, EventArgs e)
        {
            //this.Dock = DockStyle.Fill;
            DataTable dt = new DataTable();
            dt.Columns.Add("NguoiDungID", typeof(int));
            dt.Columns.Add("TenDangNhap", typeof(string));
            dt.Columns.Add("HoTen", typeof(string));
            dt.Columns.Add("VaiTro", typeof(string));
            dt.Columns.Add("Email", typeof(string));
            dt.Columns.Add("TrangThai", typeof(string));

            dt.Rows.Add(1, "admin", "Nguyễn Văn Quản", "Quản trị viên", "admin@xaydung.vn", "Hoạt động");
            dt.Rows.Add(2, "ketoan01", "Lê Thị Mai", "Kế toán", "lemai@xaydung.vn", "Hoạt động");
            dt.Rows.Add(3, "giam_sat01", "Phạm Văn Hùng", "Giám sát", "hungpham@xaydung.vn", "Hoạt động");
            dt.Rows.Add(4, "nhanvien_kho", "Trần Quốc Khánh", "Nhân viên kho", "khanhtran@xaydung.vn", "Hoạt động");
            dt.Rows.Add(5, "nhanvien01", "Võ Đức Tài", "Nhân viên thi công", "tai.vo@xaydung.vn", "Đã khóa");

            dataGridView1.DataSource = dt;
        }
    }
}
