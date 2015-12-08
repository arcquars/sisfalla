using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CNDC.BaseForms;
using ModeloSisFalla;
using CNDC.BLL;
using MenuQuantum;
using SisFallaEmailLib;
using CNDC.Pistas;
using CNDC.Dominios;
using CNDC.ExceptionHandlerLib;

namespace SISFALLA
{
    public partial class FormRevertirNotificacion : ABMBaseForm, IFuncionalidad
    {
        BindingList<ItemReversionNotif> _agentes;
        RegFalla _regFalla;
        BindingList<Persona> _agentesInvolucrados;
        public Dictionary<string, string> Parametros { get; set; }

        public FormRevertirNotificacion()
        {
            InitializeComponent();
        }

        public void VisualizarAgentesInvolucrados()
        {
            _agentes = new BindingList<ItemReversionNotif>();
            _agentesInvolucrados = _regFalla.GetAgentesInvolcrados();
            Persona ae = OraDalPersonaMgr.Instancia.GetAgente(26);
            Persona cndc = OraDalPersonaMgr.Instancia.GetAgente(7);
            Persona agentePropCompFallado = null;
            if (_regFalla.CodComponente != 0)
            {
                Componente componente = ModeloMgr.Instancia.ComponenteMgr.GetComponente(_regFalla.CodComponente);
                agentePropCompFallado = OraDalPersonaMgr.Instancia.GetAgente(componente.Propietario);
            }

            Eliminar(_agentesInvolucrados, ae);
            Eliminar(_agentesInvolucrados, cndc);
            Eliminar(_agentesInvolucrados, agentePropCompFallado);

            foreach (Persona p in _agentesInvolucrados)
            {
                _agentes.Add(new ItemReversionNotif(p));
            }
            _dgvAgentesInvolucrados.DataSource = _agentes;
            BaseForm.VisualizarColumnas(_dgvAgentesInvolucrados, GetConfColAgentes());
        }

        private void Eliminar(BindingList<Persona> agentesInvolucrados, Persona p)
        {
            if (p == null)
            {
                return;
            }

            for (int i = 0; i < agentesInvolucrados.Count; i++)
            {
                if (agentesInvolucrados[i].PkCodPersona == p.PkCodPersona)
                {
                    agentesInvolucrados.Remove(agentesInvolucrados[i]);
                    break;
                }
            }
        }

        public void Ejecutar()
        {
            _regFalla = Sesion.Instancia.GetObjetoGlobal<RegFalla>("Principal.FallaActual");
            VisualizarAgentesInvolucrados();
            if (_agentesInvolucrados.Count == 0)
            {
                MessageBox.Show(MessageMgr.Instance.GetMessage("NO_AGENTE_PA_REVERTIR"));
            }
            else
            {
                ShowDialog();
            }
        }

        private Dictionary<string, int> GetConfColAgentes()
        {
            Dictionary<string, int> resultado = new Dictionary<string, int>();
            resultado["Seleccion"] = 70;
            resultado["Sigla"] = 70;
            resultado["Agente"] = 250;
            return resultado;
        }

        protected override bool Guardar()
        {
            List<long> agentesSeleccionados = GetAgenteSeleccionados();
            string codPersonasSeparadosPorComa = GetSepadadosPorComa(agentesSeleccionados);
            if (agentesSeleccionados.Count > 0)
            {
                ModeloMgr.Instancia.NotificacionMgr.RevertirNotificacion(_regFalla.CodFalla, codPersonasSeparadosPorComa);
                EnviarEmail(codPersonasSeparadosPorComa);
                DialogResult = DialogResult.OK;
                return true;
            }
            else
            {
                MessageBox.Show(MessageMgr.Instance.GetMessage("NO_AGENTES_SELECCIONADOS"));
            }
            return false;
        }

        private ResultadoEnvioEmail EnviarEmail(string codPersonasSeparadosPorComa)
        {
            ResultadoEnvioEmail resultadoEnvioNotificacion = ResultadoEnvioEmail.NoEnviado;
            EnviadorEmail email = new EnviadorEmail();
            List<string> destinatarios = ModeloMgr.Instancia.RContactoMgr.GetEmailsDeContactos(codPersonasSeparadosPorComa);

            P_GF_Correos encabezado = ModeloMgr.Instancia.P_GF_CorreosMgr.Get(1, D_COD_SECC_CORREO.ENCABEZADO_REVERSION_NOTIF);
            encabezado.Texto = encabezado.Texto.Replace("#NN_FALLA#", RegFalla.FormatearCodFalla(_regFalla.CodFalla.ToString()));
            P_GF_Correos cuerpo = ModeloMgr.Instancia.P_GF_CorreosMgr.Get(1, D_COD_SECC_CORREO.CUERPO_REVERSION_NOTIF);
            cuerpo.Texto = cuerpo.Texto.Replace("#NN_FALLA#", RegFalla.FormatearCodFalla(_regFalla.CodFalla.ToString()));
            try
            {
                email.Enviar(encabezado.Texto, cuerpo.Texto, destinatarios, new List<string>());
                resultadoEnvioNotificacion = ResultadoEnvioEmail.Enviado;
            }
            catch (Exception ex)
            {
                resultadoEnvioNotificacion = ResultadoEnvioEmail.EnviadoConError;
                PistaMgr.Instance.Error("SISFALLA", ex);
            }
            return resultadoEnvioNotificacion;
        }

        private string GetSepadadosPorComa(List<long> agentesSeleccionados)
        {
            string resultado = string.Empty;
            foreach (var pkCodPersona in agentesSeleccionados)
            {
                if (resultado != string.Empty)
                {
                    resultado += ",";
                }
                resultado += pkCodPersona;
            }
            return resultado;
        }

        private List<long> GetAgenteSeleccionados()
        {
            List<long> resultado = new List<long>();
            _dgvAgentesInvolucrados.EndEdit();
            foreach (ItemReversionNotif item in _agentes)
            {
                if (item.Seleccion)
                {
                    resultado.Add(item.GetAgente().PkCodPersona);
                }
            }
            return resultado;
        }

        private void cndcButton1_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }
    }

    public class ItemReversionNotif
    {
        private Persona _persona;
        public bool Seleccion { get; set; }

        public ItemReversionNotif(Persona p)
        {
            _persona = p;
        }

        public string Sigla
        { get { return _persona.Sigla; } }

        public string Agente
        { get { return _persona.Nombre; } }

        public Persona GetAgente()
        { return _persona; }
    }
}