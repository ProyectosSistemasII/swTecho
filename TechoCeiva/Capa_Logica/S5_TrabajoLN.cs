using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Capa_Datos;

namespace Capa_Logica
{
    public class S5_TrabajoLN : S5_Trabajo
    {
        public S5_TrabajoLN()
        {
            this.CodigoS5 = 0;
            this.Trabajo = false;
            this.Buscando = false;
            this.RazonNoBusqueda = "";
            this.OtraRazonNoBusqueda = "";
            this.Ocupacion = "";
            this.OtraOcupacion = "";
            this.ContratoTrabajo = "";
            this.CondicionLaboral = "";
            this.UbicacionTrabajo = "";
            this.OtrosTrabajos = false;
            this.EspecificarOtrosTrabajos = "";
            this.DiasTrabajo = 0;
            this.HorasTrabajo = 0;
            this.IngresoMensual = 0;
            this.Encuestas_idEncuestas = 0;
        }

        public Boolean Insertar_EncuS5(int CodigoS5, Boolean Trabajo, Boolean Buscando, string RazonNoBusqueda, string OtraRazonNoBusqueda, string Ocupacion,
            string OtraOcupacion, string ContratoTrabajo, string CondicionLaboral, string UbicacionTrabajo, Boolean OtrosTrabajos, string EspecificarOtrosTrabajos,
            int DiasTrabajo, float HorasTrabajo, float IngresoMensual, int Encuestas_idEncuestas)
        {
            Boolean correcto = true;
            S5_Trabajo trabajo = new S5_Trabajo(CodigoS5, Trabajo, Buscando, RazonNoBusqueda, OtraRazonNoBusqueda, Ocupacion, OtraOcupacion, ContratoTrabajo, CondicionLaboral, UbicacionTrabajo, OtrosTrabajos, EspecificarOtrosTrabajos, DiasTrabajo, HorasTrabajo, IngresoMensual, Encuestas_idEncuestas);

            this.CodigoS5 = CodigoS5;
            this.Trabajo = Trabajo;
            this.Buscando = Buscando;
            this.RazonNoBusqueda = RazonNoBusqueda;
            this.OtraRazonNoBusqueda = OtraRazonNoBusqueda;
            this.Ocupacion = Ocupacion;
            this.OtraOcupacion = OtraOcupacion;
            this.ContratoTrabajo = ContratoTrabajo;
            this.CondicionLaboral = CondicionLaboral;
            this.UbicacionTrabajo = UbicacionTrabajo;
            this.OtrosTrabajos = OtrosTrabajos;
            this.EspecificarOtrosTrabajos = EspecificarOtrosTrabajos;
            this.DiasTrabajo = DiasTrabajo;
            this.HorasTrabajo = HorasTrabajo;
            this.IngresoMensual = IngresoMensual;
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
