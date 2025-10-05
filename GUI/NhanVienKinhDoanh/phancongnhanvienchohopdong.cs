using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI
{
    public partial class phancongnhanvienchohopdong : Form
    {
        public phancongnhanvienchohopdong()
        {
            InitializeComponent();
        }

        private void phancongnhanvienchohopdong_Load(object sender, EventArgs e)
        {
           
                DataTable dt = new DataTable();

                dt.Columns.Add("ID", typeof(int));
                dt.Columns.Add("Hợp đồng", typeof(string));
                dt.Columns.Add("Nhân viên", typeof(string));
                dt.Columns.Add("Vai trò", typeof(string));

                
                dt.Rows.Add(1, "Hợp đồng 001", "Nguyen A", "Soạn thảo");
                dt.Rows.Add(2, "Hợp đồng 001", "Nguyen B", "Duyệt");

                dgvPhancongnhanvienchohopdong.DataSource = dt;
                dgvPhancongnhanvienchohopdong.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            

        }
    }
}
