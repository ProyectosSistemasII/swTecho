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
	/// Lógica de interacción para UC_Prestamo.xaml
	/// </summary>
	public partial class UC_Prestamo : UserControl
	{
		public UC_Prestamo()
		{
			this.InitializeComponent();
		}

        private void btnPrestar_Click(object sender, RoutedEventArgs e)
        {
            CanvasBotton.Children.Clear();
            CanvasBotton.Children.Add(new UC_Manage());
        }

        private void btnDevolver_Click(object sender, RoutedEventArgs e)
        {
            CanvasBotton.Children.Clear();
            CanvasBotton.Children.Add(new UC_Devolver());
        }
	}
}