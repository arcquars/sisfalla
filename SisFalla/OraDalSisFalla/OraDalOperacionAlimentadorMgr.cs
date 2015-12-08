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
using CNDC.BLL;
using CNDC.Sincronizacion;

namespace OraDalSisFalla
{
    public class OraDalOperacionAlimentadorMgr : OraDalBaseMgr, IOperacionAlimentadorMgr, IMgrLocal, IProveedorDatosSincronizacion
    {
        public OraDalOperacionAlimentadorMgr()
        {

        }
        public OraDalOperacionAlimentadorMgr(ConnexionOracleMgr c)
            : base(c)
        { }

        public void Guardar(OperacionAlimentador obj)
        {
            OracleCommand cmd = null;
            string sql = string.Empty;
            if (obj.EsNuevo)
            {
                sql = "INSERT INTO {0} ({1},{2},{3},{4},{5},{6},{7},{8},{9},{10},{11},{12})" +
                "VALUES(:{1},:{2},:{3},:{4},:{5},:{6},:{7},:{8},:{9},:{10},:{11},:{12})";
            }
            else
            {
                sql = "UPDATE {0} SET " +
                "{6}=:{6} ," +
                "{7}=:{7} ," +
                "{8}=:{8} ," +
                "{9}=:{9} ," +
                "{10}=:{10},  " +
                "{11}=:{11},  " +
                "{12}=:{12}  " +
                "WHERE " +
                "{1}=:{1} AND " +
                "{2}=:{2} AND " +
                "{3}=:{3} AND " +
                "{4}=:{4} AND " +
                "{5}=:{5}";
            }

            sql = string.Format(sql, OperacionAlimentador.NOMBRE_TABLA,
            OperacionAlimentador.C_PK_COD_FALLA,
            OperacionAlimentador.C_PK_ORIGEN_INFORME,
            OperacionAlimentador.C_PK_D_COD_INFORME,
            OperacionAlimentador.C_PK_COD_COMPONENTE,
            OperacionAlimentador.C_FECHA_APERTURA,
            OperacionAlimentador.C_D_COD_TIPO_OPER_APER,
            OperacionAlimentador.C_FECHA_CIERRE,
            OperacionAlimentador.C_RELE_OPERADO,
            OperacionAlimentador.C_D_COD_TIPO_OP_CIERRE,
            OperacionAlimentador.C_POT_DESC,
            OperacionAlimentador.C_SINC_VER,
            OperacionAlimentador.C_COD_EDAC);
            cmd = CrearCommand();
            cmd.CommandText = sql;
            cmd.BindByName = true;
            cmd.Parameters.Add(OperacionAlimentador.C_PK_COD_FALLA, OracleDbType.Int32, obj.PkCodFalla, ParameterDirection.Input);
            cmd.Parameters.Add(OperacionAlimentador.C_PK_ORIGEN_INFORME, OracleDbType.Int64, obj.PkOrigenInforme, ParameterDirection.Input);
            cmd.Parameters.Add(OperacionAlimentador.C_PK_D_COD_INFORME, OracleDbType.Int64, obj.PkDCodInforme, ParameterDirection.Input);
            cmd.Parameters.Add(OperacionAlimentador.C_PK_COD_COMPONENTE, OracleDbType.Int64, obj.PkCodComponente, ParameterDirection.Input);
            cmd.Parameters.Add(OperacionAlimentador.C_FECHA_APERTURA, OracleDbType.Date, obj.FechaApertura, ParameterDirection.Input);
            cmd.Parameters.Add(OperacionAlimentador.C_D_COD_TIPO_OPER_APER, OracleDbType.Decimal, obj.DCodTipoOperAper, ParameterDirection.Input);
            cmd.Parameters.Add(OperacionAlimentador.C_FECHA_CIERRE, OracleDbType.Date, obj.FechaCierre, ParameterDirection.Input);
            cmd.Parameters.Add(OperacionAlimentador.C_RELE_OPERADO, OracleDbType.Int16, obj.ReleOperado, ParameterDirection.Input);
            cmd.Parameters.Add(OperacionAlimentador.C_D_COD_TIPO_OP_CIERRE, OracleDbType.Decimal, obj.DCodTipoOpCierre, ParameterDirection.Input);
            cmd.Parameters.Add(OperacionAlimentador.C_POT_DESC, OracleDbType.Single, obj.PotDesc, ParameterDirection.Input);
            cmd.Parameters.Add(OperacionAlimentador.C_SINC_VER, OracleDbType.Single, obj.SincVer, ParameterDirection.Input);
            cmd.Parameters.Add(OperacionAlimentador.C_COD_EDAC, OracleDbType.Int64, obj.CodEdac, ParameterDirection.Input);

            if (Actualizar(cmd))
            {
                obj.EsNuevo = false;
            }
        }

        public DataTable GetTabla()
        {
            string sql =
            @"select op.*, op.RowId 
            from F_GF_OP_ALIMENTADOR op";
            DataTable tabla = EjecutarSql(sql);
            tabla.TableName = NombreTabla;
            return tabla;
        }

