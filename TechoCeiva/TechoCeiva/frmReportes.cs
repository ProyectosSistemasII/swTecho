﻿using System;
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
            cmbComunidad.DisplayMember = "Nombre";
            cmbComunidad.ValueMember = "idComunidad";          
        }
        
        private void btnGenerar_Click(object sender, EventArgs e)
        {
            this.btnGenerar.Enabled = false;
            String NombreComunidad = cmbComunidad.SelectedText;

            //Clase donde se encuentran las consultas de los reportes
            _Reportes generar = new _Reportes();

            // Generar reporte estadistica de personas
            if (cmbSeleccionReporte.SelectedItem == "Estadísticas de personas")
            {
                rptS1_Integrantes rpt = new rptS1_Integrantes();
                rpt.SetDataSource(generar.ClasificacionTotalPersonas(Convert.ToInt32(cmbComunidad.SelectedValue)));
                rpt.SetParameterValue("Comunidad", NombreComunidad);
                crvReportes.ReportSource = rpt;
            }

            // Generar reporte datos demograficos
            if (cmbSeleccionReporte.SelectedItem == "Datos demográficos")
            {
                rptS2_Demograficos rpt = new rptS2_Demograficos();
                rpt.SetDataSource(generar.Demografico(Convert.ToInt32(cmbComunidad.SelectedValue)));
                rpt.SetParameterValue("Comunidad", NombreComunidad);
                crvReportes.ReportSource = rpt;
            }

            // Generar reporte educacion
            if (cmbSeleccionReporte.SelectedItem == "Educación")
            {
                rptS3_Educacion rpt = new rptS3_Educacion();
                rpt.SetDataSource(generar.Educacion(Convert.ToInt32(cmbComunidad.SelectedValue)));
                rpt.SetParameterValue("Comunidad", NombreComunidad);
                crvReportes.ReportSource = rpt;
            }
            // Se ejecuta si selecciona Trabajo en el combobox
            if (cmbSeleccionReporte.SelectedItem == "Trabajo")
            {
                RptS5_Trabajo rpts5 = new RptS5_Trabajo();
                rpts5.SetDataSource(generar.GenerarTrabajo(Convert.ToInt32(cmbComunidad.SelectedValue)));
                rpts5.SetParameterValue("Comunidad", NombreComunidad);
                crvReportes.ReportSource = rpts5; // se agrega el reporte al crystalview para su visualizacion
            }
            // Se ejecuta si selecciona Vivienda en el combobox
            if (cmbSeleccionReporte.SelectedItem == "Vivienda")
            {
                RptS7_Vivienda rpts7 = new RptS7_Vivienda();
                rpts7.SetDataSource(generar.GenerarVivienda(Convert.ToInt32(cmbComunidad.SelectedValue)));
                rpts7.SetParameterValue("Comunidad", NombreComunidad);
                crvReportes.ReportSource = rpts7; // se agrega el reporte al crystalview para su visualizacion
            }

            if (cmbSeleccionReporte.SelectedItem == "Servicios") // se ejecuta se selecciona servicio en el combobox
            {
                S8_ServiciosLN NReporte = new S8_ServiciosLN(); // se instancia una nueva clase de servicios y tambien el reporte de servicios
                RptS8_Servicios rpt = new RptS8_Servicios();
                rpt.SetDataSource(NReporte.GenerarReporte(Convert.ToInt32(cmbComunidad.SelectedValue)));// se toma el id de la comunidad, y se le envia para la capa de logica y datos para hacer el query
                rpt.SetParameterValue("Comunidad", NombreComunidad);
                crvReportes.ReportSource = rpt; // se agrega el reporte al crystalview para su visualizacion
            }
            else if (cmbSeleccionReporte.SelectedItem == "Propiedad")// se ejecuta se selecciona servicio en el combobox
            {
                S9_PropiedadLN NReporte = new S9_PropiedadLN();
                RptS9_Propiedad rpt = new RptS9_Propiedad();
                rpt.SetDataSource(NReporte.GenerarReporte(Convert.ToInt32(cmbComunidad.SelectedValue)));
                rpt.SetParameterValue("Comunidad", NombreComunidad);
                crvReportes.ReportSource = rpt;// se agrega el reporte al crystalview para su visualizacion
            }
            else if (cmbSeleccionReporte.SelectedItem == "Comunidad")// se ejecuta se selecciona servicio en el combobox
            {
                S10_ComunidadLN NReporte = new S10_ComunidadLN();
                rptS10_Comunidad rpt = new rptS10_Comunidad();
                rpt.SetDataSource(NReporte.GenerarReporte(Convert.ToInt32(cmbComunidad.SelectedValue)));
                rpt.SetParameterValue("Comunidad", NombreComunidad);
                crvReportes.ReportSource = rpt;// se agrega el reporte al crystalview para su visualizacion
            }
            else if (cmbSeleccionReporte.SelectedItem == "Comunidad ¿En que grupos participa?")// se ejecuta se selecciona servicio en el combobox
            {
                S1006_ComunidadLN NReporte06 = new S1006_ComunidadLN();
                S1006_Comunidad rpt1 = new S1006_Comunidad();
                rpt1.SetDataSource(NReporte06.GenerarReporte(Convert.ToInt32(cmbComunidad.SelectedValue)));
                rpt1.SetParameterValue("Comunidad", NombreComunidad);
                crvReportes.ReportSource = rpt1;// se agrega el reporte al crystalview para su visualizacion
            }
            else if (cmbSeleccionReporte.SelectedItem == "Comunidad ¿Por qué razones no participa?")// se ejecuta se selecciona servicio en el combobox
            {
                 S1007_ComunidadLN NReporte07 = new S1007_ComunidadLN();
                 S1007_Comunidad rpt2 = new S1007_Comunidad();
                 rpt2.SetDataSource(NReporte07.GenerarReporte(Convert.ToInt32(cmbComunidad.SelectedValue)));
                 rpt2.SetParameterValue("Comunidad", NombreComunidad);
                 crvReportes.ReportSource = rpt2;// se agrega el reporte al crystalview para su visualizacion
            }
            else if (cmbSeleccionReporte.SelectedItem == "Comunidad ¿Confía en personas y/o instituciones?")// se ejecuta se selecciona servicio en el combobox
            {
                S1008_ComunidadLN NReporte08 = new S1008_ComunidadLN();
                S1008_Comunidad rpt3 = new S1008_Comunidad();
                rpt3.SetDataSource(NReporte08.GenerarReporte(Convert.ToInt32(cmbComunidad.SelectedValue)));
                rpt3.SetParameterValue("Comunidad", NombreComunidad);
                crvReportes.ReportSource = rpt3;// se agrega el reporte al crystalview para su visualizacion
            }
            else if (cmbSeleccionReporte.SelectedItem == "Comunidad ¿Cuál es el grupo más afectado por los problemas de la comunidad?")// se ejecuta se selecciona servicio en el combobox
            {
                S1014_ComunidadLN NReporte14 = new S1014_ComunidadLN();
                S1014_Comunidad rpt4 = new S1014_Comunidad();
                rpt4.SetDataSource(NReporte14.GenerarReporte(Convert.ToInt32(cmbComunidad.SelectedValue)));
                rpt4.SetParameterValue("Comunidad", NombreComunidad);
                crvReportes.ReportSource = rpt4;// se agrega el reporte al crystalview para su visualizacion
            }
            else if (cmbSeleccionReporte.SelectedItem == "Movilidad")// se ejecuta se selecciona servicio en el combobox
            {
                S11_MovilidadLN NReporte = new S11_MovilidadLN();
                RptS11_Movilidad rpt = new RptS11_Movilidad();
                rpt.SetDataSource(NReporte.GenerarReporte(Convert.ToInt32(cmbComunidad.SelectedValue)));
                rpt.SetParameterValue("Comunidad", NombreComunidad);
                crvReportes.ReportSource = rpt;// se agrega el reporte al crystalview para su visualizacion
            }
            this.btnGenerar.Enabled = true;
        }
    }
}
