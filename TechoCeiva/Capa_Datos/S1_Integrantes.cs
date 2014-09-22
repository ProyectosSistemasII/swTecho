using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using MySql.Data.MySqlClient;

namespace Capa_Datos
{
    class S1_Integrantes
    {
        public int CodigoS1 { get; set; }
        public string NombreCompleto { get; set; }
        public string ApellidosCompleto { get; set; }
        public DateTime FechaNacFuturoHijo { get; set; }
        public string Genero { get; set; }
        public string Embarazo { get; set; }
        public int Encuestas_idEncuestas { get; set; }

        public List<Error> errores { get; set; }
        private static ConexionBD datos = new ConexionBD();
        private static MySqlConnection conex = ConexionBD.conexion;

        public S1_Integrantes()
        {
            this.CodigoS1 = 0;
            this.NombreCompleto = "";
            this.ApellidosCompleto = "";
            this.FechaNacFuturoHijo = DateTime.Today;
            this.Genero = "";
            this.Embarazo = "";
            this.Encuestas_idEncuestas = 0;
        }

        public S1_Integrantes(int CodigoS1, string NombreCompleto, string ApellidosCompleto, DateTime FechaNacFuturoHijo, string Genero, string Embarazo, int Encuestas_idEncuestas)
        {
            this.CodigoS1 = CodigoS1;
            this.NombreCompleto = NombreCompleto;
            this.ApellidosCompleto = ApellidosCompleto;
            this.FechaNacFuturoHijo = FechaNacFuturoHijo;
            this.Genero = Genero;
            this.Embarazo = Embarazo;
            this.Encuestas_idEncuestas = Encuestas_idEncuestas;
            this.errores = new List<Error>();
        }

        public void InsertarS1()
        {

            if (this.errores.Count == 0)
            {
                string consulta = ""; //= "INSERT INTO S1_Integr(CodigoS1, NombreCompleto, ApellidosCompleto, FechaNacFuturoHijo, Genero, Embarazo, Encuestas_idEncuestas) VALUES(@CodigoS1, @NombreCompleto, @ApellidosCompleto, @FechaNacFuturoHijo, @Genero, @Embarazo, @Encuestas_idEncuestas)";
                MySqlCommand comando = new MySqlCommand(consulta, conex);
                comando.Parameters.AddWithValue("@CodigoS1", this.CodigoS1);
                comando.Parameters.AddWithValue("@NombreCompleto", this.NombreCompleto);
                comando.Parameters.AddWithValue("@ApellidosCompleto", this.ApellidosCompleto);
                comando.Parameters.AddWithValue("@FechaNacFuturoHijo", this.FechaNacFuturoHijo);
                comando.Parameters.AddWithValue("@Genero", this.Genero);
                comando.Parameters.AddWithValue("@Embarazo", this.Embarazo);
                comando.Parameters.AddWithValue("@Encuestas_idEncuestas", this.Encuestas_idEncuestas);
               
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
    }
}
