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
        public ThemNguoiDung()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
                quanlynhanvien themnhanvien = new quanlynhanvien();
                themnhanvien.Show();
        }
    }
}
