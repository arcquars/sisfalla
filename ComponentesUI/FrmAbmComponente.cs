using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CNDC.BaseForms;
using ModeloSisFalla;
using CNDC.BLL;
using CNDC.Dominios;
using CNDC.DAL;
using CNDC.ExceptionHandlerLib;
using BLL;

namespace ComponentesUI
{
    public partial class FrmAbmComponente : Form
    {
        #region Variable
        private long _idNodoOrigen = -1;
        private long _idNodoDestino = -1;
        private decimal _idComponente;
        private ModeloComponentes.Componente _componente;

        private Dictionary<string, long> _dicTipoCompLng;
        private Dictionary<string, string> _dicTipoCompStr;
        private Dictionary<long, string> _dicTipoValStr;
        #endregion

        public bool Nuevo { get; set; }

        public ModeloComponentes.Componente Componente
        {
            get { return _componente; }
            set
            {
                _componente = value;
                CargarComponenteForm();
            }
        }

        public FrmAbmComponente()
        {
            InitializeComponent();
            _dtpFechaBaja.Enabled = false;

            _cmbAgente.DisplayMember = Persona.C_NOM_COD_AGENTE;
            _cmbAgente.ValueMember = Persona.C_PK_COD_PERSONA;
            _cmbAgente.DataSource = ModeloMgr.Instancia.PersonaMgr.GetAgentes();

            DataTable tComponentes = OraDalComponentes.ComponenteMgr.Instancia.GetTipoComponentes();

            _tbIdComp.LostFocus += new EventHandler(_tbIdComp_LostFocus);

            _dicTipoCompLng = new Dictionary<string, long>();
            _dicTipoCompStr = new Dictionary<string, string>();
            _dicTipoValStr = new Dictionary<long, string>();
            foreach (DataRow row in tComponentes.Rows)
            {
                _dicTipoCompLng.Add(((string)row["DESCRIPCION_TIPO"]).ToUpper(), (long)row["PK_COD_TIPO_COMPONENTE"]);
                _dicTipoCompStr.Add(((string)row["SIGLA"]).ToUpper(), ((string)row["DESCRIPCION_TIPO"]).ToUpper());
                _dicTipoValStr.Add((long)row["PK_COD_TIPO_COMPONENTE"], ((string)row["DESCRIPCION_TIPO"]).ToUpper());
            }
        }

        private void CargarComponenteForm()
        {
            _idComponente = _componente.PkCodComponente;
            _tbIdComp.Text = _componente.CodigoComponente;
            _tbIdComp.Enabled = false;
            _tbCodComp.Text = _componente.NombreComponente;
            _tbDescrip.Text = _componente.Descripcion;
            _dtpFechaIni.Value = _componente.FechaIngreso;
            _cbFechaBaja.Checked = _componente.TieneFechaSalida;
            if (_componente.Propietario >= 0)
            {
                _cmbAgente.SelectedValue = _componente.Propietario;
            }

            if (_componente.Propietario == 0)
            {
                _cmbAgente.Enabled = false;
            }

            if (_componente.TieneFechaSalida)
            {
                _dtpFechaBaja.Value = _componente.FechaSalida;
            }

            if (_componente.PkCodNodoOrigen > 0)
            {
                string nombreNodo = OraDalComponentes.NodoMgr.Instancia.GetIdUniversal(_componente.PkCodNodoOrigen);
                FormatNodoDespliegue(_lblNodoOrigen, _componente.PkCodNodoOrigen, nombreNodo);
            }
            if (_componente.PkCodNodoDestino > 0)
            {
                string nombreNodo = OraDalComponentes.NodoMgr.Instancia.GetIdUniversal(_componente.PkCodNodoDestino);
                FormatNodoDespliegue(_lblNodoDestino, _componente.PkCodNodoDestino, nombreNodo);
            }

            _lblTipoC.Text = _dicTipoValStr[_componente.DTipoComponente];
        }

