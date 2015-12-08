using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CNDC.DAL;
using Oracle.DataAccess.Client;
using CNDC.ExceptionHandlerLib;

namespace ExceptionHandlerTest
{
    public partial class Form1 : Form, IMessageViewer
    {
        public Form1()
        {
            ConnexionOracleMgr.Instancia.AsegurarConexion();
            ExceptionHandler.Instance.MessageViewer = this;
            InitializeComponent();
        }

        private void _btnGuardar_Click(object sender, EventArgs e)
        {
            OracleCommand cmd = ConnexionOracleMgr.Instancia.CrearCommand();
            cmd.CommandText = "INSERT INTO IVANDEMO(ID,NAME,DESCRIPTION) VALUES(:p_ID,:p_NAME,:p_DESCRIPTION)";
            try
            {
                cmd.Parameters.Add(new OracleParameter("p_ID", OracleDbType.Varchar2, _txtId.Text, ParameterDirection.Input));
                cmd.Parameters.Add(new OracleParameter("p_NAME", OracleDbType.Varchar2, _txtName.Text, ParameterDirection.Input));
                cmd.Parameters.Add(new OracleParameter("p_DESCRIPTION", OracleDbType.Varchar2, _txtDescripcion.Text, ParameterDirection.Input));
                cmd.BindByName = true;
                int num = cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                ExceptionHandler.Instance.Handle("DEMO", ex);
            }
        }

        public void Show(string msg)
        {
            MessageBox.Show(msg);
        }

        public void Show(string msg, Exception ex)
        {
            MessageBox.Show(msg + Environment.NewLine + ex.ToString());
        }
    }
}
