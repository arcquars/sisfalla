using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using CNDC.BLL;

namespace ModeloSisFalla
{
    public class P_GF_Configuracion :  ObjetoDeNegocio
    {
        public const string C_PK_COD_PERSONA = "PK_COD_PERSONA";
        public const string C_PK_COD_PARAMETRO = "PK_COD_PARAMETRO";
        public const string C_VALOR_CONFIGURACION = "VALOR_CONFIGURACION";

        public const string NOMBRE_TABLA = "P_GF_CONFIG";

        public P_GF_Configuracion(DataRow row)
        {
            CodPersona = GetValor<long>(row[C_PK_COD_PERSONA]);
            CodDominio = GetValor<long>(row[C_PK_COD_PARAMETRO]);
            Valor = GetValor<string>(row[C_VALOR_CONFIGURACION]);
        }

        public P_GF_Configuracion()
        {

        }
        public long CodPersona { get; set; }
        public long CodDominio { get; set; }
        public string Valor { get; set; }
    }

    public interface I_P_GF_ConfiguracionMgr
    {
        DataTable GetConfiguraciones(long pkCodPersonaSeleccionada);
        void Guardar(P_GF_Configuracion _configuracion);
    }
}
