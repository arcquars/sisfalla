using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using CNDC.BLL;
using System.ComponentModel;

namespace ModeloComponentes
{
    public class Nodo
    {
        public const string NOMBRE_TABLA = "F_AC_NODO";

        public const string C_PK_COD_NODO = "PK_COD_NODO";
        public const string C_PK_NIVEL_TENSION = "PK_NIVEL_TENSION";
        public const string C_D_COD_AREA = "D_COD_AREA";
        public const string C_SIGLA_NODO = "SIGLA_NODO";
        public const string C_NOMBRE_NODO = "NOMBRE_NODO";
        public const string C_DESCRIPCION_NODO = "DESCRIPCION_NODO";
        public const string C_D_COD_ESTADO = "D_COD_ESTADO";
        public const string C_SEC_LOG = "SEC_LOG";
        public const string C_SINC_VER = "SINC_VER";
        public const string C_FECHA_INGRESO = "FECHA_INGRESO";
        public const string C_FECHA_SALIDA = "FECHA_SALIDA";

        public long PkCodNodo { get; set; }
        public long PkNivelTension { get; set; }
        public long DCodArea { get; set; }
        public string SiglaNodo { get; set; }
        public string NombreNodo { get; set; }
        public string DescripcionNodo { get; set; }
        public string DCodEstado { get; set; }
        public long SecLog { get; set; }
        public long SincVer { get; set; }
        public DateTime FechaIngreso { get; set; }
        public DateTime FechaSalida { get; set; }

        public Nodo()
        { }
        public Nodo(DataRow row)
        {
            PkCodNodo = (long)row[C_PK_COD_NODO];
            PkNivelTension = (long)row[C_PK_NIVEL_TENSION];
            DCodArea = (long)row[C_D_COD_AREA];
            SiglaNodo = (string)row[C_SIGLA_NODO];
            NombreNodo = (string)row[C_NOMBRE_NODO];
            DescripcionNodo = (string)row[C_DESCRIPCION_NODO];
            DCodEstado = (string)row[C_D_COD_ESTADO];
            SecLog = (long)row[C_SEC_LOG];
            SincVer = (long)row[C_SINC_VER];
            FechaIngreso = ObjetoDeNegocio.GetValor<DateTime>(row[C_FECHA_INGRESO]);
            FechaSalida = ObjetoDeNegocio.GetValor<DateTime>(row[C_FECHA_SALIDA]);
            
        }
    }

    public interface INodoMgr
    {
        DataTable GetTabla();
        DataTable GetNodoCompleto();
        Nodo GetNodo(long pkCodNodo);
        DataTable GetNodoCompleto(long p);
        long GetPkCodNodo(string idUNodo);
        string GetIdUniversal(long pkCodNodo);
        bool IdUniversalExiste(string idUniversal);
        long Guardar(ModeloComponentes.Componente c);
        bool Eliminar(ModeloComponentes.Componente c);
        bool NodoValidoEnRango(string idUniversal, DateTime fechaIngreso, DateTime FechaSalida);
        bool NodoConRelacion(string idUniversal, DateTime fechaIngreso, DateTime FechaSalida);
    }
}
