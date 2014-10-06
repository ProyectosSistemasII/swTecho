using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using MySql.Data.MySqlClient;

namespace Capa_Datos
{
    public class S10_Comunidad
    {
        public int idS10_Com { get; set; }
        public String Ayudo { get; set; }
        public String AyudaVecinos { get; set; }
        public String RelacionVecinos { get; set; }
        public String ComentarioRelacion { get; set; }
        public String OrganizarVecinos { get; set; }
        public String OrganizarA { get; set; }
        public String OrganizarB { get; set; }
        public String OrganizarC { get; set; }
        public String ParticipacionGrupo { get; set; }
        public String Necesidad { get; set; }
        public String NecesidadA { get; set; }
        public String NecesidadB { get; set; }
        public String NecesidadC { get; set; }
        public String NecesidadCom { get; set; }
        public String NecesidadComA { get; set; }
        public String NecesidadComB { get; set; }
        public String NecesidadComC { get; set; }
        public String ProyectosVecinos { get; set; }
        public String ProyectoA { get; set; }
        public String ProyectoB { get; set; }
        public String ProyectoC { get; set; }
        public String AspectoPositivo { get; set; }
        public String AspectoPositivoA { get; set; }
        public String AspectoPositivoB { get; set; }
        public String AspectoPositivoC { get; set; }
        public String AspectoNegativo { get; set; }
        public String AspectoNegativoA { get; set; }
        public String AspectoNegativoB { get; set; }
        public String AspectoNegativoC { get; set; }
        public String Discriminacion { get; set; }
        public String TipoDiscriminacion { get; set; }
        public String OrganizacionComunitaria { get; set; }
        public String TipoOrganizacion { get; set; }
        public String ConfianzaOrganizacion { get; set; }
        public String ComentarioConfianza { get; set; }
        public String LiderA { get; set; }
        public String LiderB { get; set; }
        public String LiderC { get; set; }
        public String EstadoComunidadPasada { get; set; }
        public String ComentarioEstadoPasado { get; set; }
        public String EstadoComunidadFuturo { get; set; }
        public String ComentarioEstadoFuturo { get; set; }
        public int idEncuestas { get; set; }
        public int idS1006 { get; set; }
        public int idS1007 { get; set; }
        public int idS1008 { get; set; }
        public int idS1014 { get; set; }

        public List<Error> errores { get; set; }
        private static ConexionBD datos = new ConexionBD();
        private static MySqlConnection conex = ConexionBD.conexion;

        public S10_Comunidad()
        {
            this.idS10_Com = 0;
            this.Ayudo = "";
            this.AyudaVecinos = "";
            this.RelacionVecinos = "";
            this.ComentarioRelacion = "";
            this.OrganizarVecinos = "";
            this.OrganizarA = "";
            this.OrganizarB="";
            this.OrganizarC ="";
            this.ParticipacionGrupo ="";
            this.Necesidad = "";
            this.NecesidadA = "";
            this.NecesidadB = "";
            this.NecesidadC = "";
            this.NecesidadCom = "";
            this.NecesidadComA = "";
            this.NecesidadComB = "";
            this.NecesidadComC = "";
            this.ProyectosVecinos = "";
            this.ProyectoA = "";
            this.ProyectoB = "";
            this.ProyectoC = "";
            this.AspectoPositivo = "";
            this.AspectoPositivoA = "";
            this.AspectoPositivoB = "";
            this.AspectoPositivoC = "";
            this.AspectoNegativo = "";
            this.AspectoNegativoA = "";
            this.AspectoNegativoB = "";
            this.AspectoNegativoC = "";
            this.Discriminacion = "";
            this.TipoDiscriminacion = "";
            this.OrganizacionComunitaria = "";
            this.TipoOrganizacion = "";
            this.ConfianzaOrganizacion = "";
            this.ComentarioConfianza = "";
            this.LiderA = "";
            this.LiderB = "";
            this.LiderC = "";
            this.EstadoComunidadPasada = "";
            this.ComentarioEstadoPasado = "";
            this.EstadoComunidadFuturo = "";
            this.ComentarioEstadoFuturo = "";
            this.idEncuestas = 0;
            this.idS1006 = 0;
            this.idS1007 = 0;
            this.idS1008 = 0;
            this.idS1014 = 0; 
        }
        public S10_Comunidad(int idS10_Com, String Ayudo, String AyudaVecinos, String RelacionVecinos,
        String ComentarioRelacion, String OrganizarVecinos, String OrganizarA, String OrganizarB, String OrganizarC,
        String ParticipacionGrupo, int idEncuestas,int idS1006, int idS1007, int idS1008)
        {
            this.idS10_Com = idS10_Com;
            this.Ayudo = Ayudo;
            this.AyudaVecinos = AyudaVecinos;
            this.RelacionVecinos = RelacionVecinos;
            this.ComentarioRelacion = ComentarioRelacion;
            this.OrganizarVecinos = OrganizarVecinos;
            this.OrganizarA = OrganizarA;
            this.OrganizarB = OrganizarB;
            this.OrganizarC = OrganizarC;
            this.ParticipacionGrupo = ParticipacionGrupo;
            this.idEncuestas = idEncuestas;
            this.idS1006 = idS1006;
            this.idS1007 = idS1007;
            this.idS1008 = idS1008;
            this.errores = new List<Error>();
        }
            
