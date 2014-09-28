using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Capa_Datos;

namespace Capa_Logica
{
    class S3_EducacionLN : S3_Educacion
    {
        public S3_EducacionLN()
        {
            this.CodigoS3 = 0;
            this.LeerEscribir = "";
            this.GradoEducacion = "";
            this.Tecnico = "";
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

        public Boolean Insertar_EncuS3(int CodigoS3, string LeerEscribir, string GradoEducacion, string Tecnico, string OtroGrado,
            string AsistenciaEstablecimiento, string NombreEstablecimiento, string TipoEstablecimiento, string OtroTipoEstablecimiento, 
            string UbicacionEstablecimiento, string RazonNoAsistencia, string OtraRazon, string FormacionComplementaria, string TipoFormacion, int Encuestas_idEncuestas)
        {
            Boolean correcto = true;
            S3_Educacion Educacion = new S3_Educacion(CodigoS3, LeerEscribir, GradoEducacion, Tecnico, OtroGrado,
            AsistenciaEstablecimiento, NombreEstablecimiento, TipoEstablecimiento, OtroTipoEstablecimiento, 
            UbicacionEstablecimiento, RazonNoAsistencia, OtraRazon, FormacionComplementaria, TipoFormacion, Encuestas_idEncuestas);

            this.CodigoS3 = CodigoS3;
            this.LeerEscribir = LeerEscribir;
            this.GradoEducacion = GradoEducacion;
            this.Tecnico = Tecnico;
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

            if (errores.Count > 0)
            {
                correcto = false;
            }
            return correcto;
        }

        public string obtenerError()
        {
            Error error = errores[0];
            return error.mensaje;
        }

    }
}
