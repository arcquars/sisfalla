using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CNDC.BaseForms;
using CNDC.BLL;
using ModeloSisFalla;
using OraDalSisFalla;
using CNDC.Dominios;
using CNDC.ExceptionHandlerLib;
using SisFallaEmailLib;
using System.IO;
using MenuQuantum;
using CNDC.Pistas;
using System.Diagnostics;
using repSisfalla;

namespace SISFALLA
{
    public partial class FormInformeFalla : BaseForm, IFuncionalidad
    {
        private bool _tieneOpcionAnalisis = false;
        PK_D_COD_TIPOINFORME _tipoInforme;
        Persona _persona;
        RegFalla _regFalla;
        InformeFalla _infFalla;
        public bool _editandoInforme = false;
        Comando _cmdEditar;
        Comando _cmdCopiarDeAgeInvol;
        Comando _cmdCopiarDeAgeIndiv;
        Comando _cmdTerminarInf;
        Comando _cmdRevertirInf;
        Comando _cmdEnviarInf;
        Comando _cmdEditarSupervisor;
        private static bool _formularioInformeVisible = false;
        public static bool FormularioVisible
        {
            get { return _formularioInformeVisible; }
        }

        public bool TieneOpcionAnalisis
        { get { return _tieneOpcionAnalisis; } }
        public FormInformeFalla()
        {
            InitializeComponent();
            _cbxOrigen.DisplayMember = DefDominio.C_DESCRIPCION;
            _cbxOrigen.ValueMember = DefDominio.C_COD_DOMINIO;
            _cbxOrigen.DataSource = ModeloMgr.Instancia.DefDominioMgr.GetDominio(Dominios.D_COD_ORIGEN_INSTALACION);

            DataSet ds = new DataSet();
            DataTable tablaTipoDesconexion = ModeloMgr.Instancia.DefDominioMgr.GetDominio(Dominios.D_TIPO_DESCONEXION);
            ds.Tables.Add(tablaTipoDesconexion);
            DataTable tablaCausaDesconexion = ModeloMgr.Instancia.DefDominioMgr.GetDominio(Dominios.D_CAUSA_DESCONEXION);
            ds.Tables.Add(tablaCausaDesconexion);
            DataRelation relacion = new DataRelation("TipoDesconexion_Causa", tablaTipoDesconexion.Columns[DefDominio.C_COD_DOMINIO], tablaCausaDesconexion.Columns[DefDominio.C_COD_DOMINIO_PADRE]);
            ds.Relations.Add(relacion);

            _cbxTipoDesconex.DisplayMember = Dominios.D_TIPO_DESCONEXION + "." + DefDominio.C_DESCRIPCION;
            _cbxTipoDesconex.ValueMember = DefDominio.C_COD_DOMINIO;
            _cbxTipoDesconex.DataSource = ds;

            _cbxCausa.DisplayMember = Dominios.D_TIPO_DESCONEXION + ".TipoDesconexion_Causa." + DefDominio.C_DESCRIPCION;
            _cbxCausa.ValueMember = DefDominio.C_COD_DOMINIO;
            _cbxCausa.DataSource = ds;

            _cmbProblemasGen.DisplayMember = DefDominio.C_DESCRIPCION;
            _cmbProblemasGen.ValueMember = DefDominio.C_COD_DOMINIO;
            _cmbProblemasGen.DataSource = ModeloMgr.Instancia.DefDominioMgr.GetDominio(Dominios.D_COD_PROBLEMA_GEN);
            

        }

        public InformeFalla InfFalla
        { get { return _infFalla; } }

        private void FormInformeFalla_Load(object sender, EventArgs e)
        {
            _formularioInformeVisible = true;
            Visualizar();
        }

        private void Visualizar()
        {
            VisualizarRegFalla();
            VisualizarInfFallaActual();
            _pnlComandos.Acomodar();
            
        }

        private void VisualizarRegFalla()
        {
            _txtNumFalla.Text = RegFalla.FormatearCodFalla(_regFalla.CodFalla.ToString());
            _txtFecHoraFalla.Text = _regFalla.FecInicio.ToString(Sesion.FORMATO_FECHA);

            if (_regFalla.CodProblemasGen == 0)
            {
                _ctrlComponenteComprometido.Visible = true;
                _ctrlComponenteComprometido.PkCodComponente = _regFalla.CodComponente;
                _rbtnFalla.Checked = true;
            }
            else
            {
                _ctrlComponenteComprometido.Visible = false;
                _cmbProblemasGen.SelectedValue = _regFalla.CodProblemasGen;
                _rbtnDeficit.Checked = true;
            }
            _cmbProblemasGen.Visible = !_ctrlComponenteComprometido.Visible;
            _lblProblemasGen.Visible = _cmbProblemasGen.Visible;
        }

        public void VisualizarInfFallaActual()
        {
            _txtDescripcionFalla.Text = _infFalla.Descripcion;
            _txtInfAdicional.Text = _infFalla.InformacionAdicional;
            _txtOperacionProtecciones.Text = _infFalla.OperacionProtecciones;
            _txtProcRestitucion.Text = _infFalla.ProcRestitucion;
            if (_infFalla.CodEstadoInf == (long)D_COD_ESTADO_INF.ENVIADO)
            {
                _txtFechaHoraInforme.Text = _infFalla.FecRegistro.ToString(Sesion.FORMATO_FECHA);
            }
            else
            {
                _txtFechaHoraInforme.Text = string.Empty;
            }

            if (_infFalla.CodComponenteFallado != 0)
            {
                _ctrlComponenteComprometido.PkCodComponente = _infFalla.CodComponenteFallado;
            }
            _txtTipoInforme.Text = InformeFalla.GetTexto(_infFalla.PkDCodTipoinforme);
            _txtAgente.Text = ModeloMgr.Instancia.PersonaMgr.GetAgente(_infFalla.PkOrigenInforme).Sigla;

            _cbxOrigen.SelectedValue = _infFalla.DCodOrigen;
            _cbxTipoDesconex.SelectedValue = _infFalla.DCodTipoDesconexion;
            _cbxCausa.SelectedValue = _infFalla.DCodCausa;
            if (_infFalla.PkOrigenInforme == 7)
            {
                Persona p = ModeloMgr.Instancia.PersonaMgr.GetPorPkCodPersona(_infFalla.CodPersona);
                if (p != null)
                {
                    _txtElaboradoPor.Text = p.Nombre;
                    _txtElaboradoPor.ReadOnly = true;
                }
            }
            else
            {
                _txtElaboradoPor.Text = _infFalla.ElaboradoPor;
            }

            AsegurarTabsAnalisisColapso();
            AsegurarBotonDocAnalisis();

            if (!_infFalla.EsNuevo)
            {
                DeshabilitarControles();
            }
            //_txtNumFallaAgente estará visible sólo para Agentes
            _txtNumFallaAgente.Visible = !(Sesion.Instancia.RolSIN == "AE" || Sesion.Instancia.RolSIN == "CNDC");
            _txtNumFallaAgente.Text = _infFalla.NumFallaAgente;
        }

