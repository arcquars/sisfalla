using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL
{
    public class EstiloColumna
    {
        public string NombreColumna { get; set; }
        public string TextoColumna { get; set; }
        public string Formato { get; set; }
        public AlineacionColumna Alineacion { get; set; }
        public int Ancho { get; set; }
        public bool MultiLinea { get; set; }
    }

    public enum AlineacionColumna
    {
        Izq,
        Der,
        Centro
    }
}
