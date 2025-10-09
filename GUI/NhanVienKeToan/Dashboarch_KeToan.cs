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
    public partial class Dashboarch_KeToan : Form
    {
        public Dashboarch_KeToan()
        {
            InitializeComponent();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            DanhSachThanhToan t = new DanhSachThanhToan();
            t.MdiParent = this;
            t.Show();
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            DanhSachLuong t = new DanhSachLuong();
            t.MdiParent = this;
            t.Show();
        }
    }
}
