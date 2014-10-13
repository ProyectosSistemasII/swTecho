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
            this.Devolucion = DateTime.Parse("YYYY/MM/DD");
        }

        public _DetallePrestamo(int idDetalle, int idHerramienta, int idDetallePrestamo, int cantidadBuena, int cantidadMala, int cantidadPerdida, int activo, DateTime fechaDev)
        {
            this.idDetallePrestamo = idDetalle;
            this.Herramientas_idHerramientas = idHerramienta;
            this.Prestamo_idDetallePrestamo = idDetallePrestamo;
            this.CantidadBuenEtsado = cantidadBuena;
            this.CantidadMalEstado = cantidadMala;
            this.CantidadPerdida = cantidadPerdida;
            this.Activo = activo;
            this.Devolucion = fechaDev;
        }

        public List<_DetallePrestamo> obtenerDetalles()
        {
            string query = "";
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
                _DetallePrestamo detallePrestamo = new _DetallePrestamo(Convert.ToInt32(_row["idDetallePrestamo"]), Convert.ToInt32(_row["Herramientas_idHerramientas"]), Convert.ToInt32(_row["Prestamo_idPrestamo"]), Convert.ToInt32(_row["CantidadBuenEstado"]), Convert.ToInt32(_row["CantidadMalEstado"]), Convert.ToInt32(_row["CantidadPerdida"]), Convert.ToInt32(_row["Activo"]), Convert.ToDateTime(_row["FechaDevolucion"]));
                listaPrestamos.Add(detallePrestamo);
            }

            return listaPrestamos;
        }

        public void insertarDetalle(List<_Herramientas> listado, int idPrestamo)
        {
            _conexion.Open();

            MySqlTransaction transaction = _conexion.BeginTransaction(System.Data.IsolationLevel.ReadCommitted);
            MySqlCommand comando = _conexion.CreateCommand();

            foreach (_Herramientas herramienta in listado)
            {
                try
                {
                    comando.CommandText = "INSERT INTO DetallePrestamo (Herramientas_idHerramientas, Prestamo_idPrestamo, CantidadBuenEstado, CantidadMalEstado, CantidadPerdida, Activo, FechaDevolucion) VALUES (@idHerramienta, @idPrestamo, @cantidadBuenEstado, @cantidadMalEstado, @cantidadPerdida, @activo, @fechaDevolucion)";
                    comando.Parameters.AddWithValue("@idHerramienta", herramienta.idHerramientas);
                    comando.Parameters.AddWithValue("@idPrestamo", idPrestamo);
                    comando.Parameters.AddWithValue("@cantidadBuenEstado", 0);
                    comando.Parameters.AddWithValue("@cantidadMalEstado", 0);
                    comando.Parameters.AddWithValue("@cantidadPerdida", 0);
                    comando.Parameters.AddWithValue("@activo", 1);
                    comando.Parameters.AddWithValue("@fechaDevolucion", null);
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
}
