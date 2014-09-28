using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using MySql.Data.MySqlClient;

namespace Capa_Datos
{
    public class S5_Trabajo
    {
        public int CodigoS5 { get; set; }
        public Boolean Trabajo { get; set; }
        public Boolean Buscando { get; set; }
        public string RazonNoBusqueda { get; set; }
        public string OtraRazonNoBusqueda { get; set; }
        public string Ocupacion { get; set; }
        public string OtraOcupacion { get; set; }
        public string ContratoTrabajo { get; set; }
        public string CondicionLaboral { get; set; }
        public string UbicacionTrabajo { get; set; }
        public Boolean OtrosTrabajos { get; set; }
        public string EspecificarOtrosTrabajos { get; set; }
        public int DiasTrabajo { get; set; }
        public float HorasTrabajo { get; set; }
        public float IngresoMensual { get; set; }
        public int Encuestas_idEncuestas { get; set; }
        public List<Error> errores { get; set; }
        private static ConexionBD datos = new ConexionBD();
        private static MySqlConnection conex = ConexionBD.conexion;

        public S5_Trabajo()
        {
            this.CodigoS5 = 0;
            this.Trabajo = false;
            this.Buscando = false;
            this.RazonNoBusqueda = "";
            this.OtraRazonNoBusqueda = "";
            this.Ocupacion = "";
            this.OtraOcupacion = "";
            this.ContratoTrabajo = "";
            this.CondicionLaboral = "";
            this.UbicacionTrabajo = "";
            this.OtrosTrabajos = false;
            this.EspecificarOtrosTrabajos = "";
            this.DiasTrabajo = 0;
            this.HorasTrabajo = 0;
            this.IngresoMensual = 0;
            this.Encuestas_idEncuestas = 0;
        }

        public S5_Trabajo(int CodigoS5, Boolean Trabajo, Boolean Buscando, string RazonNoBusqueda, string OtraRazonNoBusqueda, string Ocupacion,
            string OtraOcupacion, string ContratoTrabajo, string CondicionLaboral, string UbicacionTrabajo, Boolean OtrosTrabajos, string EspecificarOtrosTrabajos,
            int DiasTrabajo, float HorasTrabajo, float IngresoMensual, int Encuestas_idEncuestas)
        {
            this.CodigoS5 = CodigoS5;
            this.Trabajo = Trabajo;
            this.Buscando = Buscando;
            this.RazonNoBusqueda = RazonNoBusqueda;
            this.OtraRazonNoBusqueda = OtraRazonNoBusqueda;
            this.Ocupacion = Ocupacion;
            this.OtraOcupacion = OtraOcupacion;
            this.ContratoTrabajo = ContratoTrabajo;
            this.CondicionLaboral = CondicionLaboral;
            this.UbicacionTrabajo = UbicacionTrabajo;
            this.OtrosTrabajos = OtrosTrabajos;
            this.EspecificarOtrosTrabajos = EspecificarOtrosTrabajos;
            this.DiasTrabajo = DiasTrabajo;
            this.HorasTrabajo = HorasTrabajo;
            this.IngresoMensual = IngresoMensual;
            this.Encuestas_idEncuestas = Encuestas_idEncuestas;
            this.errores = new List<Error>();
        }

        public void InsertarS5()
        {
            if (this.errores.Count == 0)
            {
                string consulta = ""; //= "INSERT INTO S5_Tra(CodigoS5,Trabajo,Buscando,RazonNoBusqueda,OtraRazonNoBusqueda,Ocupacion,OtraOcupacion,ContratoTrabajo,CondicionLaboral,UbicacionTrabajo,OtrosTrabajos,EspecificarOtrosTrabajos,DiasTrabajo,HorasTrabajo,IngresoMensual,Encuestas_idEncuestas) VALUES(@CodigoS5,@Trabajo,@Buscando,@RazonNoBusqueda,@OtraRazonNoBusqueda,@Ocupacion,@OtraOcupacion,@ContratoTrabajo,@CondicionLaboral,@UbicacionTrabajo,@OtrosTrabajos,@EspecificarOtrosTrabajos,@DiasTrabajo,@HorasTrabajo,@IngresoMensual,@Encuestas_idEncuestas)";
                MySqlCommand comando = new MySqlCommand(consulta, conex);
                comando.Parameters.AddWithValue("@CodigoS5", this.CodigoS5);
                comando.Parameters.AddWithValue("@Trabajo", this.Trabajo);
                comando.Parameters.AddWithValue("@Buscando", this.Buscando);
                comando.Parameters.AddWithValue("@RazonNoBusqueda", this.RazonNoBusqueda);
                comando.Parameters.AddWithValue("@OtraRazonNoBusqueda", this.OtraRazonNoBusqueda);
                comando.Parameters.AddWithValue("@Ocupacion", this.Ocupacion);
                comando.Parameters.AddWithValue("@OtraOcupacion", this.OtraOcupacion);
                comando.Parameters.AddWithValue("@ContratoTrabajo", this.ContratoTrabajo);
                comando.Parameters.AddWithValue("@CondicionLaboral", this.CondicionLaboral);
                comando.Parameters.AddWithValue("@UbicacionTrabajo", this.UbicacionTrabajo);
                comando.Parameters.AddWithValue("@OtrosTrabajos", this.OtrosTrabajos);
                comando.Parameters.AddWithValue("@EspecificarOtrosTrabajos", this.EspecificarOtrosTrabajos);
                comando.Parameters.AddWithValue("@DiasTrabajo", this.DiasTrabajo);
                comando.Parameters.AddWithValue("@Horastrabajo", this.HorasTrabajo);
                comando.Parameters.AddWithValue("@IngresoMensual", this.IngresoMensual);
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

