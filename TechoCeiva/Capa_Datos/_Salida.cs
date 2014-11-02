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
        public Boolean Activo { get; set; }
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
            this.Activo = true;
            this.Descripcion = "";

        }

        public _Salida(int _idSalida, DateTime _FechaSalida, int _Usuario, Boolean _activo, String _descripcion, int _voluntarios)
        {
            this.idSalida = _idSalida;
            this.FechaSalida = _FechaSalida;
            this.Usuarios_idUsuarios = _Usuario;
            this.Activo = _activo;
            this.Descripcion = _descripcion;
            this.Voluntarios_idVoluntarios = _voluntarios;
            this._errores = new List<Error>();
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
            ultimaSalida = new _Salida(Convert.ToInt32(_row["idSalida"]), Convert.ToDateTime(_row["FechaSalida"]), Convert.ToInt32(_row["Usuarios_idUsuarios"]), Convert.ToBoolean(_row["Activo"]), Convert.ToString(_row["Descripcion"]), Convert.ToInt32(_row["Voluntarios_idVoluntarios"]));

            return ultimaSalida.idSalida;
        }
    }
}
