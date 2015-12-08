using System.Data;
using CNDC.BLL;
using CNDC.DAL;
using Oracle.DataAccess.Client;
using System;
using CNDC.Pistas;
using ModeloSisFalla;
using CNDC.Dominios;
using Oracle.DataAccess.Types;

namespace OraDalSisFalla
{
    public class OraDalOperacion : OraDalBaseMgr, iOperacion
    {

        public OraDalOperacion()
        { }
        public OraDalOperacion(ConnexionOracleMgr c)
            : base(c)
        { }

        public long GetSecLog()
        {
            long rtn = -1;

            OracleCommand cmd = CrearCommand();
            cmd.CommandText = "SecLog";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("rtn", OracleDbType.Single, rtn, ParameterDirection.ReturnValue);
            try
            {
                object o = cmd.ExecuteScalar();
                OracleDecimal oee = (OracleDecimal)cmd.Parameters[0].Value;
                rtn = (long)oee.ToDouble();
            }
            catch (Exception exception)
            {
                PistaMgr.Instance.Error("DALSisFalla", exception);
            }
            finally
            {
                DisposeCommand(cmd);
            }
            return rtn;

        }

        public bool registrarOperacion(DOMINIOS_OPERACION Id_Operacion, long Pk_Cod_Falla, long Pk_Cod_Persona, long Sec_Log)
        {
            bool rtn = false;

            OracleCommand cmd = CrearCommand();
            cmd.CommandText =
            @"INSERT INTO F_GF_OPERACION
            (
              ID_OPERACION, PK_COD_FALLA, PK_COD_ORIGEN_INFORME, SEC_LOG
            )
            VALUES
            (
             :P_ID_OPERACION, :P_PK_COD_FALLA, :P_PK_COD_ORIGEN_INFORME, :P_SEC_LOG
            )";

            cmd.Parameters.Add(new OracleParameter("P_ID_OPERACION", OracleDbType.Decimal, Id_Operacion, ParameterDirection.Input));
            cmd.Parameters.Add(new OracleParameter("P_PK_COD_FALLA", OracleDbType.Decimal, Pk_Cod_Falla, ParameterDirection.Input));
            cmd.Parameters.Add(new OracleParameter("P_PK_COD_ORIGEN_INFORME", OracleDbType.Decimal, Pk_Cod_Persona, ParameterDirection.Input));
            cmd.Parameters.Add(new OracleParameter("P_SEC_LOG", OracleDbType.Decimal, Sec_Log, ParameterDirection.Input));

            if (Actualizar(cmd))
            {
                rtn = true;
            }
            return rtn;
        }

        public bool registrarOperacionPublicacion(DOMINIOS_OPERACION_PUBLICACION Id_Operacion, DateTime fecha, string detalle, long categoria, long Sec_Log, string motivo)
        {
            bool rtn = false;
            
            OracleCommand cmd = CrearCommand();
            cmd.CommandText =
            @"INSERT INTO F_DI_OPERACION
            (
              ID_OPERACION, FECHA_OPERACION, DETALLE, COD_CATEGORIA, SEC_LOG, MOTIVO_PUBLICACION
            )
            VALUES
            (
             :P_ID_OPERACION, :P_FECHA_OPERACION, :P_DETALLE, :P_COD_CATEGORIA, :P_SEC_LOG,:P_MOTIVO_PUBLICACION
            )";

            cmd.Parameters.Add(new OracleParameter("P_ID_OPERACION", OracleDbType.Decimal, Id_Operacion, ParameterDirection.Input));
            cmd.Parameters.Add(new OracleParameter("P_FECHA_OPERACION", OracleDbType.Date, fecha, ParameterDirection.Input));
            cmd.Parameters.Add(new OracleParameter("P_DETALLE", OracleDbType.Varchar2, detalle, ParameterDirection.Input));
            cmd.Parameters.Add(new OracleParameter("P_COD_CATEGORIA", OracleDbType.Decimal, categoria, ParameterDirection.Input));
            cmd.Parameters.Add(new OracleParameter("P_SEC_LOG", OracleDbType.Decimal, Sec_Log, ParameterDirection.Input));
            cmd.Parameters.Add(new OracleParameter("P_MOTIVO_PUBLICACION", OracleDbType.Varchar2, motivo, ParameterDirection.Input));

            if (Actualizar(cmd))
            {
                rtn = true;
            }
            return rtn;
        }
        public bool getOperacion(Operacion operacion, long Pk_Cod_Operacion)
        {
            OracleCommand cmd = CrearCommand();
            cmd.CommandText =
            @"SELECT id_operacion, pk_cod_falla, pk_cod_origen_informe, sec_log
            FROM quantum.f_gf_operacion 
            WHERE pk_cod_falla  = :p_pk_cod_falla 
            AND pk_cod_origen_informe = :P_pk_cod_origen_informe";

            cmd.Parameters.Add("p_id_operacion", Pk_Cod_Operacion);
            DataTable tabla = EjecutarCmd(cmd);
            if (tabla.Rows.Count > 0)
            {
                operacion.LoadFromDataRow(tabla.Rows[0]);
            }

            return true;
        }

