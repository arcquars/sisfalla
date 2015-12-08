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

namespace SISFALLA
{
    public partial class FormInformeFalla : BaseForm, IFuncionalidad
    {
        PK_D_COD_TIPOINFORME _tipoInforme;
        Persona _persona;
        RegFalla _regFalla;
        InformeFalla _infFalla;

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

        private void FormInformeFalla_Load(object sender, EventArgs e)
        {
            Visualizar();
        }

        private void Visualizar()
        {
            VisualizarRegFalla();
            AsegurarInfFalla();
            VisualizarInfFallaACtual();
        }

        private void VisualizarRegFalla()
        {
            _txtNumFalla.Text = RegFalla.FormatearCodFalla(_regFalla.CodFalla.ToString());
            _txtFecHoraFalla.Text = _regFalla.FecInicio.ToString(Sesion.FORMATO_FECHA);

            if (_regFalla.CodProblemasGen == 0)
            {
                _ctrlComponenteComprometido.Visible = true;
                _ctrlComponenteComprometido.PkCodComponente = _regFalla.CodComponente;
                _lblCompFallado.Visible = false;
            }
            else
            {
                _lblCompFallado.Visible = true;
                _cmbProblemasGen.SelectedValue = _regFalla.CodProblemasGen;
            }
            _cmbProblemasGen.Visible = !_ctrlComponenteComprometido.Visible;

            if (_regFalla.CodComponente == 0)
            {
                _rbtnDeficit.Checked = true;
            }
            else
            {
                _rbtnFalla.Checked = true;
            }
        }

        private void AsegurarInfFalla()
        {
            _infFalla = ModeloMgr.Instancia.InformeFallaMgr.GetInforme(_regFalla.CodFalla, _persona.PkCodPersona, (long)_tipoInforme);
            if (_infFalla == null)
            {
                _infFalla = new InformeFalla();
                _infFalla.EsNuevo = true;
                _infFalla.CodEstadoInf = (long)D_COD_ESTADO_INF.EN_ELABORACION;
                _infFalla.PkCodFalla = _regFalla.CodFalla;
                _infFalla.FecInicio = _regFalla.FecInicio;
                
                if (Sesion.Instancia.RolSIN == "CNDC")
                {
                    _infFalla.Descripcion = _regFalla.DescripcionFalla;
                }

                _infFalla.PkOrigenInforme = _persona.PkCodPersona;
                _infFalla.PkDCodTipoinforme = (long)_tipoInforme;
                _infFalla.CodComponenteFallado = (long)_regFalla.CodComponente;

                _infFalla.DCodOrigen = _regFalla.CodOrigen;
                _infFalla.DCodTipoDesconexion = _regFalla.CodTipoDesconexion;
                _infFalla.DCodCausa = _regFalla.CodCausa;
                _infFalla.CodPersona = (long)Sesion.Instancia.UsuarioActual.PkCodUsuario;

                InformeFalla informeAnterior = null;
                if (_tipoInforme == PK_D_COD_TIPOINFORME.FINAL)
                {
                    informeAnterior = ModeloMgr.Instancia.InformeFallaMgr.GetInforme(_regFalla.CodFalla, _persona.PkCodPersona, (long)PK_D_COD_TIPOINFORME.PRELIMINAR);
                }
                else if (_tipoInforme == PK_D_COD_TIPOINFORME.RECTIFICATORIO)
                {
                    informeAnterior = ModeloMgr.Instancia.InformeFallaMgr.GetInforme(_regFalla.CodFalla, _persona.PkCodPersona, (long)PK_D_COD_TIPOINFORME.FINAL);
                }

                if (informeAnterior != null)
                {
                    CopiarDePreliminar();
                    _infFalla.Descripcion = informeAnterior.Descripcion;
                    _infFalla.DCodOrigen = informeAnterior.DCodOrigen;
                    _infFalla.DCodTipoDesconexion = informeAnterior.DCodTipoDesconexion;
                    _infFalla.DCodCausa = informeAnterior.DCodCausa;
                    _infFalla.NumFallaAgente = informeAnterior.NumFallaAgente;
                }
            }
        }

