using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Capa_Datos;

namespace Capa_Logica
{
    public class _PresentacionLN : _Presentacion
    {
         public _PresentacionLN()
        {
            this.idPresentacion = 0;
            this.Nombre = "";
            this.Activo = true;
            this._errores = new List<Error>();
            
        }

        public _PresentacionLN(String _nombre)
        {
            this.idPresentacion = 0;
            this.Nombre = _nombre;
            this.Activo = true;
            this._errores = new List<Error>();
        }

        public Boolean Ingresar_Presentacion()
        {
            Boolean _correcto = true;
            _Presentacion nPresentacion = new _Presentacion(this.idPresentacion,this.Nombre,this.Activo);
            this.idPresentacion = nPresentacion.idPresentacion;
            this.Nombre = nPresentacion.Nombre;
            this.Activo = nPresentacion.Activo;
            this._errores = nPresentacion._errores;

            if (_errores.Count > 0)
            {
                _correcto = false;
            }

            return _correcto;
        }

        public Boolean Actualizar_Presentacion(int idPresentacion)
        {
            Boolean _correcto = true;
            _Presentacion nPresentacion = new _Presentacion(idPresentacion, this.Nombre, this.Activo);
            this.idPresentacion = idPresentacion;
            this.Nombre = nPresentacion.Nombre;
            this.Activo = nPresentacion.Activo;
            this._errores = nPresentacion._errores;

            if (_errores.Count > 0)
            {
                _correcto = false;
            }
            
            return _correcto;
        }

        public void InsertarEn_BD()
        {
            this._Insertar_P();
        }
        public string _Obtener_Error()
        {
            Error error = _errores[0];
            return error.mensaje;
        }
    }
}
