using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.ComponentModel;
using CNDC.Pistas;
using CNDC.DAL;
using Oracle.DataAccess.Client;
using ModeloSisFalla;
using CNDC.BLL;
using CNDC.Sincronizacion;

namespace OraDalSisFalla
{
    public class OraDalRRegFallaComponenteMgr : OraDalBaseMgr, IRRegFallaComponenteMgr, IMgrLocal, IProveedorDatosSincronizacion
    {
        public OraDalRRegFallaComponenteMgr()
        {

        }
        public OraDalRRegFallaComponenteMgr(ConnexionOracleMgr c)
            : base(c)
        { }

        
        public void Guardar(RRegFallaComponente obj)
        {
            OracleCommand cmd = null;
            string sql = string.Empty;
            obj.FecCierre = obj.FecApertura.AddMinutes(obj.TiempoConexion + obj.TiempoIndisponibilidad + obj.TiempoPreconexion);
            if (obj.EsNuevo)
            {
                Pista p = PistaMgr.Instance.Info("DALSisFalla", obj.GetEstadoString());
                obj.SecLog = (long)p.PK_SecLog;
                sql =
                @"INSERT INTO {0} 
                ({1},{2},{3},{4},{5},{6},{7},{8},{9},{10},{11},{12},{13},{14},{15},{16},{17},{18},
                 {19},{20},{21},{22},{23})
                VALUES(:{1},:{2},:{3},:{4},:{5},:{6},:{7},:{8},:{9},:{10},:{11},:{12},:{13},:{14},
                :{15},:{16},:{17},:{18},:{19},:{20},:{21},:{22},:{23})";
            }
            else
            {
                sql = "UPDATE {0} SET " +
                "{6}=:{6} ," +
                "{7}=:{7} ," +
                "{8}=:{8} ," +
                "{9}=:{9} ," +
                "{10}=:{10} ," +
                "{11}=:{11} ," +
                "{12}=:{12} ," +
                "{13}=:{13} ," +
                "{14}=:{14} ," +
                "{15}=:{15} ," +
                "{16}=:{16} ," +
                "{17}=:{17} ," +
                "{18}=:{18} ," +
                "{19}=:{19} ," +
                "{20}=:{20} ," +
                "{21}=:{21} ," +
                "{22}=:{22} ," +
                "{23}=:{23} " +
                "WHERE " +
                "{1}=:{1} AND " +
                "{2}=:{2} AND " +
                "{3}=:{3} AND " +
                "{4}=:{4} AND " +
                "{5}=:{5}";
            }

            sql = string.Format(sql, RRegFallaComponente.NOMBRE_TABLA,
            RRegFallaComponente.C_PK_COD_FALLA,
            RRegFallaComponente.C_PK_ORIGEN_INFORME,
            RRegFallaComponente.C_PK_D_COD_TIPOINFORME,
            RRegFallaComponente.C_PK_COD_COMPONENTE,
            RRegFallaComponente.C_FEC_APERTURA,
            RRegFallaComponente.C_POTENCIA_DESCONECTADA,
            RRegFallaComponente.C_TIEMPO_INDISPONIBILIDAD,
            RRegFallaComponente.C_TIEMPO_PRECONEXION,
            RRegFallaComponente.C_TIEMPO_CONEXION,
            RRegFallaComponente.C_TIEMPO_SISTEMA,
            RRegFallaComponente.C_D_COD_MOTIVO,
            RRegFallaComponente.C_FK_COD_RESPONSABLE,
            RRegFallaComponente.C_D_COD_TIPOPERACIONAPERTURA,
            RRegFallaComponente.C_FEC_CIERRE,
            RRegFallaComponente.C_D_COD_TIPOOPERACIONCIERRE,
            RRegFallaComponente.C_ETAPA_EDAC,
            RRegFallaComponente.C_D_COD_ESTADO,
            RRegFallaComponente.C_SEC_LOG,
            RRegFallaComponente.C_SINC_VER,
            RRegFallaComponente.C_FLUJO_N1_N2,
            RRegFallaComponente.C_TTOTAL_DESCONEXION,
            RRegFallaComponente.C_TIEMPO_P_SIST,
            RRegFallaComponente.C_TIEMPO_P_OPER);
            cmd = CrearCommand();
            cmd.CommandText = sql;
            cmd.Parameters.Add(RRegFallaComponente.C_PK_COD_FALLA, OracleDbType.Int32, obj.PkCodFalla, System.Data.ParameterDirection.Input);
            cmd.Parameters.Add(RRegFallaComponente.C_PK_ORIGEN_INFORME, OracleDbType.Int64, obj.PkOrigenInforme, System.Data.ParameterDirection.Input);
            cmd.Parameters.Add(RRegFallaComponente.C_PK_D_COD_TIPOINFORME, OracleDbType.Int64, obj.PkDCodTipoinforme, System.Data.ParameterDirection.Input);
            cmd.Parameters.Add(RRegFallaComponente.C_PK_COD_COMPONENTE, OracleDbType.Int64, obj.PkCodComponente, System.Data.ParameterDirection.Input);
            cmd.Parameters.Add(RRegFallaComponente.C_FEC_APERTURA, OracleDbType.Date, obj.FecApertura, System.Data.ParameterDirection.Input);
            cmd.Parameters.Add(RRegFallaComponente.C_POTENCIA_DESCONECTADA, OracleDbType.Single, obj.PotenciaDesconectada, System.Data.ParameterDirection.Input);
            cmd.Parameters.Add(RRegFallaComponente.C_TIEMPO_INDISPONIBILIDAD, OracleDbType.Single, obj.TiempoIndisponibilidad, System.Data.ParameterDirection.Input);
            cmd.Parameters.Add(RRegFallaComponente.C_TIEMPO_PRECONEXION, OracleDbType.Single, obj.TiempoPreconexion, System.Data.ParameterDirection.Input);
            cmd.Parameters.Add(RRegFallaComponente.C_TIEMPO_CONEXION, OracleDbType.Single, obj.TiempoConexion, System.Data.ParameterDirection.Input);
            cmd.Parameters.Add(RRegFallaComponente.C_TIEMPO_SISTEMA, OracleDbType.Int64 , obj.TiempoSistema, System.Data.ParameterDirection.Input);
            cmd.Parameters.Add(RRegFallaComponente.C_D_COD_MOTIVO, OracleDbType.Int64, obj.DCodMotivo, System.Data.ParameterDirection.Input);
            cmd.Parameters.Add(RRegFallaComponente.C_FK_COD_RESPONSABLE, OracleDbType.Int64, obj.FkCodResponsable, System.Data.ParameterDirection.Input);
            cmd.Parameters.Add(RRegFallaComponente.C_D_COD_TIPOPERACIONAPERTURA, OracleDbType.Int64, obj.DCodTipoperacionapertura, System.Data.ParameterDirection.Input);
            cmd.Parameters.Add(RRegFallaComponente.C_FEC_CIERRE, OracleDbType.Date, obj.FecCierre, System.Data.ParameterDirection.Input);
            cmd.Parameters.Add(RRegFallaComponente.C_D_COD_TIPOOPERACIONCIERRE, OracleDbType.Int64, obj.DCodTipooperacioncierre, System.Data.ParameterDirection.Input);
            cmd.Parameters.Add(RRegFallaComponente.C_ETAPA_EDAC, OracleDbType.Varchar2, obj.EtapaEdac, System.Data.ParameterDirection.Input);
            cmd.Parameters.Add(RRegFallaComponente.C_D_COD_ESTADO, OracleDbType.Varchar2, obj.DCodEstado, System.Data.ParameterDirection.Input);
            cmd.Parameters.Add(RRegFallaComponente.C_SEC_LOG, OracleDbType.Int64, obj.SecLog, System.Data.ParameterDirection.Input);
            cmd.Parameters.Add(RRegFallaComponente.C_SINC_VER, OracleDbType.Int64, obj.SincVer, System.Data.ParameterDirection.Input);
            cmd.Parameters.Add(RRegFallaComponente.C_FLUJO_N1_N2, OracleDbType.Varchar2, obj.FlujoN1N2.ToString(), System.Data.ParameterDirection.Input);
            cmd.Parameters.Add(RRegFallaComponente.C_TTOTAL_DESCONEXION, OracleDbType.Single, obj.TtotalDesconexion, System.Data.ParameterDirection.Input);
            cmd.Parameters.Add(RRegFallaComponente.C_TIEMPO_P_SIST, OracleDbType.Single, obj.TiempoPSist, System.Data.ParameterDirection.Input);
            cmd.Parameters.Add(RRegFallaComponente.C_TIEMPO_P_OPER, OracleDbType.Single, obj.TiempoPOper, System.Data.ParameterDirection.Input);
            cmd.BindByName = true;

            if (Actualizar(cmd))
            {
                obj.EsNuevo = false;
            }
        }

