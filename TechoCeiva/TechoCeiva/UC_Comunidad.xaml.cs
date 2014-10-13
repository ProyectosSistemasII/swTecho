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
            
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            _ComunidadLN comn = new _ComunidadLN();
            _DepartamentoLN depto = new _DepartamentoLN();
            List<_Departamento> lista = new List<_Departamento>();
            lista = depto.Obtener_D();
            cmbDepartamento.ItemsSource = depto.Obtener_D();
            cmbDepartamento.SelectedValuePath = "idDepartamento";
            cmbDepartamento.DisplayMemberPath = "nombre";

            fillDataGrid(comn);
        }

        private void btnGuardar_Click(object sender, RoutedEventArgs e)
        {
            String nombre=txtNombre.Text;
            int departamento=Convert.ToInt32(cmbDepartamento.SelectedValue);
            int municipio=Convert.ToInt32(cmbMunicipio.SelectedValue);

            _ComunidadLN comunidad = new _ComunidadLN(nombre,true, departamento, municipio);
            Boolean correcto = comunidad.Ingresar_C();

            if (mod==false)
            {
                if (correcto)
                {
                    comunidad.InsertarComunidad();
                    MessageBox.Show("Ingreso Exitoso");
                    txtNombre.Text = "";
                    cmbDepartamento.Text = "";
                    fillDataGrid(comunidad);
                }
                else
                {
                    MessageBox.Show(comunidad._obtenerError());
                }
            }
            else
            {
                if (correcto)
                {
                    comunidad.ModificarComunidad(idComn);
                    MessageBox.Show("Modificación Exitosa", "", MessageBoxButton.OK, MessageBoxImage.Information);
                    txtNombre.Text = "";
                    cmbDepartamento.Text = "";
                    fillDataGrid(comunidad);
                    mod = false;
                }
                else
                {
                    MessageBox.Show(comunidad._obtenerError());
                }
            }
            
            
        }

        private void fillDataGrid(_ComunidadLN comunidad)
        {
            List<_Comunidad> comn = new List<_Comunidad>();
            comn = comunidad.ObtenerComunidades();
            dataGridComn.ItemsSource = comn;
            
            
        }

        private void cmbDepartamento_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            _MunicipioLN mun = new _MunicipioLN();

            cmbMunicipio.ItemsSource = mun.Obtener_M(Convert.ToInt32(cmbDepartamento.SelectedValue));
            cmbMunicipio.SelectedValuePath = "idMunicipio";
            cmbMunicipio.DisplayMemberPath = "nombre";
        }

        private void btnModificar_Click(object sender, RoutedEventArgs e)
        {
            String nombre = txtNombre.Text;
            int departamento = Convert.ToInt32(cmbDepartamento.SelectedValue);
            int municipio = Convert.ToInt32(cmbMunicipio.SelectedValue);

            _ComunidadLN comunidad = new _ComunidadLN(nombre, true, departamento, municipio);
            Boolean correcto = comunidad.Ingresar_C();


            if (correcto)
            {
                comunidad.ModificarComunidad(idComn);
                MessageBox.Show("Modificación Exitosa","",MessageBoxButton.OK,MessageBoxImage.Information);
                txtNombre.Text = "";
                cmbDepartamento.Text = "";
                fillDataGrid(comunidad);
            }
            else
            {
                MessageBox.Show(comunidad._obtenerError());
            }
            
               
        }

        private void dataGridComn_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            _Comunidad sele = dataGridComn.SelectedItem as _Comunidad;
            mod = true;
            txtNombre.Text = sele.Nombre;
            cmbDepartamento.Text = sele.DepartamentoNombre;
            cmbMunicipio.Text = sele.MunicipioNombre;
            idComn = sele.idComunidad;
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
                    comunidad.eliminarComunidad(sele.idComunidad);
                    txtNombre.Text = "";
                    cmbDepartamento.Text = "";
                    fillDataGrid(comunidad);
                }
                else
                {
                    fillDataGrid(comunidad);
                }
            }
            else
            {
                MessageBox.Show(comunidad._obtenerError());
            }
                      
        }
    }
}
