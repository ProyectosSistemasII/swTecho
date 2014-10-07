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
using Capa_Logica;

namespace TechoCeiva
{
	/// <summary>
	/// Lógica de interacción para WinAddTool.xaml
	/// </summary>
	public partial class WinAddTool : Window
	{
		public WinAddTool()
		{
			this.InitializeComponent();
            txtHerramienta.Focus();
			
			// A partir de este punto se requiere la inserción de código para la creación del objeto.
		}

        private void btnCancelar_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnAgregar_Click(object sender, RoutedEventArgs e)
        {
            _HerramientasLN nuevaHerramienta = new _HerramientasLN(txtHerramienta.Text.ToString());
            Boolean correcto = nuevaHerramienta.Ingresar_Herramienta();
            txtHerramienta.Clear();

            if (correcto)
            {
                nuevaHerramienta._Insertar_H();
                txtHerramienta.Focus();
            }
            else
            {
                MessageBox.Show(nuevaHerramienta._Obtener_Error());
            }
        }
	}
}