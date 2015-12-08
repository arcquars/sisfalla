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
    public class OraDalAsignacionResposabilidadMgr : OraDalBaseMgr ,IAsignacionResposabilidadMgr, IMgrLocal, IProveedorDatosSincronizacion
    {
        public OraDalAsignacionResposabilidadMgr()
        {

        }
        public OraDalAsignacionResposabilidadMgr(ConnexionOracleMgr c)
            : base(c)
        { }

        public void Guardar(AsignacionResposabilidad obj)
        {
            OracleCommand cmd = null;
            string sql = string.Empty;
            if (obj.EsNuevo)
            {
                Pista p = PistaMgr.Instance.Info("DALSisFalla", obj.GetEstadoString());
                obj.SecLog = (long)p.PK_SecLog;
                sql = "INSERT INTO {0} ({1},{2},{3},{4},{5},{6},{7},{8},{9},{10})" +
                "VALUES(:{1},:{2},:{3},:{4},:{5},:{6},:{7},:{8},:{9},:{10})";
            }
            else
            {
                sql = "UPDATE {0} SET " +
                "{7}=:{7} ," +
                "{8}=:{8} ," +
                "{9}=:{9} ," +
                "{10}=:{10}  WHERE " +
                "{1}=:{1} AND " +
                "{2}=:{2} AND " +
                "{3}=:{3} AND " +
                "{4}=:{4} AND " +
                "{5}=:{5} AND " +
                "{6}=:{6} ";
            }

            sql = string.Format(sql, AsignacionResposabilidad.NOMBRE_TABLA,
            AsignacionResposabilidad.C_PK_COD_FALLA,
            AsignacionResposabilidad.C_PK_D_COD_TIPOINFORME,
            AsignacionResposabilidad.C_PK_ORIGEN_INFORME,
            AsignacionResposabilidad.C_PK_COD_COMPONENTE,
            AsignacionResposabilidad.C_PK_COD_PERSONA_RESPONSABLE,
            AsignacionResposabilidad.C_FEC_APERTURA,
            AsignacionResposabilidad.C_TIEMPO_RESPONSABILIDAD,
            AsignacionResposabilidad.C_D_COD_ESTADO,
            AsignacionResposabilidad.C_SEC_LOG,
            AsignacionResposabilidad.C_SINC_VER);
            cmd = CrearCommand();
            cmd.CommandText = sql;
            cmd.BindByName = true;
            cmd.Parameters.Add(AsignacionResposabilidad.C_PK_COD_FALLA, OracleDbType.Int32, obj.PkCodFalla, System.Data.ParameterDirection.Input);
            cmd.Parameters.Add(AsignacionResposabilidad.C_PK_D_COD_TIPOINFORME, OracleDbType.Int64, obj.PkDCodTipoinforme, System.Data.ParameterDirection.Input);
            cmd.Parameters.Add(AsignacionResposabilidad.C_PK_ORIGEN_INFORME, OracleDbType.Int64, obj.PkOrigenInforme, System.Data.ParameterDirection.Input);
            cmd.Parameters.Add(AsignacionResposabilidad.C_PK_COD_COMPONENTE, OracleDbType.Int64, obj.PkCodComponente, System.Data.ParameterDirection.Input);
            cmd.Parameters.Add(AsignacionResposabilidad.C_PK_COD_PERSONA_RESPONSABLE, OracleDbType.Int64, obj.PkCodPersonaResponsable, System.Data.ParameterDirection.Input);
            cmd.Parameters.Add(AsignacionResposabilidad.C_FEC_APERTURA, OracleDbType.Date, obj.FecApertura, System.Data.ParameterDirection.Input);
            cmd.Parameters.Add(AsignacionResposabilidad.C_TIEMPO_RESPONSABILIDAD, OracleDbType.Single, obj.Tiempo, System.Data.ParameterDirection.Input);
            cmd.Parameters.Add(AsignacionResposabilidad.C_D_COD_ESTADO, OracleDbType.Varchar2, obj.DCodEstado, System.Data.ParameterDirection.Input);
            cmd.Parameters.Add(AsignacionResposabilidad.C_SEC_LOG, OracleDbType.Int64, obj.SecLog, System.Data.ParameterDirection.Input);
            cmd.Parameters.Add(AsignacionResposabilidad.C_SINC_VER, OracleDbType.Int64, obj.SincVer, System.Data.ParameterDirection.Input);

            if (Actualizar(cmd))
            {
                obj.EsNuevo = false;
            }
        }

        public DataTable GetTabla()
        {
            DataTable tabla = GetTabla(AsignacionResposabilidad.NOMBRE_TABLA);
            return tabla;
        }

        public BindingList<AsignacionResposabilidad> GetLista()
        {
            BindingList<AsignacionResposabilidad> resultado = new BindingList<AsignacionResposabilidad>();
            DataTable tablaAgentes = GetTabla();
            foreach (DataRow row in tablaAgentes.Rows)
            {
                resultado.Add(new AsignacionResposabilidad(row));
            }
            return resultado;
        }

        public DataTable GetAsigResp(RRegFallaComponente comp)
        {
            DataTable resultado = null;
            string sql =
                @"SELECT A.*, B.SIGLA 
                FROM F_GF_RESPONSABILIDAD A, f_ap_persona B 
                WHERE A.PK_COD_PERSONA_RESPONSABLE= B.PK_COD_PERSONA AND 
                A.PK_COD_FALLA=:{0} AND 
                A.PK_ORIGEN_INFORME=:{1} AND 
                A.PK_COD_COMPONENTE=:{2} AND 
                A.PK_D_COD_TIPOINFORME=:{3} AND 
                A.FEC_APERTURA=:{4}
                ORDER BY B.Sigla";

            sql = string.Format(sql,
                AsignacionResposabilidad.C_PK_COD_FALLA,
                AsignacionResposabilidad.C_PK_ORIGEN_INFORME,
                AsignacionResposabilidad.C_PK_COD_COMPONENTE,
                AsignacionResposabilidad.C_PK_D_COD_TIPOINFORME,
                AsignacionResposabilidad.C_FEC_APERTURA
                );

            OracleCommand cmd = CrearCommand();
            cmd.CommandText = sql;
            cmd.BindByName = true;
            cmd.Parameters.Add(AsignacionResposabilidad.C_PK_COD_FALLA, OracleDbType.Int32, comp.PkCodFalla, System.Data.ParameterDirection.Input);
            cmd.Parameters.Add(AsignacionResposabilidad.C_PK_ORIGEN_INFORME, OracleDbType.Int64, comp.PkOrigenInforme, System.Data.ParameterDirection.Input);
            cmd.Parameters.Add(AsignacionResposabilidad.C_PK_D_COD_TIPOINFORME, OracleDbType.Int64, comp.PkDCodTipoinforme, System.Data.ParameterDirection.Input);
            cmd.Parameters.Add(AsignacionResposabilidad.C_PK_COD_COMPONENTE, OracleDbType.Int64, comp.PkCodComponente, System.Data.ParameterDirection.Input);
            cmd.Parameters.Add(AsignacionResposabilidad.C_FEC_APERTURA, OracleDbType.Date, comp.FecApertura, System.Data.ParameterDirection.Input);
            resultado = EjecutarCmd(cmd);
            return resultado;
        }

        #region IMgrLocal

        public string NombreTabla
        {
            get { return AsignacionResposabilidad.NOMBRE_TABLA; }
        }

        public void Insertar(List<DataRow> rows)
        {
            string sql = "INSERT INTO {0} ({1},{2},{3},{4},{5},{6},{7},{8},{9},{10})" +
            "VALUES(:{1},:{2},:{3},:{4},:{5},:{6},:{7},:{8},:{9},:{10})";

            InsertUpdate(rows, sql);
        }

        public void Actualizar(List<DataRow> rows)
        {
            string sql = "UPDATE {0} SET " +
                "{7}=:{7} ," +
                "{8}=:{8} ," +
                "{9}=:{9} ," +
                "{10}=:{10}  WHERE " +
                "{1}=:{1} AND " +
                "{2}=:{2} AND " +
                "{3}=:{3} AND " +
                "{4}=:{4} AND " +
                "{5}=:{5} AND " +
                "{6}=:{6} ";

            InsertUpdate(rows, sql);
        }

        void InsertUpdate(List<DataRow> rows, string sql)
        {
            OracleCommand cmd = null;

            sql = string.Format(sql, AsignacionResposabilidad.NOMBRE_TABLA,
            AsignacionResposabilidad.C_PK_COD_FALLA,
            AsignacionResposabilidad.C_PK_D_COD_TIPOINFORME,
            AsignacionResposabilidad.C_PK_ORIGEN_INFORME,
            AsignacionResposabilidad.C_PK_COD_COMPONENTE,
            AsignacionResposabilidad.C_PK_COD_PERSONA_RESPONSABLE,
            AsignacionResposabilidad.C_FEC_APERTURA,
            AsignacionResposabilidad.C_TIEMPO_RESPONSABILIDAD,
            AsignacionResposabilidad.C_D_COD_ESTADO,
            AsignacionResposabilidad.C_SEC_LOG,
            AsignacionResposabilidad.C_SINC_VER);
            cmd = CrearCommand();
            cmd.CommandText = sql;
            cmd.BindByName = true;
            cmd.ArrayBindCount = rows.Count;
            cmd.Parameters.Add(AsignacionResposabilidad.C_PK_COD_FALLA, OracleDbType.Int32, GetArray(rows, AsignacionResposabilidad.C_PK_COD_FALLA), System.Data.ParameterDirection.Input);
            cmd.Parameters.Add(AsignacionResposabilidad.C_PK_D_COD_TIPOINFORME, OracleDbType.Int64, GetArray(rows, AsignacionResposabilidad.C_PK_D_COD_TIPOINFORME), System.Data.ParameterDirection.Input);
            cmd.Parameters.Add(AsignacionResposabilidad.C_PK_ORIGEN_INFORME, OracleDbType.Int64, GetArray(rows, AsignacionResposabilidad.C_PK_ORIGEN_INFORME), System.Data.ParameterDirection.Input);
            cmd.Parameters.Add(AsignacionResposabilidad.C_PK_COD_COMPONENTE, OracleDbType.Int64, GetArray(rows, AsignacionResposabilidad.C_PK_COD_COMPONENTE), System.Data.ParameterDirection.Input);
            cmd.Parameters.Add(AsignacionResposabilidad.C_PK_COD_PERSONA_RESPONSABLE, OracleDbType.Int64, GetArray(rows, AsignacionResposabilidad.C_PK_COD_PERSONA_RESPONSABLE), System.Data.ParameterDirection.Input);
            cmd.Parameters.Add(AsignacionResposabilidad.C_FEC_APERTURA, OracleDbType.Date, GetArray(rows, AsignacionResposabilidad.C_FEC_APERTURA), System.Data.ParameterDirection.Input);
            cmd.Parameters.Add(AsignacionResposabilidad.C_TIEMPO_RESPONSABILIDAD, OracleDbType.Single, GetArray(rows, AsignacionResposabilidad.C_TIEMPO_RESPONSABILIDAD), System.Data.ParameterDirection.Input);
            cmd.Parameters.Add(AsignacionResposabilidad.C_D_COD_ESTADO, OracleDbType.Varchar2, GetArray(rows, AsignacionResposabilidad.C_D_COD_ESTADO), System.Data.ParameterDirection.Input);
            cmd.Parameters.Add(AsignacionResposabilidad.C_SEC_LOG, OracleDbType.Int64, GetArray(rows, AsignacionResposabilidad.C_SEC_LOG), System.Data.ParameterDirection.Input);
            cmd.Parameters.Add(AsignacionResposabilidad.C_SINC_VER, OracleDbType.Int64, GetArray(rows, AsignacionResposabilidad.C_SINC_VER), System.Data.ParameterDirection.Input);

            Actualizar(cmd);
        }

        #endregion IMgrLocal


        public void Eliminar(AsignacionResposabilidad a)
        {
            string sql =
            @"DELETE FROM F_GF_RESPONSABILIDAD 
            WHERE PK_COD_FALLA=:PK_COD_FALLA 
            AND PK_D_COD_TIPOINFORME=:PK_D_COD_TIPOINFORME 
            AND PK_ORIGEN_INFORME=:PK_ORIGEN_INFORME  
            AND PK_COD_COMPONENTE=:PK_COD_COMPONENTE 
            AND PK_COD_PERSONA_RESPONSABLE=:PK_COD_PERSONA_RESPONSABLE
            AND FEC_APERTURA=:FEC_APERTURA";

            OracleCommand cmd = CrearCommand();
            cmd.CommandText = sql;

            cmd.Parameters.Add(AsignacionResposabilidad.C_PK_COD_FALLA, OracleDbType.Int32, a.PkCodFalla, System.Data.ParameterDirection.Input);
            cmd.Parameters.Add(AsignacionResposabilidad.C_PK_D_COD_TIPOINFORME, OracleDbType.Int64, a.PkDCodTipoinforme, System.Data.ParameterDirection.Input);
            cmd.Parameters.Add(AsignacionResposabilidad.C_PK_ORIGEN_INFORME, OracleDbType.Int64, a.PkOrigenInforme, System.Data.ParameterDirection.Input);
            cmd.Parameters.Add(AsignacionResposabilidad.C_PK_COD_COMPONENTE, OracleDbType.Int64, a.PkCodComponente, System.Data.ParameterDirection.Input);
            cmd.Parameters.Add(AsignacionResposabilidad.C_PK_COD_PERSONA_RESPONSABLE, OracleDbType.Int64, a.PkCodPersonaResponsable, System.Data.ParameterDirection.Input);
            cmd.Parameters.Add(AsignacionResposabilidad.C_FEC_APERTURA, OracleDbType.Date, a.FecApertura, System.Data.ParameterDirection.Input);
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
                FROM f_gf_responsabilidad a
                WHERE a.sinc_ver > :sinc_ver
                AND 
                (   VERIFICARENVIAD(a.pk_cod_falla,a.pk_origen_informe,a.pk_d_cod_tipoinforme,3594)  > 0 
                    OR a.pk_origen_informe=:pk_cod_persona
                ) 
                AND a.pk_cod_falla IN 
                (SELECT b.pk_cod_falla
                FROM f_gf_notificacion b
                WHERE b.pk_cod_persona=:pk_cod_persona AND b.d_cod_estado_notificacion <> 41)";
            }
            else
            {
                sql = @"SELECT a.*
                FROM f_gf_responsabilidad a
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
    }
}