        private void CargarComponenteDeForm()
        {
            if (_componente == null)
            {
                _componente = new ModeloComponentes.Componente();
                _componente.EsNuevo = true;
            }
            _componente.CodigoComponente = _tbIdComp.Text.ToUpper();
            _componente.Descripcion = _tbDescrip.Text;
            _componente.NombreComponente = _tbCodComp.Text.ToUpper();
            _componente.FechaIngreso = _dtpFechaIni.Value.Date;
            _componente.TieneFechaSalida = _cbFechaBaja.Checked;
            _componente.FechaSalida = _dtpFechaBaja.Value.Date;
            _componente.DTipoComponente = _dicTipoCompLng[_lblTipoC.Text];

            _idNodoOrigen = -1;
            _idNodoDestino = -1;
            string sOrigen = _lblNodoOrigen.Text;
            string sDestino = _lblNodoDestino.Text;

            if (sOrigen.Length > 2)
            {
                _idNodoOrigen = ValidarNodo(sOrigen, _lblNodoOrigen);
            }

            if (sDestino.Length > 2)
            {
                _idNodoDestino = ValidarNodo(sDestino, _lblNodoDestino);
            }
            if (_componente.DTipoComponente > 0)
            {
                _componente.Propietario = (long)_cmbAgente.SelectedValue;
                _componente.PkCodNodoOrigen = _idNodoOrigen;
                _componente.PkCodNodoDestino = _idNodoDestino;
            }
        }

        private void FormatNodoDespliegue(Label l, long pkCodNodo, string IdUNodo)
        {
            l.Text = string.Format("{1} ", pkCodNodo, IdUNodo);
        }

        private bool DefinifirTipoComponente(string tipoComponente, TextBox tb, ErrorProvider ep)
        {
            bool rtn = false;
            string serror = ep.GetError(tb);

            if (_dicTipoCompStr.ContainsKey(tipoComponente))
            {
                _lblTipoC.Text = _dicTipoCompStr[tipoComponente];
                _cmbAgente.Enabled = tipoComponente != "NO";
                rtn = true;
            }
            else
            {
                serror = _errorProvider.GetError(_tbIdComp);
                serror += "Id Universal no permite identificar el tipo de componente";
                _errorProvider.SetError(_tbIdComp, serror);
            }

            return rtn;
        }

        private bool NodoValidoEnFecha(string idUniversal, DateTime fechaInicio, bool tieneFechaFin, DateTime fechaFin)
        {
            bool rtn = false;
            if (tieneFechaFin)
            {
                rtn = OraDalComponentes.NodoMgr.Instancia.NodoValidoEnRango(idUniversal, fechaInicio, fechaFin);
            }
            else
            {
                rtn = OraDalComponentes.NodoMgr.Instancia.NodoValidoEnRango(idUniversal, fechaInicio, fechaInicio);
            }
            return rtn;
        }