        public DataTable GetTabla()
        {
            string sql =
            @"select fc.*, fc.RowId 
            from F_GF_RREGFALLA_COMPONENTE fc";
            DataTable tabla = EjecutarSql(sql);
            tabla.TableName = NombreTabla;
            return tabla;
        }

        public BindingList<RRegFallaComponente> GetLista()
        {
            BindingList<RRegFallaComponente> resultado = new BindingList<RRegFallaComponente>();
            DataTable tablaAgentes = GetTabla();
            foreach (DataRow row in tablaAgentes.Rows)
            {
                resultado.Add(new RRegFallaComponente(row));
            }
            return resultado;
        }

        public DataTable GetTablaVisualizable()
        {
            DataTable resultado = null;
            string sql =
            @"select fc.*, fc.RowId, c.nombre_componente, c.descripcion 
            from F_GF_RREGFALLA_COMPONENTE fc, f_ac_componente c 
            where 
            fc.pk_cod_componente=c.pk_cod_componente";
            resultado = EjecutarSql(sql);
            return resultado;
        }

        public DataTable GetTablaVisualizable(InformeFalla informe)
        {
            DataTable resultado = null;
            string sql =
            @"select fc.*, fc.RowId, c.nombre_componente, c.descripcion_componente DESC_COMP 
            from F_GF_RREGFALLA_COMPONENTE fc, f_ac_componente c 
            where 
            fc.pk_cod_componente=c.pk_cod_componente and 
            fc.pk_cod_falla = :PK_COD_FALLA and 
            fc.PK_ORIGEN_INFORME = :PK_ORIGEN_INFORME and 
            fc.PK_D_COD_TIPOINFORME = :PK_D_COD_TIPOINFORME
            ORDER BY fc.FEC_APERTURA, c.nombre_componente";

            OracleCommand cmd = CrearCommand();
            cmd.CommandText = sql;
            cmd.Parameters.Add(RRegFallaComponente.C_PK_COD_FALLA, OracleDbType.Int32,informe.PkCodFalla, System.Data.ParameterDirection.Input);
            cmd.Parameters.Add(RRegFallaComponente.C_PK_ORIGEN_INFORME, OracleDbType.Int64, informe.PkOrigenInforme, System.Data.ParameterDirection.Input);
            cmd.Parameters.Add(RRegFallaComponente.C_PK_D_COD_TIPOINFORME, OracleDbType.Int64, informe.PkDCodTipoinforme, System.Data.ParameterDirection.Input);
            cmd.BindByName = true;

            resultado = EjecutarCmd(cmd);
            return resultado;
        }

