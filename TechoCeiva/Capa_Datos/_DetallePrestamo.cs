using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Capa_Datos
{
    public class _DetallePrestamo
    {
        public int idDetallePrestamo { get; set; }
        public int Herramientas_idHerramientas { get; set; }
        public int Prestamo_idDetallePrestamo { get; set; }
        public int CantidadBuenEtsado { get; set; }
        public int CantidadMalEstado { get; set; }
        public int CantidadPerdida { get; set; }
        public int Activo { get; set; }
        public DateTime Devolucion { get; set; }
    }
}
