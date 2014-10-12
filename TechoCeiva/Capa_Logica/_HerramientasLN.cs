using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Capa_Datos;
using System.Collections;

namespace Capa_Logica
{
    public class _HerramientasLN : _Herramientas
    {
        ArrayList detallePrestamo = new ArrayList();

        public _HerramientasLN()
        {
            this.idHerramientas = 0;
            this.Nombre = "";
            this.Existencia = 0;
            this.Activo = true;
            this._errores = new List<Error>();
        }

        public _HerramientasLN(String nombre)
        {
            this.idHerramientas = 0;
            this.Nombre = nombre;
            this.Existencia = 0;
            this.Activo = true;
            this._errores = new List<Error>();
        }

        public Boolean Ingresar_Herramienta()
        {
            Boolean _correcto = true;
            _Herramientas nHerramienta = new _Herramientas(this.idHerramientas, this.Nombre, this.Existencia, this.Activo);

            this.idHerramientas = nHerramienta.idHerramientas;
            this.Nombre = nHerramienta.Nombre;
            this.Existencia = nHerramienta.Existencia;
            this.Activo = nHerramienta.Activo;
            this._errores = nHerramienta._errores;

            if (_errores.Count > 0)
            {
                _correcto = false;
            }
             
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

        public void ingresarDetalle(int id, string herramienta, int cantidad)
        {
            string[] detalle;
            string _id = Convert.ToString(id);
            string _cantidad = Convert.ToString(cantidad);

            detalle = new string[] {_id, herramienta, _cantidad};
            detallePrestamo.Add(detalle);
        }
    }
}