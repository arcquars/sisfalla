﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CNDC.BaseForms;
using MenuQuantum;
using MC;

namespace MedicionComercialUI
{
    public partial class FormDatosLectura : BaseForm, IFuncionalidad
    {
        MC_PuntoMedicion _puntoMedicionSeleccionado = null;
        DataTable _tablaPuntoMedicion;
        DataRow _rowSeleccionado;

        public FormDatosLectura()
        {
            InitializeComponent();
        }
        public ParametrosFuncionalidad Parametros { get; set; }

        public void Ejecutar()
        {
            ShowDialog();
        }

        protected override void OnLoad(EventArgs e)
        {
            _tablaPuntoMedicion = OraDalMC_PuntoMedicionMgr.Instancia.GetTabla();
            _dgvPuntosMedicion.DataSource = _tablaPuntoMedicion;
            //_dgvPuntosMedicion.AsegurarColumnas();
            base.OnLoad(e);
        }

        private void _dgvPuntosMedicion_SelectionChanged(object sender, EventArgs e)
        {
            if (_dgvPuntosMedicion.SelectedRows.Count > 0)
            {
                _rowSeleccionado = (_dgvPuntosMedicion.SelectedRows[0].DataBoundItem as DataRowView).Row;
                _puntoMedicionSeleccionado = new MC_PuntoMedicion(_rowSeleccionado);
                _ctrlVisorDatosLectura.Visualizar(_puntoMedicionSeleccionado.PkCodPtoMedicion, _dtpDesde.Value.Date, _dtpHasta.Value.Date);
            }
        }
    }
}
