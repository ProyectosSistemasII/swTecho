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
        int currentid = 0;
        UC_Voluntarios newUcVol = new UC_Voluntarios();
        _VoluntariosLN dataVol = new _VoluntariosLN();

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
            bool bandera=verificar();
            if (!bandera)
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
                    this.Close();
                }
                else
                {
                    MessageBox.Show(voluntario._obtenerError());
                }

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

        private void btnModificar_Click(object sender, RoutedEventArgs e)
        {
            bool bandera=verificar();
            if (!bandera)
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
                    voluntario.Modificar_V(currentid);
                    this.Close();
                }
                else
                {
                    MessageBox.Show(voluntario._obtenerError());
                }
            }
        }

        public void getId(int idVol) 
        {
            currentid=idVol;
        }
        private void btnEliminar_Click(object sender, RoutedEventArgs e)
        {
            _VoluntariosLN voluntario = new _VoluntariosLN();
            Boolean correcto = voluntario.Ingresar_V();


            if (correcto)
            {
                if (MessageBox.Show("¿Desea eliminar a este voluntario?", "Confirmación", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                {
                    voluntario.Eliminar_V(currentid);
                    this.Close();
                    newUcVol.fillDataGrid();
                }
                else
                {
                    newUcVol.fillDataGrid();
                }
            }
            else
            {
                MessageBox.Show(voluntario._obtenerError());
            }
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private bool verificar() 
        {
            if(txtNombres.Text=="")
            {
                MessageBox.Show("Debe ingresar un Nombre para el voluntario");
                txtNombres.Focus();
                return true;
            }
            else
            if (txtApellidos.Text == "")
            {
                MessageBox.Show("Debe ingresar un Apellido para el voluntario");
                txtApellidos.Focus();
                return true;
            }
            else
            if (txtDireccion.Text == "")
            {
                MessageBox.Show("Debe ingresar una Direccion para el voluntario");
                txtDireccion.Focus();
                return true;
            }
            else
            if (txtCorreo.Text == "")
            {
                MessageBox.Show("Debe ingresar un Correo para el voluntario");
                txtCorreo.Focus();
                return true;
            }
            else
            if (txtTelefono.Text == "")
            {
                MessageBox.Show("Debe ingresar un Teléfono para el voluntario");
                txtTelefono.Focus();
                return true;
            }
            else
            if (txtNombreEmergencia.Text == "")
            {
                MessageBox.Show("Debe ingresar un Contacto de Emergencia para el voluntario");
                txtNombreEmergencia.Focus();
                return true;
            }
            else
            if (txtTelEmergencia.Text == "")
            {
                MessageBox.Show("Debe ingresar un Teléfono de Emergencia para el voluntario");
                txtTelEmergencia.Focus();
                return true;
            }
            else
            if (cmbDepartamento.Text == "")
            {
                MessageBox.Show("Debe ingresar un Departamento y Municipio para el voluntario");
                cmbDepartamento.Focus();
                return true;
            }
            else
            if (cmbMunicipio.Text == "")
            {
                MessageBox.Show("Debe ingresar un Municipio para el voluntario");
                cmbMunicipio.Focus();
                return true;
            }

            return false;
        }
	}
}