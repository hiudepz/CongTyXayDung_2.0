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
    public partial class quanlynhacungcap : Form
    {
        private readonly NhaCungCap_BLL bll = new NhaCungCap_BLL();
        private int selectedID = 0;
        public quanlynhacungcap()
        {
            InitializeComponent();
        }

        private void quanlynhacungcap_Load(object sender, EventArgs e)
        {
           LoadData();
        }

        private void dgvNcc_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        private void LoadData()
        {
            try
            {
                dgvNCC.DataSource = bll.GetAllSupplier();
                dgvNCC.AutoGenerateColumns = false;

                if (dgvNCC.Columns.Count == 0)
                {
                    dgvNCC.Columns.Add("NhaCungCapID", "Mã NCC");
                    dgvNCC.Columns["NhaCungCapID"].DataPropertyName = "NhaCungCapID";

                    dgvNCC.Columns.Add("TenNCC", "Tên nhà cung cấp");
                    dgvNCC.Columns["TenNCC"].DataPropertyName = "TenNCC";

                    dgvNCC.Columns.Add("Email", "Email");
                    dgvNCC.Columns["Email"].DataPropertyName = "Email";

                    dgvNCC.Columns.Add("Phone", "Số điện thoại");
                    dgvNCC.Columns["Phone"].DataPropertyName = "Phone";

                    dgvNCC.Columns.Add("DiaChi", "Địa chỉ");
                    dgvNCC.Columns["DiaChi"].DataPropertyName = "DiaChi";
                }

                //ClearForm();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải dữ liệu: " + ex.Message);
            }
        }
        private NhaCungCap_DTO GetInput()
        {
            return new NhaCungCap_DTO
            {
                NhaCungCapID = selectedID,
                TenNCC =txtTenNCC.Text.Trim(),
                Email = txtEmail.Text.Trim(),   
                Phone = txtPhone.Text.Trim(),
                DiaChi = txtDiachi.Text.Trim()
            };
        }
        private void ClearForm()
        {
            txtTenNCC.Clear();
            txtEmail.Clear();
            txtPhone.Clear();
            txtDiachi.Clear();
            selectedID = 0;
        }
        private void dgvNCC_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                var row = dgvNCC.Rows[e.RowIndex];
                selectedID = Convert.ToInt32(row.Cells["NhaCungCapID"].Value);
                txtTenNCC.Text = row.Cells["TenNCC"].Value?.ToString();
                txtEmail.Text = row.Cells["Email"].Value?.ToString();
                txtPhone.Text = row.Cells["Phone"].Value?.ToString();
                txtDiachi.Text = row.Cells["DiaChi"].Value?.ToString();
            }
        }

        private void btnThemNCC_Click(object sender, EventArgs e)
        {
            try
            {
                var dto = GetInput();

                bll.Add(dto);
                MessageBox.Show("Thêm nhà cung cấp thành công!");
                LoadData();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }

        private void btnXoaNCC_Click(object sender, EventArgs e)
        {
            if (selectedID == 0)
            {
                MessageBox.Show("Vui lòng chọn nhà cung cấp cần xóa!");
                return;
            }

            if (MessageBox.Show("Bạn có chắc muốn xóa nhà cung cấp này?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    bll.Delete(selectedID);
                    MessageBox.Show("Xóa thành công!");
                    LoadData();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi xóa: " + ex.Message);
                }
            }
        }

        private void btnSuaNCC_Click(object sender, EventArgs e)
        {
            if (selectedID == 0)
            {
                MessageBox.Show("Vui lòng chọn nhà cung cấp cần sửa.");
                return;
            }

            try
            {
                var dto = GetInput();
                bll.Update(dto);
                MessageBox.Show("Cập nhật thành công!");
                LoadData();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi sửa: " + ex.Message);
            }
        }

        private void txtTimKiem_TextChanged(object sender, EventArgs e)
        {
            string keyword = txtTimKiem.Text.Trim();
            if (string.IsNullOrEmpty(keyword))
            {
                LoadData();
            }
            else
            {
                dgvNCC.DataSource = bll.Search(keyword);
            }
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}