        private void AsegurarTabsAnalisisColapso()
        {
            if (_infFalla.PkDCodTipoinforme == (long)PK_D_COD_TIPOINFORME.PRELIMINAR
                || _infFalla.PkOrigenInforme != 7)
            {
                _tabcomponentes.TabPages.Remove(_tabColapso);
            }

            if (Sesion.Instancia.RolSIN != "CNDC" || _infFalla.PkDCodTipoinforme == (long)PK_D_COD_TIPOINFORME.PRELIMINAR)
            {
                _tabcomponentes.TabPages.Remove(_tabAnalisis);
            }
        }

        private void _tbtnGuardar_Click(object sender, EventArgs e)
        {
            Guardar(true);
        }

        private void _btnFechaHoraFallaUpdate_Click(object sender, EventArgs e)
        {
            FormUpdateFecha formUF = new FormUpdateFecha(_regFalla.FecInicio, _regFalla.CodFalla);
            formUF.ShowDialog();
            _txtFecHoraFalla.Text = formUF.getFecha().ToString(Sesion.FORMATO_FECHA);
        }

        private void _btnElaboradoPorUpdate_Click(object sender, EventArgs e)
        {
            
            int tipoInforme = (int)_tipoInforme;
            FormUpdateElaborado fUpdateElaboracion = new FormUpdateElaborado(_regFalla.CodFalla, tipoInforme, _regFalla.CodOrigen);
            fUpdateElaboracion.ShowDialog();
            if(fUpdateElaboracion.getNomPersona() != string.Empty)
                this._txtElaboradoPor.Text = fUpdateElaboracion.getNomPersona();
        }

        public bool Guardar(bool guardarTransac)
        {
            bool resultado = false;
            if (DatosValidos())
            {
                _infFalla.Descripcion = _txtDescripcionFalla.Text;
                _infFalla.InformacionAdicional = _txtInfAdicional.Text;
                _infFalla.OperacionProtecciones = _txtOperacionProtecciones.Text;
                _infFalla.ProcRestitucion = _txtProcRestitucion.Text;
                _infFalla.DCodOrigen = (long)_cbxOrigen.SelectedValue;
                _infFalla.DCodTipoDesconexion = (long)_cbxTipoDesconex.SelectedValue;
                _infFalla.DCodCausa = (long)_cbxCausa.SelectedValue;
                _infFalla.ElaboradoPor = _txtElaboradoPor.Text;
                _infFalla.CodComponenteFallado = (long)_ctrlComponenteComprometido.PkCodComponente;

                if (Sesion.Instancia.RolSIN == "CNDC")
                {
                    _infFalla.NumFallaAgente = _txtNumFalla.Text;
                }
                else
                {
                    _infFalla.NumFallaAgente = _txtNumFallaAgente.Text;
                }
                ModeloMgr.Instancia.InformeFallaMgr.Guardar(_infFalla);

                if (!_editandoInforme && (Sesion.Instancia.RolSIN != "CNDC" || ModeloMgr.Instancia.InformeFallaMgr.Bloquear(_infFalla)))
                {
                    _cmdEditar.Texto = "Terminar Edición";
                    _editandoInforme = true;
                    _pnlComandos.Acomodar();
                    VisualizarInfFallaActual();
                    HabilitarControles();

                }

                if (guardarTransac)
                {
                    Operacion opn = new Operacion();
                    DOMINIOS_OPERACION tipo_opn = _infFalla.GetTipoOpeParaGuardar();
                    opn.RegistrarOperacion(tipo_opn, _infFalla.PkCodFalla, _persona.PkCodPersona);
                }
                resultado = true;
            }
            if (_ctrlParteFallaActual != null)
            {
                resultado = _ctrlParteFallaActual.Guardar();
            }

            return resultado;
        }

        private bool DatosValidos()
        {
            bool resultado = true;
            _errorProvider.Clear();

            if (_txtDescripcionFalla.Text == string.Empty)
            {
                _errorProvider.SetError(_txtDescripcionFalla, MessageMgr.Instance.GetMessage("INGRESE_DESC_FALLA"));
                resultado = false;
            }
            return resultado;
        }

        private void _sbtnCancelar_Click(object sender, EventArgs e)
        {
            DialogResult = System.Windows.Forms.DialogResult.Cancel;
        }

