using BLL;
using DTO;
using GUI.Login;
using GUI.Report.form;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI.NhanVienKeToan
{
    public partial class ThanhToan : Form
    {
        public int NhanVienID = 0;
        private ThanhToan_BLL tt_bll = new ThanhToan_BLL();
        private DuAn_BLL da_bll = new DuAn_BLL();
        private DonDatHang_BLL ddh_bll = new DonDatHang_BLL();
        private int? donDatHangID=0;
        private int? duAnID=0;
        private decimal soTien;
        private decimal tienNo;

        public ThanhToan(int? ddhID, int? daID, decimal tien,decimal tienNo)
        {
            InitializeComponent();
            SetupGrid(dgvThanhToan);
            this.donDatHangID = ddhID;
            this.duAnID = daID;
            this.soTien = tien;
            this.tienNo = tienNo;
            //load duan or dondathang
            
            
        }
        public ThanhToan()
        {
            InitializeComponent();
        }

        private void SetupGrid(Guna.UI2.WinForms.Guna2DataGridView grid)
        {
            // Nền chung
            grid.BackgroundColor = Color.White;
            grid.BorderStyle = BorderStyle.FixedSingle;

            // Không tự sinh dòng trống
            grid.AllowUserToAddRows = false;

            // Chọn nguyên dòng
            grid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            grid.MultiSelect = false;
            grid.ReadOnly = true;

            // Tự giãn theo nội dung
            grid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            // Bố cục Header
            grid.ColumnHeadersHeight = 32;
            grid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing;

            // Kiểu dữ liệu Theme
            grid.EnableHeadersVisualStyles = false;

            // Style cho Header
            grid.ThemeStyle.HeaderStyle.BackColor = Color.FromArgb(230, 230, 230);
            grid.ThemeStyle.HeaderStyle.ForeColor = Color.Black;
            grid.ThemeStyle.HeaderStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            grid.ThemeStyle.HeaderStyle.BorderStyle = DataGridViewHeaderBorderStyle.Single;
            grid.ThemeStyle.HeaderStyle.Height = 32;

            // Style cho dòng dữ liệu
            grid.ThemeStyle.RowsStyle.BackColor = Color.White;
            grid.ThemeStyle.RowsStyle.ForeColor = Color.Black;
            grid.ThemeStyle.RowsStyle.Font = new Font("Segoe UI", 10, FontStyle.Regular);
            grid.ThemeStyle.RowsStyle.SelectionBackColor = Color.FromArgb(210, 210, 210);
            grid.ThemeStyle.RowsStyle.SelectionForeColor = Color.Black;
            grid.ThemeStyle.RowsStyle.BorderStyle = DataGridViewCellBorderStyle.Single;

            // Alternating row (dòng xen kẽ)
            grid.ThemeStyle.AlternatingRowsStyle.BackColor = Color.FromArgb(245, 245, 245);

            // Đường viền bảng
            grid.GridColor = Color.FromArgb(220, 220, 220);
        }

        private void ThanhToan_Load(object sender, EventArgs e)
        {
            txtMaThanhtoan.ReadOnly = true;
            txtMaThanhtoan.Enabled = false;

            // load dữ liệu ban đầu
            dgvThanhToan.DataSource = tt_bll.GetAllPay();
            dgvThanhToan.ReadOnly = true;

            // format dtp NgayThanhToan
            dtpNgayThanhToan.Format = DateTimePickerFormat.Custom;
            dtpNgayThanhToan.CustomFormat = "dd/MM/yyyy";
            dtpNgayThanhToan.Value = DateTime.Now;

            // load combobox HinhThuc
            cbbHinhThuc.Items.Add("Tiền mặt");
            cbbHinhThuc.Items.Add("Chuyển khoản");

            // load combobox Dự án
            cbbDuAn.DataSource = da_bll.GetAll();
            cbbDuAn.DisplayMember = "TenDuAn";
            cbbDuAn.ValueMember = "DuAnID";

            // load combobox Đơn đặt hàng
            cbbDonDatHang.DataSource = ddh_bll.GetAllOrders();
            cbbDonDatHang.DisplayMember = "TenNCC";
            cbbDonDatHang.ValueMember = "DonDatHangID";

            // Wire events for filters
            checkdgvDuAn.CheckedChanged += (s, ev) => ApplyFilter();
            checkdgvDonDatHang.CheckedChanged += (s, ev) => ApplyFilter();

            // đảm bảo danh sách hiển thị theo bộ lọc lúc load (mặc định là tất cả)
            ApplyFilter();

            if (duAnID != null)
            {
                rdbtnDuAn.Checked = true;
                cbbDuAn.SelectedValue = duAnID;
            }
            else
            {
                rdbtnDonDatHang.Checked = true;
                cbbDonDatHang.SelectedValue = donDatHangID;
            }
            txtTongTien.Text = soTien.ToString("N0");
            txtTienNo.Text = tienNo.ToString("N0");
            cbbDuAn.SelectedIndexChanged += CbbDuAn_SelectedIndexChanged;
            cbbDonDatHang.SelectedIndexChanged += CbbDonDatHang_SelectedIndexChanged;

        }

        private void CbbDonDatHang_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbbDonDatHang.SelectedValue == null) return;

            int id = Convert.ToInt32(cbbDonDatHang.SelectedValue);

            var result = tt_bll.GetTienDonDatHang(id);

            txtTongTien.Text = result.TongTien.ToString("N0");
            txtTienNo.Text = result.TienNo.ToString("N0");

            donDatHangID = id;
            duAnID = null; ;
        }

        private void CbbDuAn_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbbDuAn.SelectedValue == null) return;

            int id = Convert.ToInt32(cbbDuAn.SelectedValue);

            var result = tt_bll.GetTienDuAn(id);

            txtTongTien.Text = result.TongTien.ToString("N0");
            txtTienNo.Text = result.TienNo.ToString("N0");

            duAnID = id;
            donDatHangID = null;
        }

        private void rdbtnDuAn_CheckedChanged(object sender, EventArgs e)
        {
            // Khi radio Dự án được check -> hiển thị combobox Dự án, ẩn combobox Đơn đặt hàng
            if (rdbtnDuAn.Checked)
            {
                cbbDuAn.Visible = true;
                cbbDonDatHang.Visible = false;
            }
        }

        // Designer gọi phương thức này (tên phương thức giữ nguyên để phù hợp với Designer)
        private void rbbtnDonDatHang_CheckedChanged(object sender, EventArgs e)
        {
            // Khi radio Đơn đặt hàng được check -> hiển thị combobox Đơn đặt hàng, ẩn combobox Dự án
            if (rdbtnDonDatHang.Checked)
            {
                cbbDonDatHang.Visible = true;
                cbbDuAn.Visible = false;
            }
        }

        private void dgvThanhToan_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Bảo vệ khỏi click header hoặc vùng trống
            if (e.RowIndex < 0 || e.RowIndex >= dgvThanhToan.Rows.Count)
                return;

            var row = dgvThanhToan.Rows[e.RowIndex];
            try
            {
                txtMaThanhtoan.Text = row.Cells["ThanhToanID"]?.Value?.ToString() ?? string.Empty;
                IDThanhToan = int.Parse(txtMaThanhtoan.Text);
                txtSoTien.Text = row.Cells["SoTien"]?.Value?.ToString() ?? string.Empty;
                decimal SoTien;
                if (!decimal.TryParse(txtSoTien.Text, out SoTien))
                {
                    soTien = 0; // hoặc xử lý lỗi nếu giá trị không hợp lệ
                }
                soTien = SoTien;
                DateTime dt;
                if (DateTime.TryParse(row.Cells["NgayThanhToan"]?.Value?.ToString(), out dt))
                {
                    dtpNgayThanhToan.Value = dt;
                }
                else
                {
                    dtpNgayThanhToan.Value = DateTime.Now;
                }

                cbbHinhThuc.Text = row.Cells["HinhThuc"]?.Value?.ToString() ?? string.Empty;
                txtGhiChu.Text = row.Cells["GhiChu"]?.Value?.ToString() ?? string.Empty;

                var daID = row.Cells["DuAnID"]?.Value;
                //gan gia tri
                duAnID = (int?)daID;
                if (daID != null && int.TryParse(daID.ToString(), out int daId))
                {
                    cbbDuAn.SelectedValue = daId;
                    cbbDuAn.Visible = true;
                    rdbtnDuAn.Checked = true;
                }
                else
                {
                    cbbDuAn.Visible = false;
                    rdbtnDonDatHang.Checked = true;
                }

                var dondathangID = row.Cells["DonDatHangID"]?.Value;
                if (dondathangID != null && int.TryParse(dondathangID.ToString(), out int ddhId))
                {
                    cbbDonDatHang.SelectedValue = ddhId;
                    cbbDonDatHang.Visible = true;
                    rdbtnDonDatHang.Checked = true;
                }
                else
                {
                    cbbDonDatHang.Visible = false;
                    rdbtnDuAn.Checked = true;
                }
            }
            catch
            {
                // Nếu có lỗi khi đọc hàng (ví dụ tên cột khác) — bỏ qua để không làm crash UI.
            }
        }

        private void tsbtnTaoMoi_Click(object sender, EventArgs e)
        {
            // "Tạo mới" = Add new (user requested)
            try
            {
                var dto = new ThanhToan_DTO();

                dto.NgayThanhToan = dtpNgayThanhToan.Value;

                // parse SoTien safely
                if (!decimal.TryParse(txtSoTien.Text, NumberStyles.Number | NumberStyles.AllowThousands, CultureInfo.CurrentCulture, out decimal sotien))
                {
                    MessageBox.Show("Số tiền không hợp lệ.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                dto.SoTien = sotien;

                dto.HinhThuc = cbbHinhThuc.Text;
                dto.GhiChu = txtGhiChu.Text;

                // choose DuAn or DonDatHang
                if (cbbDuAn.Visible && cbbDuAn.SelectedValue != null && int.TryParse(cbbDuAn.SelectedValue.ToString(), out int daId))
                    dto.DuAnID = daId;
                else
                    dto.DuAnID = null;

                if (cbbDonDatHang.Visible && cbbDonDatHang.SelectedValue != null && int.TryParse(cbbDonDatHang.SelectedValue.ToString(), out int ddhId))
                    dto.DonDatHangID = ddhId;
                else
                    dto.DonDatHangID = null;

                dto.NhanVienID = login.IDNhanVienHienTai;

                // Call BLL add
                tt_bll.Add(dto);

                MessageBox.Show("Thêm mới thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // refresh grid and clear form
                ApplyFilter();
                ClearForm();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tạo mới: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void tsbtnLuu_Click(object sender, EventArgs e)
        {
            // Lưu = cập nhật bản ghi đã chọn trên giao diện
            try
            {
                if (string.IsNullOrWhiteSpace(txtMaThanhtoan.Text) || !int.TryParse(txtMaThanhtoan.Text, out int id))
                {
                    MessageBox.Show("Vui lòng chọn phiếu thanh toán cần cập nhật.", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var dto = new ThanhToan_DTO
                {
                    ThanhToanID = id,
                    NgayThanhToan = dtpNgayThanhToan.Value
                };

                if (!decimal.TryParse(txtSoTien.Text, NumberStyles.Number | NumberStyles.AllowThousands, CultureInfo.CurrentCulture, out decimal sotien))
                {
                    MessageBox.Show("Số tiền không hợp lệ.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                dto.SoTien = sotien;

                dto.HinhThuc = cbbHinhThuc.Text;
                dto.GhiChu = txtGhiChu.Text;

                if (cbbDuAn.Visible && cbbDuAn.SelectedValue != null && int.TryParse(cbbDuAn.SelectedValue.ToString(), out int daId))
                    dto.DuAnID = daId;
                else
                    dto.DuAnID = null;

                if (cbbDonDatHang.Visible && cbbDonDatHang.SelectedValue != null && int.TryParse(cbbDonDatHang.SelectedValue.ToString(), out int ddhId))
                    dto.DonDatHangID = ddhId;
                else
                    dto.DonDatHangID = null;

                dto.NhanVienID =login.IDNhanVienHienTai;

                tt_bll.Update(dto);

                MessageBox.Show("Cập nhật thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ApplyFilter();
                ClearForm();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi cập nhật: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void tsbtnXoa_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtMaThanhtoan.Text) || !int.TryParse(txtMaThanhtoan.Text, out int id))
                {
                    MessageBox.Show("Vui lòng chọn phiếu thanh toán cần xoá.", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var confirm = MessageBox.Show("Bạn có chắc muốn xoá phiếu thanh toán này?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (confirm != DialogResult.Yes)
                    return;

                tt_bll.Delete(id);

                MessageBox.Show("Xoá thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ApplyFilter();
                ClearForm();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi xoá: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void tsbtnLamMoi_Click(object sender, EventArgs e)
        {
            // Làm mới: reset bộ lọc, tải lại dữ liệu và xoá form
            txtSearch.Text = string.Empty;
            checkdgvDuAn.Checked = false;
            checkdgvDonDatHang.Checked = false;
            ApplyFilter();
            ClearForm();
        }

        private void tsbtnXuatEX_Click(object sender, EventArgs e)
        {
            // Không triển khai ở lần này (nếu cần tôi sẽ thêm)
        }
        public int IDThanhToan = 0;
        private void tsbtnInPhieu_Click(object sender, EventArgs e)
        {
            
                
                frmHoaDonThanhToan hdtt = new frmHoaDonThanhToan(duAnID, soTien, IDThanhToan);
                hdtt.Show();
            
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            ApplyFilter();
        }

        // --- Helpers ---
        private void ApplyFilter()
        {
            try
            {
                string term = txtSearch.Text;
                List<ThanhToan_DTO> list;

                if (string.IsNullOrWhiteSpace(term))
                    list = tt_bll.GetAllPay();
                else
                    list = tt_bll.SearchPays(term);

                bool filterDuAn = checkdgvDuAn.Checked;
                bool filterDon = checkdgvDonDatHang.Checked;

                if (filterDuAn && !filterDon)
                {
                    list = list.Where(p => p.DuAnID.HasValue && p.DuAnID.Value > 0).ToList();
                }
                else if (!filterDuAn && filterDon)
                {
                    list = list.Where(p => p.DonDatHangID.HasValue && p.DonDatHangID.Value > 0).ToList();
                }
                // Nếu cả hai đều check hoặc đều unchecked -> không lọc thêm

                dgvThanhToan.DataSource = list;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tìm kiếm/lọc: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ClearForm()
        {
            txtMaThanhtoan.Text = string.Empty;
            txtSoTien.Text = string.Empty;
            txtGhiChu.Text = string.Empty;
            cbbHinhThuc.SelectedIndex = -1;
            dtpNgayThanhToan.Value = DateTime.Now;
            if (cbbDuAn.Items.Count > 0) cbbDuAn.SelectedIndex = -1;
            if (cbbDonDatHang.Items.Count > 0) cbbDonDatHang.SelectedIndex = -1;
            cbbDuAn.Visible = false;
            cbbDonDatHang.Visible = false;
            rdbtnDuAn.Checked = false;
            rdbtnDonDatHang.Checked = false;
        }
    }
}
