using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ModeloProyectos;
using CNDC.BLL;
using OraDalProyectos;
using CNDC.UtilesComunes;
using CNDC.ExceptionHandlerLib;

namespace Proyectos
{
    public partial class CtrlLocalizacionDeProysDeTransmision : CtrlDatosBase, IControlesLocalizacion
    {
        DataTable _tablaLocalizacion = new DataTable();
        DataTable _tablaDepartamentos;
        bool _esNuevo = false;
        bool _esEditable = false;
        Proyecto _proyecto;
        ProyectoMaestro _proyectoMaestro;
        LocalizacionProyectosTransmision _localProysTransmisionA = new LocalizacionProyectosTransmision();
        LocalizacionProyectosTransmision _localProysTransmisionB = new LocalizacionProyectosTransmision();
        Controles.CNDCComboBox _cmbDepartamentoO = new Controles.CNDCComboBox();
        Controles.CNDCComboBox _cmbDepartamentoD = new Controles.CNDCComboBox();

        public CtrlLocalizacionDeProysDeTransmision()
        {
            InitializeComponent();
            if (Sesion.Instancia.SesionIniciada)
            {
                CargarCmbDepartamentos();
            }
        }

        private void CargarCmbDepartamentos()
        {
            _cmbDepartamentoA.DisplayMember = "Descripcion";
            _cmbDepartamentoA.ValueMember = "CodDominio";
            DefDominioMgr mgr = new DefDominioMgr();
            _cmbDepartamentoA.DataSource = mgr.GetListaDominio(DominiosProyectos.D_COD_DEPARTAMENTOS);

            _cmbDepartamentoB.DisplayMember = "Descripcion";
            _cmbDepartamentoB.ValueMember = "CodDominio";
            _cmbDepartamentoB.DataSource = mgr.GetListaDominio(DominiosProyectos.D_COD_DEPARTAMENTOS);

        }

        #region Miembros de IControlesLocalizacion

