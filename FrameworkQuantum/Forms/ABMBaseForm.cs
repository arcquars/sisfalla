using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Controles;
using CNDC.BLL;

namespace CNDC.BaseForms
{
    public partial class ABMBaseForm : BaseForm
    {
        protected bool _preguntarCancelar = false;
        private bool _cancelando = false;
        public ABMBaseForm()
        {
            InitializeComponent();
            _botones["_btnGuardar"] = _btnGuardar;
            _botones["_btnCancelar"] = _btnCancelar;
        }

        protected bool Cancelando
        { get { return _cancelando; } }

        private void _btnGuardar_Click(object sender, EventArgs e)
        {
            Guardar();
        }

        private void _btnCancelar_Click(object sender, EventArgs e)
        {
            Cancelar();
        }

        protected virtual bool Guardar()
        {
            return true;
        }

        private void Cancelar()
        {
            _cancelando = true;
            if (_preguntarCancelar)
            {
                DialogResult r = MessageBox.Show("¿ Seguro que desea cancelar la operación ?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (r == System.Windows.Forms.DialogResult.Yes)
                {
                    DialogResult = System.Windows.Forms.DialogResult.Cancel;
                }
            }
            else
            {
                DialogResult = System.Windows.Forms.DialogResult.Cancel;
            }
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            Guardar();
        }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            Cancelar();
        }

        Dictionary<string, ToolStripButton> _botones = new Dictionary<string, ToolStripButton>();
        protected virtual void AgregarOpcionesToolStrip(Image image, string name, string text, EventHandler onClick)
        {
            AgregarOpcionesToolStrip(image, name, text, onClick, ToolStripItemAlignment.Left);
        }

        protected virtual void AgregarOpcionesToolStrip(Image image, string name, string text, EventHandler onClick,ToolStripItemAlignment alignment)
        {
            ToolStripButton toolStripButton = new ToolStripButton();
            toolStripButton.Image = image;
            toolStripButton.Name = name;
            toolStripButton.Text = text;
            toolStripButton.Alignment = alignment;
            toolStripButton.Click += new EventHandler(onClick);
            this._toolStrip.Items.Add(toolStripButton);
            _botones[name] = toolStripButton;
        }

        protected virtual void SetEnable(string nombre, bool valor)
        {
            if (_botones.ContainsKey(nombre))
            {
                _botones[nombre].Enabled = valor;
            }
        }

        protected void SetTextoBoton(string nombreBoton, string nuevoText)
        {
            if (_botones.ContainsKey(nombreBoton))
            {
                _botones[nombreBoton].Text = nuevoText;
            }
        }

        protected override void SetAyudaEnLinea(string ayuda)
        {
            base.SetAyudaEnLinea(ayuda);
            _tStripAyuda.Text = ayuda;
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            if (!_cancelando && HayCambiosSinGuardar())
            {
                DialogResult r =MessageBox.Show("Desea guardar las modificaciones ?", "Hay modificaciones sin guardar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (r == DialogResult.Yes)
                {
                    if (!Guardar())
                    {
                        MessageBox.Show("Hay algunos errorres que deben corregirse antes de guardar.");
                        e.Cancel = true;
                    }
                }
            }
            base.OnClosing(e);
        }

        protected virtual bool HayCambiosSinGuardar()
        {
            return false;
        }
    }
}
