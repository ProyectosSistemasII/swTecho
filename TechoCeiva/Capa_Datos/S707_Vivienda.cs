using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using MySql.Data.MySqlClient;

namespace Capa_Datos
{
    public class S707_Vivienda
    {
        public int BlockLadrilloPrefabr { get; set; }
        public int Madera { get; set; }
        public int Adobe { get; set; }
        public int Lamina { get; set; }
        public int BaharequeBambu { get; set; }
        public int Desechos { get; set; }
        public List<Error> errores { get; set; }
        private static ConexionBD datos = new ConexionBD();
        private static MySqlConnection conex = ConexionBD.conexion;

        public S707_Vivienda()
        {
            this.BlockLadrilloPrefabr = 0;
            this.Madera = 0;
            this.Adobe = 0;
            this.Lamina = 0;
            this.BaharequeBambu = 0;
            this.Desechos = 0;
        }

        public S707_Vivienda(int BlockLadrilloPrefarbr, int Madera, int Adobe, int Lamina, int BaharequeBambu, int Desechos)
        {
            this.BlockLadrilloPrefabr = BlockLadrilloPrefarbr;
            this.Madera = Madera;
            this.Adobe = Adobe;
            this.Lamina = Lamina;
            this.BaharequeBambu = BaharequeBambu;
            this.Desechos = Desechos;
            this.errores = new List<Error>();
        }

        public void InsertarS707()
        {
            if (this.errores.Count == 0)
            {
                string consulta = "INSERT INTO S707_Viv(BlockLadrilloPrefabr,Madera,Adobe,Lamina,BaharequeBambu,Desechos) VALUES(@BlockLadrilloPrefabr,@Madera,@Adobe,@Lamina,@BaharequeBambu,@Desechos)";
                MySqlCommand comando = new MySqlCommand(consulta, conex);
                comando.Parameters.AddWithValue("@BlockLadrilloPrefabr", this.BlockLadrilloPrefabr);
                comando.Parameters.AddWithValue("@Madera", this.Madera);
                comando.Parameters.AddWithValue("@Adobe", this.Adobe);
                comando.Parameters.AddWithValue("@Lamina", this.Lamina);
                comando.Parameters.AddWithValue("@BaharequeBambu", this.BaharequeBambu);
                comando.Parameters.AddWithValue("@Desechos", this.Desechos);                
                try
                {
                    comando.Connection.Open();
                    comando.ExecuteNonQuery();
                    comando.Connection.Close();
                }
                catch (MySqlException ex)
                {
                    Error error = new Error(ex.Message + "   " + ex.Number, 2);
                    errores.Add(error);
                }
            }
        }

        public int UltimoId()
        {
            int id = 0;
            String consulta = "SELECT MAX(idS707_Viv) FROM S707_Viv";
            MySqlCommand comando = new MySqlCommand(consulta, conex);
            try
            {
                comando.Connection.Open();
                id = (Int32)comando.ExecuteScalar();
                comando.Connection.Close();
            }
            catch (MySqlException ex)
            {
                Error error = new Error(ex.Message + "   " + ex.Number, 0);
                errores.Add(error);
            }
            return id;
        }
    }
}
