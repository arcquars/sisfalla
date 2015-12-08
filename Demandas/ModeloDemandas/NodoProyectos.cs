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
    public class NodoProyectos : ObjetoDeNegocio
    {
        public const string NOMBRE_TABLA = "F_DM_NODO_PROYECTOS";

        public const string C_PK_NODO_PROYECTOS = "PK_NODO_PROYECTOS";
        public const string C_NIVEL_TENSION = "NIVEL_TENSION";
        public const string C_D_COD_AREA = "D_COD_AREA";
        public const string C_SIGLA_NODO = "SIGLA_NODO";
        public const string C_NOMBRE_NODO = "NOMBRE_NODO";
        public const string C_DESCRIPCION_NODO = "DESCRIPCION_NODO";
        public const string C_D_COD_ESTADO = "D_COD_ESTADO";
        public const string C_SEC_LOG = "SEC_LOG";
        public const string C_FECHA_INGRESO = "FECHA_INGRESO";
        public const string C_FECHA_SALIDA = "FECHA_SALIDA";
        public const string C_D_COD_TIPO_NODO = "D_COD_TIPO_NODO";

        public long PkNodoProyectos { get; set; }
        public float NivelTension { get; set; }
        public long DCodArea { get; set; }
        public string SiglaNodo { get; set; }
        public string NombreNodo { get; set; }
        public string DescripcionNodo { get; set; }
        public string DCodEstado { get; set; }
        public long SecLog { get; set; }
        public DateTime FechaIngreso { get; set; }
        public DateTime FechaSalida { get; set; }
        public long DCodTipoNodo { get; set; }

        public NodoProyectos() { }

        public NodoProyectos(DataRow dataRow)
        {
            PkNodoProyectos = GetValor<long>(dataRow[C_PK_NODO_PROYECTOS]);
            NivelTension = GetValor<float>(dataRow[C_NIVEL_TENSION]);
            DCodArea = GetValor<long>(dataRow[C_D_COD_AREA]);
            SiglaNodo = GetValor<string>(dataRow[C_SIGLA_NODO]);
            NombreNodo = GetValor<string>(dataRow[C_NOMBRE_NODO]);
            DescripcionNodo = GetValor<string>(dataRow[C_DESCRIPCION_NODO]);
            DCodEstado = GetValor<string>(dataRow[C_D_COD_ESTADO]);
            SecLog = GetValor<long>(dataRow[C_SEC_LOG]);
            FechaIngreso = GetValor<DateTime>(dataRow[C_FECHA_INGRESO]);
            FechaSalida = GetValor<DateTime>(dataRow[C_FECHA_SALIDA]);
            DCodTipoNodo = GetValor<long>(dataRow[C_D_COD_TIPO_NODO]);
        }

        public void Llenar(DataRow dataRow)
        {
            dataRow[C_PK_NODO_PROYECTOS] = PkNodoProyectos;
            dataRow[C_NIVEL_TENSION] = NivelTension;
            dataRow[C_D_COD_AREA] = DCodArea;
            dataRow[C_SIGLA_NODO] = SiglaNodo;
            dataRow[C_NOMBRE_NODO] = NombreNodo;
            dataRow[C_DESCRIPCION_NODO] = DescripcionNodo;
            dataRow[C_D_COD_ESTADO] = DCodEstado;
            dataRow[C_SEC_LOG] = SecLog;
            dataRow[C_FECHA_INGRESO] = FechaIngreso;
            dataRow[C_FECHA_SALIDA] = FechaSalida;
            dataRow[C_D_COD_TIPO_NODO] = DCodTipoNodo;
        }

        public override void Leer(DataRow dataRow)
        {
            PkNodoProyectos = GetValor<long>(dataRow[C_PK_NODO_PROYECTOS]);
            NivelTension = GetValor<float>(dataRow[C_NIVEL_TENSION]);
            DCodArea = GetValor<long>(dataRow[C_D_COD_AREA]);
            SiglaNodo = GetValor<string>(dataRow[C_SIGLA_NODO]);
            NombreNodo = GetValor<string>(dataRow[C_NOMBRE_NODO]);
            DescripcionNodo = GetValor<string>(dataRow[C_DESCRIPCION_NODO]);
            DCodEstado = GetValor<string>(dataRow[C_D_COD_ESTADO]);
            SecLog = GetValor<long>(dataRow[C_SEC_LOG]);
            FechaIngreso = GetValor<DateTime>(dataRow[C_FECHA_INGRESO]);
            FechaSalida = GetValor<DateTime>(dataRow[C_FECHA_SALIDA]);
            DCodTipoNodo = GetValor<long>(dataRow[C_D_COD_TIPO_NODO]);
        }

        public override string ToString()
        {
            return NombreNodo+" - "+ SiglaNodo;
        }
    }

    public interface INodoProyectosMgr
    {
        void Guardar(NodoProyectos obj);
        DataTable GetTabla();
        BindingList<NodoProyectos> GetLista();
    }
}