        public void S10_ComunidadCOnt( String Necesidad, String NecesidadA, String NecesidadB, String NecesidadC,
        String NecesidadCom, String NecesidadComA, String NecesidadComB, String NecesidadComC, String ProyectosVecinos,
        String ProyectoA, String ProyectoB, String ProyectoC, String AspectoPositivo, String AspectoPositivoA,
        String AspectoPositivoB, String AspectoPositivoC, String AspectoNegativo, String AspectoNegativoA,
        String AspectoNegativoB, String AspectoNegativoC, String Discriminacion, String TipoDiscriminacion,
        String OrganizacionComunitaria, String TipoOrganizacion, String ConfianzaOrganizacion, String ComentarioConfianza,
        String LiderA, String LiderB, String LiderC, String EstadoComunidadPasada, String ComentarioEstadoPasado,
        String EstadoComunidadFuturo, String ComentarioEstadoFuturo, int idS1014)
        {
            this.Necesidad = Necesidad;
            this.NecesidadA = NecesidadA;
            this.NecesidadB = NecesidadB;
            this.NecesidadC = NecesidadC;
            this.NecesidadCom = NecesidadCom;
            this.NecesidadComA = NecesidadComA;
            this.NecesidadComB = NecesidadComB;
            this.NecesidadComC = NecesidadComC;
            this.ProyectosVecinos = ProyectosVecinos;
            this.ProyectoA = ProyectoA;
            this.ProyectoB = ProyectoB;
            this.ProyectoC = ProyectoC;
            this.AspectoPositivo = AspectoPositivo;
            this.AspectoPositivoA = AspectoPositivoA;
            this.AspectoPositivoB = AspectoPositivoB;
            this.AspectoPositivoC = AspectoPositivoC;
            this.AspectoNegativo = AspectoNegativo;
            this.AspectoNegativoA = AspectoNegativoA;
            this.AspectoNegativoB = AspectoNegativoB;
            this.AspectoNegativoC = AspectoNegativoC;
            this.Discriminacion = Discriminacion;
            this.TipoDiscriminacion = TipoDiscriminacion;
            this.OrganizacionComunitaria = OrganizacionComunitaria;
            this.TipoOrganizacion = TipoOrganizacion;
            this.ConfianzaOrganizacion = ConfianzaOrganizacion;
            this.ComentarioConfianza = ComentarioConfianza;
            this.LiderA = LiderA;
            this.LiderB = LiderB;
            this.LiderC = LiderC;
            this.EstadoComunidadPasada = EstadoComunidadPasada;
            this.ComentarioEstadoPasado = ComentarioEstadoPasado;
            this.EstadoComunidadFuturo = EstadoComunidadFuturo;
            this.ComentarioEstadoFuturo = ComentarioEstadoFuturo;
            this.idS1014 = idS1014;
            this.errores = new List<Error>();
        }
        public void InsertarS10()
        {

            if (this.errores.Count == 0)
            {
                string consulta = ""; //= "INSERT INTO S9_prop(CodigoS11,VidaFamiliar,DireccionPasada,AnioTraslado,ViviendaActual,ComentarioFinal,Encuestas_idEncuestas) VALUES(@CodigoS11,VidaFamiliar,@DireccionPasada,@AnioTraslado,@ViviendaActual,@ComentarioFinal,@Encuestas_idEncuestas)";
                MySqlCommand comando = new MySqlCommand(consulta, conex);
                comando.Parameters.AddWithValue("@Ayudo", this.Ayudo);
                comando.Parameters.AddWithValue("@AyudaVecinos", this.AyudaVecinos);
                comando.Parameters.AddWithValue("@RelacionVecinos", this.RelacionVecinos);
                comando.Parameters.AddWithValue("@ComentarioRelacion", this.ComentarioRelacion);
                comando.Parameters.AddWithValue("@OrganizarVecinos", this.OrganizarVecinos);
                comando.Parameters.AddWithValue("@OrganizarA", this.OrganizarA);
                comando.Parameters.AddWithValue("@OrganizarB", this.OrganizarB);
                comando.Parameters.AddWithValue("@OrganizarC", this.OrganizarC);
                comando.Parameters.AddWithValue("@ParticipacionGrupo", this.ParticipacionGrupo);
                comando.Parameters.AddWithValue("@Necesidad", this.Necesidad);
                comando.Parameters.AddWithValue("@NecesidadA", this.NecesidadA);
                comando.Parameters.AddWithValue("@NecesidadB", this.NecesidadB);
                comando.Parameters.AddWithValue("@NecesidadC", this.NecesidadC);
                comando.Parameters.AddWithValue("@NecesidadCom", this.NecesidadCom);
                comando.Parameters.AddWithValue("@NecesidadComA", this.NecesidadComA);
                comando.Parameters.AddWithValue("@NecesidadComB", this.NecesidadComB);
                comando.Parameters.AddWithValue("@NecesidadComC", this.NecesidadComC);
                comando.Parameters.AddWithValue("@ProyectosVecinos", this.ProyectosVecinos);
                comando.Parameters.AddWithValue("@ProyectoA", this.ProyectoA);
                comando.Parameters.AddWithValue("@ProyectoB", this.ProyectoB);
                comando.Parameters.AddWithValue("@ProyectoC", this.ProyectoC);
                comando.Parameters.AddWithValue("@AspectoPositivo", this.AspectoPositivo);
                comando.Parameters.AddWithValue("@AspectoPositivoA", this.AspectoPositivoA);
                comando.Parameters.AddWithValue("@AspectoPositivoB", this.AspectoPositivoB);
                comando.Parameters.AddWithValue("@AspectoPositivoC", this.AspectoPositivoC);
                comando.Parameters.AddWithValue("@AspectoNegativo", this.AspectoNegativo);
                comando.Parameters.AddWithValue("@AspectoNegativoA", this.AspectoNegativoA);
                comando.Parameters.AddWithValue("@AspectoNegativoB", this.AspectoNegativoB);
                comando.Parameters.AddWithValue("@AspectoNegativoC", this.AspectoNegativoC);
                comando.Parameters.AddWithValue("@Discriminacion", this.Discriminacion);
                comando.Parameters.AddWithValue("@TipoDiscriminacion", this.TipoDiscriminacion);
                comando.Parameters.AddWithValue("@OrganizacionComunitaria", this.OrganizacionComunitaria);
                comando.Parameters.AddWithValue("@TipoOrganizacion", this.TipoOrganizacion);
                comando.Parameters.AddWithValue("@ConfianzaOrganizacion", this.ConfianzaOrganizacion);
                comando.Parameters.AddWithValue("@ComentarioConfianza", this.ComentarioConfianza);
                comando.Parameters.AddWithValue("@LiderA", this.LiderA);
                comando.Parameters.AddWithValue("@LiderB", this.LiderB);
                comando.Parameters.AddWithValue("@LiderC", this.LiderC);
                comando.Parameters.AddWithValue("@EstadoComunidadPasada", this.EstadoComunidadPasada);
                comando.Parameters.AddWithValue("@ComentarioEstadoPasado", this.ComentarioEstadoPasado);
                comando.Parameters.AddWithValue("@EstadoComunidadFuturo", this.EstadoComunidadFuturo);
                comando.Parameters.AddWithValue("@ComentarioEstadoFuturo", this.ComentarioEstadoFuturo);
                comando.Parameters.AddWithValue("@Encuestas_idEncuestas", this.idEncuestas);
                comando.Parameters.AddWithValue("@S1006_Com_idS1006_Com", this.idS1006);
                comando.Parameters.AddWithValue("@S1007_Com_idS1007_Com", this.idS1007);
                comando.Parameters.AddWithValue("@S1008_Com_idS1008_Com", this.idS1008);
                comando.Parameters.AddWithValue("@S1014_Com_idS1014_Com", this.idS1014);

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
    }
}
