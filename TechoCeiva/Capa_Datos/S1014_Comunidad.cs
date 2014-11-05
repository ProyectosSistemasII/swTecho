using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using MySql.Data.MySqlClient;
using System.Windows.Forms;

namespace Capa_Datos
{
    public class S1014_Comunidad
    {
        public int idS1014_com { get; set; }
        public Boolean Niños { get; set; }
        public Boolean jovenes { get; set; }
        public Boolean Mujeres { get; set; }
        public Boolean TerceraEdad { get; set; }
        public Boolean Discapacitados { get; set; }
        public Boolean GruposEtnicos { get; set; }
        public Boolean NoGruposVulnerables { get; set; }
        public Boolean Otros { get; set; }
        public String Especificar { get; set; }
        public Boolean NSNR { get; set; }

        public List<Error> errores { get; set; }
        private static ConexionBD datos = new ConexionBD();
        private static MySqlConnection conex = ConexionBD.conexion;

        public S1014_Comunidad()
        {
            this.idS1014_com = 0;
            this.Niños = false;
            this.jovenes = false;
            this.Mujeres = false;
            this.TerceraEdad = false;
            this.Discapacitados = false;
            this.GruposEtnicos = false;
            this.NoGruposVulnerables = false;
            this.Otros = false;
            this.Especificar = "";
            this.NSNR = false;
        }

        public S1014_Comunidad(int idS1014, Boolean Niño, Boolean jovenes, Boolean mujeres,Boolean terceraedad, Boolean discapacitados, Boolean gruposetnicos, Boolean nogruposVulnerables, Boolean otros, String especificar, Boolean NSNR)
        {
            this.idS1014_com = idS1014;
            this.Niños = Niño;
            this.jovenes = jovenes;
            this.Mujeres = mujeres;
            this.TerceraEdad = terceraedad;
            this.Discapacitados = discapacitados;
            this.GruposEtnicos = gruposetnicos;
            this.NoGruposVulnerables = nogruposVulnerables;
            this.Otros = otros;
            this.Especificar = especificar;
            this.NSNR = NSNR;
            this.errores = new List<Error>();
        }

        public void InsertarS1014()
        {
            if (this.errores.Count == 0)
            {
                string consulta = "INSERT INTO S1014_com(Niños,Jovenes,Mujeres,TerceraEdad,Discapacitados,GruposEtnicos,NoGruposVulnerables,Otros,Especificar,NSNR) VALUES(@Niños,@Jovenes,@Mujeres,@TerceraEdad,@Discapacitados,@GruposEtnicos,@NoGruposVulnerables,@Otros,@Especificar,@NSNR)";
                MySqlCommand comando = new MySqlCommand(consulta, conex);
                comando.Parameters.AddWithValue("@Niños", this.Niños);
                comando.Parameters.AddWithValue("@Jovenes", this.jovenes);
                comando.Parameters.AddWithValue("@Mujeres", this.Mujeres);
                comando.Parameters.AddWithValue("@TerceraEdad", this.TerceraEdad);
                comando.Parameters.AddWithValue("@Discapacitados", this.Discapacitados);
                comando.Parameters.AddWithValue("@GruposEtnicos", this.GruposEtnicos);
                comando.Parameters.AddWithValue("@NoGruposVulnerables", this.NoGruposVulnerables);
                comando.Parameters.AddWithValue("@Otros", this.Otros);
                comando.Parameters.AddWithValue("@Especificar", this.Especificar);
                comando.Parameters.AddWithValue("@NSNR", this.NSNR);

                try
                {
                    //comando.Connection.Open();
                    comando.ExecuteNonQuery();
                    //comando.Connection.Close();
                }
                catch (MySqlException ex)
                {
                    Error error = new Error(ex.Message + "   " + ex.Number, 2);
                    errores.Add(error);
                }
            }
        }

        public List<S1014_Comunidad> ObtenerS1014()
        {
            List<S1014_Comunidad> ListaComunidad = new List<S1014_Comunidad>();
            MySqlCommand comando = new MySqlCommand("SELECT * FROM S1014_Com WHERE Activo = true", conex);
            comando.CommandTimeout = 12280;
            DataSet ds = new DataSet();
            MySqlDataAdapter Adapter = new MySqlDataAdapter();
            Adapter.SelectCommand = comando;
            Adapter.Fill(ds);
            DataTable tabla = new DataTable();
            tabla = ds.Tables[0];
            for (int i = 0; i < tabla.Rows.Count; i++)
            {
                DataRow row = tabla.Rows[i];
                S1014_Comunidad comunidad = new S1014_Comunidad(Convert.ToInt32(row["idS1014_Com"]), Convert.ToBoolean(row["Niños"]), Convert.ToBoolean(row["jovenes"]), Convert.ToBoolean(row["Mujeres"]), Convert.ToBoolean(row["TerceraEdad"]), Convert.ToBoolean(row["Discapacitados"]), Convert.ToBoolean(row["GruposEtnicos"]), Convert.ToBoolean(row["NoGruposVulnerables"]), Convert.ToBoolean(row["Otros"]), Convert.ToString(row["Especificar"]), Convert.ToBoolean(row["NSNR"]));
                ListaComunidad.Add(comunidad);
            }
            return ListaComunidad;
        }

        public Int32 Obtener_Ultima_EncS1014()
        {
            int i = 0;
            MySqlCommand comando = new MySqlCommand("select max(idS1014_Com) as Contador from S1014_Com", conex);
            comando.CommandTimeout = 12280;
            DataSet ds = new DataSet();
            MySqlDataAdapter Adapter = new MySqlDataAdapter();
            Adapter.SelectCommand = comando;
            Adapter.Fill(ds);
            DataTable tabla = new DataTable();
            tabla = ds.Tables[0];
            DataRow row = tabla.Rows[0];
            i = Convert.ToInt32(row["Contador"]);
            if (i == 0)
            {
                Error error = new Error("", 41);
                errores.Add(error);
            }
            return i;
        }
        public DataTable GenerarReporte(int comunidad)
        {
            try
            {
                string consulta = "SELECT IF(Niños = 1, 'Niños','No Responde') as Ninos , IF(Jovenes = 1, 'Jovenes','No Responde') as Jovenes, IF(Mujeres = 1, 'Mujeres','No Responde') as Mujeres,IF(TerceraEdad = 1, 'TerceraEdad','No Responde') as TerceraEdad, IF(Discapacitados = 1, 'Discapacitados','No Responde') as Discapacitados,IF(GruposEtnicos = 1, 'Grupos Etnicos','No Responde') as GruposEtnicos,IF(NoGruposVulnerables = 1, 'No Existe Grupos Vulnerables','No Responde') as NoGruposVulnerables,IF(Otros = 1, 'Otros','No Responde') as Otros,IF(NSNR = 1, 'No Sabe','No Responde') as NSNR FROM S1014_com   inner join S10_Com on S1014_com_idS1014_com = idS1014_Com inner join Encuestas on Comunidad_idComunidad = @idComunidad and Encuestas_idEncuestas = idencuestas Order by Jovenes";
                MySqlCommand comando = new MySqlCommand(consulta, conex);
                comando.Parameters.AddWithValue("@idComunidad", comunidad);
                comando.CommandTimeout = 12280;
                DataSet ds = new DataSet();
                MySqlDataAdapter da = new MySqlDataAdapter(comando);
                da.Fill(ds);
                return ds.Tables[0];
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message + "   " + ex.Number, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                ///Error error = new Error(ex.Message + "   " + ex.Number, 2);
                //errores.Add(error);
                return null;
            }
        }
    }
}
