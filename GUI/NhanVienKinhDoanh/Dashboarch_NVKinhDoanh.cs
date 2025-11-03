using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI.NhanVienKinhDoanh
{
    public partial class Dashboarch_NVKinhDoanh : Form
    {
        public Dashboarch_NVKinhDoanh()
        {
            InitializeComponent();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            quanlyhopdong t = new quanlyhopdong();
            t.MdiParent = this;
            t.Show();
            t.WindowState = FormWindowState.Maximized;
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            quanlykhachhang t = new quanlykhachhang();
            t.MdiParent = this;
            t.Show();
            t.WindowState = FormWindowState.Maximized;
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            
        }
    }
}
