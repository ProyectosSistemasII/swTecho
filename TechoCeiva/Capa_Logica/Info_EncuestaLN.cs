using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Capa_Datos;
using System.Windows.Forms;

namespace Capa_Logica
{
    public class Info_EncuestaLN : Info_Encuesta
    {
        // setear las variables
        public Info_EncuestaLN()
        {
            this.CodigoHogar = "";
            this.idVoluntario1 = 0;
            this.idVoluntario2 = 0;
            this.FechaEncuesta = DateTime.Today;
            this.HoraInicio = "";
            this.HoraFin = "";
            this.DatosEncuestado = "";
            this.EstadoEncuesta = "";
            this.ObservacionesEstado = "";
            this.AldeaRuralNoZonaUrbana = "";
            this.CantonCaserioSector = "";
            this.XGPS = "";
            this.YGPS = "";
            this.JefeFamilia = "";
            this.PrimerTelefono = "";
            this.SegundoTelefono = "";
            this.Direccion = "";
            this.Especificaciones = "";
            this.idComunidad = 0;
            this.errores = new List<Error>();
        }

        // se validan los campos de la encuesta para la seccion de informacion
        public Boolean Insertar_InfoEncuesta(string CodigoHogar, int idVoluntario1, int idVoluntario2, DateTime FechaEncuesta, string HoraInicio,
                string HoraFin, string DatosEncuestado, string EstadoEncuesta, string ObservacionesEstado, string AldeaRuralNoZonaUrbana, string CantonCaserioSector,
                   string XGPS, string YGPS, string JefeFamilia, string PrimerTelefono, string SegundoTelefono, string Direccion, string Especificaciones,
                int idComunidad)
        {
            Boolean correcto = true;
            //verificar sintaxis de los datos y comprobar errores antes de ser enviado a la capa de datos
            this.CodigoHogar = CodigoHogar;
            this.idVoluntario1 = idVoluntario1;
            this.idVoluntario2 = idVoluntario2;
            this.FechaEncuesta = FechaEncuesta;
            this.HoraInicio = HoraInicio;
            this.HoraFin = HoraFin;
            this.DatosEncuestado = DatosEncuestado;
            this.EstadoEncuesta = EstadoEncuesta;
            this.ObservacionesEstado = ObservacionesEstado;
            this.AldeaRuralNoZonaUrbana = AldeaRuralNoZonaUrbana;
            this.CantonCaserioSector = CantonCaserioSector;
            this.XGPS = XGPS;
            this.YGPS = YGPS;
            this.JefeFamilia = JefeFamilia;
            this.PrimerTelefono = PrimerTelefono;
            this.SegundoTelefono = SegundoTelefono;
            this.Direccion = Direccion;
            this.Especificaciones = Especificaciones;
            this.idComunidad = idComunidad;
            this.verificarDatos(); // verifica los datos

            if (errores.Count > 0)
            {
                return correcto = false; // devuelve false si encuentra algun error
            }

            Info_Encuesta info = new Info_Encuesta(CodigoHogar, idVoluntario1, idVoluntario2, FechaEncuesta, HoraInicio,
                HoraFin, DatosEncuestado, EstadoEncuesta, ObservacionesEstado, AldeaRuralNoZonaUrbana, CantonCaserioSector,
                   XGPS, YGPS, JefeFamilia, PrimerTelefono, SegundoTelefono, Direccion, Especificaciones, idComunidad);
            this.errores = info.errores;


            /*if (idVoluntario1 == 0 && idVoluntario2 ==0)
            {
                MessageBox.Show("No se ha seleccionado un encuestador", "Error");
                return correcto = false;                
            }*/
            if (errores.Count > 0)
            {
                correcto = false;
            }
            return correcto;
        }

        // verificacion de los campos requeridos en la encuesta
        public void verificarDatos()
        {
            if (this.CodigoHogar == "")
            {
                Error error = new Error("Código hogar", 5000, 1);
                errores.Add(error);
            }
            if (this.idVoluntario1 == 0 && this.idVoluntario2 == 0)
            {
                Error error = new Error("Encuestadores", 5000, 1);
                errores.Add(error);
            }
            if (this.FechaEncuesta == null)
            {
                Error error = new Error("Fecha de encuesta", 5000, 1);
                errores.Add(error);
            }
            if (this.HoraInicio == "")
            {
                Error error = new Error("Hora inicio", 5000, 1);
                errores.Add(error);
            }
            if (this.HoraFin == "")
            {
                Error error = new Error("Hora fin", 5000, 1);
                errores.Add(error);
            }
            if (this.DatosEncuestado == "")
            {
                Error error = new Error("Nombre del encuestado", 5000, 1);
                errores.Add(error);
            }
            if (this.EstadoEncuesta == "")
            {
                Error error = new Error("Estado de la encuesta", 5000, 1);
                errores.Add(error);
            }
            if (this.ObservacionesEstado == "")
            {
                Error error = new Error("Observaciones del estado", 5000, 1);
                errores.Add(error);
            }
            if (this.AldeaRuralNoZonaUrbana == "")
            {
                Error error = new Error("Aldea rural/No. Zona Urbana", 5000, 1);
                errores.Add(error);
            }
            if (this.CantonCaserioSector == "")
            {
                Error error = new Error("Cantón/Caserio/Sector", 5000, 1);
                errores.Add(error);
            }
            if (this.XGPS == "" || this.YGPS == "")
            {
                Error error = new Error("Coordenadas GPS", 5000, 1);
                errores.Add(error);
            }
            if (this.JefeFamilia == "")
            {
                Error error = new Error("Jefe/a de familia", 5000, 1);
                errores.Add(error);
            }
            if (this.PrimerTelefono == "" && this.SegundoTelefono == "")
            {
                Error error = new Error("Teléfonos", 5000, 1);
                errores.Add(error);
            }
            if (this.Direccion == "")
            {
                Error error = new Error("Direccion", 5000, 1);
                errores.Add(error);
            }
            if (this.Especificaciones == "")
            {
                Error error = new Error("Especificaciones", 5000, 1);
                errores.Add(error);
            }
        }

        public string obtenerError()
        {
            Error error = errores[0];
            return error.mensaje;
        }
    }
}
