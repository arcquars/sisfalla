using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Oracle.DataAccess.Client;
using CNDC.DAL;
using System.Data;

namespace OraDalSisFalla
{
    public class OraDalBaseMgr
    {
        protected OracleCommand CrearCommand()
        {
            return ConnexionOracleMgr.Instancia.CrearCommand(); 
        }

        protected DataTable EjecutarCmd(OracleCommand cmd)
        {
            DataTable tabla = ConnexionOracleMgr.Instancia.EjecutarCmd(cmd);
            return tabla;
        }

        protected DataTable GetTabla(string nombreTabla)
        {
            return ConnexionOracleMgr.Instancia.GetTabla(nombreTabla); 
        }

        protected void DisposeCommand(OracleCommand cmd)
        {
            ConnexionOracleMgr.Instancia.DisposeCommand(cmd);
        }

        protected void Actualizar(OracleCommand cmd)
        {
            ConnexionOracleMgr.Instancia.Actualizar(cmd);
        }

        protected Array GetArray(List<DataRow> rows, string campo)
        {
            IConvertible[] resultado = new IConvertible[rows.Count];

            for (int i = 0; i < rows.Count; i++)
            {
                resultado[i] = (IConvertible)rows[i][campo];
            }
            return resultado;
        }

        protected DataTable EjecutarSql(string sql)
        {
            return ConnexionOracleMgr.Instancia.EjecutarSql(sql);
        }
    }
}
