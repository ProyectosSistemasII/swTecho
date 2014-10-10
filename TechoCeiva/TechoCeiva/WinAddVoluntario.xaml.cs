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
using System.Data;
using Capa_Logica;

namespace TechoCeiva
{
	/// <summary>
	/// Lógica de interacción para WinAddVoluntario.xaml
	/// </summary>
	public partial class WinAddVoluntario : Window
	{
		public WinAddVoluntario()
		{
			this.InitializeComponent();

            _DepartamentoLN depto = new _DepartamentoLN();

            cmbDepartamento.ItemsSource = depto.Obtener_D();
            cmbDepartamento.SelectedValuePath = "idDepartamento";
            cmbDepartamento.DisplayMemberPath = "nombre";
			// A partir de este punto se requiere la inserción de código para la creación del objeto.
		}

        private void cmbMunicipio_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
           
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            String nombres = txtNombres.Text;
            String apellidos = txtApellidos.Text;
            String direccion = txtDireccion.Text;
            String telefono = txtTelefono.Text;
            String correo = txtCorreo.Text;
            int dpto = Convert.ToInt32(cmbDepartamento.SelectedValue);
            int mun = Convert.ToInt32(cmbMunicipio.SelectedValue);
            String persEm = txtNombreEmergencia.Text;
            String telEm = txtTelEmergencia.Text;

            _VoluntariosLN voluntario = new _VoluntariosLN(nombres, apellidos, telefono, direccion, correo, true, dpto, mun, persEm, telEm);
            Boolean correcto = voluntario.Ingresar_V();


            if (correcto)
            {
                voluntario.Insertar_V();
                MessageBox.Show("Ingreso Exitoso");
                this.Close();
                UC_Voluntarios vol = new UC_Voluntarios();
                vol.fillDataGrid(voluntario);
                
            }
            else
            {
                MessageBox.Show(voluntario._obtenerError());
            }


        }

        private void Button_Loaded(object sender, RoutedEventArgs e)
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