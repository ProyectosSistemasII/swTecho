using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Capa_Datos;

namespace Capa_Logica
{
    public class _PrestamosLN : _Prestamo
    {
        public _PrestamosLN()
        {
            this.iDPrestamo = 0;
            this.idUsuario = 0;
            this.idVoluntario = 0;
            this.fechaPrestamo = DateTime.Parse("YYYY/MM/DD");
            this.Observaciones = "";
            this.Activo = 0;
            this.fechaFinPrestamo = DateTime.Parse("YYYY/MM/DD");
            this._errores = new List<Error>();
        }

        public _PrestamosLN(int idUsuario, int idVoluntario, DateTime fechaPrestamo, String observaciones)
        {
            this.idUsuario = idUsuario;
            this.idVoluntario = idVoluntario;
            this.fechaPrestamo = fechaPrestamo;
            this.Observaciones = observaciones;
            this._errores = new List<Error>();
        }

        public Boolean ingresarPrestamo()
        {
            Boolean correcto = true;
            _Prestamo nPrestamo = new _Prestamo(this.iDPrestamo, this.idUsuario, this.idVoluntario, this.fechaPrestamo, this.Observaciones, this.Activo, this.fechaFinPrestamo);

            this.iDPrestamo = nPrestamo.iDPrestamo;
            this.idUsuario = nPrestamo.idUsuario;
            this.idVoluntario = nPrestamo.idVoluntario;
            this.fechaPrestamo = nPrestamo.fechaPrestamo;
            this.Observaciones = nPrestamo.Observaciones;
            this.Activo = nPrestamo.Activo;
            this.fechaFinPrestamo = nPrestamo.fechaFinPrestamo;

            if (_errores.Count > 0)
            {
                correcto = false;
            }

            return correcto;
        }

        public string obtenerError()
        {
            Error error = _errores[0];
            return error.mensaje;
        }
    }
}
