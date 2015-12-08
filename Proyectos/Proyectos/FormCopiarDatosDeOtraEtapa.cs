using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CNDC.BLL;
using ModeloProyectos;
using OraDalProyectos;
using CNDC.BaseForms;

namespace Proyectos
{
    public partial class FormCopiarDatosDeOtraEtapa : BaseForm
    {
        Proyecto _proyectoSeleccionado;
        Proyecto _proyectoNuevo;
        ProyectoMaestro _proyectoMaestro;
        long _pkProyecto = 0;
        public FormCopiarDatosDeOtraEtapa()
        {
            InitializeComponent();
            if (Sesion.Instancia.SesionIniciada)
            {
                _dtpFechaRegistro.Value = DateTime.Now.Date;
            }
        }

        public void CargarEtapasDelProyecto(Proyecto proyecto)
        {
            _proyectoNuevo = proyecto;
            _proyectoMaestro = OraDalProyectoMaestroMgr.Instancia.GetPorId<ProyectoMaestro>(_proyectoNuevo.FkProyectoMaestro, ProyectoMaestro.C_PK_PROYECTO_MAESTRO);
            _cmbEtapa.DisplayMember = "Descripcion";
            _cmbEtapa.ValueMember = "CodDominio";
            DefDominioMgr mgr = new DefDominioMgr();
            _cmbEtapa.DataSource = mgr.GetListaEtapasDeProyectosVigentes(DominiosProyectos.D_COD_ETAPA_PROYECTO, _proyectoMaestro.PkProyectoMaestro);
            ShowDialog();
        }

        private string GetPrefijoDeTipoDominio(int codDomino)
        {
            DefDominioMgr mgr = new DefDominioMgr();
            DefDominio dominio = mgr.GetDominioPorPkDominio(codDomino);
            string prefijo = string.Empty;
            if (dominio != null)
            {
                prefijo = dominio.Aux1_dom;
            }
            return prefijo;
        }

