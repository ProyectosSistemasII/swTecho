using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Capa_Datos;

namespace Capa_Logica
{
    public class _DetalleSalidaLN : _DetalleSalida
    {
        public _DetalleSalidaLN()
        {
            this.idDetalleSalida = 0;
            this.Cantidad = 0;
            this.Alimentos_idAlimentos = 0;
            this.Activo = true;
            this.Salida_idSalida = 0;
        }

        public _DetalleSalidaLN(int idDetalle, int cantidad, int idAlimentos, Boolean activo, int idSalida)
        {
            this.idDetalleSalida = idDetalle;
            this.Cantidad = cantidad;
            this.Alimentos_idAlimentos = idAlimentos;
            this.Activo = activo;
            this.Salida_idSalida = idSalida;
        }
    }
}
