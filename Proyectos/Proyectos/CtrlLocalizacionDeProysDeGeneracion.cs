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
using CNDC.ExceptionHandlerLib;
using CNDC.BLL;
using CNDC.UtilesComunes;

namespace Proyectos
{
    public partial class CtrlLocalizacionDeProysDeGeneracion : CtrlDatosBase, IControlesLocalizacion
    {
        public event EventHandler<GuardarSelecEventArgs> TipoProyectoSeleccionado;
        LocalizacionProyectosGeneracion _localProysGeneracion;
        bool _esEditable = false;
        Proyecto _proyecto;
        ProyectoMaestro _proyectoMaestro;
        public CtrlLocalizacionDeProysDeGeneracion()
        {
            InitializeComponent();
            if (Sesion.Instancia.SesionIniciada)
            {
                CargarCmbDepartamentos();
            }
        }

        private void CargarCmbDepartamentos()
        {
            _cmbDepartamento.DisplayMember = "Descripcion";
            _cmbDepartamento.ValueMember = "CodDominio";
            DefDominioMgr mgr = new DefDominioMgr();
            _cmbDepartamento.DataSource = mgr.GetListaDominio(DominiosProyectos.D_COD_DEPARTAMENTOS);
        }

        public void DeshabilitarControles()
        {
            OnEstadoDeEdicionModificado(false);
            _txtAltitud.Enabled = false;
            _txtLocalidad.ReadOnly = true;
            _txtProvincia.ReadOnly = true;
            _cmbDepartamento.Enabled = false;
            _gbxUnidadMedida.Enabled = false;
        }

        public void HabilitarControles()
        {
            OnEstadoDeEdicionModificado(true);
            _txtAltitud.Enabled = true;
            _txtLocalidad.ReadOnly = false;
            _txtProvincia.ReadOnly = false;
            _cmbDepartamento.Enabled = true;
            _gbxUnidadMedida.Enabled = true;
        }

