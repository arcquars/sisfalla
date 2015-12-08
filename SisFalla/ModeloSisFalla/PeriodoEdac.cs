using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ModeloSisFalla
{
    public class PeriodoEdac
    {
        public long PkCodEdac { get; set; }
        public long PKCodAlimentador{ get; set; }
        public string FechaInicioVigencia { get; set; }
        public string Agente { get; set; }
        public int Categoria { get; set; }
        public string Rowid { get; set; }
    }
}
