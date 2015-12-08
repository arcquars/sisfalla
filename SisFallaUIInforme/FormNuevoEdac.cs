using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CNDC.BaseForms;
using ModeloSisFalla;

namespace SisFallaUIInforme
{
    public partial class FormNuevoEdac : BaseForm
    {
        PeriodoEdac _periodoEdac;
        public FormNuevoEdac()
        {
            InitializeComponent();
            
        }
        public void SetPeriodo(int Categoria,string Agente,string fecha)
        {
            _periodoEdac = new PeriodoEdac();
            _periodoEdac.Categoria = Categoria;
            _periodoEdac.Agente = Agente;
            _periodoEdac.FechaInicioVigencia = fecha;
            CargarAlimentadores();
        }
        public PeriodoEdac GetPeriodo()
        {
            return _periodoEdac;
        }
        
        private void CargarAlimentadores()
        {
            _cmbEtapa.DataSource = ModeloMgr.Instancia.OperacionAlimentadorMgr.GetEtapasDeEdac(_periodoEdac.Categoria);
            _cmbEtapa.DisplayMember = "DESC_EDAC";
            _cmbEtapa.ValueMember = "COD_EDAC";
            _cmbAlimentador.DataSource = ModeloMgr.Instancia.OperacionAlimentadorMgr.GetAlimentadoresEdac(_periodoEdac.Agente);
            _cmbAlimentador.DisplayMember = "DESC_ALI";
            _cmbAlimentador.ValueMember = "COD_ALI";
        }

        private void _btnAceptar_Click(object sender, EventArgs e)
        {
            _periodoEdac.PkCodEdac = long.Parse(_cmbEtapa.SelectedValue.ToString());
            _periodoEdac.PKCodAlimentador = long.Parse(_cmbAlimentador.SelectedValue.ToString());
            if (DatosValidos())
            {
                ModeloMgr.Instancia.OperacionAlimentadorMgr.InsertarPeriodoEdac(_periodoEdac);
                DialogResult = DialogResult.OK;
            }
            else 
            {
                _cmbEtapa.Focus();
            }
        }

        private bool DatosValidos()
        {
            if (ModeloMgr.Instancia.OperacionAlimentadorMgr.ExistePeriodoEdac(_periodoEdac))
            {
                MessageBox.Show("El Periodo actual contiene El Alimentador y la Etapa seleccionados", "Advertencia");
                return false;
            }
            else
            {
                return true;
            }
        }

        private void _btnCancelar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }
    }
}
