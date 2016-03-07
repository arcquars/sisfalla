using System;
using System.Collections.Generic;
using System.Configuration;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using OraDalSisFalla;
using ModeloSisFalla;
using MenuQuantum;
using WcfDalSisFalla;
using CNDC.Dominios;
using CNDC.UtilesComunes;
using CNDC.Pistas;
using CNDC.BaseForms;

namespace SISFALLA
{
    public partial class FormDescargaInformeBatch : Form, IFuncionalidad
    {
        public FormDescargaInformeBatch()
        {
            InitializeComponent();
        }
        public ParametrosFuncionalidad Parametros { get; set; }
        private OraDalRegFallaMgr mgr;
        public void Ejecutar()
        {
            ShowDialog();
        }

        private void FormDescargaInformeBatch_Load(object sender, System.EventArgs e)
        {

             mgr = new OraDalRegFallaMgr();

             DataTable tablagestiones = mgr.GetGestiones();
             
             _cmbGestiones.ValueMember = "valor";
             _cmbGestiones.DisplayMember = "gestion";
             _cmbGestiones.DataSource = tablagestiones;
        }

        private List<AgentesInvolucradosTmp> GetAgentesInvolucrados(int pkcodFalla)
        {
            List<AgentesInvolucradosTmp> Agentes = new List<AgentesInvolucradosTmp>();
            int _pkCodFallaSeleccionado = pkcodFalla;
            OraDalNotificacionMgr mgr = new OraDalNotificacionMgr();
            DataTable agInvolucrados = mgr.GetCodPersonaSiglaDeInvolucrados(_pkCodFallaSeleccionado);

            foreach (DataRow r in agInvolucrados.Rows)
            {
                AgentesInvolucradosTmp a = new AgentesInvolucradosTmp(r);
                if (a.PkCodPersona != 26)
                {
                    Agentes.Add(a);
                }
            }
            return Agentes;
        }

 
        private int _pkCodFalla = -1;
        private void _btnDecargar_Click(object sender, EventArgs e)
        {

            if (CNDC.Sincronizacion.SincronizadorCliente.Instancia.PingHost())
            {
                int _pkCodFallaSeleccionadoInicio = (int)_cmbRegistrosFallaInicio.SelectedValue;
                int _pkCodFallaSeleccionadoFin = (int)_cmbRegistrosFallaFin.SelectedValue;

                for (_pkCodFalla = _pkCodFallaSeleccionadoInicio; _pkCodFalla <= _pkCodFallaSeleccionadoFin; _pkCodFalla++)
                {
                    FormTareaAsincrona tarea = new FormTareaAsincrona();
                    tarea.Visualizar("Descargando Informes de Falla", "Descargando...", DescargarInformes);
                }


                this.DialogResult = System.Windows.Forms.DialogResult.OK;
                this.Close();
            }
            else
            {

                MessageBox.Show("No hay conexion con la vpn.", "", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
            }
        }

        public static bool ImportarInforme(byte[] informe, out bool continuaImportando)
        {
            bool resultado = false;
            continuaImportando = false ;
            if (informe != null)
            {
                informe = GZip.DesComprimir(informe);
                DataSet ds = Serializador.DeSerializar<DataSet>(informe);
                Importador imp = new Importador();
                DataTable dtInforme = ds.Tables["F_GF_INFORMEFALLA"];
                if (dtInforme != null)
                { 
                    if (dtInforme.Rows.Count >0)
                    {
                        long estadoInforme =(long) dtInforme.Rows[0]["D_COD_ESTADO_INF"];
                        long _pkCodPersona = (long )dtInforme.Rows[0]["PK_ORIGEN_INFORME"];
                        string ppp = dtInforme.Rows[0]["PK_COD_FALLA"].ToString();
                        Console.WriteLine(ppp);
                        // si es informe revertido del mismo agente se debe descargar
                        if ((estadoInforme == (int)D_COD_ESTADO_INF.ENVIADO)  ||
                            ((CNDC.BLL.Sesion.Instancia.EmpresaActual.PkCodPersona == _pkCodPersona) && (estadoInforme == (int)D_COD_ESTADO_INF.EN_ELABORACION)))
                        {
                            continuaImportando = true; 
                            resultado = imp.Importar(ds, ContenidoArchivo.Informe, true);
                            
                        }

                    }
                }
            
            }
            return resultado;
        }
        private void DescargarInformes()
        {
                try
                {
                    List<AgentesInvolucradosTmp> agentes = GetAgentesInvolucrados(_pkCodFalla);

                    AgentesInvolucradosTmp agCndc = new AgentesInvolucradosTmp(7, "CNDC");

                    if (agentes.Contains(agCndc))
                    {

                        agentes.Remove(agCndc);
                        bool continuaPre = false;
                        bool continuaFin = false;
                        bool continuaRec = false;

                        bool dummy;

                        byte[] informePreCNDC = WcfServicioMgr.Instancia.Servicio.GetInforme(CNDC.BLL.Sesion.Instancia.TokenSession, _pkCodFalla, agCndc.PkCodPersona, (long)PK_D_COD_TIPOINFORME.PRELIMINAR);
                        ImportarInforme(informePreCNDC, out continuaPre);

                        byte[] informeFinCNDC = WcfServicioMgr.Instancia.Servicio.GetInforme(CNDC.BLL.Sesion.Instancia.TokenSession, _pkCodFalla, agCndc.PkCodPersona, (long)PK_D_COD_TIPOINFORME.FINAL);
                        ImportarInforme(informeFinCNDC, out continuaFin);

                        byte[] informeRecCNDC = WcfServicioMgr.Instancia.Servicio.GetInforme(CNDC.BLL.Sesion.Instancia.TokenSession, _pkCodFalla, agCndc.PkCodPersona, (long)PK_D_COD_TIPOINFORME.RECTIFICATORIO);
                        ImportarInforme(informeRecCNDC, out continuaRec);

                        if (continuaPre)
                        {
                            foreach (AgentesInvolucradosTmp a in agentes)
                            {
                                byte[] informe = WcfServicioMgr.Instancia.Servicio.GetInforme(CNDC.BLL.Sesion.Instancia.TokenSession, _pkCodFalla, a.PkCodPersona, (long)PK_D_COD_TIPOINFORME.PRELIMINAR);
                                ImportarInforme(informe, out dummy);
                            }
                        }

                        if (continuaFin)

                        {
                            foreach (AgentesInvolucradosTmp a in agentes)
                            {
                                byte[] informe = WcfServicioMgr.Instancia.Servicio.GetInforme(CNDC.BLL.Sesion.Instancia.TokenSession, _pkCodFalla, a.PkCodPersona, (long)PK_D_COD_TIPOINFORME.FINAL);
                                ImportarInforme(informe, out dummy);
                            }
                        }

                        if (continuaRec)
                        {
                            foreach (AgentesInvolucradosTmp a in agentes)
                            {
                                byte[] informe = WcfServicioMgr.Instancia.Servicio.GetInforme(CNDC.BLL.Sesion.Instancia.TokenSession, _pkCodFalla, a.PkCodPersona, (long)PK_D_COD_TIPOINFORME.RECTIFICATORIO);
                                ImportarInforme(informe, out dummy);
                            }
                        }
                    }



                    //if (!_runInBack)
                    //{
                    //    MessageBox.Show("Descarga de Informes Finalizada.", "Descarga de Informes.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //}
                    DialogResult = System.Windows.Forms.DialogResult.OK;
                }
                catch (Exception ex)
                {
                    PistaMgr.Instance.Error("FormDescargaInfFalla", ex);
                }
        }


        private void MostrarMensaje()
        {
            if ((_cmbRegistrosFallaInicio.SelectedValue == null) || (_cmbRegistrosFallaFin.SelectedValue == null))
            {
                return;
            }

            int _pkCodFallaSeleccionadoInicio = (int)_cmbRegistrosFallaInicio.SelectedValue;
            int _pkCodFallaSeleccionadoFin = (int)_cmbRegistrosFallaFin.SelectedValue;

            int dif = _pkCodFallaSeleccionadoFin - _pkCodFallaSeleccionadoInicio;
          
            if (dif >= 0)
            {
                cndcLabel3.ForeColor = Color.Black;
                cndcLabel3.Text = string.Format("Se van a descargar {0} informe(s)", dif +1);
                _btnDecargar.Enabled = true ;
            }
            else
            {
                cndcLabel3.ForeColor = Color.Red ;
                cndcLabel3.Text = string.Format("El Número de Falla Inicio debe ser menor al Número de Falla Fin.");
                _btnDecargar.Enabled = false;
            }
        }
        private void _cmbRegistrosFallaInicio_SelectedIndexChanged(object sender, EventArgs e)
        {
            MostrarMensaje();
            _cbTodos.Checked = false;
        }

        private void _cmbRegistrosFallaFin_SelectedIndexChanged(object sender, EventArgs e)
        {
            MostrarMensaje();
            _cbTodos.Checked = false;
        }

        private void _cmbGestiones_SelectedIndexChanged(object sender, EventArgs e)
        {
            int gestion =int.Parse ( _cmbGestiones.SelectedValue.ToString () );

            DataTable tablaFallas = mgr.GetRegistrosXGestion(gestion);
            DataTable tablaFallasDestino = null;
            DataColumn colCodFallaFormateado = new DataColumn("Formateado", typeof(string));
            tablaFallas.Columns.Add(colCodFallaFormateado);

            foreach (DataRow r in tablaFallas.Rows)
            {
                r["Formateado"] = RegFalla.FormatearCodFalla(r[RegFalla.C_PK_COD_FALLA].ToString());
            }


            _cmbRegistrosFallaInicio.ValueMember = RegFalla.C_PK_COD_FALLA;
            _cmbRegistrosFallaInicio.DisplayMember = "Formateado";
            _cmbRegistrosFallaInicio.DataSource = tablaFallas;
            tablaFallasDestino = tablaFallas.Copy();
            _cmbRegistrosFallaFin.ValueMember = RegFalla.C_PK_COD_FALLA;
            _cmbRegistrosFallaFin.DisplayMember = "Formateado";
            _cmbRegistrosFallaFin.DataSource = tablaFallasDestino;
            _cmbRegistrosFallaFin.SelectedIndex = tablaFallasDestino.Rows.Count - 1;
            _cbTodos.Checked  = false;
            
        }

        private void _cbTodos_CheckedChanged(object sender, EventArgs e)
        {
            if (_cbTodos.Checked)
            {
                try
                {
                    _cmbRegistrosFallaInicio.SelectedIndex = 0;
                    _cmbRegistrosFallaFin.SelectedIndex = _cmbRegistrosFallaFin.Items.Count-1;
                }
                catch (Exception ex)
                {
                    int i = 0;
                }


            }
        }

    }
}
