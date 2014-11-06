namespace TechoCeiva
{
    partial class frmReporteHerramientas
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
            this.crvReporteHerramientas = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.SuspendLayout();
            // 
            // crvReporteHerramientas
            // 
            this.crvReporteHerramientas.ActiveViewIndex = -1;
            this.crvReporteHerramientas.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.crvReporteHerramientas.CachedPageNumberPerDoc = 10;
            this.crvReporteHerramientas.Cursor = System.Windows.Forms.Cursors.Default;
            this.crvReporteHerramientas.Dock = System.Windows.Forms.DockStyle.Fill;
            this.crvReporteHerramientas.Location = new System.Drawing.Point(0, 0);
            this.crvReporteHerramientas.Name = "crvReporteHerramientas";
            this.crvReporteHerramientas.Size = new System.Drawing.Size(284, 262);
            this.crvReporteHerramientas.TabIndex = 0;
            this.crvReporteHerramientas.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None;
            // 
            // frmReporteHerramientas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 262);
            this.Controls.Add(this.crvReporteHerramientas);
            this.Name = "frmReporteHerramientas";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Reporte de herramientas";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmReporteHerramientas_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private CrystalDecisions.Windows.Forms.CrystalReportViewer crvReporteHerramientas;
    }
}