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
        private Boolean isClose { get; set; }

		public WinDevolverHelp()
		{
            /*
            txtBuenEstado.Text = "0";
            txtDañadas.Text = "0";
            txtPerdidas.Text = "0";
            txtPendientes.Text = "0";
             * */

			this.InitializeComponent();
            this.damaged = 0;
            this.lost = 0;
            this.pending = 0;
            this.goodState = 0;
            this.isClose = false;
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

        private void setIsClose(Boolean close)
        {
            this.isClose = close;
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

        public Boolean getIsClose()
        {
            return this.isClose;
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

        private void txtDañadas_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                verificar(1);
                update(1);
            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.Message);
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

        private void txtPerdidas_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                verificar(2);
                update(2);
            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.Message);
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

        private void txtPendientes_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                verificar(3);
                update(3);
            }
            catch (Exception ex)
            {
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
            setIsClose(true);
            this.Close();
        }

        private void verificar(int caseSwitch)
        {
            try
            {
                        if (txtDañadas.Text == "" || txtDañadas.Text.Equals(null))
                            txtDañadas.Text = "0";
                         if (txtPerdidas.Text.Equals(null))
                             txtPerdidas.Text = "0";
                        if (txtPendientes.Text.Equals(null) || txtPendientes.Text == "")
                            txtPendientes.Text = "0";
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void update(int caseSwitch)
        {
            int flag = 0;
            try
            {
                switch (caseSwitch)
                {
                    case 1:
                        flag = 1;
                        operar(Convert.ToInt32(txtCantidad.Text), Convert.ToInt32(txtDañadas.Text), Convert.ToInt32(txtPerdidas.Text), Convert.ToInt32(txtPendientes.Text), 1);
                        break;
                    case 2:
                        flag = 2;
                        operar(Convert.ToInt32(txtCantidad.Text), Convert.ToInt32(txtDañadas.Text), Convert.ToInt32(txtPerdidas.Text), Convert.ToInt32(txtPendientes.Text), 2);
                        break;
                    case 3:
                        flag = 3;
                        operar(Convert.ToInt32(txtCantidad.Text), Convert.ToInt32(txtDañadas.Text), Convert.ToInt32(txtPerdidas.Text), Convert.ToInt32(txtPendientes.Text), 3);
                        break;
                }
                flag = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

                switch (flag)
                {
                    case 1:
                        flag = 0;
                        txtDañadas.SelectAll();
                        break;
                    case 2:
                        flag = 0;
                        txtPerdidas.SelectAll();
                        break;
                    case 3:
                        flag = 0;
                        txtPendientes.SelectAll();
                        break;
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="val1">txtCantidad</param>
        /// <param name="val2">txtDañadas</param>
        /// <param name="val3">txtPerdidas</param>
        /// <param name="val4">txtPendientes</param>
        /// <param name="caseSwitch">para saber en que txt se encuentran. Esto ayuda al focus</param>
        private void operar(int val1, int val2, int val3, int val4, int caseSwitch)
        {
            try
            {
                if ((val1 - val2 - val3 - val4) >= 0)
                    txtBuenEstado.Text = Convert.ToString(val1 - val2 - val3 - val4);
                else
                {
                    MessageBox.Show("La cantidad en herramientas en buen estado no puede ser negativa", "Cuidado", MessageBoxButton.OK, MessageBoxImage.Warning);

                    switch (caseSwitch)
                    {
                        case 1:
                            txtDañadas.SelectAll();
                            break;
                        case 2:
                            txtPerdidas.SelectAll();
                            break;
                        case 3:
                            txtPendientes.SelectAll();
                            break;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void save()
        {
            setDamaged(Convert.ToInt32(txtDañadas.Text));
            setLost(Convert.ToInt32(txtPerdidas.Text));
            setPending(Convert.ToInt32(txtPendientes.Text));
            setGoogState(Convert.ToInt32(txtBuenEstado.Text));
        }
	}
}