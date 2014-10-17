using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Capa_Logica
{
    class ValidarDatosUsuarios
    {
        public static String insertarUsuario(String username, String password, String passwordConfirm, int idTipoUsuario, int idVoluntario, string pregunta, string respuesta)
        {
            if (username == "")
                return "Debe ingresar un nombre de usuario";
            if (password == "")
                return "Debe ingresar una contaseña";
            if (passwordConfirm == "")
                return "Debe confirmar la contaseña";
            if (password != passwordConfirm)
                return "Las contaseñas no coninciden";
            if (password.Length < 6)
                return "La contraseña debe tener al menos 6 caracteres";
            if (idTipoUsuario == 0)
                return "Debe seleccionar un tipo de usuario";
            if (idVoluntario == 0)
                return "Debe seleccionar un voluntario";
            if (pregunta == "")
                return "Debes seleccionar una pregunta o ingresarla";
            if (respuesta == "")
                return "Debes ingresar una prespuesta a la pregunta secreta";
            DatosUsuario usuario = new DatosUsuario();
            return usuario.insertarUsuario(username, password, idTipoUsuario, idVoluntario,pregunta,respuesta);
        }
        public static String eliminarUsuario(string username)
        {
            DatosUsuario usuario = new DatosUsuario();
            return usuario.deshabilitarUsuario(username);
        }
    }
}
