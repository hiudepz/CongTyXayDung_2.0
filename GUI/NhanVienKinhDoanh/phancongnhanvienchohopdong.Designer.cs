namespace GUI
{
    partial class phancongnhanvienchohopdong
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
            this.btnThemnhanvienchohopdong = new System.Windows.Forms.Button();
            this.btnXoanhanvienkhoihopdong = new System.Windows.Forms.Button();
            this.btnSuanhanvienchohopdong = new System.Windows.Forms.Button();
            this.cbbTenhopdong = new System.Windows.Forms.ComboBox();
            this.cbbTennhanvien = new System.Windows.Forms.ComboBox();
            this.dgvPhancongnhanvienchohopdong = new System.Windows.Forms.DataGridView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtTimKiem = new System.Windows.Forms.TextBox();
            this.btnTimKiem = new System.Windows.Forms.Button();
            this.txtVaitro = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPhancongnhanvienchohopdong)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(39, 32);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Hợp đồng";
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(39, 91);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 16);
            this.label2.TabIndex = 0;
            this.label2.Text = "Nhân viên";
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(39, 150);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(45, 16);
            this.label3.TabIndex = 0;
            this.label3.Text = "Vai trò";
            // 
            // btnThemnhanvienchohopdong
            // 
            this.btnThemnhanvienchohopdong.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnThemnhanvienchohopdong.Location = new System.Drawing.Point(31, 214);
            this.btnThemnhanvienchohopdong.Margin = new System.Windows.Forms.Padding(4);
            this.btnThemnhanvienchohopdong.Name = "btnThemnhanvienchohopdong";
            this.btnThemnhanvienchohopdong.Size = new System.Drawing.Size(100, 28);
            this.btnThemnhanvienchohopdong.TabIndex = 1;
            this.btnThemnhanvienchohopdong.Text = "Thêm";
            this.btnThemnhanvienchohopdong.UseVisualStyleBackColor = true;
            this.btnThemnhanvienchohopdong.Click += new System.EventHandler(this.btnThemnhanvienchohopdong_Click);
            // 
            // btnXoanhanvienkhoihopdong
            // 
            this.btnXoanhanvienkhoihopdong.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnXoanhanvienkhoihopdong.Location = new System.Drawing.Point(163, 214);
            this.btnXoanhanvienkhoihopdong.Margin = new System.Windows.Forms.Padding(4);
            this.btnXoanhanvienkhoihopdong.Name = "btnXoanhanvienkhoihopdong";
            this.btnXoanhanvienkhoihopdong.Size = new System.Drawing.Size(100, 28);
            this.btnXoanhanvienkhoihopdong.TabIndex = 2;
            this.btnXoanhanvienkhoihopdong.Text = "Xóa";
            this.btnXoanhanvienkhoihopdong.UseVisualStyleBackColor = true;
            this.btnXoanhanvienkhoihopdong.Click += new System.EventHandler(this.btnXoanhanvienkhoihopdong_Click);
            // 
            // btnSuanhanvienchohopdong
            // 
            this.btnSuanhanvienchohopdong.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnSuanhanvienchohopdong.Location = new System.Drawing.Point(297, 214);
            this.btnSuanhanvienchohopdong.Margin = new System.Windows.Forms.Padding(4);
            this.btnSuanhanvienchohopdong.Name = "btnSuanhanvienchohopdong";
            this.btnSuanhanvienchohopdong.Size = new System.Drawing.Size(100, 28);
            this.btnSuanhanvienchohopdong.TabIndex = 3;
            this.btnSuanhanvienchohopdong.Text = "Sửa";
            this.btnSuanhanvienchohopdong.UseVisualStyleBackColor = true;
            this.btnSuanhanvienchohopdong.Click += new System.EventHandler(this.btnSuanhanvienchohopdong_Click);
            // 
            // cbbTenhopdong
            // 
            this.cbbTenhopdong.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.cbbTenhopdong.FormattingEnabled = true;
            this.cbbTenhopdong.Location = new System.Drawing.Point(177, 32);
            this.cbbTenhopdong.Margin = new System.Windows.Forms.Padding(4);
            this.cbbTenhopdong.Name = "cbbTenhopdong";
            this.cbbTenhopdong.Size = new System.Drawing.Size(195, 24);
            this.cbbTenhopdong.TabIndex = 4;
            // 
            // cbbTennhanvien
            // 
            this.cbbTennhanvien.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.cbbTennhanvien.FormattingEnabled = true;
            this.cbbTennhanvien.Location = new System.Drawing.Point(177, 87);
            this.cbbTennhanvien.Margin = new System.Windows.Forms.Padding(4);
            this.cbbTennhanvien.Name = "cbbTennhanvien";
            this.cbbTennhanvien.Size = new System.Drawing.Size(195, 24);
            this.cbbTennhanvien.TabIndex = 4;
            // 
            // dgvPhancongnhanvienchohopdong
            // 
            this.dgvPhancongnhanvienchohopdong.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvPhancongnhanvienchohopdong.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvPhancongnhanvienchohopdong.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPhancongnhanvienchohopdong.Location = new System.Drawing.Point(0, 303);
            this.dgvPhancongnhanvienchohopdong.Margin = new System.Windows.Forms.Padding(4);
            this.dgvPhancongnhanvienchohopdong.Name = "dgvPhancongnhanvienchohopdong";
            this.dgvPhancongnhanvienchohopdong.RowHeadersWidth = 51;
            this.dgvPhancongnhanvienchohopdong.Size = new System.Drawing.Size(1067, 251);
            this.dgvPhancongnhanvienchohopdong.TabIndex = 6;
            this.dgvPhancongnhanvienchohopdong.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvPhancongnhanvienchohopdong_CellClick);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.groupBox1.Controls.Add(this.txtVaitro);
            this.groupBox1.Controls.Add(this.cbbTennhanvien);
            this.groupBox1.Controls.Add(this.cbbTenhopdong);
            this.groupBox1.Controls.Add(this.btnSuanhanvienchohopdong);
            this.groupBox1.Controls.Add(this.btnXoanhanvienkhoihopdong);
            this.groupBox1.Controls.Add(this.btnThemnhanvienchohopdong);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(268, 32);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox1.Size = new System.Drawing.Size(545, 263);
            this.groupBox1.TabIndex = 9;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Lưu thông tin hợp đồng";
            // 
            // txtTimKiem
            // 
            this.txtTimKiem.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTimKiem.Location = new System.Drawing.Point(814, 261);
            this.txtTimKiem.Margin = new System.Windows.Forms.Padding(4);
            this.txtTimKiem.Name = "txtTimKiem";
            this.txtTimKiem.Size = new System.Drawing.Size(132, 22);
            this.txtTimKiem.TabIndex = 10;
            this.txtTimKiem.TextChanged += new System.EventHandler(this.txtTimKiem_TextChanged);
            // 
            // btnTimKiem
            // 
            this.btnTimKiem.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnTimKiem.Location = new System.Drawing.Point(954, 258);
            this.btnTimKiem.Margin = new System.Windows.Forms.Padding(4);
            this.btnTimKiem.Name = "btnTimKiem";
            this.btnTimKiem.Size = new System.Drawing.Size(100, 28);
            this.btnTimKiem.TabIndex = 9;
            this.btnTimKiem.Text = "Tìm kiếm";
            this.btnTimKiem.UseVisualStyleBackColor = true;
            // 
            // txtVaitro
            // 
            this.txtVaitro.Location = new System.Drawing.Point(177, 147);
            this.txtVaitro.Margin = new System.Windows.Forms.Padding(4);
            this.txtVaitro.Name = "txtVaitro";
            this.txtVaitro.Size = new System.Drawing.Size(195, 22);
            this.txtVaitro.TabIndex = 11;
            // 
            // phancongnhanvienchohopdong
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(1067, 554);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnTimKiem);
            this.Controls.Add(this.txtTimKiem);
            this.Controls.Add(this.dgvPhancongnhanvienchohopdong);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "phancongnhanvienchohopdong";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Phân công nhân viên cho hợp đồng";
            this.Load += new System.EventHandler(this.phancongnhanvienchohopdong_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPhancongnhanvienchohopdong)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnThemnhanvienchohopdong;
        private System.Windows.Forms.Button btnXoanhanvienkhoihopdong;
        private System.Windows.Forms.Button btnSuanhanvienchohopdong;
        private System.Windows.Forms.ComboBox cbbTenhopdong;
        private System.Windows.Forms.ComboBox cbbTennhanvien;
        private System.Windows.Forms.DataGridView dgvPhancongnhanvienchohopdong;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnTimKiem;
        private System.Windows.Forms.TextBox txtTimKiem;
        private System.Windows.Forms.TextBox txtVaitro;
    }
}