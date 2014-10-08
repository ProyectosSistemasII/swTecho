using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Capa_Datos;
using System.Text.RegularExpressions;

namespace Capa_Logica
{
    public class S1007_ComunidadLN: S1007_Comunidad
    {
        public S1007_ComunidadLN()
        {
            this.idS1007_com = 0;
            this.NoInteresa = false;
            this.FaltaInformacion = false;
            this.FaltaTiempo = false;
            this.CompromisoFamiliar = false;
            this.Otros = false;
            this.Especificar = "";
            this.NSNR = false;
        }
        public S1007_ComunidadLN(Boolean nointeresa, Boolean faltainformacion, Boolean faltatiempo, Boolean compromisofamiliar, Boolean otros, String especificar, Boolean NSNR )
        {
            
            this.NoInteresa = nointeresa;
            this.FaltaInformacion = faltainformacion;
            this.FaltaTiempo = faltatiempo;
            this.CompromisoFamiliar = compromisofamiliar;
            this.Otros = otros;
            this.Especificar = especificar;
            this.NSNR = NSNR;
            this.errores = new List<Error>();
        }
        public Boolean Insertar_EncuS1007()
        {
            Boolean correcto = true;
            //verificar sintaxis de los datos y comprobar errores antes de ser enviado a la capa de datos
            this.verificarDatos();
            if (errores.Count > 0)
            {
                return false;
            }
            // se ingresa los datos a la capa de datos            
            S1007_Comunidad comunidad = new S1007_Comunidad(0, this.NoInteresa, this.FaltaInformacion, this.FaltaTiempo, this.CompromisoFamiliar, this.Otros, this.Especificar,  this.NSNR);
            comunidad.InsertarS1007();
            this.errores = comunidad.errores;
            //Comprobar errores para la capa de datos
            if (errores.Count > 0)
            {
                return false;
            }
            else
            {
                this.idS1007_com = comunidad.Obtener_Ultima_EncS1007();

            }
            return correcto;
        }

        public void verificarDatos()
        {
            if (this.NoInteresa == false && this.FaltaInformacion == false && this.FaltaTiempo == false && this.CompromisoFamiliar == false  && this.Otros == false && this.NSNR == false)
            {
                Error error = new Error("Debe marcar la opcio  'NS/RN' de no responder en la pregunta 7", 5000, 7);
                errores.Add(error);
            }
            string expresion_Texto = @"^[a-zA-Z]+\s*[a-zA-Z]*$";
            Regex regex = new Regex(expresion_Texto);
            if (!regex.IsMatch(this.Especificar) && this.Otros == true)
            {
                Error error = new Error("Debe Especificar 'Por que razon no participa'  en la pregunta 7", 5000, 701);
                errores.Add(error);
            }
        }

        public Error obtenerError()
        {
            Error error = errores[0];
            return error;
        }

    }
}
