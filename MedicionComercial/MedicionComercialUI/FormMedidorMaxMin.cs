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
    public partial class FormMedidorMaxMin : ABMBaseForm
    {
        MC_MedidorMaxMin _medidorMaxMin;
        public FormMedidorMaxMin()
        {
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            if (_medidorMaxMin != null)
            {
                _ctrlSelecCanal.Seleccionar(_medidorMaxMin.PkCodMagnitudElec);
            }
        }

        public bool Editar(MC_MedidorMaxMin medMaxMin)
        {
            bool resultado = true;
            _medidorMaxMin = medMaxMin;
            VisualizarMedidorMaxMin();
            resultado = ShowDialog() == DialogResult.OK;
            return resultado;
        }

        private void VisualizarMedidorMaxMin()
        {
            if (_medidorMaxMin.Hasta == null)
            {
                _chbxHasta.Checked = false;
            }
            else
            {
                _chbxHasta.Checked = true;
                _dtpHasta.Value = _medidorMaxMin.Hasta.Value;
            }
            AsegurarControlHasta();
            _dtpDesde.Value = _medidorMaxMin.PkDesde;
            _txtMaximo.ValorDouble = _medidorMaxMin.Maximo;
            _txtMinimo.ValorDouble = _medidorMaxMin.Minimo;
        }

        protected override bool Guardar()
        {
            bool resultado = false;
            if (DatosSonValidos())
            {
                if (_chbxHasta.Checked)
                {
                    _medidorMaxMin.Hasta = _dtpHasta.Value.Date;
                }
                else
                {
                    _medidorMaxMin.Hasta = null;
                }
                _medidorMaxMin.PkDesde = _dtpDesde.Value.Date;
                _medidorMaxMin.Maximo = _txtMaximo.ValorDouble;
                _medidorMaxMin.Minimo = _txtMinimo.ValorDouble;
                _medidorMaxMin.PkCodMagnitudElec = _ctrlSelecCanal.GetCanalSeleccionado();
                resultado = OraDalMC_MedidorMaxMinMgr.Instancia.Guardar(_medidorMaxMin);
                if (resultado)
                {
                    DialogResult = DialogResult.OK;
                }
            }
            return resultado;
        }

        private bool DatosSonValidos()
        {
            bool resultado = true;
            _errorProvider.Clear();
            if (_ctrlSelecCanal.GetCanalSeleccionado() == 0)
            {
                _errorProvider.SetError(_ctrlSelecCanal, "Seleccione una magnitud eléctrica.");
                resultado = false;
            }

            return resultado;
        }

        private void _chbxHasta_CheckedChanged(object sender, EventArgs e)
        {
            AsegurarControlHasta();
        }

        private void AsegurarControlHasta()
        {
            if (_chbxHasta.Checked)
            {
                _dtpHasta.Visible = true;
                _txtNoDefinido.Visible = false;
            }
            else
            {
                _txtNoDefinido.Visible = true;
                _dtpHasta.Visible = false;
            }
        }
    }
}
