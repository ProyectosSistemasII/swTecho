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
using Capa_Datos;

namespace TechoCeiva
{
	/// <summary>
	/// Lógica de interacción para WinFiltro.xaml
	/// </summary>
	public partial class WinFiltro : Window
	{
        private _Voluntarios chosen { get; set; }
        private Boolean flag { get; set; }

		public WinFiltro()
		{
			this.InitializeComponent();
            this.flag = false;
            fillComboBox();
			// A partir de este punto se requiere la inserción de código para la creación del objeto.
		}

        public void setChosen(_Voluntarios v)
        {
            this.chosen = v;
        }

        public void setIsVolunteerSelected(Boolean b)
        {
            this.flag = b;
        }

        public _Voluntarios getChosen()
        {
            return this.chosen;
        }

        public Boolean isVolunteerSelected()
        {
            return flag;
        }

        private void btnCancelar_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void fillComboBox()
        {
            cbxVoluntario.ItemsSource = new _VoluntariosLN().Obtener_V();
            cbxVoluntario.SelectedValuePath = "idVoluntarios";
            cbxVoluntario.DisplayMemberPath = "nombres";
        }

        private void btnAceptar_Click(object sender, RoutedEventArgs e)
        {
            _Voluntarios elegido = cbxVoluntario.SelectedItem as _Voluntarios;
            this.setChosen(elegido);
            this.setIsVolunteerSelected(true);
            this.Close();
        }
	}
}