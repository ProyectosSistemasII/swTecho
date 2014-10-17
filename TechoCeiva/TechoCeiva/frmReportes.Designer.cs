namespace TechoCeiva
{
    partial class frmReportes
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
            this.crvReportes = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.btnGenerar = new System.Windows.Forms.Button();
            this.cmbComunidad = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbSeleccionReporte = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // crvReportes
            // 
            this.crvReportes.ActiveViewIndex = -1;
            this.crvReportes.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.crvReportes.CachedPageNumberPerDoc = 10;
            this.crvReportes.Cursor = System.Windows.Forms.Cursors.Default;
            this.crvReportes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.crvReportes.Location = new System.Drawing.Point(0, 0);
            this.crvReportes.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.crvReportes.Name = "crvReportes";
            this.crvReportes.Size = new System.Drawing.Size(1025, 572);
            this.crvReportes.TabIndex = 0;
            this.crvReportes.ToolPanelWidth = 267;
            // 
            // btnGenerar
            // 
            this.btnGenerar.Location = new System.Drawing.Point(71, 256);
            this.btnGenerar.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnGenerar.Name = "btnGenerar";
            this.btnGenerar.Size = new System.Drawing.Size(100, 28);
            this.btnGenerar.TabIndex = 1;
            this.btnGenerar.Text = "Generar Reporte";
            this.btnGenerar.UseVisualStyleBackColor = true;
            this.btnGenerar.Click += new System.EventHandler(this.btnGenerar_Click);
            // 
            // cmbComunidad
            // 
            this.cmbComunidad.FormattingEnabled = true;
            this.cmbComunidad.Location = new System.Drawing.Point(16, 97);
            this.cmbComunidad.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cmbComunidad.Name = "cmbComunidad";
            this.cmbComunidad.Size = new System.Drawing.Size(236, 24);
            this.cmbComunidad.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(29, 74);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(152, 17);
            this.label1.TabIndex = 3;
            this.label1.Text = "Seleccione Comunidad";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(29, 146);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(194, 17);
            this.label2.TabIndex = 4;
            this.label2.Text = "Seleccione Seccion Encuesta";
            // 
            // cmbSeleccionReporte
            // 
            this.cmbSeleccionReporte.FormattingEnabled = true;
            this.cmbSeleccionReporte.Items.AddRange(new object[] {
            "Trabajo",
            "Servicios",
            "Propiedad",
            "Comunidad"});
            this.cmbSeleccionReporte.Location = new System.Drawing.Point(16, 201);
            this.cmbSeleccionReporte.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cmbSeleccionReporte.Name = "cmbSeleccionReporte";
            this.cmbSeleccionReporte.Size = new System.Drawing.Size(236, 24);
            this.cmbSeleccionReporte.TabIndex = 5;
            // 
            // frmReportes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1025, 572);
            this.Controls.Add(this.cmbSeleccionReporte);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmbComunidad);
            this.Controls.Add(this.btnGenerar);
            this.Controls.Add(this.crvReportes);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "frmReportes";
            this.Text = "frmReportes";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnGenerar;
        private CrystalDecisions.Windows.Forms.CrystalReportViewer crvReportes;
        private System.Windows.Forms.ComboBox cmbComunidad;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbSeleccionReporte;
    }
}