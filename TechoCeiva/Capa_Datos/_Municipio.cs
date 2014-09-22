using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MySql.Data.MySqlClient;
using System.Data;

namespace Capa_Datos
{
    public class _Municipio
    {
        public int idMunicipio{get; set;}
        public string nombre { get; set; }
        public int idDepartamento { get; set; }

        public List<Error> _errores { get; set; }

        private static ConexionBD _datos = new ConexionBD();
        private static MySqlConnection _conexion = ConexionBD.conexion;

        public _Municipio() 
        {
            this.idMunicipio = 0;
            this.nombre = "";
            this.idDepartamento = 0;
        }

        public _Municipio(int idMunicipio, string nombre, int idDepartamento) 
        {
            this.idMunicipio = idMunicipio;
            this.nombre = nombre;
            this.idDepartamento = idDepartamento;
        }

        public List<_Municipio> Obtener_M(int idDepartamento)
        {
            List<_Municipio> Lista_M = new List<_Municipio>();
            MySqlCommand _comando = new MySqlCommand("SELECT municipio.Nombre FROM municipio where municipio.Departamento_idDepartamento="+idDepartamento, _conexion);
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
                _Municipio _propiedad = new _Municipio(Convert.ToInt32(_row["idMunicipio"]), Convert.ToString(_row["Nombre"]), Convert.ToInt32(_row["Departamento_idDepartamento"]));
                Lista_M.Add(_propiedad);
            }
            return Lista_M;
        }
    }
}
