using Capa_Datos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Capa_Logica
{
    public class S9_PropiedadLN : S9_Propiedad
    {
        public S9_PropiedadLN()
        {
            this.idS9_Prop = 0;           
            this.Propio = "";
            this.Propietario = "";
            this.OtroPropietario = "";
            this.TipoPropiedad = "";
            this.OtroTipoPropiedad = "";
            this.PropietarioTerreno = "";
            this.TelefonoPropietarioTerreno = "";
            this.NSNR = "";
            this.OtraPropiedad = "";
            this.OtraPropiedadA = "";
            this.OtraPropiedadB = "";
            this.OtraPropiedadC = "";
            this.idEncuestas = 0;
        }
        public S9_PropiedadLN(String Propio, String Propietario, String OtroPropietario, String TipoPropiedad, String OtroTipoPropiedad, String PropietarioTerreno, String TelefonoPropietarioTerreno, String NSNR, String OtraPropiedad, String PropiedadA, String PropiedadB, String PropiedadC, int idEncuestas)
        {
           
            this.Propio = Propio;
            this.Propietario = Propietario;
            this.OtroPropietario = OtroPropietario;
            this.TipoPropiedad = TipoPropiedad;
            this.OtroTipoPropiedad = OtroTipoPropiedad;
            this.PropietarioTerreno = PropietarioTerreno;
            this.TelefonoPropietarioTerreno = TelefonoPropietarioTerreno;
            this.NSNR = NSNR;
            this.OtraPropiedad = OtraPropiedad;
            this.OtraPropiedadA = OtraPropiedadA;
            this.OtraPropiedadB = OtraPropiedadB;
            this.OtraPropiedadC = OtraPropiedadC;
            this.idEncuestas = idEncuestas;
            
        }
        public Boolean Insertar_EncS9() 
        {
            Boolean correcto = true;
            //verificar sintaxis de los datos y comprobar errores antes de ser enviado a la capa de datos
            this.verificarDatos();
            if (errores.Count > 0)
            {
                return false;
            }
            S9_Propiedad Propiedad = new S9_Propiedad(0, this.Propio, this.Propietario, this.OtroPropietario, this.TipoPropiedad, this.OtroTipoPropiedad, this.PropietarioTerreno, this.TelefonoPropietarioTerreno, this.NSNR, this.OtraPropiedad, this.OtraPropiedadA, this.OtraPropiedadB, this.OtraPropiedadC, idEncuestas);
            this.errores = Propiedad.errores;
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
            string expresion_Numero = @"^[0-9]{8,10}$";
            string expresion_TextoNSNR = @"^[a-zA-Z]{1,50}/|[a-zA-Z]+\s*[a-zA-Z]*$";
            Regex regex = new Regex(expresion_TextoNSNR);
            if (!regex.IsMatch(this.Propio))
            {
                Error error = new Error("Debe seleccionar datos de la pregunta 1", 2);
                errores.Add(error);
                goto fin;
            }
            regex = new Regex(expresion_TextoNSNR);
            if (!regex.IsMatch(this.Propietario))
            {
                Error error = new Error("Debe seleccionar datos de la pregunta 2", 2);
                errores.Add(error);
                goto fin;
            }
            regex = new Regex(expresion_TextoNSNR);
            if (!regex.IsMatch(this.TipoPropiedad))
            {
                Error error = new Error("Debe seleccionar datos de la pregunta 3", 2);
                errores.Add(error);
                goto fin;
            }
            regex = new Regex(expresion_Texto);
            if (!regex.IsMatch(this.OtroTipoPropiedad))
            {
                Error error = new Error("Debe ingresar datos de otro tipo de propiedad de la pregunta 3", 2);
                errores.Add(error);
                goto fin;
            }
            regex = new Regex(expresion_Texto);
            if (!regex.IsMatch(this.PropietarioTerreno))
            {
                Error error = new Error("Debe seleccionar datos de la pregunta 4", 2);
                errores.Add(error);
                goto fin;
            }
            regex = new Regex(expresion_Numero);
            if (!regex.IsMatch(this.TelefonoPropietarioTerreno))
            {
                Error error = new Error("Debe ingresar algunos comentarios finales", 2);
                errores.Add(error);
                goto fin;
            }
            regex = new Regex(expresion_TextoNSNR);
            if (!regex.IsMatch(this.OtraPropiedad))
            {
                Error error = new Error("Debe seleccionar datos de la pregunta 5", 2);
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
