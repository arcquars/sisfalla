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
    public partial class CtrlResumenMedidor : CtrlDatosMedidorBase
    {
        AC_Medidor _tmp = null;

        public event EventHandler<MedidorEventArgs> MedidorModificado;
        public event EventHandler<MedidorEventArgs> MedidorCreado;
        public CtrlResumenMedidor()
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
            _cmbPropietario.SelectedValue = _medidor.FkCodPropietario;
            _txtDescripcion.Text = _medidor.Descripcion;
            _txtMarca.Text = _medidor.Marca;
            _txtModelo.Text = _medidor.Modelo;
            _txtNombre.Text = _medidor.Nombre;
            _txtPrimeNoins.Text = _medidor.PrimeNoins;
            _txtPresicion.ValorDecimal = _medidor.Precision;
        }

        private void _btnAdicionar_Click(object sender, EventArgs e)
        {
            _tmp = _medidor;
            _medidor = new AC_Medidor();
            _medidor.EsNuevo = true;
            Visualizar();
            HabilitarControles();
        }

        private void HabilitarControles()
        {
            _cmbPropietario.Enabled = true;
            _txtDescripcion.ReadOnly = false;
            _txtMarca.ReadOnly = false;
            _txtModelo.ReadOnly = false;
            _txtNombre.ReadOnly = false;
            _txtPrimeNoins.ReadOnly = false;
            _txtPresicion.ReadOnly = false;

            _btnGuardar.Enabled = true;
            _btnCancelar.Enabled = true;
            _btnAdicionar.Enabled = false;
            _btnEditar.Enabled = false;
            _btnDarBaja.Enabled = false;
        }

        private void DeshabilitarControles()
        {
            _cmbPropietario.Enabled = false;
            _txtDescripcion.ReadOnly = true;
            _txtMarca.ReadOnly = true;
            _txtModelo.ReadOnly = true;
            _txtNombre.ReadOnly = true;
            _txtPrimeNoins.ReadOnly = true;
            _txtPresicion.ReadOnly = true;

            _btnAdicionar.Enabled = true;
            _btnEditar.Enabled = true;
            _btnDarBaja.Enabled = true;

            _btnGuardar.Enabled = false;
            _btnCancelar.Enabled = false;
        }

        private void _btnDarBaja_Click(object sender, EventArgs e)
        {

        }

        private void _btnCancelar_Click(object sender, EventArgs e)
        {
            if (_medidor.EsNuevo)
            {
                _medidor = _tmp;
            }
            Visualizar();
            DeshabilitarControles();
        }

        private void _btnGuardar_Click(object sender, EventArgs e)
        {
            if (DatosSonValidos())
            {
                bool esNuevo = _medidor.EsNuevo;
                _medidor.FkCodPropietario = (long)_cmbPropietario.SelectedValue;
                _medidor.Descripcion = _txtDescripcion.Text;
                _medidor.Marca = _txtMarca.Text;
                _medidor.Modelo = _txtModelo.Text;
                _medidor.Nombre = _txtNombre.Text;
                _medidor.PrimeNoins = _txtPrimeNoins.Text;
                _medidor.Precision = _txtPresicion.ValorDecimal;
                OraDalMedidorMgr.Instancia.Guardar(_medidor);
                DeshabilitarControles();
                if (esNuevo)
                {
                    OnMedidorCreado(_medidor);
                }
                else
                {
                    OnMedidorModificado(_medidor);
                }
            }
        }

        private void OnMedidorModificado(AC_Medidor m)
        {
            if (MedidorModificado != null)
            {
                MedidorModificado(this, new MedidorEventArgs(m));
            }
        }

        private void OnMedidorCreado(AC_Medidor m)
        {
            if (MedidorCreado != null)
            {
                MedidorCreado(this, new MedidorEventArgs(m));
            }
        }

        private bool DatosSonValidos()
        {
            bool resultado = true;
            _errorProvider.Clear();
            _txtNombre.Text = _txtNombre.Text.Trim();
            if (string.IsNullOrEmpty(_txtNombre.Text))
            {
                _errorProvider.SetError(_txtNombre, "Ingrese el nombre del Medidor");
                resultado = false;
            }
            return resultado;
        }

        private void _btnEditar_Click(object sender, EventArgs e)
        {
            HabilitarControles();
        }
    }

    public class MedidorEventArgs : EventArgs
    {
        private AC_Medidor _medidor;
        public MedidorEventArgs(AC_Medidor m)
        {
            _medidor = m;
        }

        public AC_Medidor Medidor
        { get { return _medidor; } }
    }
}
