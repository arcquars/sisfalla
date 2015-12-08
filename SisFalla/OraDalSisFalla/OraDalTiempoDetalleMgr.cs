using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.ComponentModel;
using CNDC.DAL;
using CNDC.Pistas;
using Oracle.DataAccess.Client;
using ModeloSisFalla;
using CNDC.Sincronizacion;
using CNDC.BLL;

namespace OraDalSisFalla
{
    public class OraDalTiempoDetalleMgr : OraDalBaseMgr, ITiempoDetalleMgr, IMgrLocal, IProveedorDatosSincronizacion
    {
        public OraDalTiempoDetalleMgr()
        {

        }
        public OraDalTiempoDetalleMgr(ConnexionOracleMgr c)
            : base(c)
        { }

        public void Guardar(TiempoDetalle obj)
        {
            OracleCommand cmd = null;
            string sql = string.Empty;
            if (obj.EsNuevo)
            {
                Pista p = PistaMgr.Instance.Info("DALSisFalla", obj.GetEstadoString());
                obj.SecLog = (long)p.PK_SecLog;
                sql = "INSERT INTO {0} ({1},{2},{3},{4},{5},{6},{7},{8},{9},{10},{11},{12},{13},{14})" +
                "VALUES(:{1},:{2},:{3},:{4},:{5},:{6},:{7},:{8},:{9},:{10},:{11},:{12},:{13},:{14})";
            }
            else
            {
                sql = "UPDATE {0} SET " +
                "{7}=:{7} ," +
                "{8}=:{8} ," +
                "{9}=:{9} ," +
                "{10}=:{10} ," +
                "{11}=:{11} ," +
                "{12}=:{12} ," +
                "{13}=:{13} ," +
                "{14}=:{14} " +
                "WHERE {1}=:{1} and {2}=:{2} and {3}=:{3} and {4}=:{4} and {5}=:{5} and {6}=:{6}";
            }

            sql = string.Format(sql, TiempoDetalle.NOMBRE_TABLA,
            TiempoDetalle.C_PK_COD_FALLA,
            TiempoDetalle.C_PK_D_COD_TIPOINFORME,
            TiempoDetalle.C_PK_ORIGEN_INFORME,
            TiempoDetalle.C_PK_COD_COMPONENTE,
            TiempoDetalle.C_PK_COD_PERSONA,
            TiempoDetalle.C_FEC_APERTURA,
            TiempoDetalle.C_TIEMPO_INDISPONIBILIDAD,
            TiempoDetalle.C_TIEMPO_PRECONEXION,
            TiempoDetalle.C_TIEMPO_CONEXION,
            TiempoDetalle.C_FK_COD_RESPONSABLE,
            TiempoDetalle.C_D_COD_MOTIVO,
            TiempoDetalle.C_D_COD_ESTADO,
            TiempoDetalle.C_SEC_LOG,
            TiempoDetalle.C_SINC_VER);
            cmd = CrearCommand();
            cmd.CommandText = sql;
            cmd.BindByName = true;
            cmd.Parameters.Add(TiempoDetalle.C_PK_COD_FALLA, OracleDbType.Int32, obj.PkCodFalla, System.Data.ParameterDirection.Input);
            cmd.Parameters.Add(TiempoDetalle.C_PK_D_COD_TIPOINFORME, OracleDbType.Int64, obj.PkDCodTipoinforme, System.Data.ParameterDirection.Input);
            cmd.Parameters.Add(TiempoDetalle.C_PK_ORIGEN_INFORME, OracleDbType.Int64, obj.PkOrigenInforme, System.Data.ParameterDirection.Input);
            cmd.Parameters.Add(TiempoDetalle.C_PK_COD_COMPONENTE, OracleDbType.Int64, obj.PkCodComponente, System.Data.ParameterDirection.Input);
            cmd.Parameters.Add(TiempoDetalle.C_PK_COD_PERSONA, OracleDbType.Int64, obj.PkCodPersona, System.Data.ParameterDirection.Input);
            cmd.Parameters.Add(TiempoDetalle.C_FEC_APERTURA, OracleDbType.Date, obj.FecApertura, System.Data.ParameterDirection.Input);
            cmd.Parameters.Add(TiempoDetalle.C_TIEMPO_INDISPONIBILIDAD, OracleDbType.Single, obj.TiempoIndisponibilidad, System.Data.ParameterDirection.Input);
            cmd.Parameters.Add(TiempoDetalle.C_TIEMPO_PRECONEXION, OracleDbType.Single, obj.TiempoPreconexion, System.Data.ParameterDirection.Input);
            cmd.Parameters.Add(TiempoDetalle.C_TIEMPO_CONEXION, OracleDbType.Single, obj.TiempoConexion, System.Data.ParameterDirection.Input);
            cmd.Parameters.Add(TiempoDetalle.C_FK_COD_RESPONSABLE, OracleDbType.Int64, obj.FkCodResponsable, System.Data.ParameterDirection.Input);
            cmd.Parameters.Add(TiempoDetalle.C_D_COD_MOTIVO, OracleDbType.Int64, obj.DCodMotivo, System.Data.ParameterDirection.Input);
            cmd.Parameters.Add(TiempoDetalle.C_D_COD_ESTADO, OracleDbType.Varchar2, obj.DCodEstado, System.Data.ParameterDirection.Input);
            cmd.Parameters.Add(TiempoDetalle.C_SEC_LOG, OracleDbType.Int64, obj.SecLog, System.Data.ParameterDirection.Input);
            cmd.Parameters.Add(TiempoDetalle.C_SINC_VER, OracleDbType.Int64, obj.SincVer, System.Data.ParameterDirection.Input);

            if (Actualizar(cmd))
            {
                obj.EsNuevo = false;
            }
        }

