using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using MySql.Data.MySqlClient;

namespace Capa_Datos
{
    public class S7_Vivienda
    {
        public int Ancho { get; set; }
        public int Largo { get; set; }
        public string Cuartos { get; set; }
        public string Dormitorio { get; set; }
        public string Camas { get; set; }
        public string ProblemaVivienda { get; set; }
        public string ProblemaA { get; set; }
        public string ProblemaB { get; set; }
        public string ProblemaC { get; set; }
        public int Encuestas_idEncuestas { get; set; }
        public int S706_Viv_idS706 { get; set; }
        public int S707_Viv_idS707 { get; set; }
        public int S708_Viv_idS708 { get; set; }
        public List<Error> errores { get; set; }
        private static ConexionBD datos = new ConexionBD();
        private static MySqlConnection conex = ConexionBD.conexion;

        // Constructor
        public S7_Vivienda()
        {
            this.Ancho = 0;
            this.Largo = 0;
            this.Cuartos = "";
            this.Dormitorio = "";
            this.Camas = "";
            this.ProblemaVivienda = "";
            this.ProblemaA = "";
            this.ProblemaB = "";
            this.ProblemaC = "";
            this.Encuestas_idEncuestas = 0;
            this.S706_Viv_idS706 = 0;
            this.S707_Viv_idS707 = 0;
            this.S708_Viv_idS708 = 0;
        }

        // Setear variables
        public S7_Vivienda(int Ancho, int Largo, string Cuartos, string Dormitorio, string Camas, string ProblemaVivienda,
            string ProblemaA, string ProblemaB, string Problemac, int Encuents_idEncuestas, int S706_Viv_ids706, int S707_Viv_ids707, int S708_Viv_ids708)
        {
            this.Ancho = Ancho;
            this.Largo = Largo;
            this.Cuartos = Cuartos;
            this.Dormitorio = Dormitorio;
            this.Camas = Camas;
            this.ProblemaVivienda = ProblemaVivienda;
            this.ProblemaA = ProblemaA;
            this.ProblemaB = ProblemaB;
            this.ProblemaC = ProblemaC;
            this.Encuestas_idEncuestas = Encuents_idEncuestas;
            this.S706_Viv_idS706 = S706_Viv_ids706;
            this.S707_Viv_idS707 = S707_Viv_ids707;
            this.S708_Viv_idS708 = S708_Viv_ids708;
            this.errores = new List<Error>();
        }

        // Insertar seccion 7 de la encuesta
        public void InsertarS7()
        {
            if (this.errores.Count == 0)
            {
                string consulta = "INSERT INTO S7_Viv(Ancho,Largo,Cuartos,Dormitorio,Camas,ProblemaVivienda,ProblemaA,ProblemaB,ProblemaC,Encuestas_idEncuestas,S706_Viv_idS706_Viv,S707_Viv_idS707_Viv,S708_Viv_idS708_Viv) VALUES(@Ancho,@Largo,@Cuartos,@Dormitorio,@Camas,@ProblemaVivienda,@ProblemaA,@ProblemaB,@ProblemaC,@Encuestas_idEncuestas,@S706_Viv_ids706,@S707_Viv_ids707,@S708_Viv_ids708)";
                MySqlCommand comando = new MySqlCommand(consulta, conex);
                comando.Parameters.AddWithValue("@Ancho", this.Ancho);
                comando.Parameters.AddWithValue("@Largo", this.Largo);
                comando.Parameters.AddWithValue("@Cuartos", this.Cuartos);
                comando.Parameters.AddWithValue("@Dormitorio", this.Dormitorio);
                comando.Parameters.AddWithValue("@Camas", this.Camas);
                comando.Parameters.AddWithValue("@ProblemaVivienda", this.ProblemaVivienda);
                comando.Parameters.AddWithValue("@ProblemaA", this.ProblemaA);
                comando.Parameters.AddWithValue("@ProblemaB", this.ProblemaB);
                comando.Parameters.AddWithValue("@ProblemaC", this.ProblemaC);
                comando.Parameters.AddWithValue("@Encuestas_idEncuestas", this.Encuestas_idEncuestas);
                comando.Parameters.AddWithValue("@S706_Viv_idS706", this.S706_Viv_idS706);
                comando.Parameters.AddWithValue("@S707_Viv_idS707", this.S707_Viv_idS707);
                comando.Parameters.AddWithValue("@S708_Viv_idS708", this.S708_Viv_idS708);

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
    }
}
