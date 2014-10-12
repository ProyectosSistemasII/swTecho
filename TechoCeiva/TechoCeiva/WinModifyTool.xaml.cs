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
	/// Lógica de interacción para WinModifyTool.xaml
	/// </summary>
	public partial class WinModifyTool : Window
	{
        public int id = 0;

		public WinModifyTool()
		{
			this.InitializeComponent();
            txtHerramienta.SelectAll();
			// A partir de este punto se requiere la inserción de código para la creación del objeto.
		}

        private void btnGuardar_Click(object sender, RoutedEventArgs e)
        {
            modifyTool();
        }

        private void btnCerrar_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void txtHerramienta_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                txtCantidad.Focus();
                txtCantidad.SelectAll();
            }
        }

        private void txtCantidad_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                btnGuardar.Focus();
                modifyTool();
            }
        }

        private void modifyTool()
        {
            _HerramientasLN modificarHerramienta = new _HerramientasLN(txtHerramienta.Text.ToString(), Convert.ToInt32(txtCantidad.Text));
            Boolean correcto = modificarHerramienta.Ingresar_Herramienta();
            txtHerramienta.Clear();
            txtCantidad.Clear();

            if (correcto)
            {
                modificarHerramienta._Modificar(id);

                if (MessageBox.Show("Herramienta actualizada correctamente.", "Actualizado Exitoso", MessageBoxButton.OK, MessageBoxImage.Information) == MessageBoxResult.OK)
                {
                    this.Close();
                }
                else
                {
                }
            }
            else
            {
                MessageBox.Show(modificarHerramienta._Obtener_Error());
            }
        }
	}
}