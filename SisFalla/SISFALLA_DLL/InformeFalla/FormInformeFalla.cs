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

namespace SISFALLA
{
    public partial class FormInformeFalla : BaseForm, IFuncionalidad
    {
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

            _cmdEditar = new CmdEditar(this);
            _cmdCopiarDeAgeInvol = new CmdCopiarDeAgenInvol(this);
            _cmdCopiarDeAgeIndiv = new CmdCopiarDeAgenIndiv(this);
            _cmdTerminarInf = new CmdTerminarInf(this);
            _cmdRevertirInf = new CmdRevertirInf(this);
            _cmdEnviarInf = new CmdEnviarInf(this);
            _pnlComandos.AdicionarComando(_cmdEditar);
            _pnlComandos.AdicionarComando(_cmdCopiarDeAgeInvol);
            _pnlComandos.AdicionarComando(_cmdCopiarDeAgeIndiv);
            _pnlComandos.AdicionarComando(_cmdTerminarInf);
            _pnlComandos.AdicionarComando(_cmdEnviarInf);
            _pnlComandos.AdicionarComando(_cmdRevertirInf);
        }

        public InformeFalla InfFalla
        { get { return _infFalla; } }

        private void FormInformeFalla_Load(object sender, EventArgs e)
        {
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
            if (!(_infFalla.PkDCodTipoinforme != (long)PK_D_COD_TIPOINFORME.PRELIMINAR
                && _infFalla.PkOrigenInforme == 7))
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
            Guardar();
        }

        public bool Guardar()
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

