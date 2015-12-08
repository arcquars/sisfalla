using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Proyectos;
using ParserABNumber;
using MenuQuantum;
using CNDC.UtilesComunes;
using CNDC.BLL;
using OraDalDemandas;
using CNDC.BaseForms;

namespace DemandasUI
{
    public partial class FormMigradorBloquePrincipal : BaseForm, IFuncionalidad
    {
        DataTable _tablaBloque= new DataTable();
        public FormMigradorBloquePrincipal()
        {
            InitializeComponent();
            if (Sesion.Instancia.SesionIniciada)
            {
                
            }
        }

        private void CargarHeadersTablaBolque()
        {
            DataColumn c_PkSerie = new DataColumn("Pk_dato", typeof(long));
            DataColumn c_Anio = new DataColumn("Año", typeof(string));
            DataColumn c_Secuencia = new DataColumn("Bloque", typeof(string));
            DataColumn c_Enero = new DataColumn("Enero", typeof(double));
            DataColumn c_Febrero = new DataColumn("Febrero", typeof(double));
            DataColumn c_Marzo = new DataColumn("Marzo", typeof(double));
            DataColumn c_Abril = new DataColumn("Abril", typeof(double));
            DataColumn c_Mayo = new DataColumn("Mayo", typeof(double));
            DataColumn c_Junio = new DataColumn("Junio", typeof(double));
            DataColumn c_Julio = new DataColumn("Julio", typeof(double));
            DataColumn c_Agosto = new DataColumn("Agosto", typeof(double));
            DataColumn c_Septiembre = new DataColumn("Septiembre", typeof(double));
            DataColumn c_Octubre = new DataColumn("Octubre", typeof(double));
            DataColumn c_Noviembre = new DataColumn("Noviembre", typeof(double));
            DataColumn c_Diciembre = new DataColumn("Diciembre", typeof(double));

            _tablaBloque.Columns.Add(c_PkSerie);
            _tablaBloque.Columns.Add(c_Anio);
            _tablaBloque.Columns.Add(c_Secuencia);
            _tablaBloque.Columns.Add(c_Enero);
            _tablaBloque.Columns.Add(c_Febrero);
            _tablaBloque.Columns.Add(c_Marzo);
            _tablaBloque.Columns.Add(c_Abril);
            _tablaBloque.Columns.Add(c_Mayo);
            _tablaBloque.Columns.Add(c_Junio);
            _tablaBloque.Columns.Add(c_Julio);
            _tablaBloque.Columns.Add(c_Agosto);
            _tablaBloque.Columns.Add(c_Septiembre);
            _tablaBloque.Columns.Add(c_Octubre);
            _tablaBloque.Columns.Add(c_Noviembre);
            _tablaBloque.Columns.Add(c_Diciembre);

            _dgvDatos.DataSource = _tablaBloque;
            _dgvDatos.Columns[1].Frozen = true;
            FormatearDatosBloque();
        }

        private void _tsbVisualizar_Click(object sender, EventArgs e)
        {
            _tablaBloque.Rows.Clear();
            DataTable tabla = OraDalDatosBloquesMgr.Instancia.GetDatos();
            CopiarDatosATablaBloque(tabla);
            _dgvDatos.DataSource = _tablaBloque;
            _dgvDatos.Columns[1].Frozen = true;
            _dgvDatos.Columns[0].Visible = false;
            FormatoDeCeldas();
            FormatearDatosBloque();
        }

        private void CopiarDatosATablaBloque(DataTable tabla)
        {
            _tablaBloque.Rows.Clear();
            foreach (DataRow r in tabla.Rows)
            {
                DataRow row = _tablaBloque.NewRow();
                row[0] = r[0];
                row[1] = r[1];
                row[2] = r[2];
                row[3] = r[3];
                row[4] = r[4];
                row[5] = r[5];
                row[6] = r[6];
                row[7] = r[7];
                row[8] = r[8];
                row[9] = r[9];
                row[10] = r[10];
                row[11] = r[11];
                row[12] = r[12];
                row[13] = r[13];
                row[14] = r[14];
                _tablaBloque.Rows.Add(row);
            }
        }

        private void _btnExaminar_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
        }

