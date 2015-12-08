using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CNDC.BaseForms;
using OraDalProyectos;
using CNDC.BLL;
using ModeloProyectos;

namespace Proyectos
{
    public partial class FormProyectosHidrologicos : BaseForm
    {
        DataTable _tabla = new DataTable();
        ProyectoMaestro _proyectoSeleccionado;
        ProyectoMaestro _proyMaestro;
        DefDominio _tipoProyecto;
        public FormProyectosHidrologicos()
        {
            InitializeComponent();
            if (Sesion.Instancia.SesionIniciada)
            {
            }
        }

        private void CargarDatos()
        {
            _dgvProyectos.DataSource = OraDalProyectoMaestroMgr.Instancia.GetProyectosPorCodTipoProyecto(_txtNombreCodigoProyecto.Text.Trim(),(int)_tipoProyecto.CodDominio, _proyMaestro.PkProyectoMaestro);
            _dgvProyectos.Columns[ProyectoMaestro.C_NOMBRE].Width = 320;
            _dgvProyectos.Columns["CODIGO"].Width = 150;
            _dgvProyectos.Columns[2].Visible = false;
        }
       

        public ProyectoMaestro GetProySeleccionado()
        {
            return _proyectoSeleccionado;
        }

        private void _btnBuscar_Click(object sender, EventArgs e)
        {
            CargarDatos();
        }

        private void _dgvProyectos_SelectionChanged(object sender, EventArgs e)
        {
            if (_dgvProyectos.SelectedRows.Count > 0)
            {
                DataRow row = ((DataRowView)_dgvProyectos.SelectedRows[0].DataBoundItem).Row;
                int pkProyMaestro = int.Parse(row[2].ToString());
                if (pkProyMaestro == 0)
                {
                    _proyectoSeleccionado = new ProyectoMaestro();
                    _proyectoSeleccionado.EsNuevo = true;
                    _proyectoSeleccionado.Nombre = "";
                    _proyectoSeleccionado.Codigo = "";
                    _proyectoSeleccionado.PkProyectoMaestro = 0;
                }
                else
                {
                    _proyectoSeleccionado = OraDalProyectoMaestroMgr.Instancia.GetPorId<ProyectoMaestro>(pkProyMaestro, ProyectoMaestro.C_PK_PROYECTO_MAESTRO);
                }
            }
        }

        private void _dgvProyectos_DoubleClick(object sender, EventArgs e)
        {
            if (_proyectoSeleccionado != null)
            {
                this.DialogResult = DialogResult.OK;
                Close();
            }
        }

        public void SetTipoProyecto(DefDominio tipoProyecto, ProyectoMaestro proyMaestro)
        {
            _proyMaestro = proyMaestro;
            _tipoProyecto = tipoProyecto;
            CargarDatos();
        }

        private void _txtNombreCodigoProyecto_KeyDown(object sender, KeyEventArgs e)
        {
            if (Keys.Enter == e.KeyCode)
            {
                CargarDatos();
            }
        }
    }
}
