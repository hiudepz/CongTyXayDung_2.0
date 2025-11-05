namespace GUI.Report.form
{
    partial class frmBaocaonhansutrongduan
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
            this.frmBaoCaoNhanSu = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.txtTimKiem = new System.Windows.Forms.TextBox();
            this.btnTimKiem = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // frmBaoCaoNhanSu
            // 
            this.frmBaoCaoNhanSu.ActiveViewIndex = -1;
            this.frmBaoCaoNhanSu.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.frmBaoCaoNhanSu.Cursor = System.Windows.Forms.Cursors.Default;
            this.frmBaoCaoNhanSu.Dock = System.Windows.Forms.DockStyle.Fill;
            this.frmBaoCaoNhanSu.Location = new System.Drawing.Point(0, 0);
            this.frmBaoCaoNhanSu.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.frmBaoCaoNhanSu.Name = "frmBaoCaoNhanSu";
            this.frmBaoCaoNhanSu.Size = new System.Drawing.Size(1067, 554);
            this.frmBaoCaoNhanSu.TabIndex = 0;
            this.frmBaoCaoNhanSu.ToolPanelWidth = 267;
            this.frmBaoCaoNhanSu.Load += new System.EventHandler(this.frmBaoCaoNhanSu_Load);
            // 
            // txtTimKiem
            // 
            this.txtTimKiem.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTimKiem.Location = new System.Drawing.Point(665, 7);
            this.txtTimKiem.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtTimKiem.Name = "txtTimKiem";
            this.txtTimKiem.Size = new System.Drawing.Size(132, 22);
            this.txtTimKiem.TabIndex = 1;
            // 
            // btnTimKiem
            // 
            this.btnTimKiem.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnTimKiem.Location = new System.Drawing.Point(805, 4);
            this.btnTimKiem.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnTimKiem.Name = "btnTimKiem";
            this.btnTimKiem.Size = new System.Drawing.Size(100, 28);
            this.btnTimKiem.TabIndex = 2;
            this.btnTimKiem.Text = "Search";
            this.btnTimKiem.UseVisualStyleBackColor = true;
            this.btnTimKiem.Click += new System.EventHandler(this.btnTimKiem_Click);
            // 
            // frmBaocaonhansutrongduan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1067, 554);
            this.Controls.Add(this.btnTimKiem);
            this.Controls.Add(this.txtTimKiem);
            this.Controls.Add(this.frmBaoCaoNhanSu);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "frmBaocaonhansutrongduan";
            this.Text = "frmBaocaonhansutrongduan";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private CrystalDecisions.Windows.Forms.CrystalReportViewer frmBaoCaoNhanSu;
        private System.Windows.Forms.TextBox txtTimKiem;
        private System.Windows.Forms.Button btnTimKiem;
    }
}