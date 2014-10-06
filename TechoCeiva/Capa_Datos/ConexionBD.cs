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

        public static String ConexionDireccion = "Server=localhost;" + "Database=swtecho;" + "UID=root;" + "Password=12345;";
            public static MySqlConnection conexion = new MySqlConnection(ConexionDireccion);

        
    }
}
