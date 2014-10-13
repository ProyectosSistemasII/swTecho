using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using MySql.Data.MySqlClient;

namespace Capa_Datos
{
    public class S1007_Comunidad
    {
        public int idS1007_com { get; set; }
        public Boolean NoInteresa { get; set; }
        public Boolean FaltaInformacion { get; set; }
        public Boolean FaltaTiempo { get; set; }
        public Boolean CompromisoFamiliar { get; set; }
        public Boolean Otros { get; set; }
        public String Especificar { get; set; }
        public Boolean NSNR { get; set; }

        public List<Error> errores { get; set; }
        private static ConexionBD datos = new ConexionBD();
        private static MySqlConnection conex = ConexionBD.conexion;

        public S1007_Comunidad()
        {
            this.idS1007_com = 0;
            this.NoInteresa = false;
            this.FaltaInformacion = false;
            this.FaltaTiempo = false;
            this.CompromisoFamiliar = false;
            this.Otros = false;
            this.Especificar = "";
            this.NSNR = false;
        }

        public S1007_Comunidad(int idS1007,Boolean nointeresa, Boolean faltainformacion, Boolean faltatiempo, Boolean compromisofamiliar, Boolean otros, String especificar, Boolean NSNR )
        {
            this.idS1007_com = idS1007;
            this.NoInteresa = nointeresa;
            this.FaltaInformacion = faltainformacion;
            this.FaltaTiempo = faltatiempo;
            this.CompromisoFamiliar = compromisofamiliar;
            this.Otros = otros;
            this.Especificar = especificar;
            this.NSNR = NSNR;
            this.errores = new List<Error>();
        }

        public void InsertarS1007()
        {
            if (this.errores.Count == 0)
            {
                string consulta = "INSERT INTO S1007_com(NoInteresa,FaltaInformacion,FaltaTiempo,CompromisoFamiliar,Otro,Especificar,NSNR) VALUES(@NoInteresa,@FaltaInformacion,@FaltaTiempo,@CompromisoFamiliar,@Otros,@Especificar,@NSNR)";
                MySqlCommand comando = new MySqlCommand(consulta, conex);
                comando.Parameters.AddWithValue("@NoInteresa", this.NoInteresa);
                comando.Parameters.AddWithValue("@FaltaInformacion", this.FaltaInformacion);
                comando.Parameters.AddWithValue("@FaltaTiempo", this.FaltaTiempo);
                comando.Parameters.AddWithValue("@CompromisoFamiliar", this.CompromisoFamiliar);
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

        public List<S1007_Comunidad> ObtenerS1007()
        {
            List<S1007_Comunidad> ListaComunidad = new List<S1007_Comunidad>();
            MySqlCommand comando = new MySqlCommand("SELECT * FROM S1007_Com WHERE Activo = true", conex);
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
                S1007_Comunidad comunidad = new S1007_Comunidad(Convert.ToInt32(row["idS1007_Com"]), Convert.ToBoolean(row["NoInteresa"]), Convert.ToBoolean(row["FaltaInformacion"]), Convert.ToBoolean(row["FaltaTiempo"]), Convert.ToBoolean(row["CompromisoFamiliar"]), Convert.ToBoolean(row["Otros"]), Convert.ToString(row["Especificar"]), Convert.ToBoolean(row["NSNR"]));
                ListaComunidad.Add(comunidad);
            }
            return ListaComunidad;

        }

        public Boolean eliminarS1007(string id)
        {
            MySqlCommand eliminar = new MySqlCommand("update  S1007_com set Activo=false where idS1007_Com='" + id + "'", conex);

            eliminar.Connection.Open();
            eliminar.ExecuteNonQuery();
            eliminar.Connection.Close();
            return true;
        }

        public Int32 Obtener_Ultima_EncS1007()
        {
            int i = 0;
            MySqlCommand comando = new MySqlCommand("select max(idS1007_Com) as Contador from S1007_com", conex);
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
    }
}
