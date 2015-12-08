using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CNDC.BaseForms
{
    public interface IProveedorAyuda
    {
        string[][] ObtenerAyudaPorNombreTabla(string nombreTabla);
    }
}
