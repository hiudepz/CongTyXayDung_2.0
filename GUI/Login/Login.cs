using BLL;
using GUI.Admin;
using GUI.NhanVienKinhDoanh;
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
using GUI.NhanVienGiamSat;
using GUI.NhanVienKeToan;
using GUI.NhanVienKho;

namespace GUI.Login
{
    public partial class login : Form
    {
        private NguoiDung_BLL nd_bll = new NguoiDung_BLL();
        public static string TenDangNhapHienTai = "";
        public static int IDNhanVienHienTai = 0;
        public login()
        {
            InitializeComponent();
        }

        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            try
            {
                var username = txtTenDangNhap.Text?.Trim();
                var password = txtMatKhau.Text ?? string.Empty;
                var roleInput = comboBox1.SelectedItem?.ToString() ?? comboBox1.Text?.Trim();

                if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password) || string.IsNullOrWhiteSpace(roleInput))
                {
                    MessageBox.Show("Vui lòng nhập tên đăng nhập, mật khẩu và chọn vai trò.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Check credentials against users from BLL
                var user = nd_bll.GetAllUser()
                                 .FirstOrDefault(u => string.Equals(u.TenDangNhap, username, StringComparison.OrdinalIgnoreCase)
                                                   && u.MatKhau == password
                                                   && string.Equals(u.VaiTro, roleInput, StringComparison.OrdinalIgnoreCase));
              
                
                if (user == null)
                {
                    MessageBox.Show("Tên đăng nhập, mật khẩu hoặc vai trò không đúng.", "Đăng nhập thất bại", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                TenDangNhapHienTai = username;
                IDNhanVienHienTai = user.NhanVienID.Value;
                // Normalize role string for robust matching (remove diacritics, spaces and lowercase)
                string normalizedRole = NormalizeRole(user.VaiTro);

                // Route user to role-specific dashboard
                Form dashboard = null;
                if (normalizedRole.Contains("giam") || normalizedRole.Contains("giam-sat") || normalizedRole.Contains("giam-sat".Replace("-", "")))
                {
                    dashboard = new DashBoarch_GiamSat();
                }
                else if (normalizedRole.Contains("kinhdoanh") || normalizedRole.Contains("nvkinhdoanh") || normalizedRole.Contains("nhanvienkinhdoanh"))
                {
                    // fixed: correct class name is Dashboarch_NVKinhDoanh (lowercase 'b')
                    dashboard = new Dashboarch_NVKinhDoanh();
                }
                else if (normalizedRole.Contains("kho") || normalizedRole.Contains("nhanvienkho"))
                {
                    dashboard = new Dashboarch_Kho();
                }
                else if (normalizedRole.Contains("ketoan") || normalizedRole.Contains("ke-toan") || normalizedRole.Contains("nhanvienketoan"))
                {
                    dashboard = new Dashboarch_KeToan();
                }
                else
                {
                    // fallback to main admin dashboard
                    dashboard = new DashBoarch();
                }

                // Optionally pass user information to the dashboard (if dashboard exposes a property)
                // Example: if (dashboard is IDashboardWithUser dwu) dwu.CurrentUser = user;
                dashboard.Show();
                
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi đăng nhập: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Helper: remove diacritics, spaces and lowercase for matching
        private string NormalizeRole(string input)
        {
            if (string.IsNullOrWhiteSpace(input)) return string.Empty;
            var formD = input.Normalize(NormalizationForm.FormD);
            var sb = new StringBuilder();
            foreach (var ch in formD)
            {
                var uc = CharUnicodeInfo.GetUnicodeCategory(ch);
                if (uc != UnicodeCategory.NonSpacingMark)
                    sb.Append(ch);
            }
            // remove spaces and punctuation, lower-case
            var cleaned = new string(sb.ToString().Where(c => !char.IsPunctuation(c) && !char.IsWhiteSpace(c)).ToArray());
            return cleaned.ToLowerInvariant();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void login_Load(object sender, EventArgs e)
        {
            comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
        }
    }
}