using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MySql.Data.MySqlClient;
using System.Data;

namespace Capa_Datos
{
    public class _Prestamo
    {
        public int iDPrestamo { get; set; }
        public int idDetallePrestamo { get; set; }
        public int idUsuario { get; set; }
        public int idVoluntario { get; set; }
        public DateTime fechaPrestamo { get; set; }
        public String Observaciones { get; set; }
        public int Activo { get; set; }
        public DateTime fechaFinPrestamo { get; set; }

        public List<Error> _errores { get; set; }

        private static ConexionBD _datos = new ConexionBD();
        private static MySqlConnection _conexion = ConexionBD.conexion;

        public _Prestamo()
        {
            this.iDPrestamo = 0;
            this.idDetallePrestamo = 0;
            this.idUsuario = 0;
            this.idVoluntario = 0;
            this.fechaPrestamo =  DateTime.Parse("YYYY/MM/DD");
            this.Observaciones = "";
            this.Activo = 0;
            this.fechaFinPrestamo = DateTime.Parse("YYYY/MM/DD");

        }

        public _Prestamo(int _idPrestamo, int _idDetallePrestamo, int _idUsuario, int _idVoluntario, DateTime _fechaPrestamo, String _Observaciones, int _Activo, DateTime _fechaFinPrestamo)
        {
            this.iDPrestamo = _idPrestamo;
            this.idDetallePrestamo = _idDetallePrestamo;
            this.idUsuario = _idUsuario;
            this.idVoluntario = _idVoluntario;
            this.fechaPrestamo = _fechaPrestamo;
            this.Observaciones = _Observaciones;
            this.Activo = _Activo;
            this.fechaFinPrestamo = _fechaFinPrestamo;
        }

        public void _InsertarPrestamo()
        {
            if (this._errores.Count == 0)
            {
                string query = "";
                MySqlCommand _comando = new MySqlCommand(query, _conexion);
                _comando.Parameters.AddWithValue("@idDestallePrestamo", this.idDetallePrestamo);
                _comando.Parameters.AddWithValue("@idUsuario", this.idUsuario);
                _comando.Parameters.AddWithValue("@idVoluntario", this.idVoluntario);
                _comando.Parameters.AddWithValue("@FechaPrestamo", this.fechaPrestamo);
                _comando.Parameters.AddWithValue("@Observaciones", this.Observaciones);
                _comando.Parameters.AddWithValue("@Activo", this.Activo);
                _comando.Parameters.AddWithValue("@FechaFinPrestamo", this.fechaFinPrestamo);

                try
                {
                    _comando.Connection.Open();
                    _comando.ExecuteNonQuery();
                    _comando.Connection.Close();
                }
                catch (MySqlException ex)
                {
                    Error _error = new Error(ex.Message + " " + ex.Number, 2);
                    _errores.Add(_error);
                }
            }
        }
    }
}
