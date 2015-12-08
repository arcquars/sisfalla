using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CNDC.BaseForms;
using MenuQuantum;
using CNDC.BLL;
using DifusionInformacion;
using System.Reflection;
using CNDC.Pistas;
using System.IO;
using System.Threading;


namespace SISFALLA
{
    
    public partial class FormDifusion : BaseForm, IFuncionalidad
    {

        int _categoria;
        DateTime _fechaBase;
        string _motivo = string.Empty;
        Generador _generador;
        ProcesoPublicacion _estado = new ProcesoPublicacion();
        public FormDifusion()
        {
            InitializeComponent();
        }

        private void IniciarFormulario()
        {
            if (Sesion.Instancia.RolSIN == "CNDC")
            {
                MostrarCategoria();
            }
            //mostrarParametros();
        }

        private void IniciarFechaBase()
        {
            _fechaBase = DateTime.Now.Date; //new DateTime(2012, 10, 20);//DateTime.Now.Date;
            if (ConfigPublicacion.descripcionCategoria != "")
            {
                this.Text += " - " +  ConfigPublicacion.descripcionCategoria;
            }
        }

        private void AsegurarRutaLocal(string rutaLocal)
        {
            try
            {
                if (!File.Exists(rutaLocal))
                {
                    Directory.CreateDirectory(rutaLocal);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Directorio Local : " + ex.Message);
            }
        }

        private void MostrarCategoria()
        {
            RecuperarParametros();
            IniciarGenerador();
            IniciarFechaBase();
            AsegurarRutaLocal(ConfigPublicacion.rutaLocal);
            IniciarMotivo();
            IniciarMes();
            IniciarEstadoBotones();
            CargarDatosBase();
            CargarGuilla();

        }

        private void IniciarMotivo()
        {
            _panelRepublicar.Visible = false;
            _PanelProceso.Enabled = false;
        }
        private void IniciarProceso()
        {
            
            _PanelProceso.Enabled = true;
        }
        private void desactivarPanelParametros()
        {
            _panelParametros.Enabled = false;
        }
        private void IniciarMes()
        {
            _mes.Enabled = false;
        }

        private void IniciarEstadoBotones()
        {
            _btnPreparar.Enabled = _estado.iniciar;
            _btnCopiar.Enabled = _estado.copiar;
            _btnPublicar.Enabled = _estado.publicar;
            _btnTerminar.Enabled = _estado.final;
            
        }
        private void SetNumeroArchivos(int cantidad)
        {
            _lblCantidadArchivos.Text = cantidad + " Archivos procesados correctamente.";
        }

        private const int CP_NOCLOSE_BUTTON = 0x200;
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams mdiCp = base.CreateParams;
                mdiCp.ClassStyle = mdiCp.ClassStyle | CP_NOCLOSE_BUTTON;
                return mdiCp;
            }
        }

