using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MySql.Data.MySqlClient;
using System.Data;
namespace Capa_Datos
{
    public class _Voluntarios
    {
        public int idVoluntarios{get; set;}
        public string nombres{get; set;}
        public string apellidos{get; set;}
        public string telefono{get; set;}
        public string direccion{get; set;}
        public string correo{get; set;}
        public bool activo{get; set;}
        public string personaEmergencia{get; set;}
        public string telefonoEmergencia{get; set;}
        public int municipio{get; set; }
        public int departamento{ get; set; }

        public List<Error> _errores { get; set; }

        private static ConexionBD _datos = new ConexionBD();
        private static MySqlConnection _conexion = ConexionBD.conexion;

        public _Voluntarios()
        {
            this.idVoluntarios = 0;
            this.nombres = "";
            this.apellidos = "";
            this.telefono = "";
            this.direccion = "";
            this.correo = "";
            this.activo = true;
            this.personaEmergencia = "";
            this.telefonoEmergencia = "";
            this.municipio = 0;
            this.departamento = 0;
        }

        public _Voluntarios(int idVoluntarios, string nombres, string apellidos, string telefono, string direccion, string correo, bool activo, int municipio, int departamento, string personaEmergencia, string telefonoEmergencia)
        {
            this.idVoluntarios = idVoluntarios;
            this.nombres = nombres;
            this.apellidos = apellidos;
            this.telefono = telefono;
            this.direccion = direccion;
            this.correo = correo;
            this.activo = activo;
            this.personaEmergencia = personaEmergencia;
            this.telefonoEmergencia = telefonoEmergencia;
            this.municipio = municipio;
            this.departamento = departamento;
        }

        public void Insertar_V()
        {
            if (this._errores.Count == 0)
            {
                string query = "";
                MySqlCommand _comando = new MySqlCommand(query, _conexion);
                _comando.Parameters.AddWithValue("@Nombres", this.nombres);
                _comando.Parameters.AddWithValue("@Apellidos",this.apellidos);
                _comando.Parameters.AddWithValue("@Telefono",this.telefono);
                _comando.Parameters.AddWithValue("@Direccion", this.direccion);
                _comando.Parameters.AddWithValue("@Correo", this.correo);
                _comando.Parameters.AddWithValue("@Activo", this.activo);
                _comando.Parameters.AddWithValue("@Departamento_idDepartamento", this.departamento);
                _comando.Parameters.AddWithValue("@Municipio_idMunicipio",this.municipio);
                _comando.Parameters.AddWithValue("@PersonaEmergencia", this.personaEmergencia);
                _comando.Parameters.AddWithValue("@TelEmergencia",this.telefonoEmergencia);

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

        public List<_Voluntarios> Obtener_V()
        {
            List<_Voluntarios> Lista_V = new List<_Voluntarios>();
            MySqlCommand _comando = new MySqlCommand("SELECT * FROM VOLUNTARIOS WHERE Activo=true", _conexion);
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
                _Voluntarios _propiedad = new _Voluntarios(Convert.ToInt32(_row["idVoluntarios"]), Convert.ToString(_row["Nombres"]), Convert.ToString(_row["Apellidos"]), Convert.ToString(_row["Telefono"]), Convert.ToString(_row["Direccion"]), Convert.ToString(_row["Correo"]), Convert.ToBoolean(_row["Activo"]), Convert.ToInt32(_row["Departamento_idDepartamento"]), Convert.ToInt32(_row["Municipio_idMunicipio"]), Convert.ToString(_row["PersonaEmergencia"]), Convert.ToString(_row["TelEmergencia"]));
                Lista_V.Add(_propiedad);
            }
            return Lista_V;
        }

        public Boolean Eliminar_V(int id)
        {
            MySqlCommand _comando = new MySqlCommand("update  Voluntarios set Activo=false where idVoluntarios="+id, _conexion);

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

            return true;
        }

        public void Modificar_V(int id) 
        {
            string _query = "UPDATE Voluntarios where idVoluntarios="+id;
            MySqlCommand _comando = new MySqlCommand(_query, _conexion);
            _comando.Parameters.AddWithValue("@Nombres", this.nombres);
            _comando.Parameters.AddWithValue("@Apellidos", this.apellidos);
            _comando.Parameters.AddWithValue("@Telefono", this.telefono);
            _comando.Parameters.AddWithValue("@Direccion", this.direccion);
            _comando.Parameters.AddWithValue("@Correo", this.correo);
            _comando.Parameters.AddWithValue("@Activo", this.activo);
            _comando.Parameters.AddWithValue("@Departamento_idDepartamento", this.departamento);
            _comando.Parameters.AddWithValue("@Municipio_idMunicipio", this.municipio);
            _comando.Parameters.AddWithValue("@PersonaEmergencia", this.personaEmergencia);
            _comando.Parameters.AddWithValue("@TelEmergencia", this.telefonoEmergencia);

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
}
