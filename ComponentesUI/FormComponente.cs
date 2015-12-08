using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CNDC.BaseForms;
using MenuQuantum;
using DevExpress.XtraTab;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid;
using CNDC.UtilesComunes;
using ModeloComponentes;


namespace ComponentesUI
{
    
    public partial class FormComponente : BaseForm, IFuncionalidad
    {
        public   Dictionary<long, List<IControl>> dicControles=new Dictionary<long,List<IControl>>();
        public long _tipoComponenteActual=0;
        public List<IControl> _listaverificacion;
        public FormComponente()
        {
            InitializeComponent();
            AddControlsToToolStrip();
        }

        private DateTimePicker _dtpfecha;
        private void AddControlsToToolStrip()
        { 

             _dtpfecha= new DateTimePicker();
            _dtpfecha.Width =250;
            ToolStripControlHost hostDtpFecha = new ToolStripControlHost (_dtpfecha ) ;
            _cndcTS.Items.Add (hostDtpFecha );
        
        }

        public ParametrosFuncionalidad Parametros
        {
            get;
            set;
            
        }

        public void Ejecutar()
        {
            ShowDialog();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
        }

        private void _ctrlPanelTipoComponente_NodoClick(object sender, NodoClickEventArgs e)
        {
            LimpiarTab();
            _gdControl.DataSource = null;
            if (e.EstadoComponente == 1)
            {
                _gdControl.DataSource = OraDalComponentes.ComponenteMgr.Instancia.GetComponentePorTipo(e.TipoComponente);
               //////// CamposVisiblesGrilla();
                _tipoComponenteActual = e.TipoComponente;
               
            }
         }


        private void DibujarTabs(long tipoComponente)
        {
            dicControles.Clear();
            DataTable tTabs = new DataTable();
            tTabs = OraDalComponentes.ControlesMgr.Instancia.GetControles(tipoComponente);
            DataView dataViewControles = new DataView(tTabs);
            List<IControl> listaControles = new List<IControl>();

            foreach (DataRowView dataRowCurrent in dataViewControles)
            {
                XtraTabPage nuevaPagina = new XtraTabPage();
                string _libreria = dataRowCurrent["ENSAMBLADO"].ToString().Trim();
                string _control = dataRowCurrent["CONTROL"].ToString().Trim(); 
                _xTabDatos.TabPages.Add(nuevaPagina);
                nuevaPagina.Text=dataRowCurrent["DESCRIPCION_CONTROL"].ToString().Trim();
                nuevaPagina.Name = dataRowCurrent["DESCRIPCION_CONTROL"].ToString().Trim();
                Control c= Instanciador.Instancia.CrearInstancia<Control>(_libreria, _control);
                nuevaPagina.Controls.Add(c);
                listaControles.Add(c as IControl);
                (c as CtrlBaseComponente).AccionEjecutada += new EventHandler<AccionEjecutadaEventArgs>(FormComponente_AccionEjecutada);
               
            }
            dicControles.Add(tipoComponente, listaControles);
        }

        void FormComponente_AccionEjecutada(object sender, AccionEjecutadaEventArgs e)
        {
            if (e.AccionEjecutada == Accion.Editar)
            {
                _gdControl.Enabled = false;
                _ctrlPanelTipoComponente.Enabled = false;

            }
            else
            {
                _gdControl.Enabled = true;
                _ctrlPanelTipoComponente.Enabled = true;

            }
        }

        private void LimpiarTab()
        {
            XtraTabPage _paginaToRemove = new XtraTabPage();
            int _numeroTabs=_xTabDatos.TabPages.Count;
            _xTabDatos.TabPages.Clear();
           
        }

        private void CamposVisiblesGrilla()
        {
            //gridView1.Columns[0].Visible = false;
            gridView1.Columns[3].Visible = false;
            gridView1.Columns[4].Visible = false;
            gridView1.Columns[7].Visible = false;
            gridView1.Columns[9].Visible = false;
            gridView1.Columns[10].Visible = false;
            gridView1.Columns[11].Visible = false;
            gridView1.Columns[13].Visible = false;
            gridView1.Columns[14].Visible = false;
            gridView1.Columns[1].Caption = "COMPONENTE";
            gridView1.Columns[2].Caption = "DESCRIPCION";
            gridView1.Columns[5].Caption = "F.INGRESO";
            gridView1.Columns[6].Caption = "F.SALIDA";
            gridView1.Columns[8].Caption = "PROPIETARIO";
            gridView1.Columns[12].Caption = "C.UNIVERSAL";
        }

        private void MostrarControles(Componente componenteSel)
        {
            long indice = componenteSel.DTipoComponente;
         
                List<IControl> listaControles = new List<IControl>();
                listaControles = dicControles[indice];
                foreach (IControl c in listaControles)
                {
                    c.Visualizar(componenteSel);
                }
        }

        
        private void gridView1_SelectionChanged(object sender, DevExpress.Data.SelectionChangedEventArgs e)
        {
            if (sender != null)
            {
                Componente _componenteSeleccionado;
                if (gridView1.SelectedRowsCount > 0)
                {
                    DataRow r = gridView1.GetDataRow(gridView1.FocusedRowHandle);
                    _componenteSeleccionado = new Componente(r);
                    if (_tipoComponenteActual != _componenteSeleccionado.DTipoComponente)
                    {
                          DibujarTabs(_componenteSeleccionado.DTipoComponente);
                    }
                    MostrarControles(_componenteSeleccionado);
                    _tipoComponenteActual = _componenteSeleccionado.DTipoComponente;
                }
            }
        }



        private void _xTabDatos_SelectedPageChanging(object sender, TabPageChangingEventArgs e)
        {
            if (_xTabDatos.SelectedTabPage != null)
            {
                CtrlBaseComponente actual = (CtrlBaseComponente)_xTabDatos.SelectedTabPage.Controls[0];
                if (actual._enEdicion)
                {
                    e.Cancel = true;
       
                }
            }
        }

        private void _tSBNuevo_Click(object sender, EventArgs e)
        {
            FormNuevoComponente frm = new FormNuevoComponente();
            frm.ShowDialog();
        }

        private void tSBBaja_Click(object sender, EventArgs e)
        {
            if (gridView1.SelectedRowsCount > 0)
            {
                Componente _cParaEliminar = new Componente(gridView1.GetDataRow(gridView1.FocusedRowHandle));
                DialogResult resultado = MessageBox.Show("Desea Dar de Baja al Componente: \n" + "Codigo:     " + _cParaEliminar.NombreComponente + "\n" + "Descripcion: " + _cParaEliminar.Descripcion, "Dar de Baja", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (resultado == DialogResult.OK)
                {
                    MessageBox.Show("Componente Eliminado");
                }

            }
            else
            {
                FormBajaComponente frm = new FormBajaComponente();
                frm.ShowDialog();
            }
        }

        private void _ctrlPanelTipoComponente_GrupoClick(object sender, NodoClickEventArgs e)
        {
           // MessageBox.Show(e.TipoComponente.ToString());
            LimpiarTab();
            _gdControl.DataSource = null;
            
        }

       
      

        
    }
}
