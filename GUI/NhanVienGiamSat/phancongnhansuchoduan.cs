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


namespace GUI
{
    public partial class phancongnhansuchoduan : Form
    {
        private readonly DuAn_BLL duAnBLL = new DuAn_BLL();
        private readonly NhanVien_BLL nhanVienBLL = new NhanVien_BLL();
        private readonly PhanCong_BLL phanCongBLL = new PhanCong_BLL();
        private int duAnID;
        private string tenDuAn;
        private int selectedID = -1;

        public phancongnhansuchoduan()
        {
            InitializeComponent();
        }

        private void phancongnhansuchoduan_Load(object sender, EventArgs e)
        {
            //format date
            dtpNgaybatdau.Format = DateTimePickerFormat.Custom;
            dtpNgaybatdau.CustomFormat = "MM/dd/yyyy";
            dtpNgayketthuc.Format = DateTimePickerFormat.Custom;
            dtpNgayketthuc.CustomFormat = "MM/dd/yyyy";
            //tắt chỉnh sửa trực tiếp trên dgv
            dgvThongtinduan.ReadOnly = true;
            dgvThongtinduan.AllowUserToAddRows = false;
            dgvThongtinduan.AllowUserToDeleteRows = false;
            dgvThongtinduan.EditMode = DataGridViewEditMode.EditProgrammatically;
            cbbDuan.DropDownStyle = ComboBoxStyle.DropDownList;
            cbbNhanvien.DropDownStyle = ComboBoxStyle.DropDownList;
            duAnID = 1;
            LoadData();
            LoadDuAn();
            LoadNV();
        }
        public void LoadData()
        {
            //tắt chỉnh sửa trực tiếp trên dgv
            dgvBangPhanCong.ReadOnly = true;
            dgvBangPhanCong.AllowUserToAddRows = false;
            dgvBangPhanCong.AllowUserToDeleteRows = false;
            dgvBangPhanCong.EditMode = DataGridViewEditMode.EditProgrammatically;
    
            //-----//
           

            try {
                dgvBangPhanCong.DataSource = phanCongBLL.GetAll();

                dgvBangPhanCong.Columns["PhanCongID"].HeaderText = "Mã Phân Công";
                dgvBangPhanCong.Columns["DuAnID"].HeaderText = "Mã Dự Án";
                dgvBangPhanCong.Columns["NhanVienID"].HeaderText = "Mã nhân viên";
                dgvBangPhanCong.Columns["NhiemVu"].HeaderText = "Nhiệm Vụ";
                dgvBangPhanCong.Columns["NgayBatDau"].HeaderText = "Ngày Bắt Đầu";
                dgvBangPhanCong.Columns["NgayKetThuc"].HeaderText = "Ngày Kết Thúc";
                dgvBangPhanCong.Columns["TenDuAn"].HeaderText = "Tên Dự Án";
                dgvBangPhanCong.Columns["HoTenNV"].HeaderText = "Tên Nhân Viên";


              
                
        
            }
            catch(Exception ex)
            {
                MessageBox.Show("Lỗi khi tải dữ liệu phân công: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void LoadNV()
        {
            //tắt chỉnh sửa trực tiếp trên dgv
            dgvThongtinnhanvien.ReadOnly = true;
            dgvThongtinnhanvien.AllowUserToAddRows = false;
            dgvThongtinnhanvien.AllowUserToDeleteRows = false;
            dgvThongtinnhanvien.EditMode = DataGridViewEditMode.EditProgrammatically;
            //----//
            dgvThongtinnhanvien.DataSource = nhanVienBLL.Laydanhsachnhanvien();
            dgvThongtinnhanvien.Columns["AnhDaiDien"].Visible = false;
            try
            {
                var listNV = nhanVienBLL.Laydanhsachnhanvien();

                dgvThongtinnhanvien.DataSource = listNV;


                cbbNhanvien.DataSource = listNV;
                cbbNhanvien.DisplayMember = "HoTen";
                cbbNhanvien.ValueMember = "NhanVienID";
                cbbNhanvien.SelectedIndex = -1;

            }
            catch(Exception ex)
            {
                MessageBox.Show("Lỗi khi tải danh sách nhân viên: " + ex.Message,
                                       "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }
        public void LoadDuAn()
        {
            //tắt chỉnh sửa trực tiếp trên dgv
            dgvThongtinduan.ReadOnly = true;
            dgvThongtinduan.AllowUserToAddRows = false;
            dgvThongtinduan.AllowUserToDeleteRows = false;
            dgvThongtinduan.EditMode = DataGridViewEditMode.EditProgrammatically;
            try
            {
                var list = duAnBLL.GetAll();

                dgvThongtinduan.DataSource = list;

                dgvThongtinduan.Columns["DuAnID"].HeaderText = "Mã Dự Án";
                dgvThongtinduan.Columns["TenDuAn"].HeaderText = "Tên Dự Án";
                dgvThongtinduan.Columns["TenKhachHang"].HeaderText = "Khách Hàng";
                dgvThongtinduan.Columns["TenHopDong"].HeaderText = "Hợp Đồng";
                dgvThongtinduan.Columns["NgayBatDau"].HeaderText = "Ngày Bắt Đầu";
                dgvThongtinduan.Columns["NgayKetThuc"].HeaderText = "Ngày Kết Thúc";
                dgvThongtinduan.Columns["TienDo"].HeaderText = "Tiến Độ";


                dgvThongtinduan.Columns["KhachHangID"].Visible = false;
                dgvThongtinduan.Columns["HopDongID"].Visible = false;
                dgvThongtinduan.Columns["HinhAnhDuAn"].Visible = false;
                if (dgvThongtinduan.Columns.Contains("TenKhachHang"))
                    dgvThongtinduan.Columns["TenKhachHang"].HeaderText = "Khách Hàng";
                if (dgvThongtinduan.Columns.Contains("TenHopDong"))
                    dgvThongtinduan.Columns["TenHopDong"].HeaderText = "Hợp Đồng";


                cbbDuan.DataSource = list;
                cbbDuan.DisplayMember = "TenDuAn";
                cbbDuan.ValueMember = "DuAnID";
                cbbDuan.SelectedIndex = -1;

            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải dữ liệu dự án: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void groupBox4_Enter(object sender, EventArgs e)
        {

        }

        private void txtTimkiem_TextChanged(object sender, EventArgs e)
        {

            string keyword = txtTimkiem.Text.Trim().ToLower();

            if (string.IsNullOrEmpty(keyword))
            {
                LoadData();
                LoadDuAn();
                LoadNV();
                return;
            }

            var duAnList = duAnBLL.GetAll().Where(x =>
                RemoveDiacritics(x.TenDuAn.ToLower()).Contains(RemoveDiacritics(keyword))).ToList();

            var nhanVienList = nhanVienBLL.Laydanhsachnhanvien().Where(x =>
                RemoveDiacritics(x.HoTen.ToLower()).Contains(RemoveDiacritics(keyword)) ||
                RemoveDiacritics(x.VaiTro?.ToLower() ?? "").Contains(RemoveDiacritics(keyword))).ToList();

            var phanCongList = phanCongBLL.Timkiem(keyword).Where(x =>
                RemoveDiacritics(x.NhiemVu?.ToLower() ?? "").Contains(RemoveDiacritics(keyword)) ||
                RemoveDiacritics(x.TenDuAn?.ToLower() ?? "").Contains(RemoveDiacritics(keyword)) ||
                RemoveDiacritics(x.HoTenNV?.ToLower() ?? "").Contains(RemoveDiacritics(keyword))).ToList();

            dgvThongtinduan.DataSource = duAnList;
            dgvThongtinnhanvien.DataSource = nhanVienList;
            dgvBangPhanCong.DataSource = phanCongList;


        }
        //Hàm loại bỏ dấu tiếng Việt
        private string RemoveDiacritics(string text)
        {
            if (string.IsNullOrEmpty(text))
                return text;

            var normalized = text.Normalize(System.Text.NormalizationForm.FormD);
            var chars = normalized.Where(c =>
                System.Globalization.CharUnicodeInfo.GetUnicodeCategory(c) !=
                System.Globalization.UnicodeCategory.NonSpacingMark
            );

            return new string(chars.ToArray()).Normalize(System.Text.NormalizationForm.FormC);
        }
        private PhanCong_DTO GetInput()
        {
            return new PhanCong_DTO
            {
                PhanCongID = selectedID,
                DuAnID = cbbDuan.SelectedValue != null ? Convert.ToInt32(cbbDuan.SelectedValue) : 0,
                NhanVienID = cbbNhanvien.SelectedValue != null ? Convert.ToInt32(cbbNhanvien.SelectedValue) : 0,
                NhiemVu = txtNhiemvu.Text?.Trim(),
                NgayBatDau = dtpNgaybatdau.Value,
                NgayKetThuc = dtpNgayketthuc.Value
            };
        }

        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }

        private void btnThemnhansuvaoduan_Click(object sender, EventArgs e)
        {
           

            try
            {
                selectedID = 0;
                var pc = GetInput();
                if (pc == null) return;
                phanCongBLL.Add(pc);
                MessageBox.Show("Thêm phân công thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                selectedID = 0;
                LoadData();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi thêm phân công: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSuanhansuduan_Click(object sender, EventArgs e)
        {
            
            var pc = GetInput();
            if (pc == null || selectedID == 0)
            {
                MessageBox.Show("Vui lòng chọn một phân công để sửa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                selectedID = 0;
                phanCongBLL.Update(pc);
                MessageBox.Show("Cập nhật phân công thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                selectedID = 0;
                LoadData();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi cập nhật: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void tsbXoa_Click(object sender, EventArgs e)
        {

            if (dgvBangPhanCong.CurrentRow == null)
            {
                MessageBox.Show("Vui lòng chọn một phân công để xóa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var result = MessageBox.Show("Bạn có chắc muốn xóa phân công này?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                try
                {
                    int id = Convert.ToInt32(dgvBangPhanCong.CurrentRow.Cells["PhanCongID"].Value);
                    phanCongBLL.Delete(id);
                    MessageBox.Show("Xóa thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    selectedID = 0;
                    LoadData();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi xóa: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void tsbXoaall_Click(object sender, EventArgs e)
        {
            if (cbbDuan.SelectedValue == null)
            {
                MessageBox.Show("Vui lòng chọn dự án để xóa toàn bộ phân công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var result = MessageBox.Show("Bạn có chắc muốn xóa tất cả phân công của dự án này?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (result == DialogResult.Yes)
            {
                try
                {
                    int id = Convert.ToInt32(cbbDuan.SelectedValue);
                    phanCongBLL.DeleteAllByDuAn(id);
                    MessageBox.Show("Đã xóa toàn bộ phân công của dự án.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    selectedID = 0;
                    LoadData();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi xóa tất cả: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void dgvThongtinduan_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgvThongtinduan_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && dgvThongtinduan.CurrentRow != null)
            {
                int duAnID = Convert.ToInt32(dgvThongtinduan.CurrentRow.Cells["DuAnID"].Value);
                cbbDuan.SelectedValue = duAnID;
            }
        }

        private void dgvThongtinnhanvien_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgvThongtinnhanvien_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && dgvThongtinnhanvien.CurrentRow != null)
            {
                int nvID = Convert.ToInt32(dgvThongtinnhanvien.CurrentRow.Cells["NhanVienID"].Value);
                cbbNhanvien.SelectedValue = nvID;
            }
        }

        private void dgvBangPhanCong_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgvBangPhanCong_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && dgvBangPhanCong.CurrentRow != null)
            {
                var row = dgvBangPhanCong.CurrentRow;

                selectedID = Convert.ToInt32(row.Cells["PhanCongID"].Value); // dùng biến của bạn

                cbbDuan.SelectedValue = Convert.ToInt32(row.Cells["DuAnID"].Value);
                cbbNhanvien.SelectedValue = Convert.ToInt32(row.Cells["NhanVienID"].Value);

                txtNhiemvu.Text = row.Cells["NhiemVu"].Value?.ToString();
                dtpNgaybatdau.Value = row.Cells["NgayBatDau"].Value != null ? Convert.ToDateTime(row.Cells["NgayBatDau"].Value) : DateTime.Now;
                dtpNgayketthuc.Value = row.Cells["NgayKetThuc"].Value != null ? Convert.ToDateTime(row.Cells["NgayKetThuc"].Value) : DateTime.Now;
            }
        }
    }
}
