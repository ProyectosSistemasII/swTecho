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
using System.Windows.Navigation;
using System.Windows.Shapes;
using Capa_Logica_Negocio;

namespace TechoCeiva
{
	/// <summary>
	/// Lógica de interacción para UC_Login.xaml
	/// </summary>
	public partial class UC_Login : UserControl
	{
        public Class_close _closeLog;
        public frmLogin _new;

		public UC_Login()
		{
			this.InitializeComponent();
            txt_username.Focus();
            txt_username.SelectAll();
		}

        private void btn_Login_Click(object sender, RoutedEventArgs e)
        {
            UsuarioLN usuario = new UsuarioLN();
            Boolean correcto = usuario.iniciarSesion(txt_username.Text, txt_password.Password);
            if (correcto)
            {
                frmMenu menu = new frmMenu(usuario);
                int id = usuario.idUsuarios;
                menu._nLog = _new;
                _new.Hide();
                menu.Show();
                //_closeLog._closeLogin(_new);

            }
            else
            {
                MessageBox.Show(usuario.obtenerError());
            }

            
        }

        private void label1_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            new frmSettings().Show();
        }

        private void Button_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            WinRecuperarPassword usuario = new WinRecuperarPassword();
            System.Windows.Forms.Integration.ElementHost.EnableModelessKeyboardInterop(usuario);
            usuario.Show();
        }
	}
}