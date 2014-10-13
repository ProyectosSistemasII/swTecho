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
using System.Collections;

namespace TechoCeiva
{
    /// <summary>
    /// Lógica de interacción para UC_User.xaml
    /// </summary>
    public partial class UC_User : UserControl
    {
        public UC_User()
        {
            InitializeComponent();
        }

        private void Canvas_Loaded(object sender, RoutedEventArgs e)
        {
            //inicializacion de los componentes
            //
            //carga de datos a datagrid
            refrescar();
        }

        private void refrescar()
        {
            DatosUsuario datosUsuario = new DatosUsuario();
            List<DatosUsuario> tmp = datosUsuario.getUsuarios();
            dtgUsuarios.ItemsSource = tmp;
            dtgUsuarios.Columns[0].Header = "Nombre de Usuario";
            dtgUsuarios.Columns[1].Header = "Nombres";
            dtgUsuarios.Columns[2].Header = "Apellidos";
            dtgUsuarios.Columns[3].Header = "Tipo de usuario";
            dtgUsuarios.DisplayMemberPath = "Nombres";
        }

        private void btnGuardar_Click(object sender, RoutedEventArgs e)
        {
            //DatosVoluntario tmp = (DatosVoluntario)lstVoluntarios.SelectedItem;
            
            refrescar();
        }

        private void btnPlus_Click(object sender, RoutedEventArgs e)
        {
            WinAddUsuario usuario = new WinAddUsuario();
            System.Windows.Forms.Integration.ElementHost.EnableModelessKeyboardInterop(usuario);
            usuario.Show();
        }
    }
}
