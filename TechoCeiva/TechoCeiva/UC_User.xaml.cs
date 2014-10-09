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
            DatosUsuario datosUsuario = new DatosUsuario();
            ArrayList datos = datosUsuario.getUsuarios();
            dtgUsuarios.ItemsSource = datos;
        }
    }
}
