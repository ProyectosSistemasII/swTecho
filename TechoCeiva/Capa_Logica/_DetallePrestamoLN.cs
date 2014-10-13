using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Capa_Datos;

namespace Capa_Logica
{
    public class _DetallePrestamoLN: _DetallePrestamo
    {
        public _DetallePrestamoLN()
        {
            this.idDetallePrestamo = 0;
            this.Herramientas_idHerramientas = 0;
            this.Prestamo_idDetallePrestamo = 0;
            this.CantidadBuenEtsado = 0;
            this.CantidadMalEstado = 0;
            this.CantidadPerdida = 0;
            this.Activo = 0;
            this.Devolucion = DateTime.Parse("YYYY/MM/DD");
            this._errores = new List<Error>();
        }

        public _DetallePrestamoLN(int idHerramienta, int idDetalle, int activo)
        {
            this.Herramientas_idHerramientas = idHerramienta;
            this.Prestamo_idDetallePrestamo = idDetalle;
            this.Activo = activo;
            this._errores = new List<Error>();
        }
    }
}
