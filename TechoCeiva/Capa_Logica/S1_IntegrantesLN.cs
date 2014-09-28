using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Capa_Datos;

namespace Capa_Logica
{

    class S1_IntegrantesLN : S1_Integrantes
    {
        public S1_IntegrantesLN()
        {
            this.CodigoS1 = 0;
            this.NombreCompleto = "";
            this.ApellidosCompleto = "";
            this.FechaNacFuturoHijo = DateTime.Today;
            this.Genero = "";
            this.Embarazo = "";
            this.Encuestas_idEncuestas = 0;
        }
        public Boolean Insertar_EncuS1(int CodigoS1, string NombreCompleto, string ApellidosCompleto, DateTime FechaNacFuturoHijo, string Genero,
            string Embarazo, int Encuestas_idEncuestas)
        {
            Boolean correcto = true;
            S1_Integrantes integrantes = new S1_Integrantes(CodigoS1,NombreCompleto, ApellidosCompleto, FechaNacFuturoHijo, Genero, Embarazo, 
                        Encuestas_idEncuestas);
            this.CodigoS1 = CodigoS1;
            this.NombreCompleto = NombreCompleto;
            this.ApellidosCompleto = ApellidosCompleto;
            this.FechaNacFuturoHijo = FechaNacFuturoHijo;
            this.Genero = Genero;
            this.Embarazo = Embarazo;
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
