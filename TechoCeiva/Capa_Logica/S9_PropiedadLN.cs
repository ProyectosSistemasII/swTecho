using Capa_Datos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Data;

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
            this.NSNR = false;
            this.OtraPropiedad = "";
            this.OtraPropiedadA = "";
            this.OtraPropiedadB = "";
            this.OtraPropiedadC = "";
            this.idEncuestas = 0;
        }
        public S9_PropiedadLN(String Propio, String Propietario, String OtroPropietario, String OtraPropiedad, String PropiedadA, String PropiedadB, String PropiedadC, int idEncuestas)
        {           
            this.Propio = Propio;
            this.Propietario = Propietario;
            this.OtroPropietario = OtroPropietario;
            this.OtraPropiedad = OtraPropiedad;
            this.OtraPropiedadA = PropiedadA;
            this.OtraPropiedadB = PropiedadB;
            this.OtraPropiedadC = PropiedadC;
            this.idEncuestas = idEncuestas;
            this.errores = new List<Error>();
            
        }
        
        public S9_PropiedadLN(String Propio, String TipoPropiedad, String OtroTipoPropiedad, String PropietarioTerreno, String TelefonoPropietarioTerreno, Boolean NSNR, String OtraPropiedad, String PropiedadA, String PropiedadB, String PropiedadC, int idEncuestas)
        {
            this.Propio = Propio;
            this.TipoPropiedad = TipoPropiedad;
            this.OtroTipoPropiedad = OtroTipoPropiedad;
            this.PropietarioTerreno = PropietarioTerreno;
            this.TelefonoPropietarioTerreno = TelefonoPropietarioTerreno;
            this.NSNR = NSNR;
            this.OtraPropiedad = OtraPropiedad;
            this.OtraPropiedadA = PropiedadA;
            this.OtraPropiedadB = PropiedadB;
            this.OtraPropiedadC = PropiedadC;
            this.idEncuestas = idEncuestas;
            this.errores = new List<Error>();

        }
        public Boolean Insertar_EncS9(int caso) 
        {
            Boolean correcto = true;

            //verificar sintaxis de los datos y comprobar errores antes de ser enviado a la capa de datos
            if (caso == 1)
                this.verificarDatosCaso0();
            else
                this.verificarDatosCaso1();

            if (errores.Count > 0)
            {
                return false;
            }
            // se ingresa los datos a la capa de datos
            S9_Propiedad Propiedad = new S9_Propiedad(0, this.Propio, this.Propietario, this.OtroPropietario, this.TipoPropiedad, this.OtroTipoPropiedad, this.PropietarioTerreno, this.TelefonoPropietarioTerreno, this.NSNR, this.OtraPropiedad, this.OtraPropiedadA, this.OtraPropiedadB, this.OtraPropiedadC, idEncuestas);
            Propiedad.InsertarS9();
            this.errores = Propiedad.errores;
            //Busca errores de la capa de datos
            if (errores.Count > 0)
            {
                correcto = false;
            }
            return correcto;
 
        
        }
        public void verificarDatosCaso0()
        {
            string expresion_Texto = @"^[a-zA-Z]+\s*[a-zA-Z]*$";
            string expresion_TextoNSNR = @"^[a-zA-Z]{1,50}/|([a-zA-Z]{1,50})|[a-zA-Z]+\s*[a-zA-Z]|/|[a-zA-Z]/*$";
            Regex regex = new Regex(expresion_TextoNSNR);
            if (!regex.IsMatch(this.Propio))
            {
                Error error = new Error("Debe seleccionar datos de la pregunta 1", 5000,1);
                errores.Add(error);
             //   goto fin;
            }
            regex = new Regex(expresion_TextoNSNR);
            if (!regex.IsMatch(this.Propietario))
            {
                Error error = new Error("Debe seleccionar datos de la pregunta 2", 5000, 2);
                errores.Add(error);
           //     goto fin;
            }
            regex = new Regex(expresion_TextoNSNR);
            if (!regex.IsMatch(this.OtroPropietario)&&this.Propietario=="Otra (especificar)" )
            {
                Error error = new Error("Debe ingresar datos de 'Otro Propietario' de la pregunta 2", 5000, 201);
                errores.Add(error);
                ///goto fin;
            }
            
            regex = new Regex(expresion_TextoNSNR);
            if (!regex.IsMatch(this.OtraPropiedad))
            {
                Error error = new Error("Debe seleccionar datos de la pregunta 5", 5000, 5);
                errores.Add(error);
              ///  goto fin;
            }
            regex = new Regex(expresion_Texto);
            if (!regex.IsMatch(this.OtraPropiedadA)&& this.OtraPropiedad=="Si")
            {
                Error error = new Error("Debe ingresar datos sobre las 'Otras Propiedades' de la pregunta 5", 5000, 501);
                errores.Add(error);
            //    goto fin;
            }
            
        //fin:
          //  return;
        }
        public void verificarDatosCaso1()
        {
            string expresion_Texto = @"^[a-zA-Z]+\s*[a-zA-Z]*$";
            string expresion_Numero = @"^[0-9]{8,10}$";
            string expresion_TextoNSNR = @"^[a-zA-Z]{1,50}/|([a-zA-Z]{1,50})|[a-zA-Z]+\s*[a-zA-Z]|/|[a-zA-Z]/*$";
            Regex regex = new Regex(expresion_TextoNSNR);
            if (!regex.IsMatch(this.Propio))
            {
                Error error = new Error("Debe seleccionar datos de la pregunta 1", 5000, 1);
                errores.Add(error);
                //goto fin;
            }
            regex = new Regex(expresion_TextoNSNR);
            if (!regex.IsMatch(this.TipoPropiedad))
            {
                Error error = new Error("Debe seleccionar datos de la pregunta 3", 5000, 3);
                errores.Add(error);
              //  goto fin;
            }
            regex = new Regex(expresion_Texto);
            if (!regex.IsMatch(this.OtroTipoPropiedad) && this.TipoPropiedad == "Otra (especificar)")
            {
                Error error = new Error("Debe ingresar datos de 'Otro tipo de propiedad' de la pregunta 3", 5000, 301);
                errores.Add(error);
            //    goto fin;
            }
            regex = new Regex(expresion_Texto);
            if (!regex.IsMatch(this.PropietarioTerreno) && this.NSNR == false)
            {
                Error error = new Error("Debe ingresar datos del 'Propietario terreno' de la pregunta 4", 5000, 4);
                errores.Add(error);
          //      goto fin;
            }
            regex = new Regex(expresion_Numero);
            if (!regex.IsMatch(this.TelefonoPropietarioTerreno) && this.NSNR == false)
            {
                Error error = new Error("El 'Telefono de propietario de terreno' debe ser de 8-10 digitos", 5000, 401);
                errores.Add(error);
        //        goto fin;
            }
            regex = new Regex(expresion_TextoNSNR);
            if (!regex.IsMatch(this.OtraPropiedad))
            {
                Error error = new Error("Debe seleccionar datos de la pregunta 5", 5000, 5);
                errores.Add(error);
      //          goto fin;
            }
            regex = new Regex(expresion_Texto);
            if (!regex.IsMatch(this.OtraPropiedadA) && this.OtraPropiedad == "Si")
            {
                Error error = new Error("Debe ingresar datos sobre las 'Otras Propiedades' de la pregunta 5", 5000, 501);
                errores.Add(error);
    //            goto fin;
            }
//        fin:
  //          return;
        }

        public Error obtenerError()
        {
            Error error = errores[0];
            return error;
        }
        public DataTable ObtnerReporte(int comunidad)
        {
            S9_Propiedad Propiedad = new S9_Propiedad();
            return Propiedad.GenerarReporte(comunidad);

        }
    }
}
