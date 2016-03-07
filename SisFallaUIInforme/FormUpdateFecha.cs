using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CNDC.BLL;

using CNDC.ExceptionHandlerLib;
namespace SISFALLA
{
    public partial class FormUpdateFecha : Form
    {
        public FormUpdateFecha()
        {
            InitializeComponent();
        }

        public FormUpdateFecha(DateTime fecha, long regFalla)
        {
            InitializeComponent();
            this.fecha = fecha;
            this.regFalla = regFalla;
            this.dtp_fecha.Value = fecha;
            this.dtp_fecha.CustomFormat = Sesion.FORMATO_FECHA;

            //this._txtFechaHoraFalla.Value = fecha;
            
        }

        private void btn_cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_grabar_Click(object sender, EventArgs e)
        {
            //Console.WriteLine("fff:: "+ dtp_fecha.Value);
            this.fecha = dtp_fecha.Value;
            ModeloSisFalla.ModeloMgr.Instancia.RegFallaMgr.UpdateFecInicio(regFalla, dtp_fecha.Value);
            this.Close();
        }

        public DateTime getFecha()
        {
            return this.fecha;
        }

        private void _txtFechaHoraFalla_TextChanged(object sender, EventArgs e)
        {
            //_errorProvider.SetError(_txtFechaHoraFalla, string.Empty);
            lblError.Text = string.Empty;
        }

        private void _txtFechaHoraFalla_Validating(object sender, CancelEventArgs e)
        {

            //_errorProvider.SetError(_txtFechaHoraFalla, string.Empty);
            lblError.Text = string.Empty;
            if (_txtFechaHoraFalla.EsFechaValida())
            {
                if (_txtFechaHoraFalla.Value > DateTime.Now)
                {
                    //_errorProvider.SetError(_txtFechaHoraFalla, MessageMgr.Instance.GetMessage("NO_FECHA_POSTERIOR"));
                    lblError.Text = MessageMgr.Instance.GetMessage("NO_FECHA_POSTERIOR");
                    e.Cancel = true;
                }
                else if ((DateTime.Now - _txtFechaHoraFalla.Value).TotalDays > 365)
                {
                    //_errorProvider.SetError(_txtFechaHoraFalla, MessageMgr.Instance.GetMessage("FECHA_HORA_NO_VALIDO"));
                    lblError.Text = MessageMgr.Instance.GetMessage("FECHA_HORA_NO_VALIDO");
                    e.Cancel = true;
                }
            }
            else
            {
                //_errorProvider.SetError(_txtFechaHoraFalla, MessageMgr.Instance.GetMessage("FECHA_HORA_NO_VALIDO"));
                lblError.Text = MessageMgr.Instance.GetMessage("FECHA_HORA_NO_VALIDO");
                e.Cancel = true;
            }
            
        }

    }
}
