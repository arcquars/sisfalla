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
using BLL;
using CNDC.Dominios;

namespace OraDalSisFalla
{
    public class OraDalNotificacionMgr : OraDalBaseMgr, INotificacionMgr, IMgrLocal, IProveedorConfirmacionSinc, IProveedorDatosSincronizacion
    {
        public OraDalNotificacionMgr()
        {

        }
        public OraDalNotificacionMgr(ConnexionOracleMgr c)
            : base(c)
        { }

        public void Guardar(Notificacion obj)
        {
            OracleCommand cmd = null;
            string sql = string.Empty;
            if (obj.EsNuevo)
            {
                Pista p = PistaMgr.Instance.Info("DALSisFalla", obj.GetEstadoString());
                obj.SecLog = (long)p.PK_SecLog;
                sql = "INSERT INTO {0} ({1},{2},{3},{4},{5},{6})" +
                "VALUES(:{1},:{2},:{3},:{4},:{5},:{6})";
            }
            else
            {
                sql = "UPDATE {0} SET " +
                "{3}=:{3} ," +
                "{4}=:{4} ," +
                "{5}=:{5} ," +
                "{6}=:{6}  WHERE " +
                "{1}=:{1} AND " +
                "{2}=:{2}";
            }

            sql = string.Format(sql, Notificacion.NOMBRE_TABLA, Notificacion.C_PK_COD_FALLA,
            Notificacion.C_PK_COD_PERSONA,
            Notificacion.C_D_COD_ESTADO_NOTIFICACION,
            Notificacion.C_D_COD_ESTADO,
            Notificacion.C_SEC_LOG,
            Notificacion.C_SINC_VER);
            cmd = CrearCommand();
            cmd.CommandText = sql;
            cmd.BindByName = true;
            cmd.Parameters.Add(Notificacion.C_PK_COD_FALLA, OracleDbType.Int32, obj.PkCodFalla, System.Data.ParameterDirection.Input);
            cmd.Parameters.Add(Notificacion.C_PK_COD_PERSONA, OracleDbType.Int64, obj.PkCodPersona, System.Data.ParameterDirection.Input);
            cmd.Parameters.Add(Notificacion.C_D_COD_ESTADO_NOTIFICACION, OracleDbType.Int64, obj.DCodEstadoNotificacion, System.Data.ParameterDirection.Input);
            cmd.Parameters.Add(Notificacion.C_D_COD_ESTADO, OracleDbType.Varchar2, obj.DCodEstado, System.Data.ParameterDirection.Input);
            cmd.Parameters.Add(Notificacion.C_SEC_LOG, OracleDbType.Int64, obj.SecLog, System.Data.ParameterDirection.Input);
            cmd.Parameters.Add(Notificacion.C_SINC_VER, OracleDbType.Int64, obj.SincVer, System.Data.ParameterDirection.Input);

            if (Actualizar(cmd))
            {
                obj.EsNuevo = false;
            }
        }

        public DataTable GetTabla()
        {
            DataTable tabla = GetTabla(Notificacion.NOMBRE_TABLA);
            return tabla;
        }
        public DataTable GetRegistros(string codigo)
        {
            OracleCommand cmd = CrearCommand();
            cmd.CommandText = "select * from F_GF_NOTIFICACION where PK_COD_FALLA=:PK_COD_FALLA ";
            cmd.Parameters.Add("PK_COD_FALLA", codigo);
            cmd.BindByName = true;
            DataTable tabla = EjecutarCmd(cmd);
            tabla.TableName = Notificacion.NOMBRE_TABLA;            

            return tabla;

        }

        public bool Existe(DataRow row, DataTable tablaLocal)
        {
            bool resultado = false;
            DataRow[] registrosEncontrador = tablaLocal.Select(Notificacion.C_PK_COD_FALLA + "=" + row[Notificacion.C_PK_COD_FALLA] + " AND " + Notificacion.C_PK_COD_PERSONA + "=" + row[Notificacion.C_PK_COD_PERSONA]);
            resultado = registrosEncontrador.Length > 0;
            return resultado;
        }

