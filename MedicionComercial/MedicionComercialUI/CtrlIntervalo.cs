using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CNDC.BaseForms;
using MC;

namespace MedicionComercialUI
{
    public partial class CtrlIntervalo : QuantumBaseControl
    {
        MC_IntervaloMaestro _intervaloMaestro;
        bool _modoEdicion;
        public CtrlIntervalo()
        {
            InitializeComponent();
        }

        public void Visualizar(MC_IntervaloMaestro i)
        {
            _intervaloMaestro = i;
            VisualizarActual();
        }

        private void VisualizarActual()
        {
            _txtNombre.Text = _intervaloMaestro.Nombre;
            _txtTiempoPeriodo.ValorInt = _intervaloMaestro.PeriodoTiempo;
            _txtEstado.Text = _intervaloMaestro.DCodEstado == 1 ? "ACTIVO" : "De Baja";
            if (_intervaloMaestro.EsNuevo)
            {
                _dtpDesde.Value = DateTime.Now.Date;
                _dtpHasta.Value = DateTime.Now.Date;
                _chbxHasta.Checked = false;
            }
            else
            {
                _dtpDesde.Value = _intervaloMaestro.FechaDesde;
                if (_intervaloMaestro.FechaHasta == null)
                {
                    _chbxHasta.Checked = false;
                }
                else
                {
                    _chbxHasta.Checked = true;
                    _dtpHasta.Value = _intervaloMaestro.FechaHasta.Value;
                }
            }
            AsegurarDtpFechaHasta();
        }

        public bool Guardar()
        {
            bool resultado = true;
            if (DatosSonValidos())
            {
                _intervaloMaestro.DCodEstado = 1;
                _intervaloMaestro.FechaDesde = _dtpDesde.Value.Date;
                if (_chbxHasta.Checked)
                {
                    _intervaloMaestro.FechaHasta = _dtpHasta.Value.Date;
                }
                else
                {
                    _intervaloMaestro.FechaHasta = null;
                }
                _intervaloMaestro.Nombre = _txtNombre.Text;
                _intervaloMaestro.PeriodoTiempo = _txtTiempoPeriodo.ValorInt;
                resultado = MC_IntervaloMaestroMgr.Instancia.Guardar(_intervaloMaestro);
            }
            return resultado;
        }

        private bool DatosSonValidos()
        {
            bool resultado = true;
            _errorProvider.Clear();
            _txtNombre.Text = _txtNombre.Text.Trim();

            if (string.IsNullOrEmpty(_txtNombre.Text))
            {
                _errorProvider.SetError(_txtNombre, "Ingrese el nombre del intervalo.");
                resultado = false;
            }
            return resultado;
        }

        public void DeshabilitarEdicion()
        {
            _txtEstado.Enabled = false;
            _txtNombre.Enabled = false;
            _txtTiempoPeriodo.Enabled = false;
            _dtpDesde.Enabled = false;
            _dtpHasta.Enabled = false;
            _chbxHasta.Enabled = false;
            _dtpHasta.Enabled = false;
            _modoEdicion = false;
            AsegurarDtpFechaHasta();
        }

        public void HabilitarEdicion()
        {
            _txtEstado.Enabled = true;
            _txtNombre.Enabled = true;
            _txtTiempoPeriodo.Enabled = true;
            _dtpDesde.Enabled = true;
            _chbxHasta.Enabled = true;
            _modoEdicion = true;
            AsegurarDtpFechaHasta();
        }

        private void _chbxHasta_CheckedChanged(object sender, EventArgs e)
        {
            AsegurarDtpFechaHasta();
        }

        private void AsegurarDtpFechaHasta()
        {
            _dtpHasta.Visible = _chbxHasta.Checked;
            _txtSinDefinir.Visible = !_chbxHasta.Checked;

            if (_modoEdicion)
            {
                _dtpHasta.Enabled = _chbxHasta.Checked;
            }
        }
    }
}