        public void GuardarDatos(Proyecto proyecto)
        {
           if (DatosValidos())
            {
                switch (_proyectoMaestro.DTipoProyecto)
                {
                    case (int)D_COD_TIPO_PROYECTO.LINEA_DE_TRANSMISIÓN:
                        _localProysTransmisionA.Altitud = _txtAltitudA.ValorInt;
                        _localProysTransmisionA.DCodDepartamento = (long)_cmbDepartamentoA.SelectedValue;
                        _localProysTransmisionA.FkProyecto = _proyecto.PkProyecto;
                        _localProysTransmisionA.Localidad = _txtLocalidadA.Text;
                        _localProysTransmisionA.Subestacion = _txtSubestacionA.Text;
                        _localProysTransmisionA.OrigenDestino = "0";
                        _localProysTransmisionA.UnidadMedida = _rbtGrados.Checked ? "0" : "1";
                        _localProysTransmisionA.Longitud = _rbtGrados.Checked ? _txtLongitudGradosA.Text :"";
                        _localProysTransmisionA.Latitud = _rbtGrados.Checked ? _txtLatitudGradosA.Text : "";
                        _localProysTransmisionA.LongitudUtm = _rbtUTM.Checked ? _txtLongitudA.ValDouble :0;
                        _localProysTransmisionA.LatitudUtm = _rbtUTM.Checked ? _txtLatitudA.ValDouble : 0;
                        OraDalLocalizacionProyectosTransmisionMgr.Instancia.Guardar(_localProysTransmisionA);

                        _localProysTransmisionB.Altitud = _txtAltitudB.ValorInt;
                        _localProysTransmisionB.DCodDepartamento = (long)_cmbDepartamentoB.SelectedValue;
                        _localProysTransmisionB.FkProyecto = _proyecto.PkProyecto;
                        _localProysTransmisionB.Localidad = _txtLocalidadB.Text;
                        _localProysTransmisionB.Subestacion = _txtSubestacionB.Text;
                        _localProysTransmisionB.OrigenDestino = "1";
                        _localProysTransmisionB.UnidadMedida = _rbtGrados.Checked ? "0" : "1";
                        _localProysTransmisionB.Longitud = _rbtGrados.Checked ? _txtLongitudGradosB.Text : "";
                        _localProysTransmisionB.Latitud = _rbtGrados.Checked ? _txtLatitudGradosB.Text :"";
                        _localProysTransmisionB.LongitudUtm = _rbtUTM.Checked ? _txtLongitudB.ValDouble : 0;
                        _localProysTransmisionB.LatitudUtm = _rbtUTM.Checked ? _txtLatitudB.ValDouble : 0;
                        OraDalLocalizacionProyectosTransmisionMgr.Instancia.Guardar(_localProysTransmisionB);
                        break;

                    case (int)D_COD_TIPO_PROYECTO.TRANSFORMADOR:
                    case (int)D_COD_TIPO_PROYECTO.CAPACITOR:
                    case (int)D_COD_TIPO_PROYECTO.REACTOR:
                        _localProysTransmisionA.Altitud = _txtAltitudA.ValorInt;
                        _localProysTransmisionA.DCodDepartamento = (long)_cmbDepartamentoA.SelectedValue;
                        _localProysTransmisionA.FkProyecto = _proyecto.PkProyecto;
                        _localProysTransmisionA.Localidad = _txtLocalidadA.Text;
                        _localProysTransmisionA.Subestacion = _txtSubestacionA.Text;
                        _localProysTransmisionA.OrigenDestino = "0";
                        _localProysTransmisionA.UnidadMedida = _rbtGrados.Checked ? "0" : "1";
                        _localProysTransmisionA.Longitud = _rbtGrados.Checked ? _txtLongitudGradosA.Text :"";
                        _localProysTransmisionA.Latitud = _rbtGrados.Checked ? _txtLatitudGradosA.Text : "";
                        _localProysTransmisionA.LongitudUtm = _rbtUTM.Checked ? _txtLongitudA.ValDouble :0;
                        _localProysTransmisionA.LatitudUtm = _rbtUTM.Checked ? _txtLatitudA.ValDouble : 0;
                        OraDalLocalizacionProyectosTransmisionMgr.Instancia.Guardar(_localProysTransmisionA);
                        break;

                    default:
                        break;
                }

            }
        }

        public bool DatosValidos()
        {
            FormatearGrados(_txtLatitudGradosA);
            FormatearGrados(_txtLatitudGradosB);
            FormatearGrados(_txtLongitudGradosA);
            FormatearGrados(_txtLongitudGradosB);
            bool res = true;
            _errorProvider.Clear();
            switch (_proyectoMaestro.DTipoProyecto)
            {
                case (int)D_COD_TIPO_PROYECTO.LINEA_DE_TRANSMISIÓN:
                    if (_rbtGrados.Checked)
                    {
                        if (!AyudanteGrados.MinutosSegundosValidos(_txtLongitudGradosA.Text))
                        {
                            res = false;
                            _errorProvider.SetError(_txtLongitudGradosA, "Los datos correspondientes a minutos y segundos deben ser menores a 60.");
                        }

                        if (!AyudanteGrados.MinutosSegundosValidos(_txtLatitudGradosA.Text))
                        {
                            res = false;
                            _errorProvider.SetError(_txtLatitudGradosA, "Los datos correspondientes a minutos y segundos deben ser menores a 60.");
                        }

                        if (!AyudanteGrados.MinutosSegundosValidos(_txtLongitudGradosB.Text))
                        {
                            res = false;
                            _errorProvider.SetError(_txtLongitudGradosB, "Los datos correspondientes a minutos y segundos deben ser menores a 60.");
                        }

                        if (!AyudanteGrados.MinutosSegundosValidos(_txtLatitudGradosB.Text))
                        {
                            res = false;
                            _errorProvider.SetError(_txtLatitudGradosB, "Los datos correspondientes a minutos y segundos deben ser menores a 60.");
                        }
                    }

                    if (!ValidarDatosLocalizacionA())
                    {
                        res = false;
                        _errorProvider.SetError(_txtAltitudA,"Debe ingresar todos los datos.");
                    }
                    if (!ValidarDatosLocalizacionB())
                    {
                        res = false;
                        _errorProvider.SetError(_txtAltitudB, "Debe ingresar todos los datos.");
                    }
                    break;

                case (int)D_COD_TIPO_PROYECTO.TRANSFORMADOR:
                case (int)D_COD_TIPO_PROYECTO.CAPACITOR:
                case (int)D_COD_TIPO_PROYECTO.REACTOR:
                    if (!ValidarDatosLocalizacionA())
                    {
                        res = false;
                        _errorProvider.SetError(_txtAltitudA, "Debe ingresar todos los datos.");
                    }

                    if (_rbtGrados.Checked)
                    {
                        if (!AyudanteGrados.MinutosSegundosValidos(_txtLongitudGradosA.Text))
                        {
                            res = false;
                            _errorProvider.SetError(_txtLongitudGradosA, "Los datos correspondientes a minutos y segundos deben ser menores a 60.");
                        }
                        if (!AyudanteGrados.MinutosSegundosValidos(_txtLatitudGradosA.Text))
                        {
                            res = false;
                            _errorProvider.SetError(_txtLatitudGradosA, "Los datos correspondientes a minutos y segundos deben ser menores a 60.");
                        }
                    }
                    break;

                default:
                    break;
            }

            return res;
        }