                Operacion opn = new Operacion();
                DOMINIOS_OPERACION tipo_opn = _infFalla.GetTipoOpeParaGuardar();
                opn.RegistrarOperacion(tipo_opn, _infFalla.PkCodFalla, _persona.PkCodPersona);
                resultado = true;
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
            if (_editandoInforme || _infFalla.EsNuevo)
            {
                if (_idxTabActual == 0)
                {
                    informeGuardado = Guardar();
                }
                else
                {
                    informeGuardado = _ctrlParteFallaActual == null || _ctrlParteFallaActual.Guardar();
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
        public Dictionary<string, string> Parametros { get; set; }
        public void Ejecutar()
        {
            _regFalla = Sesion.Instancia.GetObjetoGlobal<RegFalla>("Principal.FallaActual");
            _persona = Sesion.Instancia.GetObjetoGlobal<Persona>("Principal.Persona");
            _tipoInforme = GetTipoInforme(Parametros["TAG"]);
            _infFalla = ModeloMgr.Instancia.InformeFallaMgr.GetInforme(_regFalla.CodFalla, _persona.PkCodPersona, (long)_tipoInforme);

            Operacion opn = new Operacion();
            DOMINIOS_OPERACION tipoOpnElab = InformeFalla.GetTipoOperacionElab(_tipoInforme);

            if (_infFalla == null)
            {
                if (_persona.PkCodPersona == Sesion.Instancia.EmpresaActual.PkCodPersona)
                {
                    if (opn.OperacionValida(tipoOpnElab, _regFalla.CodFalla, Sesion.Instancia.EmpresaActual.PkCodPersona))
                    {
                        AsegurarInfFalla();
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
                ShowDialog();
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
            bool banderaEdicion = Parametros.ContainsKey("ANALISIS") ? Parametros["ANALISIS"] == "SI" : false;

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
            _tbtnDocAnalisis.Enabled = _tbtnDocAnalisis.Enabled = _infFalla.PkDCodTipoinforme != (long)PK_D_COD_TIPOINFORME.PRELIMINAR && _infFalla.PkOrigenInforme == 7;
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
            if (_editandoInforme)
            {
                ModeloMgr.Instancia.InformeFallaMgr.DesBloquear(_infFalla);
            }
        }

        private void _tspDocAnalisis_Click(object sender, EventArgs e)
        {
            try
            {
                string nombreArchivo = ModeloMgr.Instancia.AnalisisMgr.DescargarInformeAnalisis(_infFalla.PkCodFalla);
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
            DialogResult = System.Windows.Forms.DialogResult.OK;
        }
    }

    public interface ICtrlParteInformeFalla
    {
        InformeFalla Informe { set; }
        bool Guardar();
        void RefrescarDatos();
    }

    class CmdEditar : Comando
    {
        FormInformeFalla _frmInfFalla;
        public CmdEditar(FormInformeFalla frmInf)
        {
            _frmInfFalla = frmInf;
            Texto = "Editar Informe";
            Imagen = global::SISFALLA.Properties.Resources.Edit;
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
                    MessageBox.Show(MessageMgr.Instance.GetMessage("INF_EDITADO_POR_OTRO"));
                }
            }
            else
            {
                Texto = "Editar Informe";
                _frmInfFalla._editandoInforme = false;
                ModeloMgr.Instancia.InformeFallaMgr.DesBloquear(_frmInfFalla.InfFalla);
                _frmInfFalla.VisualizarInfFallaActual();
                _frmInfFalla.DeshabilitarControles();
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
                //DeshabilitarControles();
                resultado = _frmInfFalla.InfFalla.CodEstadoInf != (long)D_COD_ESTADO_INF.ENVIADO && _frmInfFalla.InfFalla.PkOrigenInforme == Sesion.Instancia.EmpresaActual.PkCodPersona;
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
            Imagen = global::SISFALLA.Properties.Resources.CopiarDeAgentes;
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
            Imagen = global::SISFALLA.Properties.Resources.copiarDeInforme1;
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
            Imagen = global::SISFALLA.Properties.Resources.TerminarInf;
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
                _frmInfFalla.Guardar();
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
            Imagen = global::SISFALLA.Properties.Resources.RevertirInforme1;
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
                if (_frmInfFalla.InfFalla.PkOrigenInforme != 7)
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

    class CmdEnviarInf : Comando
    {
        FormInformeFalla _frmInfFalla;
        public CmdEnviarInf(FormInformeFalla frmInf)
        {
            _frmInfFalla = frmInf;
            Texto = "Enviar Informe";
            Imagen = global::SISFALLA.Properties.Resources.email_go;
            Tamanio = new Size(115, 36);
            Alineacion = TipoAlineamiento.Derecha;
        }

        ResultadoEnvioEmail _resultadoEnvioInforme = ResultadoEnvioEmail.NoEnviado;
        bool _datosEnviadosAlServidor = false;
        DataSet _dSetInforme;
        public override void Ejecutar()
        {
            InformeFalla infFalla = _frmInfFalla.InfFalla;
            if (!_frmInfFalla.TabActualValido())
            {
                MessageBox.Show(MessageMgr.Instance.GetMessage("HAY_ERRORES_EN_INF"));
                return;
            }

            if (!BaseForm.EstaSeguro(MessageMgr.Instance.GetMessage("SEGURO_DE_ENVIAR_INF")))
            {
                return;
            }

            infFalla.CodEstadoInf = (long)D_COD_ESTADO_INF.ENVIADO;
            infFalla.PonerFechaHora();
            if (!_frmInfFalla.Guardar())
            {
                return;
            }

            FormTareaAsincrona f = new FormTareaAsincrona();
            f.Visualizar("Envío Informe de Falla", "Enviando Informe...", EnviarInforme);
            bool enviarManualmente = false;
            string mensaje1 = string.Empty;
            string mensaje2 = string.Empty;

            switch (_resultadoEnvioInforme)
            {
                case ResultadoEnvioEmail.Enviado:
                    mensaje2 = MessageMgr.Instance.GetMessage("ENVIO_POR_EMAIL_SI");
                    break;
                case ResultadoEnvioEmail.EnviadoConError:
                case ResultadoEnvioEmail.NoEnviado:
                    mensaje2 = MessageMgr.Instance.GetMessage("ENVIO_POR_EMAIL_NO");
                    enviarManualmente = true;
                    break;
            }

            string msg = string.Empty;
            if (Sesion.Instancia.RolSIN == "CNDC")
            {
                msg = mensaje2;
            }
            else
            {
                if (_datosEnviadosAlServidor)
                {
                    mensaje1 = MessageMgr.Instance.GetMessage("ENVIO_POR_WCF_SI");
                }
                else
                {
                    mensaje1 = MessageMgr.Instance.GetMessage("ENVIO_POR_WCF_NO");
                }
                msg = string.Format("- {0}{1}- {2}", mensaje1, Environment.NewLine, mensaje2);
            }

            MessageBox.Show(msg, "Envío Informe", MessageBoxButtons.OK);

            if (enviarManualmente)
            {
                SaveFileDialog dialog = new SaveFileDialog();
                dialog.Title = MessageMgr.Instance.GetMessage("EXPORTAR_INF");
                dialog.Filter = "Archivos Sisfalla|*.gz|Todos Archivos|*.*";
                dialog.FileName = "INFORMEFALLA_" + RegFalla.FormatearCodFalla(infFalla.PkCodFalla.ToString()) + "_" + CNDC.BLL.Sesion.Instancia.EmpresaActual.Sigla + "_" + InformeFalla.GetTexto(infFalla.PkDCodTipoinforme) + ".xml";

                if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    string archivo = dialog.FileName;
                    Exportardor imp = new Exportardor();
                    imp.ExportarInformeFallaExistente(_dSetInforme, archivo);
                    MessageBox.Show("Guardado satisfactoriamente, el archivo : " + new FileInfo(archivo).Name + ".gz");
                }
            }
            _frmInfFalla.CerrarOK();
        }

        private void EnviarInforme()
        {
            //ModeloMgr.Instancia.InformeFallaMgr.PonerFechaHora(_infFalla);
            InformeFalla infFalla = _frmInfFalla.InfFalla;
            _dSetInforme = infFalla.GetDataSet();
            if (Sesion.Instancia.RolSIN != "CNDC")
            {
                _datosEnviadosAlServidor = CNDC.Sincronizacion.SincronizadorCliente.Instancia.MgrServidor.Subir(_dSetInforme, "SISFALLA");
            }
            GenerarAdjuntos(_dSetInforme);
            EnviarEmail();
        }

        public void GenerarAdjuntos(DataSet ds)
        {
            InformeFalla infFalla = _frmInfFalla.InfFalla;
            Exportardor imp = new Exportardor();
            imp.ExportarInforme(infFalla, ds);
            repSisfalla.PantallaReporte p = new repSisfalla.PantallaReporte();
            if (p.informeDesplegado("", "", 29, "", infFalla.PkCodFalla.ToString(), infFalla.PkDCodTipoinforme.ToString(), infFalla.PkOrigenInforme.ToString()))
            {
                p.Refresh();
                p.exportarpdf(Path.Combine(Application.StartupPath, "INFORMEFALLA_" + RegFalla.FormatearCodFalla(infFalla.PkCodFalla.ToString()) + "_" + CNDC.BLL.Sesion.Instancia.EmpresaActual.Sigla + "_" + InformeFalla.GetTexto(infFalla.PkDCodTipoinforme)) + ".pdf");
            }
        }

        private void EnviarEmail()
        {
            InformeFalla infFalla = _frmInfFalla.InfFalla;
            _resultadoEnvioInforme = ResultadoEnvioEmail.NoEnviado;
            string strEmail = string.Empty;
            EnviadorEmail email = new EnviadorEmail();
            List<string> destinatarios = new List<string>();
            List<string> archivosAdjuntos = new List<string>();
            string prefijoArchivo = Path.Combine(Application.StartupPath, "INFORMEFALLA_" + RegFalla.FormatearCodFalla(infFalla.PkCodFalla.ToString()) + "_" + CNDC.BLL.Sesion.Instancia.EmpresaActual.Sigla + "_" + InformeFalla.GetTexto(infFalla.PkDCodTipoinforme));

            if (Sesion.Instancia.RolSIN == "CNDC")
            {
                DataTable contactos = ModeloMgr.Instancia.RContactoMgr.GetRegistros(infFalla.PkCodFalla, CNDC.BLL.Sesion.Instancia.EmpresaActual.PkCodPersona);
                foreach (DataRow r in contactos.Rows)
                {
                    strEmail = r["EMAIL"].ToString();
                    destinatarios.Add(strEmail);
                }

                if (infFalla.PkDCodTipoinforme != (long)PK_D_COD_TIPOINFORME.PRELIMINAR)
                {
                    string nombreArchivoAnalisis = ModeloMgr.Instancia.AnalisisMgr.DescargarInformeAnalisis(infFalla.PkCodFalla);
                    if (!string.IsNullOrEmpty(nombreArchivoAnalisis))
                    {
                        archivosAdjuntos.Add(nombreArchivoAnalisis);
                    }
                }
            }
            else
            {
                destinatarios.Add("sisfallav2@cndc.bo");//TODO adicionar como destinatario al CNDC
            }

            destinatarios.Add("hnogales@cndc.bo");//TODO borrar
            destinatarios.Add("inavarro@cndc.bo");//TODO borrar
            if (File.Exists(prefijoArchivo + ".pdf"))
            {
                archivosAdjuntos.Add(prefijoArchivo + ".pdf");
            }
            if (File.Exists(prefijoArchivo + ".xml.gz"))
            {
                archivosAdjuntos.Add(prefijoArchivo + ".xml.gz");
            }
            P_GF_Correos encabezado = ModeloMgr.Instancia.P_GF_CorreosMgr.Get(1, D_COD_SECC_CORREO.ENCABEZADO_INFORME);
            encabezado.Texto = encabezado.Texto.Replace("#NN_FALLA#", RegFalla.FormatearCodFalla(infFalla.PkCodFalla.ToString()));
            P_GF_Correos cuerpo = ModeloMgr.Instancia.P_GF_CorreosMgr.Get(1, D_COD_SECC_CORREO.CUERPO_INFORME);
            cuerpo.Texto = cuerpo.Texto.Replace("#NN_FALLA#", RegFalla.FormatearCodFalla(infFalla.PkCodFalla.ToString()));
            try
            {
                email.Enviar(encabezado.Texto, cuerpo.Texto, destinatarios, archivosAdjuntos);
                _resultadoEnvioInforme = ResultadoEnvioEmail.Enviado;
            }
            catch (Exception ex)
            {
                _resultadoEnvioInforme = ResultadoEnvioEmail.EnviadoConError;
                PistaMgr.Instance.Error("SISFALLA", ex);
            }
        }   

        public override bool GetVisible()
        {
            bool resultado = false;
            InformeFalla infFalla = _frmInfFalla.InfFalla;

            Operacion opn = new Operacion();
            if (_frmInfFalla._editandoInforme)
            {
                if (Sesion.Instancia.RolSIN == "CNDC")
                {
                    if (infFalla.PkDCodTipoinforme == (long)PK_D_COD_TIPOINFORME.PRELIMINAR
                        && opn.OperacionValida(DOMINIOS_OPERACION.CNDC_ENVIA_PRELIMINAR, infFalla.PkCodFalla, 7))
                    {
                        resultado = true;
                    }
                    else if (infFalla.PkDCodTipoinforme == (long)PK_D_COD_TIPOINFORME.FINAL
                        && opn.OperacionValida(DOMINIOS_OPERACION.CNDC_ENVIA_FINAL, infFalla.PkCodFalla, 7))
                    {
                        resultado = true;
                    }
                    else if (infFalla.PkDCodTipoinforme == (long)PK_D_COD_TIPOINFORME.RECTIFICATORIO
                     && opn.OperacionValida(DOMINIOS_OPERACION.CNDC_ENVIA_RECTIFICATORIO, infFalla.PkCodFalla, 7))
                    {
                        resultado = true;
                    }
                }
                else
                {
                    if (infFalla.PkDCodTipoinforme == (long)PK_D_COD_TIPOINFORME.PRELIMINAR
                        && opn.OperacionValida(DOMINIOS_OPERACION.AGENTE_ENVIA_PRELIMINAR, infFalla.PkCodFalla, infFalla.PkOrigenInforme))
                    {
                        resultado = true;
                    }
                    else if (infFalla.PkDCodTipoinforme == (long)PK_D_COD_TIPOINFORME.FINAL
                        && opn.OperacionValida(DOMINIOS_OPERACION.AGENTE_ENVIA_FINAL, infFalla.PkCodFalla, infFalla.PkOrigenInforme))
                    {
                        resultado = true;
                    }
                }
            }
            return resultado;
        }
    }
}
