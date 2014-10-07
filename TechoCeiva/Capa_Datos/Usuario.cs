using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Data;

namespace Capa_Datos
{
    public class Usuario
    {
        public int idUsuarios { get; set; }
        public int idVoluntarios { get; set; }
        public int idTiposUsuarios { get; set; }
        public String username { get; set; }
        public String password { get; set; }
        public Boolean activado { get; set; }
        public List<Error> errores { get; set; }
        private static ConexionBD datos = new ConexionBD();
        private static MySqlConnection conex = ConexionBD.conexion;
       // public Usuario(){ }
        
       public Usuario()
        {
            this.idUsuarios = 0;
            this.idVoluntarios = 0;
            this.idTiposUsuarios = 0;
            this.username = "";
            this.password = "";
            this.activado = true;
           // this.errores = new List<Error>();
        }
        public Usuario(String username, String password) {
            this.username = username;
            this.password = password;
          this.errores = new List<Error>();
            this.existeUsuario();
            if (errores.Count > 0)
            {
                Error error = new Error("", 41);
                this.errores.Add(error);
            }
            else
            {
               // this.errores.RemoveAt(0);
                this.VerficarDatosSesion();
                if (errores.Count > 0)
                {
                    Error error = new Error("", 5);
                    this.errores.Add(error);
                    
                }
                else
                {
                    this.buscarUsuario();
                }
                
            }
        }
        public void VerficarDatosSesion()
        {
            int contador = 0;
            DataTable tabla = new DataTable();
            MySqlCommand comando = new MySqlCommand("SELECT Count(Password) AS Contra FROM Usuarios WHERE (username = @Username AND Password = SHA2(@Password,512))", conex);
            comando.Parameters.AddWithValue("@Username", this.username);
            comando.Parameters.AddWithValue("@Password", this.password);
            comando.CommandTimeout = 12280;
            
            DataSet ds = new DataSet();
            MySqlDataAdapter Adapter = new MySqlDataAdapter();
            Adapter.SelectCommand = comando;
            Adapter.Fill(ds);
            tabla = ds.Tables[0];
            DataRow row = tabla.Rows[0];
            contador = Convert.ToInt32(row["Contra"]);
           if (contador == 0)
            {
                Error error = new Error("" + this.username, 5);
                errores.Add(error);
            }
        }
         public void existeUsuario()
        {
            int i = 0;
            MySqlCommand comando = new MySqlCommand("SELECT COUNT(idUsuarios) AS Contador FROM Usuarios WHERE username = @usuario", conex);
            comando.Parameters.AddWithValue("@usuario", this.username);
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
                Error error = new Error("",41);
                errores.Add(error);
            }
        }
         public void buscarUsuario()
         {
             MySqlCommand comando = new MySqlCommand("SELECT idUsuarios,TipoUsuarios_idTipoUsuarios,Username,Voluntarios_idVoluntarios,activo FROM Usuarios WHERE username = @Username", conex);
             comando.Parameters.AddWithValue("@Username", this.username);
             comando.CommandTimeout = 12280;
            
             DataSet ds = new DataSet();
             MySqlDataAdapter Adapter = new MySqlDataAdapter();
             Adapter.SelectCommand = comando;
             Adapter.Fill(ds);
             DataTable tabla = new DataTable();
             tabla = ds.Tables[0];
             DataRow row = tabla.Rows[0];
             this.idUsuarios = Convert.ToInt32(row["idUsuarios"]);
             this.idTiposUsuarios = Convert.ToInt32(row["TipoUsuarios_idTipoUsuarios"]);
             this.idVoluntarios = Convert.ToInt32(row["Voluntarios_idVoluntarios"]);
             this.username = Convert.ToString(row["username"]);
             this.activado = Convert.ToBoolean(row["activo"]);
         }

    }
    
}
