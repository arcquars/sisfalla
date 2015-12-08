using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MC;

namespace MedicionComercialUI
{
    public partial class CtrlLecturaMedidor : UserControl
    {
        ResumenLecturaMedidor _resumenLecMed;
        public CtrlLecturaMedidor()
        {
            InitializeComponent();
        }

        public ResumenLecturaMedidor ResumenLecturaMed
        { get { return _resumenLecMed; } }

        public void Visualizar(ResumenLecturaMedidor r)
        {
            _resumenLecMed = r;
            _chbxSeleccionado.Checked = r.Seleccionado;
            _txtNombreMedidor.Text = r.NombrePuntoMedicion;
            _txtDescripcion.Text = r.Descripcion;
            
            ///_dgvDatos.DataSource = r.Detalle;
            _dgvDatos.Columns["PkCodFormato"].Visible = false;
            //_dgvDatos.Height = (r.Detalle.Rows.Count + 1) * 22;
            if (_dgvDatos.Height > Height)
            {
                this.Height = _dgvDatos.Height + 6;
            }
            _dgvDatos.AsegurarColumnas(false);
        }

        public void Refrescar()
        {
            _dgvDatos.Refresh();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            e.Graphics.DrawLine(Pens.Black, 0, Height - 1, Width, Height - 1);
        }

        private void _chbxSeleccionado_Click(object sender, EventArgs e)
        {
            _resumenLecMed.Seleccionado = _chbxSeleccionado.Checked;
        }

        public void QuitarSeleccion()
        {
            _chbxSeleccionado.Checked = false;
            _resumenLecMed.Seleccionado = false;
        }

        public void Seleccionar()
        {
            _chbxSeleccionado.Checked = true;
            _resumenLecMed.Seleccionado = true;
        }
    }
}