        ICtrlParteInformeFalla _ctrlParteFallaActual = null;
        int _idxTabActual = 0;
        private void _tabcomponentes_Selecting(object sender, TabControlCancelEventArgs e)
        {
            bool informeGuardado = true;
            if (_infFalla.EsNuevo)
            {
                if (MessageBox.Show("Guardar informe ?", "Guardar informe", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    informeGuardado = Guardar(true);
                }
                else
                {
                    informeGuardado = false;
                }
            }
            else if (_editandoInforme)
            {
                if (_idxTabActual == 0)
                {
                    informeGuardado = Guardar(false);
                }
                else if (_ctrlParteFallaActual.HayCambiosSinGuardar() && ConfirmaGuardarCambios())
                {
                    if (_ctrlParteFallaActual.Guardar())
                    {
                        informeGuardado = true;
                    }
                    else
                    {
                        MessageBox.Show(MessageMgr.Instance.GetMessage("HAY_ERRORES_EN_INF"));
                    }
                }
            }

            if (informeGuardado)
            {
                ICtrlParteInformeFalla obj = null;
                if (e.TabPage.Controls[0] is ICtrlParteInformeFalla)
                {
                    obj = (ICtrlParteInformeFalla)e.TabPage.Controls[0];
                    obj.Informe = _infFalla;
                }
                _ctrlParteFallaActual = obj;
                _idxTabActual = e.TabPageIndex;
            }
            else
            {
                e.Cancel = true;
            }
        }

        public ICtrlParteInformeFalla ParteFallaActual
        {
            get { return _ctrlParteFallaActual; }
        }

        public bool TabActualValido()
        {
            bool resultado = false;
            if (_idxTabActual == 0)
            {
                resultado = DatosValidos();
            }
            else
            {
                resultado = _ctrlParteFallaActual.Guardar();
            }
            return resultado;
        }

        #region IFuncionalidad
        public ParametrosFuncionalidad Parametros { get; set; }
        public void Ejecutar()
        {
            _regFalla = Sesion.Instancia.GetObjetoGlobal<RegFalla>("Principal.FallaActual");
            _persona = Sesion.Instancia.GetObjetoGlobal<Persona>("Principal.Persona");
            _tipoInforme = GetTipoInforme(Parametros.DiccionarioParametros["TAG"]);
            _infFalla = ModeloMgr.Instancia.InformeFallaMgr.GetInforme(_regFalla.CodFalla, _persona.PkCodPersona, (long)_tipoInforme);
            _regFalla.DeltaTiempoIngresoComponentes = ModeloMgr.Instancia.InformeFallaMgr.DeltaTiempoIngresoComponentesMinutos;

            
                

            _tieneOpcionAnalisis = Parametros.DiccionarioParametros.ContainsKey("ANALISIS") ? Parametros.DiccionarioParametros["ANALISIS"] == "SI" : false;

            Operacion opn = new Operacion();
            DOMINIOS_OPERACION tipoOpnElab = InformeFalla.GetTipoOperacionElab(_tipoInforme);

            if (_infFalla == null)
            {
                if (_persona.PkCodPersona == Sesion.Instancia.EmpresaActual.PkCodPersona && !_tieneOpcionAnalisis)
                {
                    if (opn.OperacionValida(tipoOpnElab, _regFalla.CodFalla, Sesion.Instancia.EmpresaActual.PkCodPersona))
                    {
                        _btnFechaHoraFallaUpdate.Visible = false;
                        _btnElaboradoPorUpdate.Visible = false;
                        AsegurarInfFalla();
                        CargarPanelBotones();
                        ShowDialog();
                    }
                    else
                    {
                        MessageBox.Show(MessageMgr.Instance.GetMessage("NO_OPERACION"));
                    }
                }
                else
                {
                    Close();
                    MessageBox.Show(MessageMgr.Instance.GetMessage("INF_NO_REG_EN_BD"));
                }
            }
            else
            {
                setEnableCambiarElaboradoYFechaFalla();
                CargarPanelBotones();
                ShowDialog();
            }
        }


        private void setEnableCambiarElaboradoYFechaFalla()
        {
            bool rolCNDC = false;            
            foreach (Rol value in Sesion.Instancia.RolesActuales)
            {
                Console.WriteLine("datos val:: "+value.Jerarquia+"; "+value.NombreCorto+"; "+value.Num_Rol+"; "+value.CodEstado+"; "+ _infFalla.PkOrigenInforme+"; "+ _infFalla.CodEstadoInf);
                if (value.Num_Rol == 2)
                    rolCNDC = true;
            }
            InformeFalla _aux_infFalla = ModeloMgr.Instancia.InformeFallaMgr.GetInforme(_regFalla.CodFalla, _persona.PkCodPersona, (long)PK_D_COD_TIPOINFORME.FINAL);
            if (
                _aux_infFalla == null && 
                _infFalla.PkOrigenInforme == 7 && rolCNDC)
            {
                _btnFechaHoraFallaUpdate.Enabled = true;
                _btnElaboradoPorUpdate.Enabled = true;
            }
            else
            {
                if (_infFalla.PkOrigenInforme == 7)
                {
                    _btnFechaHoraFallaUpdate.Enabled = false;
                    _btnElaboradoPorUpdate.Enabled = false;
                }
                else
                {
                    _btnFechaHoraFallaUpdate.Visible = false;
                    _btnElaboradoPorUpdate.Visible = false;
                }
            }
        }
        private void CargarPanelBotones()
        {
            _cmdEditar = new CmdEditar(this);
            _pnlComandos.AdicionarComando(_cmdEditar);
            if (!_tieneOpcionAnalisis)
            {
                _cmdCopiarDeAgeInvol = new CmdCopiarDeAgenInvol(this);
                _cmdCopiarDeAgeIndiv = new CmdCopiarDeAgenIndiv(this);
                _cmdTerminarInf = new CmdTerminarInf(this);
                _cmdRevertirInf = new CmdRevertirInf(this);
                _cmdEnviarInf = new CmdEnviarInf(this);
                _pnlComandos.AdicionarComando(_cmdCopiarDeAgeInvol);
                _pnlComandos.AdicionarComando(_cmdCopiarDeAgeIndiv);
                _pnlComandos.AdicionarComando(_cmdTerminarInf);
                _pnlComandos.AdicionarComando(_cmdEnviarInf);
                _pnlComandos.AdicionarComando(_cmdRevertirInf);
                if (Sesion.Instancia.UsuarioActualTieneRol(Roles.JEFE_DIVISION_CDC))
                { 
                    _cmdEditarSupervisor =  new CmdEditarSupervisor(this);
                    _pnlComandos.AdicionarComando(_cmdEditarSupervisor);
                }

            }
             
        }

        private void AsegurarInfFalla()
        {
            if (_infFalla == null)
            {
                _infFalla = new InformeFalla(_regFalla);
                _infFalla.PkOrigenInforme = _persona.PkCodPersona;
                _infFalla.PkDCodTipoinforme = (long)_tipoInforme;

                if (_infFalla.CopiarDatosDeInformeAnterior() == ResultadoCopiaInforme.OK)
                {
                    RecargarInforme();
                }
            }
        }

        private PK_D_COD_TIPOINFORME GetTipoInforme(string p)
        {
            PK_D_COD_TIPOINFORME resultado = PK_D_COD_TIPOINFORME.PRELIMINAR;
            if (p.Contains("PRELIMINAR"))
            {
                resultado = PK_D_COD_TIPOINFORME.PRELIMINAR;
            }
            else if (p.Contains("FINAL"))
            {
                resultado = PK_D_COD_TIPOINFORME.FINAL;
            }
            else if (p.Contains("RECTIFICATORIO"))
            {
                resultado = PK_D_COD_TIPOINFORME.RECTIFICATORIO;
            }
            return resultado;
        }
        #endregion IFuncionalidad

        private void RecargarInforme()
        {
            string elaboradorPor = _infFalla.ElaboradoPor;
            _infFalla = ModeloMgr.Instancia.InformeFallaMgr.GetInforme(_regFalla.CodFalla, _persona.PkCodPersona, (long)_tipoInforme);
            _infFalla.FecRegistro = new DateTime(0);
            _infFalla.ElaboradoPor = elaboradorPor;
            ModeloMgr.Instancia.InformeFallaMgr.Guardar(_infFalla);
        }

        public void HabilitarControles()
        {
            bool banderaEdicion = _tieneOpcionAnalisis;

            _txtDescripcionFalla.ReadOnly = banderaEdicion;
            _txtProcRestitucion.ReadOnly = banderaEdicion;
            _txtOperacionProtecciones.ReadOnly = banderaEdicion;
            _txtInfAdicional.ReadOnly = banderaEdicion;
            _txtNumFallaAgente.Enabled = !banderaEdicion;
            _txtElaboradoPor.Enabled = !banderaEdicion;
            _cbxOrigen.Enabled = !banderaEdicion;
            _cbxTipoDesconex.Enabled = !banderaEdicion;
            _cbxCausa.Enabled = !banderaEdicion;
            _ctrlComponenteComprometido.Enabled = !banderaEdicion;
            _tbtnGuardar.Enabled = !banderaEdicion;
            _tbtnCancelar.Enabled = !banderaEdicion;
            AsegurarBotonDocAnalisis();

            

            ctrlAlimentadores1.SoloLectura = banderaEdicion;
            ctrlComponentesComprometidos1.SoloLectura = banderaEdicion;
            ctrlInterruptoresReles1.SoloLectura = banderaEdicion;
            ctrlColapso1.SoloLectura = banderaEdicion;
            ctrlAnalisisFalla1.SoloLectura = !(banderaEdicion);
        }

        private void AsegurarBotonDocAnalisis()
        {
            _tbtnDocAnalisis.Enabled = _infFalla.PkDCodTipoinforme != (long)PK_D_COD_TIPOINFORME.PRELIMINAR && _infFalla.PkOrigenInforme == 7;
        }

        public void DeshabilitarControles()
        {
            _txtDescripcionFalla.ReadOnly = true;
            _txtProcRestitucion.ReadOnly = true;
            _txtOperacionProtecciones.ReadOnly = true;
            _txtInfAdicional.ReadOnly = true;
            _txtNumFallaAgente.Enabled = false;
            _txtElaboradoPor.Enabled = false;
            _cbxOrigen.Enabled = false;
            _cbxTipoDesconex.Enabled = false;
            _cbxCausa.Enabled = false;
            _ctrlComponenteComprometido.Enabled = false;
            _tbtnGuardar.Enabled = false;
            _tbtnCancelar.Enabled = false;
            AsegurarBotonDocAnalisis();

            ctrlAlimentadores1.SoloLectura = true;
            ctrlAnalisisFalla1.SoloLectura = true;
            ctrlComponentesComprometidos1.SoloLectura = true;
            ctrlInterruptoresReles1.SoloLectura = true;
            ctrlColapso1.SoloLectura = true;
        }

        private void FormInformeFalla_FormClosed(object sender, FormClosedEventArgs e)
        {
            _formularioInformeVisible = false;
            if (_editandoInforme)
            {
                ModeloMgr.Instancia.InformeFallaMgr.DesBloquear(_infFalla);
            }
        }

        private void _tspDocAnalisis_Click(object sender, EventArgs e)
        {
            try
            {
                string nombreArchivo = ModeloMgr.Instancia.AnalisisMgr.DescargarInformeAnalisis(_infFalla.PkCodFalla, _infFalla.PkDCodTipoinforme);
                if (!string.IsNullOrEmpty(nombreArchivo))
                {
                    Process proceso = new Process();
                    proceso.StartInfo.FileName = nombreArchivo;
                    proceso.Start();
                }
            }
            catch (Exception ex)
            {
                PistaMgr.Instance.Error("FormInformeFalla", ex);
            }
        }

        public void CerrarOK()
        {
            Close();
        }

        private void FormInformeFalla_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!_editandoInforme)
            {
                return;
            }

