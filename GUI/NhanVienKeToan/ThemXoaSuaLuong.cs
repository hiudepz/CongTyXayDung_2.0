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
using BLL;
using System.IO;
namespace GUI.NhanVienKeToan
{
    public partial class ThemXoaSuaLuong : Form
    {
        private readonly LuongNV_BLL bll = new LuongNV_BLL();
        private int selectedID = -1;
        private LuongNV_DTO currentLuong;//dữ liệu bên ngoài truyền  vào
        //public event Action DataChanged;
        public ThemXoaSuaLuong()
        {
            InitializeComponent();
        }
        public ThemXoaSuaLuong(LuongNV_DTO luong) : this()
        {
            currentLuong = luong;
        }
        private void LoadLuongData(int id)
        {
            var luong = bll.GetLuongByID(id);
            if (luong != null)
            {
                txtNhanvienid.Text = luong.NhanVienID.ToString();
                txtHoten.Text = luong.HoTen;
                txtThang.Text = luong.Thang.ToString();
                txtNam.Text = luong.Nam.ToString();
                txtBasicluong.Text = luong.LuongCoBan.ToString();
                txtThuong.Text = luong.Thuong.ToString();
                txtKhautru.Text = luong.KhauTru.ToString();
                txtPhucap.Text = luong.PhuCap.ToString();
                txtNgaycong.Text = luong.NgayCong.ToString();
                txtGiotangca.Text = luong.GioTangCa.ToString();
            }
        }
        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void ThemXoaSuaLuong_Load(object sender, EventArgs e)
        {
            if (currentLuong != null)
            {
                txtNhanvienid.Text = currentLuong.NhanVienID.ToString();
                txtHoten.Text = currentLuong.HoTen;
                txtThang.Text = currentLuong.Thang.ToString();
                txtNam.Text = currentLuong.Nam.ToString();
                txtBasicluong.Text = currentLuong.LuongCoBan.ToString();
                txtThuong.Text = currentLuong.Thuong.ToString();
                txtPhucap.Text = currentLuong.PhuCap.ToString();
                txtKhautru.Text = currentLuong.KhauTru.ToString();
                txtNgaycong.Text = currentLuong.NgayCong.ToString();
                txtGiotangca.Text = currentLuong.GioTangCa.ToString();
                selectedID = currentLuong.BangLuongID;
            }
            LoadData();
        }
        private void LoadData()
        {
            dgvLuong.DataSource = bll.GetAllLuong();
            dgvLuong.ClearSelection();
            ResetForm();
        }
        public void ResetForm()
        {
            //selectedID = -1;
            //txtNhanvienid.Clear();
            //txtHoten.Clear();
            //txtThang.Clear();
            //txtNam.Clear();
            //txtBasicluong.Clear();
            //txtThuong.Clear();
            //txtKhautru.Clear();
            //txtPhucap.Clear();
            //txtNgaycong.Clear();
            //txtGiotangca.Clear();
        }
        private LuongNV_DTO GetInput()
        {
            return new LuongNV_DTO
            {
                BangLuongID = selectedID,
                NhanVienID = int.TryParse(txtNhanvienid.Text, out var nvID) ? nvID : 0,
                HoTen = txtHoten.Text,
                Thang = int.TryParse(txtThang.Text, out var thang) ? thang : 0,
                Nam = int.TryParse(txtNam.Text, out var nam) ? nam : 0,
                LuongCoBan = decimal.TryParse(txtBasicluong.Text, out var luong) ? luong : 0,
                Thuong = decimal.TryParse(txtThuong.Text, out var thuong) ? thuong : 0,
                KhauTru = decimal.TryParse(txtKhautru.Text, out var khau) ? khau : 0,
                PhuCap = decimal.TryParse(txtPhucap.Text, out var phu) ? phu : 0,
                NgayCong = int.TryParse(txtNgaycong.Text, out var ngay) ? ngay : 0,
                GioTangCa = int.TryParse(txtGiotangca.Text, out var gio) ? gio : 0
            };
        }
       
