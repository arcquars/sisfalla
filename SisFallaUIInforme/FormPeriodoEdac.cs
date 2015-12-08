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
using MenuQuantum;
using SisFallaUIInforme;
using CNDC.BLL;

namespace SISFALLA
{
    public partial class FormPeriodoEdac : BaseForm, IFuncionalidad
    {
        string _fecha = string.Empty;
        PeriodoEdac _periodoEdac = new PeriodoEdac();
        bool _editable = false;
        bool _modificado = false;
        DateTime _fechaCambio;
        DateTime _nuevafechaEdac;

        public FormPeriodoEdac()
        {
            InitializeComponent();            
        }

        private void IniciarFormulario()
        {
            if (Sesion.Instancia.RolSIN == "CNDC")
            {
                CargarUltimaFecha();
            }
        }

        private void CargarUltimaFecha()
        {
            string fechaMaxima = ModeloMgr.Instancia.OperacionAlimentadorMgr.GetUltimoEdac();
            _errorProvider.Clear();
            if (fechaMaxima != string.Empty)
            {
                _fecha = fechaMaxima;
                AsignarPeriodo();
                IniciarAgentes();
                IniciarGrilla();
                this.MaximizeBox = false;
                this.MinimizeBox = false;
            }
            else
            {
                MessageBox.Show("No existe periodo EDAC Base para generar Nuevo Periodo, contacte al Administrador del Sistema","Inconveniente",MessageBoxButtons.OK,MessageBoxIcon.Error);
                AnularFuncionalidad();
            }
        }

        private void AnularFuncionalidad()
        {
            cndcToolStrip1.Enabled = false;
            cndcGroupBox1.Enabled = false;
            cndcGroupBox2.Enabled = false;
            throw new NotImplementedException();
        }

        private void IniciarGrilla()
        {
            _cmbAgentes.SelectedItem = 0;
            CargarEdac();
        }

        private void AsignarPeriodo()
        {
            _FechaVigencia.Text = _fecha;
            _FechaVigencia.Enabled = false;
            _panelEdac.Enabled = true;
            _btnGuardar.Enabled = false;
            _btnGenerarNuevo.Enabled = true;
            _btnCancelar.Enabled = false;
            EstadoModificaciones();
        }

        private void EstadoModificaciones()
        {
            if ((_FechaVigencia.Value.AddDays(4) < DateTime.Today))
            {
                _CndcTSEdac.Enabled = false;
            }
        }

        private void IniciarAgentes()
        {
            _cmbAgentes.DisplayMember = "SIGLA_AGENTE";
            _cmbAgentes.ValueMember = "COD_AGENTE";
            _cmbAgentes.DataSource = ModeloMgr.Instancia.OperacionAlimentadorMgr.GetAgentesDeEdac(_FechaVigencia.Value);
            _cmbAgentes.SelectedIndex = 0;           
        }

        private void CargarEdac() 
        {

            if (_cmbAgentes.SelectedValue != null)
            {
                CargaGrillas();
            }
        }

        private void _cmbAgentes_SelectedIndexChanged(object sender, EventArgs e)
        {
            CargarEdac();
        }

        private void CargaGrillas()
        {
            CargarSubfrecuencia(_cmbAgentes.Text);
            CargarRestitucion(_cmbAgentes.Text);
            CargarGradiente(_cmbAgentes.Text);
            ActivaModificacion();
        }

        private void CargarSubfrecuencia(string Agente)
        {
            _dgvEdacSubFrecuencia.VirtualMode = false;
            LlenarDatos(Agente, _dgvEdacSubFrecuencia, 100);
            LlenarListaEtapas(100, _dgvEdacSubFrecuencia);
            LlenarListaAlimentadores(Agente, 100, _dgvEdacSubFrecuencia);
            OcultarColumnaFila(_dgvEdacSubFrecuencia);
        }

        private void CargarRestitucion(string Agente)
        {
            _dgvEdacRestitucion.VirtualMode = false;
            LlenarDatos(Agente, _dgvEdacRestitucion, 200);
            LlenarListaEtapas(200, _dgvEdacRestitucion);
            LlenarListaAlimentadores(Agente, 200, _dgvEdacRestitucion);
            OcultarColumnaFila(_dgvEdacRestitucion);
        }

