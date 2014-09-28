using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using MySql.Data.MySqlClient;

namespace Capa_Datos
{
    public class S4_Salud
    {
        public int CodigoS4 { get; set; }
        public string AsistenciaSalud { get; set; }
        public string NombreCentro { get; set; }
        public string UbicacionCentro { get; set; }
        public Boolean ProblemaSalud { get; set; }
        public string EspecificarProblemaSalud { get; set; }
        public Boolean Accidente { get; set; }
        public string TipoAccidente { get; set; }
        public string Seguro { get; set; }
        public string Discapacidad { get; set; }
        public string OtraDiscapacidad { get; set; }
        public string OrigenDiscapacidad { get; set; }        
        public string OtroOrigen { get; set; }
        public int Encuestas_idEncuestas { get; set; }
        public List<Error> errores { get; set; }
        private static ConexionBD datos = new ConexionBD();
        private static MySqlConnection conex = ConexionBD.conexion;

        public S4_Salud()
        {
            this.CodigoS4 = 0;
            this.AsistenciaSalud = "";
            this.NombreCentro = "";
            this.UbicacionCentro = "";
            this.ProblemaSalud = false;
            this.EspecificarProblemaSalud = "";
            this.Accidente = false;
            this.TipoAccidente = "";
            this.Seguro = "";
            this.Discapacidad = "";
            this.OtraDiscapacidad = "";
            this.OrigenDiscapacidad = "";
            this.OtroOrigen = "";
            this.Encuestas_idEncuestas = 0;
        }

        public S4_Salud(int CodigoS4, string AsistenciaSalud, string NombreCentro, string UbicacionCentro, Boolean ProblemaSalud, string EspecificarProblemaSalud, Boolean Accidente, string TipoAccidente,
            string Seguro, string Discapacidad, string OtraDiscapacidad, string OrigenDiscapacidad, string OtroOrigen, int Encuestas_idEncuestas)
        {
            this.CodigoS4 = CodigoS4;
            this.AsistenciaSalud = AsistenciaSalud;
            this.NombreCentro = NombreCentro;
            this.UbicacionCentro = UbicacionCentro;
            this.ProblemaSalud = ProblemaSalud;
            this.EspecificarProblemaSalud = EspecificarProblemaSalud;
            this.Accidente = Accidente;
            this.TipoAccidente = TipoAccidente;
            this.Seguro = Seguro;
            this.Discapacidad = Discapacidad;
            this.OtraDiscapacidad = OtraDiscapacidad;
            this.OrigenDiscapacidad = OrigenDiscapacidad;
            this.OtroOrigen = OtroOrigen;
            this.Encuestas_idEncuestas = Encuestas_idEncuestas;
            this.errores = new List<Error>();
        }

        public void InsertarS4()
        {
            if (this.errores.Count == 0)
            {
                string consulta = ""; //= "INSERT INTO S4_Sal(CodigoS4,AsistenciaSalud,NombreCentro,UbicacionCentro,ProblemaSalud,EspecificarProblemaSalud,Accidente,TipoAccidente,Seguro,Discapacidad,OtraDiscapacidad,OrigenDiscapacidad,OtroOrigen,Encuestas_idEncuestas) VALUES(@CodigoS4,@AsistenciaSalud,@NombreCentro,@UbicacionCentro,@ProblemaSalud,@EspecificarProblemaSalud,@Accidente,@TipoAccidente,@Seguro,@Discapacidad,@OtraDiscapacidad,@OrigenDiscapacidad,@OtroOrigen,@Encuestas_idEncuestas)";
                MySqlCommand comando = new MySqlCommand(consulta, conex);
                comando.Parameters.AddWithValue("@CodigoS4", this.CodigoS4);
                comando.Parameters.AddWithValue("@AsistenciaSalud", this.AsistenciaSalud);
                comando.Parameters.AddWithValue("@NombreCentro", this.NombreCentro);
                comando.Parameters.AddWithValue("@UbicacionCentro", this.UbicacionCentro);
                comando.Parameters.AddWithValue("@ProblemaSalud", this.ProblemaSalud);
                comando.Parameters.AddWithValue("@EspecificarProblemaSalud", this.EspecificarProblemaSalud);
                comando.Parameters.AddWithValue("@Accidente", this.Accidente);
                comando.Parameters.AddWithValue("@TipoAccidente", this.TipoAccidente);
                comando.Parameters.AddWithValue("@Seguro", this.Seguro);
                comando.Parameters.AddWithValue("@Discapacidad", this.Discapacidad);
                comando.Parameters.AddWithValue("@OtraDiscapacidad", this.OtraDiscapacidad);
                comando.Parameters.AddWithValue("@OrigenDiscapacidad", this.OrigenDiscapacidad);
                comando.Parameters.AddWithValue("@OtroOrigen", this.OtroOrigen);
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