        private void _btnCopiar_Click(object sender, EventArgs e)
        {
            if (!DatosSonValidos())
            {
                return;
            }

            if (_cmbEtapa.SelectedItem == null)
            {
                DialogResult = DialogResult.No;
            }
            else
            {

                string prefijoEtapa = GetPrefijoDeTipoDominio((int)_proyectoNuevo.DCodEtapa);
                string prefijoTipoProy = GetPrefijoDeTipoDominio((int)_proyectoMaestro.DTipoProyecto);
                _proyectoSeleccionado.DCodEtapa = _proyectoNuevo.DCodEtapa;
                _proyectoSeleccionado.FechaDeRegistro = _dtpFechaRegistro.Value.Date;
                _proyectoSeleccionado.EsNuevo = true;
                GeneradorCodigoProyecto.Instancia.AsignarCodigo(_proyectoSeleccionado, prefijoEtapa, prefijoTipoProy);
                OraDalProyectoMgr.Instancia.Guardar(_proyectoSeleccionado);
                _proyectoNuevo = _proyectoSeleccionado;
                if (_proyectoMaestro.DTipoProyectoPadre == (long)D_COD_TIPO_PROYECTO.PROYECTOS_DE_GENERACIÓN)
                {
                    LocalizacionProyectosGeneracion localizacion = OraDalLocalizacionProyectosGeneracionMgr.Instancia.GetPorPkProyecto(_pkProyecto);
                    if (localizacion != null)
                    {
                        localizacion.EsNuevo = true;
                        localizacion.FkProyecto = _proyectoNuevo.PkProyecto;
                        OraDalLocalizacionProyectosGeneracionMgr.Instancia.Guardar(localizacion);
                    }
                }
                else if (_proyectoMaestro.DTipoProyectoPadre == (long)D_COD_TIPO_PROYECTO.PROYECTOS_DE_TRANSMISIÓN)
                {
                    List<LocalizacionProyectosTransmision> listaLocal = OraDalLocalizacionProyectosTransmisionMgr.Instancia.GetListPorPkProyecto(_pkProyecto);
                    foreach (LocalizacionProyectosTransmision local in listaLocal)
                    {
                        local.EsNuevo = true;
                        local.FkProyecto = _proyectoNuevo.PkProyecto;
                        OraDalLocalizacionProyectosTransmisionMgr.Instancia.Guardar(local);
                    }
                }

                switch (_proyectoMaestro.DTipoProyecto)
                {

                    case (long)D_COD_TIPO_PROYECTO.HIDROELÉCTRICO: //hidrologico
                        DatoTecnicoHidroelectrico datoTec = OraDalDatoTecnicoHidroelectricoMgr.Instancia.GetPorPkProyecto(_pkProyecto);
                        if (datoTec != null)
                        {
                            long pkDatoTecnico = datoTec.PkDatoTecHidroelectrico;
                            datoTec.EsNuevo = true;
                            datoTec.FkProyecto = _proyectoNuevo.PkProyecto;
                            OraDalDatoTecnicoHidroelectricoMgr.Instancia.Guardar(datoTec);

                            List<VolumenVsArea> listaVolumenArea = OraDalVolumenVsAreaMgr.Instancia.GetListPorPkDatoTecnico(pkDatoTecnico);
                            foreach (VolumenVsArea item in listaVolumenArea)
                            {
                                item.EsNuevo = true;
                                item.FkDatoTecHidroelectrico = datoTec.PkDatoTecHidroelectrico;
                                OraDalVolumenVsAreaMgr.Instancia.Guardar(item);
                            }

                            List<VolumenVsFactorDeProduccion> listaVolumenProduccion = OraDalVolumenVsFactorDeProduccionMgr.Instancia.GetListPorPkDatoTecnico(pkDatoTecnico);
                            foreach (VolumenVsFactorDeProduccion item in listaVolumenProduccion)
                            {
                                item.EsNuevo = true;
                                item.FkDatoTecHidroelectrico = datoTec.PkDatoTecHidroelectrico;
                                OraDalVolumenVsFactorDeProduccionMgr.Instancia.Guardar(item);
                            }
                        }
                        List<SerieHidrologica> listaSerie = OraDalSerieHidrologicaMgr.Instancia.GetSeriesDePkProyecto(_pkProyecto);
                        foreach (SerieHidrologica item in listaSerie)
                        {
                            item.EsNuevo = true;
                            item.FkProyecto = _proyectoNuevo.PkProyecto;
                            OraDalSerieHidrologicaMgr.Instancia.Guardar(item);
                        }

                        CopiarDatosEconomicos();
                        CopiarDatosTransAsociadaAlProyecto();
                        CopiarDatosReduccionEmisiones();


                        break;

                    case (long)D_COD_TIPO_PROYECTO.TURBINAS://turbina
                    case (long)D_COD_TIPO_PROYECTO.TÉRMICO_CICLO_COMBINADO://ciclo combinado
                        DatoTecnicoTurbina dato = OraDalDatoTecnicoTurbinaMgr.Instancia.GetPorPkProyecto(_pkProyecto);
                        if (dato != null)
                        {
                            dato.EsNuevo = true;
                            dato.FkProyecto = _proyectoNuevo.PkProyecto;
                            OraDalDatoTecnicoTurbinaMgr.Instancia.Guardar(dato);
                        }
                        CopiarDatosEconomicos();
                        CopiarDatosTransAsociadaAlProyecto();
                        CopiarDatosReduccionEmisiones();
                        break;

                    case (long)D_COD_TIPO_PROYECTO.MOTORES:
                    case (long)D_COD_TIPO_PROYECTO.TÉRMICO_A_DIESEL: //motores y diesel
                        DatoTecnicoMotorDiesel datoDiesel = OraDalDatoTecnicoMotorDieselMgr.Instancia.GetPorPkProyecto(_pkProyecto);
                        if (datoDiesel != null)
                        {
                            datoDiesel.EsNuevo = true;
                            datoDiesel.FkProyecto = _proyectoNuevo.PkProyecto;
                            OraDalDatoTecnicoMotorDieselMgr.Instancia.Guardar(datoDiesel);
                        }
                        CopiarDatosEconomicos();
                        CopiarDatosTransAsociadaAlProyecto();
                        CopiarDatosReduccionEmisiones();
                        break;

                    case (long)D_COD_TIPO_PROYECTO.TÉRMICO_A_DUAL_FUEL: //dual fuel
                        DatoTecnicoDualFuel datoDual = OraDalDatoTecnicoDualFuelMgr.Instancia.GetPorPkProyecto(_pkProyecto);
                        if (datoDual != null)
                        {
                            datoDual.EsNuevo = true;
                            datoDual.FkProyecto = _proyectoNuevo.PkProyecto;
                            OraDalDatoTecnicoDualFuelMgr.Instancia.Guardar(datoDual);
                        }
                        CopiarDatosEconomicos();
                        CopiarDatosTransAsociadaAlProyecto();
                        CopiarDatosReduccionEmisiones();
                        break;

                    case (long)D_COD_TIPO_PROYECTO.GEOTÉRMICO://Geotermico
                        DatoTecnicoGeotermico datoGeo = OraDalDatoTecnicoGeotermicoMgr.Instancia.GetPorPkProyecto(_pkProyecto);
                        if (datoGeo != null)
                        {
                            datoGeo.EsNuevo = true;
                            datoGeo.FkProyecto = _proyectoNuevo.PkProyecto;
                            OraDalDatoTecnicoGeotermicoMgr.Instancia.Guardar(datoGeo);
                        }
                        CopiarDatosEconomicos();
                        CopiarDatosTransAsociadaAlProyecto();
                        CopiarDatosReduccionEmisiones();
                        break;

                    case (long)D_COD_TIPO_PROYECTO.BIOMASA://Biomasa
                        DatoTecnicoBiomasa datoBio = OraDalDatoTecnicoBiomasaMgr.Instancia.GetPorPkProyecto(_pkProyecto);
                        if (datoBio != null)
                        {
                            datoBio.EsNuevo = true;
                            datoBio.FkProyecto = _proyectoNuevo.PkProyecto;
                            OraDalDatoTecnicoBiomasaMgr.Instancia.Guardar(datoBio);
                        }
                        CopiarDatosEconomicos();
                        CopiarDatosTransAsociadaAlProyecto();
                        CopiarDatosReduccionEmisiones();
                        break;

                    case (long)D_COD_TIPO_PROYECTO.EÓLICO://Eolico -solar
                    case (long)D_COD_TIPO_PROYECTO.SOLAR:
                        DatoTecnicoEolicoSolar datoEolico = OraDalDatoTecnicoEolicoSolarMgr.Instancia.GetPorPkProyecto(_pkProyecto);
                        if (datoEolico != null)
                        {
                            datoEolico.EsNuevo = true;
                            datoEolico.FkProyecto = _proyectoNuevo.PkProyecto;
                            OraDalDatoTecnicoEolicoSolarMgr.Instancia.Guardar(datoEolico);
                            List<GeneracionProbableEolicoSolar> lista = OraDalGeneracionProbableEolicoSolarMgr.Instancia.GetListPorPkProyecto(_pkProyecto);
                            foreach (GeneracionProbableEolicoSolar item in lista)
                            {
                                item.EsNuevo = true;
                                item.FkProyecto = _proyectoNuevo.PkProyecto;
                                OraDalGeneracionProbableEolicoSolarMgr.Instancia.Guardar(item);
                            }
                        }
                        CopiarDatosEconomicos();
                        CopiarDatosTransAsociadaAlProyecto();
                        CopiarDatosReduccionEmisiones();
                        break;
                    case (long)D_COD_TIPO_PROYECTO.LINEA_DE_TRANSMISIÓN://linea transmision
                        DatoTecnicoLineaTransmision datoLinea = OraDalDatoTecnicoLineaTransmisionMgr.Instancia.GetPorPkProyecto(_pkProyecto);
                        if (datoLinea != null)
                        {
                            datoLinea.EsNuevo = true;
                            datoLinea.FkProyecto = _proyectoNuevo.PkProyecto;
                            OraDalDatoTecnicoLineaTransmisionMgr.Instancia.Guardar(datoLinea);
                        }
                        CopiarDatosEconomicos();
                        break;
                    case (long)D_COD_TIPO_PROYECTO.TRANSFORMADOR:// transformador
                        DatoTecnicoTransformador datoTrans = OraDalDatoTecnicoTransformadorMgr.Instancia.GetPorPkProyecto(_pkProyecto);
                        if (datoTrans != null)
                        {
                            datoTrans.EsNuevo = true;
                            datoTrans.FkCodProyecto = _proyectoNuevo.PkProyecto;
                            OraDalDatoTecnicoTransformadorMgr.Instancia.Guardar(datoTrans);
                        }
                        CopiarDatosEconomicos();
                        break;
                    case (long)D_COD_TIPO_PROYECTO.CAPACITOR:// capacitor
                        DatoTecnicoCapacitor datoCap = OraDalDatoTecnicoCapacitorMgr.Instancia.GetPorPkProyecto(_pkProyecto);
                        if (datoCap != null)
                        {
                            datoCap.EsNuevo = true;
                            datoCap.FkProyecto = _proyectoNuevo.PkProyecto;
                            OraDalDatoTecnicoCapacitorMgr.Instancia.Guardar(datoCap);
                        }
                        CopiarDatosEconomicos();
                        break;
                    case (long)D_COD_TIPO_PROYECTO.REACTOR:// reactor
                        DatoTecnicoReactor datoReac = OraDalDatoTecnicoReactorMgr.Instancia.GetPorPkProyecto(_pkProyecto);
                        if (datoReac != null)
                        {
                            datoReac.EsNuevo = true;
                            datoReac.FkProyecto = _proyectoNuevo.PkProyecto;
                            OraDalDatoTecnicoReactorMgr.Instancia.Guardar(datoReac);
                        }
                        CopiarDatosEconomicos();
                        break;

                    default:
                        break;
                }
                DialogResult = DialogResult.OK;
            }
        }