        public int CopiarCompComproDeAgentes(InformeFalla informeDestino)
        {
            DataTable tabla = ModeloMgr.Instancia.InformeFallaMgr.GetInformesPorCodFalla(informeDestino.PkCodFalla);
            int contador = 0;

            foreach (DataRow r in tabla.Rows)
            {
                if (informeDestino.PkOrigenInforme != ObjetoDeNegocio.GetValor<long>(r[InformeFalla.C_PK_ORIGEN_INFORME]) &&
                    ObjetoDeNegocio.GetValor<long>(r[InformeFalla.C_PK_D_COD_TIPOINFORME]) == informeDestino.PkDCodTipoinforme)
                {
                    InformeFalla informeOrigen = new InformeFalla(r);
                    DataTable tablaCompCompro = GetTablaVisualizable(informeOrigen);
                    foreach (DataRow row in tablaCompCompro.Rows)
                    {
                        CopiarCompoCompro(row, informeDestino);
                        contador++;
                    }
                }
            }

            return contador;
        }

        private void CopiarCompoCompro(DataRow row, InformeFalla informeDestino)
        {
            RRegFallaComponente compoCompro = new RRegFallaComponente(row);
            compoCompro.PkOrigenInforme = informeDestino.PkOrigenInforme;
            compoCompro.PkDCodTipoinforme = informeDestino.PkDCodTipoinforme;
            compoCompro.EsNuevo = true;
            Guardar(compoCompro);
        }

