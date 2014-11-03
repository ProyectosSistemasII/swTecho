using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Capa_Datos;

namespace TechoCeiva
{
    public partial class frmReporteInsumos : Form
    {
        public frmReporteInsumos()
        {
            InitializeComponent();
            cmbRango.Items.Add("Enero - Abril");
            cmbRango.Items.Add("Mayo - Agosto");
            cmbRango.Items.Add("Septiembre - Diciembre");

            txtAnio.Text = Convert.ToString(DateTime.Now.Year);

        }

        private void btnGenerar_Click(object sender, EventArgs e)
        {
            if (cmbRango.Text == "" || txtAnio.Text == "")
                MessageBox.Show("No se han completado todos los datos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
            {
                try
                {
                    _Reportes rptSalidas = new _Reportes();
                    //rptSalidas.CaducidadInsumos(cmbRango.Text, Convert.ToInt32(txtAnio.Text));

                    rpt_CaducidadInsumos rpt = new rpt_CaducidadInsumos();
                    rpt.SetDataSource(rptSalidas.CaducidadInsumos(cmbRango.Text, Convert.ToInt32(txtAnio.Text)));
                    //rpt.SetParameterValue("Comunidad", NombreComunidad);
                    crvReporteInsumos.ReportSource = rpt;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al generar reporte", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
