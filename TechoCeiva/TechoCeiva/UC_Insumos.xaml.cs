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
	/// Lógica de interacción para UC_Tools.xaml
	/// </summary>
	public partial class UC_Tools : UserControl
	{
		public UC_Tools()
		{
			this.InitializeComponent();
			canvasContent.Children.Clear();
			txtNulo.Focus();
		}

		private void btnAgregar_Click(object sender, System.Windows.RoutedEventArgs e)
		{
			// TODO: Agregar implementación de controlador de eventos aquí.
			canvasContent.Children.Clear();
			canvasContent.Children.Add(new UC_NewTool());
		}

		private void btnGestion_Click(object sender, System.Windows.RoutedEventArgs e)
		{
			// TODO: Agregar implementación de controlador de eventos aquí.
			canvasContent.Children.Clear();
			canvasContent.Children.Add(new UC_Manage());
		}
	}
}