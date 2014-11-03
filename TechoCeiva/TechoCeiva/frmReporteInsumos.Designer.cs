namespace TechoCeiva
{
    partial class frmReporteInsumos
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
            this.crvReporteInsumos = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.crvReporteInsumo = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.lblAnio = new System.Windows.Forms.Label();
            this.lblRango = new System.Windows.Forms.Label();
            this.cmbRango = new System.Windows.Forms.ComboBox();
            this.btnGenerar = new System.Windows.Forms.Button();
            this.txtAnio = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtAni = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // crvReporteInsumos
            // 
            this.crvReporteInsumos.ActiveViewIndex = -1;
            this.crvReporteInsumos.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.crvReporteInsumos.CachedPageNumberPerDoc = 10;
            this.crvReporteInsumos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.crvReporteInsumos.Location = new System.Drawing.Point(0, 0);
            this.crvReporteInsumos.Name = "crvReporteInsumos";
            this.crvReporteInsumos.Size = new System.Drawing.Size(650, 415);
            this.crvReporteInsumos.TabIndex = 0;
            // 
            // crvReporteInsumo
            // 
            this.crvReporteInsumo.ActiveViewIndex = -1;
            this.crvReporteInsumo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.crvReporteInsumo.CachedPageNumberPerDoc = 10;
            this.crvReporteInsumo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.crvReporteInsumo.Location = new System.Drawing.Point(0, 0);
            this.crvReporteInsumo.Name = "crvReporteInsumo";
            this.crvReporteInsumo.Size = new System.Drawing.Size(284, 262);
            this.crvReporteInsumo.TabIndex = 0;
            // 
            // lblAnio
            // 
            this.lblAnio.AutoSize = true;
            this.lblAnio.BackColor = System.Drawing.Color.White;
            this.lblAnio.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAnio.Location = new System.Drawing.Point(11, 121);
            this.lblAnio.Name = "lblAnio";
            this.lblAnio.Size = new System.Drawing.Size(85, 13);
            this.lblAnio.TabIndex = 9;
            this.lblAnio.Text = "Año caducidad";
            // 
            // lblRango
            // 
            this.lblRango.AutoSize = true;
            this.lblRango.BackColor = System.Drawing.Color.White;
            this.lblRango.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRango.Location = new System.Drawing.Point(12, 53);
            this.lblRango.Name = "lblRango";
            this.lblRango.Size = new System.Drawing.Size(95, 13);
            this.lblRango.TabIndex = 8;
            this.lblRango.Text = "Seleccione rango";
            // 
            // cmbRango
            // 
            this.cmbRango.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbRango.FormattingEnabled = true;
            this.cmbRango.Location = new System.Drawing.Point(14, 81);
            this.cmbRango.Name = "cmbRango";
            this.cmbRango.Size = new System.Drawing.Size(178, 21);
            this.cmbRango.TabIndex = 7;
            // 
            // btnGenerar
            // 
            this.btnGenerar.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGenerar.Location = new System.Drawing.Point(57, 155);
            this.btnGenerar.Name = "btnGenerar";
            this.btnGenerar.Size = new System.Drawing.Size(75, 23);
            this.btnGenerar.TabIndex = 6;
            this.btnGenerar.Text = "Generar Reporte";
            this.btnGenerar.UseVisualStyleBackColor = true;
            this.btnGenerar.Click += new System.EventHandler(this.btnGenerar_Click);
            // 
            // txtAnio
            // 
            this.txtAnio.Location = new System.Drawing.Point(102, 118);
            this.txtAnio.Name = "txtAnio";
            this.txtAnio.Size = new System.Drawing.Size(90, 20);
            this.txtAnio.TabIndex = 10;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.White;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 53);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(95, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "Seleccione rango";
            // 
            // txtAni
            // 
            this.txtAni.Location = new System.Drawing.Point(102, 118);
            this.txtAni.Name = "txtAni";
            this.txtAni.Size = new System.Drawing.Size(90, 20);
            this.txtAni.TabIndex = 10;
            // 
            // frmReporteInsumos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(650, 415);
            this.Controls.Add(this.txtAnio);
            this.Controls.Add(this.lblAnio);
            this.Controls.Add(this.lblRango);
            this.Controls.Add(this.cmbRango);
            this.Controls.Add(this.btnGenerar);
            this.Controls.Add(this.crvReporteInsumos);
            this.Name = "frmReporteInsumos";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Reporte de insumos";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private CrystalDecisions.Windows.Forms.CrystalReportViewer crvReporteInsumos;
        private CrystalDecisions.Windows.Forms.CrystalReportViewer crvReporteInsumo;
        private System.Windows.Forms.Label lblAnio;
        private System.Windows.Forms.Label lblRango;
        private System.Windows.Forms.ComboBox cmbRango;
        private System.Windows.Forms.Button btnGenerar;
        private System.Windows.Forms.TextBox txtAnio;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtAni;
    }
}