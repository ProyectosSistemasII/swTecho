using Capa_Logica;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace TechoCeiva
{
    public partial class frmEncuesta : Form
    {   // variables para que no deje error los combobox cuando estan vacios cuando la pregunta
        //salta o otras dejan algunas vacios Seccion 9 
        String cbxS9_Propiotxt = "";
        String cbxS9_Propietariotxt = "";
        String cbxS9_TipoPropietariotxt = "";
        String cbxS9_OtraPropiedadtxt = "";
       ///---------------------------------------------------------------------------------------------------------
        // variables para que no deje error los combobox cuando estan vacios Seccion 11
        String cbxS11_1_VidaFamiliartxt= "";
        String cbxS11_4_ViviedaActualtxt= "";
        /// -----------------------------------------------------------------------------------------------------------
       
        Int32 CodigoEncuesta { get; set; }
        public frmEncuesta()
        {
            InitializeComponent();
            CodigoEncuesta = 1;

        }

        private void pbS11_Siguiente_Click(object sender, EventArgs e)
        {
            this.VerificarCombobox_S11();            
            S11_MovilidadLN S11 = new S11_MovilidadLN(cbxS11_1_VidaFamiliartxt, txtS11_2_DireccionPasada.Text, txtS11_3a_AñoTraslado.Text, txtS11_3b_Porque.Text, cbxS11_4_ViviedaActualtxt, txt_S11_ComentarioFinal.Text, this.CodigoEncuesta);
            Boolean correcto = S11.Ingresar_S11();
            if (correcto)
            {
                DialogResult pregunta = MessageBox.Show("Desea Ingresar una nueva Encuesta?", "Pregunta!", MessageBoxButtons.YesNo);
                if (pregunta == DialogResult.Yes)
                {
                    tbpS11.Parent = null;
                    tbpInfo.Parent = tbcDatos;
                }
                else if (pregunta == DialogResult.No)
                    this.Close();
            }
            else
            {
                MessageBox.Show(S11.obtenerError().mensaje);
                int cant =  S11.errores.Count -1;

                for (int i= cant; i >=0; i--)
                    this.Comprobar_S11(S11.errores[i].NumeroPregunta);
            }
        }
      
        public void Comprobar_S11(int pregunta)
        {
            switch (pregunta)
            {
                case 1:
                    cbxS11_1_VidaFamiliar.BackColor = Color.Red;
                    cbxS11_1_VidaFamiliar.Focus();
                    break;
                case 2:
                    txtS11_2_DireccionPasada.BackColor = Color.Red;
                        txtS11_2_DireccionPasada.Focus();
                    break;     
                case 3:
                        txtS11_3a_AñoTraslado.BackColor = Color.Red;
                        txtS11_3a_AñoTraslado.Focus();
                    break;
                case 301:
                        txtS11_3b_Porque.BackColor = Color.Red;
                        txtS11_3b_Porque.Focus();
                    break;
                case 4:
                        cbxS11_4_ViviedaActual.BackColor = Color.Red;
                        cbxS11_4_ViviedaActual.Focus();
                    break;
                case 5:
                    txt_S11_ComentarioFinal.BackColor = Color.Red;
                        txt_S11_ComentarioFinal.Focus();
                        break;
            }
            
        }
        public void VerificarCombobox_S11()
        {
            //comprobar cada combox si no estan vacios
            if (cbxS11_1_VidaFamiliar.SelectedIndex != -1)
                cbxS11_1_VidaFamiliartxt = cbxS11_1_VidaFamiliar.SelectedItem.ToString();
            if (cbxS11_4_ViviedaActual.SelectedIndex != -1)
                cbxS11_4_ViviedaActualtxt = cbxS11_4_ViviedaActual.SelectedItem.ToString();
        }

        private void pbS10Cont_Siguiente_Click(object sender, EventArgs e)
        {

            S11_MovilidadLN S11 = new S11_MovilidadLN();
            Boolean correcto = true; //S11.Ingresar_EncS11(Convert.ToInt32(txtCodigoS11.Text), cbxS11_1_VidaFamiliar.SelectedValue.ToString(), txtS11_2_DireccionPasada.Text, txtS11_3a_AñoTraslado.Text, txtS11_3b_Porque.Text, cbxS11_4_ViviedaActual.SelectedValue.ToString(), txt_S11_ComentarioFinal.Text, this.CodigoEncuesta);
            if (correcto)
            {
                MessageBox.Show("Ingresado Correctamente");
                tbpS10Cont.Parent = null;
                tbpS11.Parent = tbcDatos;
                cbxS11_1_VidaFamiliar.SelectedValue = 0;
                cbxS11_4_ViviedaActual.SelectedValue = 0;
            }
            else
            {
               // MessageBox.Show(S11.obtenerError());
            }

        }
       
        private void pbS10_Siguiente_Click(object sender, EventArgs e)
        {
            S9_PropiedadLN S10 = new S9_PropiedadLN();
            Boolean correcto = true;//S10.Insertar_EncS9(0, cbxS9_1_Propio.SelectedValue.ToString(), cbxS9_Propietario.SelectedValue.ToString(), txtS9_OtroPropietario.Text, cbxS9_TipoPropietario.SelectedValue.ToString(), txtS9_OtroTipoPropietario.Text, txtS9_PropietarioTerreno.Text, txtS9_TelefonoPropietarioTerreno.Text, ckbS9_NSNR.Checked.ToString(), cbxS9_OtraPropiedad.SelectedValue.ToString(), txtS9_OtraPropiedadA.Text, txtS9_OtraPropiedadB.Text, txtS9_OtraPropiedadC.Text, this.CodigoEncuesta);
            if (correcto)
            {
                MessageBox.Show("Ingresado Correctamente");
                tbpS10.Parent = null;
                tbpS10Cont.Parent = tbcDatos;
            }
            else
            {
               // MessageBox.Show(S10.obtenerError());
            }
        }

        private void pbS9_Siguiente_Click(object sender, EventArgs e)
        {
            int caso = this.VerificarCombox_S9();
            S9_PropiedadLN S9 ;
            if (caso == 1)
                S9 = new S9_PropiedadLN(cbxS9_Propiotxt, cbxS9_Propietariotxt, txtS9_OtroPropietario.Text, cbxS9_OtraPropiedadtxt, txtS9_OtraPropiedadA.Text, txtS9_OtraPropiedadB.Text, txtS9_OtraPropiedadC.Text, this.CodigoEncuesta);
            else 
                S9 = new S9_PropiedadLN(cbxS9_Propiotxt, cbxS9_TipoPropietariotxt, txtS9_OtroTipoPropietario.Text, txtS9_PropietarioTerreno.Text, txtS9_TelefonoPropietarioTerreno.Text, ckbS9_NSNR.Checked.ToString(), cbxS9_OtraPropiedadtxt, txtS9_OtraPropiedadA.Text, txtS9_OtraPropiedadB.Text, txtS9_OtraPropiedadC.Text, this.CodigoEncuesta);
            
            Boolean correcto = S9.Insertar_EncS9(caso);
            if (correcto)
            {
                MessageBox.Show("Ingresado Correctamente");
                //tbpS9.Parent = null;
                //tbpS10.Parent = tbcDatos;
            }

            else
            {
                MessageBox.Show(S9.obtenerError().mensaje);
                int cant = S9.errores.Count - 1;

                for (int i = cant; i >= 0; i--)
                    this.Comprobar_S9(S9.errores[i].NumeroPregunta);
            }
        
            
        }
        private void Comprobar_S9(int pregunta) 
        {
            switch (pregunta)
            {
                case 1:
                    cbxS9_1_Propio.BackColor = Color.Red;
                    cbxS9_1_Propio.Focus();
                    break;
                case 2:
                    cbxS9_Propietario.BackColor = Color.Red;
                    cbxS9_Propietario.Focus();
                    break;
                case 201:
                    txtS9_OtroPropietario.BackColor = Color.Red;
                    txtS9_OtroPropietario.Focus();
                    break;
                case 5:
                    cbxS9_OtraPropiedad.BackColor = Color.Red;
                    cbxS9_OtraPropiedad.Focus();
                    break;

                case 501:
                    txtS9_OtraPropiedadA.BackColor = Color.Red;
                    txtS9_OtraPropiedadA.Focus();
                    break;

                case 3:
                    cbxS9_TipoPropietario.BackColor = Color.Red;
                    cbxS9_TipoPropietario.Focus();
                    break;

                case 301:
                    txtS9_OtroTipoPropietario.BackColor = Color.Red;
                    txtS9_OtroTipoPropietario.Focus();
                    break;

                case 4:
                    txtS9_PropietarioTerreno.BackColor = Color.Red;
                    txtS9_PropietarioTerreno.Focus();
                    break;
                case 401:
                    txtS9_TelefonoPropietarioTerreno.BackColor = Color.Red;
                    txtS9_TelefonoPropietarioTerreno.Focus();
                    break;
            }
        }

        public int VerificarCombox_S9()
        {   int NumeroCaso=0;         

                if (cbxS9_1_Propio.SelectedIndex != -1)
                    cbxS9_Propiotxt = cbxS9_1_Propio.SelectedItem.ToString();

                if (cbxS9_Propietario.SelectedIndex !=-1)
                {
                    cbxS9_Propietariotxt = cbxS9_Propietario.SelectedItem.ToString();
                    NumeroCaso = 1;
                }
                if (cbxS9_TipoPropietario.SelectedIndex != -1)
                {
                    cbxS9_TipoPropietariotxt = cbxS9_TipoPropietario.SelectedItem.ToString();
                    
                }
                if (cbxS9_OtraPropiedad.SelectedIndex != -1)
                    cbxS9_OtraPropiedadtxt = cbxS9_OtraPropiedad.SelectedItem.ToString();
                if(cbxS9_1_Propio.SelectedIndex == 1)
                    NumeroCaso = 2;
                else
                    NumeroCaso = 1;

            return NumeroCaso;
        }
        private void pbS8_Siguiente_Click(object sender, EventArgs e)
        {
            S8_ServiciosLN S8 = new S8_ServiciosLN();
            Boolean correcto = true;//S8.Insertar_EncuS8(Convert.ToInt32(txtS8_CodigoS8.Text),txtS8_
            if (correcto)
            {
                MessageBox.Show("Ingresado Correctamente");
                tbpS8.Parent = null;
                tbpS9.Parent = tbcDatos;
            }
            else
            {
                MessageBox.Show(S8.obtenerError());
            }
        }
        private void cbxS9_Propietario_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbxS9_Propietario.SelectedIndex.Equals(3))
                txtS9_OtroPropietario.Enabled = true;
            else
                txtS9_OtroPropietario.Enabled = false;
        }

        private void cbxS9_TipoPropietario_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbxS9_TipoPropietario.SelectedIndex.Equals(4))
                txtS9_OtroTipoPropietario.Enabled = true;
            else
                txtS9_OtroTipoPropietario.Enabled = false;
        }

        private void cbxS9_OtraPropiedad_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbxS9_OtraPropiedad.SelectedIndex.Equals(0))
            {
                txtS9_OtraPropiedadA.Enabled = true;
                txtS9_OtraPropiedadB.Enabled = true;
                txtS9_OtraPropiedadC.Enabled = true;
            }
            else
            {
                txtS9_OtraPropiedadA.Enabled = false;
                txtS9_OtraPropiedadB.Enabled = false;
                txtS9_OtraPropiedadC.Enabled = false;
            }
        }

        private void cbxS8_FuenteAgua_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbxS8_FuenteAgua.SelectedIndex.Equals(7))
                txtS8_OtraFuente.Enabled = true;
            else
                txtS8_OtraFuente.Enabled = false;
        }

        private void cbxS8_EnergiaElectrica_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbxS8_EnergiaElectrica.SelectedIndex.Equals(5))
                txtS8_OtraEnergiaElectrica.Enabled = true;
            else
                txtS8_OtraEnergiaElectrica.Enabled = false;
        }

        private void cbxS8_EnergiaCocina_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbxS8_EnergiaCocina.SelectedIndex.Equals(5))
                txtS8_OtraEnergiaCocina.Enabled = true;
            else
                txtS8_OtraEnergiaCocina.Enabled = false;
        }

        private void cbxS8_Sanitario_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbxS8_Sanitario.SelectedIndex.Equals(4))
                txtS8_OtroTipoSanitario.Enabled = true;
            else
                txtS8_OtroTipoSanitario.Enabled = false;
        }

        private void cbxS8_BasuraHogar_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbxS8_BasuraHogar.SelectedIndex.Equals(5))
                txtS8_OtroTipoBasura.Enabled = true;
            else
                txtS8_OtroTipoBasura.Enabled = false;
        }

        private void cbxS10_RelacionVecinos_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbxS10_RelacionVecinos.SelectedIndex.Equals(5))
                txtS10_CometarioRelacion.Enabled = false;
            else
                txtS10_CometarioRelacion.Enabled = true;
        }

        private void cbxS10_OrganizarVecinos_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbxS10_OrganizarVecinos.SelectedIndex.Equals(0))
            {
                txtS10_OrganizarA.Enabled = true;
                txtS10_OrganizarB.Enabled = true;
                txtS10_OrganizarC.Enabled = true;
            }
            else
            {
                txtS10_OrganizarA.Enabled = false;
                txtS10_OrganizarB.Enabled = false;
                txtS10_OrganizarC.Enabled = false;
            }
        }

        private void cbxS10_Necesidad_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbxS10_Necesidad.SelectedIndex.Equals(0))
            {
                txtS10_NecesidadA.Enabled = true;
                txtS10_NecesidadB.Enabled = true;
                txtS10_NecesidadC.Enabled = true;
            }
            else
            {
                txtS10_NecesidadA.Enabled = false;
                txtS10_NecesidadB.Enabled = false;
                txtS10_NecesidadC.Enabled = false;
            }
        }

        private void cbxS10_NecesidadCom_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbxS10_NecesidadCom.SelectedIndex.Equals(0))
            {
                txtS10_NecesidadComA.Enabled = true;
                txtS10_NecesidadComB.Enabled = true;
                txtS10_NecesidadComC.Enabled = true;
            }
            else
            {
                txtS10_NecesidadComA.Enabled = false;
                txtS10_NecesidadComB.Enabled = false;
                txtS10_NecesidadComC.Enabled = false;
            }
        }

        private void cbxS10_ProyectosVecinos_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbxS10_ProyectosVecinos.SelectedIndex.Equals(0))
            {
                txtS10_ProyectosVecinosA.Enabled = true;
                txtS10_ProyectosVecinosB.Enabled = true;
                txtS10_ProyectosVecinosC.Enabled = true;
            }
            else
            {
                txtS10_ProyectosVecinosA.Enabled = false;
                txtS10_ProyectosVecinosB.Enabled = false;
                txtS10_ProyectosVecinosC.Enabled = false;
            }
        }

        private void cbxS10_Discriminacion_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbxS10_Discriminacion.SelectedIndex.Equals(0))
                txtS10_TipoDiscriminacion.Enabled = true;
            else
                txtS10_TipoDiscriminacion.Enabled = false;
        }

        private void cbxS10_ConfiazaOrganizacion_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(cbxS10_ConfiazaOrganizacion.SelectedIndex.Equals(2))
                txtS10_ComentarioConfianza.Enabled=false;
            else
                txtS10_ComentarioConfianza.Enabled=true;
        }

        private void cbxS10_EstadoPasado_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbxS10_EstadoPasado.SelectedIndex.Equals(3))
                txtS10_ComentarioEstadoPasado.Enabled = false;
            else
                txtS10_ComentarioEstadoPasado.Enabled = true;
        }

        private void cbxS10_estadoFuturo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbxS10_estadoFuturo.SelectedIndex.Equals(3))
                txtS10_ComentarioEstadoFuturo.Enabled = false;
            else
                txtS10_ComentarioEstadoFuturo.Enabled = true;
        }

        private void cbxS6_1_IngEstado_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbxS6_1_IngEstado.SelectedIndex.Equals(0))
            {
                lblS6_1_QEstado.Enabled = true;
                txtS6_1_CantidadIngEstado.Enabled = true;
            }
            else
            {
                lblS6_1_QEstado.Enabled = false;
                txtS6_1_CantidadIngEstado.Enabled = false;
            }
        }

        private void cbxS6_2_IngRemesas_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbxS6_2_IngRemesas.SelectedIndex.Equals(0))
            {
                lblS6_2_QRemesas.Enabled = true;
                txtS6_2_CantidadRemesas.Enabled = true;
            }
            else
            {
                lblS6_2_QRemesas.Enabled = false;
                txtS6_2_CantidadRemesas.Enabled = false;
            }
        }

        private void btnS6_Siguiente_Click(object sender, EventArgs e)
        {
            S6_IngresosLN S6 = new S6_IngresosLN();
            Boolean correcto = true;//S6.Insertar_IngreS6(Convert.ToInt32(txtS8_CodigoS8.Text),txtS8_
            if (correcto)
            {
                MessageBox.Show("Ingresado Correctamente");
            }
            else
            {
                MessageBox.Show(S6.obtenerError());
            }
        }

        private void cbsS7_5_ProbViv_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbsS7_5_ProbViv.SelectedIndex.Equals(0))
            {
                lblS7_5_A.Enabled = true;
                lblS7_5_B.Enabled = true;
                lblS7_5_C.Enabled = true;
                txtS7_5_ProblemaA.Enabled = true;
                txtS7_5_ProblemaB.Enabled = true;
                txtS7_5_ProblemaC.Enabled = true;
            }
            else
            {
                lblS7_5_A.Enabled = false;
                lblS7_5_B.Enabled = false;
                lblS7_5_C.Enabled = false;
                txtS7_5_ProblemaA.Enabled = false;
                txtS7_5_ProblemaB.Enabled = false;
                txtS7_5_ProblemaC.Enabled = false;
            }
        }

        private void btnS7_Siguiente_Click(object sender, EventArgs e)
        {
            S7_ViviendaLN S7 = new S7_ViviendaLN();
            Boolean correcto = true;//S7.Insertar_IngreS6(Convert.ToInt32(txtS8_CodigoS8.Text),txtS8_
            if (correcto)
            {
                MessageBox.Show("Ingresado Correctamente");
                tbpS7.Parent = null;
                tbpS8.Parent = tbcDatos;
            }
            else
            {
                MessageBox.Show(S7.obtenerError());
            }
        }
        //seccion 5
        private void pbS5_Siguiente_Click(object sender, EventArgs e)
        {
            S5_TrabajoLN S5 = new S5_TrabajoLN();
            Boolean correcto = true;//S5.Insertar_EncuS5(Convert.ToInt32(txtS8_CodigoS8.Text),txtS8_
            if (correcto)
            {
                MessageBox.Show("Ingresado Correctamente");
                tbpS5.Parent = null;
                tbpS6.Parent = tbcDatos;
            }
            else
            {
                MessageBox.Show(S5.obtenerError());
            }
        }

        private void pbS6_Siguiente_Click(object sender, EventArgs e)
        {
            S6_IngresosLN S6 = new S6_IngresosLN();
            Boolean correcto = true;// S6.Insertar_EncuS6(cbxS6_1_IngEstado.Text, Convert.ToInt32(txtS6_1_CantidadIngEstado.Text), cbxS6_2_IngRemesas.Text, Convert.ToInt32(txtS6_2_CantidadRemesas.Text), cbxS6_3_Deuda.Text, Convert.ToInt32(txtS6_4_CantiDeuda.Text), cbxS6_5_TiempoPagoDeuda.Text, cbxS6_6_IngresoTotal.Text, cbxS6_7_CubrenGasto.Text, cbxS6_8_AhorroMensual.Text, Convert.ToInt32(txtS6_9_CantiAhorro.Text), Convert.ToInt32(txtS6_10_CantiGastosaIngresos.Text), ENCUESTA, IDS611);
            if (correcto)
            {
                MessageBox.Show("Ingresado Correctamente");
                tbpS6.Parent = null;
                tbpS7.Parent = tbcDatos;
            }
            else
            {
                MessageBox.Show(S6.obtenerError());
            }
        }

        private void pbS7_Siguiente_Click(object sender, EventArgs e)
        {
            S7_ViviendaLN S7 = new S7_ViviendaLN();
            Boolean correcto = true;// S7.Insertar_EncuS7(Convert.ToInt32(txtS7_1_AnchoViv.Text), Convert.ToInt32(txtS7_1_LargoViv.Text), txtS7_2_Cuartos.Text, txtS7_3_CantDormitorios.Text, txtS7_4_CantCamas.Text, cbsS7_5_ProbViv.Text, txtS7_5_ProblemaA.Text, txtS7_5_ProblemaB.Text, txtS7_5_ProblemaC.Text, ENCUESTA, IDS706, IDS707, IDS708);
            if (correcto)
            {
                MessageBox.Show("Ingresado Correctamente");
                tbpS7.Parent = null;
                tbpS8.Parent = tbcDatos;
            }
            else
            {
                MessageBox.Show(S7.obtenerError());
            }
        }

        //seccion 4
        private void pbS4_Siguiente_Click(object sender, EventArgs e)
        {
            /*S4_SaludLN S4 = new S4_SaludLN();
            Boolean correcto = true;//S4.Insertar_EncuS4(Convert.ToInt32(txtS8_CodigoS8.Text),txtS8_
            if (correcto)
            {
                MessageBox.Show("Ingresado Correctamente");
                tbpS4.Parent = null;
                tbpS5.Parent = tbcDatos;
            }
            else
            {
                MessageBox.Show(S4.obtenerError());
            }
            */
            S4_SaludLN S4 = new S4_SaludLN();
            Boolean correcto = true;//S4.Insertar_EncuS4(Convert.ToInt32(txtS8_CodigoS8.Text),txtS8_
            if (correcto)
            {
                MessageBox.Show("Ingresado Correctamente");
            }
            else
            {
                MessageBox.Show(S4.obtenerError());
            }
            //este ahorita solo lo uso para esconder la pestana anterior y mostrar la q sigue
            if (correcto)
            {
                tbpS4.Parent = null;
                tbpS5.Parent = tbcDatos;
                //para s2
                int iS5 = 1;
                for (iS5 = 1; iS5 < iS1; iS5++)
                {
                    dgvS5.Rows.Add();
                    dgvS5.Rows[iS5 - 1].Cells[0].Value = iS5;
                }
            }


        }

        private void frmEncuesta_Load(object sender, EventArgs e)
        {
            tbpInfo.Parent = null;
            tbpS1.Parent = null;
            tbpS2.Parent = null;
            tbpS3.Parent = null;
            tbpS4.Parent = null;
            tbpS5.Parent = null;
            tbpS6.Parent = null;
            tbpS7.Parent = null;
            tbpS8.Parent = null;
            tbpS9.Parent = null;
            tbpS10.Parent = null;
            tbpS10Cont.Parent = null;
            //tbpS11.Parent = null;
            dgvS1.Columns[0].ReadOnly = true;
            dgvS2.Columns[0].ReadOnly = true;
            dgvS3.Columns[0].ReadOnly = true;
            dgvS4.Columns[0].ReadOnly = true;
            dgvS5.Columns[0].ReadOnly = true;
        }
        //Informacion
        private void pbNext_Click(object sender, EventArgs e)
        {
            Info_EncuestaLN InfoEnc = new Info_EncuestaLN();
            Boolean correcto = true;// InfoEnc.Insertar_InfoEncuesta(txtCodigoHogar.Text, Convert.ToInt32(cmbEncuestador1.SelectedValue.ToString()), Convert.ToInt32(cmbEncuestador2.SelectedValue.ToString()), Convert.ToDateTime(dtpFecha.ToString()), txtHoraI.Text, txtHoraF.Text, txtNombreEn.Text, txtObservaciones.Text,
                  //txtAldea.Text, txtCanton.Text, txtXGPS.Text, txtYGPS.Text, txtJefe.Text, txtTelefono1.Text, txtTelefono2.Text, txtDireccion.Text, txtEspecificaciones.Text, idComunidad);
            if (correcto)
            {
                MessageBox.Show("Ingresado Correctamente");
                tbpInfo.Parent = null;
                tbpS1.Parent = tbcDatos;
            }
            else
            {
                MessageBox.Show(InfoEnc.obtenerError());
            }
        }
        int iS1 = 1;
        private void btnAddS1_Click(object sender, EventArgs e)
        {
            dgvS1.Rows.Add();
            dgvS1.Rows[iS1 - 1].Cells[0].Value = iS1;
            iS1++;
        }

        private void btnRemS1_Click(object sender, EventArgs e)
        {
            try
            {
                dgvS1.Rows.RemoveAt(dgvS1.Rows.Count - 1);
                iS1--;
            }
            catch (Exception ex)
            { }
        }

        //Seccion 1
        private void pbNextS1_Click(object sender, EventArgs e)
        {
            S1_IntegrantesLN S1 = new S1_IntegrantesLN();
            Boolean correcto = true;//Boolean correcto = S1.Insertar_EncuS1(txtCodigoHogar.Text, Convert.ToInt32(cmbEncuestador1.SelectedValue.ToString()), Convert.ToInt32(cmbEncuestador2.SelectedValue.ToString()), Convert.ToDateTime(dtpFecha.ToString()), txtHoraI.Text, txtHoraF.Text, txtNombreEn.Text, txtObservaciones.Text,
            // txtAldea.Text, txtCanton.Text, txtXGPS.Text, txtYGPS.Text, txtJefe.Text, txtTelefono1.Text, txtTelefono2.Text, txtDireccion.Text, txtEspecificaciones.Text, idComunidad);  
            foreach (DataGridViewRow row in dgvS1.Rows)
            {
                if (correcto)
                {
                    MessageBox.Show("Ingresado Correctamente");

                }
                else
                {
                    MessageBox.Show(S1.obtenerError());
                }
            }
            if (correcto)
            {
                tbpS1.Parent = null;
                tbpS2.Parent = tbcDatos;
                //para s2
                int iS2 = 1;
                for (iS2 = 1; iS2 < iS1; iS2++)
                {
                    dgvS2.Rows.Add();
                    dgvS2.Rows[iS2 - 1].Cells[0].Value = iS2;
                }
            }
        }
        //seccion 2
        private void pbNextS2_Click(object sender, EventArgs e)
        {
            S2_DemograficaLN S2 = new S2_DemograficaLN();
            Boolean correcto = true;//Boolean correcto = S1.Insertar_EncuS1(txtCodigoHogar.Text, Convert.ToInt32(cmbEncuestador1.SelectedValue.ToString()), Convert.ToInt32(cmbEncuestador2.SelectedValue.ToString()), Convert.ToDateTime(dtpFecha.ToString()), txtHoraI.Text, txtHoraF.Text, txtNombreEn.Text, txtObservaciones.Text,
            // txtAldea.Text, txtCanton.Text, txtXGPS.Text, txtYGPS.Text, txtJefe.Text, txtTelefono1.Text, txtTelefono2.Text, txtDireccion.Text, txtEspecificaciones.Text, idComunidad);  
            foreach (DataGridViewRow row in dgvS2.Rows)
            {
                if (correcto)
                {
                    //MessageBox.Show("Ingresado Correctamente");

                }
                else
                {
                    MessageBox.Show(S2.obtenerError());
                }
            }
            if (correcto)
            {
                tbpS2.Parent = null;
                tbpS3.Parent = tbcDatos;
                //para s2
                int iS3 = 1;
                for (iS3 = 1; iS3 < iS1; iS3++)
                {
                    dgvS3.Rows.Add();
                    dgvS3.Rows[iS3 - 1].Cells[0].Value = iS3;
                }
            }
        }
        //secccion 3
        private void pbNextS3_Click(object sender, EventArgs e)
        {
            S3_EducacionLN S3 = new S3_EducacionLN();
            Boolean correcto = true;//Boolean correcto = S1.Insertar_EncuS1(txtCodigoHogar.Text, Convert.ToInt32(cmbEncuestador1.SelectedValue.ToString()), Convert.ToInt32(cmbEncuestador2.SelectedValue.ToString()), Convert.ToDateTime(dtpFecha.ToString()), txtHoraI.Text, txtHoraF.Text, txtNombreEn.Text, txtObservaciones.Text,
            // txtAldea.Text, txtCanton.Text, txtXGPS.Text, txtYGPS.Text, txtJefe.Text, txtTelefono1.Text, txtTelefono2.Text, txtDireccion.Text, txtEspecificaciones.Text, idComunidad);  
            foreach (DataGridViewRow row in dgvS3.Rows)
            {
                if (correcto)
                {
                    //MessageBox.Show("Ingresado Correctamente");

                }
                else
                {
                    MessageBox.Show(S3.obtenerError());
                }
            }
            if (correcto)
            {
                tbpS3.Parent = null;
                tbpS4.Parent = tbcDatos;
                //para s2
                int iS4 = 1;
                for (iS4 = 1; iS4 < iS1; iS4++)
                {
                    dgvS4.Rows.Add();
                    dgvS4.Rows[iS4 - 1].Cells[0].Value = iS4;
                }
            }
        }

        private void cbxS9_1_Propio_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbxS9_1_Propio.SelectedIndex == 1)
                MessageBox.Show("Debe continuar con la pregunta 3");
        }
        
    }
}
