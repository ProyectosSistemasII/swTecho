namespace TechoCeiva
{
    partial class frmPrestamoHerramientas
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
            this.crvReportePrestamo = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.SuspendLayout();
            // 
            // crvReportePrestamo
            // 
            this.crvReportePrestamo.ActiveViewIndex = -1;
            this.crvReportePrestamo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.crvReportePrestamo.CachedPageNumberPerDoc = 10;
            this.crvReportePrestamo.Cursor = System.Windows.Forms.Cursors.Default;
            this.crvReportePrestamo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.crvReportePrestamo.Location = new System.Drawing.Point(0, 0);
            this.crvReportePrestamo.Name = "crvReportePrestamo";
            this.crvReportePrestamo.Size = new System.Drawing.Size(284, 262);
            this.crvReportePrestamo.TabIndex = 0;
            this.crvReportePrestamo.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None;
            // 
            // frmPrestamoHerramientas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 262);
            this.Controls.Add(this.crvReportePrestamo);
            this.Name = "frmPrestamoHerramientas";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Prestámo de herramientas";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmPrestamoHerramientas_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private CrystalDecisions.Windows.Forms.CrystalReportViewer crvReportePrestamo;
    }
}