        public DataTable GetTabla()
        {
            DataTable tabla = GetTabla(TiempoDetalle.NOMBRE_TABLA);
            return tabla;
        }

        public BindingList<TiempoDetalle> GetLista()
        {
            BindingList<TiempoDetalle> resultado = new BindingList<TiempoDetalle>();
            DataTable tablaAgentes = GetTabla();
            foreach (DataRow row in tablaAgentes.Rows)
            {
                resultado.Add(new TiempoDetalle(row));
            }
            return resultado;
        }

        public DataTable GetTiempos(RRegFallaComponente comp)
        {
            DataTable resultado = null;
            string sql =
            @"SELECT t.*, p.sigla 
            FROM f_gf_tiemposdetalle t, f_ap_persona p 
            WHERE t.pk_cod_persona=p.pk_cod_persona and 
            t.pk_cod_falla=:{0} AND 
            t.pk_origen_informe=:{1} AND 
            t.pk_cod_componente=:{2} AND 
            t.pk_d_cod_tipoinforme=:{3} AND 
            t.FEC_APERTURA=:{4}
            ORDER BY p.Sigla";

            sql = string.Format(sql,
                TiempoDetalle.C_PK_COD_FALLA,
                TiempoDetalle.C_PK_ORIGEN_INFORME,
                TiempoDetalle.C_PK_COD_COMPONENTE,
                TiempoDetalle.C_PK_D_COD_TIPOINFORME,
                TiempoDetalle.C_FEC_APERTURA
                );

            OracleCommand cmd = CrearCommand();
            cmd.CommandText = sql;
            cmd.BindByName = true;
            cmd.Parameters.Add(TiempoDetalle.C_PK_COD_FALLA, OracleDbType.Int32, comp.PkCodFalla, System.Data.ParameterDirection.Input);
            cmd.Parameters.Add(TiempoDetalle.C_PK_ORIGEN_INFORME, OracleDbType.Int64, comp.PkOrigenInforme, System.Data.ParameterDirection.Input);
            cmd.Parameters.Add(TiempoDetalle.C_PK_D_COD_TIPOINFORME, OracleDbType.Int64, comp.PkDCodTipoinforme, System.Data.ParameterDirection.Input);
            cmd.Parameters.Add(TiempoDetalle.C_PK_COD_COMPONENTE, OracleDbType.Decimal, comp.PkCodComponente, System.Data.ParameterDirection.Input);
            cmd.Parameters.Add(TiempoDetalle.C_FEC_APERTURA, OracleDbType.Date, comp.FecApertura, System.Data.ParameterDirection.Input);
            resultado = EjecutarCmd(cmd);
            return resultado;
        }

