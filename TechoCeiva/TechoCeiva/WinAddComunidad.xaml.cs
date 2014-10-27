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
using System.Windows.Shapes;
using Capa_Datos;
using Capa_Logica;

namespace TechoCeiva
{
	/// <summary>
	/// Lógica de interacción para WinAddComunidad.xaml
	/// </summary>
	public partial class WinAddComunidad : Window
	{
        int idComn = 0;
        bool mod = false;
        UC_Comunidad comun = new UC_Comunidad();

		public WinAddComunidad()
		{
			this.InitializeComponent();
			
			// A partir de este punto se requiere la inserción de código para la creación del objeto.
		}

        private void cmbDpto_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            _MunicipioLN mun = new _MunicipioLN();

            cmbMun.ItemsSource = mun.Obtener_M(Convert.ToInt32(cmbDpto.SelectedValue));
            cmbMun.SelectedValuePath = "idMunicipio";
            cmbMun.DisplayMemberPath = "nombre";
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            _ComunidadLN comn = new _ComunidadLN();
            _DepartamentoLN depto = new _DepartamentoLN();
            List<_Departamento> lista = new List<_Departamento>();
            lista = depto.Obtener_D();
            cmbDpto.ItemsSource = depto.Obtener_D();
            cmbDpto.SelectedValuePath = "idDepartamento";
            cmbDpto.DisplayMemberPath = "nombre";
        }

        public void getId(int idComunidad)
        {
            idComn = idComunidad;
            mod = true;
        }

        private void btnGuardar_Click(object sender, RoutedEventArgs e)
        {
            String nombre = txtNombre.Text;
            int departamento = Convert.ToInt32(cmbDpto.SelectedValue);
            int municipio = Convert.ToInt32(cmbMun.SelectedValue);

            _ComunidadLN comunidad = new _ComunidadLN(nombre, true, departamento, municipio);
            Boolean correcto = comunidad.Ingresar_C();

            if (mod == false)
            {
                if (correcto)
                {
                    comunidad.InsertarComunidad();
                    txtNombre.Text = "";
                    cmbDpto.Text = "";
                    if (MessageBox.Show("¿Desea agregar otra comunidad?", "Confirmación", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                    {
                        txtNombre.Focus();
                    }
                    else
                    {
                        this.Close();
                        comun.fillDataGrid();                        
                    }
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
                    txtNombre.Text = "";
                    cmbDpto.Text = "";
                    mod = false;
                    comun.fillDataGrid();
                    this.Close();
                }
                else
                {
                    MessageBox.Show(comunidad._obtenerError());
                }
            }
            
        }

        private void btnCancelar_Click(object sender, RoutedEventArgs e)
        {

            if (MessageBox.Show("¿Desea salir?", "Confirmación", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                comun.fillDataGrid();
                this.Close();
            }
            else
            {
                txtNombre.Focus();
            }
        }
	}
}