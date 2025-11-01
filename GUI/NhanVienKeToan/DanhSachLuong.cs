using BLL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI.NhanVienKeToan
{
    public partial class DanhSachLuong : Form
    {
        private readonly LuongNV_BLL bll = new LuongNV_BLL();
        private int selectedID = 0;
        public DanhSachLuong()
        {
            InitializeComponent();
        }
        
        private void guna2Button2_Click(object sender, EventArgs e)
        {
         

            //if (selectedID == 0)
            //{
            //    MessageBox.Show("Vui lòng chọn một bản ghi.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //    return;
            //}
            // Lấy dữ liệu từ DataGridView
            var row = dgvDSThanhToan.CurrentRow;
            var luong = new DTO.LuongNV_DTO
            {
                BangLuongID = Convert.ToInt32(row.Cells["BangLuongID"].Value),
                NhanVienID = Convert.ToInt32(row.Cells["NhanVienID"].Value),
                HoTen = row.Cells["HoTen"].Value?.ToString(),
                Thang = Convert.ToInt32(row.Cells["Thang"].Value),
                Nam = Convert.ToInt32(row.Cells["Nam"].Value),
                LuongCoBan = Convert.ToDecimal(row.Cells["LuongCoBan"].Value),
                Thuong = Convert.ToDecimal(row.Cells["Thuong"].Value),
                KhauTru = Convert.ToDecimal(row.Cells["KhauTru"].Value),
                PhuCap = Convert.ToDecimal(row.Cells["PhuCap"].Value),
                NgayCong = Convert.ToInt32(row.Cells["NgayCong"].Value),
                GioTangCa = Convert.ToInt32(row.Cells["GioTangCa"].Value)
            };

            // Gọi form ThemXoaSuaLuong và truyền DTO qua constructor
            ThemXoaSuaLuong txs = new ThemXoaSuaLuong(luong);
            txs.ShowDialog();
            LoadData();
        }
        private void LoadData()
        {
            try
            {
                dgvDSThanhToan.DataSource = bll.GetAllLuong();
                dgvDSThanhToan.ClearSelection();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải danh sách lương: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void dgvDSThanhToan_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0)
                {
                    var row = dgvDSThanhToan.Rows[e.RowIndex];
                    selectedID = Convert.ToInt32(row.Cells["BangLuongID"]?.Value ?? 0);
              
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải dữ liệu bảng lương " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            //tắt chỉnh sửa trực tiếp trên dgv
            dgvDSThanhToan.ReadOnly = true;
            dgvDSThanhToan.AllowUserToAddRows = false;
            dgvDSThanhToan.AllowUserToDeleteRows = false;
            dgvDSThanhToan.EditMode = DataGridViewEditMode.EditProgrammatically;
            LoadData();
        }

        //private void dgvDSThanhToan_CellClick(object sender, DataGridViewCellEventArgs e)
        //{
        //    if (e.RowIndex >= 0)
        //    {
        //        var row = dgvDSThanhToan.Rows[e.RowIndex];
        //        selectedID = Convert.ToInt32(row.Cells["BangLuongID"].Value);
        //    }
        //}
    }
}
