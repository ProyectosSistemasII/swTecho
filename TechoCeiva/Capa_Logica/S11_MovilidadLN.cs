using Capa_Datos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Capa_Logica
{
    public class S11_MovilidadLN: S11_Movilidad
    {
        public S11_MovilidadLN()
        { 
            this.idS11_Mov = 0;
            this.VidaFamiliar = "";
            this.DireccionPasada = "";
            this.AnioTranslado = "";
            this.ViviendaActual = "";
            this.ComentarioFinal = "";
            this.idEncuestas = 0;
            this.errores = new List<Error>();
                   
        }
        
        public S11_MovilidadLN( String VidaFamiliar,String DireccionPasada, String AñoTraslado,String PorqueTraslado, String ViviendaActual, String Comentario, int idEncuesta)
        {   
            this.VidaFamiliar = VidaFamiliar;
            this.DireccionPasada = DireccionPasada;
            this.AnioTranslado = AñoTraslado;
            this.PorqueTraslado = PorqueTraslado;
            this.ViviendaActual = ViviendaActual;
            this.ComentarioFinal = Comentario;
            this.idEncuestas = idEncuestas;
            this.errores = new List<Error>();
            
        }
        public Boolean Ingresar_S11() {
            Boolean correcto = true;
            //verificar sintaxis de los datos y comprobar errores antes de ser enviado a la capa de datos
            this.verificarDatos();
            if (errores.Count > 0)
            {
                return false;
            }
            S11_Movilidad Mobilidad = new S11_Movilidad(0, this.VidaFamiliar, this.DireccionPasada, this.AnioTranslado, this.PorqueTraslado, ViviendaActual, this.ComentarioFinal, this.idEncuestas);
            this.errores = Mobilidad.errores;
            //Busca errores de la capa de datos
            if (errores.Count > 0)
            {
                correcto = false;
            }
            return correcto;
            
        }

        public void verificarDatos()
        {
            string expresion_Texto = @"^[a-zA-Z]+\s*[a-zA-Z]*$";
            string expresion_TextoNumero = @"^[a-zA-Z0-9]|[0-9a-zA-Z]+\s*[a-zA-Z0-9]*$";
            string expresion_Año = @"^[0-9]{4}$";
            string expresion_TextoNSNR = @"^[a-zA-Z]{1,50}/|[a-zA-Z]+\s*[a-zA-Z]*$";
            Regex regex = new Regex(expresion_TextoNSNR);
            if (!regex.IsMatch(this.VidaFamiliar))
            {
                Error error = new Error("Debe seleccionar datos de la pregunta 1", 2);
                errores.Add(error);
                goto fin;
            }
            regex = new Regex(expresion_TextoNumero);
            if (!regex.IsMatch(this.DireccionPasada))
            {
                Error error = new Error("Debe ingresar datos de la pregunta 2", 2);
                errores.Add(error);
                goto fin;
            }
            regex = new Regex(expresion_Año);
            if (!regex.IsMatch(this.AnioTranslado))
            {
                Error error = new Error("Debe ingresar datos de año en formato 'AAAA'", 2);
                errores.Add(error);
                goto fin;
            }
            regex = new Regex(expresion_Texto);
            if (!regex.IsMatch(this.PorqueTraslado))
            {
                Error error = new Error("Debe ingresar datos de la pregunta 3", 2);
                errores.Add(error);
                goto fin;
            }
            regex = new Regex(expresion_TextoNSNR);
            if (!regex.IsMatch(this.ViviendaActual))
            {
                Error error = new Error("Debe seleccionar datos de la pregunta 4", 2);
                errores.Add(error);
                goto fin;
            }
            regex = new Regex(expresion_TextoNumero);
            if (!regex.IsMatch(this.ViviendaActual))
            {
                Error error = new Error("Debe ingresar algunos comentarios finales", 2);
                errores.Add(error);
                goto fin;
            }
        fin:
            return;
        }

        public string obtenerError()
        {
            Error error = errores[0];
            return error.mensaje;
        }
    }
}
