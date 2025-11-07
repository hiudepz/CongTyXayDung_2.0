namespace GUI.NhanVienKeToan
{
    partial class ThemXoaSuaLuong
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.dgvLuong = new System.Windows.Forms.DataGridView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtTimkiem = new System.Windows.Forms.TextBox();
            this.btnTimkiemnhanvien = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.txtBasicluong = new System.Windows.Forms.TextBox();
            this.txtThuong = new System.Windows.Forms.TextBox();
            this.txtKhautru = new System.Windows.Forms.TextBox();
            this.txtTongluong = new System.Windows.Forms.TextBox();
            this.txtNgaycong = new System.Windows.Forms.TextBox();
            this.txtGiotangca = new System.Windows.Forms.TextBox();
            this.txtPhucap = new System.Windows.Forms.TextBox();
            this.btnThem = new System.Windows.Forms.Button();
            this.btnXoa = new System.Windows.Forms.Button();
            this.btnSua = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txtHoten = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label11 = new System.Windows.Forms.Label();
            this.dtpThangNam = new System.Windows.Forms.DateTimePicker();
            this.cbbMaNhanVien = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLuong)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvLuong
            // 
            this.dgvLuong.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvLuong.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvLuong.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dgvLuong.Location = new System.Drawing.Point(3, 107);
            this.dgvLuong.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dgvLuong.Name = "dgvLuong";
            this.dgvLuong.RowHeadersWidth = 51;
            this.dgvLuong.RowTemplate.Height = 24;
            this.dgvLuong.Size = new System.Drawing.Size(581, 481);
            this.dgvLuong.TabIndex = 0;
            this.dgvLuong.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvLuong_CellClick);
            this.dgvLuong.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvLuong_CellContentClick_1);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtTimkiem);
            this.groupBox1.Controls.Add(this.btnTimkiemnhanvien);
            this.groupBox1.Controls.Add(this.dgvLuong);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(15, 6);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox1.Size = new System.Drawing.Size(587, 590);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Chọn nhân viên";
            // 
            // txtTimkiem
            // 
            this.txtTimkiem.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtTimkiem.Location = new System.Drawing.Point(339, 48);
            this.txtTimkiem.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtTimkiem.Name = "txtTimkiem";
            this.txtTimkiem.Size = new System.Drawing.Size(132, 26);
            this.txtTimkiem.TabIndex = 20;
            this.txtTimkiem.TextChanged += new System.EventHandler(this.txtTimkiem_TextChanged);
            // 
            // btnTimkiemnhanvien
            // 
            this.btnTimkiemnhanvien.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnTimkiemnhanvien.Location = new System.Drawing.Point(480, 44);
            this.btnTimkiemnhanvien.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnTimkiemnhanvien.Name = "btnTimkiemnhanvien";
            this.btnTimkiemnhanvien.Size = new System.Drawing.Size(100, 28);
            this.btnTimkiemnhanvien.TabIndex = 19;
            this.btnTimkiemnhanvien.Text = "Tìm kiếm";
            this.btnTimkiemnhanvien.UseVisualStyleBackColor = true;
            this.btnTimkiemnhanvien.Click += new System.EventHandler(this.btnTimkiemnhanvien_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(59, 130);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(105, 20);
            this.label1.TabIndex = 3;
            this.label1.Text = "Tháng / Năm";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(59, 179);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(110, 20);
            this.label3.TabIndex = 5;
            this.label3.Text = "Lương cơ bản";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(59, 228);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(64, 20);
            this.label4.TabIndex = 6;
            this.label4.Text = "Thưởng";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(59, 277);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(72, 20);
            this.label5.TabIndex = 7;
            this.label5.Text = "Khấu trừ";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(61, 326);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(91, 20);
            this.label6.TabIndex = 8;
            this.label6.Text = "Tổng lương";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(61, 375);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(93, 20);
            this.label7.TabIndex = 9;
            this.label7.Text = "Ngày công ";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(59, 424);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(95, 20);
            this.label8.TabIndex = 10;
            this.label8.Text = "Giờ tăng ca";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(59, 473);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(70, 20);
            this.label9.TabIndex = 11;
            this.label9.Text = "Phụ cấp";
            // 
            // txtBasicluong
            // 
            this.txtBasicluong.Location = new System.Drawing.Point(201, 176);
            this.txtBasicluong.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtBasicluong.Name = "txtBasicluong";
            this.txtBasicluong.Size = new System.Drawing.Size(197, 26);
            this.txtBasicluong.TabIndex = 13;
            this.txtBasicluong.TextChanged += new System.EventHandler(this.txtBasicluong_TextChanged);
            // 
            // txtThuong
            // 
            this.txtThuong.Location = new System.Drawing.Point(201, 225);
            this.txtThuong.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtThuong.Name = "txtThuong";
            this.txtThuong.Size = new System.Drawing.Size(197, 26);
            this.txtThuong.TabIndex = 14;
            this.txtThuong.TextChanged += new System.EventHandler(this.txtThuong_TextChanged);
            // 
            // txtKhautru
            // 
            this.txtKhautru.Location = new System.Drawing.Point(201, 274);
            this.txtKhautru.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtKhautru.Name = "txtKhautru";
            this.txtKhautru.Size = new System.Drawing.Size(197, 26);
            this.txtKhautru.TabIndex = 15;
            // 
            // txtTongluong
            // 
            this.txtTongluong.Location = new System.Drawing.Point(201, 323);
            this.txtTongluong.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtTongluong.Name = "txtTongluong";
            this.txtTongluong.Size = new System.Drawing.Size(197, 26);
            this.txtTongluong.TabIndex = 16;
            this.txtTongluong.TextChanged += new System.EventHandler(this.txtTongluong_TextChanged);
            // 
            // txtNgaycong
            // 
            this.txtNgaycong.Location = new System.Drawing.Point(201, 372);
            this.txtNgaycong.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtNgaycong.Name = "txtNgaycong";
            this.txtNgaycong.Size = new System.Drawing.Size(197, 26);
            this.txtNgaycong.TabIndex = 17;
            // 
            // txtGiotangca
            // 
            this.txtGiotangca.Location = new System.Drawing.Point(201, 421);
            this.txtGiotangca.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtGiotangca.Name = "txtGiotangca";
            this.txtGiotangca.Size = new System.Drawing.Size(197, 26);
            this.txtGiotangca.TabIndex = 18;
            // 
            // txtPhucap
            // 
            this.txtPhucap.Location = new System.Drawing.Point(201, 470);
            this.txtPhucap.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtPhucap.Name = "txtPhucap";
            this.txtPhucap.Size = new System.Drawing.Size(197, 26);
            this.txtPhucap.TabIndex = 19;
            // 
            // btnThem
            // 
            this.btnThem.Location = new System.Drawing.Point(15, 2);
            this.btnThem.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(89, 34);
            this.btnThem.TabIndex = 20;
            this.btnThem.Text = "Thêm";
            this.btnThem.UseVisualStyleBackColor = true;
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
            // 
            // btnXoa
            // 
            this.btnXoa.Location = new System.Drawing.Point(121, 2);
            this.btnXoa.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(89, 34);
            this.btnXoa.TabIndex = 21;
            this.btnXoa.Text = "Xóa ";
            this.btnXoa.UseVisualStyleBackColor = true;
            this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);
            // 
            // btnSua
            // 
            this.btnSua.Location = new System.Drawing.Point(228, 2);
            this.btnSua.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnSua.Name = "btnSua";
            this.btnSua.Size = new System.Drawing.Size(89, 34);
            this.btnSua.TabIndex = 22;
            this.btnSua.Text = "Sửa";
            this.btnSua.UseVisualStyleBackColor = true;
            this.btnSua.Click += new System.EventHandler(this.btnSua_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.cbbMaNhanVien);
            this.groupBox2.Controls.Add(this.dtpThangNam);
            this.groupBox2.Controls.Add(this.label11);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.txtHoten);
            this.groupBox2.Controls.Add(this.txtPhucap);
            this.groupBox2.Controls.Add(this.txtGiotangca);
            this.groupBox2.Controls.Add(this.txtNgaycong);
            this.groupBox2.Controls.Add(this.txtTongluong);
            this.groupBox2.Controls.Add(this.txtKhautru);
            this.groupBox2.Controls.Add(this.txtThuong);
            this.groupBox2.Controls.Add(this.txtBasicluong);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(607, 6);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox2.Size = new System.Drawing.Size(445, 532);
            this.groupBox2.TabIndex = 23;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Thông tin Lương nhân viên";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(59, 80);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(59, 20);
            this.label10.TabIndex = 21;
            this.label10.Text = "Họ tên";
            // 
            // txtHoten
            // 
            this.txtHoten.Location = new System.Drawing.Point(201, 78);
            this.txtHoten.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtHoten.Name = "txtHoten";
            this.txtHoten.Size = new System.Drawing.Size(197, 26);
            this.txtHoten.TabIndex = 20;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnSua);
            this.panel1.Controls.Add(this.btnXoa);
            this.panel1.Controls.Add(this.btnThem);
            this.panel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel1.Location = new System.Drawing.Point(657, 554);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(325, 42);
            this.panel1.TabIndex = 24;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(59, 30);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(108, 20);
            this.label11.TabIndex = 23;
            this.label11.Text = "Mã nhân viên";
            // 
            // dtpThangNam
            // 
            this.dtpThangNam.Location = new System.Drawing.Point(199, 127);
            this.dtpThangNam.Name = "dtpThangNam";
            this.dtpThangNam.Size = new System.Drawing.Size(200, 26);
            this.dtpThangNam.TabIndex = 24;
            // 
            // cbbMaNhanVien
            // 
            this.cbbMaNhanVien.FormattingEnabled = true;
            this.cbbMaNhanVien.Location = new System.Drawing.Point(201, 27);
            this.cbbMaNhanVien.Name = "cbbMaNhanVien";
            this.cbbMaNhanVien.Size = new System.Drawing.Size(197, 28);
            this.cbbMaNhanVien.TabIndex = 25;
            // 
            // ThemXoaSuaLuong
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(1140, 620);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "ThemXoaSuaLuong";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "QuanLyLuong";
            this.Load += new System.EventHandler(this.ThemXoaSuaLuong_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvLuong)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvLuong;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtBasicluong;
        private System.Windows.Forms.TextBox txtThuong;
        private System.Windows.Forms.TextBox txtKhautru;
        private System.Windows.Forms.TextBox txtTongluong;
        private System.Windows.Forms.TextBox txtNgaycong;
        private System.Windows.Forms.TextBox txtGiotangca;
        private System.Windows.Forms.TextBox txtPhucap;
        private System.Windows.Forms.Button btnThem;
        private System.Windows.Forms.Button btnXoa;
        private System.Windows.Forms.Button btnSua;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox txtTimkiem;
        private System.Windows.Forms.Button btnTimkiemnhanvien;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtHoten;
        private System.Windows.Forms.DateTimePicker dtpThangNam;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.ComboBox cbbMaNhanVien;
    }
}