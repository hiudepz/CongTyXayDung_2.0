using GUI.NhanVienGiamSat;
using GUI.NhanVienKeToan;
using GUI.NhanVienKho;
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

namespace GUI.Admin
{
    public partial class DashBoarch : Form
    {
        public DashBoarch()
        {
            InitializeComponent();
        }
    
        private void quảnLýNhânViênToolStripMenuItem_Click(object sender, EventArgs e)
        {
            quanlynhanvien qlnv = new quanlynhanvien();
            qlnv.MdiParent = this;
            qlnv.Show();
        }

       

        private void tspQuanLyNhanVien_Click(object sender, EventArgs e)
        {
            quanlynhanvien qlnv = new quanlynhanvien();
            qlnv.MdiParent = this;
            
            qlnv.Show();
        }

        private void tspQuanLyTaiKhoan_Click(object sender, EventArgs e)
        {
            QuanLyNguoiDung qlnv = new QuanLyNguoiDung();
            qlnv.MdiParent = this;
            qlnv.Show();
        }

        private void quảnLýNgườiDùngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            QuanLyNguoiDung qlnv = new QuanLyNguoiDung();
            qlnv.MdiParent = this;
            qlnv.Show();
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void MainForm_Load(object sender, EventArgs e)
        {

        }

        private void quảnLýKháchHàngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            quanlykhachhang qlnv = new quanlykhachhang();
            qlnv.MdiParent = this;
            qlnv.Show();
        }

        private void quảnLýHợpĐồngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            quanlyhopdong qlnv = new quanlyhopdong();
            qlnv.MdiParent = this;
            qlnv.Show();
        }

        private void quảnLýDựÁnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            quanlyduan qlnv = new quanlyduan();
            qlnv.MdiParent = this;
            qlnv.Show();
        }

        private void phânCôngNhânSựToolStripMenuItem_Click(object sender, EventArgs e)
        {
            phancongnhansuchoduan qlnv = new phancongnhansuchoduan();
            qlnv.MdiParent = this;
            qlnv.Show();
        }

        private void quảnLýNhàCungCấpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            quanlynhacungcap qlnv = new quanlynhacungcap();
            qlnv.MdiParent = this;
            qlnv.Show();
        }

        private void quảnLýKhoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            QuanLyKho qlnv = new QuanLyKho();
            qlnv.MdiParent = this;
            qlnv.Show();
        }

        private void quảnLýLươngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DanhSachLuong qlnv = new DanhSachLuong();
            qlnv.MdiParent = this;
            qlnv.Show();
        }

        private void quảnLýThanhToánToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DanhSachThanhToan qlnv = new DanhSachThanhToan();
            qlnv.MdiParent = this;
            qlnv.Show();
        }

        private void phânToolStripMenuItem_Click(object sender, EventArgs e)
        {
            phancongnhanvienchohopdong qlnv = new phancongnhanvienchohopdong();
            qlnv.MdiParent = this;
            qlnv.Show();
        }

        private void quảnLýYêuCầuKháchHàngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            quanlyyeucaukhachhang qlnv = new quanlyyeucaukhachhang();
            qlnv.MdiParent = this;
            qlnv.Show();
        }

        private void quảnLýVậtTưToolStripMenuItem_Click(object sender, EventArgs e)
        {
            quanlyvattu qlnv = new quanlyvattu();
            qlnv.MdiParent = this;
            qlnv.Show();
        }

        private void trangChủKếToánToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Dashboarch_KeToan qlnv = new Dashboarch_KeToan();
            qlnv.Show();
        }

        private void trangChủKhoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Dashboarch_Kho qlnv = new Dashboarch_Kho();
            qlnv.Show();
        }

        private void trangChủNhânViênKinhDoanhToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Dashboarch_NVKinhDoanh qlnv = new Dashboarch_NVKinhDoanh();
            qlnv.Show();
        }

        private void trangChủGiámSátToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DashBoarch_GiamSat qlnv = new DashBoarch_GiamSat();

            qlnv.Show();
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            DonDatHang qlnv = new DonDatHang();
            qlnv.MdiParent = this;
            qlnv.Show();
        }
    }
}
