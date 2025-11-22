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
using GUI.Login;

namespace GUI.NhanVienKho
{
    public partial class QuanLyKho : Form
    {
        private Kho_BLL kho_BLL = new Kho_BLL();
        private VatTu_BLL vatTu_BLL = new VatTu_BLL();
        private DuAn_BLL duAn_BLL = new DuAn_BLL();
        private int idDonDatHang =0;
        public QuanLyKho(int id)
        {
            InitializeComponent();
            idDonDatHang = id;
        }
        public QuanLyKho()
        {
            InitializeComponent();
            
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            
        }

        private void QuanLyKho_Load(object sender, EventArgs e)
        {
            cbbDuAn.DataSource = duAn_BLL.GetAll();
            cbbDuAn.DisplayMember = "TenDuAn";
            cbbDuAn.ValueMember = "DuAnID";
            cbbLoaiVatTu.DataSource = vatTu_BLL.GetAllMaterials();
            cbbLoaiVatTu.DisplayMember = "TenVatTu";
            cbbLoaiVatTu.ValueMember = "VatTuID";

            dtpNgayGiaoDich.Format = DateTimePickerFormat.Custom;
            dtpNgayGiaoDich.CustomFormat = "dd/MM/yyyy";

            dgvKho.DataSource = kho_BLL.GetAllWareHouseRecords();
            //an id
            dgvKho.Columns["VatTuID"].Visible = false;
            dgvKho.Columns["DuAnID"].Visible = false;
            dgvKho.Columns["NhanVienID"].Visible = false;
            dgvKho.Columns["DonDatHangID"].Visible = false;
            dgvKho.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void cbNhap_CheckedChanged(object sender, EventArgs e)
        {
            SearchWarehouse();
        }

        private void cbXuat_CheckedChanged(object sender, EventArgs e)
        {
            SearchWarehouse();
        }
        public void FilterWarehouse()
        {
            // kept for compatibility, use unified search behavior
            SearchWarehouse();
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            SearchWarehouse();
        }

        // Unified search combining keyword + checkbox filters.
        // - keyword matches VatTu.TenVatTu, NhanVien.HoTen, LoaiGiaoDich (handled in DAL)
        // - checkboxes restrict to "Nhập" or "Xuất" when only one is checked
        public void SearchWarehouse()
        {
            try
            {
                string keyword = string.IsNullOrWhiteSpace(textBox1.Text) ? null : textBox1.Text.Trim();
                string loai = null;
                if (cbNhap.Checked && !cbXuat.Checked) loai = "Nhập";
                else if (!cbNhap.Checked && cbXuat.Checked) loai = "Xuất";
                var list = kho_BLL.Search(keyword, null, null, loai);
                dgvKho.DataSource = list;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tìm kiếm: " + ex.Message);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                int vatTuID = (int)cbbLoaiVatTu.SelectedValue;
                int soLuong = (int)numSoLuong.Value;
                int nhanVienID = login.IDNhanVienHienTai ;
                int duAnID = (int)cbbDuAn.SelectedValue;

                if (soLuong <= 0)
                {
                    MessageBox.Show("Vui lòng nhập số lượng > 0!");
                    return;
                }

                kho_BLL.XuatKho(vatTuID, soLuong, nhanVienID, duAnID);
                MessageBox.Show("Xuất kho thành công!");
                dgvKho.DataSource = kho_BLL.GetAllWareHouseRecords();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }
    }
}
