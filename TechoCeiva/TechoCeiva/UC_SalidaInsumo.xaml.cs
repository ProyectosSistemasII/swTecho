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
	/// Lógica de interacción para UC_SalidaInsumo.xaml
	/// </summary>
	public partial class UC_SalidaInsumo : UserControl
	{
		public UC_SalidaInsumo()
		{
			this.InitializeComponent();
            fillComboBox();
		}

        private void cbxInsumos_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void btnAgregar_Click(object sender, RoutedEventArgs e)
        {

        }

        private void fillComboBox()
        {
            _InsumosLN insumos = new _InsumosLN();
            cbxInsumos.ItemsSource = insumos._Obtener_I();
            cbxInsumos.SelectedValuePath = "idInsumos";
            cbxInsumos.DisplayMemberPath = "Nombre";

            _Voluntarios voluntario = new _Voluntarios();
            cbxVoluntarios.ItemsSource = voluntario.Obtener_V();
            cbxVoluntarios.SelectedValuePath = "idVoluntario";
            cbxVoluntarios.DisplayMemberPath = "nombres";
        }
	}
}