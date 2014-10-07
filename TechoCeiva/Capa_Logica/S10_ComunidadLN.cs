using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Capa_Datos;
using System.Text.RegularExpressions;
namespace Capa_Logica
{
    public class S10_ComunidadLN : S10_Comunidad
    {
        S10_Comunidad NuevaComS10 = null;
        public S10_ComunidadLN()
        {
            this.idS10_Com = 0;
            this.Ayudo = "";
            this.AyudaVecinos = "";
            this.RelacionVecinos = "";
            this.ComentarioRelacion = "";
            this.OrganizarVecinos = "";
            this.OrganizarA = "";
            this.OrganizarB="";
            this.OrganizarC ="";
            this.ParticipacionGrupo ="";
            this.Necesidad = "";
            this.NecesidadA = "";
            this.NecesidadB = "";
            this.NecesidadC = "";
            this.NecesidadCom = "";
            this.NecesidadComA = "";
            this.NecesidadComB = "";
            this.NecesidadComC = "";
            this.ProyectosVecinos = "";
            this.ProyectoA = "";
            this.ProyectoB = "";
            this.ProyectoC = "";
            this.AspectoPositivo = false;
            this.AspectoPositivoA = "";
            this.AspectoPositivoB = "";           
            this.AspectoNegativo = false;
            this.AspectoNegativoA = "";
            this.AspectoNegativoB = "";           
            this.Discriminacion = "";
            this.TipoDiscriminacion = "";
            this.OrganizacionComunitaria = "";
            this.TipoOrganizacion = "";
            this.ConfianzaOrganizacion = "";
            this.ComentarioConfianza = "";
            this.Lider = false;
            this.LiderA = "";
            this.LiderB = "";
            this.LiderC = "";
            this.EstadoComunidadPasada = "";
            this.ComentarioEstadoPasado = "";
            this.EstadoComunidadFuturo = "";
            this.ComentarioEstadoFuturo = "";
            this.idEncuestas = 0;
            this.idS1006 = 0;
            this.idS1007 = 0;
            this.idS1008 = 0;
            this.idS1014 = 0; 
        }
        public S10_ComunidadLN( String Ayudo,String AyudaVecinos, String RelacionVecinos, 
        String ComentarioRelacion, String OrganizarVecinos, String OrganizarA, String OrganizarB, String OrganizarC,
        String ParticipacionGrupo, String Necesidad, String NecesidadA, String NecesidadB, String NecesidadC,
        String NecesidadCom, String NecesidadComA, String NecesidadComB, String NecesidadComC, String ProyectosVecinos,
        String ProyectoA, String ProyectoB, String ProyectoC, int idEncuestas, int idS1006, int idS1007, int idS1008)
            
        {
            this.Ayudo = Ayudo;
            this.AyudaVecinos = AyudaVecinos;
            this.RelacionVecinos = RelacionVecinos;
            this.ComentarioRelacion = ComentarioRelacion;
            this.OrganizarVecinos = OrganizarVecinos;
            this.OrganizarA = OrganizarA;
            this.OrganizarB = OrganizarB;
            this.OrganizarC = OrganizarC;
            this.ParticipacionGrupo = ParticipacionGrupo;
            this.Necesidad = Necesidad;
            this.NecesidadA = NecesidadA;
            this.NecesidadB = NecesidadB;
            this.NecesidadC = NecesidadC;
            this.NecesidadCom = NecesidadCom;
            this.NecesidadComA = NecesidadComA;
            this.NecesidadComB = NecesidadComB;
            this.NecesidadComC = NecesidadComC;
            this.ProyectosVecinos = ProyectosVecinos;
            this.ProyectoA = ProyectoA;
            this.ProyectoB = ProyectoB;
            this.ProyectoC = ProyectoC;
            this.idS1006 = idS1006;
            this.idS1007 = idS1007;
            this.idS1008 = idS1008;
            this.idEncuestas = idEncuestas;
            this.errores = new List<Error>();
        }
    
