using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using MySql.Data.MySqlClient;

namespace Capa_Datos
{
    public class S708_Vivienda
    {
        public int Encementado { get; set; }
        public int LadrilloBarro { get; set; }
        public int Madera { get; set; }
        public int Tierra { get; set; }
        public List<Error> errores { get; set; }
        private static ConexionBD datos = new ConexionBD();
        private static MySqlConnection conex = ConexionBD.conexion;

        public S708_Vivienda()
        {
            this.Encementado = 0;
            this.LadrilloBarro = 0;
            this.Madera = 0;
            this.Tierra = 0;
        }

        public S708_Vivienda(int Encementado, int LadrilloBarro, int Madera, int Tierra)
        {
            this.Encementado = Encementado;
            this.LadrilloBarro = LadrilloBarro;
            this.Madera = Madera;
            this.Tierra = Tierra;
            this.errores = new List<Error>();
        }

        public void InsertarS708()
        {
            if (this.errores.Count == 0)
            {
                string consulta = "INSERT INTO S708_Viv(Encementado,LadrillosBarro,Madera,Tierra) VALUES(@Encementado,@LadrilloBarro,@Madera,@Tierra)";
                MySqlCommand comando = new MySqlCommand(consulta, conex);
                comando.Parameters.AddWithValue("@Encementado", this.Encementado);
                comando.Parameters.AddWithValue("@LadrilloBarro", this.LadrilloBarro);
                comando.Parameters.AddWithValue("@Madera", this.Madera);
                comando.Parameters.AddWithValue("@Tierra", this.Tierra);                
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

        public int UltimoId()
        {
            int id = 0;
            String consulta = "SELECT MAX(idS708_Viv) FROM S708_Viv";
            MySqlCommand comando = new MySqlCommand(consulta, conex);
            try
            {
                comando.Connection.Open();
                id = (Int32)comando.ExecuteScalar();
                comando.Connection.Close();
            }
            catch (MySqlException ex)
            {
                Error error = new Error(ex.Message + "   " + ex.Number, 0);
                errores.Add(error);
            }
            return id;
        }
    }
}