        private void VisualizarInfFallaACtual()
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
            Persona p = ModeloMgr.Instancia.PersonaMgr.GetPersona(_infFalla.CodPersona);
            if (p != null)
            {
                _txtElaboradoPor.Text = p.Nombre;
            }

            AsegurarTabsAnalisisColapso();
            AsegurarBotones();

            if (_infFalla.PkOrigenInforme != Sesion.Instancia.EmpresaActual.PkCodPersona || _infFalla.CodEstadoInf == (long)D_COD_ESTADO_INF.ENVIADO)
            {
                DeshabilitarControles();
            }

            //_txtNumFallaAgente estará visible sólo para Agentes
            _txtNumFallaAgente.Visible = !(Sesion.Instancia.RolSIN == "AE" || Sesion.Instancia.RolSIN == "CNDC");
            if (Sesion.Instancia.RolSIN == "CNDC")
            {
                _txtNumFallaAgente.Text = _txtNumFalla.Text;
            }
            else
            {
                _txtNumFallaAgente.Text = _infFalla.NumFallaAgente;
            }
        }

        private void AsegurarTabsAnalisisColapso()
        {
            if (Sesion.Instancia.RolSIN != "CNDC" || _infFalla.PkDCodTipoinforme == (long)PK_D_COD_TIPOINFORME.PRELIMINAR)
            {
                _tabcomponentes.TabPages.Remove(_tabAnalisis);
                _tabcomponentes.TabPages.Remove(_tabColapso);
            }
        }

        private void AsegurarBotones()
        {
            if (Sesion.Instancia.RolSIN == "CNDC")
            {
                _btnCopiarDatos.Visible = true;

                D_COD_ESTADO_INF estado = (D_COD_ESTADO_INF)_infFalla.CodEstadoInf;
                switch (estado)
                {
                    case D_COD_ESTADO_INF.EN_ELABORACION:
                        _btnTerminarInforme.Visible = true;
                        _btnEnviarInforme.Enabled = false;
                        break;
                    case D_COD_ESTADO_INF.ELABORADO:
                        _btnTerminarInforme.Visible = false;
                        _btnEnviarInforme.Enabled = true;
                        break;
                    case D_COD_ESTADO_INF.ENVIADO:
                        _btnTerminarInforme.Visible = false;
                        _btnEnviarInforme.Enabled = false;
                        if (_tipoInforme == PK_D_COD_TIPOINFORME.PRELIMINAR)
                        {
                            _btnRevertirInforme.Visible = true;
                        }
                        break;
                }
            }
            else
            {
                _btnCopiarDatos.Visible = false;
                _btnTerminarInforme.Visible = false;
                _btnEnviarInforme.Enabled = true;
            }

            if (_infFalla.EsNuevo && _tipoInforme != PK_D_COD_TIPOINFORME.PRELIMINAR)
            {
                _btnCopiarDePreliminar.Enabled = true;
            }
            else
            {
                _btnCopiarDePreliminar.Enabled = false;
            }
        }

        private void DeshabilitarControles()
        {
            _btnCopiarDatos.Visible = false;
            _btnTerminarInforme.Visible = false;
            _btnEnviarInforme.Enabled = false;
            _btnCopiarDePreliminar.Enabled = false;

            _txtDescripcionFalla.ReadOnly = true;
            _txtProcRestitucion.ReadOnly = true;
            _txtOperacionProtecciones.ReadOnly = true;
            _txtInfAdicional.ReadOnly = true;
            _txtNumFallaAgente.Enabled = false;
            _cbxOrigen.Enabled = false;
            _cbxTipoDesconex.Enabled = false;
            _cbxCausa.Enabled = false;
            _ctrlComponenteComprometido.Enabled = false;
            _tStripInformeFalla.Enabled = false;

            ctrlAlimentadores1.SoloLectura = true;
            ctrlAnalisisFalla1.SoloLectura = true;
            ctrlComponentesComprometidos1.SoloLectura = true;
            ctrlInterruptoresReles1.SoloLectura = true;
            ctrlColapso1.SoloLectura = true;
        }

