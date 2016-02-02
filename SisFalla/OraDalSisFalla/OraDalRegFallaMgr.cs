using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ModeloSisFalla;
using Oracle.DataAccess.Client;
using CNDC.DAL;
using CNDC.Pistas;
using System.Data;
using CNDC.BLL;
using CNDC.Sincronizacion;
using CNDC.Dominios;
using BLL;
using System.ComponentModel;

namespace OraDalSisFalla
{
    public class OraDalRegFallaMgr : OraDalBaseMgr, IRegFallaMgr, IMgrLocal, IProveedorDatosSincronizacion
    {
        public OraDalRegFallaMgr()
        {

        }
        public OraDalRegFallaMgr(ConnexionOracleMgr c)
            : base(c)
        { }


        public void Guardar(RegFalla regFalla)
        {
            OracleCommand cmd = null;
            if (regFalla.EsNuevo)
            {
                Pista p = PistaMgr.Instance.Info("DALSisFalla", "CodFalla=" + regFalla.CodFalla);
                regFalla.SecLog = p.PK_SecLog;

                cmd = CrearCommand();
                cmd.CommandText =
                @"insert into F_GF_REGFALLA 
                (PK_COD_FALLA,GESTION,PK_COD_COMPONENTE,FEC_INICIO,D_COD_CAUSA,DESCRIPCION_CORTA_FALLA,
                 D_COD_ESTADO,SEC_LOG,D_COD_ORIGEN,D_COD_TIPO_DESCONEXION,FK_COD_OPERADOR,DESCRIPCION_FALLA ,
                 FK_COD_SUPERVISOR,D_COD_PROBLEMA_GEN,D_COD_COLAPSO,SINC_VER
                 )
                values 
                (:PK_COD_FALLA,:GESTION,:PK_COD_COMPONENTE,:FEC_INICIO,:D_COD_CAUSA,:DESCRIPCION,:D_COD_ESTADO,
                 :SEC_LOG,:D_COD_ORIGEN,:D_COD_TIPO_DESCONEXION,:FK_COD_OPERADOR,:DESCRIPCION_FALLA ,
                 :FK_COD_SUPERVISOR,:D_COD_PROBLEMA_GEN,:D_COD_COLAPSO,:SINC_VER
                )";
            }
            else
            {
                cmd = CrearCommand();
                cmd.CommandText = "update F_GF_REGFALLA set " +
                    "GESTION=:GESTION," +
                    "PK_COD_COMPONENTE=:PK_COD_COMPONENTE," +
                    "FEC_INICIO=:FEC_INICIO," +
                    "D_COD_CAUSA=:D_COD_CAUSA," +
                    "DESCRIPCION_CORTA_FALLA=:DESCRIPCION," +
                    "D_COD_ESTADO=:D_COD_ESTADO, " +
                    "SEC_LOG=:SEC_LOG, " +
                    "D_COD_ORIGEN=:D_COD_ORIGEN, " +
                    "D_COD_TIPO_DESCONEXION=:D_COD_TIPO_DESCONEXION, " +
                    "FK_COD_OPERADOR=:FK_COD_OPERADOR, " +
                    "DESCRIPCION_FALLA=:DESCRIPCION_FALLA, " +
                    "FK_COD_SUPERVISOR=:FK_COD_SUPERVISOR, " +
                    "D_COD_PROBLEMA_GEN=:D_COD_PROBLEMA_GEN, " +
                    "D_COD_COLAPSO=:D_COD_COLAPSO, " +
                    "SINC_VER=:SINC_VER " +
                    "where PK_COD_FALLA=:PK_COD_FALLA";
            }

            cmd.Parameters.Add("PK_COD_FALLA", OracleDbType.Int32, regFalla.CodFalla, System.Data.ParameterDirection.Input);
            cmd.Parameters.Add("GESTION", OracleDbType.Int16, regFalla.Gestion, System.Data.ParameterDirection.Input);
            cmd.Parameters.Add("PK_COD_COMPONENTE", OracleDbType.Decimal, regFalla.CodComponente, System.Data.ParameterDirection.Input);
            cmd.Parameters.Add("FEC_INICIO", OracleDbType.Date, regFalla.FecInicio, System.Data.ParameterDirection.Input);
            cmd.Parameters.Add("D_COD_CAUSA", OracleDbType.Int64, regFalla.CodCausa, System.Data.ParameterDirection.Input);
            cmd.Parameters.Add("DESCRIPCION", OracleDbType.Varchar2, regFalla.Descripcion, System.Data.ParameterDirection.Input);
            cmd.Parameters.Add("D_COD_ESTADO", OracleDbType.Varchar2, regFalla.CodEstado, System.Data.ParameterDirection.Input);
            cmd.Parameters.Add("SEC_LOG", OracleDbType.Decimal, regFalla.SecLog, System.Data.ParameterDirection.Input);
            cmd.Parameters.Add("D_COD_ORIGEN", OracleDbType.Int64, regFalla.CodOrigen, System.Data.ParameterDirection.Input);
            cmd.Parameters.Add("D_COD_TIPO_DESCONEXION", OracleDbType.Int64, regFalla.CodTipoDesconexion, System.Data.ParameterDirection.Input);
            cmd.Parameters.Add("FK_COD_OPERADOR", OracleDbType.Long, regFalla.Fk_cod_operador, System.Data.ParameterDirection.Input);
            cmd.Parameters.Add("DESCRIPCION_FALLA", OracleDbType.Varchar2, regFalla.DescripcionFalla, System.Data.ParameterDirection.Input);
            cmd.Parameters.Add("FK_COD_SUPERVISOR", OracleDbType.Long, regFalla.Fk_cod_supervisor, System.Data.ParameterDirection.Input);
            cmd.Parameters.Add("D_COD_PROBLEMA_GEN", OracleDbType.Long, regFalla.CodProblemasGen, System.Data.ParameterDirection.Input);
            cmd.Parameters.Add("D_COD_COLAPSO", OracleDbType.Long, regFalla.CodColapso, System.Data.ParameterDirection.Input);
            cmd.Parameters.Add("SINC_VER", OracleDbType.Long, regFalla.SincVer, System.Data.ParameterDirection.Input);
            cmd.BindByName = true;

            if (Actualizar(cmd))
            {
                regFalla.EsNuevo = false;
            }

        }
   
