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
using System.Windows.Shapes;
using Capa_Logica;

namespace TechoCeiva
{
	/// <summary>
	/// Lógica de interacción para WinNewInsumo.xaml
	/// </summary>
	public partial class WinNewInsumo : Window
	{
        public int id = 0;

		public WinNewInsumo()
		{
			this.InitializeComponent();
            cbxRangoFecha.Items.Add("Enero - Abril");
            cbxRangoFecha.Items.Add("Mayo - Agosto");
            cbxRangoFecha.Items.Add("Septiembre - Diciembre");
            fillComboBox();
			
			// A partir de este punto se requiere la inserción de código para la creación del objeto.
		}

        private void btnAgregar_Click(object sender, RoutedEventArgs e)
        {
            _PresentacionLN nPresentacion = new _PresentacionLN(Convert.ToString(cmxPresentacion.Text));
            Boolean correcto2 = nPresentacion.Ingresar_Presentacion();

            _InsumosLN nInsumo = new _InsumosLN(Convert.ToString(comboBoxInsumos.Text),Convert.ToInt32(txtCantida.Text),Convert.ToString(cbxRangoFecha.Text),Convert.ToInt32(txtAni.Text),1);
            Boolean correcto = nInsumo.Ingresar_Insumo();
            Boolean verificar = nInsumo.verificarduplicado(Convert.ToString(comboBoxInsumos.Text), Convert.ToString(cbxRangoFecha.Text), Convert.ToInt32(txtAni.Text), 1);
            if (verificar)
            {
                if (correcto & correcto2)
                {
                    nPresentacion._Insertar_P();
                    nInsumo._Insertar_I();
                    if (MessageBox.Show("Insumo guardado. ¿Desea agregar uno nuevo?", "Guardado Exitoso", MessageBoxButton.YesNo, MessageBoxImage.Information) == MessageBoxResult.No)
                    {
                        this.Close();
                    }
                    else
                    {
                        comboBoxInsumos.Focus();
                    }
                }
                else
                {
                    MessageBox.Show(nInsumo._Obtener_Error());
                }
                
            }
            else
            {
            }
            
        }

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

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
	}
}