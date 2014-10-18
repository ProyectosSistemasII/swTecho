using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using MySql.Data.MySqlClient;
using System.Windows.Forms;
namespace Capa_Datos
{
    public class S1006_Comunidad
    {
        public int idS1006_com { get; set; }
        public Boolean GrupoPolitico { get; set; }
        public Boolean GrupoDeportivo { get; set; }
        public Boolean GrupoReligioso { get; set; }
        public Boolean GrupoJovenes { get; set; }
        public Boolean GrupoMujeres { get; set; }
        public Boolean OrganizacionComunitaria { get; set; }
        public Boolean MesaTrabajo { get; set; }
        public Boolean Otros { get; set; }
        public String Especificar { get; set; }
        public Boolean NSNR { get; set; }

        public List<Error> errores { get; set; }
        private static ConexionBD datos = new ConexionBD();
        private static MySqlConnection conex = ConexionBD.conexion;

        public S1006_Comunidad()
        {
            this.idS1006_com = 0;
            this.GrupoPolitico = false;
            this.GrupoDeportivo = false;
            this.GrupoReligioso = false;
            this.GrupoJovenes = false;
            this.GrupoMujeres = false;
            this.OrganizacionComunitaria = false;
            this.MesaTrabajo = false;
            this.Otros = false;
            this.Especificar = "";
            this.NSNR = false;            
        }
        public S1006_Comunidad(int idS1006, Boolean Politico, Boolean Deportivo, Boolean Religioso, Boolean Jovenes, Boolean Mujeres, Boolean OrgaComunitaria, Boolean MesaTrabajo, Boolean Otros, String Especificar, Boolean NSNR)
        {
            this.idS1006_com = idS1006;
            this.GrupoPolitico = Politico;
            this.GrupoDeportivo = Deportivo;
            this.GrupoReligioso = Religioso;
            this.GrupoJovenes = Jovenes;
            this.GrupoMujeres = Mujeres;
            this.OrganizacionComunitaria = OrgaComunitaria;
            this.MesaTrabajo = MesaTrabajo;
            this.Otros = Otros;
            this.Especificar = Especificar;
            this.NSNR = NSNR;
            this.errores = new List<Error>();
        }

        public void InsertarS1006()
        {
            if (this.errores.Count == 0)
            {
                string consulta = "INSERT INTO S1006_com(GrupoPolitico,GrupoDeportivo,GrupoReligioso,GrupoJovenes,GrupoMujeres,OrganizacionComunitaria,MesaTrabajo,Otro,Especificar,NSNR) VALUES(@GrupoPolitico,@GrupoDeportivo,@GrupoReligioso,@GrupoJovenes,@GrupoMujeres,@OrganizacionComunitaria,@MesaTrabajo,@Otro,@Especificar,@NSNR)";
                MySqlCommand comando = new MySqlCommand(consulta, conex);
                comando.Parameters.AddWithValue("@GrupoPolitico", this.GrupoPolitico);
                comando.Parameters.AddWithValue("@GrupoDeportivo", this.GrupoDeportivo);
                comando.Parameters.AddWithValue("@GrupoReligioso", this.GrupoReligioso);
                comando.Parameters.AddWithValue("@GrupoJovenes", this.GrupoJovenes);
                comando.Parameters.AddWithValue("@GrupoMujeres", this.GrupoMujeres);
                comando.Parameters.AddWithValue("@OrganizacionComunitaria", this.OrganizacionComunitaria);
                comando.Parameters.AddWithValue("@MesaTrabajo", this.MesaTrabajo);
                comando.Parameters.AddWithValue("@Otro", this.Otros);
                comando.Parameters.AddWithValue("@Especificar", this.Especificar);
                comando.Parameters.AddWithValue("@NSNR", this.NSNR);

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

        public List<S1006_Comunidad> ObtenerS1006()
        {
            List<S1006_Comunidad> ListaComunidad = new List<S1006_Comunidad>();
            MySqlCommand comando = new MySqlCommand("SELECT * FROM S1006_Com WHERE Activo = true", conex);
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
                S1006_Comunidad comunidad = new S1006_Comunidad(Convert.ToInt32(row["idS1006_Com"]), Convert.ToBoolean(row["GrupoPolitico"]), Convert.ToBoolean(row["GrupoDeportivo"]), Convert.ToBoolean(row["GrupoReligioso"]), Convert.ToBoolean(row["GrupoJovenes"]), Convert.ToBoolean(row["GrupoMujeres"]), Convert.ToBoolean(row["OrganizacionComunitaria"]), Convert.ToBoolean(row["MesaTrabajo"]), Convert.ToBoolean(row["Otros"]),  Convert.ToString(row["Especificar"]),Convert.ToBoolean(row["NSNR"]));
                ListaComunidad.Add(comunidad);
            }
            return ListaComunidad;

        }
        public Int32 Obtener_Ultima_EncS1006()
        {
            int i = 0;
            MySqlCommand comando = new MySqlCommand("select max(idS1006_Com) as Contador from S1006_com", conex);
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
                string consulta = "SELECT GrupoPolitico, GrupoDeportivo, GrupoReligioso,GrupoJovenes, GrupoMujeres,S1006_com.OrganizacionComunitaria,MesaTrabajo,S1006_com.Otro   FROM S1006_com   inner join S10_Com on S1006_com_idS1006_com = idS1006_Com inner join Encuestas on Comunidad_idComunidad = @idComunidad and Encuestas_idEncuestas = idencuestas Order by GrupoPolitico";
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
