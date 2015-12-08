using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ModeloProyectos
{
    public interface IControles
    {
        void SetParametros(bool esNuevo, Proyecto proyecto);
        string Titulo { get; }
        bool Guardado { get; }
        void SetEstadoToolBar(bool estado);
    }
}
