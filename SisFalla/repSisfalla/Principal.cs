using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace repSisfalla
{
    public partial class Principal : Form
    {
        public Principal()
        {
            InitializeComponent();
        }
        private void loadReportes(string rep, string tit, int codReporte, string param)
        {
          /*  PantallaReporte p = new PantallaReporte();
            p.informeDesplegado(rep, tit, codReporte,param,"","","");
            p.Refresh();
            p.Show();*/
        }

        private void reporteDeAgentesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            loadReportes("repAgenteSisfalla.rpt", "Reporte de Agentes del SIN ", 100,"");
        }

        private void reporteDToolStripMenuItem_Click(object sender, EventArgs e)
        {
            loadReportes("repComponenteAgente.rpt", "Reporte de Componentes por Agente ", 101,"");
        }

        private void reporteDeNodosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            loadReportes("repNodos.rpt", "Reporte de Nodos ", 102,"");
        }

        private void reporteDeLineasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            loadReportes("repComponenteParam.rpt", "Reporte de Lineas ", 103,"LT");
        }

        private void reporteDeTransformadoresToolStripMenuItem_Click(object sender, EventArgs e)
        {
            loadReportes("repComponenteParam.rpt", "Reporte de Transformadores ", 103, "TR");
        }

        private void alimentadoresToolStripMenuItem_Click(object sender, EventArgs e)
        {
            loadReportes("repComponenteParam.rpt", "Reporte de Alimentadores ", 103, "AL");
        }

        private void relesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            loadReportes("repComponenteParam.rpt", "Reporte de Reactores ", 103, "RE");
        }

        private void interruptoresToolStripMenuItem_Click(object sender, EventArgs e)
        {
            loadReportes("repComponenteParam.rpt", "Reporte de Interruptores ", 103, "IT");
        }

        private void capacitoresToolStripMenuItem_Click(object sender, EventArgs e)
        {
            loadReportes("repComponenteParam.rpt", "Reporte de Capacitores ", 103, "CP");
        }

        private void aTToolStripMenuItem_Click(object sender, EventArgs e)
        {
            loadReportes("repComponenteParam.rpt", "Reporte de Autotransformadores ", 103, "AT");
        }

        private void uGToolStripMenuItem_Click(object sender, EventArgs e)
        {
            loadReportes("repComponenteParam.rpt", "Reporte de Unidades Generación ", 103, "UG");
        }

        private void cSToolStripMenuItem_Click(object sender, EventArgs e)
        {
            loadReportes("repComponenteParam.rpt", "Reporte de Capacitores Serie ", 103, "CS");
        }

        private void iGToolStripMenuItem_Click(object sender, EventArgs e)
        {
            loadReportes("repComponenteParam.rpt", "Reporte de IG ", 103, "IG");
        }

        private void eOToolStripMenuItem_Click(object sender, EventArgs e)
        {
            loadReportes("repComponenteParam.rpt", "Reporte de EO ", 103, "EO");
        }

        private void preliminarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            loadReportes("repFalla.rpt", "INFORME DE FALLA Y DESCONEXIONES ", 104, "100064");
        }

        private void notificacionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            loadReportes("repNotificacion.rpt", "Reporte de Notificacion de Falla ", 105, "");
        }
        /*[STAThread]
        public static void Main()
        { Application.Run(new Principal()); }
        */
    }
}
