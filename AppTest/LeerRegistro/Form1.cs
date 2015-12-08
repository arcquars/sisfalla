using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.Win32;

namespace LeerRegistro
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void _btnLeer_Click(object sender, EventArgs e)
        {
            RegistryKey regKeyAppRoot = Registry.LocalMachine.OpenSubKey(_txtLlave.Text);
            label2.Text = regKeyAppRoot.GetValue("ORACLE_HOME").ToString();//(string)regKeyAppRoot.GetValue("ORACLE_HOME");
        }
    }
}