        public DataTable GetRegistros(string codigo)
        {
            OracleCommand cmd = CrearCommand();
            cmd.CommandText = "select * from F_GF_REGFALLA where PK_COD_FALLA=:COD_FALLA";
            cmd.Parameters.Add("COD_FALLA", codigo);

            DataTable tabla = EjecutarCmd(cmd);
            tabla.TableName = RegFalla.NOMBRE_TABLA;

            return tabla;
        }
        public void IncrementarSincVer(int pkCodFalla)
        {
            OracleCommand cmd = CrearCommand();
            cmd.CommandText = "update F_GF_REGFALLA set sinc_ver = 1 where PK_COD_FALLA=:pkCodFalla";
            cmd.Parameters.Add("pkCodFalla", pkCodFalla);
            
            EjecutarCmd(cmd);
           

            
        }

        public DataTable GetRegistrosXGestion(int Gestion)
              {
            OracleCommand cmd = CrearCommand();
            cmd.CommandText = "select * from f_gf_regfalla where (substr (pk_cod_falla, 1,2)) = :GESTION order by pk_cod_falla asc";
            cmd.Parameters.Add("GESTION", Gestion);

            DataTable tabla = EjecutarCmd(cmd);
            tabla.TableName = RegFalla.NOMBRE_TABLA;

            return tabla;
        }


        public DataRow GetDataRowInforme(int codFalla, long origen, long tipo)
        {
            DataRow resultado = null;
            string sql = "SELECT * FROM {0} WHERE {1}=:{1} AND {2}=:{2} AND {3}=:{3}";
            sql = string.Format(sql, InformeFalla.NOMBRE_TABLA, InformeFalla.C_PK_COD_FALLA,
                InformeFalla.C_PK_ORIGEN_INFORME, InformeFalla.C_PK_D_COD_TIPOINFORME);
            OracleCommand cmd = CrearCommand();
            cmd.CommandText = sql;
            cmd.Parameters.Add(InformeFalla.C_PK_COD_FALLA, OracleDbType.Int32, codFalla, System.Data.ParameterDirection.Input);
            cmd.Parameters.Add(InformeFalla.C_PK_ORIGEN_INFORME, OracleDbType.Int64, origen, System.Data.ParameterDirection.Input);
            cmd.Parameters.Add(InformeFalla.C_PK_D_COD_TIPOINFORME, OracleDbType.Int64, tipo, System.Data.ParameterDirection.Input);
            DataTable tabla = EjecutarCmd(cmd);
            if (tabla.Rows.Count > 0)
            {
                resultado = tabla.Rows[0];
            }
            return resultado;
        }

