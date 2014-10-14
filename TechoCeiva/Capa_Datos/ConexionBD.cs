using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace Capa_Datos
{
    public class ConexionBD
    {
        public static String ConexionDireccion =
           "Server=localhost;" +
           "Database=swtecho;" +
           "UID=root;" +
           "Password=karen123;";
        //public static String ConexionDireccion = 
            //"Server=" + Properties.Settings.Default.server + ";" + 
            //"Database=" + Properties.Settings.Default.database + ";" + 
            //"UID=" + Properties.Settings.Default.user + ";" + 
            //"Password=" + Properties.Settings.Default.password + ";";
        public static MySqlConnection conexion = new MySqlConnection(ConexionDireccion);

        public static void modificarParamentrosServer(String server, String database, String user, String password)
        {
            Properties.Settings.Default.server = server;
            Properties.Settings.Default.database = database;
            Properties.Settings.Default.user = user;
            Properties.Settings.Default.password = password;
            Properties.Settings.Default.Save();
        }

        public static String conConexion()
        {
            try
            {
                MySqlConnection conexion = new MySqlConnection("Server=" + Properties.Settings.Default.server + ";" +
            "Database=" + Properties.Settings.Default.database + ";" +
            "UID=" + Properties.Settings.Default.user + ";" +
            "Password=" + Properties.Settings.Default.password + ";");
                conexion.Open();
                conexion.Close();
                return "Conexion existosa :)";
            }
            catch(MySqlException ex)
            {
                return "No se pudo establecer conexion :(";
            }
        }

        public static String getServer()
        {
            return Properties.Settings.Default.server;
        }

        public static String getDatabase()
        {
            return Properties.Settings.Default.database;
        }

        public static String getUser()
        {
            return Properties.Settings.Default.user;
        }

        public static String getPassword()
        {
            return Properties.Settings.Default.password;
        }
    }
}