            if (_idxTabActual == 0)
            {
                Guardar(false );
            }
            else if (_ctrlParteFallaActual.HayCambiosSinGuardar() && ConfirmaGuardarCambios())
            {
                if (!_ctrlParteFallaActual.Guardar())
                {
                    MessageBox.Show(MessageMgr.Instance.GetMessage("HAY_ERRORES_EN_INF"));
                    e.Cancel = true;
                }
            }
        }

        private bool ConfirmaGuardarCambios()
        {
            bool resultado = MessageBox.Show("Guardar cambios ?", string.Empty, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes;
            return resultado;
        }
    }

    public interface ICtrlParteInformeFalla
    {
        InformeFalla Informe { set; }
        bool Guardar();
        void RefrescarDatos();
        bool HayCambiosSinGuardar();
    }

    class CmdEditar : Comando
    {
        FormInformeFalla _frmInfFalla;
        public CmdEditar(FormInformeFalla frmInf)
        {
            _frmInfFalla = frmInf;
            Texto = "Editar Informe";
            Imagen = global::SisFallaUIInforme.Properties.Resources.Edit;
            Tamanio = new Size(107, 36);
        }

        public override void Ejecutar()
        {
            if (Texto == "Editar Informe")
            {
                if (Sesion.Instancia.RolSIN != "CNDC" || ModeloMgr.Instancia.InformeFallaMgr.Bloquear(_frmInfFalla.InfFalla))
                {
                    Texto = "Terminar Edición";
                    _frmInfFalla._editandoInforme = true;
                    _frmInfFalla.VisualizarInfFallaActual();
                    _frmInfFalla.HabilitarControles();
                }
                else
                {
                    string msg = MessageMgr.Instance.GetMessage("INF_EDITADO_POR_OTRO") + Environment.NewLine;
                    DataRow row = ModeloMgr.Instancia.InformeFallaMgr.GetBloqueador(_frmInfFalla.InfFalla);
                    if (row != null)
                    {
                        msg +=
                        " Usuario: " + row["username"] + Environment.NewLine +
                        " Terminal: " + row["terminal"] + Environment.NewLine +
                        " Maquina: " + row["machine"] + Environment.NewLine +
                        " Programa: " + row["program"] + Environment.NewLine;
                    }
                    MessageBox.Show(msg);
                }
            }
            else
            {
                if (_frmInfFalla.Guardar(true))
                {
                    Texto = "Editar Informe";
                    _frmInfFalla._editandoInforme = false;
                    ModeloMgr.Instancia.InformeFallaMgr.DesBloquear(_frmInfFalla.InfFalla);
                    _frmInfFalla.VisualizarInfFallaActual();
                    _frmInfFalla.DeshabilitarControles();
                }
            }
        }

