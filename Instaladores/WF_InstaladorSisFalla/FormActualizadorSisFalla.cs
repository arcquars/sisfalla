using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
using System.IO;

namespace InstaladorSisFallaBeta
{
    public partial class FormActualizadorSisFalla : Form
    {
        string strDestino = "c:\\InstaladorQ";
        public FormActualizadorSisFalla()
        {
            InitializeComponent();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                Process proceso = new Process();
                proceso.StartInfo.FileName = "GUIA INSTALACION - SISFALLA V2 0.pdf";
                proceso.Start();
            }
            catch (Exception)
            {
                MessageBox.Show("Error al cargar la Guía de Instalación. Es posible que no tenga instalado un lector de archivos en formato PDF.");
            }
        }

        private void _btnInstalarEsquema_Click(object sender, EventArgs e)
        {
            _lblMensaje.Text = "Preparando archivos para la instalación...";
            Application.DoEvents();

            string tmpPath = Path.GetTempPath();
            DirectoryInfo origen = new DirectoryInfo(Path.Combine(Application.StartupPath, "Esquema"));
            DirectoryInfo destino = new DirectoryInfo(strDestino);
            WF_InstaladorSisFalla.Form1.CopyAll(origen, destino);
            
            Process proceso = new Process();
            proceso.StartInfo.FileName = Path.Combine(strDestino, "Import.bat");
            proceso.EnableRaisingEvents = true;
            proceso.Start();
            proceso.WaitForExit();
        }

        private void _btnInstalarSisFalla_Click(object sender, EventArgs e)
        {
            _lblMensaje.Text = "Iniciando instalación " + _lblSisFalla.Text;
            Application.DoEvents();
            Process proceso = new Process();
            proceso.StartInfo.FileName = Path.Combine(Application.StartupPath, "Instalador\\SisFalla\\SisFallaSetup.msi");
            proceso.EnableRaisingEvents = true;
            proceso.Start();
            proceso.WaitForExit();
        }
    }
}
