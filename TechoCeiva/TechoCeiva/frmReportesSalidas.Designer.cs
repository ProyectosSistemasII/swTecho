namespace TechoCeiva
{
    partial class frmReportesSalidas
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
            this.crvReportesSalidas = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.SuspendLayout();
            // 
            // crvReportesSalidas
            // 
            this.crvReportesSalidas.ActiveViewIndex = -1;
            this.crvReportesSalidas.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.crvReportesSalidas.CachedPageNumberPerDoc = 10;
            this.crvReportesSalidas.Cursor = System.Windows.Forms.Cursors.Default;
            this.crvReportesSalidas.Dock = System.Windows.Forms.DockStyle.Fill;
            this.crvReportesSalidas.Location = new System.Drawing.Point(0, 0);
            this.crvReportesSalidas.Name = "crvReportesSalidas";
            this.crvReportesSalidas.Size = new System.Drawing.Size(491, 367);
            this.crvReportesSalidas.TabIndex = 0;
            this.crvReportesSalidas.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None;
            // 
            // frmReportesSalidas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(491, 367);
            this.Controls.Add(this.crvReportesSalidas);
            this.Name = "frmReportesSalidas";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Reportes de salidas";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmReportesSalidas_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private CrystalDecisions.Windows.Forms.CrystalReportViewer crvReportesSalidas;
    }
}