        public void SetParametros(bool esEditable, Proyecto proyecto)
        {
            _esEditable = esEditable;
            LimpiarControles();
            ActivarDesActivarControles();

            _proyecto = proyecto;
            _proyectoMaestro = OraDalProyectoMaestroMgr.Instancia.GetPorId<ProyectoMaestro>(proyecto.FkProyectoMaestro, ProyectoMaestro.C_PK_PROYECTO_MAESTRO);
            _rbtGrados.Checked = true;
            if (_proyecto.EsNuevo)
            {
                _localProysGeneracion = new LocalizacionProyectosGeneracion();
                _localProysGeneracion.EsNuevo = true;
            }
            else
            {
                _localProysGeneracion = OraDalLocalizacionProyectosGeneracionMgr.Instancia.GetPorPkProyecto(_proyecto.PkProyecto);
                if (_localProysGeneracion == null)
                {
                    _localProysGeneracion = new LocalizacionProyectosGeneracion();
                    _localProysGeneracion.EsNuevo = true;
                }
                else
                {
                    _localProysGeneracion.EsNuevo = false;
                    CargarDatos();
                }
            }
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

        private void CargarDatos()
        {
            _txtAltitud.Text = _localProysGeneracion.Altitud.ToString("N0");
            _txtLocalidad.Text = _localProysGeneracion.Localidad;
            _txtProvincia.Text = _localProysGeneracion.Provincia;
            _cmbDepartamento.SelectedValue = _localProysGeneracion.DCodDepartamento;
            if (_localProysGeneracion.UnidadMedida == "0")
            {
                _rbtGrados.Checked = true;
                _rbtUTM.Checked = false;
                _txtLatitudGrados.Text = _localProysGeneracion.Latitud;
                _txtLongitudGrados.Text = _localProysGeneracion.Longitud;
                _txtLatitudGrados.Visible = true;
                _txtLatitudUTM.Visible = false;
                _txtLongitudGrados.Visible = true;
                _txtLongitudUTM.Visible = false;
                FormatearGrados(_txtLatitudGrados);
                FormatearGrados(_txtLongitudGrados);
            }
            else
            {
                _rbtGrados.Checked = false;
                _rbtUTM.Checked = true;
                _txtLatitudUTM.Text = _localProysGeneracion.LatitudUtm.ToString("N2");
                _txtLongitudUTM.Text = _localProysGeneracion.LongitudUtm.ToString("N2");
                _txtLatitudGrados.Visible = false;
                _txtLatitudUTM.Visible = true;
                _txtLongitudGrados.Visible = false;
                _txtLongitudUTM.Visible = true;
            }
            FormatearGrados(_txtLatitudGrados);
            FormatearGrados(_txtLongitudGrados);
        }

        public void GuardarDatos(Proyecto proyecto)
        {
            _proyecto = proyecto;
           
            if (DatosValidos())
            {
                _localProysGeneracion.Altitud = _txtAltitud.ValorInt;
                _localProysGeneracion.DCodDepartamento = (long) _cmbDepartamento.SelectedValue;
                _localProysGeneracion.FkProyecto = _proyecto.PkProyecto;
                _localProysGeneracion.Provincia = _txtProvincia.Text;
                _localProysGeneracion.Localidad = _txtLocalidad.Text;
                _localProysGeneracion.UnidadMedida = _rbtGrados.Checked ? "0":"1";
                _localProysGeneracion.Latitud = _rbtGrados.Checked ? _txtLatitudGrados.Text: "";
                _localProysGeneracion.Longitud = _rbtGrados.Checked? _txtLongitudGrados.Text: "";
                _localProysGeneracion.LatitudUtm = _rbtUTM.Checked ? _txtLatitudUTM.ValDouble : 0;
                _localProysGeneracion.LongitudUtm = _rbtUTM.Checked ? _txtLongitudUTM.ValDouble : 0;
                OraDalLocalizacionProyectosGeneracionMgr.Instancia.Guardar(_localProysGeneracion);
                DeshabilitarControles();
            }
        }

        public bool DatosValidos()
        {
            _errorProvider.Clear();
            FormatearGrados(_txtLatitudGrados);
            FormatearGrados(_txtLongitudGrados);
            bool res = true;

          
                if (_txtAltitud.ValorInt < 0)
                {
                    res = false;
                    _errorProvider.SetError(_txtAltitud, MessageMgr.Instance.GetMessage("INGRESE_NUM_POSITIVO"));
                }
           

            if (!_rbtGrados.Checked && !_rbtUTM.Checked)
            {
                res = false;
                _errorProvider.SetError(_gbxUnidadMedida, "Debe registrar los datos de longitud y latitud.");
            }
            
            if (_rbtGrados.Checked)
            {
                if (!AyudanteGrados.MinutosSegundosValidos(_txtLongitudGrados.Text))
                {
                    res = false;
                    _errorProvider.SetError(_txtLongitudGrados, "Los datos correspondientes a minutos y segundos deben ser menores a 60.");
                }

                if (!AyudanteGrados.MinutosSegundosValidos(_txtLatitudGrados.Text))
                {
                    res = false;
                    _errorProvider.SetError(_txtLatitudGrados, "Los datos correspondientes a minutos y segundos deben ser menores a 60.");
                }
            }
            else
            {
                if (_txtLatitudUTM.ValDouble < 0)
                {
                    res = false;
                    _errorProvider.SetError(_txtLatitudUTM, MessageMgr.Instance.GetMessage("INGRESE_NUM_POSITIVO"));
                }

                if (_txtLongitudUTM.ValDouble < 0)
                {
                    res = false;
                    _errorProvider.SetError(_txtLongitudUTM, MessageMgr.Instance.GetMessage("INGRESE_NUM_POSITIVO"));
                }
            }

            return res;
        }

        public void LimpiarControles()
        {
            _errorProvider.Clear();
            _txtAltitud.Value = 0;
            _txtLatitudGrados.Text = string.Empty;
            _txtLocalidad.Text = string.Empty;
            _txtLongitudGrados.Text = string.Empty;
            _txtProvincia.Text = string.Empty;
            _txtLongitudUTM.Visible = false;
            _txtLongitudGrados.Visible = false;
            _txtLatitudGrados.Visible = false;
            _txtLatitudUTM.Visible = false;
        }

        private void _rbtGrados_CheckedChanged(object sender, EventArgs e)
        {
            if (_rbtGrados.Checked)
            {
                _rbtUTM.Checked = false;
                _lblLatitudGrados.Visible = true;
                _lblLongitudGrados.Visible = true;
                _lblLatitudUTM.Visible = false;
                _lblLongitudUTM.Visible = false;
                _lblLongitudGrados.TextAlign = ContentAlignment.BottomRight;
                _lblLatitudGrados.TextAlign = ContentAlignment.BottomRight;
                _txtLongitudGrados.Visible = true;
                _txtLatitudGrados.Visible = true;
                _txtLongitudUTM.Visible = false;
                _txtLatitudUTM.Visible = false;
            }
        }

        private void _rbtUTM_CheckedChanged(object sender, EventArgs e)
        {
            if (_rbtUTM.Checked)
            {
                _lblLatitudGrados.Visible = false;
                _lblLongitudGrados.Visible = false;
                _lblLatitudUTM.Visible = true;
                _lblLongitudUTM.Visible = true;
                _lblLongitudGrados.TextAlign = ContentAlignment.BottomRight;
                _lblLatitudGrados.TextAlign = ContentAlignment.BottomRight;
                _rbtGrados.Checked = false;
                _txtLongitudGrados.Visible = false;
                _txtLatitudGrados.Visible = false;
                _txtLongitudUTM.Visible = true;
                _txtLatitudUTM.Visible = true;
            }
        }

        private void _txtLongitudGrados_Validating(object sender, CancelEventArgs e)
        {
            FormatearGrados(sender as MaskedTextBox);
        }

        private void FormatearGrados(MaskedTextBox txt)
        {
            txt.Text = AyudanteGrados.AsegurarFormato(txt.Text);
        }
    }

    public class GuardarSelecEventArgs : EventArgs
    {
        private TipoDeProyecto _tipoProyecto;

        public GuardarSelecEventArgs(TipoDeProyecto t)
        {
            _tipoProyecto = t;
        }

        public TipoDeProyecto TipoProyectoSeleccionado
        {
            get { return _tipoProyecto; }
        }
    }
}
