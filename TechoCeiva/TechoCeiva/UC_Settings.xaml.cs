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
using Capa_Logica;
using System.Collections;
using System.Windows.Interop;

namespace TechoCeiva
{
    /// <summary>
    /// Lógica de interacción para UC_Settings.xaml
    /// </summary>
    public partial class UC_Settings : UserControl
    {
        public UC_Settings()
        {
            InitializeComponent();
        }

        private void btn_Login_Click(object sender, RoutedEventArgs e)
        {
            String salida = SettingsSistema.saveParametros(txtServer.Text, txtDatabase.Text, txtUser.Text, pswPassword.Password);
            MessageBox.Show(salida, "Mensaje", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            HwndSource source = (HwndSource)PresentationSource.FromVisual(sender as Button);
            System.Windows.Forms.Control ctl = System.Windows.Forms.Control.FromChildHandle(source.Handle);
            ctl.FindForm().Close();
            System.Windows.Forms.Application.Restart();
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            //[0] server
            //[1] database
            //[2] user
            //[3] password
            ArrayList parametros =SettingsSistema.getParametros();
            txtServer.Text = parametros[0].ToString();
            txtDatabase.Text = parametros[1].ToString();
            txtUser.Text = parametros[2].ToString();
            pswPassword.Password = parametros[3].ToString();
        }
    }
}
