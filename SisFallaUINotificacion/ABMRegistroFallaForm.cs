using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CNDC.BaseForms;
using ModeloSisFalla;
using SisFallaEmailLib;
using CNDC.Dominios;
using CNDC.BLL;
using CNDC.ExceptionHandlerLib;
using System.IO;
using MenuQuantum;
using CNDC.Pistas;

namespace SISFALLA
{
    public partial class ABMRegistroFallaForm : ABMBaseForm, IFuncionalidad, IRegFalla
    {
        private RegFalla _regFalla;
        private bool _formularioConErrores = false;
        public ABMRegistroFallaForm()
        {
            InitializeComponent();

            if (Sesion.Instancia.RolSIN == "CNDC")
            {
                AdicionarBotonEnviarNotificacion();
            }

            _cmbOrigen.DisplayMember = DefDominio.C_DESCRIPCION;
            _cmbOrigen.ValueMember = DefDominio.C_COD_DOMINIO;
            _cmbOrigen.DataSource = ModeloMgr.Instancia.DefDominioMgr.GetDominio(Dominios.D_COD_ORIGEN_INSTALACION);

            _cmbOperador.DisplayMember = Persona.C_NOM_PERSONA;
            _cmbOperador.ValueMember = Persona.C_PK_COD_PERSONA;
            _cmbOperador.DataSource = OraDalUsuarioMgr.Instancia.GetOperadores();

            DataSet ds = new DataSet();
            DataTable tablaTipoDesconexion = ModeloMgr.Instancia.DefDominioMgr.GetDominio(Dominios.D_TIPO_DESCONEXION);
            ds.Tables.Add(tablaTipoDesconexion);

            DataTable tablaCausaDesconexion = ModeloMgr.Instancia.DefDominioMgr.GetDominio(Dominios.D_CAUSA_DESCONEXION);
            ds.Tables.Add(tablaCausaDesconexion);

            DataRelation relacion = new DataRelation("TipoDesconexion_Causa", tablaTipoDesconexion.Columns[DefDominio.C_COD_DOMINIO], tablaCausaDesconexion.Columns[DefDominio.C_COD_DOMINIO_PADRE]);
            ds.Relations.Add(relacion);

            _cmbTipoDesconexion.DisplayMember = Dominios.D_TIPO_DESCONEXION + "." + DefDominio.C_DESCRIPCION;
            _cmbTipoDesconexion.ValueMember = DefDominio.C_COD_DOMINIO;
            _cmbTipoDesconexion.DataSource = ds;

            _cmbCausa.DisplayMember = Dominios.D_TIPO_DESCONEXION + ".TipoDesconexion_Causa." + DefDominio.C_DESCRIPCION;
            _cmbCausa.ValueMember = DefDominio.C_COD_DOMINIO;
            _cmbCausa.DataSource = ds;

            _cmbProblemasGen.DisplayMember = DefDominio.C_DESCRIPCION;
            _cmbProblemasGen.ValueMember = DefDominio.C_COD_DOMINIO;
            _cmbProblemasGen.DataSource = ModeloMgr.Instancia.DefDominioMgr.GetDominio(Dominios.D_COD_PROBLEMA_GEN);

            _ctrlComponenteComprometido.ComponenteSeleccionadoPorUsuario += new EventHandler(_ctrlComponenteComprometido_ComponenteSeleccionadoPorUsuario);
        }

        private void AdicionarBotonEnviarNotificacion()
        {
            base.AgregarOpcionesToolStrip(global::SisFallaUINotificacion.Properties.Resources.email_go, "_btnEnviar", "Enviar Notificación", _btnEnviarNotificacion_Click);
        }
        private void AdicionarBotonBorrarRegFAlla()
        {
            base.AgregarOpcionesToolStrip(global::SisFallaUINotificacion.Properties.Resources.Delete, "_btnBorrarRegFalla", "Borrar Registro de Falla", _btnBorrarRegFalla_Click, ToolStripItemAlignment.Right);
        }
        
