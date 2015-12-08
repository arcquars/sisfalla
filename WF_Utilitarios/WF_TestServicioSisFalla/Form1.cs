using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WF_TestServicioSisFalla
{
    public partial class Form1 : Form
    {
        int contador = 0;
        public Form1()
        {
            InitializeComponent();
            List<Usuario> usuarios = new List<Usuario>();
            usuarios.Add(new Usuario() { Nombre = "cbe01", Contrasena = "@CBE-5233" });
            usuarios.Add(new Usuario() { Nombre = "gch01", Contrasena = "@GCH-2763" });
            usuarios.Add(new Usuario() { Nombre = "cor01", Contrasena = "@COR-8293" });
            usuarios.Add(new Usuario() { Nombre = "vhe01", Contrasena = "@VHE-2312" });
            usuarios.Add(new Usuario() { Nombre = "cbb01", Contrasena = "@CBB-5209" });
            usuarios.Add(new Usuario() { Nombre = "ere01", Contrasena = "@ERE-1357" });
            usuarios.Add(new Usuario() { Nombre = "hib01", Contrasena = "@HIB-8151" });
            usuarios.Add(new Usuario() { Nombre = "syn01", Contrasena = "@SYN-8118" });
            usuarios.Add(new Usuario() { Nombre = "sdb01", Contrasena = "@SDB-1025" });
            usuarios.Add(new Usuario() { Nombre = "gbe01", Contrasena = "@GBE-7465" });
            usuarios.Add(new Usuario() { Nombre = "ena01", Contrasena = "@ENA-0126" });

            usuarios.Add(new Usuario() { Nombre = "tde01", Contrasena = "@TDE-5033" });
            usuarios.Add(new Usuario() { Nombre = "isa01", Contrasena = "@ISA-1469" });
            usuarios.Add(new Usuario() { Nombre = "tes01", Contrasena = "@TES-3512" });
            usuarios.Add(new Usuario() { Nombre = "end01", Contrasena = "@END-0467" });

            usuarios.Add(new Usuario() { Nombre = "cre01", Contrasena = "@CRE-5262" });
            usuarios.Add(new Usuario() { Nombre = "epz01", Contrasena = "@EPZ-3004" });
            usuarios.Add(new Usuario() { Nombre = "elf01", Contrasena = "@ELF-9245" });
            usuarios.Add(new Usuario() { Nombre = "efo01", Contrasena = "@EFO-3081" });
            usuarios.Add(new Usuario() { Nombre = "ces01", Contrasena = "@CES-5153" });
            usuarios.Add(new Usuario() { Nombre = "sep01", Contrasena = "@SEP-1730" });
            usuarios.Add(new Usuario() { Nombre = "end02", Contrasena = "@END-4917" });

            usuarios.Add(new Usuario() { Nombre = "emi01", Contrasena = "@EMI-2023" });
            usuarios.Add(new Usuario() { Nombre = "cmv01", Contrasena = "@CMV-6802" });
            usuarios.Add(new Usuario() { Nombre = "cob01", Contrasena = "@COB-1533" });
            usuarios.Add(new Usuario() { Nombre = "msc01", Contrasena = "@MSC-2681" });
            _cmbUsuario.DataSource = usuarios;
            _cmbUsuario.DisplayMember = "Nombre";
            _cmbUsuario.ValueMember = "Contrasena";
        }

        private void _btnAdTab_Click(object sender, EventArgs e)
        {
            contador++;
            //TabPage p = new TabPage("Tab " + contador);
            TabPage p = new TabPage(_cmbUsuario.Text);
            CtrlTestTabla ctrl = new CtrlTestTabla();
            ctrl.SetCredenciales(_cmbUsuario.Text, (string)_cmbUsuario.SelectedValue);
            //ctrl.SetCredenciales(_txtUsuario.Text, _txtContrasena.Text);
            ctrl.Dock = DockStyle.Fill;
            p.Controls.Add(ctrl);
            _tabControl.TabPages.Add(p);
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            foreach (TabPage t in _tabControl.TabPages)
            {
                (t.Controls[0] as CtrlTestTabla).CerrarSesion();
            }
        }
    }

    class Usuario
    {
        public string Nombre { get; set; }
        public string Contrasena { get; set; }
    }
}