        protected int GetId()
        {
            uint num = 0;
            OracleCommand cmd = CrearCommand();
            cmd.CommandText = "select GETNEXTREGFALLA from dual";
            cmd.CommandType = System.Data.CommandType.Text;
            try
            {
                num = Convert.ToUInt32(cmd.ExecuteScalar());
            }
            catch (OracleException oraEx)
            {
                PistaMgr.Instance.Error("OraDalSisFalla", oraEx);
            }
            catch (Exception ex)
            {
                PistaMgr.Instance.Error("OraDalSisFalla", ex);
            }
            finally
            {
                DisposeCommand(cmd);
            }
            return (int)num;
        }
        public DataTable GetGestiones()
        {
            DataTable tabla = EjecutarSql("select (gestion + 2000) gestion , to_number(gestion) valor from (select distinct (substr (pk_cod_falla, 1,2))  gestion from f_gf_regfalla) order by 1 desc");
            tabla.TableName = "f_gf_regfalla";
            return tabla;
        }   


        public DataTable GetTabla()
        {
            DataTable tabla = EjecutarSql("SELECT * FROM f_gf_regfalla ORDER BY PK_COD_FALLA DESC");
            tabla.TableName = "f_gf_regfalla";
            return tabla;
        }

        public bool Existe(DataRow row, DataTable tablaLocal)
        {
            bool resultado = false;
            DataRow[] registrosEncontrador = tablaLocal.Select(RegFalla.C_PK_COD_FALLA + "=" + row[RegFalla.C_PK_COD_FALLA]);
            resultado = registrosEncontrador.Length > 0;
            return resultado;
        }

        public DataTable GetAgentesInvolucrados()
        {
            DataTable resultado = null;

            string sql =
            @"SELECT pk_cod_falla, a.pk_cod_persona,Sigla AGENTE_TEMP
            ,d_cod_estado_notificacion,
            PKG_EST_INF.GetEstadoInformeFalla (pk_cod_falla, a.pk_cod_persona,20)  estado_pre ,
            PKG_EST_INF.GetEstadoInformeFalla (pk_cod_falla, a.pk_cod_persona,21)  estado_fin ,
            PKG_EST_INF.GetEstadoInformeFalla (pk_cod_falla, a.pk_cod_persona,22)  estado_rec 
            FROM f_gf_notificacion a, f_ap_persona b
            WHERE a.pk_cod_persona = b.pk_cod_persona and a.d_cod_estado=1
            ORDER BY Sigla";

            resultado = EjecutarSql(sql);
            return resultado;
        }



        #region IMgrLocal

        public string NombreTabla
        {
            get { return RegFalla.NOMBRE_TABLA; }
        }
        #endregion IMgrLocal

        #region IProveedorDatosSincronizacion
        public DataTable GetDatos(decimal versionCliente, long pkCodPersona, bool parcial)
        {
            parcial = false;
            PistaMgr.Instance.Debug("OraDalSisFalla.OraDalRegFallaMgr.GetDatos()", "obteniendo datos");
            DataTable resultado = null;
            string sql = string.Empty;
            if (parcial)
            {
                sql = @"SELECT a.*
                FROM f_gf_regfalla a
                WHERE a.sinc_ver > :sinc_ver 
                AND a.pk_cod_falla IN 
                (SELECT b.pk_cod_falla
                FROM f_gf_notificacion b
                WHERE b.pk_cod_persona=:pk_cod_persona AND b.D_COD_ESTADO_NOTIFICACION <> 41)";
            }
            else
            {
                sql = @"SELECT a.*
                FROM f_gf_regfalla a
                WHERE a.sinc_ver > :sinc_ver 
                AND a.pk_cod_falla IN 
                (SELECT b.pk_cod_falla
                FROM f_gf_notificacion b
                WHERE b.D_COD_ESTADO_NOTIFICACION <> 41)";
            }
            OracleCommand cmd = CrearCommand();
            cmd.CommandText = sql;
            cmd.Parameters.Add("sinc_ver", OracleDbType.Decimal, versionCliente, System.Data.ParameterDirection.Input);
            if (parcial)
            {
                cmd.Parameters.Add("pk_cod_persona", OracleDbType.Int64, pkCodPersona, System.Data.ParameterDirection.Input);
            }
            cmd.BindByName = true;

            resultado = EjecutarCmd(cmd);
            PistaMgr.Instance.Debug("OraDalSisFalla.OraDalRegFallaMgr.GetDatos()", string.Format("Retornando {0} Registros", resultado.Rows.Count));
            return resultado;
        }
        #endregion IProveedorDatosSincronizacion

