using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.ComponentModel;
using CNDC.BLL;
using Oracle.DataAccess.Client;
using ModeloProyectos;
using CNDC.Pistas;
using CNDC.DAL;

namespace OraDalProyectos
{
    public class OraDalDatoTecnicoHidroelectricoMgr : OraDalBaseMgr, IDatoTecnicoHidroelectricoMgr
    {
        #region Singleton
        private static OraDalDatoTecnicoHidroelectricoMgr _instancia;
        static OraDalDatoTecnicoHidroelectricoMgr()
        {
            _instancia = new OraDalDatoTecnicoHidroelectricoMgr();
        }
        public static OraDalDatoTecnicoHidroelectricoMgr Instancia
        {
            get { return _instancia; }
        }

        private OraDalDatoTecnicoHidroelectricoMgr()
        {

        }
        #endregion Singleton

        public override string NombreTabla
        {
            get
            {
                return DatoTecnicoHidroelectrico.NOMBRE_TABLA;
            }
        }

        public void Guardar(DatoTecnicoHidroelectrico obj)
        {
            OracleCommand cmd = null;
            string sql = string.Empty;
            if (obj.EsNuevo)
            {
                Pista p = PistaMgr.Instance.Info("DALProyectos", obj.GetEstadoString());
                obj.SecLog = (long)p.PK_SecLog;
                obj.PkDatoTecHidroelectrico = GetIdAutoNum("SQ_F_PR_DATO_TEC_HIDROELEC");
                sql = "INSERT INTO {0} ({1},{2},{3},{4},{5},{6},{7},{8},{9},{10},{11},{12},{13},{14},{15},{16},{17},{18},{19})" +
                "VALUES(:{1},:{2},:{3},:{4},:{5},:{6},:{7},:{8},:{9},:{10},:{11},:{12},:{13},:{14},:{15},:{16},:{17},:{18},:{19})";
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
                "{17}=:{17} ," +
                "{18}=:{18} ," +
                "{19}=:{19}  WHERE {1}=:{1} ";
            }

            sql = string.Format(sql, DatoTecnicoHidroelectrico.NOMBRE_TABLA, DatoTecnicoHidroelectrico.C_PK_DATO_TEC_HIDROELECTRICO,
            DatoTecnicoHidroelectrico.C_FK_PROYECTO,
            DatoTecnicoHidroelectrico.C_POTENCIA_INSTALADA,
            DatoTecnicoHidroelectrico.C_NRO_UNIDADES,
            DatoTecnicoHidroelectrico.C_D_COD_TURBINA_HIDROELECTRICA,
            DatoTecnicoHidroelectrico.C_CAUDAL_DISENO,
            DatoTecnicoHidroelectrico.C_CUENCA,
            DatoTecnicoHidroelectrico.C_FK_PROY_VERTIMIENTO,
            DatoTecnicoHidroelectrico.C_FK_PROY_TURBINAMIENTO,
            DatoTecnicoHidroelectrico.C_GENERACION_MEDIA_ANUAL,
            DatoTecnicoHidroelectrico.C_FACTOR_PRODUCTIVIDAD,
            DatoTecnicoHidroelectrico.C_CAIDA_BRUTA,
            DatoTecnicoHidroelectrico.C_VOLUMEN_TOTAL,
            DatoTecnicoHidroelectrico.C_AREA_CUENCA,
            DatoTecnicoHidroelectrico.C_OBSERVACIONES,
            DatoTecnicoHidroelectrico.C_FK_PROY_INFILTRACION,
            DatoTecnicoHidroelectrico.C_SEC_LOG,
            DatoTecnicoHidroelectrico.C_FECHA_REGISTRO,
            DatoTecnicoHidroelectrico.C_VOLUMEN_UTIL);
            cmd = CrearCommand();
            cmd.CommandText = sql;
            cmd.BindByName = true;

            cmd.Parameters.Add(DatoTecnicoHidroelectrico.C_PK_DATO_TEC_HIDROELECTRICO, OracleDbType.Int64, obj.PkDatoTecHidroelectrico, System.Data.ParameterDirection.Input);
            cmd.Parameters.Add(DatoTecnicoHidroelectrico.C_FK_PROYECTO, OracleDbType.Int64, obj.FkProyecto, System.Data.ParameterDirection.Input);
            cmd.Parameters.Add(DatoTecnicoHidroelectrico.C_POTENCIA_INSTALADA, OracleDbType.Double, obj.PotenciaInstalada, System.Data.ParameterDirection.Input);
            cmd.Parameters.Add(DatoTecnicoHidroelectrico.C_NRO_UNIDADES, OracleDbType.Int64, obj.NroUnidades, System.Data.ParameterDirection.Input);
            cmd.Parameters.Add(DatoTecnicoHidroelectrico.C_D_COD_TURBINA_HIDROELECTRICA, OracleDbType.Int64, obj.DCodTurbinaHidroelectrica, System.Data.ParameterDirection.Input);
            cmd.Parameters.Add(DatoTecnicoHidroelectrico.C_CAUDAL_DISENO, OracleDbType.Double, obj.CaudalDiseno, System.Data.ParameterDirection.Input);
            cmd.Parameters.Add(DatoTecnicoHidroelectrico.C_CUENCA, OracleDbType.Varchar2, obj.Cuenca, System.Data.ParameterDirection.Input);
            cmd.Parameters.Add(DatoTecnicoHidroelectrico.C_FK_PROY_VERTIMIENTO, OracleDbType.Int64, obj.FkProyVertimiento, System.Data.ParameterDirection.Input);
            cmd.Parameters.Add(DatoTecnicoHidroelectrico.C_FK_PROY_TURBINAMIENTO, OracleDbType.Int64, obj.FkProyTurbinamiento, System.Data.ParameterDirection.Input);
            cmd.Parameters.Add(DatoTecnicoHidroelectrico.C_GENERACION_MEDIA_ANUAL, OracleDbType.Double, obj.GeneracionMediaAnual, System.Data.ParameterDirection.Input);
            cmd.Parameters.Add(DatoTecnicoHidroelectrico.C_FACTOR_PRODUCTIVIDAD, OracleDbType.Double, obj.FactorProductividad, System.Data.ParameterDirection.Input);
            cmd.Parameters.Add(DatoTecnicoHidroelectrico.C_CAIDA_BRUTA, OracleDbType.Double, obj.CaidaBruta, System.Data.ParameterDirection.Input);
            cmd.Parameters.Add(DatoTecnicoHidroelectrico.C_VOLUMEN_TOTAL, OracleDbType.Double, obj.VolumenTotal, System.Data.ParameterDirection.Input);
            cmd.Parameters.Add(DatoTecnicoHidroelectrico.C_AREA_CUENCA, OracleDbType.Double, obj.AreaCuenca, System.Data.ParameterDirection.Input);
            cmd.Parameters.Add(DatoTecnicoHidroelectrico.C_OBSERVACIONES, OracleDbType.Varchar2, obj.Observaciones, System.Data.ParameterDirection.Input);
            cmd.Parameters.Add(DatoTecnicoHidroelectrico.C_FK_PROY_INFILTRACION, OracleDbType.Double, obj.FkProyInfiltracion, System.Data.ParameterDirection.Input);
            cmd.Parameters.Add(DatoTecnicoHidroelectrico.C_SEC_LOG, OracleDbType.Int64, obj.SecLog, System.Data.ParameterDirection.Input);
            cmd.Parameters.Add(DatoTecnicoHidroelectrico.C_FECHA_REGISTRO, OracleDbType.Date, obj.FechaDeRegistro, System.Data.ParameterDirection.Input);
            cmd.Parameters.Add(DatoTecnicoHidroelectrico.C_VOLUMEN_UTIL, OracleDbType.Double, obj.VolumenUtil, System.Data.ParameterDirection.Input);

            if (Actualizar(cmd))
            {
                obj.EsNuevo = false;
            }
        }

