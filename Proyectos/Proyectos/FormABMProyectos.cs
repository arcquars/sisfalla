using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Proyectos
{
    public partial class FormABMProyectos : Form
    {
        TabPage tabDatosTecnicos = new TabPage();
        TabPage tabDatosEconomicos = new TabPage();
        TabPage tabDatosDeTransmision = new TabPage();
        TabPage tabDatosReduccionEmisores = new TabPage();
        TabPage tabSeriesHidrologicas = new TabPage();
        string tipoProyecto = string.Empty;

        public FormABMProyectos()
        {
            InitializeComponent();
            tabDatosTecnicos.Text = "Datos Técnicos";
            tabDatosEconomicos.Text = "Datos económicos";
            tabDatosDeTransmision.Text = "Datos de transmisión";
            tabDatosReduccionEmisores.Text = "Datos de reducción de emisores";
            tabSeriesHidrologicas.Text = "Series Hidrológicas";
        }

        public void setTipoProyecto( string tipoProy)
        {
            tipoProyecto = tipoProy;
            CargarControles();
        }

        private void CargarControles()
        {
            //CargarControlesDeDatosDeTransmisionAsociadosAlProy();
            switch (tipoProyecto)
            {
                case "Hidroeléctrico":
                    CargarControlesDatosTecnicosDeProyHidrologicos();
                    CargarControlesDeDatosEconomicos();
                    CargarControlesDeDatosDeTransmisionAsociadosAlProy();
                    break;
                case "Turbinas":
                    CargarControlesDatosTecnicosDeProyTermicoAGasTurbina();
                    CargarControlesDeDatosEconomicos();
                    CargarControlesDeDatosDeTransmisionAsociadosAlProy();
                    CargarControlesDatosReduccionDeEmisores();
                    break;
                case "Biomasa":
                    CargarControlesDatosTecnicosDeProyBiomasa();
                    CargarControlesDeDatosEconomicos();
                    CargarControlesDeDatosDeTransmisionAsociadosAlProy();
                    CargarControlesDatosReduccionDeEmisores();
                    break;
                case "Geotérmico":
                    CargarControlesDatosTecnicosDeProyGeotermico();
                    CargarControlesDeDatosEconomicos();
                    CargarControlesDeDatosDeTransmisionAsociadosAlProy();
                    CargarControlesDatosReduccionDeEmisores();
                    break;
                case "Eólico":
                    CargarControlesDatosTecnicosDeProysEolicos("Eólico");
                    CargarControlesDeDatosEconomicos();
                    CargarControlesDeDatosDeTransmisionAsociadosAlProy();
                    CargarControlesDatosReduccionDeEmisores();
                    break;
                case "Solar":
                    CargarControlesDatosTecnicosDeProysEolicos("Solar");
                    CargarControlesDeDatosEconomicos();
                    CargarControlesDeDatosDeTransmisionAsociadosAlProy();
                    CargarControlesDatosReduccionDeEmisores();

                    break;
                case "Linea de transmisión":
                    CargarControlesDeDatosTecnicosDeProysDeTransmision();
                    CargarControlesDeDatosEconomicos();
                    CargarControlesDatosReduccionDeEmisores();
                    break;

                case "Transformador":
                    CargarControlesDeDatosTecnicosDeProysTransformador();
                    CargarControlesDeDatosEconomicos();
                    CargarControlesDatosReduccionDeEmisores();
                    break;

                case "Capacitor":
                    CargarControlesDeDatosTecnicosDeProysCapacitor();
                    CargarControlesDeDatosEconomicos();
                    CargarControlesDatosReduccionDeEmisores();
                    break;

                case "Reactor":
                    CargarControlesDeDatosTecnicosDeProysReactor();
                    CargarControlesDeDatosEconomicos();
                    CargarControlesDatosReduccionDeEmisores();
                    break;

                case "Térmico a diesel":
                    CargarControlesDeDatosTermicoADiesel();
                    CargarControlesDeDatosEconomicos();
                    CargarControlesDeDatosDeTransmisionAsociadosAlProy();
                    CargarControlesDatosReduccionDeEmisores();
                    break;
                case "Motores":
                    CargarControlesDeDatosTermicoADiesel();
                    CargarControlesDeDatosEconomicos();
                    CargarControlesDeDatosDeTransmisionAsociadosAlProy();
                    CargarControlesDatosReduccionDeEmisores();
                    break;
                case "Térmico Dual Fuel":
                    CargarControlesDeDatosTermicoDualFuel();
                    CargarControlesDeDatosEconomicos();
                    CargarControlesDeDatosDeTransmisionAsociadosAlProy();
                    CargarControlesDatosReduccionDeEmisores();
                    break;
                case "Térmico Ciclo combinado":
                    CargarControlesDeDatosTermicoCicloCombinado();
                    CargarControlesDeDatosEconomicos();
                    CargarControlesDeDatosDeTransmisionAsociadosAlProy();
                    CargarControlesDatosReduccionDeEmisores();
                    break;
                default:
                    break;
            }
        }

        private void CargarControlesDeDatosTecnicosDeProysReactor()
        {
            CtrlDatosTecnicosProysReactores ctrl = new CtrlDatosTecnicosProysReactores();
            tabDatosTecnicos.Controls.Add(ctrl);
            _tbDatosDelProyecto.TabPages.Add(tabDatosTecnicos);
        }

        private void CargarControlesDeDatosTecnicosDeProysCapacitor()
        {
            CtrlDatosTecnicosDeProysCapacitores ctrl = new CtrlDatosTecnicosDeProysCapacitores();
            tabDatosTecnicos.Controls.Add(ctrl);
            _tbDatosDelProyecto.TabPages.Add(tabDatosTecnicos);
        }

        private void CargarControlesDeDatosTecnicosDeProysTransformador()
        {
            CtrlDatosTecnicosDeProysDeTransmisionDeTransformador ctrl = new CtrlDatosTecnicosDeProysDeTransmisionDeTransformador();
            tabDatosTecnicos.Controls.Add(ctrl);
            _tbDatosDelProyecto.TabPages.Add(tabDatosTecnicos);
        }

        private void CargarControlesDeDatosTermicoCicloCombinado()
        {
            CtrlDatosTecnicosProysCicloCombinado ctrl = new CtrlDatosTecnicosProysCicloCombinado();
            tabDatosTecnicos.Controls.Add(ctrl);
            _tbDatosDelProyecto.TabPages.Add(tabDatosTecnicos);
        }

        private void CargarControlesDeDatosTermicoDualFuel()
        {
            CtrlDatosTecnicosProyTermicoADualFuel ctrl = new CtrlDatosTecnicosProyTermicoADualFuel();
            tabDatosTecnicos.Controls.Add(ctrl);
            _tbDatosDelProyecto.TabPages.Add(tabDatosTecnicos);
        }

        private void CargarControlesDeDatosTermicoADiesel()
        {
            CtrlDatostecnicosProysTermicoADiesel ctrl = new CtrlDatostecnicosProysTermicoADiesel();
            tabDatosTecnicos.Controls.Add(ctrl);
            _tbDatosDelProyecto.TabPages.Add(tabDatosTecnicos);
        }

        private void CargarControlesDatosTecnicosDeProysEolicos(string tipoProy)
        {
            CtrlDatosTecnicosProysEolicos ctrl = new CtrlDatosTecnicosProysEolicos();
            ctrl.SetTipoProy(tipoProy);
            tabDatosTecnicos.Controls.Add(ctrl);
            _tbDatosDelProyecto.TabPages.Add(tabDatosTecnicos);
        }

        private void CargarControlesDatosTecnicosDeProyHidrologicos()
        {
            CtrlDatosTecnicosHidroelectricos ctrl = new CtrlDatosTecnicosHidroelectricos();
            tabDatosTecnicos.Controls.Add(ctrl);
            _tbDatosDelProyecto.TabPages.Add(tabDatosTecnicos);
        }

        private void CargarControlesDatosTecnicosDeProyGeotermico()
        {
            CtrlDatosTecnicosProysGeotermico ctrl = new CtrlDatosTecnicosProysGeotermico();
            tabDatosTecnicos.Controls.Add(ctrl);
            _tbDatosDelProyecto.TabPages.Add(tabDatosTecnicos);
        }

        private void CargarControlesDatosReduccionDeEmisores()
        {
            CtrlDatosDeRduccionDeEmisores ctrl = new CtrlDatosDeRduccionDeEmisores();
            tabDatosReduccionEmisores.Controls.Add(ctrl);
            _tbDatosDelProyecto.TabPages.Add(tabDatosReduccionEmisores);
        }

        private void CargarControlesDatosTecnicosDeProyBiomasa()
        {
            CtrlDatosTecnicosDeProyBiomasa ctrl = new CtrlDatosTecnicosDeProyBiomasa();
            tabDatosTecnicos.Controls.Add(ctrl);
            _tbDatosDelProyecto.TabPages.Add(tabDatosTecnicos);
        }

        private void CargarControlesDeDatosDeTransmisionAsociadosAlProy()
        {
            CtrlDatosDeTransmisionAsociadasAlProyecto ctrl = new CtrlDatosDeTransmisionAsociadasAlProyecto();
            tabDatosDeTransmision.Controls.Add(ctrl);
            _tbDatosDelProyecto.TabPages.Add(tabDatosDeTransmision);
        }

        private void CargarControlesDatosTecnicosDeProyTermicoAGasTurbina()
        {
            CtrlDatosTecnicosProysTermicoAGasTurbinas ctrl = new CtrlDatosTecnicosProysTermicoAGasTurbinas();
            tabDatosTecnicos.Controls.Add(ctrl);
            _tbDatosDelProyecto.TabPages.Add(tabDatosTecnicos);
        }

        private void CargarControlesDeDatosEconomicos()
        {
            CtrlDatosEconomicosYCronogramaInversion ctrl = new CtrlDatosEconomicosYCronogramaInversion();
            tabDatosEconomicos.Controls.Add(ctrl);
            _tbDatosDelProyecto.TabPages.Add(tabDatosEconomicos);
        }

        private void CargarControlesDeDatosTecnicosDeProysDeTransmision()
        {
            CtrlDatosTecnicosProysLineaTransmision ctrl = new CtrlDatosTecnicosProysLineaTransmision();
            tabDatosTecnicos.Controls.Add(ctrl);
            _tbDatosDelProyecto.TabPages.Add(tabDatosTecnicos);
        }

        private void _btnEditarDatosGenerales_Click(object sender, EventArgs e)
        {
            FormDatosGeneralesDelProyecto form = new FormDatosGeneralesDelProyecto();
            form.setTipoProyecto("");
            form.Show();
            this.Close();
        }
    }
}