        private bool ValidarDatosLocalizacionB()
        {
            bool res = true;
            //if (_txtLocalidadB.Text == string.Empty)
            //{
            //    res = false;
            //}

            //if (_txtSubestacionB.Text == string.Empty)
            //{
            //    res = false;
            //}

            if (_txtAltitudB.ValorInt < 0)
            {
                res = false;
            }

            if (!_rbtGrados.Checked && !_rbtUTM.Checked)
            {
                res = false;
            }

            if (_rbtGrados.Checked)
            {
               /* if (_txtLatitudGradosB.Text == string.Empty)
                {
                    res = false;
                }

                if (_txtLongitudGradosB.Text == string.Empty)
                {
                    res = false;
                }*/
            }
            else
            {
                if (_txtLatitudB.ValDouble < 0)
                {
                    res = false;
                }

                if (_txtLongitudB.ValDouble < 0)
                {
                    res = false;
                }
            }
            return res;
        }

        private bool ValidarDatosLocalizacionA()
        {
            bool res = true;
            //if (_txtLocalidadA.Text == string.Empty)
            //{
            //    res = false;
            //}

            //if (_txtSubestacionA.Text == string.Empty)
            //{
            //    res = false;
            //}

            if (_txtAltitudA.ValorInt < 0)
            {
                res = false;
            }

            if (!_rbtGrados.Checked && !_rbtUTM.Checked)
            {
                res = false;
            }

            if (_rbtGrados.Checked)
            {
              /*  if (_txtLatitudGradosA.Text == string.Empty)
                {
                    res = false;
                }

                if (_txtLongitudGradosA.Text == string.Empty)
                {
                    res = false;
                }*/
            }
            else
            {
                if (_txtLatitudA.ValDouble < 0)
                {
                    res = false;
                }

                if (_txtLongitudA.ValDouble < 0)
                {
                    res = false;
                }
            }
            return res;
        }

