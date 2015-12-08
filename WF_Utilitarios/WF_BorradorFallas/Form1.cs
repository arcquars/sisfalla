using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CNDC.DAL;

namespace WF_BorradorFallas
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void _btnBorrarFallas_Click(object sender, EventArgs e)
        {
            string sql = "Delete FROM F_GF_RegFalla";
            ConfigConexionMgr c = new ConfigConexionMgr();
            c.Inicializar("quantum", "quantum");
            ConnexionOracleMgr conex = new ConnexionOracleMgr(c.CadenaConexion);
            conex.Actualizar(sql);
            MessageBox.Show("Datos Borrados");
        }
    }
}
