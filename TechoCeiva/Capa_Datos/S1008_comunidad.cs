using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MySql.Data.MySqlClient;
using System.Data;
using System.Windows.Forms;


namespace Capa_Datos
{
    public class S1008_comunidad
    {
        public int idS1008_Com { get; set; }
        public int Familiar { get; set; }
        public int Vecinos { get; set; }
        public int lideresComunitarios { get; set; }
        public int Policia { get; set; }
        public int Municipalidad { get; set; }
        public int OrganizacionGobierno { get; set; }
        public int Ejercito { get; set; }
        public int partidosPoliticos { get; set; }
        public int Techo { get; set; }
        public int MedioComunicacion { get; set; }
        public int IglesiasReligiosos { get; set; }

        public List<Error> errores { get; set; }
        private static ConexionBD datos = new ConexionBD();
        private static MySqlConnection conex = ConexionBD.conexion;

        public S1008_comunidad()
        {
            this.idS1008_Com = 0;
            this.Familiar = 0;
            this.Vecinos = 0;
            this.lideresComunitarios = 0;
            this.Policia = 0;
            this.Municipalidad = 0;
            this.OrganizacionGobierno = 0;
            this.Ejercito = 0;
            this.partidosPoliticos = 0;
            this.Techo = 0;
            this.MedioComunicacion = 0;
            this.IglesiasReligiosos = 0;
        }

        public S1008_comunidad(int idS1008, int familiar, int vecinos, int liderescom, int policia, int municipalidad, int orgaGobierno, int ejercito, int partidopoliticos, int techo, int mediocomunicacion, int iglesias)
        {
            this.idS1008_Com = idS1008;
            this.Familiar = familiar;
            this.Vecinos = vecinos;
            this.lideresComunitarios = liderescom;
            this.Policia = policia;
            this.Municipalidad = municipalidad;
            this.OrganizacionGobierno = orgaGobierno;
            this.Ejercito = ejercito;
            this.partidosPoliticos = partidopoliticos;
            this.Techo = techo;
            this.MedioComunicacion = mediocomunicacion;
            this.IglesiasReligiosos = iglesias;
            this.errores = new List<Error>();
        }

