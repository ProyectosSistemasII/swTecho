using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using MySql.Data.MySqlClient;

namespace Capa_Datos
{
    public class S6_Ingresos
    {
        public string ApoyoEstado { get; set; }
        public float CantidadApoyo { get; set; }
        public string Remesas { get; set; }
        public float CantidadRemesas { get; set; }
        public string Deuda { get; set; }
        public float DineroDeuda { get; set; }
        public string TiempoPagoDeuda { get; set; }
        public float IngresoTotal { get; set; }
        public string CubreGastos { get; set; }
        public string Ahorro { get; set; }
        public float MontoAhorro { get; set; }
        public float DineroGasto { get; set; }
        public int Encuestas_idEncuestas { get; set; }
        public int S611_Ingre_idS611_Ingre { get; set; }
        public List<Error> errores { get; set; }
        private static ConexionBD datos = new ConexionBD();
        private static MySqlConnection conex = ConexionBD.conexion;

        public S6_Ingresos()
        {
            this.ApoyoEstado = "";
            this.CantidadApoyo = 0;
            this.Remesas = "";
            this.CantidadRemesas = 0;
            this.Deuda = "";
            this.DineroDeuda = 0;
            this.TiempoPagoDeuda = "";
            this.IngresoTotal = 0;
            this.CubreGastos = "";
            this.Ahorro = "";
            this.MontoAhorro = 0;
            this.DineroGasto = 0;
            this.Encuestas_idEncuestas = 0;
            this.S611_Ingre_idS611_Ingre = 0;
        }

        public S6_Ingresos(string ApoyoEstado, float CantidadApoyo, string Remesas, float CantidadRemesas, string Deuda, float DineroDeuda, string TiempoPagoDeuda,
            float IngresoTotal, string CubreGastos, string Ahorro, float MontoAhorro, float DineroGasto, int Encuestas_idEncuestas, int S611_Ingre_idS611_Ingre)
        {
            this.ApoyoEstado = ApoyoEstado;
            this.CantidadApoyo = CantidadApoyo;
            this.Remesas = Remesas;
            this.CantidadRemesas = CantidadRemesas;
            this.Deuda = Deuda;
            this.DineroDeuda = DineroDeuda;
            this.TiempoPagoDeuda = TiempoPagoDeuda;
            this.IngresoTotal = IngresoTotal;
            this.CubreGastos = CubreGastos;
            this.Ahorro = Ahorro;
            this.MontoAhorro = MontoAhorro;
            this.DineroGasto = DineroGasto;
            this.Encuestas_idEncuestas = Encuestas_idEncuestas;
            this.S611_Ingre_idS611_Ingre = S611_Ingre_idS611_Ingre;
            this.errores = new List<Error>();
        }

        public void InsertarS()
        {
            if (this.errores.Count == 0)
            {
                string consulta = ""; //= "INSERT INTO S6_Ingre(ApoyoEstado,CantidadApoyo,Remesas,CantidadRemesas,Deuda,DineroDeuda,TiempoPagoDeuda,IngresoTotal,CubreGastos,Ahorro,MontoAhorro,DineroGasto,Encuestas_idEncuestas,S611_Ingre_idS611_Ingre) VALUES(@CodigoS6,@ApoyoEstado,@CantidadApoyo,@Remesas,@CantidadRemesas,@Deuda,@DineroDeuda,@TiempoPagoDeuda,@IngresoTotal,@CubreGastos,@Ahorro,@MontoAhorro,@DineroGasto,@Encuestas_idEncuestas,@S611_Ingre_idS611_Ingre)";
                MySqlCommand comando = new MySqlCommand(consulta, conex);
                comando.Parameters.AddWithValue("@ApoyoEstado", this.ApoyoEstado);
                comando.Parameters.AddWithValue("@CantidadApoyo", this.CantidadApoyo);
                comando.Parameters.AddWithValue("@Remesas", this.Remesas);
                comando.Parameters.AddWithValue("@CantidadRemesas", this.CantidadRemesas);
                comando.Parameters.AddWithValue("@Deuda", this.Deuda);
                comando.Parameters.AddWithValue("@DineroDeuda", this.DineroDeuda);
                comando.Parameters.AddWithValue("@TiempoPagoDeuda", this.TiempoPagoDeuda);
                comando.Parameters.AddWithValue("@IngresoTotal", this.IngresoTotal);
                comando.Parameters.AddWithValue("@CubreGastos", this.CubreGastos);
                comando.Parameters.AddWithValue("@Ahorro", this.Ahorro);
                comando.Parameters.AddWithValue("@MontoAhorro", this.MontoAhorro);
                comando.Parameters.AddWithValue("@DineroGasto", this.DineroGasto);
                comando.Parameters.AddWithValue("@Encuestas_idEncuestas", this.Encuestas_idEncuestas);
                comando.Parameters.AddWithValue("@S611_Ingre_idS611_Ingre", this.S611_Ingre_idS611_Ingre);

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
