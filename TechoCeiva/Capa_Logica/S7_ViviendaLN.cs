using Capa_Datos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Capa_Logica
{
    public class S7_ViviendaLN : S7_Vivienda
    {
        public S7_ViviendaLN()
        {
            this.DimensionesVivienda = "";
            this.Cuartos = "";
            this.Dormitorio = "";
            this.Camas = "";
            this.ProblemaVivienda = "";
            this.ProblemaA = "";
            this.ProblemaB = "";
            this.ProblemaC = "";
            this.Encuestas_idEncuestas = 0;
            this.S706_Viv_idS706 = 0;
            this.S707_Viv_idS707 = 0;
            this.S708_Viv_idS708 = 0;
        }
        
        public Boolean Insertar_EncuS7(String DimensionesVivienda, String Cuartos, String Dormitorio, String Camas, String ProblemaVivienda, String ProblemaA, String ProblemaB, String ProblemaC, int idEncuesta, int idS706, int idS707, int idS708)
        {
            Boolean correcto = true;
            S7_Vivienda vivienda = new S7_Vivienda(DimensionesVivienda, Cuartos, Dormitorio, Camas, ProblemaVivienda, ProblemaA, ProblemaB, ProblemaC, idEncuesta, idS706, idS707, idS708);

            this.DimensionesVivienda = DimensionesVivienda;
            this.Cuartos = Cuartos;
            this.Dormitorio = Dormitorio;
            this.Camas = Camas;
            this.ProblemaVivienda = ProblemaVivienda;
            this.ProblemaA = ProblemaA;
            this.ProblemaB = ProblemaB;
            this.ProblemaC = ProblemaC;
            this.Encuestas_idEncuestas = idEncuesta;
            this.S706_Viv_idS706 = idS706;
            this.S707_Viv_idS707 = idS707;
            this.S708_Viv_idS708 = idS708;
            
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