        public int ExisteRegistro(DOMINIOS_OPERACION Id_Operacion, long Pk_Cod_Falla, long Pk_Cod_Persona)
        {
            int rtn = -1;
            OracleCommand cmd = CrearCommand();
            try
            {
                cmd.CommandText =
                @"SELECT  NVL (MAX(sec_log),-1)  FROM f_gf_operacion
                WHERE id_operacion = :p_id_operacion 
                AND pk_cod_falla =  :p_pk_cod_falla 
                AND pk_cod_origen_informe =:p_pk_cod_origen_informe";

                cmd.Parameters.Add(new OracleParameter("p_id_operacion", (long)Id_Operacion));
                cmd.Parameters.Add(new OracleParameter("p_pk_cod_falla", Pk_Cod_Falla));
                cmd.Parameters.Add(new OracleParameter("p_pk_cod_origen_informe", Pk_Cod_Persona));
                OracleDataReader r = cmd.ExecuteReader();
                if (r.Read())
                {
                    rtn =(int) r.GetDecimal(0);
                }
                r.Close();
            }
            catch (Exception exception)
            {
                PistaMgr.Instance.Error("DALSisFalla", exception);
            }
            finally
            {
                DisposeCommand(cmd);
            }
            return rtn;

        }
        public bool OperacionValida(DOMINIOS_OPERACION idOperacion, long Pk_Cod_Falla, long Pk_Cod_Persona)
        {
            bool rtn = false;
            try
            {
                rtn = false;
                //CNDC_ENVIA_NOTIFICACION = 1,
                //CNDC_ELABORA_PRELIMINAR = 2,
                //CNDC_TERMINA_PRELIMINAR = 3,
                //CNDC_ENVIA_PRELIMINAR = 4,
                //CNDC_ELABORA_FINAL = 5,
                //CNDC_TERMINA_FINAL = 6,
                //CNDC_ENVIA_FINAL = 7,
                //AGENTE_NOTIFICACION_RECIBIDA = 8,
                //AGENTE_ELABORA_PRELIMINAR = 9,
                //AGENTE_ELABORA_FINAL = 10,
                //AGENTE_ENVIA_PRELIMINAR = 11,
                //AGENTE_ENVIA_FINAL = 12,
                //CNDC_REVIERTE_INF_PRE_AGENTE = 1011

                if (Pk_Cod_Persona == 7)  // persona es CNDC
                {
                    switch (idOperacion)
                    {
                        case DOMINIOS_OPERACION.CNDC_ELABORA_PRELIMINAR:
                            if (ExisteRegistro(DOMINIOS_OPERACION.CNDC_ENVIA_NOTIFICACION, Pk_Cod_Falla, Pk_Cod_Persona) != -1
                                && ExisteRegistro(DOMINIOS_OPERACION.CNDC_ELABORA_PRELIMINAR, Pk_Cod_Falla, Pk_Cod_Persona) == -1)
                            {
                                rtn = true;
                            }
                            break;
                        case DOMINIOS_OPERACION.CNDC_TERMINA_PRELIMINAR:
                            if (ExisteRegistro(DOMINIOS_OPERACION.CNDC_ELABORA_PRELIMINAR, Pk_Cod_Falla, Pk_Cod_Persona) != -1
                                &&ExisteRegistro(DOMINIOS_OPERACION.CNDC_TERMINA_PRELIMINAR, Pk_Cod_Falla, Pk_Cod_Persona) == -1)
                            {
                                rtn = true;
                            }
                            break;
                        case DOMINIOS_OPERACION.CNDC_ENVIA_PRELIMINAR:
                            if (ExisteRegistro(DOMINIOS_OPERACION.CNDC_TERMINA_PRELIMINAR, Pk_Cod_Falla, Pk_Cod_Persona) != -1
                                && ExisteRegistro(DOMINIOS_OPERACION.CNDC_ENVIA_PRELIMINAR, Pk_Cod_Falla, Pk_Cod_Persona) == -1)
                            {
                                rtn = true;
                            }
                            break;

                        case DOMINIOS_OPERACION.CNDC_ELABORA_FINAL:
                            if (ExisteRegistro(DOMINIOS_OPERACION.CNDC_ENVIA_PRELIMINAR, Pk_Cod_Falla, Pk_Cod_Persona) != -1
                                && ExisteRegistro(DOMINIOS_OPERACION.CNDC_ELABORA_FINAL, Pk_Cod_Falla, Pk_Cod_Persona) == -1)
                            {
                                rtn = true;
                            }

                            break;
                        case DOMINIOS_OPERACION.CNDC_TERMINA_FINAL:
                            if (/*existeRegistro(DOMINIOS_OPERACION.CNDC_ELABORA_FINAL, Pk_Cod_Falla, Pk_Cod_Persona) != -1
                                &&*/ ExisteRegistro(DOMINIOS_OPERACION.CNDC_TERMINA_FINAL, Pk_Cod_Falla, Pk_Cod_Persona) == -1)
                            {
                                rtn = true;
                            }
                            break;
                        case DOMINIOS_OPERACION.CNDC_ENVIA_FINAL:
                            if (ExisteRegistro(DOMINIOS_OPERACION.CNDC_TERMINA_FINAL, Pk_Cod_Falla, Pk_Cod_Persona) != -1
                                && ExisteRegistro(DOMINIOS_OPERACION.CNDC_ENVIA_FINAL, Pk_Cod_Falla, Pk_Cod_Persona) == -1)
                            {
                                rtn = true;
                            }
                            break;
                        case DOMINIOS_OPERACION.CNDC_ELABORA_RECTIFICATORIO:
                            if (ExisteRegistro(DOMINIOS_OPERACION.CNDC_ENVIA_FINAL, Pk_Cod_Falla, Pk_Cod_Persona) != -1
                                && ExisteRegistro(DOMINIOS_OPERACION.CNDC_ELABORA_RECTIFICATORIO, Pk_Cod_Falla, Pk_Cod_Persona) == -1)
                            {
                                rtn = true;
                            }
                            break;
                        case DOMINIOS_OPERACION.CNDC_TERMINA_RECTIFICATORIO:
                            if (ExisteRegistro(DOMINIOS_OPERACION.CNDC_ELABORA_RECTIFICATORIO, Pk_Cod_Falla, Pk_Cod_Persona) != -1
                                && ExisteRegistro(DOMINIOS_OPERACION.CNDC_TERMINA_RECTIFICATORIO, Pk_Cod_Falla, Pk_Cod_Persona) == -1)
                            {
                                rtn = true;
                            }
                            break;
                        case DOMINIOS_OPERACION.CNDC_ENVIA_RECTIFICATORIO:
                            if (ExisteRegistro(DOMINIOS_OPERACION.CNDC_TERMINA_RECTIFICATORIO, Pk_Cod_Falla, Pk_Cod_Persona) != -1
                                && ExisteRegistro(DOMINIOS_OPERACION.CNDC_ENVIA_RECTIFICATORIO, Pk_Cod_Falla, Pk_Cod_Persona) == -1)
                            {
                                rtn = true;
                            }
                            break;
                    }
                }
                else
                {
                    switch (idOperacion)
                    {
                        case DOMINIOS_OPERACION.AGENTE_ENVIA_PRELIMINAR:
                            if (ExisteRegistro(DOMINIOS_OPERACION.CNDC_ENVIA_PRELIMINAR, Pk_Cod_Falla, 7) == -1)
                            {
                                rtn = true;
                            }

                            break;
                        case DOMINIOS_OPERACION.AGENTE_ENVIA_FINAL:
                            if (ExisteRegistro(DOMINIOS_OPERACION.CNDC_ENVIA_FINAL, Pk_Cod_Falla, 7) == -1)
                            {
                                rtn = true;
                            }
                            break;

                        case DOMINIOS_OPERACION.AGENTE_ELABORA_PRELIMINAR:
                            if( ExisteRegistro(DOMINIOS_OPERACION.CNDC_ENVIA_PRELIMINAR, Pk_Cod_Falla, 7) == -1)
                            {
                                rtn = true;
                            }
                            break;
                        case DOMINIOS_OPERACION.AGENTE_ELABORA_FINAL:
                            if (ExisteRegistro(DOMINIOS_OPERACION.CNDC_ENVIA_FINAL, Pk_Cod_Falla, 7) == -1)
                            {
                                rtn = true;
                            }
                            break;
                    }
                }
            }

            catch (Exception exception)
            {
                PistaMgr.Instance.Error("DALSisFalla", exception);
            }
            finally
            {
            }
            return rtn;
        }
    }
}