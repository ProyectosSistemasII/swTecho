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

            /*cmbDepartamento.ItemsSource = depto.Obtener_D();
            cmbDepartamento.SelectedValuePath = "idDepartamento";
            cmbDepartamento.DisplayMemberPath = "nombre";
			*/
			// A partir de este punto se requiere la inserción de código para la creación del objeto.
		}

        private void cmbMunicipio_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            _MunicipioLN mun = new _MunicipioLN();

            cmbxMunicipio.ItemsSource = mun.Obtener_M(Convert.ToInt32(cmbxDepartamento.SelectedValue));
            cmbxMunicipio.SelectedValuePath = "idMunicipio";
            cmbxMunicipio.DisplayMemberPath = "nombre";
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            String nombres = txtNombres.Text;
            String apellidos = txtApellidos.Text;
            String direccion = txtDireccion.Text;
            String telefono = txtTelefono.Text;
            String correo = txtCorreo.Text;
            int dpto = Convert.ToInt32(cmbxDepartamento.SelectedValue);
            int mun = Convert.ToInt32(cmbxMunicipio.SelectedValue);
            String persEm = txtNombreEmergencia.Text;
            String telEm = txtTelEmergencia.Text;

            _VoluntariosLN voluntario = new _VoluntariosLN(nombres,apellidos,telefono,direccion,correo,true,dpto,mun,persEm,telEm);


        }

        private void Button_Loaded(object sender, RoutedEventArgs e)
        {
            _DepartamentoLN depto = new _DepartamentoLN();

            cmbxDepartamento.ItemsSource = depto.Obtener_D();
            cmbxDepartamento.SelectedValuePath = "idDepartamento";
            cmbxDepartamento.DisplayMemberPath = "nombre";
        }

	}
}