        public int GetSiguienteNumFalla()
        {
            int resultado = 0;
            string sql =
            @"select max(f_gf_regfalla.pk_cod_falla)
              from f_gf_regfalla";
            DataTable tabla = EjecutarSql(sql);

            try
            {
                if (tabla.Rows.Count > 0)
                {
                    resultado = (int)((decimal)tabla.Rows[0][0] + 1);
                }
            }
            catch
            {
            }

            if (resultado == 0)
            {
                resultado = 110001;
            }

            return resultado;
        }

        public bool ExisteNumeroFalla(int codigo)
        {
            bool rtn = true;
            OracleCommand cmd = CrearCommand();
            cmd.CommandText = "select count(*) c from F_GF_REGFALLA where PK_COD_FALLA=:COD_FALLA";
            cmd.Parameters.Add("COD_FALLA", codigo);

            DataTable tabla = EjecutarCmd(cmd);
            int cont = (int)(decimal)tabla.Rows[0]["c"];
            if (cont == 0)
            {
                rtn = false;
            }


            return rtn;
        }

        public RegFalla GetFalla(int numFalla)
        {
            RegFalla resultado = null;
            OracleCommand cmd = CrearCommand();
            cmd.CommandText = "SELECT * FROM F_GF_REGFALLA WHERE PK_COD_FALLA=:PK_COD_FALLA";
            cmd.Parameters.Add("PK_COD_FALLA", OracleDbType.Int32, numFalla, System.Data.ParameterDirection.Input);
            cmd.BindByName = true;
            DataTable tabla = EjecutarCmd(cmd);
            if (tabla.Rows.Count > 0)
            {
                resultado = new RegFalla(tabla.Rows[0]);
            }
            
            return resultado;
        }

        public void GuardarCodColapso(int numFalla, D_COD_COLAPSO codColapso)
        {
            OracleCommand cmd = CrearCommand();
            cmd.CommandText = 
            @"update F_GF_REGFALLA set 
            D_COD_COLAPSO=:D_COD_COLAPSO 
            WHERE PK_COD_FALLA=:PK_COD_FALLA";

            cmd.Parameters.Add("PK_COD_FALLA", OracleDbType.Int32, numFalla, System.Data.ParameterDirection.Input);
            cmd.Parameters.Add("D_COD_COLAPSO", OracleDbType.Long, (long)codColapso, System.Data.ParameterDirection.Input);
            cmd.BindByName = true;

            Actualizar(cmd);
        }

        public bool Borrar(int numFalla, string motivo)
        {
            bool resultado = true;
            OracleCommand cmd = CrearCommand();
            cmd.CommandText = "f_borrar_reg_falla";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("p_cod_falla", OracleDbType.Int32, numFalla, System.Data.ParameterDirection.Input);
            cmd.Parameters.Add("p_comentario ", OracleDbType.Varchar2, motivo, System.Data.ParameterDirection.Input);
            cmd.Parameters.Add("RETURN", OracleDbType.Decimal).Direction = System.Data.ParameterDirection.ReturnValue;
            cmd.BindByName = true;
            try
            {
                cmd.ExecuteNonQuery();
                decimal res = ((Oracle.DataAccess.Types.OracleDecimal)(cmd.Parameters["RETURN"].Value)).Value;
                resultado = res != 0;
            }
            catch (Exception ex)
            {
                PistaMgr.Instance.Error("OraDalSisFalla", ex);
            }
            finally
            {
                DisposeCommand(cmd);
            }

            if (resultado)
            {
                OracleCommand cmdDeleteOper = CrearCommand();
                cmdDeleteOper.CommandText = 
                @"DELETE
                FROM F_GF_OPERACION
                WHERE PK_COD_FALLA = :PK_COD_FALLA";
                cmdDeleteOper.Parameters.Add("PK_COD_FALLA", OracleDbType.Int32, numFalla, System.Data.ParameterDirection.Input);
                cmdDeleteOper.BindByName = true;

                Actualizar(cmdDeleteOper);
            }
            return resultado;
        }

