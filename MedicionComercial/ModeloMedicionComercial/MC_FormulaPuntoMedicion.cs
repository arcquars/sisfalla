using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.ComponentModel;
using CNDC.BLL;
using CNDC.UtilesComunes;

namespace MC
{
    [Serializable]
    public class MC_FormulaPuntoMedicion : ObjetoDeNegocio
    {
        public const string NOMBRE_TABLA = "F_MC_PTO_MED_FORMULA";

        public const string C_PK_COD_FORMULA = "PK_COD_FORMULA";
        public const string C_FK_COD_PUNTO_MEDICION = "FK_COD_PUNTO_MEDICION";
        public const string C_FK_COD_MAGNITUD_ELEC = "FK_COD_MAGNITUD_ELEC";
        public const string C_FORMULA = "FORMULA";
        public const string C_FECHA_INICIO = "FECHA_INICIO";
        public const string C_FECHA_FIN = "FECHA_FIN";
        public const string C_SEC_LOG = "SEC_LOG";

        public long PkCodFormula { get; set; }
        public long FkCodPuntoMedicion { get; set; }
        public long FkCodMagnitudElec { get; set; }
        public string Formula { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime? FechaFin { get; set; }
        public long SecLog { get; set; }

        public MC_FormulaPuntoMedicion() { }

        public MC_FormulaPuntoMedicion(DataRow dataRow)
        {
            PkCodFormula = GetValor<long>(dataRow[C_PK_COD_FORMULA]);
            FkCodPuntoMedicion = GetValor<long>(dataRow[C_FK_COD_PUNTO_MEDICION]);
            FkCodMagnitudElec = GetValor<long>(dataRow[C_FK_COD_MAGNITUD_ELEC]);
            Formula = GetValor<string>(dataRow[C_FORMULA]);
            FechaInicio = GetValor<DateTime>(dataRow[C_FECHA_INICIO]);
            FechaFin = GetValor<DateTime?>(dataRow[C_FECHA_FIN]);
            SecLog = GetValor<long>(dataRow[C_SEC_LOG]);
        }

        public void Llenar(DataRow dataRow)
        {
            dataRow[C_PK_COD_FORMULA] = PkCodFormula;
            dataRow[C_FK_COD_PUNTO_MEDICION] = FkCodPuntoMedicion;
            dataRow[C_FK_COD_MAGNITUD_ELEC] = FkCodMagnitudElec;
            dataRow[C_FORMULA] = Formula;
            dataRow[C_FECHA_INICIO] = FechaInicio;
            dataRow[C_FECHA_FIN] = FechaFin;
            dataRow[C_SEC_LOG] = SecLog;
        }
    }

    public interface IMC_FormulaPuntoMedicionMgr
    {
        void Guardar(MC_FormulaPuntoMedicion obj);
        DataTable GetTabla();
        BindingList<MC_FormulaPuntoMedicion> GetLista();
        DataTable GetFormulasPorCodPuntoMed(long p);

        List<MC_FormulaPuntoMedicion> GetFormulasPorCodPuntoMed(long codPuntoMedicion, DateTime desde, DateTime hasta);
    }

    public class MC_FormulaPuntoMedicionMgr
    {
        #region Singleton
        private static IMC_FormulaPuntoMedicionMgr _instancia;
        public static IMC_FormulaPuntoMedicionMgr Instancia
        {
            get { return _instancia; }
        }

        static MC_FormulaPuntoMedicionMgr()
        {
            _instancia = Instanciador.Instancia.IntanciarPlugin<IMC_FormulaPuntoMedicionMgr>();
        }

        #endregion Singleton
    }
}