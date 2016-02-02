using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.ComponentModel;
using CNDC.DAL;
using ModeloSisFalla;
using Oracle.DataAccess.Client;
using CNDC.Pistas;
using CNDC.Sincronizacion;
using CNDC.BLL;
using BLL;
using CNDC.Dominios;

namespace OraDalSisFalla
{
    public class OraDalInformeFallaMgr : OraDalBaseMgr, IInformeFallaMgr, IMgrLocal, IProveedorDatosSincronizacion
    {
        public int DeltaTiempoIngresoComponentesMinutos{get;set;}
        public OraDalInformeFallaMgr()
        {
            DeltaTiempoIngresoComponentesMinutos = GetDeltaTiempoIngresoElementos();
        }
        public OraDalInformeFallaMgr(ConnexionOracleMgr c)
            : base(c)
        { }

        public void Guardar(InformeFalla i)
        {
            PistaMgr.Instance.Debug("OraDalSisFalla", "Guardando Informe Falla " + i.PkCodFalla);
            OracleCommand cmd = null;
            string sql = string.Empty;
            if (i.EsNuevo)
            {
                Pista p = PistaMgr.Instance.Info("DALSisFalla", string.Format("PkCodFalla={0},PkOrigenInforme={1},PkDCodTipoinforme={2} ", i.PkCodFalla, i.PkOrigenInforme, i.PkDCodTipoinforme));
                i.SecLog = (long)p.PK_SecLog;

                sql = "insert into {0} ({1},{2},{3},{4},{5},{6},{7},{8},{9},{10},{11},{12},{13},{14},{15},{16},{17},{18},{19},{20},{21})" +
                    " values (:{1},:{2},:{3},:{4},:{5},:{6},:{7},:{8},:{9},:{10},:{11},:{12},:{13},:{14},:{15},:{16},:{17},:{18},:{19},:{20},:{21})";
            }
            else
            {
                sql = "update {0} set " +
                    "{4}=:{4}, " +
                    "{5}=:{5}, " +
                    "{6}=:{6}, " +
                    "{7}=:{7}, " +
                    "{8}=:{8}, " +
                    "{9}=:{9}, " +
                    "{10}=:{10}, " +
                    "{11}=:{11}, " +
                    "{12}=:{12}, " +
                    "{13}=:{13}, " +
                    "{14}=:{14}, " +
                    "{15}=:{15}, " +
                    "{16}=:{16}, " +
                    "{17}=:{17}, " +
                    "{18}=:{18}, " +
                    "{19}=:{19}, " +
                    "{20}=:{20}, " +
                    "{21}=:{21} " +
                    "where {1}=:{1} AND {2}=:{2} AND {3}=:{3}";
            }

            sql = string.Format(sql,
                    InformeFalla.NOMBRE_TABLA,
                    InformeFalla.C_PK_COD_FALLA,
                    InformeFalla.C_PK_ORIGEN_INFORME,
                    InformeFalla.C_PK_D_COD_TIPOINFORME,
                    InformeFalla.C_FEC_INICIO,
                    InformeFalla.C_FEC_FINAL,
                    InformeFalla.C_DESCRIPCION,
                    InformeFalla.C_RESTITUCION,
                    InformeFalla.C_INFORMACION_ADICIONAL,
                    InformeFalla.C_D_COD_ESTADO,
                    InformeFalla.C_SEC_LOG,
                    InformeFalla.C_D_COD_ORIGEN,
                    InformeFalla.C_OPERACION_PROTECCIONES,
                    InformeFalla.C_D_COD_TIPO_DESCONEXION,
                    InformeFalla.C_D_COD_CAUSA,
                    InformeFalla.C_COD_PERSONA,
                    InformeFalla.C_COD_ESTADO_INF,
                    InformeFalla.C_SINC_VER,
                    InformeFalla.C_NUM_FALLA_AGENTE,
                    InformeFalla.C_COD_COMPONENTE_FALLADO,
                    InformeFalla.C_FEC_REGISTRO,
                    InformeFalla.C_ELABORADO_POR
                    );

            cmd = CrearCommand();
            cmd.CommandText = sql;
            cmd.Parameters.Add(InformeFalla.C_PK_COD_FALLA, OracleDbType.Int32, i.PkCodFalla, ParameterDirection.Input);
            cmd.Parameters.Add(InformeFalla.C_PK_ORIGEN_INFORME, OracleDbType.Int64, i.PkOrigenInforme, ParameterDirection.Input);
            cmd.Parameters.Add(InformeFalla.C_PK_D_COD_TIPOINFORME, OracleDbType.Int64, i.PkDCodTipoinforme, ParameterDirection.Input);
            cmd.Parameters.Add(InformeFalla.C_FEC_INICIO, OracleDbType.Date, i.FecInicio, ParameterDirection.Input);
            cmd.Parameters.Add(InformeFalla.C_FEC_FINAL, OracleDbType.Date, i.FecFinal, ParameterDirection.Input);
            cmd.Parameters.Add(InformeFalla.C_DESCRIPCION, OracleDbType.Varchar2, i.Descripcion, ParameterDirection.Input);
            cmd.Parameters.Add(InformeFalla.C_RESTITUCION, OracleDbType.Varchar2, i.ProcRestitucion, ParameterDirection.Input);
            cmd.Parameters.Add(InformeFalla.C_INFORMACION_ADICIONAL, OracleDbType.Varchar2, i.InformacionAdicional, ParameterDirection.Input);
            cmd.Parameters.Add(InformeFalla.C_D_COD_ESTADO, OracleDbType.Varchar2, i.DCodEstado, ParameterDirection.Input);
            cmd.Parameters.Add(InformeFalla.C_SEC_LOG, OracleDbType.Int64, i.SecLog, ParameterDirection.Input);
            cmd.Parameters.Add(InformeFalla.C_D_COD_ORIGEN, OracleDbType.Int64, i.DCodOrigen, ParameterDirection.Input);
            cmd.Parameters.Add(InformeFalla.C_OPERACION_PROTECCIONES, OracleDbType.Varchar2, i.OperacionProtecciones, ParameterDirection.Input);
            cmd.Parameters.Add(InformeFalla.C_D_COD_TIPO_DESCONEXION, OracleDbType.Int64, i.DCodTipoDesconexion, ParameterDirection.Input);
            cmd.Parameters.Add(InformeFalla.C_D_COD_CAUSA, OracleDbType.Int64, i.DCodCausa, ParameterDirection.Input);
            cmd.Parameters.Add(InformeFalla.C_COD_PERSONA, OracleDbType.Int64, i.CodPersona, ParameterDirection.Input);
            cmd.Parameters.Add(InformeFalla.C_COD_ESTADO_INF, OracleDbType.Int64, i.CodEstadoInf, ParameterDirection.Input);
            cmd.Parameters.Add(InformeFalla.C_SINC_VER, OracleDbType.Int64, i.SincVer, ParameterDirection.Input);
            cmd.Parameters.Add(InformeFalla.C_NUM_FALLA_AGENTE, OracleDbType.Varchar2, i.NumFallaAgente, ParameterDirection.Input);
            cmd.Parameters.Add(InformeFalla.C_COD_COMPONENTE_FALLADO, OracleDbType.Int64, i.CodComponenteFallado, ParameterDirection.Input);
            cmd.Parameters.Add(InformeFalla.C_FEC_REGISTRO, OracleDbType.Date, GetValor(i.FecRegistro), ParameterDirection.Input);
            cmd.Parameters.Add(InformeFalla.C_ELABORADO_POR, OracleDbType.Varchar2, i.ElaboradoPor, ParameterDirection.Input);
            cmd.BindByName = true;

            if (Actualizar(cmd))
            {
                i.EsNuevo = false;
            }
        }

