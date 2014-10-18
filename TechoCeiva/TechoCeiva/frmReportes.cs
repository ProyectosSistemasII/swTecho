using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Capa_Datos;
using Capa_Logica;
namespace TechoCeiva
{
    public partial class frmReportes : Form
    {
        public frmReportes()
        {
            InitializeComponent();
            _Comunidad Comunidades = new _Comunidad();
            cmbComunidad.DataSource =  Comunidades.ObtenerComunidadesEncuesta();
            cmbComunidad.DisplayMember = "Nombre";//.ToString();
            cmbComunidad.ValueMember = "idComunidad";//.ToString();
            
        }
        
        private void btnGenerar_Click(object sender, EventArgs e)
        {
            this.btnGenerar.Enabled = false;
           

            //Clase donde se encuentran las consultas de los reportes
            _Reportes generar = new _Reportes();
            //El reporte hecho en crystal reports
            /*
             * El dataSet lo tuve que agregar en la vista porque a la hora de enlazar el informe con el dataset no lo encuentra 
             */ 
           /* RptDepto rpt = new RptDepto();
            rpt.SetDataSource(llenar.Generar());
            crvReportes.ReportSource = rpt;
            */

            //// Reporte S8_Servicios
            if (cmbSeleccionReporte.SelectedItem == "Trabajo")
            {
                //S8_ServiciosLN NReporte = new S8_ServiciosLN();
                RptS5_Trabajo rpts5 = new RptS5_Trabajo();
                rpts5.SetDataSource(generar.GenerarTrabajo(Convert.ToInt32(cmbComunidad.SelectedValue)));
                crvReportes.ReportSource = rpts5;

            }
            if (cmbSeleccionReporte.SelectedItem == "Servicios")
            {
                S8_ServiciosLN NReporte = new S8_ServiciosLN();
                RptS8_Servicios rpt = new RptS8_Servicios();
                rpt.SetDataSource(NReporte.GenerarReporte(Convert.ToInt32(cmbComunidad.SelectedValue)));
                crvReportes.ReportSource = rpt;

            }
            else if (cmbSeleccionReporte.SelectedItem == "Propiedad")
            {
                S9_PropiedadLN NReporte = new S9_PropiedadLN();
                RptS9_Propiedad rpt = new RptS9_Propiedad();
                rpt.SetDataSource(NReporte.GenerarReporte(Convert.ToInt32(cmbComunidad.SelectedValue)));
                crvReportes.ReportSource = rpt;

            }
            else if (cmbSeleccionReporte.SelectedItem == "Comunidad")
            {
                S10_ComunidadLN NReporte = new S10_ComunidadLN();
                rptS10_Comunidad rpt = new rptS10_Comunidad();
                rpt.SetDataSource(NReporte.GenerarReporte(Convert.ToInt32(cmbComunidad.SelectedValue)));
                //rpt.SetParameterValue("Comunidad", cmbComunidad.SelectedText);
                crvReportes.ReportSource = rpt;

            }
            else if (cmbSeleccionReporte.SelectedItem == "Comunidad Pregunta 6")
            {
                S1006_ComunidadLN NReporte06 = new S1006_ComunidadLN();
                S1006_Comunidad rpt1 = new S1006_Comunidad();
                rpt1.SetDataSource(NReporte06.GenerarReporte(Convert.ToInt32(cmbComunidad.SelectedValue)));
                crvReportes.ReportSource = rpt1;
            }
            else if (cmbSeleccionReporte.SelectedItem == "Comunidad Pregunta 7")
            {
                 S1007_ComunidadLN NReporte07 = new S1007_ComunidadLN();
                 rptS10_Comunidad rpt2 = new rptS10_Comunidad();
                 rpt2.SetDataSource(NReporte07.GenerarReporte(Convert.ToInt32(cmbComunidad.SelectedValue)));
                 crvReportes.ReportSource = rpt2;
            }
            else if (cmbSeleccionReporte.SelectedItem == "Comunidad Pregunta 8")
            {
                S1008_ComunidadLN NReporte08 = new S1008_ComunidadLN();
                rptS10_Comunidad rpt3 = new rptS10_Comunidad();
                rpt3.SetDataSource(NReporte08.GenerarReporte(Convert.ToInt32(cmbComunidad.SelectedValue)));
                crvReportes.ReportSource = rpt3;
            }
            else if (cmbSeleccionReporte.SelectedItem == "Comunidad Pregunta 14")
            {
                rptS10_Comunidad rpt4 = new rptS10_Comunidad();
                S1014_ComunidadLN NReporte14 = new S1014_ComunidadLN();
                rpt4.SetDataSource(NReporte14.GenerarReporte(Convert.ToInt32(cmbComunidad.SelectedValue)));
                crvReportes.ReportSource = rpt4;
            }
            else if (cmbSeleccionReporte.SelectedItem == "Movilidad")
            {
                S11_MovilidadLN NReporte = new S11_MovilidadLN();
                RptS11_Movilidad rpt = new RptS11_Movilidad();
                rpt.SetDataSource(NReporte.GenerarReporte(Convert.ToInt32(cmbComunidad.SelectedValue)));
                crvReportes.ReportSource = rpt;

            }
            this.btnGenerar.Enabled = true;
        }
    }
}
