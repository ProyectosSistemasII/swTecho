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
	/// Lógica de interacción para UC_ShowSalidas.xaml
	/// </summary>
	public partial class UC_ShowSalidas : UserControl
	{
        private _Voluntarios voluntario = new _Voluntarios();

		public UC_ShowSalidas()
		{
			this.InitializeComponent();
            fillComboBox();
            fillGrid();
		}

        private void fillComboBox()
        {
            cbxVoluntarios.ItemsSource = new _VoluntariosLN().Obtener_V();
            cbxVoluntarios.SelectedValuePath = "idVoluntarios";
            cbxVoluntarios.DisplayMemberPath = "nombres";
        }

        private void fillGrid()
        {
            dgSalidasInsumos.ItemsSource = null;
            dgSalidasInsumos.ItemsSource = new _Salida().obtenerTodasSalidas();
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            voluntario = cbxVoluntarios.SelectedItem as _Voluntarios;
            filtrarPrestamo();
        }

        private void filtrarPrestamo()
        {
            dgSalidasInsumos.ItemsSource = null;
            dgSalidasInsumos.ItemsSource = new _Salida().buscarSalidasPor(voluntario.idVoluntarios);
        }
	}
}