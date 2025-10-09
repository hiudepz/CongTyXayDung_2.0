namespace GUI.User
{
    partial class Baocao
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
            this.btnThem = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cbbCongTrinh = new System.Windows.Forms.ComboBox();
            this.cbbLoaiBaoCao = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.crystalReportViewerAll = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnThem
            // 
            this.btnThem.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnThem.Location = new System.Drawing.Point(937, 22);
            this.btnThem.Margin = new System.Windows.Forms.Padding(2);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(56, 19);
            this.btnThem.TabIndex = 14;
            this.btnThem.Text = "Xuất";
            this.btnThem.UseVisualStyleBackColor = true;
            this.btnThem.Click += new System.EventHandler(this.btnXuat_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(5, 14);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(75, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Loại báo cáo :";
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.groupBox1.Controls.Add(this.cbbCongTrinh);
            this.groupBox1.Controls.Add(this.cbbLoaiBaoCao);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(497, 11);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox1.Size = new System.Drawing.Size(428, 40);
            this.groupBox1.TabIndex = 13;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Báo cáo";
            // 
            // cbbCongTrinh
            // 
            this.cbbCongTrinh.FormattingEnabled = true;
            this.cbbCongTrinh.Location = new System.Drawing.Point(299, 11);
            this.cbbCongTrinh.Margin = new System.Windows.Forms.Padding(2);
            this.cbbCongTrinh.Name = "cbbCongTrinh";
            this.cbbCongTrinh.Size = new System.Drawing.Size(92, 21);
            this.cbbCongTrinh.TabIndex = 6;
            this.cbbCongTrinh.SelectedIndexChanged += new System.EventHandler(this.comboBox2_SelectedIndexChanged);
            // 
            // cbbLoaiBaoCao
            // 
            this.cbbLoaiBaoCao.FormattingEnabled = true;
            this.cbbLoaiBaoCao.Location = new System.Drawing.Point(79, 11);
            this.cbbLoaiBaoCao.Margin = new System.Windows.Forms.Padding(2);
            this.cbbLoaiBaoCao.Name = "cbbLoaiBaoCao";
            this.cbbLoaiBaoCao.Size = new System.Drawing.Size(158, 21);
            this.cbbLoaiBaoCao.TabIndex = 5;
            this.cbbLoaiBaoCao.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(241, 14);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(61, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Công trình :";
            // 
            // crystalReportViewerAll
            // 
            this.crystalReportViewerAll.ActiveViewIndex = -1;
            this.crystalReportViewerAll.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.crystalReportViewerAll.Cursor = System.Windows.Forms.Cursors.Default;
            this.crystalReportViewerAll.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.crystalReportViewerAll.Location = new System.Drawing.Point(0, 245);
            this.crystalReportViewerAll.Margin = new System.Windows.Forms.Padding(2);
            this.crystalReportViewerAll.Name = "crystalReportViewerAll";
            this.crystalReportViewerAll.Size = new System.Drawing.Size(1412, 594);
            this.crystalReportViewerAll.TabIndex = 15;
            this.crystalReportViewerAll.ToolPanelWidth = 150;
            // 
            // Baocao
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(1412, 839);
            this.Controls.Add(this.crystalReportViewerAll);
            this.Controls.Add(this.btnThem);
            this.Controls.Add(this.groupBox1);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Baocao";
            this.Text = "BaoCao";
            this.Load += new System.EventHandler(this.BaoCao_User_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnThem;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox cbbLoaiBaoCao;
        private System.Windows.Forms.ComboBox cbbCongTrinh;
        private System.Windows.Forms.Label label2;
        private CrystalDecisions.Windows.Forms.CrystalReportViewer crystalReportViewerAll;
    }
}