using BLL;
using DTO;
using System;
using System.IO;
using System.Windows.Forms;

namespace GUI
{
    public partial class quanlyhopdong : Form
    {
        private readonly HopDong_BLL hopDong_BLL = new HopDong_BLL();
        private readonly KhachHang_BLL khachHang_BLL = new KhachHang_BLL();
        private readonly DuAn_BLL duAn_BLL = new DuAn_BLL();

        private int selectedID = -1;
        private byte[] fileHopDongData = null;

        public quanlyhopdong()
        {
            InitializeComponent();
        }

        private void quanlyhopdong_Load(object sender, EventArgs e)
        {
            dgvQlhopdong.ReadOnly = true;
            dgvQlhopdong.AllowUserToAddRows = false;
            dgvQlhopdong.AllowUserToDeleteRows = false;
            dgvQlhopdong.EditMode = DataGridViewEditMode.EditProgrammatically;

            cbbKH.DropDownStyle = ComboBoxStyle.DropDownList;
            cbbDuAn.DropDownStyle = ComboBoxStyle.DropDownList;
            cbbTrangthai.DropDownStyle = ComboBoxStyle.DropDownList;

            cbbTrangthai.Items.AddRange(new string[] { "Chưa ký", "Đang thực hiện", "Hoàn thành", "Đã hủy" });

            LoadKH();
            //LoadDA()/*;*/
            LoadData();
        }

        private void LoadData()
        {
            try
            {
                var list = hopDong_BLL.GetAllHopDong();
                dgvQlhopdong.DataSource = list;

                dgvQlhopdong.Columns["HopDongID"].HeaderText = "Mã Hợp Đồng";
                dgvQlhopdong.Columns["MaHopDong"].HeaderText = "Số Hợp Đồng";
                dgvQlhopdong.Columns["TenHopDong"].HeaderText = "Tên Hợp Đồng";
                dgvQlhopdong.Columns["TenKhachHang"].HeaderText = "Khách Hàng";
                //dgvQlhopdong.Columns["TenDuAn"].HeaderText = "Dự Án";
                dgvQlhopdong.Columns["NgayKy"].HeaderText = "Ngày Ký";
                dgvQlhopdong.Columns["GiaTriHopDong"].HeaderText = "Giá Trị";
                dgvQlhopdong.Columns["TrangThai"].HeaderText = "Trạng Thái";

                dgvQlhopdong.Columns["NoiDungYeuCau"].Visible = false;
                dgvQlhopdong.Columns["DieuKhoanThanhToan"].Visible = false;
                dgvQlhopdong.Columns["ThoiHanThiCong"].Visible = false;
                dgvQlhopdong.Columns["FileHopDong"].Visible = false;
                dgvQlhopdong.Columns["KhachHangID"].Visible = false;
                dgvQlhopdong.Columns["DuAnID"].Visible = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải dữ liệu hợp đồng: " + ex.Message,
                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadKH()
        {
            try
            {               

                var list = khachHang_BLL.GetAllCustomer();
                dgvTTKH.DataSource = list;
                cbbKH.DataSource = list;
                dgvTTKH.Columns["AnhDaiDien"].Visible = false;
                cbbKH.DisplayMember = "HoTenKH";
                cbbKH.ValueMember = "KhachHangID";
                cbbKH.SelectedIndex = -1;

            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải danh sách khách hàng: " + ex.Message);
            }
        }

        //private void LoadDA()
        //{
        //    try
        //    {
        //        var list = duAn_BLL.GetAll();
        //        cbbDuAn.DataSource = list;
        //        cbbDuAn.DisplayMember = "TenDuAn";
        //        cbbDuAn.ValueMember = "DuAnID";
        //        cbbDuAn.SelectedIndex = -1;
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show("Lỗi khi tải danh sách dự án: " + ex.Message);
        //    }
        //}

        private HopDong_DTO GetInput()
        {
            return new HopDong_DTO
            {
                HopDongID = selectedID,
                MaHopDong = txtMahopdong.Text.Trim(),
                TenHopDong = txtTenHopDong.Text.Trim(),
                KhachHangID = cbbKH.SelectedValue != null ? Convert.ToInt32(cbbKH.SelectedValue) : 0,
                //DuAnID = cbbDuAn.SelectedValue != null ? Convert.ToInt32(cbbDuAn.SelectedValue) : (int?)null,
                NgayKy = dtpNgayky.Value,
                GiaTriHopDong = decimal.TryParse(txtGiatri.Text, out var gt) ? gt : 0,
                NoiDungYeuCau = txtNoidung.Text.Trim(),
                ThoiHanThiCong = txtThoihan.Text.Trim(),
                DieuKhoanThanhToan = txtDieukhoan.Text.Trim(),
                TrangThai = cbbTrangthai.Text,
                FileHopDong = fileHopDongData
            };
        }

        private void dgvQlhopdong_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                var row = dgvQlhopdong.Rows[e.RowIndex];
                selectedID = Convert.ToInt32(row.Cells["HopDongID"].Value ?? 0);

                txtMahopdong.Text = row.Cells["MaHopDong"].Value?.ToString();
                txtTenHopDong.Text = row.Cells["TenHopDong"].Value?.ToString();
                txtGiatri.Text = row.Cells["GiaTriHopDong"].Value?.ToString();
                txtNoidung.Text = row.Cells["NoiDungYeuCau"].Value?.ToString();
                txtThoihan.Text = row.Cells["ThoiHanThiCong"].Value?.ToString();
                txtDieukhoan.Text = row.Cells["DieuKhoanThanhToan"].Value?.ToString();
                cbbTrangthai.Text = row.Cells["TrangThai"].Value?.ToString();

                int khID = Convert.ToInt32(row.Cells["KhachHangID"].Value ?? 0);
                //int? daID = row.Cells["DuAnID"].Value as int?;
                if (cbbKH.DataSource != null)
                    cbbKH.SelectedValue = khID;
                //if (daID.HasValue && cbbDuAn.DataSource != null)
                //    cbbDuAn.SelectedValue = daID.Value;

                if (DateTime.TryParse(row.Cells["NgayKy"].Value?.ToString(), out DateTime ngayKy))
                    dtpNgayky.Value = ngayKy;
            }
        }

