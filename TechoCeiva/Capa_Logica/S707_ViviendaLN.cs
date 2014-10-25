using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Capa_Datos;

namespace Capa_Logica
{
    public class S707_ViviendaLN : S707_Vivienda
    {
        public S707_ViviendaLN()
        {
            this.BlockLadrilloPrefabr = 0;
            this.Madera = 0;
            this.Adobe = 0;
            this.Lamina = 0;
            this.BaharequeBambu = 0;
            this.Desechos = 0;
        }

        // seteo de variables
        public S707_ViviendaLN(int BlockLadrilloPrefarbr, int Madera, int Adobe, int Lamina, int BaharequeBambu, int Desechos)
        {
            this.BlockLadrilloPrefabr = BlockLadrilloPrefarbr;
            this.Madera = Madera;
            this.Adobe = Adobe;
            this.Lamina = Lamina;
            this.BaharequeBambu = BaharequeBambu;
            this.Desechos = Desechos;
            this.errores = new List<Error>();
        }

        // insertar seccion 7 pregunta 7
        public Boolean Insertar_EncuS707()
        {
            Boolean correcto = true;
            if (errores.Count > 0)
            {
                return false;
            }
            else
            {
                S707_Vivienda ingresos = new S707_Vivienda(BlockLadrilloPrefabr, Madera, Adobe, Lamina, BaharequeBambu, Desechos);
                ingresos.InsertarS707();
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
