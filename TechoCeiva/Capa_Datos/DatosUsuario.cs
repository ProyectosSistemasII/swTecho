using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using MySql.Data;
using MySql.Data.MySqlClient;

namespace Capa_Datos
{
    public class DatosUsuario
    {
        public String userName {get; set;}
        public String nombresVoluntario {get; set;}
        public String apellidosVoluntario { get; set; }
        public String tipoUsuario { get; set; }

        //Metodo que devuelve una lista con los usuarios en el sistema
        public ArrayList getUsuarios()
        {
            ArrayList usuarios = new ArrayList();
            try
            {
                MySqlConnection conexion = new MySqlConnection(ConexionBD.ConexionDireccion);
                MySqlCommand comando = new MySqlCommand(
                   "Select Usuarios.UserName,Voluntarios.Nombres, Voluntarios.Apellidos,TipoUsuarios.NombreTipo from Usuarios" +
                   "inner join Voluntarios on Voluntarios.idVoluntarios=Usuarios.Voluntarios_idVoluntarios" +
                   "inner join TipoUsuarios on TipoUsuarios.idTipoUsuarios=Usuarios.TipoUsuarios_idTipoUsuarios where Usuarios.Activo=true;", conexion);
                conexion.Open();
                MySqlDataReader datos = comando.ExecuteReader();
                conexion.Close();
                while (datos.Read())
                {
                    DatosUsuario tmp = new DatosUsuario();
                    tmp.userName = datos["UserName"].ToString();
                    tmp.nombresVoluntario = datos["UserName"].ToString();
                    tmp.apellidosVoluntario = datos["UserName"].ToString();
                    tmp.tipoUsuario = datos["UserName"].ToString();
                    usuarios.Add(tmp);
                }
            }
            catch (MySqlException ex)
            {
                usuarios.Add(ex.Message);
            }
            return usuarios;
        }
    }
}
