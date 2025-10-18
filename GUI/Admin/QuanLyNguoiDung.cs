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

namespace GUI.Admin
{
    public partial class QuanLyNguoiDung : Form
    {
        private NguoiDung_BLL nguoiDung_BLL = new NguoiDung_BLL();
        public QuanLyNguoiDung()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ThemNguoiDung addUser = new ThemNguoiDung();
            addUser.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            SuaNguoiDung addUser = new SuaNguoiDung();
            addUser.ShowDialog();
        }

        private void QuanLyNguoiDung_Load(object sender, EventArgs e)
        {
            
            dgvNguoiDung.DataSource = nguoiDung_BLL.GetAllUser();
        }
    }
}