        public BindingList<Notificacion> GetLista()
        {
            BindingList<Notificacion> resultado = new BindingList<Notificacion>();
            DataTable tabla = GetTabla();
            foreach (DataRow row in tabla.Rows)
            {
                resultado.Add(new Notificacion(row));
            }
            return resultado;
        }

        public BindingList<Notificacion> GetAgentesInvolucrados(int codFalla)
        {
            BindingList<Notificacion> resultado = new BindingList<Notificacion>();
            string sql = 
            @"SELECT PK_COD_FALLA, PK_COD_PERSONA, D_COD_ESTADO_NOTIFICACION,
            D_COD_ESTADO, SEC_LOG, SINC_VER
            FROM F_GF_NOTIFICACION 
            WHERE 
            PK_COD_FALLA=:PK_COD_FALLA";

            OracleCommand cmd = CrearCommand();
            cmd.CommandText = sql;
            cmd.Parameters.Add(Notificacion.C_PK_COD_FALLA, OracleDbType.Int32, codFalla, System.Data.ParameterDirection.Input);
            cmd.BindByName = true;
            DataTable tabla = EjecutarCmd(cmd);
            foreach (DataRow row in tabla.Rows)
            {
                resultado.Add(new Notificacion(row));
            }
            return resultado; 
        }

        #region IMgrLocal

        public string NombreTabla
        {
            get { return Notificacion.NOMBRE_TABLA; }
        }
        #endregion IMgrLocal


        public bool Existe(int numFalla, long codPersona)
        {
            bool resultado = false;
            string sql = 
            @"SELECT COUNT(PK_COD_FALLA) 
            FROM F_GF_NOTIFICACION 
            WHERE PK_COD_FALLA=:PK_COD_FALLA AND PK_COD_PERSONA=:PK_COD_PERSONA";
            OracleCommand cmd = CrearCommand();
            cmd.CommandText = sql;
            cmd.Parameters.Add("PK_COD_FALLA", OracleDbType.Int32, numFalla, System.Data.ParameterDirection.Input);
            cmd.Parameters.Add("PK_COD_PERSONA", OracleDbType.Int64, codPersona, System.Data.ParameterDirection.Input);
            cmd.BindByName = true;
            DataTable tabla = EjecutarCmd(cmd);
            if (tabla.Rows.Count > 0)
            {
                resultado = (decimal)tabla.Rows[0][0] > 0;
            }

            return resultado;
        }

        public void ActualizarNotificaciones(long codPersona, int[] numsFalla, long estadoNotif)
        {
            string strNumsFallas = Unir(numsFalla);
            if (string.IsNullOrEmpty(strNumsFallas))
            {
                return;
            }

            string sql =
            "UPDATE F_GF_NOTIFICACION SET D_COD_ESTADO_NOTIFICACION=:D_COD_ESTADO_NOTIFICACION " +
            "WHERE PK_COD_PERSONA=:PK_COD_PERSONA "+
            "AND D_COD_ESTADO_NOTIFICACION<>:D_COD_ESTADO_NOTIFICACION " +
            "AND PK_COD_FALLA IN (" + strNumsFallas + ")";
            OracleCommand cmd = CrearCommand();
            cmd.CommandText = sql;
            cmd.Parameters.Add("D_COD_ESTADO_NOTIFICACION", OracleDbType.Int64, estadoNotif, System.Data.ParameterDirection.Input);
            cmd.Parameters.Add("PK_COD_PERSONA", OracleDbType.Int64, codPersona, System.Data.ParameterDirection.Input);
            cmd.BindByName = true;
            Actualizar(cmd);
            foreach (int  numfalla in numsFalla )
            {
                //TODO:JLA: must
                //Operacion opn = new Operacion();
                //ModeloMgr.Instancia.OperacionMgr.getOperacion(opn, (long)DOMINIOS_OPERACION.NOTIFICACION_RECIBIDA );
                //if (opn.OperacionValida(numfalla, codPersona, (long)DOMINIOS_OPERACION.NOTIFICACION_RECIBIDA))
                //{
                //    opn.RegistrarOperacion((long)DOMINIOS_OPERACION.CNDC_ENVIA_NOTIFICACION , numfalla, codPersona);
                //}
                
            }
        }

