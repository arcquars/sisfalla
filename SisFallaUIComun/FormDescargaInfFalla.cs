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
    public partial class FormDescargaInfFalla : Form,IFuncionalidad
    {
        private int _pkCodFallaSeleccionado;
        private int _cod_fallaParametro;
        private bool _runInBack;
        public ParametrosFuncionalidad Parametros { get; set; }
        public FormDescargaInfFalla()
        {
            InitializeComponent();

            _cod_fallaParametro = -1;
            _runInBack = false;
            
        }

        public FormDescargaInfFalla(int pk_codfalla, Boolean runInBack )
        {
            InitializeComponent();

            _cod_fallaParametro = pk_codfalla;
            _runInBack = runInBack;
        }
        private void FormDescargaInfFalla_Load(object sender, EventArgs e)
        {
            OraDalRegFallaMgr mgr = new OraDalRegFallaMgr();
            DataTable tablaFallas = mgr.GetTabla();
            DataColumn colCodFallaFormateado = new DataColumn("Formateado", typeof(string));
            tablaFallas.Columns.Add(colCodFallaFormateado);

            foreach (DataRow r in tablaFallas.Rows)
            {
                r["Formateado"] = RegFalla.FormatearCodFalla(r[RegFalla.C_PK_COD_FALLA].ToString());
            }

            _cmbRegistrosFalla.ValueMember = RegFalla.C_PK_COD_FALLA;
            _cmbRegistrosFalla.DisplayMember = "Formateado";
            _cmbRegistrosFalla.DataSource = tablaFallas;

            if (_cod_fallaParametro >=0)
            {
            foreach (DataRowView drv in _cmbRegistrosFalla.Items)
            {

                if ((int)drv.Row["PK_COD_FALLA"] == _cod_fallaParametro)
                {
                    _cmbRegistrosFalla.SelectedItem = drv;

                    if (_runInBack)
                    {
                        this.Visible = false;

                        _btnDecargar_Click(null, null);
                    }
                }
              
            }}
        }

        private void _cmbRegistrosFalla_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_cmbRegistrosFalla.SelectedItem != null)
            {
                _chlbxAgentes.Items.Clear();
                _pkCodFallaSeleccionado = (int)_cmbRegistrosFalla.SelectedValue;
                OraDalNotificacionMgr mgr = new OraDalNotificacionMgr();
                DataTable agInvolucrados = mgr.GetCodPersonaSiglaDeInvolucrados(_pkCodFallaSeleccionado);
              
                foreach (DataRow r in agInvolucrados.Rows)
                {
                    AgentesInvolucradosTmp a = new AgentesInvolucradosTmp(r);
                    if (a.PkCodPersona != 26)
                    {
                        
                        _chlbxAgentes.Items.Add(a);
                    }
                }
            }
        }

        public void Ejecutar()
        {
            ShowDialog();
        }

        private void _btnDecargar_Click(object sender, EventArgs e)
        {
            bool offline = Convert.ToBoolean(ConfigurationManager.AppSettings["OffLine"]);
            if (!offline)
            {
                if (_chlbxAgentes.Items.Count == 0)
                {
                    MessageBox.Show("No hay items seleccionados.");
                }
                else
                {
                    FormTareaAsincrona tarea = new FormTareaAsincrona();
                    tarea.Visualizar("Descargando Informes de Falla", "Descargando...", DescargarInformes);
                }
                this.DialogResult = System.Windows.Forms.DialogResult.OK;
                this.Close();
            }
            else
            {

                MessageBox.Show("Sistema en modo fuera de linea.", "Descarga de Informes.", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
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
        private void DescargarInformes()
        {
            try
            {
                int _pkCodFalla = _cod_fallaParametro;
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

                    // if (continuaRec)
                    //{
                    //    foreach (AgentesInvolucradosTmp a in agentes)
                    //    {
                    //        byte[] informe = WcfServicioMgr.Instancia.Servicio.GetInforme(CNDC.BLL.Sesion.Instancia.TokenSession, _pkCodFalla, a.PkCodPersona, (long)PK_D_COD_TIPOINFORME.RECTIFICATORIO  );
                    //        ImportarInforme(informe, out dummy);
                    //    }
                    //}

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
        private static bool ImportarInforme(byte[] informe, out bool continuaImportando)
        {
            bool resultado = false;
            continuaImportando = false;
            if (informe != null)
            {
                informe = GZip.DesComprimir(informe);
                DataSet ds = Serializador.DeSerializar<DataSet>(informe);
                Importador imp = new Importador();
                DataTable dtInforme = ds.Tables["F_GF_INFORMEFALLA"];
                if (dtInforme != null)
                {
                    if (dtInforme.Rows.Count > 0)
                    {
                        long estadoInforme = (long)dtInforme.Rows[0]["D_COD_ESTADO_INF"];
                        long _pkCodPersona = (long)dtInforme.Rows[0]["PK_ORIGEN_INFORME"];
                        // si es informe revertido del mismo agente se debe descargar

                        if ((estadoInforme == (int)D_COD_ESTADO_INF.ENVIADO) ||
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
       
 
    }

  public   class AgentesInvolucradosTmp : IComparable, IEquatable<AgentesInvolucradosTmp>

    {
        public long PkCodPersona { get; set; }
        public string Sigla { get; set; }

        public AgentesInvolucradosTmp(long pkCodPersona, string sigla)
        {
            PkCodPersona = pkCodPersona;
            Sigla = sigla;
        }

        public AgentesInvolucradosTmp(DataRow r)
        {
            PkCodPersona = (long)r[Notificacion.C_PK_COD_PERSONA];
            Sigla = (string)r["SIGLA"];
        }

        public override string ToString()
        {
            return Sigla;
        }

        public int CompareTo(object obj)
        {
            int rtn = 0;

            AgentesInvolucradosTmp oObj = (AgentesInvolucradosTmp)obj;
            if (this.PkCodPersona < oObj.PkCodPersona)
            {
                rtn = -1;
            }
            else
            {
                if (PkCodPersona == oObj.PkCodPersona)
                {
                    rtn = 0;
                }
                else
                {
                    rtn = 1;
                }

            }

            return rtn;
        }

        public bool Equals(AgentesInvolucradosTmp otro)
        {
            
            if (this.PkCodPersona == otro.PkCodPersona && this.Sigla == otro.Sigla 
                )
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        public static  List<AgentesInvolucradosTmp> AsegurarCNDCPrimero(List<AgentesInvolucradosTmp > origen)
        {
            List<AgentesInvolucradosTmp> rtn = new List<AgentesInvolucradosTmp>();

            foreach (AgentesInvolucradosTmp a in origen) // primero se tiebe que buscar a CNDC para ingresarlo en la lista.
            {
                if (a.PkCodPersona == 7)
                {
                    rtn.Add(a);
                    origen.Remove(a);
                    break;
                }
            }
            origen.Sort();
            foreach (AgentesInvolucradosTmp a in origen) // primero se tiebe que buscar a CNDC para ingresarlo en la lista.
            {
                rtn.Add(a);
                
            }

            return rtn;


        }

    }
}
