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
    public class GeneracionProbableEolicoSolar : ObjetoDeNegocio
    {
        public const string NOMBRE_TABLA = "F_PR_GEN_PROBABLE_EOLICO_SOLAR";

        public const string C_PK_GEN_PROBABLE_EOLICO_SOLAR = "PK_GEN_PROBABLE_EOLICO_SOLAR";
        public const string C_FK_PROYECTO = "FK_PROYECTO";
        public const string C_ANIO = "ANIO";
        public const string C_GENERACION_ENERO = "GENERACION_ENERO";
        public const string C_GENERACION_FEBRERO = "GENERACION_FEBRERO";
        public const string C_GENERACION_MARZO = "GENERACION_MARZO";
        public const string C_GENERACION_ABRIL = "GENERACION_ABRIL";
        public const string C_GENERACION_MAYO = "GENERACION_MAYO";
        public const string C_GENERACION_JUNIO = "GENERACION_JUNIO";
        public const string C_GENERACION_JULIO = "GENERACION_JULIO";
        public const string C_GENERACION_AGOSTO = "GENERACION_AGOSTO";
        public const string C_GENERACION_SEPTIEMBRE = "GENERACION_SEPTIEMBRE";
        public const string C_GENERACION_OCTUBRE = "GENERACION_OCTUBRE";
        public const string C_GENERACION_NOVIEMBRE = "GENERACION_NOVIEMBRE";
        public const string C_GENERACION_DICIEMBRE = "GENERACION_DICIEMBRE";
        public const string C_SEC_LOG = "SEC_LOG";

        public long PkGenProbableEolicoSolar { get; set; }
        public long FkProyecto { get; set; }
        public long Anio { get; set; }
        public decimal GeneracionEnero { get; set; }
        public decimal GeneracionFebrero { get; set; }
        public decimal GeneracionMarzo { get; set; }
        public decimal GeneracionAbril { get; set; }
        public decimal GeneracionMayo { get; set; }
        public decimal GeneracionJunio { get; set; }
        public decimal GeneracionJulio { get; set; }
        public decimal GeneracionAgosto { get; set; }
        public decimal GeneracionSeptiembre { get; set; }
        public decimal GeneracionOctubre { get; set; }
        public decimal GeneracionNoviembre { get; set; }
        public decimal GeneracionDiciembre { get; set; }
        public long SecLog { get; set; }

        public GeneracionProbableEolicoSolar() { }

        public GeneracionProbableEolicoSolar(DataRow dataRow)
        {
            PkGenProbableEolicoSolar = GetValor<long>(dataRow[C_PK_GEN_PROBABLE_EOLICO_SOLAR]);
            FkProyecto = GetValor<long>(dataRow[C_FK_PROYECTO]);
            Anio = GetValor<long>(dataRow[C_ANIO]);
            GeneracionEnero = GetValor<decimal>(dataRow[C_GENERACION_ENERO]);
            GeneracionFebrero = GetValor<decimal>(dataRow[C_GENERACION_FEBRERO]);
            GeneracionMarzo = GetValor<decimal>(dataRow[C_GENERACION_MARZO]);
            GeneracionAbril = GetValor<decimal>(dataRow[C_GENERACION_ABRIL]);
            GeneracionMayo = GetValor<decimal>(dataRow[C_GENERACION_MAYO]);
            GeneracionJunio = GetValor<decimal>(dataRow[C_GENERACION_JUNIO]);
            GeneracionJulio = GetValor<decimal>(dataRow[C_GENERACION_JULIO]);
            GeneracionAgosto = GetValor<decimal>(dataRow[C_GENERACION_AGOSTO]);
            GeneracionSeptiembre = GetValor<decimal>(dataRow[C_GENERACION_SEPTIEMBRE]);
            GeneracionOctubre = GetValor<decimal>(dataRow[C_GENERACION_OCTUBRE]);
            GeneracionNoviembre = GetValor<decimal>(dataRow[C_GENERACION_NOVIEMBRE]);
            GeneracionDiciembre = GetValor<decimal>(dataRow[C_GENERACION_DICIEMBRE]);
            SecLog = GetValor<long>(dataRow[C_SEC_LOG]);
        }

        public void Llenar(DataRow dataRow)
        {
            dataRow[C_PK_GEN_PROBABLE_EOLICO_SOLAR] = PkGenProbableEolicoSolar;
            dataRow[C_FK_PROYECTO] = FkProyecto;
            dataRow[C_ANIO] = Anio;
            dataRow[C_GENERACION_ENERO] = GeneracionEnero;
            dataRow[C_GENERACION_FEBRERO] = GeneracionFebrero;
            dataRow[C_GENERACION_MARZO] = GeneracionMarzo;
            dataRow[C_GENERACION_ABRIL] = GeneracionAbril;
            dataRow[C_GENERACION_MAYO] = GeneracionMayo;
            dataRow[C_GENERACION_JUNIO] = GeneracionJunio;
            dataRow[C_GENERACION_JULIO] = GeneracionJulio;
            dataRow[C_GENERACION_AGOSTO] = GeneracionAgosto;
            dataRow[C_GENERACION_SEPTIEMBRE] = GeneracionSeptiembre;
            dataRow[C_GENERACION_OCTUBRE] = GeneracionOctubre;
            dataRow[C_GENERACION_NOVIEMBRE] = GeneracionNoviembre;
            dataRow[C_GENERACION_DICIEMBRE] = GeneracionDiciembre;
            dataRow[C_SEC_LOG] = SecLog;
        }

        public override void Leer(DataRow dataRow)
        {
            PkGenProbableEolicoSolar = GetValor<long>(dataRow[C_PK_GEN_PROBABLE_EOLICO_SOLAR]);
            FkProyecto = GetValor<long>(dataRow[C_FK_PROYECTO]);
            Anio = GetValor<long>(dataRow[C_ANIO]);
            GeneracionEnero = GetValor<decimal>(dataRow[C_GENERACION_ENERO]);
            GeneracionFebrero = GetValor<decimal>(dataRow[C_GENERACION_FEBRERO]);
            GeneracionMarzo = GetValor<decimal>(dataRow[C_GENERACION_MARZO]);
            GeneracionAbril = GetValor<decimal>(dataRow[C_GENERACION_ABRIL]);
            GeneracionMayo = GetValor<decimal>(dataRow[C_GENERACION_MAYO]);
            GeneracionJunio = GetValor<decimal>(dataRow[C_GENERACION_JUNIO]);
            GeneracionJulio = GetValor<decimal>(dataRow[C_GENERACION_JULIO]);
            GeneracionAgosto = GetValor<decimal>(dataRow[C_GENERACION_AGOSTO]);
            GeneracionSeptiembre = GetValor<decimal>(dataRow[C_GENERACION_SEPTIEMBRE]);
            GeneracionOctubre = GetValor<decimal>(dataRow[C_GENERACION_OCTUBRE]);
            GeneracionNoviembre = GetValor<decimal>(dataRow[C_GENERACION_NOVIEMBRE]);
            GeneracionDiciembre = GetValor<decimal>(dataRow[C_GENERACION_DICIEMBRE]);
            SecLog = GetValor<long>(dataRow[C_SEC_LOG]);
        }
    }

    public interface IGeneracionProbableEolicoSolarMgr
    {
        void Guardar(GeneracionProbableEolicoSolar obj);
        DataTable GetTabla();
        BindingList<GeneracionProbableEolicoSolar> GetLista();
    }
}