        private string Unir(int[] numsFalla)
        {
            string resultado = string.Empty;
            foreach (var item in numsFalla)
            {
                if (resultado != string.Empty)
                {
                    resultado += ",";
                }
                resultado += item;
            }
            return resultado;
        }

        public DataTable GetTablaConfirmacionSinc(DataTable tabla)
        {
            DataTable resultado = new DataTable();
            DataColumn c = new DataColumn(Notificacion.C_PK_COD_FALLA, typeof(int));
            resultado.Columns.Add(c);
            foreach (DataRow r in tabla.Rows)
            {
                D_COD_ESTADO_NOTIFICACION estadoNotif = (D_COD_ESTADO_NOTIFICACION)(long)r[Notificacion.C_D_COD_ESTADO_NOTIFICACION];
                long pkCodPersona = (long)r[Notificacion.C_PK_COD_PERSONA];
                if (pkCodPersona == Sesion.Instancia.EmpresaActual.PkCodPersona && estadoNotif != D_COD_ESTADO_NOTIFICACION.RECIBIDO)
                {
                    DataRow rr = resultado.NewRow();
                    rr[Notificacion.C_PK_COD_FALLA] = r[Notificacion.C_PK_COD_FALLA];
                    resultado.Rows.Add(rr);
                }
            }
            return resultado;
        }

        public void BorrarNotificacionesIncorrectas(int numFalla, string codPersonasCorrectas)
        {
            string sql =
            @"DELETE FROM F_GF_NOTIFICACION WHERE PK_COD_FALLA=:PK_COD_FALLA
            AND PK_COD_PERSONA NOT IN "+codPersonasCorrectas;
            OracleCommand cmd = CrearCommand();
            cmd.CommandText = sql;
            cmd.Parameters.Add("PK_COD_FALLA", OracleDbType.Int32, numFalla, System.Data.ParameterDirection.Input);
            cmd.BindByName = true;

            Actualizar(cmd);

        }

