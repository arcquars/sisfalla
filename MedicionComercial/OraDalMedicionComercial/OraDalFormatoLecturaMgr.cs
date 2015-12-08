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
    public class OraDalFormatoLecturaMgr : OraDalBaseMgr, IFormatoLecturaMgr
    {
        #region Singleton
        private static OraDalFormatoLecturaMgr _instancia;
        static OraDalFormatoLecturaMgr()
        {
            _instancia = new OraDalFormatoLecturaMgr();
        }
        public static OraDalFormatoLecturaMgr Instancia
        {
            get { return _instancia; }
        }

        private OraDalFormatoLecturaMgr()
        {

        }
        #endregion Singleton

        public void Guardar(FormatoLectura obj)
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
                "{2}=:{2} ," +
                "{3}=:{3} ," +
                "{4}=:{4} ," +
                "{5}=:{5} ," +
                "{6}=:{6} ," +
                "{7}=:{7} ," +
                "{8}=:{8}  WHERE {1}=:{1}";
            }

            sql = string.Format(sql, FormatoLectura.NOMBRE_TABLA, FormatoLectura.C_PK_COD_FTO,
            FormatoLectura.C_DESCRIPCION_FTO,
            FormatoLectura.C_EXTENSION,
            FormatoLectura.C_VERSION,
            FormatoLectura.C_DLL_LECTOR,
            FormatoLectura.C_D_COD_ESTADO,
            FormatoLectura.C_SEC_LOG,
            FormatoLectura.C_CLASE_LECTOR);
            cmd = CrearCommand();
            cmd.CommandText = sql;
            cmd.BindByName = true;
            cmd.Parameters.Add(FormatoLectura.C_PK_COD_FTO, OracleDbType.Int64, obj.PkCodFto, ParameterDirection.Input);
            cmd.Parameters.Add(FormatoLectura.C_DESCRIPCION_FTO, OracleDbType.Varchar2, obj.DescripcionFto, ParameterDirection.Input);
            cmd.Parameters.Add(FormatoLectura.C_EXTENSION, OracleDbType.Varchar2, obj.Extension, ParameterDirection.Input);
            cmd.Parameters.Add(FormatoLectura.C_VERSION, OracleDbType.Int16, obj.Version, ParameterDirection.Input);
            cmd.Parameters.Add(FormatoLectura.C_DLL_LECTOR, OracleDbType.Varchar2, obj.DllLector, ParameterDirection.Input);
            cmd.Parameters.Add(FormatoLectura.C_D_COD_ESTADO, OracleDbType.Varchar2, obj.DCodEstado, ParameterDirection.Input);
            cmd.Parameters.Add(FormatoLectura.C_SEC_LOG, OracleDbType.Int64, obj.SecLog, ParameterDirection.Input);
            cmd.Parameters.Add(FormatoLectura.C_CLASE_LECTOR, OracleDbType.Varchar2, obj.ClaseLector, ParameterDirection.Input);

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
            DataTable tabla = GetTabla(FormatoLectura.NOMBRE_TABLA);
            return tabla;
        }

        public BindingList<FormatoLectura> GetLista()
        {
            BindingList<FormatoLectura> resultado = new BindingList<FormatoLectura>();
            DataTable tablaAgentes = GetTabla();
            foreach (DataRow row in tablaAgentes.Rows)
            {
                resultado.Add(new FormatoLectura(row));
            }
            return resultado;
        }
    }
}