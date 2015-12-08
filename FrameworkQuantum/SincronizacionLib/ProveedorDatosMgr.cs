using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CNDC.Sincronizacion;
using System.Data;
using CNDC.Pistas;
using CNDC.DAL;
using Oracle.DataAccess.Client;
using CNDC.BLL;

namespace CNDC.Sincronizacion
{
    public class ProveedorDatosMgr
    {
        Dictionary<string, IProveedorDatosSincronizacion> _dicProveedores;
        ConnexionOracleMgr _conexion;
        AyudanteSincronizacion _ayudante;

        public ProveedorDatosMgr(ConnexionOracleMgr c)
        {
            _conexion = c;
            _dicProveedores = new Dictionary<string, IProveedorDatosSincronizacion>();
            _ayudante = new AyudanteSincronizacion(_conexion);
        }

        public int CantidadProveedores
        { get { return _dicProveedores.Count; } }

        public void AdicionarProveedor(string nombreTabla, IProveedorDatosSincronizacion proveedor)
        {
            _dicProveedores[nombreTabla] = proveedor;
        }

        public DataTable GetDatos(string nombreTabla, decimal versionCliente, long pkCodPersona)
        {
            DataTable resultado = null;
            bool parcial = GetConfigModoSinc(pkCodPersona, 3621, "PARCIAL").ToUpper() == "PARCIAL";
            if (_dicProveedores.ContainsKey(nombreTabla) )
            {
                PistaMgr.Instance.Debug("CNDC.Sincronizacion.ProveedorDatosMgr.GetDatos()", "obteniendo datos");
                resultado = _dicProveedores[nombreTabla].GetDatos(versionCliente, pkCodPersona, parcial);
            }
            else
            {
                resultado = _ayudante.GetRegistros(nombreTabla, versionCliente, pkCodPersona);
            }
            return resultado;
        }

        private string GetConfigModoSinc(long pkCodPersona, long dominioConfig, string resultadoPorDefecto)
        {
            string resultado = resultadoPorDefecto;
            string sql = @"SELECT valor_configuracion FROM P_GF_CONFIG 
            WHERE pk_cod_persona=:pk_cod_persona AND pk_cod_parametro=:pk_cod_parametro";
            OracleCommand cmd = _conexion.CrearCommand();
            cmd.CommandText = sql;
            cmd.BindByName = true;
            cmd.Parameters.Add("pk_cod_persona", OracleDbType.Int64, pkCodPersona, ParameterDirection.Input);
            cmd.Parameters.Add("pk_cod_parametro", OracleDbType.Int64, dominioConfig, ParameterDirection.Input);

            DataTable tabla = _conexion.EjecutarCmd(cmd);

            if (tabla.Rows.Count > 0)
            {
                resultado = ObjetoDeNegocio.GetValor<string>(tabla.Rows[0]["valor_configuracion"]);
                if (string.IsNullOrEmpty(resultado))
                {
                    resultado = resultadoPorDefecto;
                }
            }

            return resultado.ToUpper();
        }
    }
}