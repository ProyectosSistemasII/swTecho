using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Capa_Datos;
using System.Collections;
using System.Collections.ObjectModel;


namespace Capa_Logica
{
    public class _InsumosLN : _Insumos
    {
        ArrayList detalleSalida = new ArrayList();
        public _InsumosLN()
        {
            this.idAlimentos = 0;
            this.Nombre = "";
            this.Existencia= 0;
            this.Rango = "";
            this.AnioCaducidad = 2014;
            this.Activo = true;
            this.Presentacion_idPresentacion = 1;
            this._errores = new List<Error>();
            
        }

        public _InsumosLN(String _nombre,int _existencia,String _rango,int _anio, int _id)
        {
            this.idAlimentos = 0;
            this.Nombre = _nombre;
            this.Existencia = _existencia;
            this.Rango= _rango;
            this.AnioCaducidad = _anio;
            this.Activo = true;
            this.Presentacion_idPresentacion = _id;
            this._errores = new List<Error>();
        }

        public _InsumosLN(int _idAlimentos,String _nombre, int _existencia, String _rango, int _anio, int _id)
        {
            this.idAlimentos = _idAlimentos;
            this.Nombre = _nombre;
            this.Existencia = _existencia;
            this.Rango = _rango;
            this.AnioCaducidad = _anio;
            this.Activo = true;
            this.Presentacion_idPresentacion = _id;
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

        public ObservableCollection<_InsumosLN> eliminarDeColeccion(ObservableCollection<_InsumosLN> colection)
        {
            int cont = 0;
            foreach (_InsumosLN insumos in colection)
            {
                if (insumos.idAlimentos.Equals(this.idAlimentos))
                {
                    colection.RemoveAt(cont);
                    break;
                }
                cont++;
            }
            return colection;
        }

        public void ingresarDetalle(int id, string Insumo, int cantidad, string rango, int año,Boolean activo, int idPresentacion)
        {
            string[] detalle;
            string _id = Convert.ToString(id);
            string _cantidad = Convert.ToString(cantidad);
            string _año = Convert.ToString(año);
            string _idPresentacion = Convert.ToString(idPresentacion);
            string _activo = Convert.ToString(activo);

            detalle = new string[] { _id, Insumo, _cantidad, rango, _año, _activo,_idPresentacion };
            detalleSalida.Add(detalle);
        }

        public Boolean buscarElemento(ObservableCollection<_InsumosLN> colection)
        {
            foreach (_InsumosLN valor in colection)
            {
                if (valor.idAlimentos.Equals(this.idAlimentos))
                    return true;
                else
                    return false;
            }
            return false;
        }

        public List<_Insumos> obtenerListado(ObservableCollection<_InsumosLN> listadoObjetos)
        {
            List<_Insumos> listado = new List<_Insumos>();

            foreach (_InsumosLN insumo in listadoObjetos)
            {
                listado.Add(insumo);
            }
            return listado;
        }
    }
}
