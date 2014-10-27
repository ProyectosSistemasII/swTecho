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

        public UC_ShowDetalle(int id, DateTime fecha, string nombreVol)
        {
            this.InitializeComponent();
            this.idPrestamo = id;
            this.date = fecha;
            lblNombre.Content = "Préstamos por " + nombreVol + " en fecha " + this.date.ToShortDateString();
            fillGrid();
        }

        private void btnDevolver_Click(object sender, RoutedEventArgs e)
        {
            showWinDevolver();
        }

        private void showWinDevolver()
        {
            try
            {
                _DetallePrestamo detalle = DataGridDetalle.SelectedItem as _DetallePrestamo;
                WinDevolverHelp nDevolucion = new WinDevolverHelp();
                nDevolucion.txtHerramienta.Text = detalle.nombreHerramienta;
                nDevolucion.txtFechaPrestamo.Text = this.date.ToShortDateString();
                nDevolucion.txtCantidad.Text = detalle.CantidadPrestada.ToString();
                nDevolucion.txtBuenEstado.Text = detalle.CantidadPrestada.ToString();
                nDevolucion.ShowDialog();

                if (nDevolucion.getIsClose())
                {
                    saveContent(detalle, nDevolucion);
                    fillGrid();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                //MessageBox.Show("Debe seleccionar un campo para proseguir", "Cuidado", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        private void fillGrid()
        {
            DataGridDetalle.ItemsSource = new _DetallePrestamoLN().buscarDetallesPor(this.idPrestamo);
        }

        private void DataGridDetalle_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            showWinDevolver();
        }

        private void saveContent(_DetallePrestamo varDetalle, WinDevolverHelp win)
        {
            if (win.getPending() == 0)
            {
                varDetalle.devolverTodo(win.getGoodState(), win.getDamaged(), win.getLost(), 0, System.DateTime.Now.Date, varDetalle.idDetallePrestamo, varDetalle.Prestamo_idPrestamo,varDetalle.Herramientas_idHerramientas);
                MessageBox.Show("Valores guardados correctamente", "Guardado Correcto", MessageBoxButton.OK, MessageBoxImage.Asterisk);
            }
            else
                if (win.getPending() > 0)
                {
                    varDetalle.devolverParte(win.getGoodState(), win.getDamaged(), win.getLost(), win.getPending(),System.DateTime.Now.Date, varDetalle.idDetallePrestamo, varDetalle.Herramientas_idHerramientas);
                    MessageBox.Show("Valores guardados correctamente", "Guardado Correcto", MessageBoxButton.OK, MessageBoxImage.Asterisk);
                }
        }
	}
}