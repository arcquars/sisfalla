using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ModeloSisFalla;
using CNDC.BLL;

namespace WcfServicioSISFALLA
{
    public interface IWcfObjetoNegocioMgr
    {
        void Guardar(ObjetoDeNegocio obj);
    }
}
