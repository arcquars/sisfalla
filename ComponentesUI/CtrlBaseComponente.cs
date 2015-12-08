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
    public partial class CtrlBaseComponente : QuantumBaseControl
    {
        public bool _esNuevo = false;
        public bool _enEdicion = false;
        public long _tipoComponente=0;
        public event EventHandler<AccionEjecutadaEventArgs> AccionEjecutada;

        public CtrlBaseComponente()
        {
            InitializeComponent();
        }
        public  void _tSBEditar_Click(object sender, EventArgs e)
        {
            this._tSBCancelar.Enabled = true;
            this._tSBGuardar.Enabled = true;
            this._tSBEditar.Enabled = false;
            Habilitar();
            OnAccionEjecutada(Accion.Editar);
            _enEdicion = true;
        }

        public void _tSBGuardar_Click(object sender, EventArgs e)
        {
            this._tSBCancelar.Enabled = false;
            this._tSBGuardar.Enabled = false;
            this._tSBEditar.Enabled = true;
            _enEdicion = true;
            if (Guardar())
            {
                OnAccionEjecutada(Accion.Guardar);
                Deshabilitar();
            }
        }

        private void OnAccionEjecutada(Accion accion)
        {
            if (AccionEjecutada != null)
            {
                AccionEjecutada(this, new AccionEjecutadaEventArgs(accion));
            }
        }

        public virtual void Habilitar()
        {
        }
        public virtual void Deshabilitar()
        {
        }
        public virtual bool Guardar()
        {
           return true;
           
        }
        public virtual void Nuevo()  {  }

        public virtual void _tSBCancelar_Click(object sender, EventArgs e)
        {
            this._tSBCancelar.Enabled = false;
            this._tSBGuardar.Enabled = false;
            this._tSBEditar.Enabled = true;
            OnAccionEjecutada(Accion.Cancelar);
            _enEdicion = false;
            Deshabilitar();

        }
        
    }

    public class AccionEjecutadaEventArgs:EventArgs
    {
        private Accion _accionEjecutada;
        public AccionEjecutadaEventArgs(Accion accion)
        {
            _accionEjecutada = accion;
        }

        public Accion AccionEjecutada
        { get { return _accionEjecutada; } }
    }

    public enum Accion
    {
        Guardar,
        Cancelar,
        Editar
    }
}