        public void SetParametros(bool esEditable, Proyecto proyecto)
        {
            _esEditable = esEditable;
            _proyecto = proyecto;
            _proyectoMaestro = OraDalProyectoMaestroMgr.Instancia.GetPorId<ProyectoMaestro>(proyecto.FkProyectoMaestro, ProyectoMaestro.C_PK_PROYECTO_MAESTRO);
            _rbtGrados.Checked = false;
            _rbtUTM.Checked = false;
            switch (_proyectoMaestro.DTipoProyecto)
            {
                case (int)D_COD_TIPO_PROYECTO.LINEA_DE_TRANSMISIÓN:
                    _txtSubestacionB.Visible = true;
                    _txtLocalidadB.Visible = true;
                    _cmbDepartamentoB.Visible = true;
                    _txtLatitudB.Visible = true;
                    _txtLatitudGradosB.Visible = true;
                    _txtLongitudB.Visible = true;
                    _txtLongitudGradosB.Visible = true;
                    _txtAltitudB.Visible = true;
                    break;

                case (int)D_COD_TIPO_PROYECTO.TRANSFORMADOR:
                case (int)D_COD_TIPO_PROYECTO.CAPACITOR:
                case (int)D_COD_TIPO_PROYECTO.REACTOR:
                    _txtSubestacionB.Visible = false;
                    _txtLocalidadB.Visible = false;
                    _cmbDepartamentoB.Visible = false;
                    _txtLatitudB.Visible = false;
                    _txtLatitudGradosB.Visible = false;
                    _txtLongitudGradosB.Visible = false;
                    _txtLongitudB.Visible = false;
                    _txtAltitudB.Visible = false;
                    break;

                default:
                    break;
            }
            CargarDatos();
            ActivarDesActivarControles();
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

        public void DeshabilitarControles()
        {
            OnEstadoDeEdicionModificado(false);
            _gbxLatitud.Enabled = false;
            _gbxLocalizacion.Enabled = false;
            _txtSubestacionB.Enabled = false;
            _txtLocalidadB.Enabled = false;
            _cmbDepartamentoB.Enabled = false;
            _txtLatitudB.Enabled = false;
            _txtLongitudB.Enabled = false;
            _txtAltitudB.Enabled = false;
            _txtLatitudGradosB.Enabled = false;
            _txtLongitudGradosB.Enabled = false;

            _txtLongitudGradosA.Enabled = false;
            _txtLatitudGradosA.Enabled = false;
            _txtSubestacionA.Enabled = false;
            _txtLongitudA.Enabled = false;
            _cmbDepartamentoA.Enabled = false;
            _txtLatitudA.Enabled = false;
            _txtLongitudA.Enabled = false;
            _txtAltitudA.Enabled = false;
        }

        public void HabilitarControles()
        {
            OnEstadoDeEdicionModificado(true);
            _gbxLatitud.Enabled = true;
            _gbxLocalizacion.Enabled = true;

            _txtSubestacionB.Enabled = true;
            _txtLocalidadB.Enabled = true;
            _cmbDepartamentoB.Enabled = true;
            _txtLatitudB.Enabled = true;
            _txtLongitudB.Enabled = true;
            _txtAltitudB.Enabled = true;
            _txtLatitudGradosB.Enabled = true;
            _txtLongitudGradosB.Enabled = true;

            _txtLongitudGradosA.Enabled = true;
            _txtLatitudGradosA.Enabled = true;
            _txtSubestacionA.Enabled = true;
            _txtLongitudA.Enabled = true;
            _cmbDepartamentoA.Enabled = true;
            _txtLatitudA.Enabled = true;
            _txtLongitudA.Enabled = true;
            _txtAltitudA.Enabled = true;
        }

        private void CargarDatos()
        {
            int i = 0;
            DefDominioMgr mgr = new DefDominioMgr();
            _rbtUTM.Checked = true;
            _rbtGrados.Checked = false;
            List<LocalizacionProyectosTransmision> listaDatos = OraDalLocalizacionProyectosTransmisionMgr.Instancia.GetListPorPkProyecto(_proyecto.PkProyecto);
            if (listaDatos.Count == 0)
            {
                _localProysTransmisionA = new LocalizacionProyectosTransmision();
                _localProysTransmisionA.EsNuevo = true;

                _localProysTransmisionB = new LocalizacionProyectosTransmision();
                _localProysTransmisionB.EsNuevo = true;
            }
            else
            {

                if (listaDatos.Count == 1)
                {
                    _rbtUTM.Checked = listaDatos[0].UnidadMedida=="1"? true:false;
                    _rbtGrados.Checked = listaDatos[0].UnidadMedida == "0" ? true : false;
                    CargarDatosLocalizacionA(listaDatos);
                }
                else if (listaDatos.Count == 2)
                {
                    _rbtUTM.Checked = listaDatos[0].UnidadMedida == "1" ? true : false;
                    _rbtGrados.Checked = listaDatos[0].UnidadMedida == "0" ? true : false;
                    CargarDatosLocalizacionA(listaDatos);
                    CargarDatosLocalizacionB(listaDatos);
                }

            }

        }

        private void CargarDatosLocalizacionB(List<LocalizacionProyectosTransmision> listaDatos)
        {
            if (listaDatos[1].UnidadMedida == "0")
            {
                _txtLongitudGradosB.Text = listaDatos[1].Longitud.ToString();
                _txtLatitudGradosB.Text = listaDatos[1].Latitud.ToString();
                _txtLongitudA.Visible = false;
                _txtLatitudA.Visible = false;
                FormatearGrados(_txtLongitudGradosB);
                FormatearGrados(_txtLatitudGradosB);
            }
            else
            {
                _txtLongitudB.Text = listaDatos[1].LongitudUtm.ToString("N2");
                _txtLatitudB.Text = listaDatos[1].LatitudUtm.ToString("N2");
                _txtLongitudGradosA.Visible = false;
                _txtLatitudGradosB.Visible = false;
            }

            _localProysTransmisionA = listaDatos[0];
            _localProysTransmisionB = listaDatos[1];
            _localProysTransmisionA.EsNuevo = false;
            _localProysTransmisionB.EsNuevo = false;
            _txtSubestacionB.Text = listaDatos[1].Subestacion;
            _cmbDepartamentoB.SelectedValue = listaDatos[1].DCodDepartamento;
            _txtAltitudB.Text = listaDatos[1].Altitud.ToString("N0");
            _txtLocalidadB.Text = listaDatos[1].Subestacion;
        }

        private void CargarDatosLocalizacionA(List<LocalizacionProyectosTransmision> listaDatos)
        {
            if (listaDatos[0].UnidadMedida == "0")
            {
                _txtLongitudGradosA.Text = listaDatos[0].Longitud.ToString();
                _txtLatitudGradosA.Text = listaDatos[0].Latitud.ToString();
                _txtLongitudA.Visible = false;
                _txtLatitudA.Visible = false;
                FormatearGrados(_txtLatitudGradosA);
                FormatearGrados(_txtLongitudGradosA);                
            }
            else
            {
                _txtLongitudA.Text = listaDatos[0].LongitudUtm.ToString("N2");
                _txtLatitudA.Text = listaDatos[0].LatitudUtm.ToString("N2");
                _txtLongitudGradosA.Visible = false;
                _txtLatitudGradosB.Visible = false;
            }
            _localProysTransmisionA = listaDatos[0];
            _localProysTransmisionA.EsNuevo = false;
            _cmbDepartamentoA.SelectedValue = listaDatos[0].DCodDepartamento;
            _txtAltitudA.Text = listaDatos[0].Altitud.ToString("N0");
            _txtSubestacionA.Text = listaDatos[0].Subestacion;
            _txtLocalidadA.Text = listaDatos[0].Subestacion;
        }

        private void LimpiarControles()
        {
            _rbtUTM.Checked = true;
            _txtSubestacionB.Text = string.Empty;
            _txtLocalidadB.Text = string.Empty;
            _txtLatitudB.Value = 0;
            _txtLongitudB.Value = 0;
            _txtAltitudB.Value = 0;
            _txtLatitudGradosB.Text = string.Empty;
            _txtLongitudGradosB.Text = string.Empty;

            _txtSubestacionA.Text = string.Empty;
            _txtLocalidadA.Text = string.Empty;
            _txtLatitudA.Value = 0;
            _txtLongitudA.Value = 0;
            _txtAltitudA.Value = 0;
            _txtLatitudGradosA.Text = string.Empty;
            _txtLongitudGradosA.Text = string.Empty;
        }

        #endregion

        private void _dgvLocalizacion_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
        }

