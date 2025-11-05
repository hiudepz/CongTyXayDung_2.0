namespace GUI.NhanVienKho
{
    partial class QuanLyKho
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
            this.panel2 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.cbXuat = new System.Windows.Forms.CheckBox();
            this.cbNhap = new System.Windows.Forms.CheckBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.dgvKho = new System.Windows.Forms.DataGridView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.cbbDuAn = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.numSoLuong = new System.Windows.Forms.NumericUpDown();
            this.cbbLoaiVatTu = new System.Windows.Forms.ComboBox();
            this.dtpNgayGiaoDich = new System.Windows.Forms.DateTimePicker();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvKho)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numSoLuong)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.cbXuat);
            this.panel2.Controls.Add(this.cbNhap);
            this.panel2.Controls.Add(this.textBox1);
            this.panel2.Controls.Add(this.dgvKho);
            this.panel2.Location = new System.Drawing.Point(10, 19);
            this.panel2.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1167, 829);
            this.panel2.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(908, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(82, 22);
            this.label2.TabIndex = 28;
            this.label2.Text = "Tìm kiếm";
            // 
            // cbXuat
            // 
            this.cbXuat.AutoSize = true;
            this.cbXuat.Location = new System.Drawing.Point(166, 19);
            this.cbXuat.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.cbXuat.Name = "cbXuat";
            this.cbXuat.Size = new System.Drawing.Size(69, 26);
            this.cbXuat.TabIndex = 27;
            this.cbXuat.Text = "Xuất";
            this.cbXuat.UseVisualStyleBackColor = true;
            this.cbXuat.CheckedChanged += new System.EventHandler(this.cbXuat_CheckedChanged);
            // 
            // cbNhap
            // 
            this.cbNhap.AutoSize = true;
            this.cbNhap.Location = new System.Drawing.Point(24, 19);
            this.cbNhap.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.cbNhap.Name = "cbNhap";
            this.cbNhap.Size = new System.Drawing.Size(75, 26);
            this.cbNhap.TabIndex = 26;
            this.cbNhap.Text = "Nhập";
            this.cbNhap.UseVisualStyleBackColor = true;
            this.cbNhap.CheckedChanged += new System.EventHandler(this.cbNhap_CheckedChanged);
            // 
            // textBox1
            // 
            this.textBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox1.Location = new System.Drawing.Point(998, 12);
            this.textBox1.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(164, 28);
            this.textBox1.TabIndex = 25;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // dgvKho
            // 
            this.dgvKho.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvKho.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvKho.Location = new System.Drawing.Point(5, 55);
            this.dgvKho.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.dgvKho.Name = "dgvKho";
            this.dgvKho.RowHeadersWidth = 51;
            this.dgvKho.Size = new System.Drawing.Size(1157, 768);
            this.dgvKho.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.cbbDuAn);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.numSoLuong);
            this.panel1.Controls.Add(this.cbbLoaiVatTu);
            this.panel1.Controls.Add(this.dtpNgayGiaoDich);
            this.panel1.Location = new System.Drawing.Point(14, 20);
            this.panel1.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(528, 828);
            this.panel1.TabIndex = 3;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(373, 319);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(126, 42);
            this.button1.TabIndex = 13;
            this.button1.Text = "Xuất hàng";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // cbbDuAn
            // 
            this.cbbDuAn.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.cbbDuAn.FormattingEnabled = true;
            this.cbbDuAn.Location = new System.Drawing.Point(229, 241);
            this.cbbDuAn.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.cbbDuAn.Name = "cbbDuAn";
            this.cbbDuAn.Size = new System.Drawing.Size(270, 30);
            this.cbbDuAn.TabIndex = 12;
            // 
            // label6
            // 
            this.label6.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(23, 244);
            this.label6.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(63, 22);
            this.label6.TabIndex = 10;
            this.label6.Text = "Dự án ";
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(23, 164);
            this.label4.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(129, 22);
            this.label4.TabIndex = 7;
            this.label4.Text = "Ngày giao dịch";
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(23, 90);
            this.label3.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(81, 22);
            this.label3.TabIndex = 6;
            this.label3.Text = "Số lượng";
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(23, 31);
            this.label1.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(93, 22);
            this.label1.TabIndex = 4;
            this.label1.Text = "Loại vật tư";
            // 
            // numSoLuong
            // 
            this.numSoLuong.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.numSoLuong.Location = new System.Drawing.Point(229, 88);
            this.numSoLuong.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.numSoLuong.Name = "numSoLuong";
            this.numSoLuong.Size = new System.Drawing.Size(270, 28);
            this.numSoLuong.TabIndex = 3;
            // 
            // cbbLoaiVatTu
            // 
            this.cbbLoaiVatTu.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.cbbLoaiVatTu.FormattingEnabled = true;
            this.cbbLoaiVatTu.Location = new System.Drawing.Point(229, 28);
            this.cbbLoaiVatTu.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.cbbLoaiVatTu.Name = "cbbLoaiVatTu";
            this.cbbLoaiVatTu.Size = new System.Drawing.Size(270, 30);
            this.cbbLoaiVatTu.TabIndex = 0;
            // 
            // dtpNgayGiaoDich
            // 
            this.dtpNgayGiaoDich.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.dtpNgayGiaoDich.Location = new System.Drawing.Point(229, 158);
            this.dtpNgayGiaoDich.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.dtpNgayGiaoDich.Name = "dtpNgayGiaoDich";
            this.dtpNgayGiaoDich.Size = new System.Drawing.Size(270, 28);
            this.dtpNgayGiaoDich.TabIndex = 2;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.panel1);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Left;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.groupBox1.Size = new System.Drawing.Size(558, 870);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Thông tin hàng hóa";
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.panel2);
            this.groupBox2.Location = new System.Drawing.Point(568, 0);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.groupBox2.Size = new System.Drawing.Size(1187, 860);
            this.groupBox2.TabIndex = 8;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Danh sách nhập xuất";
            this.groupBox2.Enter += new System.EventHandler(this.groupBox2_Enter);
            // 
            // QuanLyKho
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 22F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(1769, 870);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.Name = "QuanLyKho";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "QuanLyKho";
            this.Load += new System.EventHandler(this.QuanLyKho_Load);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvKho)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numSoLuong)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.DataGridView dgvKho;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown numSoLuong;
        private System.Windows.Forms.ComboBox cbbLoaiVatTu;
        private System.Windows.Forms.DateTimePicker dtpNgayGiaoDich;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.CheckBox cbNhap;
        private System.Windows.Forms.CheckBox cbXuat;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cbbDuAn;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label2;
    }
}