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
using Capa_Logica_Negocio;

namespace TechoCeiva
{
	/// <summary>
	/// Lógica de interacción para UC_Menu.xaml
	/// </summary>
	public partial class UC_Menu : UserControl
	{
        public UsuarioLN currentUser { get; set; }

		public UC_Menu()
		{
			this.InitializeComponent();
		}

        public UC_Menu(UsuarioLN user)
        {
            this.InitializeComponent();
            this.currentUser = user;
        }

        public void setUser(UsuarioLN user)
        {
            this.currentUser = user;
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
            ///
            /// Se necesita parámetro this.currentUser
            ///
            //UC_Prestamo ucPrestamo = new UC_Prestamo();
            //ucPrestamo.setUser(this.currentUser);
            canvasMenu.Children.Clear();
            canvasMenu.Children.Add(new UC_Prestamo(this.currentUser));
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
            var sComunidad = new UC_SelecComunidad();
            //frmEncuesta nEncuenta = new frmEncuesta();
            canvasMenu.Children.Clear();
            canvasMenu.Children.Add(sComunidad);
            //nEncuenta.Show();
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

        private void btnUsuariosIngresar_Click(object sender, RoutedEventArgs e)
        {
            UC_User nUser = new UC_User();
            canvasMenu.Children.Clear();
            canvasMenu.Children.Add(nUser);
        }

        private void btnUsuariosReportes_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnInsumosIngresar_Click(object sender, RoutedEventArgs e)
        {
            UC_NuevoInsumo nInsumo = new UC_NuevoInsumo();
            canvasMenu.Children.Clear();
            canvasMenu.Children.Add(nInsumo);
        }

        private void btnEncuentaReportes_Click(object sender, RoutedEventArgs e)
        {
            frmReportes GenerarRpt = new frmReportes();
            GenerarRpt.ShowDialog();
        }

        private void btnInsumosReportes_Click(object sender, RoutedEventArgs e)
        {
            UC_SalidaInsumo sInsumo = new UC_SalidaInsumo();
            canvasMenu.Children.Clear();
            canvasMenu.Children.Add(sInsumo);
            canvasMenu.Children.Add(new UC_SalidaInsumo(this.currentUser));
        }
	}
}