        private object GetValor(DateTime dateTime)
        {
            if (dateTime.Ticks == 0)
            {
                return null;
            }
            return dateTime;
        }

        public DataTable GetTabla()
        {
            DataTable tabla = GetTabla("F_GF_INFORMEFALLA");
            return tabla;
        }

        public bool ModificarSupervisorInforme(InformeFalla i, Persona p)
        {
            bool rtn = true;
            PistaMgr.Instance.Debug("OraDalSisFalla", "Modificar Supervisor Informe Falla " + i.PkCodFalla);
            OracleCommand cmd = null;
            string sql = @"
                        UPDATE f_gf_informefalla
                        SET cod_persona          = :cod_persona ,
                          elaborado_por          = :elaborado_por
                        WHERE pk_cod_falla       = :pk_cod_falla
                        AND pk_origen_informe    = :pk_origen_informe
                        AND pk_d_cod_tipoinforme = :pk_d_cod_tipoinforme ";
            cmd = CrearCommand();
            cmd.CommandText = sql;
            cmd.Parameters.Add(InformeFalla.C_COD_PERSONA, OracleDbType.Int64, p.PkCodPersona, ParameterDirection.Input);
            cmd.Parameters.Add(InformeFalla.C_ELABORADO_POR, OracleDbType.Varchar2, p.Nombre, ParameterDirection.Input);
            cmd.Parameters.Add(InformeFalla.C_PK_COD_FALLA, OracleDbType.Int32, i.PkCodFalla, ParameterDirection.Input);
            cmd.Parameters.Add(InformeFalla.C_PK_ORIGEN_INFORME, OracleDbType.Int64, i.PkOrigenInforme, ParameterDirection.Input);
            cmd.Parameters.Add(InformeFalla.C_PK_D_COD_TIPOINFORME, OracleDbType.Int64, i.PkDCodTipoinforme, ParameterDirection.Input);
            rtn = Actualizar(cmd);
            return rtn;
        }

