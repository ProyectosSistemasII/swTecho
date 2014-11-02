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
        private String fecha;

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
            filtrarPrestamoV();
        }

        private void filtrarPrestamoV()
        {
            dgSalidasInsumos.ItemsSource = null;
            dgSalidasInsumos.ItemsSource = new _Salida().buscarSalidasPorV(voluntario.idVoluntarios);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            fillGrid();
        }

        private void DatePicker_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            if (voluntario.idVoluntarios.Equals(0))
            {
                fecha = String.Format("{0:yyyy-M-d}", dpfechaSalida.SelectedDate);
                filtrarPrestamoF();
            }
            else 
            {
                fecha = String.Format("{0:yyyy-M-d}", dpfechaSalida.SelectedDate);
                filtrarPrestamoVF();
            }
        }

        private void filtrarPrestamoF()
        {
            dgSalidasInsumos.ItemsSource = null;
            dgSalidasInsumos.ItemsSource = new _Salida().buscarSalidasPorF(fecha);
        }

        private void filtrarPrestamoVF()
        {
            dgSalidasInsumos.ItemsSource = null;
            dgSalidasInsumos.ItemsSource = new _Salida().buscarSalidasPorVF(voluntario.idVoluntarios, fecha);
        }
	}
}