        public override bool GetVisible()
        {
            bool resultado = false;

            if (_frmInfFalla.InfFalla.EsNuevo)
            {
                resultado = false;
            }
            else
            {
                bool isEdicion, isRevision;
                isEdicion = _frmInfFalla.InfFalla.CodEstadoInf == (long)D_COD_ESTADO_INF.EN_ELABORACION;
                isRevision = _frmInfFalla.InfFalla.CodEstadoInf == (long)D_COD_ESTADO_INF.ELABORADO;

                resultado = (isEdicion || isRevision || _frmInfFalla.TieneOpcionAnalisis) && _frmInfFalla.InfFalla.PkOrigenInforme == Sesion.Instancia.EmpresaActual.PkCodPersona;
            }
            return resultado;
        }
    }

    class CmdCopiarDeAgenInvol : Comando
    {
        FormInformeFalla _frmInfFalla;
        public CmdCopiarDeAgenInvol(FormInformeFalla frmInf)
        {
            _frmInfFalla = frmInf;
            Texto = "Copiar de Agentes Involucrados";
            Imagen = global::SisFallaUIInforme.Properties.Resources.CopiarDeAgentes;
            Tamanio = new Size(115, 36);
        }

        public override void Ejecutar()
        {
            if (_frmInfFalla.InfFalla.EsNuevo)
            {
                MessageBox.Show(MessageMgr.Instance.GetMessage("ANTES_GUARDE_INFORME"));
            }
            else
            {
                DataTable tablaAlim = ModeloMgr.Instancia.OperacionAlimentadorMgr.GetOpeAlim(_frmInfFalla.InfFalla);
                DataTable tablaInterrup = ModeloMgr.Instancia.OperacionInterruptoresMgr.GetInterruptores(_frmInfFalla.InfFalla);
                DataTable tablaCompCompro = ModeloMgr.Instancia.RRegFallaComponenteMgr.GetTablaVisualizable(_frmInfFalla.InfFalla);

                if (tablaAlim.Rows.Count == 0 && tablaCompCompro.Rows.Count == 0 && tablaInterrup.Rows.Count == 0)
                {
                    int alimCopiados = ModeloMgr.Instancia.OperacionAlimentadorMgr.CopiarAlimentadoresDeAgentes(_frmInfFalla.InfFalla);
                    int interrupCopiados = ModeloMgr.Instancia.OperacionInterruptoresMgr.CopiarInterruptoresDeAgentes(_frmInfFalla.InfFalla);
                    int compCopiados = ModeloMgr.Instancia.RRegFallaComponenteMgr.CopiarCompComproDeAgentes(_frmInfFalla.InfFalla);
                    if (alimCopiados == 0 && interrupCopiados == 0 && compCopiados == 0)
                    {
                        MessageBox.Show(MessageMgr.Instance.GetMessage("NO_HAY_DATOS_PA_COPIAR"));
                    }
                    else
                    {
                        MessageBox.Show(MessageMgr.Instance.GetMessage("DATOS_COPIADOS_SATISF"));
                        if (_frmInfFalla.ParteFallaActual != null)
                        {
                            _frmInfFalla.ParteFallaActual.RefrescarDatos();
                        }
                    }
                }
                else
                {
                    MessageBox.Show(MessageMgr.Instance.GetMessage("NO_ES_POSIBLE_COPIAR"));
                }
            }
        }

        public override bool GetVisible()
        {
            bool resultado = false;
            if (_frmInfFalla.InfFalla != null)
            {
                resultado = true;
            }

            if (_frmInfFalla._editandoInforme && Sesion.Instancia.RolSIN == "CNDC")
            {
                resultado = _frmInfFalla.InfFalla.PkDCodTipoinforme == (long)PK_D_COD_TIPOINFORME.PRELIMINAR;
            }
            else
            {
                resultado = false;
            }

            return resultado;
        }
    }

    class CmdCopiarDeAgenIndiv : Comando
    {
        FormInformeFalla _frmInfFalla;
        public CmdCopiarDeAgenIndiv(FormInformeFalla frmInf)
        {
            _frmInfFalla = frmInf;
            Texto = "Copiar de Agente Individual";
            Imagen = global::SisFallaUIInforme.Properties.Resources.copiarDeInforme1;
            Tamanio = new Size(115, 36);
        }

        public override void Ejecutar()
        {
            FormSeleccionInforme frmSelecInf = new FormSeleccionInforme();
            InformeFalla informeActual = _frmInfFalla.InfFalla;
            if (frmSelecInf.SeleccionarInforme(informeActual) == DialogResult.OK)
            {
                InformeFalla infOrigen = frmSelecInf.GetInformeSeleccionado();
                ResultadoCopiaInforme r = ModeloMgr.Instancia.InformeFallaMgr.CopiarInformeIndividual
                     (infOrigen.PkCodFalla, infOrigen.PkOrigenInforme, infOrigen.PkDCodTipoinforme,
                     informeActual.PkCodFalla, informeActual.PkOrigenInforme, informeActual.PkDCodTipoinforme);

                if (r == ResultadoCopiaInforme.OK)
                {
                    MessageBox.Show(MessageMgr.Instance.GetMessage("DATOS_COPIADOS_SATISF"));
                }
                else
                {
                    MessageBox.Show(MessageMgr.Instance.GetMessage("DATOS_NO_COPIADOS_SATISF"));
                }
            }
        }

        public override bool GetVisible()
        {
            bool resultado = false;
            if (_frmInfFalla.InfFalla != null)
            {
                resultado = true;
            }

            if (_frmInfFalla._editandoInforme && Sesion.Instancia.RolSIN == "CNDC")
            {
                resultado = _frmInfFalla.InfFalla.PkDCodTipoinforme == (long)PK_D_COD_TIPOINFORME.PRELIMINAR;
            }
            else
            {
                resultado = false;
            }

            return resultado;
        }
    }

    class CmdTerminarInf : Comando
    {
        FormInformeFalla _frmInfFalla;
        public CmdTerminarInf(FormInformeFalla frmInf)
        {
            _frmInfFalla = frmInf;
            Texto = "Terminar Informe";
            Imagen = global::SisFallaUIInforme.Properties.Resources.TerminarInf;
            Tamanio = new Size(115, 36);
        }

        public override void Ejecutar()
        {
          
            if (!_frmInfFalla.TabActualValido())
            {
                MessageBox.Show(MessageMgr.Instance.GetMessage("HAY_ERRORES_EN_INF"));
                return;
            }

            if (BaseForm.EstaSeguro(MessageMgr.Instance.GetMessage("SEGURO_DE_TERMINAR_INF")))
            {
                _frmInfFalla.InfFalla.CodEstadoInf = (long)D_COD_ESTADO_INF.ELABORADO;
                _frmInfFalla.Guardar(true);
                MessageBox.Show(MessageMgr.Instance.GetMessage("INFORME_TERMINADO"));
                _frmInfFalla.CerrarOK();
            }
        }

