using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CNDC.BLL;

namespace ModeloSisFalla
{
     [Serializable]
    public class AnalisisFalla : ObjetoDeNegocio
    {
        public const string NOMBRE_TABLA = "F_GF_DOC_ANALISIS";
        public int PkCodFalla { get; set; }
        public long PkDCodTipoInforme { get; set; }
        public long PkOrigenInforme{ get; set; }
        public string Causa { get; set; }
        public string Observaciones { get; set; }
        public string DesconexionComponente { get; set; }
        public AnalisisFalla()
        {
            int i = 0;
        }
    }

    public interface IAnalisisFallaMgr
    {
        AnalisisFalla GetAnalisis(int numFalla, long codTipoInforme, long pkCodOrigen);
        string GetNombreArchivo(int numFalla, long codTipoInforme);
        byte[] GetArchivo(int numFalla, long codTipoInforme);
        void Guardar(int numFalla, long codTipoInforme,long pkOrigenInforme, string nomArchivo);
        void Guardar(AnalisisFalla analisis);
        string DescargarInformeAnalisis(int pkCodFalla, long codTipoInforme);

        void Copiar(int numFalla, long codTipoInformeAnterior,  long pkOrigenInforme);
    }
}
