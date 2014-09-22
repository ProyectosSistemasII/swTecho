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
	/// Lógica de interacción para UC_Menu.xaml
	/// </summary>
	public partial class UC_Menu : UserControl
	{
		public UC_Menu()
		{
			this.InitializeComponent();
		}

		private void btnToolsIngresar_Click(object sender, System.Windows.RoutedEventArgs e)
		{
			// TODO: Agregar implementación de controlador de eventos aquí.
            UC_NewTool nTool = new UC_NewTool();
            canvasMenu.Children.Clear();
			canvasMenu.Children.Add(nTool);
		}

        private void btnToolsPrestamos_Click(object sender, RoutedEventArgs e)
        {
            canvasMenu.Children.Clear();
            canvasMenu.Children.Add(new UC_Prestamo());
        }

        private void btnToolsIngresar_Click_1(object sender, RoutedEventArgs e)
        {
            UC_NewTool nTool = new UC_NewTool();
            canvasMenu.Children.Clear();
            canvasMenu.Children.Add(nTool);
        }

        private void expndrEncuestas_Expanded(object sender, System.Windows.RoutedEventArgs e)
        {
        	// TODO: Agregar implementación de controlador de eventos aquí.
			expndrInsumos.IsExpanded = false;
            expndrHerramientas.IsExpanded = false;
            expndrVoluntarios.IsExpanded = false;
            expndrUsuarios.IsExpanded = false;
        }

        private void expndrInsumos_Expanded(object sender, System.Windows.RoutedEventArgs e)
        {
        	// TODO: Agregar implementación de controlador de eventos aquí.
			expndrEncuestas.IsExpanded = false;
            expndrHerramientas.IsExpanded = false;
            expndrVoluntarios.IsExpanded = false;
            expndrUsuarios.IsExpanded = false;
        }

        private void expndrHerramientas_Expanded(object sender, System.Windows.RoutedEventArgs e)
        {
        	// TODO: Agregar implementación de controlador de eventos aquí.
			expndrInsumos.IsExpanded = false;
            expndrEncuestas.IsExpanded = false;
            expndrVoluntarios.IsExpanded = false;
            expndrUsuarios.IsExpanded = false;
        }

        private void expndrVoluntarios_Expanded(object sender, System.Windows.RoutedEventArgs e)
        {
        	// TODO: Agregar implementación de controlador de eventos aquí.
			expndrInsumos.IsExpanded = false;
            expndrEncuestas.IsExpanded = false;
            expndrHerramientas.IsExpanded = false;
            expndrUsuarios.IsExpanded = false;
        }

        private void expndrUsuarios_Expanded(object sender, System.Windows.RoutedEventArgs e)
        {
        	// TODO: Agregar implementación de controlador de eventos aquí.
			expndrInsumos.IsExpanded = false;
            expndrEncuestas.IsExpanded = false;
            expndrHerramientas.IsExpanded = false;
            expndrVoluntarios.IsExpanded = false;
        }

        private void btnEncuestaIngresar_Click(object sender, RoutedEventArgs e)
        {
            frmEncuesta nEncuenta = new frmEncuesta();
            nEncuenta.Show();
        }

        private void btnVoluntariosIngresar_Click(object sender, RoutedEventArgs e)
        {
            UC_Voluntarios nVoluntarios = new UC_Voluntarios();
            canvasMenu.Children.Clear();
            canvasMenu.Children.Add(nVoluntarios);
        }

        private void btnEncuestasComunidad_Click(object sender, RoutedEventArgs e)
        {
            UC_Comunidad nComuidad = new UC_Comunidad();
            canvasMenu.Children.Clear();
            canvasMenu.Children.Add(nComuidad);
        }
	}
}