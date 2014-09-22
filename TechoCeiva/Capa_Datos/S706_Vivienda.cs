using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using MySql.Data.MySqlClient;

namespace Capa_Datos
{
    class S706_Vivienda
    {
        public int Concreto { get; set; }
        public int TejaBarro { get; set; }
        public int Lamina { get; set; }
        public int TejaDuralita { get; set; }
        public int Paja { get; set; }
        public int Desechos { get; set; }
        public List<Error> errores { get; set; }
        private static ConexionBD datos = new ConexionBD();
        private static MySqlConnection conex = ConexionBD.conexion;

        public S706_Vivienda()
        {
            this.Concreto = 0;
            this.TejaBarro = 0;
            this.Lamina = 0;
            this.TejaDuralita = 0;
            this.Paja = 0;
            this.Desechos = 0;
        }

        public S706_Vivienda(int Concreto, int TejaBarro, int Lamina, int TejaDuralita, int Paja, int Desechos)
        {
            this.Concreto = Concreto;
            this.TejaBarro = TejaBarro;
            this.Lamina = Lamina;
            this.TejaDuralita = TejaDuralita;
            this.Paja = Paja;
            this.Desechos = Desechos;
            this.errores = new List<Error>();
        }

        public void InsertarS706()
        {
            if (this.errores.Count == 0)
            {
                string consulta = ""; //= "INSERT INTO S706_Viv(Concreto,TejaBarro,Lamina,TejaDuralita,Paja,Desechos) VALUES(@Concreto,@TejaBarro,@Lamina,@TejaDuralita,@Paja,@Desechos)";
                MySqlCommand comando = new MySqlCommand(consulta, conex);
                comando.Parameters.AddWithValue("@Concreto", this.Concreto);
                comando.Parameters.AddWithValue("@TejaBarro", this.TejaBarro);
                comando.Parameters.AddWithValue("@Lamina", this.Lamina);
                comando.Parameters.AddWithValue("@TejaDuralita", this.TejaDuralita);
                comando.Parameters.AddWithValue("@Paja", this.Paja);
                comando.Parameters.AddWithValue("@Desechos", this.Desechos);
                
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
