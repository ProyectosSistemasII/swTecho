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

        public S5_TrabajoLN(int CodigoS5, Boolean Trabajo, Boolean Buscando, string RazonNoBusqueda, string OtraRazonNoBusqueda, string Ocupacion,
            string OtraOcupacion, string ContratoTrabajo, string CondicionLaboral, string UbicacionTrabajo, Boolean OtrosTrabajos, string EspecificarOtrosTrabajos,
            int DiasTrabajo, float HorasTrabajo, float IngresoMensual, int Encuestas_idEncuestas)
        {
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
        }

        public Boolean Insertar_EncuS5()
        {
            Boolean correcto = true;
            S5_Trabajo trabajo = new S5_Trabajo(CodigoS5, Trabajo, Buscando, RazonNoBusqueda, OtraRazonNoBusqueda, Ocupacion, OtraOcupacion, ContratoTrabajo, CondicionLaboral, UbicacionTrabajo, OtrosTrabajos, EspecificarOtrosTrabajos, DiasTrabajo, HorasTrabajo, IngresoMensual, Encuestas_idEncuestas);
            trabajo.InsertarS5();
            if (errores.Count > 0)
            {
                correcto = false;
            }
            return correcto;
        }

        public Boolean validacion(int CodigoS5, Boolean Trabajo, Boolean Buscando, string RazonNoBusqueda, string OtraRazonNoBusqueda, string Ocupacion,
            string OtraOcupacion, string ContratoTrabajo, string CondicionLaboral, string UbicacionTrabajo, Boolean OtrosTrabajos, string EspecificarOtrosTrabajos,
            int DiasTrabajo, float HorasTrabajo, float IngresoMensual, int Encuestas_idEncuestas, int filas)
        {
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
            this.verificarDatos(filas + 1);
            if (errores.Count > 0)
            {
                return false;
            }
            return true;
        }

        public void verificarDatos(int filas)
        {
            if (this.Buscando.Equals("No") && this.RazonNoBusqueda.Equals(""))
            {
                Error error = new Error("Colocar la razon por la que no busca trabajo en la fila " + filas.ToString(), 5000, 1);
                errores.Add(error);
            }
            if (this.RazonNoBusqueda.Equals("Otro (Especificar)") && this.OtraRazonNoBusqueda == "")
            {
                Error error = new Error("Debe especificar la razon por la cual no busca trabajo en la fila " + filas.ToString(), 5000, 1);
                errores.Add(error);
            }
            if (this.Ocupacion.Equals("Ama de casa") || this.Ocupacion.Equals("Estudiante"))
            {
                this.ContratoTrabajo = "";
                this.CondicionLaboral = "";
                this.UbicacionTrabajo = "";
            }
            else if (this.ContratoTrabajo.Equals(""))
            {
                Error error = new Error("Colocar el tipo de contrato de trabajo que posee en la fila " + filas.ToString(), 5000, 1);
                errores.Add(error);
            }
            else if (this.CondicionLaboral.Equals(""))
            {
                Error error = new Error("Colocar la condicion laboral de trabajo que posee en la fila " + filas.ToString(), 5000, 1);
                errores.Add(error);
            }
            else if (this.UbicacionTrabajo.Equals(""))
            {
                Error error = new Error("Colocar la ubicacion del lugar de trabajo que posee en la fila " + filas.ToString(), 5000, 1);
                errores.Add(error);
            }
            if (this.Ocupacion.Equals("Otro (Especificar)") && this.OtraOcupacion == "")
            {
                Error error = new Error("Debe de especificar la otra ocupacion en la fila " + filas.ToString(), 5000, 1);
                errores.Add(error);
            }
            if (this.OtrosTrabajos == true && this.EspecificarOtrosTrabajos == "")
            {
                Error error = new Error("Debe especificar si posee otros trabajos en la fila " + filas.ToString(), 5000, 1);
                errores.Add(error);
            }
            if (this.DiasTrabajo == 0)
            {
                Error error = new Error("Colocar los dias que trabaja en la fila " + filas.ToString(), 5000, 1);
                errores.Add(error);
            }
            if (this.HorasTrabajo == 0)
            {
                Error error = new Error("Colocar las horas de trabajo en la fila " + filas.ToString(), 5000, 1);
                errores.Add(error);
            }
            if (this.IngresoMensual == 0)
            {
                Error error = new Error("Colocar el ingreso mensual en la fila " + filas.ToString(), 5000, 1);
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