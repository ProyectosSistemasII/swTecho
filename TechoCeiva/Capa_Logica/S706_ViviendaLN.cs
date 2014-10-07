using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Capa_Datos;

namespace Capa_Logica
{
    public class S706_ViviendaLN : S706_Vivienda
    {
        /// <summary>
        /// Valores de los int segun seleccion
        /// 1 = muy malo, 2 = malo, 3 = bueno, 4 = muy bueno
        /// </summary>
         public S706_ViviendaLN()
        {
            this.Concreto = 0;
            this.TejaBarro = 0;
            this.Lamina = 0;
            this.TejaDuralita = 0;
            this.Paja = 0;
            this.Desechos = 0;
         }

        public S706_ViviendaLN(int Concreto, int TejaBarro, int Lamina, int TejaDuralita, int Paja, int Desechos)
        {
            this.Concreto = Concreto;
            this.TejaBarro = TejaBarro;
            this.Lamina = Lamina;
            this.TejaDuralita = TejaDuralita;
            this.Paja = Paja;
            this.Desechos = Desechos;
            this.errores = new List<Error>();
        }

        public Boolean Insertar_EncuS706()
        {
            Boolean correcto = true;
            S706_Vivienda ingresos = new S706_Vivienda(Concreto, TejaBarro, Lamina, TejaDuralita, Paja, Desechos);
            ingresos.InsertarS706();
            this.errores = ingresos.errores;
            if (errores.Count > 0)
            {
                correcto = false;
            }
            return correcto;
        }

        public string obtenerError()
        {
            Error error = errores[0];
            return error.mensaje;
        }
    }
}