        private bool Val()
        {
            int tamano = -1;
            bool rtn = true;

            string idUniversal = _tbIdComp.Text.Trim().ToUpper();
            tamano = idUniversal.Length;
            _cmbAgente.Enabled = true;
            _tbCodComp.MaxLength = 30;

            if (Nuevo)
            {
                if (tamano <= 2)
                {
                    _errorProvider.SetError(_tbIdComp, "Tamaño del Id. Universal incorrecto");
                    rtn = false;
                }
                else
                {
                    string tipocomp = idUniversal.Substring(0, 2);
                    string nodoOrigen = string.Empty;
                    string nodoDestino = string.Empty;
                    _lblNodoOrigen.Text = string.Empty;
                    _lblNodoDestino.Text = string.Empty;

                    if (DefinifirTipoComponente(tipocomp, _tbIdComp, _errorProvider))
                    {
                        //         C  L -- - AL 10 CP 10 IG 10 IT 10 RE 10 UG 10 IT 11 LT 15 AT 16 CS 16 LT 16 TR 16 
                        if ((tipocomp == "NO") && tamano == 8)
                        {
                            _cmbAgente.Enabled = false;
                            // debo validar que no exista IdUniversalEnNodos
                            if (_tbCodComp.Text.Length > 20)
                            {
                                _tbCodComp.Text = _tbCodComp.Text.Substring(0, 20);
                            }
                            _tbCodComp.MaxLength = 20;
                            rtn = !ValidarIdUniversalDuplicado(idUniversal, true);
                            if (!rtn)
                            {
                                string serror = _errorProvider.GetError(_tbIdComp);
                                serror += "Ya Existe Id. Universal";
                                _errorProvider.SetError(_tbIdComp, serror);
                                rtn = false;
                            }
                        }
                        else if ((tamano == 10) && (tipocomp == "AL" || tipocomp == "CP" || tipocomp == "IG" || tipocomp == "IT" || tipocomp == "RE" || tipocomp == "UG"))
                        {
                            rtn = !ValidarIdUniversalDuplicado(idUniversal, false);
                            if (!rtn)
                            {
                                string serror = _errorProvider.GetError(_tbIdComp);
                                serror += "Ya Existe Id. Universal";
                                _errorProvider.SetError(_tbIdComp, serror);
                                rtn = false;
                            }
                            //AL0202BOMD
                            nodoOrigen = "NO" + idUniversal.Substring(4, 6);
                            bool ExisteIdNodo = ValidarIdUniversalDuplicado(nodoOrigen, true);
                            if (!ExisteIdNodo)
                            {
                                string serror = _errorProvider.GetError(_tbIdComp);
                                serror += "No existe nodo de conexión.";
                                _errorProvider.SetError(_tbIdComp, serror);
                                rtn = false;
                            }
                            else
                            {
                                bool nodoValido = NodoValidoEnFecha(nodoOrigen, this._dtpFechaIni.Value.Date, _cbFechaBaja.Checked, _dtpFechaBaja.Value);
                                if (!nodoValido)
                                {
                                    string serror = _errorProvider.GetError(_tbIdComp);
                                    serror += "No existe nodo de conexión no vigente";
                                    _errorProvider.SetError(_tbIdComp, serror);
                                    rtn = false;
                                }
                                else
                                {
                                    _lblNodoOrigen.Text = nodoOrigen;
                                }
                            }
                        }
                        else if ((tamano == 16) && (tipocomp == "LT" || tipocomp == "AT" || tipocomp == "CS" || tipocomp == "LT" || tipocomp == "TR"))
                        {
                            rtn = !ValidarIdUniversalDuplicado(idUniversal, false);
                            if (!rtn)
                            {
                                string serror = _errorProvider.GetError(_tbIdComp);
                                serror += "Ya Existe Id. Universal";
                                _errorProvider.SetError(_tbIdComp, serror);
                                rtn = false;
                            }

                            //LT0101BOMB01HUNB
                            nodoOrigen = "NO" + idUniversal.Substring(4, 6);
                            nodoDestino = "NO" + idUniversal.Substring(10, 6);
                            bool ExisteIdNodo = ValidarIdUniversalDuplicado(nodoOrigen, true);
                            if (!ExisteIdNodo)
                            {
                                string serror = _errorProvider.GetError(_tbIdComp);
                                serror += "No existe nodo de conexión origen";
                                _errorProvider.SetError(_tbIdComp, serror);
                                rtn = false;
                            }
                            else
                            {
                                bool nodoValido = NodoValidoEnFecha(nodoOrigen, this._dtpFechaIni.Value.Date, _cbFechaBaja.Checked, _dtpFechaBaja.Value);
                                if (!nodoValido)
                                {
                                    string serror = _errorProvider.GetError(_tbIdComp);
                                    serror += "No existe nodo origen no vigente";
                                    _errorProvider.SetError(_tbIdComp, serror);
                                    rtn = false;
                                }
                                else
                                {
                                    _lblNodoOrigen.Text = nodoOrigen;
                                }
                            }

                            ExisteIdNodo = ValidarIdUniversalDuplicado(nodoDestino, true);
                            if (!ExisteIdNodo)
                            {
                                string serror = _errorProvider.GetError(_tbIdComp);
                                serror += "No existe nodo de conexión destino";
                                _errorProvider.SetError(_tbIdComp, serror);
                                rtn = false;
                            }
                            else
                            {
                                bool nodoValido = NodoValidoEnFecha(nodoDestino, this._dtpFechaIni.Value.Date, _cbFechaBaja.Checked, _dtpFechaBaja.Value);
                                if (!nodoValido)
                                {
                                    string serror = _errorProvider.GetError(_tbIdComp);
                                    serror += "No existe nodo destino no vigente";
                                    _errorProvider.SetError(_tbIdComp, serror);
                                    rtn = false;
                                }
                                else
                                {
                                    _lblNodoDestino.Text = nodoDestino;
                                }
                            }
                        }
                        else
                        {
                            string serror = _errorProvider.GetError(_tbIdComp);
                            serror += "Tamaño de Id Univesal no corresponde al tipo de componente";
                            _errorProvider.SetError(_tbIdComp, serror);
                            rtn = false;
                        }
                        // el tipo de componente se pudo definir ;
                    }
                    else
                    {
                        rtn = false;
                    }
                }
            }
            return rtn;
        }

        void _tbIdComp_LostFocus(object sender, EventArgs e)
        {
            try
            {
                _errorProvider.Clear();
                Val();
            }
            catch (Exception ex)
            {
            }
        }

        private bool ValidarIdUniversalDuplicado(string idUniversal, bool esNodo)
        {
            bool rtn = true;
            if (esNodo)
            { rtn = OraDalComponentes.NodoMgr.Instancia.IdUniversalExiste(idUniversal); }
            else
            {
                rtn = OraDalComponentes.ComponenteMgr.Instancia.IdUniversalExiste(idUniversal);
            }
            return rtn;
        }

