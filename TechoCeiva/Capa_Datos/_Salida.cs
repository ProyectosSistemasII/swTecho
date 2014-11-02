using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MySql.Data.MySqlClient;
using System.Data;

namespace Capa_Datos
{
    public class _Salida
    {
        public int idSalida { get; set; }
        public DateTime FechaSalida { get; set; }
        public int Usuarios_idUsuarios { get; set; }
        public int Voluntarios_idVoluntarios { get; set; }
        public string nombreVoluntario { get; set; }
        public int Activo { get; set; }
        public String Descripcion { get; set; }

        public List<Error> _errores { get; set; }

        private static ConexionBD _datos = new ConexionBD();
        private static MySqlConnection _conexion = ConexionBD.conexion;

        public _Salida()
        {
            this.idSalida = 0;
            this.FechaSalida =  DateTime.Today;
            this.Usuarios_idUsuarios = 0;
            this.Voluntarios_idVoluntarios = 0;
            this.Activo = 1;
            this.Descripcion = "";
        }

        public _Salida(int _idSalida, int _idUsuario, int _idVoluntario, DateTime _fechaSalida, String _Descripcion, int _Activo)
        {
            this.idSalida = _idSalida;
            this.Usuarios_idUsuarios = _idUsuario;
            this.Voluntarios_idVoluntarios = _idVoluntario;
            this.FechaSalida = _fechaSalida;
            this.Descripcion = _Descripcion;
            this.Activo = _Activo;
            this._errores = new List<Error>();
        }

        public _Salida(int _idSalida, int _idUsuario, int _idVoluntario, DateTime _fechaSalida, String _Descripcion, int _Activo, String nombreVoluntario)
        {
            this.idSalida = _idSalida;
            this.Usuarios_idUsuarios = _idUsuario;
            this.Voluntarios_idVoluntarios = _idVoluntario;
            this.FechaSalida = _fechaSalida;
            this.Descripcion = _Descripcion;
            this.Activo = _Activo;
            this.nombreVoluntario = nombreVoluntario;
        }

        public int _InsertarSalida()
        {
            if (this._errores.Count == 0)
            {
                int lastID = 0;
                string query = "INSERT INTO Salida (FechaSalida,Usuarios_idUsuarios, Activo, Descripcion, Voluntarios_idVoluntarios) VALUES (@FechaSalida,@Usuarios_idUsuarios, @Activo, @Descripcion,@Voluntarios_idVoluntarios)";
                MySqlCommand _comando = new MySqlCommand(query, _conexion);
                _comando.Parameters.AddWithValue("@FechaSalida", this.FechaSalida);
                _comando.Parameters.AddWithValue("@Usuarios_idUsuarios", this.Usuarios_idUsuarios);
                _comando.Parameters.AddWithValue("@Activo", 1);
                _comando.Parameters.AddWithValue("@Descripcion", this.Descripcion);
                _comando.Parameters.AddWithValue("@Voluntarios_idVoluntarios", this.Voluntarios_idVoluntarios);
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
            _Salida ultimaSalida;

            MySqlCommand _comando = new MySqlCommand(query, _conexion);
            _comando.CommandTimeout = 12280;
            DataSet _ds = new DataSet();
            MySqlDataAdapter _adapter = new MySqlDataAdapter();
            _adapter.SelectCommand = _comando;
            _adapter.Fill(_ds);
            DataTable _tabla = new DataTable();
            _tabla = _ds.Tables[0];

            DataRow _row = _tabla.Rows[0];
            ultimaSalida = new _Salida(Convert.ToInt32(_row["idSalida"]), Convert.ToInt32(_row["Usuarios_idUsuarios"]), Convert.ToInt32(_row["Voluntarios_idVoluntarios"]), Convert.ToDateTime(_row["FechaSalida"]), Convert.ToString(_row["Descripcion"]), Convert.ToInt32(_row["Activo"]), Convert.ToString(_row["NombreVoluntarios"]));

            return ultimaSalida.idSalida;
        }

        public List<_Salida> obtenerTodasSalidas()
        {
            string consulta = "select salida.idSalida, salida.Usuarios_idUsuarios, salida.Voluntarios_idVoluntarios," +
                                     "salida.FechaSalida, salida.Descripcion, salida.Activo," +
                                     "Voluntarios.Nombres as NombreVoluntarios from salida" +
                         " inner join voluntarios on Voluntarios_idVoluntarios = idVoluntarios" +
                         " where salida.Activo = 1";
            List<_Salida> listadoSalidas = new List<_Salida>();

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
                _Salida salida = new _Salida(Convert.ToInt32(_row["idSalida"]), Convert.ToInt32(_row["Usuarios_idUsuarios"]), Convert.ToInt32(_row["Voluntarios_idVoluntarios"]), Convert.ToDateTime(_row["FechaSalida"]), Convert.ToString(_row["Descripcion"]), Convert.ToInt32(_row["Activo"]), Convert.ToString(_row["NombreVoluntarios"]));
                listadoSalidas.Add(salida);
            }
            return listadoSalidas;
        }

