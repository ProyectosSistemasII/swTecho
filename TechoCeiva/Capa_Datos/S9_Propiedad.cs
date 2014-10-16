using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MySql.Data.MySqlClient;
using System.Data;
using System.Windows.Forms;

namespace Capa_Datos
{
    public class S9_Propiedad
    {
        public int idS9_Prop { get; set; }       
        public String Propio { get; set; }
        public String Propietario { get; set; }
        public String OtroPropietario { get; set; }
        public String TipoPropiedad { get; set; }
        public String OtroTipoPropiedad { get; set; }
        public String PropietarioTerreno { get; set; }
        public String TelefonoPropietarioTerreno { get; set; }
        public Boolean NSNR { get; set; }
        public String OtraPropiedad { get; set; }
        public String OtraPropiedadA { get; set; }
        public String OtraPropiedadB { get; set; }
        public String OtraPropiedadC { get; set; }
        public int idEncuestas { get; set; }

        public List<Error> errores { get; set; }
        private static ConexionBD datos = new ConexionBD();
        private static MySqlConnection conex = ConexionBD.conexion;

        public S9_Propiedad()
        {
            this.idS9_Prop = 0;            
            this.Propio = "";
            this.Propietario = "";
            this.OtroPropietario = "";
            this.TipoPropiedad = "";
            this.OtroTipoPropiedad= "";
            this.PropietarioTerreno = "";
            this.TelefonoPropietarioTerreno = "";
            this.NSNR =false;
            this.OtraPropiedad="";
            this.OtraPropiedadA= "";
            this.OtraPropiedadB ="";
            this.OtraPropiedadC="";
            this.idEncuestas = 0;
        }

        public S9_Propiedad(int idS9_Prop, String Propio, String Propietario, String OtroPropietario, String TipoPropiedad, String OtroTipoPropiedad, String PropietarioTerreno, String TelefonoPropietarioTerreno, Boolean NSNR, String OtraPropiedad, String PropiedadA, String PropiedadB, String PropiedadC, int idEncuestas)
        {
            this.idS9_Prop = idS9_Prop;           
            this.Propio = Propio;
            this.Propietario = Propietario;
            this.OtroPropietario = OtroPropietario;
            this.TipoPropiedad = TipoPropiedad;
            this.OtroTipoPropiedad = OtroTipoPropiedad;
            this.PropietarioTerreno = PropietarioTerreno;
            this.TelefonoPropietarioTerreno = TelefonoPropietarioTerreno;
            this.NSNR = NSNR;
            this.OtraPropiedad = OtraPropiedad;
            this.OtraPropiedadA = PropiedadA;
            this.OtraPropiedadB = PropiedadB;
            this.OtraPropiedadC = PropiedadC;
            this.idEncuestas = idEncuestas;
            this.errores = new List<Error>();            
        }

        public void InsertarS9()
        {
            if (this.errores.Count == 0)
            {
                string consulta = "INSERT INTO S9_prop(Propio,Propietario,OtroPropietario,TipoPropiedad,OtroTipoPropiedad,PropietarioTerreno,TelefonoPropietarioTerreno,NSNR,OtraPropiedad,PropiedadA,PropiedadB,PropiedadC,Encuestas_idEncuestas) VALUES(@Propio,@Propietario,@OtroPropietario,@TipoPropiedad,@OtroTipoPropiedad,@PropietarioTerreno,@TelefonoPropietarioTerreno,@NSNR,@OtraPropiedad,@OtraPropiedadA,@OtraPropiedadB,@OtraPropiedadC,@Encuestas_idEncuestas)";
                MySqlCommand comando = new MySqlCommand(consulta, conex);               
                comando.Parameters.AddWithValue("@Propio", this.Propio);
                comando.Parameters.AddWithValue("@Propietario", this.Propietario);
                comando.Parameters.AddWithValue("@OtroPropietario", this.OtroPropietario);
                comando.Parameters.AddWithValue("@TipoPropiedad", this.TipoPropiedad);
                comando.Parameters.AddWithValue("@OtroTipoPropiedad", this.OtroTipoPropiedad);
                comando.Parameters.AddWithValue("@PropietarioTerreno", this.PropietarioTerreno);
                comando.Parameters.AddWithValue("@TelefonoPropietarioTerreno", this.TelefonoPropietarioTerreno);
                comando.Parameters.AddWithValue("@NSNR", this.NSNR);
                comando.Parameters.AddWithValue("@OtraPropiedad", this.OtraPropiedad);
                comando.Parameters.AddWithValue("@OtraPropiedadA", this.OtraPropiedadA);
                comando.Parameters.AddWithValue("@OtraPropiedadB", this.OtraPropiedadB);
                comando.Parameters.AddWithValue("@OtraPropiedadC", this.OtraPropiedadC);
                comando.Parameters.AddWithValue("@Encuestas_idEncuestas", this.idEncuestas);
                
                try
                {
                    //comando.Connection.Open();
                    comando.ExecuteNonQuery();
                    //comando.Connection.Close();
                }
                catch (MySqlException ex)
                {
                    Error error = new Error(ex.Message + "   " + ex.Number, 2);
                    errores.Add(error);
                }
            }
        }

        public List<S9_Propiedad> ObtenerS9()
        {
            List<S9_Propiedad> ListaPropiedad = new List<S9_Propiedad>();
            MySqlCommand comando = new MySqlCommand("SELECT * FROM S9_Prop WHERE Activo = true", conex);
            comando.CommandTimeout = 12280;
            DataSet ds = new DataSet();
            MySqlDataAdapter Adapter = new MySqlDataAdapter();
            Adapter.SelectCommand = comando;
            Adapter.Fill(ds);
            DataTable tabla = new DataTable();
            tabla = ds.Tables[0];
            for (int i = 0; i < tabla.Rows.Count; i++)
            {
                DataRow row = tabla.Rows[i];
                S9_Propiedad propiedad = new S9_Propiedad(Convert.ToInt32(row["idS9_Prop"]), Convert.ToString(row["Propio"]), Convert.ToString(row["Propietario"]), Convert.ToString(row["OtroPropietario"]), Convert.ToString(row["TipoPropietario"]), Convert.ToString(row["OtroTipoPropietario"]), Convert.ToString(row["PropietarioTerreno"]), Convert.ToString(row["TelefonoPropietarioTerreno"]), Convert.ToBoolean(row["NSNR"]), Convert.ToString(row["OtraPropiedad"]), Convert.ToString(row["OtraPropiedadA"]), Convert.ToString(row["OtraPropiedadB"]), Convert.ToString(row["OtraPropiedadC"]), Convert.ToInt32(row["Encuestas_idEncuestas"]));
                ListaPropiedad.Add(propiedad);
            }
            return ListaPropiedad;
        }
        public DataTable GenerarReporte(int comunidad)
        {
            try
            {
                string consulta = "SELECT S9_prop.Propio, S9_prop.Propietario, S9_prop.TipoPropiedad   FROM S9_prop    inner join Encuestas on Comunidad_idComunidad = @idComunidad and idS9_prop = idencuestas Order by Propio";
                MySqlCommand comando = new MySqlCommand(consulta, conex);
                comando.Parameters.AddWithValue("@idComunidad", comunidad);
                comando.CommandTimeout = 12280;
                DataSet ds = new DataSet();
                MySqlDataAdapter da = new MySqlDataAdapter(comando);
                da.Fill(ds);
                return ds.Tables[0];
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message + "   " + ex.Number, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                ///Error error = new Error(ex.Message + "   " + ex.Number, 2);
                //errores.Add(error);
                return null;
            }
        }
    }
}
