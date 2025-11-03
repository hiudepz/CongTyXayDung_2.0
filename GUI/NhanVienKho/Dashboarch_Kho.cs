using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI.NhanVienKho
{
    public partial class Dashboarch_Kho : Form
    {
        public Dashboarch_Kho()
        {
            InitializeComponent();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            DonDatHang t = new DonDatHang();
            t.MdiParent = this;
            t.Show();
            t.WindowState = FormWindowState.Maximized;
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            QuanLyKho t = new QuanLyKho();
            t.MdiParent = this;
            t.Show();
            t.WindowState = FormWindowState.Maximized;
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            quanlynhacungcap t = new quanlynhacungcap();
            t.MdiParent = this;
            t.Show();
            t.WindowState = FormWindowState.Maximized;
        }

        private void toolStripButton5_Click(object sender, EventArgs e)
        {
            quanlyvattu t = new quanlyvattu();
            t.MdiParent = this;
            t.Show();
            t.WindowState = FormWindowState.Maximized;
        }

        private void Dashboarch_Kho_Load(object sender, EventArgs e)
        {

        }
    }
}
