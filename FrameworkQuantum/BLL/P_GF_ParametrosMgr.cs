using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CNDC.BLL;
using CNDC.DAL;
using Oracle.DataAccess.Client;
using System.Data;
using CNDC.Pistas;

namespace BLL
{
    public class P_GF_ParametrosMgr : OraDalBaseMgr
    {
        #region Singleton
        private static P_GF_ParametrosMgr _instancia;
        bool _esNuevo = true;
        static P_GF_ParametrosMgr()
        {
            _instancia = new P_GF_ParametrosMgr();
        }
        public static P_GF_ParametrosMgr Instancia
        {
            get { return _instancia; }
        }

        public P_GF_ParametrosMgr()
        {

        }

        public P_GF_ParametrosMgr(ConnexionOracleMgr c)
            : base(c)
        {

        }
        #endregion Singleton

        public string GetString(string modulo, string tag)
        {
            string  resultado = null;
            string sql = 
            @"SELECT val_string FROM p_gf_parametros
            WHERE modulo = :modulo
            AND tag =:tag";
            OracleCommand cmd = CrearCommand(sql);
            cmd.Parameters.Add("modulo", OracleDbType.Varchar2, modulo, ParameterDirection.Input);
            cmd.Parameters.Add("tag", OracleDbType.Varchar2, tag, ParameterDirection.Input);
            OracleDataReader reader = null;
            try
            {
                reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    resultado = reader.GetString(0);
                }
            }
            catch (Exception ex)
            {
                PistaMgr.Instance.Error("BLL", ex);
            }
            finally
            {
                if (reader != null)
                {
                    reader.Close();
                }
            }

            return resultado;
        }
    }
}
