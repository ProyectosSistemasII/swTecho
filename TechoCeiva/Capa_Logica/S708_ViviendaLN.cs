using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Capa_Datos;

namespace Capa_Logica
{
    public class S708_ViviendaLN : S708_Vivienda
    {
        public S708_ViviendaLN()
        {
            this.Encementado = 0;
            this.LadrilloBarro = 0;
            this.Madera = 0;
            this.Tierra = 0;
        }

        // seteo de variables
        public S708_ViviendaLN(int Encementado, int LadrilloBarro, int Madera, int Tierra)
        {
            this.Encementado = Encementado;
            this.LadrilloBarro = LadrilloBarro;
            this.Madera = Madera;
            this.Tierra = Tierra;
            this.errores = new List<Error>();
        }

        // insertar seccion 7 pregunta 8
        public Boolean Insertar_EncuS708()
        {
            Boolean correcto = true;
            if (errores.Count > 0)
            {
                return false;
            }
            else
            {
                S708_Vivienda ingresos = new S708_Vivienda(Encementado, LadrilloBarro, Madera, Tierra);
                ingresos.InsertarS708();
                this.errores = ingresos.errores;
                if (errores.Count > 0)
                {
                    correcto = false;
                }
                return correcto;
            }
        }

        public string obtenerError()
        {
            Error error = errores[0];
            return error.mensaje;
        }
    }
}
