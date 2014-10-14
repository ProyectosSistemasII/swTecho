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
using Capa_Datos;

namespace TechoCeiva
{
    /// <summary>
    /// Lógica de interacción para UC_SelecComunidad.xaml
    /// </summary>
    public partial class UC_SelecComunidad : UserControl
    {
        public UC_SelecComunidad()
        {
            InitializeComponent();
        }

        private void btnGuardar_Click(object sender, RoutedEventArgs e)
        {
            frmEncuesta nEncuesta = new frmEncuesta();
            nEncuesta.Reiniciar = true;
            while (nEncuesta.Reiniciar)
            {
                nEncuesta = new frmEncuesta();
                nEncuesta.idComuni = Convert.ToInt32(cmbComunidad.SelectedValue.ToString());
                nEncuesta.ShowDialog();
            }
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            _Comunidad Comunidades = new _Comunidad();
            cmbComunidad.ItemsSource = Comunidades.ObtenerComunidadesEncuesta();
            cmbComunidad.DisplayMemberPath = "Nombre";//.ToString();
            cmbComunidad.SelectedValuePath = "idComunidad";//.ToString();
        }

    }
}
