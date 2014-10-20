using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MySql.Data.MySqlClient;
using System.Data;
using System.Collections.ObjectModel;

namespace Capa_Datos
{
    public class _DetallePrestamo
    {
        public int idDetallePrestamo { get; set; }
        public int Herramientas_idHerramientas { get; set; }
        public int Prestamo_idDetallePrestamo { get; set; }
        public int CantidadBuenEtsado { get; set; }
        public int CantidadMalEstado { get; set; }
        public int CantidadPerdida { get; set; }
        public int Activo { get; set; }
        public DateTime Devolucion { get; set; }

        public List<Error> _errores { get; set; }

        private static ConexionBD _datos = new ConexionBD();
        private static MySqlConnection _conexion = ConexionBD.conexion;

        public _DetallePrestamo()
        {
            this.idDetallePrestamo = 0;
            this.Herramientas_idHerramientas = 0;
            this.Prestamo_idDetallePrestamo = 0;
            this.CantidadBuenEtsado = 0;
            this.CantidadMalEstado = 0;
            this.CantidadPerdida = 0;
            this.Activo = 0;
            this.Devolucion = DateTime.MaxValue;
        }

        public _DetallePrestamo(int idDetalle, int idHerramienta, int idDetallePrestamo, int cantidadBuena, int cantidadMala, int cantidadPerdida, int activo)
        {
            this.idDetallePrestamo = idDetalle;
            this.Herramientas_idHerramientas = idHerramienta;
            this.Prestamo_idDetallePrestamo = idDetallePrestamo;
            this.CantidadBuenEtsado = cantidadBuena;
            this.CantidadMalEstado = cantidadMala;
            this.CantidadPerdida = cantidadPerdida;
            this.Activo = activo;
            //this.Devolucion = DateTime.MaxValue;
        }

        public List<_DetallePrestamo> obtenerDetalles()
        {
            string query = "SELECT * FROM DetallePrestamo WHERE Activo = 1";
            List<_DetallePrestamo> listaPrestamos = new List<_DetallePrestamo>();

            MySqlCommand _comando = new MySqlCommand(query, _conexion);
            _comando.CommandTimeout = 12280;
            DataSet _ds = new DataSet();
            MySqlDataAdapter _adapter = new MySqlDataAdapter();
            _adapter.SelectCommand = _comando;
            _adapter.Fill(_ds);
            DataTable _tabla = new DataTable();
            _tabla = _ds.Tables[0];

            for (int i = 0; i < _tabla.Rows.Count; i++)
            {
                DataRow _row = _tabla.Rows[i];
                //_DetallePrestamo detallePrestamo = new _DetallePrestamo(Convert.ToInt32(_row["idDetallePrestamo"]), Convert.ToInt32(_row["Herramientas_idHerramientas"]), Convert.ToInt32(_row["Prestamo_idPrestamo"]), Convert.ToInt32(_row["CantidadBuenEstado"]), Convert.ToInt32(_row["CantidadMalEstado"]), Convert.ToInt32(_row["CantidadPerdida"]), Convert.ToInt32(_row["Activo"]), Convert.ToDateTime(_row["FechaDevolucion"]));
                _DetallePrestamo detallePrestamo = new _DetallePrestamo(Convert.ToInt32(_row["idDetallePrestamo"]), Convert.ToInt32(_row["Herramientas_idHerramientas"]), Convert.ToInt32(_row["Prestamo_idPrestamo"]), Convert.ToInt32(_row["CantidadBuenEstado"]), Convert.ToInt32(_row["CantidadMalEstado"]), Convert.ToInt32(_row["CantidadPerdida"]), Convert.ToInt32(_row["Activo"]));
                listaPrestamos.Add(detallePrestamo);
            }

            return listaPrestamos;
        }

        public void insertarDetalle(List<_Herramientas> listado, int idPrestamo)
        {
            _conexion.Open();

            MySqlTransaction transaction = _conexion.BeginTransaction(System.Data.IsolationLevel.ReadCommitted);
            MySqlCommand comando = _conexion.CreateCommand();

            try
            {
                foreach (_Herramientas herramienta in listado)
                {
                    comando.CommandText = "insert into detalleprestamo (Herramientas_idHerramientas, Prestamo_idPrestamo,"+
                                                                        "CantidadBuenEstado, CantidadMalEstado, CantidadPerdida,"+
                                                                        "Activo, FechaDevolucion)"+
                                                                 "values(@idHerramienta, @idPrestamo, @buenEstado, @malEstado,"+
                                                                        "@perdidas, @activo, @fechaDevolucion)";
                    
                    comando.Parameters.AddWithValue("@idHerramienta",herramienta.idHerramientas);
                    comando.Parameters.AddWithValue("@idPrestamo", idPrestamo);
                    comando.Parameters.AddWithValue("@buenEstado", 0);
                    comando.Parameters.AddWithValue("@malEstado", 0);
                    comando.Parameters.AddWithValue("@perdidas", 0);
                    comando.Parameters.AddWithValue("@activo", 1);
                    comando.Parameters.AddWithValue("@fechaDevolucion", this.Devolucion);
                    comando.ExecuteNonQuery();
                    comando.Parameters.Clear();
                }
                transaction.Commit();
            }
            catch (Exception e)
            {
                transaction.Rollback();
                comando.Dispose();
                transaction.Dispose();
                _conexion.Close();
            }
            finally
            {
                comando.Dispose();
                transaction.Dispose();
                _conexion.Close();
            }
        }

        public List<_DetallePrestamo> buscarDetallesPor(int idPrestamo)
        {
            string query = "SELECT * FROM DetallePrestamo WHERE Activo = 1 AND Prestamo_idPrestamo = "+ idPrestamo;
            List<_DetallePrestamo> listaDetallesEspecificos = new List<_DetallePrestamo>();

            MySqlCommand _comando = new MySqlCommand(query, _conexion);
            _comando.CommandTimeout = 12280;
            DataSet _ds = new DataSet();
            MySqlDataAdapter _adapter = new MySqlDataAdapter();
            _adapter.SelectCommand = _comando;
            _adapter.Fill(_ds);
            DataTable _tabla = new DataTable();
            _tabla = _ds.Tables[0];

            for (int i = 0; i < _tabla.Rows.Count; i++)
            {
                DataRow _row = _tabla.Rows[i];
                _DetallePrestamo detallePrestamo = new _DetallePrestamo(Convert.ToInt32(_row["idDetallePrestamo"]), Convert.ToInt32(_row["Herramientas_idHerramientas"]), Convert.ToInt32(_row["Prestamo_idPrestamo"]), Convert.ToInt32(_row["CantidadBuenEstado"]), Convert.ToInt32(_row["CantidadMalEstado"]), Convert.ToInt32(_row["CantidadPerdida"]), Convert.ToInt32(_row["Activo"]));
                listaDetallesEspecificos.Add(detallePrestamo);
            }

            return listaDetallesEspecificos;
        }
    }
}
