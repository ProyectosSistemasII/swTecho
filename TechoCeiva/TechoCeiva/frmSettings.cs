using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace TechoCeiva
{
    public partial class frmSettings : Form
    {
        public frmSettings()
        {
            InitializeComponent();
        }

        private void frmSettings_Load(object sender, EventArgs e)
        {
            UC_Settings settings = new UC_Settings();
            canvasSettings.Child=settings;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (txtAcceso.Text == Properties.Settings.Default.passwordSettings)
            {
                canvasSettings.Visible = true;
                button1.Visible = false;
                txtAcceso.Visible = false;
                label2.Visible = false;
            }
            else
            {
                MessageBox.Show("Contraseña incorrecta","Error");
            }
        }
    }
}
