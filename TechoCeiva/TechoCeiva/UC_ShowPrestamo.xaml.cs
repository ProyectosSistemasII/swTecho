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
	/// Lógica de interacción para UC_ShowPrestamo.xaml
	/// </summary>
	public partial class UC_ShowPrestamo : UserControl
	{
        private _Voluntarios voluntario = new _Voluntarios();

		public UC_ShowPrestamo()
		{
			this.InitializeComponent();
            fillGrid();
		}

        public UC_ShowPrestamo(_Voluntarios v)
        {
            this.InitializeComponent();
        }

        private void fillGrid()
        {
            DataGridListadoPrestamos.ItemsSource = null;
            DataGridListadoPrestamos.ItemsSource = new _PrestamosLN().obtenerTodosPrestamos();
        }

        private void btnFiltrar_Click(object sender, RoutedEventArgs e)
        {
            WinFiltro nWinFiltro = new WinFiltro();
            nWinFiltro.ShowDialog();
            if (nWinFiltro.isVolunteerSelected())
            {
                voluntario = nWinFiltro.getChosen();
                lblFiltro.Content = "Filtrado por " + voluntario.nombres;
                filtrarPrestamo();
            }
        }

        private void filtrarPrestamo()
        {
            DataGridListadoPrestamos.ItemsSource = null;
            DataGridListadoPrestamos.ItemsSource = new _PrestamosLN().buscarPrestamosPor(voluntario.idVoluntarios);
        }

        private void btnVolver_Click(object sender, RoutedEventArgs e)
        {
            lblFiltro.Content = "";
            fillGrid();
        }

        private void specialFill(_Voluntarios v)
        {
            if (v != null)
            {
                lblFiltro.Content = "Filtrado por " + v.nombres;
                DataGridListadoPrestamos.ItemsSource = null;
                DataGridListadoPrestamos.ItemsSource = new _PrestamosLN().buscarPrestamosPor(v.idVoluntarios);
            }
            else
                fillGrid();
        }
	}
}