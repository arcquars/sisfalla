using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ModeloProyectos;
using OraDalProyectos;
using CNDC.BLL;
using CNDC.ExceptionHandlerLib;
using System.IO;

namespace Proyectos
{
    public partial class CtrlDatosGenerales : CtrlDatosBase, IControles
    {
        Control _controlLocalizacion;
        DefDominio _tipoProyecto = null;
        DefDominio _etapaProyectoACrear = null;
        DefDominio _tipoProyectoPadre = null;
        ProyectoMaestro _proyectoMaestro;
        bool _esNuevoProyMaestro = false;
        bool _esEditable = false;
        bool _seGuardo = false;
        Proyecto _proyectoActual;
        int _porcentaje = 0;
        public event EventHandler ProyectoGuardado;

        PictureBox _pbxAuxiliar = new PictureBox();
        public CtrlDatosGenerales()
        {
            InitializeComponent();
            if (Sesion.Instancia.SesionIniciada)
            {
                CargarDatosEntidadEjecutora();
                CargarEtapasDelProyecto();
                _tsbCancelar.Enabled = false;
                _pbxAuxiliar.Visible = false;
                _pnlEsquema.Controls.Add(_pbxAuxiliar);
                
            }
        }

        public void SetTipoProyecto(DefDominio tipoProyecto, DefDominio tipoProyectoPadre)
        {
            _tipoProyecto = tipoProyecto;
            _tipoProyectoPadre = tipoProyectoPadre;
            CargarControlesDeLocalizacion();
        }

        public void SetEditable(bool esEditable)
        {
        }

        private void CargarEtapasDelProyecto()
        {
            _cmbEtapa.DisplayMember = "Descripcion";
            _cmbEtapa.ValueMember = "CodDominio";
            DefDominioMgr mgr = new DefDominioMgr();
            _cmbEtapa.DataSource = mgr.GetListaDominio(DominiosProyectos.D_COD_ETAPA_PROYECTO);
        }

        private void CargarDatosEntidadEjecutora()
        {
            _cmbEntidadeResponsable.DisplayMember = Persona.C_NOM_PERSONA;
            _cmbEntidadeResponsable.ValueMember = Persona.C_PK_COD_PERSONA;
            DefDominioMgr mgr = new DefDominioMgr();
            _cmbEntidadeResponsable.DataSource = OraDalPersonaMgr.Instancia.GetEntidadResponsableProyectos();
        }

        private void _btnEsquema_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
            _txtEsquema.Text = openFileDialog1.FileName;
            _proyectoActual.Esquema = System.IO.File.ReadAllBytes(openFileDialog1.FileName);
            VisualizarEsquema();
        }

        private void VisualizarEsquema()
        {
            if (_proyectoActual.Esquema == null)
            {
                _pbxEsquema.Image = null;
            }
            else
            {
                System.IO.MemoryStream streamImagen = new System.IO.MemoryStream(_proyectoActual.Esquema);
                _pbxEsquema.Image = Image.FromStream(streamImagen);
            }
            _rbtnReducida.Checked=true;
            AsegurarVistaEsquema();
        }

        private void CargarControlesDeLocalizacion()
        {
            _pnlLocalizacion.Controls.Clear();
            List<string> listaDeNombresDeControles = OraDalTipoProyectoControlesMgr.Instancia.GetPorIdTipoProyecto(_tipoProyectoPadre.CodDominio);
            if (listaDeNombresDeControles.Count > 0)
            {
                string c = listaDeNombresDeControles[0];
                _controlLocalizacion = (Control)System.Reflection.Assembly.GetExecutingAssembly().CreateInstance(c);
                _controlLocalizacion.Dock = DockStyle.Fill;
                _pnlLocalizacion.Controls.Add(_controlLocalizacion);
                
            }
        }

        private void HabilitarControles()
        {
            OnEstadoDeEdicionModificado(true);
            _txtDescripcion.ReadOnly = false;
            _txtNombre.Enabled = false;
            _cmbEntidadeResponsable.Enabled = true;
            _cmbEtapa.Enabled = false;
            _btnEsquema.Enabled = true;
            _dtpFechaRegistro.Enabled = _proyectoActual.EsNuevo?true: false;
            _tsbCancelar.Enabled = true;
            _tsbGuardar.Enabled = true;
            _tsbEditar.Enabled = false;
            _txtEsquema.Enabled = true;
            _btnAddEntidadResponsable.Enabled = true;
        }

        public void DeshabilitarControles()
        {
            OnEstadoDeEdicionModificado(false);
            _txtDescripcion.ReadOnly = true;
            _txtEsquema.Enabled = false;
            _txtNombre.Enabled = false;
            _cmbEntidadeResponsable.Enabled = false;
            _cmbEtapa.Enabled = false;
            _btnEsquema.Enabled = false;
            _dtpFechaRegistro.Enabled = false;
            _tsbCancelar.Enabled = false;
            _tsbGuardar.Enabled = false;
            _tsbEditar.Enabled = true;
            _btnAddEntidadResponsable.Enabled = false;
        }

