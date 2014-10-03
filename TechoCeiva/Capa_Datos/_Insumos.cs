using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MySql.Data.MySqlClient;

namespace Capa_Datos
{
    class _Insumos
    {
        public int idAlimentos { get; set; }
        public String Nombre { get; set; }
        public String FechaCaducidad { get; set; }
        public Boolean Activo { get; set; }
        public int Presentacion_idPresentacion { get; set; }

        private static ConexionBD _datos = new ConexionBD();
        private static MySqlConnection _conexion = ConexionBD.conexion;


        public _Insumos()
        {
            this.idAlimentos = 0;
            this.Nombre = "";
            this.FechaCaducidad = "";
            this.Activo = true;
            this.Presentacion_idPresentacion = 0;
        }

    }
}
