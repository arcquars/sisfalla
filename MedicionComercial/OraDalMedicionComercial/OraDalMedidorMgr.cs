using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.ComponentModel;
using CNDC.BLL;
using Oracle.DataAccess.Client;
using CNDC.Pistas;
using BLL;
using System.IO;

namespace MC
{
    public class OraDalMedidorMgr : OraDalBaseMgr, IAC_MedidorMgr
    {
        #region Singleton
        private static OraDalMedidorMgr _instancia;
        static OraDalMedidorMgr()
        {
            _instancia = new OraDalMedidorMgr();
        }
        public static OraDalMedidorMgr Instancia
        {
            get { return _instancia; }
        }

        private OraDalMedidorMgr()
        {

        }
        #endregion Singleton

        public void Guardar(AC_Medidor obj)
        {
            OracleCommand cmd = null;
            string sql = string.Empty;
            if (obj.EsNuevo)
            {
                Pista p = PistaMgr.Instance.Info("DALSisFalla", obj.GetEstadoString());
                obj.SecLog = (long)p.PK_SecLog;
                obj.PkCodMedidor = GetIdAutoNum("SEC_PK_MEDIDOR");
                sql = "INSERT INTO {0} ({1},{2},{3},{4},{5},{6},{7},{8},{9},{10},{11},{12},{13},{14},{15})" +
                "VALUES(:{1},:{2},:{3},:{4},:{5},:{6},:{7},:{8},:{9},:{10},:{11},:{12},:{13},:{14},:{15})";
            }
            else
            {
                sql = "UPDATE {0} SET " +
                "{2}=:{2} ," +
                "{3}=:{3} ," +
                "{4}=:{4} ," +
                "{5}=:{5} ," +
                "{6}=:{6} ," +
                "{7}=:{7} ," +
                "{8}=:{8} ," +
                "{9}=:{9} ," +
                "{10}=:{10} ," +
                "{11}=:{11} ," +
                "{12}=:{12} ," +
                "{13}=:{13} ," +
                "{14}=:{14} ," +
                "{15}=:{15}  WHERE {1}=:{1}";
            }

            sql = string.Format(sql, AC_Medidor.NOMBRE_TABLA, AC_Medidor.C_PK_COD_MEDIDOR,
            AC_Medidor.C_MARCA,
            AC_Medidor.C_MODELO,
            AC_Medidor.C_PRECISION,
            AC_Medidor.C_D_COD_ESTADO,
            AC_Medidor.C_SEC_LOG,
            AC_Medidor.C_PRIME_NOINS,
            AC_Medidor.C_MEDIDOR_REEMPLAZADO,
            AC_Medidor.C_PRIORIDAD,
            AC_Medidor.C_REAL_VIRTUAL,
            AC_Medidor.C_FK_COD_PROPIETARIO,
            AC_Medidor.C_NOMBRE,
            AC_Medidor.C_DESCRIPCION,
            AC_Medidor.C_FECHA_INGRESO,
            AC_Medidor.C_FECHA_SALIDA);
            cmd = CrearCommand();
            cmd.CommandText = sql;
            cmd.BindByName = true;
            cmd.Parameters.Add(AC_Medidor.C_PK_COD_MEDIDOR, OracleDbType.Int64, obj.PkCodMedidor, System.Data.ParameterDirection.Input);
            cmd.Parameters.Add(AC_Medidor.C_MARCA, OracleDbType.Varchar2, obj.Marca, System.Data.ParameterDirection.Input);
            cmd.Parameters.Add(AC_Medidor.C_MODELO, OracleDbType.Varchar2, obj.Modelo, System.Data.ParameterDirection.Input);
            cmd.Parameters.Add(AC_Medidor.C_PRECISION, OracleDbType.Decimal, obj.Precision, System.Data.ParameterDirection.Input);
            cmd.Parameters.Add(AC_Medidor.C_D_COD_ESTADO, OracleDbType.Varchar2, obj.DCodEstado, System.Data.ParameterDirection.Input);
            cmd.Parameters.Add(AC_Medidor.C_SEC_LOG, OracleDbType.Int64, obj.SecLog, System.Data.ParameterDirection.Input);
            cmd.Parameters.Add(AC_Medidor.C_PRIME_NOINS, OracleDbType.Varchar2, obj.PrimeNoins, System.Data.ParameterDirection.Input);
            cmd.Parameters.Add(AC_Medidor.C_MEDIDOR_REEMPLAZADO, OracleDbType.Decimal, obj.MedidorReemplazado, System.Data.ParameterDirection.Input);
            cmd.Parameters.Add(AC_Medidor.C_PRIORIDAD, OracleDbType.Decimal, obj.Prioridad, System.Data.ParameterDirection.Input);
            cmd.Parameters.Add(AC_Medidor.C_REAL_VIRTUAL, OracleDbType.Int16, obj.RealVirtual, System.Data.ParameterDirection.Input);
            cmd.Parameters.Add(AC_Medidor.C_FK_COD_PROPIETARIO, OracleDbType.Int64, obj.FkCodPropietario, System.Data.ParameterDirection.Input);
            cmd.Parameters.Add(AC_Medidor.C_NOMBRE, OracleDbType.Varchar2, obj.Nombre, System.Data.ParameterDirection.Input);
            cmd.Parameters.Add(AC_Medidor.C_DESCRIPCION, OracleDbType.Varchar2, obj.Descripcion, System.Data.ParameterDirection.Input);
            cmd.Parameters.Add(AC_Medidor.C_FECHA_INGRESO, OracleDbType.Date, obj.FechaIngreso, System.Data.ParameterDirection.Input);
            cmd.Parameters.Add(AC_Medidor.C_FECHA_SALIDA, OracleDbType.Date, obj.FechaSalida, System.Data.ParameterDirection.Input);

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
            DataTable tabla = GetTabla(AC_Medidor.NOMBRE_TABLA);
            return tabla;
        }

        public BindingList<AC_Medidor> GetLista()
        {
            BindingList<AC_Medidor> resultado = new BindingList<AC_Medidor>();
            DataTable tablaAgentes = GetTabla();
            foreach (DataRow row in tablaAgentes.Rows)
            {
                resultado.Add(new AC_Medidor(row));
            }
            return resultado;
        }

        public AC_Medidor GetPorNombre(string nombreMedidor)
        {
            AC_Medidor resultado = null;
            string sql = "SELECT * FROM f_ac_medidor WHERE nombre_med=:nombre";
            OracleCommand cmd = CrearCommand();
            cmd.CommandText = sql;
            cmd.BindByName = true;
            cmd.Parameters.Add(AC_Medidor.C_NOMBRE, OracleDbType.Varchar2, nombreMedidor, System.Data.ParameterDirection.Input);

            DataTable tabla = EjecutarCmd(cmd);
            if (tabla.Rows.Count > 0)
            {
                resultado = new AC_Medidor(tabla.Rows[0]);
            }

            return resultado;
        }
    }
}