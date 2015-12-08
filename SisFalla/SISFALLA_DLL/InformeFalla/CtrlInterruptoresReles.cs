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
    public partial class CtrlInterruptoresReles : UserControl, ICtrlParteInformeFalla
    {
        private OperacionInterruptores _interruptorSeleccionado = null;
        private DataRow _rowSeleccionado = null;
        private InformeFalla _informe;
        private DataTable _tablaInterruptores;

        public CtrlInterruptoresReles()
        {
            InitializeComponent();
        }
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
                cndcToolStrip2.Enabled = !_soloLectura;
            }
        }

        public void RefrescarDatos()
        {
            Visualizar();
        }

        private void Visualizar()
        {
            _tablaInterruptores = ModeloMgr.Instancia.OperacionInterruptoresMgr.GetInterruptores(_informe);
            _dgvInterruptor.DataSource = _tablaInterruptores;
            BaseForm.VisualizarColumnas(_dgvInterruptor, ColumnStyleManger.GetEstilos("CtrlInterruptoresReles", "_dgvInterruptor"));

            if (Sesion.Instancia.RolSIN != "CNDC")
            {
                _tspCopiarInterruptor.Visible = false;
            }
        }

        private void _tspIngresarInterruptor_Click(object sender, EventArgs e)
        {
            OperacionInterruptores opInterruptor = _informe.CrearNuevoOpInterruptor();
            FormInterruptor frm = new FormInterruptor();
            if (frm.Editar(opInterruptor, GetListaInterruptores()) == DialogResult.OK)
            {
                Visualizar();
            }
        }

        private List<long> GetListaInterruptores()
        {
            List<long> resultado = new List<long>();
            DataTable tabla = (DataTable)_dgvInterruptor.DataSource;
            foreach (DataRow r in tabla.Rows)
            {
                resultado.Add((long)r[Componente.C_PK_COD_COMPONENTE]);
            }
            return resultado;
        }

        private void _tspEditarInterruptor_Click(object sender, EventArgs e)
        {
            if (_interruptorSeleccionado!=null)
            {
                FormInterruptor frm = new FormInterruptor();
                if (frm.Editar(_interruptorSeleccionado, new List<long>()) == DialogResult.OK)
                {
                    Visualizar();
                }
            }
        }

        private void _tspBorrarInterruptor_Click(object sender, EventArgs e)
        {
            if (_interruptorSeleccionado != null)
            {
                if (BaseForm.EstaSeguro())
                {
                    ModeloMgr.Instancia.OperacionInterruptoresMgr.Borrar(_interruptorSeleccionado);
                    Visualizar();
                }
            }
        }

        private void _dgvInterruptor_SelectionChanged(object sender, EventArgs e)
        {
            if (_dgvInterruptor.SelectedRows.Count > 0)
            {
                DataRowView drView = (DataRowView)_dgvInterruptor.SelectedRows[0].DataBoundItem;
                _rowSeleccionado = drView.Row;
                _interruptorSeleccionado = new OperacionInterruptores(_rowSeleccionado);
                _dgvReles.DataSource = ModeloMgr.Instancia.RelesOperadosMgr.GetTablaRelesOperador(_interruptorSeleccionado);
                BaseForm.VisualizarColumnas(_dgvReles, ColumnStyleManger.GetEstilos("CtrlInterruptoresReles", "_dgvReles"));
            }
            else
            {
                _dgvReles.DataSource = null;
            }
        }

        private void _tspCopiarInterruptor_Click(object sender, EventArgs e)
        {
            FormSeleccionInforme frmSelecInf = new FormSeleccionInforme();
            if (frmSelecInf.SeleccionarInforme(_informe) == DialogResult.OK)
            {
                FormCopiarInterruptores frmSelecAlim = new FormCopiarInterruptores();
                if (frmSelecAlim.CopiarInterruptores(frmSelecInf.GetInformeSeleccionado(), _informe) == DialogResult.OK)
                {
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
