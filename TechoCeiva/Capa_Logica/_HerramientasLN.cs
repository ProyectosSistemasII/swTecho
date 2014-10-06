using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Capa_Datos;

namespace Capa_Logica
{
    public class _HerramientasLN : _Herramientas
    {
        public _HerramientasLN()
        {
            this.idHerramientas = 0;
            this.Nombre = "";
            this.Existencia = 0;
            this.Activo = true;
            this._errores = new List<Error>();
        }

        public Boolean Ingresar_Herramienta(string _nombre, int _existencia, Boolean _activo)
        {
            Boolean _correcto = true;
            _Herramientas nHerramienta = new _Herramientas(1, _nombre, _existencia, _activo);

            this.idHerramientas = nHerramienta.idHerramientas;
            this.Nombre = nHerramienta.Nombre;
            this.Existencia = nHerramienta.Existencia;
            this.Activo = nHerramienta.Activo;
            //this._errores = nHerramienta._errores;

            /*
            this._errores = new List<Error>();
            if (_errores.Count > 0)
            {
                _correcto = false;
            }*/
             
            return _correcto;
        }

        public void InsertarEn_DB()
        {
            this._Insertar_H();
        }

        public string _Obtener_Error()
        {
            Error error = _errores[0];
            return error.mensaje;
        }
    }
}