        public DataTable GetDatos(decimal versionCliente, long pkCodPersona, bool parcial)
        {
            parcial = false;
            DataTable resultado = null;
            string sql = string.Empty;
            if (parcial)
            {
                sql = @"SELECT a.*
                FROM f_gf_notificacion a
                WHERE a.sinc_ver > :sinc_ver 
                AND a.pk_cod_falla IN 
                (SELECT b.pk_cod_falla
                FROM f_gf_notificacion b
                WHERE b.pk_cod_persona=:pk_cod_persona AND b.D_COD_ESTADO_NOTIFICACION <> 41)";
            }
            else
            {
                sql = @"SELECT a.*
                FROM f_gf_notificacion a
                WHERE a.sinc_ver > :sinc_ver 
                AND a.d_cod_estado_notificacion <> 41";
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
            return resultado;
        }

        public void Insertar(List<DataRow> tabla)
        {
            try
            {
                string sql =
                "INSERT INTO {0} ({1},{2},{3},{4},{5},{6})" +
                "VALUES(:{1},:{2},:{3},:{4},:{5},:{6})";

                InsertUpdate(tabla, sql);

                foreach (var r in tabla)
                {
                    int pkCodFalla = ObjetoDeNegocio.GetValor<int>(r[Notificacion.C_PK_COD_FALLA]);
                    long pkcodPersona = ObjetoDeNegocio.GetValor<long>(r[Notificacion.C_PK_COD_PERSONA]);
                    if (pkcodPersona == Sesion.Instancia.EmpresaActual.PkCodPersona)
                    {
                        MensajeEmergente msg = new MensajeEmergente();
                        RegFalla regFalla = ModeloMgr.Instancia.RegFallaMgr.GetFalla(ObjetoDeNegocio.GetValor<int>(r[RegFalla.C_PK_COD_FALLA]));
                        msg.Cabecera = "Notificacion de Falla: " + RegFalla.FormatearCodFalla(regFalla.CodFalla.ToString());
                        msg.Detalle = regFalla.Descripcion;
                        MensajeEmergenteMgr.Intancia.AdicionarMensaje(msg);
                    }
                }
            }
            catch (Exception)
            {
            }
        }

        public void Actualizar(List<DataRow> tabla)
        {
            string sql = 
            "UPDATE {0} SET " +
            "{3}=:{3} ," +
            "{4}=:{4} ," +
            "{5}=:{5} ," +
            "{6}=:{6}  WHERE " +
            "{1}=:{1} AND " +
            "{2}=:{2}";
            InsertUpdate(tabla, sql);
        }

        void InsertUpdate(List<DataRow> tabla, string sql)
        {
            OracleCommand cmd = null;

            sql = string.Format(sql, Notificacion.NOMBRE_TABLA, Notificacion.C_PK_COD_FALLA,
            Notificacion.C_PK_COD_PERSONA,
            Notificacion.C_D_COD_ESTADO_NOTIFICACION,
            Notificacion.C_D_COD_ESTADO,
            Notificacion.C_SEC_LOG,
            Notificacion.C_SINC_VER);
            cmd = CrearCommand();
            cmd.CommandText = sql;
            cmd.BindByName = true;
            cmd.ArrayBindCount = tabla.Count;
            cmd.Parameters.Add(Notificacion.C_PK_COD_FALLA, OracleDbType.Int32, GetArray(tabla, Notificacion.C_PK_COD_FALLA), System.Data.ParameterDirection.Input);
            cmd.Parameters.Add(Notificacion.C_PK_COD_PERSONA, OracleDbType.Int64, GetArray(tabla, Notificacion.C_PK_COD_PERSONA), System.Data.ParameterDirection.Input);
            cmd.Parameters.Add(Notificacion.C_D_COD_ESTADO_NOTIFICACION, OracleDbType.Int64, GetArray(tabla, Notificacion.C_D_COD_ESTADO_NOTIFICACION), System.Data.ParameterDirection.Input);
            cmd.Parameters.Add(Notificacion.C_D_COD_ESTADO, OracleDbType.Varchar2, GetArray(tabla, Notificacion.C_D_COD_ESTADO), System.Data.ParameterDirection.Input);
            cmd.Parameters.Add(Notificacion.C_SEC_LOG, OracleDbType.Int64, GetArray(tabla, Notificacion.C_SEC_LOG), System.Data.ParameterDirection.Input);
            cmd.Parameters.Add(Notificacion.C_SINC_VER, OracleDbType.Int64, GetArray(tabla, Notificacion.C_SINC_VER), System.Data.ParameterDirection.Input);

            Actualizar(cmd);
        }

        public void RevertirNotificacion(int numFalla, string codAgentesSeparadosPorComa)
        {
            string sql =
            @"UPDATE F_GF_NOTIFICACION
            SET D_COD_ESTADO=0
            WHERE PK_COD_FALLA=" + numFalla + " AND PK_COD_PERSONA IN (" + codAgentesSeparadosPorComa + ")";
            OracleCommand cmd = CrearCommand();
            cmd.CommandText = sql;

            if (Actualizar(cmd))
            {
                Operacion opn = new Operacion();
                string[] codAgentes = codAgentesSeparadosPorComa.Split(',');

                foreach (string codAgente in codAgentes)
                {
                    opn.RegistrarOperacion(DOMINIOS_OPERACION.CNDC_REVIERTE_NOTIF_AGENTE, numFalla, int.Parse(codAgente));
                }
            }
        }

        public DataTable GetCodPersonaSiglaDeInvolucrados(int pkCodFalla)
        {
            DataTable resultado = null;
            string sql =
            @"SELECT n.PK_COD_PERSONA,p.SIGLA
            FROM F_AP_PERSONA p,F_GF_NOTIFICACION n
            WHERE n.PK_COD_FALLA=:PK_COD_FALLA
            AND n.PK_COD_PERSONA=p.PK_COD_PERSONA
            ORDER BY p.SIGLA";
            OracleCommand cmd = CrearCommand();
            cmd.CommandText = sql;
            cmd.BindByName = true;
            cmd.Parameters.Add(Notificacion.C_PK_COD_FALLA, OracleDbType.Int32, pkCodFalla, ParameterDirection.Input);
            resultado = EjecutarCmd(cmd);
            return resultado;
        }
    }
}
