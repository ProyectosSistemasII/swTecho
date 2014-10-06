using System;
using System.Collections.Generic;
using System.Linq;
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
using System.Data;
using Capa_Datos;

namespace TechoCeiva
{
    /// <summary>
    /// Lógica de interacción para UC_Comunidad.xaml
    /// </summary>
    public partial class UC_Comunidad : UserControl
    {
        public UC_Comunidad()
        {
            InitializeComponent();
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            _DepartamentoLN depto = new _DepartamentoLN();
            
            cmbDepartamento.ItemsSource = depto.Obtener_D();
            cmbDepartamento.SelectedValuePath = "idDepartamento";
            cmbDepartamento.DisplayMemberPath = "nombre";
            
        }

        private void btnGuardar_Click(object sender, RoutedEventArgs e)
        {
            
            
        }

        private void cmbDepartamento_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            _MunicipioLN mun = new _MunicipioLN();

            cmbMunicipio.ItemsSource = mun.Obtener_M(Convert.ToInt32(cmbDepartamento.SelectedValue));
            cmbMunicipio.SelectedValuePath = "idMunicipio";
            cmbMunicipio.DisplayMemberPath = "nombre";
        }
    }
}
