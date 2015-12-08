using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ExcelLib;
using CNDC.BLL;
using System.IO;
using MC;
using MenuQuantum;

namespace MedicionComercialUI
{
    public partial class FormMigradorMedidoresFto : Form, IFuncionalidad
    {
        DataTable tabla;
        public FormMigradorMedidoresFto()
        {
            InitializeComponent();
        }
        public ParametrosFuncionalidad Parametros { get; set; }
        public void Ejecutar()
        {
            ShowDialog();
        }

        private void _btnExaminar_Click(object sender, EventArgs e)
        {
            _ofdlg.ShowDialog();
        }

        private void _ofdlg_FileOk(object sender, CancelEventArgs e)
        {
            _txtArchivo.Text = _ofdlg.FileName;
            LectorXls lector = new LectorXls();
            tabla = lector.Leer(_ofdlg.FileName, 1, 2, 1, 172, 3);
            _dgvDatos.DataSource = tabla;
        }

        private void _btnMigrar_Click(object sender, EventArgs e)
        {
            foreach (DataRow r in tabla.Rows)
            {
                string codMedidor = ObjetoDeNegocio.GetValor<string>(r[0]);
                string fto = ObjetoDeNegocio.GetValor<string>(r[1]);
                string nomArchivo = ObjetoDeNegocio.GetValor<string>(r[2]);
                fto = fto + " " + Path.GetExtension(nomArchivo).Substring(1);

                if (codMedidor != null)
                {
                    codMedidor = codMedidor.Trim();
                }

                if (fto != null)
                {
                    fto = fto.Trim();
                }

                AC_Medidor medidor = OraDalMedidorMgr.Instancia.GetPorNombre(codMedidor);
                MC_FormatoLectura formato = OraDalMC_FormatoLecturaMgr.Instancia.GetPorDescripcion(fto);

                if (medidor != null && formato != null)
                {
                    MC_RMedidorFto rMedFto = new MC_RMedidorFto();
                    rMedFto.EsNuevo = true;
                    rMedFto.DCodEstado = "1";
                    rMedFto.PrioridadLectura = 1;
                    rMedFto.NombreArchivo = nomArchivo;
                    rMedFto.PkCodFormato = formato.PkCodFto;
                    rMedFto.PkCodMedidor = medidor.PkCodMedidor;
                    rMedFto.SecLog = 1;
                    OraDalMC_RMedidorFtoMgr.Instancia.Guardar(rMedFto);
                }
            }
        }
    }
}
