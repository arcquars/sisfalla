using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CNDC.BaseForms;
using ModeloSisFalla;
using CNDC.DAL;
using CNDC.BLL;
using MenuQuantum;
using Oracle.DataAccess.Client;
using CNDC.Pistas;
using System.Text.RegularExpressions;
using CNDC.UtilesComunes;
using SisFallaEmailLib;

namespace SISFALLA
{
    public partial class EnvioCorreo : ABMBaseForm, IFuncionalidad
    {
        private OracleCommand cmd;
        
        bool esnuevo = false;
        private bool _formularioConErrores = false;
        public EnvioCorreo()
        {
            InitializeComponent();
        }

        protected override bool Guardar()
        {
            if (DatosSonValidos())
            {
                GuardarConfi();
            }
            
            return true;
        }

        private void agregarConsulta(string sql)
        {
            cmd = Sesion.Instancia.Conexion.CrearCommand();
            cmd.CommandText = sql;
            cmd.BindByName = true;
        }
        private void agregarParametro(string param1, string valor1)
        {
            if (!string.IsNullOrEmpty(param1))
            {
                cmd.Parameters.Add(param1, OracleDbType.Varchar2, valor1, System.Data.ParameterDirection.Input);
            }
        }

        private bool DatosSonValidos()
        {
            bool resultado = true;
            _errorProvider.Clear();

            _tbxServidor.Text = _tbxServidor.Text.Trim();

            if (_tbxServidor.Text == string.Empty)
            {
                _errorProvider.SetError(_tbxServidor, "Ingrese el nombre del servidor");
                resultado = false;
            }
            _tbxIP.Text = _tbxIP.Text.Trim();
            if (_tbxIP.Text == string.Empty)
            {
                _errorProvider.SetError(_tbxIP, "Ingrese la dirección IP del servidor");
                resultado = false;
            }
            else
            {
                if (!validarIP(_tbxIP.Text))
                {
                    _errorProvider.SetError(_tbxIP, "Ingrese una dirección IP válida");
                    resultado = false;

                }
            }
            _tbxPuerto.Text = _tbxPuerto.Text.Trim();
            if (_tbxPuerto.Text == string.Empty)
            {
                _errorProvider.SetError(_tbxPuerto, "Ingrese el puerto del servidor");
                resultado = false;
            }
            else
            {
                if (!EsNumero(_tbxPuerto.Text))
                {
                    _errorProvider.SetError(_tbxPuerto, "Ingrese un número de puerto válido");
                    resultado = false;

                }
            }
            _tbxEmail.Text = _tbxEmail.Text.Trim();
            if (_tbxEmail.Text == string.Empty)
            {
                _errorProvider.SetError(_tbxEmail, "Ingrese una cuenta del correo electrónico válida");
                resultado = false;
            }
            else
            {
                if (!email_bien_escrito(_tbxEmail.Text))
                {
                    _errorProvider.SetError(_tbxEmail, "Email no válido, ingrese en el formato correcto");
                    resultado = false;
                }
            }
            _tbxPasswd.Text = _tbxPasswd.Text.Trim();
            if (_tbxPasswd.Text == string.Empty)
            {
                _errorProvider.SetError(_tbxPasswd, "Ingrese la contraseña de la cuenta");
                resultado = false;
            }
            else
            {
                if (_tbxPasswd.Text.Length < 3)
                {
                    _errorProvider.SetError(_tbxPasswd, "La longitud de la contraseña debe tener mínimo 3 caracteres y máximo 15");
                    resultado = false;
                }
            }

            _formularioConErrores = !resultado;
            return resultado;
        }
        public void GuardarConfi()
        {
            string query = string.Empty;
            int ssl_servicio = 0;
            if (_chkSsl.Checked==true)
            {
                ssl_servicio = 1;
            }
            long cod = Sesion.Instancia.EmpresaActual.PkCodPersona;
            if (existeConfiguracion(cod))
            {
                query = "UPDATE P_DEF_SERVICIOENVIO SET {2}=:{2},{3}=:{3},{4}=:{4},{5}=:{5},{6}=:{6},{7}=:{7},{8}=:{8} WHERE {0}=:{0} AND {1}=:{1}";
            }
            else
            {
                query = "INSERT INTO P_DEF_SERVICIOENVIO ({0},{1},{2},{3},{4},{5},{6},{7},{8}) VALUES (:{0},:{1},:{2},:{3},:{4},:{5},:{6},:{7},:{8})";
            }
            query = string.Format(query,
                    "PK_COD_PERSONA",
                    "PK_COD_CONFI",
                    "NOMBRE_URI",
                    "DIRECCION_IP",
                    "NUM_PUERTO",
                    "NOM_CUENTA",
                    "CUENTA_PASSWD",
                    "ETIQUETA_ENVIO",
                    "SSL_ACTIVO"
                    );
            if (true)
            {
                OracleCommand cmdg = Sesion.Instancia.Conexion.CrearCommand();
                cmdg.CommandText = query;
                cmdg.BindByName = true;
                cmdg.Parameters.Add("PK_COD_PERSONA", OracleDbType.Int32, Sesion.Instancia.EmpresaActual.PkCodPersona, System.Data.ParameterDirection.Input);
                cmdg.Parameters.Add("PK_COD_CONFI", OracleDbType.Int32, 10, System.Data.ParameterDirection.Input);
                cmdg.Parameters.Add("NOMBRE_URI", OracleDbType.Varchar2, _tbxServidor.Text, System.Data.ParameterDirection.Input);
                cmdg.Parameters.Add("DIRECCION_IP", OracleDbType.Varchar2, _tbxIP.Text, System.Data.ParameterDirection.Input);
                cmdg.Parameters.Add("NUM_PUERTO", OracleDbType.Varchar2, Decimal.Parse(_tbxPuerto.Text), System.Data.ParameterDirection.Input);
                cmdg.Parameters.Add("NOM_CUENTA", OracleDbType.Varchar2, _tbxEmail.Text, System.Data.ParameterDirection.Input);
                cmdg.Parameters.Add("CUENTA_PASSWD", OracleDbType.Varchar2, Codifica.EncodeTo64(_tbxPasswd.Text), System.Data.ParameterDirection.Input);
                cmdg.Parameters.Add("ETIQUETA_ENVIO", OracleDbType.Varchar2, Sesion.Instancia.EmpresaActual.Sigla, System.Data.ParameterDirection.Input);
                cmdg.Parameters.Add("SSL_ACTIVO", OracleDbType.Int32, ssl_servicio, System.Data.ParameterDirection.Input);
                
                Sesion.Instancia.Conexion.Actualizar(cmdg);

                Sesion.Instancia.ConfiguracionCorreo = consultaConfiguracion(Sesion.Instancia.EmpresaActual.PkCodPersona);
                MessageBox.Show("Configuracion se guardo satisfactoriamente ...", "Configuracion Correo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                _btnVerificar.Visible = true;
                _btnVerificar.Focus();
            }
        }

        #region IFuncionalidad
        public Dictionary<string, string> Parametros { get; set; }       
        public void Ejecutar()
        {

            
            long  CodEmpresa = Sesion.Instancia.EmpresaActual.PkCodPersona;
            _lblEmpresa.Text = Sesion.Instancia.EmpresaActual.Sigla + " - " + Sesion.Instancia.EmpresaActual.Nombre;
            _tbxMensaje.Text = "Para el envió de información por correo electrónico, la institución debe especificar la configuración oficial y activa de su servicio de mensajería SMTP, en caso de no conocer los datos consulte con el Administrador de correo electrónico de su institución...";
            _btnVerificar.Visible = false;

            DataRow d = consultaConfiguracion(CodEmpresa);
                if (d!=null)
                {
                    _tbxServidor.Text = d["NOMBRE_URI"].ToString();
                    _tbxIP.Text = d["DIRECCION_IP"].ToString();
                    _tbxPuerto.Text = d["NUM_PUERTO"].ToString();
                    _tbxEmail.Text = d["NOM_CUENTA"].ToString();
                    _tbxPasswd.Text = Codifica.DecodeFrom64(d["CUENTA_PASSWD"].ToString());
                    if (Int32.Parse(d["SSL_ACTIVO"].ToString()) == 1)
                    {
                        _chkSsl.Checked = true;
                    }
                }
                else
                {
                    esnuevo = true;
                }
            ShowDialog();
        }
        #endregion IFuncionalidad
        public DataRow consultaConfiguracion(long CodEmpresa)
        {
            string strSql = string.Empty;
            DataTable t = new DataTable();
            strSql =
                @"SELECT
                        A.*
                        FROM
                        P_DEF_SERVICIOENVIO A
                        WHERE
                        A.PK_COD_PERSONA = :COD_EMPRESA
                        AND A.PK_COD_CONFI=10";

            agregarConsulta(strSql);
            agregarParametro("COD_EMPRESA", CodEmpresa.ToString());
            OracleDataAdapter adap = new OracleDataAdapter(cmd);
            adap.Fill(t);
            if (t.Rows.Count > 0)
            {
                return t.Rows[0];
            }
            else
            {
                return null;
            }
        }

        public bool existeConfiguracion(long CodEmpresa)
        {
            string strSql = string.Empty;
            DataTable t = new DataTable();
            strSql =
                    @"SELECT
                        A.*
                        FROM
                        P_DEF_SERVICIOENVIO A
                        WHERE
                        A.PK_COD_PERSONA = :COD_EMPRESA
                        AND A.PK_COD_CONFI=10";

            agregarConsulta(strSql);
            agregarParametro("COD_EMPRESA", CodEmpresa.ToString());
            OracleDataAdapter adap = new OracleDataAdapter(cmd);
            adap.Fill(t);
            if (t.Rows.Count > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private Boolean email_bien_escrito(String email)
        {
            String expresion;
            expresion = "\\w+([-+.']\\w+)*@\\w+([-.]\\w+)*\\.\\w+([-.]\\w+)*";
            if (Regex.IsMatch(email, expresion))
            {
                if (Regex.Replace(email, expresion, String.Empty).Length == 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }
        private bool EsNumero(string cadena)
        {
            //Sencillamente, si se logra hacer la conversión, entonces es número
            try
            {
                decimal resp = Convert.ToDecimal(cadena);
                return true;
            }
            catch //caso contrario, es falso.
            {
                return false;
            }

        } 
        private bool validarIP(string ip)
        {
            int i;
            const int NUMOCT = 4;
            int[] IP = new int[NUMOCT];
            string[] r = ip.Split('.');

            if (r.Length != NUMOCT)
            {
                return false;
            }
            else if (r.Length == NUMOCT)
            {
                for (i = 0; i <= (NUMOCT - 1); i++)
                {
                    try
                    {
                        IP[i] = int.Parse(r[i]);
                    }
                    catch
                    {
                        return false; 
                    }
                }

                for (i = 0; i <= (NUMOCT - 1); i++)
                {
                    if (IP[i] < 0 || IP[i] > 255) 
                        return false;
                }
            }

            return true;   
        }
            
        private void _btnVerificar_Click(object sender, EventArgs e)
        {
            EnviadorEmail email = new EnviadorEmail();
            bool enviado = false;
            List<string> destinatarios = new List<string>();
            List<string> archivosAdjuntos = new List<string>();
            destinatarios.Add(Sesion.Instancia.ConfiguracionCorreo["NOM_CUENTA"].ToString());
            try
            {
                email.Enviar("SisFalla V2: Prueba de Configuración", "Esto es sólo una mensaje de prueba, para verificar que la configuración de correo actual está activa y funcionando correctamente, gracias...", destinatarios, archivosAdjuntos);
                enviado = true;
            }
            catch (Exception ex)
            {
                
                PistaMgr.Instance.Error("SISFALLA", ex);
            }
            if (!enviado)
            {
                MessageBox.Show("No se pudo enviar el correo de prueba, revisar su configuración ...", "Envío Correo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                MessageBox.Show("Se envío el mensaje de prueba, favor verificar la llegada en su buzón de correo ...", "Envío Correo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
