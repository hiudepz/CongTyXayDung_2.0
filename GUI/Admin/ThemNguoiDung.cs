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

namespace GUI.Admin
{
    public partial class ThemNguoiDung : Form
    {
        private NguoiDung_BLL nd_bll = new NguoiDung_BLL();
        private NhanVien_BLL nv_bll = new NhanVien_BLL();
        public ThemNguoiDung()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
                quanlynhanvien themnhanvien = new quanlynhanvien();
                themnhanvien.ShowDialog();
        }

        private void ThemNguoiDung_Load(object sender, EventArgs e)
        {

            dgvNguoiDung.DataSource = nv_bll.Laydanhsachnhanvien();
            dgvNguoiDung.Columns["NhanVienID"].Visible = false;
            //dgvNguoiDung.Columns["NguoiDungID"].Visible = false;
            
            //them vai tro vao combobox
            cbbVaiTro.Items.Add("Admin");   
            cbbVaiTro.Items.Add("Nhân viên giám sát");
            cbbVaiTro.Items.Add("Nhân viên kế toán");
            cbbVaiTro.Items.Add("Nhân viên kho");
            cbbVaiTro.Items.Add("Nhân viên kinh doanh");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvNguoiDung.CurrentRow == null)
                {
                    MessageBox.Show("Vui lòng chọn người dùng cần thêm!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                // Parse NhanVienID from the textbox. If empty -> null; if invalid -> show error and abort.
                int? nhanVienId = null;
                var idText = txtNhanVienID.Text?.Trim();
                if (!string.IsNullOrEmpty(idText))
                {
                    if (int.TryParse(idText, out int parsedId))
                        nhanVienId = parsedId;
                    else
                    {
                        MessageBox.Show("Mã nhân viên không hợp lệ. Vui lòng nhập một số nguyên.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                }

                NguoiDung_DTO nd = new NguoiDung_DTO
                {
                    TenDangNhap = txtTenDangNhap.Text.Trim(),
                    MatKhau = txtMatKhau.Text.Trim(),
                    VaiTro = cbbVaiTro.Text.Trim(),
                    NhanVienID = nhanVienId
                };
                // Optional: validate via BLL if available
                var validationMsg = nd_bll.CheckAdd(nd);
                if (!string.IsNullOrEmpty(validationMsg))
                {
                    MessageBox.Show(validationMsg, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                nd_bll.AddUser(nd);
                MessageBox.Show("Thêm người dùng thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Vui lòng kiểm tra lại các lỗi sau:\n\n" + ex.Message,
                                "Thông báo",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);
            }
        }

        private void dgvNguoiDung_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                // Đảm bảo người dùng click vào hàng hợp lệ
                if (e.RowIndex < 0 || e.RowIndex >= dgvNguoiDung.Rows.Count)
                    return;

                var row = dgvNguoiDung.Rows[e.RowIndex];

                // Gán dữ liệu vào các textbox
                txtNhanVienID.Text = row.Cells["NhanVienID"]?.Value?.ToString() ?? string.Empty;
                txtTenNhanVien.Text = row.Cells["HoTen"]?.Value?.ToString() ?? string.Empty;
                cbbVaiTro.Text = row.Cells["VaiTro"]?.Value?.ToString() ?? string.Empty;
               
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải thông tin nhân viên: " + ex.Message,
                                "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            try
            {
                string keyword = txtTimKiem.Text.Trim();

                if (string.IsNullOrWhiteSpace(keyword))
                {
                    // Nếu trống => load lại toàn bộ danh sách
                    dgvNguoiDung.DataSource = nv_bll.Laydanhsachnhanvien();
                    return;
                }

                var ketqua = nv_bll.TimKiem(keyword);

                if (ketqua.Count == 0)
                {
                    MessageBox.Show("Không tìm thấy nhân viên nào phù hợp!", "Kết quả", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                dgvNguoiDung.DataSource = ketqua;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Đã xảy ra lỗi khi tìm kiếm: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtTimKiem_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string keyword = txtTimKiem.Text.Trim();

                if (string.IsNullOrWhiteSpace(keyword))
                {
                    // Nếu trống => load lại toàn bộ danh sách
                    dgvNguoiDung.DataSource = nv_bll.Laydanhsachnhanvien();
                    return;
                }

                var ketqua = nv_bll.TimKiem(keyword);

                if (ketqua.Count == 0)
                {
                    MessageBox.Show("Không tìm thấy nhân viên nào phù hợp!", "Kết quả", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                dgvNguoiDung.DataSource = ketqua;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Đã xảy ra lỗi khi tìm kiếm: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        //private void ReloadGridAndKeepSelection(int? selectedId = null)
        //{
        //    var data = nd_bll.GetAllUser();
        //    dgvNguoiDung.DataSource = data;

        //    if (selectedId.HasValue)
        //    {
        //        foreach (DataGridViewRow row in dgvNguoiDung.Rows)
        //        {
        //            if (Convert.ToInt32(row.Cells["NhanVienID"].Value) == selectedId.Value)
        //            {
        //                row.Selected = true;
        //                dgvNguoiDung.CurrentCell = row.Cells[0]; // Đặt focus vào dòng đó
        //                break;
        //            }
        //        }
        //    }
        //}
    }
}
