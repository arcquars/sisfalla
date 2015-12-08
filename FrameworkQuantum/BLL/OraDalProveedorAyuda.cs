using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CNDC.PluginComunicacionBase;
using CNDC.DAL;

namespace CNDC.BLL
{
    //TODO cuando se tenga el modelo de plugins.. llevar esta clase al plugin y
    //quitar la referencia a PluginComunicacionBase
    public class OraDalProveedorAyuda : IProveedorAyuda
    {
        public Dictionary<string, string> ObtenerAyudaPorNombreTabla(string nombreTabla)
        {
            Dictionary<string, string> comentarios = CommentMgr.Instance.GetMessage(nombreTabla);
            return comentarios;
        }
    }
}
