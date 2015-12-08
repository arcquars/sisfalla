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
    public class DatosDemandaNodo : ObjetoDeNegocio
    {
        public const string NOMBRE_TABLA = "F_DM_DATOS_DEMADA_NODO";

        public const string C_PK_DATOS_DEMADA_NODO = "PK_DATOS_DEMADA_NODO";
        public const string C_ANIO = "ANIO";
        public const string C_ENERO = "ENERO";
        public const string C_FEBRERO = "FEBRERO";
        public const string C_MARZO = "MARZO";
        public const string C_ABRIL = "ABRIL";
        public const string C_MAYO = "MAYO";
        public const string C_JUNIO = "JUNIO";
        public const string C_JULIO = "JULIO";
        public const string C_AGOSTO = "AGOSTO";
        public const string C_SEPTIEMBRE = "SEPTIEMBRE";
        public const string C_OCTUBRE = "OCTUBRE";
        public const string C_NOVIEMBRE = "NOVIEMBRE";
        public const string C_DICIEMBRE = "DICIEMBRE";
        public const string C_FK_PERSONA_NODO = "FK_PERSONA_NODO";
        public const string C_SEC_LOG = "SEC_LOG";
        public const string C_D_COD_CATEGORIA_DATO = "D_COD_CATEGORIA_DATO";
        public const string C_FK_DEMANDA_SALIDA_MAESTRO = "FK_DEMANDA_SALIDA_MAESTRO";

        public long PkDatosDemadaNodo { get; set; }
        public long Anio { get; set; }
        public double Enero { get; set; }
        public double Febrero { get; set; }
        public double Marzo { get; set; }
        public double Abril { get; set; }
        public double Mayo { get; set; }
        public double Junio { get; set; }
        public double Julio { get; set; }
        public double Agosto { get; set; }
        public double Septiembre { get; set; }
        public double Octubre { get; set; }
        public double Noviembre { get; set; }
        public double Diciembre { get; set; }
        public long FkPersonaNodo { get; set; }
        public long SecLog { get; set; }
        public long DCodCategoriaDato { get; set; }
        public long FkDemandaSalidaMaestro { get; set; }
       
        public DatosDemandaNodo() { }

        public DatosDemandaNodo(DataRow dataRow)
        {
            PkDatosDemadaNodo = GetValor<long>(dataRow[C_PK_DATOS_DEMADA_NODO]);
            Anio = GetValor<long>(dataRow[C_ANIO]);
            Enero = GetValor<double>(dataRow[C_ENERO]);
            Febrero = GetValor<double>(dataRow[C_FEBRERO]);
            Marzo = GetValor<double>(dataRow[C_MARZO]);
            Abril = GetValor<double>(dataRow[C_ABRIL]);
            Mayo = GetValor<double>(dataRow[C_MAYO]);
            Junio = GetValor<double>(dataRow[C_JUNIO]);
            Julio = GetValor<double>(dataRow[C_JULIO]);
            Agosto = GetValor<double>(dataRow[C_AGOSTO]);
            Septiembre = GetValor<double>(dataRow[C_SEPTIEMBRE]);
            Octubre = GetValor<double>(dataRow[C_OCTUBRE]);
            Noviembre = GetValor<double>(dataRow[C_NOVIEMBRE]);
            Diciembre = GetValor<double>(dataRow[C_DICIEMBRE]);
            FkPersonaNodo = GetValor<long>(dataRow[C_FK_PERSONA_NODO]);
            SecLog = GetValor<long>(dataRow[C_SEC_LOG]);
            DCodCategoriaDato = GetValor<long>(dataRow[C_D_COD_CATEGORIA_DATO]);
            FkDemandaSalidaMaestro = GetValor<long>(dataRow[C_FK_DEMANDA_SALIDA_MAESTRO]);
        }

        public void Llenar(DataRow dataRow)
        {
            dataRow[C_PK_DATOS_DEMADA_NODO] = PkDatosDemadaNodo;
            dataRow[C_ANIO] = Anio;
            dataRow[C_ENERO] = Enero;
            dataRow[C_FEBRERO] = Febrero;
            dataRow[C_MARZO] = Marzo;
            dataRow[C_ABRIL] = Abril;
            dataRow[C_MAYO] = Mayo;
            dataRow[C_JUNIO] = Junio;
            dataRow[C_JULIO] = Julio;
            dataRow[C_AGOSTO] = Agosto;
            dataRow[C_SEPTIEMBRE] = Septiembre;
            dataRow[C_OCTUBRE] = Octubre;
            dataRow[C_NOVIEMBRE] = Noviembre;
            dataRow[C_DICIEMBRE] = Diciembre;
            dataRow[C_FK_PERSONA_NODO] = FkPersonaNodo;
            dataRow[C_SEC_LOG] = SecLog;
            dataRow[C_D_COD_CATEGORIA_DATO] = DCodCategoriaDato;
            dataRow[C_FK_DEMANDA_SALIDA_MAESTRO] = FkDemandaSalidaMaestro;
        }

        public override void Leer(DataRow dataRow)
        {
            PkDatosDemadaNodo = GetValor<long>(dataRow[C_PK_DATOS_DEMADA_NODO]);
            Anio = GetValor<long>(dataRow[C_ANIO]);
            Enero = GetValor<double>(dataRow[C_ENERO]);
            Febrero = GetValor<double>(dataRow[C_FEBRERO]);
            Marzo = GetValor<double>(dataRow[C_MARZO]);
            Abril = GetValor<double>(dataRow[C_ABRIL]);
            Mayo = GetValor<double>(dataRow[C_MAYO]);
            Junio = GetValor<double>(dataRow[C_JUNIO]);
            Julio = GetValor<double>(dataRow[C_JULIO]);
            Agosto = GetValor<double>(dataRow[C_AGOSTO]);
            Septiembre = GetValor<double>(dataRow[C_SEPTIEMBRE]);
            Octubre = GetValor<double>(dataRow[C_OCTUBRE]);
            Noviembre = GetValor<double>(dataRow[C_NOVIEMBRE]);
            Diciembre = GetValor<double>(dataRow[C_DICIEMBRE]);
            FkPersonaNodo = GetValor<long>(dataRow[C_FK_PERSONA_NODO]);
            SecLog = GetValor<long>(dataRow[C_SEC_LOG]);
            DCodCategoriaDato = GetValor<long>(dataRow[C_D_COD_CATEGORIA_DATO]);
            FkDemandaSalidaMaestro = GetValor<long>(dataRow[C_FK_DEMANDA_SALIDA_MAESTRO]);
        }

      
    }

    public interface IDatosDemandaNodoMgr
    {
        void Guardar(DatosDemandaNodo obj);
        DataTable GetTabla();
        BindingList<DatosDemandaNodo> GetLista();
    }
}
