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
using Capa_Logica;
using Capa_Datos;

namespace TechoCeiva
{
	/// <summary>
	/// Lógica de interacción para UC_ShowDetalle.xaml
	/// </summary>
	public partial class UC_ShowDetalle : UserControl
	{
        private int idPrestamo { get; set; }
        private string name { get; set; }
        private DateTime date { get; set; }

		public UC_ShowDetalle()
		{
			this.InitializeComponent();
		}

        public UC_ShowDetalle(int id, DateTime fecha)
        {
            this.InitializeComponent();
            this.idPrestamo = id;
            this.date = fecha;
            lblFecha.Content = "de fecha " + this.date.ToShortDateString();
            fillGrid();
        }

        private void btnDevolver_Click(object sender, RoutedEventArgs e)
        {
            devolver();
        }

        private void devolver()
        {
            _DetallePrestamo detalle = DataGridDetalle.SelectedItem as _DetallePrestamo;
            WinDevolverHelp nDevolucion = new WinDevolverHelp();
            nDevolucion.txtHerramienta.Text = detalle.Herramientas_idHerramientas.ToString();
            nDevolucion.txtFechaPrestamo.Text = this.date.ToShortDateString();
            nDevolucion.txtCantidad.Text = detalle.CantidadPrestada.ToString();
            nDevolucion.ShowDialog();
        }

        private void fillGrid()
        {
            DataGridDetalle.ItemsSource = new _DetallePrestamoLN().buscarDetallesPor(this.idPrestamo);
        }

        private void DataGridDetalle_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            devolver();
        }
	}
}