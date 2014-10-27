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
using Capa_Logica;
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
            dtgUsuarios.Columns[0].Width = 120;
            dtgUsuarios.Columns[1].Width = 120;
            dtgUsuarios.Columns[2].Width = 120;
            dtgUsuarios.Columns[3].Width = 120;
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
            usuario.ShowDialog();
            refrescar();
        }

        private void btnEliminar_Click(object sender, RoutedEventArgs e)
        {
            if (dtgUsuarios.SelectedIndex == -1)
                return;
            MessageBoxResult resultado = MessageBox.Show("Desea eliminar los datos del usario seleccionado?", "", MessageBoxButton.YesNo);
            if (resultado == MessageBoxResult.Yes)
            {
                DatosUsuario usuario = (DatosUsuario) dtgUsuarios.SelectedItem;
                ValidarDatosUsuarios.eliminarUsuario(usuario.userName);
                refrescar();
            }
        }

        private void dtgUsuarios_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            WinAddUsuario win = new WinAddUsuario((DatosUsuario)dtgUsuarios.SelectedItem);
            System.Windows.Forms.Integration.ElementHost.EnableModelessKeyboardInterop(win);
            win.Show();
        }

    }
}