        public void S10_ComunidadLNCont(Boolean AspectoPositivo, String AspectoPositivoA,
        String AspectoPositivoB, Boolean AspectoNegativo, String AspectoNegativoA,
        String AspectoNegativoB, String Discriminacion, String TipoDiscriminacion,String OrganizacionComunitaria,
        String TipoOrganizacion, String ConfianzaOrganizacion, String ComentarioConfianza, Boolean Lider,
        String LiderA, String LiderB, String LiderC, String EstadoComunidadPasada, String ComentarioEstadoPasado,
        String EstadoComunidadFuturo, String ComentarioEstadoFuturo,  int idS1014)
        {
            
            this.AspectoPositivo = AspectoPositivo;
            this.AspectoPositivoA = AspectoPositivoA;
            this.AspectoPositivoB = AspectoPositivoB;
           
            this.AspectoNegativo = AspectoNegativo;
            this.AspectoNegativoA = AspectoNegativoA;
            this.AspectoNegativoB = AspectoNegativoB;
            
            this.Discriminacion = Discriminacion;
            this.TipoDiscriminacion = TipoDiscriminacion;
            this.OrganizacionComunitaria = OrganizacionComunitaria;
            this.TipoOrganizacion = TipoOrganizacion;
            this.ConfianzaOrganizacion = ConfianzaOrganizacion;
            this.ComentarioConfianza = ComentarioConfianza;
            this.Lider = Lider;
            this.LiderA = LiderA;
            this.LiderB = LiderB;
            this.LiderC = LiderC;
            this.EstadoComunidadPasada = EstadoComunidadPasada;
            this.ComentarioEstadoPasado = ComentarioEstadoPasado;
            this.EstadoComunidadFuturo = EstadoComunidadFuturo;
            this.ComentarioEstadoFuturo = ComentarioEstadoFuturo;
            this.idS1014 = idS1014;
            this.errores = new List<Error>();
        }
        public Boolean Insertar_EncuS10()
        {
            Boolean correcto = true;
            //verificar sintaxis de los datos y comprobar errores antes de ser enviado a la capa de datos
           this.verificarDatos();
            if (errores.Count > 0)
            {
                return false;
            }
            // se ingresa los datos a la capa de datos            
            NuevaComS10 = new S10_Comunidad(0, this.Ayudo, this.AyudaVecinos, this.RelacionVecinos, this.ComentarioRelacion, this.OrganizarVecinos, this.OrganizarA, this.OrganizarB, this.OrganizarC, this.ParticipacionGrupo, this.Necesidad, this.NecesidadA, this.NecesidadB, this.NecesidadC, this.NecesidadCom, this.NecesidadComA, this.NecesidadComB, this.NecesidadComC, this.ProyectosVecinos, this.ProyectoA, this.ProyectoB, this.ProyectoC,  this.idEncuestas, this.idS1006, this.idS1007, this.idS1008);
            this.errores = NuevaComS10.errores;

            //Comprobar errores para la capa de datos
            if (errores.Count > 0)
            {
                correcto = false;
            }
            return correcto;
        }
        public Boolean Insertar_EncuS10Cont()
        {
            Boolean correcto = true;
            //verificar sintaxis de los datos y comprobar errores antes de ser enviado a la capa de datos
           this.verificarDatosContS10();
            if (errores.Count > 0)
            {
                return false;
            }
            // se ingresa los datos a la capa de datos            
            NuevaComS10.S10_ComunidadCOnt( this.AspectoPositivo, this.AspectoPositivoA, this.AspectoPositivoB, this.AspectoNegativo, this.AspectoNegativoA, this.AspectoNegativoB,  this.Discriminacion, this.TipoDiscriminacion, this.OrganizacionComunitaria, this.TipoOrganizacion, this.ConfianzaOrganizacion, this.ComentarioConfianza, this.Lider,this.LiderA, this.LiderB, this.LiderC, this.EstadoComunidadPasada, this.ComentarioEstadoPasado, this.EstadoComunidadFuturo, this.ComentarioEstadoFuturo, this.idS1014);
            NuevaComS10.InsertarS10();
            this.errores = NuevaComS10.errores;

            //Comprobar errores para la capa de datos
            if (errores.Count > 0)
            {
                correcto = false;
            }
            return correcto;
        }
        public void verificarDatos()
        {
            string expresion_Texto = @"^[a-zA-Z]+\s*[a-zA-Z]*$";
            string expresion_TextoNSNR = @"^[a-zA-Z]{1,50}/|([a-zA-Z]{1,50})|[a-zA-Z]+\s*[a-zA-Z]|/|[a-zA-Z]/*$";
            Regex regex = new Regex(expresion_TextoNSNR);
            if (!regex.IsMatch(this.Ayudo))
            {
                Error error = new Error("Debe seleccionar datos de la pregunta 1", 5000, 1);
                errores.Add(error);
            }
            regex = new Regex(expresion_TextoNSNR);
            if (!regex.IsMatch(this.AyudaVecinos))
            {
                Error error = new Error("Debe seleccionar datos de la pregunta 2", 5000, 2);
                errores.Add(error);
            }
            regex = new Regex(expresion_TextoNSNR);
            if (!regex.IsMatch(this.RelacionVecinos))
            {
                Error error = new Error("Debe seleccionar datos de la pregunta 3", 5000, 3);
                errores.Add(error);
            }
            regex = new Regex(expresion_Texto);
            if (!regex.IsMatch(this.ComentarioRelacion))
            {
                Error error = new Error("Debe ingresar datos sobre  'Por que de esta manera' de la pregunta 3", 5000, 301);
                errores.Add(error);
            }

            regex = new Regex(expresion_TextoNSNR);
            if (!regex.IsMatch(this.OrganizarVecinos))
            {
                Error error = new Error("Debe seleccionar datos de la pregunta 4", 5000, 4);
                errores.Add(error);
            }
            regex = new Regex(expresion_Texto);
            if (!regex.IsMatch(this.OrganizarA) && this.OrganizarVecinos == "Si (especificar)")
            {
                Error error = new Error("Debe ingresar datos de 'Otra energia cocina' de la pregunta 4", 5000, 401);
                errores.Add(error);
            }

            regex = new Regex(expresion_TextoNSNR);
            if (!regex.IsMatch(this.ParticipacionGrupo))
            {
                Error error = new Error("Debe seleccionar datos de la pregunta 5", 5000, 5);
                errores.Add(error);
            }
            regex = new Regex(expresion_TextoNSNR);
            if (!regex.IsMatch(this.Necesidad))
            {
                Error error = new Error("Debe seleccionar datos de la pregunta 9", 5000, 9);
                errores.Add(error);
            }
            regex = new Regex(expresion_Texto);
            if (!regex.IsMatch(this.NecesidadA) && this.Necesidad == "Si (especificar)")
            {
                Error error = new Error("Debe ingresar datos de 'Necesidad y Problematica familiar' de la pregunta 9", 5000, 901);
                errores.Add(error);
            }
            regex = new Regex(expresion_TextoNSNR);
            if (!regex.IsMatch(this.NecesidadCom))
            {
                Error error = new Error("Debe seleccionar datos de la pregunta 10", 5000, 10);
                errores.Add(error);
            }
            regex = new Regex(expresion_Texto);
            if (!regex.IsMatch(this.NecesidadComA) && this.NecesidadCom == "Si (especificar)")
            {
                Error error = new Error("Debe ingresar datos de 'Problemas o Necesidades de la Comunidad' de la pregunta 10", 5000, 1001);
                errores.Add(error);
            }
            regex = new Regex(expresion_TextoNSNR);
            if (!regex.IsMatch(this.ProyectosVecinos))
            {
                Error error = new Error("Debe seleccionar datos de la pregunta 11", 5000, 11);
                errores.Add(error);
            }
            regex = new Regex(expresion_Texto);
            if (!regex.IsMatch(this.ProyectoA) && this.ProyectosVecinos == "Si (especificar)")
            {
                Error error = new Error("Debe ingresar datos de 'Cuales proyecto puntuales' de la pregunta 11", 5000, 1101);
                errores.Add(error);
            }
        }

