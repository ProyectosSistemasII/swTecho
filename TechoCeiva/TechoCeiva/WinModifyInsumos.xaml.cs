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
	/// Lógica de interacción para WinModifyInsumos.xaml
	/// </summary>
	public partial class WinModifyInsumos : Window
	{
        private int cantidad { get; set; }
        private Boolean isClose { get; set; }

		public WinModifyInsumos()
		{
            this.InitializeComponent();
            txtCantidad.Focus();
            this.cantidad = 0;
		}
        
        private void setCantidad(int Cantidad)
        {
            this.cantidad = Cantidad;
        }

        public int getCantidad()
        {
            return this.cantidad;
        }

        private void setIsClose(Boolean close)
        {
            this.isClose = close;
        }

        public Boolean getIsClose()
        {
            return this.isClose;
        }

        private void btnCancelar_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnAceptar_Click(object sender, RoutedEventArgs e)
        {
            setCantidad(Convert.ToInt32(txtCantidad.Text));
            setIsClose(true);
            this.Close();
        }
	}
}