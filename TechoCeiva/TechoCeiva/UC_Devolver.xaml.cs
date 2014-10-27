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
using Capa_Logica_Negocio;
using Capa_Datos;

namespace TechoCeiva
{
	/// <summary>
	/// Lógica de interacción para UC_Devolver.xaml
	/// </summary>
	public partial class UC_Devolver : UserControl
	{
        private _Voluntarios voluntario = new _Voluntarios();
        private UC_ShowPrestamo prestamos;

		public UC_Devolver()
		{
			this.InitializeComponent();
            prestamos = new UC_ShowPrestamo();
            CanvasDevTool.Children.Clear();
            CanvasDevTool.Children.Add(prestamos);
		}

        private void btnVerDetalle_Click(object sender, RoutedEventArgs e)
        {
            verDetalle();
        }

        private void verDetalle()
        {
            try
            {
                btnVerDetalle.IsEnabled = false;
                btnBack.IsEnabled = true;
                _Prestamo detalle = prestamos.DataGridListadoPrestamos.SelectedItem as _Prestamo;
                CanvasDevTool.Children.Clear();
                CanvasDevTool.Children.Add(new UC_ShowDetalle(detalle.iDPrestamo, detalle.fechaPrestamo, detalle.nombreVoluntario));
            }
            catch
            {
                MessageBox.Show("Debe seleccionar un campo para seguir", "Cuidado", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            btnBack.IsEnabled = false;
            btnVerDetalle.IsEnabled = true;
            CanvasDevTool.Children.Clear();
            CanvasDevTool.Children.Add(prestamos);
        }
	}
}