        private void _tsbGuardar_Click(object sender, EventArgs e)
        {
            string prefijoTipoProy = string.Empty;
            string prefijoEtapa = string.Empty;
            if (DatosValidos() && ((IControlesLocalizacion)_controlLocalizacion).DatosValidos())
            {
                _proyectoActual.DCodEtapa = (long)_cmbEtapa.SelectedValue;
                _proyectoActual.DCodPersona = (long) _cmbEntidadeResponsable.SelectedValue;
                _proyectoActual.Descripcion = _txtDescripcion.Text;
                _proyectoActual.NombreEsquema = Path.GetFileName(_txtEsquema.Text);
                _proyectoActual.FkProyectoMaestro = _proyectoMaestro.PkProyectoMaestro;

                if (_proyectoActual.EsNuevo)
                {
                    _proyectoActual.FechaDeRegistro = _dtpFechaRegistro.Value;
                    prefijoEtapa = GetPrefijoDeTipoDominio(int.Parse(_cmbEtapa.SelectedValue.ToString()));
                    prefijoTipoProy = GetPrefijoDeTipoDominio(int.Parse(_tipoProyecto.CodDominio.ToString()));
                    GeneradorCodigoProyecto.Instancia.AsignarCodigo(_proyectoActual, prefijoEtapa, prefijoTipoProy);
                }

                OraDalProyectoMgr.Instancia.Guardar(_proyectoActual);
                ((IControlesLocalizacion)_controlLocalizacion).GuardarDatos(_proyectoActual);
                DeshabilitarControles();
                if (ProyectoGuardado != null)
                {
                    ProyectoGuardado(this, EventArgs.Empty);
                }
                _seGuardo = true;
            }
        }

        private string GetPrefijoDeTipoDominio(int codDomino)
        {
            DefDominioMgr mgr = new DefDominioMgr();
            DefDominio dominio = mgr.GetDominioPorPkDominio(codDomino);
            string prefijo = string.Empty;
            if (dominio != null)
            {
                prefijo = dominio.Aux1_dom;
            }
            return prefijo;
        }

        private bool DatosValidos()
        {
            _errorProvider.Clear();
            bool res = true;
            if (_cmbEntidadeResponsable.Items.Count == 0)
            {
                res = false;
                _errorProvider.SetError(_cmbEntidadeResponsable, "No existen agentes registrados.");
            }

            if (!_proyectoMaestro.EsNuevo)
            {
                if (_proyectoActual.EsNuevo)
                {
                    if (OraDalProyectoMaestroMgr.Instancia.ExisteProyectoConEstaEtapa(_proyectoMaestro.PkProyectoMaestro, 0, (Int64)_cmbEtapa.SelectedValue))
                    {
                        res = false;
                        _errorProvider.SetError(_cmbEtapa, "EXISTE UN PROYECTO CON ESTA ETAPA");
                    }
                }
                else
                {
                    if (OraDalProyectoMaestroMgr.Instancia.ExisteProyectoConEstaEtapa(_proyectoMaestro.PkProyectoMaestro, _proyectoActual.PkProyecto, (Int64)_cmbEtapa.SelectedValue))
                    {
                        res = false;
                        _errorProvider.SetError(_cmbEtapa, "EXISTE UN PROYECTO CON ESTA ETAPA");
                    }
                }
            }
            return res;
        }

        private void CargarDatos()
        {
            _dtpFechaRegistro.Enabled = false;
            _txtNombre.Text = _proyectoMaestro.Nombre;
            _txtDescripcion.Text = _proyectoActual.Descripcion;
            _cmbEtapa.SelectedValue = _proyectoActual.DCodEtapa;
            _txtEsquema.Text = _proyectoActual.NombreEsquema;
            _dtpFechaRegistro.Value = _proyectoActual.FechaDeRegistro;
            _cmbEntidadeResponsable.SelectedValue = _proyectoActual.DCodPersona;
            VisualizarEsquema();            
        }

        private void LimpiarControles()
        {
            _errorProvider.Clear();
            _txtDescripcion.Text = string.Empty;
            _txtEsquema.Text = string.Empty;
            _txtNombre.Text = string.Empty;
            _pbxEsquema.Image = null;
            _dtpFechaRegistro.Value = DateTime.Now.Date;
        }

        private void ActivarDesActivarControles()
        {
            if (_esEditable)
            {
                HabilitarControles();
            }
            else
            {
                DeshabilitarControles();
            }
        }

        #region Miembros de IControles

