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
    public class SerieHidrologica : ObjetoDeNegocio
    {
        public const string NOMBRE_TABLA = "F_PR_SERIE_HIDROLOGICA";

        public const string C_PK_SERIE_HIDROLOGICA = "PK_SERIE_HIDROLOGICA";
        public const string C_FK_PROYECTO = "FK_PROYECTO";
        public const string C_ANIO = "ANIO";
        public const string C_CAPACIDAD_ENERO = "CAPACIDAD_ENERO";
        public const string C_CAPACIDAD_FEBRERO = "CAPACIDAD_FEBRERO";
        public const string C_CAPACIDAD_MARZO = "CAPACIDAD_MARZO";
        public const string C_CAPACIDAD_ABRIL = "CAPACIDAD_ABRIL";
        public const string C_CAPACIDAD_MAYO = "CAPACIDAD_MAYO";
        public const string C_CAPACIDAD_JUNIO = "CAPACIDAD_JUNIO";
        public const string C_CAPACIDAD_JULIO = "CAPACIDAD_JULIO";
        public const string C_CAPACIDAD_AGOSTO = "CAPACIDAD_AGOSTO";
        public const string C_CAPACIDAD_SEPTIEMBRE = "CAPACIDAD_SEPTIEMBRE";
        public const string C_CAPACIDAD_OCTUBRE = "CAPACIDAD_OCTUBRE";
        public const string C_CAPACIDAD_NOVIEMBRE = "CAPACIDAD_NOVIEMBRE";
        public const string C_CAPACIDAD_DICIEMBRE = "CAPACIDAD_DICIEMBRE";
        public const string C_FECHA_REGISTRO = "FECHA_REGISTRO";
        public const string C_SEC_LOG = "SEC_LOG";

        public long PkSerieHidrologica { get; set; }
        public long FkProyecto { get; set; }
        public string Anio { get; set; }
        public decimal CapacidadEnero { get; set; }
        public decimal CapacidadFebrero { get; set; }
        public decimal CapacidadMarzo { get; set; }
        public decimal CapacidadAbril { get; set; }
        public decimal CapacidadMayo { get; set; }
        public decimal CapacidadJunio { get; set; }
        public decimal CapacidadJulio { get; set; }
        public decimal CapacidadAgosto { get; set; }
        public decimal CapacidadSeptiembre { get; set; }
        public decimal CapacidadOctubre { get; set; }
        public decimal CapacidadNoviembre { get; set; }
        public decimal CapacidadDiciembre { get; set; }
        public DateTime FechaRegistro { get; set; }
        public long SecLog { get; set; }

        public SerieHidrologica() { }

        public SerieHidrologica(DataRow dataRow)
        {
            PkSerieHidrologica = GetValor<long>(dataRow[C_PK_SERIE_HIDROLOGICA]);
            FkProyecto = GetValor<long>(dataRow[C_FK_PROYECTO]);
            Anio = GetValor<string>(dataRow[C_ANIO]);
            CapacidadEnero = GetValor<decimal>(dataRow[C_CAPACIDAD_ENERO]);
            CapacidadFebrero = GetValor<decimal>(dataRow[C_CAPACIDAD_FEBRERO]);
            CapacidadMarzo = GetValor<decimal>(dataRow[C_CAPACIDAD_MARZO]);
            CapacidadAbril = GetValor<decimal>(dataRow[C_CAPACIDAD_ABRIL]);
            CapacidadMayo = GetValor<decimal>(dataRow[C_CAPACIDAD_MAYO]);
            CapacidadJunio = GetValor<decimal>(dataRow[C_CAPACIDAD_JUNIO]);
            CapacidadJulio = GetValor<decimal>(dataRow[C_CAPACIDAD_JULIO]);
            CapacidadAgosto = GetValor<decimal>(dataRow[C_CAPACIDAD_AGOSTO]);
            CapacidadSeptiembre = GetValor<decimal>(dataRow[C_CAPACIDAD_SEPTIEMBRE]);
            CapacidadOctubre = GetValor<decimal>(dataRow[C_CAPACIDAD_OCTUBRE]);
            CapacidadNoviembre = GetValor<decimal>(dataRow[C_CAPACIDAD_NOVIEMBRE]);
            CapacidadDiciembre = GetValor<decimal>(dataRow[C_CAPACIDAD_DICIEMBRE]);
            SecLog = GetValor<long>(dataRow[C_SEC_LOG]);
            FechaRegistro = GetValor<DateTime>(dataRow[C_FECHA_REGISTRO]);
        }

        public void Llenar(DataRow dataRow)
        {
            dataRow[C_PK_SERIE_HIDROLOGICA] = PkSerieHidrologica;
            dataRow[C_FK_PROYECTO] = FkProyecto;
            dataRow[C_ANIO] = Anio;
            dataRow[C_CAPACIDAD_ENERO] = CapacidadEnero;
            dataRow[C_CAPACIDAD_FEBRERO] = CapacidadFebrero;
            dataRow[C_CAPACIDAD_MARZO] = CapacidadMarzo;
            dataRow[C_CAPACIDAD_ABRIL] = CapacidadAbril;
            dataRow[C_CAPACIDAD_MAYO] = CapacidadMayo;
            dataRow[C_CAPACIDAD_JUNIO] = CapacidadJunio;
            dataRow[C_CAPACIDAD_JULIO] = CapacidadJulio;
            dataRow[C_CAPACIDAD_AGOSTO] = CapacidadAgosto;
            dataRow[C_CAPACIDAD_SEPTIEMBRE] = CapacidadSeptiembre;
            dataRow[C_CAPACIDAD_OCTUBRE] = CapacidadOctubre;
            dataRow[C_CAPACIDAD_NOVIEMBRE] = CapacidadNoviembre;
            dataRow[C_CAPACIDAD_DICIEMBRE] = CapacidadDiciembre;
            dataRow[C_SEC_LOG] = SecLog;
            dataRow[C_FECHA_REGISTRO] = FechaRegistro;
        }

        public override void Leer(DataRow dataRow)
        {
            PkSerieHidrologica = GetValor<long>(dataRow[C_PK_SERIE_HIDROLOGICA]);
            FkProyecto = GetValor<long>(dataRow[C_FK_PROYECTO]);
            Anio = GetValor<string>(dataRow[C_ANIO]);
            CapacidadEnero = GetValor<decimal>(dataRow[C_CAPACIDAD_ENERO]);
            CapacidadFebrero = GetValor<decimal>(dataRow[C_CAPACIDAD_FEBRERO]);
            CapacidadMarzo = GetValor<decimal>(dataRow[C_CAPACIDAD_MARZO]);
            CapacidadAbril = GetValor<decimal>(dataRow[C_CAPACIDAD_ABRIL]);
            CapacidadMayo = GetValor<decimal>(dataRow[C_CAPACIDAD_MAYO]);
            CapacidadJunio = GetValor<decimal>(dataRow[C_CAPACIDAD_JUNIO]);
            CapacidadJulio = GetValor<decimal>(dataRow[C_CAPACIDAD_JULIO]);
            CapacidadAgosto = GetValor<decimal>(dataRow[C_CAPACIDAD_AGOSTO]);
            CapacidadSeptiembre = GetValor<decimal>(dataRow[C_CAPACIDAD_SEPTIEMBRE]);
            CapacidadOctubre = GetValor<decimal>(dataRow[C_CAPACIDAD_OCTUBRE]);
            CapacidadNoviembre = GetValor<decimal>(dataRow[C_CAPACIDAD_NOVIEMBRE]);
            CapacidadDiciembre = GetValor<decimal>(dataRow[C_CAPACIDAD_DICIEMBRE]);
            SecLog = GetValor<long>(dataRow[C_SEC_LOG]);
            FechaRegistro = GetValor<DateTime>(dataRow[C_FECHA_REGISTRO]);
        }
    }

    public interface ISerieHidrologicaMgr
    {
        void Guardar(SerieHidrologica obj);
        DataTable GetTabla();
        BindingList<SerieHidrologica> GetLista();
    }
}
