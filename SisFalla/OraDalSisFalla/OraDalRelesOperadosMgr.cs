using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.ComponentModel;
using ModeloSisFalla;
using Oracle.DataAccess.Client;
using CNDC.Pistas;
using CNDC.DAL;
using CNDC.Sincronizacion;
using CNDC.BLL;

namespace OraDalSisFalla
{
    public class OraDalRelesOperadosMgr : OraDalBaseMgr, IRelesOperadosMgr, IMgrLocal, IProveedorDatosSincronizacion
    {
        public OraDalRelesOperadosMgr()
        {

        }
        public OraDalRelesOperadosMgr(ConnexionOracleMgr c)
            : base(c)
        { }

        public  long GetValorSecReleOperFunc(RelesOperados item)
        {
            long rtn = 0 ;
            OracleCommand cmd = null;
            string sql = @"SELECT NVL (MAX (sec_rele_oper_func),0) +1
                            FROM f_gf_reles_oper
                            WHERE pk_cod_falla       = :pk_cod_falla
                            AND pk_origen_informe    = :pk_origen_informe
                            AND pk_d_cod_tipoinforme = :pk_d_cod_tipoinforme
                            AND pk_cod_componente    = :pk_cod_componente
                            AND funcion_rele         = :funcion_rele
                            AND fec_apertura         = :fec_apertura ";
            cmd = CrearCommand();
            cmd.CommandText = sql;
            cmd.BindByName = true;
            cmd.Parameters.Add(RelesOperados.C_PK_COD_FALLA, OracleDbType.Int64, item.PkCodFalla, System.Data.ParameterDirection.Input);
            cmd.Parameters.Add(RelesOperados.PK_ORIGEN_INFORME, OracleDbType.Int64, item.PkOrigenFalla, System.Data.ParameterDirection.Input);
            cmd.Parameters.Add(RelesOperados.C_PK_D_COD_TIPOINFORME, OracleDbType.Int64, item.PkDCodTipoinforme, System.Data.ParameterDirection.Input);
            cmd.Parameters.Add(RelesOperados.C_PK_COD_COMPONENTE, OracleDbType.Int64, item.PkCodComponente, System.Data.ParameterDirection.Input);
            cmd.Parameters.Add(RelesOperados.C_FUNCION, OracleDbType.Varchar2, item.Funcion, System.Data.ParameterDirection.Input);
            cmd.Parameters.Add(RelesOperados.C_FEC_APERTURA, OracleDbType.TimeStamp, item.FecApertura, System.Data.ParameterDirection.Input);
            DataTable dt = EjecutarCmd(cmd);
            if (dt != null)
            {
                if (dt.Rows.Count > 0)
                {
                    rtn = (long)(decimal)dt.Rows[0][0];
                }
            }

                return rtn ;
        }

