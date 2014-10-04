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

namespace TechoCeiva
{
	/// <summary>
	/// Lógica de interacción para WinDevolverHelp.xaml
	/// </summary>
	public partial class WinDevolverHelp : Window
	{
		public WinDevolverHelp()
		{
			this.InitializeComponent();
			
			// A partir de este punto se requiere la inserción de código para la creación del objeto.
            txtDañadas.Focus();
		}

        private void btnCancelar_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
	}
}