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
            try
            {
                // Đảm bảo người dùng click vào hàng hợp lệ
                if (e.RowIndex < 0 || e.RowIndex >= dgvQuanlynhanvien.Rows.Count)
                    return;

                var row = dgvQuanlynhanvien.Rows[e.RowIndex];

                // Gán dữ liệu vào các textbox
                txtManhanvien.Text = row.Cells["NhanVienID"]?.Value?.ToString() ?? string.Empty;
                txtHotennhanvien.Text = row.Cells["HoTen"]?.Value?.ToString() ?? string.Empty;
                txtEmailnhanvien.Text = row.Cells["Email"]?.Value?.ToString() ?? string.Empty;
                txtPhonenhanvien.Text = row.Cells["Phone"]?.Value?.ToString() ?? string.Empty;
                txtVaitronhanvien.Text = row.Cells["VaiTro"]?.Value?.ToString() ?? string.Empty;

                // Xử lý ảnh đại diện (nếu có)
                var cellValue = row.Cells["AnhDaiDien"]?.Value;

                if (cellValue != null && cellValue is byte[] bytes && bytes.Length > 0)
                {
                    using (var ms = new MemoryStream(bytes))
                    {
                        ptAnhDaiDien.Image = Image.FromStream(ms);
                    }
                    Anhdaidien = bytes;
                }
                else
                {
                    // Nếu null hoặc không có ảnh
                    ptAnhDaiDien.Image = null;
                    Anhdaidien = null;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải thông tin nhân viên: " + ex.Message,
                                "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void quanlynhanvien_Load(object sender, EventArgs e)
        {

            //tắt chỉnh sửa trực tiếp trên dgv
            dgvQuanlynhanvien.ReadOnly = true;
            dgvQuanlynhanvien.AllowUserToAddRows = false;
            dgvQuanlynhanvien.AllowUserToDeleteRows = false;
            dgvQuanlynhanvien.EditMode = DataGridViewEditMode.EditProgrammatically;

            dgvQuanlynhanvien.DataSource = bll.Laydanhsachnhanvien();
            ((DataGridViewImageColumn)dgvQuanlynhanvien.Columns["AnhDaiDien"]).ImageLayout = DataGridViewImageCellLayout.Zoom;
            dgvQuanlynhanvien.RowTemplate.Height = 100;
            ptAnhDaiDien.SizeMode = PictureBoxSizeMode.Zoom;
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void btnThemnhanvien_Click(object sender, EventArgs e)
        {
            try
            {
                var nhanvien = new NhanVien_DTO
                {
                    HoTen = txtHotennhanvien.Text,
                    Email = txtEmailnhanvien.Text,
                    Phone = txtPhonenhanvien.Text,
                    VaiTro = txtVaitronhanvien.Text,
                    AnhDaiDien = Anhdaidien
                };
                bll.Add(nhanvien);
                MessageBox.Show("Thêm nhân viên thành công!");
                dgvQuanlynhanvien.DataSource = bll.Laydanhsachnhanvien();
                ReloadGridAndKeepSelection(nhanvien.NhanVienID);

            }
            catch (ArgumentException ex)
            {
                MessageBox.Show("Lỗi dữ liệu: " + ex.Message, "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi hệ thống: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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

        private void btnTimkiemnhanvien_Click(object sender, EventArgs e)
        {
            try
            {
                string keyword = txtTimkiemnhanvien.Text.Trim();

                if (string.IsNullOrWhiteSpace(keyword))
                {
                    // Nếu trống => load lại toàn bộ danh sách
                    dgvQuanlynhanvien.DataSource = bll.Laydanhsachnhanvien();
                    return;
                }

                var ketqua = bll.TimKiem(keyword);

                if (ketqua.Count == 0)
                {
                    MessageBox.Show("Không tìm thấy nhân viên nào phù hợp!", "Kết quả", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                dgvQuanlynhanvien.DataSource = ketqua;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Đã xảy ra lỗi khi tìm kiếm: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSuanhanvien_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvQuanlynhanvien.CurrentRow == null)
                {
                    MessageBox.Show("Vui lòng chọn nhân viên cần sửa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var nv = new NhanVien_DTO
                {
                    NhanVienID = Convert.ToInt32(dgvQuanlynhanvien.CurrentRow.Cells["NhanVienID"].Value),
                    HoTen = txtHotennhanvien.Text.Trim(),
                    Email = txtEmailnhanvien.Text.Trim(),
                    Phone = txtPhonenhanvien.Text.Trim(),
                    VaiTro = txtVaitronhanvien.Text.Trim(),
                    AnhDaiDien = Anhdaidien
                };

                bll.Edit(nv);
                MessageBox.Show("Sửa nhân viên thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                dgvQuanlynhanvien.DataSource = bll.Laydanhsachnhanvien();
                ReloadGridAndKeepSelection(nv.NhanVienID);
            }
            catch (ArgumentException ex)
            {
                // Lỗi do nhập dữ liệu không hợp lệ
                MessageBox.Show("Lỗi dữ liệu: " + ex.Message, "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                // Lỗi hệ thống hoặc không xác định
                MessageBox.Show("Lỗi hệ thống: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnXoanhanvien_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvQuanlynhanvien.CurrentRow == null)
                {
                    MessageBox.Show("Vui lòng chọn nhân viên cần xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                int id = Convert.ToInt32(dgvQuanlynhanvien.CurrentRow.Cells["NhanVienID"].Value);
                string hoten = dgvQuanlynhanvien.CurrentRow.Cells["HoTen"].Value?.ToString();

                var result = MessageBox.Show(
                    $"Bạn có chắc chắn muốn xóa nhân viên '{hoten}' không?",
                    "Xác nhận xóa",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question
                );

                if (result == DialogResult.Yes)
                {
                    bll.Delete(id);
                    MessageBox.Show("Xóa nhân viên thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dgvQuanlynhanvien.DataSource = bll.Laydanhsachnhanvien();
                    ReloadGridAndKeepSelection(null);
                }
            }
            catch (InvalidOperationException ex)
            {
                // Lỗi ràng buộc khóa ngoại (foreign key)
                MessageBox.Show(ex.Message, "Lỗi ràng buộc dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (ArgumentException ex)
            {
                // Lỗi dữ liệu đầu vào
                MessageBox.Show("Lỗi dữ liệu: " + ex.Message, "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                // Các lỗi khác
                MessageBox.Show("Lỗi hệ thống: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtTimkiemnhanvien_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string keyword = txtTimkiemnhanvien.Text.Trim();

                if (string.IsNullOrWhiteSpace(keyword))
                {
                    // Nếu trống => load lại toàn bộ danh sách
                    dgvQuanlynhanvien.DataSource = bll.Laydanhsachnhanvien();
                    return;
                }

                var ketqua = bll.TimKiem(keyword);

                if (ketqua.Count == 0)
                {
                    MessageBox.Show("Không tìm thấy nhân viên nào phù hợp!", "Kết quả", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                dgvQuanlynhanvien.DataSource = ketqua;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Đã xảy ra lỗi khi tìm kiếm: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
        private void ReloadGridAndKeepSelection(int? selectedId = null)
        {
            var data = bll.Laydanhsachnhanvien();
            dgvQuanlynhanvien.DataSource = data;

            if (selectedId.HasValue)
            {
                foreach (DataGridViewRow row in dgvQuanlynhanvien.Rows)
                {
                    if (Convert.ToInt32(row.Cells["NhanVienID"].Value) == selectedId.Value)
                    {
                        row.Selected = true;
                        dgvQuanlynhanvien.CurrentCell = row.Cells[0]; // Đặt focus vào dòng đó
                        break;
                    }
                }
            }
        }

        private void dgvQuanlynhanvien_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                // Đảm bảo người dùng click vào hàng hợp lệ
                if (e.RowIndex < 0 || e.RowIndex >= dgvQuanlynhanvien.Rows.Count)
                    return;

                var row = dgvQuanlynhanvien.Rows[e.RowIndex];

                // Gán dữ liệu vào các textbox
                txtManhanvien.Text = row.Cells["NhanVienID"]?.Value?.ToString() ?? string.Empty;
                txtHotennhanvien.Text = row.Cells["HoTen"]?.Value?.ToString() ?? string.Empty;
                txtEmailnhanvien.Text = row.Cells["Email"]?.Value?.ToString() ?? string.Empty;
                txtPhonenhanvien.Text = row.Cells["Phone"]?.Value?.ToString() ?? string.Empty;
                txtVaitronhanvien.Text = row.Cells["VaiTro"]?.Value?.ToString() ?? string.Empty;

                // Xử lý ảnh đại diện (nếu có)
                var cellValue = row.Cells["AnhDaiDien"]?.Value;

                if (cellValue != null && cellValue is byte[] bytes && bytes.Length > 0)
                {
                    using (var ms = new MemoryStream(bytes))
                    {
                        ptAnhDaiDien.Image = Image.FromStream(ms);
                    }
                    Anhdaidien = bytes;
                }
                else
                {
                    // Nếu null hoặc không có ảnh
                    ptAnhDaiDien.Image = null;
                    Anhdaidien = null;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải thông tin nhân viên: " + ex.Message,
                                "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
