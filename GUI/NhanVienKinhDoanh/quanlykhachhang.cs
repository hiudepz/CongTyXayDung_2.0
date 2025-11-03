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
    public partial class quanlykhachhang : Form
    {
        public quanlykhachhang()
        {
            InitializeComponent();
        }
        private byte[] Anhdaidien;
        private KhachHang_BLL KhachHang_bll = new KhachHang_BLL();

        private void dgvKhachhang_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                // Đảm bảo người dùng click vào hàng hợp lệ
                if (e.RowIndex < 0 || e.RowIndex >= dgvKhachhang.Rows.Count)
                    return;

                var row = dgvKhachhang.Rows[e.RowIndex];

                // Gán dữ liệu vào các textbox
                txtMakhachhang.Text = row.Cells["KhachHangID"]?.Value?.ToString() ?? string.Empty;
                txtHotenkhachhang.Text = row.Cells["HoTenKH"]?.Value?.ToString() ?? string.Empty;
                txtEmail.Text = row.Cells["Email"]?.Value?.ToString() ?? string.Empty;
                txtPhonekhachhang.Text = row.Cells["Phone"]?.Value?.ToString() ?? string.Empty;
                txtDiaChi.Text = row.Cells["DiaChi"]?.Value?.ToString() ?? string.Empty;

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

        private void quanlykhachhang_Load(object sender, EventArgs e)
        {
            dgvKhachhang.DataSource = KhachHang_bll.GetAllCustomer();
        }
        private void LoadCustomer(string filter = null)
        {
            List<KhachHang_DTO> users = KhachHang_bll.SearchCustomers(filter);
            dgvKhachhang.DataSource = users;
        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            LoadCustomer(txtTimKiem.Text);
        }

        private void btnThemkhachhang_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvKhachhang.CurrentRow == null)
                {
                    MessageBox.Show("Vui lòng chọn người dùng cần thêm!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                // Parse NhanVienID from the textbox. If empty -> null; if invalid -> show error and abort.
                int? khachhangId = null;
                var idText = txtMakhachhang.Text?.Trim();
                if (!string.IsNullOrEmpty(idText))
                {
                    if (int.TryParse(idText, out int parsedId))
                        khachhangId = parsedId;
                    else
                    {
                        MessageBox.Show("Mã nhân viên không hợp lệ. Vui lòng nhập một số nguyên.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                }

                KhachHang_DTO kh = new KhachHang_DTO
                {
                    HoTenKH = txtHotenkhachhang.Text.Trim(),
                    Email = txtEmail.Text.Trim(),
                    Phone = txtPhonekhachhang.Text.Trim(),
                    DiaChi = txtDiaChi.Text.Trim(),
                    AnhDaiDien = Anhdaidien
                };
                // Optional: validate via BLL if available
                var validationMsg = KhachHang_bll.CheckAdd(kh);
                if (!string.IsNullOrEmpty(validationMsg))
                {
                    MessageBox.Show(validationMsg, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                KhachHang_bll.AddCustomer(kh);
                MessageBox.Show("Thêm người dùng thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                dgvKhachhang.DataSource = KhachHang_bll.GetAllCustomer();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Vui lòng kiểm tra lại các lỗi sau:\n\n" + ex.Message,
                                "Thông báo",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);
            }
        }

        private void btnLogoncc_Click(object sender, EventArgs e)
        {
            
        }

        private void btnSuakhachhang_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvKhachhang.CurrentRow == null)
                {
                    MessageBox.Show("Vui lòng chọn khách hàng cần sửa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                var kh_dto = new KhachHang_DTO
                {
                    KhachHangID = int.Parse(txtMakhachhang.Text),
                    HoTenKH = txtHotenkhachhang.Text,
                    Email = txtEmail.Text,
                    Phone = txtPhonekhachhang.Text,
                    DiaChi = txtDiaChi.Text,
                    AnhDaiDien = Anhdaidien
                };
                // Optional: validate via BLL if available
                var validationMsg = KhachHang_bll.CheckAdd(kh_dto);
                if (!string.IsNullOrEmpty(validationMsg))
                {
                    MessageBox.Show(validationMsg, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                KhachHang_bll.UpdateCustomer(kh_dto);
                MessageBox.Show("Sửa khách hàng thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                dgvKhachhang.DataSource = KhachHang_bll.GetAllCustomer();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Vui lòng kiểm tra lại các lỗi sau:\n\n" + ex.Message,
                                "Thông báo",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);
            }
        }

        private void btnXoakhachhang_Click(object sender, EventArgs e)
        {
            if (txtMakhachhang == null)
            {
                MessageBox.Show("Vui lòng chọn khách hàng cần xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else
            {
                int customerId = int.Parse(txtMakhachhang.Text);
                var confirmResult = MessageBox.Show("Bạn có chắc chắn muốn xóa khách hàng này?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (confirmResult == DialogResult.Yes)
                {
                    try
                    {
                        KhachHang_bll.DeleteCustomer(customerId);
                        MessageBox.Show("Xóa khách hàng thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        dgvKhachhang.DataSource = KhachHang_bll.GetAllCustomer();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Lỗi khi xóa khách hàng: " + ex.Message,
                                        "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void ptAnhDaiDien_Click(object sender, EventArgs e)
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
