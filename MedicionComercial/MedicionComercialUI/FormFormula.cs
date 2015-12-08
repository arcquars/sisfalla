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
    public partial class FormFormula : ABMBaseForm
    {
        MC_FormulaPuntoMedicion _formula;
        public FormFormula()
        {
            InitializeComponent();
        }

        public bool Editar(MC_FormulaPuntoMedicion f)
        {
            _formula = f;
            Visualizar();
            return ShowDialog() == DialogResult.OK;
        }

        private void Visualizar()
        {
            _ctrlMagnitudElec.Seleccionar(_formula.FkCodMagnitudElec);
            _dtpFechaInicio.Value = _formula.FechaInicio;
            if (_formula.FechaFin == null)
            {
                _chbxHasta.Checked = false;
            }
            else
            {
                _chbxHasta.Checked = true;
                _dtpFechaFin.Value = _formula.FechaFin.Value;
            }

            _txtFormula.Text = _formula.Formula;
        }

        protected override bool Guardar()
        {
            bool resultado = true;
            if (DatosSonValidos())
            {
                _formula.FkCodMagnitudElec = _ctrlMagnitudElec.GetCanalSeleccionado();
                _formula.FechaInicio = _dtpFechaInicio.Value.Date;
                if (_chbxHasta.Checked)
                {
                    _formula.FechaFin = _dtpFechaFin.Value.Date;
                }
                else
                {
                    _formula.FechaFin = null;
                }
                _formula.Formula = _txtFormula.Text;
                MC_FormulaPuntoMedicionMgr.Instancia.Guardar(_formula);
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
            return resultado;
        }

        private void _chbxHasta_CheckedChanged(object sender, EventArgs e)
        {
            _dtpFechaFin.Visible = _chbxHasta.Checked;
            _txtSinDefinir.Visible = !_chbxHasta.Checked;
        }

        private void _btnEditarFormula_Click(object sender, EventArgs e)
        {
            FormEditorFormula form = new FormEditorFormula();
            if (form.Editar(_txtFormula.Text))
            {
                _txtFormula.Text = form.GetFormula();
            }
        }
    }
}
