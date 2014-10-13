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
                    Error _error = new Error(ex.Message + " " + ex.Number, 2);
                    _errores.Add(_error);
                }
            }
        }
            
             public List<_Presentacion> _Obtener_P()
        {
            string query = "Select * FROM Presentacion WHERE Activo = true";
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

             /*public List<String> _Obtener_P()
             {
                 string query = "Select Nombre FROM Alimentos WHERE Activo = true";
                 List<String> presentacion = new List<String>();

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
                     String nombre = new String(Convert.ToString(_row["Nombre"]));
                     _listInsumos.Add(_insumos);
                 }

                 return _listInsumos;
             }*/
            
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
                Error _error = new Error(ex.Message + " " + ex.Number, 2);
                _errores.Add(_error);
            }

            return true;
        }
    
    }
}
