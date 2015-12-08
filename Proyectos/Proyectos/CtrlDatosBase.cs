using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Proyectos
{
    public partial class CtrlDatosBase : CNDC.BaseForms.QuantumBaseControl
    {
        public event EventHandler<EstadoDeEdicionEventArgs> EstadoDeEdicionModificado;

        public CtrlDatosBase()
        {
            InitializeComponent();
        }

        protected virtual void OnEstadoDeEdicionModificado(bool editando)
        {
            if (EstadoDeEdicionModificado != null)
            {
                EstadoDeEdicionEventArgs e = new EstadoDeEdicionEventArgs(editando);
                EstadoDeEdicionModificado(this, e);
            }
        }
    }

    public class EstadoDeEdicionEventArgs : EventArgs
    {
        private bool _editando;

        public EstadoDeEdicionEventArgs(bool editando)
        {
            _editando = editando;
        }

        public bool Editando
        { get { return _editando; } }
    }
}
