using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Proyectos
{
    public partial class FormNuevoProyecto : Form
    {
        string tipoProy = string.Empty;
        string tipoProyPadre = string.Empty;

        public FormNuevoProyecto()
        {
            InitializeComponent();
            _cmbTipoProysTransmision.Enabled = false;
            _cmbTiposProysGeneracion.Enabled = false;
            CargarTiposProysDegeneracion();
            CargarTiposProysDeTransmision();
            CargarArbol();
        }

        private void CargarArbol()
        {
            treeView1.Nodes.Add("Proyectos de Generación");
            treeView1.Nodes[0].BackColor = Color.LightBlue;
            treeView1.Nodes[0].Nodes.Add("Hidroeléctrico");
            treeView1.Nodes[0].Nodes.Add("Térmico");
            treeView1.Nodes[0].Nodes[1].BackColor = Color.LightBlue;
            treeView1.Nodes[0].Nodes[1].Nodes.Add("Térmico a gas");
            treeView1.Nodes[0].Nodes[1].Nodes[0].BackColor = Color.LightBlue;
            treeView1.Nodes[0].Nodes[1].Nodes[0].Nodes.Add("Turbinas");
            treeView1.Nodes[0].Nodes[1].Nodes[0].Nodes.Add("Motores");

            treeView1.Nodes[0].Nodes[1].Nodes.Add("Térmico a diesel");
            treeView1.Nodes[0].Nodes[1].Nodes.Add("Térmico Dual Fuel");
            treeView1.Nodes[0].Nodes[1].Nodes.Add("Térmico Ciclo combinado");

            treeView1.Nodes[0].Nodes.Add("Geotérmico");
            treeView1.Nodes[0].Nodes.Add("Biomasa");
            treeView1.Nodes[0].Nodes.Add("Eólico");
            treeView1.Nodes[0].Nodes.Add("Solar");
            treeView1.Nodes.Add("Proyectos de Transmisión");
            treeView1.Nodes[1].BackColor = Color.LightBlue;
            treeView1.Nodes[1].Nodes.Add("Linea de transmisión");
            treeView1.Nodes[1].Nodes.Add("Transformador");
            treeView1.Nodes[1].Nodes.Add("Capacitor");
            treeView1.Nodes[1].Nodes.Add("Reactor");
        }

        private void _btnAceptar_Click(object sender, EventArgs e)
        {
            string tipoProy = string.Empty;
            if (_rbtGeneracion.Checked)
            {
                tipoProy = _cmbTiposProysGeneracion.SelectedItem.ToString();
            }
            else
            {
                tipoProy = _cmbTipoProysTransmision.SelectedItem.ToString();
            }

            FormABMProyectos form = new FormABMProyectos();
            form.setTipoProyecto(tipoProy);
            form.Show();
        }

        public enum TipoProy
        {
            Generacion,
            Transmision
        }

        private void _rbtGeneracion_CheckedChanged(object sender, EventArgs e)
        {
            _rbtGeneracion.Checked = _rbtGeneracion.Checked ? true : false;
            _btnTransmision.Checked = _rbtGeneracion.Checked ? false : true;
            _cmbTiposProysGeneracion.Enabled = true;
            _cmbTipoProysTransmision.Enabled = false;
        }

        private void CargarTiposProysDegeneracion()
        {
            List<string> lista = new List<string>();
            lista.Add("Hidroeléctrico");
            lista.Add("Térmico a gas");
            lista.Add("Biomasa");
            lista.Add("Geotérmico");
            lista.Add("Eólico");

            _cmbTiposProysGeneracion.DataSource = lista;
        }

        private void _btnTransmision_CheckedChanged(object sender, EventArgs e)
        {
            _rbtGeneracion.Checked = _btnTransmision.Checked ? false : true;
            _btnTransmision.Checked = _btnTransmision.Checked ? true : false;

            _cmbTiposProysGeneracion.Enabled = false;
            _cmbTipoProysTransmision.Enabled = true;
        }

        private void CargarTiposProysDeTransmision()
        {
            List<string> lista = new List<string>();
            lista.Add("Transmisión");
            _cmbTipoProysTransmision.DataSource = lista;
        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
        }

        private void treeView1_DoubleClick(object sender, EventArgs e)
        {
            // MessageBox.Show("Hola que tal " + treeView1.SelectedNode.Text);
            //FormABMProyectos form = new FormABMProyectos();
            //if (treeView1.SelectedNode.Text != "Proyectos de Generación" && treeView1.SelectedNode.Text != "Proyectos de Transmisión" && treeView1.SelectedNode.Text != "Térmico" && treeView1.SelectedNode.Text != "Térmico a gas")
            //{
            //    form.setTipoProyecto(treeView1.SelectedNode.Text);
            //    form.Show();
            //}
            tipoProy = treeView1.SelectedNode.Text;
            TreeNode nodoPadre = GetNodoPadre(treeView1.SelectedNode);
            tipoProyPadre = nodoPadre.Text;
            DialogResult = DialogResult.OK;
        }

        private TreeNode GetNodoPadre(TreeNode treeNode)
        {
            while (treeNode.Parent!=null)
            {
                treeNode = treeNode.Parent;
            }

            return treeNode;
        }
        
        public string GetTipoProyecto()
        {
            return tipoProy;
        }

        public string GetTipoProyectoPadre()
        {
            return tipoProyPadre;
        }
    }
}

