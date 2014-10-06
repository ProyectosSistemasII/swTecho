using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Capa_Datos;

namespace Capa_Logica
{
    public class _ComunidadLN:_Comunidad
    {
        public _ComunidadLN() 
        {
            this.idComunidad = 0;
            this.Nombre = "";
            this.Departamento_idDepartamento = 0;
            this.Municipio_idMunicipio = 0;
            this.errores = new List<Error>();
        }

        public Boolean Ingresar_C(string nombre, int municipio, int departamento)
        {
            Boolean _correcto = true;
            _Comunidad _comunidad = new _Comunidad(0, nombre, municipio, departamento);
            this.idComunidad = _comunidad.idComunidad;
            this.Nombre = _comunidad.Nombre;
            this.Departamento_idDepartamento = _comunidad..Departamento_idDepartamento;
            this.Municipio_idMunicipio = _comunidad.Municipio_idMunicipio;

            this.errores = _comunidad.errores;

            if (errores.Count > 0)
            {
                _correcto = false;
            }
            return _correcto;
        }

        public string _obtenerError()
        {
            Error error = errores[0];
            return error.mensaje;
        }

    }
}
