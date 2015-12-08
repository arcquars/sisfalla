using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CNDC.BLL;
using ModeloComponentes;
using System.Data;
using Oracle.DataAccess.Client;

namespace OraDalComponentes
{
    public class ControlesMgr : OraDalBaseMgr
    {
         #region Singleton
        private static ControlesMgr _instancia;
        static ControlesMgr()
        {
            _instancia = new ControlesMgr();
        }
        public static ControlesMgr Instancia
        {
            get { return _instancia; }
        }
        #endregion Singleton
        public DataTable GetControles(long pkTipoCodComponente)
        {
            DataTable resultado = null;
            OracleCommand cmd = CrearCommand();
            cmd.CommandText = @"Select * from P_CONTROL_COMPONENTE where pk_cod_tipo_componente=:pk_cod_tipo_componente order by d_tipo_dato";
            cmd.Parameters.Add("pk_cod_tipo_componente", OracleDbType.Int64, pkTipoCodComponente, System.Data.ParameterDirection.Input);
            cmd.BindByName = true;
            resultado = EjecutarCmd(cmd);
            return resultado;
        }
    }
}