        public BindingList<OperacionAlimentador> GetLista()
        {
            BindingList<OperacionAlimentador> resultado = new BindingList<OperacionAlimentador>();
            DataTable tablaAgentes = GetTabla();
            foreach (DataRow row in tablaAgentes.Rows)
            {
                resultado.Add(new OperacionAlimentador(row));
            }
            return resultado;
        }

        public DataTable GetOpeAlim(InformeFalla informe)
        {
            DataTable resultado = null;
            /*string sql =
            @"SELECT A.*,A.RowId,C.DESCRIPCION_DOMINIO TIPO_APERTURA, 
            D.DESCRIPCION_DOMINIO TIPO_CIERRE, 
            B.NOMBRE_COMPONENTE Alimentador, B.DESCRIPCION_COMPONENTE, E.TIPO_EDAC, E.AJUSTE_EDAC,E.ETAPA_EDAC 
            FROM F_GF_OP_ALIMENTADOR A, F_AC_COMPONENTE B, p_def_dominios C, 
            p_def_dominios D, f_gf_param_edac E,f_gf_rcomponente_edac F 
            WHERE a.pk_cod_componente=B.PK_COD_COMPONENTE AND 
            A.D_COD_TIPO_OPER_APER=C.COD_DOMINIO AND 
            A.D_COD_TIPO_OP_CIERRE=D.COD_DOMINIO AND 
            A.pk_cod_componente(+)=F.PK_COD_COMPONENTE AND 
            E.PK_COD_EDAC(+)=f.pk_cod_edac AND  
            A.PK_COD_FALLA=:PK_COD_FALLA AND 
            A.PK_ORIGEN_INFORME=:PK_ORIGEN_INFORME AND 
            A.PK_D_COD_TIPOINFORME=:PK_D_COD_TIPOINFORME ";*/

            string sql =
            @"SELECT A.*,A.RowId,C.DESCRIPCION_DOMINIO TIPO_APERTURA, 
            D.DESCRIPCION_DOMINIO TIPO_CIERRE, 
            B.NOMBRE_COMPONENTE Alimentador, B.DESCRIPCION_COMPONENTE, E.TIPO_EDAC, E.AJUSTE_EDAC,E.ETAPA_EDAC 
            FROM F_GF_OP_ALIMENTADOR A, F_AC_COMPONENTE B, p_def_dominios C, 
            p_def_dominios D, f_gf_param_edac E
            WHERE a.pk_cod_componente=B.PK_COD_COMPONENTE AND 
            A.D_COD_TIPO_OPER_APER=C.COD_DOMINIO AND 
            A.D_COD_TIPO_OP_CIERRE=D.COD_DOMINIO AND 
            A.COD_EDAC = E.PK_COD_EDAC (+) AND 
            A.PK_COD_FALLA=:PK_COD_FALLA AND 
            A.PK_ORIGEN_INFORME=:PK_ORIGEN_INFORME AND 
            A.PK_D_COD_TIPOINFORME=:PK_D_COD_TIPOINFORME";

            OracleCommand cmd = CrearCommand();
            cmd.CommandText = sql;
            cmd.Parameters.Add(OperacionAlimentador.C_PK_COD_FALLA, OracleDbType.Int32, informe.PkCodFalla, System.Data.ParameterDirection.Input);
            cmd.Parameters.Add(OperacionAlimentador.C_PK_ORIGEN_INFORME, OracleDbType.Int64, informe.PkOrigenInforme, System.Data.ParameterDirection.Input);
            cmd.Parameters.Add(OperacionAlimentador.C_PK_D_COD_INFORME, OracleDbType.Int64, informe.PkDCodTipoinforme, System.Data.ParameterDirection.Input);
            cmd.BindByName = true;
            resultado = EjecutarCmd(cmd);
            return resultado;
        }

        public DataTable GetOpeAlimConOpEdac(InformeFalla informe)
        {
            DataTable resultado = null;

            string sql =
            @"SELECT A.*,A.RowId,C.DESCRIPCION_DOMINIO TIPO_APERTURA, 
            D.DESCRIPCION_DOMINIO TIPO_CIERRE, 
            B.NOMBRE_COMPONENTE Alimentador, B.DESCRIPCION_COMPONENTE, E.TIPO_EDAC, E.AJUSTE_EDAC,E.ETAPA_EDAC 
            FROM F_GF_OP_ALIMENTADOR A, F_AC_COMPONENTE B, p_def_dominios C, 
            p_def_dominios D, f_gf_param_edac E
            WHERE a.pk_cod_componente=B.PK_COD_COMPONENTE AND 
            A.D_COD_TIPO_OPER_APER=C.COD_DOMINIO AND 
            A.D_COD_TIPO_OP_CIERRE=D.COD_DOMINIO AND 
            A.COD_EDAC = E.PK_COD_EDAC AND 
            A.PK_COD_FALLA=:PK_COD_FALLA AND 
            A.PK_ORIGEN_INFORME=:PK_ORIGEN_INFORME AND 
            A.PK_D_COD_TIPOINFORME=:PK_D_COD_TIPOINFORME";

            OracleCommand cmd = CrearCommand();
            cmd.CommandText = sql;
            cmd.Parameters.Add(OperacionAlimentador.C_PK_COD_FALLA, OracleDbType.Int32, informe.PkCodFalla, System.Data.ParameterDirection.Input);
            cmd.Parameters.Add(OperacionAlimentador.C_PK_ORIGEN_INFORME, OracleDbType.Int64, informe.PkOrigenInforme, System.Data.ParameterDirection.Input);
            cmd.Parameters.Add(OperacionAlimentador.C_PK_D_COD_INFORME, OracleDbType.Int64, informe.PkDCodTipoinforme, System.Data.ParameterDirection.Input);
            cmd.BindByName = true;
            resultado = EjecutarCmd(cmd);
            return resultado;
        }

