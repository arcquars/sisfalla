using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ModeloComponentes;

namespace ComponentesUI
{
    public interface IControl
    {
        void Visualizar(Componente componenteSeleccionado);
        void Visualizar(Componente componenteSeleccionado, DateTime fechaConsulta);
    }
}
