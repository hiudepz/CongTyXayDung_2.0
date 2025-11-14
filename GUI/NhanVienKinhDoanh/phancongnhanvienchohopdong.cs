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
    public partial class phancongnhanvienchohopdong : Form
    {
        private readonly HopDong_BLL hopDong_BLL = new HopDong_BLL();
        private readonly NhanVien_BLL nhanVien_BLL = new NhanVien_BLL();
        private readonly PhanCongHopDong_BLL bll = new PhanCongHopDong_BLL();
        private int selectedID = -1;
        public phancongnhanvienchohopdong()
        {
            InitializeComponent();
        }

        private void phancongnhanvienchohopdong_Load(object sender, EventArgs e)
        {

            LoadHopDong();
            LoadNhanVien();
            LoadData();



        }
        private PhanCongHopDong_DTO GetInput()
        {
            return new PhanCongHopDong_DTO
            {
                PhanCongID = selectedID > 0 ? selectedID : 0,

                // Lấy HopDongID từ ComboBox
                HopDongID = (cbbTenhopdong.SelectedValue != null)
                         ? Convert.ToInt32(cbbTenhopdong.SelectedValue)
                         : 0,

                // Lấy NhanVienID từ ComboBox
                NhanVienID = (cbbTennhanvien.SelectedValue != null)
                          ? Convert.ToInt32(cbbTennhanvien.SelectedValue)
                          : 0,

                VaiTro = txtVaitro.Text.Trim(),


            };

        }
        public void LoadData()
        {
            //tắt chỉnh sửa trực tiếp trên dgv
            dgvPhancongnhanvienchohopdong.ReadOnly = true;
            dgvPhancongnhanvienchohopdong.AllowUserToAddRows = false;
            dgvPhancongnhanvienchohopdong.AllowUserToDeleteRows = false;
            dgvPhancongnhanvienchohopdong.EditMode = DataGridViewEditMode.EditProgrammatically;

            try
            {
                dgvPhancongnhanvienchohopdong.DataSource = bll.GetAll();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi load dữ liệu: " + ex.Message + "\n" + ex.InnerException?.Message);
            }

        }
        public void LoadHopDong()
        {
            try
            {
                var listHopDong = hopDong_BLL.GetAllHopDong();
                cbbTenhopdong.DataSource = listHopDong;
                cbbTenhopdong.DisplayMember = "TenHopDong";
                cbbTenhopdong.ValueMember = "HopDongID";

                cbbTenhopdong.DropDownStyle = ComboBoxStyle.DropDownList;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi load hợp đồng: " + ex.Message);
            }
        }
        public void LoadNhanVien()
        {
            try
            {
                var listNV = nhanVien_BLL.Laydanhsachnhanvien();
                cbbTennhanvien.DataSource = listNV;
                cbbTennhanvien.DisplayMember = "HoTen";
                cbbTennhanvien.ValueMember = "NhanVienID";

                cbbTennhanvien.DropDownStyle = ComboBoxStyle.DropDownList;

            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi load nhân viên: " + ex.Message);
            }
        }

        private void txtTimKiem_TextChanged(object sender, EventArgs e)
        {
            string keyword = txtTimKiem.Text.Trim().ToLower();

            if (string.IsNullOrEmpty(keyword))
            {
                LoadData();
              
                return;
            }

          

            var phanCongList = bll.Search(keyword).Where(x =>
                RemoveDiacritics(x.TenHopDong?.ToLower() ?? "").Contains(RemoveDiacritics(keyword)) ||
             
                RemoveDiacritics(x.HoTenNV?.ToLower() ?? "").Contains(RemoveDiacritics(keyword))).ToList();

         
            dgvPhancongnhanvienchohopdong.DataSource = phanCongList;
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
        private void btnThemnhanvienchohopdong_Click(object sender, EventArgs e)
        {
            try
            {

                selectedID = 0;
                var dto = GetInput();
                if (dto == null) return;      
                bll.Add(dto);

                LoadData(); // refresh lại grid
                MessageBox.Show("Thêm phân công thành công!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi thêm: " + ex.Message);
            }


        }

        private void btnXoanhanvienkhoihopdong_Click(object sender, EventArgs e)
        {
            if (selectedID <= 0)
            {
                MessageBox.Show("Vui lòng chọn phân công cần xóa.");
                return;
            }

            var confirm = MessageBox.Show("Bạn có chắc muốn xóa phân công này?", "Xác nhận", MessageBoxButtons.YesNo);
            if (confirm == DialogResult.Yes)
            {
                try
                {
                    bll.Delete(selectedID);
                    LoadData();
                    MessageBox.Show("Xóa hợp đồng thành công!");

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi sửa: " + ex.Message);
                }
            }
        }
        private void btnSuanhanvienchohopdong_Click(object sender, EventArgs e)
        {
            if (selectedID <= 0)
            {
                MessageBox.Show("Vui lòng chọn phân công cần sửa.");
                return;
            }

            var dto = GetInput();
            if (dto == null) return;

            try
            {
                bll.Update(dto);
                LoadData();
                MessageBox.Show("Cập nhật phân công thành công!");
                
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi sửa: " + ex.Message);
            }
        }
   
        private void dgvPhancongnhanvienchohopdong_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvPhancongnhanvienchohopdong.Rows[e.RowIndex];

                selectedID = Convert.ToInt32(row.Cells["PhanCongID"].Value);
                cbbTenhopdong.SelectedValue = Convert.ToInt32(row.Cells["HopDongID"].Value);
                cbbTennhanvien.SelectedValue = Convert.ToInt32(row.Cells["NhanVienID"].Value);
                txtVaitro.Text = row.Cells["VaiTro"].Value.ToString();
            }
        }
    }
}