        public override bool GetVisible()
        {
            bool resultado = false;
            if (_frmInfFalla.InfFalla != null)
            {
                resultado = true;
            }

            if (_frmInfFalla._editandoInforme && Sesion.Instancia.RolSIN == "CNDC")
            {
                Operacion opn = new Operacion();
                InformeFalla infFalla = _frmInfFalla.InfFalla;
                if (infFalla.PkDCodTipoinforme == (long)PK_D_COD_TIPOINFORME.PRELIMINAR
                    && opn.OperacionValida(DOMINIOS_OPERACION.CNDC_TERMINA_PRELIMINAR, infFalla.PkCodFalla, 7))
                {
                    resultado = true;
                }
                else if (infFalla.PkDCodTipoinforme == (long)PK_D_COD_TIPOINFORME.FINAL
                    && opn.OperacionValida(DOMINIOS_OPERACION.CNDC_TERMINA_FINAL, infFalla.PkCodFalla, 7))
                {
                    resultado = true;
                }
                else if (infFalla.PkDCodTipoinforme == (long)PK_D_COD_TIPOINFORME.RECTIFICATORIO
                && opn.OperacionValida(DOMINIOS_OPERACION.CNDC_TERMINA_RECTIFICATORIO, infFalla.PkCodFalla, 7))
                {
                    resultado = true;
                }
                else
                {
                    resultado = false;
                }
            }
            else
            {
                resultado = false;
            }

            return resultado;
        }
    }

    class CmdRevertirInf : Comando
    {
        FormInformeFalla _frmInfFalla;
        public CmdRevertirInf(FormInformeFalla frmInf)
        {
            _frmInfFalla = frmInf;
            Texto = "Revertir Informe";
            Imagen = global::SisFallaUIInforme.Properties.Resources.RevertirInforme1;
            Tamanio = new Size(115, 36);
            Alineacion = TipoAlineamiento.Derecha;
        }

        public override void Ejecutar()
        {
            if (BaseForm.EstaSeguro(MessageMgr.Instance.GetMessage("SEGURO_REVERTIR_INF")))
            {
                _frmInfFalla.InfFalla.Revertir();
                _frmInfFalla.CerrarOK();
            }
        }

        public override bool GetVisible()
        {
            bool resultado = false;

            if (Sesion.Instancia.RolSIN == "CNDC")
            {
                if (_frmInfFalla.InfFalla.PkOrigenInforme != 7 && (D_COD_ESTADO_INF)_frmInfFalla.InfFalla.CodEstadoInf == D_COD_ESTADO_INF.ENVIADO)
                {
                    Operacion opn = new Operacion();
                    PK_D_COD_TIPOINFORME tipoInforme = (PK_D_COD_TIPOINFORME)_frmInfFalla.InfFalla.PkDCodTipoinforme;
                    switch (tipoInforme)
                    {
                        case PK_D_COD_TIPOINFORME.PRELIMINAR:
                            if (opn.ExisteRegistro(DOMINIOS_OPERACION.CNDC_ENVIA_PRELIMINAR, _frmInfFalla.InfFalla.PkCodFalla, 7) == -1)
                            {
                                resultado = true;
                            }
                            break;
                        case PK_D_COD_TIPOINFORME.FINAL:
                            if (opn.ExisteRegistro(DOMINIOS_OPERACION.CNDC_ENVIA_FINAL, _frmInfFalla.InfFalla.PkCodFalla, 7) == -1)
                            {
                                resultado = true;
                            }
                            break;
                        case PK_D_COD_TIPOINFORME.RECTIFICATORIO:
                            if (opn.ExisteRegistro(DOMINIOS_OPERACION.CNDC_ENVIA_RECTIFICATORIO, _frmInfFalla.InfFalla.PkCodFalla, 7) == -1)
                            {
                                resultado = true;
                            }
                            break;
                    }
                }
            }

            return resultado;
        }
    }

    class CmdEditarSupervisor : Comando 
    {
        private FormInformeFalla _frmInfFalla;
        private InformeFalla _infFalla;
        public CmdEditarSupervisor(FormInformeFalla frmInf)
        {
            _frmInfFalla = frmInf;
            _infFalla = _frmInfFalla.InfFalla;
            Texto = "Editar Supervisor";
            Imagen = global::SisFallaUIInforme.Properties.Resources.persona;
            Tamanio = new Size(115, 36);
            Alineacion = TipoAlineamiento.Izquierda;
        }
        public override void Ejecutar()
        {
            SisFallaUIInforme.FormModificarSupervisor frm = new SisFallaUIInforme.FormModificarSupervisor(_infFalla);

            if (frm.ShowDialog()==DialogResult.OK)
            {
                _frmInfFalla._txtElaboradoPor.Text = frm.Persona.Nombre;

            }
            
        }

        public override bool GetVisible()
        {
            bool resultado = false;
            if (_frmInfFalla.InfFalla != null)
            {
                resultado = true;
            }

            if (_frmInfFalla._editandoInforme && Sesion.Instancia.RolSIN == "CNDC")
            {
                Operacion opn = new Operacion();
                InformeFalla infFalla = _frmInfFalla.InfFalla;
                if (infFalla.PkDCodTipoinforme == (long)PK_D_COD_TIPOINFORME.PRELIMINAR
                    && opn.OperacionValida(DOMINIOS_OPERACION.CNDC_TERMINA_PRELIMINAR, infFalla.PkCodFalla, 7))
                {
                    resultado = true;
                }
                else if (infFalla.PkDCodTipoinforme == (long)PK_D_COD_TIPOINFORME.FINAL
                    && opn.OperacionValida(DOMINIOS_OPERACION.CNDC_TERMINA_FINAL, infFalla.PkCodFalla, 7))
                {
                    resultado = true;
                }
                else if (infFalla.PkDCodTipoinforme == (long)PK_D_COD_TIPOINFORME.RECTIFICATORIO
                && opn.OperacionValida(DOMINIOS_OPERACION.CNDC_TERMINA_RECTIFICATORIO, infFalla.PkCodFalla, 7))
                {
                    resultado = true;
                }
                else
                {
                    resultado = false;
                }
            }
            else
            {
                resultado = false;
            }

            return resultado;
        }
    }

