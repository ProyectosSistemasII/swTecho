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
using Capa_Logica;
using Capa_Logica_Negocio;
using Capa_Datos;

namespace TechoCeiva
{
	/// <summary>
	/// Lógica de interacción para UC_Devolver.xaml
	/// </summary>
	public partial class UC_Devolver : UserControl
	{
        private _Voluntarios voluntario = new _Voluntarios();

		public UC_Devolver()
		{
			this.InitializeComponent();
            fillGrid();
		}

        private void btnAddSingle_Click(object sender, RoutedEventArgs e)
        {
            WinDevolverHelp _nWin = new WinDevolverHelp();
            System.Windows.Forms.Integration.ElementHost.EnableModelessKeyboardInterop(_nWin);
            _nWin.Show();
        }

        private void btnFiltro_Click(object sender, RoutedEventArgs e)
        {
            WinFiltro nWinFiltro = new WinFiltro();
            nWinFiltro.ShowDialog();
            voluntario = nWinFiltro.getChosen();
        }

        private void fillGrid()
        {
            DataGridListadoPrestamos.ItemsSource = new _PrestamosLN().obtenerTodosPrestamos();
        }
	}
}