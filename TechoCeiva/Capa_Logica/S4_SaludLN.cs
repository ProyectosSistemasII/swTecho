using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Capa_Datos;

namespace Capa_Logica
{
    public class S4_SaludLN : S4_Salud
    {
        public S4_SaludLN()
        {
            this.CodigoS4 = 0;
            this.AsistenciaSalud = "";
            this.NombreCentro = "";
            this.UbicacionCentro = "";
            this.ProblemaSalud = false;
            this.EspecificarProblemaSalud = "";
            this.Accidente = false;
            this.TipoAccidente = "";
            this.Seguro = "";
            this.Discapacidad = "";
            this.OtraDiscapacidad = "";
            this.OrigenDiscapacidad = "";
            this.OtroOrigen = "";
            this.Encuestas_idEncuestas = 0;
        }

        public Boolean Insertar_EncuS4(int CodigoS4, string AsistenciaSalud, string NombreCentro, string UbicacionCentro, Boolean ProblemaSalud, string EspecificarProblemaSalud, Boolean Accidente, string TipoAccidente,
            string Seguro, string Discapacidad, string OtraDiscapacidad, string OrigenDiscapacidad, string OtroOrigen, int Encuestas_idEncuestas)
        {
            Boolean correcto = true;
            S4_Salud salud = new S4_Salud(CodigoS4, AsistenciaSalud, NombreCentro, UbicacionCentro, ProblemaSalud, EspecificarProblemaSalud, Accidente, TipoAccidente, Seguro, Discapacidad, OtraDiscapacidad, OrigenDiscapacidad, OtroOrigen, Encuestas_idEncuestas);

            this.CodigoS4 = CodigoS4;
            this.AsistenciaSalud = AsistenciaSalud;
            this.NombreCentro = NombreCentro;
            this.UbicacionCentro = UbicacionCentro;
            this.ProblemaSalud = ProblemaSalud;
            this.EspecificarProblemaSalud = EspecificarProblemaSalud;
            this.Accidente = Accidente;
            this.TipoAccidente = TipoAccidente;
            this.Seguro = Seguro;
            this.Discapacidad = Discapacidad;
            this.OtraDiscapacidad = OtraDiscapacidad;
            this.OrigenDiscapacidad = OrigenDiscapacidad;
            this.OtroOrigen = OtroOrigen;
            this.Encuestas_idEncuestas = Encuestas_idEncuestas;

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