        public DataTable GetTablaFallas(long  pk_cod_pesona,D_COD_ESTADO_INF? filtroEstadoInforme)
        {
            DataTable resultado = null;
            if (filtroEstadoInforme == null)
            {
                string sql =
                @"select * from f_gf_regfalla a 
                    where pk_cod_falla in (
                    select distinct(pk_cod_falla) from f_gf_notificacion
                    where pk_cod_persona = :pk_cod_persona )";
                //WHERE a.pk_cod_falla IN (SELECT n.pk_cod_falla FROM f_gf_notificacion n
                //WHERE n.d_cod_estado=1 AND n.pk_cod_persona=:pk_cod_persona)";
                OracleCommand cmd = CrearCommand();
                cmd.CommandText = sql;
                cmd.Parameters.Add("pk_cod_persona", OracleDbType.Int64, Sesion.Instancia.EmpresaActual.PkCodPersona, ParameterDirection.Input);
                cmd.BindByName = true;

                resultado = EjecutarCmd(cmd);
            }
            else
            {
                long d_cod_estado_inf = (long)filtroEstadoInforme;
                string sql =
                @"SELECT DISTINCT a.*
                FROM f_gf_regfalla a, f_gf_informefalla b
                WHERE a.pk_cod_falla=b.pk_cod_falla
                AND b.d_cod_estado_inf=:d_cod_estado_inf
                AND b.pk_origen_informe=:pk_origen_informe
                ANd a.pk_cod_falla IN (SELECT n.pk_cod_falla FROM f_gf_notificacion n
                WHERE n.d_cod_estado=1 AND n.pk_cod_persona=:pk_cod_persona)";
                OracleCommand cmd = CrearCommand();
                cmd.CommandText = sql;
                cmd.Parameters.Add("d_cod_estado_inf", OracleDbType.Int64, d_cod_estado_inf, ParameterDirection.Input);
                cmd.Parameters.Add("pk_origen_informe", OracleDbType.Int64, Sesion.Instancia.EmpresaActual.PkCodPersona, ParameterDirection.Input);
                cmd.Parameters.Add("pk_cod_persona", OracleDbType.Int64, Sesion.Instancia.EmpresaActual.PkCodPersona, ParameterDirection.Input);
                cmd.BindByName = true;

                resultado = EjecutarCmd(cmd);
            }
            return resultado;
        }
        public DataTable GetTablaFallas(D_COD_ESTADO_INF? filtroEstadoInforme)
        {
            DataTable resultado = null;
            if (filtroEstadoInforme == null)
            {
                string sql =
                @"SELECT a.*
                FROM f_gf_regfalla a";
                //WHERE a.pk_cod_falla IN (SELECT n.pk_cod_falla FROM f_gf_notificacion n
                //WHERE n.d_cod_estado=1 AND n.pk_cod_persona=:pk_cod_persona)";
                OracleCommand cmd = CrearCommand();
                cmd.CommandText = sql;
                cmd.Parameters.Add("pk_cod_persona", OracleDbType.Int64, Sesion.Instancia.EmpresaActual.PkCodPersona, ParameterDirection.Input);
                cmd.BindByName = true;

                resultado = EjecutarCmd(cmd);
            }
            else
            {
                long d_cod_estado_inf = (long)filtroEstadoInforme;
                string sql =
                @"SELECT DISTINCT a.*
                FROM f_gf_regfalla a, f_gf_informefalla b
                WHERE a.pk_cod_falla=b.pk_cod_falla
                AND b.d_cod_estado_inf=:d_cod_estado_inf
                AND b.pk_origen_informe=:pk_origen_informe
                ANd a.pk_cod_falla IN (SELECT n.pk_cod_falla FROM f_gf_notificacion n
                WHERE n.d_cod_estado=1 AND n.pk_cod_persona=:pk_cod_persona)";
                OracleCommand cmd = CrearCommand();
                cmd.CommandText = sql;
                cmd.Parameters.Add("d_cod_estado_inf", OracleDbType.Int64, d_cod_estado_inf, ParameterDirection.Input);
                cmd.Parameters.Add("pk_origen_informe", OracleDbType.Int64, Sesion.Instancia.EmpresaActual.PkCodPersona, ParameterDirection.Input);
                cmd.Parameters.Add("pk_cod_persona", OracleDbType.Int64, Sesion.Instancia.EmpresaActual.PkCodPersona, ParameterDirection.Input);
                cmd.BindByName = true;

                resultado = EjecutarCmd(cmd);
            }
            return resultado;
        }

