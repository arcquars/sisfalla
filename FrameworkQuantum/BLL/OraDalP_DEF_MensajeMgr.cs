using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.ComponentModel;
using Oracle.DataAccess.Client;
using CNDC.Pistas;
using CNDC.DAL;

namespace CNDC.BLL
{
    public class OraDalP_DEF_MensajeMgr : IP_DEF_MensajeMgr
    {
        #region Singleton
        private static OraDalP_DEF_MensajeMgr _instancia;
        static OraDalP_DEF_MensajeMgr()
        {
            _instancia = new OraDalP_DEF_MensajeMgr();
        }
        public static OraDalP_DEF_MensajeMgr Instancia
        {
            get { return _instancia; }
        }

        private OraDalP_DEF_MensajeMgr()
        {

        }
        #endregion Singleton

        public void Guardar(P_DEF_Mensaje obj)
        {
            OracleCommand cmd = null;
            string sql = string.Empty;
            if (obj.EsNuevo)
            {
                sql =
                "INSERT INTO {0} ({1},{2},{3})" +
                "VALUES(:{1},:{2},:{3})";
            }
            else
            {
                sql =
                "UPDATE {0} SET " +
                "{2}=:{2} ," +
                "{3}=:{3}  WHERE " +
                "{1}=:{1} ";
            }

            sql = string.Format(sql, P_DEF_Mensaje.NOMBRE_TABLA, 
            P_DEF_Mensaje.C_COD_MENSAJE,
            P_DEF_Mensaje.C_TEXTO_MENSAJE,
            P_DEF_Mensaje.C_SINC_VER);
            cmd = Sesion.Instancia.Conexion.CrearCommand();
            cmd.CommandText = sql;
            cmd.BindByName = true;
            cmd.Parameters.Add(P_DEF_Mensaje.C_COD_MENSAJE, OracleDbType.Varchar2, obj.CodMensaje, System.Data.ParameterDirection.Input);
            cmd.Parameters.Add(P_DEF_Mensaje.C_TEXTO_MENSAJE, OracleDbType.Varchar2, obj.TextoMensaje, System.Data.ParameterDirection.Input);
            cmd.Parameters.Add(P_DEF_Mensaje.C_SINC_VER, OracleDbType.Int64, obj.SincVer, System.Data.ParameterDirection.Input);

            if (Sesion.Instancia.Conexion.Actualizar(cmd))
            {
                obj.EsNuevo = false;
            }
        }

        public DataTable GetTabla()
        {
            DataTable tabla = Sesion.Instancia.Conexion.GetTabla(P_DEF_Mensaje.NOMBRE_TABLA);
            return tabla;
        }

        public BindingList<P_DEF_Mensaje> GetLista()
        {
            BindingList<P_DEF_Mensaje> resultado = new BindingList<P_DEF_Mensaje>();
            DataTable tablaAgentes = GetTabla();
            foreach (DataRow row in tablaAgentes.Rows)
            {
                resultado.Add(new P_DEF_Mensaje(row));
            }
            return resultado;
        }
    }
}