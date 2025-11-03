namespace GUI
{
    partial class quanlyduan
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.picHinhanh = new System.Windows.Forms.PictureBox();
            this.txtTenduan = new System.Windows.Forms.TextBox();
            this.txtTiendo = new System.Windows.Forms.TextBox();
            this.dtpNgaybatdau = new System.Windows.Forms.DateTimePicker();
            this.dtpNgayketthuc = new System.Windows.Forms.DateTimePicker();
            this.cbbKhachhang = new System.Windows.Forms.ComboBox();
            this.btnThemduan = new System.Windows.Forms.Button();
            this.btnXoaduan = new System.Windows.Forms.Button();
            this.btnSuaduan = new System.Windows.Forms.Button();
            this.dgvQuanlyduan = new System.Windows.Forms.DataGridView();
            this.btnPhancongnhansuchoduan = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cbbHopdong = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtTimkiem = new System.Windows.Forms.TextBox();
            this.btnTimkiem = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.picHinhanh)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvQuanlyduan)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(39, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Tên dự án";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(39, 53);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 16);
            this.label2.TabIndex = 0;
            this.label2.Text = "Tiến độ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(39, 152);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(88, 16);
            this.label3.TabIndex = 0;
            this.label3.Text = "Ngày bắt đầu";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(39, 185);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(88, 16);
            this.label4.TabIndex = 0;
            this.label4.Text = "Ngày kết thúc";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(39, 86);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(77, 16);
            this.label6.TabIndex = 0;
            this.label6.Text = "Khách hàng";
            // 
            // picHinhanh
            // 
            this.picHinhanh.Location = new System.Drawing.Point(481, 35);
            this.picHinhanh.Name = "picHinhanh";
            this.picHinhanh.Size = new System.Drawing.Size(146, 145);
            this.picHinhanh.TabIndex = 1;
            this.picHinhanh.TabStop = false;
            // 
            // txtTenduan
            // 
            this.txtTenduan.Location = new System.Drawing.Point(156, 17);
            this.txtTenduan.Name = "txtTenduan";
            this.txtTenduan.Size = new System.Drawing.Size(200, 22);
            this.txtTenduan.TabIndex = 2;
            // 
            // txtTiendo
            // 
            this.txtTiendo.Location = new System.Drawing.Point(156, 49);
            this.txtTiendo.Name = "txtTiendo";
            this.txtTiendo.Size = new System.Drawing.Size(200, 22);
            this.txtTiendo.TabIndex = 2;
            // 
            // dtpNgaybatdau
            // 
            this.dtpNgaybatdau.Location = new System.Drawing.Point(156, 149);
            this.dtpNgaybatdau.Name = "dtpNgaybatdau";
            this.dtpNgaybatdau.Size = new System.Drawing.Size(200, 22);
            this.dtpNgaybatdau.TabIndex = 3;
            // 
            // dtpNgayketthuc
            // 
            this.dtpNgayketthuc.Location = new System.Drawing.Point(156, 181);
            this.dtpNgayketthuc.Name = "dtpNgayketthuc";
            this.dtpNgayketthuc.Size = new System.Drawing.Size(200, 22);
            this.dtpNgayketthuc.TabIndex = 3;
            // 
            // cbbKhachhang
            // 
            this.cbbKhachhang.FormattingEnabled = true;
            this.cbbKhachhang.Location = new System.Drawing.Point(156, 81);
            this.cbbKhachhang.Name = "cbbKhachhang";
            this.cbbKhachhang.Size = new System.Drawing.Size(200, 24);
            this.cbbKhachhang.TabIndex = 4;
            // 
            // btnThemduan
            // 
            this.btnThemduan.Location = new System.Drawing.Point(147, 228);
            this.btnThemduan.Name = "btnThemduan";
            this.btnThemduan.Size = new System.Drawing.Size(75, 23);
            this.btnThemduan.TabIndex = 5;
            this.btnThemduan.Text = "Thêm";
            this.btnThemduan.UseVisualStyleBackColor = true;
            this.btnThemduan.Click += new System.EventHandler(this.btnThemduan_Click);
            // 
            // btnXoaduan
            // 
            this.btnXoaduan.Location = new System.Drawing.Point(228, 228);
            this.btnXoaduan.Name = "btnXoaduan";
            this.btnXoaduan.Size = new System.Drawing.Size(75, 23);
            this.btnXoaduan.TabIndex = 5;
            this.btnXoaduan.Text = "Xóa";
            this.btnXoaduan.UseVisualStyleBackColor = true;
            this.btnXoaduan.Click += new System.EventHandler(this.btnXoaduan_Click);
            // 
            // btnSuaduan
            // 
            this.btnSuaduan.Location = new System.Drawing.Point(319, 228);
            this.btnSuaduan.Name = "btnSuaduan";
            this.btnSuaduan.Size = new System.Drawing.Size(75, 23);
            this.btnSuaduan.TabIndex = 5;
            this.btnSuaduan.Text = "Sửa";
            this.btnSuaduan.UseVisualStyleBackColor = true;
            this.btnSuaduan.Click += new System.EventHandler(this.btnSuaduan_Click);
            // 
            // dgvQuanlyduan
            // 
            this.dgvQuanlyduan.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvQuanlyduan.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvQuanlyduan.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvQuanlyduan.Location = new System.Drawing.Point(0, 44);
            this.dgvQuanlyduan.Name = "dgvQuanlyduan";
            this.dgvQuanlyduan.RowHeadersWidth = 51;
            this.dgvQuanlyduan.Size = new System.Drawing.Size(985, 243);
            this.dgvQuanlyduan.TabIndex = 7;
            this.dgvQuanlyduan.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvQuanlyduan_CellClick);
            this.dgvQuanlyduan.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvQuanlyduan_CellContentClick);
            // 
            // btnPhancongnhansuchoduan
            // 
            this.btnPhancongnhansuchoduan.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPhancongnhansuchoduan.Location = new System.Drawing.Point(728, 92);
            this.btnPhancongnhansuchoduan.Name = "btnPhancongnhansuchoduan";
            this.btnPhancongnhansuchoduan.Size = new System.Drawing.Size(138, 64);
            this.btnPhancongnhansuchoduan.TabIndex = 8;
            this.btnPhancongnhansuchoduan.Text = "Phân công nhân sự";
            this.btnPhancongnhansuchoduan.UseVisualStyleBackColor = true;
            this.btnPhancongnhansuchoduan.Click += new System.EventHandler(this.btnPhancongnhansuchoduan_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.cbbHopdong);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.btnPhancongnhansuchoduan);
            this.groupBox1.Controls.Add(this.btnSuaduan);
            this.groupBox1.Controls.Add(this.btnXoaduan);
            this.groupBox1.Controls.Add(this.btnThemduan);
            this.groupBox1.Controls.Add(this.cbbKhachhang);
            this.groupBox1.Controls.Add(this.dtpNgayketthuc);
            this.groupBox1.Controls.Add(this.dtpNgaybatdau);
            this.groupBox1.Controls.Add(this.txtTiendo);
            this.groupBox1.Controls.Add(this.txtTenduan);
            this.groupBox1.Controls.Add(this.picHinhanh);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(28, 33);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox1.Size = new System.Drawing.Size(917, 260);
            this.groupBox1.TabIndex = 9;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Điền thông tin ";
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // cbbHopdong
            // 
            this.cbbHopdong.FormattingEnabled = true;
            this.cbbHopdong.Location = new System.Drawing.Point(156, 115);
            this.cbbHopdong.Name = "cbbHopdong";
            this.cbbHopdong.Size = new System.Drawing.Size(200, 24);
            this.cbbHopdong.TabIndex = 10;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(39, 119);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(67, 16);
            this.label5.TabIndex = 9;
            this.label5.Text = "Hợp đồng";
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.txtTimkiem);
            this.groupBox2.Controls.Add(this.btnTimkiem);
            this.groupBox2.Controls.Add(this.dgvQuanlyduan);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(0, 298);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(991, 293);
            this.groupBox2.TabIndex = 10;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Dự án";
            this.groupBox2.Enter += new System.EventHandler(this.groupBox2_Enter);
            // 
            // txtTimkiem
            // 
            this.txtTimkiem.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTimkiem.Location = new System.Drawing.Point(760, 16);
            this.txtTimkiem.Name = "txtTimkiem";
            this.txtTimkiem.Size = new System.Drawing.Size(138, 22);
            this.txtTimkiem.TabIndex = 9;
            this.txtTimkiem.TextChanged += new System.EventHandler(this.txtTimkiem_TextChanged);
            // 
            // btnTimkiem
            // 
            this.btnTimkiem.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnTimkiem.Location = new System.Drawing.Point(904, 18);
            this.btnTimkiem.Name = "btnTimkiem";
            this.btnTimkiem.Size = new System.Drawing.Size(75, 23);
            this.btnTimkiem.TabIndex = 9;
            this.btnTimkiem.Text = "Tìm kiếm ";
            this.btnTimkiem.UseVisualStyleBackColor = true;
            this.btnTimkiem.Click += new System.EventHandler(this.btnTimkiem_Click);
            // 
            // quanlyduan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(994, 592);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "quanlyduan";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Quản lý dự án";
            this.Load += new System.EventHandler(this.quanlyduan_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picHinhanh)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvQuanlyduan)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.PictureBox picHinhanh;
        private System.Windows.Forms.TextBox txtTenduan;
        private System.Windows.Forms.TextBox txtTiendo;
        private System.Windows.Forms.DateTimePicker dtpNgaybatdau;
        private System.Windows.Forms.DateTimePicker dtpNgayketthuc;
        private System.Windows.Forms.ComboBox cbbKhachhang;
        private System.Windows.Forms.Button btnThemduan;
        private System.Windows.Forms.Button btnXoaduan;
        private System.Windows.Forms.Button btnSuaduan;
        private System.Windows.Forms.DataGridView dgvQuanlyduan;
        private System.Windows.Forms.Button btnPhancongnhansuchoduan;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnTimkiem;
        private System.Windows.Forms.TextBox txtTimkiem;
        private System.Windows.Forms.ComboBox cbbHopdong;
        private System.Windows.Forms.Label label5;
    }
}