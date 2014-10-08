using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MySql.Data.MySqlClient;
using System.Data;

namespace Capa_Datos
{
    public class _Herramientas
    {
        public int idHerramientas { get; set; }
        public String Nombre { get; set; }
        public int Existencia { get; set; }
        public Boolean Activo { get; set; }
        public List<Error> _errores { get; set; }

        private static ConexionBD _datos = new ConexionBD();
        private static MySqlConnection _conexion = ConexionBD.conexion;        

        public _Herramientas()
        {
            this.idHerramientas = 0;
            this.Nombre = "";
            this.Existencia = 0;
            this.Activo = true;
        }

        public _Herramientas(int _idHerramienta, String _nombre, int _existencia, Boolean _activo)
        {
            this.idHerramientas = _idHerramienta;
            this.Nombre = _nombre;
            this.Existencia = _existencia;
            this.Activo = _activo;
            this._errores = new List<Error>();
        }

        /// <summary>
        /// para --> Realizar inserción en tabla Herramientas
        /// 
        /// value --> no values
        /// 
        /// query --> INSERT INTO herramientas (Nombre, Existencia, Activo) VALUES (@Nombre, @Existencia, @Activo)
        /// </summary>
        
        public void _Insertar_H()
        {
            if (this._errores.Count == 0)
            {
                string query = "INSERT INTO herramientas (Nombre, Existencia, Activo) VALUES (@Nombre,@Existencia,@Activo)";
                MySqlCommand _comando = new MySqlCommand(query, ConexionBD.conexion);
                _comando.Parameters.AddWithValue("@Nombre", this.Nombre);
                _comando.Parameters.AddWithValue("@Existencia", this.Existencia);
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

 
        public List<_Herramientas> _Obtener_H()
        {
            string query = "Select * FROM Herramientas WHERE Activo = true";
            List<_Herramientas> _listHerramientas = new List<_Herramientas>();

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
                _Herramientas _herramientas = new _Herramientas(Convert.ToInt32(_row["idHerramientas"]), Convert.ToString(_row["Nombre"]), Convert.ToInt32(_row["Existencia"]), Convert.ToBoolean(_row["Activo"]));
                _listHerramientas.Add(_herramientas);
            }

            return _listHerramientas;
        }

        public Boolean _Eliminar(int _id)
        {
            string query = "UPDATE Herramientas SET Activo = false WHERE idHerramientas = " + _id;
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

        public void _Modificar(int _id, int valor)
        {
            if (this._errores.Count == 0)
            {
                string query = "UPDATE Herramientas SET Existencia = @Existencia WHERE idHerramientas = " + _id;
                MySqlCommand _comando = new MySqlCommand(query, _conexion);
                _comando.Parameters.AddWithValue("@Nomre", this.Nombre);
                _comando.Parameters.AddWithValue("@Existencia", valor);
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
    }
}
