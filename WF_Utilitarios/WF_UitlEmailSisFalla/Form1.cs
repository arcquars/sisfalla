using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Oracle.DataAccess.Client;
using System.Net.Mail;
using CNDC.UtilesComunes;
using System.Net;
using System.IO;

namespace WF_UtilEmailSisFalla
{
    public partial class Form1 : Form
    {
        string nomCuenta = string.Empty;
        string etiquetaEnvio = string.Empty;
        string pass = string.Empty;
        string servidor = string.Empty;
        string direccIP = string.Empty;
        int puerto = 0;
        bool sslActivo = false;
        BindingList<Destinatario> _destinatarios;
        public Form1()
        {
            InitializeComponent();
            _destinatarios = new BindingList<Destinatario>();
            _dgvEnvios.DataSource = _destinatarios;
            _destinatarios.Add(new Destinatario() { CorreoE = "jjlopez@cndc.bo" });
            _destinatarios.Add(new Destinatario() { CorreoE = "inavarro@cndc.bo" });
            _destinatarios.Add(new Destinatario() { CorreoE = "ivan_n_v@hotmail.com" });
            _dgvEnvios.Columns["CorreoE"].Width = 200;
        }

        private void _btnIngresar_Click(object sender, EventArgs e)
        {
            OracleConnection con = new OracleConnection();
            string cadConexion = "USER ID={0};DATA SOURCE=(DESCRIPTION=(ADDRESS_LIST=(ADDRESS=(PROTOCOL=TCP)(HOST=localhost)(PORT=1521)))(CONNECT_DATA=(SERVER=DEDICATED)(SID=xe)));PASSWORD=\"{1}\";PERSIST SECURITY INFO=true;";
            cadConexion = string.Format(cadConexion, _txtUsuario.Text, _txtContrasena.Text);
            con.ConnectionString = cadConexion;
            _lblMensaje.Text = string.Empty;

            try
            {
                con.Open();
                string sql = 
                @"SELECT a.* from P_DEF_SERVICIOENVIO a
                WHERE a.pk_cod_persona IN 
                (SELECT c.pk_cod_empresa FROM f_ap_rcontacto c WHERE pk_cod_contacto IN(  SELECT b.pk_cod_usuario FROM F_AU_USUARIOS b WHERE b.login='{0}'))";
                sql = string.Format(sql, _txtUsuario.Text.ToUpper());

                OracleCommand cmd = con.CreateCommand();
                cmd.CommandText = sql;
                OracleDataAdapter adap = new OracleDataAdapter(cmd);
                DataTable tabla = new DataTable();
                adap.Fill(tabla);
                if (tabla.Rows.Count > 0)
                {
                    nomCuenta = (string)tabla.Rows[0]["NOM_CUENTA"];
                    etiquetaEnvio = (string)tabla.Rows[0]["ETIQUETA_ENVIO"];
                    pass = (string)tabla.Rows[0]["CUENTA_PASSWD"];
                    servidor = (string)tabla.Rows[0]["NOMBRE_URI"];
                    if (servidor == "NO")
                    {
                        servidor = (string)tabla.Rows[0]["DIRECCION_IP"];
                    }
                    sslActivo = (short)tabla.Rows[0]["SSL_ACTIVO"] == 1;
                    puerto = int.Parse(tabla.Rows[0]["NUM_PUERTO"].ToString());
                    _destinatarios.Add(new Destinatario() { CorreoE = nomCuenta });

                    _pnlLogin.Enabled = false;
                    _pnlEnvio.Enabled = true;
                }
                else
                {
                    _lblMensaje.Text = "No tiene configurado ninguna cuenta de correo electrónico.";
                }
            }
            catch (Exception ex)
            {
                _lblMensaje.Text = ex.ToString();
            }
        }

        public bool Enviar(string destinatario)
        {
            bool resultado = true;

            var fromAddress = new MailAddress(nomCuenta, etiquetaEnvio + "_SisFalla-V2");
            string fromPassword = Codifica.DecodeFrom64(pass);


            var smtp = GetSMTP_CNDC(fromAddress, fromPassword);

            var message = new MailMessage();
            message.From = fromAddress;
            message.To.Add(destinatario);

            message.Subject = "SisFalla V2 - Prueba de Utilitario.";
            message.Body = "Esta es sólo un prueba del Utilitario de cnvío de correo electrónico.";
            message.IsBodyHtml = true;
            smtp.Send(message);

            return resultado;
        }

        private SmtpClient GetSMTP_CNDC(MailAddress fromAddress, string fromPassword)
        {
            return new SmtpClient
            {
                Host = servidor,
                Port = puerto,
                EnableSsl = sslActivo,
                DeliveryMethod = (SmtpDeliveryMethod)_cmbSmtpDeliveryMethod.SelectedItem,//SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(fromAddress.Address, fromPassword)
            };
        }

        private void _btnEnviar_Click(object sender, EventArgs e)
        {
            int contadorEnviados = 0;
            for (int i = 0; i < _destinatarios.Count; i++)
            {
                _destinatarios[i].Enviado = false;
                try
                {
                    Enviar(_destinatarios[i].CorreoE);
                    _destinatarios[i].Enviado = true;
                    contadorEnviados++;
                }
                catch (Exception ex)
                {
                    EscribirLog("[ " + _destinatarios[i].CorreoE + " ]");
                    EscribirLog(ex.ToString());
                }
                _dgvEnvios.Refresh();
                Application.DoEvents();
            }

            _lblEnviados.Text = "Total Enviados: " + contadorEnviados;
        }

        private void EscribirLog(string cadena)
        {
            StreamWriter w = new StreamWriter(Path.Combine(Application.StartupPath, "Log.txt"), true);
            w.WriteLine(DateTime.Now.ToString("dd/MMM/yyyy HH:mm:ss"));
            w.WriteLine(cadena);
            w.Close();
        }

        private void _btnAdicionarEmail_Click(object sender, EventArgs e)
        {
            _txtEmail.Text = _txtEmail.Text.Trim();
            if (!string.IsNullOrEmpty(_txtEmail.Text))
            {
                _destinatarios.Add(new Destinatario() { CorreoE = _txtEmail.Text });
                _txtEmail.Text = string.Empty;
                _dgvEnvios.Refresh();
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            _cmbSmtpDeliveryMethod.Items.Add(SmtpDeliveryMethod.Network);
            _cmbSmtpDeliveryMethod.Items.Add(SmtpDeliveryMethod.PickupDirectoryFromIis);
            _cmbSmtpDeliveryMethod.SelectedIndex = 0;
        }
    }
}