        private void _btnCrear_Click(object sender, EventArgs e)
        {
            if (DatosValidos())
            {
                _tablaBloque.Rows.Clear();
                LectorXls lector = new LectorXls();
                Parser p = new Parser();
                _tablaBloque = lector.LeerSeriesBloques(0, _tablaBloque, openFileDialog1.FileName, 1, (int)_nudFilaInicio.Value, p.GetValor(_txtColumna.Text), (int)_nudFilaFin.Value, p.GetValor(_txtColumna.Text) + 11, (int)_nudAnioInicio.Value, (int)_nudAnioFin.Value, int.Parse(_txtCriterioBloque.Text));
                if (lector.GetResultado())
                {
                    _dgvDatos.DataSource = _tablaBloque;
                    _dgvDatos.Columns[1].Frozen = true;
                    _dgvDatos.Columns[0].Visible = false;
                    FormatoDeCeldas();
                    FormatearDatosBloque();
                }
                else
                {
                    _tablaBloque.Rows.Clear();
                    MessageBox.Show("Existen errores en la configuración de migración de datos.");
                }
            }
        }

        private void FormatearDatosBloque()
        {
            _dgvDatos.Columns[0].Width = 70;
            _dgvDatos.Columns[1].Width = 70;
            _dgvDatos.Columns[2].Width = 75;
            _dgvDatos.Columns[3].Width = 75;
            _dgvDatos.Columns[4].Width = 75;
            _dgvDatos.Columns[5].Width = 75;
            _dgvDatos.Columns[6].Width = 75;
            _dgvDatos.Columns[7].Width = 75;
            _dgvDatos.Columns[8].Width = 75;
            _dgvDatos.Columns[9].Width = 75;
            _dgvDatos.Columns[10].Width = 75;
            _dgvDatos.Columns[11].Width = 75;
            _dgvDatos.Columns[12].Width = 75;
            _dgvDatos.Columns[13].Width = 75;
            _dgvDatos.Columns[14].Width = 75;
            _dgvDatos.Columns[0].Visible = false;
        }

        private void FormatoDeCeldas()
        {
            switch ((int)_nudDecimales.Value)
            {
                case 0:
                    _dgvDatos.DefaultCellStyle.Format = "N0";
                    break;
                case 1:
                    _dgvDatos.DefaultCellStyle.Format = "N1";
                    break;
                case 2:
                    _dgvDatos.DefaultCellStyle.Format = "N2";
                    break;
                case 3:
                    _dgvDatos.DefaultCellStyle.Format = "N3";
                    break;
                case 4:
                    _dgvDatos.DefaultCellStyle.Format = "N4";
                    break;
                default:
                    break;
            }
            _dgvDatos.Refresh();
        }


        public ParametrosFuncionalidad Parametros { get; set; }

        public void Ejecutar()
        {
            CargarHeadersTablaBolque();
            ShowDialog();
        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
            _txtDocumento.Text = openFileDialog1.FileName;
        }

        private void _tsbGuardar_Click(object sender, EventArgs e)
        {
            if (_dgvDatos.Rows.Count>0)
            {
                DataTable tabla = OraDalDatosBloquesMgr.Instancia.GetDatos();
                if (tabla.Rows.Count > 0)
                {
                    OraDalDatosBloquesMgr.Instancia.EliminarDatos();
                }
                OraDalDatosBloquesMgr.Instancia.GuardarTablaBloque(_tablaBloque);
                MessageBox.Show("Los datos se guardaron de manera correcta.");
            }
        }

        private bool DatosValidos()
        {
            bool res = true;
            _errorProvider.Clear();
            if (!Utiles.EsEnteroPositivo(_txtCriterioBloque.Text))
            {
                res = false;
                _errorProvider.SetError(_txtCriterioBloque,"Tiene que registrar un número positivo.");
            }

            if (Utiles.EsCadenaVacia(_txtDocumento.Text))
            {
                res = false;
                _errorProvider.SetError(_txtDocumento, "Tiene que adicionar el documento a migrar.");
            }

            if (Utiles.EsCadenaVacia(_txtColumna.Text))
            {
                res = false;
                _errorProvider.SetError(_txtColumna, "Tiene que registrar el nombre de la columna a partir del cual se leeran los datos.");
            }
            return res;
        }

        private void _dgvDatos_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            if (_dgvDatos.RowCount > 0)
            {
                int idx = e.RowIndex;
                int anio = int.Parse(_dgvDatos.Rows[idx].Cells[1].Value.ToString());
                if (anio % 2 == 0)
                {
                    _dgvDatos.Rows[idx].DefaultCellStyle.BackColor = Color.LightGray;
                }
                else
                {
                    _dgvDatos.Rows[idx].DefaultCellStyle.BackColor = Color.White;
                }
            }
        }

        private void _btnLimpiar_Click(object sender, EventArgs e)
        {
            _tablaBloque.Rows.Clear();
            _dgvDatos.DataSource = _tablaBloque;
        }

        private void _tsbCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void _txtColumna_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsLetter(e.KeyChar) || e.KeyChar == '\b')
            { }
            else
            {
                e.Handled = true;
            }
        }
    }
}
