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

namespace WF_TestServicioSisFalla
{
    public partial class CtrlTestTabla : UserControl
    {
        private int _idx = 0;
        private List<string> _tablas;
        WCF_SisFalla.IServicioSISFALLA _servicio;
        BindingList<Solicitud> _solicitudes;
        private long contadorSolicitudes = 0;
        private TimeSpan _max;
        private TimeSpan _min;
        string _token = "Usuario=ELECTROPAZ|Contrasena=ELECTROPAZ";
        public CtrlTestTabla()
        {
            InitializeComponent();
            _tablas = new List<string>();
            _solicitudes = new BindingList<Solicitud>();
            _dgvSolicitudes.DataSource = _solicitudes;

            _dgvSolicitudes.Columns["Inicio"].DefaultCellStyle.Format = "HH:mm:ss.fff";
            _dgvSolicitudes.Columns["Fin"].DefaultCellStyle.Format = "HH:mm:ss.fff";
            _dgvSolicitudes.Columns["Duracion"].DefaultCellStyle.Format = "HH:mm:ss.fff";

            _dgvSolicitudes.Columns["Inicio"].Width = 80;
            _dgvSolicitudes.Columns["Fin"].Width = 80;
            _dgvSolicitudes.Columns["Duracion"].Width = 100;
            _dgvSolicitudes.Columns["Tabla"].Width = 130;
            _dgvSolicitudes.Columns["Bytes"].Width = 60;
            _dgvSolicitudes.Columns["Filas"].Width = 50;
            _dgvSolicitudes.Columns["Columnas"].Width = 50;
            _dgvSolicitudes.Columns["Bytes"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            _dgvSolicitudes.Columns["Filas"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            _dgvSolicitudes.Columns["Columnas"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
        }

        private void _btnIniciar_Click(object sender, EventArgs e)
        {
            _servicio = new WCF_SisFalla.ServicioSISFALLAClient();
            CargarTablas();
            _timer.Enabled = true;
            _btnIniciar.Enabled = false;
        }

        private void CargarTablas()
        {
            _tablas.Add("F_GF_REGFALLA");
            _tablas.Add("F_GF_INFORMEFALLA");
            _tablas.Add("F_GF_NOTIFICACION");
            _tablas.Add("F_GF_OP_INTERRUPTOR");
        }

        private void _btnSiguiente_Click(object sender, EventArgs e)
        {
            ObtenerTablaDeServidor();
        }

        private void _timer_Tick(object sender, EventArgs e)
        {
            ObtenerTablaDeServidor();
        }

        long sumatoria = 0;
        private void ObtenerTablaDeServidor()
        {
            try
            {
                string nombreTabla = _tablas[_idx];
                _lblTabla.Text = nombreTabla;
                Solicitud s = new Solicitud();
                s.Inicio = DateTime.Now;
                s.Tabla = nombreTabla;
                byte[] b = _servicio.GetTablaTest(_token, nombreTabla);
                s.Bytes = b.Length;
                b = GZip.DesComprimir(b);
                DataTable tabla = Serializador.DeSerializar<DataTable>(b);
                _dgvDatos.DataSource = tabla;
                s.Columnas = tabla.Columns.Count;
                s.Filas = tabla.Rows.Count;
                _idx = (_idx + 1) % _tablas.Count;
                s.Fin = DateTime.Now;
                s.Duracion = s.Fin - s.Inicio;
                //_solicitudes.Insert(0, s);
                _solicitudes.Add(s);
                if (contadorSolicitudes == 0)
                {
                    _min = _max = s.Duracion;
                }
                else if (s.Duracion > _max)
                {
                    _max = s.Duracion;
                }
                else if (s.Duracion < _min)
                {
                    _min = s.Duracion;
                }

                contadorSolicitudes++;
                _lblSolicitudes.Text = contadorSolicitudes + "";
                _lblHoraCNDC.Text = _servicio.GetStrFechaHora(_token);
                _lblMaximo.Text = _max + "";
                _lblMinimo.Text = _min + "";
            }
            catch (Exception ex)
            {
                EscribirLog(ex.ToString());
            }
        }

        private void EscribirLog(string cadena)
        {
            StreamWriter w = new StreamWriter(Path.Combine(Application.StartupPath, "Log" + GetHashCode() + ".txt"), true);
            w.WriteLine(DateTime.Now.ToString("dd/MMM/yyyy HH:mm:ss"));
            w.WriteLine(cadena);
            w.Close();
        }

        public void SetCredenciales(string usuario, string contrasena)
        {
            _token = string.Format("Usuario={0}|Contrasena={1}", usuario, contrasena);
        }


        public void CerrarSesion()
        {
            try
            {
                _servicio.CerrarSesion(_token);
            }
            catch (Exception ex)
            {
                EscribirLog(ex.ToString());
            }
        }
    }

    public class Solicitud
    {
        public DateTime Inicio { get; set; }
        public DateTime Fin { get; set; }
        public TimeSpan Duracion { get; set; }
        public string Tabla { get; set; }
        public int Bytes { get; set; }
        public int Columnas { get; set; }
        public int Filas { get; set; }
    }
}
