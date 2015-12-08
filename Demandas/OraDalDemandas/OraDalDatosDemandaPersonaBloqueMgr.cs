using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.ComponentModel;
using CNDC.BLL;
using Oracle.DataAccess.Client;
using ModeloDemandas;
using CNDC.Pistas;

namespace OraDalDemandas
{
    public class OraDalDatosDemandaPersonaBloqueMgr : OraDalBaseMgr, IDatosDemandaPersonaBloqueMgr
    {
        #region Singleton
        private static OraDalDatosDemandaPersonaBloqueMgr _instancia;
        static OraDalDatosDemandaPersonaBloqueMgr()
        {
            _instancia = new OraDalDatosDemandaPersonaBloqueMgr();
        }
        public static OraDalDatosDemandaPersonaBloqueMgr Instancia
        {
            get { return _instancia; }
        }

        private OraDalDatosDemandaPersonaBloqueMgr()
        {

        }
        #endregion Singleton
        public override string NombreTabla
        {
            get
            {
                return DatosDemandaPersonaBloque.NOMBRE_TABLA;
            }
        }
        public void Guardar(DatosDemandaPersonaBloque obj)
        {
            OracleCommand cmd = null;
            string sql = string.Empty;
            if (obj.EsNuevo)
            {
                Pista p = PistaMgr.Instance.Info("Demandas", obj.GetEstadoString());
                obj.SecLog = (long)p.PK_SecLog;
                obj.PkDatosDemPersonaBolque = GetIdAutoNum("SQ_DATOS_DEM_PERSONA_BOLQUE");
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

            sql = string.Format(sql, DatosDemandaPersonaBloque.NOMBRE_TABLA, DatosDemandaPersonaBloque.C_PK_DATOS_DEM_PERSONA_BOLQUE,
            DatosDemandaPersonaBloque.C_ANIO,
            DatosDemandaPersonaBloque.C_NUMERO_POR_ANIO,
            DatosDemandaPersonaBloque.C_ENERO,
            DatosDemandaPersonaBloque.C_FEBRERO,
            DatosDemandaPersonaBloque.C_MARZO,
            DatosDemandaPersonaBloque.C_ABRIL,
            DatosDemandaPersonaBloque.C_MAYO,
            DatosDemandaPersonaBloque.C_JUNIO,
            DatosDemandaPersonaBloque.C_JULIO,
            DatosDemandaPersonaBloque.C_AGOSTO,
            DatosDemandaPersonaBloque.C_SEPTIEMBRE,
            DatosDemandaPersonaBloque.C_OCTUBRE,
            DatosDemandaPersonaBloque.C_NOVIEMBRE,
            DatosDemandaPersonaBloque.C_DICIEMBRE,
            DatosDemandaPersonaBloque.C_FK_PERSONA,
            DatosDemandaPersonaBloque.C_SEC_LOG);
            cmd = CrearCommand();
            cmd.CommandText = sql;
            cmd.BindByName = true;
            cmd.Parameters.Add(DatosDemandaPersonaBloque.C_PK_DATOS_DEM_PERSONA_BOLQUE, OracleDbType.Int64, obj.PkDatosDemPersonaBolque, System.Data.ParameterDirection.Input);
            cmd.Parameters.Add(DatosDemandaPersonaBloque.C_ANIO, OracleDbType.Int32, obj.Anio, System.Data.ParameterDirection.Input);
            cmd.Parameters.Add(DatosDemandaPersonaBloque.C_NUMERO_POR_ANIO, OracleDbType.Int16, obj.NumeroPorAnio, System.Data.ParameterDirection.Input);
            cmd.Parameters.Add(DatosDemandaPersonaBloque.C_ENERO, OracleDbType.Decimal, obj.Enero, System.Data.ParameterDirection.Input);
            cmd.Parameters.Add(DatosDemandaPersonaBloque.C_FEBRERO, OracleDbType.Decimal, obj.Febrero, System.Data.ParameterDirection.Input);
            cmd.Parameters.Add(DatosDemandaPersonaBloque.C_MARZO, OracleDbType.Decimal, obj.Marzo, System.Data.ParameterDirection.Input);
            cmd.Parameters.Add(DatosDemandaPersonaBloque.C_ABRIL, OracleDbType.Decimal, obj.Abril, System.Data.ParameterDirection.Input);
            cmd.Parameters.Add(DatosDemandaPersonaBloque.C_MAYO, OracleDbType.Decimal, obj.Mayo, System.Data.ParameterDirection.Input);
            cmd.Parameters.Add(DatosDemandaPersonaBloque.C_JUNIO, OracleDbType.Decimal, obj.Junio, System.Data.ParameterDirection.Input);
            cmd.Parameters.Add(DatosDemandaPersonaBloque.C_JULIO, OracleDbType.Decimal, obj.Julio, System.Data.ParameterDirection.Input);
            cmd.Parameters.Add(DatosDemandaPersonaBloque.C_AGOSTO, OracleDbType.Decimal, obj.Agosto, System.Data.ParameterDirection.Input);
            cmd.Parameters.Add(DatosDemandaPersonaBloque.C_SEPTIEMBRE, OracleDbType.Decimal, obj.Septiembre, System.Data.ParameterDirection.Input);
            cmd.Parameters.Add(DatosDemandaPersonaBloque.C_OCTUBRE, OracleDbType.Decimal, obj.Octubre, System.Data.ParameterDirection.Input);
            cmd.Parameters.Add(DatosDemandaPersonaBloque.C_NOVIEMBRE, OracleDbType.Decimal, obj.Noviembre, System.Data.ParameterDirection.Input);
            cmd.Parameters.Add(DatosDemandaPersonaBloque.C_DICIEMBRE, OracleDbType.Decimal, obj.Diciembre, System.Data.ParameterDirection.Input);
            cmd.Parameters.Add(DatosDemandaPersonaBloque.C_FK_PERSONA, OracleDbType.Int64, obj.FkPersona, System.Data.ParameterDirection.Input);
            cmd.Parameters.Add(DatosDemandaPersonaBloque.C_SEC_LOG, OracleDbType.Int64, obj.SecLog, System.Data.ParameterDirection.Input);

            if (Actualizar(cmd))
            {
                obj.EsNuevo = false;
            }
        }
        public DataTable GetTabla()
        {
            DataTable tabla = GetTabla(DatosDemandaPersonaBloque.NOMBRE_TABLA);
            return tabla;
        }

        public BindingList<DatosDemandaPersonaBloque> GetLista()
        {
            BindingList<DatosDemandaPersonaBloque> resultado = new BindingList<DatosDemandaPersonaBloque>();
            DataTable tablaAgentes = GetTabla();
            foreach (DataRow row in tablaAgentes.Rows)
            {
                resultado.Add(new DatosDemandaPersonaBloque(row));
            }
            return resultado;
        }

        public DataTable GetDatos(long pkPersona)
        {
            string sql = "SELECT *  FROM {0} WHERE {1}={2}  order by {3},{4}";
            sql = string.Format(sql, DatosDemandaPersonaBloque.NOMBRE_TABLA, DatosDemandaPersonaBloque.C_FK_PERSONA, pkPersona, DatosDemandaPersonaBloque.C_ANIO, DatosDemandaPersonaBloque.C_NUMERO_POR_ANIO);
            DataTable tabla = EjecutarSql(sql);
            return tabla;
        }

        public void GuardarTablaBloque(DataTable tabla, long pkPersona, long pkCategoriaDato)
        {
            OracleCommand cmd = null;
            PonerIds(tabla);
            DatosDemandaNodoBLoque obj = new DatosDemandaNodoBLoque();
            obj.EsNuevo = true;

            string sql = "";

           sql= "INSERT INTO {0} ({1},{2},{3},{4},{5},{6},{7},{8},{9},{10},{11},{12},{13},{14},{15},{16},{17})" +
                "VALUES(:{1},:{2},:{3},:{4},:{5},:{6},:{7},:{8},:{9},:{10},:{11},:{12},:{13},:{14},:{15},:{16},:{17})";


           sql = string.Format(sql, DatosDemandaPersonaBloque.NOMBRE_TABLA, DatosDemandaPersonaBloque.C_PK_DATOS_DEM_PERSONA_BOLQUE,
            DatosDemandaPersonaBloque.C_ANIO,
            DatosDemandaPersonaBloque.C_NUMERO_POR_ANIO,
            DatosDemandaPersonaBloque.C_ENERO,
            DatosDemandaPersonaBloque.C_FEBRERO,
            DatosDemandaPersonaBloque.C_MARZO,
            DatosDemandaPersonaBloque.C_ABRIL,
            DatosDemandaPersonaBloque.C_MAYO,
            DatosDemandaPersonaBloque.C_JUNIO,
            DatosDemandaPersonaBloque.C_JULIO,
            DatosDemandaPersonaBloque.C_AGOSTO,
            DatosDemandaPersonaBloque.C_SEPTIEMBRE,
            DatosDemandaPersonaBloque.C_OCTUBRE,
            DatosDemandaPersonaBloque.C_NOVIEMBRE,
            DatosDemandaPersonaBloque.C_DICIEMBRE,
            DatosDemandaPersonaBloque.C_FK_PERSONA,
            DatosDemandaPersonaBloque.C_SEC_LOG);
            cmd = CrearCommand();
            cmd.CommandText = sql;
            cmd.BindByName = true;
            cmd.ArrayBindCount = tabla.Rows.Count;
            cmd.Parameters.Add(DatosDemandaPersonaBloque.C_PK_DATOS_DEM_PERSONA_BOLQUE, OracleDbType.Int64, GetArray(tabla, 0), System.Data.ParameterDirection.Input);
            cmd.Parameters.Add(DatosDemandaPersonaBloque.C_ANIO, OracleDbType.Int32, GetArray(tabla, 1), System.Data.ParameterDirection.Input);
            cmd.Parameters.Add(DatosDemandaPersonaBloque.C_NUMERO_POR_ANIO, OracleDbType.Int16, GetArray(tabla, 2), System.Data.ParameterDirection.Input);
            cmd.Parameters.Add(DatosDemandaPersonaBloque.C_ENERO, OracleDbType.Double, GetArray(tabla, 3), System.Data.ParameterDirection.Input);
            cmd.Parameters.Add(DatosDemandaPersonaBloque.C_FEBRERO, OracleDbType.Double, GetArray(tabla, 4), System.Data.ParameterDirection.Input);
            cmd.Parameters.Add(DatosDemandaPersonaBloque.C_MARZO, OracleDbType.Double, GetArray(tabla, 5), System.Data.ParameterDirection.Input);
            cmd.Parameters.Add(DatosDemandaPersonaBloque.C_ABRIL, OracleDbType.Double, GetArray(tabla, 6), System.Data.ParameterDirection.Input);
            cmd.Parameters.Add(DatosDemandaPersonaBloque.C_MAYO, OracleDbType.Double, GetArray(tabla, 7), System.Data.ParameterDirection.Input);
            cmd.Parameters.Add(DatosDemandaPersonaBloque.C_JUNIO, OracleDbType.Double, GetArray(tabla, 8), System.Data.ParameterDirection.Input);
            cmd.Parameters.Add(DatosDemandaPersonaBloque.C_JULIO, OracleDbType.Double, GetArray(tabla, 9), System.Data.ParameterDirection.Input);
            cmd.Parameters.Add(DatosDemandaPersonaBloque.C_AGOSTO, OracleDbType.Double, GetArray(tabla, 10), System.Data.ParameterDirection.Input);
            cmd.Parameters.Add(DatosDemandaPersonaBloque.C_SEPTIEMBRE, OracleDbType.Double, GetArray(tabla, 11), System.Data.ParameterDirection.Input);
            cmd.Parameters.Add(DatosDemandaPersonaBloque.C_OCTUBRE, OracleDbType.Double, GetArray(tabla, 12), System.Data.ParameterDirection.Input);
            cmd.Parameters.Add(DatosDemandaPersonaBloque.C_NOVIEMBRE, OracleDbType.Double, GetArray(tabla, 13), System.Data.ParameterDirection.Input);
            cmd.Parameters.Add(DatosDemandaPersonaBloque.C_DICIEMBRE, OracleDbType.Double, GetArray(tabla, 14), System.Data.ParameterDirection.Input);
            cmd.Parameters.Add(DatosDemandaPersonaBloque.C_FK_PERSONA, OracleDbType.Decimal, GetArray(tabla, -1, pkPersona), System.Data.ParameterDirection.Input);
            cmd.Parameters.Add(DatosDemandaPersonaBloque.C_SEC_LOG, OracleDbType.Int64, GetArray(tabla, 24), System.Data.ParameterDirection.Input);
            Actualizar(cmd);
        }

        private void PonerIds(DataTable t)
        {
            foreach (DataRow r in t.Rows)
            {
                r[0] = GetIdAutoNum("SQ_DATOS_DEM_PERSONA_BOLQUE");
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

    }
}
