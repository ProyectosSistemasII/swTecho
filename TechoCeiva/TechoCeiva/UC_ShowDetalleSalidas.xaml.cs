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
using Capa_Datos;
using Capa_Logica;

namespace TechoCeiva
{
	/// <summary>
	/// Lógica de interacción para UC_ShowDetalleSalidas.xaml
	/// </summary>
	public partial class UC_ShowDetalleSalidas : UserControl
	{
        private int idSalida { get; set; }
        private string name { get; set; }
        private DateTime date { get; set; }

		public UC_ShowDetalleSalidas()
		{
			this.InitializeComponent();
		}

        public UC_ShowDetalleSalidas(int id, DateTime fecha, string nombreVol)
        {
            this.InitializeComponent();
            this.idSalida = id;
            this.date = fecha;
            lblNombre.Content = "Salidas por " + nombreVol + " con fecha " + this.date.ToShortDateString();
            fillGrid();
        }

        private void fillGrid()
        {
            dgDetalleSalidas.ItemsSource = new _DetalleSalida().buscarDetallesPor(this.idSalida);
        }

        private void dgDetalleSalidas_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            showWinModify();
        }

        private void showWinModify()
        {
            try
            {
                _DetalleSalida detalle = dgDetalleSalidas.SelectedItem as _DetalleSalida;
                WinModifyInsumos nModificarS = new WinModifyInsumos();
                nModificarS.txAlimento.Text = detalle.NombreAlimento;
                nModificarS.txtCantidad.Text = detalle.Cantidad.ToString();
                nModificarS.ShowDialog();

                if (nModificarS.getIsClose())
                {
                    saveContent(detalle, nModificarS);
                    fillGrid();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void saveContent(_DetalleSalida varDetalle, WinModifyInsumos win)
        {
            int cantN = win.getCantidad();
            int cant = varDetalle.Cantidad;
            if (varDetalle.Cantidad > win.getCantidad())
            {
                cant = cant - cantN;
                varDetalle.Devolver(cant, cantN, varDetalle.idDetalleSalida, varDetalle.Alimentos_idAlimentos);
            }
            if (varDetalle.Cantidad < win.getCantidad())
            {
                cant = cantN - cant;
                varDetalle.Sacar(cant, cantN, varDetalle.idDetalleSalida, varDetalle.Alimentos_idAlimentos);
            }
        }
	}
}