        public DataTable GetTablaFallasSinInformes()
        {
            DataTable resultado = null;
            string sql =
            @"select a.*
            from f_gf_regfalla a
            WHERE a.pk_cod_falla NOT IN(select distinct b.pk_cod_falla from f_gf_informeFalla b)
            AND a.pk_cod_falla IN (SELECT c.pk_cod_falla FROM f_gf_notificacion c WHERE c.pk_cod_persona=:pk_cod_persona)";
            OracleCommand cmd = CrearCommand();
            cmd.CommandText = sql;
            cmd.Parameters.Add("pk_cod_persona", OracleDbType.Int64, Sesion.Instancia.EmpresaActual.PkCodPersona, System.Data.ParameterDirection.Input);
            cmd.BindByName = true;

            resultado = EjecutarCmd(cmd);
            return resultado;
        }


        public void Insertar(List<DataRow> tabla)
        {
            string sql =
             @"insert into F_GF_REGFALLA 
             (PK_COD_FALLA,GESTION,PK_COD_COMPONENTE,FEC_INICIO,D_COD_CAUSA,DESCRIPCION_CORTA_FALLA,
              D_COD_ESTADO,SEC_LOG,D_COD_ORIGEN,D_COD_TIPO_DESCONEXION,FK_COD_OPERADOR,DESCRIPCION_FALLA ,
              FK_COD_SUPERVISOR,D_COD_PROBLEMA_GEN,D_COD_COLAPSO,SINC_VER
             )
             values 
             (:PK_COD_FALLA,:GESTION,:PK_COD_COMPONENTE,:FEC_INICIO,:D_COD_CAUSA,:DESCRIPCION,:D_COD_ESTADO,
              :SEC_LOG,:D_COD_ORIGEN,:D_COD_TIPO_DESCONEXION,:FK_COD_OPERADOR,:DESCRIPCION_FALLA ,
              :FK_COD_SUPERVISOR,:D_COD_PROBLEMA_GEN,:D_COD_COLAPSO,:SINC_VER
             )";
            InsertUpdate(tabla, sql);
        }

        public void Actualizar(List<DataRow> tabla)
        {
            string sql=
            "update F_GF_REGFALLA set " +
            "GESTION=:GESTION," +
            "PK_COD_COMPONENTE=:PK_COD_COMPONENTE," +
            "FEC_INICIO=:FEC_INICIO," +
            "D_COD_CAUSA=:D_COD_CAUSA," +
            "DESCRIPCION_CORTA_FALLA=:DESCRIPCION," +
            "D_COD_ESTADO=:D_COD_ESTADO, " +
            "SEC_LOG=:SEC_LOG, " +
            "D_COD_ORIGEN=:D_COD_ORIGEN, " +
            "D_COD_TIPO_DESCONEXION=:D_COD_TIPO_DESCONEXION, " +
            "FK_COD_OPERADOR=:FK_COD_OPERADOR, " +
            "DESCRIPCION_FALLA=:DESCRIPCION_FALLA, " +
            "FK_COD_SUPERVISOR=:FK_COD_SUPERVISOR, " +
            "D_COD_PROBLEMA_GEN=:D_COD_PROBLEMA_GEN, " +
            "D_COD_COLAPSO=:D_COD_COLAPSO, " +
            "SINC_VER=:SINC_VER " +
            "where PK_COD_FALLA=:PK_COD_FALLA";
            InsertUpdate(tabla, sql);
        }