        private void IniciarGenerador()
        {
            try
            {
                _generador = InstanciarGenerador();
                if (_generador != null)
                {
                    _generador.SetConfiguracion(_categoria);
                    _generador.Parametros = Parametros;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Instacia - Categoria = " + _categoria + " : " + ex.Message);
            }

        }

        private void CargarDatosBase()
        {
            _fechaInicio.Value = _fechaBase.Date;
            _anio.Value = _fechaBase.Date;
            _mes.Items.Add("Enero");
            _mes.Items.Add("Febrero");
            _mes.Items.Add("Marzo");
            _mes.Items.Add("Abril"); 
            _mes.Items.Add("Mayo");
            _mes.Items.Add("Junio");
            _mes.Items.Add("Julio");
            _mes.Items.Add("Agosto");
            _mes.Items.Add("Septiembre");
            _mes.Items.Add("Octubre");
            _mes.Items.Add("Noviembre");
            _mes.Items.Add("Diciembre");
            _mes.SelectedIndex = (_fechaBase.Date).Month - 1;
            LimitarFechaFin();
        }

        private void CargarGuilla()
        {
            
        }
        private int CantidadArchivosProceso(List<detallePublicado> publicados)
        {
            int resultado = 0;
            if (publicados.Count > 0)
            {
                foreach (detallePublicado item in publicados)
                {
                    if (item.Detalle.StartsWith("OK"))
                    {
                        resultado++;
                    }
                }
            }
            return resultado;

        }

        private void RecuperarParametros()
                {
                    if (Parametros.ExiteParametro("CODPUBLICACION"))
                    {
                        _categoria = int.Parse(Parametros.DiccionarioParametros["CODPUBLICACION"]);
                    }
                    else 
                    {
                        _categoria = 0;
                        MessageBox.Show("No existe definido parametro de categoria publicacion para la opción...", "Parametros de opcion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }


        public ParametrosFuncionalidad Parametros
        {
            get; set;
        }

        public void Ejecutar()
        {
            IniciarFormulario();
            ShowDialog();
            
        }

        private bool Guardar()
        {
            bool resultado = false;

            return resultado;
        }

        private void _btnGuardar_Click(object sender, EventArgs e)
        {
            Guardar();
        }

        private void _btnCancelar_Click(object sender, EventArgs e)
        {
            //IniciarFormulario();
            this.Close();
        }

        private void LimpiarAvisoError()
        {
            _errorProvider.Clear();
        }

        private void MostrarFallo(Controles.CNDCButton _btnPreparar)
        {
            _errorProvider.Clear();
            if (_btnPreparar.Enabled)
            {
                _errorProvider.SetError(_btnPreparar, "Etapa Fallida: causa, ver detalle de los archivos procesados, corregir y reprocesar");
            }
        }

        private void SetGuilla(Controles.CNDCGridView Grilla)
        {
            
            if (Grilla != null)
            {
                Grilla.ReadOnly = true;
                Grilla.AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(248)))), ((int)(((byte)(251))))); ;
                Grilla.MultiSelect = true;
                Grilla.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                Grilla.Columns[0].Width = 170;
                Grilla.Columns[2].Width = 230;
            }

        }
        private void _btnAceptar_Click(object sender, EventArgs e)
        {
            if (!_generador.VerificarPublicacionCategoria(_fechaInicio.Value,_fechaFin.Value,_categoria))
            {
                _PanelProceso.Enabled = true;
                _panelParametros.Enabled = false;
                
            }
            else
            {
                _panelRepublicar.Visible = true;
                SetGrillaArchivosPublicados();
                if (_txtMotivo.Text != "")
                {
                    _PanelProceso.Enabled = true;
                    _panelParametros.Enabled = false;
                    _motivo = _txtMotivo.Text;
                }
                else
                {
                    MessageBox.Show("Ingresar el motivo para volver a publicar ...", "Publicacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    _txtMotivo.Focus();
                }
                
            }
        }


        private void SetGrillaArchivosPublicados()
        {
            List<detallePublicado> resultado = new List<detallePublicado>();
            LimpiarAvisoError();
            resultado = _generador.GetArchivosPublicadosPorCategoria(_fechaInicio.Value, _fechaFin.Value, _categoria);
            _dgvArchivosPub.DataSource = resultado;
            SetGuilla(_dgvArchivosPub);
        }

        private void CantidadArchivosDelProceso(Controles.CNDCGridView Grilla)
        {
            int contador = 0;
            Grilla.ClearSelection();
            if (Grilla.Rows.Count > 0)
            {
                foreach (DataGridViewRow row in Grilla.Rows)
                {
                    if (row.Cells[2].Value.ToString().StartsWith("OK"))
                    {
                        contador++;
                    }
                    else
                    {
                        row.Selected = true;
                    }
                }
                SetNumeroArchivos(contador);
            }

        }

        private void _btnPreparar_Click(object sender, EventArgs e)
        {

            List<detallePublicado> resultado = new List<detallePublicado>();
            LimpiarAvisoError();
            resultado = _generador.GetArchivosPreparados(_fechaInicio.Value, _fechaFin.Value, _categoria);
            _dgvArchivosPub.DataSource = resultado;
            CantidadArchivosDelProceso(_dgvArchivosPub);
            
            if (!_generador.ExisteErrorProceso(resultado))
            {
                _estado.SetCopiar(true);
                desactivarPanelParametros();
            }
            else
            {
                _estado.SetCopiar(false);
                MostrarFallo(_btnPreparar);
            }
            SetGuilla(_dgvArchivosPub);
            IniciarEstadoBotones();
            
        }


        private void _btnCopiar_Click(object sender, EventArgs e)
        {
            List<detallePublicado> resultado = new List<detallePublicado>();
            LimpiarAvisoError();
            resultado = _generador.GetArchivosCopiados(_fechaInicio.Value, _fechaFin.Value, _categoria);
            _dgvArchivosPub.DataSource = resultado;
            CantidadArchivosDelProceso(_dgvArchivosPub);
            if (!_generador.ExisteErrorProceso(resultado))
            {
                _estado.SetPublicar(true);
            }
            else
            {
                _estado.SetPublicar(false);
                MostrarFallo(_btnCopiar);
            }
            SetGuilla(_dgvArchivosPub);
            IniciarEstadoBotones();
        }

        private void _btnPublicar_Click(object sender, EventArgs e)
        {
            List<detallePublicado> resultado = new List<detallePublicado>();
            LimpiarAvisoError();
            resultado = _generador.GetArchivosPublicados(_fechaInicio.Value, _fechaFin.Value, _categoria,_motivo);
            _dgvArchivosPub.DataSource = resultado;
            CantidadArchivosDelProceso(_dgvArchivosPub);
            if (!_generador.ExisteErrorProceso(resultado))
            {
                _estado.SetFinalizar();
                DesactivarCancelar();
            }
            else
            {
                MostrarFallo(_btnPublicar);
            }
            SetGuilla(_dgvArchivosPub);
            IniciarEstadoBotones();
        }

        private void DesactivarCancelar()
        {
            _btnCancelar.Enabled = false;
        }



        private Generador InstanciarGenerador()
        {
            string assembly = Parametros.DiccionarioParametros["ASM_PROV_DATOS"];
            string clase = Parametros.DiccionarioParametros["CLASE_PROV_DATOS"];
            Assembly asm = Assembly.LoadFile(System.IO.Path.Combine(Application.StartupPath, assembly));
            PistaMgr.Instance.Debug("DifusionInformacion", "Instanciando Clase " + clase);
            Generador resultado = (Generador)asm.CreateInstance(clase);
            return resultado;
        }


        private void _fechaInicio_ValueChanged(object sender, EventArgs e)
        {
            _fechaBase = _fechaInicio.Value;
            AjustarFechas();
        }

        private void AjustarFechas()
        {
            try
            {
                _mes.SelectedIndex = _fechaBase.Month - 1;
                _mes.Refresh();
                _anio.Value = _fechaBase;
                _anio.Refresh();
                LimitarFechaFin();

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }

        private void LimitarFechaFin()
        {
            _fechaFin.MinDate = _fechaBase.Date;
            _fechaFin.Value = _fechaBase;
            _fechaFin.Refresh();
        }


        private void _btnTerminar_Click(object sender, EventArgs e)
        {

            Thread.Sleep(100);
            if (Directory.Exists(ConfigPublicacion.rutaLocal))
            {
                CNDC.UtilesComunes.UtilZip.BorrarDirectorio(ConfigPublicacion.rutaLocal, ConfigPublicacion.descripcionCategoria);
                UtilPublicar.VerificarEnlace(ConfigPublicacion.rutaVerificacionIntranet);
                UtilPublicar.VerificarEnlace(ConfigPublicacion.rutaVerificacionWeb);
            }
            _btnCancelar_Click(sender,e);
        }

        private void FormDifusion_FormClosed(object sender, FormClosedEventArgs e)
        {
            _generador.LLamarSiguienteOpcion();
        }


















    }
    class ProcesoPublicacion
    {
        public bool iniciar { get;set; }
        public bool preparar { get;set; }
        public bool copiar { get;set; }
        public bool publicar { get;set;}
        public bool final { get; set; }
        public ProcesoPublicacion()
        {
            iniciar = true;
            preparar = false;
            copiar = false;
            publicar = false;
            final = false;
        }

        private void IniciarTerminar()
        {
            iniciar = false;
            copiar = false;
            publicar = false;
        }
        public void SetCopiar(bool valor)
        {
            if (valor)
            {
                preparar = true;
                copiar = true;
            }
            else
            {
                preparar = true;
                copiar = false;
                publicar = false;
            }

        }
         public void SetPublicar(bool valor)
        {
            if (valor)
            {
                if (iniciar && preparar && copiar)
                {
                    publicar = true;
                }    
            }
            else
            {
                preparar = true;
                copiar = true;
                publicar = false;
            }
        }
         public void SetFinalizar()
         {
             if (iniciar && preparar && copiar && publicar)
             {
                 IniciarTerminar();
                 final = true;
             }
         }
    }
}
