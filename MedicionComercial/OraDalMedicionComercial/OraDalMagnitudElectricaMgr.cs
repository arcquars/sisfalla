using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.ComponentModel;
using Oracle.DataAccess.Client;
using CNDC.Pistas;
using CNDC.BLL;

namespace MC
{
    public class OraDalMagnitudElectricaMgr : OraDalBaseMgr, IMagnitudElectricaMgr
    {
        #region Singleton
        private static OraDalMagnitudElectricaMgr _instancia;
        static OraDalMagnitudElectricaMgr()
        {
            _instancia = new OraDalMagnitudElectricaMgr();
        }
        public static OraDalMagnitudElectricaMgr Instancia
        {
            get { return _instancia; }
        }

        private OraDalMagnitudElectricaMgr()
        {

        }
        #endregion Singleton

        public void Guardar(MagnitudElectrica obj)
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
                "{1}=:{1} ," +
                "{2}=:{2} ," +
                "{3}=:{3} ," +
                "{4}=:{4} ," +
                "{5}=:{5} ," +
                "{6}=:{6}  WHERE ";
            }

            sql = string.Format(sql, MagnitudElectrica.NOMBRE_TABLA, MagnitudElectrica.C_NOMBRE_MAGNITUD_ELEC,
            MagnitudElectrica.C_DESCRIPCION_MAG_ELEC,
            MagnitudElectrica.C_UNIDADES,
            MagnitudElectrica.C_D_COD_ESTADO,
            MagnitudElectrica.C_SEC_LOG,
            MagnitudElectrica.C_PK_COD_MAGNITUD_ELEC);
            cmd = CrearCommand();
            cmd.CommandText = sql;
            cmd.BindByName = true;
            cmd.Parameters.Add(MagnitudElectrica.C_NOMBRE_MAGNITUD_ELEC, OracleDbType.Varchar2, obj.NombreMagnitudElec, System.Data.ParameterDirection.Input);
            cmd.Parameters.Add(MagnitudElectrica.C_DESCRIPCION_MAG_ELEC, OracleDbType.Varchar2, obj.DescripcionMagElec, System.Data.ParameterDirection.Input);
            cmd.Parameters.Add(MagnitudElectrica.C_UNIDADES, OracleDbType.Varchar2, obj.Unidades, System.Data.ParameterDirection.Input);
            cmd.Parameters.Add(MagnitudElectrica.C_D_COD_ESTADO, OracleDbType.Varchar2, obj.DCodEstado, System.Data.ParameterDirection.Input);
            cmd.Parameters.Add(MagnitudElectrica.C_SEC_LOG, OracleDbType.Int64, obj.SecLog, System.Data.ParameterDirection.Input);
            cmd.Parameters.Add(MagnitudElectrica.C_PK_COD_MAGNITUD_ELEC, OracleDbType.Int64, obj.PkCodMagnitudElec, System.Data.ParameterDirection.Input);

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
            DataTable tabla = GetTabla(MagnitudElectrica.NOMBRE_TABLA);
            return tabla;
        }

        public BindingList<MagnitudElectrica> GetLista()
        {
            BindingList<MagnitudElectrica> resultado = new BindingList<MagnitudElectrica>();
            DataTable tablaAgentes = GetTabla();
            foreach (DataRow row in tablaAgentes.Rows)
            {
                resultado.Add(new MagnitudElectrica(row));
            }
            return resultado;
        }

        public List<long> GetMagnitudesAsociadas(long codMedidor)
        {
            List<long> resultado = new List<long>();
            string sql =
            @"SELECT DISTINCT pk_cod_magnitud_elec FROM p_mc_def_magnitud_elec WHERE pk_cod_magnitud_elec IN
            (SELECT fk_cod_infcanal FROM f_mc_rmedidor_canales WHERE fk_cod_medidor=:cod_medidor)";
            OracleCommand cmd = CrearCommand(sql);
            cmd.Parameters.Add("COD_MEDIDOR", OracleDbType.Int64, codMedidor, ParameterDirection.Input);
            DataTable tabla = EjecutarCmd(cmd);
            foreach (DataRow r in tabla.Rows)
            {
                resultado.Add((long)r[0]);
            }
            return resultado;
        }
    }
}
