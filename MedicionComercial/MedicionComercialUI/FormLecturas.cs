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
using MenuQuantum;
using LecturaArchivos;
using CNDC.UtilesComunes;
using System.IO;
using CNDC.Pistas;

namespace MedicionComercialUI
{
    public partial class FormLecturas : BaseForm, IFuncionalidad
    {
        EjecutorLectura _ejecutorLectura;
        public FormLecturas()
        {
            InitializeComponent();
            _ejecutorLectura = new EjecutorLectura();
        }

        public ParametrosFuncionalidad Parametros { get; set; }

        public void Ejecutar()
        {
            ShowDialog();
        }

        private void FormLecturas_Load(object sender, EventArgs e)
        {
            _lblFechaHoy.Text = "Fecha: " + DateTime.Now.ToString("dd/MMM/yyyy");
            _ejecutorLectura.ArchivoProcesado += new EventHandler<ArchivoProcesadoEventArgs>(_ejecutorLectura_ArchivoProcesado);
            _ejecutorLectura.Iniciar();
            _dgv.DataSource = _ejecutorLectura.TablaResumen;
            _dgv.Columns["FechaHoraPrimerRegistro"].DefaultCellStyle.Format = "dd/MMM/yyyy HH:mm";
            _dgv.Columns["FechaHoraUltimoRegistro"].DefaultCellStyle.Format = "dd/MMM/yyyy HH:mm";
        }

        delegate void Adicionar(object o, ArchivoProcesadoEventArgs e);
        void _ejecutorLectura_ArchivoProcesado(object sender, ArchivoProcesadoEventArgs e)
        {
            if (InvokeRequired)
            {
                this.Invoke(new Adicionar(_ejecutorLectura_ArchivoProcesado), sender, e);
            }
            else
            {
                lock (this)
                {
                    _ejecutorLectura.TablaResumen.Rows.Add(e.Resumen);
                }
                Application.DoEvents();
            }
        }

        private void AcomodarControles()
        {
            int y = 0;
            int idx = 0;
            _pnlResumen.VerticalScroll.Value = 0;
            foreach (CtrlLecturaMedidor ctrl in _pnlResumen.Controls)
            {
                if (ctrl.Visible)
                {
                    ctrl.Top = y;
                    ctrl.Width = _pnlResumen.Width;
                    ctrl.Anchor = AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top;
                    y += ctrl.Height;
                    if (idx % 2 == 1)
                    {
                        ctrl.BackColor = Color.FromArgb(201, 231, 241);
                    }
                    idx++;
                }
            }
        }

        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            base.OnFormClosed(e);
            _ejecutorLectura.Dispose();
            _ejecutorLectura = null;
        }

        private void _dgv_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            CtrlVisorDatosLectura ctrl = new CtrlVisorDatosLectura();
            ctrl.Dock = DockStyle.Fill;
            Form form = new Form();
            form.Text = "Datos de Lectura";
            form.Controls.Add(ctrl);
            ResumenLecturaMedidor r = (_dgv.SelectedRows[0].DataBoundItem as DataRowView).Row as ResumenLecturaMedidor;
            ctrl.Visualizar(r.PkCodPuntoMedicion, DateTime.ParseExact(r.FechaHoraPrimerRegistro.Substring(0, 11), "dd/MMM/yyyy", null), DateTime.ParseExact(r.FechaHoraUltimoRegistro.Substring(0, 11), "dd/MMM/yyyy", null));
            form.Show();
        }
    }
}
