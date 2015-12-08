using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CNDC.BaseForms;
using MC;

namespace MedicionComercialUI
{
    public partial class CtrlVisorDatosLectura : QuantumBaseControl
    {
        public CtrlVisorDatosLectura()
        {
            InitializeComponent();
        }

        public void Visualizar(long codPuntoMedicion, DateTime desde, DateTime hasta)
        {
            DataTable tabla = OraDalMC_LecturaDetalleMgr.Instancia.GetDatos(codPuntoMedicion, desde, hasta);
            Dictionary<long, string> magnitudesElectricas = GetMagnitudesElectricas(tabla);
            DataTable tablaVisualizacion = new DataTable();
            DataColumn colFechaHora = new DataColumn("Hora", typeof(string));
            tablaVisualizacion.Columns.Add(colFechaHora);
            foreach (KeyValuePair<long,string> kv in magnitudesElectricas)
            {
                DataColumn col = new DataColumn(kv.Value, typeof(double));
                tablaVisualizacion.Columns.Add(col);
            }

            DataRow destino = null;
            foreach (DataRow origen in tabla.Rows)
            {
                string hora = ((DateTime)origen["pk_fecha"]).ToString("dd/MMM/yyyy") + " " + origen["hora_intervalo"];
                if (destino == null || hora != (string)destino["hora"])
                {
                    destino = tablaVisualizacion.NewRow();
                    destino["Hora"] = hora;
                    tablaVisualizacion.Rows.Add(destino);
                }

                destino[(string)origen["nombre_magnitud_elec"]] = origen["valor"];
            }

            _dgvDatosLectura.DataSource = tablaVisualizacion;
        }

        private Dictionary<long, string> GetMagnitudesElectricas(DataTable tabla)
        {
            Dictionary<long, string> resultado = new Dictionary<long, string>();
            foreach (DataRow r in tabla.Rows)
            {
                resultado[(long)r["pk_cod_magnitud_elec"]] = (string)r["nombre_magnitud_elec"];
            }
            return resultado;
        }
    }
}
