using CNDC.BaseForms;
using CNDC.BLL;
using ModeloSisFalla;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SisFallaUIInforme
{
    public partial class FormModificarSupervisor : BaseForm
    {
        private InformeFalla _informe;
        public Persona Persona { get; set; }

        public FormModificarSupervisor(InformeFalla informe)
        {
            InitializeComponent();

            cndcLabelCombo1.ComboBox.DisplayMember = Persona.C_NOM_PERSONA;
            cndcLabelCombo1.ComboBox.ValueMember = Persona.C_PK_COD_PERSONA;
            cndcLabelCombo1.ComboBox.DataSource = OraDalUsuarioMgr.Instancia.GetOperadores();
            cndcLabelCombo1.ComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            _informe = informe;
            _lblInforme.Text =   RegFalla.FormatearCodFalla(_informe.PkCodFalla.ToString());  
        }

        private void _btnCancel_Click(object sender, EventArgs e) 
        {
            DialogResult = System.Windows.Forms.DialogResult.Cancel; 
            this.Close();
        }

        private void _btnAceptar_Click(object sender, EventArgs e)
        {
            
            DataRowView drv = (DataRowView)cndcLabelCombo1.ComboBox.SelectedItem ;
            Persona = new Persona(drv.Row);
            if (ModeloMgr.Instancia.InformeFallaMgr.ModificarSupervisorInforme(_informe, Persona))
            {
                DialogResult = System.Windows.Forms.DialogResult.OK;
                _informe.CodPersona = Persona.PkCodPersona;
                _informe.ElaboradoPor = Persona.Nombre;
            }
            else
            { DialogResult = System.Windows.Forms.DialogResult.Cancel ; }
            this.Close();
        }
    }
}
