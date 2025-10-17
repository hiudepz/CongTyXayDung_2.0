using BLL;
using DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI
{
    public partial class quanlynhanvien : Form
    {
        private NhanVien_BLL bll = new NhanVien_BLL();
        public quanlynhanvien()
        {
            InitializeComponent();
        }
        private byte[] Anhdaidien;
        private void dgvQuanlynhanvien_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void quanlynhanvien_Load(object sender, EventArgs e)
        {
            //this.Dock = DockStyle.Fill;
            
            //DataTable dt = new DataTable();
            //dt.Columns.Add("ID", typeof(int));
            //dt.Columns.Add("Họ tên", typeof(string));
            //dt.Columns.Add("Email", typeof(string));
            //dt.Columns.Add("Phone", typeof(string));
            //dt.Columns.Add("Vai trò", typeof(string));

            //dt.Rows.Add(1, "Nguyễn Văn An", "an.nguyen@company.com", "0901111222", "Kỹ sư xây dựng");
            //dt.Rows.Add(2, "Trần Thị Bình", "binh.tran@company.com", "0902222333", "Kế toán");
            //dt.Rows.Add(3, "Lê Văn Cường", "cuong.le@company.com", "0903333444", "Quản lý kho");
            //dt.Rows.Add(4, "Phạm Thị Dung", "dung.pham@company.com", "0904444555", "Giám sát công trình");

            //dgvQuanlynhanvien.DataSource = dt;
            dgvQuanlynhanvien.DataSource = bll.Laydanhsachnhanvien();
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void btnThemnhanvien_Click(object sender, EventArgs e)
        {

            var nhanvien = new NhanVien_DTO
            {
                HoTen = txtHotennhanvien.Text,
                Email = txtEmailnhanvien.Text,
                Phone = txtPhonenhanvien.Text,
                VaiTro = txtPhonenhanvien.Text,
                AnhDaiDien = Anhdaidien
            };
            bll.Add(nhanvien);
        }

        private void btnHinhanhnhanvien_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Filter = "Ảnh (*.jpg;*.png)|*.jpg;*.png";
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    ptAnhDaiDien.Image = Image.FromFile(ofd.FileName);

                    // Chuyển ảnh thành mảng byte để lưu vào DB
                    using (var ms = new MemoryStream())
                    {
                        ptAnhDaiDien.Image.Save(ms, ptAnhDaiDien.Image.RawFormat);
                        Anhdaidien = ms.ToArray();
                    }
                }
            }
        }
    }
}
