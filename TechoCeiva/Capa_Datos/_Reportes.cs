using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MySql.Data.MySqlClient;
using System.Data;
using System.Windows.Forms;

namespace Capa_Datos
{
    public class _Reportes
    {
        public _Reportes()
        {
        
        }

        private static ConexionBD _datos = new ConexionBD();
        private static MySqlConnection _conexion = ConexionBD.conexion;

        public DataTable Generar()
        {
            try
            {
                string consulta = "Select NombreD from Departamento";
                MySqlCommand comando = new MySqlCommand(consulta, _conexion);
                comando.Connection.Open();
                comando.ExecuteNonQuery();
                comando.Connection.Close();

                DataSet ds = new DataSet();
                MySqlDataAdapter da = new MySqlDataAdapter(comando);
                da.Fill(ds);

                return ds.Tables[0];
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se ha podido generar reporte", "Error",  MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }
    }
}
