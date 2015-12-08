using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ModeloSisFalla;
using System.IO;
using CNDC.BaseForms;
using CNDC.ExceptionHandlerLib;
using BLL;

namespace SISFALLA
{
    public partial class CtrlAnalisisFalla : UserControl, ICtrlParteInformeFalla
    {
        InformeFalla _informe;
        AnalisisFalla _analisis = new AnalisisFalla();

        public CtrlAnalisisFalla()
        {
            InitializeComponent();
        }

        public InformeFalla Informe
        {
            set
            {
                _informe = value;
                Visualizar();
            }
        }

        private bool _soloLectura;
        public bool SoloLectura
        {
            get { return _soloLectura; }
            set
            {
                _soloLectura = value;
                cndcToolStrip1.Enabled = !_soloLectura;
                //_btnSeleccionarArchivo.Enabled = !_soloLectura;
                //_txtArchivo.Enabled = !_soloLectura;
                cndcGroupBox1.Enabled = !_soloLectura;
                AsegurarPanelAnalisis();
            }
        }

        public void RefrescarDatos()
        {
        }

        private void Visualizar()
        {
            _txtArchivo.Text = ModeloMgr.Instancia.AnalisisMgr.GetNombreArchivo(_informe.PkCodFalla);
            _dgvAlimentadores.DataSource = ModeloMgr.Instancia.OperacionAlimentadorMgr.GetOpeAlimConOpEdac(_informe);
            BaseForm.VisualizarColumnas(_dgvAlimentadores, ColumnStyleManger.GetEstilos("CtrlAlimentadores", "_dgvAlimentadores"), false);

            _analisis = ModeloMgr.Instancia.AnalisisMgr.GetAnalisis(_informe.PkCodFalla);
            if (_analisis == null)
            {
                _analisis = new AnalisisFalla();
                _analisis.PkCodFalla = _informe.PkCodFalla;
                _analisis.Observaciones = string.Empty;
                _analisis.Causa = string.Empty;
            }

            _txtCausa.Text = _analisis.Causa;
            _txtObservaciones.Text = _analisis.Observaciones;

            AsegurarPanelAnalisis();
            AsegurarLblCargaDesconectada();
        }

        private void AsegurarPanelAnalisis()
        {
            _pnlAnalisis.Enabled = !_soloLectura;//&& _dgvAlimentadores.Rows.Count > 0;            
        }
        private void AsegurarLblCargaDesconectada()
        {
            if (_dgvAlimentadores.Rows.Count > 0)
            {
                DataTable tablaAlim = _dgvAlimentadores.DataSource as DataTable;
                float cargaDesconectada = 0;
                foreach (DataRow r in tablaAlim.Rows)
                {
                    cargaDesconectada += (float)r[OperacionAlimentador.C_POT_DESC];
                }

                _lblCargaDesc.Value = cargaDesconectada;
            }
        }

        private void _btnSeleccionarArchivo_Click(object sender, EventArgs e)
        {
            if (_ofd.ShowDialog() == DialogResult.OK)
            {
                string nombreArchivo = Path.GetFileNameWithoutExtension(_ofd.FileName);
                if (NombreValido(nombreArchivo))
                {
                    _txtArchivo.Text = _ofd.FileName;
                }
                else 
                {
                    MessageBox.Show(MessageMgr.Instance.GetMessage("NOMBRE_ARCH_INVALIDO"), "Nombre de archivo no válido.");
                }
            }
        }

        private bool NombreValido(string nombreArchivo)
        {
            bool resultado = true;
            string nombreCorrecto = RegFalla.FormatearCodFalla(_informe.PkCodFalla.ToString()) + "_analisis";
            resultado = nombreArchivo == nombreCorrecto;
            return resultado;
        }

        private void _btnDescargar_Click(object sender, EventArgs e)
        {
            //byte[] b = ModeloMgr.Instancia.AnalisisMgr.GetArchivo(_informe.PkCodFalla);
            //_sfd.FileName = _txtArchivo.Text;
            //if (b != null && _sfd.ShowDialog() == DialogResult.OK)
            //{
            //    File.WriteAllBytes(_sfd.FileName, b);
            //}
        }

        bool btnGuardarClick = false;
        private void _tbtnGuardar_Click(object sender, EventArgs e)
        {
            btnGuardarClick = true;
            Guardar();
            btnGuardarClick = false;
        }

        public bool Guardar()
        {
            bool bandera = true;
            if (HayCambiosSinGuardar())
            {
                if (!btnGuardarClick)
                {
                    bandera = MessageBox.Show("Guardar cambios ?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes;
                }

                if (bandera)
                {
                    if (_txtArchivo.Text.IndexOf("\\") >= 0)
                    {
                        ModeloMgr.Instancia.AnalisisMgr.Guardar(_informe.PkCodFalla, _txtArchivo.Text);
                        Visualizar();
                    }

                    if (_pnlAnalisis.Enabled)
                    {
                        _analisis.Observaciones = _txtObservaciones.Text;
                        _analisis.Causa = _txtCausa.Text;
                        _analisis.PkCodFalla = _informe.PkCodFalla;
                        ModeloMgr.Instancia.AnalisisMgr.Guardar(_analisis);
                    }
                }
            }
            return true;
        }

        public bool HayCambiosSinGuardar()
        {
            bool resultado = false;
            if (_txtArchivo.Text.IndexOf("\\") >= 0)
            {
                resultado = true;
            }

            _txtCausa.Text = _txtCausa.Text.Trim();
            _txtObservaciones.Text = _txtObservaciones.Text.Trim();

            if (_analisis.Observaciones != _txtObservaciones.Text)
            {
                resultado = true;
            }

            if (_analisis.Causa != _txtCausa.Text)
            {
                resultado = true;
            }

            return resultado;
        }
    }
}
