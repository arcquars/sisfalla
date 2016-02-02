using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CNDC.BLL;

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
    }
}
