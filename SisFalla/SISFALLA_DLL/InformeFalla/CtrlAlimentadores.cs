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
    public partial class CtrlAlimentadores : UserControl, ICtrlParteInformeFalla
    {
        OperacionAlimentador _opAlimenSeleccionado = null;
        private InformeFalla _informe;
        private bool _soloLectura;

        public CtrlAlimentadores()
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

        public bool SoloLectura
        {
            get { return _soloLectura; }
            set
            {
                _soloLectura = value;
                cndcToolStrip3.Enabled = !_soloLectura;
            }
        }

        public void RefrescarDatos()
        {
            Visualizar();
        }

        private void Visualizar()
        {
            _dgvAlimentadores.DataSource = ModeloMgr.Instancia.OperacionAlimentadorMgr.GetOpeAlim(_informe);
            BaseForm.VisualizarColumnas(_dgvAlimentadores, ColumnStyleManger.GetEstilos("CtrlAlimentadores", "_dgvAlimentadores"),false);
            
            if (Sesion.Instancia.RolSIN != "CNDC")
            {
                _tspCopiarAlimentador.Visible = false;
            }
        }

        private void _tspIngresarAlimentador_Click(object sender, EventArgs e)
        {
            OperacionAlimentador opAlimentador = _informe.CrearNuevoOpAlimentador();
            FrmAlimentador frmAlimentador = new FrmAlimentador();
            if (frmAlimentador.Editar(opAlimentador, GetListaAlimentadoresEnUso()) == DialogResult.OK)
            {
                Visualizar();
            }
        }

        private List<long> GetListaAlimentadoresEnUso()
        {
            List<long> resultado = new List<long>();
            DataTable tabla = (DataTable)_dgvAlimentadores.DataSource;
            foreach (DataRow r in tabla.Rows)
            {
                resultado.Add((long)r[Componente.C_PK_COD_COMPONENTE]);
            }
            return resultado;
        }

        private void _tspEditarAlimentador_Click(object sender, EventArgs e)
        {
            if (_opAlimenSeleccionado != null)
            {
                FrmAlimentador frmAlimentador = new FrmAlimentador();
                if (frmAlimentador.Editar(_opAlimenSeleccionado, new List<long>()) == DialogResult.OK)
                {
                    Visualizar();
                }
            }
        }

        private void _dgvAlimentadores_SelectionChanged(object sender, EventArgs e)
        {
            if (_dgvAlimentadores.SelectedRows.Count > 0)
            {
                DataRowView drView = (DataRowView)_dgvAlimentadores.SelectedRows[0].DataBoundItem;
                _opAlimenSeleccionado = new  OperacionAlimentador(drView.Row);
            }
            else
            {
                _opAlimenSeleccionado = null;
            }
        }

        private void _tspBorrarAlimentador_Click(object sender, EventArgs e)
        {
            if (_opAlimenSeleccionado != null)
            {
                if (BaseForm.EstaSeguro())
                {
                    ModeloMgr.Instancia.OperacionAlimentadorMgr.Borrar(_opAlimenSeleccionado);
                    Visualizar();
                }
            }
        }

        private void _tspCopiarAlimentador_Click(object sender, EventArgs e)
        {
            FormSeleccionInforme frmSelecInf = new FormSeleccionInforme();
            if (frmSelecInf.SeleccionarInforme(_informe) == DialogResult.OK)
            {
                FormCopiarAlimentadores frmSelecAlim = new FormCopiarAlimentadores();
                if (frmSelecAlim.SeleccionarAlimentadores(frmSelecInf.GetInformeSeleccionado(), _informe) == DialogResult.OK)
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