        public DataTable GetTabla()
        {
            DataTable tabla = GetTabla(DatoTecnicoHidroelectrico.NOMBRE_TABLA);
            return tabla;
        }

        public BindingList<DatoTecnicoHidroelectrico> GetLista()
        {
            BindingList<DatoTecnicoHidroelectrico> resultado = new BindingList<DatoTecnicoHidroelectrico>();
            DataTable tablaAgentes = GetTabla();
            foreach (DataRow row in tablaAgentes.Rows)
            {
                resultado.Add(new DatoTecnicoHidroelectrico(row));
            }
            return resultado;
        }

        public DatoTecnicoHidroelectrico GetPorPkProyecto(long pkProyecto)
        {
            string sql = "SELECT {0}.* FROM {0}, F_PR_PROYECTO WHERE {1}={2} AND F_PR_PROYECTO.PK_PROYECTO={0}.{1} AND F_PR_PROYECTO.ESTADO=1";
            sql = string.Format(sql, DatoTecnicoHidroelectrico.NOMBRE_TABLA, DatoTecnicoHidroelectrico.C_FK_PROYECTO, pkProyecto);
            DataTable tabla = EjecutarSql(sql);
            DatoTecnicoHidroelectrico res = null;
            if (tabla.Rows.Count > 0)
            {
                DataRow row = tabla.Rows[0];
                res = new DatoTecnicoHidroelectrico(row);
            }

            return res;
        }
    }
}
