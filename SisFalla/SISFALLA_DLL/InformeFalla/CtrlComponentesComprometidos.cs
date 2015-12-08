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
        }

        private void Visualizar()
        {
            _dgvCompoComprometido.DataSource = ModeloMgr.Instancia.RRegFallaComponenteMgr.GetTablaVisualizable(_informe);
            BaseForm.VisualizarColumnas(_dgvCompoComprometido, ColumnStyleManger.GetEstilos("CtrlComponentesComprometidos", "_dgvCompoComprometido"));
        }

        private void _tspIngresarCompo_Click(object sender, EventArgs e)
        {
            FormCompComprometido frmAdComp = new FormCompComprometido();
            RRegFallaComponente compCompr = _informe.CrearNuevoRRegFallaComponente();
            if (frmAdComp.Editar(compCompr, GetListaCompo()) == DialogResult.OK)
            {
                Visualizar();
            }
        }

        private void _tspEditarCompo_Click(object sender, EventArgs e)
        {
            if (_compComprSeleccionado != null)
            {
                FormCompComprometido frmAdComp = new FormCompComprometido();
                if (frmAdComp.Editar(_compComprSeleccionado, new List<long>()) == DialogResult.OK)
                {
                    Visualizar();
                }
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
                DataRow r = ((DataRowView)_dgvCompoComprometido.SelectedRows[0].DataBoundItem).Row;
                _compComprSeleccionado = new RRegFallaComponente(r);
                _ctrlTiemposDetalle.VisualizarTiempos(_compComprSeleccionado);
                _ctrlAsignacionResponsabilidad.VisualizarAsigResp(_compComprSeleccionado);
            }
            else
            {
                _ctrlTiemposDetalle.VisualizarTiempos(new RRegFallaComponente());
                _ctrlAsignacionResponsabilidad.VisualizarAsigResp(new RRegFallaComponente());
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
    }
}
