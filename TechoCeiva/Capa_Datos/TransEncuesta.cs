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

        /*
         * Inicia la transaccion de la encuesta
         * Recibe: ---
         * Devuelve: true si inicio la transaccion, false si hay problema de conexion
         */ 
        public Boolean IniciarTransaccion()
        {
            try
            {
                comando.Connection = conex;
                comando.Connection.Open();
                tran = comando.Connection.BeginTransaction(); // inicia transaccion
                comando.Transaction = tran;
                return true;
            }
            catch (Exception ex)
            {
                comando.Connection.Close();
                return false;
            }
        }

        /*
         * Termina la transaccion de la encuesta
         * Recibe: ---
         * Devuelve: false si termino la transaccion, true si hay problema de conexion
         */
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

        /*
         * Rollback de la transaccion de la encuesta
         * Recibe: ---
         * Devuelve: ---
         */
        public void Deshacer()
        {
            tran.Rollback();
            comando.Connection.Close();
        }
    }
}
