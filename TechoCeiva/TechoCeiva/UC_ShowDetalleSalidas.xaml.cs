using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Capa_Datos;
using Capa_Logica;

namespace TechoCeiva
{
	/// <summary>
	/// Lógica de interacción para UC_ShowDetalleSalidas.xaml
	/// </summary>
	public partial class UC_ShowDetalleSalidas : UserControl
	{
        private int idSalida { get; set; }
        private string name { get; set; }
        private DateTime date { get; set; }

		public UC_ShowDetalleSalidas()
		{
			this.InitializeComponent();
		}

        public UC_ShowDetalleSalidas(int id, DateTime fecha, string nombreVol)
        {
            this.InitializeComponent();
            this.idSalida = id;
            this.date = fecha;
            lblNombre.Content = "Salidas por " + nombreVol + " con fecha " + this.date.ToShortDateString();
            fillGrid();
        }

        private void fillGrid()
        {
            dgDetalleSalidas.ItemsSource = new _DetalleSalida().buscarDetallesPor(this.idSalida);
        }
	}
}