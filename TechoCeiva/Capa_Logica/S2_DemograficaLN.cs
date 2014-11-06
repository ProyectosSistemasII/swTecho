using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Capa_Datos;

namespace Capa_Logica
{
    public class S2_DemograficaLN : S2_Demografica
    {
        public S2_DemograficaLN()
        {
            this.CodigoS2 = 0;
            this.Nucleo = "";
            this.DPICedula = "";
            this.EstadoCivil = "";
            this.Parentesco = "";
            this.OtroFamiliar = "";
            this.Nacionalidad = "";
            this.Encuestas_idEncuestas = 0;
            this.Departamento = "";
            this.Municipio = "";
        }

        // setea las variables
        public S2_DemograficaLN(int CodigoS2, string Nucleo, string DPICedula, string EstadoCivil, string Parentesco, string OtroFamiliar,
            string Nacionalidad, int Encuestas_idEncuestas, string Departamento, string Municipio)
        {
            this.CodigoS2 = CodigoS2;
            this.Nucleo = Nucleo;
            this.DPICedula = DPICedula;
            this.EstadoCivil = EstadoCivil;
            this.Parentesco = Parentesco;
            this.OtroFamiliar = OtroFamiliar;
            this.Nacionalidad = Nacionalidad;
            this.Encuestas_idEncuestas = Encuestas_idEncuestas;
            this.Departamento = Departamento;
            this.Municipio = Municipio;
            this.errores = new List<Error>();
        }

        // inserta la seccion 2 en la base de datos
        public Boolean Insertar_EncuS2()
        {
            Boolean correcto = true;
            S2_Demografica demografica = new S2_Demografica(CodigoS2, Nucleo, DPICedula, EstadoCivil, Parentesco, OtroFamiliar, Nacionalidad, Encuestas_idEncuestas, Departamento, Municipio);
            demografica.InsertarS2();
            if (errores.Count > 0)
            {
                correcto = false;
            }
            return correcto;
        }

        // se validan los campos de la seccion 2
        public Boolean validacion(int CodigoS2, string Nucleo, string DPICedula, string EstadoCivil, string Parentesco, string OtroFamiliar,
            string Nacionalidad, int Encuestas_idEncuestas, string Departamento, string Municipio, int filas)
        {
            this.CodigoS2 = CodigoS2;
            this.Nucleo = Nucleo;
            this.DPICedula = DPICedula;
            this.EstadoCivil = EstadoCivil;
            this.Parentesco = Parentesco;
            this.OtroFamiliar = OtroFamiliar;
            this.Nacionalidad = Nacionalidad;
            this.Encuestas_idEncuestas = Encuestas_idEncuestas;
            this.Departamento = Departamento;
            this.Municipio= Municipio;
            this.errores = new List<Error>();
            this.verificarDatos(filas + 1);
            if (errores.Count > 0)
            {
                return false;
            }
            return true;
        }

        // validacion de datos de informacion de la seccion 2
        public void verificarDatos(int filas)
        {
            if (this.Nucleo.Equals(""))
            {
                Error error = new Error("Colocar el nucleo al que pertenece en la fila " + filas.ToString(), 5000, 1);
                errores.Add(error);
            }
            if (this.DPICedula.Equals(""))
            {
                Error error = new Error("Colocar el documento de identificacion en la fila " + filas.ToString(), 5000, 1);
                errores.Add(error);
            }
            if (this.EstadoCivil.Equals(""))
            {
                Error error = new Error("Colocar el estado civil en la fila " + filas.ToString(), 5000, 1);
                errores.Add(error);
            }
            if (this.Parentesco == "")
            {
                Error error = new Error("Colocar la relacion de parentesco en la fila " + filas.ToString(), 5000, 1);
                errores.Add(error);
            }
            if (this.Parentesco == "Otro familiar (especificar)" && this.OtroFamiliar == "")
            {
                Error error = new Error("Debe especificar la relacion de parentesco en la fila " + filas.ToString(), 5000, 1);
                errores.Add(error);
            }
            if (this.Parentesco == "No familiar (especificar)" && this.OtroFamiliar == "")
            {
                Error error = new Error("Debe especificar la relacion de parentesco en la fila " + filas.ToString(), 5000, 1);
                errores.Add(error);
            }
            if (this.Departamento == "")
            {
                Error error = new Error("Debe colocar el departamento de su origen " + filas.ToString(), 5000, 1);
                errores.Add(error);
            }
            if (this.Municipio == "")
            {
                Error error = new Error("Debe colocar el municipio de su origen " + filas.ToString(), 5000, 1);
                errores.Add(error);
            }
            if (this.Nacionalidad == "")
            {
                Error error = new Error("Colocar la nacionalidad en la fila " + filas.ToString(), 5000, 1);
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