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
	/// Lógica de interacción para UC_Voluntarios.xaml
	/// </summary>
	public partial class UC_Voluntarios : UserControl
	{
		public UC_Voluntarios()
		{
			this.InitializeComponent();
		}

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            WinAddVoluntario nWinAddVoluntario = new WinAddVoluntario();
            System.Windows.Forms.Integration.ElementHost.EnableModelessKeyboardInterop(nWinAddVoluntario);
            nWinAddVoluntario.Show();
        }
	}
}