using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ModeloProyectos;
using OraDalProyectos;
using CNDC.ExceptionHandlerLib;

namespace Proyectos
{
    public partial class CtrlDatosDeRduccionDeEmisores : CtrlDatosBase, IControles
    {
        bool _esEditable = true;
        Proyecto _proyecto;
        ReduccionEmisores _reduccionEmisores;
        bool _seGuardo = true;

        public CtrlDatosDeRduccionDeEmisores()
        {
            InitializeComponent();
        }

        public bool Guardado
        {
            get { return _seGuardo; }
        }

        private void LimpiarControles()
        {
            _errorProvider.Clear();
            _txtReducion.Value = 0;
            _dtpFechaRegistro.Value = DateTime.Now.Date;
        }

        private void CargarDatos()
        {
            _dtpFechaRegistro.Enabled = false;
            _txtReducion.Text = _reduccionEmisores.ReduccionCo2.ToString("N2");
            _dtpFechaRegistro.Value = _reduccionEmisores.FechaDeRegistro;
        }

        private void _tsbGuardar_Click(object sender, EventArgs e)
        {
            if (DatosValidos())
            {
                _reduccionEmisores.FkProyecto = _proyecto.PkProyecto;
                _reduccionEmisores.ReduccionCo2 = _txtReducion.ValDouble;
                if (_reduccionEmisores.EsNuevo)
                {
                    _reduccionEmisores.FechaDeRegistro = _dtpFechaRegistro.Value;
                }
                OraDalReduccionEmisoresMgr.Instancia.Guardar(_reduccionEmisores);
                DeshabilitarControles();
                _seGuardo = true;
            }
        }

        private bool DatosValidos()
        {
            _errorProvider.Clear();
            bool res = true;
            if (_txtReducion.Text == "")
            {
                _errorProvider.SetError(_txtReducion, "Ingrese un número.");
                res = false;
            }
            return res;
        }

        #region Miembros de IControles

        public string Titulo
        {
            get { return "REDUCCION DE EMISIONES"; }
        }

        protected void DeshabilitarControles()
        {
            OnEstadoDeEdicionModificado(false);
            _txtReducion.Enabled = false;
            _dtpFechaRegistro.Enabled = false;
            _tsbCancelar.Enabled = false;
            _tsbGuardar.Enabled = false;
            _tsbEditar.Enabled = true;
        }

        protected void HabilitarControles()
        {
            OnEstadoDeEdicionModificado(true);
            _txtReducion.Enabled = true;
            _dtpFechaRegistro.Enabled = _reduccionEmisores.EsNuevo? true: false;
            _tsbCancelar.Enabled = true;
            _tsbGuardar.Enabled = true;
            _tsbEditar.Enabled = false;
        }

        public void SetParametros(bool esEditable, Proyecto proyecto)
        {
            _seGuardo = true;
            _esEditable = esEditable;
            _proyecto = proyecto;
            LimpiarControles();
            _reduccionEmisores = OraDalReduccionEmisoresMgr.Instancia.GetPorPkProyecto(_proyecto.PkProyecto);
            
            if (_reduccionEmisores == null)
            {
                _reduccionEmisores = new ReduccionEmisores();
                _reduccionEmisores.EsNuevo = true;
            }
            else
            {
                _reduccionEmisores.EsNuevo = false;
                CargarDatos();
            }
            ActivarDesActivarControles();
            _txtReducion.Focus();
        }

        private void ActivarDesActivarControles()
        {
            if (_esEditable)
            {
                HabilitarControles();
            }
            else
            {
                DeshabilitarControles();
            }
        }

        #endregion

        private void _tsbEditar_Click(object sender, EventArgs e)
        {
            HabilitarControles();
            _seGuardo = false;
            _txtReducion.Focus();
        }

        private void _tsbCancelar_Click(object sender, EventArgs e)
        {
            _seGuardo = true;
            _errorProvider.Clear();
            if (_reduccionEmisores.EsNuevo)
            {
                LimpiarControles();
            }
            else
            {
                CargarDatos();
            }

            ActivarDesActivarControles();
        }


        public void SetEstadoToolBar(bool estado)
        {
            if(estado)
            {
                _toolStrip.Enabled = true;
            }
            else
            {
                _toolStrip.Enabled = false;
            }
        }
    }
}