        public void Guardar(RelesOperados obj)
        {
            OracleCommand cmd = null;
            string sql = string.Empty;
            if (obj.EsNuevo)
            {
                //Pista p = PistaMgr.Instance.Info("DALSisFalla", obj.GetEstadoString());
                //obj.SecLog = (long)p.PK_SecLog;
                sql = "INSERT INTO {0} ({1},{2},{3},{4},{5},{6},{7},{8},{9},{10},{11},{12},{13})" +
                "VALUES(:{1},:{2},:{3},:{4},:{5},:{6},:{7},:{8},:{9},:{10},:{11},:{12},:{13})";
                obj.SecReleOperFunc = GetValorSecReleOperFunc(obj);
            }
            else
            {
                sql = "UPDATE {0} SET " +
                "{7}=:{7} ," +
                "{8}=:{8} ," +
                "{9}=:{9} ," +
                "{10}=:{10}, " +
                "{11}=:{11}, " +
                "{12}=:{12} " +
                "WHERE " +
                "{1}=:{1} AND " +
                "{2}=:{2} AND " +
                "{3}=:{3} AND " +
                "{4}=:{4} AND " +
                "{5}=:{5} AND " +
                "{6}=:{6} AND " +
                "{13}=:{13} " ;
            }

            sql = string.Format(sql, RelesOperados.NOMBRE_TABLA,
            RelesOperados.C_PK_COD_FALLA,
            RelesOperados.PK_ORIGEN_INFORME,
            RelesOperados.C_PK_D_COD_TIPOINFORME,
            RelesOperados.C_PK_COD_COMPONENTE,
            RelesOperados.C_FUNCION,
            RelesOperados.C_FEC_APERTURA,
            RelesOperados.C_TIPO_RELE,
            RelesOperados.C_TIEMPO,
            RelesOperados.C_ZONA,
            RelesOperados.C_DIS,
            RelesOperados.C_NUMERO,
            RelesOperados.C_SINC_VER,
            RelesOperados.C_SEC_RELE_OPER_FUNC );
            cmd = CrearCommand();
            cmd.CommandText = sql;
            cmd.BindByName = true;
            cmd.Parameters.Add(RelesOperados.C_PK_COD_FALLA, OracleDbType.Int64, obj.PkCodFalla, System.Data.ParameterDirection.Input);
            cmd.Parameters.Add(RelesOperados.PK_ORIGEN_INFORME, OracleDbType.Int64, obj.PkOrigenFalla, System.Data.ParameterDirection.Input);
            cmd.Parameters.Add(RelesOperados.C_PK_D_COD_TIPOINFORME, OracleDbType.Int64, obj.PkDCodTipoinforme, System.Data.ParameterDirection.Input);
            cmd.Parameters.Add(RelesOperados.C_PK_COD_COMPONENTE, OracleDbType.Int64, obj.PkCodComponente, System.Data.ParameterDirection.Input);
            cmd.Parameters.Add(RelesOperados.C_FUNCION, OracleDbType.Varchar2, obj.Funcion, System.Data.ParameterDirection.Input);
            cmd.Parameters.Add(RelesOperados.C_FEC_APERTURA, OracleDbType.TimeStamp, obj.FecApertura, System.Data.ParameterDirection.Input);
            cmd.Parameters.Add(RelesOperados.C_TIPO_RELE, OracleDbType.Varchar2, obj.TipoRele, System.Data.ParameterDirection.Input);
            cmd.Parameters.Add(RelesOperados.C_TIEMPO, OracleDbType.Double, obj.Tiempo, System.Data.ParameterDirection.Input);
            cmd.Parameters.Add(RelesOperados.C_ZONA, OracleDbType.Double, obj.Zona, System.Data.ParameterDirection.Input);
            cmd.Parameters.Add(RelesOperados.C_DIS, OracleDbType.Double, obj.Distancia, System.Data.ParameterDirection.Input);
            cmd.Parameters.Add(RelesOperados.C_NUMERO, OracleDbType.Double, obj.Numero, System.Data.ParameterDirection.Input);
            cmd.Parameters.Add(RelesOperados.C_SINC_VER, OracleDbType.Int64, obj.SincVer, System.Data.ParameterDirection.Input);
            cmd.Parameters.Add(RelesOperados.C_SEC_RELE_OPER_FUNC, OracleDbType.Int64, obj.SecReleOperFunc, System.Data.ParameterDirection.Input);

            if (Actualizar(cmd))
            {
                obj.EsNuevo = false;
            }
        }

        public DataTable GetTabla()
        {
            DataTable tabla = GetTabla(RelesOperados.NOMBRE_TABLA);
            return tabla;
        }

        public BindingList<RelesOperados> GetLista()
        {
            BindingList<RelesOperados> resultado = new BindingList<RelesOperados>();
            DataTable tablaAgentes = GetTabla();
            foreach (DataRow row in tablaAgentes.Rows)
            {
                resultado.Add(new RelesOperados(row));
            }
            return resultado;
        }

        public DataTable GetTablaRelesOperador(OperacionInterruptores opInterruptor)
        {
            string sql =
            @"SELECT * 
            FROM F_GF_RELES_OPER 
            WHERE 
            pk_cod_componente=:pk_cod_componente AND 
            pk_cod_falla=:pk_cod_falla AND 
            pk_d_cod_tipoinforme=:pk_d_cod_tipoinforme AND 
            PK_ORIGEN_INFORME=:PK_ORIGEN_INFORME AND
            FEC_APERTURA=:FEC_APERTURA";
            OracleCommand cmd = CrearCommand();
            cmd.CommandText = sql;
            cmd.Parameters.Add(RelesOperados.C_PK_COD_COMPONENTE, OracleDbType.Decimal, opInterruptor.PkCodComponente, System.Data.ParameterDirection.Input);
            cmd.Parameters.Add(RelesOperados.C_PK_COD_FALLA, OracleDbType.Int64, opInterruptor.PkCodFalla, System.Data.ParameterDirection.Input);
            cmd.Parameters.Add(RelesOperados.C_PK_D_COD_TIPOINFORME, OracleDbType.Int64, opInterruptor.PkDCodInforme, System.Data.ParameterDirection.Input);
            cmd.Parameters.Add(RelesOperados.PK_ORIGEN_INFORME, OracleDbType.Int64, opInterruptor.PkOrigenInforme, System.Data.ParameterDirection.Input);
            cmd.Parameters.Add(RelesOperados.C_FEC_APERTURA, OracleDbType.TimeStamp, opInterruptor.FechaApertura, System.Data.ParameterDirection.Input);
            cmd.BindByName = true;

            DataTable tabla = EjecutarCmd(cmd);
            return tabla;
        }

