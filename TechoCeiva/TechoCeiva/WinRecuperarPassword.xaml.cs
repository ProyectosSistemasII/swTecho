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
using System.Windows.Shapes;
using Capa_Datos;

namespace TechoCeiva
{
    /// <summary>
    /// Lógica de interacción para WinRecuperarPassword.xaml
    /// </summary>
    public partial class WinRecuperarPassword : Window
    {
        public WinRecuperarPassword()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            DatosUsuario usuario = new DatosUsuario();
            if (usuario.buscarUsuario(txtUsername.Text))
            {
                lblPregunta.Content = usuario.getPregunta(txtUsername.Text);
                txtRespuesta.IsEnabled = true;
                btnVerificar.IsEnabled = true;
                btnBuscar.IsEnabled = false;
                txtUsername.IsEnabled = false;
            }
            else
                MessageBox.Show("El usuario no esta registrado");

        }

        private void btnVerificar_Click(object sender, RoutedEventArgs e)
        {
            DatosUsuario usuario = new DatosUsuario();
            if (usuario.isRespuesta(txtUsername.Text, txtRespuesta.Text))
            {
                txtRespuesta.IsEnabled = false;
                btnVerificar.IsEnabled = false;
                lblNew.Content = usuario.reiniciarPassword(txtUsername.Text);
            }
            else
                MessageBox.Show("La respuesta no es correcta");
        }
    }
}