        public BindingList<InformeFalla> GetLista()
        {
            BindingList<InformeFalla> resultado = new BindingList<InformeFalla>();
            DataTable tablaAgentes = GetTabla();
            foreach (DataRow row in tablaAgentes.Rows)
            {
                resultado.Add(new InformeFalla(row));
            }
            return resultado;
        }

        public InformeFalla GetInforme(int codFalla, long origen, long tipo)
        {
            InformeFalla resultado = null;
            
            DataRow row = GetDataRowInforme(codFalla, origen, tipo);
            if (row != null)
            {
                resultado = new InformeFalla(row);
            }
         
            return resultado;
        }

        public int GetDeltaTiempoIngresoElementos()
        {
            int resultado = 0;
            OracleCommand cmd = CrearCommand();
            cmd.CommandText =
            @"select val_number  from p_gf_parametros
            where 
            MODULO ='SISFALLA'
            AND tag ='DELTA_TIEMPO'";
            try
            {
                resultado = (int)(decimal)cmd.ExecuteScalar();
            }
            catch (Exception ex)
            {
                resultado = 60;
            }

            return resultado;


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

   
        public DataTable GetInformesPorCodFalla(int codFalla)
        {
            DataTable resultado = null;
            OracleCommand cmd = CrearCommand();
            cmd.CommandText =
            @"SELECT a.*, c.sigla as Origen, b.descripcion_dominio as Tipo_Informe  
            FROM F_GF_INFORMEFALLA a, p_def_dominios b, f_ap_persona c 
            WHERE a.pk_cod_falla=:pk_cod_falla
            and a.pk_origen_informe=c.pk_cod_persona 
            and a.pk_d_cod_tipoinforme=b.cod_dominio";

            cmd.Parameters.Add(InformeFalla.C_PK_COD_FALLA, OracleDbType.Int32, codFalla, System.Data.ParameterDirection.Input);
            resultado = EjecutarCmd(cmd);

            return resultado;
        }


        #region IMgrLocal

        public string NombreTabla
        {
            get { return InformeFalla.NOMBRE_TABLA; }
        }
        #endregion IMgrLocal

        #region IProveedorDatosSincronizacion
        public DataTable GetDatos(decimal versionCliente, long pkCodPersona, bool parcial)
        {
            DataTable resultado = null;
            string sql = string.Empty;
            if (parcial)
            {
                sql = @"SELECT a.*
                FROM f_gf_informefalla a
                WHERE a.sinc_ver > :sinc_ver 
                AND (a.d_cod_estado_inf = 3594 OR a.pk_origen_informe=:pk_cod_persona)             
                AND a.pk_cod_falla IN 
                (SELECT b.pk_cod_falla
                FROM f_gf_notificacion b
                WHERE b.pk_cod_persona=:pk_cod_persona AND b.d_cod_estado_notificacion <> 41)";
            }
            else
            {
                sql = @"SELECT a.*
                FROM f_gf_informefalla a
                WHERE a.sinc_ver > :sinc_ver 
                AND (a.d_cod_estado_inf = 3594 OR a.pk_origen_informe=:pk_cod_persona) ";
            }
            OracleCommand cmd = CrearCommand();
            cmd.CommandText = sql;
            cmd.Parameters.Add("sinc_ver", OracleDbType.Decimal, versionCliente, System.Data.ParameterDirection.Input);
            cmd.Parameters.Add("pk_cod_persona", OracleDbType.Int64, pkCodPersona, System.Data.ParameterDirection.Input);
            cmd.BindByName = true;

            resultado = EjecutarCmd(cmd);
            PistaMgr.Instance.Debug("OraDalInformeFalla.GetDatos()", string.Format("Retornando {0} Registros", resultado.Rows.Count));
            return resultado;
        }
        #endregion IMgrLocal

        public DataTable GetDatos(string nombreTabla,int pkCodFalla, long pkDCodTipoinforme, long pkOrigenInforme)
        {
            DataTable resulado = null;
            string sql =
            @"SELECT *
            FROM {0} 
            WHERE PK_COD_FALLA=:PK_COD_FALLA
            AND PK_D_COD_TIPOINFORME=:PK_D_COD_TIPOINFORME
            AND PK_ORIGEN_INFORME=:PK_ORIGEN_INFORME";
           
            sql = string.Format(sql, nombreTabla);

            OracleCommand cmd = CrearCommand();
            cmd.CommandText = sql;
            cmd.Parameters.Add("PK_COD_FALLA", OracleDbType.Int32, pkCodFalla, ParameterDirection.Input);
            cmd.Parameters.Add("PK_D_COD_TIPOINFORME", OracleDbType.Int64, pkDCodTipoinforme, ParameterDirection.Input);
            cmd.Parameters.Add("PK_ORIGEN_INFORME", OracleDbType.Int64, pkOrigenInforme, ParameterDirection.Input);
            cmd.BindByName = true;
            resulado = EjecutarCmd(cmd);
            resulado.TableName = nombreTabla;

            return resulado;
        }

        public void PonerFechaHora(InformeFalla infFalla)
        {
            if (Sesion.Instancia.FechaHoraServidor == null)
            {
                DateTime? fechaHora = Sesion.Instancia.Conexion.GetFechaHora();
                infFalla.FecRegistro = fechaHora == null ? DateTime.Now : fechaHora.Value;
            }
            else
            {
                infFalla.FecRegistro = Sesion.Instancia.FechaHoraServidor.Value;
            }
            /*string sql =
            @"update f_gf_informeFalla
            Set FECHA_REGISTRO=GetDate 
            where pk_cod_falla=:pk_cod_falla
            and pk_origen_informe=:pk_origen_informe
            and pk_d_cod_tipoinforme=:pk_d_cod_tipoinforme";
            OracleCommand cmd = CrearCommand();
            cmd.CommandText = sql;
            cmd.Parameters.Add("pk_cod_falla", OracleDbType.Int32, infFalla.PkCodFalla, System.Data.ParameterDirection.Input);
            cmd.Parameters.Add("pk_origen_informe", OracleDbType.Int64, infFalla.PkOrigenInforme, System.Data.ParameterDirection.Input);
            cmd.Parameters.Add("pk_d_cod_tipoinforme", OracleDbType.Int64, infFalla.PkDCodTipoinforme, System.Data.ParameterDirection.Input);
            cmd.BindByName = true;
            Actualizar(cmd);*/
        }

        public ResultadoCopiaInforme CopiarInforme(int codFallaA, long origenA, long tipoA, int codFallaB, long origenB, long tipoB)
        {
            ResultadoCopiaInforme resultado = ResultadoCopiaInforme.OK;

            OracleCommand cmd = CrearCommand();
            cmd.CommandText = "f_gf_copiar_informe";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("p_cod_falla", OracleDbType.Int32, codFallaA, ParameterDirection.Input);
            cmd.Parameters.Add("p_origen_informe", OracleDbType.Int64, origenA, ParameterDirection.Input);
            cmd.Parameters.Add("d_cod_tipo_informe", OracleDbType.Int64, tipoA, ParameterDirection.Input);
            cmd.Parameters.Add("p_cod_falla_destino", OracleDbType.Int32, codFallaB, ParameterDirection.Input);
            cmd.Parameters.Add("p_destino_informe", OracleDbType.Int64, origenB, ParameterDirection.Input);
            cmd.Parameters.Add("d_cod_tipo_informe_destino", OracleDbType.Int64, tipoB, ParameterDirection.Input);

            cmd.Parameters.Add("RETURN", OracleDbType.Decimal).Direction = ParameterDirection.ReturnValue;
            cmd.BindByName = true;
            try
            {
                cmd.ExecuteNonQuery();
                decimal res = ((Oracle.DataAccess.Types.OracleDecimal)(cmd.Parameters["RETURN"].Value)).Value;
                resultado = (ResultadoCopiaInforme)(int)res;
            }
            catch (Exception ex)
            {
                resultado = ResultadoCopiaInforme.Error;
                PistaMgr.Instance.Error("OraDalSisFalla", ex);
            }
            return resultado;
        }

        public ResultadoCopiaInforme CopiarInformeIndividual(int codFallaA, long origenA, long tipoA, int codFallaB, long origenB, long tipoB)
        {
            ResultadoCopiaInforme resultado = ResultadoCopiaInforme.OK;

            OracleCommand cmd = CrearCommand();
            cmd.CommandText = "f_gf_copiar_inf_agente";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("p_cod_falla", OracleDbType.Int32, codFallaA, ParameterDirection.Input);
            cmd.Parameters.Add("p_origen_informe", OracleDbType.Int64, origenA, ParameterDirection.Input);
            cmd.Parameters.Add("d_cod_tipo_informe", OracleDbType.Int64, tipoA, ParameterDirection.Input);
            cmd.Parameters.Add("p_cod_falla_destino", OracleDbType.Int32, codFallaB, ParameterDirection.Input);
            cmd.Parameters.Add("p_destino_informe", OracleDbType.Int64, origenB, ParameterDirection.Input);
            cmd.Parameters.Add("d_cod_tipo_informe_destino", OracleDbType.Int64, tipoB, ParameterDirection.Input);

            cmd.Parameters.Add("RETURN", OracleDbType.Decimal).Direction = ParameterDirection.ReturnValue;
            cmd.BindByName = true;
            try
            {
                cmd.ExecuteNonQuery();
                decimal res = ((Oracle.DataAccess.Types.OracleDecimal)(cmd.Parameters["RETURN"].Value)).Value;
                resultado = (ResultadoCopiaInforme)(int)res;
            }
            catch (Exception ex)
            {
                resultado = ResultadoCopiaInforme.Error;
                PistaMgr.Instance.Error("OraDalSisFalla", ex);
            }
            return resultado;
        }

        public void Insertar(List<DataRow> tabla)
        {
            string sql = "insert into {0} ({1},{2},{3},{4},{5},{6},{7},{8},{9},{10},{11},{12},{13},{14},{15},{16},{17},{18},{19},{20},{21})" +
                " values (:{1},:{2},:{3},:{4},:{5},:{6},:{7},:{8},:{9},:{10},:{11},:{12},:{13},:{14},:{15},:{16},:{17},:{18},:{19},:{20},:{21})";
            InsertUpdate(tabla, sql);
            if (Sesion.Instancia.Conexion != null)
            {
                foreach (var r in tabla)
                {
                    int pkCodFalla = ObjetoDeNegocio.GetValor<int>(r[InformeFalla.C_PK_COD_FALLA]);
                    if (ModeloMgr.Instancia.RegFallaMgr.EstaInvolucrado(pkCodFalla, Sesion.Instancia.EmpresaActual.PkCodPersona))
                    {
                        MensajeEmergente msg = new MensajeEmergente();
                        msg.Cabecera = "Informe de Falla: " + RegFalla.FormatearCodFalla(r[InformeFalla.C_PK_COD_FALLA].ToString());
                        Persona p = OraDalPersonaMgr.Instancia.GetAgente((long)r[InformeFalla.C_PK_ORIGEN_INFORME]);
                        msg.Detalle = "Informe " + InformeFalla.GetTexto((long)r[InformeFalla.C_PK_D_COD_TIPOINFORME]) + " " + p.Sigla +
                            Environment.NewLine + p.Nombre;
                        if (p.PkCodPersona == 7)
                        {
                            msg.Resaltado = true;
                        }
                        MensajeEmergenteMgr.Intancia.AdicionarMensaje(msg);
                        RegistrarOperacion(r);
                    }
                }
            }
        }

        private static void RegistrarOperacion(DataRow r)
        {
            Operacion op = new Operacion();
            if ((long)r[InformeFalla.C_PK_ORIGEN_INFORME] == 7 && (long)r[InformeFalla.C_COD_ESTADO_INF] == (long)D_COD_ESTADO_INF.ENVIADO)
            {
                DOMINIOS_OPERACION dOp = DOMINIOS_OPERACION.CNDC_ENVIA_PRELIMINAR;
                switch ((PK_D_COD_TIPOINFORME)(long)r[InformeFalla.C_PK_D_COD_TIPOINFORME])
                {
                    case PK_D_COD_TIPOINFORME.PRELIMINAR:
                        dOp = DOMINIOS_OPERACION.CNDC_ENVIA_PRELIMINAR;
                        break;
                    case PK_D_COD_TIPOINFORME.FINAL:
                        dOp = DOMINIOS_OPERACION.CNDC_ENVIA_FINAL;
                        break;
                    case PK_D_COD_TIPOINFORME.RECTIFICATORIO:
                        dOp = DOMINIOS_OPERACION.CNDC_ENVIA_RECTIFICATORIO;
                        break;
                }
                op.RegistrarOperacion(dOp, (int)r[InformeFalla.C_PK_COD_FALLA], 7);
            }
        }

        public void Actualizar(List<DataRow> tabla)
        {
            string sql = "update {0} set " +
                    "{4}=:{4}, " +
                    "{5}=:{5}, " +
                    "{6}=:{6}, " +
                    "{7}=:{7}, " +
                    "{8}=:{8}, " +
                    "{9}=:{9}, " +
                    "{10}=:{10}, " +
                    "{11}=:{11}, " +
                    "{12}=:{12}, " +
                    "{13}=:{13}, " +
                    "{14}=:{14}, " +
                    "{15}=:{15}, " +
                    "{16}=:{16}, " +
                    "{17}=:{17}, " +
                    "{18}=:{18}, " +
                    "{19}=:{19}, " +
                    "{20}=:{20}, " +
                    "{21}=:{21} " +
                    "where {1}=:{1} AND {2}=:{2} AND {3}=:{3}";
            InsertUpdate(tabla, sql);
            foreach (var r in tabla)
            {
                RegistrarOperacion(r);
            }
        }

        void InsertUpdate(List<DataRow> tabla, string sql)
        {
            OracleCommand cmd = null;
            sql = string.Format(sql,
                      InformeFalla.NOMBRE_TABLA,
                      InformeFalla.C_PK_COD_FALLA,
                      InformeFalla.C_PK_ORIGEN_INFORME,
                      InformeFalla.C_PK_D_COD_TIPOINFORME,
                      InformeFalla.C_FEC_INICIO,
                      InformeFalla.C_FEC_FINAL,
                      InformeFalla.C_DESCRIPCION,
                      InformeFalla.C_RESTITUCION,
                      InformeFalla.C_INFORMACION_ADICIONAL,
                      InformeFalla.C_D_COD_ESTADO,
                      InformeFalla.C_SEC_LOG,
                      InformeFalla.C_D_COD_ORIGEN,
                      InformeFalla.C_OPERACION_PROTECCIONES,
                      InformeFalla.C_D_COD_TIPO_DESCONEXION,
                      InformeFalla.C_D_COD_CAUSA,
                      InformeFalla.C_COD_PERSONA,
                      InformeFalla.C_COD_ESTADO_INF,
                      InformeFalla.C_SINC_VER,
                      InformeFalla.C_NUM_FALLA_AGENTE,
                      InformeFalla.C_COD_COMPONENTE_FALLADO,
                      InformeFalla.C_FEC_REGISTRO,
                      InformeFalla.C_ELABORADO_POR
                      );

            cmd = CrearCommand();
            cmd.CommandText = sql;
            cmd.ArrayBindCount = tabla.Count;
            cmd.Parameters.Add(InformeFalla.C_PK_COD_FALLA, OracleDbType.Int32, GetArray(tabla, InformeFalla.C_PK_COD_FALLA), ParameterDirection.Input);
            cmd.Parameters.Add(InformeFalla.C_PK_ORIGEN_INFORME, OracleDbType.Int64, GetArray(tabla, InformeFalla.C_PK_ORIGEN_INFORME), ParameterDirection.Input);
            cmd.Parameters.Add(InformeFalla.C_PK_D_COD_TIPOINFORME, OracleDbType.Int64, GetArray(tabla, InformeFalla.C_PK_D_COD_TIPOINFORME), ParameterDirection.Input);
            cmd.Parameters.Add(InformeFalla.C_FEC_INICIO, OracleDbType.Date, GetArray(tabla, InformeFalla.C_FEC_INICIO), ParameterDirection.Input);
            cmd.Parameters.Add(InformeFalla.C_FEC_FINAL, OracleDbType.Date, GetArray(tabla, InformeFalla.C_FEC_FINAL), ParameterDirection.Input);
            cmd.Parameters.Add(InformeFalla.C_DESCRIPCION, OracleDbType.Varchar2, GetArray(tabla, InformeFalla.C_DESCRIPCION), ParameterDirection.Input);
            cmd.Parameters.Add(InformeFalla.C_RESTITUCION, OracleDbType.Varchar2, GetArray(tabla, InformeFalla.C_RESTITUCION), ParameterDirection.Input);
            cmd.Parameters.Add(InformeFalla.C_INFORMACION_ADICIONAL, OracleDbType.Varchar2, GetArray(tabla, InformeFalla.C_INFORMACION_ADICIONAL), ParameterDirection.Input);
            cmd.Parameters.Add(InformeFalla.C_D_COD_ESTADO, OracleDbType.Varchar2, GetArray(tabla, InformeFalla.C_D_COD_ESTADO), ParameterDirection.Input);
            cmd.Parameters.Add(InformeFalla.C_SEC_LOG, OracleDbType.Int64, GetArray(tabla, InformeFalla.C_SEC_LOG), ParameterDirection.Input);
            cmd.Parameters.Add(InformeFalla.C_D_COD_ORIGEN, OracleDbType.Int64, GetArray(tabla, InformeFalla.C_D_COD_ORIGEN), ParameterDirection.Input);
            cmd.Parameters.Add(InformeFalla.C_OPERACION_PROTECCIONES, OracleDbType.Varchar2, GetArray(tabla, InformeFalla.C_OPERACION_PROTECCIONES), ParameterDirection.Input);
            cmd.Parameters.Add(InformeFalla.C_D_COD_TIPO_DESCONEXION, OracleDbType.Int64, GetArray(tabla, InformeFalla.C_D_COD_TIPO_DESCONEXION), ParameterDirection.Input);
            cmd.Parameters.Add(InformeFalla.C_D_COD_CAUSA, OracleDbType.Int64, GetArray(tabla, InformeFalla.C_D_COD_CAUSA), ParameterDirection.Input);
            cmd.Parameters.Add(InformeFalla.C_COD_PERSONA, OracleDbType.Int64, GetArray(tabla, InformeFalla.C_COD_PERSONA), ParameterDirection.Input);
            cmd.Parameters.Add(InformeFalla.C_COD_ESTADO_INF, OracleDbType.Int64, GetArray(tabla, InformeFalla.C_COD_ESTADO_INF), ParameterDirection.Input);
            cmd.Parameters.Add(InformeFalla.C_SINC_VER, OracleDbType.Int64, GetArray(tabla, InformeFalla.C_SINC_VER), ParameterDirection.Input);
            cmd.Parameters.Add(InformeFalla.C_NUM_FALLA_AGENTE, OracleDbType.Varchar2, GetArray(tabla, InformeFalla.C_NUM_FALLA_AGENTE), ParameterDirection.Input);
            cmd.Parameters.Add(InformeFalla.C_COD_COMPONENTE_FALLADO, OracleDbType.Int64, GetArray(tabla, InformeFalla.C_COD_COMPONENTE_FALLADO), ParameterDirection.Input);
            cmd.Parameters.Add(InformeFalla.C_FEC_REGISTRO, OracleDbType.Date, GetArray(tabla, InformeFalla.C_FEC_REGISTRO), ParameterDirection.Input);
            cmd.Parameters.Add(InformeFalla.C_ELABORADO_POR, OracleDbType.Varchar2, GetArray(tabla, InformeFalla.C_ELABORADO_POR), ParameterDirection.Input);
            cmd.BindByName = true;

            Actualizar(cmd);
        }

        public bool Bloquear(InformeFalla i)
        {
            bool resultado = false;
            DataRow rowBloqueador = ModeloMgr.Instancia.InformeFallaMgr.GetBloqueador(i);
            if (rowBloqueador == null)
            {
                DesBloquear(i);
            }
            string sql = "INSERT INTO F_GF_INF_FALLA_BLOQ({0},{1},{2},{3}) values(:{0},:{1},:{2},:{3})";
            OracleCommand cmd = CrearCommand();
            sql = string.Format(sql, "PK_COD_FALLA", "PK_ORIGEN_INFORME", "PK_D_COD_TIPOINFORME", "SESSION_ID");
            cmd.CommandText = sql;
            cmd.Parameters.Add("PK_COD_FALLA", OracleDbType.Int32, i.PkCodFalla, ParameterDirection.Input);
            cmd.Parameters.Add("PK_ORIGEN_INFORME", OracleDbType.Int64, i.PkOrigenInforme, ParameterDirection.Input);
            cmd.Parameters.Add("PK_D_COD_TIPOINFORME", OracleDbType.Int64, i.PkDCodTipoinforme, ParameterDirection.Input);
            cmd.Parameters.Add("SESSION_ID", OracleDbType.Int32, Sesion.Instancia.IdSesion, ParameterDirection.Input);
            cmd.BindByName = true;

            resultado = Actualizar(cmd);
            if (resultado)
            {
                DataRow row = GetDataRowInforme(i.PkCodFalla, i.PkOrigenInforme, i.PkDCodTipoinforme);
                i.Leer(row);
            }
            return resultado;
        }

        public void DesBloquear(InformeFalla i)
        {
            string sql =
            @"DELETE FROM F_GF_INF_FALLA_BLOQ
            WHERE {0}=:{0} AND {1}=:{1} AND {2}=:{2}";
            OracleCommand cmd = CrearCommand();
            sql = string.Format(sql, "PK_COD_FALLA", "PK_ORIGEN_INFORME", "PK_D_COD_TIPOINFORME", "SESSION_ID");
            cmd.CommandText = sql;
            cmd.Parameters.Add("PK_COD_FALLA", OracleDbType.Int32, i.PkCodFalla, ParameterDirection.Input);
            cmd.Parameters.Add("PK_ORIGEN_INFORME", OracleDbType.Int64, i.PkOrigenInforme, ParameterDirection.Input);
            cmd.Parameters.Add("PK_D_COD_TIPOINFORME", OracleDbType.Int64, i.PkDCodTipoinforme, ParameterDirection.Input);
            cmd.BindByName = true;

            Actualizar(cmd);
        }


        public DataRow GetBloqueador(InformeFalla i)
        {
            DataRow resultado = null;
            string sql =
            @"SELECT username, machine, program, terminal FROM V$session
            WHERE audsid IN 
            (SELECT session_id FROM f_gf_inf_falla_bloq
            WHERE pk_cod_falla=:pk_cod_falla 
            AND pk_origen_informe=:pk_origen_informe 
            AND pk_d_cod_tipoinforme=:pk_d_cod_tipoinforme)";
            OracleCommand cmd = CrearCommand();
            sql = string.Format(sql, "PK_COD_FALLA", "PK_ORIGEN_INFORME", "PK_D_COD_TIPOINFORME", "SESSION_ID");
            cmd.CommandText = sql;
            cmd.Parameters.Add("PK_COD_FALLA", OracleDbType.Int32, i.PkCodFalla, ParameterDirection.Input);
            cmd.Parameters.Add("PK_ORIGEN_INFORME", OracleDbType.Int64, i.PkOrigenInforme, ParameterDirection.Input);
            cmd.Parameters.Add("PK_D_COD_TIPOINFORME", OracleDbType.Int64, i.PkDCodTipoinforme, ParameterDirection.Input);
            cmd.BindByName = true;

            DataTable tabla = EjecutarCmd(cmd);
            if (tabla.Rows.Count > 0)
            {
                resultado = tabla.Rows[0];
            }
            return resultado;
        }

        /*
         * Metodo que en lugar de verificar si un informe existe, lo elimina
         * y retorna false, lo cual indica q el informe no existe.
         * 
         * Este metodo se ha implementado de esta forma para 
         * resolver el BUG 122: Resultado de reenvio-envio incorrecto.
         */
        public override bool Existe(string nombreTabla, DataRow row)
        {
            bool resultado = false;
            long dCodEstado = (long)row["D_COD_ESTADO_INF"];

            /*switch (dCodEstado) 
            {
                case 3592:*/
                     string sql = "SELECT COUNT(*) FROM {0} WHERE {1}=:{1} AND {2}=:{2} AND {3}=:{3}";
                sql = string.Format(sql, InformeFalla.NOMBRE_TABLA, InformeFalla.C_PK_COD_FALLA,
                    InformeFalla.C_PK_ORIGEN_INFORME, InformeFalla.C_PK_D_COD_TIPOINFORME);

                OracleCommand cmd = CrearCommand();
                cmd.CommandText = sql;
                cmd.Parameters.Add(InformeFalla.C_PK_COD_FALLA, OracleDbType.Int32, row[InformeFalla.C_PK_COD_FALLA], ParameterDirection.Input);
                cmd.Parameters.Add(InformeFalla.C_PK_ORIGEN_INFORME, OracleDbType.Int64, row[InformeFalla.C_PK_ORIGEN_INFORME], ParameterDirection.Input);
                cmd.Parameters.Add(InformeFalla.C_PK_D_COD_TIPOINFORME, OracleDbType.Int64, row[InformeFalla.C_PK_D_COD_TIPOINFORME], ParameterDirection.Input);
                DataTable tabla = EjecutarCmd(cmd);
                if (tabla.Rows.Count > 0)
                {
                    resultado = (decimal)tabla.Rows[0][0] > 0;
                }
               
            /*break;
            }*/
            
            //else
            //{
            //    string sql = "DELETE FROM {0} WHERE {1}=:{1} AND {2}=:{2} AND {3}=:{3}";
            //    sql = string.Format(sql, InformeFalla.NOMBRE_TABLA, InformeFalla.C_PK_COD_FALLA,
            //        InformeFalla.C_PK_ORIGEN_INFORME, InformeFalla.C_PK_D_COD_TIPOINFORME);

            //    OracleCommand cmd = CrearCommand();
            //    cmd.CommandText = sql;
            //    cmd.Parameters.Add(InformeFalla.C_PK_COD_FALLA, OracleDbType.Int32, row[InformeFalla.C_PK_COD_FALLA], ParameterDirection.Input);
            //    cmd.Parameters.Add(InformeFalla.C_PK_ORIGEN_INFORME, OracleDbType.Int64, row[InformeFalla.C_PK_ORIGEN_INFORME], ParameterDirection.Input);
            //    cmd.Parameters.Add(InformeFalla.C_PK_D_COD_TIPOINFORME, OracleDbType.Int64, row[InformeFalla.C_PK_D_COD_TIPOINFORME], ParameterDirection.Input);

            //    PistaMgr.Instance.Debug("OraDalInformeFalla.Existe",
            //        string.Format("Eliminando Informe Falla CodFalla:{0} Origen:{1} TipoInforme{2}",
            //        row[InformeFalla.C_PK_COD_FALLA], row[InformeFalla.C_PK_ORIGEN_INFORME], row[InformeFalla.C_PK_D_COD_TIPOINFORME]));

            //    Actualizar(cmd);
            //}
            return resultado;
        }

        public bool UpdateElavoradoPor(long pkRegFalla, int tipoInf, long origen, long codPersona, string nomPersona)
        {
            bool estado = true;
            try
            {
                OracleCommand cmd = null;
                string sql = string.Empty;

                sql = @"UPDATE {0} SET " +
                "{4}=:{4}, {5}=:{5} " +
                "WHERE {1}=:{1} AND {2}=:{2} AND {3}=:{3}";

                sql = string.Format(sql,
                    NombreTabla,
                    InformeFalla.C_PK_COD_FALLA,
                    InformeFalla.C_PK_D_COD_TIPOINFORME,
                    InformeFalla.C_D_COD_ORIGEN,
                    InformeFalla.C_COD_PERSONA,
                    InformeFalla.C_ELABORADO_POR
                    );

                cmd = CrearCommand();
                cmd.CommandText = sql;
                cmd.BindByName = true;
                cmd.Parameters.Add(InformeFalla.C_PK_COD_FALLA, OracleDbType.Int64, pkRegFalla, System.Data.ParameterDirection.Input);
                cmd.Parameters.Add(InformeFalla.C_PK_D_COD_TIPOINFORME, OracleDbType.Int32, tipoInf, System.Data.ParameterDirection.Input);
                cmd.Parameters.Add(InformeFalla.C_D_COD_ORIGEN, OracleDbType.Int64, origen, System.Data.ParameterDirection.Input);
                cmd.Parameters.Add("COD_PERSONA", OracleDbType.Int64, codPersona, System.Data.ParameterDirection.Input);
                cmd.Parameters.Add("ELABORADO_POR", OracleDbType.Varchar2, nomPersona, System.Data.ParameterDirection.Input);

                Actualizar(cmd);
            }catch(Exception e)
            {
                estado = false;
                PistaMgr.Instance.Error("DALSisFalla", "[UpdateElavoradoPor] "+e.Message);
            }

            return estado;
        }
    }
}
