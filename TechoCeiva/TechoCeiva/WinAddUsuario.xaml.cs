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
using Capa_Datos;

namespace TechoCeiva
{
	/// <summary>
	/// Lógica de interacción para WinAddVoluntario.xaml
	/// </summary>
	public partial class WinAddUsuario : Window
	{
        int currentid = 0;

		public WinAddUsuario()
		{
			this.InitializeComponent();
		}

        public WinAddUsuario(DatosUsuario usuario)
        {
            this.InitializeComponent();
            btnGuardar.Content = "Modificar";
            txtUsername.IsEnabled = false;
            txtUsername.Text = usuario.userName;
            
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show(ValidarDatosUsuarios.insertarUsuario(txtUsername.Text, pswPassword.Password, pswPassworConfirm.Password, Convert.ToInt16(cmbTipo.SelectedValue), Convert.ToInt16(lstVoluntarios.SelectedValue), Convert.ToString(cmbPregunta.SelectedValue), txtRespuesta.Text));
        }


        public void getId(int idVol) 
        {
            currentid=idVol;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            //carga de datos
            //carga de datos de voluntarios a lista
            DatosVoluntario datosVoluntario = new DatosVoluntario();
            lstVoluntarios.ItemsSource = datosVoluntario.getVoluntarios();
            lstVoluntarios.DisplayMemberPath = "nombresApellidos";
            lstVoluntarios.SelectedValuePath = "idVoluntario";
            //carga de datos a combobox
            DatosTipoUsuario datosTipo = new DatosTipoUsuario();
            cmbTipo.ItemsSource = datosTipo.getTipoUsuarios();
            cmbTipo.DisplayMemberPath = "nombreTipo";
            cmbTipo.SelectedValuePath = "idTipoUsuarios";
            //carga de preguntas
            cmbPregunta.Items.Add("¿Color de mi primera bicicleta?");
            cmbPregunta.Items.Add("¿Segundo nombre de mi abuela?");
            cmbPregunta.Items.Add("¿Nombre de mi primer perro?");
            cmbPregunta.Items.Add("¿Nombre de la cuidad donde nació mi padre?");
            cmbPregunta.Items.Add("¿Personaje de ficción favorito?");
            cmbPregunta.Items.Add("¿Pelicula favorita?");
        }

	}
}