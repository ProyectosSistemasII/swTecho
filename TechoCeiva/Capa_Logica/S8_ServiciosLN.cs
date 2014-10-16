using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Capa_Datos;
using System.Text.RegularExpressions;
using System.Data;

namespace Capa_Logica
{
    public class S8_ServiciosLN : S8_Servicios
    {
        public S8_ServiciosLN()
        {
            this.idS8_serv = 0;
            this.AccesoAgua = "";
            this.FuenteAgua = "";
            this.OtraFuente = "";
            this.EnergiaElectrica = "";
            this.OtraEnergiaElectrica = "";
            this.EnergiaCocina = "";
            this.OtraEnergiaCocina = "";
            this.Sanitario = "";
            this.OtroTipoSanitario = "";
            this.BasuraHogar = "";
            this.OtroTipoBasura = "";
            this.idEncuestas = 0;
            this.idS807_serv = 0;
            this.idS808_serv = 0;
        }
        public S8_ServiciosLN(String AccesoAgua, String FuenteAgua, String OtraFuente, String EnergiaElectrica, String OtraEnergiaElectrica, String EnergiaCocina, String OtraEnergiaCocina, String Sanitario, String OtroTipoSanitario, String BasuraHogar, String OtroTipoBasura, int idEncuesta)
        {
            
            this.AccesoAgua = AccesoAgua;
            this.FuenteAgua = FuenteAgua;
            this.OtraFuente = OtraFuente;
            this.EnergiaElectrica = EnergiaElectrica;
            this.OtraEnergiaElectrica = OtraEnergiaElectrica;
            this.EnergiaCocina = EnergiaCocina;
            this.OtraEnergiaCocina = OtraEnergiaCocina;
            this.Sanitario = Sanitario;
            this.OtroTipoSanitario = OtroTipoSanitario;
            this.BasuraHogar = BasuraHogar;
            this.OtroTipoBasura = OtroTipoBasura;
            this.idEncuestas = idEncuesta;
            this.errores = new List<Error>();
        }

        public Boolean Verficar_EncS8()
        {
            //verificar sintaxis de los datos y comprobar errores antes de ser enviado a la capa de datos
            this.verificarDatos();
            if (errores.Count > 0)
            {
                return false;
            }
            // se ingresa los datos a la capa de datos            
            return true;
        }
        public Boolean Insertar_EcS8()
        {
            S8_Servicios servicios = new S8_Servicios(0, this.AccesoAgua, this.FuenteAgua, this.OtraFuente, this.EnergiaElectrica, this.OtraEnergiaElectrica, this.EnergiaCocina, this.OtraEnergiaCocina, this.Sanitario, this.OtroTipoSanitario, this.BasuraHogar, this.OtroTipoBasura, this.idEncuestas, this.idS807_serv, this.idS808_serv);
            servicios.InsertarS8();
            this.errores = servicios.errores;

            //Comprobar errores para la capa de datos
            if (errores.Count > 0)
            {
                return false;
            }
            return true;
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

        public Error obtenerError()
        {
            Error error = errores[0];
            return error;
        }

        public DataTable ObtnerReporte(int comunidad)
        {
            S8_Servicios servicios = new S8_Servicios();      
            return servicios.GenerarReporte(comunidad);

        }
    }
}