    class CmdEnviarInf : Comando
    {
        private FormInformeFalla _frmInfFalla;
        private bool _cambiaFechaInforme = false;
        private bool _informeEnviadoViaWCF = false;
        private DataSet _dataSetInforme;
        private FormEnvioInforme _formConfigEnvio;
        private InformeFalla _infFalla;

        public CmdEnviarInf(FormInformeFalla frmInf)
        {
            _frmInfFalla = frmInf;
            _infFalla = _frmInfFalla.InfFalla;
            Texto = "Enviar Informe";
            Imagen = global::SisFallaUIInforme.Properties.Resources.email_go;
            Tamanio = new Size(115, 36);
            Alineacion = TipoAlineamiento.Derecha;
        }

        public override void Ejecutar()
        {
            if (!_frmInfFalla.TabActualValido())
            {
                MessageBox.Show(MessageMgr.Instance.GetMessage("HAY_ERRORES_EN_INF"));
                return;
            }

            if (_cambiaFechaInforme)
            {
                _infFalla.PonerFechaHora();
                _frmInfFalla.Guardar(false);
            }

            if (UsuarioConfirmaEnvioInforme())
            {
                FormTareaAsincrona f = new FormTareaAsincrona();
                f.Visualizar("Envío Informe de Falla", "Enviando Informe...", EnviarInforme);
                VerificarResultadoDeEnvio();
            }
        }

        private bool UsuarioConfirmaEnvioInforme()
        {
            bool resultado = false;
            string path = Exportardor.EnsureExportFolder();
            if (GenerarAdjuntos(path))
            {
                List<string> destinatarios = GetDestinatarios();
                List<string> archivosAdjuntos = GetArchivosAdjuntos(path);
                P_GF_Correos encabezado = ModeloMgr.Instancia.P_GF_CorreosMgr.Get(1, D_COD_SECC_CORREO.ENCABEZADO_INFORME);
                encabezado.Texto = encabezado.Texto.Replace("#NN_FALLA#", RegFalla.FormatearCodFalla(_infFalla.PkCodFalla.ToString()));
                P_GF_Correos cuerpo = ModeloMgr.Instancia.P_GF_CorreosMgr.Get(1, D_COD_SECC_CORREO.CUERPO_INFORME);
                cuerpo.Texto = cuerpo.Texto.Replace("#NN_FALLA#", RegFalla.FormatearCodFalla(_infFalla.PkCodFalla.ToString()));

                if (_formConfigEnvio == null)
                {
                    _formConfigEnvio = new FormEnvioInforme();
                }
                _formConfigEnvio.Para = destinatarios;
                _formConfigEnvio.Asunto = encabezado.Texto;
                _formConfigEnvio.Cuerpo = cuerpo.Texto;
                _formConfigEnvio.Adjunto = archivosAdjuntos;
                resultado = _formConfigEnvio.ShowDialog() == DialogResult.OK;
            }
            else
            {
                string mensaje = MessageMgr.Instance.GetMessage("NO_SE_GENERARON_ADJUNTOS");
                MessageBox.Show(mensaje);
                resultado = false;
            }
            return resultado;
        }

        private List<string> GetArchivosAdjuntos(string path)
        {
            List<string> resultado = new List<string>();
            if (Sesion.Instancia.RolSIN == "CNDC")
            {
                if (_infFalla.PkDCodTipoinforme != (long)PK_D_COD_TIPOINFORME.PRELIMINAR)
                {
                    string nombreArchivoAnalisis = ModeloMgr.Instancia.AnalisisMgr.DescargarInformeAnalisis(_infFalla.PkCodFalla, _infFalla.PkDCodTipoinforme);
                    if (!string.IsNullOrEmpty(nombreArchivoAnalisis))
                    {
                        resultado.Add(nombreArchivoAnalisis);
                    }
                }
            }

            string prefijoArchivo = Path.Combine(path, "INFORMEFALLA_" + RegFalla.FormatearCodFalla(_infFalla.PkCodFalla.ToString()) + "_" + CNDC.BLL.Sesion.Instancia.EmpresaActual.Sigla + "_" + InformeFalla.GetTexto(_infFalla.PkDCodTipoinforme));
            if (File.Exists(prefijoArchivo + ".pdf"))
            {
                resultado.Add(prefijoArchivo + ".pdf");
            }
            if (File.Exists(prefijoArchivo + ".xml.gz"))
            {
                resultado.Add(prefijoArchivo + ".xml.gz");
            }
            return resultado;
        }

        private List<string> GetDestinatarios()
        { 
            List<string> resultado = null;
            if (Sesion.Instancia.RolSIN == "CNDC")
            {
                resultado = ModeloMgr.Instancia.RContactoMgr.GetEmails(_infFalla.PkCodFalla, Sesion.Instancia.EmpresaActual.PkCodPersona);
            }
            else
            {
                resultado = ModeloMgr.Instancia.RContactoMgr.GetEmailsDeContactos("7");//CNDC
            }
            return resultado;
        }

        private void EnviarInforme()
        {
            
                _dataSetInforme.Tables[InformeFalla.NOMBRE_TABLA].Rows[0]["D_COD_ESTADO_INF"] = 3594;

                if (Sesion.Instancia.RolSIN != "CNDC" && CNDC.Sincronizacion.SincronizadorCliente.Instancia.PingHost())
                {
                    _informeEnviadoViaWCF = CNDC.Sincronizacion.SincronizadorCliente.Instancia.MgrServidor.Subir(_dataSetInforme, "SISFALLA");
                }

                _formConfigEnvio.Enviar();
            
        }
        
