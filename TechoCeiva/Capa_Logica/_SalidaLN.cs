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
            this.FechaSalida =  DateTime.Parse("YYYY/MM/DD");
            this.Usuarios_idUsuarios = 0;
            this.Activo = true;
            this.Descripcion = "";
            this._errores = new List<Error>();

        }

        public _SalidaLN(DateTime fechaSalida, int Usuario, String descripcion)
        {
            this.FechaSalida = fechaSalida;
            this.Usuarios_idUsuarios = Usuario;
            this.Descripcion = descripcion;
            this._errores = new List<Error>();
        }

        public Boolean ingresarSalida()
        {
            Boolean correcto = true;
            _Salida nSalida = new _Salida(this.idSalida, this.FechaSalida, this.Usuarios_idUsuarios, this.Activo, this.Descripcion);
            this.idSalida = nSalida.idSalida;
            this.FechaSalida = nSalida.FechaSalida;
            this.Usuarios_idUsuarios = nSalida.Usuarios_idUsuarios;
            this.Activo = nSalida.Activo;
            this.Descripcion = nSalida.Descripcion;

            if (_errores.Count > 0)
            {
                correcto = false;
            }

            return correcto;
        }

        public string obtenerError()
        {
            Error error = _errores[0];
            return error.mensaje;
        }
    }
}
