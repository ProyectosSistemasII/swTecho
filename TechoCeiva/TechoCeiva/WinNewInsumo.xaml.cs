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
        public int idPresentacion = 0;
        public DateTime moment = DateTime.Today;
        public bool mod = false;

		public WinNewInsumo()
		{
			this.InitializeComponent();
            
            cbxRangoFecha.Items.Add("Enero - Abril");
            cbxRangoFecha.Items.Add("Mayo - Agosto");
            cbxRangoFecha.Items.Add("Septiembre - Diciembre");
            
            txtAni.Text = Convert.ToString(moment.Year);
            fillComboBox();
			
			// A partir de este punto se requiere la inserción de código para la creación del objeto.
		}

        private void btnAgregar_Click(object sender, RoutedEventArgs e)
        {
            if (comboBoxInsumos.Text == "" || cmxPresentacion.Text == "" || txtCantida.Text == "" || cbxRangoFecha.Text == "" || txtAni.Text == "")
                MessageBox.Show("No se han completado todos los campos", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            else
            {
                _PresentacionLN nPresentacion = new _PresentacionLN(Convert.ToString(cmxPresentacion.Text));
                Boolean correcto2 = false;
                int UltimoID = idPresentacion;
                int verificarPresentacion = nPresentacion.verificarPresentacion(Convert.ToString(cmxPresentacion.Text));

                if (verificarPresentacion == 0 && mod == true)
                {
                    correcto2 = nPresentacion.Actualizar_Presentacion(idPresentacion);
                    if (correcto2)
                        nPresentacion._ActualizarPresentacion(idPresentacion, Convert.ToString(cmxPresentacion.Text));
                }
                else
                {
                    correcto2 = nPresentacion.Ingresar_Presentacion();
                    UltimoID = nPresentacion.devolver_ultimo();
                }

                if (verificarPresentacion == 0 && mod == false)
                {
                    nPresentacion._Insertar_P();
                    UltimoID = nPresentacion.devolver_ultimo();
                    _InsumosLN nInsumo = new _InsumosLN(Convert.ToString(comboBoxInsumos.Text), Convert.ToInt32(txtCantida.Text), Convert.ToString(cbxRangoFecha.Text), Convert.ToInt32(txtAni.Text), UltimoID);
                    Boolean correcto = nInsumo.Ingresar_Insumo();
                    int verificarInsumo = nInsumo.verificarduplicado(Convert.ToString(comboBoxInsumos.Text), Convert.ToString(cbxRangoFecha.Text), Convert.ToInt32(txtAni.Text), UltimoID);


                    if (correcto && correcto2 && mod == false)
                    {
                        if (Convert.ToInt32(txtAni.Text) > Convert.ToInt32(moment.Year) - 1)
                        {
                            nInsumo._Insertar_I();
                            if (MessageBox.Show("Insumo guardado. ¿Desea agregar uno nuevo?", "Guardado Exitoso", MessageBoxButton.YesNo, MessageBoxImage.Information) == MessageBoxResult.No)
                            {
                                this.Close();
                            }
                            else
                            {
                                comboBoxInsumos.Focus();
                                comboBoxInsumos.Focus();
                                comboBoxInsumos.Text = "";
                                cmxPresentacion.Text = "";
                                txtCantida.Text = "";
                                cbxRangoFecha.Text = "";
                                txtAni.Text = "";
                            }
                        }
                        else
                        {
                            MessageBox.Show("Año incorrecto");
                        }

                    }
                    else
                    {
                        MessageBox.Show(nInsumo._Obtener_Error());
                    }

                }
                else
                {
                    if (verificarPresentacion != 0 && mod == false)
                    {
                        UltimoID = nPresentacion.devolver_ultimo();
                        _InsumosLN nInsumo = new _InsumosLN(Convert.ToString(comboBoxInsumos.Text), Convert.ToInt32(txtCantida.Text), Convert.ToString(cbxRangoFecha.Text), Convert.ToInt32(txtAni.Text), UltimoID);
                        Boolean correcto = nInsumo.Ingresar_Insumo();
                        int verificarInsumo = nInsumo.verificarduplicado(Convert.ToString(comboBoxInsumos.Text), Convert.ToString(cbxRangoFecha.Text), Convert.ToInt32(txtAni.Text), UltimoID);
                        if (verificarInsumo != 0)
                            MessageBox.Show("Este registro ya existe", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                        else
                        {

                            if (correcto && correcto2 && mod == false)
                            {
                                if (Convert.ToInt32(txtAni.Text) > Convert.ToInt32(moment.Year) - 1)
                                {
                                    nInsumo._Insertar_I();
                                    if (MessageBox.Show("Insumo guardado. ¿Desea agregar uno nuevo?", "Guardado Exitoso", MessageBoxButton.YesNo, MessageBoxImage.Information) == MessageBoxResult.No)
                                    {
                                        this.Close();
                                    }
                                    else
                                    {
                                        comboBoxInsumos.Focus();
                                        comboBoxInsumos.Text = "";
                                        cmxPresentacion.Text = "";
                                        txtCantida.Text = "";
                                        cbxRangoFecha.Text = "";
                                        txtAni.Text = "";
                                    }
                                }
                                else
                                {
                                    MessageBox.Show("Año incorrecto");
                                }

                            }
                            else
                            {
                                MessageBox.Show(nInsumo._Obtener_Error());
                            }
                        }
                    }
                    else
                    {
                        _InsumosLN nInsumo = new _InsumosLN(Convert.ToString(comboBoxInsumos.Text), Convert.ToInt32(txtCantida.Text), Convert.ToString(cbxRangoFecha.Text), Convert.ToInt32(txtAni.Text), verificarPresentacion);
                        Boolean correcto = nInsumo.Ingresar_Insumo();
                        int verificarInsumo = nInsumo.verificarduplicado(Convert.ToString(comboBoxInsumos.Text), Convert.ToString(cbxRangoFecha.Text), Convert.ToInt32(txtAni.Text), verificarPresentacion);

                        if (verificarInsumo != 0)
                        {
                            nInsumo._ModificarInsumo(verificarInsumo, comboBoxInsumos.Text, Convert.ToInt32(txtCantida.Text), cbxRangoFecha.Text, txtAni.Text);
                            mod = true;
                            MessageBox.Show("Insumo existente Modificado");
                            this.Close();
                        }
                        else
                        {
                            //MessageBox.Show(comboBoxInsumos.SelectedValue.ToString());
                            nInsumo._ModificarInsumo(id, comboBoxInsumos.Text, Convert.ToInt32(txtCantida.Text), cbxRangoFecha.Text, txtAni.Text);
                            mod = true;
                            MessageBox.Show("Insumo existente Modificado");
                            this.Close();
                        }
                        /*
                    else
                    {
                        if (correcto && correcto2 && mod == true)
                        {
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

                    }*/
                    }

                }

            }
        }

        private void fillComboBox()
        {
            _InsumosLN insumos = new _InsumosLN();
            comboBoxInsumos.ItemsSource = insumos._Obtener_Distinto();
            comboBoxInsumos.SelectedValuePath = "idAlimentos";
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