using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CNDC.BaseForms;
using MC;

namespace MedicionComercialUI
{
    public partial class FormRMedidorCanal : ABMBaseForm
    {
        MC_RPuntoMedicionFormatoDetalle _rMedidorCanalSeleccionado;
        public FormRMedidorCanal()
        {
            InitializeComponent();
        }

        public bool Editar(MC_RPuntoMedicionFormatoDetalle rMedidorCanalSeleccionado)
        {
            bool resultado = false;
            _rMedidorCanalSeleccionado = rMedidorCanalSeleccionado;
            if (ShowDialog() == DialogResult.OK)
            {
                resultado = true;
            }
            return resultado;
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            Visualizar();
        }

        private void Visualizar()
        {
            _ctrlSelecCanal.Seleccionar(_rMedidorCanalSeleccionado.FkCodMagnitudElec);
            _txtKC.ValorDouble = _rMedidorCanalSeleccionado.Kc;
            _txtKCT.ValorDouble = _rMedidorCanalSeleccionado.Kct;
            _txtKPT.ValorDouble = _rMedidorCanalSeleccionado.Kpt;
            _txtNumCanal.Text = _rMedidorCanalSeleccionado.Canal.ToString();
            _txtColArchivo.Text = _rMedidorCanalSeleccionado.ColArchivo;
        }

        protected override bool Guardar()
        {
            bool resultado = true;
            if (DatosSonValidos())
            {
                _rMedidorCanalSeleccionado.FkCodMagnitudElec = _ctrlSelecCanal.GetCanalSeleccionado();
                _rMedidorCanalSeleccionado.Kc = _txtKC.ValorDouble;
                _rMedidorCanalSeleccionado.Kct = _txtKCT.ValorDouble;
                _rMedidorCanalSeleccionado.Kpt = _txtKPT.ValorDouble;
                _rMedidorCanalSeleccionado.Canal = _txtNumCanal.ValorLong;
                _rMedidorCanalSeleccionado.ColArchivo = _txtColArchivo.Text;
                resultado = OraDalMC_RPuntoMedicionFormatoDetalleMgr.Instancia.Guardar(_rMedidorCanalSeleccionado);
                DialogResult = DialogResult.OK;
            }
            else
            {
                resultado = false;
            }
            return resultado;
        }

        private bool DatosSonValidos()
        {
            bool resultado = true;
            _errorProvider.Clear();
            if (_txtKC.ValorDecimal == 0)
            {
                _errorProvider.SetError(_txtKC, "Ingrese un valor mayor a cero.");
                resultado = false;
            }

            if (_txtKCT.ValorDecimal == 0)
            {
                _errorProvider.SetError(_txtKCT, "Ingrese un valor mayor a cero.");
                resultado = false;
            }

            if (_txtKPT.ValorDecimal == 0)
            {
                _errorProvider.SetError(_txtKPT, "Ingrese un valor mayor a cero.");
                resultado = false;
            }

            if (_txtNumCanal.ValorLong == 0)
            {
                _errorProvider.SetError(_txtNumCanal, "Ingrese un valor mayor a cero.");
                resultado = false;
            }
            else if (_rMedidorCanalSeleccionado.EsNuevo)
            {

            }

            _txtColArchivo.Text = _txtColArchivo.Text.Trim();
            if (string.IsNullOrEmpty(_txtColArchivo.Text))
            {
                _errorProvider.SetError(_txtColArchivo, "Ingrese la columna.");
                resultado = false;
            }

            if (!_ctrlSelecCanal.DatosSonValidos())
            {
                resultado = false;
            }
            return resultado;
        }

        private void _txtColArchivo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar))
            {
                e.Handled = true;
            }
        }
    }
}