        public void verificarDatosContS10()
        {
            string expresion_Texto = @"^[a-zA-Z]+\s*[a-zA-Z]*$";
            string expresion_TextoNSNR = @"^[a-zA-Z]{1,50}/|([a-zA-Z]{1,50})|[a-zA-Z]+\s*[a-zA-Z]|/|[a-zA-Z]/*$";
            Regex regex = new Regex(expresion_TextoNSNR);
            
            regex = new Regex(expresion_TextoNSNR);
            if (!regex.IsMatch(this.AspectoPositivoA) && this.AspectoPositivo == true)
            {
                Error error = new Error("Debe ingresar datos de los 'Aspectos positivos' de la pregunta 12", 5000, 1201);
                errores.Add(error);
            }

            
            regex = new Regex(expresion_Texto);
            if (!regex.IsMatch(this.AspectoNegativoA) && this.AspectoNegativo == true)
            {
                Error error = new Error("Debe ingresar datos sobre los 'Aspectos negativos' de la pregunta 13", 5000, 1301);
                errores.Add(error);
            }

            regex = new Regex(expresion_TextoNSNR);
            if (!regex.IsMatch(this.Discriminacion))
            {
                Error error = new Error("Debe seleccionar datos de la pregunta 15", 5000, 15);
                errores.Add(error);
            }
            regex = new Regex(expresion_Texto);
            if (!regex.IsMatch(this.TipoDiscriminacion) && this.Discriminacion == "Si  (especificar)")
            {
                Error error = new Error("Debe ingresar datos de la 'Discriminacion' de la pregunta 15", 5000, 1501);
                errores.Add(error);
            }

            regex = new Regex(expresion_TextoNSNR);
            if (!regex.IsMatch(this.OrganizacionComunitaria))
            {
                Error error = new Error("Debe seleccionar datos de la pregunta 16", 5000, 16);
                errores.Add(error);
            }
            regex = new Regex(expresion_Texto);
            if (!regex.IsMatch(this.TipoOrganizacion))
            {
                Error error = new Error("Debe ingresar datos sobre 'Tipo de organizacion' de la pregunta 17", 5000, 17);
                errores.Add(error);
            }
            regex = new Regex(expresion_TextoNSNR);
            if (!regex.IsMatch(this.ConfianzaOrganizacion))
            {
                Error error = new Error("Debe seleccionar datos de la pregunta 18", 5000, 18);
                errores.Add(error);
            }
            regex = new Regex(expresion_Texto);
            if (!regex.IsMatch(this.ComentarioConfianza))
            {
                Error error = new Error("Debe ingresar datos sobre 'Por que razon' de la pregunta 1801", 5000, 1801);
                errores.Add(error);
            }
          
            regex = new Regex(expresion_Texto);
            if (!regex.IsMatch(this.LiderA) && this.Lider == false)
            {
                Error error = new Error("Debe ingresar datos sobre 'Quienes identifica como lideres' de la pregunta 19", 5000, 19);
                errores.Add(error);
            }

            if (!regex.IsMatch(this.EstadoComunidadPasada))
            {
                Error error = new Error("Debe seleccionar datos de la pregunta 20", 5000, 20);
                errores.Add(error);
            }

            regex = new Regex(expresion_Texto);
            if (!regex.IsMatch(this.ComentarioEstadoPasado)) 
            {
                Error error = new Error("Debe ingresar datos sobre 'por que' de la pregunta 20", 5000, 2001);
                errores.Add(error);
            }

            if (!regex.IsMatch(this.EstadoComunidadFuturo))
            {
                Error error = new Error("Debe seleccionar datos de la pregunta 21", 5000, 21);
                errores.Add(error);
            }

            regex = new Regex(expresion_Texto);
            if (!regex.IsMatch(this.ComentarioEstadoFuturo))
            {
                Error error = new Error("Debe ingresar datos sobre 'por que' de la pregunta 21", 5000, 2201);
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
