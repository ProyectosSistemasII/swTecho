using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MySql.Data.MySqlClient;
using System.Data;


namespace Capa_Datos
{
    public class _Departamento
    {
        public int idDepartamento { get; set; }
        public string nombre { get; set; }

        public List<Error> _errores { get; set; }

        private static ConexionBD _datos = new ConexionBD();
        private static MySqlConnection _conexion = ConexionBD.conexion;


        public _Departamento()
        {
            this.idDepartamento = 0;
            this.nombre = "";
        }

        public _Departamento(int idDepartamento, string nombre)
        {
            this.idDepartamento = idDepartamento;
            this.nombre = nombre;
        }

        public void Insertar_D()
        {
            if (this._errores.Count == 0)
            {
                string query = "";
                MySqlCommand _comando = new MySqlCommand(query, _conexion);
                _comando.Parameters.AddWithValue("@Nombre", this.nombre);
                
                try
                {
                    _comando.Connection.Open();
                    _comando.ExecuteNonQuery();
                    _comando.Connection.Close();
                }
                catch (MySqlException ex)
                {
                    Error _error = new Error(ex.Message + "" + ex.Number, 2);
                    _errores.Add(_error);
                }
            }
        }

        public List<_Departamento> Obtener_D()
        {
            List<_Departamento> Lista_D = new List<_Departamento>();
            MySqlCommand _comando = new MySqlCommand("SELECT * FROM Departamento", _conexion);
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
                _Departamento _propiedad = new _Departamento(Convert.ToInt32(_row["idDepartamento"]), Convert.ToString(_row["Nombre"]));
                Lista_D.Add(_propiedad);
            }
            return Lista_D;
        }

    }
}
