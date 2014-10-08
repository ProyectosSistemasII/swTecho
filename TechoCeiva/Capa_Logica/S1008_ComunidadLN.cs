using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Capa_Datos;
using System.Text.RegularExpressions;

namespace Capa_Logica
{
    public class S1008_ComunidadLN: S1008_comunidad 
    {
        public S1008_ComunidadLN()
        {
            this.idS1008_Com = 0;
            this.Familiar = 0;
            this.Vecinos = 0;
            this.lideresComunitarios = 0;
            this.Policia = 0;
            this.Municipalidad = 0;
            this.OrganizacionGobierno = 0;
            this.Ejercito = 0;
            this.partidosPoliticos = 0;
            this.Techo = 0;
            this.MedioComunicacion = 0;
            this.IglesiasReligiosos = 0;
        }
        public S1008_ComunidadLN(int familiar, int vecinos, int liderescom, int policia, int municipalidad, int orgaGobierno, int ejercito, int partidopoliticos, int techo, int mediocomunicacion, int iglesias)
        {
            this.Familiar = familiar;
            this.Vecinos = vecinos;
            this.lideresComunitarios = liderescom;
            this.Policia = policia;
            this.Municipalidad = municipalidad;
            this.OrganizacionGobierno = orgaGobierno;
            this.Ejercito = ejercito;
            this.partidosPoliticos = partidopoliticos;
            this.Techo = techo;
            this.MedioComunicacion = mediocomunicacion;
            this.IglesiasReligiosos = iglesias;
            this.errores = new List<Error>();
        }
        public Boolean Insertar_EncuS1008()
        {
            Boolean correcto = true;
            //verificar sintaxis de los datos y comprobar errores antes de ser enviado a la capa de datos
            this.verificarDatos();
            if (errores.Count > 0)
            {
                return false;
            }
            // se ingresa los datos a la capa de datos            
            S1008_comunidad comunidad = new S1008_comunidad(0, this.Familiar, this.Vecinos, this.lideresComunitarios, this.Policia, this.Municipalidad, this.OrganizacionGobierno,this.Ejercito, this.partidosPoliticos, this.Techo, this.MedioComunicacion, this.IglesiasReligiosos);
            comunidad.InsertarS1008();
            this.errores = comunidad.errores;
            //Comprobar errores para la capa de datos
            if (errores.Count > 0)
            {
                return false;
            }
            else
            {
                this.idS1008_Com = comunidad.Obtener_Ultima_EncS1008();

            }
            return correcto;
        }
        public void verificarDatos()
        {
            if (this.Familiar == -1) 
            {
                Error error = new Error("Debe selecionar una opcion 'Familiar' de la pregunta 8", 5000, 8);
                errores.Add(error);
            }
            if (this.Vecinos == -1)
            {
                Error error = new Error("Debe selecionar una opcion 'Vecinos' de la pregunta 8", 5000, 8);
                errores.Add(error);
            }
            if (this.lideresComunitarios == -1)
            {
                Error error = new Error("Debe selecionar una opcion 'Lideres Comunitarios' de la pregunta 8", 5000, 8);
                errores.Add(error);
            }
            if (this.Policia == -1)
            {
                Error error = new Error("Debe selecionar una opcion 'Policia' de la pregunta 8", 5000, 8);
                errores.Add(error);
            }
            if (this.Municipalidad == -1)
            {
                Error error = new Error("Debe selecionar una opcion 'Municipalidad' de la pregunta 8", 5000, 8);
                errores.Add(error);
            }
            if (this.OrganizacionGobierno == -1)
            {
                Error error = new Error("Debe selecionar una opcion 'Organizacion Gobierno' de la pregunta 8", 5000, 8);
                errores.Add(error);
            }
            if (this.Ejercito == -1)
            {
                Error error = new Error("Debe selecionar una opcion 'Ejercito' de la pregunta 8", 5000, 8);
                errores.Add(error);
            }
            if (this.partidosPoliticos == -1)
            {
                Error error = new Error("Debe selecionar una opcion 'Partidos Politicos' de la pregunta 8", 5000, 8);
                errores.Add(error);
            }
            if (this.Techo == -1)
            {
                Error error = new Error("Debe selecionar una opcion 'Techo' de la pregunta 8", 5000, 8);
                errores.Add(error);
            }
            if (this.MedioComunicacion == -1)
            {
                Error error = new Error("Debe selecionar una opcion 'Medio Comunicacion' de la pregunta 8", 5000, 8);
                errores.Add(error);
            }
            if (this.IglesiasReligiosos == -1)
            {
                Error error = new Error("Debe selecionar una opcion 'Iglesias Religiosos' de la pregunta 8", 5000, 8);
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
