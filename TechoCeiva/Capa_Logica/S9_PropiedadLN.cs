using Capa_Datos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Capa_Logica
{
    public class S9_PropiedadLN : S9_Propiedad
    {
        public S9_PropiedadLN()
        {
            this.idS9_Prop = 0;
            this.CodigoS9 = 0;
            this.Propio = "";
            this.Propietario = "";
            this.OtroPropietario = "";
            this.TipoPropiedad = "";
            this.OtroTipoPropiedad = "";
            this.PropietarioTerreno = "";
            this.TelefonoPropietarioTerreno = "";
            this.NSNR = "";
            this.OtraPropiedad = "";
            this.OtraPropiedadA = "";
            this.OtraPropiedadB = "";
            this.OtraPropiedadC = "";
            this.idEncuestas = 0;
        }
        public Boolean  Insertar_EncS9( int CodigoS9, String Propio, String Propietario, String OtroPropietario, String TipoPropiedad, String OtroTipoPropiedad, String PropietarioTerreno, String TelefonoPropietarioTerreno, String NSNR, String OtraPropiedad, String PropiedadA, String PropiedadB, String PropiedadC, int idEncuestas)
        {
            Boolean correcto = true;
            S9_Propiedad Propiedad = new S9_Propiedad(0, CodigoS9, Propio, Propietario, OtroPropietario, TipoPropiedad, OtroTipoPropiedad, PropietarioTerreno, TelefonoPropietarioTerreno, NSNR, OtraPropiedad, PropiedadA, PropiedadB, PropiedadC, idEncuestas);
            this.idS9_Prop = Propiedad.idS9_Prop;
            this.CodigoS9 = Propiedad.CodigoS9;
            this.Propio = Propiedad.Propio;
            this.Propietario = Propiedad.Propietario;
            this.OtroPropietario = Propiedad.OtroPropietario;
            this.TipoPropiedad = Propiedad.TipoPropiedad;
            this.OtroTipoPropiedad = Propiedad.OtroTipoPropiedad;
            this.PropietarioTerreno = Propiedad.PropietarioTerreno;
            this.TelefonoPropietarioTerreno = Propiedad.TelefonoPropietarioTerreno;
            this.NSNR = Propiedad.NSNR;
            this.OtraPropiedad = Propiedad.OtraPropiedad;
            this.OtraPropiedadA = Propiedad.OtraPropiedadA;
            this.OtraPropiedadB = Propiedad.OtraPropiedadB;
            this.OtraPropiedadC = Propiedad.OtraPropiedadC;
            this.idEncuestas = Propiedad.idEncuestas;
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
