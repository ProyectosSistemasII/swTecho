﻿using System;
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
            acction_Login();
        }

        private void txt_password_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                acction_Login();
            }
            else
            {
            }
        }

        private void acction_Login()
        {
            UsuarioLN usuario = new UsuarioLN();
            Boolean correcto = usuario.iniciarSesion(txt_username.Text, txt_password.Password);
            if (correcto)
            {
                frmMenu menu = new frmMenu();
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
	}
}