        public void InsertarS1008()
        {
            if (this.errores.Count == 0)
            {
                string consulta = "INSERT INTO S1008_com(Familiar,Vecinos,LideresComunitarios,Policia,Municipalidad,OrganizacionGobierno,Ejercito,PartidosPoliticos,Techo,MedioComunicacion,IglesiasReligiosos) VALUES(@Familiar,@Vecinos,@LideresComunitarios,@Policia,@Municipalidad,@OrganizacionGobierno,@Ejercito,@PartidosPoliticos,@Techo,@MedioComunicacion,@IglesiasReligiosos)";
                MySqlCommand comando = new MySqlCommand(consulta, conex);
                comando.Parameters.AddWithValue("@Familiar", this.Familiar);
                comando.Parameters.AddWithValue("@Vecinos", this.Vecinos);
                comando.Parameters.AddWithValue("@LideresComunitarios", this.lideresComunitarios);
                comando.Parameters.AddWithValue("@Policia", this.Policia);
                comando.Parameters.AddWithValue("@Municipalidad", this.Municipalidad);
                comando.Parameters.AddWithValue("@OrganizacionGobierno", this.OrganizacionGobierno);
                comando.Parameters.AddWithValue("@Ejercito", this.Ejercito);
                comando.Parameters.AddWithValue("@PartidosPoliticos", this.partidosPoliticos);
                comando.Parameters.AddWithValue("@Techo", this.Techo);
                comando.Parameters.AddWithValue("@MedioComunicacion", this.MedioComunicacion);
                comando.Parameters.AddWithValue("@IglesiasReligiosos", this.IglesiasReligiosos);

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

        public List<S1008_comunidad> ObtenerS1008()
        {
            List<S1008_comunidad> Listacomunidad = new List<S1008_comunidad>();
            MySqlCommand comando = new MySqlCommand("SELECT * FROM S1008_Com WHERE Activo = true", conex);
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
                S1008_comunidad comunidad = new S1008_comunidad(Convert.ToInt32(row["idS1008_com"]), Convert.ToInt32(row["Familiar"]), Convert.ToInt32(row["Vecinos"]), Convert.ToInt32(row["LideresComunitarios"]), Convert.ToInt32(row["Policia"]), Convert.ToInt32(row["Municipalidad"]), Convert.ToInt32(row["OrganizacionGobierno"]), Convert.ToInt32(row["Ejercito"]), Convert.ToInt32(row["PartidosPoliticos"]), Convert.ToInt32(row["Techo"]), Convert.ToInt32(row["MedioComunicacion"]), Convert.ToInt32(row["IglesiasReligiosas"]));
                Listacomunidad.Add(comunidad);
            }
            return Listacomunidad;
        }

        public Int32 Obtener_Ultima_EncS1008()
        {
            int i = 0;
            MySqlCommand comando = new MySqlCommand("select max(idS1008_Com) as Contador from S1008_Com", conex);
            comando.CommandTimeout = 12280;
            DataSet ds = new DataSet();
            MySqlDataAdapter Adapter = new MySqlDataAdapter();
            Adapter.SelectCommand = comando;
            Adapter.Fill(ds);
            DataTable tabla = new DataTable();
            tabla = ds.Tables[0];
            DataRow row = tabla.Rows[0];
            i = Convert.ToInt32(row["Contador"]);
            if (i == 0)
            {
                Error error = new Error("", 41);
                errores.Add(error);
            }
            return i;
        }
        public DataTable GenerarReporte(int comunidad)
        {
            try
            {
                string consulta = "SELECT (case when Familiar=3 then 'SI' when Familiar=2 then 'Indiferente' when Familiar =1 then'NO' else 'NSNR' END) as Familiar , (case when Vecinos=3 then 'SI' when Vecinos=2 then 'Indiferente' when Vecinos =1 then'NO' else 'NSNR' END) as Vecinos, (case when LideresComunitarios=3 then 'SI' when LideresComunitarios=2 then 'Indiferente' when LideresComunitarios =1 then'NO' else 'NSNR' END) as LideresComunitarios, (case when Policia=3 then 'SI' when Policia=2 then 'Indiferente' when Policia =1 then'NO' else 'NSNR' END) as Policia, (case when Municipalidad=3 then 'SI' when Municipalidad=2 then 'Indiferente' when Municipalidad =1 then'NO' else 'NSNR' END) as Municipalidad,(case when OrganizacionGobierno=3 then 'SI' when OrganizacionGobierno=2 then 'Indiferente' when OrganizacionGobierno =1 then'NO' else 'NSNR' END) as OrganizacionGobierno,(case when Ejercito=3 then 'SI' when Ejercito=2 then 'Indiferente' when Ejercito =1 then'NO' else 'NSNR' END) as Ejercito, (case when PartidosPoliticos=3 then 'SI' when PartidosPoliticos=2 then 'Indiferente' when PartidosPoliticos =1 then'NO' else 'NSNR' END) as PartidosPoliticos,(case when Techo=3 then 'SI' when Techo=2 then 'Indiferente' when Techo =1 then'NO' else 'NSNR' END) as  Techo, (case when MedioComunicacion=3 then 'SI' when MedioComunicacion=2 then 'Indiferente' when MedioComunicacion =1 then'NO' else 'NSNR' END) as MedioComunicacion,(case when IglesiasReligiosos=3 then 'SI' when IglesiasReligiosos=2 then 'Indiferente' when IglesiasReligiosos =1 then'NO' else 'NSNR' END) as IglesiasReligiosos    FROM S1008_com   inner join S10_Com on S1008_com_idS1008_com = idS1008_Com inner join Encuestas on Comunidad_idComunidad = @idComunidad and Encuestas_idEncuestas = idencuestas Order by Familiar";
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
