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
	/// Lógica de interacción para UC_Insumo.xaml
	/// </summary>
	public partial class UC_Insumo : UserControl
	{
        private UsuarioLN currentUser { get; set; }
		public UC_Insumo()
		{
			this.InitializeComponent();
		}

        public UC_Insumo(UsuarioLN user)
        {
            this.InitializeComponent();
            this.currentUser = user;
            canvasContent.Children.Clear();
            canvasContent.Children.Add(new UC_SalidaInsumo(this.currentUser));
        }

        private void btnModificar_Click(object sender, RoutedEventArgs e)
        {
            canvasContent.Children.Clear();
            canvasContent.Children.Add(new UC_ShowModificarSalida());
        }
	}
}