using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using MySql.Data.MySqlClient;

namespace Capa_Datos
{
    public class S3_Educacion
    {
        public int CodigoS3 { get; set; }
        public string LeerEscribir { get; set; }
        public string GradoEducacion { get; set; }
        public string OtroGrado { get; set; }
        public string AsistenciaEstablecimiento { get; set; }
        public string NombreEstablecimiento { get; set; }
        public string TipoEstablecimiento { get; set; }
        public string OtroTipoEstablecimiento { get; set; }
        public string UbicacionEstablecimiento { get; set; }
        public string RazonNoAsistencia { get; set; }
        public string OtraRazon { get; set; }
        public string FormacionComplementaria { get; set; }
        public string TipoFormacion { get; set; }
        public int Encuestas_idEncuestas { get; set; }

        public List<Error> errores { get; set; }
        private static ConexionBD datos = new ConexionBD();
        private static MySqlConnection conex = ConexionBD.conexion;

        public S3_Educacion()
        {
            this.CodigoS3 = 0;
            this.LeerEscribir = "";
            this.GradoEducacion = "";
            this.OtroGrado = "";
            this.AsistenciaEstablecimiento = "";
            this.NombreEstablecimiento = "";
            this.TipoEstablecimiento = "";
            this.OtroTipoEstablecimiento = "";
            this.UbicacionEstablecimiento = "";
            this.RazonNoAsistencia = "";
            this.OtraRazon = "";
            this.FormacionComplementaria = "";
            this.TipoFormacion = "";
            this.Encuestas_idEncuestas = 0;
        }

        public S3_Educacion(int CodigoS3, string LeerEscribir, string GradoEducacion, string OtroGrado,
            string AsistenciaEstablecimiento, string NombreEstablecimiento, string TipoEstablecimiento, string OtroTipoEstablecimiento,
            string UbicacionEstablecimiento, string RazonNoAsistencia, string OtraRazon, string FormacionComplementaria, string TipoFormacion, int Encuestas_idEncuestas)
        {
            this.CodigoS3 = CodigoS3;
            this.LeerEscribir = LeerEscribir;
            this.GradoEducacion = GradoEducacion;
            this.OtroGrado = OtroGrado;
            this.AsistenciaEstablecimiento = AsistenciaEstablecimiento;
            this.NombreEstablecimiento = NombreEstablecimiento;
            this.TipoEstablecimiento = TipoEstablecimiento;
            this.OtroTipoEstablecimiento = OtroTipoEstablecimiento;
            this.UbicacionEstablecimiento = UbicacionEstablecimiento;
            this.RazonNoAsistencia = RazonNoAsistencia;
            this.OtraRazon = OtraRazon;
            this.FormacionComplementaria = FormacionComplementaria;
            this.TipoFormacion = TipoFormacion;
            this.Encuestas_idEncuestas = Encuestas_idEncuestas;
            this.errores = new List<Error>();
            this.InsertarS3();
        }

        public void InsertarS3()
        {

            if (this.errores.Count == 0)
            {
                string consulta = "INSERT INTO s3_edu(CodigoS3, LeerEscribir, GradoEducacion, OtroGrado, AsistenciaEstablecimiento, NombreEstablecimiento, TipoEstablecimiento, OtroTipoEstablecimiento, UbicacionEstablecimiento, RazonNoAsistencia, OtraRazon, FormacionComplementaria, TipoFormacion, Encuestas_idEncuestas) VALUES (@CodigoS3, @LeerEscribir, @GradoEducacion, @OtroGrado, @AsistenciaEstablecimiento, @NombreEstablecimiento, @TipoEstablecimiento, @OtroTipoEstablecimiento, @UbicacionEstablecimiento, @RazonNoAsistencia, @OtraRazon, @FormacionComplementaria, @TipoFormacion, @Encuestas_idEncuestas)";
                MySqlCommand comando = new MySqlCommand(consulta, conex);
                comando.Parameters.AddWithValue("@CodigoS3", this.CodigoS3);
                comando.Parameters.AddWithValue("@LeerEscribir", this.LeerEscribir);
                comando.Parameters.AddWithValue("@GradoEducacion", this.GradoEducacion);
                comando.Parameters.AddWithValue("@OtroGrado", this.OtroGrado);
                comando.Parameters.AddWithValue("@AsistenciaEstablecimiento", this.AsistenciaEstablecimiento);
                comando.Parameters.AddWithValue("@NombreEstablecimiento", this.NombreEstablecimiento);
                comando.Parameters.AddWithValue("@TipoEstablecimiento", this.TipoEstablecimiento);
                comando.Parameters.AddWithValue("@OtroTipoEstablecimiento", this.OtroTipoEstablecimiento);
                comando.Parameters.AddWithValue("@UbicacionEstablecimiento", this.UbicacionEstablecimiento);
                comando.Parameters.AddWithValue("@RazonNoAsistencia", this.RazonNoAsistencia);
                comando.Parameters.AddWithValue("@OtraRazon", this.OtraRazon);
                comando.Parameters.AddWithValue("@FormacionComplementaria", this.FormacionComplementaria);
                comando.Parameters.AddWithValue("@TipoFormacion", this.TipoFormacion);
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