        #region IMgrLocal

        public string NombreTabla
        {
            get { return RRegFallaComponente.NOMBRE_TABLA; }
        }
        #endregion IMgrLocal

        public void Borrar(RRegFallaComponente obj)
        {
            string sql =
            @"DELETE
            FROM F_GF_RREGFALLA_COMPONENTE
where rowid= :rid 
           ";

            OracleCommand cmd = CrearCommand();
            cmd.CommandText = sql;
            //cmd.Parameters.Add(RRegFallaComponente.C_PK_COD_FALLA, OracleDbType.Int32, obj.PkCodFalla, ParameterDirection.Input);
            //cmd.Parameters.Add(RRegFallaComponente.C_PK_ORIGEN_INFORME, OracleDbType.Int64, obj.PkOrigenInforme, ParameterDirection.Input);
            //cmd.Parameters.Add(RRegFallaComponente.C_PK_D_COD_TIPOINFORME, OracleDbType.Int64, obj.PkDCodTipoinforme, ParameterDirection.Input);
            //cmd.Parameters.Add(RRegFallaComponente.C_PK_COD_COMPONENTE, OracleDbType.Int64, obj.PkCodComponente, ParameterDirection.Input);
            //cmd.Parameters.Add(RRegFallaComponente.C_FEC_APERTURA, OracleDbType.Date, obj.FecApertura, ParameterDirection.Input);

            cmd.Parameters.Add("rid", OracleDbType.Varchar2 , obj.RowId , ParameterDirection.Input);
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
                FROM f_gf_rregfalla_componente a
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
                FROM f_gf_rregfalla_componente a
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
            string sql =
                @"INSERT INTO {0} 
                ({1},{2},{3},{4},{5},{6},{7},{8},{9},{10},{11},{12},{13},{14},{15},{16},{17},{18},
                 {19},{20},{21},{22},{23})
                VALUES(:{1},:{2},:{3},:{4},:{5},:{6},:{7},:{8},:{9},:{10},:{11},:{12},:{13},:{14},
                :{15},:{16},:{17},:{18},:{19},:{20},:{21},:{22},:{23})";
            InsertUpdate(tabla, sql);
        }

        public void Actualizar(List<DataRow> tabla)
        {
            string sql = "UPDATE {0} SET " +
                "{6}=:{6} ," +
                "{7}=:{7} ," +
                "{8}=:{8} ," +
                "{9}=:{9} ," +
                "{10}=:{10} ," +
                "{11}=:{11} ," +
                "{12}=:{12} ," +
                "{13}=:{13} ," +
                "{14}=:{14} ," +
                "{15}=:{15} ," +
                "{16}=:{16} ," +
                "{17}=:{17} ," +
                "{18}=:{18} ," +
                "{19}=:{19} ," +
                "{20}=:{20} ," +
                "{21}=:{21} ," +
                "{22}=:{22} ," +
                "{23}=:{23} " +
                "WHERE " +
                "{1}=:{1} AND " +
                "{2}=:{2} AND " +
                "{3}=:{3} AND " +
                "{4}=:{4} AND " +
                "{5}=:{5}";
            InsertUpdate(tabla, sql);
        }

