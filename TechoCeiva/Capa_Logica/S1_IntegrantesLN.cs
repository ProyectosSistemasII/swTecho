using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Capa_Datos;

namespace Capa_Logica
{
    public class S1_IntegrantesLN : S1_Integrantes
    {
        public S1_IntegrantesLN()
        {
            this.CodigoS1 = 0;
            this.NombreCompleto = "";
            this.ApellidosCompleto = "";
            this.FechaNac = "";
            this.Genero = "";
            this.Embarazo = "";
            this.Encuestas_idEncuestas = 0;
        }

        public S1_IntegrantesLN(int CodigoS1, string NombreCompleto, string ApellidosCompleto, string FechaNac, string Genero,
            string Embarazo, int Encuestas_idEncuestas)
        {
            this.CodigoS1 = CodigoS1;
            this.NombreCompleto = NombreCompleto;
            this.ApellidosCompleto = ApellidosCompleto;
            this.FechaNac = FechaNac;
            this.Genero = Genero;
            this.Embarazo = Embarazo;
            this.Encuestas_idEncuestas = Encuestas_idEncuestas;
            this.errores = new List<Error>();
        }

        public Boolean Insertar_EncuS1()
        {
            Boolean correcto = true;
            S1_Integrantes integrantes = new S1_Integrantes(CodigoS1, NombreCompleto, ApellidosCompleto, FechaNac, Genero, Embarazo, Encuestas_idEncuestas);
            integrantes.InsertarS1();
            if (errores.Count > 0)
            {
                return correcto = false;
            }
            return correcto;
        }

        public void verificarDatos(int filas)
        {
            if (this.NombreCompleto == "")
            {
                Error error = new Error("Nombres en fila " + filas.ToString(), 5000, 1);
                errores.Add(error);
            }
            if (this.ApellidosCompleto == "")
            {
                Error error = new Error("Apellidos en fila " + filas.ToString(), 5000, 1);
                errores.Add(error);
            }
            if (this.FechaNac == "")
            {
                Error error = new Error("Fecha nacimiento en fila " + filas.ToString(), 5000, 1);
                errores.Add(error);
            }
        }

        public Boolean validacion(int CodigoS1, string NombreCompleto, string ApellidosCompleto, string FechaNac, string Genero,
            string Embarazo, int Encuestas_idEncuestas, int filas)
        {
            this.CodigoS1 = CodigoS1;
            this.NombreCompleto = NombreCompleto;
            this.ApellidosCompleto = ApellidosCompleto;
            this.FechaNac = FechaNac;
            this.Genero = Genero;
            this.Embarazo = Embarazo;
            this.Encuestas_idEncuestas = Encuestas_idEncuestas;
            this.errores = new List<Error>();
            this.verificarDatos(filas + 1);
            if (errores.Count > 0)
            {
                return false;
            }
            return true;
        }

        public string obtenerError()
        {
            Error error = errores[0];
            return error.mensaje;
        }
    }
}
