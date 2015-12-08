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
    public class DatosDemandaPersonaBloque : ObjetoDeNegocio
    {
        public const string NOMBRE_TABLA = "F_DM_DATOS_DEM_PERSONA_BOLQUE";

        public const string C_PK_DATOS_DEM_PERSONA_BOLQUE = "PK_DATOS_DEM_PERSONA_BOLQUE";
        public const string C_ANIO = "ANIO";
        public const string C_NUMERO_POR_ANIO = "NUMERO_POR_ANIO";
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
        public const string C_FK_PERSONA = "FK_PERSONA";
        public const string C_SEC_LOG = "SEC_LOG";

        public long PkDatosDemPersonaBolque { get; set; }
        public int Anio { get; set; }
        public short NumeroPorAnio { get; set; }
        public decimal Enero { get; set; }
        public decimal Febrero { get; set; }
        public decimal Marzo { get; set; }
        public decimal Abril { get; set; }
        public decimal Mayo { get; set; }
        public decimal Junio { get; set; }
        public decimal Julio { get; set; }
        public decimal Agosto { get; set; }
        public decimal Septiembre { get; set; }
        public decimal Octubre { get; set; }
        public decimal Noviembre { get; set; }
        public decimal Diciembre { get; set; }
        public long FkPersona { get; set; }
        public long SecLog { get; set; }

        public DatosDemandaPersonaBloque() { }

        public DatosDemandaPersonaBloque(DataRow dataRow)
        {
            PkDatosDemPersonaBolque = GetValor<long>(dataRow[C_PK_DATOS_DEM_PERSONA_BOLQUE]);
            Anio = GetValor<int>(dataRow[C_ANIO]);
            NumeroPorAnio = GetValor<short>(dataRow[C_NUMERO_POR_ANIO]);
            Enero = GetValor<decimal>(dataRow[C_ENERO]);
            Febrero = GetValor<decimal>(dataRow[C_FEBRERO]);
            Marzo = GetValor<decimal>(dataRow[C_MARZO]);
            Abril = GetValor<decimal>(dataRow[C_ABRIL]);
            Mayo = GetValor<decimal>(dataRow[C_MAYO]);
            Junio = GetValor<decimal>(dataRow[C_JUNIO]);
            Julio = GetValor<decimal>(dataRow[C_JULIO]);
            Agosto = GetValor<decimal>(dataRow[C_AGOSTO]);
            Septiembre = GetValor<decimal>(dataRow[C_SEPTIEMBRE]);
            Octubre = GetValor<decimal>(dataRow[C_OCTUBRE]);
            Noviembre = GetValor<decimal>(dataRow[C_NOVIEMBRE]);
            Diciembre = GetValor<decimal>(dataRow[C_DICIEMBRE]);
            FkPersona = GetValor<long>(dataRow[C_FK_PERSONA]);
            SecLog = GetValor<long>(dataRow[C_SEC_LOG]);
        }

        public void Llenar(DataRow dataRow)
        {
            dataRow[C_PK_DATOS_DEM_PERSONA_BOLQUE] = PkDatosDemPersonaBolque;
            dataRow[C_ANIO] = Anio;
            dataRow[C_NUMERO_POR_ANIO] = NumeroPorAnio;
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
            dataRow[C_FK_PERSONA] = FkPersona;
            dataRow[C_SEC_LOG] = SecLog;
        }

        public override void Leer(DataRow dataRow)
        {
            PkDatosDemPersonaBolque = GetValor<long>(dataRow[C_PK_DATOS_DEM_PERSONA_BOLQUE]);
            Anio = GetValor<int>(dataRow[C_ANIO]);
            NumeroPorAnio = GetValor<short>(dataRow[C_NUMERO_POR_ANIO]);
            Enero = GetValor<decimal>(dataRow[C_ENERO]);
            Febrero = GetValor<decimal>(dataRow[C_FEBRERO]);
            Marzo = GetValor<decimal>(dataRow[C_MARZO]);
            Abril = GetValor<decimal>(dataRow[C_ABRIL]);
            Mayo = GetValor<decimal>(dataRow[C_MAYO]);
            Junio = GetValor<decimal>(dataRow[C_JUNIO]);
            Julio = GetValor<decimal>(dataRow[C_JULIO]);
            Agosto = GetValor<decimal>(dataRow[C_AGOSTO]);
            Septiembre = GetValor<decimal>(dataRow[C_SEPTIEMBRE]);
            Octubre = GetValor<decimal>(dataRow[C_OCTUBRE]);
            Noviembre = GetValor<decimal>(dataRow[C_NOVIEMBRE]);
            Diciembre = GetValor<decimal>(dataRow[C_DICIEMBRE]);
            FkPersona = GetValor<long>(dataRow[C_FK_PERSONA]);
            SecLog = GetValor<long>(dataRow[C_SEC_LOG]);
        }
    }

    public interface IDatosDemandaPersonaBloqueMgr
    {
        void Guardar(DatosDemandaPersonaBloque obj);
        DataTable GetTabla();
        BindingList<DatosDemandaPersonaBloque> GetLista();
    }
}
