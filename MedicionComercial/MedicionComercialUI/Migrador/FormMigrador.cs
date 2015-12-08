using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ExcelLib;
using MenuQuantum;
using MC;

namespace MedicionComercialUI
{
    public partial class FormMigrador : Form, IFuncionalidad
    {
        DataTable tabla;
        public FormMigrador()
        {
            InitializeComponent();
        }

        private void _btnExaminar_Click(object sender, EventArgs e)
        {
            _ofdlg.ShowDialog();
        }

        private void _ofdlg_FileOk(object sender, CancelEventArgs e)
        {
            _txtArchivo.Text = _ofdlg.FileName;
            LectorXls lector = new LectorXls();
            tabla = lector.Leer(_ofdlg.FileName, 1, 4, 3, 174, 14);
            DataColumn colCanal1 = new DataColumn("Canal 1", typeof(string));
            tabla.Columns.Add(colCanal1);
            _dgvDatos.DataSource = tabla;
        }

        private void _btnMigrar_Click(object sender, EventArgs e)
        {
            List<long> tipoInf = new List<long>() { 112, 113, 114, 115, 116, 117 };
            foreach (DataRow r in tabla.Rows)
            {
                string columnaCanal1 = Menor(r);
                if (columnaCanal1 == null)
                {
                    r["Canal 1"] = DBNull.Value;
                }
                else
                {
                    r["Canal 1"] = columnaCanal1;
                }

                AC_Medidor medidor = OraDalMedidorMgr.Instancia.GetPorNombre((string)r[0]);
                if (medidor != null)
                {
                    for (int i = 8; i <= 13; i++)
                    {
                        RMedidorCanal rMedidorCanal = medidor.GetNuevoRMedidorCanal();
                        if (!(r["col" + i] is DBNull))
                        {
                            rMedidorCanal.ColArchivo = (string)r["col" + i];
                            rMedidorCanal.FkCodInfcanal = tipoInf[i - 8];
                            rMedidorCanal.Kc = (double)r["col14"];
                            rMedidorCanal.Canal = GetCanal(rMedidorCanal.ColArchivo, columnaCanal1);
                            List<MC_FormatoLectura> formatos = OraDalMC_FormatoLecturaMgr.Instancia.GetPorCodMedidor(medidor.PkCodMedidor);
                            if (formatos.Count > 0)
                            {
                                rMedidorCanal.FkCodFormato = formatos[0].PkCodFto;
                            }
                            OraDalRMedidorCanalMgr.Instancia.Guardar(rMedidorCanal);
                        }
                    }
                }
            }
        }

        private long GetCanal(string colActual, string colMenor)
        {
            int resultado = colActual[0] - colMenor[0] + 1;
            return resultado;
        }

        public ParametrosFuncionalidad Parametros { get; set; }
        public void Ejecutar()
        {
            ShowDialog();
        }

        private string Menor(DataRow row)
        {
            string resultado = "Z";

            for (int i = 0; i < 6; i++)
            {
                string nombreCol = "col" + (8 + i);
                if (!(row[nombreCol] is DBNull))
                {
                    string valor = row[nombreCol].ToString().Trim();
                    if (string.IsNullOrEmpty(valor) || valor == "-")
                    {

                    }
                    else if (string.Compare(valor, resultado) < 0)
                    {
                        resultado = valor;
                    }
                }
            }

            if (resultado == "Z")
            {
                resultado = null;
            }

            return resultado;
        }
    }
}
