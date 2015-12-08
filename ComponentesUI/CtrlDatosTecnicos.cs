using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CNDC.BaseForms;


namespace ComponentesUI
{
    public partial class CtrlDatosTecnicos : CtrlBaseComponente, IControl
    {
        public CtrlDatosTecnicos()
        {
            InitializeComponent();
        }

        public void Visualizar(ModeloComponentes.Componente componenteSeleccionado)
        {
            
        }


        public void Visualizar(ModeloComponentes.Componente componenteSeleccionado, DateTime fechaConsulta)
        {
            throw new NotImplementedException();
        }
    }
}