        #region IMgrLocal

        public string NombreTabla
        {
            get { return TiempoDetalle.NOMBRE_TABLA; }
        }
        #endregion IMgrLocal

        public void Eliminar(TiempoDetalle t)
        {
            string sql =
            @"DELETE FROM F_GF_TIEMPOSDETALLE 
            WHERE PK_COD_FALLA=:PK_COD_FALLA 
            AND PK_D_COD_TIPOINFORME=:PK_D_COD_TIPOINFORME 
            AND PK_ORIGEN_INFORME=:PK_ORIGEN_INFORME  
            AND PK_COD_COMPONENTE=:PK_COD_COMPONENTE 
            AND PK_COD_PERSONA=:PK_COD_PERSONA 
            AND FEC_APERTURA=:FEC_APERTURA";
            
            OracleCommand cmd = CrearCommand();
            cmd.CommandText = sql;

            cmd.Parameters.Add(TiempoDetalle.C_PK_COD_FALLA, OracleDbType.Int32, t.PkCodFalla, ParameterDirection.Input);
            cmd.Parameters.Add(TiempoDetalle.C_PK_D_COD_TIPOINFORME, OracleDbType.Int64, t.PkDCodTipoinforme, ParameterDirection.Input);
            cmd.Parameters.Add(TiempoDetalle.C_PK_ORIGEN_INFORME, OracleDbType.Int64, t.PkOrigenInforme, ParameterDirection.Input);
            cmd.Parameters.Add(TiempoDetalle.C_PK_COD_COMPONENTE, OracleDbType.Int64, t.PkCodComponente, ParameterDirection.Input);
            cmd.Parameters.Add(TiempoDetalle.C_PK_COD_PERSONA, OracleDbType.Int64, t.PkCodPersona, ParameterDirection.Input);
            cmd.Parameters.Add(TiempoDetalle.C_FEC_APERTURA, OracleDbType.Date, t.FecApertura, ParameterDirection.Input);
            cmd.BindByName = true;
            Actualizar(cmd);
        }