        private void _btnBorrarRegFalla_Click(object sender, EventArgs e)
        {
            InformeFalla infFalla = ModeloMgr.Instancia.InformeFallaMgr.GetInforme(_regFalla.CodFalla, Sesion.Instancia.EmpresaActual.PkCodPersona, (long)PK_D_COD_TIPOINFORME.PRELIMINAR);
            if (infFalla != null)
            {
                MessageBox.Show(MessageMgr.Instance.GetMessage("NO_POSIBLE_BORRAR_REGFALLA"));
            }
            else if (BaseForm.EstaSeguro(MessageMgr.Instance.GetMessage("SEGURO_DE_BORRAR_REGFALLA")))
            {
                FormDetalleBorradoRegFalla fDetBorrado = new FormDetalleBorradoRegFalla();
                if (fDetBorrado.ShowDialog() == DialogResult.OK)
                {
                    if (ModeloMgr.Instancia.RegFallaMgr.Borrar(_regFalla.CodFalla, fDetBorrado.Motivo))
                    {
                        MessageBox.Show(MessageMgr.Instance.GetMessage("REGFALLA_BORRADO_SATISF"));
                    }
                    else
                    {
                        MessageBox.Show(MessageMgr.Instance.GetMessage("REGFALLA_NO_PUDO_BORRARSE"));
                    }
                    DialogResult = DialogResult.OK;
                }
            }
        }

