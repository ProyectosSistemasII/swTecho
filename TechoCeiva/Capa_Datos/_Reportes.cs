﻿using System;
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

        public DataTable GenerarTrabajo(int idComunidad)
        {
            try
            {
                string consulta = "SELECT IF(Trabajo = 1, 'Si Trabaja','No Trabaja') as Trabajo, Ocupacion, ContratoTrabajo, CondicionLaboral, UbicacionTrabajo, IF(OtrosTrabajos = 1,'Si Otros', 'No Otros') as OtrosTrabajos FROM s5_tra INNER JOIN Encuestas ON Comunidad_idComunidad = @idComunidad AND Encuestas_idEncuestas = s5_Tra.Encuestas_idEncuestas";
                MySqlCommand comando = new MySqlCommand(consulta, _conexion);
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
                MessageBox.Show("No se ha podido generar reporte", "Error",  MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        public DataTable ClasificacionTotalPersonas(int idComunidad)
        {
            try
            {
                string consulta = "SELECT if(Genero = 'Mujer' AND Embarazo = 'No' AND DATE_FORMAT(FROM_DAYS(TO_DAYS(NOW())-TO_DAYS(STR_TO_DATE(FechaNac,'%d/%m/%Y'))), '%Y')+0 > 17, 'Mujeres no embarazadas',if(Genero = 'Mujer' AND Embarazo = 'Si' AND DATE_FORMAT(FROM_DAYS(TO_DAYS(NOW())-TO_DAYS(STR_TO_DATE(FechaNac,'%d/%m/%Y'))), '%Y')+0 > 17,'Mujeres embarazadas',if(Genero = 'Hombre'AND DATE_FORMAT(FROM_DAYS(TO_DAYS(NOW())-TO_DAYS(STR_TO_DATE(FechaNac,'%d/%m/%Y'))), '%Y')+0 > 17,'Hombres','Niños'))) as Total from s1_Integr inner join Encuestas on Encuestas.idEncuestas = s1_Integr.Encuestas_idEncuestas and Comunidad_idComunidad = @idComunidad";
                MySqlCommand comando = new MySqlCommand(consulta, _conexion);
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
                MessageBox.Show("No se ha podido generar reporte", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        public DataTable Demografico(int idComunidad)
        {
            try
            {
                string consulta = "SELECT EstadoCivil, Departamento from s2_dem inner join Encuestas on Encuestas.idEncuestas = s2_dem.Encuestas_idEncuestas and Comunidad_idComunidad = @idComunidad";
                MySqlCommand comando = new MySqlCommand(consulta, _conexion);
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
                MessageBox.Show("No se ha podido generar reporte", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        public DataTable DepartamentoOrigen(int idComunidad)
        {
            try
            {
                string consulta = "SELECT Departamento from s2_dem inner join Encuestas on Encuestas.idEncuestas = s2_dem.Encuestas_idEncuestas and Comunidad_idComunidad = @idComunidad";
                MySqlCommand comando = new MySqlCommand(consulta, _conexion);
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
                MessageBox.Show("No se ha podido generar reporte", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        public DataTable LeerEscribir(int idComunidad)
        {
            try
            {
                string consulta = "SELECT IF(LeerEscribir = 'Si', 'Sabe leer y escribir','No sabe leer y escribir') as Total from s3_edu inner join Encuestas on Encuestas.idEncuestas = s3_edu.Encuestas_idEncuestas and Comunidad_idComunidad = @idComunidad";
                MySqlCommand comando = new MySqlCommand(consulta, _conexion);
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
                MessageBox.Show("No se ha podido generar reporte", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        public DataTable GradoEducacion(int idComunidad)
        {
            try
            {
                string consulta = "SELECT GradoEducacion from s3_edu inner join Encuestas on Encuestas.idEncuestas = s3_edu.Encuestas_idEncuestas and Comunidad_idComunidad = @idComunidad";
                MySqlCommand comando = new MySqlCommand(consulta, _conexion);
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
                MessageBox.Show("No se ha podido generar reporte", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }
    }
}
