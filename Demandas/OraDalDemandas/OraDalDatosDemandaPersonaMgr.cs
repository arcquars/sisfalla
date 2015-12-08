using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.ComponentModel;
using CNDC.BLL;
using ModeloDemandas;
using Oracle.DataAccess.Client;
using CNDC.Pistas;

namespace OraDalDemandas
{
    public class OraDalDatosDemandaPersonaMgr : OraDalBaseMgr, IDatosDemandaPersonaMgr
    {
        #region Singleton
        private static OraDalDatosDemandaPersonaMgr _instancia;
        static OraDalDatosDemandaPersonaMgr()
        {
            _instancia = new OraDalDatosDemandaPersonaMgr();
        }
        public static OraDalDatosDemandaPersonaMgr Instancia
        {
            get { return _instancia; }
        }

        private OraDalDatosDemandaPersonaMgr()
        {

        }
        #endregion Singleton

        public override string NombreTabla
        {
            get
            {
                return DatosDemandaPersona.NOMBRE_TABLA;
            }
        }

        public void Guardar(DatosDemandaPersona obj)
        {
            OracleCommand cmd = null;
            string sql = string.Empty;
            if (obj.EsNuevo)
            {
                Pista p = PistaMgr.Instance.Info("Demandas", obj.GetEstadoString());
                obj.PkDatosDemadaPersona = GetIdAutoNum("SQ_F_FM_DATOS_DEMADA_PERSONA");
                obj.SecLog = (long)p.PK_SecLog;
                sql = "INSERT INTO {0} ({1},{2},{3},{4},{5},{6},{7},{8},{9},{10},{11},{12},{13},{14},{15},{16},{17})" +
                "VALUES(:{1},:{2},:{3},:{4},:{5},:{6},:{7},:{8},:{9},:{10},:{11},:{12},:{13},:{14},:{15},:{16},:{17})";
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
                "{15}=:{15} ," +
                "{16}=:{16} ," +
                "{17}=:{17}  WHERE {1}=:{1} ";
            }

            sql = string.Format(sql, DatosDemandaPersona.NOMBRE_TABLA, DatosDemandaPersona.C_PK_DATOS_DEMADA_PERSONA,
            DatosDemandaPersona.C_FK_PERSONA,
            DatosDemandaPersona.C_D_COD_CATEGORIA_DATO,
            DatosDemandaPersona.C_ANIO,
            DatosDemandaPersona.C_ENERO,
            DatosDemandaPersona.C_FEBRERO,
            DatosDemandaPersona.C_MARZO,
            DatosDemandaPersona.C_ABRIL,
            DatosDemandaPersona.C_MAYO,
            DatosDemandaPersona.C_JUNIO,
            DatosDemandaPersona.C_JULIO,
            DatosDemandaPersona.C_AGOSTO,
            DatosDemandaPersona.C_SEPTIEMBRE,
            DatosDemandaPersona.C_OCTUBRE,
            DatosDemandaPersona.C_NOVIEMBRE,
            DatosDemandaPersona.C_DICIEMBRE,
            DatosDemandaPersona.C_SEC_LOG);
            cmd = CrearCommand();
            cmd.CommandText = sql;
            cmd.BindByName = true;
            cmd.Parameters.Add(DatosDemandaPersona.C_PK_DATOS_DEMADA_PERSONA, OracleDbType.Int64, obj.PkDatosDemadaPersona, System.Data.ParameterDirection.Input);
            cmd.Parameters.Add(DatosDemandaPersona.C_FK_PERSONA, OracleDbType.Int64, obj.FkPersona, System.Data.ParameterDirection.Input);
            cmd.Parameters.Add(DatosDemandaPersona.C_D_COD_CATEGORIA_DATO, OracleDbType.Int64, obj.DCodCategoriaDato, System.Data.ParameterDirection.Input);
            cmd.Parameters.Add(DatosDemandaPersona.C_ANIO, OracleDbType.Int32, obj.Anio, System.Data.ParameterDirection.Input);
            cmd.Parameters.Add(DatosDemandaPersona.C_ENERO, OracleDbType.Double, obj.Enero, System.Data.ParameterDirection.Input);
            cmd.Parameters.Add(DatosDemandaPersona.C_FEBRERO, OracleDbType.Double, obj.Febrero, System.Data.ParameterDirection.Input);
            cmd.Parameters.Add(DatosDemandaPersona.C_MARZO, OracleDbType.Double, obj.Marzo, System.Data.ParameterDirection.Input);
            cmd.Parameters.Add(DatosDemandaPersona.C_ABRIL, OracleDbType.Double, obj.Abril, System.Data.ParameterDirection.Input);
            cmd.Parameters.Add(DatosDemandaPersona.C_MAYO, OracleDbType.Double, obj.Mayo, System.Data.ParameterDirection.Input);
            cmd.Parameters.Add(DatosDemandaPersona.C_JUNIO, OracleDbType.Double, obj.Junio, System.Data.ParameterDirection.Input);
            cmd.Parameters.Add(DatosDemandaPersona.C_JULIO, OracleDbType.Double, obj.Julio, System.Data.ParameterDirection.Input);
            cmd.Parameters.Add(DatosDemandaPersona.C_AGOSTO, OracleDbType.Double, obj.Agosto, System.Data.ParameterDirection.Input);
            cmd.Parameters.Add(DatosDemandaPersona.C_SEPTIEMBRE, OracleDbType.Double, obj.Septiembre, System.Data.ParameterDirection.Input);
            cmd.Parameters.Add(DatosDemandaPersona.C_OCTUBRE, OracleDbType.Double, obj.Octubre, System.Data.ParameterDirection.Input);
            cmd.Parameters.Add(DatosDemandaPersona.C_NOVIEMBRE, OracleDbType.Double, obj.Noviembre, System.Data.ParameterDirection.Input);
            cmd.Parameters.Add(DatosDemandaPersona.C_DICIEMBRE, OracleDbType.Double, obj.Diciembre, System.Data.ParameterDirection.Input);
            cmd.Parameters.Add(DatosDemandaPersona.C_SEC_LOG, OracleDbType.Int64, obj.SecLog, System.Data.ParameterDirection.Input);


            if (Actualizar(cmd))
            {
                obj.EsNuevo = false;
            }
        }
        public DataTable GetTabla()
        {
            DataTable tabla = GetTabla(DatosDemandaPersona.NOMBRE_TABLA);
            return tabla;
        }

