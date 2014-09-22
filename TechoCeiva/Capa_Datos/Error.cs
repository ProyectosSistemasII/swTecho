using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa_Datos
{
    public class Error
    {
        public int tipoError { get; set; }
        public string mensaje { get; set; }

        public Error(string tabla, int Numero)
        {
            switch (Numero)
            {
                case 0:
                    this.tipoError = 1;
                    this.mensaje = "No se ha encontrado el registro en la tabla: " + tabla;
                    break;
                case 1:
                    this.tipoError = 1;
                    this.mensaje = "No es posible encontrar los datos de conexión.";
                    break;
                case 2:
                    this.tipoError = 1;
                    this.mensaje = "El siguiente campo no se ha rellenado correctamente: " + tabla;
                    break;
                case 3:
                    this.tipoError = 1;
                    this.mensaje = "Las contraseñas ingresadas no coinciden.";
                    break;
                case 4:
                    this.tipoError = 1;
                    this.mensaje = "El usuario ya existe en la base de datos.";
                    break;
                case 41:
                    this.tipoError = 1;
                    this.mensaje = "El Usuario no existe, Verifique sus datos e Intente de Nuevo";
                    break;
                case 5:
                    this.tipoError = 1;
                    this.mensaje = "La contraseña es incorrecta para el Usuario: "+tabla;
                    break;
                case 1146:
                    this.tipoError = 1;
                    this.mensaje = "La base de datos ha sido modificada, hace falta la siguiente tabla: "+ tabla;
                    break;
            }
        }
    
    }
}
