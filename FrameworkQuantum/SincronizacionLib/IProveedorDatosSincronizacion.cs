using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace CNDC.Sincronizacion
{
    public interface IProveedorDatosSincronizacion
    {
        DataTable GetDatos(decimal versionCliente, long pkCodPersona, bool parcial);
    }
}
