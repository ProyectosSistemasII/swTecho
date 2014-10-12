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
using System.Collections.ObjectModel;
using Capa_Logica;
using Capa_Datos;

namespace TechoCeiva
{
	/// <summary>
	/// Lógica de interacción para UC_Manage.xaml
	/// </summary>
	public partial class UC_Manage : UserControl
	{
        ObservableCollection<_HerramientasLN> detalle = new ObservableCollection<_HerramientasLN>();

		public UC_Manage()
		{
			this.InitializeComponent();
            dpFecha.SelectedDate = DateTime.Now.Date;
            _VoluntariosLN Personas = new _VoluntariosLN();
            _HerramientasLN Tools = new _HerramientasLN();
            fillCboxNombre(Personas);
            fillCboxHerramientas(Tools);
		}

        private void fillCboxNombre(_VoluntariosLN Voluntarios)
        {
            cbxVoluntario.ItemsSource = Voluntarios.Obtener_V();
            cbxVoluntario.SelectedValuePath = "idVoluntarios";
            cbxVoluntario.DisplayMemberPath = "nombres";
        }

        private void fillCboxHerramientas(_HerramientasLN Herramientas)
        {
            cbxHerramienta.ItemsSource = Herramientas._Obtener_H();
            cbxHerramienta.SelectedValuePath = "idHerramienta";
            cbxHerramienta.DisplayMemberPath = "Nombre";
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            DataGridPrestamo.Items.Add(new _HerramientasLN() { Nombre = cbxHerramienta.Text, Existencia = Convert.ToInt32(txbxCantidad.Text)});
            //detalle.Add(new _HerramientasLN(cbxHerramienta.Text, Convert.ToInt32(txbxCantidad.Text)));
            //DataGridPrestamo.ItemsSource = detalle;
        }
	}
}