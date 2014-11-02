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

namespace TechoCeiva
{
	/// <summary>
	/// Lógica de interacción para UC_ShowModificarSalida.xaml
	/// </summary>
	public partial class UC_ShowModificarSalida : UserControl
	{
        private _Voluntarios voluntario = new _Voluntarios();
        private UC_ShowSalidas varSalidas;

		public UC_ShowModificarSalida()
		{
			this.InitializeComponent();
            varSalidas = new UC_ShowSalidas();
            CanvasSalidas.Children.Clear();
            CanvasSalidas.Children.Add(varSalidas);
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
                _Salida detalle = varSalidas.dgSalidasInsumos.SelectedItem as _Salida;
                CanvasSalidas.Children.Clear();
                CanvasSalidas.Children.Add(new UC_ShowDetalleSalidas(detalle.idSalida, detalle.FechaSalida, detalle.nombreVoluntario));
            }
            catch
            {
                MessageBox.Show("Debe seleccionar un campo para seguir", "Cuidado", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            CanvasSalidas.Children.Clear();
            btnBack.IsEnabled = false;
            btnVerDetalle.IsEnabled = true;
            CanvasSalidas.Children.Add(varSalidas);
        }
	}
}