        private long ValidarNodo(string idUNodo, Label lbl)
        {
            long rtn = -1;
            rtn = OraDalComponentes.NodoMgr.Instancia.GetPkCodNodo(idUNodo);
            if (rtn > 0)
            {
                FormatNodoDespliegue(lbl, rtn, idUNodo);
            }
            else
            {
                _errorProvider.SetError(_tbIdComp, "No se identifico Nodo de Conexión. Nodo no existe o está dado de baja ");
                rtn = -1;
            }
            return rtn;
        }

        private bool EsNodo;
        private bool validarCampoNoVacio(TextBox sender)
        {
            bool rtn = true;
            if (sender.Text.Trim().Length == 0)
            {
                _errorProvider.SetError(sender, "El campo no puede estar vacio");
                rtn = false;
            }
            return rtn;
        }

        private void _cbFechaBaja_CheckedChanged(object sender, EventArgs e)
        {
            _dtpFechaBaja.Enabled = _cbFechaBaja.Checked;
            tbFechaBlanca.Visible = !_cbFechaBaja.Checked;
            _dtpFechaBaja.Visible = _cbFechaBaja.Checked;
        }

        private bool ValidarFechas(object sender)
        {
            bool rtn = true;
            if (_cbFechaBaja.Checked)
            {
                DateTimePicker dtp = (DateTimePicker)sender;
                DateTime fechaAlta = _dtpFechaIni.Value.Date;
                DateTime fechaBaja = _dtpFechaBaja.Value.Date;

                if (fechaAlta >= fechaBaja)
                {
                    _errorProvider.SetError(dtp, "Fecha Baja debe ser posterior a fecha Inicio");
                    rtn = false;
                }
            }
            return rtn;
        }

        private void _dtpFechaBaja_ValueChanged(object sender, EventArgs e)
        {
            ValidarFechas(sender);
        }

        private void _dtpFechaIni_ValueChanged(object sender, EventArgs e)
        {
            DateTimePicker dtp = (DateTimePicker)sender;
            ValidarFechas(sender);
        }

        private void _tSBNuevo_Click(object sender, EventArgs e)
        {
            Cursor actual = this.Cursor;
            this.Cursor = Cursors.WaitCursor;
            bool rtn = false;
            _errorProvider.Clear();

            bool val = Val();
            bool c1 = validarCampoNoVacio(_tbCodComp);
            bool c2 = validarCampoNoVacio(_tbDescrip);

            if (val && c1 && c2)
            {
                CargarComponenteDeForm();
                bool nodoRelaciones = false;
                if (_componente.DTipoComponente == 0)
                {
                    if (!_componente.EsNuevo)
                    {
                        nodoRelaciones = OraDalComponentes.NodoMgr.Instancia.NodoConRelacion(
                            _componente.CodigoComponente, _componente.FechaIngreso, _componente.FechaSalida);
                    }
                    if ((nodoRelaciones) && (_componente.TieneFechaSalida != false ))
                    {
                        string serror = _errorProvider.GetError(_tbIdComp);
                        serror += "El nodo tiene relación vigente con componentes a esa fecha";
                        _errorProvider.SetError(_tbIdComp, serror);
                        rtn = false;
                    }
                    else
                    {
                        if (OraDalComponentes.NodoMgr.Instancia.Guardar(_componente) > 0)
                        {
                            rtn = true;
                        }
                    }
                }
                else
                {
                    bool esNuevo = _componente.EsNuevo;
                    if (OraDalComponentes.ComponenteMgr.Instancia.Guardar(_componente) > 0)
                    { rtn = true; }
                    if (esNuevo && _componente.PkCodNodoOrigen > -1)
                    {
                        rtn = rtn && OraDalComponentes.ComponenteMgr.Instancia.InsertarNodo(_componente, _componente.PkCodNodoOrigen, 3602);
                    }
                    else
                    {
                        if (!esNuevo)
                        {
                            rtn = rtn && OraDalComponentes.ComponenteMgr.Instancia.ActualizarNodo(_componente, _componente.PkCodNodoOrigen, 3602);
                        }
                    }
                    if (esNuevo && _componente.PkCodNodoDestino > -1)
                    {
                        rtn = rtn && OraDalComponentes.ComponenteMgr.Instancia.InsertarNodo(_componente, _componente.PkCodNodoDestino, 3603);
                    }
                }
            }
            this.Cursor = actual;
            if (rtn)
            {
                Nuevo = false;
                MessageBox.Show("Operación realizada correctamente");
                this.Close();
            }
        }

        private void tsEditar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
