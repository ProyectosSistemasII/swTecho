using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MySql.Data.MySqlClient;
using System.Data;

namespace Capa_Datos
{
    public class _Presentacion
    {
        public int idPresentacion { get; set; }
        public String Nombre { get; set; }
        public Boolean Activo { get; set; }
        public List<Error> _errores { get; set; }

        private static ConexionBD _datos = new ConexionBD();
        private static MySqlConnection _conexion = ConexionBD.conexion;


        public _Presentacion()
        {
            this.idPresentacion = 0;
            this.Nombre = "";
            this.Activo = true;
        }

        public _Presentacion(int _idPresentacion,String _nombre, Boolean _activo)
        {
            this.idPresentacion = _idPresentacion;
            this.Nombre = _nombre;
            this.Activo = _activo;
            this._errores = new List<Error>();
        }

        public void _Insertar_P()
        {
            if (this._errores.Count == 0)
            {
                string query = "INSERT INTO Presentacion (Nombre,Activo) VALUES (@Nombre,@Activo)";
                MySqlCommand _comando = new MySqlCommand(query, ConexionBD.conexion);
                _comando.Parameters.AddWithValue("@id", this.idPresentacion);
                _comando.Parameters.AddWithValue("@Nombre", this.Nombre);
                _comando.Parameters.AddWithValue("@Activo", this.Activo);

                try
                {
                    _comando.Connection.Open();
                    _comando.ExecuteNonQuery();
                    _comando.Connection.Close();

                }
                catch (MySqlException ex)
                {
                    _comando.Connection.Close();
                    Error _error = new Error(ex.Message + " " + ex.Number, 2);
                    _errores.Add(_error);
                }
            }
        }
            
             public List<_Presentacion> _Obtener_P()
        {
            string query = "Select * FROM Presentacion WHERE Activo = true Order By Nombre";
            List<_Presentacion> _listPresentacion = new List<_Presentacion>();

            MySqlCommand _comando = new MySqlCommand(query, _conexion);
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
                _Presentacion _presentacion = new _Presentacion(Convert.ToInt32(_row["idPresentacion"]),Convert.ToString(_row["Nombre"]), Convert.ToBoolean(_row["Activo"]));
                _listPresentacion.Add(_presentacion);
            }

            return _listPresentacion;
        }

                    
        public Boolean _Eliminar(int _id)
        {
            string query = "UPDATE Presentacion SET Activo = false WHERE idPresentacion = " + _id;
            MySqlCommand _comandoEliminar = new MySqlCommand(query, _conexion);

            try
            {
                _comandoEliminar.Connection.Open();
                _comandoEliminar.ExecuteNonQuery();
                _comandoEliminar.Connection.Close();
            }
            catch (MySqlException ex)
            {
                _comandoEliminar.Connection.Close();
                Error _error = new Error(ex.Message + " " + ex.Number, 2);
                _errores.Add(_error);
            }

            return true;
        }

        public int verificarPresentacion(String nombre)
        {
            MySqlCommand comando = new MySqlCommand("SELECT COUNT(idPresentacion) AS Contador, idPresentacion FROM Presentacion WHERE Nombre = @Presentacion", _conexion);
            comando.Parameters.AddWithValue("@Presentacion", this.Nombre);
            comando.CommandTimeout = 12280;
            
            int i = 0;
            int id = 0;
            DataSet ds = new DataSet();
            MySqlDataAdapter Adapter = new MySqlDataAdapter();
            Adapter.SelectCommand = comando;
            Adapter.Fill(ds);
            DataTable tabla = new DataTable();
            tabla = ds.Tables[0];
            DataRow row = tabla.Rows[0];
            i = Convert.ToInt32(row["Contador"]);
            if (i == 0)
            {
                return i;
            }
            else
            {
                id = Convert.ToInt32(row["idPresentacion"]);
                return id;
            }
        }

        public int devolver_ultimo()
        {
            try
            {
                MySqlCommand comando2 = new MySqlCommand("SELECT MAX(idPresentacion) AS Total From Presentacion", _conexion);
                comando2.CommandTimeout = 12280;

                int id;
                DataSet ds = new DataSet();
                MySqlDataAdapter Adapter = new MySqlDataAdapter();
                Adapter.SelectCommand = comando2;
                Adapter.Fill(ds);
                DataTable tabla = new DataTable();
                tabla = ds.Tables[0];
                DataRow row = tabla.Rows[0];
                id = Convert.ToInt32(row["total"]);
                return id;
            }
            catch (Exception ex)
            {
                return 0;
            }
        }

        public Boolean _ActualizarPresentacion(int _id, string _nombre)
        {
            string query = "UPDATE Presentacion SET Nombre = @Nombre WHERE idPresentacion = " + _id;
            MySqlCommand _comando = new MySqlCommand(query, _conexion);
            _comando.Parameters.AddWithValue("@Nombre", _nombre);


            try
            {
                _comando.Connection.Open();
                _comando.ExecuteNonQuery();
                _comando.Connection.Close();
            }
            catch (MySqlException ex)
            {
                _comando.Connection.Close();
                Error _error = new Error(ex.Message + " " + ex.Number, 2);
                _errores.Add(_error);
            }

            return true;
        }
    
    }
}
