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
    public class OraDalMC_PuntoMedicionMgr : OraDalBaseMgr, IMC_PuntoMedicionMgr
    {
        #region Singleton
        private static OraDalMC_PuntoMedicionMgr _instancia;
        static OraDalMC_PuntoMedicionMgr()
        {
            _instancia = new OraDalMC_PuntoMedicionMgr();
        }
        public static OraDalMC_PuntoMedicionMgr Instancia
        {
            get { return _instancia; }
        }

        private OraDalMC_PuntoMedicionMgr()
        {

        }
        #endregion Singleton

        public void Guardar(MC_PuntoMedicion obj)
        {
            OracleCommand cmd = null;
            string sql = string.Empty;
            if (obj.EsNuevo)
            {
                Pista p = PistaMgr.Instance.Info("DALSisFalla", obj.GetEstadoString());
                obj.SecLog = (long)p.PK_SecLog;
                obj.PkCodPtoMedicion = GetIdAutoNum("SEC_PK_COD_PTO_MEDICION");
                sql = "INSERT INTO F_MC_PUNTO_MEDICION (pk_cod_punto_medicion,NOMBRE,DESCRIPCION,TIPO,FK_COD_PROPIETARIO,FECHA_INICIO,FECHA_FIN,SEC_LOG)" +
                "VALUES(:pk_cod_punto_medicion,:NOMBRE,:DESCRIPCION,:TIPO,:FK_COD_PROPIETARIO,:FECHA_INICIO,:FECHA_FIN,:SEC_LOG)";
            }
            else
            {
                sql = @"UPDATE F_MC_PUNTO_MEDICION SET 
                NOMBRE=:NOMBRE ,
                DESCRIPCION=:DESCRIPCION ,
                TIPO=:TIPO ,
                FK_COD_PROPIETARIO=:FK_COD_PROPIETARIO ,
                FECHA_INICIO=:FECHA_INICIO ,
                FECHA_FIN=:FECHA_FIN ,
                SEC_LOG=:SEC_LOG
                WHERE pk_cod_punto_medicion=:pk_cod_punto_medicion";
            }

            cmd = CrearCommand();
            cmd.CommandText = sql;
            cmd.BindByName = true;
            cmd.Parameters.Add(MC_PuntoMedicion.C_PK_COD_PUNTO_MEDICION, OracleDbType.Int64, obj.PkCodPtoMedicion, ParameterDirection.Input);
            cmd.Parameters.Add(MC_PuntoMedicion.C_NOMBRE, OracleDbType.Varchar2, obj.Nombre, ParameterDirection.Input);
            cmd.Parameters.Add(MC_PuntoMedicion.C_DESCRIPCION, OracleDbType.Varchar2, obj.Descripcion, ParameterDirection.Input);
            cmd.Parameters.Add(MC_PuntoMedicion.C_TIPO, OracleDbType.Int32, obj.Tipo, ParameterDirection.Input);
            cmd.Parameters.Add(MC_PuntoMedicion.C_FK_COD_PROPIETARIO, OracleDbType.Int64, obj.FkCodPropietario, ParameterDirection.Input);
            cmd.Parameters.Add(MC_PuntoMedicion.C_FECHA_INICIO, OracleDbType.Date, obj.FechaIngreso, ParameterDirection.Input);
            cmd.Parameters.Add(MC_PuntoMedicion.C_FECHA_FIN, OracleDbType.Varchar2, obj.FechaSalida, ParameterDirection.Input);
            cmd.Parameters.Add(MC_PuntoMedicion.C_SEC_LOG, OracleDbType.Int64, obj.SecLog, ParameterDirection.Input);

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
            DataTable tabla = GetTabla(MC_PuntoMedicion.NOMBRE_TABLA);
            return tabla;
        }

        public BindingList<MC_PuntoMedicion> GetLista()
        {
            BindingList<MC_PuntoMedicion> resultado = new BindingList<MC_PuntoMedicion>();
            DataTable tablaAgentes = GetTabla();
            foreach (DataRow row in tablaAgentes.Rows)
            {
                resultado.Add(new MC_PuntoMedicion(row));
            }
            return resultado;
        }

        public DataTable GetParaLectura(DateTime desde, DateTime hasta, TipoPuntoMedicion tipo)
        {
            DataTable resultado = null;
            string sql = @"SELECT pk_cod_punto_medicion,nombre, descripcion, fk_cod_propietario
            FROM f_mc_punto_medicion
            WHERE :desde BETWEEN fecha_inicio AND NVL(fecha_fin,sysdate +1)
            AND tipo=:tipo
            ORDER BY nombre";
            OracleCommand cmd = CrearCommand();
            cmd.CommandText = sql;
            cmd.BindByName = true;
            cmd.Parameters.Add("desde", OracleDbType.Date, desde, ParameterDirection.Input);
            cmd.Parameters.Add("tipo", OracleDbType.Int32, tipo, ParameterDirection.Input);
            resultado = EjecutarCmd(cmd);
            return resultado;
        }
    }
}