using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CNDC.BaseForms;
using MenuQuantum;
using MC;

namespace MedicionComercialUI
{
    public partial class FormLecturaVirtuales : BaseForm, IFuncionalidad
    {
        DataTable _tablaPuntosMedVirtuales;
        public FormLecturaVirtuales()
        {
            InitializeComponent();
        }

        public ParametrosFuncionalidad Parametros { get; set; }

        public void Ejecutar()
        {
            ShowDialog();
        }

        protected override void OnLoad(EventArgs e)
        {
            _tablaPuntosMedVirtuales = OraDalMC_PuntoMedicionMgr.Instancia.GetParaLectura(_dtpDesde.Value.Date, _dtpHasta.Value.Date, TipoPuntoMedicion.Virtual);
            _dgv.DataSource = _tablaPuntosMedVirtuales;
            base.OnLoad(e);
        }

        private void _btnIniciar_Click(object sender, EventArgs e)
        {
            foreach (DataRow r in _tablaPuntosMedVirtuales.Rows)
            {
                long codPuntoMedicion = (long)r["pk_cod_punto_medicion"];
                string res = MC_LecturaMgr.Instancia.CalcularDatosLectura(codPuntoMedicion, _dtpDesde.Value.Date, _dtpHasta.Value.Date);
            }
        }
    }
}
