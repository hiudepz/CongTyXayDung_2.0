using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI.NhanVienGiamSat
{
    public partial class DashBoarch_GiamSat : Form
    {
        public DashBoarch_GiamSat()
        {
            InitializeComponent();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            quanlyduan qlda = new quanlyduan();
            qlda.MdiParent = this;
            qlda.Show();
        }
    }
}
