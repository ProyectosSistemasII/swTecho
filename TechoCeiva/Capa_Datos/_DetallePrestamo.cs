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
        public int Prestamo_idPrestamo { get; set; }
        public int CantidadPrestada { get; set; }
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
            this.Prestamo_idPrestamo = 0;
            this.CantidadPrestada = 0;
            this.CantidadBuenEtsado = 0;
            this.CantidadMalEstado = 0;
            this.CantidadPerdida = 0;
            this.Activo = 0;
            this.Devolucion = DateTime.MaxValue;
        }

        public _DetallePrestamo(int idDetalle, int idHerramienta, int idPrestamo, int cantidadPrestada, int cantidadBuena, int cantidadMala, int cantidadPerdida, int activo)
        {
            this.idDetallePrestamo = idDetalle;
            this.Herramientas_idHerramientas = idHerramienta;
            this.Prestamo_idPrestamo = idPrestamo;
            this.CantidadPrestada = cantidadPrestada;
            this.CantidadBuenEtsado = cantidadBuena;
            this.CantidadMalEstado = cantidadMala;
            this.CantidadPerdida = cantidadPerdida;
            this.Activo = activo;
            //this.Devolucion = DateTime.MaxValue;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
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
                _DetallePrestamo detallePrestamo = new _DetallePrestamo(Convert.ToInt32(_row["idDetallePrestamo"]), Convert.ToInt32(_row["Herramientas_idHerramientas"]), Convert.ToInt32(_row["Prestamo_idPrestamo"]), Convert.ToInt32(_row["CantidadPrestada"]), Convert.ToInt32(_row["CantidadBuenEstado"]), Convert.ToInt32(_row["CantidadMalEstado"]), Convert.ToInt32(_row["CantidadPerdida"]), Convert.ToInt32(_row["Activo"]));
                listaPrestamos.Add(detallePrestamo);
            }

            return listaPrestamos;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="listado"></param>
        /// <param name="idPrestamo"></param>
        public void insertarDetalle(List<_Herramientas> listado, int idPrestamo)
        {
            _conexion.Open();

            MySqlTransaction transaction = _conexion.BeginTransaction(System.Data.IsolationLevel.ReadCommitted);
            MySqlCommand comando = _conexion.CreateCommand();
            MySqlCommand comando2 = _conexion.CreateCommand();

            try
            {
                foreach (_Herramientas herramienta in listado)
                {
                    comando.CommandText = "insert into detalleprestamo (Herramientas_idHerramientas, Prestamo_idPrestamo,"+
                                                                        "CantidadPrestada, CantidadBuenEstado, CantidadMalEstado,"+
                                                                        "CantidadPerdida, Activo, FechaDevolucion)" +
                                                                 "values(@idHerramienta, @idPrestamo, @prestado, @buenEstado,"+
                                                                        "@malEstado, @perdidas, @activo, @fechaDevolucion)";
                    
                    comando.Parameters.AddWithValue("@idHerramienta",herramienta.idHerramientas);
                    comando.Parameters.AddWithValue("@idPrestamo", idPrestamo);
                    comando.Parameters.AddWithValue("@prestado",herramienta.Existencia);
                    comando.Parameters.AddWithValue("@buenEstado", 0);
                    comando.Parameters.AddWithValue("@malEstado", 0);
                    comando.Parameters.AddWithValue("@perdidas", 0);
                    comando.Parameters.AddWithValue("@activo", 1);
                    comando.Parameters.AddWithValue("@fechaDevolucion", this.Devolucion);
                    comando.ExecuteNonQuery();
                    comando.Parameters.Clear();

                    comando2.CommandText = "update herramientas SET Existencia = @nExistencia WHERE idHerramientas = @idH";
                    comando2.Parameters.AddWithValue("@nExistencia", herramienta.nuevaExistencia(herramienta.idHerramientas, herramienta.Existencia));
                    comando2.Parameters.AddWithValue("@idH", herramienta.idHerramientas);
                    comando2.ExecuteNonQuery();
                    comando2.Parameters.Clear();
                }
                transaction.Commit();
            }
            catch (Exception e)
            {
                transaction.Rollback();
                comando.Dispose();
                comando2.Dispose();
                transaction.Dispose();
                _conexion.Close();
            }
            finally
            {
                comando.Dispose();
                comando2.Dispose();
                transaction.Dispose();
                _conexion.Close();
            }
        }



        /// <summary>
        /// 
        /// </summary>
        /// <param name="idPrestamo"></param>
        /// <returns></returns>
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
                _DetallePrestamo detallePrestamo = new _DetallePrestamo(Convert.ToInt32(_row["idDetallePrestamo"]), Convert.ToInt32(_row["Herramientas_idHerramientas"]), Convert.ToInt32(_row["Prestamo_idPrestamo"]), Convert.ToInt32(_row["CantidadPrestada"]), Convert.ToInt32(_row["CantidadBuenEstado"]), Convert.ToInt32(_row["CantidadMalEstado"]), Convert.ToInt32(_row["CantidadPerdida"]), Convert.ToInt32(_row["Activo"]));
                listaDetallesEspecificos.Add(detallePrestamo);
            }
            return listaDetallesEspecificos;
        }




        /// <summary>
        /// 
        /// </summary>
        /// <param name="buenas"></param>
        /// <param name="malas"></param>
        /// <param name="perdidas"></param>
        /// <param name="activo"></param>
        /// <param name="devolucion"></param>
        /// <param name="idDetalle"></param>
        /// <param name="idPrestamo"></param>
        /// <param name="idH"></param>
        public void devolverTodo(int buenas, int malas, int perdidas, int activo, DateTime devolucion, int idDetalle, int idPrestamo, int idH)
        {
                string query = "update DetallePrestamo SET CantidadBuenEstado = @cantidadBuena, CantidadMalEstado = @cantidadMala," +
                                                          "CantidadPerdida = @cantidadPerdida, Activo = @activo," +
                                                          "FechaDevolucion = @fechaDev "+
                                                    "where idDetallePrestamo = @idDetalle";

                string query2 = "update Herramientas SET Existencia = @existencia where idHerramientas = @idH";
                _Herramientas h = new _Herramientas();


                MySqlCommand _comando = new MySqlCommand(query, ConexionBD.conexion);
                MySqlCommand _comando2 = new MySqlCommand(query2, ConexionBD.conexion);

                _comando.Parameters.AddWithValue("@cantidadBuena", buenas);
                _comando.Parameters.AddWithValue("@cantidadMala", malas);
                _comando.Parameters.AddWithValue("@cantidadPerdida", perdidas);
                _comando.Parameters.AddWithValue("@activo", 0);
                _comando.Parameters.AddWithValue("@fechaDev", devolucion);
                _comando.Parameters.AddWithValue("@idDetalle", idDetalle);

                _comando2.Parameters.AddWithValue("@existencia", h.cargarInventario(idH, buenas));
                _comando2.Parameters.AddWithValue("@idH",idH);

                try
                {
                    _comando.Connection.Open();
                    _comando.ExecuteNonQuery();
                    _comando.Connection.Close();

                    _comando2.Connection.Open();
                    _comando2.ExecuteNonQuery();
                    _comando2.Connection.Close();

                    evaluarPrestamo(cantidadRegistros(idPrestamo), idPrestamo);
                }
                catch (MySqlException ex)
                {
                    _comando.Connection.Close();
                    _comando2.Connection.Close();
                    Error _error = new Error(ex.Message + " " + ex.Number, 2);
                    _errores.Add(_error);
                }
        }



        /// <summary>
        /// 
        /// </summary>
        /// <param name="buenas"></param>
        /// <param name="malas"></param>
        /// <param name="perdidas"></param>
        /// <param name="pendintes"></param>
        /// <param name="devolucion"></param>
        /// <param name="idP"></param>
        /// <param name="idH"></param>
        public void devolverParte(int buenas, int malas, int perdidas, int pendintes, DateTime devolucion, int idP, int idH)
        {
                string query = "update DetallePrestamo SET CantidadPrestada = @cantidadPrestada, CantidadBuenEstado = @cantidadBuena," +
                                                          "CantidadMalEstado = @cantidadMala, CantidadPerdida = @cantidadPerdida," +
                                                          "FechaDevolucion = @fechaDev " +
                                                    "where idDetallePrestamo = @idPrestamo";

                string query2 = "update Herramientas SET Existencia = @existencia WHERE idHerramientas = @idH";
                _Herramientas h = new _Herramientas();


                MySqlCommand _comando = new MySqlCommand(query, ConexionBD.conexion);
                MySqlCommand _comando2 = new MySqlCommand(query2, ConexionBD.conexion);

                _comando.Parameters.AddWithValue("@cantidadPrestada",pendintes);
                _comando.Parameters.AddWithValue("@cantidadBuena", buenas);
                _comando.Parameters.AddWithValue("@cantidadMala", malas);
                _comando.Parameters.AddWithValue("@cantidadPerdida", perdidas);
                _comando.Parameters.AddWithValue("@fechaDev", devolucion);
                _comando.Parameters.AddWithValue("@idPrestamo", idP);

                _comando2.Parameters.AddWithValue("@existencia", h.cargarInventario(idH, buenas));
                _comando2.Parameters.AddWithValue("@idH", idH);

                try
                {
                    _comando.Connection.Open();
                    _comando.ExecuteNonQuery();
                    _comando.Connection.Close();

                    _comando2.Connection.Open();
                    _comando2.ExecuteNonQuery();
                    _comando2.Connection.Close();
                }
                catch (MySqlException ex)
                {
                    _comando.Connection.Close();
                    _comando2.Connection.Close();
                    Error _error = new Error(ex.Message + " " + ex.Number, 2);
                    _errores.Add(_error);
                }
        }



        /// <summary>
        /// 
        /// </summary>
        /// <param name="idPrestamo"></param>
        /// <returns></returns>
        private int cantidadRegistros(int idPrestamo)
        {
            string contar = "select count(*) from DetallePrestamo WHERE Activo = 1 AND Prestamo_idPrestamo = " + idPrestamo;
            MySqlCommand comando = new MySqlCommand(contar, _conexion);
            comando.CommandTimeout = 12280;

            comando.Connection.Open();
            int cantidad = Convert.ToInt32(comando.ExecuteScalar());
            comando.Connection.Close();
            return cantidad;
        }



        /// <summary>
        /// 
        /// </summary>
        /// <param name="cantidadRegistros"></param>
        /// <param name="idPrestamo"></param>
        private void evaluarPrestamo(int cantidadRegistros, int idPrestamo)
        {
            if (cantidadRegistros == 0)
            {
                string query = "update Prestamo SET Activo = 0 " +
                                                "WHERE idPrestamo = @idPrestamo";
                MySqlCommand _comando = new MySqlCommand(query, ConexionBD.conexion);
                _comando.Parameters.AddWithValue("@idPrestamo", idPrestamo);

                try
                {
                    _comando.Connection.Open();
                    _comando.ExecuteNonQuery();
                    _comando.Connection.Close();
                }
                catch (MySqlException ex)
                {
                    _comando.Connection.Close();
                    Error _error = new Error(ex.Message + " " + ex.Number, 2);
                    _errores.Add(_error);
                }
            }
        }
    }
}