        void InsertUpdate(List<DataRow> tabla, string sql)
        {
            OracleCommand cmd = null;

            sql = string.Format(sql, RRegFallaComponente.NOMBRE_TABLA,
            RRegFallaComponente.C_PK_COD_FALLA,
            RRegFallaComponente.C_PK_ORIGEN_INFORME,
            RRegFallaComponente.C_PK_D_COD_TIPOINFORME,
            RRegFallaComponente.C_PK_COD_COMPONENTE,
            RRegFallaComponente.C_FEC_APERTURA,
            RRegFallaComponente.C_POTENCIA_DESCONECTADA,
            RRegFallaComponente.C_TIEMPO_INDISPONIBILIDAD,
            RRegFallaComponente.C_TIEMPO_PRECONEXION,
            RRegFallaComponente.C_TIEMPO_CONEXION,
            RRegFallaComponente.C_TIEMPO_SISTEMA,
            RRegFallaComponente.C_D_COD_MOTIVO,
            RRegFallaComponente.C_FK_COD_RESPONSABLE,
            RRegFallaComponente.C_D_COD_TIPOPERACIONAPERTURA,
            RRegFallaComponente.C_FEC_CIERRE,
            RRegFallaComponente.C_D_COD_TIPOOPERACIONCIERRE,
            RRegFallaComponente.C_ETAPA_EDAC,
            RRegFallaComponente.C_D_COD_ESTADO,
            RRegFallaComponente.C_SEC_LOG,
            RRegFallaComponente.C_SINC_VER,
            RRegFallaComponente.C_FLUJO_N1_N2,
            RRegFallaComponente.C_TTOTAL_DESCONEXION,
            RRegFallaComponente.C_TIEMPO_P_OPER,
            RRegFallaComponente.C_TIEMPO_P_SIST);
            cmd = CrearCommand();
            cmd.CommandText = sql;
            cmd.ArrayBindCount = tabla.Count;
            cmd.Parameters.Add(RRegFallaComponente.C_PK_COD_FALLA, OracleDbType.Int32, GetArray(tabla, RRegFallaComponente.C_PK_COD_FALLA), System.Data.ParameterDirection.Input);
            cmd.Parameters.Add(RRegFallaComponente.C_PK_ORIGEN_INFORME, OracleDbType.Int64, GetArray(tabla, RRegFallaComponente.C_PK_ORIGEN_INFORME), System.Data.ParameterDirection.Input);
            cmd.Parameters.Add(RRegFallaComponente.C_PK_D_COD_TIPOINFORME, OracleDbType.Int64, GetArray(tabla, RRegFallaComponente.C_PK_D_COD_TIPOINFORME), System.Data.ParameterDirection.Input);
            cmd.Parameters.Add(RRegFallaComponente.C_PK_COD_COMPONENTE, OracleDbType.Int64, GetArray(tabla, RRegFallaComponente.C_PK_COD_COMPONENTE), System.Data.ParameterDirection.Input);
            cmd.Parameters.Add(RRegFallaComponente.C_FEC_APERTURA, OracleDbType.Date, GetArray(tabla, RRegFallaComponente.C_FEC_APERTURA), System.Data.ParameterDirection.Input);
            cmd.Parameters.Add(RRegFallaComponente.C_POTENCIA_DESCONECTADA, OracleDbType.Single, GetArray(tabla, RRegFallaComponente.C_POTENCIA_DESCONECTADA), System.Data.ParameterDirection.Input);
            cmd.Parameters.Add(RRegFallaComponente.C_TIEMPO_INDISPONIBILIDAD, OracleDbType.Single, GetArray(tabla, RRegFallaComponente.C_TIEMPO_INDISPONIBILIDAD), System.Data.ParameterDirection.Input);
            cmd.Parameters.Add(RRegFallaComponente.C_TIEMPO_PRECONEXION, OracleDbType.Single, GetArray(tabla, RRegFallaComponente.C_TIEMPO_PRECONEXION), System.Data.ParameterDirection.Input);
            cmd.Parameters.Add(RRegFallaComponente.C_TIEMPO_CONEXION, OracleDbType.Single, GetArray(tabla, RRegFallaComponente.C_TIEMPO_CONEXION), System.Data.ParameterDirection.Input);
            cmd.Parameters.Add(RRegFallaComponente.C_TIEMPO_SISTEMA, OracleDbType.Single, GetArray(tabla, RRegFallaComponente.C_TIEMPO_SISTEMA), System.Data.ParameterDirection.Input);
            cmd.Parameters.Add(RRegFallaComponente.C_D_COD_MOTIVO, OracleDbType.Int64, GetArray(tabla, RRegFallaComponente.C_D_COD_MOTIVO), System.Data.ParameterDirection.Input);
            cmd.Parameters.Add(RRegFallaComponente.C_FK_COD_RESPONSABLE, OracleDbType.Int64, GetArray(tabla, RRegFallaComponente.C_FK_COD_RESPONSABLE), System.Data.ParameterDirection.Input);
            cmd.Parameters.Add(RRegFallaComponente.C_D_COD_TIPOPERACIONAPERTURA, OracleDbType.Int64, GetArray(tabla, RRegFallaComponente.C_D_COD_TIPOPERACIONAPERTURA), System.Data.ParameterDirection.Input);
            cmd.Parameters.Add(RRegFallaComponente.C_FEC_CIERRE, OracleDbType.Date, GetArray(tabla, RRegFallaComponente.C_FEC_CIERRE), System.Data.ParameterDirection.Input);
            cmd.Parameters.Add(RRegFallaComponente.C_D_COD_TIPOOPERACIONCIERRE, OracleDbType.Int64, GetArray(tabla, RRegFallaComponente.C_D_COD_TIPOOPERACIONCIERRE), System.Data.ParameterDirection.Input);
            cmd.Parameters.Add(RRegFallaComponente.C_ETAPA_EDAC, OracleDbType.Varchar2, GetArray(tabla, RRegFallaComponente.C_ETAPA_EDAC), System.Data.ParameterDirection.Input);
            cmd.Parameters.Add(RRegFallaComponente.C_D_COD_ESTADO, OracleDbType.Varchar2, GetArray(tabla, RRegFallaComponente.C_D_COD_ESTADO), System.Data.ParameterDirection.Input);
            cmd.Parameters.Add(RRegFallaComponente.C_SEC_LOG, OracleDbType.Int64, GetArray(tabla, RRegFallaComponente.C_SEC_LOG), System.Data.ParameterDirection.Input);
            cmd.Parameters.Add(RRegFallaComponente.C_SINC_VER, OracleDbType.Int64, GetArray(tabla, RRegFallaComponente.C_SINC_VER), System.Data.ParameterDirection.Input);
            cmd.Parameters.Add(RRegFallaComponente.C_FLUJO_N1_N2, OracleDbType.Varchar2, GetArray(tabla, RRegFallaComponente.C_FLUJO_N1_N2), System.Data.ParameterDirection.Input);
            cmd.Parameters.Add(RRegFallaComponente.C_TTOTAL_DESCONEXION, OracleDbType.Single, GetArray(tabla, RRegFallaComponente.C_TTOTAL_DESCONEXION), System.Data.ParameterDirection.Input);
            cmd.Parameters.Add(RRegFallaComponente.C_TIEMPO_P_OPER, OracleDbType.Single, GetArray(tabla, RRegFallaComponente.C_TIEMPO_P_OPER), System.Data.ParameterDirection.Input);
            cmd.Parameters.Add(RRegFallaComponente.C_TIEMPO_P_SIST, OracleDbType.Single, GetArray(tabla, RRegFallaComponente.C_TIEMPO_P_SIST), System.Data.ParameterDirection.Input);
            cmd.BindByName = true;

            Actualizar(cmd);
        }

