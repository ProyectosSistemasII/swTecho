using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MySql.Data.MySqlClient;
using System.Data;
using System.Windows.Forms;

namespace Capa_Datos
{
    public class _Reportes
    {
        private static ConexionBD _datos = new ConexionBD();
        private static MySqlConnection _conexion = ConexionBD.conexion;

        public _Reportes()
        {
        
        }

        /*
         * Metodo para generar reporte de la seccion 5 de la encuesta
         */ 
        public DataTable GenerarTrabajo(int idComunidad)
        {
            MySqlCommand comando = null;
            try
            {
                string consulta = "SELECT IF(Trabajo = 1, 'Si Trabaja','No Trabaja') as Trabajo, Ocupacion, ContratoTrabajo, CondicionLaboral, UbicacionTrabajo, IF(OtrosTrabajos = 1,'Si Otros', 'No Otros') as OtrosTrabajos FROM s5_tra INNER JOIN Encuestas ON Comunidad_idComunidad = @idComunidad AND Encuestas_idEncuestas = s5_Tra.Encuestas_idEncuestas";
                comando = new MySqlCommand(consulta, _conexion);
                comando.Parameters.AddWithValue("@idComunidad", idComunidad);
                comando.Connection.Open();
                comando.ExecuteNonQuery();
                comando.Connection.Close();

                DataSet ds = new DataSet();
                MySqlDataAdapter da = new MySqlDataAdapter(comando);
                da.Fill(ds);

                return ds.Tables[0];
            }
            catch (Exception ex)
            {
                comando.Connection.Close();
                MessageBox.Show("No se ha podido generar reporte", "Error",  MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        /*
         * Metodo para generar reporte de seccion 7 de la encuesta
         */ 
        public DataTable GenerarVivienda(int idComunidad)
        {
            MySqlCommand comando = null;
            try
            {
                string consulta = "SELECT Cuartos, Camas, Concreto, TejaBarro, s706_Viv.Lamina, TejaDuralita, Paja, s706_Viv.Desechos, BlockLadrilloPrefabr, s707_Viv.Madera, Adobe, s707_Viv.Lamina as LaminaP, BaharequeBambu, s707_Viv.Desechos as DesechosP, Encementado, LadrillosBarro, s708_Viv.Madera as MaderaPi, Tierra FROM S7_Viv INNER JOIN S706_viv ON S706_Viv_idS706_Viv = idS706_Viv INNER JOIN S707_Viv ON S707_Viv_idS707_Viv = idS707_Viv INNER JOIN S708_Viv ON S708_Viv_idS708_Viv = idS708_Viv INNER JOIN Encuestas ON Comunidad_idComunidad = @idComunidad AND Encuestas_idEncuestas = s7_Viv.Encuestas_idEncuestas";
                comando = new MySqlCommand(consulta, _conexion);
                comando.Parameters.AddWithValue("@idComunidad", idComunidad);
                comando.Connection.Open();
                comando.ExecuteNonQuery();
                comando.Connection.Close();

                DataSet ds = new DataSet();
                MySqlDataAdapter da = new MySqlDataAdapter(comando);
                da.Fill(ds);

                return ds.Tables[0];
            }
            catch (Exception ex)
            {
                comando.Connection.Close();
                MessageBox.Show("No se ha podido generar reporte", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        /*
         * Metodo para generar reporte de la seccion 1 de la encuesta
         */ 
        public DataTable ClasificacionTotalPersonas(int idComunidad)
        {
            MySqlCommand comando = null;
            try
            {
                string consulta = "SELECT if(Genero = 'Mujer' AND Embarazo = 'No' AND DATE_FORMAT(FROM_DAYS(TO_DAYS(NOW())-TO_DAYS(STR_TO_DATE(FechaNac,'%d/%m/%Y'))), '%Y')+0 > 17, 'Mujeres no embarazadas',if(Genero = 'Mujer' AND Embarazo = 'Si' AND DATE_FORMAT(FROM_DAYS(TO_DAYS(NOW())-TO_DAYS(STR_TO_DATE(FechaNac,'%d/%m/%Y'))), '%Y')+0 > 17,'Mujeres embarazadas',if(Genero = 'Hombre'AND DATE_FORMAT(FROM_DAYS(TO_DAYS(NOW())-TO_DAYS(STR_TO_DATE(FechaNac,'%d/%m/%Y'))), '%Y')+0 > 17,'Hombres','Niños'))) as Total from s1_Integr inner join Encuestas on Encuestas.idEncuestas = s1_Integr.Encuestas_idEncuestas and Comunidad_idComunidad = @idComunidad";
                comando = new MySqlCommand(consulta, _conexion);
                comando.Parameters.AddWithValue("@idComunidad", idComunidad);
                comando.Connection.Open();
                comando.ExecuteNonQuery();
                comando.Connection.Close();

                DataSet ds = new DataSet();
                MySqlDataAdapter da = new MySqlDataAdapter(comando);
                da.Fill(ds);
                return ds.Tables[0];
            }
            catch (Exception ex)
            {
                comando.Connection.Close();
                MessageBox.Show("No se ha podido generar reporte", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        /*
         * Metodo para generar reporte de la seccion 2 de la encuesta
         */ 
        public DataTable Demografico(int idComunidad)
        {
            MySqlCommand comando = null;
            try
            {
                string consulta = "SELECT EstadoCivil, Departamento from s2_dem inner join Encuestas on Encuestas.idEncuestas = s2_dem.Encuestas_idEncuestas and Comunidad_idComunidad = @idComunidad";
                comando = new MySqlCommand(consulta, _conexion);
                comando.Parameters.AddWithValue("@idComunidad", idComunidad);
                comando.Connection.Open();
                comando.ExecuteNonQuery();
                comando.Connection.Close();

                DataSet ds = new DataSet();
                MySqlDataAdapter da = new MySqlDataAdapter(comando);
                da.Fill(ds);
                return ds.Tables[0];
            }
            catch (Exception ex)
            {
                comando.Connection.Close();
                MessageBox.Show("No se ha podido generar reporte", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        /*
         * Metodo para generar reporte de la seccion 3 de la encuesta
         */ 
        public DataTable Educacion(int idComunidad)
        {
            MySqlCommand comando = null;
            try
            {
                string consulta = "SELECT GradoEducacion, IF(LeerEscribir = 'Si', 'Sabe leer y escribir','No sabe leer y escribir') as Total from s3_edu inner join Encuestas on Encuestas.idEncuestas = s3_edu.Encuestas_idEncuestas and Comunidad_idComunidad = @idComunidad";
                comando = new MySqlCommand(consulta, _conexion);
                comando.Parameters.AddWithValue("@idComunidad", idComunidad);
                comando.Connection.Open();
                comando.ExecuteNonQuery();
                comando.Connection.Close();

                DataSet ds = new DataSet();
                MySqlDataAdapter da = new MySqlDataAdapter(comando);
                da.Fill(ds);
                return ds.Tables[0];
            }
            catch (Exception ex)
            {
                comando.Connection.Close();
                MessageBox.Show("No se ha podido generar reporte", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        /*
         * Metodo para generar reporte de salidas de alimentos
         */
        public DataTable SalidasInsumos(int idSalida)
        {
            MySqlCommand comando = null;
            try
            {
                string consulta = "SELECT FechaSalida, Descripcion, UserName, Cantidad, Alimentos.Nombre AS Alimento, Presentacion.Nombre AS Presentacion FROM Salida INNER JOIN Usuarios ON Usuarios.idUsuarios = Salida.Usuarios_idUsuarios INNER JOIN DetalleSalida ON DetalleSalida.Salida_idSalida = Salida.idSalida INNER JOIN Alimentos ON Alimentos.idAlimentos = DetalleSalida.Alimentos_idAlimentos INNER JOIN Presentacion ON Presentacion.idPresentacion = Alimentos.Presentacion_idPresentacion WHERE Salida.idSalida = @idSalida";
                comando = new MySqlCommand(consulta, _conexion);
                comando.Parameters.AddWithValue("@idSalida", idSalida);
                comando.Connection.Open();
                comando.ExecuteNonQuery();
                comando.Connection.Close();

                DataSet ds = new DataSet();
                MySqlDataAdapter da = new MySqlDataAdapter(comando);
                da.Fill(ds);
                return ds.Tables[0];
            }
            catch (Exception ex)
            {
                comando.Connection.Close();
                MessageBox.Show("No se ha podido generar reporte", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }
    }
}
