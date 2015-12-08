using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Controles
{
  public  interface IValidadorControl
    {

        bool IsValido(string valor);

        int Posicion {
            get; 
            set; }
    }
}
