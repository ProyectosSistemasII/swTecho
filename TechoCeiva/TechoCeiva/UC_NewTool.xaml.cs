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
using Capa_Datos;

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
            fillDataGrid();
		}

        private void btnPlus_Click(object sender, RoutedEventArgs e)
        {
            WinAddTool nWinToAddTool = new WinAddTool();
            System.Windows.Forms.Integration.ElementHost.EnableModelessKeyboardInterop(nWinToAddTool);
            nWinToAddTool.ShowDialog();
            fillDataGrid();
        }

        private void fillDataGrid()
        {
            _HerramientasLN Herramientas = new _HerramientasLN();
            DataGridHerramientas.ItemsSource = Herramientas._Obtener_H();
        }

        private void DataGridHerramientas_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            _Herramientas row = DataGridHerramientas.SelectedItem as _Herramientas;
            WinModifyTool modificar = new WinModifyTool();

            modificar.id = row.idHerramientas;
            modificar.txtHerramienta.Text = row.Nombre;
            modificar.txtCantidad.Text = Convert.ToString(row.Existencia);

            System.Windows.Forms.Integration.ElementHost.EnableModelessKeyboardInterop(modificar);
            modificar.ShowDialog();
            fillDataGrid();
        }
	}
}