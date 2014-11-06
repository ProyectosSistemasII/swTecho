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
    public partial class frmReporteHerramientas : Form
    {
        public int idSalida = 0;
        public frmReporteHerramientas()
        {
            InitializeComponent();
        }

        private void frmReporteHerramientas_Load(object sender, EventArgs e)
        {
            try
            {
                _Reportes rptSalidas = new _Reportes();
                rpt_Herramientas rpt = new rpt_Herramientas();
                rpt.SetDataSource(rptSalidas.Herramientas());
                crvReporteHerramientas.ReportSource = rpt;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al generar reporte", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