        public DataTable GetEtapasConEdac(string Agente, int Categoria,string fecha)
        {
            DataTable resultado = null;

            string sql =
            @"SELECT


            A.Pk_Cod_Edac AS CodigoEdac,
            B.PK_COD_COMPONENTE AS CodigoAlimentador,
            d.SIGLA AS Agente,
            A.ROWID as Fila
                        
                        FROM F_Gf_Rcomponente_Edac A,
                        F_Ac_Componente B ,
               	        F_gf_param_edac c,
												F_AP_PERSONA d,
												P_DEF_DOMINIOS e
                        WHERE 
						trunc(A.FECHA_INICIO) = to_date('{2}','DD/MM/YYYY')
                        AND C.Pk_Cod_Edac = A.Pk_Cod_Edac
                       
                        AND A.Pk_Cod_Componente = B.Pk_Cod_Componente
		        AND B.PROPIETARIO = d.PK_COD_PERSONA
            AND C.TIPO_EDAC = e.DESCRIPCION_DOMINIO
            AND d.SIGLA = '{0}'
            AND e.ORDEN BETWEEN {1} AND ({1} + 99)         
            ORDER BY e.ORDEN  ASC";

            OracleCommand cmd = CrearCommand();
            sql = string.Format(sql,Agente,Categoria.ToString(),fecha);
            cmd.CommandText = sql;
            cmd.BindByName = true;
            resultado = EjecutarCmd(cmd);
            return resultado;
        }

        public DataTable GetEtapasDeEdac(int Categoria)
        {
            DataTable resultado = null;

            string sql =
            @"SELECT
            F_GF_PARAM_EDAC.PK_COD_EDAC AS COD_EDAC,
            F_GF_PARAM_EDAC.TIPO_EDAC || ' | ' || TO_CHAR(F_GF_PARAM_EDAC.AJUSTE_EDAC,'90D99') || ' | ' || TO_CHAR(F_GF_PARAM_EDAC.ETAPA_EDAC,'90D999') AS DESC_EDAC
            FROM
            F_GF_PARAM_EDAC
            INNER JOIN P_DEF_DOMINIOS ON F_GF_PARAM_EDAC.TIPO_EDAC = P_DEF_DOMINIOS.DESCRIPCION_DOMINIO
            AND P_DEF_DOMINIOS.ORDEN BETWEEN {0} AND ({0} + 99) 
            ORDER BY
            P_DEF_DOMINIOS.ORDEN asc";

            OracleCommand cmd = CrearCommand();
            sql = string.Format(sql, Categoria.ToString());
            cmd.CommandText = sql;
            cmd.BindByName = true;
            resultado = EjecutarCmd(cmd);
            return resultado;
        }
        public long GetEtapasDeEdac(string descripcion)
        {
            DataTable resultado = null;

            string sql =
            @"SELECT A.COD_EDAC FROM
            (
            SELECT
                        F_GF_PARAM_EDAC.PK_COD_EDAC AS COD_EDAC,
                        F_GF_PARAM_EDAC.TIPO_EDAC || ' | ' || TO_CHAR(F_GF_PARAM_EDAC.AJUSTE_EDAC,'90D99') || ' | ' || TO_CHAR(F_GF_PARAM_EDAC.ETAPA_EDAC,'90D999') AS DESC_EDAC
                        FROM
                        F_GF_PARAM_EDAC
                        INNER JOIN P_DEF_DOMINIOS ON F_GF_PARAM_EDAC.TIPO_EDAC = P_DEF_DOMINIOS.DESCRIPCION_DOMINIO
            
                        ORDER BY
                        P_DEF_DOMINIOS.ORDEN asc
            ) A
            WHERE
            A.DESC_EDAC LIKE '%{0}%'";

            OracleCommand cmd = CrearCommand();
            sql = string.Format(sql, descripcion);
            cmd.CommandText = sql;
            cmd.BindByName = true;
            resultado = EjecutarCmd(cmd);
            return ObjetoDeNegocio.GetValor<long>(resultado.Rows[0]["COD_EDAC"]);
            
        }

        public string GetUltimoEdac()
        {
            DataTable resultado = null;
            string fechaMaxima = string.Empty;
            string sql =
            @"SELECT TO_CHAR(MAX(A.FECHA_INICIO),'DD/MM/YYYY') AS FECHAMAX FROM F_GF_RCOMPONENTE_EDAC A WHERE A.FECHA_FIN is NULL";

            OracleCommand cmd = CrearCommand();
            sql = string.Format(sql);
            cmd.CommandText = sql;
            cmd.BindByName = true;
            resultado = EjecutarCmd(cmd);
            if (resultado.Rows.Count > 0)
            {
                fechaMaxima = resultado.Rows[0]["FECHAMAX"].ToString();
            }
            return fechaMaxima;
        }

