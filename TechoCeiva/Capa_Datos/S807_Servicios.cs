using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MySql.Data.MySqlClient;
using System.Data;

namespace Capa_Datos
{
    public class S807_Servicios
    {

        public int idS807_serv {get; set;}
        public Boolean Ninguno { get; set; }
        public Boolean CableTV { get; set; }
        public Boolean TelefonoResid { get; set; }
        public Boolean Internet { get; set; }
        public Boolean NSNR { get; set; }

        public List<Error> errores { get; set; }
        private static ConexionBD datos = new ConexionBD();
        private static MySqlConnection conex = ConexionBD.conexion;

        public S807_Servicios()
        {
            this.idS807_serv = 0;
            this.Ninguno = false;
            this.CableTV = false;
            this.TelefonoResid = false;
            this.Internet = false;
            this.NSNR = false;

        }
        public S807_Servicios(int idS08, Boolean Ninguno, Boolean Cable, Boolean Telefono, Boolean Internet, Boolean NSNR)
        {
            this.idS807_serv = idS08;
            this.CableTV = Cable;
            this.Ninguno = Ninguno;
            this.TelefonoResid = Telefono;
            this.Internet = Internet;
            this.NSNR = NSNR;
            this.errores = new List<Error>();
        }
        public void InsertarS807()
        {

            if (this.errores.Count == 0)
            {
                string consulta = ""; //= "INSERT INTO S9_prop(CodigoS11,VidaFamiliar,DireccionPasada,AnioTraslado,ViviendaActual,ComentarioFinal,Encuestas_idEncuestas) VALUES(@CodigoS11,VidaFamiliar,@DireccionPasada,@AnioTraslado,@ViviendaActual,@ComentarioFinal,@Encuestas_idEncuestas)";
                MySqlCommand comando = new MySqlCommand(consulta, conex);
                comando.Parameters.AddWithValue("@Ninguno", this.Ninguno);
                comando.Parameters.AddWithValue("@CableTV", this.CableTV);
                comando.Parameters.AddWithValue("@TelefonoResid", this.TelefonoResid);
                comando.Parameters.AddWithValue("@Internet", this.Internet);
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

        public List<S807_Servicios> ObtenerS807()
        {
            List<S807_Servicios> ListaServicios = new List<S807_Servicios>();
            MySqlCommand comando = new MySqlCommand("SELECT * FROM S807_Serv WHERE Activo = true", conex);
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
                S807_Servicios Servicio = new S807_Servicios(Convert.ToInt32(row["idS807_Serv"]), Convert.ToBoolean(row["Ninguno"]), Convert.ToBoolean(row["CableTV"]), Convert.ToBoolean(row["TelefonoResid"]), Convert.ToBoolean(row["Internet"]), Convert.ToBoolean(row["NSNR"]));
                ListaServicios.Add(Servicio);
            }
            return ListaServicios;

        }
        public Int32 Obtener_Ultima_EncS807()
        {
            int i = 0;
            MySqlCommand comando = new MySqlCommand("select max(idS807_Serv) as Contador from S807_Serv", conex);
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