        private void btnThemhopdong_Click(object sender, EventArgs e)
        {
            try
            {
                selectedID = 0;
                var hd = GetInput();
                hopDong_BLL.Add(hd);
                LoadData();
                MessageBox.Show("Thêm hợp đồng thành công!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi thêm hợp đồng: " + ex.Message);
            }
        }

        private void btnSuahopdong_Click(object sender, EventArgs e)
        {
            try
            {
                var hd = GetInput();
                hopDong_BLL.Update(hd);
                LoadData();
                MessageBox.Show("Cập nhật hợp đồng thành công!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi sửa hợp đồng: " + ex.Message);
            }
        }

        private void btnXoahopdong_Click(object sender, EventArgs e)
        {
            if (selectedID <= 0)
            {
                MessageBox.Show("Vui lòng chọn hợp đồng để xóa!");
                return;
            }

            if (MessageBox.Show("Bạn có chắc chắn muốn xóa hợp đồng này?",
                "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    hopDong_BLL.Delete(selectedID);
                    LoadData();
                    MessageBox.Show("Xóa hợp đồng thành công!");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi xóa hợp đồng: " + ex.Message);
                }
            }
        }

      
       

        private void btnUploadfilehopdong_Click(object sender, EventArgs e)
        {
              var ofd = new OpenFileDialog
                        {
                            Filter = "PDF files (*.pdf)|*.pdf|All files (*.*)|*.*"
                        };
                        if (ofd.ShowDialog() == DialogResult.OK)
                        {
                            fileHopDongData = File.ReadAllBytes(ofd.FileName);
                            MessageBox.Show("Tải file hợp đồng thành công!");
                        }
        }

        private void txtTimKiem_TextChanged(object sender, EventArgs e)
        {

            if (string.IsNullOrWhiteSpace(txtTimKiem.Text))
            {
                LoadData();
            }
        }

        private void btnTimkiemkhachhang_Click(object sender, EventArgs e)
        {
            string keyword = txtTimKiem.Text.Trim();
            dgvQlhopdong.DataSource = hopDong_BLL.TimKiem(keyword);
        }

        private void btnPhanCong_Click(object sender, EventArgs e)
        {
            phancongnhanvienchohopdong frm = new phancongnhanvienchohopdong();
            frm.ShowDialog();
        }

        private void dgvTTKH_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
