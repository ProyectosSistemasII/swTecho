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

namespace TechoCeiva
{
	/// <summary>
	/// Lógica de interacción para UC_ShowModificarSalida.xaml
	/// </summary>
	public partial class UC_ShowModificarSalida : UserControl
	{
        private UC_ShowSalidas varSalidas = new UC_ShowSalidas();
		public UC_ShowModificarSalida()
		{
			this.InitializeComponent();
            CanvasSalidas.Children.Clear();
            CanvasSalidas.Children.Add(varSalidas);
		}

        private void btnVerDetalle_Click(object sender, RoutedEventArgs e)
        {
            CanvasSalidas.Children.Clear();
            btnVerDetalle.IsEnabled = false;
            btnBack.IsEnabled = true;
            CanvasSalidas.Children.Add(new UC_ShowDetalleSalidas());
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