        private void _tbtnGuardar_Click(object sender, EventArgs e)
        {
            Guardar();
        }

        private void Guardar()
        {
            if (DatosValidos())
            {
                //_infFalla.FecInicio = _txtFecHoraFalla.;
                _infFalla.Descripcion = _txtDescripcionFalla.Text;
                _infFalla.InformacionAdicional = _txtInfAdicional.Text;
                _infFalla.OperacionProtecciones = _txtOperacionProtecciones.Text;
                _infFalla.ProcRestitucion = _txtProcRestitucion.Text;
                _infFalla.DCodOrigen = (long)_cbxOrigen.SelectedValue;
                _infFalla.DCodTipoDesconexion = (long)_cbxTipoDesconex.SelectedValue;
                _infFalla.DCodCausa = (long)_cbxCausa.SelectedValue;
                _infFalla.NumFallaAgente = _txtNumFallaAgente.Text;
                _infFalla.CodComponenteFallado = (long)_ctrlComponenteComprometido.PkCodComponente;
                ModeloMgr.Instancia.InformeFallaMgr.Guardar(_infFalla);

                Operacion opn = new Operacion();
                DOMINIOS_OPERACION tipo_opn  = DOMINIOS_OPERACION.NULL;
                if (Sesion.Instancia.RolSIN == "CNDC")
                {
                    switch (_tipoInforme)
                    {
                        case PK_D_COD_TIPOINFORME.PRELIMINAR:
                            tipo_opn = DOMINIOS_OPERACION.CNDC_ELABORA_PRELIMINAR;
                            break;
                        case PK_D_COD_TIPOINFORME.FINAL:
                            tipo_opn = DOMINIOS_OPERACION.CNDC_ELABORA_FINAL;
                            break;
                        case PK_D_COD_TIPOINFORME.RECTIFICATORIO:
                            break;
                    }
                }
                else
                {
                    switch (_tipoInforme)
                    {
                        case PK_D_COD_TIPOINFORME.PRELIMINAR:
                            tipo_opn = DOMINIOS_OPERACION.AGENTE_ELABORA_PRELIMINAR;
                            break;
                        case PK_D_COD_TIPOINFORME.FINAL:
                            tipo_opn = DOMINIOS_OPERACION.AGENTE_ELABORA_FINAL;
                            break;
                        case PK_D_COD_TIPOINFORME.RECTIFICATORIO:
                            break;

                    }
                }
                opn.RegistrarOperacion(tipo_opn, _infFalla.PkCodFalla, _persona.PkCodPersona);
            }
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

        private void _tabcomponentes_Selecting(object sender, TabControlCancelEventArgs e)
        {
            if (e.TabPageIndex > 0)
            {
                if (_infFalla.EsNuevo)
                {
                    Guardar();
                }
                ICtrlParteInformeFalla obj = e.TabPage.Controls[0] as ICtrlParteInformeFalla;
                obj.Informe = _infFalla;
            }
        }

        private void _btnCopiarDatos_Click(object sender, EventArgs e)
        {
            if (_infFalla.EsNuevo)
            {
                MessageBox.Show("Antes debe guardar el Informe.");
            }
            else
            {
                DataTable tablaAlim = ModeloMgr.Instancia.OperacionAlimentadorMgr.GetOpeAlim(_infFalla);
                DataTable tablaInterrup = ModeloMgr.Instancia.OperacionInterruptoresMgr.GetInterruptores(_infFalla);
                DataTable tablaCompCompro = ModeloMgr.Instancia.RRegFallaComponenteMgr.GetTablaVisualizable(_infFalla);

                if (tablaAlim.Rows.Count == 0 && tablaCompCompro.Rows.Count == 0 && tablaInterrup.Rows.Count == 0)
                {
                    ModeloMgr.Instancia.OperacionAlimentadorMgr.CopiarAlimentadoresDeAgentes(_infFalla);
                    ModeloMgr.Instancia.OperacionInterruptoresMgr.CopiarInterruptoresDeAgentes(_infFalla);
                    ModeloMgr.Instancia.RRegFallaComponenteMgr.CopiarCompComproDeAgentes(_infFalla);
                    MessageBox.Show("Los datos han sido copiados satisfactoriamente.");
                }
                else
                {
                    MessageBox.Show(MessageMgr.Instance.GetMessage("NO_ES_POSIBLE_COPIAR"));
                }
            }
        }

        ResultadoEnvioEmail _resultadoEnvioInforme = ResultadoEnvioEmail.NoEnviado;
        bool _datosEnviadosAlServidor = false;
        DataSet _dSetInforme;
        private void _btnEnviarInforme_Click(object sender, EventArgs e)
        {
            _infFalla.CodEstadoInf = (long)D_COD_ESTADO_INF.ENVIADO;
            if (Sesion.Instancia.FechaHoraServidor == null)
            {
                _infFalla.FecRegistro = Sesion.Instancia.Conexion.GetFechaHora();
            }
            else
            {
                _infFalla.FecRegistro = Sesion.Instancia.FechaHoraServidor.Value;
            }
            Guardar();
            FormTareaAsincrona f = new FormTareaAsincrona();
            f.Visualizar("Envío Informe de Falla", "Enviando Informe...", EnviarInforme);
            bool enviarManualmente = false;
            string mensaje1 = string.Empty;
            string mensaje2 = string.Empty;

            switch (_resultadoEnvioInforme)
            {
                case ResultadoEnvioEmail.Enviado:
                    mensaje2 = "Envío de datos vía Correo Electrónico: SI";
                    break;
                case ResultadoEnvioEmail.EnviadoConError:
                case ResultadoEnvioEmail.NoEnviado:
                    mensaje2 = "Envío de datos vía Correo Electrónico: CON ERRORES. Se recomienda enviarlos por otro medio. Se procedera a crear los archivos correspondientes.";                    
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
                    mensaje1 = "Envío de datos vía Servicio CNDC: SI";
                }
                else
                {
                    mensaje1 = "Envío de datos vía Servicio CNDC: NO";
                }
                msg = string.Format("- {0}{1}- {2}", mensaje1, Environment.NewLine, mensaje2);
            }
            
            MessageBox.Show(msg, "Envío Informe", MessageBoxButtons.OK);

            if (enviarManualmente)
            {
                SaveFileDialog dialog = new SaveFileDialog();

                dialog.Title = "Exportar Registro para envío por correo electrónico.";
                dialog.Filter = "Archivos Sisfalla|*.gz|Todos Archivos|*.*";
                dialog.FileName = "INFORMEFALLA_" + RegFalla.FormatearCodFalla(_infFalla.PkCodFalla.ToString()) + "_" + CNDC.BLL.Sesion.Instancia.EmpresaActual.Sigla + "_" + InformeFalla.GetTexto(_infFalla.PkDCodTipoinforme) + ".xml";

                if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    string archivo = dialog.FileName;
                    ExportarImportar imp = new ExportarImportar(12, _dSetInforme, _infFalla);
                    imp.ExportarInformeFallaExistente(archivo);
                    MessageBox.Show("Guardado satisfactoriamente, el archivo : " + new FileInfo(archivo).Name + ".gz");
                }
            }
            DialogResult= System.Windows.Forms.DialogResult.OK;
        }

        private void EnviarInforme()
        {
            //ModeloMgr.Instancia.InformeFallaMgr.PonerFechaHora(_infFalla);
            _dSetInforme = _infFalla.GetDataSet();
            if (Sesion.Instancia.RolSIN != "CNDC")
            {
                _datosEnviadosAlServidor = CNDC.Sincronizacion.SincronizadorCliente.Instancia.MgrServidor.Subir(_dSetInforme, "SISFALLA");
            }
            GenerarAdjuntos(_dSetInforme);
            EnviarEmail();

            DOMINIOS_OPERACION top = DOMINIOS_OPERACION.NULL;
            if (Sesion.Instancia.RolSIN == "CNDC")
            {
                switch (_tipoInforme)
                {
                    case PK_D_COD_TIPOINFORME.PRELIMINAR:
                        top = DOMINIOS_OPERACION.CNDC_ENVIA_PRELIMINAR;
                        break;
                    case PK_D_COD_TIPOINFORME.FINAL:
                        top = DOMINIOS_OPERACION.CNDC_ENVIA_FINAL;
                        break;
                    case PK_D_COD_TIPOINFORME.RECTIFICATORIO:
                        break;
                }

                Operacion opn = new Operacion();
                if (opn.OperacionValida(top, _infFalla.PkCodFalla, _persona.PkCodPersona))
                {
                    opn.RegistrarOperacion(top, _infFalla.PkCodFalla, _persona.PkCodPersona);
                }
                else
                {
                    MessageBox.Show("No valido");
                }
            }
        }

        public void GenerarAdjuntos(DataSet ds)
        {
            ExportarImportar imp = new ExportarImportar(12, ds, _infFalla);
            imp.mgrXML();
            repSisfalla.PantallaReporte p = new repSisfalla.PantallaReporte();
            if (p.informeDesplegado("", "", 29, "", _infFalla.PkCodFalla.ToString(), _infFalla.PkDCodTipoinforme.ToString(), _infFalla.PkOrigenInforme.ToString()))
            {
                p.Refresh();
                p.exportarpdf(Path.Combine(Application.StartupPath, "INFORMEFALLA_" + RegFalla.FormatearCodFalla(_infFalla.PkCodFalla.ToString()) + "_" + CNDC.BLL.Sesion.Instancia.EmpresaActual.Sigla + "_" + InformeFalla.GetTexto(_infFalla.PkDCodTipoinforme)) + ".pdf");
            }
        }

        private void EnviarEmail()
        {
            _resultadoEnvioInforme = ResultadoEnvioEmail.NoEnviado;
            string strEmail = string.Empty;
            EnviadorEmail email = new EnviadorEmail();
            List<string> destinatarios = new List<string>();
            List<string> archivosAdjuntos = new List<string>();
            string prefijoArchivo = Path.Combine(Application.StartupPath, "INFORMEFALLA_" + RegFalla.FormatearCodFalla(_infFalla.PkCodFalla.ToString()) + "_" + CNDC.BLL.Sesion.Instancia.EmpresaActual.Sigla + "_" + InformeFalla.GetTexto(_infFalla.PkDCodTipoinforme));
            DataTable contactos = ModeloMgr.Instancia.RContactoMgr.GetRegistros(_infFalla.PkCodFalla, CNDC.BLL.Sesion.Instancia.EmpresaActual.PkCodPersona);

            if (Sesion.Instancia.RolSIN == "CNDC")
            {
                foreach (DataRow r in contactos.Rows)
                {
                    strEmail = r["EMAIL"].ToString();
                    destinatarios.Add(strEmail);
                }
            }
            else
            {
                destinatarios.Add("sisfallav2@cndc.bo");//TODO adicionar como destinatario al CNDC
            }

            destinatarios.Add("hnogales@cndc.bo");//TODO borrar
            //destinatarios.Add("gesquivel@cndc.bo");//TODO borrar
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
            encabezado.Texto = encabezado.Texto.Replace("#NN_FALLA#", RegFalla.FormatearCodFalla(_infFalla.PkCodFalla.ToString()));
            P_GF_Correos cuerpo = ModeloMgr.Instancia.P_GF_CorreosMgr.Get(1, D_COD_SECC_CORREO.CUERPO_INFORME);
            cuerpo.Texto = cuerpo.Texto.Replace("#NN_FALLA#", RegFalla.FormatearCodFalla(_infFalla.PkCodFalla.ToString()));
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

        private void _btnTerminarInforme_Click(object sender, EventArgs e)
        {
            if (BaseForm.EstaSeguro("Seguro que desea Terminar el Informe ?"))
            {
                Operacion opn = new Operacion();
                DOMINIOS_OPERACION tipo_opn = DOMINIOS_OPERACION.NULL;

                if (Sesion.Instancia.RolSIN == "CNDC")
                {
                    switch (_tipoInforme)
                    {
                        case PK_D_COD_TIPOINFORME.PRELIMINAR:
                            tipo_opn = DOMINIOS_OPERACION.CNDC_TERMINA_PRELIMINAR  ;
                            break;
                        case PK_D_COD_TIPOINFORME.FINAL:
                            tipo_opn = DOMINIOS_OPERACION.CNDC_TERMINA_FINAL ;
                            break;
                        case PK_D_COD_TIPOINFORME.RECTIFICATORIO:
                       
                            break;
                    }
                }
                if (opn.OperacionValida(tipo_opn, _infFalla.PkCodFalla, _persona.PkCodPersona))
                {
                    opn.RegistrarOperacion(tipo_opn, _infFalla.PkCodFalla, _persona.PkCodPersona);
                    _infFalla.CodEstadoInf = (long)D_COD_ESTADO_INF.ELABORADO;
                    Guardar();
                    MessageBox.Show("El Informe se ha Terminado satisfactoriamente.");
                    DialogResult = System.Windows.Forms.DialogResult.OK;
                }
                else
                {
                    MessageBox.Show("El estado del Informe no permite guardarlo");
                }
            }
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
            DOMINIOS_OPERACION tipo_opn =  DOMINIOS_OPERACION.NULL ;

            if (Sesion.Instancia.RolSIN == "CNDC")
            {
                switch (_tipoInforme)
                {
                    case PK_D_COD_TIPOINFORME.PRELIMINAR:
                        tipo_opn = DOMINIOS_OPERACION.CNDC_ELABORA_PRELIMINAR;
                        break;
                    case PK_D_COD_TIPOINFORME.FINAL:
                        tipo_opn = DOMINIOS_OPERACION.CNDC_ELABORA_FINAL;
                        break;
                    case PK_D_COD_TIPOINFORME.RECTIFICATORIO:
                        //tipo_opn = DOMINIOS_OPERACION.RECTIFICATORIO_CNDC ;
                        break;
                }
                //if (_persona.PkCodPersona == Sesion.Instancia.EmpresaActual.PkCodPersona && !opn.OperacionValida((long)tipo_opn, _regFalla.CodFalla, _persona.PkCodPersona))
                //{
                //    Close();
                //    MessageBox.Show("No puede realizar ésta operación.");
                //}
            }

            if (_persona.PkCodPersona != Sesion.Instancia.EmpresaActual.PkCodPersona && _infFalla == null)
            {
                Close();
                MessageBox.Show("Informe no registrado en Base de Datos.");
            }
            else
            {
                ShowDialog();
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

        private void _btnCopiarDePreliminar_Click(object sender, EventArgs e)
        {
            CopiarDePreliminar();
        }

        private void CopiarDePreliminar()
        {
            ResultadoCopiaInforme resultado = ModeloMgr.Instancia.InformeFallaMgr.CopiarInforme
            (_infFalla.PkCodFalla, _infFalla.PkOrigenInforme, (long)PK_D_COD_TIPOINFORME.PRELIMINAR,
            _infFalla.PkCodFalla, _infFalla.PkOrigenInforme, (long)PK_D_COD_TIPOINFORME.FINAL);
            switch (resultado)
            {
                case ResultadoCopiaInforme.Error:
                    break;
                case ResultadoCopiaInforme.OK:
                    MessageBox.Show("Se han copiado los datos del Informe Preliminar.");
                    RecargarInforme();
                    break;
                case ResultadoCopiaInforme.NoExisteOrigen:
                    break;
                case ResultadoCopiaInforme.YaExisteDestino:
                    break;
            }
        }

        private void RecargarInforme()
        {
            _infFalla = ModeloMgr.Instancia.InformeFallaMgr.GetInforme(_regFalla.CodFalla, _persona.PkCodPersona, (long)_tipoInforme);
            Visualizar();
        }

        private void _btnRevertirInforme_Click(object sender, EventArgs e)
        {
            if (EstaSeguro("Esta seguro de Revertir el Informe ?"))
            {
                _infFalla.Revertir();
                DialogResult = DialogResult.OK;
            }
        }
    }

    public interface ICtrlParteInformeFalla
    {
        InformeFalla Informe { set; }
    }
}
