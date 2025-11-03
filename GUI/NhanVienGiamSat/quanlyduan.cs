using BLL;
using DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI
{
    public partial class quanlyduan : Form
    {
        private readonly DuAn_BLL bll = new DuAn_BLL();
        private readonly KhachHang_BLL khachHangBLL = new KhachHang_BLL();
        private readonly HopDong_BLL hopDong_BLL = new HopDong_BLL();

        private int selectedID = -1;
        public quanlyduan()
        {
            InitializeComponent();
        }

        private void quanlyduan_Load(object sender, EventArgs e)
        {
            //format date
            dtpNgaybatdau.Format = DateTimePickerFormat.Custom;
            dtpNgaybatdau.CustomFormat = "MM/dd/yyyy";
            dtpNgayketthuc.Format = DateTimePickerFormat.Custom;
            dtpNgayketthuc.CustomFormat = "MM/dd/yyyy";
            //tắt chỉnh sửa trực tiếp trên dgv
            dgvQuanlyduan.ReadOnly = true;
            dgvQuanlyduan.AllowUserToAddRows = false;
            dgvQuanlyduan.AllowUserToDeleteRows = false;
            dgvQuanlyduan.EditMode = DataGridViewEditMode.EditProgrammatically;
            cbbKhachhang.DropDownStyle = ComboBoxStyle.DropDownList;
            cbbHopdong.DropDownStyle = ComboBoxStyle.DropDownList;
            LoadKH();
            LoadHD();
            LoadData();


        }
        private void LoadData()
        {
            try
            {
                var list = bll.GetAll();

                dgvQuanlyduan.DataSource = list;

                dgvQuanlyduan.Columns["DuAnID"].HeaderText = "Mã Dự Án";
                dgvQuanlyduan.Columns["TenDuAn"].HeaderText = "Tên Dự Án";
                dgvQuanlyduan.Columns["TenKhachHang"].HeaderText = "Khách Hàng";
                dgvQuanlyduan.Columns["TenHopDong"].HeaderText = "Hợp Đồng";
                dgvQuanlyduan.Columns["NgayBatDau"].HeaderText = "Ngày Bắt Đầu";
                dgvQuanlyduan.Columns["NgayKetThuc"].HeaderText = "Ngày Kết Thúc";
                dgvQuanlyduan.Columns["TienDo"].HeaderText = "Tiến Độ";


                dgvQuanlyduan.Columns["KhachHangID"].Visible = false;
                dgvQuanlyduan.Columns["HopDongID"].Visible = false;
                dgvQuanlyduan.Columns["HinhAnhDuAn"].Visible = false;
                if (dgvQuanlyduan.Columns.Contains("TenKhachHang"))
                    dgvQuanlyduan.Columns["TenKhachHang"].HeaderText = "Khách Hàng";
                if (dgvQuanlyduan.Columns.Contains("TenHopDong"))
                    dgvQuanlyduan.Columns["TenHopDong"].HeaderText = "Hợp Đồng";

            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải dữ liệu dự án: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void LoadKH()
        {
            try
            {
                var listKH = khachHangBLL.GetAllCustomer();



                cbbKhachhang.DataSource = listKH;
                cbbKhachhang.DisplayMember = "HoTenKH";  // Hiển thị tên KH
                cbbKhachhang.ValueMember = "KhachHangID";     // Giá trị lưu thực tế
                cbbKhachhang.SelectedIndex = -1;              // Không chọn mặc định
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải danh sách khách hàng: " + ex.Message,
                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void LoadHD()
        {
            try
            {
                var listHD = hopDong_BLL.GetAllHopDong();
                cbbHopdong.DataSource = listHD;
                cbbHopdong.DisplayMember = "TenHopDong";  // Hiển thị tên hợp đồng
                cbbHopdong.ValueMember = "HopDongID";     // Giá trị lưu thực tế
                cbbHopdong.SelectedIndex = -1;              // Không chọn mặc định
            }
            catch(Exception ex)
            {
                MessageBox.Show("Lỗi khi tải danh sách hợp đồng: " + ex.Message,
                                       "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);  
            }
        }
        private DuAn_DTO GetInput()
        {
            return new DuAn_DTO
            {
                DuAnID = selectedID,
                TenDuAn = txtTenduan.Text,
                KhachHangID = cbbKhachhang.SelectedValue != null
                        ? Convert.ToInt32(cbbKhachhang.SelectedValue)
                        : 0,
                HopDongID = cbbHopdong.SelectedValue != null
                        ? Convert.ToInt32(cbbHopdong.SelectedValue)
                        : 0,
                NgayBatDau = dtpNgaybatdau.Value,
                NgayKetThuc = dtpNgayketthuc.Value,
                TienDo = txtTiendo.Text,
                //HinhAnhDuAn = picHinhanh.Image != null ? ImageToByteArray(picHinhanh.Image) : null
            };
        }
        //private byte[] ImageToByteArray(Image image)
        //{
        //    using (var ms = new MemoryStream())
        //    {
        //        image.Save(ms, image.RawFormat);
        //        return ms.ToArray();
        //    }
        //}

        private void btnPhancongnhansuchoduan_Click(object sender, EventArgs e)
        {
            phancongnhansuchoduan frm = new phancongnhansuchoduan();
            frm.ShowDialog();
        }

        private void dgvQuanlyduan_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0)
                {
                    var row = dgvQuanlyduan.Rows[e.RowIndex];

                    selectedID = Convert.ToInt32(row.Cells["DuAnID"]?.Value ?? 0);

                    txtTenduan.Text = row.Cells["TenDuAn"]?.Value?.ToString() ?? string.Empty;
                    //CHỈ chọn theo ValueMember (ID)
                    int khachHangID = Convert.ToInt32(row.Cells["KhachHangID"].Value ?? 0);
                    int hopDongID = Convert.ToInt32(row.Cells["HopDongID"].Value ?? 0);

                    // Đảm bảo ComboBox đã có DataSource
                    if (cbbKhachhang.DataSource != null)
                        cbbKhachhang.SelectedValue = khachHangID;

                    if (cbbHopdong.DataSource != null)
                        cbbHopdong.SelectedValue = hopDongID;

                    if (DateTime.TryParse(row.Cells["NgayBatDau"]?.Value?.ToString(), out DateTime ngayBatDau))
                        dtpNgaybatdau.Value = ngayBatDau;
                    else
                        dtpNgaybatdau.Value = DateTime.Now;

                    if (DateTime.TryParse(row.Cells["NgayKetThuc"]?.Value?.ToString(), out DateTime ngayKetThuc))
                        dtpNgayketthuc.Value = ngayKetThuc;
                    else
                        dtpNgayketthuc.Value = DateTime.Now;

                    txtTiendo.Text = row.Cells["TienDo"]?.Value?.ToString() ?? string.Empty;

                    //hiển thị hình ảnh dự án (
                    //if (row.Cells["HinhAnhDuAn"].Value != DBNull.Value && row.Cells["HinhAnhDuAn"].Value != null)
                    //{
                    //    byte[] imgData = (byte[])row.Cells["HinhAnhDuAn"].Value;
                    //    using (var ms = new MemoryStream(imgData))
                    //    {
                    //        picHinhanh.Image = Image.FromStream(ms);
                    //    }
                    //}
                    //else
                    //{
                    //    picHinhanh.Image = null;
                    //}
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải dữ liệu dự án: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnThemduan_Click(object sender, EventArgs e)
        {
            try
            {
                selectedID = 0;

                var da = GetInput();
                bll.Add(da);
                LoadData();
                MessageBox.Show("Thêm dự án thành công!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnXoaduan_Click(object sender, EventArgs e)
        {
            if (selectedID == 0)
            {
                MessageBox.Show("Vui lòng chọn dự án để xóa.");
                return;
            }

            if (MessageBox.Show("Bạn có chắc muốn xóa dự án này?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    bll.Delete(selectedID);
                    LoadData();
                    MessageBox.Show("Xóa dự án thành công!");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi: " + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnSuaduan_Click(object sender, EventArgs e)
        {
            try
            {
                

                var da = GetInput();
                bll.Update(da);
                LoadData();
                MessageBox.Show("Cập nhật dự án thành công!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnTimkiem_Click(object sender, EventArgs e)
        {
            string keyword = txtTimkiem.Text.Trim();
            var result = bll.Search(keyword);
            dgvQuanlyduan.DataSource = result;

          
        }
            private void txtTimkiem_TextChanged(object sender, EventArgs e)
            {
                if (string.IsNullOrWhiteSpace(txtTimkiem.Text))
                {
                    dgvQuanlyduan.DataSource = bll.GetAll();
                }
            }

            private void dgvQuanlyduan_CellClick(object sender, DataGridViewCellEventArgs e)
            {
                if (e.RowIndex >= 0)
                {
                    var row = dgvQuanlyduan.Rows[e.RowIndex];
                    selectedID = Convert.ToInt32(row.Cells["DuAnID"].Value);
                    txtTenduan.Text = row.Cells["TenDuAn"].Value?.ToString();
                    txtTiendo.Text = row.Cells["TienDo"].Value?.ToString();
                    int khachHangID = Convert.ToInt32(row.Cells["KhachHangID"].Value ?? 0);
                int hopDongID = Convert.ToInt32(row.Cells["HopDongID"].Value ?? 0);

                // Đảm bảo ComboBox đã có DataSource
                if (cbbKhachhang.DataSource != null)
                        cbbKhachhang.SelectedValue = khachHangID;

                if (cbbHopdong.DataSource != null)
                    cbbHopdong.SelectedValue = hopDongID;
                dtpNgaybatdau.Value = Convert.ToDateTime(row.Cells["NgayBatDau"].Value);
                    dtpNgayketthuc.Value = Convert.ToDateTime(row.Cells["NgayKetThuc"].Value);
                    txtTiendo.Text = row.Cells["TienDo"].Value?.ToString() ?? "";

                }
            }

            private void groupBox2_Enter(object sender, EventArgs e)
            {

            }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
    } 

