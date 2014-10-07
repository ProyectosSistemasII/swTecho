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
using Capa_Logica;

namespace TechoCeiva
{
	/// <summary>
	/// Lógica de interacción para UC_NewTool.xaml
	/// </summary>
	public partial class UC_NewTool : UserControl
	{
		public UC_NewTool()
		{
			this.InitializeComponent();
            _HerramientasLN Tools = new _HerramientasLN();
            fillComboBox();
            fillDataGrid();
            cbxHerramienta.Focus();
		}

        private void btnPlus_Click(object sender, RoutedEventArgs e)
        {
            WinAddTool nWinToAddTool = new WinAddTool();
            System.Windows.Forms.Integration.ElementHost.EnableModelessKeyboardInterop(nWinToAddTool);
            nWinToAddTool.ShowDialog();
            fillComboBox();
            fillDataGrid();
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            acctionAdd();
        }

        private void txtCantidad_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                acctionAdd();
            }
            else
            {
            }
        }

        private void fillComboBox()
        {
            _HerramientasLN Herramientas = new _HerramientasLN();
            cbxHerramienta.ItemsSource = Herramientas._Obtener_H();
            cbxHerramienta.SelectedValuePath = "idHerramientas";
            cbxHerramienta.DisplayMemberPath = "Nombre";
        }

        private void fillDataGrid()
        {
            _HerramientasLN Herramientas = new _HerramientasLN();
            DataGridHerramientas.ItemsSource = Herramientas._Obtener_H();
        }

        private void acctionAdd()
        {
            _HerramientasLN herramienta = new _HerramientasLN();
            herramienta._Modificar(Convert.ToInt32(cbxHerramienta.SelectedValue), Convert.ToInt32(txtCantidad.Text.ToString()));

            txtCantidad.Clear();
            MessageBox.Show("Existencia de " + cbxHerramienta.Text + " modificada correctamente");
            fillDataGrid();
        }
	}
}