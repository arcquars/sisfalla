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
    public partial class FormMedidorFlujoMaxMinDetalle : ABMBaseForm
    {
        MedidorFlujoMaxMinDetalle _medidorMaxMin;
        public FormMedidorFlujoMaxMinDetalle()
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

        public bool Editar(MedidorFlujoMaxMinDetalle medMaxMin)
        {
            bool resultado = true;
            _medidorMaxMin = medMaxMin;
            VisualizarMedidorMaxMin();
            resultado = ShowDialog() == DialogResult.OK;
            return resultado;
        }

        private void VisualizarMedidorMaxMin()
        {
            _txtMaximo.ValorDouble = _medidorMaxMin.Maximo;
            _txtMinimo.ValorDouble = _medidorMaxMin.Minimo;
        }

        protected override bool Guardar()
        {
            bool resultado = false;
            if (DatosSonValidos())
            {
                _medidorMaxMin.Maximo = _txtMaximo.ValorDouble;
                _medidorMaxMin.Minimo = _txtMinimo.ValorDouble;
                _medidorMaxMin.PkCodMagnitudElec = _ctrlSelecCanal.GetCanalSeleccionado();
                resultado = OraDalMedidorFlujoMaxMinDetalleMgr.Instancia.Guardar(_medidorMaxMin);
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

            if (_txtMaximo.ValorDouble < _txtMinimo.ValorDouble)
            {
                _errorProvider.SetError(_txtMaximo, "El máximo tiene que ser mayor al mínimo.");
                resultado = false;
            }

            return resultado;
        }
    }
}
