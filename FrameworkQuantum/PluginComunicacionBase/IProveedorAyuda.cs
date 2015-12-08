using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CNDC.PluginComunicacionBase
{
    public interface IProveedorAyuda
    {
        Dictionary<string, string> ObtenerAyudaPorNombreTabla(string nombreTabla);
    }
}
