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

        public S6_IngresosLN(string ApoyoEstado, float CantidadApoyo, string Remesas, float CantidadRemesas, string Deuda, float DineroDeuda, string TiempoPagoDeuda, float IngresoTotal, string CubreGastos, string Ahorro, float MontoAhorro, float DineroGasto, int idEncuesta, int idS611)
        {
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

        public Boolean Insertar_EncuS6()
        {
            Boolean correcto = true;
            S6_Ingresos ingresos = new S6_Ingresos(this.ApoyoEstado, this.CantidadApoyo, this.Remesas, this.CantidadRemesas, this.Deuda, this.DineroDeuda, this.TiempoPagoDeuda, this.IngresoTotal, this.CubreGastos, this.Ahorro, this.MontoAhorro, this.DineroGasto, this.Encuestas_idEncuestas, this.S611_Ingre_idS611_Ingre);
            ingresos.InsertarS();
            this.errores = ingresos.errores;
            if (errores.Count > 0)
            {
                correcto = false;
            }
            return correcto;            
        }

        public void verificarDatos()
        {
            if (this.ApoyoEstado.Equals("null"))
            {
                Error error = new Error("Debe seleccionar datos de la pregunta 1", 5000, 1);
                errores.Add(error);
            }
            if (this.CantidadApoyo.Equals(0) && this.ApoyoEstado.Equals("Si"))
            {
                Error error = new Error("Debe ingresar la cantidad de apoyo en la pregunta 1", 5000, 101);
                errores.Add(error);
            }
            if (this.Remesas.Equals("null"))
            {
                Error error = new Error("Debe seleccionar datos de la pregunta 2", 5000, 2);
                errores.Add(error);
            }
            if (this.CantidadRemesas.Equals(0) && this.Remesas.Equals("Si"))
            {
                Error error = new Error("Debe ingresar la cantidad de remesas en la pregunta 2", 5000, 201);
                errores.Add(error);
            }
            if (this.Deuda.Equals("null"))
            {
                Error error = new Error("Debe seleccionar datos de la pregunta 3", 5000, 3);
                errores.Add(error);
            }
            if (this.Deuda.Equals("Si") &&  this.DineroDeuda.Equals(0))
            {
                Error error = new Error("Debe ingresar la cantidad de las deudas en la pregunta 4", 5000, 4);
                errores.Add(error);
            }
            if (this.Deuda.Equals("Si") && this.TiempoPagoDeuda.Equals(""))
            {
                Error error = new Error("Debe seleccionar datos de la pregunta 5", 5000, 5);
                errores.Add(error);
            }
            if (this.IngresoTotal.Equals(0))
            {
                Error error = new Error("Debe ingresar el ingreso total de la pregunta 6", 5000, 6);
                errores.Add(error);
            }
            if (this.CubreGastos.Equals(""))
            {
                Error error = new Error("Debe seleccionar datos de la pregunta 7", 5000, 7);
                errores.Add(error);
            }
            if (this.CubreGastos.Equals("Si") && this.Ahorro.Equals("null"))
            {
                Error error = new Error("Debe seleccionar datos de la pregunta 8", 5000, 8);
                errores.Add(error); 
            }
            if (this.CubreGastos.Equals("No") && this.DineroGasto.Equals(0))
            {
                Error error = new Error("Debe ingresar la cantidad en la pregunta 10", 5000, 10);
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
