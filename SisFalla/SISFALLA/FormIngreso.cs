﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CNDC.BaseForms;
using CNDC.BLL;
using System.DirectoryServices ;
using CNDC.Pistas;
using CNDC.ExceptionHandlerLib;

namespace SISFALLA
{
    public partial class FormIngreso : BaseForm
    {
        static int NumIntentos =  1;
        static int MaxIntentos = 3;
        public FormIngreso()
        {
            InitializeComponent();
            TextBoxPassword.Focus();
        }

        private void LoginIngreso_Load(object sender, EventArgs e)
        {
            if (Sesion.Instancia.ConfigConexion.TipoBD == CNDC.DAL.TipoBaseDatos.Centralizada)
            {
                _cmbConectarDesde.SelectedIndexChanged += new EventHandler(_cmbConectarDesde_SelectedIndexChanged);
                switch (Sesion.Instancia.ConfigConexion.TipoAutenticacion)
                {
                    case CNDC.DAL.TipoAutenticacion.NoDefinido:
                        _cmbConectarDesde.SelectedIndex = -1;
                        break;
                    case CNDC.DAL.TipoAutenticacion.BaseDatos:
                        _cmbConectarDesde.SelectedIndex = 0;
                        break;
                    case CNDC.DAL.TipoAutenticacion.Dominio:
                        _cmbConectarDesde.SelectedIndex = 1;
                        break;
                }
            }
            else
            {
                _cmbConectarDesde.Visible = false;
                _lblConectadoDesde.Visible = false;
            }

            PistaMgr.Instance.Debug("Sisfalla", string.Format("Application.StartupPath: {0}", Application.StartupPath));
            // This returns the usernameLoggedUser.Identity.Name
            cndcLabelInfo.Text = "Introducir nombre de usuario y contraseña ...";//MessageMgr.Instance.GetMessage("INGRESAR_US_CONTRASENA");
            cndcComboDestino.Items.Add("Remoto - CNDC");
            cndcComboDestino.Items.Add("Local - OFFLINE");
            cndcComboDestino.SelectedIndex = 0;
        }

        private bool ValidateUser(string username, string password)
        {
            bool isValid = true;
            try
            {
                if (Sesion.Instancia.ConfigConexion.TipoAutenticacion== CNDC.DAL.TipoAutenticacion.Dominio)
                {
                    isValid = ActiveDirectoryAuthentication.ValidUserInDomanin(username, password);
                }
            }
            catch (Exception e)
            {
                PistaMgr.Instance.Error("SisFalla", e);
            }

            return isValid;
        }

        private void _btnAceptar_Click(object sender, EventArgs e)
        {
            string username = TextBoxUsuario.Text.Trim ();
            string password = TextBoxPassword.Text.Trim ();
            bool usuarioNoValido = false;
            ErrorInicioSession error = ErrorInicioSession.SinError;
            if (ValidateUser(username, password))
            {
                error = Sesion.Instancia.IniciarSesion(username, password);
                if (error == ErrorInicioSession.SinError)
                {
                    RegistradorArchLocal.Instancia.NombreArchivo = Sesion.Instancia.EmpresaActual.Sigla;
                    MessageMgr.Instance.SetConexion(Sesion.Instancia.Conexion);
                    this.Hide();
                    DialogResult = System.Windows.Forms.DialogResult.OK;
                }
                else if (error == ErrorInicioSession.UsuarioNoValido || error == ErrorInicioSession.UsuarioNoValidoParaSisFalla)
                {
                    usuarioNoValido = true;
                }
                else
                {
                    MessageBox.Show(GetMensaje(error));
                    DialogResult = System.Windows.Forms.DialogResult.Cancel;
                }
            }
            else
            {
                usuarioNoValido = true;
                error = ErrorInicioSession.UsuarioNoValido;
            }

            if (usuarioNoValido)
            {
                if (error == ErrorInicioSession.UsuarioNoValido)
                {
                    cndcLabelInfo.Text = "Usuario o contraseña incorrecto...(Intento " + NumIntentos + " de " + MaxIntentos + ")";
                }
                else if (error == ErrorInicioSession.UsuarioNoValidoParaSisFalla)
                {
                    cndcLabelInfo.Text = "Usuario no válido para SisFalla (Intento " + NumIntentos + " de " + MaxIntentos + ")";
                }

                TextBoxPassword.Text = "";
                TextBoxPassword.Focus();
                NumIntentos++;
                if (NumIntentos > MaxIntentos)
                {
                    MessageBox.Show("Tercer intento fallido, se cerrará la aplicación.");//MessageMgr.Instance.GetMessage("TERCER_INTENTO"));
                    TextBoxUsuario.Enabled = false;
                    TextBoxPassword.Enabled = false;
                    DialogResult = System.Windows.Forms.DialogResult.Cancel;
                }
            }
        }

        private string GetMensaje(ErrorInicioSession error)
        {
            string resultado = string.Empty;
            switch (error)
            {
                case ErrorInicioSession.UsuarioNoValido:
                    resultado = MessageMgr.Instance.GetMessage("US_CONTRASENA_INVALIDOS");
                    break;
                case ErrorInicioSession.ErrorConexionBD:
                    resultado = "Error de conexión a Base de Datos";//MessageMgr.Instance.GetMessage("ERROR_CON_BD");
                    break;
                case ErrorInicioSession.OtroError:
                    resultado = MessageMgr.Instance.GetMessage("ERROR_INICIO_SESION");
                    break;
            }
            return resultado;
        }

        private void _btnCancelar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void _cmbConectarDesde_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (_cmbConectarDesde.SelectedIndex)
            {
                case 0:
                    Sesion.Instancia.ConfigConexion.TipoAutenticacion = CNDC.DAL.TipoAutenticacion.BaseDatos;
                    TextBoxUsuario.Text = string.Empty;
                    break;
                case 1:
                    Sesion.Instancia.ConfigConexion.TipoAutenticacion = CNDC.DAL.TipoAutenticacion.Dominio;
                    TextBoxUsuario.Text = System.Security.Principal.WindowsIdentity.GetCurrent().Name;
                    break;
            }
        }
    }
}
