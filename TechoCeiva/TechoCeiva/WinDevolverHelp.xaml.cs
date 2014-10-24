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

namespace TechoCeiva
{
	/// <summary>
	/// Lógica de interacción para WinDevolverHelp.xaml
	/// </summary>
	public partial class WinDevolverHelp : Window
	{
        private int damaged { get; set; }
        private int lost { get; set; }
        private int pending { get; set; }
        private int goodState { get; set; }

		public WinDevolverHelp()
		{
			this.InitializeComponent();
            txtDañadas.Focus();
            txtDañadas.SelectAll();
		}

        private void setDamaged(int Damaged)
        {
            this.damaged = Damaged;
        }

        private void setLost(int Lost)
        {
            this.lost = Lost;
        }

        private void setPending(int Pending)
        {
            this.pending = Pending;
        }

        private void setGoogState(int GoodState)
        {
            this.goodState = GoodState;
        }

        public int getDamaged()
        {
            return this.damaged;
        }
        public int getLost()
        {
            return this.lost;
        }

        public int getPending()
        {
            return this.pending;
        }

        public int getGoodState()
        {
            return this.goodState;
        }

        private void btnCancelar_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void txtDañadas_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                verificar(1);
                update(1);
                txtPerdidas.Focus();
                txtPerdidas.SelectAll();
            }
        }

        private void txtPerdidas_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                verificar(2);
                update(2);
                txtPendientes.Focus();
                txtPendientes.SelectAll();
            }
        }

        private void txtPendientes_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                verificar(3);
                update(3);
                btnAceptar.Focus();
            }
        }

        private void txtBuenEstado_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                btnAceptar.Focus();
            }
        }

        private void btnAceptar_Click(object sender, RoutedEventArgs e)
        {
            save();
            this.Close();
        }

        private void verificar(int caseSwitch)
        {
            try
            {
                switch (caseSwitch)
                {
                    case 1:
                        if (txtDañadas.Text == "")
                            txtDañadas.Text = "0";
                        break;
                    case 2:
                        if (txtPerdidas.Text == "")
                            txtPerdidas.Text = "0";
                        break;
                    case 3:
                        if (txtPendientes.Text == "")
                            txtPendientes.Text = "0";
                        break;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void update(int caseSwitch)
        {
            try
            {
                switch (caseSwitch)
                {
                    case 1:
                        operar(Convert.ToInt32(txtBuenEstado.Text), Convert.ToInt32(txtDañadas.Text));
                        break;
                    case 2:
                        operar(Convert.ToInt32(txtBuenEstado.Text), Convert.ToInt32(txtPerdidas.Text));
                        break;
                    case 3:
                        operar(Convert.ToInt32(txtBuenEstado.Text), Convert.ToInt32(txtPendientes.Text));
                        break;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void operar(int val1, int val2)
        {
            if ((val1 - val2) >= 0)
            {
                txtBuenEstado.Text = Convert.ToString(val1 - val2);
            }
            else
                MessageBox.Show("La cantidad en herramientas en buen estado no puede ser negativa", "Cuidado", MessageBoxButton.OK, MessageBoxImage.Warning);
        }

        private void save()
        {
            setDamaged(Convert.ToInt32(txtDañadas.Text));
            setLost(Convert.ToInt32(txtPerdidas.Text));
            setPending(Convert.ToInt32(txtPendientes.Text));
            setGoogState(Convert.ToInt32(txtBuenEstado));
        }
	}
}