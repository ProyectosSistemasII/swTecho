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
            _HerramientasLN nuevaHerramienta = new _HerramientasLN();
            Boolean correcto = nuevaHerramienta.Ingresar_Herramienta(txtHerramienta.Text.ToString(), 0, true);
            txtHerramienta.Clear();

            if (correcto)
            {
                nuevaHerramienta._Insertar_H();
                //MessageBox.Show("Herramienta ingresada correctamente");
                txtHerramienta.Focus();
            }
            else
            {
                MessageBox.Show(nuevaHerramienta._Obtener_Error());
            }
        }
	}
}