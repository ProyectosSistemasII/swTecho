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
    public partial class frmReportes : Form
    {
        public frmReportes()
        {
            InitializeComponent();
        }

        private void btnGenerar_Click(object sender, EventArgs e)
        {
            //Clase donde se encuentran las consultas de los reportes
            _Reportes llenar = new _Reportes();
            //El reporte hecho en crystal reports
            /*
             * El dataSet lo tuve que agregar en la vista porque a la hora de enlazar el informe con el dataset no lo encuentra 
             */ 
            RptDepto rpt = new RptDepto();
            rpt.SetDataSource(llenar.Generar());
            crvReportes.ReportSource = rpt;
        }
    }
}
