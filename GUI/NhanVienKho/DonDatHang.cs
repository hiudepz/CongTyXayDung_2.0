using BLL;
using DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common.CommandTrees.ExpressionBuilder;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI.NhanVienKho
{
    
    public partial class DonDatHang : Form
    {
        public int NhanVienID { get; set; }
        private DonDatHang_BLL ddh_bll = new DonDatHang_BLL();
        private ChiTietDonDatHang_BLL ctdh_bll = new ChiTietDonDatHang_BLL();
        private NhanVien_BLL  nv_bll = new NhanVien_BLL();
        private NhaCungCap_BLL ncc_bll = new NhaCungCap_BLL();

        // store currently selected order id (nullable)
        private int? _selectedOrderId;
        public DonDatHang()
        {
            InitializeComponent();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (Convert.ToInt32(dgvDonDatHang.CurrentRow.Cells["DonDatHangID"].Value) == null) { 
                MessageBox.Show("Vui lòng chọn đơn đặt hàng cần xem chi tiết!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            int donDatHangID = Convert.ToInt32(dgvDonDatHang.CurrentRow.Cells["DonDatHangID"].Value);
            int nhanVienID = Convert.ToInt32(dgvDonDatHang.CurrentRow.Cells["NhanVienID"].Value);

            ChiTietDonHang  ct = new ChiTietDonHang(donDatHangID,nhanVienID);
            ct.ShowDialog();
        }

        private void DonDatHang_Load(object sender, EventArgs e)
        {
            //load data dgvDonDatHang
            dgvDonDatHang.DataSource = ddh_bll.GetAllOrders();
            dgvDonDatHang.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            //load data cbb:
            //1.NhaCungCap
            cbbNhaCungCap.DataSource = ncc_bll.GetAllSuplier();
            cbbNhaCungCap.DisplayMember = "TenNCC";
            cbbNhaCungCap.ValueMember = "NhaCungCapID";
            //2.NhanVien
            cbbNhanVien.DataSource = nv_bll.Laydanhsachnhanvien();
            cbbNhanVien.DisplayMember = "HoTen";
            cbbNhanVien.ValueMember = "NhanVienID";

            //fomat dtp NgayDat
            dtpNgayDatDon.Format = DateTimePickerFormat.Custom;
            dtpNgayDatDon.CustomFormat = "dd/MM/yyyy";

            //an cot ID (guard in case columns not present yet)
            if (dgvDonDatHang.Columns.Contains("DonDatHangID"))
                dgvDonDatHang.Columns["DonDatHangID"].Visible = false;
            if (dgvDonDatHang.Columns.Contains("NhaCungCapID"))
                dgvDonDatHang.Columns["NhaCungCapID"].Visible = false;
            if (dgvDonDatHang.Columns.Contains("NhanVienID"))
                dgvDonDatHang.Columns["NhanVienID"].Visible = false;
            txtDonDathangID.Visible = false;

            //Add Trang thai
            cbbTrangThai.Items.Add("Đang Giao");
            cbbTrangThai.Items.Add("Đã hủy hàng");
            cbbTrangThai.Items.Add("Đã Nhập Kho");
            

            cbbTrangThai.DropDownStyle = ComboBoxStyle.DropDownList;

            // initialize selected id
            _selectedOrderId = null;

            // optional: allow clicking entire row to select (improves UX)
            dgvDonDatHang.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvDonDatHang.MultiSelect = false;
        }

        private void btnHienThiThem_Click(object sender, EventArgs e)
        {

            ThongTinChiTietNhanVienDatHang tt = new ThongTinChiTietNhanVienDatHang();
            if (tt.ShowDialog() == DialogResult.OK)
            {
                // set lại ComboBox theo nhân viên vừa chọn
                cbbNhanVien.SelectedValue = tt.SelectedNhanVienID;
                //txtHoTenNhanVien.Text = f.SelectedHoTen;
            }
        }

        private void dgvDonDatHang_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Guard against header clicks or invalid row index
            var row = dgvDonDatHang.Rows[e.RowIndex];
            txtDonDathangID.Text = row.Cells["DonDatHangID"]?.Value?.ToString() ?? string.Empty;


            
            // Prefer selecting ComboBox by Value (IDs) rather than Text
            var nccIdObj = row.Cells["NhaCungCapID"]?.Value;
            if (nccIdObj != null && int.TryParse(nccIdObj.ToString(), out int nccId))
                cbbNhaCungCap.SelectedValue = nccId;
            else
                cbbNhaCungCap.SelectedIndex = -1;

            var nvIdObj = row.Cells["NhanVienID"]?.Value;
            if (nvIdObj != null && int.TryParse(nvIdObj.ToString(), out int nvId))
                cbbNhanVien.SelectedValue = nvId;
            else
                cbbNhanVien.SelectedIndex = -1;

            DateTime parsedDate;
            if (DateTime.TryParse(row.Cells["NgayDat"]?.Value?.ToString(), out parsedDate))
                dtpNgayDatDon.Value = parsedDate;
            else
                dtpNgayDatDon.Value = DateTime.Now;

            cbbTrangThai.Text = row.Cells["TrangThai"]?.Value?.ToString() ?? string.Empty;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            try 
            {
                // Validate selected supplier and employee via SelectedValue (not by Display text)
                if (cbbNhaCungCap.SelectedValue == null)
                {
                    MessageBox.Show("Vui lòng chọn nhà cung cấp.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (cbbNhanVien.SelectedValue == null)
                {
                    MessageBox.Show("Vui lòng chọn nhân viên.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (string.IsNullOrWhiteSpace(cbbTrangThai.Text))
                {
                    MessageBox.Show("Vui lòng chọn trạng thái đơn.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (!int.TryParse(cbbNhaCungCap.SelectedValue.ToString(), out int nccId))
                {
                    MessageBox.Show("Giá trị NhaCungCapID không hợp lệ.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (!int.TryParse(cbbNhanVien.SelectedValue.ToString(), out int nvId))
                {
                    MessageBox.Show("Giá trị NhanVienID không hợp lệ.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                DonDatHang_DTO ddh = new DonDatHang_DTO
                {
                    // Do NOT set DonDatHangID for new entries (DB will generate)
                    NhaCungCapID = nccId,
                    NhanVienID = nvId,
                    NgayDat = dtpNgayDatDon.Value,
                    TrangThai = cbbTrangThai.Text
                };

                ddh_bll.AddOrder(ddh);

                // Refresh grid and notify user
                dgvDonDatHang.DataSource = ddh_bll.GetAllOrders();
                MessageBox.Show("Thêm đơn đặt hàng thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Optionally reset inputs
                cbbNhaCungCap.SelectedIndex = -1;
                cbbNhanVien.SelectedIndex = -1;
                cbbTrangThai.SelectedIndex = -1;
                dtpNgayDatDon.Value = DateTime.Now;
                _selectedOrderId = null;
            } 
            catch (Exception ex) 
            {
                MessageBox.Show("Vui lòng kiểm tra lại các lỗi sau:\n\n" + ex.Message,
                                "Thông báo",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            
            if (string.IsNullOrEmpty(txtDonDathangID.Text))
            {
                MessageBox.Show("Vui lòng chọn đơn đặt hàng cần xóa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

                     var confirm = MessageBox.Show("Bạn có chắc chắn muốn xóa đơn đặt hàng đã chọn?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (confirm != DialogResult.Yes) return;

            try
            {
                ddh_bll.DeleteOrderDetail(Convert.ToInt32(txtDonDathangID.Text));
                ddh_bll.DeleteOrder(Convert.ToInt32(txtDonDathangID.Text));
                
                dgvDonDatHang.DataSource = ddh_bll.GetAllOrders();
                MessageBox.Show("Xóa đơn đặt hàng thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                _selectedOrderId = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi xóa đơn: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {


            if (string.IsNullOrEmpty(txtDonDathangID.Text))
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
            if (cbbNhanVien.SelectedValue == null)
            {
                MessageBox.Show("Vui lòng chọn nhân viên.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (string.IsNullOrWhiteSpace(cbbTrangThai.Text))
            {
                MessageBox.Show("Vui lòng chọn trạng thái đơn.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!int.TryParse(cbbNhaCungCap.SelectedValue.ToString(), out int nccId))
            {
                MessageBox.Show("Giá trị NhaCungCapID không hợp lệ.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (!int.TryParse(cbbNhanVien.SelectedValue.ToString(), out int nvId))
            {
                MessageBox.Show("Giá trị NhanVienID không hợp lệ.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                DonDatHang_DTO ddh = new DonDatHang_DTO
                {
                    DonDatHangID = int.Parse(txtDonDathangID.Text),
                    NhaCungCapID = nccId,
                    NhanVienID = nvId,
                    NgayDat = dtpNgayDatDon.Value,
                    TrangThai = cbbTrangThai.Text
                };

                ddh_bll.UpdateOrder(ddh);

                dgvDonDatHang.DataSource = ddh_bll.GetAllOrders();
                MessageBox.Show("Cập nhật đơn đặt hàng thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                _selectedOrderId = null;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi cập nhật đơn: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtTimKiem_TextChanged(object sender, EventArgs e)
        {
            LoadOders(txtTimKiem.Text);
        }
        private void LoadOders(string filter = null)
        {
            List<DonDatHang_DTO> users = ddh_bll.SearchOrders(filter);
            dgvDonDatHang.DataSource = users;
        }

        private void btnNhapHang_Click(object sender, EventArgs e)
        {
            if (Convert.ToInt32(dgvDonDatHang.CurrentRow.Cells["DonDatHangID"].Value) == null)
            {
                MessageBox.Show("Vui lòng chọn đơn đặt hàng cần nhập kho", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            int donDatHangID = Convert.ToInt32(dgvDonDatHang.CurrentRow.Cells["DonDatHangID"].Value);
            QuanLyKho ct = new QuanLyKho(donDatHangID);
            ct.ShowDialog();
        }
    }
}
