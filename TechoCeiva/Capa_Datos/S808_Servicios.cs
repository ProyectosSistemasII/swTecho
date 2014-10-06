using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MySql.Data.MySqlClient;
using System.Data;

namespace Capa_Datos
{
    public class S808_Servicios
    {
        public int idS808_Serv { get; set; }
        public int Refrigerador { get; set; }
        public int EquipoSonido { get; set; }
        public int Televisor { get; set; }
        public int DVD { get; set; }
        public int Motocicleta { get; set; }
        public int Automovil { get; set; }
        public int Computadora { get; set; }
        public int Amueblado { get; set; }
        public int Otros { get; set; }
        public String Especificar { get; set; }

        public List<Error> errores { get; set; }
        private static ConexionBD datos = new ConexionBD();
        private static MySqlConnection conex = ConexionBD.conexion;

        public S808_Servicios() 
        {
            this.idS808_Serv = 0;
            this.Refrigerador = 0;
            this.EquipoSonido = 0;
            this.Televisor = 0;
            this.DVD = 0;
            this.Motocicleta = 0;
            this.Automovil = 0;
            this.Computadora = 0;
            this.Amueblado = 0;
            this.Otros = 0;
            this.Especificar = "";
        }
        public S808_Servicios(int idS808, int refrigerador, int EquipoSonido, int Televisor, int DVD, int Motocicleta, int Automovil, int computadora, int aumeblado,int Otros, String Especificar ) 
        {
            this.idS808_Serv = idS808;
            this.Refrigerador = refrigerador;
            this.EquipoSonido = EquipoSonido;
            this.Televisor = Televisor;
            this.DVD = DVD;
            this.Motocicleta = Motocicleta;
            this.Automovil = Automovil;
            this.Computadora = computadora;
            this.Amueblado = aumeblado;
            this.Otros = Otros;
            this.Especificar = Especificar;
            this.errores = new List<Error>();
            
        }
        public void InsertarS808()
        {

            if (this.errores.Count == 0)
            {
                string consulta = "INSERT INTO S808_Serv(Refrigedor,EquipoSonido,Televisor,DVD,Motocicleta,Automovil,Computadora,Amueblado,Otros,Especificar) VALUES(@Refrigedor,@EquipoSonido,@Televisor,@DVD,@Motocicleta,@Automovil,@Computadora,@Amueblado,@Otros,@Especificar)";
                MySqlCommand comando = new MySqlCommand(consulta, conex);
                comando.Parameters.AddWithValue("@Refrigedor", this.Refrigerador);
                comando.Parameters.AddWithValue("@EquipoSonido", this.EquipoSonido);
                comando.Parameters.AddWithValue("@Televisor", this.Televisor);
                comando.Parameters.AddWithValue("@DVD", this.DVD);
                comando.Parameters.AddWithValue("@Motocicleta", this.Motocicleta); 
                comando.Parameters.AddWithValue("@Automovil", this.Automovil);
                comando.Parameters.AddWithValue("@Computadora", this.Computadora);
                comando.Parameters.AddWithValue("@Amueblado", this.Amueblado);
                comando.Parameters.AddWithValue("@Otros", this.Otros);
                comando.Parameters.AddWithValue("@Especificar", this.Especificar);

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

        public List<S808_Servicios> ObtenerS808()
        {
            List<S808_Servicios> ListaServicios = new List<S808_Servicios>();
            MySqlCommand comando = new MySqlCommand("SELECT * FROM S808_Serv WHERE Activo = true", conex);
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
                S808_Servicios Servicio = new S808_Servicios(Convert.ToInt32(row["idS808_Serv"]), Convert.ToInt32(row["Refrigerador"]), Convert.ToInt32(row["EquipoSonido"]), Convert.ToInt32(row["Televisor"]), Convert.ToInt32(row["DVD"]), Convert.ToInt32(row["Motocicleta"]), Convert.ToInt32(row["Automovil"]), Convert.ToInt32(row["Computadora"]), Convert.ToInt32(row["Amueblado"]), Convert.ToInt32(row["Otros"]), Convert.ToString(row["Especificar"]));
                ListaServicios.Add(Servicio);
            }
            return ListaServicios;

        }
        public Int32 Obtener_Ultima_EncS808()
        {
            int i = 0;
            MySqlCommand comando = new MySqlCommand("select max(idS808_Serv) as Contador from S808_Serv", conex);
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
