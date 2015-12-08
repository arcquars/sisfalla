using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ActualizadorModulosCliente.ServActualizador;
using System.IO;

namespace ActualizadorModulosCliente
{
    public partial class Form1 : Form
    {
        FormSplash _splash;
        IServActualizacion _servActualizacion;
        Modulo[] _modulos;

        public Form1()
        {
            InitializeComponent();
            _splash = new FormSplash();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            _splash.Show();
            Application.DoEvents();
            _servActualizacion = new ServActualizacionClient();
            _modulos = _servActualizacion.GetModulos();
            _splash.Close();
            VisualizarModulos();
        }

        private void VisualizarModulos()
        {
            Dictionary<string,float> modulosLocales = GetModulosLocales();
            foreach (Modulo m in _modulos)
            {
                if (modulosLocales.ContainsKey(m.NombreModulo))
                {
                    if (m.MaxVersion>modulosLocales[m.NombreModulo])
                    {
                        _lbxModulosActualizar.Items.Add(m.NombreModulo);
                    }
                }
                else
                {
                    _lbxModulosActualizar.Items.Add(m.NombreModulo);
                }
            }
        }

        private Dictionary<string, float> GetModulosLocales()
        {
            Dictionary<string, float> resultado = new Dictionary<string, float>();
            string misDocumentos = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            string directorioModulos = Path.Combine(misDocumentos, "AppsCNDC");
            string[] modulos = Directory.GetDirectories(directorioModulos);

            foreach (string modulo in modulos)
            {
                string archivoVersion = Path.Combine(modulo, "Version.txt");
                float version = 0;
                try
                {
                    StreamReader reader = new StreamReader(archivoVersion);
                    version = float.Parse(reader.ReadLine());
                }
                catch (Exception)
                {
                }
                resultado[modulo] = version;
            }

            return resultado;
        }

        private void _btnActualizar_Click(object sender, EventArgs e)
        {

        }

        
    }
}