        public DataTable GetAlimentadoresEdac(String Agente)
        {
            DataTable resultado = null;

            string sql =
            @"SELECT
            F_AC_COMPONENTE.PK_COD_COMPONENTE as COD_ALI,
            F_AC_COMPONENTE.NOMBRE_COMPONENTE as DESC_ALI
            FROM
            F_AC_COMPONENTE
            INNER JOIN F_AP_PERSONA ON F_AC_COMPONENTE.PROPIETARIO = F_AP_PERSONA.PK_COD_PERSONA
            WHERE
            F_AC_COMPONENTE.D_TIPO_COMPONENTE = 3
            AND F_AP_PERSONA.SIGLA = '{0}'
            ORDER BY 2";

            OracleCommand cmd = CrearCommand();
            sql = string.Format(sql, Agente);
            cmd.CommandText = sql;
            cmd.BindByName = true;
            resultado = EjecutarCmd(cmd);
            return resultado;
        }
        public DataTable GetAgentesDeEdac(DateTime fecha)
        {
            DataTable resultado = null;

//            string sql =
//            @"SELECT
//            DISTINCT
//                        B.Propietario as COD_AGENTE,
//                        d.SIGLA as SIGLA_AGENTE
//                        FROM F_Gf_Rcomponente_Edac A,
//                        F_Ac_Componente B ,
//               	        F_gf_param_edac c,
//												F_AP_PERSONA d
//                        WHERE 
//						trunc(A.FECHA_INICIO) =:pfecha
//                        AND C.Pk_Cod_Edac = A.Pk_Cod_Edac
//                        
//                        AND A.Pk_Cod_Componente = B.Pk_Cod_Componente
//		        AND B.PROPIETARIO = d.PK_COD_PERSONA
//            ORDER BY 2";

            string sql = @"SELECT DISTINCT
  B.Propietario AS COD_AGENTE,
  d.SIGLA       AS SIGLA_AGENTE
FROM
  F_Ac_Componente B ,
  F_AP_PERSONA d
WHERE
  B.PROPIETARIO        = d.PK_COD_PERSONA
AND b.d_tipo_componente=3
ORDER BY
  2";

            OracleCommand cmd = CrearCommand();
            cmd.Parameters.Add("pfecha", OracleDbType.Date, fecha, ParameterDirection.Input);
            sql = string.Format(sql,fecha);
            cmd.CommandText = sql;
            cmd.BindByName = true;
            resultado = EjecutarCmd(cmd);
            return resultado;
        }
        public bool ExistePeriodoEdac(PeriodoEdac periodo)
        {
            bool resultado = false;
             string sql =
            @"SELECT
            A.*
            FROM
            F_GF_RCOMPONENTE_EDAC A
            WHERE
            A.PK_COD_EDAC = :COD_EDAC
            AND A.PK_COD_COMPONENTE = :COD_COMPONENTE
            AND to_date(:FECHA_INICIO,'DD/MM/YYYY') BETWEEN A.FECHA_INICIO AND NVL(A.FECHA_FIN,A.FECHA_INICIO+1)";

            DataTable tabla = null;
            OracleCommand cmd = CrearCommand();

            cmd.CommandText = sql;
            cmd.Parameters.Add("COD_EDAC", OracleDbType.Int64, periodo.PkCodEdac, ParameterDirection.Input);
            cmd.Parameters.Add("COD_COMPONENTE", OracleDbType.Int64, periodo.PKCodAlimentador, ParameterDirection.Input);
            cmd.Parameters.Add("FECHA_INICIO", OracleDbType.Varchar2, periodo.FechaInicioVigencia, ParameterDirection.Input);
            cmd.BindByName = true;
            tabla = EjecutarCmd(cmd);
            if (tabla.Rows.Count > 0)
            {
                resultado = true;
            }
            return resultado;
        }

