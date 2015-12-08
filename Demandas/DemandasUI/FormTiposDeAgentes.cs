using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CNDC.BLL;
using CNDC.BaseForms;

namespace DemandasUI
{
    public partial class FormTiposDeAgentes : BaseForm
    {
        DefDominio _dominio;
        public FormTiposDeAgentes()
        {
            InitializeComponent();
            if (Sesion.Instancia.SesionIniciada)
            {
                CargarTiposAgentes();
            }
        }

        private void CargarTiposAgentes()
        {
            DefDominioMgr mgr= new DefDominioMgr();
            _dgvTiposAgentes.DataSource = mgr.GetTiposAgentes();
            _dgvTiposAgentes.Columns[0].Visible = false;
            _dgvTiposAgentes.Columns[1].Width = 250;
            _dgvTiposAgentes.Refresh();
        }

        private void _dgvTiposAgentes_DoubleClick(object sender, EventArgs e)
        {
            if (_dominio != null)
            {
                this.DialogResult = DialogResult.OK;
                Close();
            }
        }

        public DefDominio GetTipoAgente()
        {
            return _dominio;
        }

        private void _dgvTiposAgentes_SelectionChanged(object sender, EventArgs e)
        {
            if (_dgvTiposAgentes.SelectedRows.Count > 0)
            {
                DataRow row = ((DataRowView)_dgvTiposAgentes.SelectedRows[0].DataBoundItem).Row;
                int codDominio = int.Parse(row[0].ToString());
                if (codDominio == 0)
                {
                    _dominio = new DefDominio();
                    _dominio.EsNuevo = true;
                    _dominio.Descripcion = "";
                    _dominio.CodDominio = 0;
                }
                else
                {
                    DefDominioMgr mgr = new DefDominioMgr();
                    _dominio = mgr.GetPorId<DefDominio>(codDominio, DefDominio.C_COD_DOMINIO);
                }
            }
        }
    }
}
