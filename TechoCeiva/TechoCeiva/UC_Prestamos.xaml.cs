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
	/// Lógica de interacción para UC_Prestamo.xaml
	/// </summary>
	public partial class UC_Prestamo : UserControl
	{
        public UsuarioLN currentUser { get; set; }

		public UC_Prestamo()
		{
			this.InitializeComponent();
		}

        public UC_Prestamo(UsuarioLN user)
        {
            this.InitializeComponent();
            this.currentUser = user;
        }

        public void setUser(UsuarioLN user)
        {
            this.currentUser = user;
        }

        private void btnPrestar_Click(object sender, RoutedEventArgs e)
        {
            ///
            /// UC_Manage() es el equivalente a UC_Prestar
            /// se necesita parámetro this.currentUser
            ///
            //UC_Manage ucPrestar = new UC_Manage();
            //ucPrestar.setUser(this.currentUser);
            CanvasBotton.Children.Clear();
            CanvasBotton.Children.Add(new UC_Manage(this.currentUser));
        }

        private void btnDevolver_Click(object sender, RoutedEventArgs e)
        {
            CanvasBotton.Children.Clear();
            CanvasBotton.Children.Add(new UC_Devolver());
        }
	}
}