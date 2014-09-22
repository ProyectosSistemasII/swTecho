using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Capa_Datos;

namespace Capa_Logica
{
    public class _DepartamentoLN : _Departamento
    {
        public _DepartamentoLN() 
        {
            this.idDepartamento = 0;
            this.nombre = "";
            this._errores = new List<Error>();
        }

        public Boolean Ingresar_D(string nombre) 
        {
            Boolean _correcto = true;
            _Departamento _departamento = new _Departamento(0, nombre);

            this.nombre = _departamento.nombre;

            this._errores = _departamento._errores;
            if (_errores.Count > 0)
            {
                _correcto = false;
            }
            return _correcto;
        }

        public string _obtenerError()
        {
            Error error = _errores[0];
            return error.mensaje;
        }
    }
}