        private void VerificarResultadoDeEnvio()
        {
            bool enviarPorOtroMedio = true;
            Mensaje mensaje1 = new Mensaje();
            Mensaje mensaje2 = new Mensaje();
            Mensaje mensaje3 = new Mensaje();

            switch (_formConfigEnvio.Resultado)
            {
                case ResultadoEnvioEmail.Enviado:
                    enviarPorOtroMedio = false;
                    mensaje2.Msg = MessageMgr.Instance.GetMessage("ENVIO_POR_EMAIL_SI");
                    mensaje2.Icono = IconoMsg.Informacion;
                    break;
                case ResultadoEnvioEmail.EnviadoConError:
                    mensaje2.Msg = MessageMgr.Instance.GetMessage("ENVIO_POR_EMAIL_CON_ERROR");
                    if (_formConfigEnvio.DestinosNoEnviados != null)
                    {
                        mensaje2.Msg += Environment.NewLine + "DESTINATARIOS A LOS QUE NO SE PUDO ENVIAR:";

                        foreach (string destNoEnviado in _formConfigEnvio.DestinosNoEnviados)
                        {
                            mensaje2.Msg += Environment.NewLine + "- " + destNoEnviado;
                        }
                    }
                    mensaje2.Icono = IconoMsg.Error;
                    break;
                case ResultadoEnvioEmail.NoEnviado:
                    mensaje2.Msg = MessageMgr.Instance.GetMessage("ENVIO_POR_EMAIL_NO");
                    mensaje2.Icono = IconoMsg.Error;
                    break;
                case ResultadoEnvioEmail.EnvioCanceladoPorUs:
                    return;
            }

            if (Sesion.Instancia.RolSIN == "CNDC")
            {
                _infFalla.CodEstadoInf = (long)D_COD_ESTADO_INF.ENVIADO;
            }
            else
            {
                if (_informeEnviadoViaWCF)
                {
                    mensaje1.Msg = MessageMgr.Instance.GetMessage("ENVIO_POR_WCF_SI");
                    mensaje1.Icono = IconoMsg.Informacion;
                    _infFalla.CodEstadoInf = (long)D_COD_ESTADO_INF.ENVIADO;
                }
                else
                {
                    enviarPorOtroMedio = true;
                    _infFalla.CodEstadoInf = (long)D_COD_ESTADO_INF.ENVIADO_ERROR;
                    mensaje1.Msg = MessageMgr.Instance.GetMessage("ENVIO_POR_WCF_NO");
                    mensaje1.Icono = IconoMsg.Error;
                    if (_formConfigEnvio.Resultado != ResultadoEnvioEmail.Enviado)
                    {
                        mensaje3.Msg = MessageMgr.Instance.GetMessage("INFORME_NOVPN_NOMAIL");
                    }
                    else
                    {
                        mensaje3.Msg = MessageMgr.Instance.GetMessage("COORDINAR_CON_CNDC");
                    }
                    mensaje3.Icono = IconoMsg.Informacion;
                }
            }
            List<Mensaje> mensajes = new List<Mensaje>();
            mensajes.Add(mensaje1);
            mensajes.Add(mensaje2);
            mensajes.Add(mensaje3);
            FormMensajes fMensajes = new FormMensajes();
            fMensajes.Visualizar("Envío Informe", mensajes);
            //MessageBox.Show(msg, "Envío Informe", MessageBoxButtons.OK);

            if (enviarPorOtroMedio)
            {
                long estadoActualInforme = _infFalla.CodEstadoInf;
                _infFalla.CodEstadoInf = (long)D_COD_ESTADO_INF.ENVIADO;
                SaveFileDialog dialog = new SaveFileDialog();
                dialog.InitialDirectory = Exportardor.EnsureExportFolder();

                dialog.Title = MessageMgr.Instance.GetMessage("EXPORTAR_INF");
                dialog.Filter = "Archivos Sisfalla|*.gz|Todos Archivos|*.*";
                dialog.FileName = "INFORMEFALLA_" + RegFalla.FormatearCodFalla(_infFalla.PkCodFalla.ToString()) + "_" + CNDC.BLL.Sesion.Instancia.EmpresaActual.Sigla + "_" + InformeFalla.GetTexto(_infFalla.PkDCodTipoinforme) + ".xml";

                if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    string archivo = dialog.FileName;
                    Exportardor exp = new Exportardor();
                    exp.ExportarInformeFallaExistente(_dataSetInforme, archivo);
                    FileInfo finfo = new FileInfo(archivo);
                    PistaMgr.Instance.EscribirLog("SISFALLA", "Informe Exportado en :" + finfo.FullName + ".gz", TipoPista.Info);

                    MessageBox.Show("Guardado satisfactoriamente, el archivo : " + finfo.FullName + ".gz", "Informe Exportado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                _infFalla.CodEstadoInf = estadoActualInforme;
            }

            if (!_frmInfFalla.Guardar(true))
            {
                return;
            }
            _frmInfFalla.CerrarOK();
        }

        public bool GenerarAdjuntos(string path)
        {
            Exportardor exp = new Exportardor();
            _dataSetInforme = _infFalla.GetDataSet();
            bool resultado = exp.ExportarInforme(_infFalla, _dataSetInforme, path);

            RptInformeFallaParametroExtra paramExtra = new RptInformeFallaParametroExtra(_infFalla.PkCodFalla, _infFalla.PkOrigenInforme, (PK_D_COD_TIPOINFORME)_infFalla.PkDCodTipoinforme);
            paramExtra.ModoVisible = false;
            paramExtra.NombreArchivoExportar = Path.Combine(path, "INFORMEFALLA_" + RegFalla.FormatearCodFalla(_infFalla.PkCodFalla.ToString()) + "_" + CNDC.BLL.Sesion.Instancia.EmpresaActual.Sigla + "_" + InformeFalla.GetTexto(_infFalla.PkDCodTipoinforme)) + ".pdf";
            CNDCMenu.Instancia.EjecutarOpcion(29, paramExtra);
            return resultado;
        }

        public override bool GetVisible()
        {
            bool resultado = false;
            _cambiaFechaInforme = !(D_COD_ESTADO_INF.ENVIADO == (D_COD_ESTADO_INF)_infFalla.CodEstadoInf);

            if (_infFalla.PkOrigenInforme == Sesion.Instancia.EmpresaActual.PkCodPersona)
            {
                if (Sesion.Instancia.RolSIN == "CNDC")
                {
                    if (Sesion.Instancia.UsuarioActualTieneRol(2) && D_COD_ESTADO_INF.EN_ELABORACION != (D_COD_ESTADO_INF)_infFalla.CodEstadoInf)
                    {
                        resultado = true;
                    }
                }
                else if (_frmInfFalla._editandoInforme)
                {
                    Operacion opn = new Operacion();
                    if (_infFalla.PkDCodTipoinforme == (long)PK_D_COD_TIPOINFORME.PRELIMINAR
                    && opn.OperacionValida(DOMINIOS_OPERACION.AGENTE_ENVIA_PRELIMINAR, _infFalla.PkCodFalla, _infFalla.PkOrigenInforme))
                    {
                        resultado = true;
                    }
                    else if (_infFalla.PkDCodTipoinforme == (long)PK_D_COD_TIPOINFORME.FINAL
                    && opn.OperacionValida(DOMINIOS_OPERACION.AGENTE_ENVIA_FINAL, _infFalla.PkCodFalla, _infFalla.PkOrigenInforme))
                    {
                        resultado = true;
                    }
                }
            }

            return resultado;
        }
    }
}
