using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CNDC.BaseForms;
using MC;

namespace MedicionComercialUI
{
    public partial class FormProgresoLectura : BaseForm
    {
        List<ResumenLecturaMedidor> _lista;
        DateTime _desde;
        DateTime _hasta;
        EjecutorLectura _ejecutorLectura;
        public FormProgresoLectura()
        {
            InitializeComponent();
        }      

        public void EjecutarLectura(List<ResumenLecturaMedidor> list, DateTime desde, DateTime hasta, EjecutorLectura ej)
        {
            _lista = list;
            _desde = desde;
            _hasta = hasta;
            _ejecutorLectura = ej;
            _pgbar.Maximum = _lista.Count;
            _bkwr.RunWorkerAsync();
            ShowDialog();
        }

        private void _bkwr_DoWork(object sender, DoWorkEventArgs e)
        {
            int i = 0;
            foreach (ResumenLecturaMedidor r in _lista)
            {
                if (r.Seleccionado)
                {
                    _ejecutorLectura.EjecutarLectura(r, _desde, _hasta);
                }
                i++;
                int porcentaje = (i * 100) / _lista.Count;
                _bkwr.ReportProgress(porcentaje);
            }
        }

        private void _bkwr_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            _pgbar.Value++;
        }

        private void _bkwr_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            _pgbar.Value = _pgbar.Maximum;
            DialogResult = DialogResult.OK;
        }

        private void _btnCancelar_Click(object sender, EventArgs e)
        {

        }
    }
}