        void InsertUpdate(List<DataRow> tabla, string sql)
        {
            OracleCommand cmd = null;
            cmd = CrearCommand();
            cmd.CommandText = sql;
            cmd.ArrayBindCount = tabla.Count;
            cmd.Parameters.Add("PK_COD_FALLA", OracleDbType.Int32, GetArray(tabla, "PK_COD_FALLA"), System.Data.ParameterDirection.Input);
            cmd.Parameters.Add("GESTION", OracleDbType.Int16, GetArray(tabla, "GESTION"), System.Data.ParameterDirection.Input);
            cmd.Parameters.Add("PK_COD_COMPONENTE", OracleDbType.Decimal, GetArray(tabla, "PK_COD_COMPONENTE"), System.Data.ParameterDirection.Input);
            cmd.Parameters.Add("FEC_INICIO", OracleDbType.Date, GetArray(tabla, "FEC_INICIO"), System.Data.ParameterDirection.Input);
            cmd.Parameters.Add("D_COD_CAUSA", OracleDbType.Int64, GetArray(tabla, "D_COD_CAUSA"), System.Data.ParameterDirection.Input);
            cmd.Parameters.Add("DESCRIPCION", OracleDbType.Varchar2, GetArray(tabla, RegFalla.C_DESCRIPCION), System.Data.ParameterDirection.Input);
            cmd.Parameters.Add("D_COD_ESTADO", OracleDbType.Varchar2, GetArray(tabla, "D_COD_ESTADO"), System.Data.ParameterDirection.Input);
            cmd.Parameters.Add("SEC_LOG", OracleDbType.Decimal, GetArray(tabla, "SEC_LOG"), System.Data.ParameterDirection.Input);
            cmd.Parameters.Add("D_COD_ORIGEN", OracleDbType.Int64, GetArray(tabla, "D_COD_ORIGEN"), System.Data.ParameterDirection.Input);
            cmd.Parameters.Add("D_COD_TIPO_DESCONEXION", OracleDbType.Int64, GetArray(tabla, "D_COD_TIPO_DESCONEXION"), System.Data.ParameterDirection.Input);
            cmd.Parameters.Add("FK_COD_OPERADOR", OracleDbType.Long, GetArray(tabla, "FK_COD_OPERADOR"), System.Data.ParameterDirection.Input);
            cmd.Parameters.Add("DESCRIPCION_FALLA", OracleDbType.Varchar2, GetArray(tabla, "DESCRIPCION_FALLA"), System.Data.ParameterDirection.Input);
            cmd.Parameters.Add("FK_COD_SUPERVISOR", OracleDbType.Long, GetArray(tabla, "FK_COD_SUPERVISOR"), System.Data.ParameterDirection.Input);
            cmd.Parameters.Add("D_COD_PROBLEMA_GEN", OracleDbType.Long, GetArray(tabla, "D_COD_PROBLEMA_GEN"), System.Data.ParameterDirection.Input);
            cmd.Parameters.Add("D_COD_COLAPSO", OracleDbType.Long, GetArray(tabla, "D_COD_COLAPSO"), System.Data.ParameterDirection.Input);
            cmd.Parameters.Add("SINC_VER", OracleDbType.Long, GetArray(tabla, "SINC_VER"), System.Data.ParameterDirection.Input);
            cmd.BindByName = true;

            Actualizar(cmd);
        }

        public BindingList<Persona> GetAgentesNotificados(int p)
        {
            BindingList<Persona> resultado = new BindingList<Persona>();
            string sql =
            @"select * from f_ap_persona p
            where p.pk_cod_persona in 
            (SELECT n.pk_cod_persona from f_gf_notificacion n
            WHERE n.pk_cod_falla=:pk_cod_falla 
            AND n.d_cod_estado_notificacion<>:d_cod_estado_notificacion
            AND d_cod_estado='1')";
            OracleCommand cmd = CrearCommand();
            cmd.CommandText = sql;
            cmd.Parameters.Add("pk_cod_falla", OracleDbType.Int32, p, System.Data.ParameterDirection.Input);
            cmd.Parameters.Add("d_cod_estado_notificacion", OracleDbType.Int64, (long)D_COD_ESTADO_NOTIFICACION.REGISTRADO, System.Data.ParameterDirection.Input);
            cmd.BindByName = true;
            DataTable tabla = EjecutarCmd(cmd);
            foreach (DataRow r in tabla.Rows)
            {
                resultado.Add(new Persona(r));
            }
            
            return resultado;
        }

        public BindingList<Persona> GetAgentesSinNotificar(int p)
        {
            BindingList<Persona> resultado = new BindingList<Persona>();
            string sql =
            @"select * from f_ap_persona p
            where p.pk_cod_persona in 
            (SELECT n.pk_cod_persona from f_gf_notificacion n
            WHERE n.pk_cod_falla=:pk_cod_falla AND n.d_cod_estado_notificacion=:d_cod_estado_notificacion)";
            OracleCommand cmd = CrearCommand();
            cmd.CommandText = sql;
            cmd.Parameters.Add("pk_cod_falla", OracleDbType.Int32, p, System.Data.ParameterDirection.Input);
            cmd.Parameters.Add("d_cod_estado_notificacion", OracleDbType.Int64, (long)D_COD_ESTADO_NOTIFICACION.REGISTRADO, ParameterDirection.Input);
            cmd.BindByName = true;
            DataTable tabla = EjecutarCmd(cmd);
            foreach (DataRow r in tabla.Rows)
            {
                resultado.Add(new Persona(r));
            }

            return resultado;
        }


