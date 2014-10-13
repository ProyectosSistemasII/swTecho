using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Capa_Datos;
using System.Collections;
using System.Collections.ObjectModel;

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

        public _HerramientasLN(String nombre, int existencia)
        {
            this.idHerramientas = 0;
            this.Nombre = nombre;
            this.Existencia = existencia;
            this.Activo = true;
            this._errores = new List<Error>();
        }

        /// <summary>
        /// Constructor utilizado para el préstamo de las herramientas.
        /// 
        /// Se requiere para la lista que se utiliza para manejar los detalles que se
        /// muestran el el grid al Prestar una Herrameinta.
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="herramienta"></param>
        /// <param name="cantidad_a_Prestar"></param>

        public _HerramientasLN(int id, String herramienta, int cantidad_a_Prestar)
        {
            this.idHerramientas = id;
            this.Nombre = herramienta;
            this.Existencia = cantidad_a_Prestar;
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

        public Boolean buscarElemento(ObservableCollection<_HerramientasLN> colection)
        {
            foreach (_HerramientasLN valor in colection)
            {
                if (valor.idHerramientas.Equals(this.idHerramientas))
                    return true;
                else
                    return false;
            }
            return false;
        }

        public ObservableCollection<_HerramientasLN> eliminarDeColeccion(ObservableCollection<_HerramientasLN> colection)
        {
            int cont = 0;
            foreach (_HerramientasLN herramienta in colection)
            {
                if (herramienta.idHerramientas.Equals(this.idHerramientas))
                {
                    colection.RemoveAt(cont);
                    break;
                }
                cont++;
            }
            return colection;
        }

        public void guardarElementos(ObservableCollection<_HerramientasLN> listado, int idPrestamo)
        {
            List<_Herramientas> nuevoListado = new List<_Herramientas>();
            foreach (_HerramientasLN herramienta in listado)
            {
                nuevoListado.Add(herramienta);
            }
        }
    }
}