        public bool SolapaTiempos(RRegFallaComponente obj)
        {
            bool resultado = false;
            string sql=
            @"SELECT *
            FROM F_GF_RREGFALLA_COMPONENTE
            WHERE PK_COD_FALLA         = :PK_COD_FALLA
            AND PK_ORIGEN_INFORME      = :PK_ORIGEN_INFORME
            AND RowId                  <> :Row_Id
            AND PK_D_COD_TIPOINFORME   = :PK_D_COD_TIPOINFORME
            AND PK_COD_COMPONENTE      = :PK_COD_COMPONENTE
            AND 
            (
                (FEC_APERTURA          >= :FEC_APERTURA
                AND FEC_APERTURA       <= :FEC_CIERRE OR 
                FEC_CIERRE             >= :FEC_APERTURA
                AND FEC_CIERRE         <= :FEC_CIERRE
                ) 
                OR
                (:FEC_APERTURA         >= FEC_APERTURA
                AND :FEC_APERTURA      <= FEC_CIERRE OR 
                :FEC_CIERRE            >= FEC_APERTURA
                AND :FEC_CIERRE        <= FEC_CIERRE
                )
            )";

            OracleCommand cmd = CrearCommand();
            cmd.CommandText = sql;
            cmd.Parameters.Add(RRegFallaComponente.C_PK_COD_FALLA, OracleDbType.Int32, obj.PkCodFalla, ParameterDirection.Input);
            cmd.Parameters.Add(RRegFallaComponente.C_PK_ORIGEN_INFORME, OracleDbType.Int64, obj.PkOrigenInforme, ParameterDirection.Input);
            cmd.Parameters.Add(RRegFallaComponente.C_PK_D_COD_TIPOINFORME, OracleDbType.Int64, obj.PkDCodTipoinforme, ParameterDirection.Input);
            cmd.Parameters.Add(RRegFallaComponente.C_PK_COD_COMPONENTE, OracleDbType.Int64, obj.PkCodComponente, ParameterDirection.Input);
            cmd.Parameters.Add(RRegFallaComponente.C_FEC_APERTURA, OracleDbType.Date, obj.FecApertura, ParameterDirection.Input);
            cmd.Parameters.Add(RRegFallaComponente.C_FEC_CIERRE, OracleDbType.Date, obj.FecCierre, ParameterDirection.Input);
            cmd.Parameters.Add("Row_Id", OracleDbType.Varchar2, obj.RowId, ParameterDirection.Input);
            cmd.BindByName = true;

            DataTable tabla = EjecutarCmd(cmd);
            if (tabla.Rows.Count > 0)
            {
                resultado = true;
            }
            return resultado;
        }

        public void Refrescar(DataRow row)
        {
            string sql =
            @"SELECT fc.*, fc.RowId, c.nombre_componente, c.descripcion_componente DESC_COMP 
            FROM f_gf_rregfalla_componente fc, f_ac_componente c 
            WHERE 
            fc.pk_cod_componente=c.pk_cod_componente AND 
            fc.RowId=:Row_Id";

            OracleCommand cmd = CrearCommand();
            cmd.CommandText = sql;
            cmd.BindByName = true;
            cmd.Parameters.Add("Row_Id", OracleDbType.Varchar2, row["RowId"], ParameterDirection.Input);
            DataTable resultado = EjecutarCmd(cmd);
            if (resultado.Rows.Count > 0)
            {
                foreach (DataColumn col in resultado.Columns)
                {
                    row[col.ColumnName] = resultado.Rows[0][col.ColumnName];
                }
            }
        }
    }
}