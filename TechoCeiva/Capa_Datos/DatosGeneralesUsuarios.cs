﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MySql.Data.MySqlClient;

namespace Capa_Datos
{
    //
    //Este archivo contiene varias clases que sirven para cargar los datos para el UC de usuarios
    //

    ///
    ///
    /// 
    /// 
    ///
    //La clase establece paramentros y metodos que sirven para cargar datos de los usuarios
    public class DatosVoluntario
    {
        public int idVoluntario { get; set; }
        public string nombres { get; set; }
        public string apellidos { get; set; }
        public string nombresApellidos { get; set; }

        //metodo que devuelve una lista con los datos basicos de voluntarios
        public List<DatosVoluntario> getVoluntarios()
        {
            List<DatosVoluntario> usuarios = new List<DatosVoluntario>();
            try
            {
                MySqlConnection conexion = new MySqlConnection(ConexionBD.ConexionDireccion);
                MySqlCommand comando = new MySqlCommand("select idVoluntarios,Nombres,Apellidos from Voluntarios where Activo=true;", conexion);
                conexion.Open();
                MySqlDataReader datos = comando.ExecuteReader();
                while (datos.Read())
                {
                    DatosVoluntario tmp = new DatosVoluntario();
                    tmp.idVoluntario = Convert.ToInt16(datos["idVoluntarios"]);
                    tmp.nombres = datos["Nombres"].ToString();
                    tmp.apellidos = datos["Apellidos"].ToString();
                    tmp.nombresApellidos = datos["Nombres"].ToString() + " " + datos["Apellidos"].ToString();
                    usuarios.Add(tmp);
                }
            }
            catch
            {
                return null;
            }
            return usuarios;
        }
    }
    ///
    /// 
    /// 
    /// 
    ///
    //clase que establece parametros y proporciona metodos que sirven para el manejo de los datos de usuarios
    public class DatosUsuario
    {
        public String userName { get; set; }
        public String nombresVoluntario { get; set; }
        public String apellidosVoluntario { get; set; }
        public String tipoUsuario { get; set; }
        //public String pregunta { get; set; }
        //public String respuesta { get; set; }

        //Metodo que devuelve una lista con los usuarios en el sistema
        public List<DatosUsuario> getUsuarios()
        {
            List<DatosUsuario> usuarios = new List<DatosUsuario>();
            try
            {
                MySqlConnection conexion = new MySqlConnection(ConexionBD.ConexionDireccion);
                MySqlCommand comando = new MySqlCommand(
                   "Select Usuarios.UserName,Voluntarios.Nombres, Voluntarios.Apellidos,TipoUsuarios.NombreTipo from Usuarios " +
                   "inner join Voluntarios on Voluntarios.idVoluntarios=Usuarios.Voluntarios_idVoluntarios " +
                   "inner join TipoUsuarios on TipoUsuarios.idTipoUsuarios=Usuarios.TipoUsuarios_idTipoUsuarios where Usuarios.Activo=true;", conexion);
                conexion.Open();
                MySqlDataReader datos = comando.ExecuteReader();
                while (datos.Read())
                {
                    DatosUsuario tmp = new DatosUsuario();
                    tmp.userName = datos["UserName"].ToString();
                    tmp.nombresVoluntario = datos["Nombres"].ToString();
                    tmp.apellidosVoluntario = datos["Apellidos"].ToString();
                    tmp.tipoUsuario = datos["NombreTipo"].ToString();
                    usuarios.Add(tmp);
                }
            }
            catch
            {
                return null;
            }
            return usuarios;
        }

        //metodo que determina si existe un usuario con un determinado nombre
        public bool buscarUsuario(String usuario)
        {
            try
            {
                MySqlConnection conexion = new MySqlConnection(ConexionBD.ConexionDireccion);
                MySqlCommand comando = new MySqlCommand("select COUNT(*)  from Usuarios where UserName=@usuario and Activo=true", conexion);
                comando.Parameters.AddWithValue("@usuario", usuario);
                conexion.Open();
                int numero = Convert.ToInt16(comando.ExecuteScalar());
                conexion.Close();
                if (numero > 0)
                    return true;
            }
            catch
            {
                return true;
            }
            return false;
        }

        //metodo que determina si un voluntario tiene un usuario existente
        public bool buscarVoluntario(int idVoluntario)
        {
            try
            {
                MySqlConnection conexion = new MySqlConnection(ConexionBD.ConexionDireccion);
                MySqlCommand comando = new MySqlCommand("select count(*) from Usuarios where Voluntarios_idVoluntarios=@id and Activo=true", conexion);
                comando.Parameters.AddWithValue("@id", idVoluntario);
                conexion.Open();
                int numero = Convert.ToInt16(comando.ExecuteScalar());
                conexion.Close();
                if (numero > 0)
                    return true;
            }
            catch
            {
                return true;
            }
            return false;
        }

