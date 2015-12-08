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
using CNDC.BLL;

namespace MedicionComercialUI
{
    public partial class CtrlPuntoMedicion : CtrlDatosPuntoMedicionBase
    {
        MC_PuntoMedicion _tmp = null;
        public event EventHandler<PuntoMedicionEventArgs> PuntoMedicionModificado;
        public event EventHandler<PuntoMedicionEventArgs> PuntoMedicionCreado;
        public CtrlPuntoMedicion()
        {
            InitializeComponent();
            if (Sesion.Instancia.SesionIniciada)
            {
                DataTable tabla = OraDalPersonaMgr.Instancia.GetAgentes();
                _cmbPropietario.DisplayMember = "nom_cod_agente";
                _cmbPropietario.ValueMember = "pk_cod_persona";
                _cmbPropietario.DataSource = tabla;
            }
        }

        public override void Visualizar()
        {
            _cmbPropietario.SelectedValue = _puntoMedicion.FkCodPropietario;
            _txtDescripcion.Text = _puntoMedicion.Descripcion;
            _txtNombre.Text = _puntoMedicion.Nombre;
            _dtpFechaIngreso.Value = _puntoMedicion.FechaIngreso;
            if (_puntoMedicion.FechaSalida == null)
            {
                _chbxFechaSalida.Checked = false;
            }
            else
            {
                _chbxFechaSalida.Checked = true;
                _dtpFechaSalida.Value = _puntoMedicion.FechaSalida.Value;
            }

            if (_puntoMedicion.Tipo == 1)
            {
                _rbtnReal.Checked = true;
            }
            else
            {
                _rbtnVirtual.Checked = true;
            }
        }

        private void _btnAdicionar_Click(object sender, EventArgs e)
        {
            _tmp = _puntoMedicion;
            _puntoMedicion = new MC_PuntoMedicion();
            _puntoMedicion.EsNuevo = true;
            _puntoMedicion.FechaIngreso = DateTime.Now.Date;
            Visualizar();
            HabilitarControles();
        }

        private void HabilitarControles()
        {
            _cmbPropietario.Enabled = true;
            _txtDescripcion.ReadOnly = false;
            _txtNombre.ReadOnly = false;
            _dtpFechaIngreso.Enabled = true;
            _dtpFechaSalida.Enabled = true;
            _chbxFechaSalida.Enabled = true;

            _btnGuardar.Enabled = true;
            _btnCancelar.Enabled = true;
            _btnAdicionar.Enabled = false;
            _btnEditar.Enabled = false;
            _btnDarBaja.Enabled = false;
            _pnlRadioButtons.Enabled = true;
        }

        private void DeshabilitarControles()
        {
            _cmbPropietario.Enabled = false;
            _txtDescripcion.ReadOnly = true;
            _txtNombre.ReadOnly = true;
            _dtpFechaIngreso.Enabled = false;
            _dtpFechaSalida.Enabled = false;
            _chbxFechaSalida.Enabled = false;

            _btnAdicionar.Enabled = true;
            _btnEditar.Enabled = true;
            _btnDarBaja.Enabled = true;

            _btnGuardar.Enabled = false;
            _btnCancelar.Enabled = false;
            _pnlRadioButtons.Enabled = false;
        }

        private void _btnDarBaja_Click(object sender, EventArgs e)
        {

        }

        private void _btnCancelar_Click(object sender, EventArgs e)
        {
            if (_puntoMedicion.EsNuevo)
            {
                _puntoMedicion = _tmp;
            }
            Visualizar();
            DeshabilitarControles();
        }

        private void _btnGuardar_Click(object sender, EventArgs e)
        {
            if (DatosSonValidos())
            {
                bool esNuevo = _puntoMedicion.EsNuevo;
                _puntoMedicion.FkCodPropietario = (long)_cmbPropietario.SelectedValue;
                _puntoMedicion.Descripcion = _txtDescripcion.Text;
                _puntoMedicion.Nombre = _txtNombre.Text;
                _puntoMedicion.FechaIngreso = _dtpFechaIngreso.Value;
                _puntoMedicion.Tipo = _rbtnReal.Checked ? 1 : 2;
                if (_chbxFechaSalida.Checked)
                {
                    _puntoMedicion.FechaSalida = _dtpFechaSalida.Value;
                }
                else
                {
                    _puntoMedicion.FechaSalida = null;
                }
                OraDalMC_PuntoMedicionMgr.Instancia.Guardar(_puntoMedicion);
                DeshabilitarControles();
                if (esNuevo)
                {
                    OnMedidorCreado(_puntoMedicion);
                }
                else
                {
                    OnMedidorModificado(_puntoMedicion);
                }
            }
        }

        private void OnMedidorModificado(MC_PuntoMedicion m)
        {
            if (PuntoMedicionModificado != null)
            {
                PuntoMedicionModificado(this, new PuntoMedicionEventArgs(m));
            }
        }

        private void OnMedidorCreado(MC_PuntoMedicion m)
        {
            if (PuntoMedicionCreado != null)
            {
                PuntoMedicionCreado(this, new PuntoMedicionEventArgs(m));
            }
        }

        private bool DatosSonValidos()
        {
            bool resultado = true;
            _errorProvider.Clear();
            _txtNombre.Text = _txtNombre.Text.Trim();
            if (string.IsNullOrEmpty(_txtNombre.Text))
            {
                _errorProvider.SetError(_txtNombre, "Ingrese el nombre del Punto de Medición.");
                resultado = false;
            }
            return resultado;
        }

        private void _btnEditar_Click(object sender, EventArgs e)
        {
            HabilitarControles();
        }

        private void _chbxFechaSalida_CheckedChanged(object sender, EventArgs e)
        {
            if (_chbxFechaSalida.Checked)
            {
                _dtpFechaSalida.Visible = true;
                _txtFechaSinDefinir.Visible = false;
            }
            else
            {
                _txtFechaSinDefinir.Visible = true;
                _dtpFechaSalida.Visible = false;
            }
        }
    }

    public class PuntoMedicionEventArgs : EventArgs
    {
        private MC_PuntoMedicion _puntoMedicion;
        public PuntoMedicionEventArgs(MC_PuntoMedicion m)
        {
            _puntoMedicion = m;
        }

        public MC_PuntoMedicion PuntoMedicion
        { get { return _puntoMedicion; } }
    }
}
