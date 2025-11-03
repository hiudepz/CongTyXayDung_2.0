using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BLL;

namespace GUI.NhanVienKho
{
    public partial class ThongTinChiTietNhanVienDatHang : Form
    {
        public int SelectedNhanVienID { get; private set; }
        public string SelectedHoTen { get; private set; }
        public ThongTinChiTietNhanVienDatHang()
        {
            InitializeComponent();
        }
        private NhanVien_BLL NhanVien_BLL = new NhanVien_BLL();
        private void ThongTinChiTietNhanVienDatHang_Load(object sender, EventArgs e)
        {
            //lay du lieu tu nhan vien
            dgvNhanVien.DataSource = NhanVien_BLL.Laydanhsachnhanvien();
            dgvNhanVien.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void btnChon_Click(object sender, EventArgs e)
        {
            
        }

        private void dgvNhanVien_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                SelectedNhanVienID = (int)dgvNhanVien.Rows[e.RowIndex].Cells["NhanVienID"].Value;
                SelectedHoTen = dgvNhanVien.Rows[e.RowIndex].Cells["HoTen"].Value.ToString();
                DialogResult = DialogResult.OK;
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string keyword = txtTimKiem.Text.Trim();

                if (string.IsNullOrWhiteSpace(keyword))
                {
                    // Nếu trống => load lại toàn bộ danh sách
                    dgvNhanVien.DataSource = NhanVien_BLL.Laydanhsachnhanvien();
                    return;
                }

                var ketqua = NhanVien_BLL.TimKiem(keyword);

                if (ketqua.Count == 0)
                {
                    MessageBox.Show("Không tìm thấy nhân viên nào phù hợp!", "Kết quả", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                dgvNhanVien.DataSource = ketqua;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Đã xảy ra lỗi khi tìm kiếm: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
    }
}