        public void InsertarPeriodoEdac(PeriodoEdac periodo)
        {
            string sql = @"INSERT " +
            "INTO F_GF_RCOMPONENTE_EDAC " +
            "(PK_COD_EDAC,PK_COD_COMPONENTE,FECHA_INICIO) " +
            "VALUES " +
            "(:COD_EDAC,:COD_COMPONENTE,to_date(:FECHA_INICIO,'DD/MM/YYYY'))";
            
            OracleCommand cmd = CrearCommand();
            cmd.CommandText = sql;
            cmd.Parameters.Add("COD_EDAC", OracleDbType.Int64, periodo.PkCodEdac, ParameterDirection.Input);
            cmd.Parameters.Add("COD_COMPONENTE", OracleDbType.Int64, periodo.PKCodAlimentador, ParameterDirection.Input);
            cmd.Parameters.Add("FECHA_INICIO", OracleDbType.Varchar2, periodo.FechaInicioVigencia, ParameterDirection.Input);

            cmd.BindByName = true;
            Actualizar(cmd);
        }
        public bool CrearNuevoPeriodo(DateTime periodo, DateTime nuevoPeriodo)
        {
            bool resultado = false;
            string sql = @"INSERT 
            INTO F_GF_RCOMPONENTE_EDAC
            (PK_COD_EDAC,PK_COD_COMPONENTE,FECHA_INICIO) 
            (
            SELECT
            PK_COD_EDAC,PK_COD_COMPONENTE,to_date('{1}','dd/mm/yyyy')
            FROM
            F_GF_RCOMPONENTE_EDAC
            WHERE
            FECHA_INICIO = to_date('{0}','dd/mm/yyyy')
            )";

            OracleCommand cmd = CrearCommand();
            sql = string.Format(sql, periodo.ToString("dd/MM/yyyy"), nuevoPeriodo.ToString("dd/MM/yyyy"));
            cmd.CommandText = sql;
            cmd.BindByName = true;
            
            if (Actualizar(cmd))
            {
                resultado = true;
            }
            return resultado;
        }
        public bool ModificarNuevoPeriodo(DateTime periodo, DateTime nuevoPeriodo)
        {
            bool resultado = false;
            string sql = @"UPDATE 
            F_GF_RCOMPONENTE_EDAC 
            SET FECHA_FIN=to_date('{1}','dd/mm/yyyy') 
            WHERE FECHA_INICIO = to_date('{0}','dd/mm/yyyy')";

            OracleCommand cmd = CrearCommand();
            sql = string.Format(sql, periodo.ToString("dd/MM/yyyy"), nuevoPeriodo.AddDays(-1).ToString("dd/MM/yyyy"));
            cmd.CommandText = sql;
            cmd.BindByName = true;

            if (Actualizar(cmd))
            {
                resultado = true;
            }
            return resultado;
        }
        public void ActualizarPeriodoEdac(PeriodoEdac periodo)
        {
            string sql = @"UPDATE " +
            "F_GF_RCOMPONENTE_EDAC SET " +
            "PK_COD_EDAC = :COD_EDAC, PK_COD_COMPONENTE = :COD_COMPONENTE " +
            "WHERE " +
            "ROWID = :ROW_ID";

            OracleCommand cmd = CrearCommand();
            cmd.CommandText = sql;
            cmd.Parameters.Add("COD_EDAC", OracleDbType.Int64, periodo.PkCodEdac, ParameterDirection.Input);
            cmd.Parameters.Add("COD_COMPONENTE", OracleDbType.Int64, periodo.PKCodAlimentador, ParameterDirection.Input);
            cmd.Parameters.Add("ROW_ID", OracleDbType.Varchar2, periodo.Rowid, ParameterDirection.Input);

            cmd.BindByName = true;
            Actualizar(cmd);
        }
        public void BorrarPeriodoEdac(PeriodoEdac periodo)
        {
            string sql = @"DELETE " +
            "FROM F_GF_RCOMPONENTE_EDAC " +
            "WHERE " +
            "ROWID = :ROW_ID";

            OracleCommand cmd = CrearCommand();
            cmd.CommandText = sql;
            cmd.Parameters.Add("ROW_ID", OracleDbType.Varchar2, periodo.Rowid, ParameterDirection.Input);
            cmd.BindByName = true;
            Actualizar(cmd);
        }
        public DataTable GetPotenciaPorAgenteConOpEdac(InformeFalla informe)
        {
            DataTable resultado = null;

            string sql =
            @"SELECT 
            F.SIGLA AS SIGLA,
            sum(A.POT_DESC) AS POT_DESC
            FROM 
            F_GF_OP_ALIMENTADOR A, F_AC_COMPONENTE B, f_gf_param_edac E,  F_AP_PERSONA F
            WHERE a.pk_cod_componente=B.PK_COD_COMPONENTE AND
            A.COD_EDAC = E.PK_COD_EDAC AND  
            B.PROPIETARIO = F.PK_COD_PERSONA AND
            A.PK_COD_FALLA=:PK_COD_FALLA AND 
            A.PK_ORIGEN_INFORME=:PK_ORIGEN_INFORME AND 
            A.PK_D_COD_TIPOINFORME=:PK_D_COD_TIPOINFORME
            GROUP BY F.SIGLA
            ORDER BY F.SIGLA
            ";

            OracleCommand cmd = CrearCommand();
            cmd.CommandText = sql;
            cmd.Parameters.Add(OperacionAlimentador.C_PK_COD_FALLA, OracleDbType.Int32, informe.PkCodFalla, System.Data.ParameterDirection.Input);
            cmd.Parameters.Add(OperacionAlimentador.C_PK_ORIGEN_INFORME, OracleDbType.Int64, informe.PkOrigenInforme, System.Data.ParameterDirection.Input);
            cmd.Parameters.Add(OperacionAlimentador.C_PK_D_COD_INFORME, OracleDbType.Int64, informe.PkDCodTipoinforme, System.Data.ParameterDirection.Input);
            cmd.BindByName = true;
            resultado = EjecutarCmd(cmd);
            return resultado;
        }

