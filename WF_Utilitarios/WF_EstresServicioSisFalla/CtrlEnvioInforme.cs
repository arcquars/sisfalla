using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CNDC.UtilesComunes;
using System.IO;

namespace WF_EstresServicioSisFalla
{
    public partial class CtrlEnvioInforme : UserControl
    {
        DataSet _dataSetInforme;
        public long PkCodPersona { get; set; }
        WCF_SisFalla.IServicioSISFALLA _servicio;
        DataTable _tablaRegFalla;
        int _indiceFalla = 0;
        BindingList<DatosEnvio> _envios = new BindingList<DatosEnvio>();
        int _contadorEnvios = 0;
        TimeSpan minimo;
        TimeSpan maximo;
        TimeSpan sumatoria = new TimeSpan();
        public CtrlEnvioInforme()
        {
            InitializeComponent();
            _dgvEnvios.DataSource = _envios;

            _dgvEnvios.Columns["Inicio"].DefaultCellStyle.Format = "HH:mm:ss.fff";
            _dgvEnvios.Columns["Fin"].DefaultCellStyle.Format = "HH:mm:ss.fff";
            _dgvEnvios.Columns["Duracion"].DefaultCellStyle.Format = "HH:mm:ss.fff";

            _dgvEnvios.Columns["Inicio"].Width = 80;
            _dgvEnvios.Columns["Fin"].Width = 80;
            _dgvEnvios.Columns["Duracion"].Width = 100;
        }

        public void AbrirInforme()
        {
            _dataSetInforme = new DataSet();
            _dataSetInforme.ReadXmlSchema("EsquemaInforme.xml");
            string archDestino = DescomprimirArchivo("Informe.xml.gz");
            _dataSetInforme.ReadXml(archDestino);
        }

        public string DescomprimirArchivo(string archivo)
        {
            string archi = archivo.Substring(0, archivo.Length - 3);
            byte[] buffer = File.ReadAllBytes(archivo);
            byte[] bufferzip = GZip.DesComprimir(buffer);
            byte[] bufferdecodec = CodificarArchivo.decodificar(bufferzip);
            File.WriteAllBytes(archi, bufferdecodec);
            return archi;
        }

        private void _btnIniciar_Click(object sender, EventArgs e)
        {
            _servicio = new WCF_SisFalla.ServicioSISFALLAClient();
            byte[]b=_servicio.GetRegistrosSincronizacion(FormLogin.TokenSesion, "F_GF_REGFALLA", 0, PkCodPersona);
            b = GZip.DesComprimir(b);
            _tablaRegFalla = Serializador.DeSerializar<DataTable>(b);
            _lblFallasInvolucradas.Text = _tablaRegFalla.Rows.Count + "";
            AbrirInforme();
            _timerEnvio.Enabled = true;
        }

        DatosEnvio _envioActual;
        private void _timerEnvio_Tick(object sender, EventArgs e)
        {
            _envioActual = new DatosEnvio();
            _timerEnvio.Enabled = false;
            _bgWorker.RunWorkerAsync();
        }

        private void Enviar()
        {
            _envioActual.Inicio = DateTime.Now;
            int codFalla = (int)_tablaRegFalla.Rows[_indiceFalla]["PK_COD_FALLA"];
            PonerCodFallaYCodEmpresa(codFalla);
            byte[] b = Serializador.Serializar(_dataSetInforme);
            b = GZip.Comprimir(b);
            bool resultadoSubida = _servicio.Subir(FormLogin.TokenSesion, b, "SISFALLA");
            _indiceFalla = (_indiceFalla + 1) % _tablaRegFalla.Rows.Count;
            _envioActual.Fin = DateTime.Now;
            _envioActual.Duracion = _envioActual.Fin - _envioActual.Inicio;
            _envioActual.Bytes = b.Length;
            sumatoria = sumatoria.Add(_envioActual.Duracion);
        }

        private void PonerCodFallaYCodEmpresa(int codFalla)
        {
            for (int i = 0; i < _dataSetInforme.Tables.Count; i++)
            {
                for (int j = 0; j < _dataSetInforme.Tables[i].Rows.Count; j++)
                {
                    _dataSetInforme.Tables[i].Rows[j]["PK_COD_FALLA"] = codFalla;
                    _dataSetInforme.Tables[i].Rows[j]["PK_ORIGEN_INFORME"] = PkCodPersona;
                }
            }
        }

        private void _bgWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            Enviar();
        }

        private void _bgWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (_contadorEnvios == 0)
            {
                maximo = minimo = _envioActual.Duracion;
            }
            else if(_envioActual.Duracion>maximo)
            {
                maximo = _envioActual.Duracion;
            }
            else if (_envioActual.Duracion < minimo)
            {
                minimo = _envioActual.Duracion;
            }
            _contadorEnvios++;
            _lblCantEnvios.Text = _contadorEnvios + "";
            _envios.Add(_envioActual);
            _timerEnvio.Enabled = true;
            _lblMaximo.Text = maximo.ToString();
            _lblMinimo.Text = minimo.ToString();
            _lblPromedio.Text = new TimeSpan(sumatoria.Ticks / _contadorEnvios) + "";
        }
    }

    class DatosEnvio
    {
        public DateTime Inicio { get; set; }
        public DateTime Fin { get; set; }
        public TimeSpan Duracion { get; set; }
        public int Bytes { get; set; }
    }
}