        private void CargarGradiente(string Agente)
        {
            _dgvEdacGradiente.VirtualMode = false;
            LlenarDatos(Agente, _dgvEdacGradiente, 300);
            LlenarListaEtapas(300, _dgvEdacGradiente);
            LlenarListaAlimentadores(Agente, 300, _dgvEdacGradiente);
            OcultarColumnaFila(_dgvEdacGradiente);
        }

        private void OcultarColumnaFila(Controles.CNDCGridView Grilla)
        {
            if (Grilla.Columns["Agente"] != null)
            {
                Grilla.Columns["Agente"].HeaderText = "Agente";
                Grilla.Columns["Agente"].ReadOnly = true;
            }
            if (Grilla.Columns["Fila"] != null)
            {
                Grilla.Columns["Fila"].Visible = false;
            }
            Grilla.ReadOnly = true;
            Grilla.AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(248)))), ((int)(((byte)(251))))); ;
            Grilla.MultiSelect=false;
            Grilla.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

        }

        private void LlenarListaEtapas(int Categoria,DataGridView Grilla)
        {
            
            Grilla.Columns.Remove(Grilla.Columns["CodigoEdac"]);
            
            DataGridViewComboBoxColumn _cmbEtapa = new DataGridViewComboBoxColumn();
            _cmbEtapa.Name = "CodigoEdac";
            _cmbEtapa.HeaderText = "Etapa | Frec.  |  Tiempo";
            _cmbEtapa.DataPropertyName = "CodigoEdac";
            _cmbEtapa.DisplayMember = "DESC_EDAC";
            _cmbEtapa.ValueMember = "COD_EDAC";
            _cmbEtapa.Width = 180;
            _cmbEtapa.DataSource = ModeloMgr.Instancia.OperacionAlimentadorMgr.GetEtapasDeEdac(Categoria);

            Grilla.Columns.Add(_cmbEtapa);
        }

        private void LlenarListaAlimentadores(String Agente, int Categoria, DataGridView Grilla)
        {

            Grilla.Columns.Remove(Grilla.Columns["CodigoAlimentador"]);
            
            DataGridViewComboBoxColumn _cmbAlimentador = new DataGridViewComboBoxColumn();
            _cmbAlimentador.Name = "CodigoAlimentador";
            _cmbAlimentador.HeaderText = "Alimentador";
            _cmbAlimentador.DataPropertyName = "CodigoAlimentador";
            _cmbAlimentador.DisplayMember = "DESC_ALI";
            _cmbAlimentador.ValueMember = "COD_ALI";
            _cmbAlimentador.Width = 233;

            _cmbAlimentador.DataSource = ModeloMgr.Instancia.OperacionAlimentadorMgr.GetAlimentadoresEdac(Agente);

            Grilla.Columns.Add(_cmbAlimentador);

        }

        private void LlenarDatos(string Agente,DataGridView Grilla, int Categoria)
        {
            DataTable tablaEdac = ModeloMgr.Instancia.OperacionAlimentadorMgr.GetEtapasConEdac(Agente, Categoria,_fecha);
            Grilla.DataSource = tablaEdac;
        }

        private void dvgComboSubfrecuencia_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (_dgvEdacSubFrecuencia.Columns[e.ColumnIndex].Name == "CodigoEdac")
            {
                ModificarCelda(_dgvEdacSubFrecuencia, e);

            }
            if (_dgvEdacSubFrecuencia.Columns[e.ColumnIndex].Name == "CodigoAlimentador")
            {
                ModificarCelda(_dgvEdacSubFrecuencia, e);
            }
        }

        private void dvgComboRestitucion_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (_dgvEdacRestitucion.Columns[e.ColumnIndex].Name == "CodigoEdac")
            {
                ModificarCelda(_dgvEdacRestitucion, e);
            }
            if (_dgvEdacRestitucion.Columns[e.ColumnIndex].Name == "CodigoAlimentador")
            {
                ModificarCelda(_dgvEdacRestitucion, e);
            }
        }

        private void dvgComboGradiente_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (_dgvEdacGradiente.Columns[e.ColumnIndex].Name == "CodigoEdac")
            {
                ModificarCelda(_dgvEdacGradiente, e);
            }
            if (_dgvEdacGradiente.Columns[e.ColumnIndex].Name == "CodigoAlimentador")
            {
                ModificarCelda(_dgvEdacGradiente, e);
            }
        }

        private void FilaSeleccionada(Controles.CNDCGridView dgv)
        {
            if (dgv.SelectedRows.Count == 1)
            {
                if (dgv.CurrentRow != null)
                {
                    DataGridViewRow row = dgv.Rows[dgv.CurrentRow.Index];
                    _periodoEdac.Rowid = row.Cells["Fila"].Value.ToString();
                }
            }
        }

        private void ModificarCelda(Controles.CNDCGridView dgv, DataGridViewCellEventArgs e)
        {
            if (_editable)
            {
                _editable = false;
                dgv.ReadOnly = true;
            }
        }

        private void Grilla_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            Controles.CNDCGridView dgv = (Controles.CNDCGridView)sender;
            DataGridViewRow row = dgv.Rows[dgv.CurrentRow.Index];
            //DataGridViewComboBoxCell combo = _dgv.Rows[e.RowIndex].Cells[e.ColumnIndex] as DataGridViewComboBoxCell;
            DataGridViewComboBoxCell comboEtapa = dgv.Rows[e.RowIndex].Cells["CodigoEdac"] as DataGridViewComboBoxCell;
            DataGridViewComboBoxCell comboAlimentador = dgv.Rows[e.RowIndex].Cells["CodigoAlimentador"] as DataGridViewComboBoxCell;


            if ((dgv.Columns[e.ColumnIndex].Name == "CodigoEdac" || dgv.Columns[e.ColumnIndex].Name == "CodigoAlimentador"))
            {

                if (!_editable) return;
                string codigoEdac = row.Cells["CodigoEdac"].FormattedValue.ToString();
                string codigoAlimentador = row.Cells["CodigoAlimentador"].FormattedValue.ToString();
                if ((!e.FormattedValue.Equals(codigoEdac) && dgv.Columns[e.ColumnIndex].Name == "CodigoEdac") || (!e.FormattedValue.Equals(codigoAlimentador) && dgv.Columns[e.ColumnIndex].Name == "CodigoAlimentador"))
                {
                    string Fila = dgv.Rows[e.RowIndex].Cells["Fila"].Value.ToString();
                    if (dgv.Columns[e.ColumnIndex].Name == "CodigoEdac")
                    {
                        long etapa = ModeloMgr.Instancia.OperacionAlimentadorMgr.GetEtapasDeEdac(e.FormattedValue.ToString());
                        _periodoEdac.PkCodEdac = etapa;
                        _periodoEdac.PKCodAlimentador = long.Parse(comboAlimentador.Value.ToString());
                    }
                    else if (dgv.Columns[e.ColumnIndex].Name == "CodigoAlimentador")
                    {
                        DataTable dato = ModeloMgr.Instancia.OperacionAlimentadorMgr.GetAlimentadoresEdac(_cmbAgentes.Text);
                        DataRow[] registro = dato.Select("DESC_ALI LIKE '" + e.FormattedValue.ToString() + "'");
                        long alimentador = long.Parse(registro[0]["COD_ALI"].ToString());
                        _periodoEdac.PkCodEdac = long.Parse(comboEtapa.Value.ToString());
                        _periodoEdac.PKCodAlimentador = alimentador;
                    }                  

                    _periodoEdac.Rowid = Fila;
                    _periodoEdac.FechaInicioVigencia = _fecha;
                    if (DatosValidos())
                    {
                        ModeloMgr.Instancia.OperacionAlimentadorMgr.ActualizarPeriodoEdac(_periodoEdac);
                        e.Cancel = false;
                        ActivaModificacion();
                        _modificado = true;
                    }
                    else
                    {
                        MessageBox.Show("El Periodo actual contiene El Alimentador y la Etapa seleccionados, tecla ESC para dejar sin cambios", "Advertencia",MessageBoxButtons.OK,MessageBoxIcon.Error);
                        e.Cancel = true;
                        //_modificado = false;
                        
                        //comboAlimentador.Value = _comboAlimentadores;
                        //comboEtapa.Value = _comboEtapas;
                    }
                }
            }
        }

        private bool DatosValidos()
        {
            if (ModeloMgr.Instancia.OperacionAlimentadorMgr.ExistePeriodoEdac(_periodoEdac))
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public ParametrosFuncionalidad Parametros
        {
            get; set;
        }

        public void Ejecutar()
        {
            IniciarFormulario();
            ShowDialog();
        }


        private bool Guardar()
        {
            bool resultado = false;
            if (_FechaVigencia.Enabled)
            {
                if (Validar())
                {
                    if (ModeloMgr.Instancia.OperacionAlimentadorMgr.ModificarNuevoPeriodo(_fechaCambio, _nuevafechaEdac) &&
                        ModeloMgr.Instancia.OperacionAlimentadorMgr.CrearNuevoPeriodo(_fechaCambio, _nuevafechaEdac))
                    {

                        //DialogResult = System.Windows.Forms.DialogResult.OK;
                        //Ejecutar();
                        MessageBox.Show("Nueva version del Periodo EDAC creado satisfactoriamente, favor proceder a cambiar Etapas o Alimentadores si es necesario", "Confirmacion", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        IniciarFormulario();
                    }
                    else
                    {
                        MessageBox.Show("No se creo el periodo EDAC correctamente, Notificar al Administrador del Sistema","Inconveniente",MessageBoxButtons.OK, MessageBoxIcon.Error);
                        DialogResult = System.Windows.Forms.DialogResult.Cancel;
                    }
                }
            }
            else
            {
                DialogResult = System.Windows.Forms.DialogResult.OK;
            }
            
            return resultado;
        }

        private bool Validar()
        {
            bool resultado = false;
            _errorProvider.Clear();
            _nuevafechaEdac = _FechaVigencia.Value;
            //DateTime fechaActual = ;
            if ((_nuevafechaEdac >= DateTime.Today) )
            {
                //resultado = true;
                if ((_nuevafechaEdac - _fechaCambio).Days > 0)
                {
                    resultado = true;
                }
                else
                {
                    _errorProvider.SetError(_FechaVigencia, "El periodo debe tener vigencia de por lo menos un dia");
                    _FechaVigencia.Focus();
                }
            }
            else
            {
                _errorProvider.SetError(_FechaVigencia, "La fecha asignada debe ser mayor al valor de la fecha actual");
                _FechaVigencia.Focus();
            }
            return resultado;
        }

        private void BorrarFila(Controles.CNDCGridView Grilla)
        {
            if (MessageBox.Show("Esta Seguro de Eliminar?", "Confirmar Eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                ModeloMgr.Instancia.OperacionAlimentadorMgr.BorrarPeriodoEdac(_periodoEdac);
                Grilla.Rows.RemoveAt(Grilla.CurrentRow.Index);
                Grilla.ClearSelection();
                CargaGrillas();
            }
        }

        private void EditarGrillas()
        {
                if (_tabEtapas.SelectedIndex == 0 && _dgvEdacSubFrecuencia.SelectedRows.Count == 1)
                {
                    EditarGrilla(_dgvEdacSubFrecuencia);
                }
                else if (_tabEtapas.SelectedIndex == 1 && _dgvEdacRestitucion.SelectedRows.Count == 1)
                {
                    EditarGrilla(_dgvEdacRestitucion);
                }
                else if (_tabEtapas.SelectedIndex == 2 && _dgvEdacGradiente.SelectedRows.Count == 1)
                {
                    EditarGrilla(_dgvEdacGradiente);
                }
                cndcToolStrip1.Enabled = false;
        }

        private void EditarGrilla(Controles.CNDCGridView Grilla)
        {
            if (Grilla.SelectedRows.Count == 1)
            {
                Grilla.ReadOnly = false;
                if (Grilla.Columns["Agente"] != null)
                {
                    Grilla.Columns["Agente"].ReadOnly = true;
                }
                DesactivarModificacion();
                _editable = true;
                _modificado = false;
            }
        }

        private void Grilla_SelectionChanged(object sender, EventArgs e)
        {
            Controles.CNDCGridView dgv = (Controles.CNDCGridView)sender;
            if (dgv.SelectedRows.Count == 1)
            {
                FilaSeleccionada(dgv);
            }
        }

        private void Grilla__RowStateChanged(object sender, DataGridViewRowStateChangedEventArgs e)
        {
            Controles.CNDCGridView dgv = (Controles.CNDCGridView)sender;
            if (dgv.CurrentRow != null && _modificado == true)
            {
                CambioEstado(dgv);
            }
        }
/*
        private void Grilla_RowLeave(object sender, DataGridViewCellEventArgs e)
        {
            Controles.CNDCGridView dgv = (Controles.CNDCGridView)sender;
            if (dgv.SelectedRows.Count == 1 && _editable == true)
            {
                CambioEstado(dgv);
            }
        }
  */              

        private void Grilla_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            e.Control.PreviewKeyDown -= Control_PreviewKeyDown; 
            e.Control.PreviewKeyDown += new PreviewKeyDownEventHandler(Control_PreviewKeyDown);
        }

        void Control_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                ActivaModificacion();
                _modificado = true;
            }
        }
        private void CambioEstado(Controles.CNDCGridView dgv)
        {
            OperacionCambioEstado();
            dgv.ReadOnly = true;
        }

        private void OperacionCambioEstado()
        {
            ActivaModificacion();
            
            cndcToolStrip1.Enabled = true;
        }


        private void _btnAdicionar_Click(object sender, EventArgs e)
        {
            DialogResult dr = new DialogResult();
            PeriodoEdac nuevo;
            int Categoria = 0;
            switch (_tabEtapas.SelectedIndex)
            {
                case 0: Categoria = 100;
                    break;
                case 1: Categoria = 200;
                    break;
                case 2: Categoria = 300;
                    break;
                default:
                    break;
            }

            FormNuevoEdac frmNuevo = new FormNuevoEdac();
            frmNuevo.SetPeriodo(Categoria, _cmbAgentes.Text, _fecha);
            dr = frmNuevo.ShowDialog();
            if (dr == DialogResult.OK)
            {
                nuevo = frmNuevo.GetPeriodo();
                CargaGrillas();
            }
            else if (dr == DialogResult.Cancel)
            {
                //MessageBox.Show("User clicked Cancel button");
            }

        }

        private void _btnEditar_Click(object sender, EventArgs e)
        {
            EditarGrillas();
        }

        private void _btnEliminar_Click(object sender, EventArgs e)
        {
            if (_tabEtapas.SelectedIndex == 0 && _dgvEdacSubFrecuencia.CurrentRow != null)
            {
                BorrarFila(_dgvEdacSubFrecuencia);
            }
            if (_tabEtapas.SelectedIndex == 1 && _dgvEdacRestitucion.CurrentRow != null)
            {
                BorrarFila(_dgvEdacRestitucion);
            }
            if (_tabEtapas.SelectedIndex == 2 && _dgvEdacGradiente.CurrentRow != null)
            {
                BorrarFila(_dgvEdacGradiente);
            }
        }


        private void _tabEtapas_SelectedIndexChanged(object sender, EventArgs e)
        {
            CargaGrillas();
        }

        private void ActivaModificacion()
        {
            _btnAdicionar.Enabled = true;
            _btnEditar.Enabled = true;
            _btnEliminar.Enabled = true;
            _cmbAgentes.Enabled = true;
            cndcToolStrip1.Enabled = true;
        }
        private void DesactivarModificacion()
        {
            _btnAdicionar.Enabled = false;
            _btnEliminar.Enabled = false;
            _cmbAgentes.Enabled = false;
            cndcToolStrip1.Enabled = false;
        }

        private void NuevoPeriodo()
        {
            _panelEdac.Enabled = false;
            _FechaVigencia.Enabled = true;
            _fechaCambio = _FechaVigencia.Value;
            _FechaVigencia.Value = _fechaCambio.AddDays(1);
            _btnGuardar.Enabled = true;
            _btnCancelar.Enabled = true;
            _btnGenerarNuevo.Enabled = false;
            _CndcTSEdac.Enabled = true;
        }

        private void _btnGuardar_Click(object sender, EventArgs e)
        {
            Guardar();
        }

        private void _btnGenerarNuevo_Click(object sender, EventArgs e)
        {
            NuevoPeriodo();
        }

        private void _btnCancelar_Click(object sender, EventArgs e)
        {
            IniciarFormulario();
        }





    }
}
