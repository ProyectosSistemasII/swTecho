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
    public partial class frmReportesSalidas : Form
    {
        public frmReportesSalidas()
        {
            InitializeComponent();
        }

        public int idSalida = 0;
        private void frmReportesSalidas_Load(object sender, EventArgs e)
        {
            bool intentar = false;
            do
            {
                try
                {
                    _Reportes rptSalidas = new _Reportes();
                    rptSalidas.SalidasInsumos(idSalida);

                    rpt_SalidaInsumos rpt = new rpt_SalidaInsumos();
                    rpt.SetDataSource(rptSalidas.SalidasInsumos(idSalida));
                    //rpt.SetParameterValue("Comunidad", NombreComunidad);
                    crvReportesSalidas.ReportSource = rpt;
                }
                catch (Exception ex)
                {
                    DialogResult pregunta = MessageBox.Show("Ha ocurrido un error, ¿Desea volver a generar?", "Error", MessageBoxButtons.YesNo, MessageBoxIcon.Error);
                    if (pregunta == DialogResult.Yes)
                        intentar = true;
                    else
                        intentar = false;
                }
            } while (intentar == true);

        }
    }
}