        private bool DatosSonValidos()
        {
            bool resultado = true;
            _errorProvider.Clear();
            if (_dtpFechaRegistro.Value.Date > DateTime.Now.Date)
            {
                _errorProvider.SetError(_dtpFechaRegistro, "La fecha de registro no puede ser porterior a la fecha de sistema.");
                resultado = false;
            }
            return resultado;
        }

        public Proyecto GetProyectoActual()
        {
            return _proyectoNuevo;
        }
        private void CopiarDatosReduccionEmisiones()
        {
            ReduccionEmisores emision = OraDalReduccionEmisoresMgr.Instancia.GetPorPkProyecto(_pkProyecto);
            if (emision != null)
            {
                emision.EsNuevo = true;
                emision.FkProyecto = _proyectoNuevo.PkProyecto;
                OraDalReduccionEmisoresMgr.Instancia.Guardar(emision);
            }
        }

        private void CopiarDatosTransAsociadaAlProyecto()
        {
            TransmisionAsociadaAlProyecto trans = OraDalTransmisionAsociadaAlProyectoMgr.Instancia.GetPorPkProyecto(_pkProyecto);
            if (trans != null)
            {
                trans.EsNuevo = true;
                trans.FkProyecto = _proyectoNuevo.PkProyecto;
                OraDalTransmisionAsociadaAlProyectoMgr.Instancia.Guardar(trans);
            }
        }

