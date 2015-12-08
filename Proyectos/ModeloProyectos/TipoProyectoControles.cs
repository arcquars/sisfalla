using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.ComponentModel;
using CNDC.BLL;

namespace ModeloProyectos
{
    [Serializable]
    public class TipoProyectoControles : ObjetoDeNegocio
    {
        public const string NOMBRE_TABLA = "F_PR_TIPO_PROY_CONTROLES";

        public const string C_PK_TIPO_PROY_CONTROLES = "PK_TIPO_PROY_CONTROLES";
        public const string C_D_COD_TIPO_PROYECTO = "D_COD_TIPO_PROYECTO";
        public const string C_NOMBRE_CONTROL = "NOMBRE_CONTROL";
        public const string C_ORDEN = "ORDEN";

        public long PkTipoProyControles { get; set; }
        public long DCodTipoProyecto { get; set; }
        public string NombreControl { get; set; }
        public short Orden { get; set; }

        public TipoProyectoControles() { }

        public TipoProyectoControles(DataRow dataRow)
        {
            PkTipoProyControles = GetValor<long>(dataRow[C_PK_TIPO_PROY_CONTROLES]);
            DCodTipoProyecto = GetValor<long>(dataRow[C_D_COD_TIPO_PROYECTO]);
            NombreControl = GetValor<string>(dataRow[C_NOMBRE_CONTROL]);
            Orden = GetValor<short>(dataRow[C_ORDEN]);
        }

        public void Llenar(DataRow dataRow)
        {
            dataRow[C_PK_TIPO_PROY_CONTROLES] = PkTipoProyControles;
            dataRow[C_D_COD_TIPO_PROYECTO] = DCodTipoProyecto;
            dataRow[C_NOMBRE_CONTROL] = NombreControl;
            dataRow[C_ORDEN] = Orden;
        }

        public override void Leer(DataRow dataRow)
        {
            PkTipoProyControles = GetValor<long>(dataRow[C_PK_TIPO_PROY_CONTROLES]);
            DCodTipoProyecto = GetValor<long>(dataRow[C_D_COD_TIPO_PROYECTO]);
            NombreControl = GetValor<string>(dataRow[C_NOMBRE_CONTROL]);
            Orden = GetValor<short>(dataRow[C_ORDEN]);
        }
    }

    public interface ITipoProyectoControlesMgr
    {
        void Guardar(TipoProyectoControles obj);
        DataTable GetTabla();
        BindingList<TipoProyectoControles> GetLista();
    }
}