        public Edac GetEdac(decimal codComponente, DateTime fecha)
        {
            Edac resultado = null;
            /*string sql =
            @"SELECT  
            B.PK_COD_EDAC, B.TIPO_EDAC, B.AJUSTE_EDAC,B.ETAPA_EDAC 
            FROM 
            F_AC_COMPONENTE A, f_gf_param_edac B,f_gf_rcomponente_edac C
            WHERE  
            A.pk_cod_componente=C.PK_COD_COMPONENTE AND 
            B.PK_COD_EDAC=C.pk_cod_edac AND 
            A.pk_cod_componente=:pk_cod_componente";*/

            string sql =
            @"select pe.*
            from f_gf_param_edac pe
            where pe.pk_cod_edac IN
            (SELECT r.pk_cod_edac 
             from f_gf_rcomponente_edac r
             WHERE r.pk_cod_componente=:cod_componente
             AND :fecha between r.fecha_inicio and NVL(r.fecha_fin,sysdate+1) )";

            DataTable tabla = null;
            OracleCommand cmd = CrearCommand();
            cmd.CommandText = sql;
            cmd.Parameters.Add("cod_componente", OracleDbType.Decimal, codComponente, ParameterDirection.Input);
            cmd.Parameters.Add("fecha", OracleDbType.Date, fecha.Date, ParameterDirection.Input);
            cmd.BindByName = true;
            tabla = EjecutarCmd(cmd);

            if (tabla.Rows.Count > 0)
            {
                resultado = new Edac();
                resultado.PkCodEdac = ObjetoDeNegocio.GetValor<long>(tabla.Rows[0]["PK_COD_EDAC"]);
                resultado.Etapa = ObjetoDeNegocio.GetValor<string>(tabla.Rows[0]["TIPO_EDAC"]);
                resultado.Frecuencia = ObjetoDeNegocio.GetValor<float>(tabla.Rows[0]["AJUSTE_EDAC"]).ToString("N2");
                resultado.Tiempo = ObjetoDeNegocio.GetValor<float>(tabla.Rows[0]["ETAPA_EDAC"]);
            }
            return resultado;
        }

        public void Borrar(OperacionAlimentador opAli)
        {
            string sql = @"DELETE
            FROM F_GF_OP_ALIMENTADOR
            WHERE PK_COD_FALLA       = :PK_COD_FALLA
            AND PK_ORIGEN_INFORME    = :PK_ORIGEN_INFORME
            AND PK_D_COD_TIPOINFORME = :PK_D_COD_TIPOINFORME
            AND PK_COD_COMPONENTE    = :PK_COD_COMPONENTE
            AND FECHA_APERTURA       = :FECHA_APERTURA";
            OracleCommand cmd = CrearCommand();
            cmd.CommandText = sql;
            cmd.Parameters.Add("PK_COD_FALLA", OracleDbType.Int32, opAli.PkCodFalla, ParameterDirection.Input);
            cmd.Parameters.Add("PK_ORIGEN_INFORME", OracleDbType.Int64, opAli.PkOrigenInforme, ParameterDirection.Input);
            cmd.Parameters.Add("PK_D_COD_TIPOINFORME", OracleDbType.Int64, opAli.PkDCodInforme, ParameterDirection.Input);
            cmd.Parameters.Add("PK_COD_COMPONENTE", OracleDbType.Int64, opAli.PkCodComponente, ParameterDirection.Input);
            cmd.Parameters.Add("FECHA_APERTURA", OracleDbType.Date, opAli.FechaApertura, ParameterDirection.Input);
            cmd.BindByName = true;
            Actualizar(cmd);
        }

        public void GopiarAlimentador(DataRow row, InformeFalla informeDestino)
        {
            OperacionAlimentador opAlim = new OperacionAlimentador(row);
            opAlim.PkOrigenInforme = informeDestino.PkOrigenInforme;
            opAlim.PkDCodInforme = informeDestino.PkDCodTipoinforme;
            opAlim.EsNuevo = true;
            Guardar(opAlim);
        }

        public int CopiarAlimentadoresDeAgentes(InformeFalla informeDestino)
        {
            DataTable tabla = ModeloMgr.Instancia.InformeFallaMgr.GetInformesPorCodFalla(informeDestino.PkCodFalla);
            int contador = 0;
            foreach (DataRow r in tabla.Rows)
            {
                if (informeDestino.PkOrigenInforme != ObjetoDeNegocio.GetValor<long>(r[InformeFalla.C_PK_ORIGEN_INFORME]) &&
                    ObjetoDeNegocio.GetValor<long>(r[InformeFalla.C_PK_D_COD_TIPOINFORME]) == informeDestino.PkDCodTipoinforme)
                {
                    InformeFalla informeOrigen = new InformeFalla(r);
                    DataTable tablaAlimentadores = GetOpeAlim(informeOrigen);
                    foreach (DataRow row in tablaAlimentadores.Rows)
                    {
                        ModeloMgr.Instancia.OperacionAlimentadorMgr.GopiarAlimentador(row, informeDestino);
                        contador++;
                    }
                }
            }
            return contador;
        }

        #region IMgrLocal

        public string NombreTabla
        {
            get { return OperacionAlimentador.NOMBRE_TABLA; }
        }
        #endregion IMgrLocal

