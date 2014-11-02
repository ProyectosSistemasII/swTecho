using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Capa_Datos;

namespace Capa_Logica
{
    public class _SalidaLN : _Salida
    {
        public _SalidaLN()
        {
            this.idSalida = 0;
            this.FechaSalida =  DateTime.Today;
            this.Usuarios_idUsuarios = 0;
            this.Voluntarios_idVoluntarios = 0;
            this.Activo = 0;
            this.Descripcion = "";
            this._errores = new List<Error>();
        }

        public _SalidaLN(DateTime fechaSalida, int Usuario, int Activo, String descripcion, int idVoluntario)
        {
            this.FechaSalida = fechaSalida;
            this.Usuarios_idUsuarios = Usuario;
            this.Activo = Activo;
            this.Descripcion = descripcion;
            this.Voluntarios_idVoluntarios = idVoluntario;
            this._errores = new List<Error>();
        }

        public Boolean ingresarSalida()
        {
            Boolean correcto = true;
            _Salida nSalida = new _Salida(this.idSalida, this.Usuarios_idUsuarios, this.Voluntarios_idVoluntarios, this.FechaSalida, this.Descripcion, this.Activo);

            this.idSalida = nSalida.idSalida;
            this.Usuarios_idUsuarios = nSalida.Usuarios_idUsuarios;
            this.Voluntarios_idVoluntarios = nSalida.Voluntarios_idVoluntarios;
            this.FechaSalida = nSalida.FechaSalida;
            this.Descripcion = nSalida.Descripcion;
            this.Activo = nSalida.Activo;
            if (_errores.Count > 0)
                correcto = false;
            return correcto;
        }

        public string obtenerError()
        {
            Error error = _errores[0];
            return error.mensaje;
        }
    }
}
