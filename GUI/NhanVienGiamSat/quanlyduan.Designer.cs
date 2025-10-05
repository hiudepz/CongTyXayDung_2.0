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
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.txtTenduan = new System.Windows.Forms.TextBox();
            this.txtTiendo = new System.Windows.Forms.TextBox();
            this.dtpNgaybatdau = new System.Windows.Forms.DateTimePicker();
            this.dtpNgayketthuc = new System.Windows.Forms.DateTimePicker();
            this.cbbKhachhang = new System.Windows.Forms.ComboBox();
            this.btnThemduan = new System.Windows.Forms.Button();
            this.btnXoaduan = new System.Windows.Forms.Button();
            this.btnSuaduan = new System.Windows.Forms.Button();
            this.btnChonanhduan = new System.Windows.Forms.Button();
            this.dgvQuanlyduan = new System.Windows.Forms.DataGridView();
            this.btnPhancongnhansuchoduan = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvQuanlyduan)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(620, 289);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Tên dự án";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(620, 322);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Tiến độ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(620, 406);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(72, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "Ngày bắt đầu";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(620, 439);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(74, 13);
            this.label4.TabIndex = 0;
            this.label4.Text = "Ngày kết thúc";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(620, 360);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(65, 13);
            this.label6.TabIndex = 0;
            this.label6.Text = "Khách hàng";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(1105, 289);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(135, 135);
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // txtTenduan
            // 
            this.txtTenduan.Location = new System.Drawing.Point(738, 286);
            this.txtTenduan.Name = "txtTenduan";
            this.txtTenduan.Size = new System.Drawing.Size(100, 20);
            this.txtTenduan.TabIndex = 2;
            // 
            // txtTiendo
            // 
            this.txtTiendo.Location = new System.Drawing.Point(739, 312);
            this.txtTiendo.Name = "txtTiendo";
            this.txtTiendo.Size = new System.Drawing.Size(100, 20);
            this.txtTiendo.TabIndex = 2;
            // 
            // dtpNgaybatdau
            // 
            this.dtpNgaybatdau.Location = new System.Drawing.Point(739, 406);
            this.dtpNgaybatdau.Name = "dtpNgaybatdau";
            this.dtpNgaybatdau.Size = new System.Drawing.Size(200, 20);
            this.dtpNgaybatdau.TabIndex = 3;
            // 
            // dtpNgayketthuc
            // 
            this.dtpNgayketthuc.Location = new System.Drawing.Point(739, 432);
            this.dtpNgayketthuc.Name = "dtpNgayketthuc";
            this.dtpNgayketthuc.Size = new System.Drawing.Size(200, 20);
            this.dtpNgayketthuc.TabIndex = 3;
            // 
            // cbbKhachhang
            // 
            this.cbbKhachhang.FormattingEnabled = true;
            this.cbbKhachhang.Location = new System.Drawing.Point(738, 357);
            this.cbbKhachhang.Name = "cbbKhachhang";
            this.cbbKhachhang.Size = new System.Drawing.Size(121, 21);
            this.cbbKhachhang.TabIndex = 4;
            // 
            // btnThemduan
            // 
            this.btnThemduan.Location = new System.Drawing.Point(636, 534);
            this.btnThemduan.Name = "btnThemduan";
            this.btnThemduan.Size = new System.Drawing.Size(75, 23);
            this.btnThemduan.TabIndex = 5;
            this.btnThemduan.Text = "Thêm";
            this.btnThemduan.UseVisualStyleBackColor = true;
            // 
            // btnXoaduan
            // 
            this.btnXoaduan.Location = new System.Drawing.Point(803, 534);
            this.btnXoaduan.Name = "btnXoaduan";
            this.btnXoaduan.Size = new System.Drawing.Size(75, 23);
            this.btnXoaduan.TabIndex = 5;
            this.btnXoaduan.Text = "Xóa";
            this.btnXoaduan.UseVisualStyleBackColor = true;
            // 
            // btnSuaduan
            // 
            this.btnSuaduan.Location = new System.Drawing.Point(964, 534);
            this.btnSuaduan.Name = "btnSuaduan";
            this.btnSuaduan.Size = new System.Drawing.Size(75, 23);
            this.btnSuaduan.TabIndex = 5;
            this.btnSuaduan.Text = "Sửa";
            this.btnSuaduan.UseVisualStyleBackColor = true;
            // 
            // btnChonanhduan
            // 
            this.btnChonanhduan.Location = new System.Drawing.Point(1255, 401);
            this.btnChonanhduan.Name = "btnChonanhduan";
            this.btnChonanhduan.Size = new System.Drawing.Size(75, 23);
            this.btnChonanhduan.TabIndex = 6;
            this.btnChonanhduan.Text = "Chọn ảnh";
            this.btnChonanhduan.UseVisualStyleBackColor = true;
            // 
            // dgvQuanlyduan
            // 
            this.dgvQuanlyduan.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvQuanlyduan.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvQuanlyduan.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dgvQuanlyduan.Location = new System.Drawing.Point(0, 576);
            this.dgvQuanlyduan.Name = "dgvQuanlyduan";
            this.dgvQuanlyduan.Size = new System.Drawing.Size(1443, 263);
            this.dgvQuanlyduan.TabIndex = 7;
            // 
            // btnPhancongnhansuchoduan
            // 
            this.btnPhancongnhansuchoduan.Location = new System.Drawing.Point(1092, 534);
            this.btnPhancongnhansuchoduan.Name = "btnPhancongnhansuchoduan";
            this.btnPhancongnhansuchoduan.Size = new System.Drawing.Size(129, 23);
            this.btnPhancongnhansuchoduan.TabIndex = 8;
            this.btnPhancongnhansuchoduan.Text = "Phân công nhân sự";
            this.btnPhancongnhansuchoduan.UseVisualStyleBackColor = true;
            this.btnPhancongnhansuchoduan.Click += new System.EventHandler(this.btnPhancongnhansuchoduan_Click);
            // 
            // quanlyduan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1443, 839);
            this.Controls.Add(this.btnPhancongnhansuchoduan);
            this.Controls.Add(this.dgvQuanlyduan);
            this.Controls.Add(this.btnChonanhduan);
            this.Controls.Add(this.btnSuaduan);
            this.Controls.Add(this.btnXoaduan);
            this.Controls.Add(this.btnThemduan);
            this.Controls.Add(this.cbbKhachhang);
            this.Controls.Add(this.dtpNgayketthuc);
            this.Controls.Add(this.dtpNgaybatdau);
            this.Controls.Add(this.txtTiendo);
            this.Controls.Add(this.txtTenduan);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "quanlyduan";
            this.Text = "Quản lý dự án";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.quanlyduan_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvQuanlyduan)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.TextBox txtTenduan;
        private System.Windows.Forms.TextBox txtTiendo;
        private System.Windows.Forms.DateTimePicker dtpNgaybatdau;
        private System.Windows.Forms.DateTimePicker dtpNgayketthuc;
        private System.Windows.Forms.ComboBox cbbKhachhang;
        private System.Windows.Forms.Button btnThemduan;
        private System.Windows.Forms.Button btnXoaduan;
        private System.Windows.Forms.Button btnSuaduan;
        private System.Windows.Forms.Button btnChonanhduan;
        private System.Windows.Forms.DataGridView dgvQuanlyduan;
        private System.Windows.Forms.Button btnPhancongnhansuchoduan;
    }
}