        public BindingList<RelesOperados> GetLista(OperacionInterruptores opInterruptor)
        {
            BindingList<RelesOperados> resultado = new BindingList<RelesOperados>();
            DataTable tablaAgentes = GetTablaRelesOperador(opInterruptor);
            foreach (DataRow row in tablaAgentes.Rows)
            {
                resultado.Add(new RelesOperados(row));
            }
            return resultado;
        }

        public void Borrar(RelesOperados item)
        {
            string sql =
            @"DELETE
            FROM F_GF_RELES_OPER
            WHERE PK_COD_FALLA       = :PK_COD_FALLA
            AND PK_ORIGEN_INFORME    = :PK_ORIGEN_INFORME
            AND PK_D_COD_TIPOINFORME = :PK_D_COD_TIPOINFORME
            AND PK_COD_COMPONENTE    = :PK_COD_COMPONENTE
            AND FUNCION_RELE         = :FUNCION_RELE
            AND FEC_APERTURA         = :FEC_APERTURA
            AND SEC_RELE_OPER_FUNC   = :SEC_RELE_OPER_FUNC
            ";
            OracleCommand cmd = CrearCommand();
            cmd.CommandText = sql;
            cmd.Parameters.Add("PK_COD_FALLA", OracleDbType.Int32, item.PkCodFalla, System.Data.ParameterDirection.Input);
            cmd.Parameters.Add("PK_ORIGEN_INFORME", OracleDbType.Int64, item.PkOrigenFalla, System.Data.ParameterDirection.Input);
            cmd.Parameters.Add("PK_D_COD_TIPOINFORME", OracleDbType.Int64, item.PkDCodTipoinforme, System.Data.ParameterDirection.Input);
            cmd.Parameters.Add("PK_COD_COMPONENTE", OracleDbType.Int64, item.PkCodComponente, System.Data.ParameterDirection.Input);
            cmd.Parameters.Add("FUNCION_RELE", OracleDbType.Varchar2, item.Funcion, System.Data.ParameterDirection.Input);
            cmd.Parameters.Add("FEC_APERTURA", OracleDbType.TimeStamp, item.FecApertura, System.Data.ParameterDirection.Input);
            cmd.Parameters.Add("SEC_RELE_OPER_FUNC", OracleDbType.Int64, item.SecReleOperFunc, System.Data.ParameterDirection.Input);
            cmd.BindByName = true;

            Actualizar(cmd);
        }

        #region IMgrLocal

        public string NombreTabla
        {
            get { return RelesOperados.NOMBRE_TABLA; }
        }
        #endregion IMgrLocal

        public DataTable GetDatos(decimal versionCliente, long pkCodPersona, bool parcial)
        {
            DataTable resultado = null;
            string sql = string.Empty;
            if (parcial)
            {
                sql = @"SELECT a.* 
                FROM F_GF_RELES_OPER a
                WHERE a.sinc_ver > :sinc_ver 
                AND 
                (   VERIFICARENVIAD(a.pk_cod_falla,a.pk_origen_informe,a.pk_d_cod_tipoinforme,3594)  > 0 
                    OR a.pk_origen_informe=:pk_cod_persona
                )
                AND a.pk_cod_falla IN 
                (SELECT b.pk_cod_falla
                FROM f_gf_notificacion b
                WHERE b.pk_cod_persona=:pk_cod_persona AND b.D_COD_ESTADO_NOTIFICACION <> 41)";
            }
            else
            {
                sql = @"SELECT a.* 
                FROM F_GF_RELES_OPER a
                WHERE a.sinc_ver > :sinc_ver 
                AND 
                (   VERIFICARENVIAD(a.pk_cod_falla,a.pk_origen_informe,a.pk_d_cod_tipoinforme,3594)  > 0 
                    OR a.pk_origen_informe=:pk_cod_persona
                )";
            }
            OracleCommand cmd = CrearCommand();
            cmd.CommandText = sql;
            cmd.Parameters.Add("sinc_ver", OracleDbType.Decimal, versionCliente, System.Data.ParameterDirection.Input);
            cmd.Parameters.Add("pk_cod_persona", OracleDbType.Int64, pkCodPersona, System.Data.ParameterDirection.Input);
            cmd.BindByName = true;

            resultado = EjecutarCmd(cmd);
            return resultado;
        }

        public void Insertar(List<DataRow> tabla)
        {
            string sql = "INSERT INTO {0} ({1},{2},{3},{4},{5},{6},{7},{8},{9},{10},{11},{12},{13})" +
                "VALUES(:{1},:{2},:{3},:{4},:{5},:{6},:{7},:{8},:{9},:{10},:{11},:{12},:{13})";
            InsertUpdate(tabla, sql);
        }