        public List<_Salida> buscarSalidasPorV(int idVoluntario)
        {
            string consulta = "select salida.idSalida, salida.Usuarios_idUsuarios, salida.Voluntarios_idVoluntarios," +
                                     "salida.FechaSalida, salida.Descripcion, salida.Activo," +
                                     "Voluntarios.Nombres as NombreVoluntarios from salida" +
                         " inner join voluntarios on Voluntarios_idVoluntarios = idVoluntarios" +
                         " where salida.Activo = 1 and salida.Voluntarios_idVoluntarios = " + idVoluntario;
            List<_Salida> listadoSalidasEspecificas = new List<_Salida>();

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
                _Salida salida = new _Salida(Convert.ToInt32(_row["idSalida"]), Convert.ToInt32(_row["Usuarios_idUsuarios"]), Convert.ToInt32(_row["Voluntarios_idVoluntarios"]), Convert.ToDateTime(_row["FechaSalida"]), Convert.ToString(_row["Descripcion"]), Convert.ToInt32(_row["Activo"]), Convert.ToString(_row["NombreVoluntarios"]));
                listadoSalidasEspecificas.Add(salida);
            }
            return listadoSalidasEspecificas;
        }

        public List<_Salida> buscarSalidasPorF(String FechaSalida)
        {
            string consulta = "select salida.idSalida, salida.Usuarios_idUsuarios, salida.Voluntarios_idVoluntarios," +
                                     "salida.FechaSalida, salida.Descripcion, salida.Activo," +
                                     "Voluntarios.Nombres as NombreVoluntarios from salida" +
                         " inner join voluntarios on Voluntarios_idVoluntarios = idVoluntarios" +
                         " where salida.Activo = 1 and salida.FechaSalida = '" + FechaSalida + "'";
            List<_Salida> listadoSalidasEspecificas = new List<_Salida>();

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
                _Salida salida = new _Salida(Convert.ToInt32(_row["idSalida"]), Convert.ToInt32(_row["Usuarios_idUsuarios"]), Convert.ToInt32(_row["Voluntarios_idVoluntarios"]), Convert.ToDateTime(_row["FechaSalida"]), Convert.ToString(_row["Descripcion"]), Convert.ToInt32(_row["Activo"]), Convert.ToString(_row["NombreVoluntarios"]));
                listadoSalidasEspecificas.Add(salida);
            }
            return listadoSalidasEspecificas;
        }

        public List<_Salida> buscarSalidasPorVF(int idVoluntario, String FechaSalida)
        {
            string consulta = "select salida.idSalida, salida.Usuarios_idUsuarios, salida.Voluntarios_idVoluntarios," +
                                     "salida.FechaSalida, salida.Descripcion, salida.Activo," +
                                     "Voluntarios.Nombres as NombreVoluntarios from salida" +
                         " inner join voluntarios on Voluntarios_idVoluntarios = idVoluntarios" +
                         " where salida.Activo = 1 and salida.Voluntarios_idVoluntarios = " + idVoluntario + " and salida.FechaSalida = '" + FechaSalida + "'";
            List<_Salida> listadoSalidasEspecificas = new List<_Salida>();

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
                _Salida salida = new _Salida(Convert.ToInt32(_row["idSalida"]), Convert.ToInt32(_row["Usuarios_idUsuarios"]), Convert.ToInt32(_row["Voluntarios_idVoluntarios"]), Convert.ToDateTime(_row["FechaSalida"]), Convert.ToString(_row["Descripcion"]), Convert.ToInt32(_row["Activo"]), Convert.ToString(_row["NombreVoluntarios"]));
                listadoSalidasEspecificas.Add(salida);
            }
            return listadoSalidasEspecificas;
        }
    }
}
