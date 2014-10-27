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
        public int idUsuario { get; set; }
        public int idVoluntario { get; set; }
        public string nombreVoluntario { get; set; }
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
            this.idUsuario = 0;
            this.idVoluntario = 0;
            this.fechaPrestamo =  DateTime.MinValue;
            this.Observaciones = "";
            this.Activo = 0;
            this.fechaFinPrestamo = DateTime.MaxValue;

        }

        public _Prestamo(int _idPrestamo, int _idUsuario, int _idVoluntario, DateTime _fechaPrestamo, String _Observaciones, int _Activo, String nombreVoluntario)
        {
            this.iDPrestamo = _idPrestamo;
            this.idUsuario = _idUsuario;
            this.idVoluntario = _idVoluntario;
            this.fechaPrestamo = _fechaPrestamo;
            this.Observaciones = _Observaciones;
            this.Activo = _Activo;
            this.nombreVoluntario = nombreVoluntario;
            //this.fechaFinPrestamo = _fechaFinPrestamo;
            this._errores = new List<Error>();
        }

        public _Prestamo(int _idPrestamo, int _idUsuario, int _idVoluntario, DateTime _fechaPrestamo, String _Observaciones, int _Activo)
        {
            this.iDPrestamo = _idPrestamo;
            this.idUsuario = _idUsuario;
            this.idVoluntario = _idVoluntario;
            this.fechaPrestamo = _fechaPrestamo;
            this.Observaciones = _Observaciones;
            this.Activo = _Activo;
            //this.fechaFinPrestamo = _fechaFinPrestamo;
            this._errores = new List<Error>();
        }

        public int _InsertarPrestamo()
        {
            if (this._errores.Count == 0)
            {
                int  lastID = 0;
                string consulta = "insert into prestamo (Usuarios_idUsuarios, Voluntarios_idVoluntarios, FechaPrestamo," +
                                                        "Observaciones, Activo, FechaFinPrestamo)" +
                                                "values (@idUsuario, @idVoluntario, @FechaPrestamo, @Observaciones," +
                                                        "@Activo, @FechaFinPrestamo)";

                MySqlCommand _comando = new MySqlCommand(consulta, ConexionBD.conexion);
                _comando.Parameters.AddWithValue("@idUsuario", this.idUsuario);
                _comando.Parameters.AddWithValue("@idVoluntario", this.idVoluntario);
                _comando.Parameters.AddWithValue("@FechaPrestamo", this.fechaPrestamo);
                _comando.Parameters.AddWithValue("@Observaciones", this.Observaciones);
                _comando.Parameters.AddWithValue("@Activo", 1);
                _comando.Parameters.AddWithValue("@FechaFinPrestamo", this.fechaFinPrestamo);

                try
                {
                    _comando.Connection.Open();
                    _comando.ExecuteNonQuery();
                    lastID = Convert.ToInt32(_comando.LastInsertedId);
                    _comando.Connection.Close();
                    return lastID;
                }
                catch (MySqlException ex)
                {
                    _comando.Connection.Close();
                    Error _error = new Error(ex.Message + " " + ex.Number, 2);
                    _errores.Add(_error);
                }
            }
            return 0;
        }

        public int ultimaInsercion()
        {
            string query = "";
            _Prestamo ultimoPrestamo;

            MySqlCommand _comando = new MySqlCommand(query, _conexion);
            _comando.CommandTimeout = 12280;
            DataSet _ds = new DataSet();
            MySqlDataAdapter _adapter = new MySqlDataAdapter();
            _adapter.SelectCommand = _comando;
            _adapter.Fill(_ds);
            DataTable _tabla = new DataTable();
            _tabla = _ds.Tables[0];

            DataRow _row = _tabla.Rows[0];
            //ultimoPrestamo = new _Prestamo(Convert.ToInt32(_row["idPrestamo"]), Convert.ToInt32(_row["Usuarios_idUsuarios"]), Convert.ToInt32(_row["Voluntarios_idVoluntarios"]), Convert.ToDateTime(_row["FechaPrestamo"]), Convert.ToString(_row["Observaciones"]), Convert.ToInt32(_row["Activo"]), Convert.ToDateTime(_row["FechaFinPrestamo"]));
            ultimoPrestamo = new _Prestamo(Convert.ToInt32(_row["idPrestamo"]), Convert.ToInt32(_row["Usuarios_idUsuarios"]), Convert.ToInt32(_row["Voluntarios_idVoluntarios"]), Convert.ToDateTime(_row["FechaPrestamo"]), Convert.ToString(_row["Observaciones"]), Convert.ToInt32(_row["Activo"]), Convert.ToString(_row["NombreVoluntarios"]));

            return ultimoPrestamo.iDPrestamo;
        }

        public List<_Prestamo> obtenerTodosPrestamos()
        {
            //string query = "Select * FROM Prestamo WHERE Activo = 1";
            string consulta = "select prestamo.idPrestamo, prestamo.Usuarios_idUsuarios, prestamo.Voluntarios_idVoluntarios,"+
                                     "prestamo.FechaPrestamo, prestamo.Observaciones, prestamo.Activo,"+
                                     "Voluntarios.Nombres as NombreVoluntarios from prestamo"+
                         " inner join voluntarios on Voluntarios_idVoluntarios = idVoluntarios"+
                         " where prestamo.Activo = 1";
            List<_Prestamo> listadoPrestamos = new List<_Prestamo>();

            MySqlCommand _comando = new MySqlCommand(consulta, _conexion);
            _comando.CommandTimeout = 12280;
            DataSet _ds = new DataSet();
            MySqlDataAdapter _adapter = new MySqlDataAdapter();
            _adapter.SelectCommand = _comando;
            _adapter.Fill(_ds);
            DataTable _tabla = new DataTable();
            _tabla = _ds.Tables[0];

            for (int i = 0; i < _tabla.Rows.Count; i++)
            {
                DataRow _row = _tabla.Rows[i];
                _Prestamo prestamo = new _Prestamo(Convert.ToInt32(_row["idPrestamo"]), Convert.ToInt32(_row["Usuarios_idUsuarios"]), Convert.ToInt32(_row["Voluntarios_idVoluntarios"]), Convert.ToDateTime(_row["FechaPrestamo"]), Convert.ToString(_row["Observaciones"]), Convert.ToInt32(_row["Activo"]), Convert.ToString(_row["NombreVoluntarios"]));
                listadoPrestamos.Add(prestamo);
            }

            return listadoPrestamos;
        }
        
        public List<_Prestamo> buscarPrestamosPor(int idVoluntario)
        {
            //string query = "Select * FROM Prestamo WHERE Activo = 1 AND Voluntarios_idVoluntarios = "+idVoluntario;
            string consulta = "select prestamo.idPrestamo, prestamo.Usuarios_idUsuarios, prestamo.Voluntarios_idVoluntarios," +
                                     "prestamo.FechaPrestamo, prestamo.Observaciones, prestamo.Activo," +
                                     "Voluntarios.Nombres as NombreVoluntarios from prestamo" +
                         " inner join voluntarios on Voluntarios_idVoluntarios = idVoluntarios" +
                         " where prestamo.Activo = 1 and prestamo.Voluntarios_idVoluntarios = "+idVoluntario;
            List<_Prestamo> listadoPrestamosEspecificos = new List<_Prestamo>();

            MySqlCommand _comando = new MySqlCommand(consulta, _conexion);
            _comando.CommandTimeout = 12280;
            DataSet _ds = new DataSet();
            MySqlDataAdapter _adapter = new MySqlDataAdapter();
            _adapter.SelectCommand = _comando;
            _adapter.Fill(_ds);
            DataTable _tabla = new DataTable();
            _tabla = _ds.Tables[0];

            for (int i = 0; i < _tabla.Rows.Count; i++)
            {
                DataRow _row = _tabla.Rows[i];
                _Prestamo prestamo = new _Prestamo(Convert.ToInt32(_row["idPrestamo"]), Convert.ToInt32(_row["Usuarios_idUsuarios"]), Convert.ToInt32(_row["Voluntarios_idVoluntarios"]), Convert.ToDateTime(_row["FechaPrestamo"]), Convert.ToString(_row["Observaciones"]), Convert.ToInt32(_row["Activo"]), Convert.ToString(_row["NombreVoluntarios"]));
                listadoPrestamosEspecificos.Add(prestamo);
            }

            return listadoPrestamosEspecificos;
        }
    }
}
