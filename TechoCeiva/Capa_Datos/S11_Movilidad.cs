using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MySql.Data.MySqlClient;
using System.Data;


namespace Capa_Datos
{
    public class S11_Movilidad
    {
        public int idS11_Mov { get; set; }        
        public String VidaFamiliar { get; set; }
        public String DireccionPasada { get; set; }
        public String AnioTranslado { get; set; }
        public String PorqueTraslado { get; set; }
        public String ViviendaActual { get; set; }
        public String ComentarioFinal{ get; set; }
        public int idEncuestas { get; set; }
        public List<Error> errores { get; set; }
        
        private static ConexionBD datos = new ConexionBD();
        private static MySqlConnection conex = ConexionBD.conexion;

        public S11_Movilidad()
        {
            this.idS11_Mov = 0;
            
            this.VidaFamiliar = "";
            this.DireccionPasada = "";
            this.AnioTranslado = "";
            this.PorqueTraslado = "";
            this.ViviendaActual = "";
            this.ComentarioFinal = "";
            this.idEncuestas = 0;
            this.errores = new List<Error>();
        }

        public S11_Movilidad(int idS11_Mov, String VidaFamiliar,String DireccionPasada, String AñoTraslado,String PorqueTraslado, String ViviendaActual, String Comentario, int idEncuesta){
            this.idS11_Mov = idS11_Mov;            
            this.VidaFamiliar = VidaFamiliar;
            this.DireccionPasada = DireccionPasada;
            this.AnioTranslado = AñoTraslado;
            this.PorqueTraslado = PorqueTraslado; 
            this.ViviendaActual = ViviendaActual;
            this.ComentarioFinal = Comentario;
            this.idEncuestas = idEncuesta;
            this.errores = new List<Error>();
            this.InsertarS11();


        }
        public void InsertarS11() {
            
            if (this.errores.Count == 0)
            {
                string consulta = "INSERT INTO S11_Mov(VidaFamiliar,DireccionPasada,AnioTraslado,PorqueTraslado,ViviendaActual,ComentarioFinal,Encuestas_idEncuestas) VALUES(@CodigoS11,VidaFamiliar,@DireccionPasada,@AnioTraslado,@PorqueTraslado,@ViviendaActual,@ComentarioFinal,@Encuestas_idEncuestas)";
                    MySqlCommand comando = new MySqlCommand(consulta, conex);                    
                    comando.Parameters.AddWithValue("@VidaFamiliar", this.VidaFamiliar);
                    comando.Parameters.AddWithValue("@DireccionPasada", this.DireccionPasada);
                    comando.Parameters.AddWithValue("@AnioTraslado", this.AnioTranslado);
                    comando.Parameters.AddWithValue("@PorqueTraslado", this.PorqueTraslado);
                    comando.Parameters.AddWithValue("@ViviendaActual", this.ViviendaActual);
                    comando.Parameters.AddWithValue("@ComentarioFinal", this.ComentarioFinal);
                    comando.Parameters.AddWithValue("@Encuestas_idEncuestas", this.idEncuestas);
                                  
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
        
        public List<S11_Movilidad> ObtenerS11()
        {
            List<S11_Movilidad> ListaMovilidad = new List<S11_Movilidad>();
            MySqlCommand comando = new MySqlCommand("SELECT * FROM S11_Mov WHERE Activo = true", conex);
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
                S11_Movilidad movilidad = new S11_Movilidad(Convert.ToInt32(row["idS11_mov"]), Convert.ToString(row["VidaFamiliar"]), Convert.ToString(row["DireccionPasada"]), Convert.ToString(row["AnioTraslado"]),Convert.ToString(row["PorqueTraslado"]),Convert.ToString(row["ViviendaActual"]),Convert.ToString(row["ComentarioFinal"]),Convert.ToInt32(row["Encuestas_idEncuestas"]));
                ListaMovilidad.Add(movilidad);
            }
            return ListaMovilidad;

        }
    }
}
