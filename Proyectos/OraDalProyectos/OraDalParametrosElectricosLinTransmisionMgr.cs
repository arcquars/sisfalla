using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.ComponentModel;
using CNDC.BLL;
using Oracle.DataAccess.Client;
using CNDC.Pistas;
using ModeloProyectos;

namespace OraDalProyectos
{
    public class OraDalParametrosElectricosLinTransmisionMgr : OraDalBaseMgr, IParametrosElectricosLinTransmisionMgr
    {
        #region Singleton
        private static OraDalParametrosElectricosLinTransmisionMgr _instancia;
        static OraDalParametrosElectricosLinTransmisionMgr()
        {
            _instancia = new OraDalParametrosElectricosLinTransmisionMgr();
        }
        public static OraDalParametrosElectricosLinTransmisionMgr Instancia
        {
            get { return _instancia; }
        }

        private OraDalParametrosElectricosLinTransmisionMgr()
        {

        }
        #endregion Singleton

        public void Guardar(ParametrosElectricosLinTransmision parametrosElecLinTransmision)
        {
            OracleCommand cmd = null;
            string sql = string.Empty;
            if (parametrosElecLinTransmision.EsNuevo)
            {
                Pista p = PistaMgr.Instance.Info("DALProyectos", parametrosElecLinTransmision.GetEstadoString());
                parametrosElecLinTransmision.SecLog = (long)p.PK_SecLog;
                sql = "INSERT INTO {0} ({1},{2},{3},{4},{5},{6},{7},{8},{9})" +
                "VALUES(:{1},:{2},:{3},:{4},:{5},:{6},:{7},:{8},:{9})";
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
                "{8}=:{8} ," +
                "{9}=:{9}  WHERE ";
            }

            sql = string.Format(sql, ParametrosElectricosLinTransmision.NOMBRE_TABLA, ParametrosElectricosLinTransmision.C_PK_PARAM_ELEC_LIN_TRANS,
            ParametrosElectricosLinTransmision.C_FK_PROYECTO,
            ParametrosElectricosLinTransmision.C_FK_DATO_TEC_LIN_TRANSMISION,
            ParametrosElectricosLinTransmision.C_FK_LOC_PROY_TRANSMISION,
            ParametrosElectricosLinTransmision.C_LONGITUD_LINEA,
            ParametrosElectricosLinTransmision.C_RESISTENCIA,
            ParametrosElectricosLinTransmision.C_REACTANCIA,
            ParametrosElectricosLinTransmision.C_SUSCEPTANCIA,
            ParametrosElectricosLinTransmision.C_SEC_LOG);
            cmd = CrearCommand();
            cmd.CommandText = sql;
            cmd.BindByName = true;
            cmd.Parameters.Add(ParametrosElectricosLinTransmision.C_PK_PARAM_ELEC_LIN_TRANS, OracleDbType.Int64, parametrosElecLinTransmision.PkParamElecLinTrans, System.Data.ParameterDirection.Input);
            cmd.Parameters.Add(ParametrosElectricosLinTransmision.C_FK_PROYECTO, OracleDbType.Int64, parametrosElecLinTransmision.FkProyecto, System.Data.ParameterDirection.Input);
            cmd.Parameters.Add(ParametrosElectricosLinTransmision.C_FK_DATO_TEC_LIN_TRANSMISION, OracleDbType.Int64, parametrosElecLinTransmision.FkDatoTecLinTransmision, System.Data.ParameterDirection.Input);
            cmd.Parameters.Add(ParametrosElectricosLinTransmision.C_FK_LOC_PROY_TRANSMISION, OracleDbType.Int64, parametrosElecLinTransmision.FkLocProyTransmision, System.Data.ParameterDirection.Input);
            cmd.Parameters.Add(ParametrosElectricosLinTransmision.C_LONGITUD_LINEA, OracleDbType.Double, parametrosElecLinTransmision.LongitudLinea, System.Data.ParameterDirection.Input);
            cmd.Parameters.Add(ParametrosElectricosLinTransmision.C_RESISTENCIA, OracleDbType.Double, parametrosElecLinTransmision.Resistencia, System.Data.ParameterDirection.Input);
            cmd.Parameters.Add(ParametrosElectricosLinTransmision.C_REACTANCIA, OracleDbType.Double, parametrosElecLinTransmision.Reactancia, System.Data.ParameterDirection.Input);
            cmd.Parameters.Add(ParametrosElectricosLinTransmision.C_SUSCEPTANCIA, OracleDbType.Double, parametrosElecLinTransmision.Susceptancia, System.Data.ParameterDirection.Input);
            cmd.Parameters.Add(ParametrosElectricosLinTransmision.C_SEC_LOG, OracleDbType.Int64, parametrosElecLinTransmision.SecLog, System.Data.ParameterDirection.Input);

            if (Actualizar(cmd))
            {
                parametrosElecLinTransmision.EsNuevo = false;
            }
        }

        public DataTable GetTabla()
        {
            DataTable tabla = GetTabla(ParametrosElectricosLinTransmision.NOMBRE_TABLA);
            return tabla;
        }

        public BindingList<ParametrosElectricosLinTransmision> GetLista()
        {
            BindingList<ParametrosElectricosLinTransmision> resultado = new BindingList<ParametrosElectricosLinTransmision>();
            DataTable tablaAgentes = GetTabla();
            foreach (DataRow row in tablaAgentes.Rows)
            {
                resultado.Add(new ParametrosElectricosLinTransmision(row));
            }
            return resultado;
        }
    }
}
