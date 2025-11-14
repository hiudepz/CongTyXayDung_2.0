namespace GUI.Report.form
{
    partial class frmBaoCaoHopDong
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
            this.crvHopDong = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.cbbHopDong = new System.Windows.Forms.ComboBox();
            this.btnExportPdf = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // crvHopDong
            // 
            this.crvHopDong.ActiveViewIndex = -1;
            this.crvHopDong.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.crvHopDong.Cursor = System.Windows.Forms.Cursors.Default;
            this.crvHopDong.Dock = System.Windows.Forms.DockStyle.Fill;
            this.crvHopDong.Location = new System.Drawing.Point(0, 0);
            this.crvHopDong.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.crvHopDong.Name = "crvHopDong";
            this.crvHopDong.Size = new System.Drawing.Size(1067, 554);
            this.crvHopDong.TabIndex = 0;
            this.crvHopDong.ToolPanelWidth = 267;
            this.crvHopDong.Load += new System.EventHandler(this.crvHopDong_Load);
            // 
            // cbbHopDong
            // 
            this.cbbHopDong.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cbbHopDong.FormattingEnabled = true;
            this.cbbHopDong.Location = new System.Drawing.Point(517, 12);
            this.cbbHopDong.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cbbHopDong.Name = "cbbHopDong";
            this.cbbHopDong.Size = new System.Drawing.Size(339, 24);
            this.cbbHopDong.TabIndex = 1;
            this.cbbHopDong.SelectedIndexChanged += new System.EventHandler(this.cbbHopDong_SelectedIndexChanged);
            // 
            // btnExportPdf
            // 
            this.btnExportPdf.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExportPdf.Location = new System.Drawing.Point(863, 13);
            this.btnExportPdf.Name = "btnExportPdf";
            this.btnExportPdf.Size = new System.Drawing.Size(75, 23);
            this.btnExportPdf.TabIndex = 2;
            this.btnExportPdf.Text = "Export";
            this.btnExportPdf.UseVisualStyleBackColor = true;
            this.btnExportPdf.Click += new System.EventHandler(this.btnExportPdf_Click);
            // 
            // frmBaoCaoHopDong
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1067, 554);
            this.Controls.Add(this.btnExportPdf);
            this.Controls.Add(this.cbbHopDong);
            this.Controls.Add(this.crvHopDong);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "frmBaoCaoHopDong";
            this.Text = "frmBaoCaoHopDong";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.ResumeLayout(false);

        }

        #endregion

        private CrystalDecisions.Windows.Forms.CrystalReportViewer crvHopDong;
        private System.Windows.Forms.ComboBox cbbHopDong;
        private System.Windows.Forms.Button btnExportPdf;
    }
}