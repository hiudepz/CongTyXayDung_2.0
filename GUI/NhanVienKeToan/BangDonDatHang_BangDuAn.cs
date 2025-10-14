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
    public partial class BangDonDatHang_BangDuAn : Form
    {
        public BangDonDatHang_BangDuAn()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ThanhToan thanhToan = new ThanhToan();
            thanhToan.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ThanhToan thanhToan = new ThanhToan();
            thanhToan.ShowDialog();
        }
    }
}