        public DataTable GetDatos(decimal versionCliente, long pkCodPersona, bool parcial)
        {
            DataTable resultado = null;
            string sql = string.Empty;
            if (parcial)
            {
                sql = @"SELECT a.*
                FROM F_GF_OP_ALIMENTADOR a
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
                FROM F_GF_OP_ALIMENTADOR a
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
            string sql = "INSERT INTO {0} ({1},{2},{3},{4},{5},{6},{7},{8},{9},{10},{11},{12})" +
                "VALUES(:{1},:{2},:{3},:{4},:{5},:{6},:{7},:{8},:{9},:{10},:{11},:{12})";
            InsertUpdate(tabla, sql);
        }


        public void Actualizar(List<DataRow> tabla)
        {
            string sql = 
            "UPDATE {0} SET " +
            "{6}=:{6} ," +
            "{7}=:{7} ," +
            "{8}=:{8} ," +
            "{9}=:{9} ," +
            "{10}=:{10},  " +
            "{11}=:{11},  " +
            "{12}=:{12}  " +
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
            
            sql = string.Format(sql, OperacionAlimentador.NOMBRE_TABLA,
            OperacionAlimentador.C_PK_COD_FALLA,
            OperacionAlimentador.C_PK_ORIGEN_INFORME,
            OperacionAlimentador.C_PK_D_COD_INFORME,
            OperacionAlimentador.C_PK_COD_COMPONENTE,
            OperacionAlimentador.C_FECHA_APERTURA,
            OperacionAlimentador.C_D_COD_TIPO_OPER_APER,
            OperacionAlimentador.C_FECHA_CIERRE,
            OperacionAlimentador.C_RELE_OPERADO,
            OperacionAlimentador.C_D_COD_TIPO_OP_CIERRE,
            OperacionAlimentador.C_POT_DESC,
            OperacionAlimentador.C_SINC_VER,
            OperacionAlimentador.C_COD_EDAC);
            cmd = CrearCommand();
            cmd.CommandText = sql;
            cmd.BindByName = true;
            cmd.ArrayBindCount = tabla.Count;
            cmd.Parameters.Add(OperacionAlimentador.C_PK_COD_FALLA, OracleDbType.Int32, GetArray(tabla, OperacionAlimentador.C_PK_COD_FALLA), System.Data.ParameterDirection.Input);
            cmd.Parameters.Add(OperacionAlimentador.C_PK_ORIGEN_INFORME, OracleDbType.Int64, GetArray(tabla, OperacionAlimentador.C_PK_ORIGEN_INFORME), System.Data.ParameterDirection.Input);
            cmd.Parameters.Add(OperacionAlimentador.C_PK_D_COD_INFORME, OracleDbType.Int64, GetArray(tabla, OperacionAlimentador.C_PK_D_COD_INFORME), System.Data.ParameterDirection.Input);
            cmd.Parameters.Add(OperacionAlimentador.C_PK_COD_COMPONENTE, OracleDbType.Int64, GetArray(tabla, OperacionAlimentador.C_PK_COD_COMPONENTE), System.Data.ParameterDirection.Input);
            cmd.Parameters.Add(OperacionAlimentador.C_FECHA_APERTURA, OracleDbType.Date, GetArray(tabla, OperacionAlimentador.C_FECHA_APERTURA), System.Data.ParameterDirection.Input);
            cmd.Parameters.Add(OperacionAlimentador.C_D_COD_TIPO_OPER_APER, OracleDbType.Decimal, GetArray(tabla, OperacionAlimentador.C_D_COD_TIPO_OPER_APER), System.Data.ParameterDirection.Input);
            cmd.Parameters.Add(OperacionAlimentador.C_FECHA_CIERRE, OracleDbType.Date, GetArray(tabla, OperacionAlimentador.C_FECHA_CIERRE), System.Data.ParameterDirection.Input);
            cmd.Parameters.Add(OperacionAlimentador.C_RELE_OPERADO, OracleDbType.Int16, GetArray(tabla, OperacionAlimentador.C_RELE_OPERADO), System.Data.ParameterDirection.Input);
            cmd.Parameters.Add(OperacionAlimentador.C_D_COD_TIPO_OP_CIERRE, OracleDbType.Decimal, GetArray(tabla, OperacionAlimentador.C_D_COD_TIPO_OP_CIERRE), System.Data.ParameterDirection.Input);
            cmd.Parameters.Add(OperacionAlimentador.C_POT_DESC, OracleDbType.Single, GetArray(tabla, OperacionAlimentador.C_POT_DESC), System.Data.ParameterDirection.Input);
            cmd.Parameters.Add(OperacionAlimentador.C_SINC_VER, OracleDbType.Int64, GetArray(tabla, OperacionAlimentador.C_SINC_VER), System.Data.ParameterDirection.Input);
            cmd.Parameters.Add(OperacionAlimentador.C_COD_EDAC, OracleDbType.Int64, GetArray(tabla, OperacionAlimentador.C_COD_EDAC), System.Data.ParameterDirection.Input);

            Actualizar(cmd);
        }

        public bool SolapaTiempos(OperacionAlimentador obj)
        {
            bool resultado = false;
            string sql =
            @"SELECT *
            FROM F_GF_OP_ALIMENTADOR
            WHERE PK_COD_FALLA         = :PK_COD_FALLA
            AND PK_ORIGEN_INFORME      = :PK_ORIGEN_INFORME
            AND RowId                  <> :Row_Id
            AND PK_D_COD_TIPOINFORME   = :PK_D_COD_TIPOINFORME
            AND PK_COD_COMPONENTE      = :PK_COD_COMPONENTE
            AND 
            (
                (FECHA_APERTURA          >= :FECHA_APERTURA
                 AND FECHA_APERTURA      <= :FECHA_CIERRE OR 
                 FECHA_CIERRE            >= :FECHA_APERTURA
                 AND FECHA_CIERRE        <= :FECHA_CIERRE
                ) 
                OR
                (:FECHA_APERTURA         >= FECHA_APERTURA
                 AND :FECHA_APERTURA     <= FECHA_CIERRE OR 
                 :FECHA_CIERRE           >= FECHA_APERTURA
                 AND :FECHA_CIERRE       <= FECHA_CIERRE
                )
            )";

            OracleCommand cmd = CrearCommand();
            cmd.CommandText = sql;
            cmd.Parameters.Add(OperacionAlimentador.C_PK_COD_FALLA, OracleDbType.Int32, obj.PkCodFalla, ParameterDirection.Input);
            cmd.Parameters.Add(OperacionAlimentador.C_PK_ORIGEN_INFORME, OracleDbType.Int64, obj.PkOrigenInforme, ParameterDirection.Input);
            cmd.Parameters.Add(OperacionAlimentador.C_PK_D_COD_INFORME, OracleDbType.Int64, obj.PkDCodInforme, ParameterDirection.Input);
            cmd.Parameters.Add(OperacionAlimentador.C_PK_COD_COMPONENTE, OracleDbType.Int64, obj.PkCodComponente, ParameterDirection.Input);
            cmd.Parameters.Add(OperacionAlimentador.C_FECHA_APERTURA, OracleDbType.Date, obj.FechaApertura, ParameterDirection.Input);
            cmd.Parameters.Add(OperacionAlimentador.C_FECHA_CIERRE, OracleDbType.Date, obj.FechaCierre, ParameterDirection.Input);
            cmd.Parameters.Add("Row_Id", OracleDbType.Varchar2, obj.RowId, ParameterDirection.Input);
            cmd.BindByName = true;

            DataTable tabla = EjecutarCmd(cmd);
            if (tabla.Rows.Count > 0)
            {
                resultado = true;
            }
            return resultado;
        }

        public void Refrescar(OperacionAlimentador opAlim, DataRow row)
        {
            string sql =
            @"SELECT A.*,A.RowId,C.DESCRIPCION_DOMINIO TIPO_APERTURA, 
            D.DESCRIPCION_DOMINIO TIPO_CIERRE, 
            B.NOMBRE_COMPONENTE Alimentador, B.DESCRIPCION_COMPONENTE, E.TIPO_EDAC, E.AJUSTE_EDAC,E.ETAPA_EDAC 
            FROM F_GF_OP_ALIMENTADOR A, F_AC_COMPONENTE B, p_def_dominios C, 
            p_def_dominios D, f_gf_param_edac E
            WHERE a.pk_cod_componente=B.PK_COD_COMPONENTE AND 
            A.D_COD_TIPO_OPER_APER=C.COD_DOMINIO AND 
            A.D_COD_TIPO_OP_CIERRE=D.COD_DOMINIO AND 
            A.COD_EDAC = E.PK_COD_EDAC (+)             
            AND A.PK_COD_FALLA=:PK_COD_FALLA 
            AND A.PK_ORIGEN_INFORME=:PK_ORIGEN_INFORME
            AND A.PK_D_COD_TIPOINFORME=:PK_D_COD_TIPOINFORME 
            AND A.PK_COD_COMPONENTE=:PK_COD_COMPONENTE
            AND A.FECHA_APERTURA=:FECHA_APERTURA";

            OracleCommand cmd = CrearCommand();
            cmd.CommandText = sql;
            cmd.BindByName = true;
            cmd.Parameters.Add(OperacionAlimentador.C_PK_COD_FALLA, OracleDbType.Int32, opAlim.PkCodFalla, ParameterDirection.Input);
            cmd.Parameters.Add(OperacionAlimentador.C_PK_ORIGEN_INFORME, OracleDbType.Int64, opAlim.PkOrigenInforme, ParameterDirection.Input);
            cmd.Parameters.Add(OperacionAlimentador.C_PK_D_COD_INFORME, OracleDbType.Int64, opAlim.PkDCodInforme, ParameterDirection.Input);
            cmd.Parameters.Add(OperacionAlimentador.C_PK_COD_COMPONENTE, OracleDbType.Int64, opAlim.PkCodComponente, ParameterDirection.Input);
            cmd.Parameters.Add(OperacionAlimentador.C_FECHA_APERTURA, OracleDbType.TimeStamp, opAlim.FechaApertura, ParameterDirection.Input);
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