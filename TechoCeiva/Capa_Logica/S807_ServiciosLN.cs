using Capa_Datos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Capa_Logica
{
    public class S807_ServiciosLN : S807_Servicios
    {
        public S807_ServiciosLN()
        {
            this.idS807_serv = 0;
            this.Ninguno = false;
            this.CableTV = false;
            this.TelefonoResid = false;
            this.Internet = false;
            this.NSNR = false;

        }
        public S807_ServiciosLN( Boolean Ninguno, Boolean Cable, Boolean Telefono, Boolean Internet, Boolean NSNR)
        {
            this.CableTV = Cable;
            this.Ninguno = Ninguno;
            this.TelefonoResid = Telefono;
            this.Internet = Internet;
            this.NSNR = NSNR;
            this.errores = new List<Error>();
        }
        public Boolean Insertar_EncuS807()
        {
            Boolean correcto = true;
            //verificar sintaxis de los datos y comprobar errores antes de ser enviado a la capa de datos
            this.verificarDatos();
            if (errores.Count > 0)
            {
                return false;
            }
            // se ingresa los datos a la capa de datos            
            S807_Servicios servicios = new S807_Servicios(0, this.Ninguno, this.CableTV, this.TelefonoResid, this.Internet, this.NSNR);
            servicios.InsertarS807();
            this.errores = servicios.errores;
            //Comprobar errores para la capa de datos
            if (errores.Count > 0)
            {
                return  false;
            }
            else
            {
                this.idS807_serv = servicios.Obtener_Ultima_EncS807();
            
            }
            return correcto;
        }

        public void verificarDatos()
        {
            if (this.Ninguno == false && this.CableTV == false && this.TelefonoResid == false && this.TelefonoResid == false && this.NSNR == false)
            {
                Error error = new Error("Debe marcar la opcio 'No cuenta con ningun otros' o NS/RN en la pregunta 7", 5000, 1);
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
