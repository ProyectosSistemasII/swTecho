using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using MySql.Data.MySqlClient;

namespace Capa_Datos
{
    public class Info_Encuesta
    {
        public string CodigoHogar { get; set; }
        public int idVoluntario1 { get; set; }
        public int idVoluntario2 { get; set; }
        public DateTime FechaEncuesta { get; set; }
        public string HoraInicio { get; set; }
        public string HoraFin { get; set; }
        public string DatosEncuestado { get; set; }
        public string EstadoEncuesta { get; set; }
        public string ObservacionesEstado { get; set; }
        public string AldeaRuralNoZonaUrbana { get; set; }
        public string CantonCaserioSector { get; set; }
        public string XGPS { get; set; }
        public string YGPS { get; set; }
        public string JefeFamilia { get; set; }
        public string PrimerTelefono { get; set; }
        public string SegundoTelefono { get; set; }
        public string Direccion { get; set; }
        public string Especificaciones { get; set; }
        public int idComunidad { get; set; }

        public List<Error> errores { get; set; }
        private static ConexionBD datos = new ConexionBD();
        private static MySqlConnection conex = ConexionBD.conexion;

        public Info_Encuesta()
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
        }
        public Info_Encuesta(string CodigoHogar, int idVoluntario1, int idVoluntario2, DateTime FechaEncuesta, string HoraInicio, string HoraFin,
            string DatosEncuestado, string EstadoEncuesta, string ObservacionesEstado, string AldeaRuralNoZonaUrbana, string CantonCaserioSector, string XGPS, string YGPS,
            string JefeFamilia, string PrimerTelefono, string SegundoTelefono, string Direccion, string Especificaciones, int idComunidad)
        {
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
            this.errores = new List<Error>();
            this.InsertarInfoEncuesta();
        }

        // Ingreso de informacion de encuesta
        public void InsertarInfoEncuesta()
        {

            if (this.errores.Count == 0)
            {
                string consulta = "INSERT INTO Encuestas(CodigoHogar, Voluntarios_idVoluntarios, Voluntarios_idVoluntarios1, FechaEncuesta, HoraInicio, HoraFin, DatosEncuestado, EstadoEncuesta, ObservacionesEstado, AldeaRuralNoZonaUrbana, CantonCaserioSector, XGPS, YGPS, JefeFamilia, PrimerTelefono, SegundoTelefono, Direccion, Especificaciones, Activo, Comunidad_idComunidad) VALUES(@CodigoHogar, @Voluntarios_idVoluntarios, @Voluntarios_idVoluntarios1, @FechaEncuesta, @HoraInicio, @HoraFin, @DatosEncuestado, @EstadoEncuesta, @ObservacionesEstado, @AldeaRuralNoZonaUrbana, @CantonCaserioSector, @XGPS, @YGPS, @JefeFamilia, @PrimerTelefono, @SegundoTelefono, @Direccion, @Especificaciones, true, @Comunidad_idComunidad)";
                MySqlCommand comando = new MySqlCommand(consulta, conex);
                comando.Parameters.AddWithValue("@CodigoHogar", this.CodigoHogar);
                comando.Parameters.AddWithValue("@Voluntarios_idVoluntarios", this.idVoluntario1);
                if (this.idVoluntario2 == 0)
                    comando.Parameters.AddWithValue("@Voluntarios_idVoluntarios1", null);
                else
                    comando.Parameters.AddWithValue("@Voluntarios_idVoluntarios1", this.idVoluntario2);
                comando.Parameters.AddWithValue("@FechaEncuesta", this.FechaEncuesta.Date);
                comando.Parameters.AddWithValue("@HoraInicio", this.HoraInicio);
                comando.Parameters.AddWithValue("@HoraFin", this.HoraFin);
                comando.Parameters.AddWithValue("@DatosEncuestado", this.DatosEncuestado);
                comando.Parameters.AddWithValue("@EstadoEncuesta", this.EstadoEncuesta);
                comando.Parameters.AddWithValue("@ObservacionesEstado", this.ObservacionesEstado);
                comando.Parameters.AddWithValue("@AldeaRuralNoZonaUrbana", this.AldeaRuralNoZonaUrbana);
                comando.Parameters.AddWithValue("@CantonCaserioSector", this.CantonCaserioSector);
                comando.Parameters.AddWithValue("@XGPS", this.XGPS);
                comando.Parameters.AddWithValue("@YGPS", this.YGPS);
                comando.Parameters.AddWithValue("@JefeFamilia", this.JefeFamilia);
                comando.Parameters.AddWithValue("@PrimerTelefono", this.PrimerTelefono);
                comando.Parameters.AddWithValue("@SegundoTelefono", this.SegundoTelefono);
                comando.Parameters.AddWithValue("@Direccion", this.Direccion);
                comando.Parameters.AddWithValue("@Especificaciones", this.Especificaciones);
                comando.Parameters.AddWithValue("@Comunidad_idComunidad", this.idComunidad);

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
        // Obtener el idEncuesta ingresado
        public int UltimoId()
        {
            int id = 0;
            String consulta = "SELECT MAX(idEncuestas) FROM Encuestas";
            MySqlCommand comando = new MySqlCommand(consulta, conex);
            try
            {
                comando.Connection.Open();
                id = (Int32)comando.ExecuteScalar();
                comando.Connection.Close();
            }
            catch (MySqlException ex)
            {
                Error error = new Error(ex.Message + " " + ex.Number, 0);
                errores.Add(error);
            }
            return id;
        }
    }
}
