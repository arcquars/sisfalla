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
    public class OraDalOperacionInterruptoresMgr : OraDalBaseMgr, IOperacionInterruptoresMgr, IMgrLocal, IProveedorDatosSincronizacion
    {
        public OraDalOperacionInterruptoresMgr()
        {

        }
        public OraDalOperacionInterruptoresMgr(ConnexionOracleMgr c)
            : base(c)
        { }

        public void Guardar(OperacionInterruptores obj)
        {
            OracleCommand cmd = null;
            string sql = string.Empty;
            if (obj.EsNuevo)
            {
                //Pista p = PistaMgr.Instance.Info("DALSisFalla", obj.GetEstadoString());
                //obj.SecLog = (long)p.PK_SecLog;
                sql = "INSERT INTO {0} ({1},{2},{3},{4},{5},{6},{7},{8},{9},{10})" +
                "VALUES(:{1},:{2},:{3},:{4},:{5},:{6},:{7},:{8},:{9},:{10})";
            }
            else
            {
                sql = "UPDATE {0} SET " +
                "{6}=:{6} ," +
                "{7}=:{7} ," +
                "{8}=:{8} ," +
                "{9}=:{9}, " +
                "{10}=:{10} " +
                "WHERE " +
                "{1}=:{1} AND " +
                "{2}=:{2} AND " +
                "{3}=:{3} AND " +
                "{4}=:{4} AND " +
                "{5}=:{5} ";
            }

            sql = string.Format(sql, OperacionInterruptores.NOMBRE_TABLA,
            OperacionInterruptores.C_PK_COD_FALLA,
            OperacionInterruptores.C_PK_ORIGEN_INFORME,
            OperacionInterruptores.C_PK_D_COD_INFORME,
            OperacionInterruptores.C_PK_COD_COMPONENTE,
            OperacionInterruptores.C_FECHA_APERTURA,
            OperacionInterruptores.C_PK_D_COD_TIPO_OPER_APER,
            OperacionInterruptores.C_FECHA_CIERRE,
            OperacionInterruptores.C_PK_D_COD_TIPO_OPER_CIERRE,
            OperacionInterruptores.C_RECONECTADO,
            OperacionInterruptores.C_SINC_VER);
            cmd = CrearCommand();
            cmd.CommandText = sql;
            cmd.BindByName = true;
            cmd.Parameters.Add(OperacionInterruptores.C_PK_COD_FALLA, OracleDbType.Int64, obj.PkCodFalla, System.Data.ParameterDirection.Input);
            cmd.Parameters.Add(OperacionInterruptores.C_PK_ORIGEN_INFORME, OracleDbType.Int64, obj.PkOrigenInforme, System.Data.ParameterDirection.Input);
            cmd.Parameters.Add(OperacionInterruptores.C_PK_D_COD_INFORME, OracleDbType.Int64, obj.PkDCodInforme, System.Data.ParameterDirection.Input);
            cmd.Parameters.Add(OperacionInterruptores.C_PK_COD_COMPONENTE, OracleDbType.Decimal, obj.PkCodComponente, System.Data.ParameterDirection.Input);
            cmd.Parameters.Add(OperacionInterruptores.C_FECHA_APERTURA, OracleDbType.TimeStamp, obj.FechaApertura, System.Data.ParameterDirection.Input);
            cmd.Parameters.Add(OperacionInterruptores.C_PK_D_COD_TIPO_OPER_APER, OracleDbType.Int64, obj.PkDCodTipoOperAper, System.Data.ParameterDirection.Input);
            cmd.Parameters.Add(OperacionInterruptores.C_FECHA_CIERRE, OracleDbType.TimeStamp, obj.FechaCierre, System.Data.ParameterDirection.Input);
            cmd.Parameters.Add(OperacionInterruptores.C_PK_D_COD_TIPO_OPER_CIERRE, OracleDbType.Int64, obj.PkDCodTipoOperCierre, System.Data.ParameterDirection.Input);
            cmd.Parameters.Add(OperacionInterruptores.C_RECONECTADO, OracleDbType.Int16, obj.Reconectado, System.Data.ParameterDirection.Input);
            cmd.Parameters.Add(OperacionInterruptores.C_SINC_VER, OracleDbType.Int64, obj.SincVer, System.Data.ParameterDirection.Input);

            if (Actualizar(cmd))
            {
                obj.EsNuevo = false;
            }
        }

        public DataTable GetTabla()
        {
            DataTable tabla = GetTabla(OperacionInterruptores.NOMBRE_TABLA);
            return tabla;
        }

        public BindingList<OperacionInterruptores> GetLista()
        {
            BindingList<OperacionInterruptores> resultado = new BindingList<OperacionInterruptores>();
            DataTable tablaAgentes = GetTabla();
            foreach (DataRow row in tablaAgentes.Rows)
            {
                resultado.Add(new OperacionInterruptores(row));
            }
            return resultado;
        }

        public DataTable GetInterruptores(InformeFalla informe)
        {
            string sql =
            @"SELECT A.*,A.RowId,
            B.DESCRIPCION_DOMINIO TIPO_APERTURA,C.DESCRIPCION_DOMINIO TIPO_CIERRE,
            D.NOMBRE_COMPONENTE, D.Descripcion_componente 
            FROM 
            F_GF_OP_INTERRUPTOR A ,p_def_dominios B , p_def_dominios C,F_AC_COMPONENTE D 
            WHERE 
            A.PK_D_COD_TIPO_OPER_APER = b.cod_dominio 
            AND A.PK_D_COD_TIPO_OPER_CIERRE =C.cod_dominio 
            AND B.d_cod_tipo='D_COD_TIPO_OPERACION' 
            AND C.d_cod_tipo='D_COD_TIPO_OPERACION' AND 
            A.pk_cod_componente=D.PK_COD_COMPONENTE AND 
            A.PK_COD_FALLA=:PK_COD_FALLA AND 
            A.PK_ORIGEN_INFORME=:PK_ORIGEN_INFORME AND 
            A.PK_D_COD_TIPOINFORME=:PK_D_COD_TIPOINFORME";
           
            OracleCommand cmd = CrearCommand();
            cmd.CommandText = sql;
            cmd.Parameters.Add("PK_COD_FALLA", OracleDbType.Int64, informe.PkCodFalla, ParameterDirection.Input);
            cmd.Parameters.Add("PK_ORIGEN_INFORME", OracleDbType.Int64, informe.PkOrigenInforme, ParameterDirection.Input);
            cmd.Parameters.Add("PK_D_COD_TIPOINFORME", OracleDbType.Int64, informe.PkDCodTipoinforme, ParameterDirection.Input);
            cmd.BindByName = true;
            DataTable resultado = EjecutarCmd(cmd);

            return resultado;
        }

        public void Borrar(OperacionInterruptores interruptor)
        {
            string sql = 
            @"DELETE FROM F_GF_OP_INTERRUPTOR
            WHERE 
            PK_COD_FALLA = :PK_COD_FALLA 
            AND PK_ORIGEN_INFORME = :PK_ORIGEN_INFORME 
            AND PK_D_COD_TIPOINFORME = :PK_D_COD_TIPOINFORME 
            AND PK_COD_COMPONENTE = :PK_COD_COMPONENTE
            AND FECHA_APERTURA = :FECHA_APERTURA";
            OracleCommand cmd = CrearCommand();
            cmd.CommandText = sql;
            cmd.Parameters.Add("PK_COD_FALLA", OracleDbType.Int32, interruptor.PkCodFalla, ParameterDirection.Input);
            cmd.Parameters.Add("PK_ORIGEN_INFORME", OracleDbType.Int64, interruptor.PkOrigenInforme, ParameterDirection.Input);
            cmd.Parameters.Add("PK_D_COD_TIPOINFORME", OracleDbType.Int64, interruptor.PkDCodInforme, ParameterDirection.Input);
            cmd.Parameters.Add("PK_COD_COMPONENTE", OracleDbType.Int64, interruptor.PkCodComponente, ParameterDirection.Input);
            cmd.Parameters.Add("FECHA_APERTURA", OracleDbType.TimeStamp, interruptor.FechaApertura, ParameterDirection.Input);
            cmd.BindByName = true;

            Actualizar(cmd);
        }

        public void Copiar(DataRow row, InformeFalla informeDestino)
        {
            OperacionInterruptores opInterrup = new OperacionInterruptores(row);
            opInterrup.PkOrigenInforme = informeDestino.PkOrigenInforme;
            opInterrup.PkDCodInforme = informeDestino.PkDCodTipoinforme;
            opInterrup.EsNuevo = true;
            Guardar(opInterrup);
            CopiarReles(new OperacionInterruptores(row), informeDestino);
        }

        private void CopiarReles(OperacionInterruptores opInterrup, InformeFalla informeDestino)
        {
            DataTable tablaReles = ModeloMgr.Instancia.RelesOperadosMgr.GetTablaRelesOperador(opInterrup);
            foreach (DataRow row in tablaReles.Rows)
            {
                RelesOperados rele = new RelesOperados(row);
                rele.PkOrigenFalla = informeDestino.PkOrigenInforme;
                rele.PkDCodTipoinforme = informeDestino.PkDCodTipoinforme;
                rele.EsNuevo = true;
                ModeloMgr.Instancia.RelesOperadosMgr.Guardar(rele);
            }
        }

        public int CopiarInterruptoresDeAgentes(InformeFalla informeDestino)
        {
            DataTable tabla = ModeloMgr.Instancia.InformeFallaMgr.GetInformesPorCodFalla(informeDestino.PkCodFalla);
            int contador = 0;

            foreach (DataRow r in tabla.Rows)
            {
                if (informeDestino.PkOrigenInforme != ObjetoDeNegocio.GetValor<long>(r[InformeFalla.C_PK_ORIGEN_INFORME]) &&
                    ObjetoDeNegocio.GetValor<long>(r[InformeFalla.C_PK_D_COD_TIPOINFORME]) == informeDestino.PkDCodTipoinforme)
                {
                    InformeFalla informeOrigen = new InformeFalla(r);
                    DataTable tablaAlimentadores = ModeloMgr.Instancia.OperacionInterruptoresMgr.GetInterruptores(informeOrigen);
                    foreach (DataRow row in tablaAlimentadores.Rows)
                    {
                        ModeloMgr.Instancia.OperacionInterruptoresMgr.Copiar(row, informeDestino);
                        contador++;
                    }
                }
            }

            return contador;
        }

        #region IMgrLocal

        public string NombreTabla
        {
            get { return OperacionInterruptores.NOMBRE_TABLA; }
        }
        #endregion IMgrLocal

        public DataTable GetDatos(decimal versionCliente, long pkCodPersona, bool parcial)
        {
            DataTable resultado = null;
            string sql = string.Empty;
            if (parcial)
            {
                sql = @"SELECT a.*
                FROM F_GF_OP_INTERRUPTOR a
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
                FROM F_GF_OP_INTERRUPTOR a
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
            "INSERT INTO {0} ({1},{2},{3},{4},{5},{6},{7},{8},{9},{10})" +
            "VALUES(:{1},:{2},:{3},:{4},:{5},:{6},:{7},:{8},:{9},:{10})";
            InsertUpdate(tabla, sql);
        }

        public void Actualizar(List<DataRow> tabla)
        {
            string sql = 
            "UPDATE {0} SET " +
            "{6}=:{6} ," +
            "{7}=:{7} ," +
            "{8}=:{8} ," +
            "{9}=:{9}, " +
            "{10}=:{10} " +
            "WHERE " +
            "{1}=:{1} AND " +
            "{2}=:{2} AND " +
            "{3}=:{3} AND " +
            "{4}=:{4} AND " +
            "{5}=:{5} ";
            InsertUpdate(tabla, sql);
        }

        void InsertUpdate(List<DataRow> tabla, string sql)
        {
            OracleCommand cmd = null;

            sql = string.Format(sql, OperacionInterruptores.NOMBRE_TABLA,
            OperacionInterruptores.C_PK_COD_FALLA,
            OperacionInterruptores.C_PK_ORIGEN_INFORME,
            OperacionInterruptores.C_PK_D_COD_INFORME,
            OperacionInterruptores.C_PK_COD_COMPONENTE,
            OperacionInterruptores.C_FECHA_APERTURA,
            OperacionInterruptores.C_PK_D_COD_TIPO_OPER_APER,
            OperacionInterruptores.C_FECHA_CIERRE,
            OperacionInterruptores.C_PK_D_COD_TIPO_OPER_CIERRE,
            OperacionInterruptores.C_RECONECTADO,
            OperacionInterruptores.C_SINC_VER);
            cmd = CrearCommand();
            cmd.CommandText = sql;
            cmd.BindByName = true;
            cmd.ArrayBindCount = tabla.Count;
            cmd.Parameters.Add(OperacionInterruptores.C_PK_COD_FALLA, OracleDbType.Int64, GetArray(tabla, OperacionInterruptores.C_PK_COD_FALLA), System.Data.ParameterDirection.Input);
            cmd.Parameters.Add(OperacionInterruptores.C_PK_ORIGEN_INFORME, OracleDbType.Int64, GetArray(tabla, OperacionInterruptores.C_PK_ORIGEN_INFORME), System.Data.ParameterDirection.Input);
            cmd.Parameters.Add(OperacionInterruptores.C_PK_D_COD_INFORME, OracleDbType.Int64, GetArray(tabla, OperacionInterruptores.C_PK_D_COD_INFORME), System.Data.ParameterDirection.Input);
            cmd.Parameters.Add(OperacionInterruptores.C_PK_COD_COMPONENTE, OracleDbType.Decimal, GetArray(tabla, OperacionInterruptores.C_PK_COD_COMPONENTE), System.Data.ParameterDirection.Input);
            cmd.Parameters.Add(OperacionInterruptores.C_FECHA_APERTURA, OracleDbType.TimeStamp, GetArray(tabla, OperacionInterruptores.C_FECHA_APERTURA), System.Data.ParameterDirection.Input);
            cmd.Parameters.Add(OperacionInterruptores.C_PK_D_COD_TIPO_OPER_APER, OracleDbType.Int64, GetArray(tabla, OperacionInterruptores.C_PK_D_COD_TIPO_OPER_APER), System.Data.ParameterDirection.Input);
            cmd.Parameters.Add(OperacionInterruptores.C_FECHA_CIERRE, OracleDbType.TimeStamp, GetArray(tabla, OperacionInterruptores.C_FECHA_CIERRE), System.Data.ParameterDirection.Input);
            cmd.Parameters.Add(OperacionInterruptores.C_PK_D_COD_TIPO_OPER_CIERRE, OracleDbType.Int64, GetArray(tabla, OperacionInterruptores.C_PK_D_COD_TIPO_OPER_CIERRE), System.Data.ParameterDirection.Input);
            cmd.Parameters.Add(OperacionInterruptores.C_RECONECTADO, OracleDbType.Int16, GetArray(tabla, OperacionInterruptores.C_RECONECTADO), System.Data.ParameterDirection.Input);
            cmd.Parameters.Add(OperacionInterruptores.C_SINC_VER, OracleDbType.Int64, GetArray(tabla, OperacionInterruptores.C_SINC_VER), System.Data.ParameterDirection.Input);

            Actualizar(cmd);
        }

        public bool SolapaTiempos(OperacionInterruptores obj)
        {
            bool resultado = false;
            string sql =
            @"SELECT *
            FROM F_GF_OP_INTERRUPTOR
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
            cmd.Parameters.Add(OperacionInterruptores.C_PK_COD_FALLA, OracleDbType.Int32, obj.PkCodFalla, ParameterDirection.Input);
            cmd.Parameters.Add(OperacionInterruptores.C_PK_ORIGEN_INFORME, OracleDbType.Int64, obj.PkOrigenInforme, ParameterDirection.Input);
            cmd.Parameters.Add(OperacionInterruptores.C_PK_D_COD_INFORME, OracleDbType.Int64, obj.PkDCodInforme, ParameterDirection.Input);
            cmd.Parameters.Add(OperacionInterruptores.C_PK_COD_COMPONENTE, OracleDbType.Int64, obj.PkCodComponente, ParameterDirection.Input);
            cmd.Parameters.Add(OperacionInterruptores.C_FECHA_APERTURA, OracleDbType.TimeStamp, obj.FechaApertura, ParameterDirection.Input);
            cmd.Parameters.Add(OperacionInterruptores.C_FECHA_CIERRE, OracleDbType.TimeStamp, obj.FechaCierre, ParameterDirection.Input);
            cmd.Parameters.Add("Row_Id", OracleDbType.Varchar2, obj.RowId, ParameterDirection.Input);
            cmd.BindByName = true;

            DataTable tabla = EjecutarCmd(cmd);
            if (tabla.Rows.Count > 0)
            {
                resultado = true;
            }
            return resultado;
        }

        public void Refrescar(OperacionInterruptores interruptor, DataRow row)
        {
            string sql =
             @"SELECT A.*,A.RowId,
            B.DESCRIPCION_DOMINIO TIPO_APERTURA,C.DESCRIPCION_DOMINIO TIPO_CIERRE,
            D.NOMBRE_COMPONENTE, D.Descripcion_componente 
            FROM 
            F_GF_OP_INTERRUPTOR A ,p_def_dominios B , p_def_dominios C,F_AC_COMPONENTE D 
            WHERE 
            A.PK_D_COD_TIPO_OPER_APER = b.cod_dominio 
            AND A.PK_D_COD_TIPO_OPER_CIERRE =C.cod_dominio 
            AND B.d_cod_tipo='D_COD_TIPO_OPERACION' 
            AND C.d_cod_tipo='D_COD_TIPO_OPERACION'  
            AND A.pk_cod_componente=D.PK_COD_COMPONENTE  
            AND A.PK_COD_FALLA=:PK_COD_FALLA 
            AND A.PK_ORIGEN_INFORME=:PK_ORIGEN_INFORME
            AND A.PK_D_COD_TIPOINFORME=:PK_D_COD_TIPOINFORME 
            AND A.PK_COD_COMPONENTE=:PK_COD_COMPONENTE
            AND A.FECHA_APERTURA=:FECHA_APERTURA";

            OracleCommand cmd = CrearCommand();
            cmd.CommandText = sql;
            cmd.BindByName = true;
            cmd.Parameters.Add(OperacionInterruptores.C_PK_COD_FALLA, OracleDbType.Int32, interruptor.PkCodFalla, ParameterDirection.Input);
            cmd.Parameters.Add(OperacionInterruptores.C_PK_ORIGEN_INFORME, OracleDbType.Int64, interruptor.PkOrigenInforme, ParameterDirection.Input);
            cmd.Parameters.Add(OperacionInterruptores.C_PK_D_COD_INFORME, OracleDbType.Int64, interruptor.PkDCodInforme, ParameterDirection.Input);
            cmd.Parameters.Add(OperacionInterruptores.C_PK_COD_COMPONENTE, OracleDbType.Int64, interruptor.PkCodComponente, ParameterDirection.Input);
            cmd.Parameters.Add(OperacionInterruptores.C_FECHA_APERTURA, OracleDbType.TimeStamp, interruptor.FechaApertura, ParameterDirection.Input);
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