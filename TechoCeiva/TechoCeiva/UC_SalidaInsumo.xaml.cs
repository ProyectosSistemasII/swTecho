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
using System.Collections.ObjectModel;
using Capa_Logica;
using Capa_Datos;
using Capa_Logica_Negocio;

namespace TechoCeiva
{
	/// <summary>
	/// Lógica de interacción para UC_SalidaInsumo.xaml
	/// </summary>
	public partial class UC_SalidaInsumo : UserControl

	{
        public UsuarioLN currentUser { get; set; }

        private ObservableCollection<_InsumosLN> detalle = new ObservableCollection<_InsumosLN>();

		public UC_SalidaInsumo()
		{
            this.InitializeComponent();
            fillComboBox();
		}

        private void cbxInsumos_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void btnAgregar_Click(object sender, RoutedEventArgs e)
        {
            if (cbxInsumos.Text.Equals("") || txtCantidad.Text.Equals(""))
            {
                MessageBox.Show("Debe seleccionar un Insumo y asignar una cantidad para agregar", "Error en datos", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                _Insumos seleccion = cbxInsumos.SelectedItem as _Insumos;
                addToGrid(seleccion);
            }
        }

        private void fillComboBox()
        {
            _InsumosLN insumos = new _InsumosLN();
            cbxInsumos.ItemsSource = insumos._Obtener_In();
            cbxInsumos.SelectedValuePath = "idAlimentos";
            cbxInsumos.DisplayMemberPath = "Nombre";

            _Voluntarios voluntario = new _Voluntarios();
            cbxVoluntarios.ItemsSource = voluntario.Obtener_V();
            cbxVoluntarios.SelectedValuePath = "idVoluntario";
            cbxVoluntarios.DisplayMemberPath = "nombres";
        }

        private void actionAdd(int valor)
        {
            _InsumosLN Insumos = new _InsumosLN();
            Insumos._Modificar(this.cbxInsumos.SelectedIndex,int.Parse(txtCantidad.Text));

        }

        private void addToGrid(_Insumos seleccion)
        {
            try
            {
                Boolean correcto = seleccion.verificarExistencia(Convert.ToInt32(txtCantidad.Text));

                if (correcto && seleccion.Existencia > 0)
                {
                    if (Convert.ToInt32(txtCantidad.Text) > 0)
                    {
                        _InsumosLN insumo = new _InsumosLN(seleccion.idAlimentos,seleccion.Nombre, Convert.ToInt32(txtCantidad.Text),seleccion.Rango,seleccion.AnioCaducidad,seleccion.Presentacion_idPresentacion);
                        Boolean existe = insumo.buscarElemento(detalle);

                        if (!existe)
                        {
                            detalle.Add(insumo);
                            dgdDetalle.Items.Add(insumo);
                            txtCantidad.Clear();
                            cbxInsumos.Focus();
                        }
                        else
                        {
                            MessageBox.Show("Ya existe un elemento de este tipo, eliminelo o agrege uno nuevo", "Elemento existente", MessageBoxButton.OK, MessageBoxImage.Warning);
                        }
                    }
                    else
                    {
                        MessageBox.Show("ERROR: No puede prestar una cantidad con valor 0 ó valor netagivo", "Error en préstamo", MessageBoxButton.OK, MessageBoxImage.Error);
                        txtCantidad.Focus();
                        txtCantidad.SelectAll();
                    }
                }
                else
                {
                    MessageBox.Show("No puede prestar más de lo que tiene en inventario", "Error en préstamo", MessageBoxButton.OK, MessageBoxImage.Error);
                    MessageBox.Show(seleccion.Nombre + " tiene " + seleccion.Existencia + " unidades actualmente", "Existencia actual", MessageBoxButton.OK, MessageBoxImage.Information);
                    txtCantidad.Focus();
                    txtCantidad.SelectAll();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ingrese una cantidad válida", "Error en datos", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void btnGuardar_Click(object sender, RoutedEventArgs e)
        {
            Guardar();
            dgdDetalle.Items.Clear();
        }

        private void btnX_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                deleteFromGrid();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ingrese datos válidos", "Error en datos", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void Guardar()
        {
            int idSalida = 0;
            _DetalleSalidaLN detalleSalida = new _DetalleSalidaLN();
            _InsumosLN contenido = new _InsumosLN();
            List<_Insumos> listaInsumos = new List<_Insumos>();
            listaInsumos = contenido.obtenerListado(detalle);

                _SalidaLN datosSalida = new _SalidaLN(DateTime.Today,1,true,Convert.ToString(txtDescripcion.Text));
                Boolean correcto = datosSalida.ingresarSalida();

                if (correcto)
                {
                    //datosSalida._InsertarSalida();
                    _Insumos modificado = new _Insumos();
                    //txtCantidad.Text = Convert.ToString(); 
                    //modificado._Modificar(25, 10000);
   

                 
                    MessageBox.Show("Datos Modificados");
                }
                else
                {
                    MessageBox.Show(datosSalida.obtenerError());
                }
        }
        

        private void deleteFromGrid()
        {
            try
            {
                _InsumosLN eliminar = dgdDetalle.SelectedItem as _InsumosLN;
                detalle = eliminar.eliminarDeColeccion(detalle);
                dgdDetalle.Items.Clear();
                foreach (_InsumosLN h in detalle)
                {
                    dgdDetalle.Items.Add(h);
                }
            }
            catch 
            {
                
            }
        }

        private void btnCancelar_Click(object sender, RoutedEventArgs e)
        {
            dgdDetalle.Items.Clear();
            deleteFromGrid();
        }

	}
}