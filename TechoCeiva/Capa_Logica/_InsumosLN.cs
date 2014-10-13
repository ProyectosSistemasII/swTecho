using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Capa_Datos;

namespace Capa_Logica
{
    public class _InsumosLN : _Insumos
    {
        public _InsumosLN()
        {
            this.idAlimentos = 0;
            this.Nombre = "";
            this.Existencia= 0;
            this.Rango = "";
            this.AnioCaducidad = DateTime.Now;
            this.Activo = true;
            this.Presentacion_idPresentacion = 0;
            this._errores = new List<Error>();
            
        }

        public _InsumosLN(String _nombre)
        {
            this.idAlimentos = 0;
            this.Nombre = _nombre;
            this.Existencia = 0;
            this.Rango= "";
            this.AnioCaducidad = DateTime.Now;
            this.Activo = true;
            this.Presentacion_idPresentacion = 0;
            this._errores = new List<Error>();
        }

        public Boolean Ingresar_Insumo()
        {
            Boolean _correcto = true;
            _Insumos nInsumo = new _Insumos(this.idAlimentos,this.Nombre, this.Existencia, this.Rango, this.AnioCaducidad, this.Activo, this.Presentacion_idPresentacion);
            this.idAlimentos = nInsumo.idAlimentos;
            this.Nombre = nInsumo.Nombre;
            this.Existencia = nInsumo.Existencia;
            this.Rango = nInsumo.Rango;
            this.AnioCaducidad = nInsumo.AnioCaducidad;
            this.Activo = nInsumo.Activo;
            this.Presentacion_idPresentacion = nInsumo.Presentacion_idPresentacion;
            this._errores = nInsumo._errores;

            if (_errores.Count > 0)
            {
                _correcto = false;
            }

            return _correcto;
        }

        public void InsertarEn_BD()
        {
            this._Insertar_I();
        }
        public string _Obtener_Error()
        {
            Error error = _errores[0];
            return error.mensaje;
        }
    }
}
