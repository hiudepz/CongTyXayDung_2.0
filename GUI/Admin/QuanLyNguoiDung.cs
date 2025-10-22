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

namespace GUI.Admin
{
    public partial class QuanLyNguoiDung : Form
    {
        private NguoiDung_BLL nguoiDung_BLL = new NguoiDung_BLL();
        public QuanLyNguoiDung()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ThemNguoiDung addUser = new ThemNguoiDung();
            addUser.ShowDialog();
            dgvNguoiDung.DataSource = nguoiDung_BLL.GetAllUser();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            SuaNguoiDung addUser = new SuaNguoiDung();
            addUser.ShowDialog();
            dgvNguoiDung.DataSource = nguoiDung_BLL.GetAllUser();
        }

        private void QuanLyNguoiDung_Load(object sender, EventArgs e)
        {
            
            dgvNguoiDung.DataSource = nguoiDung_BLL.GetAllUser();
            dgvNguoiDung.Columns["NhanVienID"].Visible = false;
            dgvNguoiDung.Columns["NguoiDungID"].Visible = false;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            // Lấy hàng được chọn: ưu tiên SelectedRows, fallback sang CurrentRow
            DataGridViewRow selectedRow = null;
            if (dgvNguoiDung.SelectedRows != null && dgvNguoiDung.SelectedRows.Count > 0)
                selectedRow = dgvNguoiDung.SelectedRows[0];
            else if (dgvNguoiDung.CurrentRow != null)
                selectedRow = dgvNguoiDung.CurrentRow;

            if (selectedRow == null)
            {
                MessageBox.Show("Vui lòng chọn người dùng cần xóa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var idObj = selectedRow.Cells["NguoiDungID"]?.Value;
            if (idObj == null || !int.TryParse(idObj.ToString(), out int userId))
            {
                MessageBox.Show("Không xác định được ID người dùng. Vui lòng chọn lại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var confirm = MessageBox.Show($"Bạn có chắc chắn muốn xóa người dùng đã chọn", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (confirm != DialogResult.Yes)
                return;

            try
            {
                nguoiDung_BLL.DeleteUser(userId);

                // Cập nhật lại DataGridView
                dgvNguoiDung.DataSource = nguoiDung_BLL.GetAllUser();

                MessageBox.Show("Xóa người dùng thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi xóa người dùng: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void TxtSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.Handled = true;
                e.SuppressKeyPress = true;
                LoadUsers(txtTimKiem.Text);
            }
        }
        private void LoadUsers(string filter = null)
        {
            List<NguoiDung_DTO> users = nguoiDung_BLL.SearchUsers(filter);
            dgvNguoiDung.DataSource = users;
        }
        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            LoadUsers(txtTimKiem.Text);
        }

        private void txtTimKiem_TextChanged(object sender, EventArgs e)
        {
            LoadUsers(txtTimKiem.Text);
        }
    }
}