        protected override bool Guardar()
        {
            bool resultado = false;
            if (DatosSonValidos())
            {
                bool esNuevaFalla = _regFalla.EsNuevo;
                if (_regFalla.EsNuevo)
                {
                    _regFalla.CodFalla = CodFalla;
                }

                _regFalla.FecInicio = FecInicio;
                _regFalla.Descripcion = Descripcion;
                _regFalla.CodComponente = CodComponente;
                _regFalla.CodProblemasGen = CodProblemasGen;
                _regFalla.CodOrigen = CodOrigen;
                _regFalla.CodTipoDesconexion = CodTipoDesconexion;
                _regFalla.CodCausa = CodCausa;
                _regFalla.Fk_cod_operador = Fk_cod_operador;
                _regFalla.DescripcionFalla = DescripcionFalla;
                _regFalla.Fk_cod_supervisor = (long)CNDC.BLL.Sesion.Instancia.UsuarioActual.PkCodUsuario;
                ModeloMgr.Instancia.RegFallaMgr.Guardar(_regFalla);

                _ctrlAgentesInvolucrados.GuardarNotificaciones(D_COD_ESTADO_NOTIFICACION.REGISTRADO);
                _ctrlAgentesInvolucrados.VisualizarAgentesInvolucrados(_regFalla);
                if (esNuevaFalla)
                {
                    string numeroFallaFormateado = RegFalla.FormatearCodFalla(_regFalla.CodFalla.ToString());
                    string msg = MessageMgr.Instance.GetMessage("REG_FALLA_GUARDADO");
                    msg = string.Format(msg, numeroFallaFormateado);
                    MessageBox.Show(msg, "TOME NOTA...", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Sesion.Instancia.SetObjetoGlobal("Principal.FallaActual", _regFalla);
                }
                else
                {
                    MessageBox.Show(MessageMgr.Instance.GetMessage("DATOS_GUARDADOS"), string.Empty, MessageBoxButtons.OK);
                }

                SetTextoBoton("_btnCancelar", "Salir");
                SetEnable("_btnEnviar", true);
                _txtNumeroFalla.Enabled = false;
                resultado = true;
            }
            return resultado;
        }

        private bool DatosSonValidos()
        {
            bool resultado = true;
            _errorProvider.Clear();

            _txtNumeroFalla.Text = _txtNumeroFalla.Text.Trim();

            if (_txtNumeroFalla.Text == string.Empty)
            {
                _errorProvider.SetError(_txtNumeroFalla, MessageMgr.Instance.GetMessage("INGRESE_NUM_FALLA"));
                resultado = false;
            }
            else
            {
                if (!_txtNumeroFalla.ReadOnly && ModeloMgr.Instancia.RegFallaMgr.ExisteNumeroFalla(CodFalla))
                {
                    _errorProvider.SetError(_txtNumeroFalla, MessageMgr.Instance.GetMessage("NUM_FALLA_EXISTENTE"));
                    resultado = false;
                }
            }

            if (_txtFechaHoraFalla.EsFechaValida())
            {
                if (_txtFechaHoraFalla.Value > DateTime.Now)
                {
                    _errorProvider.SetError(_txtFechaHoraFalla, MessageMgr.Instance.GetMessage("NO_FECHA_POSTERIOR"));
                    resultado = false;
                }
                else if ((DateTime.Now - _txtFechaHoraFalla.Value).TotalDays > 5)
                {
                    _errorProvider.SetError(_txtFechaHoraFalla, MessageMgr.Instance.GetMessage("FECHA_HORA_NO_VALIDO"));
                    resultado = false;
                }

                if (_txtNumeroFalla.AnioFalla != _txtFechaHoraFalla.Value.Year % 100)
                {
                    _errorProvider.SetError(_txtFechaHoraFalla, MessageMgr.Instance.GetMessage("FECHA_NO_COINCIDE_NUM_FALLA"));
                    resultado = false;
                }
            }
            else
            {
                _errorProvider.SetError(_txtFechaHoraFalla, MessageMgr.Instance.GetMessage("FECHA_HORA_NO_VALIDO"));
                resultado = false;
            }

            if (_rbtnFalla.Checked && _ctrlComponenteComprometido.Componente == null)
            {
                _errorProvider.SetError(_ctrlComponenteComprometido, MessageMgr.Instance.GetMessage("DEFINA_COMPO_FALLADO"));
                resultado = false;
            }

            if (_txtDescripcion.Text == string.Empty)
            {
                _errorProvider.SetError(_txtDescripcion, MessageMgr.Instance.GetMessage("INGRESE_DESCR"));
                resultado = false;
            }

            if (_cmbCausa.SelectedValue == null)
            {
                _errorProvider.SetError(_cmbCausa, MessageMgr.Instance.GetMessage("SELECCIONE_CAUSA"));
                resultado = false;
            }

            if (_cmbOperador.SelectedValue == null)
            {
                _errorProvider.SetError(_cmbOperador, MessageMgr.Instance.GetMessage("SELECCIONE_OPERADOR"));
                resultado = false;
            }

            if (_cmbOrigen.SelectedValue == null)
            {
                _errorProvider.SetError(_cmbOrigen, MessageMgr.Instance.GetMessage("SELECCIONE_ORIGEN"));
                resultado = false;
            }

            if (_cmbTipoDesconexion.SelectedValue == null)
            {
                _errorProvider.SetError(_cmbTipoDesconexion, MessageMgr.Instance.GetMessage("SELECCIONE_TIPO_DESCONEXION"));
                resultado = false;
            }

            _formularioConErrores = !resultado;
            return resultado;
        }

        private void _btnAgentesNotificar_Click(object sender, EventArgs e)
        {
            if (_rbtnFalla.Checked && _ctrlComponenteComprometido.Componente == null)
            {
                MessageBox.Show(MessageMgr.Instance.GetMessage("DEFINA_COMPO_FALLADO"));
            }
            else
            {
                _ctrlAgentesInvolucrados.SeleccionarAgentes();
            }
        }

        private void VisualizarFallaActual()
        {
            PistaMgr.Instance.Debug("Inicio AMBRegFalla.VisualizarFallaActual", DateTime.Now.ToString("HH:mm:ss:fff"));
            if (_regFalla.EsNuevo)
            {
                CodFalla = ModeloMgr.Instancia.RegFallaMgr.GetSiguienteNumFalla();
            }
            else
            {
                CodFalla = _regFalla.CodFalla;
                _txtFechaHoraFalla.Value = _regFalla.FecInicio;
            }

            Descripcion = _regFalla.Descripcion;
            DescripcionFalla = _regFalla.DescripcionFalla;
            CodOrigen = _regFalla.CodOrigen;
            CodTipoDesconexion = _regFalla.CodTipoDesconexion;
            CodCausa = _regFalla.CodCausa;
            if (_regFalla.EsNuevo)
            {
                _lblSupervisor.Text = CNDC.BLL.Sesion.Instancia.UsuarioActual.Nombre;
            }
            else
            {
                _lblSupervisor.Text = ModeloMgr.Instancia.PersonaMgr.GetPersona(_regFalla.Fk_cod_supervisor).Nombre;
            }

            Fk_cod_operador = _regFalla.Fk_cod_operador;

            if (_regFalla.CodProblemasGen == 0)
            {
                _rbtnFalla.Checked = true;
                _ctrlComponenteComprometido.VisualizarComponente(_regFalla.CodComponente);
                SetPropietarioCompoCompro();
            }
            else
            {
                _rbtnFalla.Checked = false;
                _cmbProblemasGen.SelectedValue = _regFalla.CodProblemasGen;
            }

            _rbtnDeficit.Checked = !_rbtnFalla.Checked;
            _ctrlAgentesInvolucrados.VisualizarAgentesInvolucrados(_regFalla);
            PistaMgr.Instance.Debug("Fin AMBRegFalla.VisualizarFallaActual", DateTime.Now.ToString("HH:mm:ss:fff"));
        }

        private void _btnEnviarNotificacion_Click(object sender, EventArgs e)
        {
            bool enviarNotif = true;
            if (HayCambiosSinGuardar())
            {
                Guardar();
                if (_formularioConErrores)
                {
                    enviarNotif = false;
                    MessageBox.Show(MessageMgr.Instance.GetMessage("NO_POSIBLE_ENVIAR_NOTIF"));
                }
            }

            if (enviarNotif)
            {
                EnviarNotificacion();
                ModeloMgr.Instancia.RegFallaMgr.Guardar(_regFalla);
                ModeloMgr.Instancia.RegFallaMgr.IncrementarSincVer (_regFalla.CodFalla);
            }
        }

        private void EnviarNotificacion()
        {
            ResultadoEnvioEmail r = _ctrlAgentesInvolucrados.EnviarEmail(_txtOtrosDestinatarios.Text);
            string msg = string.Empty;
            MessageBoxIcon icono = MessageBoxIcon.None;
            switch (r)
            {
                case ResultadoEnvioEmail.Enviado:
                    msg=MessageMgr.Instance.GetMessage("NOTIFICACION_ENVIADA");
                    icono = MessageBoxIcon.Information;
                    break;
                case ResultadoEnvioEmail.NoEnviado:
                    msg = MessageMgr.Instance.GetMessage("NOTIF_NO_ENVIADA");
                    icono = MessageBoxIcon.Error;
                    break;
                case ResultadoEnvioEmail.EnviadoConError:
                    msg = MessageMgr.Instance.GetMessage("NOTIF_ENVIADA_PARCIAL");
                    icono = MessageBoxIcon.Warning;
                    break;
                case ResultadoEnvioEmail.EnvioCanceladoPorUs:
                    msg = MessageMgr.Instance.GetMessage("NOTIF_CANCELADA_US");
                    icono = MessageBoxIcon.Warning;
                    break;
            }
            MessageBox.Show(msg, "Envío Notificación", MessageBoxButtons.OK, icono);
            DialogResult = System.Windows.Forms.DialogResult.OK;
        }

        private void DeshabilitarControles()
        {
            PistaMgr.Instance.Debug("Inicio AMBRegFalla.DeshabilitarControles", DateTime.Now.ToString("HH:mm:ss:fff"));
            _btnCancelar.Enabled = false;
            _btnGuardar.Enabled = false;
            _btnAgentesNotificar.Enabled = false;
            _ctrlComponenteComprometido.Enabled = false;
            _cmbProblemasGen.Enabled = false;

            _txtNumeroFalla.ReadOnly = true;
            _txtDescripcionFalla.ReadOnly = true;
            _txtFechaHoraFalla.ReadOnly = true;
            _txtOtrosDestinatarios.ReadOnly = true;
            _txtDescripcion.ReadOnly = true;

            _cmbCausa.Enabled = false;
            _cmbOperador.Enabled = false;
            _cmbOrigen.Enabled = false;
            _cmbTipoDesconexion.Enabled = false;

            _pnlBotonesRadio.Enabled = false;

            SetEnable("_btnEnviar", false);
            PistaMgr.Instance.Debug("Fin AMBRegFalla.DeshabilitarControles", DateTime.Now.ToString("HH:mm:ss:fff"));

        }

        private void _rbtnFalla_CheckedChanged(object sender, EventArgs e)
        {
            AsegurarCompComproCmbProblGen();
        }

        private void AsegurarCompComproCmbProblGen()
        {
            PistaMgr.Instance.Debug("Inicio AMBRegFalla.AsegurarCompComproCmbProblGen", DateTime.Now.ToString("HH:mm:ss:fff"));
            _ctrlComponenteComprometido.Visible = _rbtnFalla.Checked;
            _cmbProblemasGen.Visible = !_ctrlComponenteComprometido.Visible;
            PistaMgr.Instance.Debug("Fin AMBRegFalla.AsegurarCompComproCmbProblGen", DateTime.Now.ToString("HH:mm:ss:fff"));
        }

        private void _txtFechaHoraFalla_TextChanged(object sender, EventArgs e)
        {
            _errorProvider.SetError(_txtFechaHoraFalla, string.Empty);
        }

        private void _txtFechaHoraFalla_Validating(object sender, CancelEventArgs e)
        {
            _errorProvider.SetError(_txtFechaHoraFalla, string.Empty);
            if (_txtFechaHoraFalla.EsFechaValida())
            {
                if (_txtFechaHoraFalla.Value > DateTime.Now)
                {
                    _errorProvider.SetError(_txtFechaHoraFalla, MessageMgr.Instance.GetMessage("NO_FECHA_POSTERIOR"));
                    e.Cancel = true;
                }
                else if ((DateTime.Now - _txtFechaHoraFalla.Value).TotalDays > 365)
                {
                    _errorProvider.SetError(_txtFechaHoraFalla, MessageMgr.Instance.GetMessage("FECHA_HORA_NO_VALIDO"));
                    e.Cancel = true;
                }
            }
            else
            {
                _errorProvider.SetError(_txtFechaHoraFalla, MessageMgr.Instance.GetMessage("FECHA_HORA_NO_VALIDO"));
                e.Cancel = true;
            }
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            PistaMgr.Instance.Debug("Inicio AMBRegFalla.OnLoad", DateTime.Now.ToString("HH:mm:ss:fff"));
            AsegurarCompComproCmbProblGen();

            PistaMgr.Instance.Debug("Fin AMBRegFalla.OnLoad", DateTime.Now.ToString("HH:mm:ss:fff"));
        }

        #region Funcionalidad
        public ParametrosFuncionalidad Parametros { get; set; }

        public void Ejecutar()
        {
            PistaMgr.Instance.Debug("Inicio AMBRegFalla.Ejecutar", DateTime.Now.ToString("HH:mm:ss:fff"));
            bool visualizarVentana = true;
            if (Parametros != null)
            {
                switch (Parametros.DiccionarioParametros["TAG"])
                {
                    case "NOTIFICACION.ENVIARNOTIFICACION":
                        _regFalla = Sesion.Instancia.GetObjetoGlobal<RegFalla>("Principal.FallaActual");
                        Operacion opn = new Operacion();
                        if (opn.ExisteRegistro(DOMINIOS_OPERACION.CNDC_ENVIA_PRELIMINAR, _regFalla.CodFalla, 7) == -1)
                        {
                            VisualizarFallaActual();
                            SetEnable("_btnEnviar", true);
                            _txtNumeroFalla.ReadOnly = true;
                            _txtFechaHoraFalla.ReadOnly = true;
                        }
                        else
                        {
                            MessageBox.Show(MessageMgr.Instance.GetMessage("TARDE_PARA_NOTIFICAR"));
                            visualizarVentana = false;
                        }
                        break;
                    case "NOTIFICACION.VISUALIZAR":
                        _regFalla = Sesion.Instancia.GetObjetoGlobal<RegFalla>("Principal.FallaActual");
                        VisualizarFallaActual();
                        DeshabilitarControles();
                        break;
                    case "NOTIFICACION.REGISTROFALLA":
                        _regFalla = new RegFalla();
                        _regFalla.EsNuevo = true;
                        VisualizarFallaActual();
                        SetEnable("_btnEnviar", false);
                        break;
                    case "NOTIFICACION.ELIM_REG_FALLA":
                        _regFalla = Sesion.Instancia.GetObjetoGlobal<RegFalla>("Principal.FallaActual");
                        VisualizarFallaActual();
                        DeshabilitarControles();
                        AdicionarBotonBorrarRegFAlla();
                        break;
                }
            }

            if (visualizarVentana)
            {
                ShowDialog();
            }

            PistaMgr.Instance.Debug("Fin AMBRegFalla.Ejecutar", DateTime.Now.ToString("HH:mm:ss:fff"));
        }
        #endregion Funcionalidad

        private void ABMRegistroFallaForm_FormClosing(object sender, FormClosingEventArgs e)
        {
        //    if (_regFalla.EsNuevo)
        //    {
        //        if (MessageBox.Show("No se ha guardado el registro de falla, Está seguro de cerrar la ventana ?", "", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.No)
        //        {
        //            e.Cancel = true;
        //        }
        //    }
        //    else if (HayCambiosSinGuardar())
        //    {
        //        if (MessageBox.Show("Hay cambios que no se han guardado, Está seguro de cerrar la ventana ?", "", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.No)
        //        {
        //            e.Cancel = true;
        //        }
        //    }
        }

        protected override bool HayCambiosSinGuardar()
        {
            bool resultado = false;

            if (CodCausa != _regFalla.CodCausa)
            {
                resultado = true;
            }

            if (_rbtnFalla.Checked && CodComponente != _regFalla.CodComponente)
            {
                resultado = true;
            }

            if (CodOrigen != _regFalla.CodOrigen)
            {
                resultado = true;
            }

            if (_rbtnDeficit.Checked && CodProblemasGen != _regFalla.CodProblemasGen)
            {
                resultado = true;
            }

            if (CodTipoDesconexion != _regFalla.CodTipoDesconexion)
            {
                resultado = true;
            }

            if (Descripcion != _regFalla.Descripcion)
            {
                resultado = true;
            }

            if (DescripcionFalla != _regFalla.DescripcionFalla)
            {
                resultado = true;
            }

            if (FecInicio != _regFalla.FecInicio)
            {
                resultado = true;
            }

            if (Fk_cod_operador != _regFalla.Fk_cod_operador)
            {
                resultado = true;
            }

            if (_ctrlAgentesInvolucrados.HayCambiosSinGuardar())
            {
                resultado = true;
            }
            return resultado;
        }

        #region Propiedades
        public long CodCausa
        {
            get { return ObjetoDeNegocio.GetValor<long>(_cmbCausa.SelectedValue); }
            set { _cmbCausa.SelectedValue = value; }
        }

        public long CodColapso
        {
            get { throw new NotImplementedException(); }
            set { throw new NotImplementedException(); }
        }

        public decimal CodComponente
        {
            get
            {
                if (_rbtnFalla.Checked)
                    return _ctrlComponenteComprometido.PkCodComponente;
                else
                    return 0;
            }
            set { _ctrlComponenteComprometido.PkCodComponente = value; }
        }

        public int CodFalla
        {
            get { return _txtNumeroFalla.NumeroFalla; }
            set { _txtNumeroFalla.NumeroFalla = value; }
        }

        public long CodOrigen
        {
            get { return ObjetoDeNegocio.GetValor<long>(_cmbOrigen.SelectedValue); }
            set { _cmbOrigen.SelectedValue = value; }
        }

        public long CodProblemasGen
        {
            get
            {
                if (_rbtnDeficit.Checked)
                    return ObjetoDeNegocio.GetValor<long>(_cmbProblemasGen.SelectedValue);
                else
                    return 0;
            }
            set { _cmbProblemasGen.SelectedValue = value; }
        }

        public long CodTipoDesconexion
        {
            get { return ObjetoDeNegocio.GetValor<long>(_cmbTipoDesconexion.SelectedValue); }
            set { _cmbTipoDesconexion.SelectedValue = value; }
        }

        public string Descripcion
        {
            get { return _txtDescripcion.Text; }
            set { _txtDescripcion.Text = value; }
        }

        public string DescripcionFalla
        {
            get { return _txtDescripcionFalla.Text; }
            set { _txtDescripcionFalla.Text = value; }
        }

        public DateTime FecInicio
        {
            get { return _txtFechaHoraFalla.Value; }
            set { _txtFechaHoraFalla.Value = value; }
        }

        public long Fk_cod_operador
        {
            get { return ObjetoDeNegocio.GetValor<long>(_cmbOperador.SelectedValue); }
            set { _cmbOperador.SelectedValue = value; }
        }
        #endregion

        private void _ctrlComponenteComprometido_ComponenteSeleccionadoPorUsuario(object sender, EventArgs e)
        {
            SetPropietarioCompoCompro();
        }

        private void SetPropietarioCompoCompro()
        {
            if (_ctrlComponenteComprometido.Componente == null)
            {

            }
            else
            {
                Persona agentePropCompFallado = OraDalPersonaMgr.Instancia.GetAgente(_ctrlComponenteComprometido.Componente.Propietario);
                _ctrlAgentesInvolucrados.SetPropietarioCompoCompro(agentePropCompFallado);
            }
        }
    }
}