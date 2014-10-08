using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using MySql.Data.MySqlClient;

namespace Capa_Datos
{
    public class _Comunidad
    {
        public int idComunidad { get; set;  }
        public string Nombre { get; set; }
        public Boolean Activo { get; set; }
        public int Departamento_idDepartamento { get; set; }
        public int Municipio_idMunicipio { get; set; }
        public string DepartamentoNombre { get; set; }
        public string MunicipioNombre { get; set; }
        public List<Error> errores { get; set; }
        private static ConexionBD datos = new ConexionBD();
        private static MySqlConnection conex = ConexionBD.conexion;

        public _Comunidad()
        {
            this.Nombre = "";
            this.Activo = false;
            this.Departamento_idDepartamento = 0;
            this.Municipio_idMunicipio = 0;
        }

        public _Comunidad(int idComunidad, string Nombre)
        {
            this.idComunidad = idComunidad;
            this.Nombre = Nombre;
            this.errores = new List<Error>();
        }

        public _Comunidad(int idComunidad, string Nombre,bool activo, int idDepartamento, int idMunicipio)
        {
            this.idComunidad = idComunidad;
            this.Nombre = Nombre;
            this.Activo = activo;
            this.Departamento_idDepartamento = idDepartamento;
            this.Municipio_idMunicipio = idMunicipio;
            this.errores = new List<Error>();
        }

        public _Comunidad(string Nombre, string Municipio, string Departamento)
        {
            this.Nombre = Nombre;
            this.DepartamentoNombre = Departamento;
            this.MunicipioNombre = Municipio;
        }

        public List<_Comunidad> ObtenerComunidades()
        {
            List<_Comunidad> ListaComunidad = new List<_Comunidad>();
            MySqlCommand comando = new MySqlCommand("SELECT Comunidad.Nombre, municipio.NombreM, departamento.NombreD FROM comunidad inner join Departamento on Departamento_idDepartamento = idDepartamento inner join Municipio  on Municipio_idMunicipio = idMunicipio where activo=true group by comunidad.Nombre", conex);
            comando.CommandTimeout = 12280;
            DataSet ds = new DataSet();
            MySqlDataAdapter Adapter = new MySqlDataAdapter();
            Adapter.SelectCommand = comando;
            Adapter.Fill(ds);
            DataTable tabla = new DataTable();
            tabla = ds.Tables[0];
            for (int i = 0; i < tabla.Rows.Count; i++)
            {
                DataRow row = tabla.Rows[i];
                _Comunidad Comunidades = new _Comunidad(Convert.ToString(row["Nombre"]), Convert.ToString(row["NombreM"]), Convert.ToString(row["NombreD"]));
                ListaComunidad.Add(Comunidades);
            }
            return ListaComunidad;
        }

        public List<_Comunidad> ObtenerComunidadesEncuesta()
        {
            List<_Comunidad> ListaComunidad = new List<_Comunidad>();
            MySqlCommand comando = new MySqlCommand("SELECT Comunidad.idComunidad, Comunidad.Nombre FROM comunidad where activo=true order by Comunidad.Nombre ASC", conex);
            comando.CommandTimeout = 12280;
            DataSet ds = new DataSet();
            MySqlDataAdapter Adapter = new MySqlDataAdapter();
            Adapter.SelectCommand = comando;
            Adapter.Fill(ds);
            DataTable tabla = new DataTable();
            tabla = ds.Tables[0];
            for (int i = 0; i < tabla.Rows.Count; i++)
            {
                DataRow row = tabla.Rows[i];
                _Comunidad Comunidades = new _Comunidad(Convert.ToInt32(row["idComunidad"]), Convert.ToString(row["Nombre"]));
                ListaComunidad.Add(Comunidades);
            }
            return ListaComunidad;
        }

        public void InsertarComunidad()
        {
            if (this.errores.Count == 0)
            {
                string consulta = "INSERT INTO comunidad(Nombre, Activo, Departamento_idDepartamento, Municipio_idMunicipio) VALUES(@Nombre,@Activo,@Departamento_idDepartamento,@Municipio_idMunicipio)"; 
                MySqlCommand comando = new MySqlCommand(consulta, conex);
                comando.Parameters.AddWithValue("@Nombre", this.Nombre);
                comando.Parameters.AddWithValue("@Activo", this.Activo);
                comando.Parameters.AddWithValue("@Departamento_idDepartamento", this.Departamento_idDepartamento);
                comando.Parameters.AddWithValue("@Municipio_idMunicipio", this.Municipio_idMunicipio);

                try
                {
                    comando.Connection.Open();
                    comando.ExecuteNonQuery();
                    comando.Connection.Close();
                }
                catch (MySqlException ex)
                {
                    Error error = new Error(ex.Message + "   " + ex.Number, 2);
                    errores.Add(error);
                }
            }
        }

        public void ModificarComunidad()
        {
            string consulta = ""; //= "update Comunidad set Nombre = @Nombre, Departamento_idDepartamento = @Departamento_idDepartamento, Municipio_idMunicipio = @Municipio_idMunicipio where idComunidad=@idComunidad)";
            MySqlCommand comando = new MySqlCommand(consulta, conex);
            comando.Parameters.AddWithValue("@idComunidad", this.idComunidad);
            comando.Parameters.AddWithValue("@Nombre", this.Nombre);
            comando.Parameters.AddWithValue("@Departamento_idDepartamento", this.Departamento_idDepartamento);
            comando.Parameters.AddWithValue("@Municipio_idMunicipio", this.Municipio_idMunicipio);

            try
            {
                comando.Connection.Open();
                comando.ExecuteNonQuery();
                comando.Connection.Close();
            }
            catch (MySqlException ex)
            {
                Error error = new Error(ex.Message + "   " + ex.Number, 2);
                errores.Add(error);
            }
        }

        public Boolean eliminarComunidad(string id)
        {
            MySqlCommand eliminar = new MySqlCommand("update Comunidad set Activo=false where idComunidad='" + id + "'", conex);

            eliminar.Connection.Open();
            eliminar.ExecuteNonQuery();
            eliminar.Connection.Close();
            return true;
        }
    }
}