        public BindingList<DatosDemandaPersona> GetLista()
        {
            BindingList<DatosDemandaPersona> resultado = new BindingList<DatosDemandaPersona>();
            DataTable tablaAgentes = GetTabla();
            foreach (DataRow row in tablaAgentes.Rows)
            {
                resultado.Add(new DatosDemandaPersona(row));
            }
            return resultado;
        }

        public void GuardarDemandaPersona(DataTable tabla, long pkPersona, long pkCategoriaDato)
        {
            OracleCommand cmd = null;
            PonerIds(tabla);
            string sql = "";
            sql = "INSERT INTO {0} ({1},{2},{3},{4},{5},{6},{7},{8},{9},{10},{11},{12},{13},{14},{15},{16},{17})" +
                 "VALUES(:{1},:{2},:{3},:{4},:{5},:{6},:{7},:{8},:{9},:{10},:{11},:{12},:{13},:{14},:{15},:{16},:{17})";

            sql = string.Format(sql, DatosDemandaPersona.NOMBRE_TABLA, DatosDemandaPersona.C_PK_DATOS_DEMADA_PERSONA,
           DatosDemandaPersona.C_FK_PERSONA,
           DatosDemandaPersona.C_D_COD_CATEGORIA_DATO,
           DatosDemandaPersona.C_ANIO,
           DatosDemandaPersona.C_ENERO,
           DatosDemandaPersona.C_FEBRERO,
           DatosDemandaPersona.C_MARZO,
           DatosDemandaPersona.C_ABRIL,
           DatosDemandaPersona.C_MAYO,
           DatosDemandaPersona.C_JUNIO,
           DatosDemandaPersona.C_JULIO,
           DatosDemandaPersona.C_AGOSTO,
           DatosDemandaPersona.C_SEPTIEMBRE,
           DatosDemandaPersona.C_OCTUBRE,
           DatosDemandaPersona.C_NOVIEMBRE,
           DatosDemandaPersona.C_DICIEMBRE,
           DatosDemandaPersona.C_SEC_LOG);
            cmd = CrearCommand();
            cmd.CommandText = sql;
            cmd.BindByName = true;
            cmd.ArrayBindCount = tabla.Rows.Count;
            cmd.Parameters.Add(DatosDemandaPersona.C_PK_DATOS_DEMADA_PERSONA, OracleDbType.Int64, GetArray(tabla, 0), ParameterDirection.Input);
            cmd.Parameters.Add(DatosDemandaPersona.C_FK_PERSONA, OracleDbType.Int64, GetArray(tabla, -1, pkPersona), ParameterDirection.Input);
            cmd.Parameters.Add(DatosDemandaPersona.C_D_COD_CATEGORIA_DATO, OracleDbType.Int64, GetArray(tabla, -1, pkCategoriaDato), ParameterDirection.Input);
            cmd.Parameters.Add(DatosDemandaPersona.C_ANIO, OracleDbType.Int32, GetArray(tabla, 1), ParameterDirection.Input);
            cmd.Parameters.Add(DatosDemandaPersona.C_ENERO, OracleDbType.Double, GetArray(tabla, 2), ParameterDirection.Input);
            cmd.Parameters.Add(DatosDemandaPersona.C_FEBRERO, OracleDbType.Double, GetArray(tabla, 3), ParameterDirection.Input);
            cmd.Parameters.Add(DatosDemandaPersona.C_MARZO, OracleDbType.Double, GetArray(tabla, 4), ParameterDirection.Input);
            cmd.Parameters.Add(DatosDemandaPersona.C_ABRIL, OracleDbType.Double, GetArray(tabla, 5), ParameterDirection.Input);
            cmd.Parameters.Add(DatosDemandaPersona.C_MAYO, OracleDbType.Double,GetArray(tabla, 6), ParameterDirection.Input);
            cmd.Parameters.Add(DatosDemandaPersona.C_JUNIO, OracleDbType.Double, GetArray(tabla, 7), ParameterDirection.Input);
            cmd.Parameters.Add(DatosDemandaPersona.C_JULIO, OracleDbType.Double, GetArray(tabla,8), ParameterDirection.Input);
            cmd.Parameters.Add(DatosDemandaPersona.C_AGOSTO, OracleDbType.Double, GetArray(tabla, 9), ParameterDirection.Input);
            cmd.Parameters.Add(DatosDemandaPersona.C_SEPTIEMBRE, OracleDbType.Double, GetArray(tabla, 10), ParameterDirection.Input);
            cmd.Parameters.Add(DatosDemandaPersona.C_OCTUBRE, OracleDbType.Double, GetArray(tabla, 11), ParameterDirection.Input);
            cmd.Parameters.Add(DatosDemandaPersona.C_NOVIEMBRE, OracleDbType.Double, GetArray(tabla, 12), ParameterDirection.Input);
            cmd.Parameters.Add(DatosDemandaPersona.C_DICIEMBRE, OracleDbType.Double, GetArray(tabla, 13), ParameterDirection.Input);
            cmd.Parameters.Add(DatosDemandaPersona.C_SEC_LOG, OracleDbType.Int64, GetArray(tabla, 17), ParameterDirection.Input);
            Actualizar(cmd);
        }

