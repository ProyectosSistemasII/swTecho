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
            this.NoFamiliar = "";
            this.Nacionalidad = "";
            this.Encuestas_idEncuestas = 0;
            this.Departamento_idDepartamento = 0;
            this.Municipio_idMunicipio = 0;
        }

        public Boolean Insertar_EncuS2(int CodigoS2, string Nucleo, string DPICedula, string EstadoCivil, string Parentesco, string OtroFamiliar,
            string Nacionalidad, int Encuestas_idEncuestas, int Departamento_idDepartamento, int Municipio_idMunicipio)
        {
            Boolean correcto = true;
            S2_Demografica demografica = new S2_Demografica(CodigoS2, Nucleo, DPICedula, EstadoCivil, Parentesco, OtroFamiliar, NoFamiliar, Nacionalidad,
                Encuestas_idEncuestas, Departamento_idDepartamento, Municipio_idMunicipio);

            this.CodigoS2 = CodigoS2;
            this.Nucleo = Nucleo;
            this.DPICedula = DPICedula;
            this.EstadoCivil = EstadoCivil;
            this.Parentesco = Parentesco;
            this.OtroFamiliar = OtroFamiliar;
            this.NoFamiliar = NoFamiliar;
            this.Nacionalidad = Nacionalidad;
            this.Encuestas_idEncuestas = Encuestas_idEncuestas;
            this.Departamento_idDepartamento = Departamento_idDepartamento;
            this.Municipio_idMunicipio = Municipio_idMunicipio;
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
