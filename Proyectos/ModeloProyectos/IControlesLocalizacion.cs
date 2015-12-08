using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ModeloProyectos
{
    public interface IControlesLocalizacion
    {
        void SetParametros(bool esEditable, Proyecto proyecto);
        void GuardarDatos(Proyecto proyecto);
        void HabilitarControles();
        void DeshabilitarControles();
        bool DatosValidos();
    }
}
