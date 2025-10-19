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
    public partial class ThemNguoiDung : Form
    {
        private NguoiDung_BLL nd_bll = new NguoiDung_BLL();
        public ThemNguoiDung()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
                quanlynhanvien themnhanvien = new quanlynhanvien();
                themnhanvien.Show();
        }

        private void ThemNguoiDung_Load(object sender, EventArgs e)
        {

            dgvNguoiDung.DataSource = nd_bll.GetAllUser();
            dgvNguoiDung.Columns["NhanVienID"].Visible = false;
            dgvNguoiDung.Columns["NguoiDungID"].Visible = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                NguoiDung_DTO nd = new NguoiDung_DTO
                {
                    TenDangNhap = txtTenDangNhap.Text.Trim(),
                    MatKhau = txtMatKhau.Text.Trim(),
                    VaiTro = cbbVaiTro.SelectedItem?.ToString(),
                    NhanVienID = txtTenNhanVien.TabIndex
                };

                nd_bll.AddUser(nd);
                MessageBox.Show("Thêm người dùng thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Vui lòng kiểm tra lại các lỗi sau:\n\n" + ex.Message,
                                "Thông báo",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);
            }
        }
    }
}
