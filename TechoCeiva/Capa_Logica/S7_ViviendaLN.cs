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
            this.Ancho = 0;
            this.Largo = 0;
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

        public S7_ViviendaLN(int Ancho, int Largo, String Cuartos, String Dormitorio, String Camas, String ProblemaVivienda, String ProblemaA, String ProblemaB, String ProblemaC, int idEncuesta, int idS706, int idS707, int idS708)
        {
            this.Ancho = Ancho;
            this.Largo = Largo;
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
        }

        public Boolean Insertar_EncuS7()
        {
            Boolean correcto = true;
            S7_Vivienda vivienda = new S7_Vivienda(Ancho, Largo, Cuartos, Dormitorio, Camas, ProblemaVivienda, ProblemaA, ProblemaB, ProblemaC, Encuestas_idEncuestas, S706_Viv_idS706, S707_Viv_idS707, S708_Viv_idS708);
            vivienda.InsertarS7();               
            if (errores.Count > 0)
            {
                correcto = false;
            }
            return correcto;
        }

        public Boolean VerificarCampos()
        {
            Boolean correcto = true;
            this.verificarDatos();
            if (errores.Count > 0)
            {
                return false;
            }
            return correcto;
        }

        public void verificarDatos()
        {
            if (this.Ancho.Equals(0))
            {
                Error error = new Error("Debe ingresar el ancho de la vivienda en la pregunta 1", 5000, 1);
                errores.Add(error);
            }
            if (this.Largo.Equals(0))
            {
                Error error = new Error("Debe ingresar el largo de la vivienda en la pregunta 1", 5000, 1);
                errores.Add(error);
            }
            if (this.Cuartos.Equals(""))
            {
                Error error = new Error("Debe ingresar la cantidad de cuartos en la pregunta 2", 5000, 2);
                errores.Add(error);
            }
            if (this.Dormitorio.Equals(""))
            {
                Error error = new Error("Debe ingresar la cantidad de dormitorios en la pregunta 3", 5000, 3);
                errores.Add(error);
            }
            if (this.Camas.Equals(""))
            {
                Error error = new Error("Debe ingresar la cantidad de camas en la pregunta 4", 5000, 4);
                errores.Add(error);
            }
            if (this.ProblemaVivienda.Equals(""))
            {
                Error error = new Error("Debe seleccionar datos de la pregunta 5", 5000, 5);
                errores.Add(error);
            }
            if (this.ProblemaVivienda.Equals("Si (especificar cuales)") && this.ProblemaA.Equals(""))
            {
                Error error = new Error("Debe especificar los problemas en la pregunta 5", 5000, 501);
                errores.Add(error);
            }
        }

        public string obtenerError()
        {
            Error error = errores[0];
            return error.mensaje;
        }
    }
}
