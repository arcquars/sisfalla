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
    public partial class FormMedidorFlujoMaxMin : ABMBaseForm
    {
        MedidorFlujoMaxMin _medidorMaxMin;
        public FormMedidorFlujoMaxMin()
        {
            InitializeComponent();
        }

        public bool Editar(MedidorFlujoMaxMin medMaxMin)
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
            _dtpDesde.Value = _medidorMaxMin.Desde;
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
                _medidorMaxMin.Desde = _dtpDesde.Value.Date;
                bool esNuevo = _medidorMaxMin.EsNuevo;
                resultado = OraDalMedidorFlujoMaxMinMgr.Instancia.Guardar(_medidorMaxMin);
                if (resultado)
                {
                    if (esNuevo)
                    {
                        resultado = OraDalMedidorFlujoMaxMinDetalleMgr.Instancia.CrearDetalle(_medidorMaxMin);
                    }
                    DialogResult = DialogResult.OK;
                }
            }
            return resultado;
        }

        private bool DatosSonValidos()
        {
            bool resultado = true;
            _errorProvider.Clear();
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
