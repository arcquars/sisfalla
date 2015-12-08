using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.ComponentModel;
using Oracle.DataAccess.Client;
using CNDC.Pistas;
using CNDC.DAL;
using CNDC.BLL;

namespace MC
{
    public class OraDalMC_FormatoLecturaMgr : OraDalBaseMgr, IMC_FormatoLecturaMgr
    {
        #region Singleton
        private static OraDalMC_FormatoLecturaMgr _instancia;
        static OraDalMC_FormatoLecturaMgr()
        {
            _instancia = new OraDalMC_FormatoLecturaMgr();
        }
        public static OraDalMC_FormatoLecturaMgr Instancia
        {
            get { return _instancia; }
        }

        private OraDalMC_FormatoLecturaMgr()
        {

        }
        #endregion Singleton

        public void Guardar(MC_FormatoLectura obj)
        {
            OracleCommand cmd = null;
            string sql = string.Empty;
            if (obj.EsNuevo)
            {
                Pista p = PistaMgr.Instance.Info("DALSisFalla", obj.GetEstadoString());
                obj.SecLog = (long)p.PK_SecLog;
                sql = "INSERT INTO {0} ({1},{2},{3},{4},{5},{6},{7},{8})" +
                "VALUES(:{1},:{2},:{3},:{4},:{5},:{6},:{7},:{8})";
            }
            else
            {
                sql = "UPDATE {0} SET " +
                "{1}=:{1} ," +
                "{2}=:{2} ," +
                "{3}=:{3} ," +
                "{4}=:{4} ," +
                "{5}=:{5} ," +
                "{6}=:{6} ," +
                "{7}=:{7} ," +
                "{8}=:{8}  WHERE ";
            }

            sql = string.Format(sql, MC_FormatoLectura.NOMBRE_TABLA, MC_FormatoLectura.C_PK_COD_FTO,
            MC_FormatoLectura.C_DESCRIPCION_FTO,
            MC_FormatoLectura.C_EXTENSION,
            MC_FormatoLectura.C_VERSION,
            MC_FormatoLectura.C_DLL_LECTOR,
            MC_FormatoLectura.C_D_COD_ESTADO,
            MC_FormatoLectura.C_SEC_LOG,
            MC_FormatoLectura.C_CLASE_LECTOR);
            cmd = CrearCommand();
            cmd.CommandText = sql;
            cmd.BindByName = true;
            cmd.Parameters.Add(MC_FormatoLectura.C_PK_COD_FTO, OracleDbType.Int64, obj.PkCodFto, System.Data.ParameterDirection.Input);
            cmd.Parameters.Add(MC_FormatoLectura.C_DESCRIPCION_FTO, OracleDbType.Varchar2, obj.DescripcionFto, System.Data.ParameterDirection.Input);
            cmd.Parameters.Add(MC_FormatoLectura.C_EXTENSION, OracleDbType.Varchar2, obj.Extension, System.Data.ParameterDirection.Input);
            cmd.Parameters.Add(MC_FormatoLectura.C_VERSION, OracleDbType.Int16, obj.Version, System.Data.ParameterDirection.Input);
            cmd.Parameters.Add(MC_FormatoLectura.C_DLL_LECTOR, OracleDbType.Varchar2, obj.DllLector, System.Data.ParameterDirection.Input);
            cmd.Parameters.Add(MC_FormatoLectura.C_D_COD_ESTADO, OracleDbType.Varchar2, obj.DCodEstado, System.Data.ParameterDirection.Input);
            cmd.Parameters.Add(MC_FormatoLectura.C_SEC_LOG, OracleDbType.Int64, obj.SecLog, System.Data.ParameterDirection.Input);
            cmd.Parameters.Add(MC_FormatoLectura.C_CLASE_LECTOR, OracleDbType.Varchar2, obj.ClaseLector, System.Data.ParameterDirection.Input);

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
        public DataTable GetTabla()
        {
            DataTable tabla = GetTabla(MC_FormatoLectura.NOMBRE_TABLA);
            return tabla;
        }

        public BindingList<MC_FormatoLectura> GetLista()
        {
            BindingList<MC_FormatoLectura> resultado = new BindingList<MC_FormatoLectura>();
            DataTable tablaAgentes = GetTabla();
            foreach (DataRow row in tablaAgentes.Rows)
            {
                resultado.Add(new MC_FormatoLectura(row));
            }
            return resultado;
        }

        public MC_FormatoLectura GetPorDescripcion(string descripcion)
        {
            MC_FormatoLectura resultado = null;
            string sql = "SELECT * FROM P_MC_FTO_LECTURA WHERE DESCRIPCION_FTO=:DESCRIPCION_FTO";
            OracleCommand cmd = CrearCommand();
            cmd.BindByName = true;
            cmd.CommandText = sql;
            cmd.Parameters.Add("DESCRIPCION_FTO", OracleDbType.Varchar2, descripcion, ParameterDirection.Input);
            DataTable tabla = EjecutarCmd(cmd);
            if (tabla.Rows.Count > 0)
            {
                resultado = new MC_FormatoLectura(tabla.Rows[0]);
            }

            return resultado;
        }

        public List<MC_FormatoLectura> GetPorCodMedidor(long pkCodMedidor)
        {
            List<MC_FormatoLectura> resultado = new List<MC_FormatoLectura>();
            string sql = @"SELECT fto.* FROM p_mc_fto_lectura fto 
            WHERE fto.pk_cod_fto IN( SELECT mfto.pk_cod_formato FROM f_mc_rmedidor_fto mfto WHERE mfto.pk_cod_medidor=:pk_cod_medidor)";
            OracleCommand cmd = CrearCommand();
            cmd.BindByName = true;
            cmd.CommandText = sql;
            cmd.Parameters.Add("pk_cod_medidor", OracleDbType.Varchar2, pkCodMedidor, ParameterDirection.Input);
            DataTable tabla = EjecutarCmd(cmd);
            foreach (DataRow r in tabla.Rows)
            {
                resultado.Add(new MC_FormatoLectura(r));
            }
            return resultado;
        }
    }
}