using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Capa_Datos;

namespace Capa_Logica
{
    public class Info_EncuestaLN : Info_Encuesta
    {
        public Info_EncuestaLN()
        {
            this.CodigoHogar = "";
            this.idVoluntario1 = 0;
            this.idVoluntario2 = 0;
            this.FechaEncuesta = DateTime.Today;
            this.HoraInicio = "";
            this.HoraFin = "";
            this.DatosEncuestado = "";
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
        }

        public Boolean Insertar_InfoEncuesta(string CodigoHogar, int idVoluntario1, int idVoluntario2, DateTime FechaEncuesta, string HoraInicio,
                string HoraFin, string DatosEncuestado, string ObservacionesEstado, string AldeaRuralNoZonaUrbana, string CantonCaserioSector,
                   string XGPS, string YGPS, string JefeFamilia, string PrimerTelefono, string SegundoTelefono, string Direccion, string Especificaciones,
                int idComunidad)
        {
            Boolean correcto = true;
            Info_Encuesta info = new Info_Encuesta(CodigoHogar, idVoluntario1, idVoluntario2, FechaEncuesta, HoraInicio,
                HoraFin, DatosEncuestado, ObservacionesEstado, AldeaRuralNoZonaUrbana, CantonCaserioSector,
                   XGPS, YGPS, JefeFamilia, PrimerTelefono, SegundoTelefono, Direccion, Especificaciones, idComunidad);
            this.CodigoHogar = CodigoHogar;
            this.idVoluntario1 = idVoluntario1;
            this.idVoluntario2 = idVoluntario2;
            this.FechaEncuesta = FechaEncuesta;
            this.HoraInicio = HoraInicio;
            this.HoraFin = HoraFin;
            this.DatosEncuestado = DatosEncuestado;
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
