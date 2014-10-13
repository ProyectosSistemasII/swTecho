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
using System.Windows.Shapes;
using System.Data;
using Capa_Datos;

namespace TechoCeiva
{
	/// <summary>
	/// Lógica de interacción para WinAddVoluntario.xaml
	/// </summary>
	public partial class WinAddUsuario : Window
	{
        int currentid = 0;

		public WinAddUsuario()
		{
			this.InitializeComponent();

		}


        private void Button_Click(object sender, RoutedEventArgs e)
        {
            DatosUsuario nuevo = new DatosUsuario();
            MessageBox.Show(nuevo.insertarUsuario(txtUsername.Text, pswPassword.Password, Convert.ToInt16(cmbTipo.SelectedValue), Convert.ToInt16(lstVoluntarios.SelectedValue)));
        }


        public void getId(int idVol) 
        {
            currentid=idVol;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

        }

	}
}