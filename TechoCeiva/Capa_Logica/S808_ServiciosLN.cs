using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Capa_Datos;
using System.Text.RegularExpressions;

namespace Capa_Logica
{
    public class S808_ServiciosLN : S808_Servicios
    {
        public S808_ServiciosLN() 
        {
            this.idS808_Serv = 0;
            this.Refrigerador = 0;
            this.EquipoSonido = 0;
            this.Televisor = 0;
            this.DVD = 0;
            this.Motocicleta = 0;
            this.Automovil = 0;
            this.Computadora = 0;
            this.Amueblado = 0;
            this.Otros = 0;
            this.Especificar = "";
        }
        public S808_ServiciosLN(int refrigerador, int EquipoSonido, int Televisor, int DVD, int Motocicleta, int Automovil, int computadora, int amueblado,int Otros, String Especificar ) 
        {
            this.Refrigerador = refrigerador;
            this.EquipoSonido = EquipoSonido;
            this.Televisor = Televisor;
            this.DVD = DVD;
            this.Motocicleta = Motocicleta;
            this.Automovil = Automovil;
            this.Computadora = computadora;
            this.Amueblado = amueblado;
            this.Otros = Otros;
            this.Especificar = Especificar;
            this.errores = new List<Error>();
        }
        public Boolean Insertar_EncuS808()
        {
            Boolean correcto = true;
            //verificar sintaxis de los datos y comprobar errores antes de ser enviado a la capa de datos
            this.verificarDatos();
            if (errores.Count > 0)
            {
                return false;
            }
            // se ingresa los datos a la capa de datos            
            S808_Servicios servicios = new S808_Servicios(0,this.Refrigerador, this.EquipoSonido, this.Televisor, this.DVD, this.Motocicleta, this.Automovil, this.Computadora, this.Amueblado, this.Otros, this.Especificar);
            servicios.InsertarS808();
            this.errores = servicios.errores;
            ///this.idS808_Serv = servicios.Obtener_Ultima_EncS808();
            //Comprobar errores para la capa de datos
            if (errores.Count > 0)
            {
                return false;
            }
            else
            {
                this.idS808_Serv = servicios.Obtener_Ultima_EncS808();

            }
            return correcto;
        }

        public void verificarDatos()
        {
            string expresion_Texto = @"^[a-zA-Z]+\s*[a-zA-Z]*$";
            Regex regex = new Regex(expresion_Texto);
            if (!regex.IsMatch(this.Especificar) && this.Otros != 0)
            {
                Error error = new Error("Debe Especificar el articulo que no se encuenta en la lista", 5000, 9);
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
