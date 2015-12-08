using System;
using System.Collections.Generic;
using System.Data;

namespace CNDC.Sincronizacion
{
    public class SincronizadorRegistroFallas : IEquatable<SincronizadorRegistroFallas>
    {
        public int PkCodFalla { get; set; }

        public long PkOrigenFalla { get; set; }

        public long PkDCodTipoInforme { get; set; }

        public long PSecLog { get; set; }

        public long PSincVer { get; set; }

        public SincronizadorRegistroFallas(int codFalla, long origenFalla, long tipoInforme, long secLog, long sincVer)
        {
            this.PkCodFalla = codFalla;
            this.PkOrigenFalla = origenFalla;
            this.PkDCodTipoInforme = tipoInforme;
            this.PSecLog = secLog;
            this.PSincVer = sincVer;
        }

        public SincronizadorRegistroFallas(DataRow row)
        {
            this.PkCodFalla = (int)row["PK_COD_FALLA"];
            this.PkOrigenFalla = (long)row["PK_ORIGEN_INFORME"];
            this.PkDCodTipoInforme = (long)row["PK_D_COD_TIPOINFORME"];
            this.PSecLog = (long)row["SEC_LOG"];
            this.PSincVer = (long)row["SINC_VER"];
        }

        public static List<SincronizadorRegistroFallas> GetLista(DataTable table)
        {
            List<SincronizadorRegistroFallas> list = new List<SincronizadorRegistroFallas>();
            foreach (DataRow row in (InternalDataCollectionBase)table.Rows)
                list.Add(new SincronizadorRegistroFallas(row));
            return list;
        }

        public bool Equals(SincronizadorRegistroFallas other)
        {
            if (other == null)
                return false;
            return this.PkCodFalla == other.PkCodFalla && this.PkOrigenFalla == other.PkOrigenFalla && (this.PkDCodTipoInforme == other.PkDCodTipoInforme && this.PSecLog == other.PSecLog) && this.PSincVer == other.PSincVer;
        }

        public override string ToString()
        {
            return string.Format("PkCodFalla :{0} ,PkOrigenFalla :{1} ,PkDCodTipoInforme :{2} ,PSecLog :{3} ,PSincVer:{4} ", (object)this.PkCodFalla, (object)this.PkOrigenFalla, (object)this.PkDCodTipoInforme, (object)this.PSecLog, (object)this.PSincVer);
        }
    }
}
