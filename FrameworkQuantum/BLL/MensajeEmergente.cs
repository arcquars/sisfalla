using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL
{
    public class MensajeEmergente
    {
        public DateTime FechaHora { get; set; }
        public string Cabecera { get; set; }
        public string Detalle { get; set; }
        public bool Leido { get; set; }
        public bool Resaltado { get; set; }
        public event EventHandler Borrado;

        public MensajeEmergente()
        {
            FechaHora = DateTime.Now;
        }

        public override string ToString()
        {
            return Cabecera;
        }

        public void Borrar()
        {
            if (Borrado != null)
            {
                Borrado(this, EventArgs.Empty);
            }
        }
    }
}