        private void PonerIds(DataTable t)
        {
            foreach (DataRow r in t.Rows)
            {
                r[0] = GetIdAutoNum("SQ_F_DM_DATOS_DEMADA_NODO");
            }
        }

        private Array GetArray(DataTable tabla, int campo)
        {
            return GetArray(tabla, campo, null);
        }

        private Array GetArray(DataTable tabla, int campo, object valorDefecto)
        {
            object[] resultado = new object[tabla.Rows.Count];

            for (int i = 0; i < tabla.Rows.Count; i++)
            {
                if (campo >= 0 && campo < tabla.Rows[i].Table.Columns.Count)
                {
                    resultado[i] = tabla.Rows[i][campo];
                }
                else
                {
                    resultado[i] = valorDefecto;
                }
            }
            return resultado;
        }

        public DataTable GetDatos(long pkPersona, long codTipoDato)
        {
            string sql = "SELECT * FROM {0} WHERE {1}={2} AND {3}={4} order by anio";
            sql = string.Format(sql, DatosDemandaPersona.NOMBRE_TABLA, DatosDemandaPersona.C_FK_PERSONA, pkPersona, DatosDemandaPersona.C_D_COD_CATEGORIA_DATO,codTipoDato);
            DataTable tabla = EjecutarSql(sql);
            return tabla;
        }

        public void EliminarDatosPersona(long pkPersona, long pkTipoTabla)
        {
            string sql = "delete from {0} where {1}={2} and {3}={4} ";
            sql = string.Format(sql, NombreTabla, DatosDemandaPersona.C_FK_PERSONA, pkPersona, DatosDemandaPersona.C_D_COD_CATEGORIA_DATO, pkTipoTabla);
            OracleCommand cmd = CrearCommand();
            cmd.CommandText = sql;
            bool res = Actualizar(cmd);
        }

        public void EliminarDatosPersona(long pkDato)
        {
            string sql = "delete from {0} where {1}={2} ";
            sql = string.Format(sql, NombreTabla, DatosDemandaPersona.C_PK_DATOS_DEMADA_PERSONA,pkDato);
            OracleCommand cmd = CrearCommand();
            cmd.CommandText = sql;
            bool res = Actualizar(cmd);
        }

        public void EliminarTablaDatosPersonaNodo(long pkPersona, long pkTipoTabla)
        {
            string sql = "delete from {0} where {1}={2} and {3}={4} ";
            sql = string.Format(sql, NombreTabla, DatosDemandaPersona.C_FK_PERSONA, pkPersona, DatosDemandaPersona.C_D_COD_CATEGORIA_DATO, pkTipoTabla);
            OracleCommand cmd = CrearCommand();
            cmd.CommandText = sql;
            bool res = Actualizar(cmd);
        }
    }
}
