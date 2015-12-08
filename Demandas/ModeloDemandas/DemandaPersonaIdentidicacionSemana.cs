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
    public class DemandaPersonaIdentidicacionSemana : ObjetoDeNegocio
    {
        public const string NOMBRE_TABLA = "F_DM_DEM_PERSONA_IDENT_SEMANA";

        public const string C_PK_DEM_PERSONA_IDENT_SEMANA = "PK_DEM_PERSONA_IDENT_SEMANA";
        public const string C_D_COD_DIA_SEMANA = "D_COD_DIA_SEMANA";
        public const string C_HORA_1 = "HORA_1";
        public const string C_HORA_2 = "HORA_2";
        public const string C_HORA_3 = "HORA_3";
        public const string C_HORA_4 = "HORA_4";
        public const string C_HORA_5 = "HORA_5";
        public const string C_HORA_6 = "HORA_6";
        public const string C_HORA_7 = "HORA_7";
        public const string C_HORA_8 = "HORA_8";
        public const string C_HORA_9 = "HORA_9";
        public const string C_HORA_10 = "HORA_10";
        public const string C_HORA_11 = "HORA_11";
        public const string C_HORA_12 = "HORA_12";
        public const string C_HORA_13 = "HORA_13";
        public const string C_HORA_14 = "HORA_14";
        public const string C_HORA_15 = "HORA_15";
        public const string C_HORA_16 = "HORA_16";
        public const string C_HORA_17 = "HORA_17";
        public const string C_HORA_18 = "HORA_18";
        public const string C_HORA_19 = "HORA_19";
        public const string C_HORA_20 = "HORA_20";
        public const string C_HORA_21 = "HORA_21";
        public const string C_HORA_22 = "HORA_22";
        public const string C_HORA_23 = "HORA_23";
        public const string C_HORA_24 = "HORA_24";
        public const string C_FK_PERSONA = "FK_PERSONA";
        public const string C_SEC_LOG = "SEC_LOG";
        public const string C_D_COD_CATEGORIA_DATO = "D_COD_CATEGORIA_DATO";

        public long PkDemPersonaIdentSemana { get; set; }
        public long DCodDiaSemana { get; set; }
        public decimal Hora1 { get; set; }
        public decimal Hora2 { get; set; }
        public decimal Hora3 { get; set; }
        public decimal Hora4 { get; set; }
        public decimal Hora5 { get; set; }
        public decimal Hora6 { get; set; }
        public decimal Hora7 { get; set; }
        public double Hora8 { get; set; }
        public decimal Hora9 { get; set; }
        public double Hora10 { get; set; }
        public double Hora11 { get; set; }
        public double Hora12 { get; set; }
        public double Hora13 { get; set; }
        public double Hora14 { get; set; }
        public double Hora15 { get; set; }
        public double Hora16 { get; set; }
        public double Hora17 { get; set; }
        public double Hora18 { get; set; }
        public double Hora19 { get; set; }
        public double Hora20 { get; set; }
        public double Hora21 { get; set; }
        public double Hora22 { get; set; }
        public double Hora23 { get; set; }
        public double Hora24 { get; set; }
        public long FkPersona { get; set; }
        public long SecLog { get; set; }
        public long DCodCategoriaDato { get; set; }

        public DemandaPersonaIdentidicacionSemana() { }

        public DemandaPersonaIdentidicacionSemana(DataRow dataRow)
        {
            PkDemPersonaIdentSemana = GetValor<long>(dataRow[C_PK_DEM_PERSONA_IDENT_SEMANA]);
            DCodDiaSemana = GetValor<long>(dataRow[C_D_COD_DIA_SEMANA]);
            Hora1 = GetValor<decimal>(dataRow[C_HORA_1]);
            Hora2 = GetValor<decimal>(dataRow[C_HORA_2]);
            Hora3 = GetValor<decimal>(dataRow[C_HORA_3]);
            Hora4 = GetValor<decimal>(dataRow[C_HORA_4]);
            Hora5 = GetValor<decimal>(dataRow[C_HORA_5]);
            Hora6 = GetValor<decimal>(dataRow[C_HORA_6]);
            Hora7 = GetValor<decimal>(dataRow[C_HORA_7]);
            Hora8 = GetValor<double>(dataRow[C_HORA_8]);
            Hora9 = GetValor<decimal>(dataRow[C_HORA_9]);
            Hora10 = GetValor<double>(dataRow[C_HORA_10]);
            Hora11 = GetValor<double>(dataRow[C_HORA_11]);
            Hora12 = GetValor<double>(dataRow[C_HORA_12]);
            Hora13 = GetValor<double>(dataRow[C_HORA_13]);
            Hora14 = GetValor<double>(dataRow[C_HORA_14]);
            Hora15 = GetValor<double>(dataRow[C_HORA_15]);
            Hora16 = GetValor<double>(dataRow[C_HORA_16]);
            Hora17 = GetValor<double>(dataRow[C_HORA_17]);
            Hora18 = GetValor<double>(dataRow[C_HORA_18]);
            Hora19 = GetValor<double>(dataRow[C_HORA_19]);
            Hora20 = GetValor<double>(dataRow[C_HORA_20]);
            Hora21 = GetValor<double>(dataRow[C_HORA_21]);
            Hora22 = GetValor<double>(dataRow[C_HORA_22]);
            Hora23 = GetValor<double>(dataRow[C_HORA_23]);
            Hora24 = GetValor<double>(dataRow[C_HORA_24]);
            FkPersona = GetValor<long>(dataRow[C_FK_PERSONA]);
            SecLog = GetValor<long>(dataRow[C_SEC_LOG]);
            DCodCategoriaDato = GetValor<long>(dataRow[C_D_COD_CATEGORIA_DATO]);
        }

        public void Llenar(DataRow dataRow)
        {
            dataRow[C_PK_DEM_PERSONA_IDENT_SEMANA] = PkDemPersonaIdentSemana;
            dataRow[C_D_COD_DIA_SEMANA] = DCodDiaSemana;
            dataRow[C_HORA_1] = Hora1;
            dataRow[C_HORA_2] = Hora2;
            dataRow[C_HORA_3] = Hora3;
            dataRow[C_HORA_4] = Hora4;
            dataRow[C_HORA_5] = Hora5;
            dataRow[C_HORA_6] = Hora6;
            dataRow[C_HORA_7] = Hora7;
            dataRow[C_HORA_8] = Hora8;
            dataRow[C_HORA_9] = Hora9;
            dataRow[C_HORA_10] = Hora10;
            dataRow[C_HORA_11] = Hora11;
            dataRow[C_HORA_12] = Hora12;
            dataRow[C_HORA_13] = Hora13;
            dataRow[C_HORA_14] = Hora14;
            dataRow[C_HORA_15] = Hora15;
            dataRow[C_HORA_16] = Hora16;
            dataRow[C_HORA_17] = Hora17;
            dataRow[C_HORA_18] = Hora18;
            dataRow[C_HORA_19] = Hora19;
            dataRow[C_HORA_20] = Hora20;
            dataRow[C_HORA_21] = Hora21;
            dataRow[C_HORA_22] = Hora22;
            dataRow[C_HORA_23] = Hora23;
            dataRow[C_HORA_24] = Hora24;
            dataRow[C_FK_PERSONA] = FkPersona;
            dataRow[C_SEC_LOG] = SecLog;
            dataRow[C_D_COD_CATEGORIA_DATO] = DCodCategoriaDato;
        }

        public override void Leer(DataRow dataRow)
        {
            PkDemPersonaIdentSemana = GetValor<long>(dataRow[C_PK_DEM_PERSONA_IDENT_SEMANA]);
            DCodDiaSemana = GetValor<long>(dataRow[C_D_COD_DIA_SEMANA]);
            Hora1 = GetValor<decimal>(dataRow[C_HORA_1]);
            Hora2 = GetValor<decimal>(dataRow[C_HORA_2]);
            Hora3 = GetValor<decimal>(dataRow[C_HORA_3]);
            Hora4 = GetValor<decimal>(dataRow[C_HORA_4]);
            Hora5 = GetValor<decimal>(dataRow[C_HORA_5]);
            Hora6 = GetValor<decimal>(dataRow[C_HORA_6]);
            Hora7 = GetValor<decimal>(dataRow[C_HORA_7]);
            Hora8 = GetValor<double>(dataRow[C_HORA_8]);
            Hora9 = GetValor<decimal>(dataRow[C_HORA_9]);
            Hora10 = GetValor<double>(dataRow[C_HORA_10]);
            Hora11 = GetValor<double>(dataRow[C_HORA_11]);
            Hora12 = GetValor<double>(dataRow[C_HORA_12]);
            Hora13 = GetValor<double>(dataRow[C_HORA_13]);
            Hora14 = GetValor<double>(dataRow[C_HORA_14]);
            Hora15 = GetValor<double>(dataRow[C_HORA_15]);
            Hora16 = GetValor<double>(dataRow[C_HORA_16]);
            Hora17 = GetValor<double>(dataRow[C_HORA_17]);
            Hora18 = GetValor<double>(dataRow[C_HORA_18]);
            Hora19 = GetValor<double>(dataRow[C_HORA_19]);
            Hora20 = GetValor<double>(dataRow[C_HORA_20]);
            Hora21 = GetValor<double>(dataRow[C_HORA_21]);
            Hora22 = GetValor<double>(dataRow[C_HORA_22]);
            Hora23 = GetValor<double>(dataRow[C_HORA_23]);
            Hora24 = GetValor<double>(dataRow[C_HORA_24]);
            FkPersona = GetValor<long>(dataRow[C_FK_PERSONA]);
            SecLog = GetValor<long>(dataRow[C_SEC_LOG]);
            DCodCategoriaDato = GetValor<long>(dataRow[C_D_COD_CATEGORIA_DATO]);
        }

    }

    public interface IDemandaPersonaIdentidicacionSemanaMgr
    {
        void Guardar(DemandaPersonaIdentidicacionSemana obj);
        DataTable GetTabla();
        BindingList<DemandaPersonaIdentidicacionSemana> GetLista();
    }
}
