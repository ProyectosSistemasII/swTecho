using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MySql.Data.MySqlClient;
using System.Data;
using System.Collections.ObjectModel;

namespace Capa_Datos
{
    public class _DetalleSalida
    {
        public int idDetalleSalida { get; set; }
        public int Cantidad { get; set; }
        public int Alimentos_idAlimentos { get; set; }
        public Boolean Activo { get; set; }
        public int Salida_idSalida { get; set; }
        public List<Error> _errores { get; set; }

        private static ConexionBD _datos = new ConexionBD();
        private static MySqlConnection _conexion = ConexionBD.conexion;

        public _DetalleSalida()
        {
            this.idDetalleSalida = 0;
            this.Cantidad = 0;
            this.Alimentos_idAlimentos = 0;
            this.Activo = true;
            this.Salida_idSalida = 0;
        }

        public _DetalleSalida(int idDetalle, int cantidad, int idAlimentos, Boolean activo, int idSalida)
        {
            this.idDetalleSalida = idDetalle;
            this.Cantidad = cantidad;
            this.Alimentos_idAlimentos = idAlimentos;
            this.Activo = activo;
            this.Salida_idSalida = idSalida;
        }

        public List<_DetalleSalida> _Obtener_D()
        {
            string query = "Select * from DetalleSalida where activo = 1";
            List<_DetalleSalida> lista = new List<_DetalleSalida>();

            MySqlCommand _comando = new MySqlCommand(query, _conexion);
            _comando.CommandTimeout = 12280;
            DataSet _ds = new DataSet();
            MySqlDataAdapter adapter = new MySqlDataAdapter();
            adapter.SelectCommand = _comando;
            adapter.Fill(_ds);
            DataTable _tabla = new DataTable();
            _tabla = _ds.Tables[0];

            for (int i = 0; i < _tabla.Rows.Count; i++)
            {
                DataRow _row = _tabla.Rows[i];
                _DetalleSalida detalleSalida = new _DetalleSalida(Convert.ToInt32(_row["idDetalleSalida"]), Convert.ToInt32(_row["Cantidad"]), Convert.ToInt32(_row["Alimentos_idAlimentos"]), Convert.ToBoolean(_row["Activo"]), Convert.ToInt32(_row["Salida_idSalida"]));
                lista.Add(detalleSalida);
            }
            return lista;
        }

        public void insertarDetalle(List<_Insumos> listado, int idSalida)
        {
            _conexion.Open();

            MySqlTransaction transaction = _conexion.BeginTransaction(System.Data.IsolationLevel.ReadCommitted);
            MySqlCommand comando = _conexion.CreateCommand();

            try
            {
                foreach (_Insumos Insumos in listado)
                {
                    comando.CommandText = "INSERT INTO DetalleSalida (Cantidad, Alimentos_idAlimentos,Activo, Salida_idSalida) VALUES (@Cantidad, @idAlimentos, @activo, @idSalida)";
                    comando.Parameters.AddWithValue("@Cantidad", Cantidad);
                    comando.Parameters.AddWithValue("@idAlimentos", 0);
                    comando.Parameters.AddWithValue("@activo", true);
                    comando.Parameters.AddWithValue("@idSalida", 0);
                }
                transaction.Commit();
            }
            catch (Exception e)
            {
                transaction.Rollback();
            }
            finally
            {
                comando.Dispose();
                transaction.Dispose();
            }
        }
    }
}

