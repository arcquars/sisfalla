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
    public partial class FormRMedidorFormato : ABMBaseForm
    {
        MC_RPuntoMedicionFormato _puntoMedicionFormato;
        public FormRMedidorFormato()
        {
            InitializeComponent();
        }

        public bool Editar(MC_RPuntoMedicionFormato medFto)
        {
            bool resultado = true;
            _puntoMedicionFormato = medFto;
            CargarFormatos();
            resultado = ShowDialog() == DialogResult.OK;
            return resultado;
        }

        private void CargarFormatos()
        {
            DataTable tablaFormatos = OraDalMC_FormatoLecturaMgr.Instancia.GetTabla();
            _cmbFormato.DisplayMember = MC_FormatoLectura.C_DESCRIPCION_FTO;
            _cmbFormato.ValueMember = MC_FormatoLectura.C_PK_COD_FTO;
            _cmbFormato.DataSource = tablaFormatos;
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            _cmbFormato.SelectedValue = _puntoMedicionFormato.FkCodFormato; ;
            _txtNombreArchivo.Text = _puntoMedicionFormato.NombreArchivo;
            _chbxContieneFinIntervalo.Checked = _puntoMedicionFormato.ContieneFinIntervalo == 1;
        }

        protected override bool Guardar()
        {
            bool resultado = true;
            if (DatosSonValidos())
            {
                _puntoMedicionFormato.FkCodFormato = (long)_cmbFormato.SelectedValue;
                _puntoMedicionFormato.NombreArchivo = _txtNombreArchivo.Text;
                _puntoMedicionFormato.ContieneFinIntervalo = (short)(_chbxContieneFinIntervalo.Checked ? 1 : 0);
                OraDalMC_RPtoMedFtoMgr.Instancia.Guardar(_puntoMedicionFormato);
                DialogResult = DialogResult.OK;
            }
            return resultado;
        }

        private bool DatosSonValidos()
        {
            bool resultado = true;
            _errorProvider.Clear();
            
            if (_cmbFormato.SelectedValue == null)
            {
                _errorProvider.SetError(_cmbFormato, "Elija un formato de la lista.");
                resultado = false;
            }
            else if (_puntoMedicionFormato.EsNuevo && OraDalMC_RPtoMedFtoMgr.Instancia.Existe(_puntoMedicionFormato.FkCodPuntoMedicion, _puntoMedicionFormato.FkCodMedidor, (long)_cmbFormato.SelectedValue))
            {
                _errorProvider.SetError(_cmbFormato, "El formato seleccionado ya esta asignado al medidor.");
                resultado = false;
            }

            if (string.IsNullOrEmpty(_txtNombreArchivo.Text))
            {
                _errorProvider.SetError(_txtNombreArchivo, "Escriba el nombre del archivo.");
                resultado = false;
            }
            return resultado;
        }
    }
}
