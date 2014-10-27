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
        int idComn = 0;
        bool mod = false;

        public UC_Comunidad()
        {
            InitializeComponent();
            fillDataGrid();            
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            fillDataGrid();
        }

        private void btnGuardar_Click(object sender, RoutedEventArgs e)
        {
            WinAddComunidad newComunidad = new WinAddComunidad();
            System.Windows.Forms.Integration.ElementHost.EnableModelessKeyboardInterop(newComunidad);
            newComunidad.ShowDialog();
            fillDataGrid();
        }

        public void fillDataGrid()
        {
            _ComunidadLN comunidad = new _ComunidadLN();
            dataGridComn.ItemsSource = comunidad.ObtenerComunidades();               
        }

        private void dataGridComn_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            _Comunidad sele = dataGridComn.SelectedItem as _Comunidad;
            _ComunidadLN comunidad = new _ComunidadLN();
            idComn = sele.idComunidad;

            WinAddComunidad nWinAddComunidad = new WinAddComunidad();
            System.Windows.Forms.Integration.ElementHost.EnableModelessKeyboardInterop(nWinAddComunidad);

            nWinAddComunidad.txtNombre.Text = sele.Nombre;
            nWinAddComunidad.cmbDpto.Text = sele.DepartamentoNombre;
            nWinAddComunidad.cmbMun.Text = sele.MunicipioNombre;
            nWinAddComunidad.getId(idComn);
            nWinAddComunidad.Show();
            fillDataGrid();
        }

        private void btnCancelar_Click(object sender, RoutedEventArgs e)
        {
            _Comunidad sele = dataGridComn.SelectedItem as _Comunidad;
            _ComunidadLN comunidad = new _ComunidadLN();
            Boolean correcto = comunidad.Ingresar_C();

            if (correcto)
            {

                if (MessageBox.Show("¿Desea eliminar esta comunidad?", "Confirmación", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                {
                    /*comunidad.eliminarComunidad(sele.idComunidad);
                    txtNombre.Text = "";
                    cmbDepartamento.Text = "";
                    fillDataGrid(comunidad);*/
                    fillDataGrid();
                }
                else
                {
                    fillDataGrid();
                }
            }
            else
            {
                MessageBox.Show(comunidad._obtenerError());
            }
                      
        }
    }
}