        private void _rbtGrados_CheckedChanged(object sender, EventArgs e)
        {
            if (_rbtGrados.Checked)
            {
                _rbtUTM.Checked = false;

                _lblLatitudGrados.Visible = true;
                _lblLongitudGrados.Visible = true;
                _lblUTMLatitud.Visible = false;
                _lblUTMLongitud.Visible = false;
                switch (_proyectoMaestro.DTipoProyecto)
                {
                    case (int)D_COD_TIPO_PROYECTO.LINEA_DE_TRANSMISIÓN:

                        _txtLatitudA.Visible = false;
                        _txtLongitudA.Visible = false;
                        _txtLongitudGradosA.Visible = true;
                        _txtLatitudGradosA.Visible = true;

                        _txtLatitudB.Visible = false;
                        _txtLongitudB.Visible = false;
                        _txtLongitudGradosB.Visible = true;
                        _txtLatitudGradosB.Visible = true;
                        break;

                    case (int)D_COD_TIPO_PROYECTO.TRANSFORMADOR:
                    case (int)D_COD_TIPO_PROYECTO.CAPACITOR:
                    case (int)D_COD_TIPO_PROYECTO.REACTOR:
                        _txtLatitudA.Visible = false;
                        _txtLongitudA.Visible = false;
                        _txtLongitudGradosA.Visible = true;
                        _txtLatitudGradosA.Visible = true;
                        break;

                    default:
                        break;
                }
            }
        }