        public DataTable GetAgentesInvolucrados(int numFalla)
        {
            string sql =
            @"select p.* 
            from f_ap_persona p
            where p.pk_cod_persona in 
            (select n.pk_cod_persona from f_gf_notificacion n
            where n.pk_cod_falla=:pk_cod_falla AND n.d_cod_estado=1)";
            OracleCommand cmd = CrearCommand();
            cmd.CommandText = sql;
            cmd.Parameters.Add("pk_cod_falla", OracleDbType.Int32, numFalla, System.Data.ParameterDirection.Input);
            cmd.BindByName = true;
            DataTable resultado = EjecutarCmd(cmd);
            return resultado;
        }

        public bool EstaInvolucrado(int pkCodFalla, long pkCodPersona)
        {
            bool resultado = false;
            string sql =
            @"SELECT COUNT(pk_cod_falla)            
            FROM f_gf_notificacion 
            WHERE pk_cod_persona=:pk_cod_persona 
            AND pk_cod_falla=:pk_cod_falla";

            OracleCommand cmd = CrearCommand();
            cmd.CommandText = sql;
            cmd.Parameters.Add("pk_cod_falla", OracleDbType.Int32, pkCodFalla, System.Data.ParameterDirection.Input);
            cmd.Parameters.Add("pk_cod_persona", OracleDbType.Int64, pkCodPersona, System.Data.ParameterDirection.Input);
            cmd.BindByName = true;

            DataTable tabla = EjecutarCmd(cmd);
            if (tabla.Rows.Count > 0)
            {
                resultado = (decimal)tabla.Rows[0][0] > 0;
            }
            return resultado;
        }

        public void UpdateFecInicio(long regFallaId, DateTime nuevaFecIni)
        {
            OracleCommand cmd = null;
            string sql = string.Empty;

            sql = "UPDATE {0} SET " +
            "{2}=:{2} " +
            "WHERE {1}=:{1} ";

            sql = string.Format(sql,
                NombreTabla,
                RegFalla.C_PK_COD_FALLA,
                RegFalla.C_FEC_INICIO
                );

            cmd = CrearCommand();
            cmd.CommandText = sql;
            cmd.BindByName = true;
            cmd.Parameters.Add(RegFalla.C_PK_COD_FALLA, OracleDbType.Int64, regFallaId, System.Data.ParameterDirection.Input);
            cmd.Parameters.Add(RegFalla.C_FEC_INICIO, OracleDbType.Date, nuevaFecIni, System.Data.ParameterDirection.Input);

            Actualizar(cmd);
        }

        public bool isDelete(int pkCodFalla)
        {
            string sql =
            @"select * 
            from F_GF_INFORMEFALLA infFalla
            where PK_COD_FALLA = :pk_cod_falla ";
            OracleCommand cmd = CrearCommand();
            cmd.CommandText = sql;
            cmd.Parameters.Add("pk_cod_falla", OracleDbType.Int32, pkCodFalla, System.Data.ParameterDirection.Input);
            cmd.BindByName = true;
            DataTable resultado = EjecutarCmd(cmd);

            Console.WriteLine("Numero de filas:: "+ resultado.Rows.Count+"; codFalla:: "+pkCodFalla);
            if (resultado.Rows.Count > 0)
                return false;
            else
                return true;
        }

        public bool DeleteRegFallaById(int pkCodFalla)
        {
            bool delete = false;
            OracleCommand cmdDeleteOper = CrearCommand();
            cmdDeleteOper.CommandText =
            @"DELETE
                FROM F_GF_REGFALLA
                WHERE PK_COD_FALLA = :PK_COD_FALLA";
            cmdDeleteOper.Parameters.Add("PK_COD_FALLA", OracleDbType.Int32, pkCodFalla, System.Data.ParameterDirection.Input);
            cmdDeleteOper.BindByName = true;

            Actualizar(cmdDeleteOper);

            return delete;
        }
    }
}