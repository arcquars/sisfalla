using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CNDC.BLL;
using ModeloSisFalla;
using CNDC.BaseForms;
using CNDC.Dominios;
using SisFallaEmailLib;
using System.IO;
using CNDC.Pistas;
using BLL;
using MenuQuantum;
using repSisfalla;

namespace SISFALLA
{
    public partial class CtrlAgentesInvolucrados : UserControl
    {
        private RegFalla _regFalla;
        private Persona _agenteSeleccionado;
        private Persona _ae;
        private Persona _cndc;
        private Persona _agentePropCompFallado;

        private BindingList<Persona> _listaOriginalAgentes;
        private BindingList<Persona> _agentesInvolucrados;
        private BindingSource _bsrcContactos;
        private bool _visualizarTodosContactos;

        private int PkCodCNDC = 7;

        public CtrlAgentesInvolucrados()
        {
            InitializeComponent();
            _agentesInvolucrados = new BindingList<Persona>();
        }

        private Dictionary<string, int> GetConfColAgentes()
        {
            Dictionary<string, int> resultado = new Dictionary<string, int>();
            resultado["Sigla"] = 70;
            resultado["Nombre"] = 300;
            return resultado;
        }

        public void VisualizarAgentesInvolucrados(RegFalla regFalla)
        {
            _agentesInvolucrados = new BindingList<Persona>();
            _listaOriginalAgentes = null;
            _regFalla = regFalla;
            _cndc = OraDalPersonaMgr.Instancia.GetAgente(PkCodCNDC);
            AsegurarAE();

            BindingList<Notificacion> notificaciones = ModeloMgr.Instancia.NotificacionMgr.GetAgentesInvolucrados(_regFalla.CodFalla);
            foreach (var n in notificaciones)
            {
                if (!Existe(_agentesInvolucrados, n.PkCodPersona) && n.PkCodPersona != _cndc.PkCodPersona)
                {
                    if (n.PkCodPersona != 26 && n.DCodEstado == "1")
                    {
                        _agentesInvolucrados.Add(OraDalPersonaMgr.Instancia.GetAgente(n.PkCodPersona));
                    }
                }
            }
        }

        public void SeleccionarAgentes()
        {
            _listaOriginalAgentes = GetCopia(_agentesInvolucrados);
            FormAgentesInvolucrados frmAgeNotif = new FormAgentesInvolucrados();
            frmAgeNotif.SeleccionarAgentes(_agentesInvolucrados);
        }

        private BindingList<Persona> GetCopia(BindingList<Persona> lista)
        {
            BindingList<Persona> resultado = new BindingList<Persona>();
            foreach (Persona p in lista)
            {
                resultado.Add(p);
            }
            return resultado;
        }

        private void RefrescarListaContactos()
        {
            AsegurarAE();

            string filtro = RContacto.C_PK_COD_EMPRESA + " IN (";
            if (_visualizarTodosContactos)
            {
                foreach (var item in _agentesInvolucrados)
                {
                    filtro += item.PkCodPersona + ", ";
                }
                if (_agentesInvolucrados.Count > 0)
                {
                    filtro = filtro.Substring(0, filtro.Length - 2);
                }
                else
                {
                    filtro += -1;
                }
            }
            else if (_agenteSeleccionado == null)
            {
                filtro += -1;
            }
            else
            {
                filtro += _agenteSeleccionado.PkCodPersona;
            }
            filtro += ")";
            _bsrcContactos.Filter = filtro;
        }

        public void GuardarNotificaciones(D_COD_ESTADO_NOTIFICACION estadoNotif)
        {
            string codPersonas = string.Empty;
            _agentesInvolucrados.Add(_cndc);
            foreach (var a in _agentesInvolucrados)
            {
                Notificacion n = new Notificacion();
                n.PkCodFalla = _regFalla.CodFalla;
                n.PkCodPersona = a.PkCodPersona;
                n.DCodEstado = "1";
                n.EsNuevo = !ModeloMgr.Instancia.NotificacionMgr.Existe(_regFalla.CodFalla, a.PkCodPersona);

                n.DCodEstadoNotificacion = (long)estadoNotif;
                if (n.EsNuevo || estadoNotif != D_COD_ESTADO_NOTIFICACION.REGISTRADO)
                {
                    ModeloMgr.Instancia.NotificacionMgr.Guardar(n);
                }

                codPersonas += a.PkCodPersona + ",";
            }

            if (codPersonas != string.Empty)
            {
                codPersonas = string.Format("({0})", codPersonas.Substring(0, codPersonas.Length - 1));
                ModeloMgr.Instancia.NotificacionMgr.BorrarNotificacionesIncorrectas(_regFalla.CodFalla, codPersonas);
            }
            _agentesInvolucrados.Remove(_cndc);
        }

