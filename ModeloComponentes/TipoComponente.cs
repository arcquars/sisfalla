using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.ComponentModel;
using CNDC.BLL;

namespace ModeloComponentes
{
    class TipoComponente:ObjetoDeNegocio
    {
        public const string NOMBRE_TABLA = "P_DEF_COMPONENTE";

        public const string C_PK_COD_TIPO_COMPONENTE = "PK_COD_TIPO_COMPONENTE";
        public const string C_DESCRIPCION_TIPO = "DESCRIPCION_TIPO";
        public const string C_ORDEN = "ORDEN";
        public const string C_COD_TIPO_PADRE = "COD_TIPO_PADRE";
        public const string C_ESTADO = "ESTADO";
        public const string C_SEC_LOG = "SEC_LOG";
        public const string C_SINC_VER = "SINC_VER";


        public long PkCodTipoComponente { get; set; }
        public string DescripcionTipo { get; set; }
        public decimal Orden { get; set; }
        public long CodTipoPadre { get; set; }
        public decimal Estado { get; set; }
        public long SecLog { get; set; }
        public long SincVer { get; set; }


        public TipoComponente()
        { 
        }
          public TipoComponente(DataRow row)
        {
            PkCodTipoComponente = (long)row[C_PK_COD_TIPO_COMPONENTE];
            DescripcionTipo = (string)row[C_DESCRIPCION_TIPO];
            Orden=(decimal)row[C_ORDEN];
            CodTipoPadre = (long)row[C_COD_TIPO_PADRE];
            Estado=(long)row[C_ESTADO];
            SecLog = (long)row[C_SEC_LOG];
            SincVer = (long)row[C_SINC_VER];
        }
    }
    public interface ITipoComponenteMgr
    {
        //DataTable GetTabla();
        DataTable GetComponente();
        DataTable GetTipoOrdenado();
        
    }
}
