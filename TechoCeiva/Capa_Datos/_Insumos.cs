using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MySql.Data.MySqlClient;
using System.Data;

namespace Capa_Datos
{
    public class _Insumos
    {
        public int idAlimentos { get; set; }
        public String Nombre { get; set; }
        public int Existencia { get; set; }
        public String Rango { get; set; }
        public int AnioCaducidad { get; set; }
        public Boolean Activo { get; set; }
        public int Presentacion_idPresentacion { get; set; }
        public List<Error> _errores { get; set; }

        private static ConexionBD _datos = new ConexionBD();
        private static MySqlConnection _conexion = ConexionBD.conexion;


        public _Insumos()
        {
            this.idAlimentos = 0;
            this.Nombre = "";
            this.Existencia = 0;
            this.Rango = "";
            this.AnioCaducidad = 2014;
            this.Activo = true;
            this.Presentacion_idPresentacion = 0;

        }

        public _Insumos(int _idAlimentos,String _nombre, int _existencia, String _rango, int _anioCaducidad, Boolean _activo, int _presentacion)
        {
            this.idAlimentos = _idAlimentos;
            this.Nombre = _nombre;
            this.Existencia = _existencia;
            this.Rango = _rango;
            this.AnioCaducidad = _anioCaducidad;
            this.Activo = _activo;
            this.Presentacion_idPresentacion = _presentacion;
            this._errores = new List<Error>();
        }

        public void _Insertar_I()
        {
            if (this._errores.Count == 0)
            {
                string query = "INSERT INTO Alimentos (idAlimentos,Nombre,Existencia,Rango,AnioCaducidad,Activo,Presentacion_idPresentacion) VALUES (@id,@Nombre,@Existencia,@Rango,@Anio,@Activo,@Presentacion_idPresentacion)";
                MySqlCommand _comando = new MySqlCommand(query, ConexionBD.conexion);
                _comando.Parameters.AddWithValue("@id", this.idAlimentos);
                _comando.Parameters.AddWithValue("@Nombre", this.Nombre);
                _comando.Parameters.AddWithValue("@Existencia", this.Existencia);
                _comando.Parameters.AddWithValue("@Rango", this.Rango);
                _comando.Parameters.AddWithValue("@Anio", this.AnioCaducidad);
                _comando.Parameters.AddWithValue("@Activo", this.Activo);
                _comando.Parameters.AddWithValue("@Presentacion_idPresentacion", this.Presentacion_idPresentacion);

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
            
             public List<_Insumos> _Obtener_I()
        {
            string query = "Select * FROM Alimentos WHERE Activo = true";
            List<_Insumos> _listInsumos = new List<_Insumos>();

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
                _Insumos _insumos = new _Insumos(Convert.ToInt32(_row["idAlimentos"]),Convert.ToString(_row["Nombre"]), Convert.ToInt32(_row["Existencia"]), Convert.ToString(_row["Rango"]), Convert.ToInt32(_row["AnioCaducidad"]), Convert.ToBoolean(_row["Activo"]), Convert.ToInt32(_row["Presentacion_idPresentacion"]));
                _listInsumos.Add(_insumos);
            }

            return _listInsumos;
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
            string query = "UPDATE Alimentos SET Activo = false WHERE idAlimentos = " + _id;
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

        public void _Modificar(int _id,int _cantidad)
        {
            if (this._errores.Count == 0)
            {
                string query = "UPDATE Alimentos SET Existencia = @Existencia WHERE idAlimentos = " + _id;
                MySqlCommand _comando = new MySqlCommand(query, _conexion);
                _comando.Parameters.AddWithValue("@idAlimentos", this.idAlimentos);
                _comando.Parameters.AddWithValue("@Nombre", this.Nombre);
                _comando.Parameters.AddWithValue("@Existencia", _cantidad);
                _comando.Parameters.AddWithValue("@Rango", this.Rango);
                _comando.Parameters.AddWithValue("@AnioCaducidad", this.AnioCaducidad);
                _comando.Parameters.AddWithValue("@Activo", this.Activo);
                _comando.Parameters.AddWithValue("@Presentacion_idPresentacion", this.Presentacion_idPresentacion);
              

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

        public Boolean verificarExistencia(int cantidad)
        {
            if (this.Existencia > cantidad)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public Boolean verificarduplicado(String nombre, string rango, int año, int presentacion)
        {
            return true;
        }

    }
}


