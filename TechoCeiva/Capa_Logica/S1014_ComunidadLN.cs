using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using Capa_Datos;

namespace Capa_Logica
{
    public class S1014_ComunidadLN : S1014_Comunidad
    {
        public S1014_ComunidadLN()
        {
            this.idS1014_com = 0;
            this.Niños = false;
            this.jovenes = false;
            this.Mujeres = false;
            this.TerceraEdad = false;
            this.Discapacitados = false;
            this.GruposEtnicos = false;
            this.NoGruposVulnerables = false;
            this.Otros = false;
            this.Especificar = "";
            this.NSNR = false;

        }
        public S1014_ComunidadLN(Boolean Niño, Boolean jovenes, Boolean mujeres,Boolean terceraedad, Boolean discapacitados, Boolean gruposetnicos, Boolean nogruposVulnerables, Boolean otros, String especificar, Boolean NSNR)
        {
            this.Niños = Niño;
            this.jovenes = jovenes;
            this.Mujeres = mujeres;
            this.TerceraEdad = terceraedad;
            this.Discapacitados = discapacitados;
            this.GruposEtnicos = gruposetnicos;
            this.NoGruposVulnerables = nogruposVulnerables;
            this.Otros = otros;
            this.Especificar = especificar;
            this.NSNR = NSNR;
            this.errores = new List<Error>();

        }
        public Boolean Insertar_EncuS1014()
        {
            Boolean correcto = true;
            //verificar sintaxis de los datos y comprobar errores antes de ser enviado a la capa de datos
            this.verificarDatos();
            if (errores.Count > 0)
            {
                return false;
            }
            // se ingresa los datos a la capa de datos            
            S1014_Comunidad comunidad = new S1014_Comunidad(0, this.Niños, this.jovenes, this.Mujeres, this.TerceraEdad,this.Discapacitados, this.GruposEtnicos, this.NoGruposVulnerables, this.Otros, this.Especificar, this.NSNR);
            comunidad.InsertarS1014();
            this.errores = comunidad.errores;
            //Comprobar errores para la capa de datos
            if (errores.Count > 0)
            {
                return false;
            }
            else
            {
                this.idS1014_com = comunidad.Obtener_Ultima_EncS1014();

            }
            return correcto;
        }

        public void verificarDatos()
        {
            if (this.Niños == false && this.jovenes == false && this.Mujeres == false && this.TerceraEdad == false && this.Discapacitados == false && this.GruposEtnicos == false && this.NoGruposVulnerables == false  && this.Otros == false && this.NSNR == false)
            {
                Error error = new Error("Debe marcar la opcion  'NS/RN' de no responder en la pregunta 14", 5000, 14);
                errores.Add(error);
            }
            string expresion_Texto = @"^[a-zA-Z]+\s*[a-zA-Z]*$";
            Regex regex = new Regex(expresion_Texto);
            if (!regex.IsMatch(this.Especificar) && this.Otros == true)
            {
                Error error = new Error("Debe Especificar 'El grupo mas afectado' de la pregunta 14", 5000, 1401);
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
