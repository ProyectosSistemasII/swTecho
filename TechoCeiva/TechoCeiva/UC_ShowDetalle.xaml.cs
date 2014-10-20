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
	/// Lógica de interacción para UC_ShowDetalle.xaml
	/// </summary>
	public partial class UC_ShowDetalle : UserControl
	{
        private int idPrestamo { get; set; }

		public UC_ShowDetalle()
		{
			this.InitializeComponent();
		}

        public UC_ShowDetalle(int id)
        {
            this.InitializeComponent();
            this.idPrestamo = id;
        }

        private void btnDevolver_Click(object sender, RoutedEventArgs e)
        {
            devolucion();
        }

        private void devolucion()
        {
            WinDevolverHelp nDevolucion = new WinDevolverHelp();
            nDevolucion.ShowDialog();
        }
	}
}