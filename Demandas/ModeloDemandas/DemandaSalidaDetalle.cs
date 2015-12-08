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
    public class DemandaSalidaDetalle : ObjetoDeNegocio
    {
        public const string NOMBRE_TABLA = "F_DM_R_DEMANDA_SALIDA_DETALLE";

        public const string C_PK_DEMANDA_SALIDA_DETALLE = "PK_DEMANDA_SALIDA_DETALLE";
        public const string C_FK_DEMANDA_SALIDA_MAESTRO = "FK_DEMANDA_SALIDA_MAESTRO";
        public const string C_FK_NODO_DEMANDA = "FK_NODO_DEMANDA";
        public const string C_SEC_LOG = "SEC_LOG";

        public long PkDemandaSalidaDetalle { get; set; }
        public long FkDemandaSalidaMaestro { get; set; }
        public long FkNodoDemanda { get; set; }
        public long SecLog { get; set; }

        public DemandaSalidaDetalle() { }

        public DemandaSalidaDetalle(DataRow dataRow)
        {
            PkDemandaSalidaDetalle = GetValor<long>(dataRow[C_PK_DEMANDA_SALIDA_DETALLE]);
            FkDemandaSalidaMaestro = GetValor<long>(dataRow[C_FK_DEMANDA_SALIDA_MAESTRO]);
            FkNodoDemanda = GetValor<long>(dataRow[C_FK_NODO_DEMANDA]);
            SecLog = GetValor<long>(dataRow[C_SEC_LOG]);
        }

        public void Llenar(DataRow dataRow)
        {
            dataRow[C_PK_DEMANDA_SALIDA_DETALLE] = PkDemandaSalidaDetalle;
            dataRow[C_FK_DEMANDA_SALIDA_MAESTRO] = FkDemandaSalidaMaestro;
            dataRow[C_FK_NODO_DEMANDA] = FkNodoDemanda;
            dataRow[C_SEC_LOG] = SecLog;
        }
    }

    public interface IDemandaSalidaDetalleMgr
    {
        void Guardar(DemandaSalidaDetalle obj);
        DataTable GetTabla();
        BindingList<DemandaSalidaDetalle> GetLista();
    }
}
