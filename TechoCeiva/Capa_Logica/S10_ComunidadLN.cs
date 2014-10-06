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
            this.AspectoPositivo = "";
            this.AspectoPositivoA = "";
            this.AspectoPositivoB = "";
            this.AspectoPositivoC = "";
            this.AspectoNegativo = "";
            this.AspectoNegativoA = "";
            this.AspectoNegativoB = "";
            this.AspectoNegativoC = "";
            this.Discriminacion = "";
            this.TipoDiscriminacion = "";
            this.OrganizacionComunitaria = "";
            this.TipoOrganizacion = "";
            this.ConfianzaOrganizacion = "";
            this.ComentarioConfianza = "";
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
        String ParticipacionGrupo, int idEncuestas, int idS1006,int idS1007, int idS1008)
            
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
            this.idS1006 = idS1006;
            this.idS1007 = idS1007;
            this.idS1008 = idS1008;
            this.idEncuestas = idEncuestas;
            this.errores = new List<Error>();
        }
    
        public void S10_ComunidadLNCont(    String Necesidad, String NecesidadA, String NecesidadB, String NecesidadC,
        String NecesidadCom, String NecesidadComA, String NecesidadComB, String NecesidadComC, String ProyectosVecinos,
        String ProyectoA, String ProyectoB, String ProyectoC, String AspectoPositivo, String AspectoPositivoA,
        String AspectoPositivoB, String AspectoPositivoC, String AspectoNegativo, String AspectoNegativoA,
        String AspectoNegativoB, String AspectoNegativoC, String Discriminacion, String TipoDiscriminacion,
        String OrganizacionComunitaria, String TipoOrganizacion, String ConfianzaOrganizacion, String ComentarioConfianza,
        String LiderA, String LiderB, String LiderC, String EstadoComunidadPasada, String ComentarioEstadoPasado,
        String EstadoComunidadFuturo, String ComentarioEstadoFuturo,  int idS1014)
        {
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
            this.AspectoPositivo = AspectoPositivo;
            this.AspectoPositivoA = AspectoPositivoA;
            this.AspectoPositivoB = AspectoPositivoB;
            this.AspectoPositivoC = AspectoPositivoC;
            this.AspectoNegativo = AspectoNegativo;
            this.AspectoNegativoA = AspectoNegativoA;
            this.AspectoNegativoB = AspectoNegativoB;
            this.AspectoNegativoC = AspectoNegativoC;
            this.Discriminacion = Discriminacion;
            this.TipoDiscriminacion = TipoDiscriminacion;
            this.OrganizacionComunitaria = OrganizacionComunitaria;
            this.TipoOrganizacion = TipoOrganizacion;
            this.ConfianzaOrganizacion = ConfianzaOrganizacion;
            this.ComentarioConfianza = ComentarioConfianza;
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
            NuevaComS10 = new S10_Comunidad(0, this.Ayudo, this.AyudaVecinos, this.RelacionVecinos, this.ComentarioRelacion, this.OrganizarVecinos, this.OrganizarA, this.OrganizarB, this.OrganizarC, this.ParticipacionGrupo, this.Necesidad, this.NecesidadA, this.NecesidadB, this.NecesidadC, this.NecesidadCom, this.NecesidadComA, this.NecesidadComB, this.NecesidadComC, this.ProyectosVecinos, this.ProyectoA, this.ProyectoB, this.ProyectoC, this.AspectoPositivo, this.AspectoPositivoA, this.AspectoPositivoB, this.AspectoPositivoC, this.AspectoPositivo, this.AspectoPositivoA, this.AspectoPositivoB, this.AspectoPositivoC, this.Discriminacion, this.TipoDiscriminacion, this.OrganizacionComunitaria, this.TipoOrganizacion, this.ConfianzaOrganizacion, this.ComentarioConfianza, this.LiderA, this.LiderB, this.LiderC, this.EstadoComunidadPasada, this.ComentarioEstadoPasado, this.EstadoComunidadFuturo, this.ComentarioEstadoFuturo, this.idEncuestas, this.idS1006, this.idS1007, this.idS1008);
            
            NuevaComS10.InsertarS10();
            this.errores = NuevaComS10.errores;

            //Comprobar errores para la capa de datos
            if (errores.Count > 0)
            {
                correcto = false;
            }
            return correcto;
        }
        public Boolean Insertar_EncuS10()
        {
            Boolean correcto = true;
            //verificar sintaxis de los datos y comprobar errores antes de ser enviado a la capa de datos
            this.verificarDatosContS10();
            if (errores.Count > 0)
            {
                return false;
            }
            // se ingresa los datos a la capa de datos            
            NuevaComS10.S10_ComunidadCOnt(this.Necesidad, this.NecesidadA, this.NecesidadB, this.NecesidadC, this.NecesidadCom, this.NecesidadComA, this.NecesidadComB, this.NecesidadComC, this.ProyectosVecinos, this.ProyectoA, this.ProyectoB, this.ProyectoC, this.AspectoPositivo, this.AspectoPositivoA, this.AspectoPositivoB, this.AspectoPositivoC, this.AspectoPositivo, this.AspectoPositivoA, this.AspectoPositivoB, this.AspectoPositivoC, this.Discriminacion, this.TipoDiscriminacion, this.OrganizacionComunitaria, this.TipoOrganizacion, this.ConfianzaOrganizacion, this.ComentarioConfianza, this.LiderA, this.LiderB, this.LiderC, this.EstadoComunidadPasada, this.ComentarioEstadoPasado, this.EstadoComunidadFuturo, this.ComentarioEstadoFuturo, this.idS1014);
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
            if (!regex.IsMatch(this.AccesoAgua))
            {
                Error error = new Error("Debe seleccionar datos de la pregunta 1", 5000, 1);
                errores.Add(error);
            }
            regex = new Regex(expresion_TextoNSNR);
            if (!regex.IsMatch(this.FuenteAgua))
            {
                Error error = new Error("Debe seleccionar datos de la pregunta 2", 5000, 2);
                errores.Add(error);
            }
            regex = new Regex(expresion_TextoNSNR);
            if (!regex.IsMatch(this.OtraFuente) && this.FuenteAgua == "Otro (especifique)")
            {
                Error error = new Error("Debe ingresar datos de 'Otro fuente de agua' de la pregunta 2", 5000, 201);
                errores.Add(error);
            }

            regex = new Regex(expresion_TextoNSNR);
            if (!regex.IsMatch(this.EnergiaElectrica))
            {
                Error error = new Error("Debe seleccionar datos de la pregunta 3", 5000, 3);
                errores.Add(error);
            }
            regex = new Regex(expresion_Texto);
            if (!regex.IsMatch(this.OtraEnergiaElectrica) && this.EnergiaElectrica == "Otro (especifique)")
            {
                Error error = new Error("Debe ingresar datos sobre  'Otras energia electrica' de la pregunta 3", 5000, 301);
                errores.Add(error);
            }

            regex = new Regex(expresion_TextoNSNR);
            if (!regex.IsMatch(this.EnergiaCocina))
            {
                Error error = new Error("Debe seleccionar datos de la pregunta 4", 5000, 4);
                errores.Add(error);
            }
            regex = new Regex(expresion_Texto);
            if (!regex.IsMatch(this.OtraEnergiaCocina) && this.EnergiaCocina == "Otro (especifique)")
            {
                Error error = new Error("Debe ingresar datos de 'Otra energia cocina' de la pregunta 4", 5000, 401);
                errores.Add(error);
            }

            regex = new Regex(expresion_TextoNSNR);
            if (!regex.IsMatch(this.Sanitario))
            {
                Error error = new Error("Debe seleccionar datos de la pregunta 5", 5000, 5);
                errores.Add(error);
            }
            regex = new Regex(expresion_Texto);
            if (!regex.IsMatch(this.OtroTipoSanitario) && this.Sanitario == "Otra (especificar)")
            {
                Error error = new Error("Debe ingresar datos sobre 'Otro tipo de sanitario' de la pregunta 5", 5000, 501);
                errores.Add(error);
            }
            regex = new Regex(expresion_TextoNSNR);
            if (!regex.IsMatch(this.BasuraHogar))
            {
                Error error = new Error("Debe seleccionar datos de la pregunta 6", 5000, 6);
                errores.Add(error);
            }
            regex = new Regex(expresion_Texto);
            if (!regex.IsMatch(this.OtroTipoBasura) && this.BasuraHogar == "Otro (especifique)")
            {
                Error error = new Error("Debe ingresar datos sobre 'Otro tipo de basura' de la pregunta 6", 5000, 601);
                errores.Add(error);
            }
        }

        public void verificarDatosContS10()
        {
            string expresion_Texto = @"^[a-zA-Z]+\s*[a-zA-Z]*$";
            string expresion_TextoNSNR = @"^[a-zA-Z]{1,50}/|([a-zA-Z]{1,50})|[a-zA-Z]+\s*[a-zA-Z]|/|[a-zA-Z]/*$";
            Regex regex = new Regex(expresion_TextoNSNR);
            if (!regex.IsMatch(this.AccesoAgua))
            {
                Error error = new Error("Debe seleccionar datos de la pregunta 1", 5000, 1);
                errores.Add(error);
            }
            regex = new Regex(expresion_TextoNSNR);
            if (!regex.IsMatch(this.FuenteAgua))
            {
                Error error = new Error("Debe seleccionar datos de la pregunta 2", 5000, 2);
                errores.Add(error);
            }
            regex = new Regex(expresion_TextoNSNR);
            if (!regex.IsMatch(this.OtraFuente) && this.FuenteAgua == "Otro (especifique)")
            {
                Error error = new Error("Debe ingresar datos de 'Otro fuente de agua' de la pregunta 2", 5000, 201);
                errores.Add(error);
            }

            regex = new Regex(expresion_TextoNSNR);
            if (!regex.IsMatch(this.EnergiaElectrica))
            {
                Error error = new Error("Debe seleccionar datos de la pregunta 3", 5000, 3);
                errores.Add(error);
            }
            regex = new Regex(expresion_Texto);
            if (!regex.IsMatch(this.OtraEnergiaElectrica) && this.EnergiaElectrica == "Otro (especifique)")
            {
                Error error = new Error("Debe ingresar datos sobre  'Otras energia electrica' de la pregunta 3", 5000, 301);
                errores.Add(error);
            }

            regex = new Regex(expresion_TextoNSNR);
            if (!regex.IsMatch(this.EnergiaCocina))
            {
                Error error = new Error("Debe seleccionar datos de la pregunta 4", 5000, 4);
                errores.Add(error);
            }
            regex = new Regex(expresion_Texto);
            if (!regex.IsMatch(this.OtraEnergiaCocina) && this.EnergiaCocina == "Otro (especifique)")
            {
                Error error = new Error("Debe ingresar datos de 'Otra energia cocina' de la pregunta 4", 5000, 401);
                errores.Add(error);
            }

            regex = new Regex(expresion_TextoNSNR);
            if (!regex.IsMatch(this.Sanitario))
            {
                Error error = new Error("Debe seleccionar datos de la pregunta 5", 5000, 5);
                errores.Add(error);
            }
            regex = new Regex(expresion_Texto);
            if (!regex.IsMatch(this.OtroTipoSanitario) && this.Sanitario == "Otra (especificar)")
            {
                Error error = new Error("Debe ingresar datos sobre 'Otro tipo de sanitario' de la pregunta 5", 5000, 501);
                errores.Add(error);
            }
            regex = new Regex(expresion_TextoNSNR);
            if (!regex.IsMatch(this.BasuraHogar))
            {
                Error error = new Error("Debe seleccionar datos de la pregunta 6", 5000, 6);
                errores.Add(error);
            }
            regex = new Regex(expresion_Texto);
            if (!regex.IsMatch(this.OtroTipoBasura) && this.BasuraHogar == "Otro (especifique)")
            {
                Error error = new Error("Debe ingresar datos sobre 'Otro tipo de basura' de la pregunta 6", 5000, 601);
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
