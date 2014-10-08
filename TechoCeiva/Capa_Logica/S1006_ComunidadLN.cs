using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Capa_Datos;
using System.Text.RegularExpressions;

namespace Capa_Logica
{
    public class S1006_ComunidadLN : S1006_Comunidad
    {
        public S1006_ComunidadLN()
        {
           
            this.GrupoPolitico = false;
            this.GrupoDeportivo = false;
            this.GrupoReligioso = false;
            this.GrupoJovenes = false;
            this.GrupoMujeres = false;
            this.OrganizacionComunitaria = false;
            this.MesaTrabajo = false;
            this.Otros = false;
            this.Especificar = "";
            this.NSNR = false;            
        }
        public S1006_ComunidadLN( Boolean Politico, Boolean Deportivo, Boolean Religioso, Boolean Jovenes, Boolean Mujeres, Boolean OrgaComunitaria, Boolean MesaTrabajo, Boolean Otros, String Especificar, Boolean NSNR)
        {
            this.GrupoPolitico = Politico;
            this.GrupoDeportivo = Deportivo;
            this.GrupoReligioso = Religioso;
            this.GrupoJovenes = Jovenes;
            this.GrupoMujeres = Mujeres;
            this.OrganizacionComunitaria = OrgaComunitaria;
            this.MesaTrabajo = MesaTrabajo;
            this.Otros = Otros;
            this.Especificar = Especificar;
            this.NSNR = NSNR;
            this.errores = new List<Error>();
        }
        public Boolean Insertar_EncuS1006()
        {
            Boolean correcto = true;
            //verificar sintaxis de los datos y comprobar errores antes de ser enviado a la capa de datos
            this.verificarDatos();
            if (errores.Count > 0)
            {
                return false;
            }
            // se ingresa los datos a la capa de datos            
            S1006_Comunidad comunidad = new S1006_Comunidad(0, this.GrupoPolitico, this.GrupoDeportivo, this.GrupoReligioso, this.GrupoJovenes,this.GrupoMujeres,this.OrganizacionComunitaria,this.MesaTrabajo,this.Otros, this.Especificar, this.NSNR);
            comunidad.InsertarS1006();
            this.errores = comunidad.errores;
            //Comprobar errores para la capa de datos
            if (errores.Count > 0)
            {
                return false;
            }
            else
            {
                this.idS1006_com= comunidad.Obtener_Ultima_EncS1006();

            }
            return correcto;
        }

        public void verificarDatos()
        {
            if (this.GrupoPolitico == false && this.GrupoDeportivo == false && this.GrupoReligioso == false && this.GrupoJovenes == false && this.GrupoMujeres == false && this.OrganizacionComunitaria == false && this.MesaTrabajo == false && this.Otros == false && this.NSNR == false )
            {
                Error error = new Error("Debe marcar la opcio 'No cuenta con ningun otros' o NS/RN en la pregunta 6", 5000, 6);
                errores.Add(error);
            }
            string expresion_Texto = @"^[a-zA-Z]+\s*[a-zA-Z]*$";
            Regex regex = new Regex(expresion_Texto);
            if (!regex.IsMatch(this.Especificar) && this.Otros != true)
            {
                Error error = new Error("Debe Especificar el articulo que no se encuenta en la lista", 5000, 9);
                errores.Add(error);
            }
        }

        public Error obtenerError()
        {
            Error error = errores[0];
            return error;
        }
    }

}
