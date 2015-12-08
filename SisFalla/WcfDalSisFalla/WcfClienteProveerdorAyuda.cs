using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CNDC.PluginComunicacionBase;
using CNDC.UtilesComunes;
using CNDC.BLL;

namespace WcfDalSisFalla
{
    public class WcfClienteProveerdorAyuda : IProveedorAyuda
    {
        public Dictionary<string, string> ObtenerAyudaPorNombreTabla(string nombreTabla)
        {
            Dictionary<string, string> comentarios = new Dictionary<string, string>();
            return comentarios;
        }
    }
}
