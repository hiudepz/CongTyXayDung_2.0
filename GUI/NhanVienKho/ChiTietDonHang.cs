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
using System.Globalization;
using System.Runtime.InteropServices;

namespace GUI.NhanVienKho
{
    public partial class ChiTietDonHang : Form
    {
        private ChiTietDonDatHang_BLL ctddh_Bll = new ChiTietDonDatHang_BLL();
        private VatTu_BLL vatTu_Bll = new VatTu_BLL();
        private Kho_BLL Kho_BLL = new Kho_BLL();
        private int _donHangId;
        private int _nhanvienId;
        public ChiTietDonHang(int idDonDatHang, int idNhanVienID)
        {
            InitializeComponent();
            _donHangId = idDonDatHang;
            _nhanvienId = idNhanVienID;
        }
        

        private void ChiTietDonHang_Load(object sender, EventArgs e)
        {
            // Get all details for this order id
            dgvChiTietDonDatHang.DataSource = ctddh_Bll.GetDetailsByOrderId(_donHangId);
            dgvChiTietDonDatHang.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            //load combobox vat tu
            cbbVatTu.DataSource = vatTu_Bll.GetAllMaterials();
            cbbVatTu.DisplayMember = "TenVatTu";
            cbbVatTu.ValueMember = "VatTuID";

            //an id
            dgvChiTietDonDatHang.Columns["ChiTietID"].Visible = false;
            dgvChiTietDonDatHang.Columns["VatTuID"].Visible = false;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            try
            {
                if (cbbVatTu.SelectedValue == null)
                {
                    MessageBox.Show("Vui lòng chọn vật tư.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (!decimal.TryParse(txtDonGia.Text?.Trim(), NumberStyles.Number, CultureInfo.InvariantCulture, out decimal donGia))
                {
                    MessageBox.Show("Đơn giá không hợp lệ.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                var dto = new ChiTietDonDatHang_DTO
                {
                    DonDatHangID = _donHangId,
                    VatTuID = Convert.ToInt32(cbbVatTu.SelectedValue),
                    SoLuong = (int)nbSoLuong.Value,
                    DonGia = donGia
                };

                ctddh_Bll.AddOrderDetail(dto);
                MessageBox.Show("Thêm chi tiết thành công.", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);

                dgvChiTietDonDatHang.DataSource = ctddh_Bll.GetDetailsByOrderId(_donHangId);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi thêm chi tiết: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvChiTietDonDatHang.CurrentRow == null)
                {
                    MessageBox.Show("Vui lòng chọn một dòng để xóa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var cell = dgvChiTietDonDatHang.CurrentRow.Cells["ChiTietID"];
                if (cell == null || cell.Value == null)
                {
                    MessageBox.Show("Không thể lấy ID chi tiết.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                int chiTietId = Convert.ToInt32(cell.Value);

                var confirm = MessageBox.Show("Bạn có chắc muốn xóa chi tiết này?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (confirm != DialogResult.Yes) return;

                ctddh_Bll.DeleteOrderDetail(chiTietId);
                MessageBox.Show("Xóa thành công.", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);

                dgvChiTietDonDatHang.DataSource = ctddh_Bll.GetDetailsByOrderId(_donHangId);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi xóa chi tiết: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvChiTietDonDatHang.CurrentRow == null)
                {
                    MessageBox.Show("Vui lòng chọn một dòng để sửa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var cell = dgvChiTietDonDatHang.CurrentRow.Cells["ChiTietID"];
                if (cell == null || cell.Value == null)
                {
                    MessageBox.Show("Không thể lấy ID chi tiết.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (cbbVatTu.SelectedValue == null)
                {
                    MessageBox.Show("Vui lòng chọn vật tư.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (!decimal.TryParse(txtDonGia.Text?.Trim(), NumberStyles.Number, CultureInfo.InvariantCulture, out decimal donGia))
                {
                    MessageBox.Show("Đơn giá không hợp lệ.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                int chiTietId = Convert.ToInt32(cell.Value);

                var dto = new ChiTietDonDatHang_DTO
                {
                    ChiTietID = chiTietId,
                    DonDatHangID = _donHangId,
                    VatTuID = Convert.ToInt32(cbbVatTu.SelectedValue),
                    SoLuong = (int)nbSoLuong.Value,
                    DonGia = donGia
                };

                ctddh_Bll.UpdateOrderDetail(dto);
                MessageBox.Show("Cập nhật thành công.", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);

                dgvChiTietDonDatHang.DataSource = ctddh_Bll.GetDetailsByOrderId(_donHangId);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi cập nhật chi tiết: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvChiTietDonDatHang_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            cbbVatTu.SelectedValue = dgvChiTietDonDatHang.Rows[e.RowIndex].Cells["VatTuID"].Value;
            nbSoLuong.Value = Convert.ToDecimal(dgvChiTietDonDatHang.Rows[e.RowIndex].Cells["SoLuong"].Value);
            txtDonGia.Text = dgvChiTietDonDatHang.Rows[e.RowIndex].Cells["DonGia"].Value.ToString();
        }

        private void btnNhapHang_Click(object sender, EventArgs e)
        {
            

            var confirm = MessageBox.Show("Xác nhận nhập kho cho đơn hàng này?",
                                          "Nhập kho",
                                          MessageBoxButtons.YesNo,
                                          MessageBoxIcon.Question);

            if (confirm == DialogResult.Yes)
            {
                Kho_BLL.AddToWareHouse(_donHangId, _nhanvienId);
                MessageBox.Show("Nhập kho thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                 // reload lại giao diện
            }
        }
    }
}