        private void ValidateInput(LuongNV_DTO luong)
        {
            if (luong.NhanVienID <= 0)
                throw new ArgumentException("ID nhân viên không hợp lệ.");

            if (string.IsNullOrWhiteSpace(luong.HoTen))
                throw new ArgumentException("Họ tên không được để trống.");

            if (luong.Thang < 1 || luong.Thang > 12)
                throw new ArgumentException("Tháng phải nằm trong khoảng 1 đến 12.");

            if (luong.Nam < 2000 || luong.Nam > DateTime.Now.Year + 1)
                throw new ArgumentException("Năm không hợp lệ.");

            if (luong.LuongCoBan < 0)
                throw new ArgumentException("Lương cơ bản không thể âm.");

            if (luong.Thuong < 0)
                throw new ArgumentException("Thưởng không thể âm.");

            if (luong.KhauTru < 0)
                throw new ArgumentException("Khoản khấu trừ không thể âm.");

            if (luong.PhuCap < 0)
                throw new ArgumentException("Phụ cấp không thể âm.");

            if (luong.NgayCong < 0 || luong.NgayCong > 31)
                throw new ArgumentException("Số ngày công không hợp lệ (0–31).");

            if (luong.GioTangCa < 0)
                throw new ArgumentException("Giờ tăng ca không hợp lệ.");
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            try
            {
                var luong = GetInput();
                ValidateInput(luong);
                bll.Add(luong);
                MessageBox.Show("Thêm bảng lương thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadData();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi thêm bảng lương: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            try
            {
                if (selectedID <= 0)
                {
                    MessageBox.Show("Vui lòng chọn bảng lương cần xóa từ danh sách.", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (MessageBox.Show("Bạn có chắc chắn muốn xóa bảng lương này không?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    var luong = GetInput();
                    bll.Delete(selectedID);
                    MessageBox.Show("Xóa bảng lương thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadData();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi xóa bảng lương: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            try
            {
                if (selectedID <= 0)
                {
                    MessageBox.Show("Vui lòng chọn bảng lương cần sửa từ danh sách.", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                var luong = GetInput();
                ValidateInput(luong);
                bll.Update(luong);
                MessageBox.Show("Sửa bảng lương thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadData();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi sửa bảng lương: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



        private void btnTimkiemnhanvien_Click(object sender, EventArgs e)
        {
            string keyword = txtTimkiem.Text.Trim().ToLower();
            var result = bll.TimKiem(keyword);
            dgvLuong.DataSource = result;
        }

      

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void dgvLuong_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0)
                {
                    var row = dgvLuong.Rows[e.RowIndex];
                    selectedID = Convert.ToInt32(row.Cells["BangLuongID"]?.Value ?? 0);
                    txtNhanvienid.Text = row.Cells["NhanVienID"]?.Value?.ToString() ?? string.Empty;
                    txtHoten.Text = row.Cells["HoTen"]?.Value?.ToString() ?? string.Empty;
                    txtThang.Text = row.Cells["Thang"]?.Value?.ToString() ?? string.Empty;
                    txtNam.Text = row.Cells["Nam"]?.Value?.ToString() ?? string.Empty;
                    txtBasicluong.Text = row.Cells["LuongCoBan"]?.Value?.ToString() ?? string.Empty;
                    txtThuong.Text = row.Cells["Thuong"]?.Value?.ToString() ?? string.Empty;
                    txtKhautru.Text = row.Cells["KhauTru"]?.Value?.ToString() ?? string.Empty;
                    txtPhucap.Text = row.Cells["PhuCap"]?.Value?.ToString() ?? string.Empty;
                    txtNgaycong.Text = row.Cells["NgayCong"]?.Value?.ToString() ?? string.Empty;
                    txtGiotangca.Text = row.Cells["GioTangCa"]?.Value?.ToString() ?? string.Empty;
                    txtTongluong.Text = row.Cells["TongLuong"]?.Value?.ToString() ?? string.Empty;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải dữ liệu bảng lương " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void dgvLuong_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                var row = dgvLuong.Rows[e.RowIndex];
                selectedID = Convert.ToInt32(row.Cells["BangLuongID"].Value);
                txtNhanvienid.Text = row.Cells["NhanVienID"].Value?.ToString();
                txtHoten.Text = row.Cells["HoTen"].Value?.ToString();
                txtThang.Text = row.Cells["Thang"].Value?.ToString();
                txtNam.Text = row.Cells["Nam"].Value?.ToString();
                txtBasicluong.Text = row.Cells["LuongCoBan"].Value?.ToString();
                txtThuong.Text = row.Cells["Thuong"].Value?.ToString();
                txtKhautru.Text = row.Cells["KhauTru"].Value?.ToString();
                txtPhucap.Text = row.Cells["PhuCap"].Value?.ToString();
                txtNgaycong.Text = row.Cells["NgayCong"].Value?.ToString();
                txtGiotangca.Text = row.Cells["GioTangCa"].Value?.ToString();
            }
        }

        private void txtTimkiem_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtTimkiem.Text))
            {
                dgvLuong.DataSource = bll.GetAllLuong();
            }
        }
    }
}
