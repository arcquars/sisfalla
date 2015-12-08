using System;
using System.Collections.Generic;
using System.Text;

namespace CNDC.Pistas
{
    [Serializable]
    public class Pista
    {
        public decimal PK_SecLog { get; set; }
        public string Usuario { get; set; }
        public string IP { get; set; }
        public string Modulo { get; set; }
        public DateTime FechaHora { get; set; }
        public string Detalle { get; set; }
        public string Excepcion { get; set; }
        public TipoPista Tipo { get; set; }

        public override string ToString()
        {
            string format = "{0} [{1}] {2} {3} {4}{6}{5}";
            return string.Format(format, FechaHora.ToString("ddMMMyyyy HH:mm:ss"),
                Modulo, IP, Usuario, Excepcion, Detalle, Environment.NewLine);
        }
    }

    public enum TipoPista
    {
        Debug,
        Info,
        Warn,
        Error,
        Fatal
    }
}
