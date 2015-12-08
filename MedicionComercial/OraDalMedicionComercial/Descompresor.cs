using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ionic.Zip;

namespace MC
{
    public class Descompresor
    {
        private string _origen;
        private string _destino;

        public event EventHandler DescompresionFinalizada;

        public string Destino
        { get { return _destino; } }

        public string Origen
        { get { return _origen; } }

        public bool Descomprimir(string origen, string destino)
        {
            bool resultado = true;
            _origen = origen;
            _destino = destino;
            try
            {
                ZipFile zip = ZipFile.Read(_origen);
                zip.ExtractProgress += new EventHandler<ExtractProgressEventArgs>(zip_ExtractProgress);
                zip.ExtractAll(_destino);
            }
            catch (Exception ex)
            {
                resultado = false;
                //Guardar pista
            }
            return resultado;
        }

        void zip_ExtractProgress(object sender, ExtractProgressEventArgs e)
        {
            if (e.EventType == ZipProgressEventType.Extracting_AfterExtractAll)
            {
                OnDescompresionFinalizada();
            }
        }

        private void OnDescompresionFinalizada()
        {
            if (DescompresionFinalizada != null)
            {
                DescompresionFinalizada(this, EventArgs.Empty);
            }
        }
    }
}
