using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Capa_Datos;

namespace Capa_Logica
{
    public class S8_ServiciosLN : S8_Servicios
    {
        public S8_ServiciosLN()
        {
            this.idS8_serv = 0;
            this.CodigoS8 = 0;
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
        public Boolean Insertar_EncuS8(int codigoS8, String AccesoAgua, String FuenteAgua, String OtraFuente,String Energia, String OtraEnergia, String Cocina, String OtraCocina, String Sanitario, String OtroTipoSanitario, String BasuraHogar, String OtroTipoBasura, int idEncuesta, int idS807, int idS808) 
        {
            Boolean correcto = true;
            S8_Servicios servicios = new S8_Servicios(0, codigoS8, AccesoAgua, FuenteAgua, OtraFuente, Energia, OtraEnergia, Cocina, OtraCocina, Sanitario, OtroTipoSanitario, BasuraHogar, OtroTipoBasura, idEncuesta, idS807, idS808);

            this.idS808_serv = servicios.idS8_serv;
            this.CodigoS8 = servicios.CodigoS8;
            this.AccesoAgua = servicios.AccesoAgua;
            this.FuenteAgua = servicios.FuenteAgua;
            this.OtraFuente = servicios.OtraFuente;
            this.EnergiaElectrica = servicios.EnergiaElectrica;
            this.OtraEnergiaElectrica = servicios.OtraEnergiaElectrica;
            this.EnergiaCocina = servicios.EnergiaCocina;
            this.OtraEnergiaCocina = servicios.OtraEnergiaCocina;
            this.Sanitario = servicios.Sanitario;
            this.OtroTipoSanitario = servicios.OtroTipoSanitario;
            this.idEncuestas = servicios.idEncuestas;
            this.idS807_serv = servicios.idS807_serv;
            this.idS808_serv = servicios.idS808_serv;
            
            this.errores = new List<Error>();
            if (errores.Count > 0)
            {
                correcto = false;
            }
            return correcto;
        }

        public string obtenerError()
        {
            Error error = errores[0];
            return error.mensaje;
        }
    }
}
