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
            String NombreComunidad = cmbComunidad.SelectedText;

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
            if (cmbSeleccionReporte.SelectedItem == "Servicios") // se ejecuta se selecciona servicio el el combox
            {
                S8_ServiciosLN NReporte = new S8_ServiciosLN(); // se instancia una nueva clase de servcios y tambien el reporte de servicios
                RptS8_Servicios rpt = new RptS8_Servicios();
                rpt.SetDataSource(NReporte.GenerarReporte(Convert.ToInt32(cmbComunidad.SelectedValue)));// se toma el id de la comunidad, y se le envia para la capa de logica y datos para hacer el query
                rpt.SetParameterValue("Comunidad", NombreComunidad);
                crvReportes.ReportSource = rpt; // se agrega el reporte a al crystalview para su visualizacion.

            }
            else if (cmbSeleccionReporte.SelectedItem == "Propiedad")
            {
                S9_PropiedadLN NReporte = new S9_PropiedadLN();
                RptS9_Propiedad rpt = new RptS9_Propiedad();
                rpt.SetDataSource(NReporte.GenerarReporte(Convert.ToInt32(cmbComunidad.SelectedValue)));
                rpt.SetParameterValue("Comunidad", NombreComunidad);
                crvReportes.ReportSource = rpt;

            }
            else if (cmbSeleccionReporte.SelectedItem == "Comunidad")
            {
                S10_ComunidadLN NReporte = new S10_ComunidadLN();
                rptS10_Comunidad rpt = new rptS10_Comunidad();
                rpt.SetDataSource(NReporte.GenerarReporte(Convert.ToInt32(cmbComunidad.SelectedValue)));
                rpt.SetParameterValue("Comunidad", NombreComunidad);
                crvReportes.ReportSource = rpt;

            }
            else if (cmbSeleccionReporte.SelectedItem == "Comunidad Pregunta 6")
            {
                S1006_ComunidadLN NReporte06 = new S1006_ComunidadLN();
                S1006_Comunidad rpt1 = new S1006_Comunidad();
                rpt1.SetDataSource(NReporte06.GenerarReporte(Convert.ToInt32(cmbComunidad.SelectedValue)));
                rpt1.SetParameterValue("Comunidad", NombreComunidad);
                crvReportes.ReportSource = rpt1;
            }
            else if (cmbSeleccionReporte.SelectedItem == "Comunidad Pregunta 7")
            {
                 S1007_ComunidadLN NReporte07 = new S1007_ComunidadLN();
                 S1007_Comunidad rpt2 = new S1007_Comunidad();
                 rpt2.SetDataSource(NReporte07.GenerarReporte(Convert.ToInt32(cmbComunidad.SelectedValue)));
                 rpt2.SetParameterValue("Comunidad", NombreComunidad); 
                crvReportes.ReportSource = rpt2;
            }
            else if (cmbSeleccionReporte.SelectedItem == "Comunidad Pregunta 8")
            {
                S1008_ComunidadLN NReporte08 = new S1008_ComunidadLN();
                S1008_Comunidad rpt3 = new S1008_Comunidad();
                rpt3.SetDataSource(NReporte08.GenerarReporte(Convert.ToInt32(cmbComunidad.SelectedValue)));
                rpt3.SetParameterValue("Comunidad", NombreComunidad);
                crvReportes.ReportSource = rpt3;
            }
            else if (cmbSeleccionReporte.SelectedItem == "Comunidad Pregunta 14")
            {
                S1014_ComunidadLN NReporte14 = new S1014_ComunidadLN();
                S1014_Comunidad rpt4 = new S1014_Comunidad();
                rpt4.SetDataSource(NReporte14.GenerarReporte(Convert.ToInt32(cmbComunidad.SelectedValue)));
                rpt4.SetParameterValue("Comunidad", NombreComunidad);
                crvReportes.ReportSource = rpt4;
            }
            else if (cmbSeleccionReporte.SelectedItem == "Movilidad")
            {
                S11_MovilidadLN NReporte = new S11_MovilidadLN();
                RptS11_Movilidad rpt = new RptS11_Movilidad();
                rpt.SetDataSource(NReporte.GenerarReporte(Convert.ToInt32(cmbComunidad.SelectedValue)));
                rpt.SetParameterValue("Comunidad", NombreComunidad);
                crvReportes.ReportSource = rpt;

            }
            this.btnGenerar.Enabled = true;
        }
    }
}
