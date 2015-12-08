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
    public partial class FormCopiarInterruptores : Form
    {
        InformeFalla _informeDestino;
        DataRow _rowSeleccionado = null;
        OperacionInterruptores _interruptorSeleccionado = null;
        public FormCopiarInterruptores()
        {
            InitializeComponent();
        }

        public DialogResult CopiarInterruptores(InformeFalla informeOrigen, InformeFalla informeDestino)
        {
            _informeDestino = informeDestino;
            DataTable _tablaInterruptores = ModeloMgr.Instancia.OperacionInterruptoresMgr.GetInterruptores(informeOrigen);
            _dgvInterruptor.DataSource = _tablaInterruptores;
            BaseForm.VisualizarColumnas(_dgvInterruptor, ColumnStyleManger.GetEstilos("CtrlInterruptoresReles", "_dgvInterruptor"));
            return ShowDialog();
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
        }

        private void _btnAceptar_Click(object sender, EventArgs e)
        {
            if (_dgvInterruptor.SelectedRows.Count > 0)
            {
                if (ContarComunes() > 0)
                {
                    MessageBox.Show(MessageMgr.Instance.GetMessage("HAY_INTERRUP_YA_REGIS"));
                }
                else if (BaseForm.EstaSeguro(MessageMgr.Instance.GetMessage("SEGURO_DE_COPIAR_INTERRUP")))
                {
                    CopiarInterruptores();
                    DialogResult = System.Windows.Forms.DialogResult.OK;
                }
            }
            else
            {
                MessageBox.Show(MessageMgr.Instance.GetMessage("NO_HAY_ALIM_SELEC"));
            }
        }

        private int ContarComunes()
        {
            int contador = 0;
            DataTable tablaInterruptores = ModeloMgr.Instancia.OperacionInterruptoresMgr.GetInterruptores(_informeDestino);
            foreach (DataGridViewRow r in _dgvInterruptor.SelectedRows)
            {
                DataRow row = ((DataRowView)r.DataBoundItem).Row;
                foreach (DataRow row2 in tablaInterruptores.Rows)
                {
                    if (((long)row[OperacionInterruptores.C_PK_COD_COMPONENTE] == (long)row2[OperacionInterruptores.C_PK_COD_COMPONENTE]) && ((DateTime)row[OperacionInterruptores.C_FECHA_APERTURA] == (DateTime)row2[OperacionInterruptores.C_FECHA_APERTURA]))
                    {
                        contador++;
                    }
                }
            }
            return contador;
        }

        private void CopiarInterruptores()
        {
            foreach (DataGridViewRow r in _dgvInterruptor.SelectedRows)
            {
                DataRow row = ((DataRowView)r.DataBoundItem).Row;                
                ModeloMgr.Instancia.OperacionInterruptoresMgr.Copiar(row, _informeDestino);
            }
        }

        private void _btnSalir_Click(object sender, EventArgs e)
        {
            DialogResult = System.Windows.Forms.DialogResult.Cancel;
        }
    }
}