        public DataTable GetDatos(decimal versionCliente, long pkCodPersona, bool parcial)
        {
            DataTable resultado = null;
            string sql = string.Empty;
            if (parcial)
            {
                sql = @"SELECT a.*
                FROM F_GF_TIEMPOSDETALLE a
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
                FROM F_GF_TIEMPOSDETALLE a
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
            string sql = "INSERT INTO {0} ({1},{2},{3},{4},{5},{6},{7},{8},{9},{10},{11},{12},{13},{14})" +
                "VALUES(:{1},:{2},:{3},:{4},:{5},:{6},:{7},:{8},:{9},:{10},:{11},:{12},:{13},:{14})";
            InsertUpdate(tabla, sql);
        }

        public void Actualizar(List<DataRow> tabla)
        {
            string sql = "UPDATE {0} SET " +
                "{7}=:{7} ," +
                "{8}=:{8} ," +
                "{9}=:{9} ," +
                "{10}=:{10} ," +
                "{11}=:{11} ," +
                "{12}=:{12} ," +
                "{13}=:{13}, " +
                "{14}=:{14} " +
                "WHERE {1}=:{1} and {2}=:{2} and {3}=:{3} and {4}=:{4} and {5}=:{5} and {6}=:{6}";
            InsertUpdate(tabla, sql);
        }

        void InsertUpdate(List<DataRow> tabla, string sql)
        {
            OracleCommand cmd = null;

            sql = string.Format(sql, TiempoDetalle.NOMBRE_TABLA,
            TiempoDetalle.C_PK_COD_FALLA,
            TiempoDetalle.C_PK_D_COD_TIPOINFORME,
            TiempoDetalle.C_PK_ORIGEN_INFORME,
            TiempoDetalle.C_PK_COD_COMPONENTE,
            TiempoDetalle.C_PK_COD_PERSONA,
            TiempoDetalle.C_FEC_APERTURA,
            TiempoDetalle.C_TIEMPO_INDISPONIBILIDAD,
            TiempoDetalle.C_TIEMPO_PRECONEXION,
            TiempoDetalle.C_TIEMPO_CONEXION,
            TiempoDetalle.C_FK_COD_RESPONSABLE,
            TiempoDetalle.C_D_COD_MOTIVO,
            TiempoDetalle.C_D_COD_ESTADO,
            TiempoDetalle.C_SEC_LOG,
            TiempoDetalle.C_SINC_VER);
            cmd = CrearCommand();
            cmd.CommandText = sql;
            cmd.BindByName = true;
            cmd.ArrayBindCount = tabla.Count;
            cmd.Parameters.Add(TiempoDetalle.C_PK_COD_FALLA, OracleDbType.Int32, GetArray(tabla, TiempoDetalle.C_PK_COD_FALLA), ParameterDirection.Input);
            cmd.Parameters.Add(TiempoDetalle.C_PK_D_COD_TIPOINFORME, OracleDbType.Int64, GetArray(tabla, TiempoDetalle.C_PK_D_COD_TIPOINFORME), ParameterDirection.Input);
            cmd.Parameters.Add(TiempoDetalle.C_PK_ORIGEN_INFORME, OracleDbType.Int64, GetArray(tabla, TiempoDetalle.C_PK_ORIGEN_INFORME), ParameterDirection.Input);
            cmd.Parameters.Add(TiempoDetalle.C_PK_COD_COMPONENTE, OracleDbType.Int64, GetArray(tabla, TiempoDetalle.C_PK_COD_COMPONENTE), ParameterDirection.Input);
            cmd.Parameters.Add(TiempoDetalle.C_PK_COD_PERSONA, OracleDbType.Int64, GetArray(tabla, TiempoDetalle.C_PK_COD_PERSONA), ParameterDirection.Input);
            cmd.Parameters.Add(TiempoDetalle.C_FEC_APERTURA, OracleDbType.Date, GetArray(tabla, TiempoDetalle.C_FEC_APERTURA), ParameterDirection.Input);
            cmd.Parameters.Add(TiempoDetalle.C_TIEMPO_INDISPONIBILIDAD, OracleDbType.Single, GetArray(tabla, TiempoDetalle.C_TIEMPO_INDISPONIBILIDAD), ParameterDirection.Input);
            cmd.Parameters.Add(TiempoDetalle.C_TIEMPO_PRECONEXION, OracleDbType.Single, GetArray(tabla, TiempoDetalle.C_TIEMPO_PRECONEXION), ParameterDirection.Input);
            cmd.Parameters.Add(TiempoDetalle.C_TIEMPO_CONEXION, OracleDbType.Single, GetArray(tabla, TiempoDetalle.C_TIEMPO_CONEXION), ParameterDirection.Input);
            cmd.Parameters.Add(TiempoDetalle.C_FK_COD_RESPONSABLE, OracleDbType.Int64, GetArray(tabla, TiempoDetalle.C_FK_COD_RESPONSABLE), ParameterDirection.Input);
            cmd.Parameters.Add(TiempoDetalle.C_D_COD_MOTIVO, OracleDbType.Int64, GetArray(tabla, TiempoDetalle.C_D_COD_MOTIVO), ParameterDirection.Input);
            cmd.Parameters.Add(TiempoDetalle.C_D_COD_ESTADO, OracleDbType.Varchar2, GetArray(tabla, TiempoDetalle.C_D_COD_ESTADO), ParameterDirection.Input);
            cmd.Parameters.Add(TiempoDetalle.C_SEC_LOG, OracleDbType.Int64, GetArray(tabla, TiempoDetalle.C_SEC_LOG), ParameterDirection.Input);
            cmd.Parameters.Add(TiempoDetalle.C_SINC_VER, OracleDbType.Int64, GetArray(tabla, TiempoDetalle.C_SINC_VER), ParameterDirection.Input);

            Actualizar(cmd);
        }
    }
}