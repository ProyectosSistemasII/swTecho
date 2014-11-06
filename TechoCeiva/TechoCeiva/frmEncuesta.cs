using Capa_Logica;
using Capa_Datos;
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
    {
        public Boolean Reiniciar = false;

        //variable para colorer los campos con errores.
        // variables para que no deje error los combobox cuando estan vacios cuando la pregunta
        //salta o otras dejan algunas vacios Seccion 9 
        Color ColorCampsVacios = Color.Red;

        ///selecciones en la pregunta 611
        Boolean RecorteGastos = false;
        Boolean Prestamo = false;
        Boolean VentaMaterial = false;
        Boolean TrabajoOcasional = false;
        Boolean Ahorros = false;
        Boolean AyudaFamiliar = false;
        Boolean ApoyoEstado = false;
        Boolean Otro = false;
        Boolean NSNR = false;
        /// -----------------------------------------------------------------------------------------------------------

        /// Selecciones en la pregunta 706
        int Concreto = 0;
        int TejaBarro = 0;
        int Lamina6 = 0;
        int TejaDuralita = 0;
        int Paja = 0;
        int Desechos6 = 0;
        ///-----------------------------------------------------------------------------------------------------------

        /// Selecciones en la pregunta 707
        int BlockLadrilloPrefbr = 0;
        int Madera7 = 0;
        int Adobe = 0;
        int Lamina7 = 0;
        int BaharequeBambu = 0;
        int Desechos7 = 0;
        ///------------------------------------------------------------------------------------------------------------

        /// Selecciones en la pregunta 708
        int Encementado = 0;
        int LadrilloBarro = 0;
        int Madera8 = 0;
        int Tierra = 0;
        ///-----------------------------------------------------------------------------------------------------------       

        /// variables para que no deje error los combobox cuando estan vacios Seccion 8
        String cbxS8_AccesoAguatxt = "";
        String cbxS8_FuenteAguatxt = "";
        String cbxS8_EnergiaElectricatxt = "";
        String cbxS8_EnergiaCocinatxt = "";
        String cbxS8_Sanitariotxt = "";
        String cbxS8_BasuraHogartxt = "";
        S807_ServiciosLN NuevaS807 = null;
        S808_ServiciosLN NuevaS808 = null;
        Boolean Pregunta807 = false;
        Boolean Pregunta808 = false;
        ///------------------------------------------------------------------------------------------------------------

        //selecciones en la pregunta 8.08
        int rbtS808_Refrigerador = 0;
        int rbtS808_EquipoDeSonido = 0;
        int rbtS808_Televisor = 0;
        int rbtS808_ReproductorDVD = 0;
        int rbtS808_Motocicleta = 0;
        int rbtS808_Automovil = 0;
        int rbtS808_Computadora = 0;
        int rbtS808_Amueblado = 0;
        int rbtS808_Otros = 0;
        /// -----------------------------------------------------------------------------------------------------------

        /// variables para seccion 9
        String cbxS9_Propiotxt = "";
        String cbxS9_Propietariotxt = "";
        String cbxS9_TipoPropietariotxt = "";
        String cbxS9_OtraPropiedadtxt = "";
        ///---------------------------------------------------------------------------------------------------------

        /// variables para que no deje error los combobox cuando estan vacios Seccion 10        
        S10_ComunidadLN NuevaS10_Comunidad = new S10_ComunidadLN();

        String cbxS10_RelacionVecinostxt = "";
        String cbxS10_OrganizarVecinostxt = "";
        String cbxS10_ParticipacionGrupotxt = "";
        String cbxS10_Necesidadtxt = "";
        String cbxS10_NecesidadComtxt = "";
        String cbxS10_ProyectosVecinostxt = "";
        String cbxS10_Discriminaciontxt = "";
        String cbxS10_OrganizacionComunitariatxt = "";
        String cbxS10_ConfiazaOrganizaciontxt = "";
        String cbxS10_EstadoPasadotxt = "";
        String cbxS10_estadoFuturotxt = "";

        S1006_ComunidadLN NuevaS1006 = new S1006_ComunidadLN();
        S1007_ComunidadLN NuevaS1007 = new S1007_ComunidadLN();
        S1008_ComunidadLN NuevaS1008 = new S1008_ComunidadLN();
        S1014_ComunidadLN NuevaS1014 = new S1014_ComunidadLN();
        Boolean Pregunta1006 = false;
        Boolean Pregunta1007 = false;
        Boolean Pregunta1008 = false;
        Boolean Pregunta1014 = false;
        Boolean Pregunta1006Mensaje = false;
        ///---------------------------------------------------------------------------------------------------------

        ///selecciones en la pregunta 1008
        int rbtS1008_Familiar = -1;
        int rbtS1008_Vecinos = -1;
        int rbtS1008_lideresComunitarios = -1;
        int rbtS1008_Policia = -1;
        int rbtS1008_Municipalidad = -1;
        int rbtS1008_OrganizacionGobierno = -1;
        int rbtS1008_Ejercito = -1;
        int rbtS1008_partidosPoliticos = -1;
        int rbtS1008_Techo = -1;
        int rbtS1008_MedioComunicacion = -1;
        int rbtS1008_IglesiasReligiosos = -1;
        /// -----------------------------------------------------------------------------------------------------------

        /// variables para que no deje error los combobox cuando estan vacios Seccion 11
        String cbxS11_1_VidaFamiliartxt = "";
        String cbxS11_4_ViviedaActualtxt = "";
        ///-----------------------------------------------------------------------------------------------------------

        /// variable de idComunidad
        public int idComuni = 0;
        /// ultimo idEncuesta
        public int idEncu = 0;
       
        public frmEncuesta()
        {
            InitializeComponent();
            txtCodigoHogar.Focus();
        }

        // Iniciar la transaccion para la encuesta
        public Boolean transaccion = false;
        TransEncuesta tran = new TransEncuesta();

        /// <summary>
        /// Información de la encuesta realizada
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pbNext_Click(object sender, EventArgs e)
        {
            Info_EncuestaLN InfoEnc = new Info_EncuestaLN();
            if (txtCodigoHogar.Text == "")
            {
                MessageBox.Show("Debe ingresar el codigo de la encuesta", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtCodigoHogar.Focus();
            }
            else
            {
                int codVoluntario1 = 0, codVoluntario2 = 0;
                if (cmbEncuestador1.Text == cmbEncuestador2.Text)
                    MessageBox.Show("Los voluntarios no pueden ser iguales", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else
                {
                    if (cmbEncuestador1.Text == "")
                        codVoluntario1 = 0;
                    else
                        codVoluntario1 = Convert.ToInt32(cmbEncuestador1.SelectedValue.ToString());
                    if (cmbEncuestador2.Text == "" || cmbEncuestador2.Text == null)
                        codVoluntario2 = 0;
                    else
                        codVoluntario2 = Convert.ToInt32(cmbEncuestador2.SelectedValue.ToString());
                    if (transaccion = tran.IniciarTransaccion()) // inicia transaccion e inserta la informacion de la encuesta
                    {
                        Boolean correcto = InfoEnc.Insertar_InfoEncuesta(txtCodigoHogar.Text, codVoluntario1, codVoluntario2, Convert.ToDateTime(dtpFecha.Value.ToString()), txtHoraI.Text, txtHoraF.Text, txtNombreEn.Text, cmbEstadoEn.Text, txtObservaciones.Text,
                            txtAldea.Text, txtCanton.Text, txtXGPS.Text, txtYGPS.Text, txtJefe.Text, txtTelefono1.Text, txtTelefono2.Text, txtDireccion.Text, txtEspecificaciones.Text, idComuni);
                        if (correcto)
                        {
                            tbpInfo.Parent = null;
                            tbpS1.Parent = tbcDatos;
                            idEncu = InfoEnc.UltimoId(); // obtiene el ultimo id de la encuesta ingresada
                        }
                        else
                            MessageBox.Show(InfoEnc.obtenerError());
                    }
                    else
                        MessageBox.Show("Ha ocurrido un error, intente de nuevo", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        /// <summary>
        /// Seccion 1
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pbNextS1_Click(object sender, EventArgs e)
        {
            S1_IntegrantesLN S1 = new S1_IntegrantesLN();
            Boolean correcto = false;
            int Filas = 0;
            //Recorrer para validar todos los campos del grid
            foreach (DataGridViewRow row in dgvS1.Rows)
            {
                dgvS1.CurrentCell = dgvS1.Rows[Filas].Cells[0];
                correcto = S1.validacion(Convert.ToInt32(row.Cells[0].Value.ToString()), row.Cells[1].Value.ToString(), row.Cells[2].Value.ToString(), row.Cells[3].Value.ToString(), row.Cells[4].Value.ToString(), row.Cells[5].Value.ToString(), idEncu, Filas);
                if (correcto)
                    Filas++;
                else
                {
                    Filas = 0;
                    MessageBox.Show(S1.obtenerError());
                    break;
                }
            }
            if (correcto)
            {
                //Recorrer para insertar, valida en capa logica
                Filas = 0;
                foreach (DataGridViewRow row in dgvS1.Rows)
                {
                    dgvS1.CurrentCell = dgvS1.Rows[Filas].Cells[0];
                    S1_IntegrantesLN SIn = new S1_IntegrantesLN(Convert.ToInt32(row.Cells[0].Value.ToString()), row.Cells[1].Value.ToString(), row.Cells[2].Value.ToString(), row.Cells[3].Value.ToString(), row.Cells[4].Value.ToString(), row.Cells[5].Value.ToString(), idEncu);
                    correcto = SIn.Insertar_EncuS1(); // se insertan las filas del datagrid
                    if (correcto)
                        Filas++;
                    else
                    {
                        Filas = 0;
                        MessageBox.Show(SIn.obtenerError());
                        break;
                    }
                }
                tbpS1.Parent = null; // muestra la seccion 2 de la encuesta
                tbpS2.Parent = tbcDatos;

                //para s2
                int iS2 = 1;
                for (iS2 = 1; iS2 < iS1; iS2++)
                {
                    dgvS2.Rows.Add(); // se cargan las filas
                    dgvS2.Rows[iS2 - 1].Cells[0].Value = iS2;
                    for (int i = 1; i < 9; i++)
                        dgvS2.Rows[iS2 - 1].Cells[i].Value = "";
                }
            }
        }

        /// <summary>
        /// Seccion 2
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pbNextS2_Click(object sender, EventArgs e)
        {
            S2_DemograficaLN S2 = new S2_DemograficaLN();
            Boolean correcto = false;
            int Filas = 0;
            //Recorrer para validar
            foreach (DataGridViewRow row in dgvS2.Rows)
            {
                dgvS2.CurrentCell = dgvS2.Rows[Filas].Cells[0];
                correcto = S2.validacion(Convert.ToInt32(row.Cells[0].Value.ToString()), row.Cells[1].Value.ToString(), row.Cells[2].Value.ToString(), row.Cells[3].Value.ToString(), row.Cells[4].Value.ToString(), row.Cells[5].Value.ToString(), row.Cells[8].Value.ToString(), idEncu, row.Cells[6].Value.ToString(), row.Cells[7].Value.ToString(), Filas);
                if (correcto)
                    Filas++;
                else
                {
                    Filas = 0;
                    MessageBox.Show(S2.obtenerError());
                    break;
                }
            }
            if (correcto)
            {
                //Recorrer para insertar
                Filas = 0;
                foreach (DataGridViewRow row in dgvS2.Rows)
                {
                    dgvS2.CurrentCell = dgvS2.Rows[Filas].Cells[0];
                    S2_DemograficaLN SIn = new S2_DemograficaLN(Convert.ToInt32(row.Cells[0].Value.ToString()), row.Cells[1].Value.ToString(), row.Cells[2].Value.ToString(), row.Cells[3].Value.ToString(), row.Cells[4].Value.ToString(), row.Cells[5].Value.ToString(), row.Cells[8].Value.ToString(), idEncu, row.Cells[6].Value.ToString(), row.Cells[7].Value.ToString());
                    correcto = SIn.Insertar_EncuS2();
                    if (correcto)
                        Filas++;
                    else
                    {
                        Filas = 0;
                        MessageBox.Show(SIn.obtenerError());
                        break;
                    }
                }
                tbpS2.Parent = null;
                tbpS3.Parent = tbcDatos;
                
                //para s3
                int iS3 = 1;
                for (iS3 = 1; iS3 < iS1; iS3++)
                {
                    dgvS3.Rows.Add();
                    dgvS3.Rows[iS3 - 1].Cells[0].Value = iS3;
                    for (int i = 1; i < 13; i++)
                        dgvS3.Rows[iS3 - 1].Cells[i].Value = "";
                }
            }
        }

        /// <summary>
        /// Seccion 3
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pbNextS3_Click(object sender, EventArgs e)
        {
            S3_EducacionLN S3 = new S3_EducacionLN();
            Boolean correcto = false;
            int Filas = 0;
            //Recorrer para validar las filas del datagrid
            foreach (DataGridViewRow row in dgvS3.Rows)
            {
                dgvS3.CurrentCell = dgvS3.Rows[Filas].Cells[0];
                correcto = S3.validacion(Convert.ToInt32(row.Cells[0].Value.ToString()), row.Cells[1].Value.ToString(), row.Cells[2].Value.ToString(), row.Cells[3].Value.ToString(), row.Cells[4].Value.ToString(),
                    row.Cells[5].Value.ToString(), row.Cells[6].Value.ToString(), row.Cells[7].Value.ToString(), row.Cells[8].Value.ToString(), row.Cells[9].Value.ToString(), row.Cells[10].Value.ToString(),
                    row.Cells[11].Value.ToString(), row.Cells[12].Value.ToString(), idEncu, Filas);
                if (correcto)
                    Filas++;
                else
                {
                    Filas = 0;
                    MessageBox.Show(S3.obtenerError());
                    break;
                }                
            }
            if (correcto)
            {
                Filas = 0;
                //recorrer para insertar las filas del datagrid
                foreach (DataGridViewRow row in dgvS3.Rows)
                {
                    dgvS3.CurrentCell = dgvS3.Rows[Filas].Cells[0];
                    S3_EducacionLN SIn = new S3_EducacionLN(Convert.ToInt32(row.Cells[0].Value.ToString()), row.Cells[1].Value.ToString(), row.Cells[2].Value.ToString(), row.Cells[3].Value.ToString(), row.Cells[4].Value.ToString(),
                        row.Cells[5].Value.ToString(), row.Cells[6].Value.ToString(), row.Cells[7].Value.ToString(), row.Cells[8].Value.ToString(), row.Cells[9].Value.ToString(), row.Cells[10].Value.ToString(),
                        row.Cells[11].Value.ToString(), row.Cells[12].Value.ToString(), idEncu);
                    correcto = S3.Insertar_EncuS3(); // inserts de las filas del datagrid
                    if (correcto)
                        Filas++;
                    else
                    {
                        Filas = 0;
                        MessageBox.Show(SIn.obtenerError());
                        break;
                    }
                }
                tbpS3.Parent = null;// muestra seccion 4 de la encuesta
                tbpS4.Parent = tbcDatos;

                //para s4
                int iS4 = 1;
                for (iS4 = 1; iS4 < iS1; iS4++)
                {
                    dgvS4.Rows.Add();
                    dgvS4.Rows[iS4 - 1].Cells[0].Value = iS4;
                    for (int i = 1; i < 13; i++)
                        dgvS4.Rows[iS4 - 1].Cells[i].Value = "";
                }
            }
        }

        /// <summary>
        /// Seccion 4
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pbS4_Siguiente_Click(object sender, EventArgs e)
        {
            S4_SaludLN S4 = new S4_SaludLN();
            Boolean correcto = false;
            int Filas = 0;
            //Recorrer para validar que todos los campos esten llenos
            foreach (DataGridViewRow row in dgvS4.Rows)
            {
                dgvS4.CurrentCell = dgvS4.Rows[Filas].Cells[0];
                Boolean problema = false;
                Boolean accidente = false;
                if (row.Cells[4].Value.ToString().Equals("Si (especificar)"))
                    problema = true;
                if (row.Cells[6].Value.ToString().Equals("Si (especificar)"))
                    accidente = true;
                correcto = S4.validacion(Convert.ToInt32(row.Cells[0].Value.ToString()), row.Cells[1].Value.ToString(), row.Cells[2].Value.ToString(), row.Cells[3].Value.ToString(), problema, row.Cells[5].Value.ToString(), accidente, row.Cells[7].Value.ToString(), row.Cells[8].Value.ToString(), row.Cells[9].Value.ToString(), row.Cells[10].Value.ToString(), row.Cells[11].Value.ToString(), row.Cells[12].Value.ToString(), idEncu, Filas);
                if (correcto)
                    Filas++; // Si todos los campos estan bien pasar a la siguiente fila hasta recorrer toda la tabla
                else
                {
                    Filas = 0;
                    MessageBox.Show(S4.obtenerError());
                    break;
                }
            }
            if (correcto)
            {
                //Recorrer para insertar cada fila de campos en la base de datos
                Filas = 0;
                foreach (DataGridViewRow row in dgvS4.Rows)
                {
                    dgvS4.CurrentCell = dgvS4.Rows[Filas].Cells[0];
                    Boolean problema = false;
                    Boolean accidente = false;
                    if (row.Cells[4].Value.ToString().Equals("Si (especificar)"))
                        problema = true;
                    if (row.Cells[6].Value.ToString().Equals("Si (especificar)"))
                        accidente = true;
                    S4_SaludLN SIn = new S4_SaludLN(Convert.ToInt32(row.Cells[0].Value.ToString()), row.Cells[1].Value.ToString(), row.Cells[2].Value.ToString(), row.Cells[3].Value.ToString(), problema, row.Cells[5].Value.ToString(), accidente, row.Cells[7].Value.ToString(), row.Cells[8].Value.ToString(), row.Cells[9].Value.ToString(), row.Cells[10].Value.ToString(), row.Cells[11].Value.ToString(), row.Cells[12].Value.ToString(), idEncu);
                    correcto = SIn.Insertar_EncuS4(); // Se llama a la capa logica para verificación de campos y saltos
                    if (correcto)
                        Filas++; // Se inserta fila por fila hasta terminar con toda la tabla
                    else
                    {
                        Filas = 0;
                        MessageBox.Show(SIn.obtenerError());
                        break;
                    }
                }
                // Si se insertaron bien todos los datos pasar a la siguiente pestaña de la encuesta
                tbpS4.Parent = null;
                tbpS5.Parent = tbcDatos;
                //para  obtener los codigos en la seccion 5
                int iS5 = 1;
                for (iS5 = 1; iS5 < iS1; iS5++)
                {
                    dgvS5.Rows.Add();
                    dgvS5.Rows[iS5 - 1].Cells[0].Value = iS5;
                    for (int i = 1; i < 15; i++)
                        dgvS5.Rows[iS5 - 1].Cells[i].Value = "";
                }
            }
        }

        /// <summary>
        /// Seccion 5
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pbS5_Siguiente_Click(object sender, EventArgs e)
        {
            S5_TrabajoLN S5 = new S5_TrabajoLN();
            Boolean correcto = false;
            int Filas = 0;
            //Recorrer para validar que todos los campos esten llenos
            foreach (DataGridViewRow row in dgvS5.Rows)
            {
                dgvS5.CurrentCell = dgvS5.Rows[Filas].Cells[0];
                Boolean trabajo = false;
                Boolean buscando = false;
                Boolean otrosTrabajos = false;
                int dias = 0; float horas = 0; float ingreso = 0;
                if (row.Cells[1].Value.ToString().Equals("Si"))
                    trabajo = true;
                if (row.Cells[2].Value.ToString().Equals("Si"))
                    buscando = true;
                if (row.Cells[10].Value.ToString().Equals("Si (especificar)"))
                    otrosTrabajos = true;
                if (row.Cells[12].Value.ToString() == "")
                    dias = 0;
                else
                    dias = Convert.ToInt32(row.Cells[12].Value.ToString());
                if (row.Cells[13].Value.ToString() == "")
                    horas = 0;
                else
                    horas = float.Parse(row.Cells[13].Value.ToString());
                if (row.Cells[14].Value.ToString() == "")
                    ingreso = 0;
                else
                    ingreso = float.Parse(row.Cells[14].Value.ToString());
                correcto = S5.validacion(Convert.ToInt32(row.Cells[0].Value.ToString()), trabajo, buscando, row.Cells[3].Value.ToString(), row.Cells[4].Value.ToString(), row.Cells[5].Value.ToString(), row.Cells[6].Value.ToString(), row.Cells[7].Value.ToString(), row.Cells[8].Value.ToString(), row.Cells[9].Value.ToString(), otrosTrabajos, row.Cells[11].Value.ToString(), dias, horas, ingreso, idEncu, Filas);
                if (correcto)
                    Filas++; // Si la fila 1 es correcta pasa a la siguiente hasta que se hayan validado todas las filas
                else
                {
                    Filas = 0;
                    MessageBox.Show(S5.obtenerError());
                    break;
                }
            }
            if (correcto)
            {
                //Recorrer para insertar en base de datos
                Filas = 0;
                foreach (DataGridViewRow row in dgvS5.Rows)
                {
                    dgvS5.CurrentCell = dgvS5.Rows[Filas].Cells[0];
                    Boolean trabajo = false;
                    Boolean buscando = false;
                    Boolean otrosTrabajos = false;
                    int dias = 0; float horas = 0; float ingreso = 0;
                    if (row.Cells[1].Value.ToString().Equals("Si"))
                        trabajo = true;
                    if (row.Cells[2].Value.ToString().Equals("Si"))
                        buscando = true;
                    if (row.Cells[10].Value.ToString().Equals("Si (especificar)"))
                        otrosTrabajos = true;
                    if (row.Cells[12].Value.ToString() == "")
                        dias = 0;
                    else
                        dias = Convert.ToInt32(row.Cells[12].Value.ToString());
                    if (row.Cells[13].Value.ToString() == "")
                        horas = 0;
                    else
                        horas = float.Parse(row.Cells[13].Value.ToString());
                    if (row.Cells[14].Value.ToString() == "")
                        ingreso = 0;
                    else
                        ingreso = float.Parse(row.Cells[14].Value.ToString());
                    S5_TrabajoLN SIn = new S5_TrabajoLN(Convert.ToInt32(row.Cells[0].Value.ToString()), trabajo, buscando, row.Cells[3].Value.ToString(), row.Cells[4].Value.ToString(), row.Cells[5].Value.ToString(), row.Cells[6].Value.ToString(), row.Cells[7].Value.ToString(), row.Cells[8].Value.ToString(), row.Cells[9].Value.ToString(), otrosTrabajos, row.Cells[11].Value.ToString(), dias, horas, ingreso, idEncu);
                    correcto = SIn.Insertar_EncuS5(); //Se validan los datos en la capa logica del negocio
                    if (correcto)
                        Filas++; // Si la fila 1 es correcta pasa a la siguiente hasta que se hayan insertado todas las filas
                    else
                    {
                        Filas = 0;
                        MessageBox.Show(SIn.obtenerError());
                        break;
                    }
                }
                // Se pasa a la siguiente pestaña de la encuesta
                tbpS5.Parent = null;
                tbpS6.Parent = tbcDatos;
                cbxS6_1_IngEstado.Focus();
            }
        }

        /*
         * Se verifican los listBox de la pregunta 611
         * true los marcados y false los no marcados
         */
        public void verificarListBoxS6()
        {
            foreach (var item in chlbS6_11_CubrirFaltaDinero.CheckedItems)
            {
                switch (item.ToString())
                {
                    case "Recorte de gastos / Ajuste de presupuesto":
                        this.RecorteGastos = true;
                        break;
                    case "Endeudamiento o préstamo":
                        this.Prestamo = true;
                        break;
                    case "Vendiendo algo del hogar (televisor, radio, etc.)":
                        this.VentaMaterial = true;
                        break;
                    case "Trabajos ocasionales":
                        this.TrabajoOcasional = true;
                        break;
                    case "Ahorros":
                        this.Ahorros = true;
                        break;
                    case "Ayuda familiar":
                        this.AyudaFamiliar = true;
                        break;
                    case "Apoyos del Estado":
                        this.ApoyoEstado = true;
                        break;
                    case "Otro (especifique)":
                        this.Otro = true;
                        break;
                    case "NS/NR":
                        this.NSNR = true;
                        break;
                }
            }
        }

        /*
         * Se iguala a 0 los campos que llevan numero y no se les coloco
         */
        public void IgualarText()
        {
            if (txtS6_1_CantidadIngEstado.Text == "")
                txtS6_1_CantidadIngEstado.Text = "0";
            if (txtS6_2_CantidadRemesas.Text == "")
                txtS6_2_CantidadRemesas.Text = "0";
            if (txtS6_4_CantiDeuda.Text == "")
                txtS6_4_CantiDeuda.Text = "0";
            if (txtS6_6_IngresoTotal.Text == "")
                txtS6_6_IngresoTotal.Text = "0";
            if (txtS6_9_CantiAhorro.Text == "")
                txtS6_9_CantiAhorro.Text = "0";
            if (txtS6_10_CantiGastosaIngresos.Text == "")
                txtS6_10_CantiGastosaIngresos.Text = "0";
        }

        /// <summary>
        /// Seccion 6
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pbS6_Siguiente_Click(object sender, EventArgs e)
        {
            int ids611 = 0;
            IgualarText();
            S6_IngresosLN SDatos = new S6_IngresosLN(cbxS6_1_IngEstado.Text, float.Parse(txtS6_1_CantidadIngEstado.Text), cbxS6_2_IngRemesas.Text, float.Parse(txtS6_2_CantidadRemesas.Text), cbxS6_3_Deuda.Text, float.Parse(txtS6_4_CantiDeuda.Text), cbxS6_5_TiempoPagoDeuda.Text, float.Parse(txtS6_6_IngresoTotal.Text), cbxS6_7_CubrenGasto.Text, cbxS6_8_AhorroMensual.Text, float.Parse(txtS6_9_CantiAhorro.Text), float.Parse(txtS6_10_CantiGastosaIngresos.Text), idEncu, ids611);
            Boolean campos = SDatos.VerificarCampos(); // Verificacion de los campos 
            if (campos)
            {
                //Cuando no se ingresar la pregunta 11 de la seccion 6
                this.verificarListBoxS6();
                S611_IngresosLN S611 = new S611_IngresosLN(this.RecorteGastos, this.Prestamo, this.VentaMaterial, this.TrabajoOcasional, this.Ahorros, this.AyudaFamiliar, this.ApoyoEstado, this.Otro, txtS6_11_EspecificarFaltaDinero.Text, this.NSNR);
                if (cbxS6_7_CubrenGasto.Text.Equals("No"))
                    S611.Validar11(); // Validacion de campos correctos en la capa logica

                //Por si hay saltos y no tienen que contestar unas preguntas
                if (cbxS6_7_CubrenGasto.Text.Equals("Iguales") || cbxS6_7_CubrenGasto.Text.Equals("NS/NR") || cbxS6_7_CubrenGasto.Text.Equals("Si"))
                {
                    //Ingresar la seccion 6 completa en la base de datos
                    S6_IngresosLN S6 = new S6_IngresosLN(cbxS6_1_IngEstado.Text, float.Parse(txtS6_1_CantidadIngEstado.Text), cbxS6_2_IngRemesas.Text, float.Parse(txtS6_2_CantidadRemesas.Text), cbxS6_3_Deuda.Text, float.Parse(txtS6_4_CantiDeuda.Text), cbxS6_5_TiempoPagoDeuda.Text, float.Parse(txtS6_6_IngresoTotal.Text), cbxS6_7_CubrenGasto.Text, cbxS6_8_AhorroMensual.Text, float.Parse(txtS6_9_CantiAhorro.Text), float.Parse(txtS6_10_CantiGastosaIngresos.Text), idEncu, ids611);
                    Boolean correcto = S6.Insertar_EncuS6();
                    if (correcto)
                    { // si los campos fueron ingresados con exito se pasa a la siguiente pestaña de la encuesta
                        tbpS6.Parent = null;
                        tbpS7.Parent = tbcDatos;
                        txtS7_1_AnchoViv.Focus();
                    }
                    else
                        MessageBox.Show(S6.obtenerError());
                }
                else
                { // Cuando ya se ingreso la pregunta 11 de la seccion 6
                    Boolean correctos611 = S611.Insertar_EncuS611();
                    if (correctos611)
                    {
                        S611_Ingresos s611 = new S611_Ingresos();
                        ids611 = s611.UltimoId(); // Se busca el ultimo id de la pregunta 6.11
                        //Ingresar la seccion 6 completa
                        S6_IngresosLN S6 = new S6_IngresosLN(cbxS6_1_IngEstado.Text, float.Parse(txtS6_1_CantidadIngEstado.Text), cbxS6_2_IngRemesas.Text, float.Parse(txtS6_2_CantidadRemesas.Text), cbxS6_3_Deuda.Text, float.Parse(txtS6_4_CantiDeuda.Text), cbxS6_5_TiempoPagoDeuda.Text, float.Parse(txtS6_6_IngresoTotal.Text), cbxS6_7_CubrenGasto.Text, cbxS6_8_AhorroMensual.Text, float.Parse(txtS6_9_CantiAhorro.Text), float.Parse(txtS6_10_CantiGastosaIngresos.Text), idEncu, ids611);
                        Boolean correcto = S6.Insertar_EncuS6();
                        if (correcto)
                        { // si los campos fueron ingresados con exito se pasa a la siguiente pestaña de la encuesta
                            tbpS6.Parent = null;
                            tbpS7.Parent = tbcDatos;
                            txtS7_1_AnchoViv.Focus();
                        }
                        else
                            MessageBox.Show(S6.obtenerError());
                    }
                    else
                        MessageBox.Show(S611.obtenerError());
                }
            }
            else
                MessageBox.Show(SDatos.obtenerError());
        }

        /*
         * Asignacion de los radio buttom para la seccion 7
         * 1 = muy malo; 2 =  malo; 3 = bueno; 4 = muy bueno
         */
        public void verificarRBS706()
        {
            //Calificacion de concreto
            if (rbS7_61_MuyMalo.Checked)
                Concreto = 1;
            else if (rbS7_61_Malo.Checked)
                Concreto = 2;
            else if (rbS7_61_Bueno.Checked)
                Concreto = 3;
            else if (rbS7_61_MuyBueno.Checked)
                Concreto = 4;

            //Calificacion de tejaBarro
            if (rbS7_62_MuyMalo.Checked)
                TejaBarro = 1;
            else if (rbS7_62_Malo.Checked)
                TejaBarro = 2;
            else if (rbS7_62_Bueno.Checked)
                TejaBarro = 3;
            else if (rbS7_62_MuyBueno.Checked)
                TejaBarro = 4;

            //Calificacion de lamina
            if (rbS7_63_MuyMalo.Checked)
                Lamina6 = 1;
            else if (rbS7_63_Malo.Checked)
                Lamina6 = 2;
            else if (rbS7_63_Bueno.Checked)
                Lamina6 = 3;
            else if (rbS7_63_MuyBueno.Checked)
                Lamina6 = 4;

            //Calificacion de TejaDuralita
            if (rbS7_64_MuyMalo.Checked)
                TejaDuralita = 1;
            else if (rbS7_64_Malo.Checked)
                TejaDuralita = 2;
            else if (rbS7_64_Bueno.Checked)
                TejaDuralita = 3;
            else if (rbS7_64_MuyBueno.Checked)
                TejaDuralita = 4;

            //Calificacion de Paja
            if (rbS7_65_MuyMalo.Checked)
                Paja = 1;
            else if (rbS7_65_Malo.Checked)
                Paja = 2;
            else if (rbS7_65_Bueno.Checked)
                Paja = 3;
            else if (rbS7_65_MuyBueno.Checked)
                Paja = 4;

            //Calificacion de desechos
            if (rbS7_66_MuyMalo.Checked)
                Desechos6 = 1;
            else if (rbS7_66_Malo.Checked)
                Desechos6 = 2;
            else if (rbS7_66_Bueno.Checked)
                Desechos6 = 3;
            else if (rbS7_66_MuyBueno.Checked)
                Desechos6 = 4;
        }

        public void verificarRBS707()
        {
            //Calificacion de blockLadrilloPrefabr
            if (rbS7_71_MuyMalo.Checked)
                BlockLadrilloPrefbr = 1;
            else if (rbS7_71_Malo.Checked)
                BlockLadrilloPrefbr = 2;
            else if (rbS7_71_Bueno.Checked)
                BlockLadrilloPrefbr = 3;
            else if (rbS7_71_MuyBueno.Checked)
                BlockLadrilloPrefbr = 4;

            //Calificacion de Madera
            if (rbS7_72_MuyMalo.Checked)
                Madera7 = 1;
            else if (rbS7_72_Malo.Checked)
                Madera7 = 2;
            else if (rbS7_72_Bueno.Checked)
                Madera7 = 3;
            else if (rbS7_72_MuyBueno.Checked)
                Madera7 = 4;

            //Calificacion de adobe
            if (rbS7_73_MuyMalo.Checked)
                Adobe = 1;
            else if (rbS7_73_Malo.Checked)
                Adobe = 2;
            else if (rbS7_73_Bueno.Checked)
                Adobe = 3;
            else if (rbS7_73_MuyBueno.Checked)
                Adobe = 4;

            //Calificacion de lamina
            if (rbS7_74_MuyMalo.Checked)
                Lamina7 = 1;
            else if (rbS7_74_Malo.Checked)
                Lamina7 = 2;
            else if (rbS7_74_Bueno.Checked)
                Lamina7 = 3;
            else if (rbS7_74_MuyBueno.Checked)
                Lamina7 = 4;

            //Calificacion de baharequeBambu
            if (rbS7_75_MuyMalo.Checked)
                BaharequeBambu = 1;
            else if (rbS7_75_Malo.Checked)
                BaharequeBambu = 2;
            else if (rbS7_75_Bueno.Checked)
                BaharequeBambu = 3;
            else if (rbS7_75_MuyBueno.Checked)
                BaharequeBambu = 4;

            //Calificacion de desechos
            if (rbS7_76_MuyMalo.Checked)
                Desechos7 = 1;
            else if (rbS7_76_Malo.Checked)
                Desechos7 = 2;
            else if (rbS7_76_Bueno.Checked)
                Desechos7 = 3;
            else if (rbS7_76_MuyBueno.Checked)
                Desechos7 = 4;
        }

        public void verificarRBS708()
        {
            //Calificacion de encementado
            if (rbS7_81_MuyMalo.Checked)
                Encementado = 1;
            else if (rbS7_81_Malo.Checked)
                Encementado = 2;
            else if (rbS7_81_Bueno.Checked)
                Encementado = 3;
            else if (rbS7_81_MuyBueno.Checked)
                Encementado = 4;

            //Calificacion de LadrillosBarro
            if (rbS7_82_MuyMalo.Checked)
                LadrilloBarro = 1;
            else if (rbS7_82_Malo.Checked)
                LadrilloBarro = 2;
            else if (rbS7_82_Bueno.Checked)
                LadrilloBarro = 3;
            else if (rbS7_82_MuyBueno.Checked)
                LadrilloBarro = 4;

            //Calificacion de madera
            if (rbS7_83_MuyMalo.Checked)
                Madera8 = 1;
            else if (rbS7_83_Malo.Checked)
                Madera8 = 2;
            else if (rbS7_83_Bueno.Checked)
                Madera8 = 3;
            else if (rbS7_83_MuyBueno.Checked)
                Madera8 = 4;

            //Calificacion de tierra
            if (rbS7_84_MuyMalo.Checked)
                Tierra = 1;
            else if (rbS7_84_Malo.Checked)
                Tierra = 2;
            else if (rbS7_84_Bueno.Checked)
                Tierra = 3;
            else if (rbS7_84_MuyBueno.Checked)
                Tierra = 4;
        }

        /*
         * Colocar 0 en caso no tengan las dimensiones de la vivienda de la seccion 7
         */
        public void IgualarTextS7()
        {
            if (txtS7_1_AnchoViv.Text == "")
                txtS7_1_AnchoViv.Text = "0";
            if (txtS7_1_LargoViv.Text == "")
                txtS7_1_LargoViv.Text = "0";
        }

        /// <summary>
        /// Seccion 7
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pbS7_Siguiente_Click_1(object sender, EventArgs e)
        {
            int ids706 = 0, ids707 = 0, ids708 = 0;
            // Ingresar la seccion 7 por completo
            IgualarTextS7();
            S7_ViviendaLN SDatos = new S7_ViviendaLN(Convert.ToInt32(txtS7_1_AnchoViv.Text), Convert.ToInt32(txtS7_1_LargoViv.Text), txtS7_2_Cuartos.Text, txtS7_3_CantDormitorios.Text, txtS7_4_CantCamas.Text, cbsS7_5_ProbViv.Text, txtS7_5_ProblemaA.Text, txtS7_5_ProblemaB.Text, txtS7_5_ProblemaC.Text, idEncu, ids706, ids707, ids708);
            Boolean campos = SDatos.VerificarCampos(); // Verificación de los campos
            if (campos)
            {
                //Ingresar la pregunta 6 de la seccion 7
                this.verificarRBS706();
                if (!this.Concreto.Equals(0) && !this.TejaBarro.Equals(0) && !this.Lamina6.Equals(0) && !this.TejaDuralita.Equals(0) && !this.Paja.Equals(0) && !this.Desechos6.Equals(0))
                {
                    S706_ViviendaLN S706 = new S706_ViviendaLN(this.Concreto, this.TejaBarro, this.Lamina6, this.TejaDuralita, this.Paja, this.Desechos6);
                    Boolean correctos706 = S706.Insertar_EncuS706();
                    if (correctos706)
                    {
                        S706_Vivienda s706 = new S706_Vivienda();
                        ids706 = s706.UltimoId(); // Se busca el ultimo id de la pregunta 6 para colocarlo en el insert de la seccion 7 completa
                    }
                    else
                        MessageBox.Show(S706.obtenerError());
                }

                //Ingresar la pregunta 7 de la seccion 7
                this.verificarRBS707();
                if (!this.BlockLadrilloPrefbr.Equals(0) && !this.Madera7.Equals(0) && !this.Adobe.Equals(0) && !this.Lamina7.Equals(0) && !this.BaharequeBambu.Equals(0) && !this.Desechos7.Equals(0))
                {
                    S707_ViviendaLN S707 = new S707_ViviendaLN(this.BlockLadrilloPrefbr, this.Madera7, this.Adobe, this.Lamina7, this.BaharequeBambu, this.Desechos7);
                    Boolean correctos707 = S707.Insertar_EncuS707();
                    if (correctos707)
                    {
                        S707_Vivienda s707 = new S707_Vivienda();
                        ids707 = s707.UltimoId(); // Se busca el ultimo id de la pregunta 7 para colocarlo en el insert de la seccion 7 completa
                    }
                    else
                        MessageBox.Show(S707.obtenerError());
                }

                //Ingresar la pregunta 8 de la seccion 7
                this.verificarRBS708();
                if (!this.Encementado.Equals(0) && !this.LadrilloBarro.Equals(0) && !this.Madera8.Equals(0) && !this.Tierra.Equals(0))
                {
                    S708_ViviendaLN S708 = new S708_ViviendaLN(this.Encementado, this.LadrilloBarro, this.Madera8, this.Tierra);
                    Boolean correctos708 = S708.Insertar_EncuS708();
                    if (correctos708)
                    {
                        S708_Vivienda s708 = new S708_Vivienda();
                        ids708 = s708.UltimoId(); // Se busca el ultimo id de la pregunta 8 para colocarlo en el insert de la seccion 7 completa
                    }
                    else
                        MessageBox.Show(S708.obtenerError());
                }

                //Ingresar la seccion 7 completa
                S7_ViviendaLN S7 = new S7_ViviendaLN(Convert.ToInt32(txtS7_1_AnchoViv.Text), Convert.ToInt32(txtS7_1_LargoViv.Text), txtS7_2_Cuartos.Text, txtS7_3_CantDormitorios.Text, txtS7_4_CantCamas.Text, cbsS7_5_ProbViv.Text, txtS7_5_ProblemaA.Text, txtS7_5_ProblemaB.Text, txtS7_5_ProblemaC.Text, idEncu, ids706, ids707, ids708);
                Boolean correcto = S7.Insertar_EncuS7();
                if (correcto)
                { // Si la insercion se completo se pasa a la siguiente pestaña de la encuesta
                    tbpS7.Parent = null;
                    tbpS8.Parent = tbcDatos;
                    cbxS8_AccesoAgua.Focus();
                }
                else
                    MessageBox.Show(S7.obtenerError());
            }
            else
                MessageBox.Show(SDatos.obtenerError());
        }

        /*
        * Se comprueba cada error de cada seccion 8 y marcarlos con diferentes color
        */
        private void Comprobar_S8(int pregunta)
        {
            switch (pregunta)
            {
                case 1:
                    cbxS8_AccesoAgua.BackColor = Color.Red;
                    cbxS8_AccesoAgua.Focus();
                    break;
                case 2:
                    cbxS8_FuenteAgua.BackColor = ColorCampsVacios;
                    cbxS8_FuenteAgua.Focus();
                    break;
                case 201:
                    txtS8_OtraFuente.BackColor = ColorCampsVacios;
                    txtS8_OtraFuente.Focus();
                    break;
                case 3:
                    cbxS8_EnergiaElectrica.BackColor = ColorCampsVacios;
                    cbxS8_EnergiaElectrica.Focus();
                    break;
                case 301:
                    txtS8_OtraEnergiaElectrica.BackColor = ColorCampsVacios;
                    txtS8_OtraEnergiaElectrica.Focus();
                    break;
                case 4:
                    cbxS8_EnergiaCocina.BackColor = ColorCampsVacios;
                    cbxS8_EnergiaCocina.Focus();
                    break;
                case 401:
                    txtS8_OtraEnergiaCocina.BackColor = ColorCampsVacios;
                    txtS8_OtraEnergiaCocina.Focus();
                    break;
                case 5:
                    cbxS8_Sanitario.BackColor = ColorCampsVacios;
                    cbxS8_Sanitario.Focus();
                    break;
                case 501:
                    txtS8_OtroTipoSanitario.BackColor = ColorCampsVacios;
                    txtS8_OtroTipoSanitario.Focus();
                    break;
                case 6:
                    cbxS8_BasuraHogar.BackColor = ColorCampsVacios;
                    cbxS8_BasuraHogar.Focus();
                    break;
                case 601:
                    txtS8_OtroTipoBasura.BackColor = ColorCampsVacios;
                    txtS8_OtroTipoBasura.Focus();
                    break;
            }
        }

        /*
         * Se verifican que todos los combobox hayan sido seleccionados de lo contrario se marcaran como contenido vacio
         */
        public void VerificarCombox_S8()
        {
            if (cbxS8_AccesoAgua.SelectedIndex != -1)
                cbxS8_AccesoAguatxt = cbxS8_AccesoAgua.SelectedItem.ToString();
            if (cbxS8_FuenteAgua.SelectedIndex != -1)
                cbxS8_FuenteAguatxt = cbxS8_FuenteAgua.SelectedItem.ToString();
            if (cbxS8_EnergiaElectrica.SelectedIndex != -1)
                cbxS8_EnergiaElectricatxt = cbxS8_EnergiaElectrica.SelectedItem.ToString();
            if (cbxS8_EnergiaCocina.SelectedIndex != -1)
                cbxS8_EnergiaCocinatxt = cbxS8_EnergiaCocina.SelectedItem.ToString();
            if (cbxS8_Sanitario.SelectedIndex != -1)
                cbxS8_Sanitariotxt = cbxS8_Sanitario.SelectedItem.ToString();
            if (cbxS8_BasuraHogar.SelectedIndex != -1)
                cbxS8_BasuraHogartxt = cbxS8_BasuraHogar.SelectedItem.ToString();
        }

        public Boolean IngresarS808()
        {
            this.VerificarRadioBtn_S808(); // se verifica cada radio button de la pregunta 8.8
            NuevaS808 = new S808_ServiciosLN(rbtS808_Refrigerador, rbtS808_EquipoDeSonido, rbtS808_Televisor, rbtS808_ReproductorDVD, rbtS808_Motocicleta, rbtS808_Automovil, rbtS808_Computadora, rbtS808_Amueblado, rbtS808_Otros, rbtS808_OtroEspecificar.Text);
            Boolean correcto = NuevaS808.Insertar_EncuS808();
            if (!correcto)
            {// se reccoren los posibles errores que puedan existir y se envia el numero para ser marcado con otro color.
                MessageBox.Show(NuevaS808.obtenerError().mensaje);
                int cant = NuevaS808.errores.Count - 1;

                for (int i = cant; i >= 0; i--)
                    this.Comprobar_S808(NuevaS808.errores[i].NumeroPregunta);
            }
            return correcto; // se retorna un true si toda ha ido bien
        }

        /*
         * Se comprueban los componentes que tienen errores y se marca con otro color
         */
        private void Comprobar_S808(int pregunta)
        {
            switch (pregunta)
            {
                case 9:
                    rbtS808_OtroEspecificar.BackColor = ColorCampsVacios;
                    rbtS808_OtroEspecificar.Focus();
                    break;
            }
        }

        /*
         * Se verifica cada radio button para asignarle una valor
         * 1:Malo, 2:regular, 3: bueno
         */
        public void VerificarRadioBtn_S808()
        {
            if (rbtS808_Refrigerador_M.Checked)
                rbtS808_Refrigerador = 1;
            else if (rbtS808_Refrigerador_R.Checked)
                rbtS808_Refrigerador = 2;
            else if (rbtS808_Refrigerador_B.Checked)
                rbtS808_Refrigerador = 3;
            if (rbtS808_EquipoSonido_M.Checked)
                rbtS808_EquipoDeSonido = 1;
            else if (rbtS808_EquipoSonido_R.Checked)
                rbtS808_EquipoDeSonido = 2;
            else if (rbtS808_EquipoSonido_B.Checked)
                rbtS808_EquipoDeSonido = 3;
            if (rbtS808_Televisor_M.Checked)
                rbtS808_Televisor = 1;
            else if (rbtS808_Televisor_R.Checked)
                rbtS808_Televisor = 2;
            else if (rbtS808_Televisor_B.Checked)
                rbtS808_Televisor = 3;
            if (rbtS808_DVD_M.Checked)
                rbtS808_ReproductorDVD = 1;
            else if (rbtS808_DVD_R.Checked)
                rbtS808_ReproductorDVD = 2;
            else if (rbtS808_DVD_B.Checked)
                rbtS808_ReproductorDVD = 3;
            if (rbtS808_Motocleta_M.Checked)
                rbtS808_Motocicleta = 1;
            else if (rbtS808_Motocleta_R.Checked)
                rbtS808_Motocicleta = 2;
            else if (rbtS808_Motocicleta_B.Checked)
                rbtS808_Motocicleta = 3;
            if (rbtS808_Automovil_M.Checked)
                rbtS808_Automovil = 1;
            else if (rbtS808_Automovil_R.Checked)
                rbtS808_Automovil = 2;
            else if (rbtS808_Automovil_B.Checked)
                rbtS808_Automovil = 3;
            if (rbtS808_Computadora_M.Checked)
                rbtS808_Computadora = 1;
            else if (rbtS808_Computadora_R.Checked)
                rbtS808_Computadora = 2;
            else if (rbtS808_Computadora_B.Checked)
                rbtS808_Computadora = 3;
            if (rbtS808_Amueblado_M.Checked)
                rbtS808_Amueblado = 1;
            else if (rbtS808_Amueblado_R.Checked)
                rbtS808_Amueblado = 2;
            else if (rbtS808_Amueblado_B.Checked)
                rbtS808_Amueblado = 3;
            if (rbtS808_Otros_M.Checked)
                rbtS808_Otros = 1;
            else if (rbtS808_Otros_R.Checked)
                rbtS808_Otros = 2;
            else if (rbtS808_Otros_B.Checked)
                rbtS808_Otros = 3;
        }

        public Boolean IngresarS807()
        {// se instancia una clase de la pregunta 8-07 y se envian los datos
            NuevaS807 = new S807_ServiciosLN(Convert.ToBoolean(cklS8_S807.GetItemCheckState(0)), Convert.ToBoolean(cklS8_S807.GetItemCheckState(1)), Convert.ToBoolean(cklS8_S807.GetItemCheckState(2)), Convert.ToBoolean(cklS8_S807.GetItemCheckState(3)), Convert.ToBoolean(cklS8_S807.GetItemCheckState(4)));
            Boolean correcto = NuevaS807.Insertar_EncuS807();
            if (!correcto)
            {// si al momento de validarlos e ingresarlos a la base de datos existe error retorna un false
                MessageBox.Show(NuevaS807.obtenerError().mensaje);
                int cant = NuevaS807.errores.Count - 1;
                // se recorre el error el orden descendente para el focus
                for (int i = cant; i >= 0; i--)
                    this.Comprobar_S807(NuevaS807.errores[i].NumeroPregunta);
            }
            return correcto; // no todo ha ido bien de la funcion envia un true;
        }

        /*
         * Se comprueba el componente que tenga error para marcarlo con color 
         */
        private void Comprobar_S807(int pregunta)
        {
            switch (pregunta)
            {
                case 1:
                    cklS8_S807.BackColor = ColorCampsVacios;
                    cklS8_S807.Focus();
                    break;
            }
        }

        /// <summary>
        /// Seccion 8
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pbS8_Siguiente_Click(object sender, EventArgs e)
        {
            this.VerificarCombox_S8(); // se verifican los combobox por si existe alguno que no se haya seleccionado.
            S8_ServiciosLN S8 = new S8_ServiciosLN(cbxS8_AccesoAguatxt, cbxS8_FuenteAguatxt, txtS8_OtraFuente.Text, cbxS8_EnergiaElectricatxt, txtS8_OtraEnergiaElectrica.Text, cbxS8_EnergiaCocinatxt, txtS8_OtraEnergiaCocina.Text, cbxS8_Sanitariotxt, txtS8_OtroTipoSanitario.Text, cbxS8_BasuraHogartxt, txtS8_OtroTipoBasura.Text, this.idEncu);
            Boolean correcto = S8.Verficar_EncS8();

            if (Pregunta807 == false) // sirve para el control de la pregunta 8.07 para solo ingresarla una vez.
            {
                if (this.IngresarS807() == true)
                    Pregunta807 = true;
            }
            if (Pregunta808 == false)// sirve para el control de la pregunta 8.06 para solo ingresarla una vez.
            {
                if (this.IngresarS808() == true)
                    Pregunta808 = true;
            }
            if (Pregunta807 == true && Pregunta808 == true) // si ya se ingresaron los dos se va a insertar todas las preguntas de esta seccion
            {
                goto Ingresar;
            }
            if (!correcto)// si nos retorna falso recorremos la lista de errores
            {
                goto Errores;
            }

        Errores:
            MessageBox.Show(S8.obtenerError().mensaje);
            int cant = S8.errores.Count - 1;
            //se recorre en orden descendente para mayor control del focus.
            for (int i = cant; i >= 0; i--)
                this.Comprobar_S8(S8.errores[i].NumeroPregunta);
            goto Fin;

        Ingresar: // sino existe error se le asignan los id de las preguntas 8.07 y 8.08             
            S8.idS807_serv = NuevaS807.idS807_serv;
            S8.idS808_serv = NuevaS808.idS808_Serv;
            Boolean correcto2 = S8.Insertar_EcS8();
            if (!correcto2) // se ingresa la seccion 8 en la base de datos.
            {
                goto Errores;
            }//se avanza a la siguiente seccion
            tbpS8.Parent = null;
            tbpS9.Parent = tbcDatos;
            cbxS9_1_Propio.Focus();
        Fin:
            return; // termina el evento y no retorna nada.
        }

        /*
         * Se verfican los componentes que tengan errores para marcarlos con otro color.
         */
        private void Comprobar_S9(int pregunta)
        {
            switch (pregunta)
            {
                case 1:
                    cbxS9_1_Propio.BackColor = ColorCampsVacios;
                    cbxS9_1_Propio.Focus();
                    break;
                case 2:
                    cbxS9_Propietario.BackColor = ColorCampsVacios;
                    cbxS9_Propietario.Focus();
                    break;
                case 201:
                    txtS9_OtroPropietario.BackColor = ColorCampsVacios;
                    txtS9_OtroPropietario.Focus();
                    break;
                case 5:
                    cbxS9_OtraPropiedad.BackColor = ColorCampsVacios;
                    cbxS9_OtraPropiedad.Focus();
                    break;
                case 501:
                    txtS9_OtraPropiedadA.BackColor = ColorCampsVacios;
                    txtS9_OtraPropiedadA.Focus();
                    break;
                case 3:
                    cbxS9_TipoPropietario.BackColor = ColorCampsVacios;
                    cbxS9_TipoPropietario.Focus();
                    break;
                case 301:
                    txtS9_OtroTipoPropietario.BackColor = ColorCampsVacios;
                    txtS9_OtroTipoPropietario.Focus();
                    break;
                case 4:
                    txtS9_PropietarioTerreno.BackColor = ColorCampsVacios;
                    txtS9_PropietarioTerreno.Focus();
                    break;
                case 401:
                    txtS9_TelefonoPropietarioTerreno.BackColor = ColorCampsVacios;
                    txtS9_TelefonoPropietarioTerreno.Focus();
                    break;
            }
        }

        /*
         * Se verfican los combobox en caso que no se hayan seleccionado y los campos que se puedan dejar vacios.
         */
        public int VerificarCombox_S9()
        {
            int NumeroCaso = 0;
            if (cbxS9_1_Propio.SelectedIndex != -1)
                cbxS9_Propiotxt = cbxS9_1_Propio.SelectedItem.ToString();

            if (cbxS9_Propietario.SelectedIndex != -1)
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
            if (cbxS9_1_Propio.SelectedIndex == 1)
                NumeroCaso = 2;
            else
                NumeroCaso = 1;

            return NumeroCaso;
        }

        /// <summary>
        /// Seccion 9
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pbS9_Siguiente_Click(object sender, EventArgs e)
        {// verificar contenido de los combobox en caso de no selecionar alguno.
            int caso = this.VerificarCombox_S9();
            S9_PropiedadLN S9;
            if (caso == 1) //segun sean los casos se envia solo algunos parametros y asi dejar algunos vacios cuando existen saltos en la preguntas.
                S9 = new S9_PropiedadLN(cbxS9_Propiotxt, cbxS9_Propietariotxt, txtS9_OtroPropietario.Text, cbxS9_OtraPropiedadtxt, txtS9_OtraPropiedadA.Text, txtS9_OtraPropiedadB.Text, txtS9_OtraPropiedadC.Text, this.idEncu);
            else
                S9 = new S9_PropiedadLN(cbxS9_Propiotxt, cbxS9_TipoPropietariotxt, txtS9_OtroTipoPropietario.Text, txtS9_PropietarioTerreno.Text, txtS9_TelefonoPropietarioTerreno.Text, ckbS9_NSNR.Checked, cbxS9_OtraPropiedadtxt, txtS9_OtraPropiedadA.Text, txtS9_OtraPropiedadB.Text, txtS9_OtraPropiedadC.Text, this.idEncu);

            Boolean correcto = S9.Insertar_EncS9(caso);
            if (correcto) // cuando no existe error, se avanza a la siguiente seccion
            {
                tbpS9.Parent = null;
                tbpS10.Parent = tbcDatos;
                txtS10_Ayudo.Focus();
            }
            else
            { // se recorre el lsita de errores posibles que tengan la preguntas.
                MessageBox.Show(S9.obtenerError().mensaje);
                int cant = S9.errores.Count - 1;
                //se recorrece en orden ascendente para mayor control del focus.
                for (int i = cant; i >= 0; i--)
                    this.Comprobar_S9(S9.errores[i].NumeroPregunta);
            }
        }

        /*
         * Se verfican tipo de errores y se pone el color rojo los compontes con contenido erroneo.
         */
        private void Comprobar_S10(int pregunta)
        {
            switch (pregunta)
            {
                case 1:
                    txtS10_Ayudo.BackColor = ColorCampsVacios;
                    txtS10_Ayudo.Focus();
                    break;
                case 2:
                    txtS10_AyudaVecinos.BackColor = ColorCampsVacios;
                    txtS10_AyudaVecinos.Focus();
                    break;
                case 3:
                    cbxS10_RelacionVecinos.BackColor = ColorCampsVacios;
                    cbxS10_RelacionVecinos.Focus();
                    break;
                case 301:
                    txtS10_CometarioRelacion.BackColor = ColorCampsVacios;
                    txtS10_CometarioRelacion.Focus();
                    break;
                case 4:
                    cbxS10_OrganizarVecinos.BackColor = ColorCampsVacios;
                    cbxS10_OrganizarVecinos.Focus();
                    break;
                case 401:
                    txtS10_OrganizarA.BackColor = ColorCampsVacios;
                    txtS10_OrganizarA.Focus();
                    break;
                case 5:
                    cbxS10_ParticipacionGrupo.BackColor = ColorCampsVacios;
                    cbxS10_ParticipacionGrupo.Focus();
                    break;
                case 6:
                    cklS1006_Com.BackColor = ColorCampsVacios;
                    cklS1006_Com.Focus();
                    break;
                case 601:
                    txtS1006_Especificar.BackColor = ColorCampsVacios;
                    txtS1006_Especificar.Focus();
                    break;
                case 7:
                    cklS1007_Com.BackColor = ColorCampsVacios;
                    cklS1007_Com.Focus();
                    break;
                case 701:
                    txtS1007_Especificar.BackColor = ColorCampsVacios;
                    txtS1007_Especificar.Focus();
                    break;
                case 9:
                    cbxS10_Necesidad.BackColor = ColorCampsVacios;
                    cbxS10_Necesidad.Focus();
                    break;
                case 901:
                    txtS10_NecesidadA.BackColor = ColorCampsVacios;
                    txtS10_NecesidadA.Focus();
                    break;
                case 10:
                    cbxS10_NecesidadCom.BackColor = ColorCampsVacios;
                    cbxS10_NecesidadCom.Focus();
                    break;
                case 1001:
                    txtS10_NecesidadComA.BackColor = ColorCampsVacios;
                    txtS10_NecesidadComA.Focus();
                    break;
                case 11:
                    cbxS10_ProyectosVecinos.BackColor = ColorCampsVacios;
                    cbxS10_ProyectosVecinos.Focus();
                    break;
                case 1101:
                    txtS10_ProyectosVecinosA.BackColor = ColorCampsVacios;
                    txtS10_ProyectosVecinosA.Focus();
                    break;
                case 12:
                    txtS10_ApectosPositivosA.BackColor = ColorCampsVacios;
                    txtS10_ApectosPositivosA.Focus();
                    break;
                case 13:
                    txtS10_ApectosNegativosA.BackColor = ColorCampsVacios;
                    txtS10_ApectosNegativosA.Focus();
                    break;
                case 14:
                    cklS1014_Com.BackColor = ColorCampsVacios;
                    cklS1014_Com.Focus();
                    break;
                case 1401:
                    txtS1014_Especificar.BackColor = ColorCampsVacios;
                    txtS1014_Especificar.Focus();
                    break;
                case 15:
                    cbxS10_Discriminacion.BackColor = ColorCampsVacios;
                    cbxS10_Discriminacion.Focus();
                    break;
                case 1501:
                    txtS10_TipoDiscriminacion.BackColor = ColorCampsVacios;
                    txtS10_TipoDiscriminacion.Focus();
                    break;
                case 16:
                    cbxS10_OrganizacionComunitaria.BackColor = ColorCampsVacios;
                    cbxS10_OrganizacionComunitaria.Focus();
                    break;
                case 17:
                    txtS10_TipoOrganizaciones.BackColor = ColorCampsVacios;
                    txtS10_TipoOrganizaciones.Focus();
                    break;
                case 18:
                    cbxS10_ConfiazaOrganizacion.BackColor = ColorCampsVacios;
                    cbxS10_ConfiazaOrganizacion.Focus();
                    break;
                case 1801:
                    txtS10_ComentarioConfianza.BackColor = ColorCampsVacios;
                    txtS10_ComentarioConfianza.Focus();
                    break;
                case 19:
                    txtS10_LiderA.BackColor = ColorCampsVacios;
                    txtS10_LiderA.Focus();
                    break;
                case 20:
                    cbxS10_EstadoPasado.BackColor = ColorCampsVacios;
                    cbxS10_EstadoPasado.Focus();
                    break;
                case 2001:
                    txtS10_ComentarioEstadoPasado.BackColor = ColorCampsVacios;
                    txtS10_ComentarioEstadoPasado.Focus();
                    break;
                case 21:
                    cbxS10_estadoFuturo.BackColor = ColorCampsVacios;
                    cbxS10_estadoFuturo.Focus();
                    break;
                case 2101:
                    txtS10_ComentarioEstadoFuturo.BackColor = ColorCampsVacios;
                    txtS10_ComentarioEstadoFuturo.Focus();
                    break;
            }
        }

        /*
         * Se pone como vacio cuando combobox no se selecciona
         */
        public int VerificarCombox_S10()
        {
            int NumeroCaso = 0;
            if (cbxS10_RelacionVecinos.SelectedIndex != -1)
                cbxS10_RelacionVecinostxt = cbxS10_RelacionVecinos.SelectedItem.ToString();
            if (cbxS10_OrganizarVecinos.SelectedIndex != -1)
                cbxS10_OrganizarVecinostxt = cbxS10_OrganizarVecinos.SelectedItem.ToString();
            if (cbxS10_ParticipacionGrupo.SelectedIndex != -1)
                cbxS10_ParticipacionGrupotxt = cbxS10_ParticipacionGrupo.SelectedItem.ToString();
            if (cbxS10_Necesidad.SelectedIndex != -1)
                cbxS10_Necesidadtxt = cbxS10_Necesidad.SelectedItem.ToString();
            if (cbxS10_NecesidadCom.SelectedIndex != -1)
                cbxS10_NecesidadComtxt = cbxS10_NecesidadCom.SelectedItem.ToString();
            if (cbxS10_ProyectosVecinos.SelectedIndex != -1)
                cbxS10_ProyectosVecinostxt = cbxS10_ProyectosVecinos.SelectedItem.ToString();
            if (cbxS10_Discriminacion.SelectedIndex != -1)
                cbxS10_Discriminaciontxt = cbxS10_Discriminacion.SelectedItem.ToString();
            if (cbxS10_OrganizacionComunitaria.SelectedIndex != -1)
                cbxS10_OrganizacionComunitariatxt = cbxS10_OrganizacionComunitaria.SelectedItem.ToString();
            if (cbxS10_ConfiazaOrganizacion.SelectedIndex != -1)
                cbxS10_ConfiazaOrganizaciontxt = cbxS10_ConfiazaOrganizacion.SelectedItem.ToString();
            if (cbxS10_EstadoPasado.SelectedIndex != -1)
                cbxS10_EstadoPasadotxt = cbxS10_EstadoPasado.SelectedItem.ToString();
            if (cbxS10_estadoFuturo.SelectedIndex != -1)
                cbxS10_estadoFuturotxt = cbxS10_estadoFuturo.SelectedItem.ToString();
            /// salto de preguntas y asi poder dejar algunos vacios
            if (cbxS10_ParticipacionGrupo.SelectedIndex == 1)
                NumeroCaso = 2;
            if (Pregunta1006Mensaje == true)
                NumeroCaso = 1;
            if (cbxS10_OrganizacionComunitaria.SelectedIndex == 1)
                NumeroCaso = 3;
            return NumeroCaso;
        }

        public Boolean IngresarS1014()
        {   // ser instacia una nueva clase para pregunta 14 y se envia los datos
            NuevaS1014 = new S1014_ComunidadLN(Convert.ToBoolean(cklS1014_Com.GetItemCheckState(0)), Convert.ToBoolean(cklS1014_Com.GetItemCheckState(1)), Convert.ToBoolean(cklS1014_Com.GetItemCheckState(2)), Convert.ToBoolean(cklS1014_Com.GetItemCheckState(3)), Convert.ToBoolean(cklS1014_Com.GetItemCheckState(4)), Convert.ToBoolean(cklS1014_Com.GetItemCheckState(5)), Convert.ToBoolean(cklS1006_Com.GetItemCheckState(6)), Convert.ToBoolean(cklS1006_Com.GetItemCheckState(7)), txtS1014_Especificar.Text, Convert.ToBoolean(cklS1006_Com.GetItemCheckState(8)));

            Boolean correcto = NuevaS1014.Insertar_EncuS1014(); // verficar sino poseen errores en capa logica
            if (!correcto)
            {//se recorre el listado de errores posibles en orden descendente
                MessageBox.Show(NuevaS1014.obtenerError().mensaje);
                int cant = NuevaS1014.errores.Count - 1;

                for (int i = cant; i >= 0; i--)
                    this.Comprobar_S10(NuevaS1014.errores[i].NumeroPregunta);
            }
            return correcto; // si todo a ido bien se envia un true para poder seguir y sacar el ID.
        }

        public Boolean IngresarS1006()
        {// ser instacia una nueva clase para pregunta 10-06 y se envia los datos
            NuevaS1006 = new S1006_ComunidadLN(Convert.ToBoolean(cklS1006_Com.GetItemCheckState(0)), Convert.ToBoolean(cklS1006_Com.GetItemCheckState(1)), Convert.ToBoolean(cklS1006_Com.GetItemCheckState(2)), Convert.ToBoolean(cklS1006_Com.GetItemCheckState(3)), Convert.ToBoolean(cklS1006_Com.GetItemCheckState(4)), Convert.ToBoolean(cklS1006_Com.GetItemCheckState(5)), Convert.ToBoolean(cklS1006_Com.GetItemCheckState(6)), Convert.ToBoolean(cklS1006_Com.GetItemCheckState(7)), txtS1006_Especificar.Text, Convert.ToBoolean(cklS1006_Com.GetItemCheckState(8)));

            Boolean correcto = NuevaS1006.Insertar_EncuS1006();// verficar sino poseen errores en capa logica
            if (!correcto)
            {//se recorre el listado de errores posibles en orden descendente
                MessageBox.Show(NuevaS1006.obtenerError().mensaje);
                int cant = NuevaS1006.errores.Count - 1;

                for (int i = cant; i >= 0; i--)
                    this.Comprobar_S10(NuevaS1006.errores[i].NumeroPregunta);
            }
            return correcto;// si todo a ido bien se envia un true para poder seguir y sacar el ID
        }

        public Boolean IngresarS1007()
        {// ser instacia una nueva clase para pregunta 10-07 y se envia los datos
            NuevaS1007 = new S1007_ComunidadLN(Convert.ToBoolean(cklS1007_Com.GetItemCheckState(0)), Convert.ToBoolean(cklS1007_Com.GetItemCheckState(1)), Convert.ToBoolean(cklS1007_Com.GetItemCheckState(2)), Convert.ToBoolean(cklS1007_Com.GetItemCheckState(3)), Convert.ToBoolean(cklS1007_Com.GetItemCheckState(4)), txtS1007_Especificar.Text, Convert.ToBoolean(cklS1006_Com.GetItemCheckState(5)));

            Boolean correcto = NuevaS1007.Insertar_EncuS1007();// verficar sino poseen errores en capa logica
            if (!correcto)
            {//se recorre el listado de errores posibles en orden descendente
                MessageBox.Show(NuevaS1007.obtenerError().mensaje);
                int cant = NuevaS1007.errores.Count - 1;

                for (int i = cant; i >= 0; i--)
                    this.Comprobar_S10(NuevaS1007.errores[i].NumeroPregunta);
            }
            return correcto;// si todo a ido bien se envia un true para poder seguir y sacar el ID
        }

        public Boolean IngresarS1008()
        {// ser instacia una nueva clase para pregunta 10-08 y se envia los datos
            this.VerificarRadioBtn_S1008();
            NuevaS1008 = new S1008_ComunidadLN(rbtS1008_Familiar, rbtS1008_Vecinos, rbtS1008_lideresComunitarios, rbtS1008_Policia, rbtS1008_Municipalidad, rbtS1008_OrganizacionGobierno, rbtS1008_Ejercito, rbtS1008_partidosPoliticos, rbtS1008_Techo, rbtS1008_MedioComunicacion, rbtS1008_IglesiasReligiosos);
            Boolean correcto = NuevaS1008.Insertar_EncuS1008();// verficar sino poseen errores en capa logica
            if (!correcto)
            {//se recorre el listado de errores posibles en orden descendente
                MessageBox.Show(NuevaS1008.obtenerError().mensaje);
                int cant = NuevaS1008.errores.Count - 1;

                for (int i = cant; i >= 0; i--)
                    this.Comprobar_S10(NuevaS1008.errores[i].NumeroPregunta);
            }
            return correcto;// si todo a ido bien se envia un true para poder seguir y sacar el ID
        }

        /*
         * Se verifican los radioButton's selecionados y asi asignales un valor
         * 0 = NS/NR ; 1 = No; 2 = Indiferente ; 3 = Si
         */
        public void VerificarRadioBtn_S1008()
        {
            if (rbtS1008_Familia_NS.Checked)
                rbtS1008_Familiar = 0;
            else if (rbtS1008_Familia_N.Checked)
                rbtS1008_Familiar = 1;
            else if (rbtS1008_Familia_I.Checked)
                rbtS1008_Familiar = 2;
            else if (rbtS1008_Familia_S.Checked)
                rbtS1008_Familiar = 3;
            if (rbtS1008_Vecinos_NS.Checked)
                rbtS1008_Vecinos = 0;
            else if (rbtS1008_Vecinos_N.Checked)
                rbtS1008_Vecinos = 1;
            else if (rbtS1008_Vecinos_I.Checked)
                rbtS1008_Vecinos = 2;
            else if (rbtS1008_Vecinos_S.Checked)
                rbtS1008_Vecinos = 3;
            if (rbtS1008_LiderCom_NS.Checked)
                rbtS1008_lideresComunitarios = 0;
            else if (rbtS1008_LiderCom_N.Checked)
                rbtS1008_lideresComunitarios = 1;
            else if (rbtS1008_LiderCom_I.Checked)
                rbtS1008_lideresComunitarios = 2;
            else if (rbtS1008_LiderCom_S.Checked)
                rbtS1008_lideresComunitarios = 3;
            if (rbtS1008_Policia_NS.Checked)
                rbtS1008_Policia = 0;
            else if (rbtS1008_Policia_N.Checked)
                rbtS1008_Policia = 1;
            else if (rbtS1008_Policia_I.Checked)
                rbtS1008_Policia = 2;
            else if (rbtS1008_Policia_S.Checked)
                rbtS1008_Policia = 3;
            if (rbtS1008_Muni_NS.Checked)
                rbtS1008_Municipalidad = 0;
            else if (rbtS1008_Muni_N.Checked)
                rbtS1008_Municipalidad = 1;
            else if (rbtS1008_Muni_I.Checked)
                rbtS1008_Municipalidad = 2;
            else if (rbtS1008_Muni_S.Checked)
                rbtS1008_Municipalidad = 3;
            if (rbtS1008_OrgGobierno_NS.Checked)
                rbtS1008_OrganizacionGobierno = 0;
            else if (rbtS1008_OrgGobierno_N.Checked)
                rbtS1008_OrganizacionGobierno = 1;
            else if (rbtS1008_OrgGobierno_I.Checked)
                rbtS1008_OrganizacionGobierno = 2;
            else if (rbtS1008_OrgGobierno_S.Checked)
                rbtS1008_OrganizacionGobierno = 3;
            if (rbtS1008_Ejercito_NS.Checked)
                rbtS1008_Ejercito = 0;
            else if (rbtS1008_Ejercito_N.Checked)
                rbtS1008_Ejercito = 1;
            else if (rbtS1008_Ejercito_I.Checked)
                rbtS1008_Ejercito = 2;
            else if (rbtS1008_Ejercito_S.Checked)
                rbtS1008_Ejercito = 3;
            if (rbtS1008_Politicos_NS.Checked)
                rbtS1008_partidosPoliticos = 0;
            else if (rbtS1008_Politicos_N.Checked)
                rbtS1008_partidosPoliticos = 1;
            else if (rbtS1008_Politicos_I.Checked)
                rbtS1008_partidosPoliticos = 2;
            else if (rbtS1008_Politicos_S.Checked)
                rbtS1008_partidosPoliticos = 3;
            if (rbtS1008_Techo_NS.Checked)
                rbtS1008_Techo = 0;
            else if (rbtS1008_Techo_N.Checked)
                rbtS1008_Techo = 1;
            else if (rbtS1008_Techo_I.Checked)
                rbtS1008_Techo = 2;
            else if (rbtS1008_Techo_S.Checked)
                rbtS1008_Techo = 3;
            if (rbtS1008_Comunicacion_NS.Checked)
                rbtS1008_MedioComunicacion = 0;
            else if (rbtS1008_Comunicacion_N.Checked)
                rbtS1008_MedioComunicacion = 1;
            else if (rbtS1008_Comunicacion_I.Checked)
                rbtS1008_MedioComunicacion = 2;
            else if (rbtS1008_Comunicacion_S.Checked)
                rbtS1008_MedioComunicacion = 3;
            if (rbtS1008_Iglesia_NS.Checked)
                rbtS1008_IglesiasReligiosos = 0;
            else if (rbtS1008_Iglesia_N.Checked)
                rbtS1008_IglesiasReligiosos = 1;
            else if (rbtS1008_Iglesia_I.Checked)
                rbtS1008_IglesiasReligiosos = 2;
            else if (rbtS1008_Iglesia_S.Checked)
                rbtS1008_IglesiasReligiosos = 3;
        }

        /// <summary>
        /// Seccion 10
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pbS10Cont_Siguiente_Click(object sender, EventArgs e)
        {
            int caso = this.VerificarCombox_S10(); // se verfican los combobox de la seccion 10 para que no queden vacios o no seleccionados
            NuevaS10_Comunidad.S10_ComunidadLNCont(this.ckbS10_Positivo.Checked, txtS10_ApectosPositivosA.Text, txtS10_ApectosPositivosB.Text, ckbS10_Negativo.Checked, txtS10_ApectosNegativosA.Text, txtS10_ApectosNegativosB.Text, cbxS10_Discriminaciontxt, txtS10_TipoDiscriminacion.Text, cbxS10_OrganizacionComunitariatxt, txtS10_TipoOrganizaciones.Text, cbxS10_ConfiazaOrganizaciontxt, txtS10_ComentarioConfianza.Text, ckbS10_Lider.Checked, txtS10_LiderA.Text, txtS10_LiderB.Text, txtS10_LiderC.Text, cbxS10_EstadoPasadotxt, txtS10_ComentarioEstadoPasado.Text, cbxS10_estadoFuturotxt, txtS10_ComentarioEstadoFuturo.Text, NuevaS1014.idS1014_com);
            Boolean correcto = NuevaS10_Comunidad.Insertar_EncuS10Cont(caso); // se agrega la segunda parte de la encuestas y se verfica en la capa logica de negocio
            if (!correcto)
            {
                goto Errores; // si contiene errores se dirige en esa seccion
            }
            if (Pregunta1014 == false) // se verfica si ya se ingreso es pregunta S1014 
            {
                if (this.IngresarS1014() == true)
                {
                    Pregunta1014 = true;
                    goto Ingresar; // no redirige al apartado ingresar ya se obtuvo el id de la S1014_comunidad
                }
            }

        Errores: // se reccorren los errores y muestra el mensaje del primer error
            MessageBox.Show(NuevaS10_Comunidad.obtenerError().mensaje);
            int cant = NuevaS10_Comunidad.errores.Count - 1;

            for (int i = cant; i >= 0; i--)
                this.Comprobar_S10(NuevaS10_Comunidad.errores[i].NumeroPregunta); //se corre de orden descendente para el focus.
            goto Fin;

        Ingresar: // se ingresa el ID de la pregunta 14 
            NuevaS10_Comunidad.idS1014 = NuevaS1014.idS1014_com;
            Boolean correcto2 = NuevaS10_Comunidad.Insertar_S10_Com(Pregunta1014); // se envia para la capa de datos
            if (!correcto2 == true) //si contiene errores regresa al apartado de errores
                goto Errores;
            else
            {
                tbpS10Cont.Parent = null; // se avanza a la siguiente seccion.
                tbpS11.Parent = tbcDatos;
                cbxS11_1_VidaFamiliar.Focus();
            }
        Fin:
            return; // sirve para terminar el evento y no retorna nada.
        }

        /// <summary>
        /// continuacion de seccion 10
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pbS10_Siguiente_Click(object sender, EventArgs e)
        {
            int caso = this.VerificarCombox_S10(); // se verfican los combobox de la seccion 10 para que no queden vacios o no seleccionados
            NuevaS10_Comunidad = new S10_ComunidadLN(txtS10_Ayudo.Text, txtS10_AyudaVecinos.Text, cbxS10_RelacionVecinostxt, txtS10_CometarioRelacion.Text, cbxS10_OrganizarVecinostxt, txtS10_OrganizarA.Text, txtS10_OrganizarB.Text, txtS10_OrganizarC.Text, cbxS10_ParticipacionGrupotxt, cbxS10_Necesidadtxt, txtS10_NecesidadA.Text, txtS10_NecesidadB.Text, txtS10_NecesidadC.Text, cbxS10_NecesidadComtxt, txtS10_NecesidadComA.Text, txtS10_NecesidadComB.Text, txtS10_NecesidadComC.Text, cbxS10_ProyectosVecinostxt, txtS10_ProyectosVecinosA.Text, txtS10_ProyectosVecinosB.Text, txtS10_ProyectosVecinosC.Text, this.idEncu, NuevaS1006.idS1006_com, NuevaS1007.idS1007_com, NuevaS1008.idS1008_Com);
            Boolean correcto = NuevaS10_Comunidad.Insertar_EncuS10(); // se ingresa la primera parte de esta seccion
            if (!correcto) // si existe error en capa logica
            {//nos muestra el primer error y recorremos todos los errores en orden descendente.
                goto Errores;
            }
            if (Pregunta1006 == false && caso == 1)// se comprueba si ya se ingreso pregunta 10-06 :: si es caso uno se debe ingresar y dejar vacio 10-07
            {
                if (this.IngresarS1006() == true)
                    Pregunta1006 = true;
            }
            if (Pregunta1007 == false && caso == 2)// se comprueba si ya se ingreso pregunta 10-07 :: si caso 2 se debe ingresar y dejar vacio 10-06
            {
                if (this.IngresarS1007() == true)
                    Pregunta1007 = true;
            }
            if (Pregunta1008 == false)// se comprueba si ya se ingreso pregunta 10-08
            {
                if (this.IngresarS1008() == true)
                    Pregunta1008 = true;
            }
            if (correcto == true)
            {
                goto Avanzar; //si la seccion no tiene errores se puede avanzar a la siguiente seccion
            }

        Errores:// muesta lo posibles errores siempre en orden ascendente
            MessageBox.Show(NuevaS10_Comunidad.obtenerError().mensaje);
            int cant = NuevaS10_Comunidad.errores.Count - 1;

            for (int i = cant; i >= 0; i--)
                this.Comprobar_S10(NuevaS10_Comunidad.errores[i].NumeroPregunta);
            goto fin;

        Avanzar:
               NuevaS10_Comunidad.idS1006 =  NuevaS1006.idS1006_com ;
               NuevaS10_Comunidad.idS1007 =  NuevaS1007.idS1007_com;
               NuevaS10_Comunidad.idS1008 = NuevaS1008.idS1008_Com;
               if (!NuevaS10_Comunidad.Ingresar_encuestaS10() == true) { goto Errores; }
               // se activa la siguiente seccion y se oculta el actual.
               else
               {
                   tbpS10.Parent = null;
                   tbpS10Cont.Parent = tbcDatos;
                   txtS10_ApectosPositivosA.Focus();
               }
        fin:
            return; // finaliza el envento no envia nada
        }

        /*
         * Dependiendo del componente que poseea el error por su numero recibido, se verifica y se colorea dicho componente con color rojo.
         */
        public void Comprobar_S11(int pregunta)
        {
            switch (pregunta)
            {
                case 1:
                    cbxS11_1_VidaFamiliar.BackColor = ColorCampsVacios;
                    cbxS11_1_VidaFamiliar.Focus();
                    break;
                case 2:
                    txtS11_2_DireccionPasada.BackColor = ColorCampsVacios;
                    txtS11_2_DireccionPasada.Focus();
                    break;
                case 3:
                    txtS11_3a_AñoTraslado.BackColor = ColorCampsVacios;
                    txtS11_3a_AñoTraslado.Focus();
                    break;
                case 301:
                    txtS11_3b_Porque.BackColor = ColorCampsVacios;
                    txtS11_3b_Porque.Focus();
                    break;
                case 4:
                    cbxS11_4_ViviedaActual.BackColor = ColorCampsVacios;
                    cbxS11_4_ViviedaActual.Focus();
                    break;
                case 5:
                    txt_S11_ComentarioFinal.BackColor = ColorCampsVacios;
                    txt_S11_ComentarioFinal.Focus();
                    break;
            }
        }

        /*
         * Comprobar cada combobox si no estan vacios
         */
        public int VerificarCombobox_S11()
        {
            int caso = 0;
            if (cbxS11_1_VidaFamiliar.SelectedIndex != -1)
                cbxS11_1_VidaFamiliartxt = cbxS11_1_VidaFamiliar.SelectedItem.ToString();
            if (cbxS11_4_ViviedaActual.SelectedIndex != -1)
                cbxS11_4_ViviedaActualtxt = cbxS11_4_ViviedaActual.SelectedItem.ToString();
            if (cbxS11_1_VidaFamiliar.SelectedIndex == 0) // dependiendo que contenido es selecionado para dar un salto y dejar algunos campos vacios
                caso = 1;
            else
                caso = 2;
            return caso;
        }

        /// <summary>
        /// Seccion 11
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pbS11_Siguiente_Click(object sender, EventArgs e)
        {
            // se verfica todos los combox de la seccion 11 por si alguno no se ha selecionado.
            int caso = this.VerificarCombobox_S11();
            //se instancia la clase para enviar datos a la capa logica
            S11_MovilidadLN S11 = new S11_MovilidadLN(cbxS11_1_VidaFamiliartxt, txtS11_2_DireccionPasada.Text, txtS11_3a_AñoTraslado.Text, txtS11_3b_Porque.Text, cbxS11_4_ViviedaActualtxt, txt_S11_ComentarioFinal.Text, this.idEncu);
            Boolean correcto = S11.Ingresar_S11(caso); // si es verdadero significa que no tiene errores
            if (correcto)
            { // terminamos la transaccion para realizar el commit
                if (!tran.TerminarTransaccion())
                {
                    DialogResult pregunta = MessageBox.Show("Desea Ingresar una nueva Encuesta?", "Pregunta!", MessageBoxButtons.YesNo);
                    if (pregunta == DialogResult.Yes)
                    {
                        transaccion = false; // la transaccion a sido existosa y se reinicia la ventana para ingresar una nueva encuesta
                        Reiniciar = true;
                        txtCodigoHogar.Focus();
                        this.Close();
                    }
                    else if (pregunta == DialogResult.No)
                        this.Close(); // sino responde solo se cierra la ventana
                }
                else
                    MessageBox.Show("No se ha podido ingresar encuesta, intente de nuevo", "Advertencia", MessageBoxButtons.OK);
            }
            else
            { // mostramos los posibles errores que hayan ocurrido tanto en la capa logica como datos
                MessageBox.Show(S11.obtenerError().mensaje);
                int cant = S11.errores.Count - 1;

                for (int i = cant; i >= 0; i--) //el recorido es decendente, asi no queda el utilmo como el primer error encontrado y ayuda a que el focus no se pierda de las primeras preguntas
                    this.Comprobar_S11(S11.errores[i].NumeroPregunta); //verifica en que componente ocurrio el error
            }
        }

        /// <summary>
        /// Cambios de Indices en Combobox seccion 6
        /// Se utiliza para activar campos en caso de que las preguntas necesitan ser especificadas.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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

        /// <summary>
        /// Cambios de Indices en Combobox seccion 7
        /// Se utiliza para activar campos en caso de que las preguntas necesitan ser especificadas.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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

        /// <summary>
        /// Cambios de Indices en Combobox seccion 8
        /// Se utiliza para activar campos en caso de que las preguntas necesitan ser especificadas.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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

        /// <summary>
        /// Cambios de Indices en Combobox seccion 9 
        /// Se utiliza para activar campos en caso de que las preguntas necesitan ser especificadas.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cbxS9_Propietario_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbxS9_Propietario.SelectedIndex.Equals(3))
            {
                txtS9_OtroPropietario.Enabled = true;
                txtS9_OtroPropietario.Focus();
            }
            else
            {
                txtS9_OtroPropietario.Enabled = false;
                cbxS9_OtraPropiedad.Focus();
            }
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

        /// <summary>
        /// Cambios de Indices en Combobox seccion 10
        /// Se utiliza para activar campos en caso de que las preguntas necesitan ser especificadas.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
            if (cbxS10_ConfiazaOrganizacion.SelectedIndex.Equals(2))
                txtS10_ComentarioConfianza.Enabled = false;
            else
                txtS10_ComentarioConfianza.Enabled = true;
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
        
        /*
         * Con este método se inicia el formulario de la encuesta
         */
        private void frmEncuesta_Load(object sender, EventArgs e)
        {
            //tbpInfo.Parent = null;
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
            tbpS11.Parent = null;
            dgvS1.Columns[0].ReadOnly = true;
            dgvS2.Columns[0].ReadOnly = true;
            dgvS3.Columns[0].ReadOnly = true;
            dgvS4.Columns[0].ReadOnly = true;
            dgvS5.Columns[0].ReadOnly = true;
            _VoluntariosLN Voluntarios = new _VoluntariosLN();

            cmbEncuestador1.DataSource = Voluntarios.Obtener_VNomCompleto();
            cmbEncuestador1.Text = null;
            cmbEncuestador1.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cmbEncuestador1.AutoCompleteSource = AutoCompleteSource.ListItems;

            cmbEncuestador2.DataSource = Voluntarios.Obtener_VNomCompleto();
            cmbEncuestador2.Text = null;
            cmbEncuestador2.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cmbEncuestador2.AutoCompleteSource = AutoCompleteSource.ListItems;

            _Departamento depto = new _Departamento();
            dgvCmbDepto.DataSource = depto.Obtener_D();
            dgvCmbDepto.DisplayMember = "nombre";

            _Municipio muni = new _Municipio();
            dgvCmbMuni.DisplayMember = "nombre";

            dgvCmbMuni.DataSource = muni.ObtenerTodosMuni();
        }        

        int iS1 = 1;
        private void btnAddS1_Click(object sender, EventArgs e)
        {
            dgvS1.Rows.Add();//Agregar filas en datagrid de seccion 1
            dgvS1.Rows[iS1 - 1].Cells[0].Value = iS1;
            dgvS1.Rows[iS1 - 1].Cells[1].Value = "";
            dgvS1.Rows[iS1 - 1].Cells[2].Value = "";
            dgvS1.Rows[iS1 - 1].Cells[3].Value = "DD/MM/AAAA";
            dgvS1.Rows[iS1 - 1].Cells[4].Value = "Hombre";
            dgvS1.Rows[iS1 - 1].Cells[5].Value = "No";
            iS1++;
        }

        private void btnRemS1_Click(object sender, EventArgs e)
        {
            try
            {
                dgvS1.Rows.RemoveAt(dgvS1.Rows.Count - 1);
                iS1--;
                // remover filas del datagrid de seccion 1
            }
            catch (Exception ex)
            { }
        }

        /// <summary>
        /// Para verificar los radiobuttom de la seccion 8
        /// true si estan marcados y false si no lo estan
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void rbtS808_Otros_B_CheckedChanged(object sender, EventArgs e)
        {
            if (rbtS808_Otros_B.Checked)
                rbtS808_OtroEspecificar.Enabled = true;
            else
                rbtS808_OtroEspecificar.Enabled = false;
        }

        private void rbtS808_Otros_R_CheckedChanged(object sender, EventArgs e)
        {
            if (rbtS808_Otros_R.Checked)
                rbtS808_OtroEspecificar.Enabled = true;
            else
                rbtS808_OtroEspecificar.Enabled = false;
        }

        private void rbtS808_Otros_M_CheckedChanged(object sender, EventArgs e)
        {
            if (rbtS808_Otros_M.Checked)
                rbtS808_OtroEspecificar.Enabled = true;
            else
                rbtS808_OtroEspecificar.Enabled = false;
        }

        private void dgvS1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            /*if (dgvS1.CurrentRow.Cells[3].Value.ToString() == "DD/MM/AAAA")
                dgvS1.CurrentRow.Cells[3].Value = "";*/
        }        

        private void cklS1007_Com_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            if (cklS1007_Com.GetSelected(4) == true)
                txtS1007_Especificar.Enabled = true;
            else
                txtS1007_Especificar.Enabled = false;
        }

        private void cklS1006_Com_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            if (cklS1006_Com.GetSelected(7) == true)
                txtS1006_Especificar.Enabled = true;
            else
                txtS1006_Especificar.Enabled = false;

            if (Pregunta1006Mensaje == false)
                Pregunta1006Mensaje = true;
        }

        private void cklS1014_Com_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cklS1014_Com.GetSelected(7) == true)
                txtS1014_Especificar.Enabled = true;
            else
                txtS1014_Especificar.Enabled = false;
        }

        private void cbxS9_1_Propio_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            if (cbxS9_1_Propio.SelectedIndex == 1)
                cbxS9_TipoPropietario.Focus();
        }

        private void cbxS11_1_VidaFamiliar_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbxS11_1_VidaFamiliar.SelectedIndex == 0)
                cbxS11_4_ViviedaActual.Focus();
        }

        private void cbxS10_ParticipacionGrupo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbxS10_ParticipacionGrupo.SelectedIndex == 1)
                cklS1007_Com.Focus();
        }

        private void cbxS10_OrganizacionComunitaria_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbxS10_OrganizacionComunitaria.SelectedIndex == 1)
                txtS10_LiderA.Focus();
        }

        private void dgvS2_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            if (e.Control is DataGridViewComboBoxEditingControl)
            {
                ((ComboBox)e.Control).DropDownStyle = ComboBoxStyle.DropDown;
                ((ComboBox)e.Control).AutoCompleteSource = AutoCompleteSource.ListItems;
                ((ComboBox)e.Control).AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            }
        }

        /*
         * Cambios de Indices en Combobox seccion 7
         * Se utiliza para activar campos en caso de que las preguntas necesitan ser especificadas.
         */
        private void cbsS7_5_ProbViv_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            if (cbsS7_5_ProbViv.SelectedIndex == 0)
            {
                lblS7_5_A.Enabled = true;
                txtS7_5_ProblemaA.Enabled = true;
                lblS7_5_B.Enabled = true;
                txtS7_5_ProblemaB.Enabled = true;
                lblS7_5_C.Enabled = true;
                txtS7_5_ProblemaC.Enabled = true;
            }
            else
            {
                lblS7_5_A.Enabled = false;
                txtS7_5_ProblemaA.Enabled = false;
                lblS7_5_B.Enabled = false;
                txtS7_5_ProblemaB.Enabled = false;
                lblS7_5_C.Enabled = false;
                txtS7_5_ProblemaC.Enabled = false;
            }
        }

        /*
         * Cambios de Indices en Combobox seccion 6
         * Se utiliza para activar campos en caso de que las preguntas necesitan ser especificadas.
         */
        private void cbxS6_1_IngEstado_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            if (cbxS6_1_IngEstado.SelectedIndex == 0)
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

        private void cbxS6_2_IngRemesas_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            if (cbxS6_2_IngRemesas.SelectedIndex == 0)
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

        private void frmEncuesta_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (transaccion == true) //se recodifico por si da error al cerrar la ventana.
            {
                tran.Deshacer(); // si se cierra la encuesta antes de terminar hace un rollback de la transaccion
                return;
            }
            else
                return;
        }

        // Controlar los saltos de la seccion 6
        private void cbxS6_3_Deuda_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbxS6_3_Deuda.SelectedIndex == 2 || cbxS6_3_Deuda.SelectedIndex == 3)
            {
                txtS6_4_CantiDeuda.Text = "0";
                txtS6_6_IngresoTotal.Focus();
            }
            if (cbxS6_3_Deuda.SelectedIndex == 0)
            {
                txtS6_4_CantiDeuda.Focus();
            }
        }

        private void cbxS6_7_CubrenGasto_SelectedValueChanged(object sender, EventArgs e)
        {
            if(cbxS6_7_CubrenGasto.SelectedIndex == 1)
            {
                txtS6_10_CantiGastosaIngresos.Focus();
            }
            if (cbxS6_7_CubrenGasto.SelectedIndex == 2 || cbxS6_7_CubrenGasto.SelectedIndex == 3)
            {
                pbS6_Siguiente.Focus();
            }
            if (cbxS6_7_CubrenGasto.SelectedIndex == 0)
            {
                cbxS6_8_AhorroMensual.Focus();
            }
        }

        private void txtS6_9_CantiAhorro_TextChanged(object sender, EventArgs e)
        {
            if (txtS6_9_CantiAhorro.Text != "")
            {
                pbS6_Siguiente.Focus();
            }
        }

    }
}
