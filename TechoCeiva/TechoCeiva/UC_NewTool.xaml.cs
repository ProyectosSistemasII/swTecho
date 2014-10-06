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
            fillCbox(Tools);
            fillDataGrid(Tools);
		}

        private void btnPlus_Click(object sender, RoutedEventArgs e)
        {
            WinAddTool nWinToAddTool = new WinAddTool();
            System.Windows.Forms.Integration.ElementHost.EnableModelessKeyboardInterop(nWinToAddTool);
            nWinToAddTool.Show();
        }

        private void fillCbox(_HerramientasLN Herramientas)
        {
            cbxHerramienta.ItemsSource = Herramientas._Obtener_H();
            cbxHerramienta.SelectedValuePath = "idHerramientas";
            cbxHerramienta.DisplayMemberPath = "Nombre";
        }

        private void fillDataGrid(_HerramientasLN Herramientas)
        {
            DataGridHerramientas.ItemsSource = Herramientas._Obtener_H();
        }
	}
}