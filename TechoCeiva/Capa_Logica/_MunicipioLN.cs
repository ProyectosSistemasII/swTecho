using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Capa_Datos;

namespace Capa_Logica
{
    public class _MunicipioLN : _Municipio
    {

        public _MunicipioLN() 
        {
            this.idMunicipio = 0;
            this.nombre = "";
            this.idDepartamento = 0;

            this._errores = new List<Error>();
        }

        public Boolean Ingresar_M(string nombre, int idDepartamento) 
        {
            Boolean _correcto = true;
            _Municipio _municipio = new _Municipio(0, nombre, idDepartamento);

            this._errores = _municipio._errores;
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
