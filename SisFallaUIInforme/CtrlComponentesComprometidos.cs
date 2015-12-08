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
using BLL;

namespace SISFALLA
{
    public partial class CtrlComponentesComprometidos : UserControl, ICtrlParteInformeFalla
    {
        RRegFallaComponente _compComprSeleccionado = null;
        RRegFallaComponente _compComprSeleccionadoGrid = null;
        DataRow _rowSeleccionado = null;
        public CtrlComponentesComprometidos()
        {
            InitializeComponent();
        }

        private InformeFalla _informe;
        public InformeFalla Informe
        {
            set
            {
                _informe = value;
                Visualizar();
            }
        }

        private bool _soloLectura;
        public bool SoloLectura
        {
            get { return _soloLectura; }
            set
            {
                _soloLectura = value;
                cndcToolStrip1.Enabled = !_soloLectura;
                //_ctrlTiemposDetalle.SoloLectura = value;
            }
        }

        public void RefrescarDatos()
        {
            Visualizar();
            AsegurarComponeteSeleccionado();

        }

        private void Visualizar()
        {
            _dgvCompoComprometido.DataSource = ModeloMgr.Instancia.RRegFallaComponenteMgr.GetTablaVisualizable(_informe);
            BaseForm.VisualizarColumnas(_dgvCompoComprometido, ColumnStyleManger.GetEstilos("CtrlComponentesComprometidos", "_dgvCompoComprometido"));
        }

        private void AsegurarComponeteSeleccionado()
        {
            if (_compComprSeleccionadoGrid != null)
            {
                for (int i = 0; i < _dgvCompoComprometido.Rows.Count; i++)
                {
                    DataRow r = ((DataRowView)_dgvCompoComprometido.Rows[i].DataBoundItem).Row;
                    if (_compComprSeleccionadoGrid.PkCodComponente == (long)r["Pk_Cod_Componente"])
                    {
                        _dgvCompoComprometido.Rows[i].Selected = true;
                        _dgvCompoComprometido.BindingContext[_dgvCompoComprometido].Position = i;
                        if (i < _dgvCompoComprometido.FirstDisplayedScrollingRowIndex)
                        {
                            _dgvCompoComprometido.FirstDisplayedScrollingRowIndex = i;
                        }
                        else if (i >= _dgvCompoComprometido.FirstDisplayedScrollingRowIndex + 7)
                        {
                            _dgvCompoComprometido.FirstDisplayedScrollingRowIndex = i - 7 + 1;
                        }
                        //_dgvCompoComprometido.FirstDisplayedScrollingRowIndex = i;
                    }
                    else
                    {
                        _dgvCompoComprometido.Rows[i].Selected = false;
                    }
                }
            }

        }

        private void _tspIngresarCompo_Click(object sender, EventArgs e)
        {
            FormCompComprometido frmAdComp = new FormCompComprometido();
            RRegFallaComponente compCompr = _informe.CrearNuevoRRegFallaComponente();
            if (frmAdComp.Editar(compCompr, GetListaCompo()) == DialogResult.OK)
            {
                Visualizar();
            }
            this.RefrescarDatos();
        }

        private void _tspEditarCompo_Click(object sender, EventArgs e)
        {
            if (_compComprSeleccionado != null)
            {
                _compComprSeleccionadoGrid = _compComprSeleccionado;
                FormCompComprometido frmAdComp = new FormCompComprometido();
                if (frmAdComp.Editar(_compComprSeleccionado, new List<long>()) == DialogResult.OK)
                {
                    ModeloMgr.Instancia.RRegFallaComponenteMgr.Refrescar(_rowSeleccionado);
                    _dgvCompoComprometido.Refresh();                    
               //     AsegurarComponenteSeleccionado();
                    //Visualizar();
                }
                this.RefrescarDatos();
            }
        }

        private List<long> GetListaCompo()
        {
            List<long> resultado = new List<long>();
            DataTable tabla = (DataTable)_dgvCompoComprometido.DataSource;
            foreach (DataRow r in tabla.Rows)
            {
                resultado.Add((long)r[Componente.C_PK_COD_COMPONENTE]);
            }
            return resultado;
        }

        private void _dgvCompoComprometido_SelectionChanged(object sender, EventArgs e)
        {
            if (_dgvCompoComprometido.SelectedRows.Count > 0)
            {
                _rowSeleccionado = ((DataRowView)_dgvCompoComprometido.SelectedRows[0].DataBoundItem).Row;
            }
            else
            {
                _rowSeleccionado = null;
            }
            AsegurarComponenteSeleccionado();
        }

        private void AsegurarComponenteSeleccionado()
        {
            if (_rowSeleccionado == null)
            {
                _compComprSeleccionado = null;
                _ctrlTiemposDetalle.VisualizarTiempos(new RRegFallaComponente());
                _ctrlAsignacionResponsabilidad.VisualizarAsigResp(new RRegFallaComponente());
            }
            else
            {
                _compComprSeleccionado = new RRegFallaComponente(_rowSeleccionado);
                _ctrlTiemposDetalle.VisualizarTiempos(_compComprSeleccionado);
                _ctrlAsignacionResponsabilidad.VisualizarAsigResp(_compComprSeleccionado);
            }
        }

        private void _tspBorrarCompo_Click(object sender, EventArgs e)
        {
            if (_compComprSeleccionado != null)
            {
                if (BaseForm.EstaSeguro())
                {
                    ModeloMgr.Instancia.RRegFallaComponenteMgr.Borrar(_compComprSeleccionado);
                    Visualizar();
                }
            }
        }

        public bool Guardar()
        {
            return true;
        }

        public bool HayCambiosSinGuardar()
        {
            return false;
        }
    }
}
