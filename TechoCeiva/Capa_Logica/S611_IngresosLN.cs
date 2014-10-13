using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Capa_Datos;

namespace Capa_Logica
{
    public class S611_IngresosLN : S611_Ingresos
    {
        public S611_IngresosLN()
        {
            this.RecorteGastos = false;
            this.Prestamo = false;
            this.VentaMaterial = false;
            this.TrabajoOcasional = false;
            this.Ahorros = false;
            this.AyudaFamiliar = false;
            this.ApoyoEstado = false;
            this.Otro = false;
            this.Especificar = "";
            this.NSNR = false;
        }

        public S611_IngresosLN(Boolean RecorteGastos, Boolean Prestamo, Boolean VentaMaterial, Boolean TrabajoOcasional, Boolean Ahorros, Boolean AyudaFamiliar, Boolean ApoyoEstado, Boolean Otro, String Especificar, Boolean NSNR)
        {
            this.RecorteGastos = RecorteGastos;
            this.Prestamo = Prestamo;
            this.VentaMaterial = VentaMaterial;
            this.TrabajoOcasional = TrabajoOcasional;
            this.Ahorros = Ahorros;
            this.AyudaFamiliar = AyudaFamiliar;
            this.ApoyoEstado = ApoyoEstado;
            this.Otro = Otro;
            this.Especificar = Especificar;
            this.NSNR = NSNR;
            this.errores = new List<Error>();
        }

        public Boolean Insertar_EncuS611()
        {
            Boolean correcto = true;
            this.verificarDatos();
            if (errores.Count > 0)
            {
                return false;
            }
            else
            {
                S611_Ingresos ingresos = new S611_Ingresos(RecorteGastos, Prestamo, VentaMaterial, TrabajoOcasional, Ahorros, AyudaFamiliar, ApoyoEstado, Otro, Especificar, NSNR);
                ingresos.InsertarS611();
                this.errores = ingresos.errores;
                if (errores.Count > 0)
                {
                    correcto = false;
                }
                return correcto;
            }
        }

        public string obtenerError()
        {
            Error error = errores[0];
            return error.mensaje;
        }

        public void verificarDatos()
        {
            if (this.Otro == true && this.Especificar.Equals(""))
            {
                Error error = new Error("Debe especificar en la pregunta 11", 5000, 1);
                errores.Add(error);
            }
        }

        public void Validar11()
        {
            if (this.RecorteGastos == false && this.Prestamo == false && this.VentaMaterial == false && this.TrabajoOcasional == false && this.Ahorros == false && this.AyudaFamiliar == false && this.ApoyoEstado == false && this.Otro == false && this.NSNR == false)
            {
                Error error = new Error("Debe especificar en la pregunta 11", 5000, 1);
                errores.Add(error);
            }
        }
    }
}
