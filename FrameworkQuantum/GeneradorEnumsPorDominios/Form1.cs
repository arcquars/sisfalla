using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CNDC.DAL;

namespace GeneradorEnumsPorDominios
{
    public partial class Form1 : Form
    {
        ConfigConexionMgr _confMgr = new ConfigConexionMgr();
        ConnexionOracleMgr _conexion;
        DataTable _tablaCategorias;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            _confMgr.Inicializar("", "");
            _conexion = new ConnexionOracleMgr(_confMgr.CadenaConexion);
            _tablaCategorias = _conexion.EjecutarSql(
                "SELECT COD_CAT_DOMINIO,DESCRIPCION_DOMINIO,D_COD_TIPO_DOMINIO FROM P_DEF_CAT_DOMINIOS");
            DataColumn seleccionado = new DataColumn("Seleccion", typeof(bool));
            _tablaCategorias.Columns.Add(seleccionado);
            _dgvCategorias.DataSource = _tablaCategorias;
        }

        private void _btnOk_Click(object sender, EventArgs e)
        {
            List<string> codigos = new List<string>();
            foreach (DataRow r in _tablaCategorias.Rows)
            {
                if (!(r["Seleccion"] is DBNull))
                {
                    bool seleccionado = (bool)r["Seleccion"];
                    if (seleccionado)
                    {
                        codigos.Add((string)r["D_COD_TIPO_DOMINIO"]);
                    }
                }
            }

            if (codigos.Count == 0)
            {
                MessageBox.Show("No se ha seleccionado ninguna categoria.");
            }
            else
            {
                string codsSepPorComa = ListToString(codigos);
                string sql = "SELECT * FROM P_DEF_DOMINIOS WHERE d_cod_tipo IN ({0})";
                sql = string.Format(sql, codsSepPorComa);
                DataTable tablaDominios = _conexion.EjecutarSql(sql);
                if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    GeneradorEnum g = new GeneradorEnum();
                    g.CargarDatos(tablaDominios);
                    g.CrearEnums(_txtNamespace.Text, saveFileDialog1.FileName);
                }
            }
        }

        private string ListToString(List<string> codigos)
        {
            string resultado = string.Empty;
            foreach (string c in codigos)
            {
                if (resultado != string.Empty)
                {
                    resultado += ",";
                }
                resultado += "'" + c + "'";
            }
            return resultado;
        }
    }
}
