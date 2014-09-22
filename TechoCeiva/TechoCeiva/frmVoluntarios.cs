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
    public partial class frmVoluntarios : Form
    {
        public frmVoluntarios()
        {
            InitializeComponent();
        }

        private void frmVoluntarios_Load(object sender, EventArgs e)
        {
            pnlIngreso.Visible = false;
            pnlConsulta.Visible = false;
            pnlVer.Visible = false;
            pnlModificar.Visible = false;
        }

        private void nuevoVoluntarioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pnlIngreso.Visible = true;
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void verVoluntarioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pnlConsulta.Visible = true;

        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            pnlVer.Visible = true;
        }

        private void modificarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pnlModificar.Visible = true;
        }
    }
}
