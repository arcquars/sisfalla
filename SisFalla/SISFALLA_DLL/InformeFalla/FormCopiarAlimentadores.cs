using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ModeloSisFalla;
using CNDC.BaseForms;
using CNDC.ExceptionHandlerLib;
using BLL;

namespace SISFALLA
{
    public partial class FormCopiarAlimentadores : Form
    {
        InformeFalla _informeDestino;
        public FormCopiarAlimentadores()
        {
            InitializeComponent();
        }

        public DialogResult SeleccionarAlimentadores(InformeFalla informe, InformeFalla informeDestino)
        {
            _informeDestino = informeDestino;
            _dgvAlimentadores.DataSource = ModeloMgr.Instancia.OperacionAlimentadorMgr.GetOpeAlim(informe);
            BaseForm.VisualizarColumnas(_dgvAlimentadores, ColumnStyleManger.GetEstilos("CtrlAlimentadores", "_dgvAlimentadores"));
            return ShowDialog();
        }

        private void _btnAceptar_Click(object sender, EventArgs e)
        {
            if (_dgvAlimentadores.SelectedRows.Count > 0)
            {
                if (ContarComunes() > 0)
                {
                    MessageBox.Show(MessageMgr.Instance.GetMessage("ALIM_YA_REGISTRADOS"));
                }
                else if (BaseForm.EstaSeguro(MessageMgr.Instance.GetMessage("SEGURO_DE_COPIAR_ALIM")))
                {
                    CopiarAlimentadores();
                    DialogResult = System.Windows.Forms.DialogResult.OK;
                }
            }
            else
            {
                MessageBox.Show(MessageMgr.Instance.GetMessage("NO_ALIM_SELECCIONADOS"));
            }
        }

        private int ContarComunes()
        {
            int contador = 0;
            DataTable tablaAlimentadores = ModeloMgr.Instancia.OperacionAlimentadorMgr.GetOpeAlim(_informeDestino);
            foreach (DataGridViewRow r in _dgvAlimentadores.SelectedRows)
            {
                DataRow row = ((DataRowView)r.DataBoundItem).Row;
                foreach (DataRow row2 in tablaAlimentadores.Rows)
                {
                    if ((long)row[OperacionAlimentador.C_PK_COD_COMPONENTE] == (long)row2[OperacionAlimentador.C_PK_COD_COMPONENTE])
                    {
                        contador++;
                    }
                }
            }
            return contador;
        }

        private void CopiarAlimentadores()
        {
            foreach (DataGridViewRow r in _dgvAlimentadores.SelectedRows)
            {
                DataRow row = ((DataRowView)r.DataBoundItem).Row;
                ModeloMgr.Instancia.OperacionAlimentadorMgr.GopiarAlimentador(row, _informeDestino);
            }
        }

        private void _btnSalir_Click(object sender, EventArgs e)
        {
            DialogResult = System.Windows.Forms.DialogResult.Cancel;
        }
    }
}
