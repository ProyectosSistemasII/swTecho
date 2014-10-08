using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using Capa_Datos;

namespace Capa_Logica
{
    public class SettingsSistema
    {
        ArrayList errores = new ArrayList();        
        //metodo que obtiene los parametros del servidor de base de datos que se tiene actualemte
        //[0] server
        //[1] database
        //[2] user
        //[3] password
        public static ArrayList getParametros()
        {
            ArrayList paramentros = new ArrayList();
            paramentros.Add(ConexionBD.getServer());
            paramentros.Add(ConexionBD.getDatabase());
            paramentros.Add(ConexionBD.getUser());
            paramentros.Add(ConexionBD.getPassword());
            return paramentros;
        }
        public static String saveParametros(String server, String database, String user, String password)
        {
            ConexionBD.modificarParamentrosServer(server, database, user, password);
            return ConexionBD.conConexion();
        }
    }
}
