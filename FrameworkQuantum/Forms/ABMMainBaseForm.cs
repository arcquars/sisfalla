using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace CNDC.BaseForms
{
    public partial class ABMMainBaseForm : BaseForm
    {
        public ABMMainBaseForm()
        {
            InitializeComponent();
        }

        public void SetStatus(string status)
        {
            _tsLblStatus.Text = status;
        }

        private void _btnInsertar_Click(object sender, EventArgs e)
        {
            OnNew();
        }

        private void _btnDarBaja_Click(object sender, EventArgs e)
        {
            OnDisable();
        }

        private void _btnEditar_Click(object sender, EventArgs e)
        {
            OnEdit();
        }

        private void _btnEliminar_Click(object sender, EventArgs e)
        {
            OnDelete();
        }

        private void _btnRecargar_Click(object sender, EventArgs e)
        {
            OnReload();
        }

        protected void SetData(DataTable tabla)
        {
            _bindingSource.DataSource = tabla;
            _grid.DataSource = _bindingSource;
        }

        protected virtual void OnNew()
        {
        }

        protected virtual void OnDisable()
        {
        }

        protected virtual void OnEdit()
        {
        }

        protected virtual void OnDelete()
        {
        }

        protected virtual void OnReload()
        {
        }
    }
}
