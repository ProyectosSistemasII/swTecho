using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Capa_Datos;


namespace Capa_Logica_Negocio
{
    public class UsuarioLN : Usuario
    {
        
        public UsuarioLN()
        {
            this.idUsuarios=0;
            this.idVoluntarios = 0;
            this.idTiposUsuarios = 0;
            this.username = "";
            this.password = "";
            this.activado = true;
            this.errores = new List<Error>();
        }

        public Boolean iniciarSesion(string username, string contraseña)
        {
           Boolean correcto = true;
            Usuario usuario = new Usuario(username,contraseña);
            this.idUsuarios = usuario.idUsuarios;
            this.idTiposUsuarios = usuario.idTiposUsuarios;
            this.idVoluntarios = usuario.idVoluntarios;
            this.username = username;
            this.password = contraseña;
            this.errores = usuario.errores;

           
            if (errores.Count > 0)
            {
                correcto = false;
            }
            return correcto;
        }

        public string obtenerError()
        {
            Error error = errores[0];
            return error.mensaje;
        }
    }
}
