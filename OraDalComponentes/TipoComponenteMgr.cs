using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CNDC.BLL;
using ModeloComponentes;
using CNDC.DAL;
using Oracle.DataAccess.Client;
using System.Data;
using CNDC.Pistas;

namespace OraDalComponentes
{
    public class TipoComponenteMgr : OraDalBaseMgr,ITipoComponenteMgr
    {
        #region Singleton
        private static TipoComponenteMgr _instancia;
        static TipoComponenteMgr()
        {
            _instancia = new TipoComponenteMgr();
        }
        public static TipoComponenteMgr Instancia
        {
            get { return _instancia; }
        }
        #endregion Singleton

        public DataTable GetTipoOrdenado()
        {
            string sql = @"select * from P_AC_TIPOCOMPONENTE order by ORDEN";
            return EjecutarSql(sql);
        }
        public DataTable GetComponente()
        {
           // string sql = @"select * from P_DEF_COMPONENTE where estado=1 order by orden";
            string sql = @"select * from P_AC_TIPOCOMPONENTE where cod_tipo_padre>0 order by orden";
            return EjecutarSql(sql);
        }
        public DataTable GetClaseComponente()
        {
            string sql = @"select *, round(orden/1000,0) as clase from P_AC_TIPOCOMPONENTE where cod_tipo_padre=0 order by orden";
            return EjecutarSql(sql);

        }
        public DataTable GetTipoComponente()
        {
            string sql = @"select pk_cod_tipo_componente, descripcion_tipo  from P_AC_TIPOCOMPONENTE where estado>0 order by orden";
            return EjecutarSql(sql);
        }

     /*   public DataTable GetControles()
        {
            string sql = @"Select * from P_AC_TIPOCOMPONENTE";
            return EjecutarSql(sql);
        }*/
    }
}
