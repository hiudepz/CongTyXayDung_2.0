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
    public partial class quanlyvattu : Form
    {
        private VatTu_BLL vt_bll = new VatTu_BLL();
        private NhaCungCap_BLL ncc_bll = new NhaCungCap_BLL();

        public quanlyvattu()
        {
            InitializeComponent();
        }

        private void dgvVattu_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                // Đảm bảo người dùng click vào hàng hợp lệ
                if (e.RowIndex < 0 || e.RowIndex >= dgvVattu.Rows.Count)
                    return;

                var row = dgvVattu.Rows[e.RowIndex];

                // Gán dữ liệu vào các textbox
                txtMaVT.Text = row.Cells["VatTuID"]?.Value?.ToString() ?? string.Empty;
                txtTenVatTu.Text = row.Cells["TenVatTu"]?.Value?.ToString() ?? string.Empty;
                txtDonViTinh.Text = row.Cells["DonViTinh"]?.Value?.ToString() ?? string.Empty;
                txtsoluong.Text = row.Cells["SoLuongTon"]?.Value?.ToString() ?? string.Empty;

                cbbNhaCungCap.SelectedValue = int.Parse(row.Cells["NhaCungCapID"]?.Value?.ToString() ?? string.Empty);
                //var nccIdObj = row.Cells["NhaCungCapID"]?.Value;
                //if (nccIdObj != null && int.TryParse(nccIdObj.ToString(), out int nccId))
                //    cbbNhaCungCap.SelectedValue = nccId;
                //else
                //    cbbNhaCungCap.SelectedIndex = -1;

                // Xử lý ảnh đại diện (nếu có)
                var cellValue = row.Cells["HinhAnhVatTu"]?.Value;

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

        private void quanlyvattu_Load(object sender, EventArgs e)
        {

             // load nhà cung cấp lên combobox
            cbbNhaCungCap.DataSource = ncc_bll.GetAllSuplier();
            cbbNhaCungCap.DisplayMember = "TenNCC";
            cbbNhaCungCap.ValueMember = "NhaCungCapID";
            // Load dữ liệu vật tư lên DataGridView
            dgvVattu.DataSource = vt_bll.GetAllMaterials();

           
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            try
            {
                VatTu_DTO newVT = new VatTu_DTO
                {
                    TenVatTu = txtTenVatTu.Text,
                    DonViTinh = txtDonViTinh.Text,
                    SoLuongTon = int.Parse(txtsoluong.Text),
                    NhaCungCapID = int.Parse(cbbNhaCungCap.SelectedValue.ToString()),
                    HinhAnhVatTu = Anhdaidien
                };
                vt_bll.AddMaterial(newVT);
                MessageBox.Show("Thêm vật tư thành công!");
                dgvVattu.DataSource = vt_bll.GetAllMaterials();
            }
            catch(Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }
        private byte[] Anhdaidien;

        //private void btnLogoNCC_Click(object sender, EventArgs e)
        //{
        //    using (OpenFileDialog ofd = new OpenFileDialog())
        //    {
        //        ofd.Filter = "Ảnh (*.jpg;*.png)|*.jpg;*.png";
        //        if (ofd.ShowDialog() == DialogResult.OK)
        //        {
        //            ptAnhDaiDien.Image = Image.FromFile(ofd.FileName);

        //            // Chuyển ảnh thành mảng byte để lưu vào DB
        //            using (var ms = new MemoryStream())
        //            {
        //                ptAnhDaiDien.Image.Save(ms, ptAnhDaiDien.Image.RawFormat);
        //                Anhdaidien = ms.ToArray();
        //            }
        //        }
        //    }
        //}

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtMaVT.Text))
            {
                MessageBox.Show("Vui lòng chọn đơn đặt hàng cần xóa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            var confirm = MessageBox.Show("Bạn có chắc chắn muốn xóa vật tư đã chọn?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (confirm != DialogResult.Yes) return;
            try
            {
                vt_bll.Delete(int.Parse(txtMaVT.Text));

               dgvVattu.DataSource = vt_bll.GetAllMaterials();
                MessageBox.Show("Xóa đơn đặt hàng thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi xóa đơn: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private void btnLogoNCC_Click(object sender, EventArgs e)
        {

        }

        private void btnSua_Click(object sender, EventArgs e)
        {

            if (string.IsNullOrEmpty(txtMaVT.Text))
            {
                MessageBox.Show("Vui lòng chọn đơn đặt hàng cần sửa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Validate inputs (same as Add)
            if (cbbNhaCungCap.SelectedValue == null)
            {
                MessageBox.Show("Vui lòng chọn nhà cung cấp.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            

            if (!int.TryParse(cbbNhaCungCap.SelectedValue.ToString(), out int nccId))
            {
                MessageBox.Show("Giá trị NhaCungCapID không hợp lệ.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
           

            try
            {
                VatTu_DTO ddh = new VatTu_DTO
                {
                    VatTuID = int.Parse(txtMaVT.Text),
                    TenVatTu = txtTenVatTu.Text,
                    DonViTinh = txtDonViTinh.Text,
                    SoLuongTon = int.Parse(txtsoluong.Text),
                    NhaCungCapID = nccId,
                    HinhAnhVatTu = Anhdaidien
                };

                vt_bll.UpdateMaterial(ddh);

                dgvVattu.DataSource = vt_bll.GetAllMaterials();
                MessageBox.Show("Cập nhật vật tư thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi cập nhật vật tư: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            LoadOders(txtSearch.Text);
        }
        private void LoadOders(string filter = null)
        {
            List<VatTu_DTO> users = vt_bll.SearchMaterials(filter);
           dgvVattu.DataSource = users;
        }
    }
}
