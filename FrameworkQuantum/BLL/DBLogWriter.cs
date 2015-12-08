using System;
using System.Collections.Generic;
using System.Text;
using CNDC.Pistas;
using Oracle.DataAccess.Client;
using CNDC.DAL;
using System.Data;

namespace CNDC.BLL
{
    public class DBLogWriter : IRegistradorPista
    {
        public bool Registrar(Pista e)
        {
            bool result = false;
            string detalle = e.Detalle;
            if (detalle.Length > 3900)
            {
                detalle = detalle.Substring(0, 3900);
            }

            if (Sesion.Instancia.Conexion.EstadoConexion == ConnectionState.Open)
            {
                string tableName = "F_AL_ERROR";
                OracleCommand cmd = null;
                if (e.Tipo == TipoPista.Debug || e.Tipo == TipoPista.Info)
                {
                    tableName = "F_AL_LOG";
                    e.PK_SecLog = GetId(tableName);
                    cmd = Sesion.Instancia.Conexion.CrearCommand();
                    cmd.CommandText = string.Format(
                        "INSERT INTO {0} (pk_sec_log,fecha_hora,modulo,usuario,ip,tipo,detalle) ", tableName) +
                        "VALUES (:pk_sec_log,:fecha_hora,:modulo,:usuario,:p_ip,:tipo,:detalle)";
                    cmd.Parameters.Add("pk_sec_log", OracleDbType.Int64 , e.PK_SecLog, ParameterDirection.Input);
                    cmd.Parameters.Add("fecha_hora", OracleDbType.Date, e.FechaHora, ParameterDirection.Input);
                    cmd.Parameters.Add("modulo", OracleDbType.Varchar2, e.Modulo, ParameterDirection.Input);
                    cmd.Parameters.Add("usuario", OracleDbType.Varchar2, e.Usuario, ParameterDirection.Input);
                    cmd.Parameters.Add("p_ip", OracleDbType.Varchar2, e.IP, ParameterDirection.Input);
                    cmd.Parameters.Add("tipo", OracleDbType.Varchar2, e.Tipo, ParameterDirection.Input);
                    cmd.Parameters.Add("detalle", OracleDbType.Varchar2, detalle, ParameterDirection.Input);
                }
                else
                {
                    e.PK_SecLog = GetId(tableName);
                    cmd = Sesion.Instancia.Conexion.CrearCommand();
                    cmd.CommandText = string.Format(
                        "INSERT INTO {0} (pk_cod_error,fecha_hora,modulo,usuario,ip,tipo,excepcion,detalle) ", tableName) +
                        "VALUES (:pk_cod_error,:fecha_hora,:modulo,:usuario,:p_ip,:tipo,:excepcion,:detalle)";
                    cmd.Parameters.Add("pk_cod_error", OracleDbType.Int64, (long)e.PK_SecLog, ParameterDirection.Input);
                    cmd.Parameters.Add("fecha_hora", OracleDbType.Date, e.FechaHora, ParameterDirection.Input);
                    cmd.Parameters.Add("modulo", OracleDbType.Varchar2, e.Modulo, ParameterDirection.Input);
                    cmd.Parameters.Add("usuario", OracleDbType.Varchar2, e.Usuario, ParameterDirection.Input);
                    cmd.Parameters.Add("p_ip", OracleDbType.Varchar2, e.IP, ParameterDirection.Input);
                    cmd.Parameters.Add("tipo", OracleDbType.Varchar2, e.Tipo.ToString(), ParameterDirection.Input);
                    cmd.Parameters.Add("excepcion", OracleDbType.Varchar2, e.Excepcion, ParameterDirection.Input);
                    cmd.Parameters.Add("detalle", OracleDbType.Varchar2, detalle, ParameterDirection.Input);
                }

                result = Sesion.Instancia.Conexion.Actualizar(cmd);
            }
            return result;
        }

        protected decimal GetId(string tableName)
        {
            decimal num = 0;
            OracleCommand cmd = Sesion.Instancia.Conexion.CrearCommand();
            cmd.CommandText = "select SQ_SEC_LOG.NEXTVAL from dual";
            cmd.CommandType = System.Data.CommandType.Text;
            try
            {
                num = (decimal)cmd.ExecuteScalar();
            }
            catch (OracleException)
            {
                //orcl.HandleOracleException(exception);
            }
            catch (Exception)
            {
                //MessageBox.Show(exception2.ToString());
                //Program.ExceptionLog(exception2);
            }
            finally
            {
                Sesion.Instancia.Conexion.DisposeCommand(cmd);
            }
            return num;
        }
    }
}
