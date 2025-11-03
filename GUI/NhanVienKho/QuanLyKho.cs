using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BLL;
using DTO;

namespace GUI.NhanVienKho
{
    public partial class QuanLyKho : Form
    {
        private Kho_BLL kho_BLL = new Kho_BLL();
        private int idDonDatHang;
        public QuanLyKho(int id)
        {
            InitializeComponent();
            idDonDatHang = id;
        }
 

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void QuanLyKho_Load(object sender, EventArgs e)
        {
            dgvKho.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvKho.DataSource = kho_BLL.GetAllWareHouseRecords();
        }
    }
}
