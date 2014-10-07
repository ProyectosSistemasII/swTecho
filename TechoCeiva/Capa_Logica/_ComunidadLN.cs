using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Capa_Datos;

namespace Capa_Logica
{
    public class _ComunidadLN : _Comunidad
    {
        public _ComunidadLN() 
        {
            this.idComunidad = 0;
            this.Nombre = "";
            this.Activo = true;
            this.Departamento_idDepartamento = 0;
            this.Municipio_idMunicipio = 0;

            this.errores = new List<Error>();
        }

        public _ComunidadLN(String Nombre, bool Activo, int Departamento_idDepartamento, int Municipio_idMunicipio)
        {
            this.Nombre = Nombre;
            this.Activo = Activo;
            this.Departamento_idDepartamento = Departamento_idDepartamento;
            this.Municipio_idMunicipio = Municipio_idMunicipio;
            
            this.errores = new List<Error>();
            
        }

        public Boolean Ingresar_C()
        {
            Boolean _correcto = true;
            _Comunidad _comunidad = new _Comunidad(0, this.Nombre,this.Activo,this.Departamento_idDepartamento,this.Municipio_idMunicipio);
            this.idComunidad = _comunidad.idComunidad;
            this.Nombre = _comunidad.Nombre;
            this.Activo = _comunidad.Activo;
            this.Departamento_idDepartamento = _comunidad.Departamento_idDepartamento;
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
