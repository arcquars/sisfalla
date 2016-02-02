using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SISFALLA
{
    public partial class FormUpdateElaborado : Form
    {
        public FormUpdateElaborado()
        {
            InitializeComponent();
            //System.Console.WriteLine("xxx:: " + this.dataGridView1.Columns.Count);

            setDataTable();
        }

        private void setDataTable()
        {
            //this.dataGridView1.DataSource = CNDC.BLL.OraDalPersonaMgr.Instancia.ListUsuariosElaboradoPor();
            this.dataGridView1.DataSource = CNDC.BLL.OraDalPersonaMgr.Instancia.ListUsuariosElaboradoPor().DefaultView;
            this.dataGridView1.Columns[0].Visible = false;
            this.dataGridView1.Columns[1].Width = 200;
            this.dataGridView1.Columns[1].HeaderText = "Elaborado por";
            /*
            BindingSource bindingSource1 = new BindingSource();
            bindingSource1.DataSource = CNDC.BLL.OraDalPersonaMgr.Instancia.ListUsuariosElaboradoPor();

            this.dataGridView1.DataSource = bindingSource1;
            */
        }

        public FormUpdateElaborado(long codFalla, int tipoInforme, long codOrigen)
        {
            InitializeComponent();
            setDataTable();

            this.codFalla = codFalla;
            this.tipoInforme = tipoInforme;
            this.codOrigen = codOrigen;

        }


        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnGrabar_Click(object sender, EventArgs e)
        {
            try {
                int index = this.dataGridView1.SelectedRows[0].Index;
                DataGridViewRow selectionRow = dataGridView1.Rows[index];
                if (selectionRow.Index > 0)
                {
                    this.pkPerson = Convert.ToInt64(selectionRow.Cells[0].Value.ToString());
                    this.nomPersona = selectionRow.Cells[1].Value.ToString();
                    System.Console.WriteLine("Usuario seleccionado::" + this.pkPerson + " - " + this.nomPersona);
                    System.Console.WriteLine("Tipo de Informe::" + this.codFalla + " - " + this.codOrigen + " - " + this.tipoInforme);
                    this.Close();
                    ModeloSisFalla.ModeloMgr.Instancia.InformeFallaMgr.UpdateElavoradoPor(this.codFalla, this.tipoInforme, this.codOrigen, this.pkPerson, this.nomPersona);
                    this.lblError.Text = "";
                }
                else
                {
                    this.pkPerson = 0;
                    this.nomPersona = string.Empty;
                    System.Console.WriteLine("Seleccione al usuario.");
                    this.lblError.Text = "¡Seleccione al usuario!";
                }
            }catch(NullReferenceException ex)
            {
                Console.WriteLine(ex.Message);
                this.Close();
            }

        }

        public long getPkPerson()
        {
            return this.pkPerson;
        }

        public string getNomPersona()
        {
            return this.nomPersona;
        }

        private void splitContainer1_Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void splitContainer1_Panel2_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
