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
        public int buenEstado { get; set; }
        public int malEstado { get; set; }
        public int perdidas { get; set; }
        public Boolean Activo { get; set; }
        public List<Error> _errores { get; set; }

        /// <summary>
        /// variable utilizada para el método verificarExistencia()
        /// </summary>
        private static ConexionBD _datos = new ConexionBD();
        private static MySqlConnection _conexion = ConexionBD.conexion;        

        public _Herramientas()
        {
            this.idHerramientas = 0;
            this.Nombre = "";
            this.buenEstado = 0;
            this.malEstado = 0;
            this.perdidas = 0;
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
                    _comando.Connection.Close();
                    Error _error = new Error(ex.Message + " " + ex.Number, 2);
                    _errores.Add(_error);
                }
            }
        } 

        /// <summary>
        /// para --> Obtener listado de todas las herrameintas ingresadas
        /// 
        /// value --> No value
        /// 
        /// query --> "Select * FROM Herramientas WHERE Activo = true"
        /// </summary>
        /// <returns> _listaHerramientas </_Herramientas> </returns>        
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

        /// <summary>
        /// para --> Realiza eliminación "setea activo = false"
        /// 
        /// value --> id de la herramienta a eliminar
        /// 
        /// query --> "UPDATE Herramientas SET Activo = false WHERE idHerramientas = " + _id;
        /// </summary>
        /// <param name="_id"></param>
        /// <returns></returns>
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
                _comandoEliminar.Connection.Close();
                Error _error = new Error(ex.Message + " " + ex.Number, 2);
                _errores.Add(_error);
            }
            return true;
        }

        /// <summary>
        /// para --> Realizar UPDATE de la información modificada por el usuario
        /// 
        /// query --> "UPDATE Herramientas SET Existencia = @Existencia WHERE idHerramientas = " + _id;
        /// </summary>
        /// <param name="_id"></param>
        public void _Modificar(int _id)
        {
            if (this._errores.Count == 0)
            {
                string query = "UPDATE Herramientas SET Nombre = @Nombre, Existencia = @Existencia WHERE idHerramientas = " + _id;
                MySqlCommand _comando = new MySqlCommand(query, _conexion);
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
                    _comando.Connection.Close();
                    Error _error = new Error(ex.Message + " " + ex.Number, 2);
                    _errores.Add(_error);
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="cantidad"></param>
        /// <returns></returns>
        public Boolean verificarExistencia(int cantidad)
        {
            if (this.Existencia > cantidad)
                return true;
            else
                return false;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="valor"></param>
        /// <returns></returns>
        public int nuevaExistencia(int id, int valor)
        {
            string query = "Select * FROM Herramientas WHERE Activo = true AND idHerramientas = " + id;
            _Herramientas _tool;

            MySqlCommand _comando = new MySqlCommand(query, _conexion);
            _comando.CommandTimeout = 12280;
            DataSet _ds = new DataSet();
            MySqlDataAdapter _adapter = new MySqlDataAdapter();
            _adapter.SelectCommand = _comando;
            _adapter.Fill(_ds);
            DataTable _tabla = new DataTable();
            _tabla = _ds.Tables[0];

            DataRow _row = _tabla.Rows[0];
            _tool = new _Herramientas(Convert.ToInt32(_row["idHerramientas"]), Convert.ToString(_row["Nombre"]), Convert.ToInt32(_row["Existencia"]), Convert.ToBoolean(_row["Activo"]));

            return _tool.Existencia - valor;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="valor"></param>
        /// <returns></returns>
        public int cargarInventario(int id, int valor)
        {
            string query = "Select * FROM Herramientas WHERE Activo = true AND idHerramientas = " + id;
            _Herramientas _tool;

            MySqlCommand _comando = new MySqlCommand(query, _conexion);
            _comando.CommandTimeout = 12280;
            DataSet _ds = new DataSet();
            MySqlDataAdapter _adapter = new MySqlDataAdapter();
            _adapter.SelectCommand = _comando;
            _adapter.Fill(_ds);
            DataTable _tabla = new DataTable();
            _tabla = _ds.Tables[0];

            DataRow _row = _tabla.Rows[0];
            _tool = new _Herramientas(Convert.ToInt32(_row["idHerramientas"]), Convert.ToString(_row["Nombre"]), Convert.ToInt32(_row["Existencia"]), Convert.ToBoolean(_row["Activo"]));

            return _tool.Existencia + valor;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public Boolean verificarUso()
        {
            Boolean usada = true;
            string contar = "select count(*) from DetallePrestamo WHERE Activo = 1 " +
                                                                 "AND Herramientas_idHerramientas = " + this.idHerramientas;
            MySqlCommand comando = new MySqlCommand(contar, _conexion);
            comando.CommandTimeout = 12280;

            comando.Connection.Open();
            int cantidad = Convert.ToInt32(comando.ExecuteScalar());
            comando.Connection.Close();

            if (cantidad > 0)
                usada = true;
            else
                usada = false;
            return usada;
        }

        /// <summary>
        /// 
        /// </summary>
        public void eliminar()
        {
            string query = "UPDATE Herramientas SET Activo = false WHERE idHerramientas = " + this.idHerramientas;
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
        }
    }
}