        public void Actualizar(List<DataRow> tabla)
        {
            string sql = "UPDATE {0} SET " +
                "{7}=:{7} ," +
                "{8}=:{8} ," +
                "{9}=:{9} ," +
                "{10}=:{10}, " +
                "{11}=:{11}, " +
                "{12}=:{12}, " +
                "{13}=:{13} " +
                "WHERE " +
                "{1}=:{1} AND " +
                "{2}=:{2} AND " +
                "{3}=:{3} AND " +
                "{4}=:{4} AND " +
                "{5}=:{5} AND " +
                "{6}=:{6}";
            InsertUpdate(tabla, sql);
        }

        void InsertUpdate(List<DataRow> tabla, string sql)
        {
            OracleCommand cmd = null;

            sql = string.Format(sql, RelesOperados.NOMBRE_TABLA,
            RelesOperados.C_PK_COD_FALLA,
            RelesOperados.PK_ORIGEN_INFORME,
            RelesOperados.C_PK_D_COD_TIPOINFORME,
            RelesOperados.C_PK_COD_COMPONENTE,
            RelesOperados.C_FUNCION,
            RelesOperados.C_FEC_APERTURA,
            RelesOperados.C_TIPO_RELE,
            RelesOperados.C_TIEMPO,
            RelesOperados.C_ZONA,
            RelesOperados.C_DIS,
            RelesOperados.C_NUMERO,
            RelesOperados.C_SINC_VER,
            RelesOperados.C_SEC_RELE_OPER_FUNC);
            cmd = CrearCommand();
            cmd.CommandText = sql;
            cmd.BindByName = true;
            cmd.ArrayBindCount = tabla.Count;
            cmd.Parameters.Add(RelesOperados.C_PK_COD_FALLA, OracleDbType.Int64, GetArray(tabla, RelesOperados.C_PK_COD_FALLA), System.Data.ParameterDirection.Input);
            cmd.Parameters.Add(RelesOperados.PK_ORIGEN_INFORME, OracleDbType.Int64, GetArray(tabla, RelesOperados.PK_ORIGEN_INFORME), System.Data.ParameterDirection.Input);
            cmd.Parameters.Add(RelesOperados.C_PK_D_COD_TIPOINFORME, OracleDbType.Int64, GetArray(tabla, RelesOperados.C_PK_D_COD_TIPOINFORME), System.Data.ParameterDirection.Input);
            cmd.Parameters.Add(RelesOperados.C_PK_COD_COMPONENTE, OracleDbType.Int64, GetArray(tabla, RelesOperados.C_PK_COD_COMPONENTE), System.Data.ParameterDirection.Input);
            cmd.Parameters.Add(RelesOperados.C_FUNCION, OracleDbType.Varchar2, GetArray(tabla, RelesOperados.C_FUNCION), System.Data.ParameterDirection.Input);
            cmd.Parameters.Add(RelesOperados.C_FEC_APERTURA, OracleDbType.TimeStamp, GetArray(tabla, RelesOperados.C_FEC_APERTURA), System.Data.ParameterDirection.Input);
            cmd.Parameters.Add(RelesOperados.C_TIPO_RELE, OracleDbType.Varchar2, GetArray(tabla, RelesOperados.C_TIPO_RELE), System.Data.ParameterDirection.Input);
            cmd.Parameters.Add(RelesOperados.C_TIEMPO, OracleDbType.Double, GetArray(tabla, RelesOperados.C_TIEMPO), System.Data.ParameterDirection.Input);
            cmd.Parameters.Add(RelesOperados.C_ZONA, OracleDbType.Double, GetArray(tabla, RelesOperados.C_ZONA), System.Data.ParameterDirection.Input);
            cmd.Parameters.Add(RelesOperados.C_DIS, OracleDbType.Double, GetArray(tabla, RelesOperados.C_DIS), System.Data.ParameterDirection.Input);
            cmd.Parameters.Add(RelesOperados.C_NUMERO, OracleDbType.Double, GetArray(tabla, RelesOperados.C_NUMERO), System.Data.ParameterDirection.Input);
            cmd.Parameters.Add(RelesOperados.C_SINC_VER, OracleDbType.Int64, GetArray(tabla, RelesOperados.C_SINC_VER), System.Data.ParameterDirection.Input);
            cmd.Parameters.Add(RelesOperados.C_SEC_RELE_OPER_FUNC, OracleDbType.Int64, GetArray(tabla, RelesOperados.C_SEC_RELE_OPER_FUNC), System.Data.ParameterDirection.Input);

            Actualizar(cmd);
        }
    }
}