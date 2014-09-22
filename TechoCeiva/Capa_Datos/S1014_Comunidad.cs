using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using MySql.Data.MySqlClient;

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

        }
        public void InsertarS1014()
        {

            if (this.errores.Count == 0)
            {
                string consulta = ""; //= "INSERT INTO S9_prop(CodigoS11,VidaFamiliar,DireccionPasada,AnioTraslado,ViviendaActual,ComentarioFinal,Encuestas_idEncuestas) VALUES(@CodigoS11,VidaFamiliar,@DireccionPasada,@AnioTraslado,@ViviendaActual,@ComentarioFinal,@Encuestas_idEncuestas)";
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
                    comando.Connection.Open();
                    comando.ExecuteNonQuery();
                    comando.Connection.Close();
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
        public Boolean eliminarS1014(string id)
        {
            MySqlCommand eliminar = new MySqlCommand("update  S1014_com set Activo=false where idS1014_Com='" + id + "'", conex);

            eliminar.Connection.Open();
            eliminar.ExecuteNonQuery();
            eliminar.Connection.Close();
            return true;
        }

    }
}
