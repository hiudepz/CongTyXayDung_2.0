using BLL;
using DTO;
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
    public partial class SuaNguoiDung : Form
    {
        private NguoiDung_BLL nd_bll = new NguoiDung_BLL();
        private NhanVien_BLL nv_bll = new NhanVien_BLL();
        public SuaNguoiDung()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            // Hiển thị xác nhận trước khi sửa
            var dr = MessageBox.Show("Bạn có chắc muốn lưu thay đổi?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr != DialogResult.Yes)
                return;
            try
            {

                // Parse NguoiDungID an toàn
                if (!int.TryParse(txtNguoiDungID.Text?.Trim(), out int nguoiDungId))
                {
                    MessageBox.Show("ID người dùng không hợp lệ.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Lấy NhanVienID từ SelectedValue (có thể null)
                int? nhanVienId = null;
                var sel = cbbNhanVien.SelectedValue;
                if (sel != null && int.TryParse(sel.ToString(), out int parsedNv))
                    nhanVienId = parsedNv;

                // Lấy vai trò từ combobox (nếu dùng DataSource là string list thì SelectedItem trả về string)
                string vaiTro = null;
                if (cbbVaiTro.SelectedItem != null)
                    vaiTro = cbbVaiTro.SelectedItem.ToString();
                else
                    vaiTro = cbbVaiTro.Text?.Trim();

                var nd = new NguoiDung_DTO
                {
                    NguoiDungID = nguoiDungId,
                    TenDangNhap = txtTenDangNhap.Text?.Trim(),
                    MatKhau = txtMatKhau.Text?.Trim(),
                    VaiTro = vaiTro,
                    NhanVienID = nhanVienId
                };

                var validationMsg = nd_bll.CheckSua(nd);
                if (!string.IsNullOrEmpty(validationMsg))
                {
                    MessageBox.Show(validationMsg, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Gọi UpdateUser (không gọi AddUser khi sửa)
                nd_bll.UpdateUser(nd);

                MessageBox.Show("Sửa người dùng thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi sửa người dùng: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SuaNguoiDung_Load(object sender, EventArgs e)
        {
            dgvNguoiDung.DataSource = nd_bll.GetAllUser();

            cbbVaiTro.Items.Add("Admin");
            cbbVaiTro.Items.Add("Nhân Viên Giám Sát");
            cbbVaiTro.Items.Add("Nhân Viên Kinh Doanh");
            cbbVaiTro.Items.Add("Nhân Viên Kế Toán");
            cbbVaiTro.Items.Add("Nhân Viên Kho");

            dgvNguoiDung.Columns["NhanVienID"].Visible = false;

            // truyen du lieu vao combobox NhanVien
            cbbNhanVien.DataSource = nv_bll.Laydanhsachnhanvien().GroupBy(u => new { u.NhanVienID, u.HoTen })
                                                                    .Select(g => g.First()) // lấy phần tử đầu tiên mỗi nhóm
                                                                          .ToList();
            cbbNhanVien.DisplayMember = "HoTen";
            cbbNhanVien.ValueMember = "NhanVienID"
            ;
        }

        private void dgvNhanVien_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                // Đảm bảo người dùng click vào hàng hợp lệ
                if (e.RowIndex < 0 || e.RowIndex >= dgvNguoiDung.Rows.Count)
                    return;

                var row = dgvNguoiDung.Rows[e.RowIndex];

                // Gán dữ liệu vào các textbox
                cbbNhanVien.Text = row.Cells["HoTenNhanVien"]?.Value?.ToString() ?? string.Empty;
                txtNguoiDungID.Text = row.Cells["NguoiDungID"]?.Value?.ToString() ?? string.Empty;
                txtMatKhau.Text = row.Cells["MatKhau"]?.Value?.ToString() ?? string.Empty;
                txtTenDangNhap.Text = row.Cells["TenDangNhap"]?.Value?.ToString() ?? string.Empty;
                cbbVaiTro.Text = row.Cells["VaiTro"]?.Value?.ToString() ?? string.Empty;

            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải thông tin nhân viên: " + ex.Message,
                                "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void TxtSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.Handled = true;
                e.SuppressKeyPress = true;
                LoadUsers(txtTimKiem.Text);
            }
        }
        private void LoadUsers(string filter = null)
        {
            List<NguoiDung_DTO> users = nd_bll.SearchUsers(filter);
            dgvNguoiDung.DataSource = users;
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            LoadUsers(txtTimKiem.Text);
        }

        private void txtTimKiem_TextChanged(object sender, EventArgs e)
        {
            LoadUsers(txtTimKiem.Text);
        }
       
    }
}
