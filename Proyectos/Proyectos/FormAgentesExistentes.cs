using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CNDC.BLL;
using CNDC.BaseForms;

namespace Proyectos
{
    public partial class FormAgentesExistentes : BaseForm
    {
        Persona _persona;
        public FormAgentesExistentes()
        {
            InitializeComponent();
            if (Sesion.Instancia.SesionIniciada)
            {
                CargarAgentesRegistrados();
            }
        }

        private void CargarAgentesRegistrados()
        {
            _dgvAgentes.DataSource = OraDalPersonaMgr.Instancia.GetAgentesRegistrados();
            _dgvAgentes.Columns[0].Visible = false;
            _dgvAgentes.Columns[1].Width = 320;
            _dgvAgentes.Columns[2].Width = 100;
            _dgvAgentes.Columns[3].Width = 200;
            _dgvAgentes.Columns[4].Width = 100;

        }

        private void _dgvAgentes_DoubleClick(object sender, EventArgs e)
        {
            if (_persona != null)
            {
                this.DialogResult = DialogResult.OK;
                Close();
            }
        }

        public Persona GetAgente()
        {
            return _persona;
        }

        private void _dgvAgentes_SelectionChanged(object sender, EventArgs e)
        {
            if (_dgvAgentes.SelectedRows.Count > 0)
            {
                DataRow row = ((DataRowView)_dgvAgentes.SelectedRows[0].DataBoundItem).Row;
                int pkPersona = int.Parse(row[0].ToString());
                if (pkPersona == 0)
                {
                    _persona = new Persona();
                    _persona.EsNuevo = true;
                    _persona.Nombre = "";
                    _persona.Sigla = "" ;
                    _persona.Direccion = "";
                    _persona.Telefono = "";
                }
                else
                {
                   _persona = OraDalPersonaMgr.Instancia.GetPorId<Persona>(pkPersona,Persona.C_PK_COD_PERSONA);
                }
            }
        }
    }
}
