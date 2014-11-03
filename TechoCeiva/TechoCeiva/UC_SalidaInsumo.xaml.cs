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
        private int existenciaActual { get; set; }

        private ObservableCollection<_InsumosLN> detalle = new ObservableCollection<_InsumosLN>();

        public UC_SalidaInsumo()
        {
            this.InitializeComponent();
            fillComboBox();
        }

        /*
         * Con este metodo obtengo el id del usuario que esta logueado
         */
        public UC_SalidaInsumo(UsuarioLN user)
        {
            this.InitializeComponent();
            this.currentUser = user;
            fillComboBox();
            cbxVoluntarios.IsDropDownOpen = true;
            cbxVoluntarios.Focus();
        }

        public void setUser(UsuarioLN user)
        {
            this.currentUser = user;
        }

        private void cbxInsumos_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            updateExistencia();
        }

        // Se despliega cuanto hay de existencia para cada alimento
        private void updateExistencia()
        {
            if (cbxInsumos.SelectedIndex != -1)
            {
                _Insumos chosenI = cbxInsumos.SelectedItem as _Insumos;
                lblExistencia.Content = chosenI.Existencia + " unidades actualmente";
            }
            else
                lblExistencia.Content = "";
        }

        private void fillComboBox()
        {
            _Insumos insumos = new _Insumos();
            cbxInsumos.ItemsSource = insumos._Obtener_In();
            cbxInsumos.SelectedValuePath = "idAlimentos";
            cbxInsumos.DisplayMemberPath = "Nombre";

            _Voluntarios voluntario = new _Voluntarios();
            cbxVoluntarios.ItemsSource = voluntario.Obtener_V();
            cbxVoluntarios.SelectedValuePath = "idVoluntario";
            cbxVoluntarios.DisplayMemberPath = "nombres";
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
                        _InsumosLN insumo = new _InsumosLN(seleccion.idAlimentos, seleccion.Nombre, Convert.ToInt32(txtCantidad.Text), seleccion.Rango, seleccion.AnioCaducidad, seleccion.Presentacion_idPresentacion);
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

        /*
         * Método para guardar el detalle como la salida del alimento y actualizar su existencia
         */ 
        private void Guardar()
        {
            int idSalida = 0;
            _DetalleSalidaLN detalleSalida = new _DetalleSalidaLN();
            _InsumosLN contenido = new _InsumosLN();
            List<_Insumos> listInsumos = new List<_Insumos>();
            listInsumos = contenido.obtenerListado(detalle);
            try
            {
                _Voluntarios voluntario = cbxVoluntarios.SelectedItem as _Voluntarios;
                _SalidaLN datosSalida = new _SalidaLN(DateTime.Now.Date, currentUser.idUsuarios, 0, txtDescripcion.Text, voluntario.idVoluntarios);
                Boolean correcto = datosSalida.ingresarSalida();
                if (correcto)
                {
                    idSalida = datosSalida._InsertarSalida();
                    detalleSalida.insertarDetalle(listInsumos, idSalida);
                    MessageBox.Show("Salida de insumos exitosa, generando reporte", "Éxito", MessageBoxButton.OK, MessageBoxImage.Information);
                    //if (MessageBox.Show("Salida exitosa, ¿Desea imprimir reporte?", "Éxito", MessageBoxButton.YesNo, MessageBoxImage.Information) == MessageBoxResult.Yes)
                    //{
                        //Generar reporte
                        frmReportesSalidas MostrarRpt = new frmReportesSalidas();
                        MostrarRpt.idSalida = idSalida;
                        MostrarRpt.ShowDialog();
                    //}
                    clearContent();
                    fillComboBox();
                    correcto = false;
                    detalle = new ObservableCollection<_InsumosLN>();
                }
                else
                {
                    MessageBox.Show(datosSalida.obtenerError());
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Debe completar la información para poder guardar", "Cuidado", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        private void clearContent()
        {
            dgdDetalle.Items.Clear();
            txtDescripcion.Clear();
            txtCantidad.Clear();
            cbxVoluntarios.SelectedIndex = -1;
            cbxInsumos.SelectedIndex = -1;
            cbxVoluntarios.IsDropDownOpen = true;
            cbxVoluntarios.IsEditable = true;
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

        /*
         * Cancelar toda la salida de alimentos
         */ 
        private void btnCancelar_Click(object sender, RoutedEventArgs e)
        {
            dgdDetalle.Items.Clear();
            deleteFromGrid();
        }

        /*
         * Para agregar una salida de alimento en el datagrid
         */ 
        private void btnAdd_Click(object sender, RoutedEventArgs e)
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

        /*
         * Para eliminar una salida de alimento en el datagrid
         */ 
        private void btnQuit_Click(object sender, RoutedEventArgs e)
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
    }
}