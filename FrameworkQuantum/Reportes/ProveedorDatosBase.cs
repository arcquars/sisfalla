using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MenuQuantum;
using Oracle.DataAccess.Client;
using System.Data;
using CNDC.BLL;
using System.Windows.Forms;

namespace Reportes
{
    public abstract class ProveedorDatosBase : IProveedorDatos
    {
        protected ParametroExtra _parametroExtra;
        protected ParametrosFuncionalidad _parametrosFuncionalidad;
        protected DataTable EjecutarComando(OracleCommand cmd, string nombreTabla)
        {
            DataTable resultado = Sesion.Instancia.Conexion.EjecutarCmd(cmd);
            resultado.TableName = nombreTabla;
            return resultado;
        }

        protected OracleCommand CrearComando(string sql)
        {
            OracleCommand cmd = Sesion.Instancia.Conexion.CrearCommand();
            cmd.CommandText = sql;
            cmd.BindByName = true;
            return cmd;
        }

        public void SetParametroExtra(ParametroExtra p)
        {
            _parametroExtra = p;
        }

        public void SetParametrosFuncionalidad(ParametrosFuncionalidad p)
        {
            _parametrosFuncionalidad = p;
        }

        public virtual TipoPanel GetTipoPanel()
        {
            return TipoPanel.Ninguno;
        }

        public virtual List<ToolStripButton> GetBotonesAdicionales()
        {
            return new List<ToolStripButton>();
        }

        public virtual bool PuedeConfigurarParametros()
        { return false; }

        public virtual bool ConfigurarParametros()
        { return false; }

        public abstract List<DataTable> GetDatos();
        public abstract System.Resources.ResourceManager GetResourceManager();
    }
}
