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
            txtDañadas.Focus();
		}

        private void btnCancelar_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void txtDañadas_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                txtPerdidas.Focus();
            }
        }

        private void txtPerdidas_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                txtPendientes.Focus();
            }
        }

        private void txtPendientes_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                txtBuenEstado.Focus();
            }
        }

        private void txtBuenEstado_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                btnAceptar.Focus();
            }
        }
	}
}