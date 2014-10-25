using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using MySql.Data.MySqlClient;

namespace Capa_Datos
{
    public class S611_Ingresos
    {
        public Boolean RecorteGastos { get; set; }
        public Boolean Prestamo { get; set; }
        public Boolean VentaMaterial { get; set; }
        public Boolean TrabajoOcasional { get; set; }
        public Boolean Ahorros { get; set; }
        public Boolean AyudaFamiliar { get; set; }
        public Boolean ApoyoEstado { get; set; }
        public Boolean Otro { get; set; }
        public string Especificar { get; set; }
        public Boolean NSNR { get; set; }
        public List<Error> errores { get; set; }
        private static ConexionBD datos = new ConexionBD();
        private static MySqlConnection conex = ConexionBD.conexion;

        // Constructor
        public S611_Ingresos()
        {
            this.RecorteGastos = false;
            this.Prestamo = false;
            this.VentaMaterial = false;
            this.TrabajoOcasional = false;
            this.Ahorros = false;
            this.AyudaFamiliar = false;
            this.ApoyoEstado = false;
            this.Otro = false;
            this.Especificar = "";
            this.NSNR = false;
        }

        // Setear las variables
        public S611_Ingresos(Boolean RecorteGastos, Boolean Prestamo, Boolean VentaMaterial, Boolean TrabajoOcasional, Boolean Ahorros, Boolean AyudaFamiliar, Boolean ApoyoEstado, Boolean Otro, string Especificar, Boolean NSNR)
        {
            this.RecorteGastos = RecorteGastos;
            this.Prestamo = Prestamo;
            this.VentaMaterial = VentaMaterial;
            this.TrabajoOcasional = TrabajoOcasional;
            this.Ahorros = Ahorros;
            this.AyudaFamiliar = AyudaFamiliar;
            this.ApoyoEstado = ApoyoEstado;
            this.Otro = Otro;
            this.Especificar = Especificar;
            this.NSNR = NSNR;
            this.errores = new List<Error>();
        }

        // Insertar seccion s611_ingresos de la encuesta
        public void InsertarS611()
        {
            if (this.errores.Count == 0)
            {
                string consulta = "INSERT INTO s611_ingre(RecorteGastos,Prestamo,VentaMaterial,TrabajoOcasional,Ahorros,AyudaFamiliar,ApoyoEstado,Otro,Especificar,NSNR) VALUES(@RecorteGastos,@Prestamo,@VentaMaterial,@TrabajoOcasional,@Ahorros,@AyudaFamiliar,@ApoyoEstado,@Otro,@Especificar,@NSNR)";
                MySqlCommand comando = new MySqlCommand(consulta, conex);
                comando.Parameters.AddWithValue("@RecorteGastos", this.RecorteGastos);
                comando.Parameters.AddWithValue("@Prestamo", this.Prestamo);
                comando.Parameters.AddWithValue("@VentaMaterial", this.VentaMaterial);
                comando.Parameters.AddWithValue("@TrabajoOcasional", this.TrabajoOcasional);
                comando.Parameters.AddWithValue("@Ahorros", this.Ahorros);
                comando.Parameters.AddWithValue("@AyudaFamiliar", this.AyudaFamiliar);
                comando.Parameters.AddWithValue("@ApoyoEstado", this.ApoyoEstado);
                comando.Parameters.AddWithValue("@Otro", this.Otro);
                comando.Parameters.AddWithValue("@Especificar", this.Especificar);
                comando.Parameters.AddWithValue("@NSNR", this.NSNR);
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

        // Obtener el ultimo id de la tabla s611_Ingre
        public int UltimoId()
        {
            int id = 0;
            String consulta = "SELECT MAX(idS611_Ingre) FROM S611_Ingre";
            MySqlCommand comando = new MySqlCommand(consulta, conex);
            try
            {
                //comando.Connection.Open();
                id = (Int32)comando.ExecuteScalar();
                //comando.Connection.Close();
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
