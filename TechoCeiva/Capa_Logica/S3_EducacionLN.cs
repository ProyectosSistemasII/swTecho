using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Capa_Datos;

namespace Capa_Logica
{
    public class S3_EducacionLN : S3_Educacion
    {
        public S3_EducacionLN()
        {
            this.CodigoS3 = 0;
            this.LeerEscribir = "";
            this.GradoEducacion = "";
            this.OtroGrado = "";
            this.AsistenciaEstablecimiento = "";
            this.NombreEstablecimiento = "";
            /*uno solo*/
            this.TipoEstablecimiento = "";
            this.OtroTipoEstablecimiento = "";
            /*---------*/
            this.UbicacionEstablecimiento = "";
            /*uno solo*/
            this.RazonNoAsistencia = "";
            this.OtraRazon = "";
            /*----------*/
            /*uno solo*/
            this.FormacionComplementaria = "";
            this.TipoFormacion = "";
            /*----------*/
            this.Encuestas_idEncuestas = 0;
        }

        public S3_EducacionLN(int CodigoS3, string LeerEscribir, string GradoEducacion, string OtroGrado,
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
        }

        public Boolean Insertar_EncuS3()
        {
            Boolean correcto = true;
            S3_Educacion educacion = new S3_Educacion(CodigoS3, LeerEscribir, GradoEducacion, OtroGrado, AsistenciaEstablecimiento, NombreEstablecimiento, TipoEstablecimiento,
                OtroTipoEstablecimiento, UbicacionEstablecimiento, RazonNoAsistencia, OtraRazon, FormacionComplementaria, TipoFormacion, Encuestas_idEncuestas);
            educacion.InsertarS3();
            if (errores.Count > 0)
            {
                correcto = false;
            }
            return correcto;
        }

        public Boolean validacion(int CodigoS3, string LeerEscribir, string GradoEducacion, string OtroGrado,
            string AsistenciaEstablecimiento, string NombreEstablecimiento, string TipoEstablecimiento, string OtroTipoEstablecimiento,
            string UbicacionEstablecimiento, string RazonNoAsistencia, string OtraRazon, string FormacionComplementaria, string TipoFormacion, int Encuestas_idEncuestas, int Filas)
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
            this.verificarDatos(Filas);

            if (errores.Count > 0)
            {
                return false;
            }
            return true;
        }

        public void verificarDatos(int filas)
        {
            if (this.LeerEscribir == "")
            {
                Error error = new Error("¿Sabe leer y escribir? Fila:" + filas.ToString(), 5000, 1);
                errores.Add(error);
            }
            if (this.GradoEducacion == "")
            {
                Error error = new Error("¿Cuál es el grado más alto de educación que completó? " + filas.ToString(), 5000, 1);
                errores.Add(error);
            }
            if (this.GradoEducacion == "Técnico (especificar)" || this.GradoEducacion == "Otro (especificar)")
            {
                if (this.OtroGrado == "")
                {
                    Error error = new Error("Especificar grado de educación" + filas.ToString(), 5000, 1);
                    errores.Add(error);
                }
            }
            if (this.AsistenciaEstablecimiento == "")
            {
                Error error = new Error("Actualmente ¿Asiste a algún establecimiento educativo?" + filas.ToString(), 5000, 1);
                errores.Add(error);
            }
            if (this.AsistenciaEstablecimiento == "Si asiste")// || this.AsistenciaEstablecimiento == "NR/NR")
            {
                if (this.NombreEstablecimiento == "")
                {
                    Error error = new Error("¿Cuál es el nombre del centro educativo al que asiste?" + filas.ToString(), 5000, 1);
                    errores.Add(error);
                }
                if (this.TipoEstablecimiento == "")
                {
                    Error error = new Error("¿Qué tipo de establecimiento es el centro educativo donde estudia?" + filas.ToString(), 5000, 1);
                    errores.Add(error);
                }
                if (this.TipoEstablecimiento == "Otro (especificar)")
                {
                    if (this.OtroTipoEstablecimiento == "")
                    {
                        Error error = new Error("Especificar otro tipo de establecimiento" + filas.ToString(), 5000, 1);
                        errores.Add(error);
                    }
                }
                if (this.UbicacionEstablecimiento == "")
                {
                    Error error = new Error("¿Dónde se ubica el establecimiento educativo al que asiste?" + filas.ToString(), 5000, 1);
                    errores.Add(error);
                }
            }
            if (this.RazonNoAsistencia == "")
            {
                Error error = new Error("¿Cuál es la razón principal por la cual no asistió, no asiste o dejo de ir a un centro educativo?" + filas.ToString(), 5000, 1);
                errores.Add(error);
            }
            if (this.RazonNoAsistencia == "Otra razón (especificar)")
            {
                if (this.OtraRazon == "")
                {
                    Error error = new Error("Especificar otra razón de no asistencia" + filas.ToString(), 5000, 1);
                    errores.Add(error);
                }
            }
            if (this.FormacionComplementaria == "")
            {
                Error error = new Error("¿Ha recibido algún tipo de formación complementaria?" + filas.ToString(), 5000, 1);
                errores.Add(error);
            }
            if (this.FormacionComplementaria == "Si (especificar)")
            {
                if (this.TipoFormacion == "")
                {
                    Error error = new Error("Especificar otro tipo de formación" + filas.ToString(), 5000, 1);
                    errores.Add(error);
                }
            }
        }

        public Boolean Insertar_EncuS3()
        {
            Boolean correcto = true;
            S3_Educacion educacion = new S3_Educacion(CodigoS3,LeerEscribir,GradoEducacion,OtroGrado,AsistenciaEstablecimiento,NombreEstablecimiento,TipoEstablecimiento,OtroTipoEstablecimiento,UbicacionEstablecimiento,RazonNoAsistencia,OtraRazon,FormacionComplementaria, TipoFormacion,Encuestas_idEncuestas);
            educacion.InsertarS3();
            this.errores = educacion.errores;
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
