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
using Capa_Datos;
using Capa_Logica;

namespace TechoCeiva
{
	/// <summary>
	/// Lógica de interacción para UC_NuevoInsumo.xaml
	/// </summary>
	public partial class UC_NuevoInsumo : UserControl
	{
		public UC_NuevoInsumo()
		{
			this.InitializeComponent();
            fillDataGrid();
		}

        private void btnMas_Click(object sender, RoutedEventArgs e)
        {
            WinNewInsumo nInsumo = new WinNewInsumo();
            System.Windows.Forms.Integration.ElementHost.EnableModelessKeyboardInterop(nInsumo);
            nInsumo.ShowDialog();
            fillDataGrid();
        }

        private void fillDataGrid()
        {
            _InsumosLN insumos = new _InsumosLN();
            dgInsumos.ItemsSource = insumos._Obtener_I();
        }

        private void dgInsumos_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            _Insumos row = dgInsumos.SelectedItem as _Insumos;
            WinNewInsumo modificar = new WinNewInsumo();

            modificar.mod = true;
            modificar.comboBoxInsumos.IsEnabled= false;
            modificar.cmxPresentacion.IsEnabled = false;
            modificar.id = row.idAlimentos;
            modificar.comboBoxInsumos.Text = row.Nombre;
            modificar.cmxPresentacion.Text = row.Presentacion;
            modificar.txtCantida.Text = Convert.ToString(row.Existencia);
            modificar.cbxRangoFecha.Text = row.Rango;
            modificar.txtAni.Text = Convert.ToString(row.AnioCaducidad);
            System.Windows.Forms.Integration.ElementHost.EnableModelessKeyboardInterop(modificar);
            modificar.ShowDialog();
            fillDataGrid();
        
        }
	}
}