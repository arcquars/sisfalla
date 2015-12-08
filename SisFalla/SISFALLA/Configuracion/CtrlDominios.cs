using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ModeloSisFalla;
using CNDC.BaseForms;
using CNDC.BLL;
using BLL;

namespace SISFALLA
{
    public partial class CtrlDominios : UserControl
    {
        //private RRegFallaComponente _compComprometido;
        private DataTable _tablaDominio;
        private DataRow _rowSeleccionado = null;
        private List<DataRow> _nuevos = new List<DataRow>();
        private List<DataRow> _eliminados = new List<DataRow>();
        private List<DataRow> _modificados = new List<DataRow>();
        private DefDominio _ElementoSeleccionada;
        private string _tipoCodigo;
        public bool esGuardar = false;

        public CtrlDominios()
        {
            InitializeComponent();
        }

        public bool PanelToolVisible
        {
            get { return _pnlTool.Visible; }
            set { _pnlTool.Visible = value; }
        }

        public void VisualizarDominios(string TipoCodigo)
        {
            _tipoCodigo = TipoCodigo;
            _tablaDominio = ModeloMgr.Instancia.DefDominioMgr.GetDominio(_tipoCodigo);
            _dgvDominio.DataSource = _tablaDominio;
            BaseForm.VisualizarColumnas(_dgvDominio, ColumnStyleManger.GetEstilos("CtrlDominios", "_dgvDominio"));
            
        }

        
        private void _btnAdicionar_Click(object sender, EventArgs e)
        {
            DefDominio dominio = new DefDominio();
            FormDominios frmDom = new FormDominios();
            if (frmDom.Editar(dominio,_tipoCodigo) == DialogResult.OK)
            {
                DataRow r = _tablaDominio.NewRow();
                dominio.Llenar(r);
                
                _nuevos.Add(r);
                _tablaDominio.Rows.Add(r);
                
                esGuardar = true;
                
            }
        }

        private void _btnEditar_Click(object sender, EventArgs e)
        {
            if (_ElementoSeleccionada != null)
            {
                
                FormDominios frmDom = new FormDominios();
                if (frmDom.Editar(_ElementoSeleccionada,_tipoCodigo) == DialogResult.OK)
                {
                    _ElementoSeleccionada.Llenar(_rowSeleccionado);
                    //_rowSeleccionado[Persona.C_SIGLA] = frmAsigResp.AgenteSeleccionado.Sigla;
                    if (!_nuevos.Contains(_rowSeleccionado) && !_modificados.Contains(_rowSeleccionado))
                    {
                        _modificados.Add(_rowSeleccionado);
                        esGuardar = true;
                    }
                    
                }
            }
        }

        private void _btnEliminar_Click(object sender, EventArgs e)
        {
            if (_ElementoSeleccionada != null)
            {
                if (BaseForm.EstaSeguro())
                {
                    ModeloMgr.Instancia.DefDominioMgr.Borrar(_ElementoSeleccionada);
                    VisualizarDominios(_tipoCodigo);
                    
                }
            }
        }
        
        private void _dgvDominio_SelectionChanged(object sender, EventArgs e)
        {
            if (_dgvDominio.SelectedRows.Count > 0)
            {
                _rowSeleccionado = ((DataRowView)_dgvDominio.SelectedRows[0].DataBoundItem).Row;
                _ElementoSeleccionada = new DefDominio(_rowSeleccionado);
                _ElementoSeleccionada.EsNuevo = _nuevos.Contains(_rowSeleccionado);
            }
        }

        public void Guardar()
        {
            foreach (DataRow r in _nuevos)
            {
                DefDominio dominio = new DefDominio(r);

                dominio.EsNuevo = true;
                ModeloMgr.Instancia.DefDominioMgr.Guardar(dominio);
            }
            foreach (DataRow r in _modificados)
            {
                DefDominio dominio = new DefDominio(r);
                ModeloMgr.Instancia.DefDominioMgr.Guardar(dominio);
            }
            esGuardar = false;
        }
    }
}
