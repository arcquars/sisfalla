using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.ComponentModel;
using Oracle.DataAccess.Client;
using CNDC.Pistas;
using CNDC.BLL;
using System.IO;

namespace MC
{
    public class OraDalMC_RMedidorFtoMgr : OraDalBaseMgr, IMC_RMedidorFtoMgr
    {
        #region Singleton
        private static OraDalMC_RMedidorFtoMgr _instancia;
        static OraDalMC_RMedidorFtoMgr()
        {
            _instancia = new OraDalMC_RMedidorFtoMgr();
        }
        public static OraDalMC_RMedidorFtoMgr Instancia
        {
            get { return _instancia; }
        }

        private OraDalMC_RMedidorFtoMgr()
        {

        }
        #endregion Singleton

        public void Guardar(MC_RMedidorFto obj)
        {
            OracleCommand cmd = null;
            string sql = string.Empty;
            if (obj.EsNuevo)
            {
                Pista p = PistaMgr.Instance.Info("DALSisFalla", obj.GetEstadoString());
                obj.SecLog = (long)p.PK_SecLog;
                obj.PrioridadLectura = GetPrioridad(obj);
                sql = "INSERT INTO {0} ({1},{2},{3},{4},{5},{6},{7})" +
                "VALUES(:{1},:{2},:{3},:{4},:{5},:{6},:{7})";
            }
            else
            {
                sql = "UPDATE {0} SET " +
                "{3}=:{3} ," +
                "{4}=:{4} ," +
                "{5}=:{5} ," +
                "{6}=:{6} ," +
                "{7}=:{7}  WHERE {1}=:{1} AND {2}=:{2} ";
            }

            sql = string.Format(sql, MC_RMedidorFto.NOMBRE_TABLA, MC_RMedidorFto.C_PK_COD_MEDIDOR,
            MC_RMedidorFto.C_PK_COD_FORMATO,
            MC_RMedidorFto.C_NOMBRE_ARCHIVO,
            MC_RMedidorFto.C_PRIORIDAD_LECTURA,
            MC_RMedidorFto.C_D_COD_ESTADO,
            MC_RMedidorFto.C_SEC_LOG,
            MC_RMedidorFto.C_CONTIENE_FIN_INTERVALO);
            cmd = CrearCommand();
            cmd.CommandText = sql;
            cmd.BindByName = true;
            cmd.Parameters.Add(MC_RMedidorFto.C_PK_COD_MEDIDOR, OracleDbType.Int64, obj.PkCodMedidor, ParameterDirection.Input);
            cmd.Parameters.Add(MC_RMedidorFto.C_PK_COD_FORMATO, OracleDbType.Int64, obj.PkCodFormato, ParameterDirection.Input);
            cmd.Parameters.Add(MC_RMedidorFto.C_NOMBRE_ARCHIVO, OracleDbType.Varchar2, obj.NombreArchivo, ParameterDirection.Input);
            cmd.Parameters.Add(MC_RMedidorFto.C_PRIORIDAD_LECTURA, OracleDbType.Int16, obj.PrioridadLectura, ParameterDirection.Input);
            cmd.Parameters.Add(MC_RMedidorFto.C_D_COD_ESTADO, OracleDbType.Varchar2, obj.DCodEstado, ParameterDirection.Input);
            cmd.Parameters.Add(MC_RMedidorFto.C_SEC_LOG, OracleDbType.Int64, obj.SecLog, ParameterDirection.Input);
            cmd.Parameters.Add(MC_RMedidorFto.C_CONTIENE_FIN_INTERVALO, OracleDbType.Int16, obj.ContieneFinIntervalo, ParameterDirection.Input);

            try
            {
                cmd.ExecuteNonQuery();
                obj.EsNuevo = false;
            }
            catch (Exception exception)
            {
                PistaMgr.Instance.Error("DALSisFalla", exception);
            }
            finally
            {
                DisposeCommand(cmd);
            }
        }

