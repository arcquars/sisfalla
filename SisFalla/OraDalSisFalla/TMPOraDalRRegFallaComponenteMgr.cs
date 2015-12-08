using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.ComponentModel;
using CNDC.DAL;
using ModeloSisFalla;

namespace OraDalSisFalla
{
    public class OraDalRRegFallaComponenteMgr : IRRegFallaComponenteMgr
    {
        #region Singleton
        private static OraDalRRegFallaComponenteMgr _instancia;
        static OraDalRRegFallaComponenteMgr()
        {
            _instancia = new OraDalRRegFallaComponenteMgr();
        }
        public static OraDalRRegFallaComponenteMgr Instancia
        {
            get { return _instancia; }
        }

        private OraDalRRegFallaComponenteMgr()
        {

        }
        #endregion Singleton

        public const string NOMBRE_TABLA = "F_GF_RREGFALLA_COMPONENTE";
        public void Guardar(RRegFallaComponente obj)
        {
        }

        public DataTable GetTabla()
        {
            DataTable tabla = ConnexionOracleMgr.Instancia.GetTabla(NOMBRE_TABLA);
            return tabla;
        }

        public BindingList<RRegFallaComponente> GetLista()
        {
            BindingList<RRegFallaComponente> resultado = new BindingList<RRegFallaComponente>();
            DataTable tablaAgentes = GetTabla();
            foreach (DataRow row in tablaAgentes.Rows)
            {
                resultado.Add(new RRegFallaComponente(row));
            }
            return resultado;
        }

        public DataTable GetTablaVisualizable()
        {
            DataTable resultado = null;
            string sql = "select fc.*, c.nombre_componente, c.descripcion " +
            "from F_GF_RREGFALLA_COMPONENTE fc, f_ac_componente c " +
            "where fc.pk_cod_componente=c.pk_cod_componente";
            resultado = ConnexionOracleMgr.Instancia.EjecutarSql(sql);
            return resultado;
        }
    }
}
