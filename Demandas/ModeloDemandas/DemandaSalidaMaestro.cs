using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.ComponentModel;
using CNDC.BLL;

namespace ModeloDemandas
{
    [Serializable]
    public class DemandaSalidaMaestro : ObjetoDeNegocio
    {
        public const string NOMBRE_TABLA = "F_DM_DEMANDA_SALIDA_MAESTRO";

        public const string C_PK_DEMANDA_SALIDA_MAESTRO = "PK_DEMANDA_SALIDA_MAESTRO";
        public const string C_FK_NODO_SALIDA = "FK_NODO_SALIDA";
        public const string C_D_COD_TIPO_NODO_SALIDA = "D_COD_TIPO_NODO_SALIDA";
        public const string C_FK_NODO_DEMANDA = "FK_NODO_DEMANDA";
        public const string C_FK_PERSONA_NODO = "FK_PERSONA_NODO";
        public const string C_SEG_LOG = "SEC_LOG";

        public long PkDemandaSalidaMaestro { get; set; }
        public long FkNodoSalida { get; set; }
        public long DCodTipoNodoSalida { get; set; }
        public long FkNodoDemanda { get; set; }
        public long FkPersonaNodo { get; set; }
        public long SecLog { get; set; }

        public DemandaSalidaMaestro() { }

        public DemandaSalidaMaestro(DataRow dataRow)
        {
            PkDemandaSalidaMaestro = GetValor<long>(dataRow[C_PK_DEMANDA_SALIDA_MAESTRO]);
            FkNodoSalida = GetValor<long>(dataRow[C_FK_NODO_SALIDA]);
            DCodTipoNodoSalida = GetValor<long>(dataRow[C_D_COD_TIPO_NODO_SALIDA]);
            FkNodoDemanda = GetValor<long>(dataRow[C_FK_NODO_DEMANDA]);
            FkPersonaNodo = GetValor<long>(dataRow[C_FK_PERSONA_NODO]);
            SecLog = GetValor<long>(dataRow[C_SEG_LOG]);
        }

        public void Llenar(DataRow dataRow)
        {
            dataRow[C_PK_DEMANDA_SALIDA_MAESTRO] = PkDemandaSalidaMaestro;
            dataRow[C_FK_NODO_SALIDA] = FkNodoSalida;
            dataRow[C_D_COD_TIPO_NODO_SALIDA] = DCodTipoNodoSalida;
            dataRow[C_FK_NODO_DEMANDA] = FkNodoDemanda;
            dataRow[C_FK_PERSONA_NODO] = FkPersonaNodo;
            dataRow[C_SEG_LOG] = SecLog;
        }
    }

    public interface IDemandaSalidaMaestroMgr
    {
        void Guardar(DemandaSalidaMaestro obj);
        DataTable GetTabla();
        BindingList<DemandaSalidaMaestro> GetLista();
    }
}
