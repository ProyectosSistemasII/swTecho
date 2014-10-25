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

        // setear las variables
        public S4_SaludLN(int CodigoS4, string AsistenciaSalud, string NombreCentro, string UbicacionCentro, Boolean ProblemaSalud, string EspecificarProblemaSalud, Boolean Accidente, string TipoAccidente,
            string Seguro, string Discapacidad, string OtraDiscapacidad, string OrigenDiscapacidad, string OtroOrigen, int Encuestas_idEncuestas)
        {
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
        }

        // validacion de los campos de la seccion 4
        public Boolean validacion(int CodigoS4, string AsistenciaSalud, string NombreCentro, string UbicacionCentro, Boolean ProblemaSalud, string EspecificarProblemaSalud, Boolean Accidente, string TipoAccidente,
            string Seguro, string Discapacidad, string OtraDiscapacidad, string OrigenDiscapacidad, string OtroOrigen, int Encuestas_idEncuestas, int filas)
        {
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
            this.verificarDatos(filas);
            if (errores.Count > 0)
            {
                return false; // retorna falso si hay error
            }
            return true;
        }

        // inserta la seccion 4 en la base de datos
        public Boolean Insertar_EncuS4()
        {
            Boolean correcto = true;
            S4_Salud salud = new S4_Salud(CodigoS4, AsistenciaSalud, NombreCentro, UbicacionCentro, ProblemaSalud, EspecificarProblemaSalud, Accidente, TipoAccidente, Seguro, Discapacidad, OtraDiscapacidad, OrigenDiscapacidad, OtroOrigen, Encuestas_idEncuestas);
            salud.InsertarS4();
            this.errores = salud.errores;
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

        // verifica los campos de la encuesta validos
        public void verificarDatos(int filas)
        {
            if (this.AsistenciaSalud.Equals("Nunca") || this.AsistenciaSalud.Equals("NS/NR"))
            {
                this.NombreCentro = "";
                this.UbicacionCentro = "";
            }
            else if (this.NombreCentro.Equals(""))
            {
                Error error = new Error("Colocar el nombre del centro de salud en la fila " + filas.ToString(), 5000, 1);
                errores.Add(error);
            }
            if (this.ProblemaSalud == true && this.EspecificarProblemaSalud == "")
            {
                Error error = new Error("Debe especificar el problema de salud o enfermedad en la fila " + filas.ToString(), 5000, 1);
                errores.Add(error);
            }
            if (this.Accidente == true && this.TipoAccidente == "")
            {
                Error error = new Error("Debe especificar el accidente en la fila " + filas.ToString(), 5000, 1);
                errores.Add(error);
            }
            if (this.Seguro == "")
            {
                Error error = new Error("Colocar el tipo de seguro de salud en la fila " + filas.ToString(), 5000, 1);
                errores.Add(error);
            }
            if (this.Discapacidad == "")
            {
                Error error = new Error("Colocar el tipo de discapacidad en la fila " + filas.ToString(), 5000, 1);
                errores.Add(error);
            }
            if (this.Discapacidad == "Otra (especificar)" && this.OtraDiscapacidad == "")
            {
                Error error = new Error("Debe especificar el tipo de discapacidad en la fila " + filas.ToString(), 5000, 1);
                errores.Add(error);
            }
            if (this.Discapacidad.Equals("No tiene ninguna de estas condiciones de larga duración") || this.Discapacidad.Equals("NS/NR"))
            {
                this.OrigenDiscapacidad = "";
            }
            else if (this.OrigenDiscapacidad.Equals(""))
            {
                Error error = new Error("Colocar el origen de discapacidad en la fila " + filas.ToString(), 5000, 1);
                errores.Add(error);
            }
            if (this.OrigenDiscapacidad == "Otra (especificar)" && this.OtroOrigen == "")
            {
                Error error = new Error("Debe especificar el origen de discapacidad en la fila " + filas.ToString(), 5000, 1);
                errores.Add(error);
            }
        }
    }
}
