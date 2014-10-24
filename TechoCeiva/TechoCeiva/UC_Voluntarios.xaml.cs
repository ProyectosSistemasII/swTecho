using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
//using System.Windows.Forms;
using System.ComponentModel;
using System.Drawing;
using System.Collections;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Capa_Logica;
using Capa_Datos;

namespace TechoCeiva
{
	/// <summary>
	/// Lógica de interacción para UC_Voluntarios.xaml
	/// </summary>
	public partial class UC_Voluntarios : UserControl
	{
        int idVol = 0;
		public UC_Voluntarios()
		{
			this.InitializeComponent();
            _VoluntariosLN vol = new _VoluntariosLN();
            fillDataGrid();
		}

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //UC_AddVoluntario nWinAddVoluntario = new UC_AddVoluntario();
            
            
        }

        public void fillDataGrid()
        {
            _VoluntariosLN voluntarios = new _VoluntariosLN();
            datagdVoluntarios.ItemsSource = voluntarios.Obtener_V();

        }

        private void btnPlus_Click(object sender, RoutedEventArgs e)
        {
            WinAddVoluntario nWinAddVoluntario = new WinAddVoluntario();
            _VoluntariosLN voluntario = new _VoluntariosLN();

            System.Windows.Forms.Integration.ElementHost.EnableModelessKeyboardInterop(nWinAddVoluntario);
            nWinAddVoluntario.btnModificar.Visibility = Visibility.Hidden;
            nWinAddVoluntario.ShowDialog();
            fillDataGrid();
        }

        private void datagdVoluntarios_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            _Voluntarios selec = datagdVoluntarios.SelectedItem as _Voluntarios;
            _VoluntariosLN voluntario = new _VoluntariosLN();
            idVol = selec.idVoluntarios;

            WinAddVoluntario nWinAddVoluntario = new WinAddVoluntario();
            System.Windows.Forms.Integration.ElementHost.EnableModelessKeyboardInterop(nWinAddVoluntario);
            
            nWinAddVoluntario.txtNombres.Text = selec.nombres;
            nWinAddVoluntario.txtApellidos.Text = selec.apellidos;
            nWinAddVoluntario.txtDireccion.Text = selec.direccion;
            nWinAddVoluntario.txtTelefono.Text = selec.telefono;
            nWinAddVoluntario.txtCorreo.Text = selec.correo;
            nWinAddVoluntario.txtNombreEmergencia.Text = selec.personaEmergencia;
            nWinAddVoluntario.txtTelEmergencia.Text = selec.telefonoEmergencia;
            nWinAddVoluntario.cmbDepartamento.Text = selec.nombreD;
            nWinAddVoluntario.cmbMunicipio.Text = selec.nombreM;
            nWinAddVoluntario.btnGuardar.Visibility = Visibility.Hidden;
            nWinAddVoluntario.getId(idVol);
            nWinAddVoluntario.ShowDialog();
            fillDataGrid();
        }

        private void btnEliminar_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnDelet_Click(object sender, RoutedEventArgs e)
        {
            _Voluntarios selec = datagdVoluntarios.SelectedItem as _Voluntarios;           
            _VoluntariosLN voluntario = new _VoluntariosLN();
            Boolean correcto = voluntario.Ingresar_V();
            idVol = selec.idVoluntarios;

            if (correcto)
            {

                if (MessageBox.Show("¿Desea eliminar a este voluntario?", "Confirmación", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                {
                    voluntario.Eliminar_V(idVol);
                    fillDataGrid();
                }
                else
                {
                    fillDataGrid();
                }
            }
            else
            {
                MessageBox.Show(voluntario._obtenerError());
            }
        }        
	}
}