        public void SetParametros(bool esEditable, Proyecto proyecto)
        {
            _pbxAuxiliar.Visible = false;
            _esEditable = proyecto.EsNuevo ? true : false;
            _seGuardo = !proyecto.EsNuevo ? true : false;
            _esNuevoProyMaestro = esEditable;
            _proyectoActual = proyecto;

            LimpiarControles();
            CargarDatosEntidadEjecutora();
            _proyectoMaestro = OraDalProyectoMaestroMgr.Instancia.GetPorId<ProyectoMaestro>(proyecto.FkProyectoMaestro,ProyectoMaestro.C_PK_PROYECTO_MAESTRO);

            if (_proyectoActual.EsNuevo)
            {
                _cmbEtapa.SelectedValue = _proyectoActual.DCodEtapa;
                _txtNombre.Text = _proyectoMaestro.Nombre;
                if (_proyectoActual.FechaDeRegistro > DateTime.MinValue)
                {
                    _dtpFechaRegistro.Value = _proyectoActual.FechaDeRegistro;
                }
            }
            else
            {
                _proyectoMaestro = OraDalProyectoMaestroMgr.Instancia.GetPorId<ProyectoMaestro>(_proyectoActual.FkProyectoMaestro, ProyectoMaestro.C_PK_PROYECTO_MAESTRO);
                CargarDatos();
            }
            ((IControlesLocalizacion)_controlLocalizacion).SetParametros(_esEditable, _proyectoActual);
            ActivarDesActivarControles();
        }
        
        public string Titulo
        {
            get { return "DATOS GENERALES"; }
        }

        public bool Guardado
        {
            get { return _seGuardo; }
        }

        #endregion

        private void _tsbEditar_Click(object sender, EventArgs e)
        {
            HabilitarControles();
            ((IControlesLocalizacion)_controlLocalizacion).HabilitarControles();
            _seGuardo = false;
            _txtDescripcion.Focus();
        }
        
        private void _tsbCancelar_Click(object sender, EventArgs e)
        {
            _esEditable = false;
            _seGuardo = _proyectoActual.EsNuevo ? false : true;
            _errorProvider.Clear();

            if (_proyectoActual.EsNuevo)
            {
                LimpiarControles();
            }
            else
            {
                CargarDatos();
            }
            _txtNombre.Text = _proyectoMaestro.Nombre;
            ((IControlesLocalizacion)_controlLocalizacion).SetParametros(_esEditable, _proyectoActual);
            ActivarDesActivarControles();
        }

        private void _btnAddEntidadResponsable_Click(object sender, EventArgs e)
        {
            _errorProvider.Clear();
            FormEntidadResponsable form = new FormEntidadResponsable();
            form.RegistrarEntidadResponsable();
            DialogResult res = form.ShowDialog();

            if (res == DialogResult.OK)
            {
                CargarDatosEntidadEjecutora();
                _cmbEntidadeResponsable.SelectedValue = form.GetPersona().PkCodPersona;
            }
            else
            {
                CargarDatosEntidadEjecutora();
            }
        }

        private void _dtpFechaRegistro_ValueChanged(object sender, EventArgs e)
        {

        }

        private void _rbtnReal_Click(object sender, EventArgs e)
        {
            AsegurarVistaEsquema();
        }

        private void AsegurarVistaEsquema()
        {
            if (_pbxEsquema.Image == null)
            {
                _rbtnReducida.Enabled = false;
                _rbtnReal.Enabled = false;
                _numPorcentaje.Enabled = false;
                _pbxAuxiliar.Visible = false;
                _pbxEsquema.Visible = false;
            }
            else
            {
                _rbtnReducida.Enabled = true;
                _rbtnReal.Enabled = true;

                if (_rbtnReal.Checked)
                {
                    _pbxAuxiliar.Visible = false;
                    _pbxEsquema.Visible = true;
                    _numPorcentaje.Enabled = false;
                }
                else
                {
                    _pbxAuxiliar.Height = _pnlEsquema.Height;
                    _pbxAuxiliar.SizeMode = PictureBoxSizeMode.StretchImage;
                    _pbxAuxiliar.Image = _pbxEsquema.Image;
                    int porcentajeH = (_pnlEsquema.Height * 100) / _pbxEsquema.Image.Height;
                    int porcentajeW = (_pnlEsquema.Width* 100) / _pbxEsquema.Image.Width;
                    _porcentaje = porcentajeH < porcentajeW ? porcentajeH : porcentajeW;
                    _porcentaje--;
                    
                    _pbxAuxiliar.Width = (_pbxEsquema.Image.Width * _porcentaje) / 100;
                    _pbxEsquema.Visible = false;
                    _pbxAuxiliar.Visible = true;
                    _porcentaje = _porcentaje > 100 ? 100 : _porcentaje;
                    _numPorcentaje.Value = _porcentaje;
                    _numPorcentaje.Enabled = true;
                }
            }
        }

        private void _numPorcentaje_ValueChanged(object sender, EventArgs e)
        {
            int porcentaje = (int)_numPorcentaje.Value;

            _pbxAuxiliar.Width = (_pbxEsquema.Image.Width * porcentaje) / 100;
            _pbxAuxiliar.Height = (_pbxEsquema.Image.Height * porcentaje) / 100;
        }

        public void SetEstadoToolBar(bool estado)
        {
            if (estado)
            {
                _toolStrip.Enabled = true;
            }
            else
            {
                _toolStrip.Enabled = false;
            }
        }
    }
}