        public void SetPropietarioCompoCompro(Persona agentePropCompFallado)
        {
            AsegurarAE();
            if (_agentePropCompFallado != null)
            {
                _agentesInvolucrados.Remove(_agentePropCompFallado);
            }

            _agentePropCompFallado = agentePropCompFallado;
            _agentesInvolucrados.Remove(_agentePropCompFallado);
            int idxParaInsertar = 1;
            if (_agentesInvolucrados.Count == 0)
            {
                idxParaInsertar = 0;
            }
            _agentesInvolucrados.Insert(idxParaInsertar, _agentePropCompFallado);
        }

        ResultadoEnvioEmail resultadoEnvioNotificacion = ResultadoEnvioEmail.NoEnviado;
        string _otrosDestinatarios = string.Empty;
        BindingList<Persona> agentesNotificar;
        string _encabezado;
        string _cuerpo;
        public ResultadoEnvioEmail EnviarEmail(string otrosDestinatarios)
        {
            _otrosDestinatarios = otrosDestinatarios;
            resultadoEnvioNotificacion = ResultadoEnvioEmail.NoEnviado;
            BindingList<Persona> notificados = _regFalla.GetAgentesNotificados();
            agentesNotificar = _agentesInvolucrados;
            if (notificados.Count > 0)
            {
                BindingList<Persona> sinNotificar = _regFalla.GetAgentesSinNotificar();
                FormAgentesNotificar frmAgentesNotificar = new FormAgentesNotificar();
                agentesNotificar = frmAgentesNotificar.Visualizar(notificados, sinNotificar);
                if (agentesNotificar == null)
                {
                    return ResultadoEnvioEmail.EnvioCanceladoPorUs;
                }
            }
            FormEnvioNotif fEnvioNotif = new FormEnvioNotif();
            P_GF_Correos encabezado = ModeloMgr.Instancia.P_GF_CorreosMgr.Get(1, D_COD_SECC_CORREO.ENCABEZADO);
            P_GF_Correos cuerpo = ModeloMgr.Instancia.P_GF_CorreosMgr.Get(1, D_COD_SECC_CORREO.CUERPO);
            _encabezado = encabezado.Texto.Replace("#NN_FALLA#", RegFalla.FormatearCodFalla(_regFalla.CodFalla.ToString()));
            _cuerpo = cuerpo.Texto.Replace("#NN_FALLA#", RegFalla.FormatearCodFalla(_regFalla.CodFalla.ToString()));

            if (fEnvioNotif.Visualizar(_encabezado, _cuerpo) == DialogResult.OK)
            {
                PistaMgr.Instance.Info("Sisfalla  ", "Envio "); 
                _encabezado = fEnvioNotif.Asunto;
                _cuerpo = fEnvioNotif.Cuerpo;
                FormTareaAsincrona f = new FormTareaAsincrona();
                PistaMgr.Instance.Info("Envío Notificación de Falla", "Enviando Notificación..."); 
                f.Visualizar("Envío Notificación de Falla", "Enviando Notificación...", EnviarNotificacion);

                if (resultadoEnvioNotificacion != ResultadoEnvioEmail.NoEnviado)
                {
                    GuardarNotificaciones(D_COD_ESTADO_NOTIFICACION.ENVIADO);
                    RegistrarOperaciones(agentesNotificar);
                }
            }
            else
            {
                resultadoEnvioNotificacion = ResultadoEnvioEmail.EnvioCanceladoPorUs;
            }

            return resultadoEnvioNotificacion;
        }

        private void RegistrarOperaciones(BindingList<Persona> agentesNotificar)
        {
            Operacion opn = new Operacion();
            if (agentesNotificar.Count == _agentesInvolucrados.Count)
            {
                agentesNotificar.Add(_cndc);
            }

            foreach (var a in agentesNotificar)
            {
                opn.RegistrarOperacion(DOMINIOS_OPERACION.CNDC_ENVIA_NOTIFICACION, _regFalla.CodFalla, a.PkCodPersona);
            }

            agentesNotificar.Remove(_cndc);
        }

