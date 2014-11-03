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
    public partial class frmPrestamoHerramientas : Form
    {
        public frmPrestamoHerramientas()
        {
            InitializeComponent();
        }

        public int idPrestamo = 0;
        private void frmPrestamoHerramientas_Load(object sender, EventArgs e)
        {
            bool intentar = false;
            do
            {
                try
                {
                    _Reportes rptSalidas = new _Reportes();
                    rptSalidas.SalidasHerramientas(idPrestamo);

                    rpt_PrestamoHerramientas rpt = new rpt_PrestamoHerramientas();
                    rpt.SetDataSource(rptSalidas.SalidasHerramientas(idPrestamo));
                    //rpt.SetParameterValue("Comunidad", NombreComunidad);
                    crvReportePrestamo.ReportSource = rpt;
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
