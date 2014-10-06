using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MySql.Data.MySqlClient;
using System.Data;

namespace Capa_Datos
{
    public class S8_Servicios
    {
        public int idS8_serv { get; set; }
        public String AccesoAgua  { get; set; }
        public String FuenteAgua  { get; set; }
        public String OtraFuente { get; set; }
        public String EnergiaElectrica { get; set; }
        public String OtraEnergiaElectrica { get; set; }
        public String EnergiaCocina { get; set; }
        public String OtraEnergiaCocina { get; set; }
        public String Sanitario { get; set; }
        public String OtroTipoSanitario { get; set; }
        public String BasuraHogar { get; set; }
        public String OtroTipoBasura { get; set; }
        public int idEncuestas { get; set; }
        public int idS807_serv { get; set; }
        public int idS808_serv { get; set; }
        
        public List<Error> errores { get; set; }
        private static ConexionBD datos = new ConexionBD();
        private static MySqlConnection conex = ConexionBD.conexion;

        public S8_Servicios()
        {
            this.idS8_serv = 0;
            this.AccesoAgua = "";
            this.FuenteAgua = "";
            this.OtraFuente = "";
            this.EnergiaElectrica = "";
            this.OtraEnergiaElectrica = "";
            this.EnergiaCocina = "";
            this.OtraEnergiaCocina = "";
            this.Sanitario = "";
            this.OtroTipoSanitario = "";
            this.BasuraHogar = "";
            this.OtroTipoBasura = "";
            this.idEncuestas = 0;
            this.idS807_serv = 0;
            this.idS808_serv = 0;
        }
        public S8_Servicios(int idS8_serv, String AccesoAgua, String FuenteAgua, String OtraFuente,String Energia, String OtraEnergia, String Cocina, String OtraCocina, String Sanitario, String OtroTipoSanitario, String BasuraHogar, String OtroTipoBasura, int idEncuesta, int idS807, int idS808) {
            this.idS808_serv = idS8_serv;
            this.AccesoAgua = AccesoAgua;
            this.FuenteAgua = FuenteAgua;
            this.OtraFuente = OtraFuente;
            this.EnergiaElectrica = Energia;
            this.OtraEnergiaElectrica = OtraEnergia;
            this.EnergiaCocina = Cocina;
            this.OtraEnergiaCocina = OtraCocina;
            this.Sanitario = Sanitario;
            this.OtroTipoSanitario = OtroTipoSanitario;
            this.idEncuestas = idEncuesta;
            this.idS807_serv = idS807;
            this.idS808_serv = idS808;
            this.errores = new List<Error>();
            
        }
        public void InsertarS8()
        {

            if (this.errores.Count == 0)
            {
                string consulta = ""; //= "INSERT INTO S9_prop(CodigoS11,VidaFamiliar,DireccionPasada,AnioTraslado,ViviendaActual,ComentarioFinal,Encuestas_idEncuestas) VALUES(@CodigoS11,VidaFamiliar,@DireccionPasada,@AnioTraslado,@ViviendaActual,@ComentarioFinal,@Encuestas_idEncuestas)";
                MySqlCommand comando = new MySqlCommand(consulta, conex);
                comando.Parameters.AddWithValue("@AccesoAgua", this.AccesoAgua);
                comando.Parameters.AddWithValue("@FuenteAgua", this.FuenteAgua);
                comando.Parameters.AddWithValue("@OtraFuente", this.OtraFuente);
                comando.Parameters.AddWithValue("@EnergiaElectrica", this.EnergiaElectrica);
                comando.Parameters.AddWithValue("@OtraEnergiaElectrica", this.OtraEnergiaElectrica);
                comando.Parameters.AddWithValue("@EnergiaCocina", this.EnergiaCocina);
                comando.Parameters.AddWithValue("@OtraEnergiaElectrica", this.OtraEnergiaCocina);
                comando.Parameters.AddWithValue("@Sanitario", this.Sanitario);
                comando.Parameters.AddWithValue("@otroTipoSanitario", this.OtroTipoSanitario);
                comando.Parameters.AddWithValue("@BasuraHogar", this.BasuraHogar);
                comando.Parameters.AddWithValue("@OtroTipoBasura", this.OtroTipoBasura);
                comando.Parameters.AddWithValue("@Encuestas_idEncuestas", this.idEncuestas);
                comando.Parameters.AddWithValue("@S807_Serv_idS807_Serv", this.idS807_serv);
                comando.Parameters.AddWithValue("@S808_Serv_idS808_Serv", this.idS808_serv);

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

        public List<S8_Servicios> ObtenerS8()
        {
            List<S8_Servicios> ListaServicios = new List<S8_Servicios>();
            MySqlCommand comando = new MySqlCommand("SELECT * FROM S8_Serv WHERE Activo = true", conex);
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
                S8_Servicios servicios = new S8_Servicios(Convert.ToInt32(row["idS8_Serv"]), Convert.ToString(row["AccesoAgua"]), Convert.ToString(row["FuenteAgua"]), Convert.ToString(row["OtraFuente"]), Convert.ToString(row["EnergiaElectrica"]), Convert.ToString(row["OtraEnergiaElectrica"]), Convert.ToString(row["EnergiaCocina"]), Convert.ToString(row["OtraEnergiaCocina"]), Convert.ToString(row["Sanitario"]), Convert.ToString(row["OtroTipoSanitario"]), Convert.ToString(row["BasuraHogar"]), Convert.ToString(row["OtroTipoBasura"]), Convert.ToInt32(row["Encuestas_idEncuestas"]), Convert.ToInt32(row["S807_Serv_idS807_Serv"]), Convert.ToInt32(row["S808_Serv_idS808_Serv"]));
                ListaServicios.Add(servicios);
            }
            return ListaServicios;

        }
    }
}
