using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MC;
using CNDC.BLL;

namespace MedicionComercialUI
{
    public partial class CtrlFiltro : UserControl
    {
        FiltroCompuesto<ResumenLecturaMedidor> _filtro;
        FiltroMedidor _filtroMedidor;
        FiltroAgente _filtroAgente;
        public event EventHandler FiltroModificado;
        public CtrlFiltro()
        {
            InitializeComponent();
            _filtro = new FiltroCompuesto<ResumenLecturaMedidor>();
            _filtroAgente = new FiltroAgente();
            _filtroMedidor = new FiltroMedidor();
            _filtro.AdicionarFiltro(_filtroAgente);
            _filtro.AdicionarFiltro(_filtroMedidor);

            if (Sesion.Instancia.SesionIniciada)
            {
                DataTable tabla = OraDalPersonaMgr.Instancia.GetAgentes();
                _cmbFiltroAgente.DisplayMember = "nom_cod_agente";
                _cmbFiltroAgente.ValueMember = "pk_cod_persona";
                _cmbFiltroAgente.DataSource = tabla;
            }
        }

        public bool CumpleCriterio(ResumenLecturaMedidor r)
        {
            return _filtro.CumpleCondicion(r); 
        }

        private void _chbxFiltroMedidor_CheckedChanged(object sender, EventArgs e)
        {
            _filtroMedidor.Activo = _chbxFiltroMedidor.Checked;
            OnFiltroModificado();
        }

        private void _chbxFiltroAgente_CheckedChanged(object sender, EventArgs e)
        {
            _filtroAgente.Activo = _chbxFiltroAgente.Checked;
            OnFiltroModificado();
        }

        private void _txtFiltroMedidor_TextChanged(object sender, EventArgs e)
        {
            _filtroMedidor.Criterio = _txtFiltroMedidor.Text;
            OnFiltroModificado();
        }

        private void _cmbFiltroAgente_SelectedIndexChanged(object sender, EventArgs e)
        {
            _filtroAgente.CodAgente = (long)_cmbFiltroAgente.SelectedValue;
            OnFiltroModificado();
        }

        private void OnFiltroModificado()
        {
            if (FiltroModificado != null)
            {
                FiltroModificado(this, EventArgs.Empty);
            }
        }
    }
}
