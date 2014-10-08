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
            this.SuspendLayout();
            // 
            // canvasSettings
            // 
            this.canvasSettings.Location = new System.Drawing.Point(2, 2);
            this.canvasSettings.Name = "canvasSettings";
            this.canvasSettings.Size = new System.Drawing.Size(280, 400);
            this.canvasSettings.TabIndex = 0;
            this.canvasSettings.Text = "elementHost1";
            this.canvasSettings.Child = null;
            // 
            // frmSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 408);
            this.Controls.Add(this.canvasSettings);
            this.Name = "frmSettings";
            this.Text = "Paramentos del servidor";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Integration.ElementHost canvasSettings;
    }
}