        //metodo que inserta un registro de usuarios
        public string insertarUsuario(string userName, string password, int idTipoUsuario, int idVoluntario, string pregunta, string respuesta)
        {
            try
            {
                if (buscarUsuario(userName))
                    return "El nombre de usuario ya fue ingresado";
                if (buscarVoluntario(idVoluntario))
                    return "El voluntario ya tiene un usuario";
                MySqlConnection conexion = new MySqlConnection(ConexionBD.ConexionDireccion);
                MySqlCommand comando = new MySqlCommand("INSERT INTO Usuarios (Username, Password,TipoUsuarios_idTipoUsuarios,Voluntarios_idVoluntarios,Activo,PreguntaSecreta,Respuesta)VALUES (@userName,SHA2(@password,512),@idTipo,@idVoluntario,true,@pregunta,@respuesta);", conexion);
                comando.Parameters.AddWithValue("@userName", userName);
                comando.Parameters.AddWithValue("@password", password);
                comando.Parameters.AddWithValue("@idTipo", idTipoUsuario);
                comando.Parameters.AddWithValue("@idVoluntario", idVoluntario);
                comando.Parameters.AddWithValue("@pregunta", pregunta);
                comando.Parameters.AddWithValue("@respuesta", respuesta);
                conexion.Open();
                comando.ExecuteNonQuery();
                conexion.Close();
            }
            catch (MySqlException ex)
            {
                return ex.Message;
            }
            return "Registro agregado";
        }

        //Metodo que dehabilida los usuarios
        public string deshabilitarUsuario(string username)
        {
            try
            {
                MySqlConnection conexion = new MySqlConnection(ConexionBD.ConexionDireccion);
                MySqlCommand comando = new MySqlCommand("update Usuarios set Activo=false where UserName=@username;", conexion);
                comando.Parameters.AddWithValue("@username", username);
                conexion.Open();
                comando.ExecuteNonQuery();
                conexion.Close();
            }
            catch (MySqlException ex)
            {
                return ex.Message;
            }
            return "Registro eliminado";
        }
    }

    ///
    ///
    /// 
    /// 
    ///
    //Clase que establece datos y metodos para el manejo de los tipos de usuarios
    public class DatosTipoUsuario 
    {
        public int idTipoUsuarios { get; set; }
        public String nombreTipo { get; set; }
        public String permisos { get; set; }
        private List<String> listaPermisos { get; set; }

        //Metodo que devuelve una lista con los tipos de usuarios en el sistema
        public List<DatosTipoUsuario> getTipoUsuarios()
        {
            List<DatosTipoUsuario> tipos = new List<DatosTipoUsuario>();
            try
            {
                MySqlConnection conexion = new MySqlConnection(ConexionBD.ConexionDireccion);
                MySqlCommand comando = new MySqlCommand("select idTipoUsuarios,NombreTipo from TipoUsuarios where Activo=true;", conexion);
                conexion.Open();
                MySqlDataReader datos = comando.ExecuteReader();
                while (datos.Read())
                {
                    DatosTipoUsuario tmp = new DatosTipoUsuario();
                    tmp.idTipoUsuarios = Convert.ToInt16(datos["idTipoUsuarios"]);
                    tmp.nombreTipo = datos["NombreTipo"].ToString();
                    tipos.Add(tmp);
                }
            }
            catch
            {
                return null;
            }
            return tipos;
        }

        //Metodo que devuelve una lista con los tipos de usuarios en el sistema
        public List<DatosTipoUsuario> listaTiposUsuarios()
        {
            List<DatosTipoUsuario> tipos = new List<DatosTipoUsuario>();
            try
            {
                MySqlConnection conexion = new MySqlConnection(ConexionBD.ConexionDireccion);
                MySqlCommand comando = new MySqlCommand("select idTipoUsuarios,NombreTipo from TipoUsuarios where Activo=true;", conexion);
                conexion.Open();
                MySqlDataReader datos = comando.ExecuteReader();
                while (datos.Read())
                {
                    DatosTipoUsuario tmp = new DatosTipoUsuario();
                    tmp.idTipoUsuarios = Convert.ToInt16(datos["idTipoUsuarios"]);
                    tmp.nombreTipo = datos["NombreTipo"].ToString();

                    //MySqlCommand cmd = new MySqlCommand("select Permisos.Nombre from Permisos_has_TipoUsuarios inner join Permisos on Permisos.idPermisos =Permisos_has_TipoUsuarios.Permisos_idPermisos  where TipoUsuarios_idTipoUsuarios=idTipo;", conexion);
                    //cmd.Parameters.AddWithValue("@idTipo",tmp.idTipoUsuarios);
                    //conexion.Open();
                    //MySqlDataReader datosTmp = comando.ExecuteReader();
                    //List<String> permisosTmp= new List<String>();
                    //while (datosTmp.Read())
                    //    permisosTmp.Add(datos["Nombre"].ToString());
                    //String cadenaPermisos="";
                    //for (int i = 0; i < permisosTmp.Count; i++)
                    //    cadenaPermisos += permisosTmp[i] + " ";
                    //tmp.listaPermisos = permisosTmp;
                    //tmp.permisos = cadenaPermisos;

                    tipos.Add(tmp);
                }
            }
            catch
            {
                return null;
            }
            return tipos;
        }
    }

}