        private void CopiarDatosEconomicos()
        {
            DatoEconomico datoEco = OraDalDatoEconomicoMgr.Instancia.GetPorPkProyecto(_pkProyecto);
            if (datoEco != null)
            {
                long pkDatoEco = datoEco.PkDatoEconomico;
                datoEco.EsNuevo = true;
                datoEco.FkProyecto = _proyectoNuevo.PkProyecto;
                OraDalDatoEconomicoMgr.Instancia.Guardar(datoEco);

                List<CronogramaDeInversion> listaCronograma = OraDalCronogramaDeInversionMgr.Instancia.GetTodoElCronogramaPorPkDatoEconomico(pkDatoEco);
                foreach (CronogramaDeInversion item in listaCronograma)
                {
                    item.EsNuevo = true;
                    item.FkDatoEconomico = datoEco.PkDatoEconomico;
                    OraDalCronogramaDeInversionMgr.Instancia.Guardar(item);
                }
            }
        }

        private void _btnNoCopiar_Click(object sender, EventArgs e)
        {
            _proyectoNuevo.FechaDeRegistro = _dtpFechaRegistro.Value.Date;
            DialogResult = DialogResult.No;
        }

        private void _cmbEtapa_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_cmbEtapa.SelectedItem != null)
            {
                _proyectoSeleccionado = OraDalProyectoMgr.Instancia.GetProyectoPorEtapa((long)_cmbEtapa.SelectedValue, _proyectoMaestro.PkProyectoMaestro);
                _pkProyecto = _proyectoSeleccionado.PkProyecto;
            }
        }

        private void _tsbCancelar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }
    }
}