        private short GetPrioridad(MC_RMedidorFto obj)
        {
            short resultado = 1;
            string sql = 
            @"SELECT MAX(prioridad_lectura) FROM F_MC_RMEDIDOR_FTO
            WHERE pk_cod_medidor=:pk_cod_medidor";
            OracleCommand cmd = CrearCommand(sql);
            cmd.Parameters.Add("pk_cod_medidor", OracleDbType.Int64, obj.PkCodMedidor, ParameterDirection.Input);

            DataTable tabla = EjecutarCmd(cmd);
            resultado = (short)ObjetoDeNegocio.GetValor<decimal>(tabla.Rows[0][0]);
            resultado++;
            return resultado;
        }

        public DataTable GetTabla()
        {
            DataTable tabla = GetTabla(MC_RMedidorFto.NOMBRE_TABLA);
            return tabla;
        }

        public BindingList<MC_RMedidorFto> GetLista()
        {
            BindingList<MC_RMedidorFto> resultado = new BindingList<MC_RMedidorFto>();
            DataTable tablaAgentes = GetTabla();
            foreach (DataRow row in tablaAgentes.Rows)
            {
                resultado.Add(new MC_RMedidorFto(row));
            }
            return resultado;
        }

        public DataTable GetFormatos(AC_Medidor medidor)
        {
            return GetFormatos(medidor.PkCodMedidor);
        }

        public DataTable GetFormatos(long pkCodMedidor)
        {
            string sql =
            @"SELECT r.*,f.descripcion_fto 
            FROM f_mc_rmedidor_fto r, p_mc_fto_lectura f
            WHERE r.pk_cod_medidor=:pk_cod_medidor AND r.pk_cod_formato=f.pk_cod_fto
            ORDER BY r.prioridad_lectura";
            OracleCommand cmd = CrearCommand(sql);
            cmd.Parameters.Add("pk_cod_medidor", OracleDbType.Int64, pkCodMedidor, ParameterDirection.Input);
            DataTable resultado = EjecutarCmd(cmd);
            return resultado;
        }

        public bool Existe(long codMedidor, long codFormato)
        {
            bool resultado = false;
            string sql =
            @"SELECT COUNT(*) FROM f_mc_rmedidor_fto
            WHERE pk_cod_medidor=:pk_cod_medidor AND pk_cod_formato=:pk_cod_formato";
            OracleCommand cmd = CrearCommand(sql);
            cmd.Parameters.Add("pk_cod_medidor", OracleDbType.Int64, codMedidor, ParameterDirection.Input);
            cmd.Parameters.Add("pk_cod_formato", OracleDbType.Int64, codFormato, ParameterDirection.Input);
            DataTable tabla = EjecutarCmd(cmd);

            decimal cantidad = (decimal)tabla.Rows[0][0];
            resultado = cantidad > 0;

            return resultado;
        }

        public string BuscarArchivo(string nombreArchivoPrototipo, string carpeta)
        {
            string resultado = string.Empty;
            nombreArchivoPrototipo = nombreArchivoPrototipo.ToLower();
            if (Directory.Exists(carpeta))
            {
                string[] archivos = Directory.GetFiles(carpeta);
                foreach (string arch in archivos)
                {
                    string a = Path.GetFileName(arch.ToLower());
                    if (a == nombreArchivoPrototipo)
                    {
                        resultado = Path.GetFileName(arch);
                        break;
                    }
                    else if (nombreArchivoPrototipo.IndexOf('[') >= 0)
                    {
                        if (TienenMismoPatron(nombreArchivoPrototipo, a))
                        {
                            resultado = Path.GetFileName(arch);
                            break;
                        }
                    }
                }
            }
            return resultado;
        }

        private bool TienenMismoPatron(string nombreArchivoPrototipo, string a)
        {
            bool resultado = false;
            int idx1 = nombreArchivoPrototipo.IndexOf('[');
            int idx2 = nombreArchivoPrototipo.IndexOf(']');
            string inicio = nombreArchivoPrototipo.Substring(0, idx1);
            string fin = nombreArchivoPrototipo.Substring(idx2 + 1);
            resultado = a.StartsWith(inicio) && a.EndsWith(fin);
            return resultado;
        }
    }
}