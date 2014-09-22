namespace TechoCeiva
{
    partial class frmVoluntarios
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.ingresoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.nuevoVoluntarioToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.consultaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.verVoluntarioToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.modificarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pnlIngreso = new System.Windows.Forms.Panel();
            this.lblNombre = new System.Windows.Forms.Label();
            this.lblSegundoNombre = new System.Windows.Forms.Label();
            this.lblApellido = new System.Windows.Forms.Label();
            this.lblSegundoApellido = new System.Windows.Forms.Label();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.txtSegundoNombre = new System.Windows.Forms.TextBox();
            this.txtApellido = new System.Windows.Forms.TextBox();
            this.txtSegundoApellido = new System.Windows.Forms.TextBox();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pnlConsulta = new System.Windows.Forms.Panel();
            this.lblCodigo = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.pnlVer = new System.Windows.Forms.Panel();
            this.lblName = new System.Windows.Forms.Label();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.lblSndNombre = new System.Windows.Forms.Label();
            this.lblApellid = new System.Windows.Forms.Label();
            this.lblScndApellido = new System.Windows.Forms.Label();
            this.lblActivo = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.pnlModificar = new System.Windows.Forms.Panel();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.button1 = new System.Windows.Forms.Button();
            this.menuStrip1.SuspendLayout();
            this.pnlIngreso.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.pnlConsulta.SuspendLayout();
            this.pnlVer.SuspendLayout();
            this.pnlModificar.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ingresoToolStripMenuItem,
            this.consultaToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(369, 28);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // ingresoToolStripMenuItem
            // 
            this.ingresoToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.nuevoVoluntarioToolStripMenuItem});
            this.ingresoToolStripMenuItem.Name = "ingresoToolStripMenuItem";
            this.ingresoToolStripMenuItem.Size = new System.Drawing.Size(70, 24);
            this.ingresoToolStripMenuItem.Text = "Ingreso";
            // 
            // nuevoVoluntarioToolStripMenuItem
            // 
            this.nuevoVoluntarioToolStripMenuItem.Name = "nuevoVoluntarioToolStripMenuItem";
            this.nuevoVoluntarioToolStripMenuItem.Size = new System.Drawing.Size(194, 24);
            this.nuevoVoluntarioToolStripMenuItem.Text = "Nuevo Voluntario";
            this.nuevoVoluntarioToolStripMenuItem.Click += new System.EventHandler(this.nuevoVoluntarioToolStripMenuItem_Click);
            // 
            // consultaToolStripMenuItem
            // 
            this.consultaToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.verVoluntarioToolStripMenuItem,
            this.modificarToolStripMenuItem});
            this.consultaToolStripMenuItem.Name = "consultaToolStripMenuItem";
            this.consultaToolStripMenuItem.Size = new System.Drawing.Size(78, 24);
            this.consultaToolStripMenuItem.Text = "Consulta";
            // 
            // verVoluntarioToolStripMenuItem
            // 
            this.verVoluntarioToolStripMenuItem.Name = "verVoluntarioToolStripMenuItem";
            this.verVoluntarioToolStripMenuItem.Size = new System.Drawing.Size(152, 24);
            this.verVoluntarioToolStripMenuItem.Text = "Ver";
            this.verVoluntarioToolStripMenuItem.Click += new System.EventHandler(this.verVoluntarioToolStripMenuItem_Click);
            // 
            // modificarToolStripMenuItem
            // 
            this.modificarToolStripMenuItem.Name = "modificarToolStripMenuItem";
            this.modificarToolStripMenuItem.Size = new System.Drawing.Size(152, 24);
            this.modificarToolStripMenuItem.Text = "Modificar";
            this.modificarToolStripMenuItem.Click += new System.EventHandler(this.modificarToolStripMenuItem_Click);
            // 
            // pnlIngreso
            // 
            this.pnlIngreso.Controls.Add(this.btnGuardar);
            this.pnlIngreso.Controls.Add(this.txtSegundoApellido);
            this.pnlIngreso.Controls.Add(this.txtApellido);
            this.pnlIngreso.Controls.Add(this.txtSegundoNombre);
            this.pnlIngreso.Controls.Add(this.txtNombre);
            this.pnlIngreso.Controls.Add(this.lblSegundoApellido);
            this.pnlIngreso.Controls.Add(this.lblApellido);
            this.pnlIngreso.Controls.Add(this.lblSegundoNombre);
            this.pnlIngreso.Controls.Add(this.lblNombre);
            this.pnlIngreso.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pnlIngreso.Location = new System.Drawing.Point(0, 31);
            this.pnlIngreso.Name = "pnlIngreso";
            this.pnlIngreso.Size = new System.Drawing.Size(329, 273);
            this.pnlIngreso.TabIndex = 2;
            this.pnlIngreso.Visible = false;
            // 
            // lblNombre
            // 
            this.lblNombre.AutoSize = true;
            this.lblNombre.Location = new System.Drawing.Point(57, 67);
            this.lblNombre.Name = "lblNombre";
            this.lblNombre.Size = new System.Drawing.Size(60, 17);
            this.lblNombre.TabIndex = 0;
            this.lblNombre.Text = "Nombre:";
            // 
            // lblSegundoNombre
            // 
            this.lblSegundoNombre.AutoSize = true;
            this.lblSegundoNombre.Location = new System.Drawing.Point(7, 98);
            this.lblSegundoNombre.Name = "lblSegundoNombre";
            this.lblSegundoNombre.Size = new System.Drawing.Size(116, 17);
            this.lblSegundoNombre.TabIndex = 1;
            this.lblSegundoNombre.Text = "Segundo Nombre:";
            // 
            // lblApellido
            // 
            this.lblApellido.AutoSize = true;
            this.lblApellido.Location = new System.Drawing.Point(57, 130);
            this.lblApellido.Name = "lblApellido";
            this.lblApellido.Size = new System.Drawing.Size(59, 17);
            this.lblApellido.TabIndex = 2;
            this.lblApellido.Text = "Apellido:";
            // 
            // lblSegundoApellido
            // 
            this.lblSegundoApellido.AutoSize = true;
            this.lblSegundoApellido.Location = new System.Drawing.Point(7, 164);
            this.lblSegundoApellido.Name = "lblSegundoApellido";
            this.lblSegundoApellido.Size = new System.Drawing.Size(115, 17);
            this.lblSegundoApellido.TabIndex = 3;
            this.lblSegundoApellido.Text = "Segundo Apellido:";
            // 
            // txtNombre
            // 
            this.txtNombre.BackColor = System.Drawing.SystemColors.MenuBar;
            this.txtNombre.Location = new System.Drawing.Point(127, 64);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(177, 25);
            this.txtNombre.TabIndex = 4;
            // 
            // txtSegundoNombre
            // 
            this.txtSegundoNombre.BackColor = System.Drawing.SystemColors.MenuBar;
            this.txtSegundoNombre.Location = new System.Drawing.Point(127, 95);
            this.txtSegundoNombre.Name = "txtSegundoNombre";
            this.txtSegundoNombre.Size = new System.Drawing.Size(177, 25);
            this.txtSegundoNombre.TabIndex = 5;
            // 
            // txtApellido
            // 
            this.txtApellido.BackColor = System.Drawing.SystemColors.MenuBar;
            this.txtApellido.Location = new System.Drawing.Point(127, 127);
            this.txtApellido.Name = "txtApellido";
            this.txtApellido.Size = new System.Drawing.Size(177, 25);
            this.txtApellido.TabIndex = 6;
            // 
            // txtSegundoApellido
            // 
            this.txtSegundoApellido.BackColor = System.Drawing.SystemColors.MenuBar;
            this.txtSegundoApellido.Location = new System.Drawing.Point(127, 161);
            this.txtSegundoApellido.Name = "txtSegundoApellido";
            this.txtSegundoApellido.Size = new System.Drawing.Size(177, 25);
            this.txtSegundoApellido.TabIndex = 7;
            this.txtSegundoApellido.TextChanged += new System.EventHandler(this.textBox4_TextChanged);
            // 
            // btnGuardar
            // 
            this.btnGuardar.Location = new System.Drawing.Point(163, 214);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(75, 29);
            this.btnGuardar.TabIndex = 8;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.UseVisualStyleBackColor = true;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::TechoCeiva.Properties.Resources.Logo;
            this.pictureBox1.Location = new System.Drawing.Point(263, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(105, 28);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 3;
            this.pictureBox1.TabStop = false;
            // 
            // pnlConsulta
            // 
            this.pnlConsulta.Controls.Add(this.pnlModificar);
            this.pnlConsulta.Controls.Add(this.btnBuscar);
            this.pnlConsulta.Controls.Add(this.pnlVer);
            this.pnlConsulta.Controls.Add(this.textBox1);
            this.pnlConsulta.Controls.Add(this.lblCodigo);
            this.pnlConsulta.Location = new System.Drawing.Point(0, 31);
            this.pnlConsulta.Name = "pnlConsulta";
            this.pnlConsulta.Size = new System.Drawing.Size(368, 369);
            this.pnlConsulta.TabIndex = 9;
            this.pnlConsulta.Visible = false;
            // 
            // lblCodigo
            // 
            this.lblCodigo.AutoSize = true;
            this.lblCodigo.Location = new System.Drawing.Point(27, 36);
            this.lblCodigo.Name = "lblCodigo";
            this.lblCodigo.Size = new System.Drawing.Size(43, 13);
            this.lblCodigo.TabIndex = 0;
            this.lblCodigo.Text = "Código:";
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.SystemColors.MenuBar;
            this.textBox1.Location = new System.Drawing.Point(106, 36);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(145, 20);
            this.textBox1.TabIndex = 1;
            // 
            // pnlVer
            // 
            this.pnlVer.Controls.Add(this.label5);
            this.pnlVer.Controls.Add(this.label3);
            this.pnlVer.Controls.Add(this.label4);
            this.pnlVer.Controls.Add(this.label2);
            this.pnlVer.Controls.Add(this.label1);
            this.pnlVer.Controls.Add(this.lblActivo);
            this.pnlVer.Controls.Add(this.lblScndApellido);
            this.pnlVer.Controls.Add(this.lblApellid);
            this.pnlVer.Controls.Add(this.lblSndNombre);
            this.pnlVer.Controls.Add(this.lblName);
            this.pnlVer.Location = new System.Drawing.Point(0, 118);
            this.pnlVer.Name = "pnlVer";
            this.pnlVer.Size = new System.Drawing.Size(368, 248);
            this.pnlVer.TabIndex = 2;
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Location = new System.Drawing.Point(63, 29);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(47, 13);
            this.lblName.TabIndex = 0;
            this.lblName.Text = "Nombre:";
            // 
            // btnBuscar
            // 
            this.btnBuscar.Location = new System.Drawing.Point(127, 74);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(75, 23);
            this.btnBuscar.TabIndex = 3;
            this.btnBuscar.Text = "Buscar";
            this.btnBuscar.UseVisualStyleBackColor = true;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // lblSndNombre
            // 
            this.lblSndNombre.AutoSize = true;
            this.lblSndNombre.Location = new System.Drawing.Point(17, 63);
            this.lblSndNombre.Name = "lblSndNombre";
            this.lblSndNombre.Size = new System.Drawing.Size(93, 13);
            this.lblSndNombre.TabIndex = 1;
            this.lblSndNombre.Text = "Segundo Nombre:";
            // 
            // lblApellid
            // 
            this.lblApellid.AutoSize = true;
            this.lblApellid.Location = new System.Drawing.Point(63, 102);
            this.lblApellid.Name = "lblApellid";
            this.lblApellid.Size = new System.Drawing.Size(47, 13);
            this.lblApellid.TabIndex = 2;
            this.lblApellid.Text = "Apellido:";
            // 
            // lblScndApellido
            // 
            this.lblScndApellido.AutoSize = true;
            this.lblScndApellido.Location = new System.Drawing.Point(17, 136);
            this.lblScndApellido.Name = "lblScndApellido";
            this.lblScndApellido.Size = new System.Drawing.Size(93, 13);
            this.lblScndApellido.TabIndex = 3;
            this.lblScndApellido.Text = "Segundo Apellido:";
            // 
            // lblActivo
            // 
            this.lblActivo.AutoSize = true;
            this.lblActivo.Location = new System.Drawing.Point(70, 171);
            this.lblActivo.Name = "lblActivo";
            this.lblActivo.Size = new System.Drawing.Size(40, 13);
            this.lblActivo.TabIndex = 4;
            this.lblActivo.Text = "Activo:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(141, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 13);
            this.label1.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(141, 63);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(0, 13);
            this.label2.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(141, 136);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(0, 13);
            this.label3.TabIndex = 8;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(141, 102);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(0, 13);
            this.label4.TabIndex = 7;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(141, 171);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(0, 13);
            this.label5.TabIndex = 9;
            // 
            // pnlModificar
            // 
            this.pnlModificar.Controls.Add(this.button1);
            this.pnlModificar.Controls.Add(this.radioButton1);
            this.pnlModificar.Controls.Add(this.textBox5);
            this.pnlModificar.Controls.Add(this.textBox4);
            this.pnlModificar.Controls.Add(this.textBox3);
            this.pnlModificar.Controls.Add(this.textBox2);
            this.pnlModificar.Location = new System.Drawing.Point(116, 117);
            this.pnlModificar.Name = "pnlModificar";
            this.pnlModificar.Size = new System.Drawing.Size(249, 252);
            this.pnlModificar.TabIndex = 4;
            this.pnlModificar.Visible = false;
            // 
            // textBox2
            // 
            this.textBox2.BackColor = System.Drawing.SystemColors.MenuBar;
            this.textBox2.Location = new System.Drawing.Point(6, 27);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(166, 20);
            this.textBox2.TabIndex = 0;
            // 
            // textBox3
            // 
            this.textBox3.BackColor = System.Drawing.SystemColors.MenuBar;
            this.textBox3.Location = new System.Drawing.Point(6, 62);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(166, 20);
            this.textBox3.TabIndex = 1;
            // 
            // textBox4
            // 
            this.textBox4.BackColor = System.Drawing.SystemColors.MenuBar;
            this.textBox4.Location = new System.Drawing.Point(6, 100);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(166, 20);
            this.textBox4.TabIndex = 2;
            // 
            // textBox5
            // 
            this.textBox5.BackColor = System.Drawing.SystemColors.MenuBar;
            this.textBox5.Location = new System.Drawing.Point(6, 134);
            this.textBox5.Name = "textBox5";
            this.textBox5.Size = new System.Drawing.Size(166, 20);
            this.textBox5.TabIndex = 3;
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Location = new System.Drawing.Point(11, 170);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(14, 13);
            this.radioButton1.TabIndex = 4;
            this.radioButton1.TabStop = true;
            this.radioButton1.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(57, 215);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(78, 25);
            this.button1.TabIndex = 5;
            this.button1.Text = "Guardar";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // frmVoluntarios
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(369, 400);
            this.Controls.Add(this.pnlConsulta);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.pnlIngreso);
            this.Controls.Add(this.menuStrip1);
            this.Name = "frmVoluntarios";
            this.Text = "frmVoluntarios";
            this.Load += new System.EventHandler(this.frmVoluntarios_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.pnlIngreso.ResumeLayout(false);
            this.pnlIngreso.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.pnlConsulta.ResumeLayout(false);
            this.pnlConsulta.PerformLayout();
            this.pnlVer.ResumeLayout(false);
            this.pnlVer.PerformLayout();
            this.pnlModificar.ResumeLayout(false);
            this.pnlModificar.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem ingresoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem nuevoVoluntarioToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem consultaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem verVoluntarioToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem modificarToolStripMenuItem;
        private System.Windows.Forms.Panel pnlIngreso;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.TextBox txtSegundoApellido;
        private System.Windows.Forms.TextBox txtApellido;
        private System.Windows.Forms.TextBox txtSegundoNombre;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.Label lblSegundoApellido;
        private System.Windows.Forms.Label lblApellido;
        private System.Windows.Forms.Label lblSegundoNombre;
        private System.Windows.Forms.Label lblNombre;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel pnlConsulta;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label lblCodigo;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.Panel pnlVer;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblActivo;
        private System.Windows.Forms.Label lblScndApellido;
        private System.Windows.Forms.Label lblApellid;
        private System.Windows.Forms.Label lblSndNombre;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Panel pnlModificar;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.TextBox textBox5;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.TextBox textBox2;

    }
}