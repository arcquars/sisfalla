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
    public class OraDalDatosBloquesMgr : OraDalBaseMgr, IDatosBloquesMgr
    {
        #region Singleton
        private static OraDalDatosBloquesMgr _instancia;
        static OraDalDatosBloquesMgr()
        {
            _instancia = new OraDalDatosBloquesMgr();
        }
        public static OraDalDatosBloquesMgr Instancia
        {
            get { return _instancia; }
        }

        private OraDalDatosBloquesMgr()
        {

        }
        #endregion Singleton
        public override string NombreTabla
        {
            get
            {
                return DatosBloques.NOMBRE_TABLA;
            }
        }
        public void Guardar(DatosBloques obj)
        {
            OracleCommand cmd = null;
            string sql = string.Empty;
            if (obj.EsNuevo)
            {
                Pista p = PistaMgr.Instance.Info("DALSisFalla", obj.GetEstadoString());
                obj.SecLog = (long)p.PK_SecLog;
                sql = "INSERT INTO {0} ({1},{2},{3},{4},{5},{6},{7},{8},{9},{10},{11},{12},{13},{14},{15},{16})" +
                "VALUES(:{1},:{2},:{3},:{4},:{5},:{6},:{7},:{8},:{9},:{10},:{11},:{12},:{13},:{14},:{15},:{16})";
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
                "{16}=:{16}  WHERE {1}=:{1} ";
            }

            sql = string.Format(sql, DatosBloques.NOMBRE_TABLA, DatosBloques.C_PK_DATOS_BLOQUE_PRINCIPAL,
            DatosBloques.C_ANIO,
            DatosBloques.C_NUMERO_BLOQUE_POR_ANIO,
            DatosBloques.C_ENERO,
            DatosBloques.C_FEBRERO,
            DatosBloques.C_MARZO,
            DatosBloques.C_ABRIL,
            DatosBloques.C_MAYO,
            DatosBloques.C_JUNIO,
            DatosBloques.C_JULIO,
            DatosBloques.C_AGOSTO,
            DatosBloques.C_SEPTIEMBRE,
            DatosBloques.C_OCTUBRE,
            DatosBloques.C_NOVIEMBRE,
            DatosBloques.C_DICIEMBRE,
            DatosBloques.C_SEC_LOG);
            cmd = CrearCommand();
            cmd.CommandText = sql;
            cmd.BindByName = true;
            cmd.Parameters.Add(DatosBloques.C_PK_DATOS_BLOQUE_PRINCIPAL, OracleDbType.Int64, obj.PkDatosBloquePrincipal, System.Data.ParameterDirection.Input);
            cmd.Parameters.Add(DatosBloques.C_ANIO, OracleDbType.Int32, obj.Anio, System.Data.ParameterDirection.Input);
            cmd.Parameters.Add(DatosBloques.C_NUMERO_BLOQUE_POR_ANIO, OracleDbType.Int16, obj.NumeroBloquePorAnio, System.Data.ParameterDirection.Input);
            cmd.Parameters.Add(DatosBloques.C_ENERO, OracleDbType.Decimal, obj.Enero, System.Data.ParameterDirection.Input);
            cmd.Parameters.Add(DatosBloques.C_FEBRERO, OracleDbType.Decimal, obj.Febrero, System.Data.ParameterDirection.Input);
            cmd.Parameters.Add(DatosBloques.C_MARZO, OracleDbType.Decimal, obj.Marzo, System.Data.ParameterDirection.Input);
            cmd.Parameters.Add(DatosBloques.C_ABRIL, OracleDbType.Decimal, obj.Abril, System.Data.ParameterDirection.Input);
            cmd.Parameters.Add(DatosBloques.C_MAYO, OracleDbType.Decimal, obj.Mayo, System.Data.ParameterDirection.Input);
            cmd.Parameters.Add(DatosBloques.C_JUNIO, OracleDbType.Decimal, obj.Junio, System.Data.ParameterDirection.Input);
            cmd.Parameters.Add(DatosBloques.C_JULIO, OracleDbType.Decimal, obj.Julio, System.Data.ParameterDirection.Input);
            cmd.Parameters.Add(DatosBloques.C_AGOSTO, OracleDbType.Decimal, obj.Agosto, System.Data.ParameterDirection.Input);
            cmd.Parameters.Add(DatosBloques.C_SEPTIEMBRE, OracleDbType.Decimal, obj.Septiembre, System.Data.ParameterDirection.Input);
            cmd.Parameters.Add(DatosBloques.C_OCTUBRE, OracleDbType.Decimal, obj.Octubre, System.Data.ParameterDirection.Input);
            cmd.Parameters.Add(DatosBloques.C_NOVIEMBRE, OracleDbType.Decimal, obj.Noviembre, System.Data.ParameterDirection.Input);
            cmd.Parameters.Add(DatosBloques.C_DICIEMBRE, OracleDbType.Decimal, obj.Diciembre, System.Data.ParameterDirection.Input);
            cmd.Parameters.Add(DatosBloques.C_SEC_LOG, OracleDbType.Int64, obj.SecLog, System.Data.ParameterDirection.Input);

            if (Actualizar(cmd))
            {
                obj.EsNuevo = false;
            }
        }
        public DataTable GetTabla()
        {
            DataTable tabla = GetTabla(DatosBloques.NOMBRE_TABLA);
            return tabla;
        }

        public BindingList<DatosBloques> GetLista()
        {
            BindingList<DatosBloques> resultado = new BindingList<DatosBloques>();
            DataTable tablaAgentes = GetTabla();
            foreach (DataRow row in tablaAgentes.Rows)
            {
                resultado.Add(new DatosBloques(row));
            }
            return resultado;
        }

        public DataTable GetDatos()
        {
            string sql = "select * from {0} order by {1}";
            sql = string.Format(sql, DatosBloques.NOMBRE_TABLA, DatosBloques.C_PK_DATOS_BLOQUE_PRINCIPAL);
            DataTable tabla = EjecutarSql(sql);
            return tabla;
        }

        public void GuardarTablaBloque(DataTable tabla)
        {
            OracleCommand cmd = null;
            PonerIds(tabla);
            string  sql = "INSERT INTO {0} ({1},{2},{3},{4},{5},{6},{7},{8},{9},{10},{11},{12},{13},{14},{15},{16})" +
                "VALUES(:{1},:{2},:{3},:{4},:{5},:{6},:{7},:{8},:{9},:{10},:{11},:{12},:{13},:{14},:{15},:{16})";
         

            sql = string.Format(sql, DatosBloques.NOMBRE_TABLA, DatosBloques.C_PK_DATOS_BLOQUE_PRINCIPAL,
            DatosBloques.C_ANIO,
            DatosBloques.C_NUMERO_BLOQUE_POR_ANIO,
            DatosBloques.C_ENERO,
            DatosBloques.C_FEBRERO,
            DatosBloques.C_MARZO,
            DatosBloques.C_ABRIL,
            DatosBloques.C_MAYO,
            DatosBloques.C_JUNIO,
            DatosBloques.C_JULIO,
            DatosBloques.C_AGOSTO,
            DatosBloques.C_SEPTIEMBRE,
            DatosBloques.C_OCTUBRE,
            DatosBloques.C_NOVIEMBRE,
            DatosBloques.C_DICIEMBRE,
            DatosBloques.C_SEC_LOG);
           cmd = CrearCommand();
            cmd.CommandText = sql;
            cmd.BindByName = true;
            cmd.ArrayBindCount = tabla.Rows.Count;
            cmd.Parameters.Add(DatosBloques.C_PK_DATOS_BLOQUE_PRINCIPAL,OracleDbType.Int64, GetArray(tabla, 0), System.Data.ParameterDirection.Input);
            cmd.Parameters.Add(DatosBloques.C_ANIO, OracleDbType.Int32, GetArray(tabla, 1), System.Data.ParameterDirection.Input);
            cmd.Parameters.Add(DatosBloques.C_NUMERO_BLOQUE_POR_ANIO, OracleDbType.Int32,GetArray(tabla, 2),  System.Data.ParameterDirection.Input);
            cmd.Parameters.Add(DatosBloques.C_ENERO, OracleDbType.Decimal, GetArray(tabla, 3), System.Data.ParameterDirection.Input);
            cmd.Parameters.Add(DatosBloques.C_FEBRERO, OracleDbType.Decimal, GetArray(tabla, 4), System.Data.ParameterDirection.Input);
            cmd.Parameters.Add(DatosBloques.C_MARZO, OracleDbType.Decimal, GetArray(tabla, 5), System.Data.ParameterDirection.Input);
            cmd.Parameters.Add(DatosBloques.C_ABRIL, OracleDbType.Decimal, GetArray(tabla, 6), System.Data.ParameterDirection.Input);
            cmd.Parameters.Add(DatosBloques.C_MAYO, OracleDbType.Decimal, GetArray(tabla, 7), System.Data.ParameterDirection.Input);
            cmd.Parameters.Add(DatosBloques.C_JUNIO, OracleDbType.Decimal, GetArray(tabla, 8), System.Data.ParameterDirection.Input);
            cmd.Parameters.Add(DatosBloques.C_JULIO, OracleDbType.Decimal, GetArray(tabla, 9), System.Data.ParameterDirection.Input);
            cmd.Parameters.Add(DatosBloques.C_AGOSTO, OracleDbType.Decimal,GetArray(tabla, 10), System.Data.ParameterDirection.Input);
            cmd.Parameters.Add(DatosBloques.C_SEPTIEMBRE, OracleDbType.Decimal, GetArray(tabla, 11), System.Data.ParameterDirection.Input);
            cmd.Parameters.Add(DatosBloques.C_OCTUBRE, OracleDbType.Decimal, GetArray(tabla, 12), System.Data.ParameterDirection.Input);
            cmd.Parameters.Add(DatosBloques.C_NOVIEMBRE, OracleDbType.Decimal, GetArray(tabla, 13), System.Data.ParameterDirection.Input);
            cmd.Parameters.Add(DatosBloques.C_DICIEMBRE, OracleDbType.Decimal, GetArray(tabla, 14), System.Data.ParameterDirection.Input);
            cmd.Parameters.Add(DatosBloques.C_SEC_LOG, OracleDbType.Int64, GetArray(tabla, 31), System.Data.ParameterDirection.Input);

            Actualizar(cmd);
        }

        private void PonerIds(DataTable t)
        {
            foreach (DataRow r in t.Rows)
            {
                r[0] = GetIdAutoNum("SQ_F_DM_DATOS_BLOQUE_PRINCIPAL");
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

        public void EliminarDatos()
        {
            string sql = "delete * from {0} ";
            sql = string.Format(sql, DatosBloques.NOMBRE_TABLA);
            OracleCommand cmd = CrearCommand();
            cmd.CommandText = sql;
            bool res = Actualizar(cmd);
        }
    }
}
