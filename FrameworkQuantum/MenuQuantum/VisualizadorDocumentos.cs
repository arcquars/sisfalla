using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;

namespace MenuQuantum
{
    public class VisualizadorDocumentos : IFuncionalidad
    {
        public ParametrosFuncionalidad Parametros { get; set; }

        public void Ejecutar()
        {
            string documento = Parametros.DiccionarioParametros.ContainsKey("DOCUMENTO") ? Parametros.DiccionarioParametros["DOCUMENTO"] : string.Empty;

            if (string.IsNullOrEmpty(documento))
            {

            }
            else
            {
                try
                {
                    Process proceso = new Process();
                    proceso.StartInfo.FileName = Path.Combine(Application.StartupPath, documento);
                    proceso.Start();
                }
                catch (Exception)
                {
                    MessageBox.Show("Error al cargar el Documento.");
                }
            }
        }
    }
}
