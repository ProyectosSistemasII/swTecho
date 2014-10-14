using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MySql.Data.MySqlClient;

namespace Capa_Datos
{
    public class TransEncuesta
    {
        public MySqlTransaction tran { get; set; }

        public TransEncuesta()
        {
            this.tran = null;
        }


        private static ConexionBD datos = new ConexionBD();
        private static MySqlConnection conex = ConexionBD.conexion;
        MySqlCommand comando = new MySqlCommand();

        public Boolean IniciarTransaccion()
        {
            try
            {
                comando.Connection = conex;
                comando.Connection.Open();
                tran = comando.Connection.BeginTransaction();
                comando.Transaction = tran;
                return true;
            }
            catch (Exception ex)
            {
                comando.Connection.Close();
                return false;
            }
        }

        public Boolean TerminarTransaccion()
        {
            try
            {
                tran.Commit();
                comando.Connection.Close();
                return false;
            }
            catch (Exception ex)
            {
                return true;
            }
        }

        public void Deshacer()
        {
            tran.Rollback();
            comando.Connection.Close();
        }
    }
}
