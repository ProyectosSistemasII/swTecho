using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using MySql.Data.MySqlClient;

namespace Capa_Datos
{
    public class S2_Demografica
    {
        public int CodigoS2 { get; set; }
        public string Nucleo { get; set; }
        public string DPICedula { get; set; }
        public string EstadoCivil { get; set; }
        public string Parentesco { get; set; }
        public string OtroFamiliar { get; set; }
        public string Nacionalidad { get; set; }
        public int Encuestas_idEncuestas { get; set; }
        public int Departamento_idDepartamento { get; set; }
        public int Municipio_idMunicipio { get; set; }

        public List<Error> errores { get; set; }
        private static ConexionBD datos = new ConexionBD();
        private static MySqlConnection conex = ConexionBD.conexion;

        public S2_Demografica()
        {
            this.CodigoS2 = 0;
            this.Nucleo = "";
            this.DPICedula = "";
            this.EstadoCivil = "";
            this.Parentesco = "";
            this.OtroFamiliar = "";
            this.Nacionalidad = "";
            this.Encuestas_idEncuestas = 0;
            this.Departamento_idDepartamento = 0;
            this.Municipio_idMunicipio = 0;
        }

        public S2_Demografica(int CodigoS2, string Nucleo, string DPICedula, string EstadoCivil, string Parentesco, string OtroFamiliar, string Nacionalidad, int Encuestas_idEncuestas, int Departamento_idDepartamento, int Municipio_idMunicipio)
        {
            this.CodigoS2 = CodigoS2;
            this.Nucleo = Nucleo;
            this.DPICedula = DPICedula;
            this.EstadoCivil = EstadoCivil;
            this.Parentesco = Parentesco;
            this.OtroFamiliar = OtroFamiliar;
            this.Nacionalidad = Nacionalidad;
            this.Encuestas_idEncuestas = Encuestas_idEncuestas;
            this.Departamento_idDepartamento = Departamento_idDepartamento;
            this.Municipio_idMunicipio = Municipio_idMunicipio;
            this.errores = new List<Error>();
        }

        public void InsertarS2()
        {
            if (this.errores.Count == 0)
            {
                string consulta = "INSERT INTO S2_Dem(CodigoS2, Nucleo, DPICedula, EstadoCivil, Parentesco, OtroFamiliar, Nacionalidad, Encuestas_idEncuestas, Departamento_idDepartamento, Municipio_idMunicipio) VALUES (@CodigoS2, @Nucleo, @DPICedula, @EstadoCivil, @Parentesco, @OtroFamiliar, @Nacionalidad, @Encuestas_idEncuestas, @Departamento_idDepartamento, @Municipio_idMunicipio)";
                MySqlCommand comando = new MySqlCommand(consulta, conex);
                comando.Parameters.AddWithValue("@CodigoS2", this.CodigoS2);
                comando.Parameters.AddWithValue("@Nucleo", this.Nucleo);
                comando.Parameters.AddWithValue("@DPICedula", this.DPICedula);
                comando.Parameters.AddWithValue("@EstadoCivil", this.EstadoCivil);
                comando.Parameters.AddWithValue("@Parentesco", this.Parentesco);
                comando.Parameters.AddWithValue("@OtroFamiliar", this.OtroFamiliar);
                comando.Parameters.AddWithValue("@Nacionalidad", this.Nacionalidad);
                comando.Parameters.AddWithValue("@Encuestas_idEncuestas", this.Encuestas_idEncuestas);
                comando.Parameters.AddWithValue("@Departamento_idDepartamento", this.Departamento_idDepartamento);
                comando.Parameters.AddWithValue("@Municipio_idMunicipio", this.Municipio_idMunicipio);

                try
                {
                    //comando.Connection.Open();
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