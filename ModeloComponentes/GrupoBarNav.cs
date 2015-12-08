using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DevExpress.XtraNavBar;


namespace ModeloComponentes
{
    public  class GrupoBarNav : NavBarGroup
    {
        public GrupoBarNav()
        { 
        }
        public long TipoComponente { get; private set; }
        public int EstadoComponente { get; private set; }
        public string DescripcionTipo{get; private set;}
        public GrupoBarNav(long tipoComponente, string descripcionTipo, int estadoComponente)
        {
            TipoComponente = tipoComponente;
            DescripcionTipo = descripcionTipo;
            EstadoComponente = estadoComponente;
        }
    }
}
