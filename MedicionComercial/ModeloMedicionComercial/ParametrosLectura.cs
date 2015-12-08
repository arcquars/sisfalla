using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MC;
using System.Data;

namespace MC
{
    public class ParametrosLectura
    {
        public List<MC_RPuntoMedicionFormatoDetalle> DetalleMagElec { get; set; }
    }

    public class ResultadoLectura
    {
        public DataTable Tabla { get; set; }
        public List<RegistroLectura> Registros { get; set; }

        public ResultadoLectura()
        {
            Registros = new List<RegistroLectura>();
        }
    }
}