        private void _rbtUTM_CheckedChanged(object sender, EventArgs e)
        {
            if (_rbtUTM.Checked)
            {
                _rbtGrados.Checked = false;
                _lblLatitudGrados.Visible = false;
                _lblLongitudGrados.Visible = false;
                _lblUTMLatitud.Visible = true;
                _lblUTMLongitud.Visible = true;
                switch (_proyectoMaestro.DTipoProyecto)
                {
                    case (int)D_COD_TIPO_PROYECTO.LINEA_DE_TRANSMISIÓN:

                        _txtLatitudA.Visible = true;
                        _txtLongitudA.Visible = true;
                        _txtLongitudGradosA.Visible = false;
                        _txtLatitudGradosA.Visible = false;

                        _txtLatitudB.Visible = true;
                        _txtLongitudB.Visible = true;
                        _txtLongitudGradosB.Visible = false;
                        _txtLatitudGradosB.Visible = false;
                        break;

                    case (int)D_COD_TIPO_PROYECTO.TRANSFORMADOR:
                    case (int)D_COD_TIPO_PROYECTO.CAPACITOR:
                    case (int)D_COD_TIPO_PROYECTO.REACTOR:
                        _txtLatitudA.Visible = true;
                        _txtLongitudA.Visible = true;
                        _txtLongitudGradosA.Visible = false;
                        _txtLatitudGradosA.Visible = false;
                        break;

                    default:
                        break;
                }
            }
        }

        private void _gbxLocalizacion_Enter(object sender, EventArgs e)
        {

        }

        private void _txtLatitudGradosA_Validating(object sender, CancelEventArgs e)
        {
            FormatearGrados(sender as MaskedTextBox);
        }

        private void FormatearGrados(MaskedTextBox txt)
        {
            txt.Text = AyudanteGrados.AsegurarFormato(txt.Text);
        }

        private void _txtLatitudGradosB_Validating(object sender, CancelEventArgs e)
        {
            FormatearGrados(sender as MaskedTextBox);
        }

        private void _txtLongitudGradosA_Validating(object sender, CancelEventArgs e)
        {
            FormatearGrados(sender as MaskedTextBox);
        }

        private void _txtLongitudGradosB_Validating(object sender, CancelEventArgs e)
        {
            FormatearGrados(sender as MaskedTextBox);
        }
    }
}