        private void EnviarNotificacion()
        {
            GenerarAdjuntos();

            EnviadorEmail email = new EnviadorEmail();
            List<string> destinatarios = _regFalla.GetDestinatarios(agentesNotificar, _otrosDestinatarios);
            List<string> archivosAdjuntos = new List<string>();

            string pdf_name = "NOTIFICACIONFALLA_" + RegFalla.FormatearCodFalla(_regFalla.CodFalla.ToString()) + ".pdf";
            string pdf_path = Path.Combine(Exportardor.EnsureExportFolder(), pdf_name);

            archivosAdjuntos.Add(pdf_path);
            archivosAdjuntos.Add(Path.Combine(Exportardor.EnsureExportFolder (), "NOTIFICACIONFALLA_" + RegFalla.FormatearCodFalla(_regFalla.CodFalla.ToString()) + ".xml.gz"));
            
            try
            {
                email.Enviar(_encabezado, _cuerpo, destinatarios, archivosAdjuntos);
                resultadoEnvioNotificacion = ResultadoEnvioEmail.Enviado;
            }
            catch (Exception ex)
            {
                resultadoEnvioNotificacion = ResultadoEnvioEmail.EnviadoConError;
                PistaMgr.Instance.Error("SISFALLA", ex);
            }
        }

        private void AsegurarAE()
        {
            if (_agentesInvolucrados.Count == 0)
            {
                _bsrcContactos = new BindingSource();
                _bsrcContactos.DataSource = ModeloMgr.Instancia.RContactoMgr.GetTabla();
                _dgvContactos.DataSource = _bsrcContactos;

                _dgvAgentesNotificar.DataSource = _agentesInvolucrados;
                BaseForm.VisualizarColumnas(_dgvAgentesNotificar, GetConfColAgentes());
                BaseForm.VisualizarColumnas(_dgvContactos, ColumnStyleManger.GetEstilos("ABMRegistroFallaForm", "_dgvContactos"));

                _ae = OraDalPersonaMgr.Instancia.GetAgente(26);
                if (_agentesInvolucrados.IndexOf(_ae) == -1)
                {
                    _agentesInvolucrados.Add(_ae);
                }
            }
        }

        private bool Existe(BindingList<Persona> lista, long pkCodPersona)
        {
            bool resultado = false;
            foreach (Persona p in lista)
            {
                if (p.PkCodPersona == pkCodPersona)
                {
                    resultado = true;
                    break;
                }
            }
            return resultado;
        }

        private void GenerarAdjuntos()
        {
            Exportardor imp = new Exportardor();
            imp.ExportarNotificacion(_regFalla);
            RptNotificacionParametroExtra parametro = new RptNotificacionParametroExtra(_regFalla.CodFalla);
            string pdf_name = "NOTIFICACIONFALLA_" + RegFalla.FormatearCodFalla(_regFalla.CodFalla.ToString()) + ".pdf";
            string pdf_path = Path.Combine(Exportardor.EnsureExportFolder(), pdf_name);

            parametro.NombreArchivoExportar = pdf_path;
            parametro.ModoVisible = false;
            CNDCMenu.Instancia.EjecutarOpcion(46, parametro);
        }

        private void _dgvAgentesNotificar_SelectionChanged(object sender, EventArgs e)
        {
            if (_dgvAgentesNotificar.CurrentRow != null)
            {
                _agenteSeleccionado = (Persona)_dgvAgentesNotificar.CurrentRow.DataBoundItem;
                RefrescarListaContactos();
            }
        }

        private void _btnVisualizarTodos_Click(object sender, EventArgs e)
        {
            _visualizarTodosContactos = !_visualizarTodosContactos;
            if (_visualizarTodosContactos)
            {
                _btnVisualizarTodos.Text = "Visualizar contactos sólo del agente seleccionado";
            }
            else
            {
                _btnVisualizarTodos.Text = "Visualizar todos los contactos.";
            }
            RefrescarListaContactos();
        }

        public bool HayCambiosSinGuardar()
        {
            bool resultado = false;
            if (_listaOriginalAgentes != null)
            {
                resultado = !ContenidosInguales(_agentesInvolucrados, _listaOriginalAgentes);
            }
            return resultado;
        }

        private bool ContenidosInguales(BindingList<Persona> a, BindingList<Persona> b)
        {
            bool resultado = true;
            if (a.Count == b.Count)
            {
                foreach (Persona p in a)
                {
                    if (!b.Contains(p))
                    {
                        resultado = false;
                        break;
                    }
                }
            }
            else
            {
                resultado = false;
            }
            return resultado;
        }
    }
}
