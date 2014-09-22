using Capa_Datos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Capa_Logica
{
    public class S11_MovilidadLN: S11_Movilidad
    {
        public S11_MovilidadLN()
        { 
            this.idS11_Mov = 0;
            this.CodigoS11 = 0;
            this.VidaFamiliar = "";
            this.DirecionPasada = "";
            this.AnioTranslado = "";
            this.ViviendaActual = "";
            this.ComentarioFinal = "";
            this.idEncuestas = 0;
            this.errores = new List<Error>();
                   
        }
        
        public Boolean Ingresar_EncS11(int Codigo11, String VidaFamiliar,String DireccionPasada, String AñoTraslado,String PorqueTraslado, String ViviendaActual, String Comentario, int idEncuesta)
        {
            Boolean correcto = true;
            S11_Movilidad Mobilidad = new S11_Movilidad(0, Codigo11, VidaFamiliar, DireccionPasada, AñoTraslado,PorqueTraslado, ViviendaActual, Comentario, idEncuesta);
            this.idS11_Mov = Mobilidad.idS11_Mov;
            this.CodigoS11 = Mobilidad.CodigoS11;
            this.VidaFamiliar = Mobilidad.VidaFamiliar;
            this.DirecionPasada = Mobilidad.DirecionPasada;
            this.AnioTranslado = Mobilidad.AnioTranslado;
            this.ViviendaActual = Mobilidad.ViviendaActual;
            this.ComentarioFinal = Mobilidad.ComentarioFinal;
            this.idEncuestas = Mobilidad.idEncuestas;
            this.errores = Mobilidad.errores;
            
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
