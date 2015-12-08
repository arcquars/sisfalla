using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ModeloSisFalla;
using CNDC.BLL;
using CNDC.BaseForms;
using CNDC.ExceptionHandlerLib;
using BLL;

namespace SISFALLA
{
    public partial class FormSeleccionInforme : Form
    {
        private DataRow _rowSeleccionado;
        public FormSeleccionInforme()
        {
            InitializeComponent();
        }

        public DialogResult SeleccionarInforme(InformeFalla informe)
        {
            DataTable tabla = ModeloMgr.Instancia.InformeFallaMgr.GetInformesPorCodFalla(informe.PkCodFalla);
            QuitarInforme(informe,tabla);
            _dgvInformes.DataSource = tabla;
            BaseForm.VisualizarColumnas(_dgvInformes, ColumnStyleManger.GetEstilos("FormSeleccionInforme", "_dgvInformes"));
            return ShowDialog();
        }

        private void QuitarInforme(InformeFalla informe, DataTable tabla)
        {
            for (int i = 0; i < tabla.Rows.Count; i++)
            {
                DataRow row = tabla.Rows[i];
                InformeFalla inf = new InformeFalla(row);
                if (inf.Equals(informe))
                {
                    tabla.Rows.Remove(row);
                    break;
                }
            }
        }

        private void _dgvInformes_SelectionChanged(object sender, EventArgs e)
        {
            if (_dgvInformes.SelectedRows.Count > 0)
            {
                _rowSeleccionado = ((DataRowView)_dgvInformes.SelectedRows[0].DataBoundItem).Row;
            }
        }

        private void _btnAceptar_Click(object sender, EventArgs e)
        {
            if (_rowSeleccionado == null)
            {
                MessageBox.Show(MessageMgr.Instance.GetMessage("INFORME_NO_SELECCIONADO"));
            }
            else
            {
                DialogResult = System.Windows.Forms.DialogResult.OK;
            }
        }

        private void _btnSalir_Click(object sender, EventArgs e)
        {
            DialogResult = System.Windows.Forms.DialogResult.Cancel;
        }

        public InformeFalla GetInformeSeleccionado()
        {
            InformeFalla resutlado = null;
            if (_rowSeleccionado != null)
            {
                int codFalla = ObjetoDeNegocio.GetValor<int>(_rowSeleccionado[InformeFalla.C_PK_COD_FALLA]);
                long origen = ObjetoDeNegocio.GetValor<long>(_rowSeleccionado[InformeFalla.C_PK_ORIGEN_INFORME]);
                long tipo = ObjetoDeNegocio.GetValor<long>(_rowSeleccionado[InformeFalla.C_PK_D_COD_TIPOINFORME]);
                resutlado = ModeloMgr.Instancia.InformeFallaMgr.GetInforme(codFalla, origen, tipo);
            }
            return resutlado;
        }
    }
}
