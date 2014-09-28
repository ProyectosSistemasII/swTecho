using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Capa_Datos;

namespace Capa_Logica
{
    public class S6_IngresosLN : S6_Ingresos
    {
        public S6_IngresosLN()
        {
            this.CodigoS6 = 0;
            this.ApoyoEstado = "";
            this.CantidadApoyo = 0;
            this.Remesas = "";
            this.CantidadRemesas = 0;
            this.Deuda = "";
            this.DineroDeuda = 0;
            this.TiempoPagoDeuda = "";
            this.IngresoTotal = 0;
            this.CubreGastos = "";
            this.Ahorro = "";
            this.MontoAhorro = 0;
            this.DineroGasto = 0;
            this.Encuestas_idEncuestas = 0;
            this.S611_Ingre_idS611_Ingre = 0;
        }

        public Boolean Insertar_EncuS6(int CodigoS6, String ApoyoEstado, int CantidadApoyo, String Remesas, int CantidadRemesas, String Deuda, int DineroDeuda, String TiempoPagoDeuda, int IngresoTotal, String CubreGastos, String Ahorro, int MontoAhorro, int DineroGasto, int idEncuesta, int idS611)
        {
            Boolean correcto = true;
            S6_Ingresos ingresos = new S6_Ingresos(CodigoS6, ApoyoEstado, CantidadApoyo, Remesas, CantidadRemesas, Deuda, DineroDeuda, TiempoPagoDeuda, IngresoTotal, CubreGastos, Ahorro, MontoAhorro, DineroGasto, Encuestas_idEncuestas, S611_Ingre_idS611_Ingre);

            this.CodigoS6 = CodigoS6;
            this.ApoyoEstado = ApoyoEstado;
            this.CantidadApoyo = CantidadApoyo;
            this.Remesas = Remesas;
            this.CantidadRemesas = CantidadRemesas;
            this.Deuda = Deuda;
            this.DineroDeuda = DineroDeuda;
            this.TiempoPagoDeuda = TiempoPagoDeuda;
            this.IngresoTotal = IngresoTotal;
            this.CubreGastos = CubreGastos;
            this.Ahorro = Ahorro;
            this.MontoAhorro = MontoAhorro;
            this.DineroGasto = DineroGasto;
            this.Encuestas_idEncuestas = idEncuesta;
            this.S611_Ingre_idS611_Ingre = idS611;

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
