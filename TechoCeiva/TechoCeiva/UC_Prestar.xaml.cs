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
	/// Lógica de interacción para UC_Manage.xaml
	/// </summary>
	public partial class UC_Manage : UserControl
	{
        public UsuarioLN currentUser { get; set; }

        private ObservableCollection<_HerramientasLN> detalle = new ObservableCollection<_HerramientasLN>();
		
        public UC_Manage()
		{
			this.InitializeComponent();
            dpFecha.SelectedDate = DateTime.Now.Date;
            _VoluntariosLN Personas = new _VoluntariosLN();
            _HerramientasLN Tools = new _HerramientasLN();
            fillCboxNombre(Personas);
            fillCboxHerramientas(Tools);
            cbxVoluntario.Focus();
            cbxVoluntario.IsDropDownOpen = true;
            cbxVoluntario.Focus();
		}

        public UC_Manage(UsuarioLN user)
        {
            this.currentUser = user;
        }

        private void fillCboxNombre(_VoluntariosLN Voluntarios)
        {
            cbxVoluntario.ItemsSource = Voluntarios.Obtener_V();
            cbxVoluntario.SelectedValuePath = "idVoluntarios";
            cbxVoluntario.DisplayMemberPath = "nombres";
        }

        private void fillCboxHerramientas(_HerramientasLN Herramientas)
        {
            cbxHerramienta.ItemsSource = Herramientas._Obtener_H();
            cbxHerramienta.SelectedValuePath = "idHerramienta";
            cbxHerramienta.DisplayMemberPath = "Nombre";
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            if (cbxHerramienta.Text.Equals("") || txbxCantidad.Text.Equals(""))
            {
                MessageBox.Show("Debe seleccionar una herramienta y asignar una cantidad para agregar", "Error en datos", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                _Herramientas chosenTool = cbxHerramienta.SelectedItem as _Herramientas;
                addToGrid(chosenTool);
            }
        }

        private void txbxCantidad_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.Key == Key.Enter)
                {
                    _Herramientas chosenTool = cbxHerramienta.SelectedItem as _Herramientas;
                    addToGrid(chosenTool);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ingrese datos válidos","Error en datos",MessageBoxButton.OK,MessageBoxImage.Error);
            }
        }

        private void cbxHerramienta_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
                cbxHerramienta.IsDropDownOpen = true;
        }

        private void cbxVoluntario_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
                cbxVoluntario.IsDropDownOpen = true;
        }

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

        private void btnGuardar_Click(object sender, RoutedEventArgs e)
        {
            saveContent();
        }

        private void addToGrid(_Herramientas chosenTool)
        {
            try
            {
                Boolean correcto = chosenTool.verificarExistencia(Convert.ToInt32(txbxCantidad.Text));

                if (correcto && chosenTool.Existencia > 0)
                {
                    if (Convert.ToInt32(txbxCantidad.Text) > 0)
                    {
                        _HerramientasLN toolForGrid = new _HerramientasLN(chosenTool.idHerramientas, chosenTool.Nombre, Convert.ToInt32(txbxCantidad.Text));
                        Boolean existe = toolForGrid.buscarElemento(detalle);

                        if (!existe)
                        {
                            detalle.Add(toolForGrid);
                            DataGridPrestamo.Items.Add(toolForGrid);
                            txbxCantidad.Clear();
                            cbxHerramienta.Focus();
                        }
                        else
                        {
                            MessageBox.Show("Ya existe un elemento de este tipo, eliminelo o agrege uno nuevo", "Elemento existente", MessageBoxButton.OK, MessageBoxImage.Warning);
                        }
                    }
                    else
                    {
                        MessageBox.Show("ERROR: No puede prestar una cantidad con valor 0 ó valor netagivo", "Error en préstamo", MessageBoxButton.OK, MessageBoxImage.Error);
                        txbxCantidad.Focus();
                        txbxCantidad.SelectAll();
                    }
                }
                else
                {
                    MessageBox.Show("No puede prestar más de lo que tiene en inventario", "Error en préstamo", MessageBoxButton.OK, MessageBoxImage.Error);
                    MessageBox.Show(chosenTool.Nombre + " tiene " + chosenTool.Existencia + " unidades actualmente", "Existencia actual", MessageBoxButton.OK, MessageBoxImage.Information);
                    txbxCantidad.Focus();
                    txbxCantidad.SelectAll();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ingrese una cantidad válida", "Error en datos", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void deleteFromGrid()
        {
            try
            {
                _HerramientasLN toolToDelete = DataGridPrestamo.SelectedItem as _HerramientasLN;
                detalle = toolToDelete.eliminarDeColeccion(detalle);
                DataGridPrestamo.Items.Clear();
                foreach (_HerramientasLN h in detalle)
                {
                    DataGridPrestamo.Items.Add(h);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al borrar datos: Debe seleccionar una herramienta para eliminar", "Error al borrar datos", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void saveContent()
        {
            try
            {
                _Voluntarios voluntario = cbxVoluntario.SelectedItem as _Voluntarios;
                _PrestamosLN datosPrestamo = new _PrestamosLN(currentUser.idUsuarios, voluntario.idVoluntarios, Convert.ToDateTime(dpFecha.SelectedDate), txtObservaciones.Text);
                Boolean correcto = datosPrestamo.ingresarPrestamo();

                if (correcto)
                {
                    datosPrestamo._InsertarPrestamo();
                }
                else
                {
                    MessageBox.Show(datosPrestamo.obtenerError());
                }

                int idPrestamo = datosPrestamo.ultimaInsercion();
                _HerramientasLN contenido = new _HerramientasLN();
                contenido.guardarElementos(detalle, idPrestamo);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Debe completar la información para poder guardar", "Cuidado", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }
	}
}