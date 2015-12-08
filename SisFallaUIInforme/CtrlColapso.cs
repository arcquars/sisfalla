using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ModeloSisFalla;
using CNDC.Dominios;
using CNDC.BLL;

namespace SISFALLA
{
    public partial class CtrlColapso : UserControl, ICtrlParteInformeFalla
    {
        private List<Colapso> _listaColapso;
        private BindingList<ItemGridColapso> _listaItems;
        private BindingList<DefDominio> _listaDominios;
        private RegFalla _regFalla;

        public CtrlColapso()
        {
            InitializeComponent();
        }

        private bool _soloLectura;
        public bool SoloLectura
        {
            get { return _soloLectura; }
            set
            {
                _soloLectura = value;
                cndcToolStrip1.Enabled = !_soloLectura;
                _rbtnParcial.Enabled = !_soloLectura;
                _rbtnTotal.Enabled = !_soloLectura;
                _dgvZonas.ReadOnly = _soloLectura;
            }
        }

        private void VisualizarColapso()
        {
            _listaDominios = ModeloMgr.Instancia.DefDominioMgr.GetListaDominio(Dominios.D_COD_ZONA);
            _regFalla = ModeloMgr.Instancia.RegFallaMgr.GetFalla(_informe.PkCodFalla);
            _listaColapso = ModeloMgr.Instancia.ColapsoMgr.GetLista(_regFalla.CodFalla);

            VisualizarItems();

            _rbtnTotal.Checked = _regFalla.CodColapso == (long)D_COD_COLAPSO.TOTAL;
            _rbtnParcial.Checked = !_rbtnTotal.Checked;
            _dgvZonas.Enabled = !_rbtnTotal.Checked;
        }

        private void VisualizarItems()
        {
            _listaItems = new BindingList<ItemGridColapso>();
            foreach (var d in _listaDominios)
            {
                ItemGridColapso itemGrid = new ItemGridColapso(d);
                _listaItems.Add(itemGrid);
                foreach (var c in _listaColapso)
                {
                    if (c.PkDCodZona == d.CodDominio)
                    {
                        itemGrid.Seleccionado = true;
                    }
                }
            }
            _dgvZonas.DataSource = _listaItems;
        }

        public bool Guardar()
        {
            _dgvZonas.EndEdit();
            _listaColapso.Clear();
            foreach (var item in _listaItems)
            {
                if (item.Seleccionado)
                {
                    _listaColapso.Add(new Colapso() { PkDCodZona = item._dominio.CodDominio });
                }
            }

            D_COD_COLAPSO codColapso;
            if (_rbtnTotal.Checked)
            {
                codColapso = D_COD_COLAPSO.TOTAL;
            }
            else
            {
                codColapso = D_COD_COLAPSO.PARCIAL;
            }

            ModeloMgr.Instancia.RegFallaMgr.GuardarCodColapso(_regFalla.CodFalla, codColapso);
            ModeloMgr.Instancia.ColapsoMgr.Guardar(_listaColapso, _regFalla.CodFalla);

            return true;
        } 
        
        public bool HayCambiosSinGuardar()
        {
            return false;
        }

        private void _rbtnTotal_Click(object sender, EventArgs e)
        {
            if (_rbtnTotal.Checked)
            {
                foreach (var item in _listaItems)
                {
                    item.Seleccionado = true;
                }
            }
            else
            {
                VisualizarItems();
            }
            _dgvZonas.Enabled = !_rbtnTotal.Checked;
        }

        private void _tbtnGuardar_Click(object sender, EventArgs e)
        {
            Guardar();
        }

        InformeFalla _informe;
        public InformeFalla Informe
        {
            set
            {
                _informe = value;
                VisualizarColapso();
            }
        }

        public void RefrescarDatos()
        {         
        }
    }

    public class ItemGridColapso
    {
        internal DefDominio _dominio;
        public bool Seleccionado { get; set; }
        public ItemGridColapso(DefDominio d)
        {
            _dominio = d;
        }

        public string Zona
        {
            get { return _dominio.Descripcion; }
        }
    }
}