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

        }

        private void btnGuardar_Click(object sender, RoutedEventArgs e)
        {
            _DepartamentoLN depto = new _DepartamentoLN();
            depto.Obtener_D();
            cmbDepartamento.DisplayMemberPath = depto.nombre;
            cmbDepartamento.SelectedValue = depto.idDepartamento;

        }
    }
}
