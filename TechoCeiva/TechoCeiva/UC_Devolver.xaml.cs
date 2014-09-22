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
	/// Lógica de interacción para UC_Devolver.xaml
	/// </summary>
	public partial class UC_Devolver : UserControl
	{
		public UC_Devolver()
		{
			this.InitializeComponent();
		}

        private void btnAddSingle_Click(object sender, RoutedEventArgs e)
        {
            WinDevolverHelp _nWin = new WinDevolverHelp();
            System.Windows.Forms.Integration.ElementHost.EnableModelessKeyboardInterop(_nWin);
            _nWin.Show();
        }
	}
}