namespace TechoCeiva
{
    partial class frmSettings
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
            this.canvasSettings = new System.Windows.Forms.Integration.ElementHost();
            this.button1 = new System.Windows.Forms.Button();
            this.txtAcceso = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // canvasSettings
            // 
            this.canvasSettings.Location = new System.Drawing.Point(0, 0);
            this.canvasSettings.Name = "canvasSettings";
            this.canvasSettings.Size = new System.Drawing.Size(280, 400);
            this.canvasSettings.TabIndex = 0;
            this.canvasSettings.Text = "elementHost1";
            this.canvasSettings.Visible = false;
            this.canvasSettings.Child = null;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(146)))), ((int)(((byte)(221)))));
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.SystemColors.Control;
            this.button1.Location = new System.Drawing.Point(87, 177);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(115, 36);
            this.button1.TabIndex = 1;
            this.button1.Text = "Ingresar";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // txtAcceso
            // 
            this.txtAcceso.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAcceso.Location = new System.Drawing.Point(75, 139);
            this.txtAcceso.Name = "txtAcceso";
            this.txtAcceso.PasswordChar = '*';
            this.txtAcceso.Size = new System.Drawing.Size(142, 26);
            this.txtAcceso.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(218, 32);
            this.label1.TabIndex = 3;
            this.label1.Text = "Ajustes del sistema";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(71, 116);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(86, 20);
            this.label2.TabIndex = 4;
            this.label2.Text = "Contraseña:";
            // 
            // frmSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(194)))), ((int)(((byte)(194)))));
            this.ClientSize = new System.Drawing.Size(284, 408);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtAcceso);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.canvasSettings);
            this.Name = "frmSettings";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Paramentos del servidor";
            this.Load += new System.EventHandler(this.frmSettings_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Integration.ElementHost canvasSettings;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox txtAcceso;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}