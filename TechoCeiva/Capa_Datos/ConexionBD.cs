using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace Capa_Datos
{
    class ConexionBD
    {
        public static String ConexionDireccion = "Server=localhost;" + "Database=techo;" + "UID=root;" + "Password=1303;";
        public static MySqlConnection conexion = new MySqlConnection(ConexionDireccion);        
    }
}
