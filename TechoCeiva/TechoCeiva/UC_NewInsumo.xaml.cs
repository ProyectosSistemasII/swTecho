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
using Capa_Logica;

namespace TechoCeiva
{
	/// <summary>
	/// Lógica de interacción para UC_NewInsumo.xaml
	/// </summary>
	public partial class UC_NewInsumo : UserControl
	{
		public UC_NewInsumo()
		{
			this.InitializeComponent();
            cbxRangoFecha.Items.Add("Enero - Abril");
            cbxRangoFecha.Items.Add("Mayo - Agosto");
            cbxRangoFecha.Items.Add("Septiembre - Diciembre");
            _InsumosLN Insumo = new _InsumosLN();
            fillComboBox();
            fillDataGrid();
            comboBoxInsumos.Focus();
		}

        private void btnSigno_Click(object sender, RoutedEventArgs e)
        {
            WinAddInsumos nform = new WinAddInsumos();
            System.Windows.Forms.Integration.ElementHost.EnableModelessKeyboardInterop(nform);
            nform.ShowDialog();
            fillComboBox();
            fillDataGrid();
        }

        
        private void btnAgregar_Click(object sender, RoutedEventArgs e)
       {

            _PresentacionLN nPresentacion = new _PresentacionLN(Convert.ToString(cmxPresentacion.Text));
            Boolean correcto2 = nPresentacion.Ingresar_Presentacion();

            _InsumosLN nInsumo = new _InsumosLN(Convert.ToString(comboBoxInsumos.Text),Convert.ToInt32(txtCantida.Text),Convert.ToString(cbxRangoFecha.Text),Convert.ToInt32(txtAni.Text),1);
            Boolean correcto = nInsumo.Ingresar_Insumo();
            int verificar = nInsumo.verificarduplicado(Convert.ToString(comboBoxInsumos.Text), Convert.ToString(cbxRangoFecha.Text), Convert.ToInt32(txtAni.Text), 1);
            if (verificar == 0)
            {
                if (correcto & correcto2)
                {
                    nPresentacion._Insertar_P();
                    nInsumo._Insertar_I();
                }
                else
                {
                    MessageBox.Show(nInsumo._Obtener_Error());
                }
                fillDataGrid();

            }
            else
            {
            }
            
        }

        /*{
            _InsumosLN modificar = new _InsumosLN(Convert.ToString(comboBoxInsumos.Text), Convert.ToInt32(txtCantida.Text), Convert.ToString(cbxRangoFecha.Text), Convert.ToInt32(txtAni.Text), cmxPresentacion.SelectedIndex);
            Boolean correcto = modificar.Ingresar_Insumo();
            
            if (correcto)
            {
                
                modificar._Modificar(comboBoxInsumos.SelectedIndex,Convert.ToInt32(txtCantida.Text));

                
            }
            else
            {
                MessageBox.Show(modificar._Obtener_Error());
            }
        }*/

        private void fillComboBox()
        {
            _InsumosLN insumos = new _InsumosLN();
            comboBoxInsumos.ItemsSource = insumos._Obtener_I();
            comboBoxInsumos.SelectedValuePath = "idInsumos";
            comboBoxInsumos.DisplayMemberPath = "Nombre";

            _PresentacionLN presentacion = new _PresentacionLN();
            cmxPresentacion.ItemsSource = presentacion._Obtener_P();
            cmxPresentacion.SelectedValuePath = "idPresentacion";
            cmxPresentacion.DisplayMemberPath = "Nombre";
        }
        private void fillDataGrid()
        {
            _InsumosLN insumos = new _InsumosLN();
            dgInsumos.ItemsSource = insumos._Obtener_I();
        }

        private void actionAdd()
        {
            _InsumosLN Insumos = new _InsumosLN();
            Insumos._Modificar(comboBoxInsumos.SelectedIndex, Convert.ToInt32(txtCantida.Text.ToString()));

            txtCantida.Clear();
            MessageBox.Show("Existencia de " + comboBoxInsumos.Text + " modificada correctamente");
            fillDataGrid();
        }

        private void comboBoxInsumos_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void cbxRangoFecha_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void dgInsumos_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

	}
}